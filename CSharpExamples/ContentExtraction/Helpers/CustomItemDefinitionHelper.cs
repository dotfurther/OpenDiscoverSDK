// ***************************************************************************************
// 
//  Copyright © 2019-2025 dotFurther Inc. All rights reserved. 
//	 The software and associated documentation supplied hereunder are the proprietary 
//   information of dotFurther, inc., and are supplied subject to licence terms.
// 
// ***************************************************************************************
using System;
using System.Collections.Generic;
using System.IO;
using OpenDiscoverSDK;
using OpenDiscoverSDK.Interfaces.Settings.TextAnalytics;

namespace ContentExtractionExample
{
    public class CustomItemDefinitionHelper
    {
        /// <summary>
        /// Loads text file containing text used to create a list of CustomEntityDefinition to
        /// extract during content extraction.  CustomEntityDefinitions can only be loaded once during a 
        /// process.
        ///  FORMAT of text file:
        ///   - lines starting with '#' are comments
        ///   - lines starting with '[CustomEntityDefinition]' are the start of a custom item definition
        ///   - the next non-comment line must have be of format: 
        ///   
        ///  Format of custom item definitions in this test file (a line beginning with a '#' is a comment and ignored):
        ///    [CustomEntityDefinition]
        ///    Name | Classification | RequireKeywordSequenceAtStartOfLine | ExtractType
        ///    keyword+sequence+1
        ///    keyword+sequence+2
        ///    ...
        ///    keyword+sequence+N                 
        ///    Example:
        ///        [CustomEntityDefinition]
        ///        # Test #1: searches for "invoiced company name:" AND "invoiced co. name:" (not case sensitive) and returns the remaining text on the line
        ///        InvoicedCompany | InvoiceDocument | false | RemainingLine
        ///        invoiced+company+name+:
        ///        invoiced+co+.+name+:
        ///        invoiced+co+name+:
        ///    
        ///  OR if ExtractType = RegularExpressionAfter, RegularExpressionBefore, or RegularExpressionBeforeAndAfter:
        ///         Name | Classification | KeywordSequence | RequireKeywordSequenceAtStartOfLine | ExtractType
        ///         RegularExpression
        ///         NumRegExSearchChars
        ///         
        ///   A keyword sequence is terms and symbols separated by '+' (addition sign). There can be no space between terms, '+', and symbols
        ///   and a sequence cannot start or end with a '+'. A sequence must begin with a word term.
        /// </summary>
        /// <returns>
        /// A parsed list of CustomEntityDefinition's
        /// </returns>
        public static List<CustomEntityDefinition> LoadCustomEntityDefinitions()
        {
            var dlg = new System.Windows.Forms.OpenFileDialog();
            dlg.Title       = "Load CustomEntityDefinition File...";
            dlg.Multiselect = false;
            dlg.Filter      = "*.*|*.*";
            dlg.CheckFileExists = true;

            var definitionList = new List<CustomEntityDefinition>();

            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (!File.Exists(dlg.FileName))
                {
                    throw new Exception("Selected CustomEntityDefinition Format file does not exist.");
                }

                var customentityDefText = File.ReadAllText(dlg.FileName);
                definitionList = ContentExtractorFactory.ParseCustomEntityDefinitions(customentityDefText);
            }

            return definitionList;
        }
    }
}
