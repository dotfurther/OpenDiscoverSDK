// ***************************************************************************************
// 
//  Copyright © 2019-2020 dotFurther Inc. All rights reserved. 
//	 The software and associated documentation supplied hereunder are the proprietary 
//   information of dotFurther, inc., and are supplied subject to licence terms.
// 
// ***************************************************************************************
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using OpenDiscoverSDK.Interfaces;
using OpenDiscoverSDK.Interfaces.Content;

namespace SdkAPIWinFormClient
{
    /// <summary>
    /// Extracted archive content view.
    /// </summary>
    public partial class ArchiveView : UserControl
    {
        private IHostUI         _hostUI;
        private ArchiveContent  _archiveContent;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="host">Host interface.</param>
        public ArchiveView(IHostUI host)
        {
            InitializeComponent();

            _hostUI = host;
        }

        #region public void ClearView()
        /// <summary>
        /// Clears all controls.
        /// </summary>
        public void ClearView()
        {
            _archiveContent   = null;
            _metadataListView.Items.Clear();
            _archiveItemInfoListView.Items.Clear();
            _foldersTreeView.Nodes.Clear();

            _attributesTabPage.Text = "Attributes (0)";

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
            _attributesTextBox.Text    = "";

            _totalItemCountLabel.Text = "";
        }
        #endregion

        #region public void UpdateContentView(DocumentContent archiveContent, string filename, long filelength)
        /// <summary>
        /// Displays archive content.
        /// </summary>
        /// <param name="archiveContent"></param>
        /// <param name="filename"></param>
        /// <param name="filelength"></param>
        public void UpdateContentView(ArchiveContent archiveContent, string filename, long filelength)
        {
            ClearView();
            _archiveContent   = archiveContent;

            _fileNameLabel.Text = filename;
            _fileSizeLabel.Text = string.Format("{0:###,###,###,###}", filelength);

            if (_archiveContent == null)
            {
                return;
            }

            _fileIdLabel.Text          = archiveContent.FormatId.ID.ToString();
            _classificationLabel.Text  = archiveContent.FormatId.Classification.ToString();
            _idMatchTypeLabel.Text     = archiveContent.FormatId.MatchType.ToString();
            _textSourceLabel.Text      = archiveContent.TextSourceType.ToString();
            _contentResultLabel.Text   = archiveContent.Result.ToString();
            _errorMessageLabel.Text    = archiveContent.ErrorMessage    != null ? archiveContent.ErrorMessage    : "";
            _sha1BinaryHashLabel.Text  = archiveContent.SHA1BinaryHash  != null ? archiveContent.SHA1BinaryHash  : "";
            _sha1ContentHashLabel.Text = archiveContent.SHA1ContentHash != null ? archiveContent.SHA1ContentHash : "";
            _fileEntropyLabel.Text     = archiveContent.FileEntropy     != null ? archiveContent.FileEntropy.Value.ToString("F7") : "";
            _isEncryptedLabel.Text     = archiveContent.FormatId.IsEncrypted.ToString();

            _totalItemCountLabel.Text = archiveContent.ItemCount.ToString();


            //
            // Set metadata:
            //
            if (archiveContent.Metadata.Count > 0)
            {
                MetadataHelper.PopulateListViewWithMetadata(_metadataListView, archiveContent.Metadata);
            }

            _metdataTabPage.Text = string.Format("Metadata ({0})", archiveContent.Metadata.Count);

            UpdateArchiveItemListView();

            //
            // Set Attributes:
            //
            if (archiveContent.Attributes.Count > 0)
            {
                var attributeBuilder = new StringBuilder();

                foreach (var flag in archiveContent.Attributes)
                {
                    attributeBuilder.AppendLine(flag.ToString());
                }
                _attributesTextBox.Text = attributeBuilder.ToString();
            }
            else
            {
                _attributesTextBox.Text = "";
            }

            _attributesTabPage.Text = string.Format("Attributes ({0})", archiveContent.Attributes.Count);

            //
            //
            // Set folders (note: not all archives have internally stored email folders):
            //
            if (archiveContent.Root != null)
            {
                SetFolders(archiveContent.Root, _foldersTreeView);
                if (_foldersTreeView.Nodes.Count > 0)
                {
                    _foldersTreeView.ExpandAll();
                    _foldersTreeView.SelectedNode = _foldersTreeView.Nodes[0];
                }
            }
        }
        #endregion

        #region private void UpdateArchiveItemListView()
        private void UpdateArchiveItemListView()
        {
            if (_archiveContent.ChildDocuments.Count > 0)
            {
                try
                {
                    _archiveItemInfoListView.BeginUpdate();
                    _archiveItemInfoListView.Items.Clear();

                    foreach (var child in _archiveContent.ChildDocuments)
                    {
                        var item = new ListViewItem(child.Name != null ? child.Name : "unnamed");
                        item.Tag = child;

                        item.UseItemStyleForSubItems = false;

                        item.SubItems.Add(child.EncryptedInContainer    ? "true" : "false");
                        item.SubItems.Add(child.LastModifiedTimeFileSystem.HasValue ? string.Format("{0} ({1})", child.LastModifiedTimeFileSystem.Value.ToString(), child.LastModifiedTimeFileSystem.Value.Kind) : "false");
                        item.SubItems.Add(child.PackedSize.HasValue ? string.Format("{0:###,###,###,###}", child.PackedSize.Value) : "Not set");
                        item.SubItems.Add(child.Size == 0           ? "0" : string.Format("{0:###,###,###,###}", child.Size));

                        var testedSizeSubItem   = item.SubItems.Add(child.TestedSize.HasValue   ? (child.TestedSize.Value == 0 ? "0" : string.Format("{0:###,###,###,###}", child.TestedSize.Value)) : "Not tested");
                        var testedResultSubItem = item.SubItems.Add(child.TestedResult.HasValue ? child.TestedResult.Value.ToString() : "Not tested");

                        item.SubItems.Add(child.Index.ToString());
                        item.SubItems.Add(child.ArchiveBlock.ToString());
                        item.SubItems.Add(child.ContainerRelativePath != null ? child.ContainerRelativePath : "");

                        if (child.TestedResult.HasValue)
                        {
                            if (child.TestedResult.Value == ContentResult.Ok)
                            {
                                testedResultSubItem.BackColor = System.Drawing.Color.DarkGreen;
                                testedResultSubItem.ForeColor = System.Drawing.Color.White;
                            }
                            if (child.TestedResult.Value != ContentResult.Ok)
                            {
                                testedResultSubItem.BackColor = System.Drawing.Color.DarkRed;
                                testedResultSubItem.ForeColor = System.Drawing.Color.White;
                            }
                        }

                        if (child.TestedSize.HasValue)
                        {
                            if (child.TestedSize.Value == child.Size)
                            {
                                testedSizeSubItem.BackColor = System.Drawing.Color.DarkGreen;
                                testedSizeSubItem.ForeColor = System.Drawing.Color.White;
                            }
                            if (child.TestedSize.Value != child.Size)
                            {
                                testedSizeSubItem.BackColor = System.Drawing.Color.DarkRed;
                                testedSizeSubItem.ForeColor = System.Drawing.Color.White;
                            }
                        }

                        _archiveItemInfoListView.Items.Add(item);
                    }
                }
                catch
                {
                }
                finally
                {
                    _archiveItemInfoListView.EndUpdate();
                }
            }
        }
        #endregion

        //
        // Sets archive folder hierarchy:
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
