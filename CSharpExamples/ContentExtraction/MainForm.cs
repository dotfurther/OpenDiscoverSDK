﻿// ***************************************************************************************
// 
//  Copyright © 2019-2025 dotFurther Inc. All rights reserved. 
//	 The software and associated documentation supplied hereunder are the proprietary 
//   information of dotFurther, inc., and are supplied subject to licence terms.
// 
// ***************************************************************************************
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.Versioning;
using System.Text;
using System.Windows.Forms;
using ContentExtractionExample.Content;
using OpenDiscoverSDK;
using OpenDiscoverSDK.Interfaces;
using OpenDiscoverSDK.Interfaces.Content;
using OpenDiscoverSDK.Interfaces.Extractors;
using OpenDiscoverSDK.Interfaces.Settings;

namespace ContentExtractionExample
{
    public partial class MainForm : Form, IHostUI
    {
        private IdResult _docIdResult;
        private DocumentContent _docContent;
        private IContentExtractor _contentExtractorBase;
        private ContentView _contentView;
        private ArchiveView _archiveView;
        private MailStoreView _mailStoreView;
        private int _numLogMessages;
        private Stream _stream;
        private string[] _passwords;
        private Stream[] _splitSegmentStreamsInOrder;
        private ContentExtractionSettings _extractionSettings = new ContentExtractionSettings();

        #region internal enum ViewMode
        internal enum ViewMode
        {
            Hex = 0,
            Structure = 1,
            MultiSelectedDocHex = 2
        }
        #endregion

        #region internal class FileItem
        internal class FileItem
        {
            public FileItem(FileInfo fInfo)
            {
                Filename = fInfo.Name;
                Path = fInfo.FullName;
            }

            public string Filename { get; set; }
            public string Path { get; set; }
        }
        #endregion

        #region public class ListViewColumnSorter : IComparer
        /// <summary>
        /// This class is an implementation of the 'IComparer' interface.
        /// </summary>
        public class ListViewColumnSorter : IComparer
        {
            /// <summary>
            /// Specifies the column to be sorted
            /// </summary>
            private int ColumnToSort;
            /// <summary>
            /// Specifies the order in which to sort (i.e. 'Ascending').
            /// </summary>
            private SortOrder OrderOfSort;
            /// <summary>
            /// Case insensitive comparer object
            /// </summary>
            private CaseInsensitiveComparer ObjectCompare;

            /// <summary>
            /// Class constructor.  Initializes various elements
            /// </summary>
            public ListViewColumnSorter()
            {
                // Initialize the column to '0'
                ColumnToSort = 0;

                // Initialize the sort order to 'none'
                OrderOfSort = SortOrder.None;

                // Initialize the CaseInsensitiveComparer object
                ObjectCompare = new CaseInsensitiveComparer();
            }

            /// <summary>
            /// This method is inherited from the IComparer interface.  It compares the two objects passed using a case insensitive comparison.
            /// </summary>
            /// <param name="x">First object to be compared</param>
            /// <param name="y">Second object to be compared</param>
            /// <returns>The result of the comparison. "0" if equal, negative if 'x' is less than 'y' and positive if 'x' is greater than 'y'</returns>
            public int Compare(object x, object y)
            {
                int compareResult;
                ListViewItem listviewX, listviewY;

                // Cast the objects to be compared to ListViewItem objects
                listviewX = (ListViewItem)x;
                listviewY = (ListViewItem)y;

                // Compare the two items
                compareResult = ObjectCompare.Compare(listviewX.SubItems[ColumnToSort].Text, listviewY.SubItems[ColumnToSort].Text);

                // Calculate correct return value based on object comparison
                if (OrderOfSort == SortOrder.Ascending)
                {
                    // Ascending sort is selected, return normal result of compare operation
                    return compareResult;
                }
                else if (OrderOfSort == SortOrder.Descending)
                {
                    // Descending sort is selected, return negative result of compare operation
                    return (-compareResult);
                }
                else
                {
                    // Return '0' to indicate they are equal
                    return 0;
                }
            }

            /// <summary>
            /// Gets or sets the number of the column to which to apply the sorting operation (Defaults to '0').
            /// </summary>
            public int SortColumn
            {
                set
                {
                    ColumnToSort = value;
                }
                get
                {
                    return ColumnToSort;
                }
            }

            /// <summary>
            /// Gets or sets the order of sorting to apply (for example, 'Ascending' or 'Descending').
            /// </summary>
            public SortOrder Order
            {
                set
                {
                    OrderOfSort = value;
                }
                get
                {
                    return OrderOfSort;
                }
            }
        }
        #endregion


        #region Constructors...
        /// <summary>
        /// Constructors.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            //
            // Set application title with Open Discover SDK Version and Framework Version:
            //
            var openDiscoverSDKVersion = "unknown";
            var names = Assembly.GetExecutingAssembly().GetReferencedAssemblies();
            foreach (var name in names)
            {
                if (name.Name.StartsWith("OpenDiscoverSDK"))
                {
                    openDiscoverSDKVersion = name.Version.ToString();
                    break;
                }
            }

            var frameworkVer = Assembly.GetEntryAssembly()?.GetCustomAttribute<TargetFrameworkAttribute>()?.FrameworkName;
            Text = string.Format("{0}          OpenDiscoverSDK Version = {1}         Framework Version = {2}", Text, openDiscoverSDKVersion, frameworkVer != null ? frameworkVer : "Unknown");

            _contentView = new ContentView(this);
            _contentView.Dock = DockStyle.Fill;

            _archiveView = new ArchiveView(this);
            _archiveView.Dock = DockStyle.Fill;
            _archiveView.Visible = false;

            _mailStoreView = new MailStoreView(this);
            _mailStoreView.Dock = DockStyle.Fill;
            _mailStoreView.Visible = false;

            _contentTabPage.Controls.Add(_contentView);
            _contentTabPage.Controls.Add(_archiveView);
            _contentTabPage.Controls.Add(_mailStoreView);

            //==============================================================
            // Initialize ExtractionSettings controls with default values:
            //==============================================================
            _extractionTypeComboBox.SelectedIndex = (int)_extractionSettings.ExtractionType;          // ExtractionType.TextAndMetadata
            _embeddedObjExtractionComboBox.SelectedIndex = (int)_extractionSettings.EmbeddedObjectExtraction;// EmbeddedExtractionType.EmbeddedDocumentsAndMedia

            //
            // PdfDocument controls:
            //
            _pdfImageExtractionComboBox.SelectedIndex = (int)_extractionSettings.PdfDocument.ImageExtraction; // PdfImageExtraction.None
            _pdfPageExtractedTextCriteriaComboBox.SelectedIndex = 1; // 1 char

            //
            // LanguageId controls:
            //
            _identifyLangInExtractedTextCheckBox.Checked = _extractionSettings.LanguageId.IdentifyLanguages; // true
            _maxLanguageIdCharactersComboBox.SelectedIndex = 6; //500,000 chars
            _partitionLatinScriptRegionsCheckBox.Checked = _extractionSettings.LanguageId.PartitionLatinScriptRegions; // false
            _latinScriptRegionSizeComboBox.SelectedIndex = 5; //1,000 chars, but above line disables partitioning

            //
            // TimeZoneAndEmail controls:
            //
            _selectedTimeZoneComboBox.DataSource = TimeZoneInfo.GetSystemTimeZones();
            _selectedTimeZoneComboBox.DisplayMember = "DisplayName";
            _selectedTimeZoneComboBox.SelectedItem = TimeZoneInfo.Utc;

            _selectedEmailDateFormatComboBox.DataSource = new List<string>()
                {
                    "MonthDayYearTime  (EX: 6/15/2009 8:46 PM)",
                    "FullDateShortTime (EX: Monday, June 15, 2009 8:45 PM)",
                    "YearMonthDayTime  (EX: 2009/06/15 8:46 PM)",
                    "RFC1123  (EX: Thu, 10 Apr 2008 13:30:00 GMT)",
                };

            _selectedTimeZoneComboBox.SelectedItem = _extractionSettings.TimeZoneAndEmail.CollectionTimeZone;// TimeZoneInfo.Utc;
            _selectedEmailDateFormatComboBox.SelectedIndex = (int)_extractionSettings.TimeZoneAndEmail.EmailDateTimeFormat;   // EmailDateTimeFormat.MonthDayYearTime
            _showUtcOffsetForTimeCheckBox.Checked = _extractionSettings.TimeZoneAndEmail.ShowUtcOffsetForTime;
            _extractAllKnownOutlookMAPIPropertiesCheckBox.Checked = _extractionSettings.TimeZoneAndEmail.ExtractAllKnownOutlookMAPIProperties;

            //
            // Entity Extraction Check:
            //
            _enablePiiItemsCheckCheckBox.Checked = _extractionSettings.EntityExtractionSettings.Enabled;
            _dedupEntityItemsCheckBox.Checked = _extractionSettings.EntityExtractionSettings.DeduplicateEntityItems;
            _enableEmojiEntityDetectionCheckBox.Checked = _extractionSettings.EntityExtractionSettings.EnableEmojiEntityDetection;
            _enablePersonNameFinderCheckBox.Checked = _extractionSettings.EntityExtractionSettings.EnablePersonNameFinder;
            _enableEntityPersonNameChecksInBinaryToTextCheckBox.Checked = _extractionSettings.EntityExtractionSettings.EnablePersonNameFinderInBinaryToText;

            _customSensitiveItemCheckBox.Checked = _extractionSettings.EntityExtractionSettings.CustomEntityExtractionEnabled;

            _extractionSettings.EntityExtractionSettings.DeduplicateEntityItems = false;

            //
            // UnsupportedFiltering controls:
            //
            _filteringTypeComboBox.SelectedIndex = (int)_extractionSettings.UnsupportedFiltering.FilteringType;  //FilteringType.Unsupported
            _filterMinWordLengthComboBox.SelectedIndex = _extractionSettings.UnsupportedFiltering.FilterMinWordLength - 1; // 1 char 
            _largeUnsupportedMaxFilteredCharsComboBox.SelectedIndex = 2; //3M filtered chars max

            //
            // Hashing controls:
            //
            _hashingTypeComboBox.SelectedIndex = (int)_extractionSettings.Hashing.HashingType;
            _maxBinaryHashLengthComboBox.SelectedIndex = 0; // -1, no hashing byte limit


            _largeDocumentCriteraComboBox.SelectedIndex = 0; //50 MB
        }
        #endregion


        //
        // IHostUI implementation:
        //
        #region public void LogMessage(string message)
        public void LogMessage(string message)
        {
            _logTabPage.Text = string.Format("Log ({0})", ++_numLogMessages);
            _logTextBox.AppendText(message);
            _logTextBox.AppendText("\r\n");
            _logTextBox.SelectionStart = _logTextBox.TextLength;
            _logTextBox.ScrollToCaret();
        }
        #endregion

        #region public void ShowMessageBox(string message, string caption)
        public void ShowMessageBox(string message, string caption)
        {
            if (!string.IsNullOrWhiteSpace(caption))
            {
                MessageBox.Show(message, caption);
            }
            else
            {
                MessageBox.Show(message);
            }
        }
        #endregion

        #region public DialogResult RequestPassword(out string password)
        public DialogResult RequestPassword(out string password)
        {
            var passwordDialog = new PasswordForm();
            var result = passwordDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                password = passwordDialog.Password;
            }
            else
            {
                password = null;
            }

            return result;
        }
        #endregion

        #region public void ShowBusy(bool isBusy)
        public void ShowBusy(bool isBusy)
        {
            UseWaitCursor = isBusy;
            Enabled = !isBusy;
        }
        #endregion


        //
        // Extract document content:
        //
        #region private void ExtractContent(string fileName)
        /// <summary>
        /// This method does the following:
        /// 1) Uses SDK class DocumentIdentifier to identifiy the file format of the document (file)
        /// 2) Uses the file identity from (1) with SDK ContentExtractorFactory to extract the document's content.
        /// 3) Based upon the format of the file, display extracted content results in a specific user control. 
        ///    Archives and mail stores have a different user control that allows container item extraction testing.
        /// </summary>
        /// <param name="filePath"></param>
        private void ExtractContent(string filePath)
        {
            try
            {
                //
                // Disposes open stream from previous document:
                //
                if (_stream != null)
                {
                    _stream.Dispose();
                    _stream = null;
                }

                if (_contentExtractorBase != null)
                {
                    // Disposing of the content extractor is important for some database formats. In this case,
                    _contentExtractorBase.Dispose();
                    _contentExtractorBase = null;
                }

                if (_splitSegmentStreamsInOrder != null)
                {
                    foreach (var stream in _splitSegmentStreamsInOrder)
                    {
                        if (stream != null)
                        {
                            try
                            {
                                stream.Dispose();
                            }
                            catch { }
                        }
                    }
                    _splitSegmentStreamsInOrder = null;
                }

                //
                // Read selected document into MemoryStream if under 100MB, otherwise open FileStream:
                //
                var stopWatch = Stopwatch.StartNew();
                var fInfo = new FileInfo(filePath);

                _stream = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                stopWatch.Stop();
                var loadTime = stopWatch.Elapsed.TotalMilliseconds;

                _docContent = null;
                _archiveView.ClearView();
                _contentView.ClearView();

                //========================================================================================
                // Set ContentExtractionSettings with UI selected values:
                //========================================================================================
                UpdateExtractionSettings();

                //========================================================================================
                // 1) Identify document file format:
                //========================================================================================
                stopWatch.Restart();

                _docIdResult = DocumentIdentifier.Identify(_stream, filePath);

                stopWatch.Stop();
                var fileIdTime = stopWatch.Elapsed.TotalMilliseconds;

                //========================================================================================
                // 2) Extract content from document:
                //========================================================================================
                ContentExtractorType extractorType = ContentExtractorType.Document;
                stopWatch.Restart();

                //
                // Get Content Extractor for identified file format type:
                //
                var contentExtractorResult = ContentExtractorFactory.GetContentExtractor(_stream, _docIdResult, filePath, _extractionSettings);

                if (contentExtractorResult.HasError)
                {
                    LogMessage(string.Format("Error getting content extractor for file ID {0}: {1}", _docIdResult.ID, contentExtractorResult.Error));
                    _contentView.UpdateContentView(_docContent, Path.GetFileName(filePath), _stream.Length, _contentExtractorBase);
                }
                else
                {
                    extractorType = contentExtractorResult.ContentExtractor.ContentExtractorType;
                    _contentExtractorBase = contentExtractorResult.ContentExtractor;

                    switch (extractorType)
                    {
                        case ContentExtractorType.Archive:
                            #region Archive Extraction...
                            {
                                var archiveExtractor = (IArchiveExtractor)_contentExtractorBase;

                                if (archiveExtractor.IsSplit)
                                {
                                    // Detected that currently selected file is the main split segment for a split archive. Now we will use archive
                                    // extractor helper method 'GetSplitSegmentStreamsInOrder' to get the other split archive segments (in proper order) 
                                    // in the same directory:
                                    string[] splitSegmentNameInOrder = null;

                                    archiveExtractor.GetSplitSegmentStreamsInOrder(filePath, out _splitSegmentStreamsInOrder, out splitSegmentNameInOrder);

                                    _docContent = archiveExtractor.ExtractContent(_splitSegmentStreamsInOrder, splitSegmentNameInOrder);

                                    //
                                    // We have an archive level password (versus item level passwords):
                                    //
                                    if (_docContent.Result == ContentResult.WrongPassword)
                                    {
                                        string password;

                                        // We have an encrypted archive (archive level password) that is supported for decryption, keep prompting user for passwords 
                                        // until result is not ContentResult.WrongPassword or until user presses "Cancel" button:
                                        while (RequestPassword(out password) == DialogResult.OK)
                                        {
                                            _docContent = archiveExtractor.ExtractContent(_splitSegmentStreamsInOrder, splitSegmentNameInOrder, password);

                                            if (_docContent.Result != ContentResult.WrongPassword)
                                            {
                                                _docContent.Password = password; // Store the valid password
                                                break;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    _docContent = archiveExtractor.ExtractContent();

                                    //
                                    // We have an archive level password (versus item level passwords):
                                    //
                                    if (_docContent.Result == ContentResult.WrongPassword)
                                    {
                                        string password;

                                        // Keep prompting user for passwords until result is not ContentResult.WrongPassword or until user presses "Cancel" button
                                        while (RequestPassword(out password) == DialogResult.OK)
                                        {
                                            _docContent = archiveExtractor.ExtractContent(password);

                                            if (_docContent.Result != ContentResult.WrongPassword)
                                            {
                                                _docContent.Password = password; // Store the valid password
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                            #endregion
                            break;
                        case ContentExtractorType.Document:
                            #region Document Extraction...
                            {
                                var documentExtractor = (IDocumentContentExtractor)_contentExtractorBase;
                                _docContent = documentExtractor.ExtractContent();

                                // We have an encrypted document that is supported for decryption, keep prompting user for passwords until result is not 
                                // ContentResult.WrongPassword or until user presses "Cancel" button:
                                if (_docContent.Result == ContentResult.WrongPassword && _docContent.IsEncrypted && documentExtractor.SupportsDecryption)
                                {
                                    string password;

                                    while (RequestPassword(out password) == DialogResult.OK)
                                    {
                                        _docContent = documentExtractor.ExtractContent(password);

                                        if (_docContent.Result != ContentResult.WrongPassword)
                                        {
                                            _docContent.Password = password; // Store the valid password
                                            break;
                                        }
                                    }
                                }
                            }
                            #endregion
                            break;
                        case ContentExtractorType.MailStore:
                            #region MailStore Extraction...
                            {
                                var mailStoreExtractor = (IMailStoreExtractor)_contentExtractorBase;
                                _docContent = mailStoreExtractor.ExtractContent();
                            }
                            #endregion
                            break;
                        case ContentExtractorType.Database:
                            #region Database Extraction...
                            {
                                var databaseExtractor = (IDatabaseExtractor)_contentExtractorBase;

                                // The file path should always be passed as an argument for database formats, some formats can
                                // only be opened with a file path:
                                _docContent = databaseExtractor.ExtractContent(filePath);

                                // We have an encrypted document that is supported for decryption, keep prompting user for passwords until result is not 
                                // ContentResult.WrongPassword or until user presses "Cancel" button:
                                if (_docContent.Result == ContentResult.WrongPassword && _docContent.IsEncrypted && databaseExtractor.SupportsDecryption)
                                {
                                    string password;

                                    while (RequestPassword(out password) == DialogResult.OK)
                                    {
                                        _docContent = databaseExtractor.ExtractContent(filePath, password);

                                        if (_docContent.Result != ContentResult.WrongPassword)
                                        {
                                            _docContent.Password = password; // Store the valid password
                                            break;
                                        }
                                    }
                                }

                            }
                            #endregion
                            break;
                        case ContentExtractorType.DocumentStore:
                            #region DocumentStore Extraction...
                            {
                                var docStoreExtractor = (IDocumentStoreExtractor)_contentExtractorBase;
                                _docContent = docStoreExtractor.ExtractContent();
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
                                var unsupportedExtractor = (IUnsupportedExtractor)_contentExtractorBase;
                                _docContent = unsupportedExtractor.ExtractContent();
                            }
                            #endregion
                            break;
                        case ContentExtractorType.LargeUnsupported:
                            #region "Large" Unsupported/Unknown Type Extraction...
                            {
                                // We have a "large" unsupported/unknown file format. User should decide if they want to binary-to-text filter this document
                                // or not. And user should pay attention to size of the document. Do you want to hash and filter text from a unknown
                                // 100GB BLOB? Maybe you do if you are doing file forensics.
                                // This content extractor interface will do the following:
                                //   1) binary hash the file (if binary hashing is enabled). ContentExtractionSettings.Hashing.MaxBinaryHashLength property can
                                //      be set to hash just the first 'MaxBinaryHashLength' bytes of the BLOB (e.g., hash up to the 1st 4GB)
                                //   2) write the binary-to-text filtered text to either UTF16 or UTF8 to the supplied stream (the stream should be a 
                                //      FileStream (with because this document is "large"). 
                                //   3) If sensitive item detection *** is enabled, then will scan up to the first 100 million bytes for sensitive items and entities
                                //     (emoji entity detection is disabled for "large" unsupported/unknown binary blobs).
                                //
                                // ** For simplicity, this example uses a MemoryStream to simplify this example code, and because of this, we limit the maximum size
                                //    of the file we filter to < 200MB. 
                                //   
                                if (_stream.Length < 200 * 1024 * 1024)
                                {
                                    var largeUnsupporedExtractor = (ILargeUnsupportedExtractor)_contentExtractorBase;

                                    using (var textMemStream = new MemoryStream())
                                    {
                                        try
                                        {
                                            _extractionSettings.Hashing.MaxBinaryHashLength = 100 * 1024 * 1024; // limit hash to first 100 MB of bytes
                                            _docContent = largeUnsupporedExtractor.ExtractContent(textMemStream);
                                            textMemStream.Position = 0;

                                            if (_extractionSettings.UseLargeDocumentUTF16Encoding)
                                            {
                                                _docContent.ExtractedText = Encoding.Unicode.GetString(textMemStream.ToArray());

                                            }
                                            else
                                            {
                                                _docContent.ExtractedText = Encoding.UTF8.GetString(textMemStream.ToArray());
                                            }
                                        }
                                        finally
                                        {
                                            _extractionSettings.Hashing.MaxBinaryHashLength = -1; // Set back to hash all file bytes
                                        }
                                    }
                                }
                                else
                                {
                                    _docContent = new DocumentContent();
                                    _docContent.FormatId = _docIdResult;
                                    _docContent.Result = ContentResult.UnsupportedError; // 'Unsupported' for this test application since we are writting to MemoryStream instead of FileStream
                                    _docContent.ErrorMessage = "File too large for this C# example implementation.";
                                    LogMessage("ILargeUnsupportedExtractor - File too large for this C# example implementation");
                                }
                            }
                            #endregion
                            break;
                        case ContentExtractorType.LargeEncodedText:
                            #region "Large" Encoded Text File Extraction...
                            {
                                // We have a "large" encoded text file. If file is already in an easy to index encoding such as
                                // UTF16 or UTF8 (Id.TextUTF16 or Id.TextUTF8) then user should think about skipping over this content 
                                // extractor. 
                                // This content extractor interface will do the following:
                                //   1) binary hash the file (if binary hashing is enabled). ContentExtractionSettings.Hashing.MaxBinaryHashLength property can
                                //      be set to hash just the first 'MaxBinaryHashLength' bytes of the 'large' text file (e.g., hash up to the 1st 4GB)
                                //   2) write the encoded text to either UTF16 or UTF8 to the supplied stream (the stream should be a 
                                //      FileStream because this document is "large") 
                                //   3) If sensitive item detection is enabled, then will scan up to the first 200 million characters for sensitive items and entities.
                                //
                                // ** For simplicity, this example uses a MemoryStream to simplify the example code, and because of this, we limit the maximum size of the file 
                                //    to < 200MB. If file size is greater than 200 MB it is skipped. In a real application a FileStream should be used to save the re-encoded 
                                //    (to UTF/UTF16) text.
                                if (_stream.Length < 200 * 1024 * 1024)
                                {
                                    var largeEncodedExtractor = (ILargeEncodedTextExtractor)_contentExtractorBase;
                                    using (var textMemStream = new MemoryStream())
                                    {
                                        _docContent = largeEncodedExtractor.ExtractContent(textMemStream);
                                        textMemStream.Position = 0;

                                        if (_extractionSettings.UseLargeDocumentUTF16Encoding)
                                        {
                                            _docContent.ExtractedText = Encoding.Unicode.GetString(textMemStream.ToArray());

                                        }
                                        else
                                        {
                                            _docContent.ExtractedText = Encoding.UTF8.GetString(textMemStream.ToArray());
                                        }
                                    }
                                }
                                else
                                {
                                    _docContent = new DocumentContent();
                                    _docContent.FormatId = _docIdResult;
                                    _docContent.Result = ContentResult.UnsupportedError; // 'Unsupported' for this test application since we are writting to MemoryStream instead of FileStream
                                    _docContent.ErrorMessage = "File too large for this C# example implementation.";
                                    LogMessage("ILargeEncodedTextExtractor - File too large for this C# example implementation");
                                }
                            }
                            #endregion
                            break;
                    }
                }

                stopWatch.Stop();
                var extractTime = stopWatch.Elapsed.TotalMilliseconds;

                if (_docContent != null && _docContent.Result != ContentResult.Ok)
                {
                    LogMessage(string.Format("Filename = {0}", Path.GetFileName(filePath)));
                    LogMessage(string.Format("Content  = {0}", _docContent.Result));
                    LogMessage(string.Format("Error    = {0}", _docContent.ErrorMessage));
                    LogMessage(" ");
                }

                //
                // Set the appropriate content view for the file format:
                //
                switch (extractorType)
                {
                    case ContentExtractorType.Document:
                    case ContentExtractorType.Database:
                    case ContentExtractorType.DocumentStore:
                    case ContentExtractorType.Unsupported:
                    case ContentExtractorType.LargeUnsupported:
                    case ContentExtractorType.LargeEncodedText:
                        _contentView.Visible = true;
                        _archiveView.Visible = false;
                        _contentView.UpdateContentView(_docContent, Path.GetFileName(filePath), _stream.Length, _contentExtractorBase);
                        break;
                    case ContentExtractorType.Archive:
                        _contentView.Visible = false;
                        _archiveView.Visible = true;
                        _archiveView.UpdateContentView(_docContent as ArchiveContent, (IArchiveExtractor)_contentExtractorBase, Path.GetFileName(filePath), _stream.Length);
                        break;
                    case ContentExtractorType.MailStore:
                        _contentView.Visible = false;
                        _archiveView.Visible = false;
                        _mailStoreView.Visible = true;
                        _mailStoreView.UpdateContentView((MailStoreContent)_docContent, (IMailStoreExtractor)_contentExtractorBase, Path.GetFileName(filePath), _stream.Length);
                        break;
                }

                _filesListBox.Focus();

                //
                // Display identification and extraction metrics:
                //
                _toolStripStatusLabel.Text = string.Format("File loaded in {0:F2} [ms], File ID in {1:F2} [ms], Content Extracted in {2:F2} [ms]",
                                                           loadTime, fileIdTime, extractTime);
            }
            catch (Exception ex)
            {
                fileNameLabel.Text = string.Empty;
                if (ex.InnerException != null)
                {
                    LogMessage(string.Format("Load error: {0}, Inner Exception: {1}", ex.Message, ex.InnerException.Message));
                }
                else
                {
                    LogMessage(string.Format("Load error: {0}", ex.Message));
                }
                if (_stream != null)
                {
                    _stream.Dispose();
                    _stream = null;
                }
            }
        }
        #endregion

        #region private void UpdateExtractionSettings()
        /// <summary>
        /// Update ContentExtractionSettings object with user selected control values.
        /// </summary>
        private void UpdateExtractionSettings()
        {
            _extractionSettings.ExtractionType = (ExtractionType)_extractionTypeComboBox.SelectedIndex;
            _extractionSettings.EmbeddedObjectExtraction = (EmbeddedExtractionType)_embeddedObjExtractionComboBox.SelectedIndex;

            _extractionSettings.Hashing.HashingType = (HashingType)_hashingTypeComboBox.SelectedIndex;
            var maxHashLen = _maxBinaryHashLengthComboBox.Text.Substring(0, _maxBinaryHashLengthComboBox.Text.IndexOf('(')).Replace(",", "").Trim();
            _extractionSettings.Hashing.MaxBinaryHashLength = 100485760; //‬long.Parse(maxHashLen); 
            _extractionSettings.Hashing.CalculateFileEntropy = _calculateFileEntropyCheckBox.Checked;

            _extractionSettings.PdfDocument.ImageExtraction = (PdfImageExtraction)_pdfImageExtractionComboBox.SelectedIndex;
            _extractionSettings.PdfDocument.PageExtractedTextCriteria = int.Parse(_pdfPageExtractedTextCriteriaComboBox.Text);

            _extractionSettings.LanguageId.IdentifyLanguages = _identifyLangInExtractedTextCheckBox.Checked;
            _extractionSettings.LanguageId.MaxLanguageIdCharacters = int.Parse(_maxLanguageIdCharactersComboBox.Text);
            _extractionSettings.LanguageId.PartitionLatinScriptRegions = _partitionLatinScriptRegionsCheckBox.Checked;
            _extractionSettings.LanguageId.LatinScriptRegionPartitionSize = int.Parse(_latinScriptRegionSizeComboBox.Text);

            _extractionSettings.UnsupportedFiltering.FilteringType = (UnsupportedFilterType)_filteringTypeComboBox.SelectedIndex;
            _extractionSettings.UnsupportedFiltering.FilterMinWordLength = int.Parse(_filterMinWordLengthComboBox.Text);
            _extractionSettings.UnsupportedFiltering.LargeUnsupportedMaxFilteredChars = long.Parse(_largeUnsupportedMaxFilteredCharsComboBox.Text.Replace(",", "").Trim());

            _extractionSettings.TimeZoneAndEmail.CollectionTimeZone = (TimeZoneInfo)_selectedTimeZoneComboBox.SelectedItem;
            _extractionSettings.TimeZoneAndEmail.ApplyTimeZoneToMetadata = _setDateTimeUnspecifiedMetaToUtcCheckBox.Checked;
            _extractionSettings.TimeZoneAndEmail.EmailDateTimeFormat = (EmailDateTimeFormat)_selectedEmailDateFormatComboBox.SelectedIndex;
            _extractionSettings.TimeZoneAndEmail.ShowUtcOffsetForTime = _showUtcOffsetForTimeCheckBox.Checked;
            _extractionSettings.TimeZoneAndEmail.DisplayEmailRecipientNameAndSmtp = _displayEmailRecipientNameAndSmtpCheckBox.Checked;
            _extractionSettings.TimeZoneAndEmail.ExtractAllKnownOutlookMAPIProperties = _extractAllKnownOutlookMAPIPropertiesCheckBox.Checked;

            var largeDocCriteriaText = _largeDocumentCriteraComboBox.Text.Substring(0, _largeDocumentCriteraComboBox.Text.IndexOf('(')).Replace(",", "").Trim();
            _extractionSettings.LargeDocumentCritera = int.Parse(largeDocCriteriaText);
            _extractionSettings.UseLargeDocumentUTF16Encoding = _useLargeDocumentUTF16EncodingCheckBox.Checked;

            //
            // Entity Item Checks:
            //
            _sensitiveItemTabControl.Enabled = true;

            _extractionSettings.EntityExtractionSettings.Enabled = _enablePiiItemsCheckCheckBox.Checked;
            _extractionSettings.EntityExtractionSettings.DeduplicateEntityItems = _dedupEntityItemsCheckBox.Checked;
            _extractionSettings.EntityExtractionSettings.EnableEmojiEntityDetection = _enableEmojiEntityDetectionCheckBox.Checked;
            _extractionSettings.EntityExtractionSettings.CustomEntityExtractionEnabled = _customSensitiveItemCheckBox.Checked;
            _extractionSettings.EntityExtractionSettings.EnablePersonNameFinder = _enablePersonNameFinderCheckBox.Checked;
            _extractionSettings.EntityExtractionSettings.EnablePersonNameFinderInBinaryToText = _enableEntityPersonNameChecksInBinaryToTextCheckBox.Checked;


        }
        #endregion

        #region private void OpenFile(string filePath)
        private void OpenFile(string filePath)
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                _filesListBox.Items.Clear();

                //
                // Display any other files in the parent directory of the input file:
                //
                var dir = Path.GetDirectoryName(filePath);
                var files = Directory.GetFiles(dir);

                if (files != null)
                {
                    foreach (var file in files)
                    {
                        var fileItem = new FileItem(new FileInfo(file));
                        _filesListBox.Items.Add(fileItem);
                    }
                }

                fileNameLabel.Text = filePath;
                ExtractContent(filePath);
            }
        }
        #endregion


        //
        // UI Event Handlers:
        //
        #region private void openFileMenuItem_Click(object sender, EventArgs e)
        private void openFileMenuItem_Click(object sender, EventArgs e)
        {
            var openFileDlg = new OpenFileDialog();
            openFileDlg.DefaultExt = "*.*";
            openFileDlg.Multiselect = false;

            if (openFileDlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    OpenFile(openFileDlg.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading file: " + ex.Message, "Error..");
                }
            }
        }
        #endregion

        #region private void _filesListBox_SelectedIndexChanged(object sender, EventArgs e)
        private void _filesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var item = _filesListBox.SelectedItem as FileItem;

                if (item != null)
                {
                    fileNameLabel.Text = item.Path;
                    ExtractContent(item.Path);
                }
            }
            catch (Exception ex)
            {
                LogMessage(string.Format("Load error: {0}\n", ex.Message));
            }
        }
        #endregion

        #region private void loadPasswordsToolStripMenuItem_Click(object sender, EventArgs e)
        private void loadPasswordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openFileDlg = new OpenFileDialog();
            openFileDlg.Title = "Load Password List (1 password per line in text file)...";
            openFileDlg.DefaultExt = "*.*";
            openFileDlg.Multiselect = false;

            if (openFileDlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var passwordList = new List<string>();
                    var textLines = File.ReadLines(openFileDlg.FileName);
                    foreach (var line in textLines)
                    {
                        if (!string.IsNullOrWhiteSpace(line))
                        {
                            passwordList.Add(line.Trim());
                        }
                    }

                    _passwords = passwordList.ToArray();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading password file: " + ex.Message, "Error..");
                }
            }
        }
        #endregion

        #region private void _filesListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        private void _filesListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                var result = _filesListBox.SelectedItem as FileItem;
                if (result != null)
                {
                    Process.Start("explorer.exe", string.Format("/select,\"{0}\"", result.Path));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error", ex.Message);
            }
        }
        #endregion

        #region private void _extractionTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        private void _extractionTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var extractionType = (ExtractionType)_extractionTypeComboBox.SelectedIndex;

                switch (extractionType)
                {
                    case ExtractionType.TextAndMetadata:
                        EnableTabPageControls(_langIdTabPage, true);
                        EnableTabPageControls(_unsupportedTabPage, true);
                        EnableTabPageControls(_pdfTabPage, true);
                        _embeddedObjExtractionComboBox.Enabled = true;
                        _selectedEmailDateFormatComboBox.Enabled = true;
                        _showUtcOffsetForTimeCheckBox.Enabled = true;
                        _displayEmailRecipientNameAndSmtpCheckBox.Enabled = true;
                        break;
                    case ExtractionType.MetadataOnly:
                        EnableTabPageControls(_langIdTabPage, false);
                        EnableTabPageControls(_unsupportedTabPage, false);
                        EnableTabPageControls(_pdfTabPage, false);
                        _embeddedObjExtractionComboBox.Enabled = false;
                        _selectedEmailDateFormatComboBox.Enabled = false;
                        _showUtcOffsetForTimeCheckBox.Enabled = false;
                        _displayEmailRecipientNameAndSmtpCheckBox.Enabled = false;
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error", ex.Message);
            }
        }
        #endregion

        #region private void EnableTabPageControls(TabPage tabPage, bool enable)
        private void EnableTabPageControls(TabPage tabPage, bool enable)
        {
            foreach (Control ctl in tabPage.Controls)
            {
                ctl.Enabled = enable;
            }
        }
        #endregion

        #region private void _loadCustomSensitiveItemDefButton_Click(object sender, EventArgs e)
        private void _loadCustomSensitiveItemDefButton_Click(object sender, EventArgs e)
        {
            if (ContentExtractorFactory.CustomEntityDefinitionsLoaded)
            {
                MessageBox.Show("Custom entity definitions have already been loaded.", "Error");
                _loadCustomSensitiveItemDefButton.Enabled = false;
            }

            try
            {
                var items = CustomItemDefinitionHelper.LoadCustomEntityDefinitions();

                ContentExtractorFactory.LoadCustomEntityDefinitions(items);

                _numCustItemDefsLoadedLabel.Text = string.Format("{0} CustomEntityDefinitions loaded.", items.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        #endregion

        private void _UserMapiPropertyRequestsButton_Click(object sender, EventArgs e)
        {
            //TODO:
        }
    }
}
