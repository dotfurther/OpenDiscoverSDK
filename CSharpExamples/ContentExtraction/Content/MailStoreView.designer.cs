﻿namespace ContentExtractionExample.Content
{
    partial class MailStoreView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MailStoreView));
            this._selectOutputFolderButton = new System.Windows.Forms.Button();
            this._messageCountLabel = new System.Windows.Forms.Label();
            this._emailOutputFolderTextBox = new System.Windows.Forms.TextBox();
            this._fileEntropyLabel = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this._errorMessageLabel = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._isEncryptedLabel = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this._fileNameLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._fileSizeLabel = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._saveWithMailStoreFolderStructureCheckBox = new System.Windows.Forms.CheckBox();
            this._metadataListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._idMatchTypeLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this._sha1ContentHashLabel = new System.Windows.Forms.Label();
            this._sha1BinaryHashLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this._textSourceLabel = new System.Windows.Forms.Label();
            this._extractAllEmailsButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this._imageList = new System.Windows.Forms.ImageList(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this._metdataTabPage = new System.Windows.Forms.TabPage();
            this._contentResultLabel = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this._classificationLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this._fileIdLabel = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this._toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this._docBaseTabPage = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this._foldersTreeView = new System.Windows.Forms.TreeView();
            this.tabControl3.SuspendLayout();
            this._metdataTabPage.SuspendLayout();
            this._docBaseTabPage.SuspendLayout();
            this.tabControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _selectOutputFolderButton
            // 
            this._selectOutputFolderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._selectOutputFolderButton.Location = new System.Drawing.Point(616, 344);
            this._selectOutputFolderButton.Name = "_selectOutputFolderButton";
            this._selectOutputFolderButton.Size = new System.Drawing.Size(27, 24);
            this._selectOutputFolderButton.TabIndex = 28;
            this._selectOutputFolderButton.Text = "...";
            this._selectOutputFolderButton.UseVisualStyleBackColor = true;
            this._selectOutputFolderButton.Click += new System.EventHandler(this._selectOutputFolderButton_Click);
            // 
            // _messageCountLabel
            // 
            this._messageCountLabel.AutoSize = true;
            this._messageCountLabel.Location = new System.Drawing.Point(708, 24);
            this._messageCountLabel.Name = "_messageCountLabel";
            this._messageCountLabel.Size = new System.Drawing.Size(13, 13);
            this._messageCountLabel.TabIndex = 24;
            this._messageCountLabel.Text = "0";
            // 
            // _emailOutputFolderTextBox
            // 
            this._emailOutputFolderTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._emailOutputFolderTextBox.Location = new System.Drawing.Point(111, 347);
            this._emailOutputFolderTextBox.Name = "_emailOutputFolderTextBox";
            this._emailOutputFolderTextBox.Size = new System.Drawing.Size(500, 20);
            this._emailOutputFolderTextBox.TabIndex = 27;
            // 
            // _fileEntropyLabel
            // 
            this._fileEntropyLabel.BackColor = System.Drawing.SystemColors.Control;
            this._fileEntropyLabel.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._fileEntropyLabel.Location = new System.Drawing.Point(117, 230);
            this._fileEntropyLabel.Name = "_fileEntropyLabel";
            this._fileEntropyLabel.Size = new System.Drawing.Size(305, 13);
            this._fileEntropyLabel.TabIndex = 70;
            this._fileEntropyLabel.Text = " ";
            this._fileEntropyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(5, 230);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(65, 13);
            this.label27.TabIndex = 69;
            this.label27.Text = "File Entropy:";
            // 
            // _errorMessageLabel
            // 
            this._errorMessageLabel.BackColor = System.Drawing.SystemColors.Control;
            this._errorMessageLabel.ForeColor = System.Drawing.Color.DarkRed;
            this._errorMessageLabel.Location = new System.Drawing.Point(93, 100);
            this._errorMessageLabel.Name = "_errorMessageLabel";
            this._errorMessageLabel.Size = new System.Drawing.Size(388, 13);
            this._errorMessageLabel.TabIndex = 68;
            this._errorMessageLabel.Text = " ";
            this._errorMessageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(3, 100);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(75, 13);
            this.label19.TabIndex = 67;
            this.label19.Text = "ErrorMessage:";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Value";
            this.columnHeader7.Width = 152;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "IsUserDefined";
            this.columnHeader2.Width = 86;
            // 
            // _isEncryptedLabel
            // 
            this._isEncryptedLabel.BackColor = System.Drawing.SystemColors.Control;
            this._isEncryptedLabel.Location = new System.Drawing.Point(94, 166);
            this._isEncryptedLabel.Name = "_isEncryptedLabel";
            this._isEncryptedLabel.Size = new System.Drawing.Size(218, 13);
            this._isEncryptedLabel.TabIndex = 60;
            this._isEncryptedLabel.Text = " ";
            this._isEncryptedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(5, 166);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 13);
            this.label11.TabIndex = 59;
            this.label11.Text = "IsEncrypted:";
            // 
            // _fileNameLabel
            // 
            this._fileNameLabel.BackColor = System.Drawing.SystemColors.Control;
            this._fileNameLabel.Location = new System.Drawing.Point(94, 127);
            this._fileNameLabel.Name = "_fileNameLabel";
            this._fileNameLabel.Size = new System.Drawing.Size(218, 13);
            this._fileNameLabel.TabIndex = 58;
            this._fileNameLabel.Text = " ";
            this._fileNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(5, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 57;
            this.label2.Text = "Name:";
            // 
            // _fileSizeLabel
            // 
            this._fileSizeLabel.BackColor = System.Drawing.SystemColors.Control;
            this._fileSizeLabel.Location = new System.Drawing.Point(94, 145);
            this._fileSizeLabel.Name = "_fileSizeLabel";
            this._fileSizeLabel.Size = new System.Drawing.Size(218, 13);
            this._fileSizeLabel.TabIndex = 56;
            this._fileSizeLabel.Text = " ";
            this._fileSizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(5, 145);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(83, 13);
            this.label12.TabIndex = 55;
            this.label12.Text = "Size:";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Type";
            this.columnHeader6.Width = 72;
            // 
            // _saveWithMailStoreFolderStructureCheckBox
            // 
            this._saveWithMailStoreFolderStructureCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._saveWithMailStoreFolderStructureCheckBox.Location = new System.Drawing.Point(616, 227);
            this._saveWithMailStoreFolderStructureCheckBox.Name = "_saveWithMailStoreFolderStructureCheckBox";
            this._saveWithMailStoreFolderStructureCheckBox.Size = new System.Drawing.Size(401, 100);
            this._saveWithMailStoreFolderStructureCheckBox.TabIndex = 30;
            this._saveWithMailStoreFolderStructureCheckBox.Text = "Save with mail store folder structure (applies to only mail stores that have inte" +
    "rnal folders like Outlook PST/OST";
            this._toolTip2.SetToolTip(this._saveWithMailStoreFolderStructureCheckBox, "WARNING: Potential resulting long file paths are not handled - so be aware of thi" +
        "s.  In addtion there is no check for illegal path characters in mail store folde" +
        "rs.\r\n");
            this._saveWithMailStoreFolderStructureCheckBox.UseVisualStyleBackColor = true;
            // 
            // _metadataListView
            // 
            this._metadataListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._metadataListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader6,
            this.columnHeader2,
            this.columnHeader7});
            this._metadataListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._metadataListView.FullRowSelect = true;
            this._metadataListView.HideSelection = false;
            this._metadataListView.Location = new System.Drawing.Point(3, 3);
            this._metadataListView.Name = "_metadataListView";
            this._metadataListView.Size = new System.Drawing.Size(487, 257);
            this._metadataListView.TabIndex = 6;
            this._metadataListView.UseCompatibleStateImageBehavior = false;
            this._metadataListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 142;
            // 
            // _idMatchTypeLabel
            // 
            this._idMatchTypeLabel.BackColor = System.Drawing.SystemColors.Control;
            this._idMatchTypeLabel.Location = new System.Drawing.Point(94, 42);
            this._idMatchTypeLabel.Name = "_idMatchTypeLabel";
            this._idMatchTypeLabel.Size = new System.Drawing.Size(218, 13);
            this._idMatchTypeLabel.TabIndex = 54;
            this._idMatchTypeLabel.Text = " ";
            this._idMatchTypeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(4, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 13);
            this.label8.TabIndex = 53;
            this.label8.Text = "ID Match Type:";
            // 
            // _sha1ContentHashLabel
            // 
            this._sha1ContentHashLabel.BackColor = System.Drawing.SystemColors.Control;
            this._sha1ContentHashLabel.Location = new System.Drawing.Point(116, 211);
            this._sha1ContentHashLabel.Name = "_sha1ContentHashLabel";
            this._sha1ContentHashLabel.Size = new System.Drawing.Size(297, 13);
            this._sha1ContentHashLabel.TabIndex = 50;
            this._sha1ContentHashLabel.Text = " ";
            this._sha1ContentHashLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _sha1BinaryHashLabel
            // 
            this._sha1BinaryHashLabel.BackColor = System.Drawing.SystemColors.Control;
            this._sha1BinaryHashLabel.Location = new System.Drawing.Point(116, 192);
            this._sha1BinaryHashLabel.Name = "_sha1BinaryHashLabel";
            this._sha1BinaryHashLabel.Size = new System.Drawing.Size(297, 13);
            this._sha1BinaryHashLabel.TabIndex = 48;
            this._sha1BinaryHashLabel.Text = " ";
            this._sha1BinaryHashLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 192);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 13);
            this.label5.TabIndex = 47;
            this.label5.Text = "SHA-1 Binary Hash:";
            // 
            // _textSourceLabel
            // 
            this._textSourceLabel.BackColor = System.Drawing.SystemColors.Control;
            this._textSourceLabel.Location = new System.Drawing.Point(94, 62);
            this._textSourceLabel.Name = "_textSourceLabel";
            this._textSourceLabel.Size = new System.Drawing.Size(181, 13);
            this._textSourceLabel.TabIndex = 46;
            this._textSourceLabel.Text = " ";
            this._textSourceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _extractAllEmailsButton
            // 
            this._extractAllEmailsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._extractAllEmailsButton.Location = new System.Drawing.Point(649, 343);
            this._extractAllEmailsButton.Name = "_extractAllEmailsButton";
            this._extractAllEmailsButton.Size = new System.Drawing.Size(117, 26);
            this._extractAllEmailsButton.TabIndex = 25;
            this._extractAllEmailsButton.Text = "Extract All Emails";
            this._extractAllEmailsButton.UseVisualStyleBackColor = true;
            this._extractAllEmailsButton.Click += new System.EventHandler(this._selectOutputFolderButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "MailStore Folders:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(617, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Message Count:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 350);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Email Output Folder:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 211);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 13);
            this.label7.TabIndex = 49;
            this.label7.Text = "SHA-1 Content Hash:";
            // 
            // _imageList
            // 
            this._imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("_imageList.ImageStream")));
            this._imageList.TransparentColor = System.Drawing.Color.Transparent;
            this._imageList.Images.SetKeyName(0, "FolderClosed_16x.png");
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(4, 62);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 13);
            this.label10.TabIndex = 45;
            this.label10.Text = "TextSourceType:";
            // 
            // tabControl3
            // 
            this.tabControl3.Controls.Add(this._metdataTabPage);
            this.tabControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl3.Location = new System.Drawing.Point(0, 0);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(501, 289);
            this.tabControl3.TabIndex = 13;
            // 
            // _metdataTabPage
            // 
            this._metdataTabPage.Controls.Add(this._metadataListView);
            this._metdataTabPage.Location = new System.Drawing.Point(4, 22);
            this._metdataTabPage.Name = "_metdataTabPage";
            this._metdataTabPage.Padding = new System.Windows.Forms.Padding(3);
            this._metdataTabPage.Size = new System.Drawing.Size(493, 263);
            this._metdataTabPage.TabIndex = 3;
            this._metdataTabPage.Text = "Metadata (0)";
            this._metdataTabPage.UseVisualStyleBackColor = true;
            // 
            // _contentResultLabel
            // 
            this._contentResultLabel.BackColor = System.Drawing.SystemColors.Control;
            this._contentResultLabel.Location = new System.Drawing.Point(94, 81);
            this._contentResultLabel.Name = "_contentResultLabel";
            this._contentResultLabel.Size = new System.Drawing.Size(181, 13);
            this._contentResultLabel.TabIndex = 44;
            this._contentResultLabel.Text = " ";
            this._contentResultLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 81);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 13);
            this.label9.TabIndex = 43;
            this.label9.Text = "ContentResult:";
            // 
            // _classificationLabel
            // 
            this._classificationLabel.BackColor = System.Drawing.SystemColors.Control;
            this._classificationLabel.Location = new System.Drawing.Point(94, 24);
            this._classificationLabel.Name = "_classificationLabel";
            this._classificationLabel.Size = new System.Drawing.Size(181, 13);
            this._classificationLabel.TabIndex = 42;
            this._classificationLabel.Text = " ";
            this._classificationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 41;
            this.label6.Text = "Classification:";
            // 
            // _fileIdLabel
            // 
            this._fileIdLabel.BackColor = System.Drawing.SystemColors.Control;
            this._fileIdLabel.Location = new System.Drawing.Point(94, 5);
            this._fileIdLabel.Name = "_fileIdLabel";
            this._fileIdLabel.Size = new System.Drawing.Size(211, 13);
            this._fileIdLabel.TabIndex = 40;
            this._fileIdLabel.Text = " ";
            this._fileIdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(4, 5);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(21, 13);
            this.label13.TabIndex = 39;
            this.label13.Text = "ID:";
            // 
            // _docBaseTabPage
            // 
            this._docBaseTabPage.BackColor = System.Drawing.SystemColors.Control;
            this._docBaseTabPage.Controls.Add(this._fileEntropyLabel);
            this._docBaseTabPage.Controls.Add(this.label27);
            this._docBaseTabPage.Controls.Add(this._errorMessageLabel);
            this._docBaseTabPage.Controls.Add(this.label19);
            this._docBaseTabPage.Controls.Add(this._isEncryptedLabel);
            this._docBaseTabPage.Controls.Add(this.label11);
            this._docBaseTabPage.Controls.Add(this._fileNameLabel);
            this._docBaseTabPage.Controls.Add(this.label2);
            this._docBaseTabPage.Controls.Add(this._fileSizeLabel);
            this._docBaseTabPage.Controls.Add(this.label12);
            this._docBaseTabPage.Controls.Add(this._idMatchTypeLabel);
            this._docBaseTabPage.Controls.Add(this.label8);
            this._docBaseTabPage.Controls.Add(this._sha1ContentHashLabel);
            this._docBaseTabPage.Controls.Add(this.label7);
            this._docBaseTabPage.Controls.Add(this._sha1BinaryHashLabel);
            this._docBaseTabPage.Controls.Add(this.label5);
            this._docBaseTabPage.Controls.Add(this._textSourceLabel);
            this._docBaseTabPage.Controls.Add(this.label10);
            this._docBaseTabPage.Controls.Add(this._contentResultLabel);
            this._docBaseTabPage.Controls.Add(this.label9);
            this._docBaseTabPage.Controls.Add(this._classificationLabel);
            this._docBaseTabPage.Controls.Add(this.label6);
            this._docBaseTabPage.Controls.Add(this._fileIdLabel);
            this._docBaseTabPage.Controls.Add(this.label13);
            this._docBaseTabPage.Location = new System.Drawing.Point(4, 22);
            this._docBaseTabPage.Name = "_docBaseTabPage";
            this._docBaseTabPage.Padding = new System.Windows.Forms.Padding(3);
            this._docBaseTabPage.Size = new System.Drawing.Size(521, 263);
            this._docBaseTabPage.TabIndex = 0;
            this._docBaseTabPage.Text = "MailStoreContent";
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this._docBaseTabPage);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(529, 289);
            this.tabControl2.TabIndex = 0;
            // 
            // splitContainer5
            // 
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.Location = new System.Drawing.Point(0, 0);
            this.splitContainer5.Name = "splitContainer5";
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.tabControl2);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.Controls.Add(this.tabControl3);
            this.splitContainer5.Size = new System.Drawing.Size(1034, 289);
            this.splitContainer5.SplitterDistance = 529;
            this.splitContainer5.TabIndex = 2;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer5);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this._saveWithMailStoreFolderStructureCheckBox);
            this.splitContainer1.Panel2.Controls.Add(this._selectOutputFolderButton);
            this.splitContainer1.Panel2.Controls.Add(this._foldersTreeView);
            this.splitContainer1.Panel2.Controls.Add(this._messageCountLabel);
            this.splitContainer1.Panel2.Controls.Add(this._emailOutputFolderTextBox);
            this.splitContainer1.Panel2.Controls.Add(this._extractAllEmailsButton);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Size = new System.Drawing.Size(1034, 670);
            this.splitContainer1.SplitterDistance = 289;
            this.splitContainer1.TabIndex = 2;
            // 
            // _foldersTreeView
            // 
            this._foldersTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this._foldersTreeView.ImageIndex = 0;
            this._foldersTreeView.ImageList = this._imageList;
            this._foldersTreeView.Location = new System.Drawing.Point(11, 21);
            this._foldersTreeView.Name = "_foldersTreeView";
            this._foldersTreeView.SelectedImageIndex = 0;
            this._foldersTreeView.Size = new System.Drawing.Size(600, 320);
            this._foldersTreeView.TabIndex = 22;
            // 
            // MailStoreView2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "MailStoreView2";
            this.Size = new System.Drawing.Size(1034, 670);
            this.tabControl3.ResumeLayout(false);
            this._metdataTabPage.ResumeLayout(false);
            this._docBaseTabPage.ResumeLayout(false);
            this._docBaseTabPage.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
            this.splitContainer5.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _selectOutputFolderButton;
        private System.Windows.Forms.Label _messageCountLabel;
        private System.Windows.Forms.TextBox _emailOutputFolderTextBox;
        private System.Windows.Forms.Label _fileEntropyLabel;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label _errorMessageLabel;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label _isEncryptedLabel;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label _fileNameLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label _fileSizeLabel;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.CheckBox _saveWithMailStoreFolderStructureCheckBox;
        private System.Windows.Forms.ToolTip _toolTip2;
        private System.Windows.Forms.ListView _metadataListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label _idMatchTypeLabel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label _sha1ContentHashLabel;
        private System.Windows.Forms.Label _sha1BinaryHashLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label _textSourceLabel;
        private System.Windows.Forms.Button _extractAllEmailsButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ImageList _imageList;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TabControl tabControl3;
        private System.Windows.Forms.TabPage _metdataTabPage;
        private System.Windows.Forms.Label _contentResultLabel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label _classificationLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label _fileIdLabel;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TabPage _docBaseTabPage;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView _foldersTreeView;
    }
}
