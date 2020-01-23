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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._filesListBox = new System.Windows.Forms.ListBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.fileNameLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this._toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this._useLargeDocumentUTF16EncodingCheckBox = new System.Windows.Forms.CheckBox();
            this._largeDocumentCriteraComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this._subSettingsTabControl = new System.Windows.Forms.TabControl();
            this._hashingTabPage = new System.Windows.Forms.TabPage();
            this._includeBccRecipientsInEmailContentHashCheckBox = new System.Windows.Forms.CheckBox();
            this._maxBinaryHashLengthComboBox = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this._hashingTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this._pdfTabPage = new System.Windows.Forms.TabPage();
            this._pdfPageExtractedTextCriteriaComboBox = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this._pdfImageExtractionComboBox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this._langIdTabPage = new System.Windows.Forms.TabPage();
            this._maxLanguageIdCharactersComboBox = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this._partitionLatinScriptRegionsCheckBox = new System.Windows.Forms.CheckBox();
            this._latinScriptRegionSizeComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this._identifyLangInExtractedTextCheckBox = new System.Windows.Forms.CheckBox();
            this._unsupportedTabPage = new System.Windows.Forms.TabPage();
            this._largeUnsupportedMaxFilteredCharsComboBox = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this._filterMinWordLengthComboBox = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this._filteringTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this._timeZoneTabPage = new System.Windows.Forms.TabPage();
            this._displayEmailRecipientNameAndSmtpCheckBox = new System.Windows.Forms.CheckBox();
            this._showUtcOffsetForTimeCheckBox = new System.Windows.Forms.CheckBox();
            this._selectedEmailDateFormatComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this._selectedTimeZoneComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this._setDateTimeUnspecifiedMetaToUtcCheckBox = new System.Windows.Forms.CheckBox();
            this._embeddedObjExtractionComboBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this._extractionTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._tabControl = new System.Windows.Forms.TabControl();
            this._contentTabPage = new System.Windows.Forms.TabPage();
            this._logTabPage = new System.Windows.Forms.TabPage();
            this._logTextBox = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this._piiTabPage = new System.Windows.Forms.TabPage();
            this._enablePiiItemsCheckCheckBox = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this._subSettingsTabControl.SuspendLayout();
            this._hashingTabPage.SuspendLayout();
            this._pdfTabPage.SuspendLayout();
            this._langIdTabPage.SuspendLayout();
            this._unsupportedTabPage.SuspendLayout();
            this._timeZoneTabPage.SuspendLayout();
            this._tabControl.SuspendLayout();
            this._logTabPage.SuspendLayout();
            this._piiTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1372, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openFileMenuItem
            // 
            this.openFileMenuItem.Name = "openFileMenuItem";
            this.openFileMenuItem.Size = new System.Drawing.Size(112, 22);
            this.openFileMenuItem.Text = "Open...";
            this.openFileMenuItem.Click += new System.EventHandler(this.openFileMenuItem_Click);
            // 
            // _filesListBox
            // 
            this._filesListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._filesListBox.DisplayMember = "Filename";
            this._filesListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._filesListBox.FormattingEnabled = true;
            this._filesListBox.Location = new System.Drawing.Point(0, 0);
            this._filesListBox.Name = "_filesListBox";
            this._filesListBox.Size = new System.Drawing.Size(385, 257);
            this._filesListBox.TabIndex = 7;
            this._filesListBox.ValueMember = "Path";
            this._filesListBox.SelectedIndexChanged += new System.EventHandler(this._filesListBox_SelectedIndexChanged);
            this._filesListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this._filesListBox_MouseDoubleClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileNameLabel,
            this._toolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 668);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1372, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // fileNameLabel
            // 
            this.fileNameLabel.Name = "fileNameLabel";
            this.fileNameLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // _toolStripStatusLabel
            // 
            this._toolStripStatusLabel.Name = "_toolStripStatusLabel";
            this._toolStripStatusLabel.Size = new System.Drawing.Size(42, 17);
            this._toolStripStatusLabel.Text = "Ready.";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Location = new System.Drawing.Point(7, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this._tabControl);
            this.splitContainer1.Size = new System.Drawing.Size(1360, 641);
            this.splitContainer1.SplitterDistance = 385;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 10;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this._filesListBox);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer2.Size = new System.Drawing.Size(385, 641);
            this.splitContainer2.SplitterDistance = 257;
            this.splitContainer2.SplitterWidth = 6;
            this.splitContainer2.TabIndex = 15;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(385, 378);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(377, 352);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "ContentExtractionSettings";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this._useLargeDocumentUTF16EncodingCheckBox);
            this.panel1.Controls.Add(this._largeDocumentCriteraComboBox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this._subSettingsTabControl);
            this.panel1.Controls.Add(this._embeddedObjExtractionComboBox);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this._extractionTypeComboBox);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(371, 346);
            this.panel1.TabIndex = 13;
            // 
            // _useLargeDocumentUTF16EncodingCheckBox
            // 
            this._useLargeDocumentUTF16EncodingCheckBox.AutoSize = true;
            this._useLargeDocumentUTF16EncodingCheckBox.Location = new System.Drawing.Point(6, 323);
            this._useLargeDocumentUTF16EncodingCheckBox.Name = "_useLargeDocumentUTF16EncodingCheckBox";
            this._useLargeDocumentUTF16EncodingCheckBox.Size = new System.Drawing.Size(199, 17);
            this._useLargeDocumentUTF16EncodingCheckBox.TabIndex = 34;
            this._useLargeDocumentUTF16EncodingCheckBox.Text = "UseLargeDocumentUTF16Encoding";
            this.toolTip1.SetToolTip(this._useLargeDocumentUTF16EncodingCheckBox, resources.GetString("_useLargeDocumentUTF16EncodingCheckBox.ToolTip"));
            this._useLargeDocumentUTF16EncodingCheckBox.UseVisualStyleBackColor = true;
            // 
            // _largeDocumentCriteraComboBox
            // 
            this._largeDocumentCriteraComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._largeDocumentCriteraComboBox.Items.AddRange(new object[] {
            "52,428,800 (50 MB)",
            "78,643,200 (75 MB)",
            "104,857,600 (100 MB)",
            "157,286,400 (150 MB)",
            "209,715,200 (200 MB)",
            "262,144,000 (250 MB)",
            "419,430,400 (400 MB)",
            "524,288,000 (500 MB)",
            "1,073,741,824 (1000 MB)"});
            this._largeDocumentCriteraComboBox.Location = new System.Drawing.Point(124, 296);
            this._largeDocumentCriteraComboBox.Name = "_largeDocumentCriteraComboBox";
            this._largeDocumentCriteraComboBox.Size = new System.Drawing.Size(194, 21);
            this._largeDocumentCriteraComboBox.TabIndex = 33;
            this.toolTip1.SetToolTip(this._largeDocumentCriteraComboBox, resources.GetString("_largeDocumentCriteraComboBox.ToolTip"));
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 300);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "LargeDocumentCritera:";
            // 
            // _subSettingsTabControl
            // 
            this._subSettingsTabControl.Controls.Add(this._hashingTabPage);
            this._subSettingsTabControl.Controls.Add(this._pdfTabPage);
            this._subSettingsTabControl.Controls.Add(this._langIdTabPage);
            this._subSettingsTabControl.Controls.Add(this._unsupportedTabPage);
            this._subSettingsTabControl.Controls.Add(this._timeZoneTabPage);
            this._subSettingsTabControl.Controls.Add(this._piiTabPage);
            this._subSettingsTabControl.Location = new System.Drawing.Point(5, 66);
            this._subSettingsTabControl.Name = "_subSettingsTabControl";
            this._subSettingsTabControl.SelectedIndex = 0;
            this._subSettingsTabControl.Size = new System.Drawing.Size(363, 226);
            this._subSettingsTabControl.TabIndex = 24;
            // 
            // _hashingTabPage
            // 
            this._hashingTabPage.Controls.Add(this._includeBccRecipientsInEmailContentHashCheckBox);
            this._hashingTabPage.Controls.Add(this._maxBinaryHashLengthComboBox);
            this._hashingTabPage.Controls.Add(this.label11);
            this._hashingTabPage.Controls.Add(this._hashingTypeComboBox);
            this._hashingTabPage.Controls.Add(this.label10);
            this._hashingTabPage.Location = new System.Drawing.Point(4, 22);
            this._hashingTabPage.Name = "_hashingTabPage";
            this._hashingTabPage.Padding = new System.Windows.Forms.Padding(3);
            this._hashingTabPage.Size = new System.Drawing.Size(355, 200);
            this._hashingTabPage.TabIndex = 1;
            this._hashingTabPage.Text = "Hashing";
            this._hashingTabPage.UseVisualStyleBackColor = true;
            // 
            // _includeBccRecipientsInEmailContentHashCheckBox
            // 
            this._includeBccRecipientsInEmailContentHashCheckBox.AutoSize = true;
            this._includeBccRecipientsInEmailContentHashCheckBox.Location = new System.Drawing.Point(9, 104);
            this._includeBccRecipientsInEmailContentHashCheckBox.Name = "_includeBccRecipientsInEmailContentHashCheckBox";
            this._includeBccRecipientsInEmailContentHashCheckBox.Size = new System.Drawing.Size(226, 17);
            this._includeBccRecipientsInEmailContentHashCheckBox.TabIndex = 30;
            this._includeBccRecipientsInEmailContentHashCheckBox.Text = "IncludeBccRecipientsInEmailContentHash";
            this.toolTip1.SetToolTip(this._includeBccRecipientsInEmailContentHashCheckBox, "If true, includes email \'Bcc\' recipients in the email overall recipient hash (see" +
        " properties EmailDocumentContent.Sha1RecipientsHash ");
            this._includeBccRecipientsInEmailContentHashCheckBox.UseVisualStyleBackColor = true;
            // 
            // _maxBinaryHashLengthComboBox
            // 
            this._maxBinaryHashLengthComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._maxBinaryHashLengthComboBox.Items.AddRange(new object[] {
            "-1 (no byte length limit)",
            "104,857,600‬ (100 MB)",
            "209,715,200‬ (200 MB)",
            "524,288,000‬‬ (500 MB)",
            "1,048,576,000‬‬ (1 GB)",
            "5,242,880,000‬ (5 GB)",
            "10,485,760,000‬ (10 GB)",
            "20,971,520,000 (20 GB)",
            "52,428,800,000 (50 GB)"});
            this._maxBinaryHashLengthComboBox.Location = new System.Drawing.Point(129, 57);
            this._maxBinaryHashLengthComboBox.Name = "_maxBinaryHashLengthComboBox";
            this._maxBinaryHashLengthComboBox.Size = new System.Drawing.Size(163, 21);
            this._maxBinaryHashLengthComboBox.TabIndex = 29;
            this.toolTip1.SetToolTip(this._maxBinaryHashLengthComboBox, "Maximum number of bytes to use for MD5/SHA-1 binary hash (digest) calculation");
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 60);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(117, 13);
            this.label11.TabIndex = 28;
            this.label11.Text = "MaxBinaryHashLength:";
            // 
            // _hashingTypeComboBox
            // 
            this._hashingTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._hashingTypeComboBox.Items.AddRange(new object[] {
            "None",
            "BinaryHashOnly",
            "BinaryAndContentHash"});
            this._hashingTypeComboBox.Location = new System.Drawing.Point(95, 18);
            this._hashingTypeComboBox.Name = "_hashingTypeComboBox";
            this._hashingTypeComboBox.Size = new System.Drawing.Size(197, 21);
            this._hashingTypeComboBox.TabIndex = 25;
            this.toolTip1.SetToolTip(this._hashingTypeComboBox, "Document hashing type.");
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "HashingType:";
            // 
            // _pdfTabPage
            // 
            this._pdfTabPage.Controls.Add(this._pdfPageExtractedTextCriteriaComboBox);
            this._pdfTabPage.Controls.Add(this.label9);
            this._pdfTabPage.Controls.Add(this._pdfImageExtractionComboBox);
            this._pdfTabPage.Controls.Add(this.label8);
            this._pdfTabPage.Location = new System.Drawing.Point(4, 22);
            this._pdfTabPage.Name = "_pdfTabPage";
            this._pdfTabPage.Size = new System.Drawing.Size(355, 200);
            this._pdfTabPage.TabIndex = 5;
            this._pdfTabPage.Text = "PDF";
            this._pdfTabPage.UseVisualStyleBackColor = true;
            // 
            // _pdfPageExtractedTextCriteriaComboBox
            // 
            this._pdfPageExtractedTextCriteriaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._pdfPageExtractedTextCriteriaComboBox.Items.AddRange(new object[] {
            "0",
            "1",
            "5",
            "10",
            "15",
            "20",
            "25",
            "30",
            "40",
            "50",
            "100"});
            this._pdfPageExtractedTextCriteriaComboBox.Location = new System.Drawing.Point(185, 53);
            this._pdfPageExtractedTextCriteriaComboBox.Name = "_pdfPageExtractedTextCriteriaComboBox";
            this._pdfPageExtractedTextCriteriaComboBox.Size = new System.Drawing.Size(105, 21);
            this._pdfPageExtractedTextCriteriaComboBox.TabIndex = 27;
            this.toolTip1.SetToolTip(this._pdfPageExtractedTextCriteriaComboBox, "Minimum PDF page extracted text length (in characters) criteria");
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(168, 13);
            this.label9.TabIndex = 26;
            this.label9.Text = "PageExtractedTextCriteria [chars]:";
            // 
            // _pdfImageExtractionComboBox
            // 
            this._pdfImageExtractionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._pdfImageExtractionComboBox.Items.AddRange(new object[] {
            "None",
            "OnlyFailedPdfPages",
            "AllPdfPages"});
            this._pdfImageExtractionComboBox.Location = new System.Drawing.Point(96, 20);
            this._pdfImageExtractionComboBox.Name = "_pdfImageExtractionComboBox";
            this._pdfImageExtractionComboBox.Size = new System.Drawing.Size(195, 21);
            this._pdfImageExtractionComboBox.TabIndex = 25;
            this.toolTip1.SetToolTip(this._pdfImageExtractionComboBox, "PDF page image extraction.");
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 13);
            this.label8.TabIndex = 24;
            this.label8.Text = "ImageExtraction:";
            // 
            // _langIdTabPage
            // 
            this._langIdTabPage.Controls.Add(this._maxLanguageIdCharactersComboBox);
            this._langIdTabPage.Controls.Add(this.label12);
            this._langIdTabPage.Controls.Add(this._partitionLatinScriptRegionsCheckBox);
            this._langIdTabPage.Controls.Add(this._latinScriptRegionSizeComboBox);
            this._langIdTabPage.Controls.Add(this.label4);
            this._langIdTabPage.Controls.Add(this._identifyLangInExtractedTextCheckBox);
            this._langIdTabPage.Location = new System.Drawing.Point(4, 22);
            this._langIdTabPage.Name = "_langIdTabPage";
            this._langIdTabPage.Size = new System.Drawing.Size(355, 200);
            this._langIdTabPage.TabIndex = 2;
            this._langIdTabPage.Text = "LangId";
            this._langIdTabPage.UseVisualStyleBackColor = true;
            // 
            // _maxLanguageIdCharactersComboBox
            // 
            this._maxLanguageIdCharactersComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._maxLanguageIdCharactersComboBox.Items.AddRange(new object[] {
            "5000",
            "10000",
            "20000",
            "50000",
            "100000",
            "200000",
            "500000",
            "1000000",
            "5000000",
            "10000000"});
            this._maxLanguageIdCharactersComboBox.Location = new System.Drawing.Point(175, 41);
            this._maxLanguageIdCharactersComboBox.Name = "_maxLanguageIdCharactersComboBox";
            this._maxLanguageIdCharactersComboBox.Size = new System.Drawing.Size(115, 21);
            this._maxLanguageIdCharactersComboBox.TabIndex = 26;
            this.toolTip1.SetToolTip(this._maxLanguageIdCharactersComboBox, "Maximum number of characters in extracted text to use for language identification" +
        ".");
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(6, 39);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(165, 23);
            this.label12.TabIndex = 25;
            this.label12.Text = "MaxLanguageIdCharacters:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _partitionLatinScriptRegionsCheckBox
            // 
            this._partitionLatinScriptRegionsCheckBox.AutoSize = true;
            this._partitionLatinScriptRegionsCheckBox.Location = new System.Drawing.Point(9, 83);
            this._partitionLatinScriptRegionsCheckBox.Name = "_partitionLatinScriptRegionsCheckBox";
            this._partitionLatinScriptRegionsCheckBox.Size = new System.Drawing.Size(153, 17);
            this._partitionLatinScriptRegionsCheckBox.TabIndex = 24;
            this._partitionLatinScriptRegionsCheckBox.Text = "PartitionLatinScriptRegions";
            this.toolTip1.SetToolTip(this._partitionLatinScriptRegionsCheckBox, "Determines if Latin script regions detected during the language identification pr" +
        "ocess are partitioned into smaller regions ");
            this._partitionLatinScriptRegionsCheckBox.UseVisualStyleBackColor = true;
            // 
            // _latinScriptRegionSizeComboBox
            // 
            this._latinScriptRegionSizeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._latinScriptRegionSizeComboBox.Items.AddRange(new object[] {
            "150",
            "250",
            "350",
            "500",
            "750",
            "1000",
            "2000",
            "3000",
            "4000",
            "5000",
            "10000",
            "20000",
            "50000"});
            this._latinScriptRegionSizeComboBox.Location = new System.Drawing.Point(175, 108);
            this._latinScriptRegionSizeComboBox.Name = "_latinScriptRegionSizeComboBox";
            this._latinScriptRegionSizeComboBox.Size = new System.Drawing.Size(115, 21);
            this._latinScriptRegionSizeComboBox.TabIndex = 23;
            this.toolTip1.SetToolTip(this._latinScriptRegionSizeComboBox, "Used by language identification algorithm to partition detected Latin script regi" +
        "ons into smaller character ranges of this size. ");
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(165, 23);
            this.label4.TabIndex = 22;
            this.label4.Text = "LatinScriptRegionPartitionSize:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _identifyLangInExtractedTextCheckBox
            // 
            this._identifyLangInExtractedTextCheckBox.AutoSize = true;
            this._identifyLangInExtractedTextCheckBox.Checked = true;
            this._identifyLangInExtractedTextCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this._identifyLangInExtractedTextCheckBox.Location = new System.Drawing.Point(9, 19);
            this._identifyLangInExtractedTextCheckBox.Name = "_identifyLangInExtractedTextCheckBox";
            this._identifyLangInExtractedTextCheckBox.Size = new System.Drawing.Size(113, 17);
            this._identifyLangInExtractedTextCheckBox.TabIndex = 21;
            this._identifyLangInExtractedTextCheckBox.Text = "IdentifyLanguages";
            this.toolTip1.SetToolTip(this._identifyLangInExtractedTextCheckBox, "Determines if languages present in extract text are to be identified by content e" +
        "xtractors.");
            this._identifyLangInExtractedTextCheckBox.UseVisualStyleBackColor = true;
            // 
            // _unsupportedTabPage
            // 
            this._unsupportedTabPage.Controls.Add(this._largeUnsupportedMaxFilteredCharsComboBox);
            this._unsupportedTabPage.Controls.Add(this.label15);
            this._unsupportedTabPage.Controls.Add(this._filterMinWordLengthComboBox);
            this._unsupportedTabPage.Controls.Add(this.label13);
            this._unsupportedTabPage.Controls.Add(this._filteringTypeComboBox);
            this._unsupportedTabPage.Controls.Add(this.label14);
            this._unsupportedTabPage.Location = new System.Drawing.Point(4, 22);
            this._unsupportedTabPage.Name = "_unsupportedTabPage";
            this._unsupportedTabPage.Size = new System.Drawing.Size(355, 200);
            this._unsupportedTabPage.TabIndex = 4;
            this._unsupportedTabPage.Text = "Unsupported";
            this._unsupportedTabPage.UseVisualStyleBackColor = true;
            // 
            // _largeUnsupportedMaxFilteredCharsComboBox
            // 
            this._largeUnsupportedMaxFilteredCharsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._largeUnsupportedMaxFilteredCharsComboBox.Items.AddRange(new object[] {
            "1,048,576",
            "2,000,000",
            "3,000,000",
            "4,000,000",
            "5,000,000",
            "10,000,000",
            "20,000,000",
            "50,000,000",
            "100,000,000"});
            this._largeUnsupportedMaxFilteredCharsComboBox.Location = new System.Drawing.Point(8, 125);
            this._largeUnsupportedMaxFilteredCharsComboBox.Name = "_largeUnsupportedMaxFilteredCharsComboBox";
            this._largeUnsupportedMaxFilteredCharsComboBox.Size = new System.Drawing.Size(275, 21);
            this._largeUnsupportedMaxFilteredCharsComboBox.TabIndex = 37;
            this.toolTip1.SetToolTip(this._largeUnsupportedMaxFilteredCharsComboBox, "Limits the numbers of filtered characters that are written to a stream (should be" +
        " a FileStream) by ILargeUnsupportedExtractor.ExtractContent(System.IO.Stream).");
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(5, 107);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(214, 13);
            this.label15.TabIndex = 36;
            this.label15.Text = "LargeUnsupportedMaxFilteredChars [chars]:";
            // 
            // _filterMinWordLengthComboBox
            // 
            this._filterMinWordLengthComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._filterMinWordLengthComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this._filterMinWordLengthComboBox.Location = new System.Drawing.Point(154, 58);
            this._filterMinWordLengthComboBox.Name = "_filterMinWordLengthComboBox";
            this._filterMinWordLengthComboBox.Size = new System.Drawing.Size(129, 21);
            this._filterMinWordLengthComboBox.TabIndex = 33;
            this.toolTip1.SetToolTip(this._filterMinWordLengthComboBox, "Minimum word length, in characters, for binary-to-text filtering. If filtered wor" +
        "d lengths are less than this value they will not show up in extracted text. ");
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(5, 61);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(143, 13);
            this.label13.TabIndex = 32;
            this.label13.Text = "FilterMinWordLength [chars]:";
            // 
            // _filteringTypeComboBox
            // 
            this._filteringTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._filteringTypeComboBox.Items.AddRange(new object[] {
            "None",
            "Unsupported",
            "UnsupportedAndEncrypted"});
            this._filteringTypeComboBox.Location = new System.Drawing.Point(92, 19);
            this._filteringTypeComboBox.Name = "_filteringTypeComboBox";
            this._filteringTypeComboBox.Size = new System.Drawing.Size(191, 21);
            this._filteringTypeComboBox.TabIndex = 31;
            this.toolTip1.SetToolTip(this._filteringTypeComboBox, "Binary-to-text filtering of unsupported/unknown document file format options.");
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(5, 23);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(70, 13);
            this.label14.TabIndex = 30;
            this.label14.Text = "FilteringType:";
            // 
            // _timeZoneTabPage
            // 
            this._timeZoneTabPage.Controls.Add(this._displayEmailRecipientNameAndSmtpCheckBox);
            this._timeZoneTabPage.Controls.Add(this._showUtcOffsetForTimeCheckBox);
            this._timeZoneTabPage.Controls.Add(this._selectedEmailDateFormatComboBox);
            this._timeZoneTabPage.Controls.Add(this.label5);
            this._timeZoneTabPage.Controls.Add(this._selectedTimeZoneComboBox);
            this._timeZoneTabPage.Controls.Add(this.label1);
            this._timeZoneTabPage.Controls.Add(this._setDateTimeUnspecifiedMetaToUtcCheckBox);
            this._timeZoneTabPage.Location = new System.Drawing.Point(4, 22);
            this._timeZoneTabPage.Name = "_timeZoneTabPage";
            this._timeZoneTabPage.Size = new System.Drawing.Size(355, 200);
            this._timeZoneTabPage.TabIndex = 3;
            this._timeZoneTabPage.Text = "TimeZoneAndEmail";
            this._timeZoneTabPage.UseVisualStyleBackColor = true;
            // 
            // _displayEmailRecipientNameAndSmtpCheckBox
            // 
            this._displayEmailRecipientNameAndSmtpCheckBox.Location = new System.Drawing.Point(7, 170);
            this._displayEmailRecipientNameAndSmtpCheckBox.Name = "_displayEmailRecipientNameAndSmtpCheckBox";
            this._displayEmailRecipientNameAndSmtpCheckBox.Size = new System.Drawing.Size(278, 21);
            this._displayEmailRecipientNameAndSmtpCheckBox.TabIndex = 29;
            this._displayEmailRecipientNameAndSmtpCheckBox.Text = "DisplayEmailRecipientNameAndSmtp";
            this.toolTip1.SetToolTip(this._displayEmailRecipientNameAndSmtpCheckBox, "For email types, if true, the SMTP email address (if known) is also included in t" +
        "he extracted text for each recipient (e.g., \"DisplayName <SMTP Address>\").");
            this._displayEmailRecipientNameAndSmtpCheckBox.UseVisualStyleBackColor = true;
            // 
            // _showUtcOffsetForTimeCheckBox
            // 
            this._showUtcOffsetForTimeCheckBox.Checked = true;
            this._showUtcOffsetForTimeCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this._showUtcOffsetForTimeCheckBox.Location = new System.Drawing.Point(8, 132);
            this._showUtcOffsetForTimeCheckBox.Name = "_showUtcOffsetForTimeCheckBox";
            this._showUtcOffsetForTimeCheckBox.Size = new System.Drawing.Size(291, 32);
            this._showUtcOffsetForTimeCheckBox.TabIndex = 28;
            this._showUtcOffsetForTimeCheckBox.Text = "ShowUtcOffsetForTime (ex: 5/18/2007 7:30 AM UTC-07:00)";
            this.toolTip1.SetToolTip(this._showUtcOffsetForTimeCheckBox, "If true, extracted text date/times for emails, appointments, tasks, journal objec" +
        "ts, etc., are outputted with UTC offset.");
            this._showUtcOffsetForTimeCheckBox.UseVisualStyleBackColor = true;
            // 
            // _selectedEmailDateFormatComboBox
            // 
            this._selectedEmailDateFormatComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._selectedEmailDateFormatComboBox.Location = new System.Drawing.Point(5, 103);
            this._selectedEmailDateFormatComboBox.Name = "_selectedEmailDateFormatComboBox";
            this._selectedEmailDateFormatComboBox.Size = new System.Drawing.Size(292, 21);
            this._selectedEmailDateFormatComboBox.TabIndex = 27;
            this.toolTip1.SetToolTip(this._selectedEmailDateFormatComboBox, "Determines the extracted text format of email sent date, appointment start/end da" +
        "tes, task dates, and journal dates.");
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 20);
            this.label5.TabIndex = 26;
            this.label5.Text = "EmailDateTimeFormat:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _selectedTimeZoneComboBox
            // 
            this._selectedTimeZoneComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._selectedTimeZoneComboBox.Location = new System.Drawing.Point(6, 30);
            this._selectedTimeZoneComboBox.Name = "_selectedTimeZoneComboBox";
            this._selectedTimeZoneComboBox.Size = new System.Drawing.Size(291, 21);
            this._selectedTimeZoneComboBox.TabIndex = 25;
            this.toolTip1.SetToolTip(this._selectedTimeZoneComboBox, "Determines the time zone of a document collection. ");
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(4, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 17);
            this.label1.TabIndex = 24;
            this.label1.Text = "Collection TimeZone:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _setDateTimeUnspecifiedMetaToUtcCheckBox
            // 
            this._setDateTimeUnspecifiedMetaToUtcCheckBox.Location = new System.Drawing.Point(11, 58);
            this._setDateTimeUnspecifiedMetaToUtcCheckBox.Name = "_setDateTimeUnspecifiedMetaToUtcCheckBox";
            this._setDateTimeUnspecifiedMetaToUtcCheckBox.Size = new System.Drawing.Size(278, 21);
            this._setDateTimeUnspecifiedMetaToUtcCheckBox.TabIndex = 23;
            this._setDateTimeUnspecifiedMetaToUtcCheckBox.Text = "ApplyTimeZoneToMetadata ";
            this.toolTip1.SetToolTip(this._setDateTimeUnspecifiedMetaToUtcCheckBox, "Determines if CollectionTimeZone is applied to extracted DateTime metadata with D" +
        "ateTime.Kind equal to DateTimeKind.Unspecified.");
            this._setDateTimeUnspecifiedMetaToUtcCheckBox.UseVisualStyleBackColor = true;
            // 
            // _embeddedObjExtractionComboBox
            // 
            this._embeddedObjExtractionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._embeddedObjExtractionComboBox.Items.AddRange(new object[] {
            "None",
            "EmbeddedDocumentsOnly",
            "EmbeddedDocumentsAndMedia"});
            this._embeddedObjExtractionComboBox.Location = new System.Drawing.Point(113, 38);
            this._embeddedObjExtractionComboBox.Name = "_embeddedObjExtractionComboBox";
            this._embeddedObjExtractionComboBox.Size = new System.Drawing.Size(207, 21);
            this._embeddedObjExtractionComboBox.TabIndex = 23;
            this.toolTip1.SetToolTip(this._embeddedObjExtractionComboBox, "Embedded document/attachment and embedded office media extraction setting.");
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Embedded Objects:";
            // 
            // _extractionTypeComboBox
            // 
            this._extractionTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._extractionTypeComboBox.Items.AddRange(new object[] {
            "TextAndMetadata",
            "MetadataOnly"});
            this._extractionTypeComboBox.Location = new System.Drawing.Point(113, 8);
            this._extractionTypeComboBox.Name = "_extractionTypeComboBox";
            this._extractionTypeComboBox.Size = new System.Drawing.Size(205, 21);
            this._extractionTypeComboBox.TabIndex = 21;
            this.toolTip1.SetToolTip(this._extractionTypeComboBox, "Text and metadata extraction setting.");
            this._extractionTypeComboBox.SelectedIndexChanged += new System.EventHandler(this._extractionTypeComboBox_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "ExtractionType:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(3, 485);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Log:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _tabControl
            // 
            this._tabControl.Controls.Add(this._contentTabPage);
            this._tabControl.Controls.Add(this._logTabPage);
            this._tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tabControl.Location = new System.Drawing.Point(0, 0);
            this._tabControl.Name = "_tabControl";
            this._tabControl.SelectedIndex = 0;
            this._tabControl.Size = new System.Drawing.Size(972, 641);
            this._tabControl.TabIndex = 0;
            // 
            // _contentTabPage
            // 
            this._contentTabPage.Location = new System.Drawing.Point(4, 22);
            this._contentTabPage.Name = "_contentTabPage";
            this._contentTabPage.Size = new System.Drawing.Size(964, 615);
            this._contentTabPage.TabIndex = 2;
            this._contentTabPage.Text = "Content";
            this._contentTabPage.UseVisualStyleBackColor = true;
            // 
            // _logTabPage
            // 
            this._logTabPage.Controls.Add(this._logTextBox);
            this._logTabPage.Location = new System.Drawing.Point(4, 22);
            this._logTabPage.Name = "_logTabPage";
            this._logTabPage.Size = new System.Drawing.Size(1000, 615);
            this._logTabPage.TabIndex = 3;
            this._logTabPage.Text = "Log";
            this._logTabPage.UseVisualStyleBackColor = true;
            // 
            // _logTextBox
            // 
            this._logTextBox.AcceptsReturn = true;
            this._logTextBox.BackColor = System.Drawing.Color.White;
            this._logTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._logTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._logTextBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._logTextBox.Location = new System.Drawing.Point(0, 0);
            this._logTextBox.Multiline = true;
            this._logTextBox.Name = "_logTextBox";
            this._logTextBox.ReadOnly = true;
            this._logTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this._logTextBox.Size = new System.Drawing.Size(1000, 615);
            this._logTextBox.TabIndex = 15;
            this._logTextBox.WordWrap = false;
            // 
            // _piiTabPage
            // 
            this._piiTabPage.Controls.Add(this._enablePiiItemsCheckCheckBox);
            this._piiTabPage.Location = new System.Drawing.Point(4, 22);
            this._piiTabPage.Name = "_piiTabPage";
            this._piiTabPage.Size = new System.Drawing.Size(355, 200);
            this._piiTabPage.TabIndex = 6;
            this._piiTabPage.Text = "PII";
            this._piiTabPage.UseVisualStyleBackColor = true;
            // 
            // _enablePiiItemsCheckCheckBox
            // 
            this._enablePiiItemsCheckCheckBox.AutoSize = true;
            this._enablePiiItemsCheckCheckBox.Location = new System.Drawing.Point(16, 12);
            this._enablePiiItemsCheckCheckBox.Name = "_enablePiiItemsCheckCheckBox";
            this._enablePiiItemsCheckCheckBox.Size = new System.Drawing.Size(137, 17);
            this._enablePiiItemsCheckCheckBox.TabIndex = 32;
            this._enablePiiItemsCheckCheckBox.Text = "Enable PII Item Checks";
            this.toolTip1.SetToolTip(this._enablePiiItemsCheckCheckBox, "If true, includes email \'Bcc\' recipients in the email overall recipient hash (see" +
        " properties EmailDocumentContent.Sha1RecipientsHash ");
            this._enablePiiItemsCheckCheckBox.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1372, 690);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "MainForm";
            this.Text = "Open Discover® SDK for .NET  -   Content Extraction Sample";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this._subSettingsTabControl.ResumeLayout(false);
            this._hashingTabPage.ResumeLayout(false);
            this._hashingTabPage.PerformLayout();
            this._pdfTabPage.ResumeLayout(false);
            this._pdfTabPage.PerformLayout();
            this._langIdTabPage.ResumeLayout(false);
            this._langIdTabPage.PerformLayout();
            this._unsupportedTabPage.ResumeLayout(false);
            this._unsupportedTabPage.PerformLayout();
            this._timeZoneTabPage.ResumeLayout(false);
            this._tabControl.ResumeLayout(false);
            this._logTabPage.ResumeLayout(false);
            this._logTabPage.PerformLayout();
            this._piiTabPage.ResumeLayout(false);
            this._piiTabPage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileMenuItem;
        private System.Windows.Forms.ListBox _filesListBox;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel fileNameLabel;
        private System.Windows.Forms.ToolStripStatusLabel _toolStripStatusLabel;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl _tabControl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage _contentTabPage;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
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
        private System.Windows.Forms.CheckBox _useLargeDocumentUTF16EncodingCheckBox;
        private System.Windows.Forms.ComboBox _largeDocumentCriteraComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox _largeUnsupportedMaxFilteredCharsComboBox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TabPage _piiTabPage;
        private System.Windows.Forms.CheckBox _enablePiiItemsCheckCheckBox;
    }
}

