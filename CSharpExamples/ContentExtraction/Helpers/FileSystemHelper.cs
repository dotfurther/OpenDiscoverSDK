// ***************************************************************************************
// 
//  Copyright © 2019-2025 dotFurther Inc. All rights reserved. 
//	 The software and associated documentation supplied hereunder are the proprietary 
//   information of dotFurther, inc., and are supplied subject to licence terms.
// 
// ***************************************************************************************
using System.Collections.Generic;
using System.IO;
using OpenDiscoverSDK.Interfaces.Content;

namespace ContentExtractionExample
{
    /// <summary>
    /// Very simple file syestem helpers. 
    /// </summary>
    public class FileSystemHelper
    {
        #region public static void CreateContainerFolderDirectoryHierarchy(string rootFolder, List<ContainerFolder> subFolders)
        /// <summary>
        /// Creates the directory hierarchy given by an instance of an <see cref="ArchiveContent.Root"/> or <see cref="MailStoreContent.Root"/>
        /// and passing in the root folder's <see cref="ContainerFolder.SubFolders"/>.
        /// </summary>
        /// <remarks>
        /// **WARNING**: This method does not check for illegal path characters or for long file paths (i.e., paths greater than MAX_PATH), both which 
        /// could cause an exception.
        /// </remarks>
        /// <param name="rootFolder">The root folder path to extract the container folder hierarchy.</param>
        /// <param name="subFolders">
        /// On first call, the container root folder's (<see cref="ArchiveContent.Root"/> or <see cref="MailStoreContent.Root"/>) sub-folders given
        /// by <see cref="ContainerFolder.SubFolders"/>.
        /// </param>
        public static void CreateContainerFolderDirectoryHierarchy(string rootFolder, List<ContainerFolder> subFolders)
        {
            foreach (var folder in subFolders)
            {
                if (!string.IsNullOrWhiteSpace(folder.Path))
                {
                    // TODO: User should check for long file paths and illegal path characters

                    var fullFolderPath = Path.Combine(rootFolder, folder.Path);

                    if (!Directory.Exists(fullFolderPath))
                    {
                        Directory.CreateDirectory(fullFolderPath);
                    }
                }

                // Recursive call for sub-folders oft his folder:
                if (folder.SubFolders.Count > 0)
                {
                    CreateContainerFolderDirectoryHierarchy(rootFolder, folder.SubFolders);
                }
            }
        }
        #endregion

        #region public static void CheckForAndCorrectDuplicateItemFilePaths(ChildDocument childDoc, string filePath)
        /// <summary>
        /// Checks for potential duplicate container item names in extracted path. Ideally, we would want to check for
        /// illegal characters in the filename/file path and also long file paths. That will be left up to the user to 
        /// implement for production level code.
        /// </summary>
        /// <remarks>
        /// Some archive formats allow duplicate named files in same archive path - how this happens is by adding the same
        /// named file at a later date/time as an update. This method is an attempt to rename duplicate files like Windows
        /// does ("filename (##).ext", where (##) = 2,3,...,Number-of-duplicates).
        /// </remarks>
        /// <param name="itemFilenameByCountDict">A dictionary that stores item path as key and the count of total times this item path was used as value.</param>
        /// <param name="childDoc">The <see cref="ChildDocument"/> whose item name will be used as part of full item path.</param>
        /// <param name="itemFullPath">The folder path that this item will be eventually saved to.</param>
        public static void CheckForAndCorrectDuplicateItemFilePaths(Dictionary<string, int> itemFilenameByCountDict, ChildDocument childDoc, ref string itemFullPath)
        {
            if (itemFilenameByCountDict.TryGetValue(itemFullPath, out var count))
            {
                var folder        = Path.GetDirectoryName(itemFullPath);
                var extension     = Path.GetExtension(childDoc.Name);
                var nameWithNoExt = Path.GetFileNameWithoutExtension(childDoc.Name);
                itemFullPath      = Path.Combine(folder, string.Format("{0} ({1}){2}", nameWithNoExt, count, extension));
                itemFilenameByCountDict[itemFullPath] = ++count;
            }
            else
            {
                itemFilenameByCountDict[itemFullPath] = 1;
            }
        }
        #endregion
    }
}
