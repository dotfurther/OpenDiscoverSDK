// ***************************************************************************************
// 
//  Copyright © 2019-2020 dotFurther Inc. All rights reserved. 
//	 The software and associated documentation supplied hereunder are the proprietary 
//   information of dotFurther, inc., and are supplied subject to licence terms.
// 
// ***************************************************************************************
// ***************************************************************************************
// 
//  Copyright © 2019-2020 dotFurther Inc. All rights reserved. 
//	 The software and associated documentation supplied hereunder are the proprietary 
//   information of dotFurther, inc., and are supplied subject to licence terms.
// 
// ***************************************************************************************
using System;
using System.Collections.Generic;
using System.IO;
using System.ServiceModel;
using System.Text;
using OpenDiscoverSDK;
using OpenDiscoverSDK.Interfaces;
using OpenDiscoverSDK.Interfaces.Content;
using OpenDiscoverSDK.Interfaces.Content.Sensitive;
using OpenDiscoverSDK.Interfaces.Extractors;
using OpenDiscoverSDK.Interfaces.Settings;
using SdkAPI.Common;

namespace SdkAPIWCFService
{
    /// <summary>
    /// Simple SDK API Service implementation. Not all features of SDK content extraction are illustrated in this example like archive or 
    /// mail store item extraction or archive item expansion size tests.
    /// </summary>
    /// <remarks>
    /// <para>
    /// InstanceContextMode.PerSession: the service uses the PerSession instance mode to maintain the result for each session. 
    /// Because server also needs to send message to client without client’s request, server need to maintain the connect session
    /// </para>
    /// <para>
    /// This test application helps test and validate the OpenDiscoverSDK.Interfaces namespaces DataContracts
    /// </para>
    /// of client.
    /// </remarks>
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, ConcurrencyMode= ConcurrencyMode.Reentrant, IncludeExceptionDetailInFaults = true)]
    public class SdkAPIService : ISdkAPIService
    {
        private ISdkAPIServiceCallback _callback;

        public SdkAPIService()
        {
            _callback = OperationContext.Current.GetCallbackChannel<ISdkAPIServiceCallback>();
        }

        //
        // ISdkAPIService Implementation:
        //
        #region public List<FileFormatDefinition> GetSupportedFileFormats()
        /// <summary>
        /// Get all supported file formats for file format identification.
        /// </summary>
        /// <returns>List of supported file formats for format identification.</returns>
        public List<FileFormatDefinition> GetSupportedFileFormats()
        {
            var result = DocumentIdentifier.SupportedFormats();

#if DEBUG
            return DebugCheckDataContractSerialize(result);
#else
            return result;
#endif
        }
        #endregion

        #region public IdResult Identify(string filePath)
        /// <summary>
        /// Identifies the file format of a file.
        /// </summary>
        /// <param name="filePath">Full path to file.</param>
        /// <returns>The identified file format.</returns>
        public IdResult Identify(string filePath)
        {
            using (var documentStream = File.OpenRead(filePath))
            {
                try
                {
                    var result = DocumentIdentifier.Identify(documentStream, filePath);
#if DEBUG
                    return DebugCheckDataContractSerialize(result);
#else
                    return result;
#endif
                }
                catch (Exception ex)
                {
                    _callback.ServiceException(ex.Message, ex.StackTrace);
                    return DocumentIdentifier.UnknownResult;
                }
            }
        }
        #endregion

        #region public void ExtractContent(string filePath, IdResult idResult, ContentExtractionSettings settings, string password)
        /// <summary>
        /// Asynchronously extracts content from a document. To get extracted content user must sign up to the <see cref="ISdkAPIServiceCallback.ExtractContentCompleted(DocumentContent)"/>
        /// callback (see example test client applications).
        /// </summary>
        /// <remarks>
        /// Note: if file is an archive or mailstore format then only the metadata of this file is returned - there are memory and WCF maximum message size limitiations
        /// to consider.
        /// </remarks>
        /// <param name="filePath">Full path to file.</param>
        /// <param name="idResult">File format identification of file obtained by a previous call to <see cref="Identify(string)"/>.</param>
        /// <param name="setting">Extraction settings that determine what is extracted from the document.</param>
        /// <param name="password">
        /// If <see cref="IdResult.IsEncrypted"/> and password is known, set this parameter to the known password. Set to null otherwise.
        /// </param>
        /// <returns>The extracted document content. Note: archive or mailstore formats will only have their metadata returned.</returns>
        public void ExtractContent(string filePath, IdResult idResult, ContentExtractionSettings settings, string password)
        {
            DocumentContent docContent = null;
            try
            {
                using (var documentStream = File.OpenRead(filePath))
                {
                    //
                    // Get Content Extractor for identified file format type:
                    //
                    var contentExtractorResult = ContentExtractorFactory.GetContentExtractor(documentStream, idResult, filePath, settings);

                    if (!contentExtractorResult.HasError)
                    {
                        var extractorType = contentExtractorResult.ContentExtractor.ContentExtractorType;

                        switch (extractorType)
                        {
                            case ContentExtractorType.Archive:
                                #region Archive Extraction...
                                {
                                    var archiveExtractor = (IArchiveExtractor)contentExtractorResult.ContentExtractor;

                                    if (archiveExtractor.IsSplit)
                                    {
                                        // Detected that currently selected file is the main split segment for a split (multi-part) archive. Now we will use archive
                                        // extractor helper method 'GetSplitSegmentStreamsInOrder' to get the other split archive segments (in proper order) 
                                        // in the same directory:
                                        Stream[] splitSegmentStreamsInOrder = null;
                                        string[] splitSegmentNameInOrder = null;

                                        archiveExtractor.GetSplitSegmentStreamsInOrder(filePath, out splitSegmentStreamsInOrder, out splitSegmentNameInOrder);

                                        docContent = archiveExtractor.ExtractContent(splitSegmentStreamsInOrder, splitSegmentNameInOrder);

                                        //
                                        // We have an archive level password (versus item level passwords):
                                        //
                                        if (docContent.Result == ContentResult.WrongPassword)
                                        {
                                            if (!string.IsNullOrEmpty(password))
                                            {
                                                docContent = archiveExtractor.ExtractContent(splitSegmentStreamsInOrder, splitSegmentNameInOrder, password);

                                                if (docContent.Result != ContentResult.WrongPassword)
                                                {
                                                    docContent.Password = password; // Store the valid password
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        docContent = archiveExtractor.ExtractContent();

                                        //
                                        // We have an archive level password (versus item level passwords):
                                        //
                                        if (docContent.Result == ContentResult.WrongPassword)
                                        {
                                            if (!string.IsNullOrEmpty(password))
                                            {
                                                docContent = archiveExtractor.ExtractContent(password);

                                                if (docContent.Result != ContentResult.WrongPassword)
                                                {
                                                    docContent.Password = password; // Store the valid password
                                                }
                                            }
                                        }
                                    }
                                }
                                #endregion
                                break;
                            case ContentExtractorType.Document:
                                #region Document Extraction...
                                {
                                    var docExtractor = ((IDocumentContentExtractor)contentExtractorResult.ContentExtractor);
                                    docContent = docExtractor.ExtractContent();

                                    // We have an encrypted document that is supported for decryption, keep prompting user for passwords until result is not 
                                    // ContentResult.WrongPassword or until user presses "Cancel" button:
                                    if (docContent.Result == ContentResult.WrongPassword && docContent.IsEncrypted && docExtractor.SupportsDecryption)
                                    {
                                        if (!string.IsNullOrEmpty(password))
                                        {
                                            docContent = ((IDocumentContentExtractor)contentExtractorResult.ContentExtractor).ExtractContent(password);

                                            if (docContent.Result != ContentResult.WrongPassword)
                                            {
                                                docContent.Password = password; // Store the valid password
                                            }
                                        }
                                    }
                                }
                                #endregion
                                break;
                            case ContentExtractorType.MailStore:
                                #region MailStore Extraction...
                                {
                                    var mailStoreExtractor = ((IMailStoreExtractor)contentExtractorResult.ContentExtractor);
                                    docContent             = mailStoreExtractor.ExtractContent();
                                }
                                #endregion
                                break;
                            case ContentExtractorType.DocumentStore:
                                #region DocumentStore Extraction...
                                {
                                    var docExtractor = ((IDocumentContentExtractor)contentExtractorResult.ContentExtractor);
                                    docContent       = docExtractor.ExtractContent();
                                }
                                #endregion
                                break;
                            case ContentExtractorType.Unsupported:
                                #region Unsupported Type Extraction...
                                {
                                    //
                                    // Binary-to-text extraction: Note, if property ContentExtractionSettings.BinaryToTextOnUnsupportedTypes is false, then calling
                                    //                            IUnsupportedExtractor.ExtractContent will only calculate binary hashes without performing binary-to-text.
                                    //                            Binary-to-text is not useful for file formats that do not have any textual content (e.g., compressed archives or encrypted files) 
                                    //                            It is up to the user to filter these formats out using either file format Id or file format classification.
                                    //
                                    var docExtractor = ((IUnsupportedExtractor)contentExtractorResult.ContentExtractor);
                                    docContent       = docExtractor.ExtractContent();
                                }
                                #endregion
                                break;
                            case ContentExtractorType.LargeUnsupported:
                                #region "Large" Unsupported Type Extraction...
                                {
                                    // We have a "large" unsupported file format. User should decide if the want to binary-to-text filter this document
                                    // or not. And user should pay attention to size of the document. Do you want to hash and filter text from a unknown
                                    // 100GB BLOB? Maybe you do if you are in file forensics.
                                    // This content extractor interface will do the following:
                                    //   1) binary hash the file (if binary hashing is enabled)
                                    //   2) write the binary-to-text filtered text to either UTF16 or UTF8 to the supplied stream (the stream should be a 
                                    //      FileStream because this document is "large"). 
                                    // ** This example uses a MemoryStream to simplify the example code but also limits the amount of the file filtered 
                                    //    to the first 100MB of the file.
                                    //   
                                    var docExtractor = ((ILargeUnsupportedExtractor)contentExtractorResult.ContentExtractor);
                                    using (var textMemStream = new MemoryStream())
                                    {
                                        docContent = docExtractor.ExtractContent(textMemStream);
                                        textMemStream.Position = 0;

                                        if (settings.UseLargeDocumentUTF16Encoding)
                                        {
                                            docContent.ExtractedText = Encoding.Unicode.GetString(textMemStream.ToArray());
                                        }
                                        else
                                        {
                                            docContent.ExtractedText = Encoding.UTF8.GetString(textMemStream.ToArray());
                                        }
                                    }
                                }
                                #endregion
                                break;
                            case ContentExtractorType.LargeEncodedText:
                                #region "Large" Encoded Type Extraction...
                                {
                                    // We have a "large" encoded text file. If file is already in an easy to index encoding such as
                                    // UTF16 or UTF8 (Id.TextUTF16 or Id.TextUTF8) then user should think about skipping over this content 
                                    // extractor. 
                                    // This content extractor interface will do the following:
                                    //   1) binary hash the file (if binary hashing is enabled)
                                    //   2) write the encoded text to either UTF16 or UTF8 to the supplied stream (the stream should be a 
                                    //      FileStream because this document is "large") 
                                    // ** This example uses a MemoryStream to simplify the example code but also limits the amount of the file 
                                    //    filtered to the first 100MB of the file.
                                    var docExtractor = ((ILargeEncodedTextExtractor)contentExtractorResult.ContentExtractor);
                                    using (var textMemStream = new MemoryStream())
                                    {
                                        docContent = docExtractor.ExtractContent(textMemStream);
                                        textMemStream.Position = 0;

                                        if (settings.UseLargeDocumentUTF16Encoding)
                                        {
                                            docContent.ExtractedText = Encoding.Unicode.GetString(textMemStream.ToArray());
                                        }
                                        else
                                        {
                                            docContent.ExtractedText = Encoding.UTF8.GetString(textMemStream.ToArray());
                                        }
                                    }
                                }
                                #endregion
                                break;
                        }
                    }

#if DEBUG
                    DebugCheckDataContractSerialize(docContent);
#endif
                }
            }
            catch (Exception ex)
            {
                _callback.ServiceException(ex.Message, ex.StackTrace);
                return;
            }

            //
            // Callback the client with the DocumentContent result:
            //
            _callback.ExtractContentCompleted(docContent);
        }
        #endregion

        #region public void LoadCustomItemDefinitions(List<CustomItemDefinition> customItemDefinitions)
        /// <summary>
        /// Loads CustomItemDefinitions to detect/extract from content extracted text and metadata.
        /// </summary>
        /// <param name="customItemDefinitions">List of user defined custom item definitions.</param>
        public void LoadCustomItemDefinitions(List<CustomItemDefinition> customItemDefinitions)
        {
            try
            {
                ContentExtractorFactory.LoadCustomItemDefinitions(customItemDefinitions);
            }
            catch (Exception ex)
            {
                _callback.ServiceException(ex.Message, ex.StackTrace);
                return;
            }
        }
        #endregion

        //
        // DEBUG DataContract Serialization Test: Used to validate serialization
        //
        #region private T DebugCheckDataContractSerialize<T>(T returnValue)
        /// <summary>
        /// Used for data contract serialization trouble shooting. This method will serialize and then deserialize the input argument.
        /// WCF will often give cryptic error messages, that if serialization related, are hard to track down. If serialization is the 
        /// issue, any serialization related exceptions will happen here - and then we will know (note: you can attach the VS debugger 
        /// to a running instance of the service host app)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objToSerialize">The object to serialize.</param>
        /// <returns>The input argument serialized and then de-serialized by DataContractSerializer.</returns>
        private T DebugCheckDataContractSerialize<T>(T objToSerialize)
        {
            var serializer = new System.Runtime.Serialization.DataContractSerializer(typeof(T));

            byte[] bytes;
            using (var serializedStream = new System.IO.MemoryStream())
            {
                serializer.WriteObject(serializedStream, objToSerialize);
                bytes = serializedStream.ToArray();
            }

            T result;
            using (var deserializedStream = new System.IO.MemoryStream(bytes))
            {
                result = (T)serializer.ReadObject(deserializedStream);
            }

            return result;
        }
        #endregion
    }
}
