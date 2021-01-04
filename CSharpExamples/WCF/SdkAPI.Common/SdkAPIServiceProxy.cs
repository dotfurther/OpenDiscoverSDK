// ***************************************************************************************
// 
//  Copyright © 2019-2021 dotFurther Inc. All rights reserved. 
//	 The software and associated documentation supplied hereunder are the proprietary 
//   information of dotFurther, inc., and are supplied subject to licence terms.
// 
// ***************************************************************************************
using System.Collections.Generic;
using System.IO;
using System.ServiceModel;
using System;
using OpenDiscoverSDK.Interfaces;
using OpenDiscoverSDK.Interfaces.Content;
using System.ServiceModel.Channels;
using OpenDiscoverSDK.Interfaces.Settings;
using OpenDiscoverSDK.Interfaces.Content.Sensitive;

namespace SdkAPI.Common
{
    public delegate void SdkAPIServiceOpenedDelegate();
    public delegate void SdkAPIServiceFaultedDelegate();

    /// <summary>
    /// Lightweight SDK API Service Proxy that does not depend on "Add Service Reference" proxy generation by clients.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This proxy uses named piped binding for fast inter-process communication. 
    /// </para>
    /// <para>
    /// By not relying on WCF WSDL proxy generation, this proxy class can be referenced by and used by different projects.
    /// Just remember to update this proxy class if you update SdkAPIService.
    /// </para>
    /// </remarks>
    public class SdkAPIServiceProxy
    {
        private DuplexChannelFactory<ISdkAPIService> _sdkServiceBindingFactory;
        private ISdkAPIService      _sdkServiceProxy;
        private InstanceContext     _context;
        private Binding             _binding;
        private EndpointAddress     _endpoint;

        #region Constructors...
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="callbackInstance">Callback context that implements interface <see cref="IPlatformServiceCallback"/>.</param>
        /// <param name="binding">Channel transport binding.</param>
        /// <param name="endpoint">Service end point</param>
        public SdkAPIServiceProxy(InstanceContext callbackInstance, Binding binding, EndpointAddress endpoint)
        {
            _context  = callbackInstance;
            _binding  = binding;
            _endpoint = endpoint;
        }
        #endregion

        /// <summary>
        /// SDK API service opened event.
        /// </summary>
        public event SdkAPIServiceOpenedDelegate Opened;
        /// <summary>
        /// SDK API service faulted event.
        /// </summary>
        public event SdkAPIServiceFaultedDelegate Faulted;

        #region public void Open()
        /// <summary>
        /// Opens a connection to Platform API Service.
        /// </summary>
        public void Open()
        {
            // Create duplex channel (needed for IPlatformServiceCallback):
            _sdkServiceBindingFactory = new DuplexChannelFactory<ISdkAPIService>(_context, _binding, _endpoint);
            _sdkServiceProxy          = _sdkServiceBindingFactory.CreateChannel();
            ((IClientChannel)_sdkServiceProxy).OperationTimeout = new System.TimeSpan(2, 0, 0); // 2 hour time out for response - more than enough to process a document set
            ((IClientChannel)_sdkServiceProxy).Faulted += SdkAPIServiceProxy_Faulted;
            ((IClientChannel)_sdkServiceProxy).Opened  += SdkAPIServiceProxy_Opened;
            ((IClientChannel)_sdkServiceProxy).Open(new System.TimeSpan(0, 0, 0, 0, 500)); // 500 [ms] open timeout
        }
        #endregion

        #region public void Close()
        /// <summary>
        /// Closes the Platform API service connection.
        /// </summary>
        public void Close()
        {
            ((IClientChannel)_sdkServiceProxy).Close();
        }
        #endregion

        //
        // ISdkAPIService Contract:
        //

        /// <summary>
        /// Get all supported file formats for file format identification.
        /// </summary>
        /// <returns>List of supported file formats for format identification.</returns>
        public List<FileFormatDefinition> GetSupportedFileFormats()
        {
            return _sdkServiceProxy.GetSupportedFileFormats(); 
        }

        /// <summary>
        /// Identifies the file format of a file.
        /// </summary>
        /// <param name="filePath">Full path to file.</param>
        /// <returns>The identified file format.</returns>
        public IdResult Identify(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new ArgumentException(string.Format("File does not exist: '{0}'", filePath));
            }
            return _sdkServiceProxy.Identify(filePath);
        }

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
        public void ExtractContent(string filePath, IdResult idResult, ContentExtractionSettings setting, string password)
        {
            _sdkServiceProxy.ExtractContent(filePath, idResult, setting, password);
        }

        /// <summary>
        /// Loads CustomItemDefinitions to detect/extract from content extracted text and metadata.
        /// </summary>
        /// <param name="customItemDefinitions">List of user defined custom item definitions.</param>
        public void LoadCustomItemDefinitions(List<CustomItemDefinition> customItemDefinitions)
        {
            _sdkServiceProxy.LoadCustomItemDefinitions(customItemDefinitions);
        }

        //
        // Helper Methods:
        //
        #region private void SdkAPIServiceProxy_Opened(object sender, System.EventArgs e)
        private void SdkAPIServiceProxy_Opened(object sender, System.EventArgs e)
        {
            Opened?.Invoke();
        }
        #endregion

        #region private void SdkAPIServiceProxy_Faulted(object sender, System.EventArgs e)
        private void SdkAPIServiceProxy_Faulted(object sender, System.EventArgs e)
        {
            Faulted?.Invoke();
        }
        #endregion
    }
}
