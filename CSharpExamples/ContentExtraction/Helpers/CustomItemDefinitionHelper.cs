using System;
using System.Collections.Generic;
using System.IO;
using OpenDiscoverSDK.Interfaces.Content.Sensitive;

namespace ContentExtractionExample
{
    public class CustomItemDefinitionHelper
    {
        /// <summary>
        /// Loads text file containing text used to create a list of CustomItemDefinitions to
        /// extract during content extraction.  CustomItemDefinitions can only be loaded once during a 
        /// process.
        ///  FORMAT of text file:
        ///   - lines starting with '#' are comments
        ///   - lines starting with '[CustomItemDefinition]' are the start of a custom item definition
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
        ///   A keyword sequence is terms and symbols separated by '+' (addition sign). 
        ///   Rules:
        ///   - There can be no space between terms, '+', and symbols
        ///   - All terms must be lower case
        ///   - A sequence must begin with a word term ('wg12', 'the') and can not begin with a number or symbol.
        ///   - A sequence cannot start or end with a '+'. 
        /// </summary>
        /// <returns></returns>
        public static List<CustomItemDefinition> LoadCustomItemDefinitions()
        {
            var dlg = new System.Windows.Forms.OpenFileDialog();
            dlg.Title           = "Load CustomItemDefinition File...";
            dlg.Multiselect     = false;
            dlg.Filter          = "*.*|*.*";
            dlg.CheckFileExists = true;

            var definitionList = new List<CustomItemDefinition>();

            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (!File.Exists(dlg.FileName))
                {
                    throw new Exception("Selected CustomItemDefinition Format file does not exist.");
                }

                using (var streamReader = File.OpenText(dlg.FileName))
                {
                    var all = streamReader.ReadToEnd();

                    if (string.IsNullOrWhiteSpace(all))
                    {
                        throw new Exception("File was empty (no CustomItemDefinition statements).");
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

                        if (string.Compare(trimline, "[CustomItemDefinition]", true) == 0)
                        {
                            isCustDefnPropertyBlock = true;
                            continue;
                        }
                        else if (isCustDefnPropertyBlock)
                        {
                            var parts = trimline.Split(new char[] { '|' });
                            if (parts == null || parts.Length != 5)
                            {
                                throw new Exception(string.Format("Line #{0} under [CustomItemDefinition] section requires 5 parts separated by a '|' (Name | Classification | KeywordSequence | RequireKeywordSequenceAtStartOfLine | ExtractType).", lineCount));
                            }

                            var name           = parts[0].Trim();
                            var classification = parts[1].Trim();
                            var sequence       = parts[2].Trim();
                            var requireKeywordSequenceAtStartOfLine = bool.Parse(parts[3].Trim());
                            var extractType       = (CustomItemExtractType)Enum.Parse(typeof(CustomItemExtractType), parts[4].Trim());
                            var regExpression     = "";
                            var regExSearchLength = 0;

                            if (extractType == CustomItemExtractType.RegularExpressionAfter  ||
                                extractType == CustomItemExtractType.RegularExpressionBefore ||
                                extractType == CustomItemExtractType.RegularExpressionBeforeAndAfter)
                            {
                                if (iLine + 2 >= lines.Length)
                                {
                                    throw new Exception(string.Format("Line #{0} under [CustomItemDefinition] section is missing the regular expression line and/or NumRegExSearchChars.", iLine + 1));
                                }

                                regExpression      = lines[++iLine].Trim();
                                var numSearchChars = lines[++iLine].Trim();

                                if (string.IsNullOrWhiteSpace(regExpression) || regExpression.Length < 1)
                                {
                                    throw new Exception(string.Format("Line #{0} under [CustomItemDefinition] section RegularExpression.Length < 1.", iLine + 1));
                                }

                                if (!int.TryParse(numSearchChars, out regExSearchLength))
                                {
                                    throw new Exception(string.Format("Line #{0} under [CustomItemDefinition] has invalid RegExSearchLength.", iLine + 1));
                                }

                                if (regExSearchLength < 1)
                                {
                                    throw new Exception(string.Format("Line #{0} under [CustomItemDefinition] RegExSearchLength < 1.", iLine + 1));
                                }
                            }

                            definitionList.Add(new CustomItemDefinition(name, classification, sequence, requireKeywordSequenceAtStartOfLine, extractType, regExpression, regExSearchLength));
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
