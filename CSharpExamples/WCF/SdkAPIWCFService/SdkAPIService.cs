// ***************************************************************************************
// 
//  Copyright © 2019-2021 dotFurther Inc. All rights reserved. 
//	 The software and associated documentation supplied hereunder are the proprietary 
//   information of dotFurther, inc., and are supplied subject to licence terms.
// 
// ***************************************************************************************
// ***************************************************************************************
// 
//  Copyright © 2019-2021 dotFurther Inc. All rights reserved. 
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

                            case ContentExtractorType.Database:
                                #region Database Extraction...
                                {
                                    //
                                    // This is an incomplete database example for WCF. Just the metadata and table information will be returned
                                    // to the host. Database tables can be very large, so we won't return the table(s) text in this example
                                    //
                                    var databaseExtractor = (IDatabaseExtractor)contentExtractorResult.ContentExtractor;

                                    // The file path should always be passed as an argument for database formats, some formats can
                                    // only be opened with a file path:
                                    docContent = databaseExtractor.ExtractContent(filePath);

                                    // We have an encrypted document that is supported for decryption, keep prompting user for passwords until result is not 
                                    // ContentResult.WrongPassword or until user presses "Cancel" button:
                                    if (docContent.Result == ContentResult.WrongPassword && docContent.IsEncrypted && databaseExtractor.SupportsDecryption)
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
                                #region "Large" Unsupported/Unknown Type Extraction...
                                // We have a "large" unsupported/unknown file format. User should decide if they want to binary-to-text filter this document
                                // or not. And user should pay attention to size of the document. Do you want to hash and filter text from a unknown
                                // 100GB BLOB? Maybe you do if you are doing file forensics.
                                // This content extractor interface will do the following:
                                //   1) binary hash the file (if binary hashing is enabled). ContentExtractionSettings.Hashing.MaxBinaryHashLength property can
                                //      be set to hash just the first 'MaxBinaryHashLength' bytes of the BLOB (e.g., hash up to the 1st 4GB)
                                //   2) write the binary-to-text filtered text to either UTF16 or UTF8 to the supplied stream (the stream should be a 
                                //      FileStream (with because this document is "large"). 
                                //   3) If sensitive item detection *** is enabled, then will scan up to the first 100 million bytes for sensitive items and entities
                                //     (emoji entity detection is disabled for "large" unsupported/unknown binary blobs).
                                //
                                // ** For simplicity, this example uses a MemoryStream to simplify this example code, and because of this, we limit the maximum size
                                //    of the file we filter to < 200MB. 
                                //   
                                if (documentStream.Length < 200 * 1024 * 1024)
                                {
                                    try
                                    {
                                        settings.Hashing.MaxBinaryHashLength = 100 * 1024 * 1024; // limit hash to first 100 MB of bytes

                                        var largeUnsupporedExtractor = (ILargeUnsupportedExtractor)contentExtractorResult.ContentExtractor;

                                        using (var textMemStream = new MemoryStream())
                                        {
                                            docContent = largeUnsupporedExtractor.ExtractContent(textMemStream);
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
                                    finally
                                    {
                                        settings.Hashing.MaxBinaryHashLength = -1; // Set back to hash all file bytes
                                    }
                                }
                                else
                                {
                                    docContent = new DocumentContent();
                                    docContent.FormatId     = idResult;
                                    docContent.Result       = ContentResult.UnsupportedError; // 'Unsupported' for this test application since we are writting to MemoryStream instead of FileStream
                                    docContent.ErrorMessage = "File too large for this C# example implementation.";
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
                                    //   1) binary hash the file (if binary hashing is enabled). ContentExtractionSettings.Hashing.MaxBinaryHashLength property can
                                    //      be set to hash just the first 'MaxBinaryHashLength' bytes of the 'large' text file (e.g., hash up to the 1st 4GB)
                                    //   2) write the encoded text to either UTF16 or UTF8 to the supplied stream (the stream should be a 
                                    //      FileStream because this document is "large") 
                                    //   3) If sensitive item detection is enabled, then will scan up to the first 200 million characters for sensitive items and entities.
                                    //
                                    // ** For simplicity, this example uses a MemoryStream to simplify the example code, and because of this, we limit the maximum size of the file 
                                    //    to < 200MB. If file size is greater than 200 MB it is skipped. In a real application a FileStream should be used to save the re-encoded 
                                    //    (to UTF/UTF16) text.
                                    if (documentStream.Length < 200 * 1024 * 1024)
                                    {
                                        try
                                        {
                                            settings.Hashing.MaxBinaryHashLength = 100 * 1024 * 1024; // limit hash to first 100 MB of bytes, user needs to decide for their own purposes 
                                                                                                      // (we don't want to be hashing all bytes of a 10GB file, for example in this example code)

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
                                        finally
                                        {
                                            settings.Hashing.MaxBinaryHashLength = -1; // Set back to hash all file bytes
                                        }
                                    }
                                    else
                                    {
                                        docContent = new DocumentContent();
                                        docContent.FormatId     = idResult;
                                        docContent.Result       = ContentResult.UnsupportedError; // 'Unsupported' for this test application since we are writting to MemoryStream instead of FileStream
                                        docContent.ErrorMessage = "File too large for this C# example implementation.";
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
