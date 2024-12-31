// ***************************************************************************************
// 
//  Copyright © 2019-2025 dotFurther Inc. All rights reserved. 
//	 The software and associated documentation supplied hereunder are the proprietary 
//   information of dotFurther, inc., and are supplied subject to licence terms.
// 
// ***************************************************************************************
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
    /// Identifies a file and extracts document content, and returns this information as a DocumentContent object.
    /// </summary>
    /// <remarks>
    /// Note: DocumentContent is also the base class for HtmlDocumentContent, PdfDocumentContent, EmailDocumentContent,
    ///       MailStoreContent, and ArchiveContent classes. These DocumentContent derived classes hold extra content for 
    ///       their respective format types.
    /// </remarks>
    [Cmdlet(VerbsCommon.Get, "FileContent")]
    [OutputType(typeof(DocumentContent))]
    public class GetFileContentCmdlet : Cmdlet
    {
        static GetFileContentCmdlet()
        {
            Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

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
        /// Override
        /// </summary>
        protected override void ProcessRecord()
        {
            IdResult        idResult = null;
            DocumentContent content  = null;

            ContentExtractorType extractorType = ContentExtractorType.Document;

            using (var stream = File.OpenRead(Path))
            {
                idResult = DocumentIdentifier.Identify(stream, Path);

                //
                // Extract metadata content from document:
                //
                var settings = new ContentExtractionSettings();
                settings.ExtractionType                   = ExtractionType.TextAndMetadata;
                settings.EmbeddedObjectExtraction         = EmbeddedExtractionType.EmbeddedDocumentsAndMedia;
                settings.EntityExtractionSettings.Enabled = true; // Enable sensitive item checks
                settings.Hashing.HashingType              = HashingType.BinaryAndContentHash;
                settings.LargeDocumentCritera             = 100 * 1024 * 1024; // Define a 'large' file as >= 100MB (this determines when 
                                                                               // ContentExtractorType.LargeUnsupported and ContentExtractorType.LargeEncodedText
                                                                               // extractor interfaces are returned.

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
                                        // wrong password 
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
                                        // wrong password 
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

                                if (content.Result == ContentResult.WrongPassword)
                                {
                                    // wrong password 
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

                        case ContentExtractorType.Database:
                            #region Database Extraction...
                            {
                                // We will only get table/column info (individual table extracted text can be quite large):
                                var databaseExtractor = ((IDatabaseExtractor)contentExtractorResult.ContentExtractor);
                                content = databaseExtractor.ExtractContent(Path);
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

                        case ContentExtractorType.LargeUnsupported:
                            #region 'Large' Unsupported Type Extraction...
                            {
                                // Ignore for this example, very 'large' binary-to-text that needs a FileStream could be extracted
                                content        = new DocumentContent(idResult);
                                content.Result = ContentResult.UnsupportedError;
                                content.ErrorMessage = "Not supported for this example. Users should write output to a file stream when implemented";
                            }
                            #endregion
                            break;

                        case ContentExtractorType.LargeEncodedText:
                            #region 'Large' Encoded Text File Extraction...
                            {
                                // Ignore for this example 
                                content = new DocumentContent(idResult);
                                content.Result = ContentResult.UnsupportedError;
                                content.ErrorMessage = "Not supported for this example. Users should write output to a file stream when implemented";
                            }
                            #endregion
                            break;
                    }
                }
            }

            WriteObject(content);
        }
    }
}
