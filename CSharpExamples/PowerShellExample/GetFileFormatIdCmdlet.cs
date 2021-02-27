// ***************************************************************************************
// 
//  Copyright © 2019-2021 dotFurther Inc. All rights reserved. 
//	 The software and associated documentation supplied hereunder are the proprietary 
//   information of dotFurther, inc., and are supplied subject to licence terms.
// 
// ***************************************************************************************
using System.IO;
using System.Management.Automation;
using System.Text;
using OpenDiscoverSDK.Interfaces;

namespace OpenDiscoverSDK.PowerShell
{
    /// <summary>
    /// Identifies a file's format and returns the identification IdResult object.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "FileFormatId")]
    [OutputType(typeof(IdResult))]
    public class GetFileFormatIdCmdlet : Cmdlet
    {
        static GetFileFormatIdCmdlet()
        {
            Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        /// <summary>
        /// Path to file to identify.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage ="Path to file to identify")]
        public string Path { get; set; }

        /// <summary>
        /// Override
        /// </summary>
        protected override void ProcessRecord()
        {
            IdResult result = null;
            using (var stream = File.OpenRead(Path))
            {
                result = DocumentIdentifier.Identify(stream, Path);
            }

            WriteObject(result);
        }
    }
}
