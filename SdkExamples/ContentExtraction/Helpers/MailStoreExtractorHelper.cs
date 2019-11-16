// ***************************************************************************************
// 
//  Copyright © 2019-2020 dotFurther Inc. All rights reserved. 
//	 The software and associated documentation supplied hereunder are the proprietary 
//   information of dotFurther, inc., and are supplied subject to licence terms.
// 
// ***************************************************************************************
using System.Diagnostics;
using System.IO;
using OpenDiscoverSDK;
using OpenDiscoverSDK.Interfaces;
using OpenDiscoverSDK.Interfaces.Content;

namespace ContentExtractionExample
{
    /// <summary>
    /// Helper class that uses an MailStoreContent object and associated IMailStoreExtractor to extract email objects from a mail store and save
    /// these emails items to file system.
    /// </summary>
    public class MailStoreExtractorHelper
    {
        private MailStoreContent    _mailStoreContent;
        private IMailStoreExtractor _mailStoreExtractor;
        private IHostUI         _messageLogger;

        public MailStoreExtractorHelper(MailStoreContent mailStoreContent, IMailStoreExtractor mailStoreExtractor, IHostUI messageLogger)
        {
            _mailStoreContent   = mailStoreContent;
            _mailStoreExtractor = mailStoreExtractor;
            _messageLogger      = messageLogger;
        }

        /// <summary>
        /// Total elapsed time to extract from archive [ms].
        /// </summary>
        public double TotalElapsedTimeMs { get; private set; }
        /// <summary>
        /// Total number of items extracted.
        /// </summary>
        public int TotalItemsExtracted { get; private set; }

        #region public void ExtractItemsToDirectory(string rootOutputPath, bool saveWithMailStoreFolderStructure = false)
        /// <summary>
        /// Extracts all mail store items to root output path using either (1) the mail store folder structure (see remarks for warning) 
        /// or (2) with a safer folder structure that outputs folders into root directory that contain at most 1000 message objects each
        /// and are named "1000", "2000", etc.
        /// </summary>
        /// <remarks>
        /// **WARNING**: Outputting mail store folder structure does not check for illegal path characters or for long file paths 
        /// (i.e., paths greater than MAX_PATH), both which could cause an exception. It is left to user to write production level
        /// code to check for and replace illegal file system characters in mail store folder names and to also ensure that their 
        /// application can handle paths greater than MAX_PATH.
        /// </remarks>
        /// <param name="rootOutputPath">Root folder path to extract archive items.</param>
        /// <param name="saveWithMailStoreFolderStructure">
        /// If true, recreates the container folder hierarchy of the mail store by appending container relative paths to 'rootOutputPath'
        /// and creating these directories and extracting the emails associated with the container relative paths to these directories.
        /// NOTE: This method does not check for long file paths (paths greater than MAX_PATH)
        /// </param>
        public void ExtractItemsToDirectory(string rootOutputPath, bool saveWithMailStoreFolderStructure = false)
        {
            var totalEmailMessagesWritten = 0;
            var stopwatch = Stopwatch.StartNew();

            if (!Directory.Exists(rootOutputPath))
            {
                Directory.CreateDirectory(rootOutputPath);
            }

            var subFolder     = 1000;
            var subFolderName = subFolder.ToString();
            var path          = Path.Combine(rootOutputPath, subFolderName);

            if (!saveWithMailStoreFolderStructure)
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
            }
            else if (_mailStoreContent.Root != null && _mailStoreContent.Root.SubFolders.Count > 0)
            {
                // We need to create the mail store "Root" directory 1st, all sub-folders and emails in mail store will have at least "Root" as part of their paths:
                var mailStoreRootPath = Path.Combine(rootOutputPath, _mailStoreContent.Root.DisplayName);
                if (!Directory.Exists(mailStoreRootPath))
                {
                    Directory.CreateDirectory(mailStoreRootPath);
                }

                FileSystemHelper.CreateContainerFolderDirectoryHierarchy(rootOutputPath, _mailStoreContent.Root.SubFolders);
            }


            ChildDocument childDocMsg;

            while ((childDocMsg = _mailStoreExtractor.GetNextMessage()) != null)
            {
                // Extracted child items from archives and mailstores are not automatically identified
                // like they are for document attachments/embedded items - we Id item here but nothing is
                // done with the Id:
                childDocMsg.FormatId = DocumentIdentifier.Identify(childDocMsg.DocumentBytes, null);

                var emailName = childDocMsg.EntryId;

                if (!string.IsNullOrWhiteSpace(childDocMsg.EntryId))
                {
                    var emailExt     = childDocMsg.FormatId.PrimaryExtension;
                    childDocMsg.Name = string.Format("{0}{1}", childDocMsg.EntryId, emailExt == null ? "" : emailExt);
                    emailName        = childDocMsg.Name;
                }

                if (string.IsNullOrWhiteSpace(emailName))
                {
                    emailName = childDocMsg.Name;
                    if (string.IsNullOrWhiteSpace(emailName))
                    {
                        var emailExt     = childDocMsg.FormatId.PrimaryExtension;
                        childDocMsg.Name = string.Format("{0}-{1}{2}", childDocMsg.Index + 1, childDocMsg.FormatId.ID.ToString(), emailExt == null ? "" : emailExt);
                        emailName        = childDocMsg.Name;
                    }
                }

                ++totalEmailMessagesWritten;

                if (saveWithMailStoreFolderStructure)
                {
                    path = Path.Combine(rootOutputPath, childDocMsg.ContainerRelativePath ?? "").Trim();
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    File.WriteAllBytes(System.IO.Path.Combine(path, emailName), childDocMsg.DocumentBytes);
                }
                else
                {
                    // Save to folders under "rootOutputPath' names '1000', '2000','3000', etc that each hold 1000 emails until
                    // there are no more email objects to save:
                    File.WriteAllBytes(System.IO.Path.Combine(path, emailName), childDocMsg.DocumentBytes);

                    // Limit 1000 message files per sub-folder:
                    if (totalEmailMessagesWritten % 1000 == 0)
                    {
                        subFolder     += 1000;
                        subFolderName = subFolder.ToString();
                        path          = Path.Combine(rootOutputPath, subFolderName);

                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                    }
                }

                childDocMsg.DocumentBytes = null;
            }

            stopwatch.Stop();
            TotalElapsedTimeMs  = stopwatch.Elapsed.TotalMilliseconds;
            TotalItemsExtracted = totalEmailMessagesWritten;
        }
        #endregion
    }
}
