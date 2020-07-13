// ***************************************************************************************
// 
//  Copyright © 2019-2020 dotFurther Inc. All rights reserved. 
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
using System.ServiceModel;
using System.Text;
using System.Windows.Forms;
using OpenDiscoverSDK;
using OpenDiscoverSDK.Interfaces;
using OpenDiscoverSDK.Interfaces.Content;
using OpenDiscoverSDK.Interfaces.Settings;
using SdkAPI.Common;

namespace SdkAPIWinFormClient
{
    public partial class MainForm : Form, IHostUI, ISdkAPIServiceCallback
    {
        private Process             _serviceHostProcess;
        private SdkAPIServiceProxy  _sdkAPIServiceProxy;
        private ContentView         _contentView;
        private ArchiveView         _archiveView;
        private MailStoreView       _mailStoreView;
        private string              _selectedFilePath;
        private long                _selectedFileLength;
        private int                 _numLogMessages;
        private Stopwatch           _stopWatch = new Stopwatch();
        private double              _fileIdTime;
        private ContentExtractionSettings  _extractionSettings   = new ContentExtractionSettings();

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
                Path     = fInfo.FullName;
            }

            public string Filename { get; set; }
            public string Path     { get; set; }
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

            Shown += MainForm_Shown;
            FormClosing += MainForm_FormClosing;
            _contentView      = new ContentView(this);
            _contentView.Dock = DockStyle.Fill;

            _archiveView         = new ArchiveView(this);
            _archiveView.Dock    = DockStyle.Fill;
            _archiveView.Visible = false;

            _mailStoreView         = new MailStoreView(this);
            _mailStoreView.Dock    = DockStyle.Fill;
            _mailStoreView.Visible = false;

            _contentTabPage.Controls.Add(_contentView);
            _contentTabPage.Controls.Add(_archiveView);
            _contentTabPage.Controls.Add(_mailStoreView);

            //==============================================================
            // Initialize ExtractionSettings controls with default values:
            //==============================================================
            _extractionTypeComboBox.SelectedIndex        = (int)_extractionSettings.ExtractionType;          // ExtractionType.TextAndMetadata
            _embeddedObjExtractionComboBox.SelectedIndex = (int)_extractionSettings.EmbeddedObjectExtraction;// EmbeddedExtractionType.EmbeddedDocumentsAndMedia

            //
            // PdfDocument controls:
            //
            _pdfImageExtractionComboBox.SelectedIndex = (int)_extractionSettings.PdfDocument.ImageExtraction; // PdfImageExtraction.None
            _pdfPageExtractedTextCriteriaComboBox.SelectedIndex = 1; // 1 char

            //
            // LanguageId controls:
            //
            _identifyLangInExtractedTextCheckBox.Checked   = _extractionSettings.LanguageId.IdentifyLanguages; // true
            _maxLanguageIdCharactersComboBox.SelectedIndex = 6; //500,000 chars
            _partitionLatinScriptRegionsCheckBox.Checked   = _extractionSettings.LanguageId.PartitionLatinScriptRegions; // false
            _latinScriptRegionSizeComboBox.SelectedIndex   = 5; //1,000 chars, but above line disables partitioning

            //
            // TimeZoneAndEmail controls:
            //
            _selectedTimeZoneComboBox.DataSource    = TimeZoneInfo.GetSystemTimeZones();
            _selectedTimeZoneComboBox.DisplayMember = "DisplayName";
            _selectedTimeZoneComboBox.SelectedItem  = TimeZoneInfo.Utc;

            _selectedEmailDateFormatComboBox.DataSource = new List<string>()
                {
                    "MonthDayYearTime  (EX: 6/15/2009 8:46 PM)",
                    "FullDateShortTime (EX: Monday, June 15, 2009 8:45 PM)",
                    "YearMonthDayTime  (EX: 2009/06/15 8:46 PM)",
                    "RFC1123  (EX: Thu, 10 Apr 2008 13:30:00 GMT)",
                };

            _selectedTimeZoneComboBox.SelectedItem         = _extractionSettings.TimeZoneAndEmail.CollectionTimeZone;// TimeZoneInfo.Utc;
            _selectedEmailDateFormatComboBox.SelectedIndex = (int)_extractionSettings.TimeZoneAndEmail.EmailDateTimeFormat;   // EmailDateTimeFormat.MonthDayYearTime
            _showUtcOffsetForTimeCheckBox.Checked          = _extractionSettings.TimeZoneAndEmail.ShowUtcOffsetForTime;

            //
            // UnsupportedFiltering controls:
            //
            _filteringTypeComboBox.SelectedIndex       = (int)_extractionSettings.UnsupportedFiltering.FilteringType;  //FilteringType.Unsupported
            _filterMinWordLengthComboBox.SelectedIndex = _extractionSettings.UnsupportedFiltering.FilterMinWordLength - 1; // 1 char 
            _largeUnsupportedMaxFilteredCharsComboBox.SelectedIndex = 2; //3M filtered chars max

            //
            // Sensitive Item Checks:
            //
            _socSecurityCheckBox.Checked         = _extractionSettings.SensitiveItemCheck.SocialSecurityCheck;
            _creditCardCheckBox.Checked          = _extractionSettings.SensitiveItemCheck.CreditCardCheck;
            _bankAccountCheckBox.Checked         = _extractionSettings.SensitiveItemCheck.BankAccountCheck;
            _ibanCheckBox.Checked                = _extractionSettings.SensitiveItemCheck.IBANAccountCheck;
            _investmentAccountCheckBox.Checked   = _extractionSettings.SensitiveItemCheck.InvestmentAccountCheck;
            _phoneNumberCheckBox.Checked         = _extractionSettings.SensitiveItemCheck.PhoneNumberCheck;
            _emailAddressCheckBox.Checked        = _extractionSettings.SensitiveItemCheck.EmailAddressCheck;
            _driversLicenseCheckBox.Checked      = _extractionSettings.SensitiveItemCheck.DriversLicenseCheck;
            _passportCheckBox.Checked            = _extractionSettings.SensitiveItemCheck.PassportCheck;
            _dateOfBirthCheckBox.Checked         = _extractionSettings.SensitiveItemCheck.DateOfBirthCheck;
            _maidenNameCheckBox.Checked          = _extractionSettings.SensitiveItemCheck.MaidenNameCheck;
            _socialMediaCheckBox.Checked         = _extractionSettings.SensitiveItemCheck.SocialMediaAccountCheck;
            _licensePlateNumCheckBox.Checked     = _extractionSettings.SensitiveItemCheck.LicensePlateNumberCheck;
            _vinCheckBox.Checked                 = _extractionSettings.SensitiveItemCheck.VehicleIdentificationNumberCheck;
            _healthCareNumberCheckBox.Checked    = _extractionSettings.SensitiveItemCheck.HealthCareNumberIdCheck;
            _addressCheckBox.Checked             = _extractionSettings.SensitiveItemCheck.AddressCheck;
            _ipv4CheckBox.Checked                = _extractionSettings.SensitiveItemCheck.IPv4AddressCheck;
            _passwordCheckBox4.Checked           = _extractionSettings.SensitiveItemCheck.PasswordCheck;
            _usernameCheckBox.Checked            = _extractionSettings.SensitiveItemCheck.UsernameCheck;
            _networkNameCheckBox.Checked         = _extractionSettings.SensitiveItemCheck.NetworkNameCheck;
            _databaseCredentialsCheckBox.Checked = _extractionSettings.SensitiveItemCheck.DatabaseCredentialsCheck;

            _generalAccountCheckBox.Checked    = _extractionSettings.SensitiveItemCheck.GeneralAccountCheck;
            _genIdentificationCheckBox.Checked = _extractionSettings.SensitiveItemCheck.GeneralIdentificationCheck;
            _generalUrlCheckBox.Checked        = _extractionSettings.SensitiveItemCheck.GeneralUrlCheck;

            _enableSensitiveItemsCheckCheckBox.Checked = _extractionSettings.SensitiveItemCheck.Check;

            //
            // Hashing controls:
            //
            _hashingTypeComboBox.SelectedIndex         = (int)_extractionSettings.Hashing.HashingType; // HashingType.BinaryAndContentHash
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
            Enabled       = !isBusy;
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
                UseWaitCursor = true;
                _filesListBox.Enabled = false;

                _archiveView.ClearView();
                _contentView.ClearView();

                //
                // Read selected document into MemoryStream if under 100MB, otherwise open FileStream:
                //
                var fInfo = new FileInfo(filePath);

                _selectedFileLength = fInfo.Length;

                //========================================================================================
                // Set ContentExtractionSettings with UI selected values:
                //========================================================================================
                UpdateExtractionSettings();

                //========================================================================================
                // 1) Identify document file format:
                //========================================================================================
                _stopWatch.Restart();

                var docIdResult = _sdkAPIServiceProxy.Identify(filePath);

                _stopWatch.Stop();
                _fileIdTime = _stopWatch.Elapsed.TotalMilliseconds;

                //========================================================================================
                // 2) Extract content from document:
                //========================================================================================
                _stopWatch.Restart();
                string password = null;

                _sdkAPIServiceProxy.ExtractContent(filePath, docIdResult, _extractionSettings, password);

                _filesListBox.Focus();
            }
            catch (Exception ex)
            {
                _filesListBox.Enabled = true;
                fileNameLabel.Text = String.Empty;
                LogMessage(string.Format("Service error: {0}", ex.Message));
            }
        }
        #endregion

        #region private void UpdateExtractionSettings()
        /// <summary>
        /// Update ContentExtractionSettings object with user selected control values.
        /// </summary>
        private void UpdateExtractionSettings()
        {
            _extractionSettings.ExtractionType           = (ExtractionType)_extractionTypeComboBox.SelectedIndex;
            _extractionSettings.EmbeddedObjectExtraction = (EmbeddedExtractionType)_embeddedObjExtractionComboBox.SelectedIndex;

            _extractionSettings.Hashing.HashingType = (HashingType)_hashingTypeComboBox.SelectedIndex;
            var maxHashLen = _maxBinaryHashLengthComboBox.Text.Substring(0, _maxBinaryHashLengthComboBox.Text.IndexOf('(')).Replace(",", "").Trim();
            _extractionSettings.Hashing.MaxBinaryHashLength  = int.Parse(maxHashLen);
            _extractionSettings.Hashing.CalculateFileEntropy = _calculateFileEntropyCheckBox.Checked;

            _extractionSettings.PdfDocument.ImageExtraction = (PdfImageExtraction)_pdfImageExtractionComboBox.SelectedIndex;
            _extractionSettings.PdfDocument.PageExtractedTextCriteria = int.Parse(_pdfPageExtractedTextCriteriaComboBox.Text);

            _extractionSettings.LanguageId.IdentifyLanguages              = _identifyLangInExtractedTextCheckBox.Checked;
            _extractionSettings.LanguageId.MaxLanguageIdCharacters        = int.Parse(_maxLanguageIdCharactersComboBox.Text);
            _extractionSettings.LanguageId.PartitionLatinScriptRegions    = _partitionLatinScriptRegionsCheckBox.Checked;
            _extractionSettings.LanguageId.LatinScriptRegionPartitionSize = int.Parse(_latinScriptRegionSizeComboBox.Text);

            _extractionSettings.UnsupportedFiltering.FilteringType       = (UnsupportedFilterType)_filteringTypeComboBox.SelectedIndex;
            _extractionSettings.UnsupportedFiltering.FilterMinWordLength = int.Parse(_filterMinWordLengthComboBox.Text);
            _extractionSettings.UnsupportedFiltering.LargeUnsupportedMaxFilteredChars = long.Parse(_largeUnsupportedMaxFilteredCharsComboBox.Text.Replace(",", "").Trim());

            _extractionSettings.TimeZoneAndEmail.CollectionTimeZone      = (TimeZoneInfo)_selectedTimeZoneComboBox.SelectedItem;
            _extractionSettings.TimeZoneAndEmail.ApplyTimeZoneToMetadata = _setDateTimeUnspecifiedMetaToUtcCheckBox.Checked;
            _extractionSettings.TimeZoneAndEmail.EmailDateTimeFormat     = (EmailDateTimeFormat)_selectedEmailDateFormatComboBox.SelectedIndex;
            _extractionSettings.TimeZoneAndEmail.ShowUtcOffsetForTime    = _showUtcOffsetForTimeCheckBox.Checked;
            _extractionSettings.TimeZoneAndEmail.DisplayEmailRecipientNameAndSmtp = _displayEmailRecipientNameAndSmtpCheckBox.Checked;

            var largeDocCriteriaText = _largeDocumentCriteraComboBox.Text.Substring(0, _largeDocumentCriteraComboBox.Text.IndexOf('(')).Replace(",", "").Trim();
            _extractionSettings.LargeDocumentCritera          = int.Parse(largeDocCriteriaText);
            _extractionSettings.UseLargeDocumentUTF16Encoding = _useLargeDocumentUTF16EncodingCheckBox.Checked;

            //
            // Sensitive Item Checks:
            //
            _extractionSettings.SensitiveItemCheck.SocialSecurityCheck        = _socSecurityCheckBox.Checked;
            _extractionSettings.SensitiveItemCheck.CreditCardCheck            = _creditCardCheckBox.Checked;
            _extractionSettings.SensitiveItemCheck.BankAccountCheck           = _bankAccountCheckBox.Checked;
            _extractionSettings.SensitiveItemCheck.IBANAccountCheck           = _ibanCheckBox.Checked;
            _extractionSettings.SensitiveItemCheck.InvestmentAccountCheck     = _investmentAccountCheckBox.Checked;
            _extractionSettings.SensitiveItemCheck.PhoneNumberCheck           = _phoneNumberCheckBox.Checked;
            _extractionSettings.SensitiveItemCheck.EmailAddressCheck          = _emailAddressCheckBox.Checked;
            _extractionSettings.SensitiveItemCheck.DriversLicenseCheck        = _driversLicenseCheckBox.Checked;
            _extractionSettings.SensitiveItemCheck.PassportCheck              = _passportCheckBox.Checked;
            _extractionSettings.SensitiveItemCheck.DateOfBirthCheck           = _dateOfBirthCheckBox.Checked;
            _extractionSettings.SensitiveItemCheck.MaidenNameCheck            = _maidenNameCheckBox.Checked;
            _extractionSettings.SensitiveItemCheck.SocialMediaAccountCheck    = _socialMediaCheckBox.Checked;
            _extractionSettings.SensitiveItemCheck.LicensePlateNumberCheck    = _licensePlateNumCheckBox.Checked;
            _extractionSettings.SensitiveItemCheck.VehicleIdentificationNumberCheck = _vinCheckBox.Checked;
            _extractionSettings.SensitiveItemCheck.HealthCareNumberIdCheck    = _healthCareNumberCheckBox.Checked;
            _extractionSettings.SensitiveItemCheck.AddressCheck               = _addressCheckBox.Checked;
            _extractionSettings.SensitiveItemCheck.IPv4AddressCheck           = _ipv4CheckBox.Checked;
            _extractionSettings.SensitiveItemCheck.PasswordCheck              = _passwordCheckBox4.Checked;
            _extractionSettings.SensitiveItemCheck.UsernameCheck              = _usernameCheckBox.Checked;
            _extractionSettings.SensitiveItemCheck.NetworkNameCheck           = _networkNameCheckBox.Checked;
            _extractionSettings.SensitiveItemCheck.DatabaseCredentialsCheck   = _databaseCredentialsCheckBox.Checked;

            _extractionSettings.SensitiveItemCheck.GeneralAccountCheck        = _generalAccountCheckBox.Checked;
            _extractionSettings.SensitiveItemCheck.GeneralIdentificationCheck = _genIdentificationCheckBox.Checked;
            _extractionSettings.SensitiveItemCheck.GeneralUrlCheck            = _generalUrlCheckBox.Checked;

            _extractionSettings.SensitiveItemCheck.Check = _enableSensitiveItemsCheckCheckBox.Checked;
            _sensitiveItemTabControl.Enabled             = _enableSensitiveItemsCheckCheckBox.Checked;

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
                var dir   = Path.GetDirectoryName(filePath);
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
        // ISdkAPIServiceCallback Implementation:
        //
        #region public void ExtractContentCompleted(DocumentContent extractedContent)
        public void ExtractContentCompleted(DocumentContent extractedContent)
        {
            // Don't block the service (via callback) by doing time consuming activities on callback -
            // this invokes the handling of callback to the UI thread:
            this.BeginInvoke((Action)delegate
            {
                try
                {
                    _stopWatch.Stop();
                    var extractTime = _stopWatch.Elapsed.TotalMilliseconds;

                    if (extractedContent is ArchiveContent)
                    {
                        _contentView.Visible = false;
                        _archiveView.Visible = true;
                        _archiveView.UpdateContentView((ArchiveContent)extractedContent, Path.GetFileName(_selectedFilePath), _selectedFileLength);
                    }
                    else if (extractedContent is MailStoreContent)
                    {
                        _contentView.Visible   = false;
                        _archiveView.Visible   = false;
                        _mailStoreView.Visible = true;
                        _mailStoreView.UpdateContentView((MailStoreContent)extractedContent, Path.GetFileName(_selectedFilePath), _selectedFileLength);
                    }
                    else
                    {
                        _contentView.Visible = true;
                        _archiveView.Visible = false;
                        _contentView.UpdateContentView(extractedContent, Path.GetFileName(_selectedFilePath), _selectedFileLength);
                    }

                    //
                    // Display identification and extraction metrics:
                    //
                    _toolStripStatusLabel.Text = string.Format("File ID in {0:F2} [ms], Content Extracted in {1:F2} [ms]", _fileIdTime, extractTime);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ISdkAPIServiceCallback service callback error: " + ex.Message);
                }
                finally
                {
                    _filesListBox.Enabled = true;
                    UseWaitCursor = false;
                    _filesListBox.Focus();
                }
            });
        }
        #endregion

        #region public void Exception(string message, string stackTrace)
        public void ServiceException(string message, string stackTrace)
        {
            this.BeginInvoke((Action)delegate
            {
                try
                {
                    MessageBox.Show(string.Format("{0}\r\nStackTrace:\r\n{1}",  message, stackTrace), "ISdkAPIService Error");

                    //
                    // Display identification and extraction metrics:
                    //
                    _toolStripStatusLabel.Text = "Service Error: " + message;
                }
                finally
                {
                    _filesListBox.Enabled = true;
                    UseWaitCursor = false;
                    _filesListBox.Focus();
                }
            });
        }
        #endregion

        //
        // UI Event Handlers:
        //
        #region private void MainForm_Shown(object sender, EventArgs e)
        private void MainForm_Shown(object sender, EventArgs e)
        {
            try
            {
                //
                // Start WCF ASK API service host (see project SdkAPIServiceHost.csproj):
                //
                var procStartInfo = new ProcessStartInfo();
                procStartInfo.UseShellExecute  = true;
                procStartInfo.WorkingDirectory = Environment.CurrentDirectory;
                procStartInfo.FileName = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "SdkAPIServiceHost.exe");

                try
                {
                    _serviceHostProcess = Process.Start(procStartInfo);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("SdkAPIServiceHost.exe could not be started: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error starting service host: " + ex.Message);
                Close();
            }

            var connectForm = new ConnectForm();

            if (connectForm.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    var context  = new InstanceContext(this);
                    var binding  = new NetNamedPipeBinding(NetNamedPipeSecurityMode.None);
                    var endpoint = new EndpointAddress("net.pipe://localhost/SdkAPIService");

                    binding.MaxBufferSize          = int.MaxValue;  
                    binding.MaxReceivedMessageSize = binding.MaxBufferSize;
                    binding.MaxConnections = 2;
                    binding.ReceiveTimeout = new TimeSpan(0, 0, 30); // 30 sec receive timeout

                    // Trouble Shooting for connection errors:
                    //-----------------------------------------
                    // 1. Open Control Panel.
                    // 2. Select Programs, then "Programs and Features", or if in Classic view, select "Programs and Features".
                    // 3. Right mouse click on "Turn Windows Features on or off".
                    // 4. Expand the Microsoft.NET Framework 3.0(or 3.5) tree view node and check the "Windows Communication Foundation Non-HTTP Activation" feature.
                    // 5. Make sure "Net.Pipe Listener Adapter" Windows service is running
                    //    a. Run Services.msc
                    //    b. Make sure Net.Pipe Listener Adapter service is running. Start if not running.
                    _sdkAPIServiceProxy = new SdkAPIServiceProxy(context, binding, endpoint);
                    _sdkAPIServiceProxy.Opened  += _sdkAPIServiceProxy_Opened;
                    _sdkAPIServiceProxy.Faulted += _sdkAPIServiceProxy_Faulted;

                    _sdkAPIServiceProxy.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error connecting to SdkAPIService service:\r\n" + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Must connect to SdkAPIService service... exiting.");
                this.Close();
            }
        }
        #endregion

        #region private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_sdkAPIServiceProxy != null)
            {
                try
                {
                    _sdkAPIServiceProxy.Close();
                }
                catch { }
            }

            if (_serviceHostProcess != null && !_serviceHostProcess.HasExited)
            {
                _serviceHostProcess.Kill();
            }
        }
        #endregion

        //
        // Service Proxy event handlers:
        //
        #region private void _sdkAPIServiceProxy_Opened()
        private void _sdkAPIServiceProxy_Opened()
        {
            _toolStripStatusLabel.Text = "Connection to ISdkAPIService is open.";
        }
        #endregion

        #region private void _sdkAPIServiceProxy_Faulted()
        private void _sdkAPIServiceProxy_Faulted()
        {
            // this invokes the handling of callback to the UI thread:
            this.BeginInvoke((Action)delegate
            {
                _filesListBox.Enabled = true;
                UseWaitCursor = false;
                _filesListBox.Focus();
                MessageBox.Show("ISdkAPIService service faulted!");
            });
        }
        #endregion


        //
        // WinForm event handlers:
        //
        #region private void openFileMenuItem_Click(object sender, EventArgs e)
        private void openFileMenuItem_Click(object sender, EventArgs e)
        {
            var openFileDlg = new OpenFileDialog();
            openFileDlg.DefaultExt  = "*.*";
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
                    _selectedFilePath = item.Path;
                    ExtractContent(item.Path);
                }
            }
            catch (Exception ex)
            {
                LogMessage(string.Format("Load error: {0}\n", ex.Message));
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
                    case  ExtractionType.TextAndMetadata:
                        EnableTabPageControls(_langIdTabPage, true);
                        EnableTabPageControls(_unsupportedTabPage, true);
                        EnableTabPageControls(_pdfTabPage, true);
                        _embeddedObjExtractionComboBox.Enabled   = true;
                        _selectedEmailDateFormatComboBox.Enabled = true;
                        _showUtcOffsetForTimeCheckBox.Enabled    = true;
                        _displayEmailRecipientNameAndSmtpCheckBox.Enabled = true;
                        break;
                    case ExtractionType.MetadataOnly:
                        EnableTabPageControls(_langIdTabPage, false);
                        EnableTabPageControls(_unsupportedTabPage, false);
                        EnableTabPageControls(_pdfTabPage, false);
                        _embeddedObjExtractionComboBox.Enabled   = false;
                        _selectedEmailDateFormatComboBox.Enabled = false;
                        _showUtcOffsetForTimeCheckBox.Enabled    = false;
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

        #region private void _enableSensitiveItemsCheckCheckBox_CheckedChanged(object sender, EventArgs e)
        private void _enableSensitiveItemsCheckCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _sensitiveItemTabControl.Enabled = _enableSensitiveItemsCheckCheckBox.Checked;
        }
        #endregion

        private void _UserMapiPropertyRequestsButton_Click(object sender, EventArgs e)
        {
            //TODO:
        }
    }
}
