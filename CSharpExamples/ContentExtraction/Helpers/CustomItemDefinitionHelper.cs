// ***************************************************************************************
// 
//  Copyright © 2019-2023 dotFurther Inc. All rights reserved. 
//	 The software and associated documentation supplied hereunder are the proprietary 
//   information of dotFurther, inc., and are supplied subject to licence terms.
// 
// ***************************************************************************************
using System;
using System.Collections.Generic;
using System.IO;
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
        ///         Name | Classification | KeywordSequence | RequireKeywordSequenceAtStartOfLine | ExtractType
        ///         
        ///      OR if ExtractType = RegularExpressionAfter, RegularExpressionBefore, or RegularExpressionBeforeAndAfter:
        ///      
        ///         Name | Classification | KeywordSequence | RequireKeywordSequenceAtStartOfLine | ExtractType
        ///         RegularExpression
        ///         NumRegExSearchChars
        ///         
        ///   A keyword sequence is terms and symbols separated by '+' (addition sign). There can be no space between terms, '+', and symbols
        ///   and a sequence cannot start or end with a '+'. A sequence must begin with a word term.
        /// </summary>
        /// <returns></returns>
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

                using (var streamReader = File.OpenText(dlg.FileName))
                {
                    var all = streamReader.ReadToEnd();

                    if (string.IsNullOrWhiteSpace(all))
                    {
                        throw new Exception("File was empty (no CustomEntityDefinition statements).");
                    }

                    var lines = all.Trim().Split(new char[] { '\n' });

                    var isCustDefnPropertyBlock = false;
                    var lineCount = 1;

                    for (var iLine = 0; iLine < lines.Length; ++iLine)
                    {
                        var line     = lines[iLine];
                        var trimline = line.Trim();

                        if (string.IsNullOrWhiteSpace(trimline) || trimline.StartsWith("#"))
                        {
                            ++lineCount;
                            continue;
                        }

                        if (string.Compare(trimline, "[CustomEntityDefinition]", true) == 0)
                        {
                            isCustDefnPropertyBlock = true;
                            continue;
                        }
                        else if (isCustDefnPropertyBlock)
                        {
                            var parts = trimline.Split(new char[] { '|' });
                            if (parts == null || parts.Length != 5)
                            {
                                throw new Exception(string.Format("Line #{0} under [CustomEntityDefinition] section requires 5 parts separated by a '|' (Name | Classification | KeywordSequence | RequireKeywordSequenceAtStartOfLine | ExtractType).", lineCount));
                            }

                            var name           = parts[0].Trim();
                            var classification = parts[1].Trim();
                            var sequence       = parts[2].Trim();
                            var requireKeywordSequenceAtStartOfLine = bool.Parse(parts[3].Trim());
                            var extractType       = (CustomEntityExtractType)Enum.Parse(typeof(CustomEntityExtractType), parts[4].Trim());
                            var regExpression     = "";
                            var regExSearchLength = 0;

                            if (extractType == CustomEntityExtractType.RegularExpressionAfter  ||
                                extractType == CustomEntityExtractType.RegularExpressionBefore ||
                                extractType == CustomEntityExtractType.RegularExpressionBeforeAndAfter)
                            {
                                if (iLine + 2 >= lines.Length)
                                {
                                    throw new Exception(string.Format("Line #{0} under [CustomEntityDefinition] section is missing the regular expression line and/or NumRegExSearchChars.", iLine + 1));
                                }

                                regExpression      = lines[++iLine].Trim();
                                var numSearchChars = lines[++iLine].Trim();

                                if (string.IsNullOrWhiteSpace(regExpression) || regExpression.Length < 1)
                                {
                                    throw new Exception(string.Format("Line #{0} under [CustomEntityDefinition] section RegularExpression.Length < 1.", iLine+1));
                                }

                                if (!int.TryParse(numSearchChars, out regExSearchLength))
                                {
                                    throw new Exception(string.Format("Line #{0} under [CustomEntityDefinition] has invalid RegExSearchLength.", iLine + 1));
                                }

                                if (regExSearchLength < 1)
                                {
                                    throw new Exception(string.Format("Line #{0} under [CustomEntityDefinition] RegExSearchLength < 1.", iLine + 1));
                                }
                            }

                            definitionList.Add(new CustomEntityDefinition(name, classification, sequence, requireKeywordSequenceAtStartOfLine, extractType, regExpression, regExSearchLength));
                            isCustDefnPropertyBlock = false;
                        }

                        ++lineCount;
                    }
                }
            }

            return definitionList;
        }
    }
}
