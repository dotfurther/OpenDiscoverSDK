// ***************************************************************************************
// 
//  Copyright © 2019-2022 dotFurther Inc. All rights reserved. 
//	 The software and associated documentation supplied hereunder are the proprietary 
//   information of dotFurther, inc., and are supplied subject to licence terms.
// 
// ***************************************************************************************
using OpenDiscoverSDK.Interfaces;

namespace DocumentIdentifierExample
{
    /// <summary>
    /// Helper class to help display a subset of file format identification result properties (i.e., IdResult)
    /// </summary>
    internal class DocumentIdResult
    {
        public DocumentIdResult()
        {
        }

        public DocumentIdResult(string file, IdResult formatResult)
        {
            File             = file;
            ID               = formatResult.ID;
            MatchType        = formatResult.MatchType;
            Extensions       = formatResult.Extensions;
            MediaType        = formatResult.MediaType;
            Description      = formatResult.Description;
            Classification   = formatResult.Classification;
            PrimaryExtension = formatResult.PrimaryExtension;
        }

        public string           File           { get; set; }
        public Id               ID             { get; set; }
        public IdMatchType      MatchType      { get; set; }
        public IdClassification Classification { get; set; }
        public string           Extensions     { get; set; }
        public string           MediaType      { get; set; }
        public string           Description      { get; set; }
        public string           PrimaryExtension { get; set; }
        
        public bool   HasError     { get; set; }
        public string ErrorMessage { get; set; }
    }
}
