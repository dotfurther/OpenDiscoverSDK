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

namespace SdkAPIWinFormClient
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

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="host"></param>
        public MailStoreView(IHostUI host)
        {
            InitializeComponent();

            _hostUI = host;
        }

        #region public void ClearView()
        /// <summary>
        /// Clear all controls
        /// </summary>
        public void ClearView()
        {
            _mailStoreContent   = null;
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
            _fileEntropyLabel.Text     = "";
            _isEncryptedLabel.Text     = "";
        }
        #endregion

        #region public void UpdateContentView(MailStoreContent docContent, string filename, long filelength)
        /// <summary>
        /// Displays mail store content.
        /// </summary>
        /// <param name="docContent"></param>
        /// <param name="filename"></param>
        /// <param name="filelength"></param>
        public void UpdateContentView(MailStoreContent docContent, string filename, long filelength)
        {
            try
            {
                ClearView();
                _mailStoreContent = docContent;

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
                _errorMessageLabel.Text    = _mailStoreContent.ErrorMessage    != null ? _mailStoreContent.ErrorMessage    : "";
                _sha1BinaryHashLabel.Text  = _mailStoreContent.SHA1BinaryHash  != null ? _mailStoreContent.SHA1BinaryHash  : "";
                _sha1ContentHashLabel.Text = _mailStoreContent.SHA1ContentHash != null ? _mailStoreContent.SHA1ContentHash : "";
                _fileEntropyLabel.Text     = _mailStoreContent.FileEntropy     != null ? _mailStoreContent.FileEntropy.Value.ToString("F7") : "";
                _isEncryptedLabel.Text     = _mailStoreContent.FormatId.IsEncrypted.ToString();

                _messageCountLabel.Text = _mailStoreContent.MessageCount.ToString();

                //
                // Set metadata:
                //
                if (_mailStoreContent.Metadata.Count > 0)
                {
                    MetadataHelper.PopulateListViewWithMetadata(_metadataListView, _mailStoreContent.Metadata);
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
    }
}
