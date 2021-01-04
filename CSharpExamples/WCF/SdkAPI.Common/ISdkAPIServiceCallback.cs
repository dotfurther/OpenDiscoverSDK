// ***************************************************************************************
// 
//  Copyright © 2019-2021 dotFurther Inc. All rights reserved. 
//	 The software and associated documentation supplied hereunder are the proprietary 
//   information of dotFurther, inc., and are supplied subject to licence terms.
// 
// ***************************************************************************************
using System.ServiceModel;
using OpenDiscoverSDK.Interfaces.Content;

namespace SdkAPI.Common
{
    /// <summary>
    /// Service callback interface.
    /// </summary>
    public interface ISdkAPIServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void ExtractContentCompleted(DocumentContent extractedContent);

        [OperationContract(IsOneWay = true)]
        void ServiceException(string message, string stackTrace);
    }
}