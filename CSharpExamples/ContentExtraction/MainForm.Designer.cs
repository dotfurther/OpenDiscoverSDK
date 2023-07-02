namespace ContentExtractionExample
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            openFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            loadPasswordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            hexViewerModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            passwordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            _filesListBox = new System.Windows.Forms.ListBox();
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            fileNameLabel = new System.Windows.Forms.ToolStripStatusLabel();
            _toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            splitContainer1 = new System.Windows.Forms.SplitContainer();
            splitContainer2 = new System.Windows.Forms.SplitContainer();
            tabControl1 = new System.Windows.Forms.TabControl();
            tabPage1 = new System.Windows.Forms.TabPage();
            panel1 = new System.Windows.Forms.Panel();
            _useLargeDocumentUTF16EncodingCheckBox = new System.Windows.Forms.CheckBox();
            _largeDocumentCriteraComboBox = new System.Windows.Forms.ComboBox();
            label15 = new System.Windows.Forms.Label();
            _subSettingsTabControl = new System.Windows.Forms.TabControl();
            _hashingTabPage = new System.Windows.Forms.TabPage();
            _calculateFileEntropyCheckBox = new System.Windows.Forms.CheckBox();
            _includeBccRecipientsInEmailContentHashCheckBox = new System.Windows.Forms.CheckBox();
            _maxBinaryHashLengthComboBox = new System.Windows.Forms.ComboBox();
            label11 = new System.Windows.Forms.Label();
            _hashingTypeComboBox = new System.Windows.Forms.ComboBox();
            label10 = new System.Windows.Forms.Label();
            _pdfTabPage = new System.Windows.Forms.TabPage();
            _pdfPageExtractedTextCriteriaComboBox = new System.Windows.Forms.ComboBox();
            label9 = new System.Windows.Forms.Label();
            _pdfImageExtractionComboBox = new System.Windows.Forms.ComboBox();
            label8 = new System.Windows.Forms.Label();
            _langIdTabPage = new System.Windows.Forms.TabPage();
            _maxLanguageIdCharactersComboBox = new System.Windows.Forms.ComboBox();
            label12 = new System.Windows.Forms.Label();
            _partitionLatinScriptRegionsCheckBox = new System.Windows.Forms.CheckBox();
            _latinScriptRegionSizeComboBox = new System.Windows.Forms.ComboBox();
            label4 = new System.Windows.Forms.Label();
            _identifyLangInExtractedTextCheckBox = new System.Windows.Forms.CheckBox();
            _unsupportedTabPage = new System.Windows.Forms.TabPage();
            _largeUnsupportedMaxFilteredCharsComboBox = new System.Windows.Forms.ComboBox();
            label3 = new System.Windows.Forms.Label();
            _filterMinWordLengthComboBox = new System.Windows.Forms.ComboBox();
            label13 = new System.Windows.Forms.Label();
            _filteringTypeComboBox = new System.Windows.Forms.ComboBox();
            label14 = new System.Windows.Forms.Label();
            _piiCheckTabPage = new System.Windows.Forms.TabPage();
            _sensitiveItemTabControl = new System.Windows.Forms.TabControl();
            tabPage4 = new System.Windows.Forms.TabPage();
            _enablePiiItemsCheckCheckBox = new System.Windows.Forms.CheckBox();
            _enableEmojiEntityDetectionCheckBox = new System.Windows.Forms.CheckBox();
            _enableEntityPersonNameChecksInBinaryToTextCheckBox = new System.Windows.Forms.CheckBox();
            _enablePersonNameFinderCheckBox = new System.Windows.Forms.CheckBox();
            _dedupEntityItemsCheckBox = new System.Windows.Forms.CheckBox();
            tabPage5 = new System.Windows.Forms.TabPage();
            _numCustItemDefsLoadedLabel = new System.Windows.Forms.Label();
            _loadCustomSensitiveItemDefButton = new System.Windows.Forms.Button();
            _customSensitiveItemCheckBox = new System.Windows.Forms.CheckBox();
            _timeZoneTabPage = new System.Windows.Forms.TabPage();
            _extractAllKnownOutlookMAPIPropertiesCheckBox = new System.Windows.Forms.CheckBox();
            _UserMapiPropertyRequestsButton = new System.Windows.Forms.Button();
            _displayEmailRecipientNameAndSmtpCheckBox = new System.Windows.Forms.CheckBox();
            _showUtcOffsetForTimeCheckBox = new System.Windows.Forms.CheckBox();
            _selectedEmailDateFormatComboBox = new System.Windows.Forms.ComboBox();
            label5 = new System.Windows.Forms.Label();
            _selectedTimeZoneComboBox = new System.Windows.Forms.ComboBox();
            label1 = new System.Windows.Forms.Label();
            _setDateTimeUnspecifiedMetaToUtcCheckBox = new System.Windows.Forms.CheckBox();
            _embeddedObjExtractionComboBox = new System.Windows.Forms.ComboBox();
            label7 = new System.Windows.Forms.Label();
            _extractionTypeComboBox = new System.Windows.Forms.ComboBox();
            label6 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            _tabControl = new System.Windows.Forms.TabControl();
            _contentTabPage = new System.Windows.Forms.TabPage();
            _logTabPage = new System.Windows.Forms.TabPage();
            _logTextBox = new System.Windows.Forms.TextBox();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            toolTip1 = new System.Windows.Forms.ToolTip(components);
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            panel1.SuspendLayout();
            _subSettingsTabControl.SuspendLayout();
            _hashingTabPage.SuspendLayout();
            _pdfTabPage.SuspendLayout();
            _langIdTabPage.SuspendLayout();
            _unsupportedTabPage.SuspendLayout();
            _piiCheckTabPage.SuspendLayout();
            _sensitiveItemTabControl.SuspendLayout();
            tabPage4.SuspendLayout();
            tabPage5.SuspendLayout();
            _timeZoneTabPage.SuspendLayout();
            _tabControl.SuspendLayout();
            _logTabPage.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { fileToolStripMenuItem, viewToolStripMenuItem });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            menuStrip1.Size = new System.Drawing.Size(1601, 24);
            menuStrip1.TabIndex = 8;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { openFileMenuItem, loadPasswordsToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // openFileMenuItem
            // 
            openFileMenuItem.Name = "openFileMenuItem";
            openFileMenuItem.Size = new System.Drawing.Size(167, 22);
            openFileMenuItem.Text = "Open...";
            openFileMenuItem.Click += openFileMenuItem_Click;
            // 
            // loadPasswordsToolStripMenuItem
            // 
            loadPasswordsToolStripMenuItem.Name = "loadPasswordsToolStripMenuItem";
            loadPasswordsToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            loadPasswordsToolStripMenuItem.Text = "Load Passwords...";
            loadPasswordsToolStripMenuItem.Click += loadPasswordsToolStripMenuItem_Click;
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { hexViewerModeToolStripMenuItem, passwordsToolStripMenuItem });
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            viewToolStripMenuItem.Text = "&View";
            // 
            // hexViewerModeToolStripMenuItem
            // 
            hexViewerModeToolStripMenuItem.Name = "hexViewerModeToolStripMenuItem";
            hexViewerModeToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            hexViewerModeToolStripMenuItem.Text = "Hex Viewer Mode";
            // 
            // passwordsToolStripMenuItem
            // 
            passwordsToolStripMenuItem.Name = "passwordsToolStripMenuItem";
            passwordsToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            passwordsToolStripMenuItem.Text = "Passwords...";
            // 
            // _filesListBox
            // 
            _filesListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            _filesListBox.DisplayMember = "Filename";
            _filesListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            _filesListBox.FormattingEnabled = true;
            _filesListBox.ItemHeight = 15;
            _filesListBox.Location = new System.Drawing.Point(0, 0);
            _filesListBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            _filesListBox.Name = "_filesListBox";
            _filesListBox.Size = new System.Drawing.Size(456, 230);
            _filesListBox.TabIndex = 7;
            _filesListBox.ValueMember = "Path";
            _filesListBox.SelectedIndexChanged += _filesListBox_SelectedIndexChanged;
            _filesListBox.MouseDoubleClick += _filesListBox_MouseDoubleClick;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { fileNameLabel, _toolStripStatusLabel });
            statusStrip1.Location = new System.Drawing.Point(0, 774);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            statusStrip1.Size = new System.Drawing.Size(1601, 22);
            statusStrip1.TabIndex = 9;
            statusStrip1.Text = "statusStrip1";
            // 
            // fileNameLabel
            // 
            fileNameLabel.Name = "fileNameLabel";
            fileNameLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // _toolStripStatusLabel
            // 
            _toolStripStatusLabel.Name = "_toolStripStatusLabel";
            _toolStripStatusLabel.Size = new System.Drawing.Size(42, 17);
            _toolStripStatusLabel.Text = "Ready.";
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            splitContainer1.BackColor = System.Drawing.SystemColors.Control;
            splitContainer1.Location = new System.Drawing.Point(8, 28);
            splitContainer1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(splitContainer2);
            splitContainer1.Panel1.Controls.Add(label2);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(_tabControl);
            splitContainer1.Size = new System.Drawing.Size(1587, 740);
            splitContainer1.SplitterDistance = 456;
            splitContainer1.TabIndex = 10;
            // 
            // splitContainer2
            // 
            splitContainer2.BackColor = System.Drawing.SystemColors.Control;
            splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer2.Location = new System.Drawing.Point(0, 0);
            splitContainer2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(_filesListBox);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(tabControl1);
            splitContainer2.Size = new System.Drawing.Size(456, 740);
            splitContainer2.SplitterDistance = 230;
            splitContainer2.SplitterWidth = 7;
            splitContainer2.TabIndex = 15;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControl1.Location = new System.Drawing.Point(0, 0);
            tabControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(456, 503);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(panel1);
            tabPage1.Location = new System.Drawing.Point(4, 24);
            tabPage1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabPage1.Size = new System.Drawing.Size(448, 475);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "ContentExtractionSettings";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Controls.Add(_useLargeDocumentUTF16EncodingCheckBox);
            panel1.Controls.Add(_largeDocumentCriteraComboBox);
            panel1.Controls.Add(label15);
            panel1.Controls.Add(_subSettingsTabControl);
            panel1.Controls.Add(_embeddedObjExtractionComboBox);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(_extractionTypeComboBox);
            panel1.Controls.Add(label6);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(4, 3);
            panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(440, 469);
            panel1.TabIndex = 13;
            // 
            // _useLargeDocumentUTF16EncodingCheckBox
            // 
            _useLargeDocumentUTF16EncodingCheckBox.AutoSize = true;
            _useLargeDocumentUTF16EncodingCheckBox.Location = new System.Drawing.Point(6, 428);
            _useLargeDocumentUTF16EncodingCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            _useLargeDocumentUTF16EncodingCheckBox.Name = "_useLargeDocumentUTF16EncodingCheckBox";
            _useLargeDocumentUTF16EncodingCheckBox.Size = new System.Drawing.Size(212, 19);
            _useLargeDocumentUTF16EncodingCheckBox.TabIndex = 37;
            _useLargeDocumentUTF16EncodingCheckBox.Text = "UseLargeDocumentUTF16Encoding";
            toolTip1.SetToolTip(_useLargeDocumentUTF16EncodingCheckBox, resources.GetString("_useLargeDocumentUTF16EncodingCheckBox.ToolTip"));
            _useLargeDocumentUTF16EncodingCheckBox.UseVisualStyleBackColor = true;
            // 
            // _largeDocumentCriteraComboBox
            // 
            _largeDocumentCriteraComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            _largeDocumentCriteraComboBox.Items.AddRange(new object[] { "52,428,800 (50 MB)", "78,643,200 (75 MB)", "104,857,600 (100 MB)", "157,286,400 (150 MB)", "209,715,200 (200 MB)", "262,144,000 (250 MB)", "419,430,400 (400 MB)", "524,288,000 (500 MB)", "1,073,741,824 (1000 MB)" });
            _largeDocumentCriteraComboBox.Location = new System.Drawing.Point(144, 397);
            _largeDocumentCriteraComboBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            _largeDocumentCriteraComboBox.Name = "_largeDocumentCriteraComboBox";
            _largeDocumentCriteraComboBox.Size = new System.Drawing.Size(226, 23);
            _largeDocumentCriteraComboBox.TabIndex = 36;
            toolTip1.SetToolTip(_largeDocumentCriteraComboBox, resources.GetString("_largeDocumentCriteraComboBox.ToolTip"));
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new System.Drawing.Point(2, 402);
            label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(130, 15);
            label15.TabIndex = 35;
            label15.Text = "LargeDocumentCritera:";
            // 
            // _subSettingsTabControl
            // 
            _subSettingsTabControl.Controls.Add(_hashingTabPage);
            _subSettingsTabControl.Controls.Add(_pdfTabPage);
            _subSettingsTabControl.Controls.Add(_langIdTabPage);
            _subSettingsTabControl.Controls.Add(_unsupportedTabPage);
            _subSettingsTabControl.Controls.Add(_piiCheckTabPage);
            _subSettingsTabControl.Controls.Add(_timeZoneTabPage);
            _subSettingsTabControl.Location = new System.Drawing.Point(6, 75);
            _subSettingsTabControl.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            _subSettingsTabControl.Name = "_subSettingsTabControl";
            _subSettingsTabControl.SelectedIndex = 0;
            _subSettingsTabControl.Size = new System.Drawing.Size(430, 315);
            _subSettingsTabControl.TabIndex = 24;
            // 
            // _hashingTabPage
            // 
            _hashingTabPage.Controls.Add(_calculateFileEntropyCheckBox);
            _hashingTabPage.Controls.Add(_includeBccRecipientsInEmailContentHashCheckBox);
            _hashingTabPage.Controls.Add(_maxBinaryHashLengthComboBox);
            _hashingTabPage.Controls.Add(label11);
            _hashingTabPage.Controls.Add(_hashingTypeComboBox);
            _hashingTabPage.Controls.Add(label10);
            _hashingTabPage.Location = new System.Drawing.Point(4, 24);
            _hashingTabPage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            _hashingTabPage.Name = "_hashingTabPage";
            _hashingTabPage.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            _hashingTabPage.Size = new System.Drawing.Size(422, 287);
            _hashingTabPage.TabIndex = 1;
            _hashingTabPage.Text = "Hashing";
            _hashingTabPage.UseVisualStyleBackColor = true;
            // 
            // _calculateFileEntropyCheckBox
            // 
            _calculateFileEntropyCheckBox.AutoSize = true;
            _calculateFileEntropyCheckBox.Location = new System.Drawing.Point(10, 115);
            _calculateFileEntropyCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            _calculateFileEntropyCheckBox.Name = "_calculateFileEntropyCheckBox";
            _calculateFileEntropyCheckBox.Size = new System.Drawing.Size(140, 19);
            _calculateFileEntropyCheckBox.TabIndex = 31;
            _calculateFileEntropyCheckBox.Text = "Calculate File Entropy";
            toolTip1.SetToolTip(_calculateFileEntropyCheckBox, "If true, calculates the file's Shannon entropy. File entropy is useful in determining if an unknown file is compressed or encrypted.");
            _calculateFileEntropyCheckBox.UseVisualStyleBackColor = true;
            // 
            // _includeBccRecipientsInEmailContentHashCheckBox
            // 
            _includeBccRecipientsInEmailContentHashCheckBox.AutoSize = true;
            _includeBccRecipientsInEmailContentHashCheckBox.Location = new System.Drawing.Point(10, 151);
            _includeBccRecipientsInEmailContentHashCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            _includeBccRecipientsInEmailContentHashCheckBox.Name = "_includeBccRecipientsInEmailContentHashCheckBox";
            _includeBccRecipientsInEmailContentHashCheckBox.Size = new System.Drawing.Size(247, 19);
            _includeBccRecipientsInEmailContentHashCheckBox.TabIndex = 30;
            _includeBccRecipientsInEmailContentHashCheckBox.Text = "IncludeBccRecipientsInEmailContentHash";
            toolTip1.SetToolTip(_includeBccRecipientsInEmailContentHashCheckBox, "If true, includes email 'Bcc' recipients in the email overall recipient hash (see properties EmailDocumentContent.Sha1RecipientsHash ");
            _includeBccRecipientsInEmailContentHashCheckBox.UseVisualStyleBackColor = true;
            // 
            // _maxBinaryHashLengthComboBox
            // 
            _maxBinaryHashLengthComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            _maxBinaryHashLengthComboBox.Items.AddRange(new object[] { "-1 (no byte length limit)", "104,857,600‬ (100 MB)", "209,715,200‬ (200 MB)", "524,288,000‬‬ (500 MB)", "1,048,576,000‬‬ (1 GB)", "5,242,880,000‬ (5 GB)", "10,485,760,000‬ (10 GB)", "20,971,520,000 (20 GB)", "52,428,800,000 (50 GB)" });
            _maxBinaryHashLengthComboBox.Location = new System.Drawing.Point(150, 66);
            _maxBinaryHashLengthComboBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            _maxBinaryHashLengthComboBox.Name = "_maxBinaryHashLengthComboBox";
            _maxBinaryHashLengthComboBox.Size = new System.Drawing.Size(190, 23);
            _maxBinaryHashLengthComboBox.TabIndex = 29;
            toolTip1.SetToolTip(_maxBinaryHashLengthComboBox, "Maximum number of bytes to use for MD5/SHA-1 binary hash (digest) calculation");
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(7, 69);
            label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(130, 15);
            label11.TabIndex = 28;
            label11.Text = "MaxBinaryHashLength:";
            // 
            // _hashingTypeComboBox
            // 
            _hashingTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            _hashingTypeComboBox.Items.AddRange(new object[] { "None", "BinaryHashOnly", "BinaryAndContentHash" });
            _hashingTypeComboBox.Location = new System.Drawing.Point(111, 21);
            _hashingTypeComboBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            _hashingTypeComboBox.Name = "_hashingTypeComboBox";
            _hashingTypeComboBox.Size = new System.Drawing.Size(229, 23);
            _hashingTypeComboBox.TabIndex = 25;
            toolTip1.SetToolTip(_hashingTypeComboBox, "Document hashing type.");
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(7, 25);
            label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(78, 15);
            label10.TabIndex = 24;
            label10.Text = "HashingType:";
            // 
            // _pdfTabPage
            // 
            _pdfTabPage.Controls.Add(_pdfPageExtractedTextCriteriaComboBox);
            _pdfTabPage.Controls.Add(label9);
            _pdfTabPage.Controls.Add(_pdfImageExtractionComboBox);
            _pdfTabPage.Controls.Add(label8);
            _pdfTabPage.Location = new System.Drawing.Point(4, 24);
            _pdfTabPage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            _pdfTabPage.Name = "_pdfTabPage";
            _pdfTabPage.Size = new System.Drawing.Size(422, 287);
            _pdfTabPage.TabIndex = 5;
            _pdfTabPage.Text = "PDF";
            _pdfTabPage.UseVisualStyleBackColor = true;
            // 
            // _pdfPageExtractedTextCriteriaComboBox
            // 
            _pdfPageExtractedTextCriteriaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            _pdfPageExtractedTextCriteriaComboBox.Items.AddRange(new object[] { "0", "1", "5", "10", "15", "20", "25", "30", "40", "50", "100" });
            _pdfPageExtractedTextCriteriaComboBox.Location = new System.Drawing.Point(216, 61);
            _pdfPageExtractedTextCriteriaComboBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            _pdfPageExtractedTextCriteriaComboBox.Name = "_pdfPageExtractedTextCriteriaComboBox";
            _pdfPageExtractedTextCriteriaComboBox.Size = new System.Drawing.Size(122, 23);
            _pdfPageExtractedTextCriteriaComboBox.TabIndex = 27;
            toolTip1.SetToolTip(_pdfPageExtractedTextCriteriaComboBox, "Minimum PDF page extracted text length (in characters) criteria");
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(5, 65);
            label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(183, 15);
            label9.TabIndex = 26;
            label9.Text = "PageExtractedTextCriteria [chars]:";
            // 
            // _pdfImageExtractionComboBox
            // 
            _pdfImageExtractionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            _pdfImageExtractionComboBox.Items.AddRange(new object[] { "None", "OnlyFailedPdfPages", "AllPdfPages" });
            _pdfImageExtractionComboBox.Location = new System.Drawing.Point(112, 23);
            _pdfImageExtractionComboBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            _pdfImageExtractionComboBox.Name = "_pdfImageExtractionComboBox";
            _pdfImageExtractionComboBox.Size = new System.Drawing.Size(227, 23);
            _pdfImageExtractionComboBox.TabIndex = 25;
            toolTip1.SetToolTip(_pdfImageExtractionComboBox, "PDF page image extraction.");
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(5, 28);
            label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(96, 15);
            label8.TabIndex = 24;
            label8.Text = "ImageExtraction:";
            // 
            // _langIdTabPage
            // 
            _langIdTabPage.Controls.Add(_maxLanguageIdCharactersComboBox);
            _langIdTabPage.Controls.Add(label12);
            _langIdTabPage.Controls.Add(_partitionLatinScriptRegionsCheckBox);
            _langIdTabPage.Controls.Add(_latinScriptRegionSizeComboBox);
            _langIdTabPage.Controls.Add(label4);
            _langIdTabPage.Controls.Add(_identifyLangInExtractedTextCheckBox);
            _langIdTabPage.Location = new System.Drawing.Point(4, 24);
            _langIdTabPage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            _langIdTabPage.Name = "_langIdTabPage";
            _langIdTabPage.Size = new System.Drawing.Size(422, 287);
            _langIdTabPage.TabIndex = 2;
            _langIdTabPage.Text = "LangId";
            _langIdTabPage.UseVisualStyleBackColor = true;
            // 
            // _maxLanguageIdCharactersComboBox
            // 
            _maxLanguageIdCharactersComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            _maxLanguageIdCharactersComboBox.Items.AddRange(new object[] { "5000", "10000", "20000", "50000", "100000", "200000", "500000", "1000000", "5000000", "10000000" });
            _maxLanguageIdCharactersComboBox.Location = new System.Drawing.Point(204, 47);
            _maxLanguageIdCharactersComboBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            _maxLanguageIdCharactersComboBox.Name = "_maxLanguageIdCharactersComboBox";
            _maxLanguageIdCharactersComboBox.Size = new System.Drawing.Size(134, 23);
            _maxLanguageIdCharactersComboBox.TabIndex = 26;
            toolTip1.SetToolTip(_maxLanguageIdCharactersComboBox, "Maximum number of characters in extracted text to use for language identification.");
            // 
            // label12
            // 
            label12.Location = new System.Drawing.Point(7, 45);
            label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(192, 27);
            label12.TabIndex = 25;
            label12.Text = "MaxLanguageIdCharacters:";
            label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _partitionLatinScriptRegionsCheckBox
            // 
            _partitionLatinScriptRegionsCheckBox.AutoSize = true;
            _partitionLatinScriptRegionsCheckBox.Location = new System.Drawing.Point(10, 96);
            _partitionLatinScriptRegionsCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            _partitionLatinScriptRegionsCheckBox.Name = "_partitionLatinScriptRegionsCheckBox";
            _partitionLatinScriptRegionsCheckBox.Size = new System.Drawing.Size(169, 19);
            _partitionLatinScriptRegionsCheckBox.TabIndex = 24;
            _partitionLatinScriptRegionsCheckBox.Text = "PartitionLatinScriptRegions";
            toolTip1.SetToolTip(_partitionLatinScriptRegionsCheckBox, "Determines if Latin script regions detected during the language identification process are partitioned into smaller regions ");
            _partitionLatinScriptRegionsCheckBox.UseVisualStyleBackColor = true;
            // 
            // _latinScriptRegionSizeComboBox
            // 
            _latinScriptRegionSizeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            _latinScriptRegionSizeComboBox.Items.AddRange(new object[] { "150", "250", "350", "500", "750", "1000", "2000", "3000", "4000", "5000", "10000", "20000", "50000" });
            _latinScriptRegionSizeComboBox.Location = new System.Drawing.Point(204, 125);
            _latinScriptRegionSizeComboBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            _latinScriptRegionSizeComboBox.Name = "_latinScriptRegionSizeComboBox";
            _latinScriptRegionSizeComboBox.Size = new System.Drawing.Size(134, 23);
            _latinScriptRegionSizeComboBox.TabIndex = 23;
            toolTip1.SetToolTip(_latinScriptRegionSizeComboBox, "Used by language identification algorithm to partition detected Latin script regions into smaller character ranges of this size. ");
            // 
            // label4
            // 
            label4.Location = new System.Drawing.Point(7, 122);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(192, 27);
            label4.TabIndex = 22;
            label4.Text = "LatinScriptRegionPartitionSize:";
            label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _identifyLangInExtractedTextCheckBox
            // 
            _identifyLangInExtractedTextCheckBox.AutoSize = true;
            _identifyLangInExtractedTextCheckBox.Checked = true;
            _identifyLangInExtractedTextCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            _identifyLangInExtractedTextCheckBox.Location = new System.Drawing.Point(10, 22);
            _identifyLangInExtractedTextCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            _identifyLangInExtractedTextCheckBox.Name = "_identifyLangInExtractedTextCheckBox";
            _identifyLangInExtractedTextCheckBox.Size = new System.Drawing.Size(123, 19);
            _identifyLangInExtractedTextCheckBox.TabIndex = 21;
            _identifyLangInExtractedTextCheckBox.Text = "IdentifyLanguages";
            toolTip1.SetToolTip(_identifyLangInExtractedTextCheckBox, "Determines if languages present in extract text are to be identified by content extractors.");
            _identifyLangInExtractedTextCheckBox.UseVisualStyleBackColor = true;
            // 
            // _unsupportedTabPage
            // 
            _unsupportedTabPage.Controls.Add(_largeUnsupportedMaxFilteredCharsComboBox);
            _unsupportedTabPage.Controls.Add(label3);
            _unsupportedTabPage.Controls.Add(_filterMinWordLengthComboBox);
            _unsupportedTabPage.Controls.Add(label13);
            _unsupportedTabPage.Controls.Add(_filteringTypeComboBox);
            _unsupportedTabPage.Controls.Add(label14);
            _unsupportedTabPage.Location = new System.Drawing.Point(4, 24);
            _unsupportedTabPage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            _unsupportedTabPage.Name = "_unsupportedTabPage";
            _unsupportedTabPage.Size = new System.Drawing.Size(422, 287);
            _unsupportedTabPage.TabIndex = 4;
            _unsupportedTabPage.Text = "Unsupported";
            _unsupportedTabPage.UseVisualStyleBackColor = true;
            // 
            // _largeUnsupportedMaxFilteredCharsComboBox
            // 
            _largeUnsupportedMaxFilteredCharsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            _largeUnsupportedMaxFilteredCharsComboBox.Items.AddRange(new object[] { "1,048,576", "2,000,000", "3,000,000", "4,000,000", "5,000,000", "10,000,000", "20,000,000", "50,000,000", "100,000,000" });
            _largeUnsupportedMaxFilteredCharsComboBox.Location = new System.Drawing.Point(9, 137);
            _largeUnsupportedMaxFilteredCharsComboBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            _largeUnsupportedMaxFilteredCharsComboBox.Name = "_largeUnsupportedMaxFilteredCharsComboBox";
            _largeUnsupportedMaxFilteredCharsComboBox.Size = new System.Drawing.Size(320, 23);
            _largeUnsupportedMaxFilteredCharsComboBox.TabIndex = 35;
            toolTip1.SetToolTip(_largeUnsupportedMaxFilteredCharsComboBox, "Limits the numbers of filtered characters that are written to a stream (should be a FileStream) by ILargeUnsupportedExtractor.ExtractContent(System.IO.Stream).");
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(6, 117);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(239, 15);
            label3.TabIndex = 34;
            label3.Text = "LargeUnsupportedMaxFilteredChars [chars]:";
            // 
            // _filterMinWordLengthComboBox
            // 
            _filterMinWordLengthComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            _filterMinWordLengthComboBox.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6" });
            _filterMinWordLengthComboBox.Location = new System.Drawing.Point(180, 67);
            _filterMinWordLengthComboBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            _filterMinWordLengthComboBox.Name = "_filterMinWordLengthComboBox";
            _filterMinWordLengthComboBox.Size = new System.Drawing.Size(150, 23);
            _filterMinWordLengthComboBox.TabIndex = 33;
            toolTip1.SetToolTip(_filterMinWordLengthComboBox, "Minimum word length, in characters, for binary-to-text filtering. If filtered word lengths are less than this value they will not show up in extracted text. ");
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new System.Drawing.Point(6, 70);
            label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(162, 15);
            label13.TabIndex = 32;
            label13.Text = "FilterMinWordLength [chars]:";
            // 
            // _filteringTypeComboBox
            // 
            _filteringTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            _filteringTypeComboBox.Items.AddRange(new object[] { "None", "Unsupported", "UnsupportedAndEncrypted" });
            _filteringTypeComboBox.Location = new System.Drawing.Point(107, 22);
            _filteringTypeComboBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            _filteringTypeComboBox.Name = "_filteringTypeComboBox";
            _filteringTypeComboBox.Size = new System.Drawing.Size(222, 23);
            _filteringTypeComboBox.TabIndex = 31;
            toolTip1.SetToolTip(_filteringTypeComboBox, "Binary-to-text filtering of unsupported/unknown document file format options.");
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new System.Drawing.Point(6, 27);
            label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(77, 15);
            label14.TabIndex = 30;
            label14.Text = "FilteringType:";
            // 
            // _piiCheckTabPage
            // 
            _piiCheckTabPage.Controls.Add(_sensitiveItemTabControl);
            _piiCheckTabPage.Location = new System.Drawing.Point(4, 24);
            _piiCheckTabPage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            _piiCheckTabPage.Name = "_piiCheckTabPage";
            _piiCheckTabPage.Size = new System.Drawing.Size(422, 287);
            _piiCheckTabPage.TabIndex = 6;
            _piiCheckTabPage.Text = "Entity Item";
            _piiCheckTabPage.UseVisualStyleBackColor = true;
            // 
            // _sensitiveItemTabControl
            // 
            _sensitiveItemTabControl.Controls.Add(tabPage4);
            _sensitiveItemTabControl.Controls.Add(tabPage5);
            _sensitiveItemTabControl.Enabled = false;
            _sensitiveItemTabControl.Location = new System.Drawing.Point(4, 3);
            _sensitiveItemTabControl.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            _sensitiveItemTabControl.Name = "_sensitiveItemTabControl";
            _sensitiveItemTabControl.SelectedIndex = 0;
            _sensitiveItemTabControl.Size = new System.Drawing.Size(413, 279);
            _sensitiveItemTabControl.TabIndex = 36;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(_enablePiiItemsCheckCheckBox);
            tabPage4.Controls.Add(_enableEmojiEntityDetectionCheckBox);
            tabPage4.Controls.Add(_enableEntityPersonNameChecksInBinaryToTextCheckBox);
            tabPage4.Controls.Add(_enablePersonNameFinderCheckBox);
            tabPage4.Controls.Add(_dedupEntityItemsCheckBox);
            tabPage4.Location = new System.Drawing.Point(4, 24);
            tabPage4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabPage4.Name = "tabPage4";
            tabPage4.Size = new System.Drawing.Size(405, 251);
            tabPage4.TabIndex = 2;
            tabPage4.Text = "Entity";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // _enablePiiItemsCheckCheckBox
            // 
            _enablePiiItemsCheckCheckBox.AutoSize = true;
            _enablePiiItemsCheckCheckBox.Location = new System.Drawing.Point(11, 11);
            _enablePiiItemsCheckCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            _enablePiiItemsCheckCheckBox.Name = "_enablePiiItemsCheckCheckBox";
            _enablePiiItemsCheckCheckBox.Size = new System.Drawing.Size(162, 19);
            _enablePiiItemsCheckCheckBox.TabIndex = 35;
            _enablePiiItemsCheckCheckBox.Text = "Enable Entity Item Checks";
            toolTip1.SetToolTip(_enablePiiItemsCheckCheckBox, "Enables or disables all entity item checks");
            _enablePiiItemsCheckCheckBox.UseVisualStyleBackColor = true;
            // 
            // _enableEmojiEntityDetectionCheckBox
            // 
            _enableEmojiEntityDetectionCheckBox.AutoSize = true;
            _enableEmojiEntityDetectionCheckBox.Location = new System.Drawing.Point(10, 119);
            _enableEmojiEntityDetectionCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            _enableEmojiEntityDetectionCheckBox.Name = "_enableEmojiEntityDetectionCheckBox";
            _enableEmojiEntityDetectionCheckBox.Size = new System.Drawing.Size(181, 19);
            _enableEmojiEntityDetectionCheckBox.TabIndex = 34;
            _enableEmojiEntityDetectionCheckBox.Text = "Enable Emoji Entity Detection";
            _enableEmojiEntityDetectionCheckBox.UseVisualStyleBackColor = true;
            // 
            // _enableEntityPersonNameChecksInBinaryToTextCheckBox
            // 
            _enableEntityPersonNameChecksInBinaryToTextCheckBox.AutoSize = true;
            _enableEntityPersonNameChecksInBinaryToTextCheckBox.Location = new System.Drawing.Point(10, 94);
            _enableEntityPersonNameChecksInBinaryToTextCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            _enableEntityPersonNameChecksInBinaryToTextCheckBox.Name = "_enableEntityPersonNameChecksInBinaryToTextCheckBox";
            _enableEntityPersonNameChecksInBinaryToTextCheckBox.Size = new System.Drawing.Size(341, 19);
            _enableEntityPersonNameChecksInBinaryToTextCheckBox.TabIndex = 33;
            _enableEntityPersonNameChecksInBinaryToTextCheckBox.Text = "Enable 'PersonName' Checks in Binary-to-Text Filtered Files ";
            _enableEntityPersonNameChecksInBinaryToTextCheckBox.UseVisualStyleBackColor = true;
            // 
            // _enablePersonNameFinderCheckBox
            // 
            _enablePersonNameFinderCheckBox.AutoSize = true;
            _enablePersonNameFinderCheckBox.Location = new System.Drawing.Point(10, 69);
            _enablePersonNameFinderCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            _enablePersonNameFinderCheckBox.Name = "_enablePersonNameFinderCheckBox";
            _enablePersonNameFinderCheckBox.Size = new System.Drawing.Size(240, 19);
            _enablePersonNameFinderCheckBox.TabIndex = 32;
            _enablePersonNameFinderCheckBox.Text = "Enable 'PersonName\" entity name finder";
            toolTip1.SetToolTip(_enablePersonNameFinderCheckBox, "Enables or disables 'PersonName'  entity name finder");
            _enablePersonNameFinderCheckBox.UseVisualStyleBackColor = true;
            // 
            // _dedupEntityItemsCheckBox
            // 
            _dedupEntityItemsCheckBox.AutoSize = true;
            _dedupEntityItemsCheckBox.Location = new System.Drawing.Point(10, 44);
            _dedupEntityItemsCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            _dedupEntityItemsCheckBox.Name = "_dedupEntityItemsCheckBox";
            _dedupEntityItemsCheckBox.Size = new System.Drawing.Size(154, 19);
            _dedupEntityItemsCheckBox.TabIndex = 2;
            _dedupEntityItemsCheckBox.Text = "Deduplicate Entity Items";
            _dedupEntityItemsCheckBox.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            tabPage5.Controls.Add(_numCustItemDefsLoadedLabel);
            tabPage5.Controls.Add(_loadCustomSensitiveItemDefButton);
            tabPage5.Controls.Add(_customSensitiveItemCheckBox);
            tabPage5.Location = new System.Drawing.Point(4, 24);
            tabPage5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabPage5.Name = "tabPage5";
            tabPage5.Size = new System.Drawing.Size(405, 251);
            tabPage5.TabIndex = 3;
            tabPage5.Text = "Custom Items";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // _numCustItemDefsLoadedLabel
            // 
            _numCustItemDefsLoadedLabel.AutoSize = true;
            _numCustItemDefsLoadedLabel.Location = new System.Drawing.Point(15, 85);
            _numCustItemDefsLoadedLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            _numCustItemDefsLoadedLabel.Name = "_numCustItemDefsLoadedLabel";
            _numCustItemDefsLoadedLabel.Size = new System.Drawing.Size(0, 15);
            _numCustItemDefsLoadedLabel.TabIndex = 4;
            // 
            // _loadCustomSensitiveItemDefButton
            // 
            _loadCustomSensitiveItemDefButton.Location = new System.Drawing.Point(14, 37);
            _loadCustomSensitiveItemDefButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            _loadCustomSensitiveItemDefButton.Name = "_loadCustomSensitiveItemDefButton";
            _loadCustomSensitiveItemDefButton.Size = new System.Drawing.Size(296, 27);
            _loadCustomSensitiveItemDefButton.TabIndex = 3;
            _loadCustomSensitiveItemDefButton.Text = "Load File with CustomItemDefinitions...";
            _loadCustomSensitiveItemDefButton.UseVisualStyleBackColor = true;
            _loadCustomSensitiveItemDefButton.Click += _loadCustomSensitiveItemDefButton_Click;
            // 
            // _customSensitiveItemCheckBox
            // 
            _customSensitiveItemCheckBox.AutoSize = true;
            _customSensitiveItemCheckBox.Location = new System.Drawing.Point(14, 10);
            _customSensitiveItemCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            _customSensitiveItemCheckBox.Name = "_customSensitiveItemCheckBox";
            _customSensitiveItemCheckBox.Size = new System.Drawing.Size(152, 19);
            _customSensitiveItemCheckBox.TabIndex = 2;
            _customSensitiveItemCheckBox.Text = "Check for custom items";
            _customSensitiveItemCheckBox.UseVisualStyleBackColor = true;
            // 
            // _timeZoneTabPage
            // 
            _timeZoneTabPage.Controls.Add(_extractAllKnownOutlookMAPIPropertiesCheckBox);
            _timeZoneTabPage.Controls.Add(_UserMapiPropertyRequestsButton);
            _timeZoneTabPage.Controls.Add(_displayEmailRecipientNameAndSmtpCheckBox);
            _timeZoneTabPage.Controls.Add(_showUtcOffsetForTimeCheckBox);
            _timeZoneTabPage.Controls.Add(_selectedEmailDateFormatComboBox);
            _timeZoneTabPage.Controls.Add(label5);
            _timeZoneTabPage.Controls.Add(_selectedTimeZoneComboBox);
            _timeZoneTabPage.Controls.Add(label1);
            _timeZoneTabPage.Controls.Add(_setDateTimeUnspecifiedMetaToUtcCheckBox);
            _timeZoneTabPage.Location = new System.Drawing.Point(4, 24);
            _timeZoneTabPage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            _timeZoneTabPage.Name = "_timeZoneTabPage";
            _timeZoneTabPage.Size = new System.Drawing.Size(422, 287);
            _timeZoneTabPage.TabIndex = 3;
            _timeZoneTabPage.Text = "TimeZoneAndEmail";
            _timeZoneTabPage.UseVisualStyleBackColor = true;
            // 
            // _extractAllKnownOutlookMAPIPropertiesCheckBox
            // 
            _extractAllKnownOutlookMAPIPropertiesCheckBox.Location = new System.Drawing.Point(8, 205);
            _extractAllKnownOutlookMAPIPropertiesCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            _extractAllKnownOutlookMAPIPropertiesCheckBox.Name = "_extractAllKnownOutlookMAPIPropertiesCheckBox";
            _extractAllKnownOutlookMAPIPropertiesCheckBox.Size = new System.Drawing.Size(324, 24);
            _extractAllKnownOutlookMAPIPropertiesCheckBox.TabIndex = 31;
            _extractAllKnownOutlookMAPIPropertiesCheckBox.Text = "ExtractAllKnownOutlookMAPIProperties";
            toolTip1.SetToolTip(_extractAllKnownOutlookMAPIPropertiesCheckBox, "If true, all known MAPI properties are extracted from Outlook message files (.msg). If false, a focused subset of the most common and useful properties are extracted from Outlook message files.");
            _extractAllKnownOutlookMAPIPropertiesCheckBox.UseVisualStyleBackColor = true;
            // 
            // _UserMapiPropertyRequestsButton
            // 
            _UserMapiPropertyRequestsButton.Location = new System.Drawing.Point(37, 235);
            _UserMapiPropertyRequestsButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            _UserMapiPropertyRequestsButton.Name = "_UserMapiPropertyRequestsButton";
            _UserMapiPropertyRequestsButton.Size = new System.Drawing.Size(312, 33);
            _UserMapiPropertyRequestsButton.TabIndex = 30;
            _UserMapiPropertyRequestsButton.Text = "Add/Remove UserMapiPropertyRequests";
            _UserMapiPropertyRequestsButton.UseVisualStyleBackColor = true;
            _UserMapiPropertyRequestsButton.Click += _UserMapiPropertyRequestsButton_Click;
            // 
            // _displayEmailRecipientNameAndSmtpCheckBox
            // 
            _displayEmailRecipientNameAndSmtpCheckBox.Location = new System.Drawing.Point(8, 178);
            _displayEmailRecipientNameAndSmtpCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            _displayEmailRecipientNameAndSmtpCheckBox.Name = "_displayEmailRecipientNameAndSmtpCheckBox";
            _displayEmailRecipientNameAndSmtpCheckBox.Size = new System.Drawing.Size(324, 24);
            _displayEmailRecipientNameAndSmtpCheckBox.TabIndex = 29;
            _displayEmailRecipientNameAndSmtpCheckBox.Text = "DisplayEmailRecipientNameAndSmtp";
            toolTip1.SetToolTip(_displayEmailRecipientNameAndSmtpCheckBox, "For email types, if true, the SMTP email address (if known) is also included in the extracted text for each recipient (e.g., \"DisplayName <SMTP Address>\").");
            _displayEmailRecipientNameAndSmtpCheckBox.UseVisualStyleBackColor = true;
            // 
            // _showUtcOffsetForTimeCheckBox
            // 
            _showUtcOffsetForTimeCheckBox.Checked = true;
            _showUtcOffsetForTimeCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            _showUtcOffsetForTimeCheckBox.Location = new System.Drawing.Point(9, 146);
            _showUtcOffsetForTimeCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            _showUtcOffsetForTimeCheckBox.Name = "_showUtcOffsetForTimeCheckBox";
            _showUtcOffsetForTimeCheckBox.Size = new System.Drawing.Size(340, 37);
            _showUtcOffsetForTimeCheckBox.TabIndex = 28;
            _showUtcOffsetForTimeCheckBox.Text = "ShowUtcOffsetForTime (ex: 5/18/2007 7:30 AM UTC-07:00)";
            toolTip1.SetToolTip(_showUtcOffsetForTimeCheckBox, "If true, extracted text date/times for emails, appointments, tasks, journal objects, etc., are outputted with UTC offset.");
            _showUtcOffsetForTimeCheckBox.UseVisualStyleBackColor = true;
            // 
            // _selectedEmailDateFormatComboBox
            // 
            _selectedEmailDateFormatComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            _selectedEmailDateFormatComboBox.Location = new System.Drawing.Point(6, 119);
            _selectedEmailDateFormatComboBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            _selectedEmailDateFormatComboBox.Name = "_selectedEmailDateFormatComboBox";
            _selectedEmailDateFormatComboBox.Size = new System.Drawing.Size(340, 23);
            _selectedEmailDateFormatComboBox.TabIndex = 27;
            toolTip1.SetToolTip(_selectedEmailDateFormatComboBox, "Determines the extracted text format of email sent date, appointment start/end dates, task dates, and journal dates.");
            // 
            // label5
            // 
            label5.Location = new System.Drawing.Point(9, 95);
            label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(142, 23);
            label5.TabIndex = 26;
            label5.Text = "EmailDateTimeFormat:";
            label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _selectedTimeZoneComboBox
            // 
            _selectedTimeZoneComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            _selectedTimeZoneComboBox.Location = new System.Drawing.Point(7, 35);
            _selectedTimeZoneComboBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            _selectedTimeZoneComboBox.Name = "_selectedTimeZoneComboBox";
            _selectedTimeZoneComboBox.Size = new System.Drawing.Size(339, 23);
            _selectedTimeZoneComboBox.TabIndex = 25;
            toolTip1.SetToolTip(_selectedTimeZoneComboBox, "Determines the time zone of a document collection. ");
            // 
            // label1
            // 
            label1.Location = new System.Drawing.Point(5, 12);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(192, 20);
            label1.TabIndex = 24;
            label1.Text = "Collection TimeZone:";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _setDateTimeUnspecifiedMetaToUtcCheckBox
            // 
            _setDateTimeUnspecifiedMetaToUtcCheckBox.Location = new System.Drawing.Point(13, 67);
            _setDateTimeUnspecifiedMetaToUtcCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            _setDateTimeUnspecifiedMetaToUtcCheckBox.Name = "_setDateTimeUnspecifiedMetaToUtcCheckBox";
            _setDateTimeUnspecifiedMetaToUtcCheckBox.Size = new System.Drawing.Size(324, 24);
            _setDateTimeUnspecifiedMetaToUtcCheckBox.TabIndex = 23;
            _setDateTimeUnspecifiedMetaToUtcCheckBox.Text = "ApplyTimeZoneToMetadata ";
            toolTip1.SetToolTip(_setDateTimeUnspecifiedMetaToUtcCheckBox, "Determines if CollectionTimeZone is applied to extracted DateTime metadata with DateTime.Kind equal to DateTimeKind.Unspecified.");
            _setDateTimeUnspecifiedMetaToUtcCheckBox.UseVisualStyleBackColor = true;
            // 
            // _embeddedObjExtractionComboBox
            // 
            _embeddedObjExtractionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            _embeddedObjExtractionComboBox.Items.AddRange(new object[] { "None", "EmbeddedDocumentsOnly", "EmbeddedDocumentsAndMedia" });
            _embeddedObjExtractionComboBox.Location = new System.Drawing.Point(132, 44);
            _embeddedObjExtractionComboBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            _embeddedObjExtractionComboBox.Name = "_embeddedObjExtractionComboBox";
            _embeddedObjExtractionComboBox.Size = new System.Drawing.Size(226, 23);
            _embeddedObjExtractionComboBox.TabIndex = 23;
            toolTip1.SetToolTip(_embeddedObjExtractionComboBox, "Embedded document/attachment and embedded office media extraction setting.");
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(6, 48);
            label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(110, 15);
            label7.TabIndex = 22;
            label7.Text = "Embedded Objects:";
            // 
            // _extractionTypeComboBox
            // 
            _extractionTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            _extractionTypeComboBox.Items.AddRange(new object[] { "TextAndMetadata", "MetadataOnly" });
            _extractionTypeComboBox.Location = new System.Drawing.Point(132, 9);
            _extractionTypeComboBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            _extractionTypeComboBox.Name = "_extractionTypeComboBox";
            _extractionTypeComboBox.Size = new System.Drawing.Size(226, 23);
            _extractionTypeComboBox.TabIndex = 21;
            toolTip1.SetToolTip(_extractionTypeComboBox, "Text and metadata extraction setting.");
            _extractionTypeComboBox.SelectedIndexChanged += _extractionTypeComboBox_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(6, 14);
            label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(87, 15);
            label6.TabIndex = 20;
            label6.Text = "ExtractionType:";
            // 
            // label2
            // 
            label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            label2.AutoSize = true;
            label2.BackColor = System.Drawing.SystemColors.Control;
            label2.Location = new System.Drawing.Point(4, 560);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(30, 15);
            label2.TabIndex = 14;
            label2.Text = "Log:";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _tabControl
            // 
            _tabControl.Controls.Add(_contentTabPage);
            _tabControl.Controls.Add(_logTabPage);
            _tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            _tabControl.Location = new System.Drawing.Point(0, 0);
            _tabControl.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            _tabControl.Name = "_tabControl";
            _tabControl.SelectedIndex = 0;
            _tabControl.Size = new System.Drawing.Size(1127, 740);
            _tabControl.TabIndex = 0;
            // 
            // _contentTabPage
            // 
            _contentTabPage.Location = new System.Drawing.Point(4, 24);
            _contentTabPage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            _contentTabPage.Name = "_contentTabPage";
            _contentTabPage.Size = new System.Drawing.Size(1119, 712);
            _contentTabPage.TabIndex = 2;
            _contentTabPage.Text = "Content";
            _contentTabPage.UseVisualStyleBackColor = true;
            // 
            // _logTabPage
            // 
            _logTabPage.Controls.Add(_logTextBox);
            _logTabPage.Location = new System.Drawing.Point(4, 24);
            _logTabPage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            _logTabPage.Name = "_logTabPage";
            _logTabPage.Size = new System.Drawing.Size(1119, 712);
            _logTabPage.TabIndex = 3;
            _logTabPage.Text = "Log";
            _logTabPage.UseVisualStyleBackColor = true;
            // 
            // _logTextBox
            // 
            _logTextBox.AcceptsReturn = true;
            _logTextBox.BackColor = System.Drawing.Color.White;
            _logTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            _logTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            _logTextBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            _logTextBox.Location = new System.Drawing.Point(0, 0);
            _logTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            _logTextBox.Multiline = true;
            _logTextBox.Name = "_logTextBox";
            _logTextBox.ReadOnly = true;
            _logTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            _logTextBox.Size = new System.Drawing.Size(1119, 712);
            _logTextBox.TabIndex = 15;
            _logTextBox.WordWrap = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1601, 796);
            Controls.Add(splitContainer1);
            Controls.Add(menuStrip1);
            Controls.Add(statusStrip1);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "MainForm";
            Text = "Open Discover® SDK for .NET  -   Content Extraction Sample";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            _subSettingsTabControl.ResumeLayout(false);
            _hashingTabPage.ResumeLayout(false);
            _hashingTabPage.PerformLayout();
            _pdfTabPage.ResumeLayout(false);
            _pdfTabPage.PerformLayout();
            _langIdTabPage.ResumeLayout(false);
            _langIdTabPage.PerformLayout();
            _unsupportedTabPage.ResumeLayout(false);
            _unsupportedTabPage.PerformLayout();
            _piiCheckTabPage.ResumeLayout(false);
            _sensitiveItemTabControl.ResumeLayout(false);
            tabPage4.ResumeLayout(false);
            tabPage4.PerformLayout();
            tabPage5.ResumeLayout(false);
            tabPage5.PerformLayout();
            _timeZoneTabPage.ResumeLayout(false);
            _tabControl.ResumeLayout(false);
            _logTabPage.ResumeLayout(false);
            _logTabPage.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hexViewerModeToolStripMenuItem;
        private System.Windows.Forms.ListBox _filesListBox;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel fileNameLabel;
        private System.Windows.Forms.ToolStripStatusLabel _toolStripStatusLabel;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl _tabControl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage _contentTabPage;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStripMenuItem loadPasswordsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem passwordsToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabPage _logTabPage;
        private System.Windows.Forms.TextBox _logTextBox;
        private System.Windows.Forms.ComboBox _embeddedObjExtractionComboBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox _extractionTypeComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabControl _subSettingsTabControl;
        private System.Windows.Forms.TabPage _pdfTabPage;
        private System.Windows.Forms.TabPage _hashingTabPage;
        private System.Windows.Forms.TabPage _langIdTabPage;
        private System.Windows.Forms.TabPage _timeZoneTabPage;
        private System.Windows.Forms.CheckBox _showUtcOffsetForTimeCheckBox;
        private System.Windows.Forms.ComboBox _selectedEmailDateFormatComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox _selectedTimeZoneComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox _setDateTimeUnspecifiedMetaToUtcCheckBox;
        private System.Windows.Forms.TabPage _unsupportedTabPage;
        private System.Windows.Forms.CheckBox _partitionLatinScriptRegionsCheckBox;
        private System.Windows.Forms.ComboBox _latinScriptRegionSizeComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox _identifyLangInExtractedTextCheckBox;
        private System.Windows.Forms.CheckBox _displayEmailRecipientNameAndSmtpCheckBox;
        private System.Windows.Forms.ComboBox _pdfImageExtractionComboBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox _pdfPageExtractedTextCriteriaComboBox;
        private System.Windows.Forms.ComboBox _hashingTypeComboBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox _maxBinaryHashLengthComboBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ComboBox _maxLanguageIdCharactersComboBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox _filterMinWordLengthComboBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox _filteringTypeComboBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox _includeBccRecipientsInEmailContentHashCheckBox;
        private System.Windows.Forms.ComboBox _largeUnsupportedMaxFilteredCharsComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox _useLargeDocumentUTF16EncodingCheckBox;
        private System.Windows.Forms.ComboBox _largeDocumentCriteraComboBox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button _UserMapiPropertyRequestsButton;
        private System.Windows.Forms.TabPage _piiCheckTabPage;
        private System.Windows.Forms.CheckBox _calculateFileEntropyCheckBox;
        private System.Windows.Forms.TabControl _sensitiveItemTabControl;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.CheckBox _dedupEntityItemsCheckBox;
        private System.Windows.Forms.CheckBox _dedupSensitiveItemsCheckBox;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.CheckBox _customSensitiveItemCheckBox;
        private System.Windows.Forms.Button _loadCustomSensitiveItemDefButton;
        private System.Windows.Forms.Label _numCustItemDefsLoadedLabel;
        private System.Windows.Forms.CheckBox _enablePersonNameFinderCheckBox;
        private System.Windows.Forms.CheckBox _enableEmojiEntityDetectionCheckBox;
        private System.Windows.Forms.CheckBox _extractAllKnownOutlookMAPIPropertiesCheckBox;
        private System.Windows.Forms.CheckBox _enableEntityPersonNameChecksInBinaryToTextCheckBox;
        private System.Windows.Forms.CheckBox _enablePiiItemsCheckCheckBox;
    }
}

