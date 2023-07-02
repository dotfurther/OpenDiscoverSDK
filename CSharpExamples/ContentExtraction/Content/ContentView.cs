// ***************************************************************************************
// 
//  Copyright © 2019-2023 dotFurther Inc. All rights reserved. 
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
using OpenDiscoverSDK.Interfaces.Content.TextAnalytics;
using OpenDiscoverSDK.Interfaces.Extractors;

namespace ContentExtractionExample.Content
{
    public partial class ContentView : UserControl
    {
        private IHostUI           _iHostUI;
        private DocumentContent   _docContent;
        private IContentExtractor _contentExtractorBase;
        private ToolStripMenuItem _saveAsMenuItem;
        private TabPage           _lastActivePage;

        #region Constructors...
        /// <summary>
        /// Constructor.
        /// </summary>
        public ContentView(IHostUI host)
        {
            InitializeComponent();

            _iHostUI = host;

            var contextMenu = new ContextMenuStrip();
            _saveAsMenuItem = new ToolStripMenuItem("Save As...");
            _saveAsMenuItem.Click += _saveAsMenuItem_Click;
            contextMenu.Items.Add(_saveAsMenuItem);
            _childDocsListView.ContextMenuStrip = contextMenu;

            _langIdListView.HideSelection = false;
            _langIdRegionsListView.HideSelection = false;
            _extractedTextBox.HideSelection = false;

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
            _hyperLinksListView.Items.Clear();
            _childDocsListView.Items.Clear();
            _langIdListView.Items.Clear();
            _langIdRegionsListView.Items.Clear();
            _piiListView.Items.Clear();
            _tableColListView.Items.Clear();
            _dbTableListView.Items.Clear();

            _extractedTextBox.Text    = "";
            _totalTextCharsLabel.Text = "";

            _emailHeaderTraceTreeView.Nodes.Clear();
            if (_selectedChildInfoTabControl.TabPages.Contains(_emailTransportHeaderTraceTabPage))
            {
                _selectedChildInfoTabControl.TabPages.Remove(_emailTransportHeaderTraceTabPage);
            }

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
            if (_docTypeTabControl.TabPages.Contains(_tabDatabasePage))
            {
                _docTypeTabControl.TabPages.Remove(_tabDatabasePage);
            }


            _metdataTabPage.Text    = "Metadata";
            _attributesTabPage.Text = "Attributes";
            _hyperLinksTabPage.Text = "Hyperlinks";
            _languagesTabPage.Text  = "Languages";
            _childrenTabPage.Text   = "Children";
            _attributesTextBox.Text = "";
            _piiTabPage.Text        = "Entity Items";

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

            _fromNameLabel.Text      = "";
            _fromSmtpLabel.Text      = "";
            _fromX500DNLabel.Text    = "";
            _senderNameLabel.Text    = "";
            _senderSmtpLabel.Text    = "";
            _senderX500DNLabel.Text  = "";
            _emailSentTimeLabel.Text = "";
            _emailCreationTimeLabel.Text = "";
            _emailSubjectLabel.Text  = "";
            _emailBodyTypeLabel.Text = "";
            _emailHeaderSha1HashLabel.Text    = "";
            _mimePartialMessageInfoLabel.Text = "";
            _emailRecipientListView.Items.Clear();
            _emailTextBodyTextBox.Text = null;
            _rtfBodyTextBox.Text       = null;
            _htmlBodyTextBox.Text      = null;

            _htmlTitleLabel.Text    = "";
            _htmlBaseUrlLabel.Text  = "";
            _htmlImagesTabPage.Text = "Images";
            _htmlImagesListView.Items.Clear();

            _numFailedPdfPagesLabel.Text = "";
            _failedPdfPagesListView.Items.Clear();
        }
        #endregion

        #region public void UpdateContentView(DocumentContent docContent, string filename, long filelength, IContentExtractor contentExtractorBase)
        public void UpdateContentView(DocumentContent docContent, string filename, long filelength, IContentExtractor contentExtractorBase)
        {
            _docContent = docContent;
            _contentExtractorBase = contentExtractorBase;

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
            _fileEntropyLabel.Text     = docContent.FileEntropy     != null ? docContent.FileEntropy.Value.ToString("F7") : "";
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

                _htmlTitleLabel.Text = htmlDocContent.Title != null ? htmlDocContent.Title : "";
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
                        item.SubItems.Add(failedPage.ExceptionMessage != null       ? failedPage.ExceptionMessage : "");
                        item.SubItems.Add(failedPage.NumTextCharsExtracted.HasValue ? failedPage.NumTextCharsExtracted.Value.ToString() : "");
                        item.SubItems.Add(failedPage.ContentLength.HasValue ? failedPage.ContentLength.Value.ToString() : "");
                        item.SubItems.Add(failedPage.HasImages.HasValue     ? failedPage.HasImages.Value.ToString() : "");
                        item.SubItems.Add(failedPage.ImageCount.HasValue    ? failedPage.ImageCount.Value.ToString() : "");
                        _failedPdfPagesListView.Items.Add(item);
                    }
                }
                finally
                {
                    _failedPdfPagesListView.EndUpdate();
                }
                #endregion
            }
            else if (docContent is DatabaseContent)
            {
                #region Database Format Extra Content...
                //
                // Database specific extra content:
                //
                if (!_docTypeTabControl.TabPages.Contains(_tabDatabasePage))
                {
                    _docTypeTabControl.TabPages.Add(_tabDatabasePage);
                }

                if (_lastActivePage == _tabDatabasePage)
                {
                    _docTypeTabControl.SelectedTab = _tabDatabasePage;
                }

                var databaseContent = (DatabaseContent)docContent;

                try
                {
                    _dbTableListView.BeginUpdate();
                    _tableColListView.BeginUpdate();

                    foreach (var table in databaseContent.Tables)
                    {
                        var item = new ListViewItem(table.Name);
                        item.SubItems.Add(table.RowCount.ToString());
                        item.SubItems.Add(table.IsUserTable.ToString());
                        item.SubItems.Add(table.IsSystemTable.ToString());
                        item.SubItems.Add(table.IsHiddenTable.ToString());
                        item.Tag = table;
                        _dbTableListView.Items.Add(item);

                        foreach (var col in table.Columns)
                        {
                            var colItem = new ListViewItem(col.Name);
                            colItem.SubItems.Add(col.DataType.ToString());
                            colItem.SubItems.Add(col.Index.ToString());
                            colItem.SubItems.Add(col.ID.HasValue ? col.ID.ToString() : "");
                            colItem.SubItems.Add(col.CodePage.HasValue ? col.CodePage.ToString() : "");
                            _tableColListView.Items.Add(colItem);
                        }
                    }
                }
                finally
                {
                    _tableColListView.EndUpdate();
                    _dbTableListView.EndUpdate();
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

                    var extractedText = docContent.ExtractedText;

                    // Limit displayed extracted text to 10M characters
                    if (docContent.ExtractedText.Length > 10 * 1024 * 1024)
                    {
                        extractedText = extractedText.Substring(0, 10 * 1024 * 1024);
                    }

                    if (_docContent.TextSourceType == TextSourceType.BinaryToText)
                    {
                        _extractedTextBox.Text = string.Format("[[Extracted using Binary-To-Text)]]:\r\n\r\n{0}", extractedText);
                    }
                    else if (_docContent.TextSourceType == TextSourceType.ExtractionFallback)
                    {
                        _extractedTextBox.Text = string.Format("[[Extracted using secondary 'Fallback' method)]]:\r\n\r\n{0}", extractedText);
                    }
                    else
                    {
                        _extractedTextBox.Text = extractedText;
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

            _metdataTabPage.Text    = string.Format("Metadata ({0})",   _docContent.Metadata.Count + _docContent.CustomMetadata.Count);
            _attributesTabPage.Text = string.Format("Attributes ({0})", _docContent.Attributes.Count);
            _hyperLinksTabPage.Text = string.Format("Hyperlinks ({0})", _docContent.HyperLinks.Count);

            _languagesTabPage.Text = string.Format("Languages ({0})", _docContent.LanguageIdResults != null ? _docContent.LanguageIdResults.Count : 0);
            _childrenTabPage.Text  = string.Format("Children ({0})",  _docContent.ChildDocuments.Count);

            _piiTabPage.Text = string.Format("Entity Items ({0})",    _docContent.EntityExtractionResult != null ? _docContent.EntityExtractionResult.Items.Count : 0);

            //
            // Set Entity Items:
            //
            if (_docContent.EntityExtractionResult.Items.Count > 0)
            {
                try
                {
                    _piiListView.BeginUpdate();

                    foreach (var entityItem in _docContent.EntityExtractionResult.Items)
                    {
                        var item = new ListViewItem(entityItem.ItemType.ToString());
                        item.UseItemStyleForSubItems = false;

                        switch (entityItem.ItemType)
                        {
                            case EntityType.Address:
                                item.ImageIndex = 41;
                                break;
                            case EntityType.BankAccount:
                            case EntityType.InvestmentAccount:
                            case EntityType.IBANAccount:
                                item.ImageIndex = 14;
                                break;
                            case EntityType.CreditCard:
                                item.ImageIndex = 47;
                                break;
                            case EntityType.DatabaseCredential:
                                if (entityItem.Associated != null)
                                {
                                    if (entityItem.Associated.StartsWith("azure") || entityItem.Associated.StartsWith("aws") ||
                                        entityItem.Associated.StartsWith("sharepoint") || entityItem.Associated.StartsWith("onedrive"))
                                    {
                                        item.ImageIndex = 16;
                                    }
                                    else
                                    {
                                        item.ImageIndex = 17;
                                    }
                                }
                                else
                                {
                                    item.ImageIndex = 17;
                                }
                                break;
                            case EntityType.DateOfBirth:
                                item.ImageIndex = 40;
                                break;
                            case EntityType.DriversLicense:
                                item.ImageIndex = 18;
                                break;
                            case EntityType.EmailAddress:
                                item.ImageIndex = 20;
                                break;
                            case EntityType.EmailAddressAndName:
                                item.ImageIndex = 19;
                                break;
                            case EntityType.HealthCareNumberID:
                                item.ImageIndex = 48;
                                break;
                            case EntityType.IPv4Address:
                            case EntityType.IPv6Address:
                                item.ImageIndex = 22;
                                break;
                            case EntityType.LicensePlateNumber:
                                item.ImageIndex = 23;
                                break;
                            case EntityType.MaidenName:
                                item.ImageIndex = 43;
                                break;
                            case EntityType.EmailAddressAndIPAddress:
                                break;
                            case EntityType.NetworkName:
                                if (entityItem.Keywords.StartsWith("wi", StringComparison.OrdinalIgnoreCase))
                                {
                                    item.ImageIndex = 25;
                                }
                                else
                                {
                                    item.ImageIndex = 24;
                                }
                                break;
                            case EntityType.Passport:
                                item.ImageIndex = 26;
                                break;
                            case EntityType.Password:
                                item.ImageIndex = 27;
                                break;
                            case EntityType.PhoneNumber:
                                item.ImageIndex = 30;
                                break;
                            case EntityType.SocialSecurityNumber:
                                item.ImageIndex = 44;
                                break;
                            case EntityType.Username:
                                item.ImageIndex = 35;
                                break;
                            case EntityType.VehicleIdentificationNumber:
                                item.ImageIndex = 36;
                                break;
                            case EntityType.SocialMediaAccount:
                                {
                                    if (entityItem.Associated != null)
                                    {
                                        if (entityItem.Associated.StartsWith("facebook"))
                                        {
                                            item.ImageIndex = 1;
                                        }
                                        else if (entityItem.Associated.StartsWith("instagram"))
                                        {
                                            item.ImageIndex = 4;
                                        }
                                        else if (entityItem.Associated.StartsWith("pinterest"))
                                        {
                                            item.ImageIndex = 6;
                                        }
                                        else if (entityItem.Associated.StartsWith("linkedin"))
                                        {
                                            item.ImageIndex = 5;
                                        }
                                        else if (entityItem.Associated.StartsWith("skype"))
                                        {
                                            item.ImageIndex = 8;
                                        }
                                        else if (entityItem.Associated.StartsWith("reddit"))
                                        {
                                            item.ImageIndex = 7;
                                        }
                                        else if (entityItem.Associated.StartsWith("tumblr"))
                                        {
                                            item.ImageIndex = 9;
                                        }
                                        else if (entityItem.Associated.StartsWith("twitter"))
                                        {
                                            item.ImageIndex = 10;
                                        }
                                        else if (entityItem.Associated.StartsWith("vimeo"))
                                        {
                                            item.ImageIndex = 11;
                                        }
                                        else if (entityItem.Associated.StartsWith("youtube"))
                                        {
                                            item.ImageIndex = 12;
                                        }
                                        else if (entityItem.Associated.StartsWith("snapchat"))
                                        {
                                            item.ImageIndex = 13;
                                        }
                                    }
                                }
                                break;
                        }

                        item.SubItems.Add(entityItem.MatchType.ToString());
                        item.SubItems.Add(entityItem.Keywords != null ? entityItem.Keywords : "");
                        item.SubItems.Add(entityItem.Text != null ? entityItem.Text : "");
                        item.SubItems.Add(entityItem.Context != null ? entityItem.Context : "");
                        item.SubItems.Add(entityItem.Associated != null ? entityItem.Associated : "");

                        var subItem = item.SubItems.Add(entityItem.LocationType.ToString());
                        if (entityItem.LocationType == EntityLocationType.Metadata)
                        {
                            subItem.ForeColor = Color.Blue;
                        }
                        else if (entityItem.LocationType == EntityLocationType.Hyperlink)
                        {
                            subItem.ForeColor = Color.DarkMagenta;
                        }
                        else if (entityItem.LocationType == EntityLocationType.Content)
                        {
                            subItem.ForeColor = Color.DarkOrange;
                        }

                        subItem = item.SubItems.Add(entityItem.MetadataName != null ? entityItem.MetadataName : "");
                        if (entityItem.MetadataName != null)
                        {
                            subItem.ForeColor = Color.DarkRed;
                        }

                        item.SubItems.Add(entityItem.Start.ToString());
                        item.SubItems.Add(entityItem.End.ToString());
                        item.SubItems.Add(entityItem.Line.ToString());

                        item.Tag = entityItem;

                        _piiListView.Items.Add(item);
                    }
                }
                finally
                {
                    _piiListView.EndUpdate();
                }

            }

            if (_docContent.EntityExtractionResult.EmailTransportHeadersTrace != null)
            {
                try
                {
                    _emailHeaderTraceTreeView.BeginUpdate();

                    if (_docContent.EntityExtractionResult.EmailTransportHeadersTrace != null &&
                        _docContent.EntityExtractionResult.EmailTransportHeadersTrace.Count > 0)
                    {
                        if (!_selectedChildInfoTabControl.TabPages.Contains(_emailTransportHeaderTraceTabPage))
                        {
                            _selectedChildInfoTabControl.TabPages.Add(_emailTransportHeaderTraceTabPage);
                        }

                        var root = _emailHeaderTraceTreeView.Nodes.Add("Headers - Top Down");
                        root.ImageIndex = 0;
                        root.SelectedImageIndex = 0;

                        foreach (var header in _docContent.EntityExtractionResult.EmailTransportHeadersTrace)
                        {
                            var item = new TreeNode();
                            item.Text = header.Name;
                            item.Tag = header.Text;

                            if (header.Name.StartsWith("Received"))
                            {
                                item.ImageIndex = 4;
                                item.SelectedImageIndex = 4;
                            }
                            else if (header.Name == "Date")
                            {
                                item.ImageIndex = 7;
                                item.SelectedImageIndex = 7;
                            }
                            else
                            {
                                item.ImageIndex = 1;
                                item.SelectedImageIndex = 1;
                            }

                            if (header.Items != null && header.Items.Count > 0)
                            {
                                foreach (var hItem in header.Items)
                                {
                                    var itemChildNode = new TreeNode();
                                    if (hItem.ItemType == EntityType.EmailAddress)
                                    {
                                        itemChildNode.Text = hItem.Text;
                                        itemChildNode.ImageIndex = 5;
                                        itemChildNode.SelectedImageIndex = 5;
                                        item.Nodes.Add(itemChildNode);
                                    }
                                    if (hItem.ItemType == EntityType.IPv4Address ||
                                        hItem.ItemType == EntityType.IPv6Address)
                                    {
                                        itemChildNode.Text = hItem.Text;
                                        itemChildNode.ImageIndex = 6;
                                        itemChildNode.SelectedImageIndex = 6;
                                        item.Nodes.Add(itemChildNode);
                                    }
                                }
                            }

                            root.Nodes.Add(item);
                        }
                    }
                }
                finally
                {
                    _emailHeaderTraceTreeView.EndUpdate();
                    if (_emailHeaderTraceTreeView.Nodes != null && _emailHeaderTraceTreeView.Nodes.Count > 0)
                    {
                        _emailHeaderTraceTreeView.ExpandAll();
                        _emailHeaderTraceTreeView.SelectedNode = _emailHeaderTraceTreeView.Nodes[0];
                    }
                }
            }

            //
            // Set metadata:
            //
            if (_docContent.Metadata.Count > 0 || _docContent.CustomMetadata.Count > 0)
            {
                MetadataHelper.PopulateListViewWithMetadata(_metadataListView, _docContent.Metadata);
                MetadataHelper.PopulateListViewWithMetadata(_metadataListView, _docContent.CustomMetadata, false);
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

            try
            {
                _hyperLinksListView.BeginUpdate();

                foreach (var link in _docContent.HyperLinks)
                {
                    var item = new ListViewItem(link.IsExternalLink.ToString());
                    item.SubItems.Add(link.Text     != null ? link.Text : "");
                    item.SubItems.Add(link.Url      != null ? link.Url : "");
                    item.SubItems.Add(link.Download != null ? link.Download : "");
                    item.SubItems.Add(link.Type     != null ? link.Type : "");
                    item.SubItems.Add(link.Relationship != null ? link.Relationship : "");
                    item.SubItems.Add(link.RefLang != null ? link.RefLang : "");
                    item.SubItems.Add(link.Target  != null ? link.Target : "");
                    item.SubItems.Add(link.Ping    != null ? link.Ping : "");

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
                        item.SubItems.Add(child.EncryptedInContainer.ToString());
                        item.SubItems.Add(child.IsInlineEmailImage.ToString());
                        item.SubItems.Add(child.Index.ToString());
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
            _pictureBox.Image = null;
            _selectedChildInfoTabControl.TabPages.Remove(_imageViewTabPage);

            if (_childDocsListView.SelectedItems.Count == 1)
            {
                _saveAsMenuItem.Enabled = true;
                var child = _childDocsListView.SelectedItems[0].Tag as ChildDocument;

                if (child.FormatId != null)
                {
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
                                        _pictureBox.Image  = Image.FromStream(new MemoryStream(outStream.ToArray()));
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
                        saveAsDlg.Title = "Save Child Document...";
                        saveAsDlg.AddExtension = true;
                        saveAsDlg.DefaultExt = child.Extension;
                        saveAsDlg.FileName = child.Name;

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
                        _extractedTextBox.SelectionStart = scriptRegion.StartIndex;
                        _extractedTextBox.SelectionLength = scriptRegion.EndIndex - scriptRegion.StartIndex + 1;
                        _extractedTextBox.ScrollToCaret();
                        _langIdRegionsListView.Focus();
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
                    saveDialog.FileName = _fileNameLabel.Text + ".txt";

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

        #region  private void copyToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        /// <summary>
        /// Copies metadata ListView item "Value" column to clipboard.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void copyToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (_metadataListView.SelectedItems != null && _metadataListView.SelectedItems.Count == 1)
                {
                    var item = _metadataListView.SelectedItems[0];
                    var val = (item.SubItems != null ? item.SubItems[3].Text : null) as string;

                    if (val != null)
                    {
                        Clipboard.SetText(val);
                    }
                }
            }
            catch { }
        }
        #endregion

        #region private void _emailHeaderTraceTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        private void _emailHeaderTraceTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (_emailHeaderTraceTreeView.SelectedNode != null && _emailHeaderTraceTreeView.SelectedNode.Tag != null)
                {
                    _transportHeaderValueTextBox.Text = _emailHeaderTraceTreeView.SelectedNode.Tag as string;
                }
                else
                {
                    _transportHeaderValueTextBox.Text = "";
                }
            }
            catch { }
        }
        #endregion


        #region private void _piiListView_SelectedIndexChanged(object sender, EventArgs e)
        private void _piiListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (_piiListView.SelectedItems.Count == 1)
                {
                    var piiResult = _piiListView.SelectedItems[0].Tag as Entity;
                    if (piiResult != null)
                    {
                        _selectedChildInfoTabControl.SelectedTab = _textTabPage;
                        _extractedTextBox.Focus();
                        _extractedTextBox.SelectionStart = piiResult.Start;
                        _extractedTextBox.SelectionLength = piiResult.End - piiResult.Start + 1;
                        _extractedTextBox.ScrollToCaret();
                        _piiListView.Focus();
                    }
                }
            }
            catch
            {
            }
        }
        #endregion

        #region private void _entityItemListView_SelectedIndexChanged(object sender, EventArgs e)
        private void _entityItemListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if (_entityItemListView.SelectedItems.Count == 1)
            //    {
            //        var entityResult = _entityItemListView.SelectedItems[0].Tag as EntityItem;
            //        if (entityResult != null)
            //        {
            //            _selectedChildInfoTabControl.SelectedTab = _textTabPage;
            //            _extractedTextBox.Focus();
            //            _extractedTextBox.SelectionStart  = entityResult.Start;
            //            _extractedTextBox.SelectionLength = entityResult.End - entityResult.Start + 1;
            //            _extractedTextBox.ScrollToCaret();
            //            _entityItemListView.Focus();
            //        }
            //    }
            //}
            //catch
            //{
            //}
        }
        #endregion

        #region private void _custSenItemListView_SelectedIndexChanged(object sender, EventArgs e)
        private void _custSenItemListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if (_custSenItemListView.SelectedItems.Count == 1)
            //    {
            //        var result = _custSenItemListView.SelectedItems[0].Tag as SensitiveItem;
            //        if (result != null)
            //        {
            //            _selectedChildInfoTabControl.SelectedTab = _textTabPage;
            //            _extractedTextBox.Focus();
            //            _extractedTextBox.SelectionStart  = result.Start;
            //            _extractedTextBox.SelectionLength = result.End - result.Start + 1;
            //            _extractedTextBox.ScrollToCaret();
            //            _custSenItemListView.Focus();
            //        }
            //    }
            //}
            //catch
            //{
            //}
        }
        #endregion

        #region private void _dbTableListView_SelectedIndexChanged(object sender, EventArgs e)
        private void _dbTableListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (_dbTableListView.SelectedItems.Count == 1)
                {
                    var table = _dbTableListView.SelectedItems[0].Tag as TableInfo;
                    if (table != null)
                    {
                        ExtractTableText(table);
                    }
                }
            }
            catch
            {
            }
        }
        #endregion


        #region private void ExtractTableText(TableInfo table)
        private void ExtractTableText(TableInfo table)
        {
            try
            {
                var databaseExtractor = (IDatabaseExtractor)_contentExtractorBase;

                //
                // The IDatabaseExtractor is a general database interface that will be expanded to include formats that support very large
                // maximum databases sizes. This is why method ExtractTableAsText writes text to a Stream argument, this allows the user some 
                // extracted/stored/indexed. The Stream should be a FileStream. 
                //
                var dbContent = (DatabaseContent)_docContent;

                var textBuilder = new StringBuilder();

                if (table.RowCount > 10)
                {
                    textBuilder.AppendLine("[[Limited Extracted Text Display to the first 10 rows]]");
                }

                using (var textMemStream = new MemoryStream())
                {
                    // For this example we will limit the the max number of rows to 10 because some databases can have very large text
                    // columns (user should always extract to a FileStream):
                    databaseExtractor.ExtractTableAsText(table, textMemStream, 0, 9);

                    textMemStream.Position = 0;
                    if (textMemStream.Length > 0)
                    {
                        // Limit text to 10MB
                        if (textMemStream.Length <= 10 * 1024 * 1024)
                        {
                            textBuilder.AppendLine(Encoding.Unicode.GetString(textMemStream.ToArray()));
                        }
                        else
                        {
                            textBuilder.AppendLine(Encoding.Unicode.GetString(textMemStream.ToArray(), 0, 10 * 1024 * 1024));
                        }
                    }

                    _extractedTextBox.Text = textBuilder.ToString();

                    //// Example EnumerateTableRows: Uncomment to test out
                    //// For users who want more control over binary columns, very large text columns, or text output, then use the table
                    //// row enumerator method:
                    //var rowCount = 1;
                    //foreach (var rowData in databaseExtractor.EnumerateTableRows(table))
                    //{
                    //    // For test, limit to 1st 100 rows of table:
                    //    if (rowCount > 100)
                    //    {
                    //        break;
                    //    }

                    //    //TODO
                    //    foreach (var val in rowData)
                    //    {
                    //        if (val is string)
                    //        {
                    //            var strVal = (string)val;
                    //            //TODO
                    //        }
                    //        else if (val is int)
                    //        {
                    //            var intVal = (int)val;
                    //            //TODO
                    //        }
                    //        else if (val is byte[])
                    //        {
                    //            var byteVal = (byte[])val;
                    //            //TODO
                    //        }
                    //        // TODO: Do for rest of ColumnDataType supported values 
                    //    }
                    //    ++rowCount;
                    //}

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting database table extracted text: " + ex.Message);
            }
        }
        #endregion
    }
}
