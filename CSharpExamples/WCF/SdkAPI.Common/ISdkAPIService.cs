// ***************************************************************************************
// 
//  Copyright © 2019-2020 dotFurther Inc. All rights reserved. 
//	 The software and associated documentation supplied hereunder are the proprietary 
//   information of dotFurther, inc., and are supplied subject to licence terms.
// 
// ***************************************************************************************
using System.Collections.Generic;
using System.ServiceModel;
using OpenDiscoverSDK.Interfaces;
using OpenDiscoverSDK.Interfaces.Content;
using OpenDiscoverSDK.Interfaces.Content.Sensitive;
using OpenDiscoverSDK.Interfaces.Settings;

namespace SdkAPI.Common
{
    /// <summary>
    /// SDK service interface.
    /// </summary>
    [ServiceContract(SessionMode = SessionMode.Required, CallbackContract = typeof(ISdkAPIServiceCallback), ProtectionLevel = System.Net.Security.ProtectionLevel.None)]
    public interface ISdkAPIService
    {
        /// <summary>
        /// Get all supported file formats for file format identification.
        /// </summary>
        /// <returns>List of supported file formats for format identification.</returns>
        [OperationContract(IsOneWay = false)]
        List<FileFormatDefinition> GetSupportedFileFormats();

        /// <summary>
        /// Identifies the file format of a file.
        /// </summary>
        /// <param name="filePath">Full path to file.</param>
        /// <returns>The identified file format.</returns>
        [OperationContract(IsOneWay = false)]
        IdResult Identify(string filePath);

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
        [OperationContract(IsOneWay = true)]
        void ExtractContent(string filePath, IdResult idResult, ContentExtractionSettings setting, string password);

        /// <summary>
        /// Loads CustomItemDefinitions to detect/extract from content extracted text and metadata.
        /// </summary>
        /// <param name="customItemDefinitions">List of user defined custom item definitions.</param>
        [OperationContract(IsOneWay = true)]
        void LoadCustomItemDefinitions(List<CustomItemDefinition> customItemDefinitions);
    }
}
