// ***************************************************************************************
// 
//  Copyright © 2019-2023 dotFurther Inc. All rights reserved. 
//	 The software and associated documentation supplied hereunder are the proprietary 
//   information of dotFurther, inc., and are supplied subject to licence terms.
// 
// ***************************************************************************************
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using OpenDiscoverSDK;
using OpenDiscoverSDK.Interfaces;
using OpenDiscoverSDK.Interfaces.Content;
using OpenDiscoverSDK.Interfaces.Extractors;
using OpenDiscoverSDK.Interfaces.Metadata;

namespace ContentExtractionExample
{
    /// <summary>
    /// Class that demostrates how to use IArchiveExtractor and extracted ArchiveContent object to test and 
    /// extract archive items (files) to file system.
    /// </summary>
    public class ArchiveExtractorHelper
    {
        private Dictionary<string, int> _itemFilenameByCountDict = new Dictionary<string, int>(); // check against duplicate filenames with same path in archive
        private ArchiveContent    _archiveContent;
        private IArchiveExtractor _archiveExtractor;
        private IHostUI           _hostUI;
        private string            _rootOutputFolder;
        private long              _testedExpandSize;
        private long              _testedCompressionRatio;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="archiveContent"></param>
        /// <param name="archiveExtractor"></param>
        /// <param name="host"></param>
        public ArchiveExtractorHelper(ArchiveContent archiveContent, IArchiveExtractor archiveExtractor, IHostUI host)
        {
            _archiveContent   = archiveContent;
            _archiveExtractor = archiveExtractor;
            _hostUI           = host;
        }

        /// <summary>
        /// Total elapsed time to extract from archive [ms].
        /// </summary>
        public double TotalElapsedTimeMs { get; private set; }
        /// <summary>
        /// Total number of items extracted.
        /// </summary>
        public double TotalItemsExtracted { get; private set; }

        #region public void TestItems()
        /// <summary>
        /// Test archive items for actual expanded (de-compressed) size, actual compression ratio, and for any extraction errors 
        /// without expanding items into memory or saving to file system (e.g., ContentResult.CrcError, ContentResult.WrongPassword, etc).
        /// 
        /// ** To help protect against malicious archives the user should test the expanded size of archives before expanding archives. 
        ///    A malicous archive can have modified item headers that advertise much much smaller expanded size than the actual item
        ///    expanded size.
        /// </summary>
        public void TestItems()
        {
            _testedCompressionRatio = 0L;

            if (_archiveExtractor.IsSolid)
            {
                //================================================================================================================
                // Solid archive test:
                //================================================================================================================
                var stopWatch  = Stopwatch.StartNew();
                var testResult = _archiveExtractor.TestSolidBlockItems(ItemTestFinishedCallback, _archiveContent.Password);

                if (testResult == ContentResult.WrongPassword && _archiveExtractor.SupportsDecryption)
                {
                    string password;

                    while (_hostUI.RequestPassword(out password) == DialogResult.OK)
                    {
                        stopWatch.Restart();
                        testResult = _archiveExtractor.TestSolidBlockItems(ItemTestFinishedCallback, password);

                        if (testResult != ContentResult.WrongPassword)
                        {
                            break;
                        }
                    }
                }

                stopWatch.Stop();

                if (testResult == ContentResult.Ok)
                {
                    // Add these 2 user RESERVED metadata fields calculated from test results:
                    if (_archiveExtractor.Length > 0)
                    {
                        var testedCompressionRatio = (double)_testedExpandSize / _archiveExtractor.Length;
                       _archiveContent.Metadata[KnownDoubleMetadataFields.TestedCompressionRatio] = new DoubleProperty(testedCompressionRatio);
                    }
                    _archiveContent.Metadata[KnownInt64MetadataFields.TestedExpandedSize] = new Int64Property(_testedExpandSize);
                }

                if (testResult != ContentResult.Ok)
                {
                    _hostUI.ShowMessageBox(string.Format("Test unsuccessfully (result = {0}) completed in {1:F4} [sec]\n\nArchive total expanded size = {2:###,###,###,###} bytes",
                                           testResult.ToString(), stopWatch.Elapsed.TotalSeconds, _testedCompressionRatio), "Archive Test Results");
                }
                else
                {
                    _hostUI.ShowMessageBox(string.Format("Test successfully completed in {0:F4} [sec]\n\nArchive total expanded size = {1:###,###,###,###} bytes",
                                           stopWatch.Elapsed.TotalSeconds, _testedExpandSize), "Archive Test Results");
                }
            }
            else
            {
                //================================================================================================================
                // Non-solid archive test:
                //================================================================================================================
                var password = _archiveContent.Password; //Use archive level password as 1st guess (if it exists) for item passwords
                var totalElapsedSeconds = 0.0;

                foreach (var childDoc in _archiveContent.ChildDocuments)
                {
                    try
                    {
                        long testedSize = -1;

                        var stopWatch  = Stopwatch.StartNew();
                        var testResult = _archiveExtractor.TestItem((int)childDoc.Index, out testedSize, password);

                        if (testResult == ContentResult.WrongPassword)
                        {
                            // Keep prompting user for passwords until result is not ContentResult.WrongPassword or until user presses "Cancel" button.
                            while (_hostUI.RequestPassword(out password) == DialogResult.OK)
                            {
                                stopWatch.Reset();
                                testResult = _archiveExtractor.TestItem((int)childDoc.Index, out testedSize, password);

                                if (testResult != ContentResult.WrongPassword)
                                {
                                    break;
                                }
                            }
                        }

                        childDoc.TestedSize   = testedSize;
                        childDoc.TestedResult = testResult;

                        if (testedSize > 0)
                        {
                            _testedExpandSize += testedSize;
                        }

                        stopWatch.Stop();
                        totalElapsedSeconds += stopWatch.Elapsed.TotalSeconds;
                    }
                    catch
                    {
                        childDoc.TestedSize   = -1;
                        childDoc.TestedResult = ContentResult.DataError;
                    }
                }

                // Add these 2 user RESERVED metadata fields calculated from test results:
                if (_archiveExtractor.Length > 0)
                {
                    var testedCompressionRatio = (double)_testedExpandSize / _archiveExtractor.Length;
                    _archiveContent.Metadata[KnownDoubleMetadataFields.TestedCompressionRatio] = new DoubleProperty(testedCompressionRatio);
                }

                _archiveContent.Metadata[KnownInt64MetadataFields.TestedExpandedSize] = new Int64Property(_testedExpandSize);

                _hostUI.ShowMessageBox(string.Format("Test successfully completed in {0:F4} [sec]\n\nArchive total expanded size = {1:###,###,###,###} bytes", 
                                       totalElapsedSeconds, _testedExpandSize), "Archive Test Results");
            }
        }
        #endregion

        #region public void ExtractItemsToDirectory(string rootOutputPath)
        /// <summary>
        /// Extracts all archive items to a root output directory using archive folder structure (if any).
        /// </summary>
        /// <remarks>
        /// **WARNING**: Outputting items to the archive folder structure does not check for illegal item name or path characters or for long file paths 
        /// (i.e., paths greater than MAX_PATH), both which could cause an exception. It is left to user to write production level
        /// code to check for and replace illegal file system characters in mail store folder names and to also ensure that their 
        /// application can handle paths greater than MAX_PATH.
        /// </remarks>
        /// <param name="rootOutputPath">Root folder path to extract archive items.</param>
        /// <param name="passwords">Optional list of passwords to cycle through when encountering an encrypted archive item. Archives can have archive level passwords and/or
        /// different passwords for different items.</param>
        public void ExtractItemsToDirectory(string rootOutputPath)
        {
            var stopwatch = Stopwatch.StartNew();

            TotalItemsExtracted = 0;

            _rootOutputFolder = rootOutputPath;

            if (!Directory.Exists(_rootOutputFolder))
            {
                Directory.CreateDirectory(_rootOutputFolder);
            }

            var outputDirFiles = Directory.GetFiles(_rootOutputFolder);
            if (outputDirFiles != null && outputDirFiles.Length > 0)
            {
                // This is just an example, so will play it safe:
                _hostUI.LogMessage("Extraction aborted - there are existing files in output folder, select/create a folder with no existing files.");
                _hostUI.ShowMessageBox("Extraction aborted - there are existing files in output folder, select/create a folder with no existing files.", "Error");
                return;
            }

            //
            // Create archive directory structure first (if there is one) under input argument 'rootOutputPath':
            //
            if (_archiveContent.Root != null && _archiveContent.Root.SubFolders.Count > 0)
            {
                FileSystemHelper.CreateContainerFolderDirectoryHierarchy(_rootOutputFolder, _archiveContent.Root.SubFolders);
            }

            if (_archiveExtractor.IsSolid)
            {
                //================================================================================================================
                // Solid archive: The archive has 1 or more solid compressed blocks:
                //
                // Solid compressed archives are archives (e.g., 7z or Rar) where items are compressed together is pre-defined block sizes
                // in order to improve compression ratios. It is very very inefficient to randomly extract one item at a time from a solid compressed
                // archive block, especially if there are 100's to 1000's of items in that block. The way to extract from solid block archives 
                // shown here with callback delegates is the most efficient way:
                //================================================================================================================
                var blockItemResult = _archiveExtractor.ExtractSolidBlockItems(ItemGetStreamCallback, ItemFinishedCallback, _archiveContent.Password);

                if (blockItemResult == ContentResult.WrongPassword)
                {
                    var foundPassword = false;
                    string password;

                    // Keep prompting user for passwords until result is not ContentResult.WrongPassword or until user presses "Cancel" button
                    while (_hostUI.RequestPassword(out password) == DialogResult.OK)
                    {
                        blockItemResult = _archiveExtractor.ExtractSolidBlockItems(ItemGetStreamCallback, ItemFinishedCallback, password);

                        if (blockItemResult != ContentResult.WrongPassword)
                        {
                            foundPassword = true;
                            break;
                        }
                    }

                    if (!foundPassword)
                    {
                        _hostUI.LogMessage("Could not extract items from 'solid' archive - archive solid block is encrypted and no valid password was found.");
                        _hostUI.ShowMessageBox("Could not extract items from 'solid' archive - archive solid block is encrypted and no valid password was found.", "Error");
                    }
                }
            }
            else
            {
                //================================================================================================================
                // Non-solid archives:
                //================================================================================================================
                var password = _archiveContent.Password; // Use archive level password (if there is one) for 1st try at item level password 

                foreach (var childDoc in _archiveContent.ChildDocuments)
                {
                    try
                    {
                        if (string.IsNullOrWhiteSpace(childDoc.Name))
                        {
                            childDoc.Name = string.Format("item_{0}", childDoc.Index);
                        }

                        var filePath = Path.Combine(_rootOutputFolder, childDoc.ContainerRelativePath, childDoc.Name);

                        //
                        // Check for duplicate file paths and if found rename filename with like Windows does for duplicate files, e.g., "filename (2).ext"
                        // Some archive types can have duplicate named files in same directory, so this is a check for that:
                        //
                        FileSystemHelper.CheckForAndCorrectDuplicateItemFilePaths(_itemFilenameByCountDict, childDoc, ref filePath);

                        Stream stream = null;

                        try
                        {
                            stream = new FileStream(filePath, FileMode.CreateNew, FileAccess.ReadWrite); 

                            var itemExtractResult = _archiveExtractor.ExtractItem((int)childDoc.Index, stream, password);

                            if (itemExtractResult == ContentResult.Ok)
                            {
                                // Success
                                ++TotalItemsExtracted;
                                continue;
                            }
                            else if (itemExtractResult == ContentResult.WrongPassword)
                            {
                                var foundPassword = false;

                                // Keep prompting user for passwords until result is not ContentResult.WrongPassword or until user presses "Cancel" button
                                while (_hostUI.RequestPassword(out password) == DialogResult.OK)
                                {
                                    itemExtractResult = _archiveExtractor.ExtractItem((int)childDoc.Index, stream, password);

                                    if (itemExtractResult != ContentResult.WrongPassword)
                                    {
                                        foundPassword = true;
                                        break;
                                    }
                                }

                                if (foundPassword)
                                {
                                    ++TotalItemsExtracted;
                                    continue;
                                }
                                else
                                {
                                    // Set item file format identification:
                                    childDoc.FormatId = DocumentIdentifier.ContainerUnextractableResult;
                                    _hostUI.LogMessage(string.Format("Could not extract item #{0} from archive - archive item is encrypted and no valid password was found.", childDoc.Index));
                                }
                            }
                            else
                            {
                                // Some level of error has occured:
                                if (itemExtractResult == ContentResult.DataError && stream != null && (stream.Length >= (long)(0.5*childDoc.Size) && stream.Length <= (long)(1.1* childDoc.Size)))
                                {
                                    // We have a data error but also have at least the expanded size of data extracted from archive - attempt to process this data if 
                                    // expanded stream is not too much larger than item's 'Size' property. 
                                    ++TotalItemsExtracted;
                                    continue;
                                }
                                else
                                {
                                    childDoc.FormatId = DocumentIdentifier.ContainerUnextractableResult;
                                    var msg = string.Format("Could not extract item #{0} from archive - item error = '{1}'", childDoc.Index, itemExtractResult.ToString());
                                    _hostUI.LogMessage(msg);
                                }
                            }
                        }
                        finally
                        {
                            if (stream != null)
                            {
                                stream.Dispose();
                            }
                        }
                    }
                    catch 
                    {
                        childDoc.FormatId = DocumentIdentifier.ContainerUnextractableResult;
                    }
                }
            }

            stopwatch.Stop();
            TotalElapsedTimeMs = stopwatch.Elapsed.TotalMilliseconds;
        }
        #endregion

        //
        // 'Solid' archive callback methods:
        //
        #region private void ItemTestFinishedCallback(int index, long testedSize, ContentResult testResult)
        private void ItemTestFinishedCallback(int index, long testedSize, ContentResult testResult)
        {
            _archiveContent.ChildDocuments[index].TestedSize   = testedSize;
            _archiveContent.ChildDocuments[index].TestedResult = testResult;

            if (testedSize > 0)
            {
                _testedExpandSize += testedSize;
            }
        }
        #endregion

        #region private void ItemGetStreamCallback(int index, out Stream stream)
        /// <summary>
        /// Solid archive item requests a stream to write extracted item's data.
        /// </summary>
        /// <param name="index">The zero-offset archive child item index.</param>
        /// <param name="stream">The stream to be provided for extracted data.</param>
        private void ItemGetStreamCallback(int index, out Stream stream)
        {
            // This delegate requests a stream to which to extract the archive item. It can be a MemoryStream or FileStream depending
            // on your needs, however, pay attention to the extracted size of the item (ChildDocument.Size) to determine if you want to 
            // or even can extract to a MemoryStream:
            ChildDocument childDoc = null;

            try
            {
                stream   = null;
                childDoc = _archiveContent.ChildDocuments[index];

                if (string.IsNullOrWhiteSpace(childDoc.Name))
                {
                    // Give the item a name based on index if it does not have one:
                    childDoc.Name = string.Format("item_{0}", childDoc.Index);
                }

                var filePath = Path.Combine(_rootOutputFolder, childDoc.ContainerRelativePath, childDoc.Name);

                //
                // Check for duplicate file paths and if found rename filename with like Windows does for duplicate files, e.g., "filename (2).ext"
                // Some archive types can have duplicate named files in same directory, so this is a check for that:
                //
                FileSystemHelper.CheckForAndCorrectDuplicateItemFilePaths(_itemFilenameByCountDict, childDoc, ref filePath);

                // Return an open file stream:
                stream = new FileStream(filePath, FileMode.CreateNew, FileAccess.ReadWrite); 
            }
            catch 
            {
                stream = null;
                if (childDoc != null)
                {
                    childDoc.FormatId = DocumentIdentifier.ContainerUnextractableResult;
                }
            }
        }
        #endregion

        #region private void ItemFinishedCallback(int index, ContentResult result, Stream stream)
        /// <summary>
        /// Solid archive item extraction to stream finished.
        /// </summary>
        /// <param name="index">The zero-offset archive child item index.</param>
        /// <param name="result">Archive item extraction result.</param>
        /// <param name="stream">The stream provided by a previous call to method ItemGetStreamCallback.</param>
        private void ItemFinishedCallback(int index, ContentResult result, Stream stream)
        {
            var childDoc = _archiveContent.ChildDocuments[index];

            try
            {
                if (result != ContentResult.Ok)
                {
                    if (result == ContentResult.DataError && stream != null && stream.Length >= childDoc.Size)
                    {
                        // We have a data error but also have at least the expanded size of data extracted from archive - attempt to process this data.
                        _hostUI.LogMessage(string.Format("Archive item #{0}, had non-'Ok' ContentResult = {1}, but had expanded size bytes (Size) extracted.", index, result));
                    }
                    else
                    {
                        _hostUI.LogMessage(string.Format("Archive item #{0}, had non-'Ok' ContentResult = {1}.", index, result));
                    }
                }

                // If we were extracting items into memory using a MemoryStream for in-memory processing, we could get extracted item bytes from MemoryStream.ToArray() method,
                // but AFTER first setting stream position to 0 (MemoryStream.Position = 0)

                var fileStream = stream as FileStream;

                // Close the file stream - it will contain the archive item extracted data:
                if (fileStream != null)
                {
                    fileStream.Dispose();
                    fileStream = null;
                    ++TotalItemsExtracted;
                }
                else
                {
                    childDoc.FormatId = DocumentIdentifier.ContainerUnextractableResult;
                }
            }
            catch 
            {
                // Error extracting item from its parent archive container:
                childDoc.FormatId = DocumentIdentifier.ContainerUnextractableResult;
            }
        }
        #endregion
    }
}
