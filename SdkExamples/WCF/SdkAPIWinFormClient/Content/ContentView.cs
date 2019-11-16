﻿// ***************************************************************************************
// 
//  Copyright © 2019-2020 dotFurther Inc. All rights reserved. 
//	 The software and associated documentation supplied hereunder are the proprietary 
//   information of dotFurther, inc., and are supplied subject to licence terms.
// 
// ***************************************************************************************
using System;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Windows.Forms;
using OpenDiscoverSDK.Interfaces;
using OpenDiscoverSDK.Interfaces.Content;

namespace SdkAPIWinFormClient
{
    public partial class ContentView : UserControl
    {
        private IHostUI          _iHostUI;
        private DocumentContent  _docContent;
        private MenuItem         _saveAsMenuItem;
        private TabPage          _lastActivePage;

        #region Constructors...
        /// <summary>
        /// Constructor.
        /// </summary>
        public ContentView(IHostUI host)
        {
            InitializeComponent();

            _iHostUI = host;

            var contextMenu = new ContextMenu();
            _saveAsMenuItem = new MenuItem("Save As...");
            _saveAsMenuItem.Click += _saveAsMenuItem_Click;
            contextMenu.MenuItems.Add(_saveAsMenuItem);
            _childDocsListView.ContextMenu = contextMenu;

            _langIdListView.HideSelection        = false;
            _langIdRegionsListView.HideSelection = false;
            _extractedTextBox.HideSelection      = false;

            if (_docTypeTabControl.TabPages.Contains(_emailDocTabPage))
            {
                _docTypeTabControl.TabPages.Remove(_emailDocTabPage);
            }
            if (_docTypeTabControl.TabPages.Contains(_htmlDocTabPage))
            {
                _docTypeTabControl.TabPages.Remove(_htmlDocTabPage);
            }
            if (_docTypeTabControl.TabPages.Contains(_pdfDocTabPage))
            {
                _docTypeTabControl.TabPages.Remove(_pdfDocTabPage);
            }
        }
        #endregion


        #region public void ClearView()
        /// <summary>
        /// Clear view of data.
        /// </summary>
        public void ClearView()
        {
            _metadataListView.Items.Clear();
            _attributesTextBox.Text = "";
            _hyperLinksListView.Items.Clear();
            _childDocsListView.Items.Clear();
            _langIdListView.Items.Clear();
            _langIdRegionsListView.Items.Clear();

            _extractedTextBox.Text       = "";
            _totalTextCharsLabel.Text    = "";

            _pictureBox.Image = null;
            if (_selectedChildInfoTabControl.TabPages.Contains(_imageViewTabPage))
            {
                _selectedChildInfoTabControl.TabPages.Remove(_imageViewTabPage);
            }

            _lastActivePage = _docTypeTabControl.SelectedTab;

            if (_docTypeTabControl.TabPages.Contains(_emailDocTabPage))
            {
                _docTypeTabControl.TabPages.Remove(_emailDocTabPage);
            }
            if (_docTypeTabControl.TabPages.Contains(_htmlDocTabPage))
            {
                _docTypeTabControl.TabPages.Remove(_htmlDocTabPage);
            }
            if (_docTypeTabControl.TabPages.Contains(_pdfDocTabPage))
            {
                _docTypeTabControl.TabPages.Remove(_pdfDocTabPage);
            }

            _metdataTabPage.Text    = "Metadata (0)";
            _attributesTabPage.Text = "Attributes (0)";
            _hyperLinksTabPage.Text = "Hyperlinks (0)";
            _languagesTabPage.Text  = "Languages (0)";
            _childrenTabPage.Text   = "Children (0)";

            _fileIdLabel.Text          = "";
            _classificationLabel.Text  = "";
            _idMatchTypeLabel.Text     = "";
            _textSourceLabel.Text      = "";
            _contentResultLabel.Text   = "";
            _errorMessageLabel.Text    = "";
            _sha1BinaryHashLabel.Text  = "";
            _sha1ContentHashLabel.Text = "";
            _isEncryptedLabel.Text     = "";

            _fromNameLabel.Text        = "";
            _fromSmtpLabel.Text        = "";
            _fromX500DNLabel.Text      = "";
            _senderNameLabel.Text      = "";
            _senderSmtpLabel.Text      = "";
            _senderX500DNLabel.Text    = "";

            _emailSentTimeLabel.Text          = "";
            _emailCreationTimeLabel.Text      = "";
            _emailSubjectLabel.Text           = "";
            _emailBodyTypeLabel.Text          = "";
            _emailHeaderSha1HashLabel.Text    = "";
            _mimePartialMessageInfoLabel.Text = "";
            _emailRecipientListView.Items.Clear();
            _emailTextBodyTextBox.Text = null;
            _rtfBodyTextBox.Text       = null;
            _htmlBodyTextBox.Text      = null;

            _htmlTitleLabel.Text   = "";
            _htmlBaseUrlLabel.Text = "";

            _htmlImagesTabPage.Text = "Images";
            _htmlImagesListView.Items.Clear();

            _numFailedPdfPagesLabel.Text = "";
            _failedPdfPagesListView.Items.Clear();
        }
        #endregion

        #region public void UpdateContentView(DocumentContent docContent, string filename, long filelength)
        public void UpdateContentView(DocumentContent docContent, string filename, long filelength)
        {
            _docContent = docContent;

            _fileNameLabel.Text = filename;
            _fileSizeLabel.Text = string.Format("{0:###,###,###,###}", filelength);

            if (_docContent == null)
            {
                return;
            }

            _fileIdLabel.Text          = docContent.FormatId.ID.ToString();
            _classificationLabel.Text  = docContent.FormatId.Classification.ToString();
            _idMatchTypeLabel.Text     = docContent.FormatId.MatchType.ToString();
            _textSourceLabel.Text      = docContent.TextSourceType.ToString();
            _contentResultLabel.Text   = docContent.Result.ToString();
            _errorMessageLabel.Text    = docContent.ErrorMessage    != null ? docContent.ErrorMessage    : "";
            _sha1BinaryHashLabel.Text  = docContent.SHA1BinaryHash  != null ? docContent.SHA1BinaryHash  : "";
            _sha1ContentHashLabel.Text = docContent.SHA1ContentHash != null ? docContent.SHA1ContentHash : "";
            _isEncryptedLabel.Text     = docContent.FormatId.IsEncrypted.ToString();

            //
            // Check for special document content classes that derive from DocumentContent class and
            // have extra content extracted:
            //
            if (docContent is EmailDocumentContent)
            {
                #region Email Extra Content...
                //
                // Email specific extra content:
                //
                if (!_docTypeTabControl.TabPages.Contains(_emailDocTabPage))
                {
                    _docTypeTabControl.TabPages.Add(_emailDocTabPage);
                }

                if (_lastActivePage == _emailDocTabPage)
                {
                    _docTypeTabControl.SelectedTab = _emailDocTabPage;
                }

                var emailDocContent = (EmailDocumentContent)docContent;

                if (emailDocContent.From.Count > 0)
                {
                    var firstFrom = emailDocContent.From[0];
                    _fromNameLabel.Text   = firstFrom.Name;
                    _fromSmtpLabel.Text   = firstFrom.SmtpAddress;
                    _fromX500DNLabel.Text = firstFrom.X500DN;
                }

                _senderNameLabel.Text          = emailDocContent.Sender.Name;
                _senderSmtpLabel.Text          = emailDocContent.Sender.SmtpAddress;
                _senderX500DNLabel.Text        = emailDocContent.Sender.X500DN;
                _emailSentTimeLabel.Text       = emailDocContent.SentDate.HasValue     ? emailDocContent.SentDate.Value.ToString() : "";
                _emailCreationTimeLabel.Text   = emailDocContent.CreationDate.HasValue ? emailDocContent.CreationDate.Value.ToString() : "";
                _emailSubjectLabel.Text        = emailDocContent.Subject != null ? emailDocContent.Subject : "";
                _emailBodyTypeLabel.Text       = emailDocContent.BodyType.ToString();
                _emailHeaderSha1HashLabel.Text = emailDocContent.SHA1HeaderHash != null ? emailDocContent.SHA1HeaderHash : "";

                if (emailDocContent.IsMimePartialMessage)
                {
                    _mimePartialMessageInfoLabel.Text = string.Format("number={0}; total={1}; id={2}",
                        emailDocContent.MimePartialMessagePartNumber.HasValue ? emailDocContent.MimePartialMessagePartNumber.Value.ToString() : "?",
                        emailDocContent.MimePartialMessageTotalParts.HasValue ? emailDocContent.MimePartialMessageTotalParts.Value.ToString() : "?",
                        emailDocContent.MimePartialMessageId != null ? emailDocContent.MimePartialMessageId : "?");
                }

                // Eamil bodies:
                try
                {
                    // Display text email body:
                    if (emailDocContent.HasTextBody)
                    {
                        if (!_emailBodyTabControl.TabPages.Contains(_textBodyPage))
                        {
                            _emailBodyTabControl.TabPages.Add(_textBodyPage);
                        }

                        _emailTextBodyTextBox.Text = emailDocContent.TextBody;
                    }
                    else
                    {
                        _emailBodyTabControl.TabPages.Remove(_textBodyPage);
                    }

                    // Display raw RTF email body:
                    if (emailDocContent.HasRtfBody)
                    {
                        if (!_emailBodyTabControl.TabPages.Contains(_rtfBodyTabPage))
                        {
                            _emailBodyTabControl.TabPages.Add(_rtfBodyTabPage);
                        }

                        _rtfBodyTextBox.Text = emailDocContent.RtfBody;
                    }
                    else
                    {
                        _emailBodyTabControl.TabPages.Remove(_rtfBodyTabPage);
                    }

                    // Display raw HTML email body:
                    if (emailDocContent.HasHtmlBody)
                    {
                        if (!_emailBodyTabControl.TabPages.Contains(_htmlBodyTabPage))
                        {
                            _emailBodyTabControl.TabPages.Add(_htmlBodyTabPage);
                        }

                        _htmlBodyTextBox.Text = emailDocContent.HtmlBody;
                    }
                    else
                    {
                        _emailBodyTabControl.TabPages.Remove(_htmlBodyTabPage);
                    }
                }
                catch { }

                try
                {
                    _emailRecipientListView.Items.Clear();

                    _emailRecipientListView.BeginUpdate();

                    foreach (var recip in emailDocContent.ToRecipients)
                    {
                        var item = new ListViewItem(recip.AddressType.ToString());
                        item.SubItems.Add(recip.Name        != null ? recip.Name : "");
                        item.SubItems.Add(recip.SmtpAddress != null ? recip.SmtpAddress : "");
                        item.SubItems.Add(recip.X500DN      != null ? recip.X500DN : "");
                        _emailRecipientListView.Items.Add(item);
                    }
                    foreach (var recip in emailDocContent.CcRecipients)
                    {
                        var item = new ListViewItem(recip.AddressType.ToString());
                        item.SubItems.Add(recip.Name        != null ? recip.Name : "");
                        item.SubItems.Add(recip.SmtpAddress != null ? recip.SmtpAddress : "");
                        item.SubItems.Add(recip.X500DN      != null ? recip.X500DN : "");
                        _emailRecipientListView.Items.Add(item);
                    }
                    foreach (var recip in emailDocContent.BccRecipients)
                    {
                        var item = new ListViewItem(recip.AddressType.ToString());
                        item.SubItems.Add(recip.Name        != null ? recip.Name : "");
                        item.SubItems.Add(recip.SmtpAddress != null ? recip.SmtpAddress : "");
                        item.SubItems.Add(recip.X500DN      != null ? recip.X500DN : "");
                        _emailRecipientListView.Items.Add(item);
                    }
                }
                finally
                {
                    _emailRecipientListView.EndUpdate();
                    _emailRecipientsTabPage.Text = string.Format("Recipients ({0})", _emailRecipientListView.Items.Count.ToString());
                }
                #endregion
            }
            else if (docContent is HtmlDocumentContent)
            {
                #region HTML Extra Content...
                //
                // HTML specific extra content:
                //
                if (!_docTypeTabControl.TabPages.Contains(_htmlDocTabPage))
                {
                    _docTypeTabControl.TabPages.Add(_htmlDocTabPage);
                }

                if (_lastActivePage == _htmlDocTabPage)
                {
                    _docTypeTabControl.SelectedTab = _htmlDocTabPage;
                }

                var htmlDocContent = (HtmlDocumentContent)docContent;

                _htmlTitleLabel.Text   = htmlDocContent.Title   != null ? htmlDocContent.Title : "";
                _htmlBaseUrlLabel.Text = htmlDocContent.BaseUrl != null ? htmlDocContent.BaseUrl : "";

                try
                {
                    _htmlImagesTabPage.Text = string.Format("Images ({0})", htmlDocContent.ImageTags.Count);
                    _htmlImagesListView.BeginUpdate();

                    foreach (var imageTag in htmlDocContent.ImageTags)
                    {
                        var item = new ListViewItem(imageTag.Source != null ? imageTag.Source : "");
                        item.SubItems.Add(imageTag.AlternateText   != null ? imageTag.AlternateText : "");
                        item.SubItems.Add(imageTag.Width           != null ? imageTag.Width : "");
                        item.SubItems.Add(imageTag.Height          != null ? imageTag.Height : "");
                        item.SubItems.Add(imageTag.SourceSet       != null ? imageTag.SourceSet : "");
                        item.SubItems.Add(imageTag.LongDescription != null ? imageTag.LongDescription : "");
                        _htmlImagesListView.Items.Add(item);
                    }
                }
                finally
                {
                    _htmlImagesListView.EndUpdate();
                }
                #endregion
            }
            else if (docContent is PdfDocumentContent)
            {
                #region PDF Extra Content...
                //
                // PDF specific extra content:
                //
                if (!_docTypeTabControl.TabPages.Contains(_pdfDocTabPage))
                {
                    _docTypeTabControl.TabPages.Add(_pdfDocTabPage);
                }

                if (_lastActivePage == _pdfDocTabPage)
                {
                    _docTypeTabControl.SelectedTab = _pdfDocTabPage;
                }

                var pdfDocContent = (PdfDocumentContent)docContent;

                try
                {
                    _numFailedPdfPagesLabel.Text = pdfDocContent.FailedPdfPages.Count.ToString();
                    _failedPdfPagesListView.BeginUpdate();

                    foreach (var failedPage in pdfDocContent.FailedPdfPages)
                    {
                        var item = new ListViewItem(failedPage.PageNumber.ToString());
                        item.SubItems.Add(failedPage.FailedDueToException.ToString());
                        item.SubItems.Add(failedPage.ExceptionMessage != null        ? failedPage.ExceptionMessage : "");
                        item.SubItems.Add(failedPage.NumTextCharsExtracted.HasValue  ? failedPage.NumTextCharsExtracted.Value.ToString() : "");
                        item.SubItems.Add(failedPage.ContentLength.HasValue          ? failedPage.ContentLength.Value.ToString() : "");
                        item.SubItems.Add(failedPage.HasImages.HasValue              ? failedPage.HasImages.Value.ToString() : "");
                        item.SubItems.Add(failedPage.ImageCount.HasValue             ? failedPage.ImageCount.Value.ToString() : "");
                        _failedPdfPagesListView.Items.Add(item);
                    }
                }
                finally
                {
                    _failedPdfPagesListView.EndUpdate();
                }
                #endregion
            }


            //
            // Set Extracted Text:
            //
            if (_docContent.ExtractedText != null && _docContent.ExtractedText.Length > 0)
            {
                try
                {
                    _totalTextCharsLabel.Text = string.Format("{0:###,###,###,###} chars of extracted text", _docContent.ExtractedText.Length);

                    if (_docContent.TextSourceType == TextSourceType.BinaryToText)
                    {
                        _extractedTextBox.Text = string.Format("[[Extracted using Binary-To-Text)]]:\r\n\r\n{0}", _docContent.ExtractedText);
                    }
                    else if (_docContent.TextSourceType == TextSourceType.ExtractionFallback)
                    {
                        _extractedTextBox.Text = string.Format("[[Extracted using secondary 'Fallback' method)]]:\r\n\r\n{0}", _docContent.ExtractedText);
                    }
                    else
                    {
                        _extractedTextBox.Text = _docContent.ExtractedText;
                    }
                }
                catch (Exception ex)
                {
                    _extractedTextBox.Text = "Encoding Error: " + ex.Message;
                }
            }
            else
            {
                _totalTextCharsLabel.Text = "0 chars of extracted text";
            }

            _metdataTabPage.Text    = string.Format("Metadata ({0})",   _docContent.Metadata.Count);
            _attributesTabPage.Text = string.Format("Attributes ({0})", _docContent.Attributes.Count); 
            _languagesTabPage.Text  = string.Format("Languages ({0})",  _docContent.LanguageIdResults != null ? _docContent.LanguageIdResults.Count : 0);
            _childrenTabPage.Text   = string.Format("Children ({0})",   _docContent.ChildDocuments.Count);

            //
            // Set metadata:
            //
            if (_docContent.Metadata.Count > 0)
            {
                MetadataHelper.PopulateListViewWithMetadata(_metadataListView, _docContent.Metadata);
            }

            if (_docContent.Attributes.Count > 0)
            {
                var attributeBuilder = new StringBuilder();

                foreach (var flag in _docContent.Attributes)
                {
                    attributeBuilder.AppendLine(flag.ToString());
                }
                _attributesTextBox.Text = attributeBuilder.ToString();
            }
            else
            {
                _attributesTextBox.Text = "";
            }

            //
            // Document Hyperlinks:
            //
            _hyperLinksTabPage.Text = string.Format("Hyperinks ({0})", _docContent.HyperLinks.Count);

            try
            {
                _hyperLinksListView.BeginUpdate();

                foreach (var link in _docContent.HyperLinks)
                {
                    var item = new ListViewItem(link.IsExternalLink.ToString());
                    item.SubItems.Add(link.Text         != null ? link.Text : "");
                    item.SubItems.Add(link.Url          != null ? link.Url  : "");
                    item.SubItems.Add(link.Download     != null ? link.Download : "");
                    item.SubItems.Add(link.Type         != null ? link.Type : "");
                    item.SubItems.Add(link.Relationship != null ? link.Relationship : "");
                    item.SubItems.Add(link.RefLang      != null ? link.RefLang : "");
                    item.SubItems.Add(link.Target       != null ? link.Target : "");
                    item.SubItems.Add(link.Ping         != null ? link.Ping : "");
                    _hyperLinksListView.Items.Add(item);
                }
            }
            finally
            {
                _hyperLinksListView.EndUpdate();
            }

            //
            // Set child documents:
            //
            if (_docContent.ChildDocuments.Count > 0)
            {
                try
                {
                    _childDocsListView.BeginUpdate();
                    foreach (var child in _docContent.ChildDocuments)
                    {
                        var item = new ListViewItem(child.Name != null ? child.Name : "");
                        item.Tag = child;

                        //item.SubItems.Add(child.Extension     != null ? child.Extension : "");
                        item.SubItems.Add(child.Size.ToString());

                        if (child.FormatId != null)
                        {
                            item.SubItems.Add(child.FormatId.ID.ToString());
                            item.SubItems.Add(child.FormatId.Classification.ToString());
                        }
                        else
                        {
                            item.SubItems.Add("?");
                            item.SubItems.Add("?");
                        }
                        item.SubItems.Add(child.HasError.ToString());
                        _childDocsListView.Items.Add(item);
                    }
                }
                catch
                {
                }
                finally
                {
                    _childDocsListView.EndUpdate();
                }
            }

            //
            // Set language identification results:
            //
            if (_docContent.LanguageIdResults != null && _docContent.LanguageIdResults.Count > 0)
            {
                foreach (var langIdResult in _docContent.LanguageIdResults)
                {
                    var item = new ListViewItem(langIdResult.LangIso639);
                    item.SubItems.Add(langIdResult.Language);
                    item.SubItems.Add(langIdResult.PercentOfFullText.ToString("F2"));
                    item.Tag = langIdResult;

                    _langIdListView.Items.Add(item);
                }
            }
        }
        #endregion


        #region private void _childDocsListView_SelectedIndexChanged(object sender, EventArgs e)
        private void _childDocsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            _pictureBox.Image            = null;
            _selectedChildInfoTabControl.TabPages.Remove(_imageViewTabPage);
            
            if (_childDocsListView.SelectedItems.Count == 1)
            {
                _saveAsMenuItem.Enabled = true;
                var child = _childDocsListView.SelectedItems[0].Tag as ChildDocument;

                if (child.FormatId != null)
                { 
                    //
                    // If child Id'ed as an image that PictureBox supports, then load the child image
                    // into the PictureBox:
                    //
                    switch (child.FormatId.ID)
                    {
                        case Id.JpegEXIF:
                        case Id.JpegJFIF:
                        case Id.JpegSPIFF:
                        case Id.JpegRaw:
                        case Id.Png:
                        case Id.Gif:
                        case Id.WindowsBitmap:
                        case Id.WindowsMetafile1:
                        case Id.WindowsMetafile3:
                        case Id.PlaceableWindowsMetafile:
                        case Id.WindowsEnhancedMetafile:
                        case Id.Tiff:
                        case Id.TiffBigEndian:
                            try
                            {
                                _pictureBox.SuspendLayout();
                                _pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                                _pictureBox.Image    = Image.FromStream(new MemoryStream(child.DocumentBytes));
                                _pictureBox.ResumeLayout();
                                _selectedChildInfoTabControl.TabPages.Add(_imageViewTabPage);
                                _selectedChildInfoTabControl.SelectedTab = _imageViewTabPage;
                                _pictureBox.Invalidate();
                            }
                            catch { }
                            break;

                        case Id.CompressedWindowsMetafile:
                        case Id.CompressedWindowsEnhancedMetafile:
                            try
                            {
                                _pictureBox.SuspendLayout();
                                _pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                                using (var deflate = new GZipStream(new MemoryStream(child.DocumentBytes), CompressionMode.Decompress))
                                {
                                    using (var outStream = new MemoryStream())
                                    {
                                        deflate.CopyTo(outStream);
                                        outStream.Position = 0;
                                        _pictureBox.Image = Image.FromStream(new MemoryStream(outStream.ToArray()));
                                    }
                                }

                                _pictureBox.ResumeLayout();
                                _selectedChildInfoTabControl.TabPages.Add(_imageViewTabPage);
                                _selectedChildInfoTabControl.SelectedTab = _imageViewTabPage;
                                _pictureBox.Invalidate();
                            }
                            catch { }
                            break;
                    }
                }
            }
            else
            {
                _saveAsMenuItem.Enabled = false;
            }

            _childDocsListView.Focus();
        }
        #endregion

        #region private void _saveAsMenuItem_Click(object sender, EventArgs e)
        private void _saveAsMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (_childDocsListView.SelectedItems.Count == 1)
                {
                    var child = _childDocsListView.SelectedItems[0].Tag as ChildDocument;
                    if (child != null && child.DocumentBytes != null)
                    {
                        var saveAsDlg = new SaveFileDialog();
                        saveAsDlg.Title        = "Save Child Document...";
                        saveAsDlg.AddExtension = true;
                        saveAsDlg.DefaultExt   = child.Extension;
                        saveAsDlg.FileName     = child.Name;

                        if (saveAsDlg.ShowDialog() == DialogResult.OK)
                        {
                            File.WriteAllBytes(saveAsDlg.FileName, child.DocumentBytes);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        #endregion

        #region private void _langIdListView_SelectedIndexChanged(object sender, EventArgs e)
        private void _langIdListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _langIdRegionsListView.Items.Clear();

                if (_langIdListView.SelectedItems.Count == 1)
                {
                    var langIdResult = _langIdListView.SelectedItems[0].Tag as LanguageIdResult;
                    if (langIdResult != null)
                    {
                        foreach (var region in langIdResult.Regions)
                        {
                            var item = new ListViewItem(region.DetectedScript);
                            item.SubItems.Add(region.StartIndex.ToString());
                            item.SubItems.Add(region.EndIndex.ToString());
                            item.Tag = region;

                            _langIdRegionsListView.Items.Add(item);
                        }

                        if (_langIdRegionsListView.Items.Count > 0)
                        {
                            _langIdRegionsListView.Items[0].Selected = true;
                        }
                    }
                }
            }
            catch
            {
            }
        }
        #endregion

        #region private void _langIdRegionsListView_SelectedIndexChanged(object sender, EventArgs e)
        private void _langIdRegionsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (_langIdRegionsListView.SelectedItems.Count == 1)
                {
                    var scriptRegion = _langIdRegionsListView.SelectedItems[0].Tag as ScriptRegion;
                    if (scriptRegion != null)
                    {
                        _selectedChildInfoTabControl.SelectedTab = _textTabPage;
                        _extractedTextBox.Focus();
                        _extractedTextBox.SelectionStart  = scriptRegion.StartIndex;
                        _extractedTextBox.SelectionLength = scriptRegion.EndIndex - scriptRegion.StartIndex + 1;
                        _extractedTextBox.ScrollToCaret();
                        //_extractedTextBox.Invalidate();
                    }
                }
            }
            catch
            {
            }
        }
        #endregion

        #region private void _saveTextButton_Click(object sender, EventArgs e)
        private void _saveTextButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (_docContent != null && _docContent.ExtractedText != null)
                {
                    var saveDialog = new SaveFileDialog();
                    saveDialog.DefaultExt = ".txt";
                    saveDialog.FileName   = _fileNameLabel.Text + ".txt";

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(saveDialog.FileName, _docContent.ExtractedText, Encoding.UTF8);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error saving text...");
            }
        }
        #endregion
    }
}