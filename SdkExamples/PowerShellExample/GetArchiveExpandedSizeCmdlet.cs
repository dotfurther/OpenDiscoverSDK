
// UNDER CONSTRUCTION

// ***************************************************************************************
// 
//  Copyright © 2019-2020 dotFurther Inc. All rights reserved. 
//	 The software and associated documentation supplied hereunder are the proprietary 
//   information of dotFurther, inc., and are supplied subject to licence terms.
// 
// ***************************************************************************************
/*
using System.IO;
using System.Management.Automation;
using System.Text;
using OpenDiscoverSDK.Interfaces;
using OpenDiscoverSDK.Interfaces.Content;
using OpenDiscoverSDK.Interfaces.Settings;

namespace OpenDiscoverSDK.PowerShell
{
    /// <summary>
    /// Tests an archive for true expanded size and true compression ratio.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "ArchiveExpandedSize")]
    [OutputType(typeof(string))]
    public class GetArchiveExpandedSizeCmdlet : Cmdlet
    {
        private ArchiveContent    _archiveContent;
        private IArchiveExtractor _archiveExtractor;
        private long              _testedExpandSize;
        private long              _testedCompressionRatio;

        /// <summary>
        /// Path to file.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline =true, HelpMessage ="Path to file")]
        public string Path { get; set; }
        /// <summary>
        /// Optional password to try for supported password protected documents.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = true, HelpMessage = "Optional password to try for supported password protected documents.")]
        public string Password { get; set; }

        /// <summary>
        /// Override
        /// </summary>
        protected override void ProcessRecord()
        {
            IdResult idResult = null;
            var strBuilder = new StringBuilder();

            using (var stream = File.OpenRead(Path))
            {
                idResult = DocumentIdentifier.Identify(stream, Path);

                switch (idResult.ID)
                {
                    case Id.Archive7ZipSplitSegment:
                    case Id.ArchiveRarSplitSegment:
                    case Id.ArchiveRar5SplitSegment:
                    case Id.ArchiveZipSplitSegment:
                        WriteObject("Error: User selected an archive split segment that was not the main segment with end of central directory (main segement is usually last in Explorer view but sometimes first).");
                        return;
                }

                //
                // Extract metadata content from document:
                //
                var settings = new ContentExtractionSettings();
                settings.ExtractionType      = ExtractionType.TextAndMetadata;
                settings.Hashing.HashingType = HashingType.None;
                
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
                    var extractorType = contentExtractorResult.ContentExtractor.ContentExtractorType;

                    if (extractorType == ContentExtractorType.Archive)
                    {
                        _archiveExtractor = (IArchiveExtractor)contentExtractorResult.ContentExtractor;

                        if (_archiveExtractor.IsSplit)
                        {
                            // Detected that currently selected file is the main split segment (main multi-part) for a split archive. 
                            // Now we will use archive extractor helper method 'GetSplitSegmentStreamsInOrder' to get the other split 
                            // archive segments (in proper order) in the same directory:
                            Stream[] splitSegmentStreamsInOrder = null;
                            string[] splitSegmentNameInOrder = null;

                            _archiveExtractor.GetSplitSegmentStreamsInOrder(Path, out splitSegmentStreamsInOrder, out splitSegmentNameInOrder);

                            _archiveContent = _archiveExtractor.ExtractContent(splitSegmentStreamsInOrder, splitSegmentNameInOrder, Password);

                            //
                            // We have an archive level password (versus item level passwords):
                            //
                            if (_archiveContent.Result == ContentResult.WrongPassword)
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
                            _archiveContent = _archiveExtractor.ExtractContent(Password);

                            //
                            // We have an archive level password (versus item level passwords):
                            //
                            if (_archiveContent.Result == ContentResult.WrongPassword)
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
                    else if (extractorType == ContentExtractorType.Unsupported)
                    {
                        strBuilder.AppendLine(string.Format("ERROR: File format is an 'unsupported' format (ID={0}, Classification={1})", idResult.ID.ToString(), idResult.Classification.ToString()));
                        WriteObject(strBuilder.ToString());
                        return;
                    }
                    else
                    {
                        strBuilder.AppendLine(string.Format("ERROR: File is not an archive format (ID={0}, Classification={1})", idResult.ID.ToString(), idResult.Classification.ToString()));
                        WriteObject(strBuilder.ToString());
                        return;
                    }
                }
            }

            var hostInfoMsg = new HostInformationMessage();
            
            WriteObject(strBuilder.ToString());
        }
    }
}
*/