// ***************************************************************************************
// 
//  Copyright © 2019-2021 dotFurther Inc. All rights reserved. 
//	 The software and associated documentation supplied hereunder are the proprietary 
//   information of dotFurther, inc., and are supplied subject to licence terms.
// 
// ***************************************************************************************
using System;
using System.IO;
using System.Management.Automation;
using System.Text;
using OpenDiscoverSDK.Interfaces;
using OpenDiscoverSDK.Interfaces.Content;
using OpenDiscoverSDK.Interfaces.Extractors;
using OpenDiscoverSDK.Interfaces.Settings;

namespace OpenDiscoverSDK.PowerShell
{
    /// <summary>
    /// Displays the results of file identification and extracted document metadata, attributes, and hyperlinks for the
    /// document given by the 'Path' argument. If parameter 'ShowText' is true, will also display up to the first 1000
    /// characters of extracted text.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "FileInfo")]
    [OutputType(typeof(string))]
    public class GetFileInfoCmdlet : Cmdlet
    {
        /// <summary>
        /// Path to file.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline =true, HelpMessage ="Path to file")]
        public string Path { get; set; }
        /// <summary>
        /// Optional password to try for supported password protected formats.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = true, HelpMessage = "Optional password to try for supported password protected documents.")]
        public string Password { get; set; }
        /// <summary>
        /// If true, shows up to the first 1000 characters of extracted text (if any).
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = true, HelpMessage = "If true, shows up to the first 1000 characters of extracted text (if any) (valid for files that are not archives, mail stores, or unknown 'large' files)")]
        public bool ShowText { get; set; }

        /// <summary>
        /// Override
        /// </summary>
        protected override void ProcessRecord()
        {
            IdResult        idResult = null;
            DocumentContent content  = null;
            var strBuilder    = new StringBuilder();
            var extractorType = ContentExtractorType.Document;

            using (var stream = File.OpenRead(Path))
            {
                idResult = DocumentIdentifier.Identify(stream, Path);

                //
                // Content extraction settings:
                //
                var settings = new ContentExtractionSettings();
                settings.ExtractionType      = ExtractionType.TextAndMetadata;
                settings.Hashing.HashingType = HashingType.BinaryAndContentHash;
                settings.SensitiveItemCheck.Check = true;

                //
                // Get Content Extractor for identified file format type:
                //
                var contentExtractorResult = ContentExtractorFactory.GetContentExtractor(stream, idResult, Path, settings);

                if (contentExtractorResult.HasError)
                {
                    WriteObject("Error: " + contentExtractorResult.Error);
                    return;
                }
                else
                {
                    extractorType = contentExtractorResult.ContentExtractor.ContentExtractorType;

                    switch (extractorType)
                    {
                        case ContentExtractorType.Archive:
                            #region Archive Extraction...
                            {
                                var archiveExtractor = (IArchiveExtractor)contentExtractorResult.ContentExtractor;

                                if (archiveExtractor.IsSplit)
                                {
                                    // Detected that currently selected file is the main split segment for a split archive. Now we will use archive
                                    // extractor helper method 'GetSplitSegmentStreamsInOrder' to get the other split archive segments (in proper order) 
                                    // in the same directory:
                                    Stream[] splitSegmentStreamsInOrder = null;
                                    string[] splitSegmentNameInOrder = null;

                                    archiveExtractor.GetSplitSegmentStreamsInOrder(Path, out splitSegmentStreamsInOrder, out splitSegmentNameInOrder);

                                    content = archiveExtractor.ExtractContent(splitSegmentStreamsInOrder, splitSegmentNameInOrder, Password);

                                    //
                                    // We have an archive level password (versus item level passwords):
                                    //
                                    if (content.Result == ContentResult.WrongPassword)
                                    {
                                        if (!string.IsNullOrWhiteSpace(Password))
                                        {
                                            strBuilder.AppendLine("ERROR:  Wrong Password");
                                        }
                                        else
                                        {
                                            strBuilder.AppendLine("ERROR:  Archive requires a password");
                                        }
                                    }
                                }
                                else
                                {
                                    content = archiveExtractor.ExtractContent(Password);

                                    //
                                    // We have an archive level password (versus item level passwords):
                                    //
                                    if (content.Result == ContentResult.WrongPassword)
                                    {
                                        if (!string.IsNullOrWhiteSpace(Password))
                                        {
                                            strBuilder.AppendLine("ERROR:  Wrong Password");
                                        }
                                        else
                                        {
                                            strBuilder.AppendLine("ERROR:  Archive requires a password");
                                        }
                                    }
                                }
                            }
                            #endregion
                            break;
                        case ContentExtractorType.Document:
                            #region Document Extraction...
                            {
                                var docExtractor = ((IDocumentContentExtractor)contentExtractorResult.ContentExtractor);
                                content = docExtractor.ExtractContent();

                                // We have an encrypted document that is supported for decryption, keep prompting user for passwords until result is not 
                                // ContentResult.WrongPassword or until user presses "Cancel" button:
                                if (content.Result == ContentResult.WrongPassword && content.IsEncrypted && docExtractor.SupportsDecryption)
                                {
                                    if (!string.IsNullOrWhiteSpace(Password))
                                    {
                                        strBuilder.AppendLine("ERROR:  Wrong Password");
                                    }
                                    else
                                    {
                                        strBuilder.AppendLine("ERROR:  Document requires a password");
                                    }
                                }
                                else if (content.Result == ContentResult.WrongPassword && content.IsEncrypted && !docExtractor.SupportsDecryption)
                                {
                                    strBuilder.AppendLine("ERROR:  Document is encrypted with a password but format is not supported for decryption.");
                                }
                            }
                            #endregion
                            break;
                        case ContentExtractorType.MailStore:
                            #region MailStore Extraction...
                            {
                                var mailStoreExtractor = ((IMailStoreExtractor)contentExtractorResult.ContentExtractor);
                                content = mailStoreExtractor.ExtractContent();
                            }
                            #endregion
                            break;
                        case ContentExtractorType.DocumentStore:
                            #region DocumentStore Extraction...
                            {
                                var docExtractor = ((IDocumentContentExtractor)contentExtractorResult.ContentExtractor);
                                content = docExtractor.ExtractContent();
                            }
                            #endregion
                            break;
                        case ContentExtractorType.Unsupported:
                            #region Unsupported Type Extraction...
                            {
                                //
                                // Binary-to-text extraction: Note, if property ContentExtractionSettings.BinaryToTextOnUnsupportedTypes is false, then calling
                                //                            IUnsupportedExtractor.ExtractContent will only calculate binary hashes without performing binary-to-text.
                                //                            Binary-to-text is not useful for file formats that do not have any textual content (e.g., compressed archives or encrypted files) 
                                //                            It is up to the user to filter these formats out using either file format Id or file format classification.
                                //
                                var docExtractor = ((IUnsupportedExtractor)contentExtractorResult.ContentExtractor);
                                content = docExtractor.ExtractContent();
                            }
                            #endregion
                            break;
                        case ContentExtractorType.Database:
                            // Ignore for this example
                            break;
                        case ContentExtractorType.LargeUnsupported:
                            // Ignore for this example
                            break;
                        case ContentExtractorType.LargeEncodedText:
                            // Ignore for this example
                            break;
                    }
                }
            }

            strBuilder.AppendLine("File Format:");
            strBuilder.AppendLine("------------");
            strBuilder.AppendLine(string.Format("   ID:               {0}", idResult.ID.ToString()));
            strBuilder.AppendLine(string.Format("   Classification:   {0}", idResult.Classification.ToString()));
            strBuilder.AppendLine(string.Format("   MatchType:        {0}", idResult.MatchType.ToString()));
            strBuilder.AppendLine(string.Format("   Text Encoding ID: {0}", idResult.EncodingID.ToString()));
            strBuilder.AppendLine(string.Format("   IsEncrypted:      {0}", idResult.IsEncrypted.ToString()));
            strBuilder.AppendLine(string.Format("   MediaType:        {0}", idResult.MediaType.ToString()));
            strBuilder.AppendLine(string.Format("   Description:      {0}", idResult.Description.ToString()));

            if (content != null)
            {
                strBuilder.AppendLine();
                strBuilder.AppendLine("File Metadata:");
                strBuilder.AppendLine("---------------");

                foreach (var meta in content.Metadata)
                {
                    string value = "";
                    switch (meta.Value.PropertyType)
                    {
                        case PropertyType.Boolean:
                            value = ((BooleanProperty)meta.Value).Value.ToString();
                            break;
                        case PropertyType.DateTime:
                            value = ((DateTimeProperty)meta.Value).Value.ToString();
                            break;
                        case PropertyType.Double:
                            value = ((DoubleProperty)meta.Value).Value.ToString();
                            break;
                        case PropertyType.Int32:
                            value = ((Int32Property)meta.Value).Value.ToString();
                            break;
                        case PropertyType.Int64:
                            value = ((Int64Property)meta.Value).Value.ToString();
                            break;
                        case PropertyType.String:
                            value = ((StringProperty)meta.Value).Value;
                            break;
                        case PropertyType.BooleanList:
                            value = string.Join("; ", ((BooleanListProperty)meta.Value).Value);
                            break;
                        case PropertyType.DateTimeList:
                            value = string.Join("; ", ((DateTimeListProperty)meta.Value).Value);
                            break;
                        case PropertyType.DoubleList:
                            value = string.Join("; ", ((DoubleListProperty)meta.Value).Value);
                            break;
                        case PropertyType.Int32List:
                            value = string.Join("; ", ((Int32ListProperty)meta.Value).Value);
                            break;
                        case PropertyType.Int64List:
                            value = string.Join("; ", ((Int64ListProperty)meta.Value).Value);
                            break;
                        case PropertyType.StringList:
                            value = string.Join("; ", ((StringListProperty)meta.Value).Value);
                            break;
                    }

                    strBuilder.AppendLine(string.Format("   {0,-35} {1}", meta.Key, value));
                }

                strBuilder.AppendLine();
                strBuilder.AppendLine("Custom Metadata:");
                strBuilder.AppendLine("-----------------");

                foreach (var meta in content.CustomMetadata)
                {
                    string value = "";
                    switch (meta.Value.PropertyType)
                    {
                        case PropertyType.Boolean:
                            value = ((BooleanProperty)meta.Value).Value.ToString();
                            break;
                        case PropertyType.DateTime:
                            value = ((DateTimeProperty)meta.Value).Value.ToString();
                            break;
                        case PropertyType.Double:
                            value = ((DoubleProperty)meta.Value).Value.ToString();
                            break;
                        case PropertyType.Int32:
                            value = ((Int32Property)meta.Value).Value.ToString();
                            break;
                        case PropertyType.Int64:
                            value = ((Int64Property)meta.Value).Value.ToString();
                            break;
                        case PropertyType.String:
                            value = ((StringProperty)meta.Value).Value;
                            break;
                        case PropertyType.BooleanList:
                            value = string.Join("; ", ((BooleanListProperty)meta.Value).Value);
                            break;
                        case PropertyType.DateTimeList:
                            value = string.Join("; ", ((DateTimeListProperty)meta.Value).Value);
                            break;
                        case PropertyType.DoubleList:
                            value = string.Join("; ", ((DoubleListProperty)meta.Value).Value);
                            break;
                        case PropertyType.Int32List:
                            value = string.Join("; ", ((Int32ListProperty)meta.Value).Value);
                            break;
                        case PropertyType.Int64List:
                            value = string.Join("; ", ((Int64ListProperty)meta.Value).Value);
                            break;
                        case PropertyType.StringList:
                            value = string.Join("; ", ((StringListProperty)meta.Value).Value);
                            break;
                    }

                    strBuilder.AppendLine(string.Format("   {0,-35} {1}", meta.Key, value));
                }

                strBuilder.AppendLine();
                strBuilder.AppendLine("File Attributes:");
                strBuilder.AppendLine("----------------");
                if (content.Attributes.Count > 0)
                {
                    foreach (var attr in content.Attributes)
                    {
                        strBuilder.AppendLine(string.Format("   {0}", attr.ToString()));
                    }
                }

                strBuilder.AppendLine();
                strBuilder.AppendLine("File Hyperlinks:");
                strBuilder.AppendLine("----------------");
                if (content.HyperLinks.Count > 0)
                {
                    foreach (var link in content.HyperLinks)
                    {
                        strBuilder.AppendLine(string.Format("   {0}", link.Url));
                    }
                }
                strBuilder.AppendLine();

                strBuilder.AppendLine();
                strBuilder.AppendLine("Detected Sensitive Items:");
                strBuilder.AppendLine("-------------------------");
                if (content.SensitiveItemResult.Items.Count > 0)
                {
                    foreach (var item in content.SensitiveItemResult.Items)
                    {
                        strBuilder.AppendLine(string.Format("   {0,-30} {1,-20}  {2,-15}  {3}", item.ItemType.ToString(), item.MatchType.ToString(), item.LocationType.ToString(), item.Text));
                    }
                }
                strBuilder.AppendLine();


                strBuilder.AppendLine();
                strBuilder.AppendLine("Detected Languages:");
                strBuilder.AppendLine("-------------------");
                if (content.LanguageIdResults.Count > 0)
                {
                    foreach (var langIdResult in content.LanguageIdResults)
                    {
                        strBuilder.AppendLine(string.Format("   {0,-30} {1,-20}  {2,-15}", langIdResult.Language, langIdResult.LangIso639, langIdResult.PercentOfFullText));
                    }
                }
                strBuilder.AppendLine();

                if (ShowText)
                {
                    strBuilder.AppendLine();
                    if (content.ExtractedText != null)
                    {
                        var charsToDisplay = Math.Min(1000, content.ExtractedText.Length);
                        strBuilder.AppendLine(string.Format("Extracted Text: Total Chars = {0}, Displayed Chars = {1}", content.ExtractedText.Length, charsToDisplay));
                        strBuilder.AppendLine("-------------------------------------------------------------------");
                        strBuilder.AppendLine(content.ExtractedText.Substring(0, charsToDisplay));
                        strBuilder.AppendLine();
                    }
                    else
                    {
                        strBuilder.AppendLine(string.Format("Extracted Text: Total Chars = {0}, Displayed Chars = {1}", 0, 0));
                        strBuilder.AppendLine("-------------------------------------------------------------------");
                        strBuilder.AppendLine();
                    }
                }
            }

            WriteObject(strBuilder.ToString());
        }
    }
}
