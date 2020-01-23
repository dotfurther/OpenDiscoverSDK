namespace SdkAPIWinFormClient
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
            this._imageList = new System.Windows.Forms.ImageList(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this._docBaseTabPage = new System.Windows.Forms.TabPage();
            this._errorMessageLabel = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this._isEncryptedLabel = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this._fileNameLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._fileSizeLabel = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this._idMatchTypeLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this._sha1ContentHashLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this._sha1BinaryHashLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this._textSourceLabel = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this._contentResultLabel = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this._classificationLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this._fileIdLabel = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this._metdataTabPage = new System.Windows.Forms.TabPage();
            this._metadataListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._foldersTreeView = new System.Windows.Forms.TreeView();
            this._messageCountLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this._docBaseTabPage.SuspendLayout();
            this.tabControl3.SuspendLayout();
            this._metdataTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // _imageList
            // 
            this._imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("_imageList.ImageStream")));
            this._imageList.TransparentColor = System.Drawing.Color.Transparent;
            this._imageList.Images.SetKeyName(0, "FolderClosed.png");
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
            this.splitContainer1.Panel2.Controls.Add(this._foldersTreeView);
            this.splitContainer1.Panel2.Controls.Add(this._messageCountLabel);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Size = new System.Drawing.Size(911, 633);
            this.splitContainer1.SplitterDistance = 275;
            this.splitContainer1.TabIndex = 0;
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
            this.splitContainer5.Size = new System.Drawing.Size(911, 275);
            this.splitContainer5.SplitterDistance = 430;
            this.splitContainer5.TabIndex = 2;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this._docBaseTabPage);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(430, 275);
            this.tabControl2.TabIndex = 0;
            // 
            // _docBaseTabPage
            // 
            this._docBaseTabPage.BackColor = System.Drawing.SystemColors.Control;
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
            this._docBaseTabPage.Size = new System.Drawing.Size(422, 249);
            this._docBaseTabPage.TabIndex = 0;
            this._docBaseTabPage.Text = "MailStoreContent";
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 211);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 13);
            this.label7.TabIndex = 49;
            this.label7.Text = "SHA-1 Content Hash:";
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
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(4, 62);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 13);
            this.label10.TabIndex = 45;
            this.label10.Text = "TextSourceType:";
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
            // tabControl3
            // 
            this.tabControl3.Controls.Add(this._metdataTabPage);
            this.tabControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl3.Location = new System.Drawing.Point(0, 0);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(477, 275);
            this.tabControl3.TabIndex = 13;
            // 
            // _metdataTabPage
            // 
            this._metdataTabPage.Controls.Add(this._metadataListView);
            this._metdataTabPage.Location = new System.Drawing.Point(4, 22);
            this._metdataTabPage.Name = "_metdataTabPage";
            this._metdataTabPage.Padding = new System.Windows.Forms.Padding(3);
            this._metdataTabPage.Size = new System.Drawing.Size(469, 249);
            this._metdataTabPage.TabIndex = 3;
            this._metdataTabPage.Text = "Metadata (0)";
            this._metdataTabPage.UseVisualStyleBackColor = true;
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
            this._metadataListView.Size = new System.Drawing.Size(463, 243);
            this._metadataListView.TabIndex = 6;
            this._metadataListView.UseCompatibleStateImageBehavior = false;
            this._metadataListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 142;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Type";
            this.columnHeader6.Width = 72;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Value";
            this.columnHeader7.Width = 152;
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
            this._foldersTreeView.Size = new System.Drawing.Size(600, 315);
            this._foldersTreeView.TabIndex = 22;
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
            // columnHeader2
            // 
            this.columnHeader2.Text = "IsUserDefined";
            this.columnHeader2.Width = 87;
            // 
            // MailStoreView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "MailStoreView";
            this.Size = new System.Drawing.Size(911, 633);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
            this.splitContainer5.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this._docBaseTabPage.ResumeLayout(false);
            this._docBaseTabPage.PerformLayout();
            this.tabControl3.ResumeLayout(false);
            this._metdataTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList _imageList;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView _foldersTreeView;
        private System.Windows.Forms.Label _messageCountLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage _docBaseTabPage;
        private System.Windows.Forms.Label _isEncryptedLabel;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label _fileNameLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label _fileSizeLabel;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label _idMatchTypeLabel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label _sha1ContentHashLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label _sha1BinaryHashLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label _textSourceLabel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label _contentResultLabel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label _classificationLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label _fileIdLabel;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TabControl tabControl3;
        private System.Windows.Forms.TabPage _metdataTabPage;
        private System.Windows.Forms.ListView _metadataListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Label _errorMessageLabel;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}
