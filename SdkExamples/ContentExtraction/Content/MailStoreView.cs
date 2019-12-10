// ***************************************************************************************
// 
//  Copyright © 2019-2020 dotFurther Inc. All rights reserved. 
//	 The software and associated documentation supplied hereunder are the proprietary 
//   information of dotFurther, inc., and are supplied subject to licence terms.
// 
// ***************************************************************************************
using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using OpenDiscoverSDK.Interfaces;
using OpenDiscoverSDK.Interfaces.Content;

namespace ContentExtractionExample
{
    /// <summary>
    /// Extracted mail store content view.
    /// </summary>
    public partial class MailStoreView : UserControl
    {
        private IHostUI             _hostUI;
        private BackgroundWorker    _worker = new BackgroundWorker();
        private string              _outputFolder;
        private MailStoreContent    _mailStoreContent;
        private IMailStoreExtractor _mailStoreExtractor;
        private bool                _saveWithMailStoreFolderStructure;
        private int                 _totalEmailMessagesWritten;
        private double              _totalWriteTime_ms;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="host"></param>
        public MailStoreView(IHostUI host)
        {
            InitializeComponent();

            _hostUI = host;

            _worker.DoWork += _worker_DoWork;
            _worker.RunWorkerCompleted += _worker_RunWorkerCompleted;
        }

        #region public void ClearView()
        /// <summary>
        /// Clear all controls
        /// </summary>
        public void ClearView()
        {
            _mailStoreContent   = null;
            _mailStoreExtractor = null;
            _metadataListView.Items.Clear();
            _foldersTreeView.Nodes.Clear();
            _messageCountLabel.Text = "0";

            _fileIdLabel.Text          = "";
            _classificationLabel.Text  = "";
            _idMatchTypeLabel.Text     = "";
            _textSourceLabel.Text      = "";
            _contentResultLabel.Text   = "";
            _errorMessageLabel.Text    = "";
            _sha1BinaryHashLabel.Text  = "";
            _sha1ContentHashLabel.Text = "";
            _isEncryptedLabel.Text     = "";

            _metdataTabPage.Text = "Metadata";
        }
        #endregion

        #region public void UpdateContentView(MailStoreContent docContent, IMailStoreExtractor extractor, string filename, long filelength)
        /// <summary>
        /// Displays mail store content.
        /// </summary>
        /// <param name="docContent"></param>
        /// <param name="extractor"></param>
        public void UpdateContentView(MailStoreContent docContent, IMailStoreExtractor extractor, string filename, long filelength)
        {
            try
            {
                ClearView();
                _mailStoreContent = docContent;

                _extractAllEmailsButton.Enabled = true;

                if (_saveWithMailStoreFolderStructureCheckBox.Checked)
                {
                    switch (_mailStoreContent.FormatId.ID)
                    {
                        case Id.OutlookPSTAnsi:
                        case Id.OutlookPSTUnicode:
                        case Id.OutlookOST2013Unicode:
                        case Id.OutlookOSTAnsi:
                        case Id.OutlookOSTUnicode:
                            _saveWithMailStoreFolderStructureCheckBox.Enabled = true;
                            break;
                        default:
                            _saveWithMailStoreFolderStructureCheckBox.Checked = false;
                            _saveWithMailStoreFolderStructureCheckBox.Enabled = false;
                            break;
                    }
                }

                _fileNameLabel.Text = filename;
                _fileSizeLabel.Text = string.Format("{0:###,###,###,###}", filelength);

                if (_mailStoreContent == null)
                {
                    return;
                }

                _fileIdLabel.Text          = _mailStoreContent.FormatId.ID.ToString();
                _classificationLabel.Text  = _mailStoreContent.FormatId.Classification.ToString();
                _idMatchTypeLabel.Text     = _mailStoreContent.FormatId.MatchType.ToString();
                _textSourceLabel.Text      = _mailStoreContent.TextSourceType.ToString();
                _contentResultLabel.Text   = _mailStoreContent.Result.ToString();
                _errorMessageLabel.Text    = _mailStoreContent.ErrorMessage    != null ? _mailStoreContent.ErrorMessage : "";
                _sha1BinaryHashLabel.Text  = _mailStoreContent.SHA1BinaryHash  != null ? _mailStoreContent.SHA1BinaryHash : "";
                _sha1ContentHashLabel.Text = _mailStoreContent.SHA1ContentHash != null ? _mailStoreContent.SHA1ContentHash : "";
                _isEncryptedLabel.Text     = _mailStoreContent.FormatId.IsEncrypted.ToString();

                _mailStoreExtractor = extractor;

                _messageCountLabel.Text = _mailStoreContent.MessageCount.ToString();

                //
                // Set metadata:
                //
                _metdataTabPage.Text = string.Format("Metadata ({0})", _mailStoreContent.Metadata.Count + _mailStoreContent.CustomMetadata.Count);

                if (_mailStoreContent.Metadata.Count > 0 || _mailStoreContent.CustomMetadata.Count > 0)
                {
                    MetadataHelper.PopulateListViewWithMetadata(_metadataListView, _mailStoreContent.Metadata);
                    MetadataHelper.PopulateListViewWithMetadata(_metadataListView, _mailStoreContent.CustomMetadata, false);
                }

                //
                // Set folders (note: not all mail stores (e.g., MBOX) have internally stored email folders):
                //
                if (_mailStoreContent.Root != null)
                {
                    SetFolders(_mailStoreContent.Root, _foldersTreeView);
                    if (_foldersTreeView.Nodes.Count > 0)
                    {
                        _foldersTreeView.ExpandAll();
                        _foldersTreeView.SelectedNode = _foldersTreeView.Nodes[0];
                    }
                }
            }
            catch (Exception ex)
            {
                _hostUI.LogMessage("Error in MailStoreView.UpdateContentView: " + ex.Message);
            }
        }
        #endregion

        //
        // Control Event Handlers:
        //
        #region private void _extractAllEmailsButton_Click(object sender, EventArgs e)
        private void _extractAllEmailsButton_Click(object sender, EventArgs e)
        {
            try
            {
                _outputFolder = _emailOutputFolderTextBox.Text;

                _totalEmailMessagesWritten = 0;
                _totalWriteTime_ms = 0;

                _saveWithMailStoreFolderStructure = _saveWithMailStoreFolderStructureCheckBox.Checked;

                if (!Directory.Exists(_outputFolder))
                {
                    MessageBox.Show("Email Output folder does not exist: " + _outputFolder);
                    return;
                }

                this.Enabled = false;
                this.Cursor  = Cursors.WaitCursor;

                _worker.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                _hostUI.LogMessage("Error in MailStoreView._extractAllEmailsButton_Click: " + ex.Message);
                _hostUI.ShowMessageBox(ex.Message, "Error extracting emails...");
            }
        }
        #endregion

        #region private void _selectOutputFolderButton_Click(object sender, EventArgs e)
        private void _selectOutputFolderButton_Click(object sender, EventArgs e)
        {
            var folderBrowser = new FolderBrowserDialog();

            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                _emailOutputFolderTextBox.Text = folderBrowser.SelectedPath;
            }
        }
        #endregion

        //
        // Sets mail store folder hierarchy:
        //
        #region private void SetFolders(ContainerFolder rootFolder, TreeView treeView)
        private void SetFolders(ContainerFolder rootFolder, TreeView treeView)
        {
            var rootTreeNode = new TreeNode(string.Format("{0} ({1})", string.IsNullOrWhiteSpace(rootFolder.DisplayName) ? "Root" : rootFolder.DisplayName, rootFolder.ContentCount));
            treeView.Nodes.Add(rootTreeNode);

            foreach (var folder in rootFolder.SubFolders)
            {
                var subFolderTreeNode = new TreeNode(string.Format("{0} ({1})", folder.DisplayName, folder.ContentCount));
                rootTreeNode.Nodes.Add(subFolderTreeNode);

                SetSubFolders(folder, subFolderTreeNode);
            }
        }
        #endregion

        #region private void SetSubFolders(ContainerFolder folder, TreeNode parentFolderNode)
        private void SetSubFolders(ContainerFolder folder, TreeNode parentFolderNode)
        {
            foreach (var subFolder in folder.SubFolders)
            {
                var subFolderNode = new TreeNode(string.Format("{0} ({1})", subFolder.DisplayName, subFolder.ContentCount));
                parentFolderNode.Nodes.Add(subFolderNode);

                if (subFolder.SubFolders.Count > 0)
                {
                    SetSubFolders(subFolder, subFolderNode);
                }
            }
        }
        #endregion

        //
        // Extract and write emails to file system:
        //
        #region  private void _worker_DoWork(object sender, DoWorkEventArgs e)
        /// <summary>
        /// Writes out mail store emails on a background worker thread.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _worker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var mailStoreExtractor = new MailStoreExtractorHelper(_mailStoreContent, _mailStoreExtractor, _hostUI);
                mailStoreExtractor.ExtractItemsToDirectory(_outputFolder, _saveWithMailStoreFolderStructure);

                _totalWriteTime_ms         = mailStoreExtractor.TotalElapsedTimeMs;
                _totalEmailMessagesWritten = mailStoreExtractor.TotalItemsExtracted;
            }
            catch (Exception ex)
            {
                Invoke((Action)delegate
                {
                    MessageBox.Show(this, ex.Message, "Error writing out emails...");
                });
            }
            finally
            {
                Invoke((Action)delegate
                {
                    // After extracting emails once the IMailStoreExtractor method GetNextMessage will only return null. So disable "Extract All Emails" 
                    // button so user will know they can't extract again unless they create a new IMailStoreExtractor by selecting the same mail store again:
                    this.Enabled = true;
                    this.Cursor  = Cursors.Default;
                });
            }
        }
        #endregion

        #region private void _worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        private void _worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                this.Enabled = true;
                this.Cursor  = Cursors.Default;

                MessageBox.Show(this, string.Format("Extracted and wrote {0} emails in {1:F2} [secs]", _totalEmailMessagesWritten, _totalWriteTime_ms / 1000.0), "Finished");
            }
            catch { }
        }
        #endregion
    }
}
