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
        ///   - the next non-comment line must have be of format: Name | Classification | KeywordSequence | ExtractType
        ///   A keyword sequence is terms and symbols separated by '+' (addition sign). There can be no space between terms, '+', and symbols
        ///   and a sequence cannot start or end with a '+'. A sequence must begin with a word term.
        /// </summary>
        /// <returns></returns>
        public static List<CustomItemDefinition> LoadCustomItemDefinitions()
        {
            var dlg = new System.Windows.Forms.OpenFileDialog();
            dlg.Title       = "Load CustomItemDefinition File...";
            dlg.Multiselect = false;
            dlg.Filter      = "*.*|*.*";
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

                    foreach (var line in lines)
                    {
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
                            if (parts == null || parts.Length != 4)
                            {
                                throw new Exception("Line #{0} under [CustomItemDefinition] section requires 4 parts separated by a '|' (Name | Classification | KeywordSequence | ExtractType).");
                            }

                            var name           = parts[0].Trim();
                            var classification = parts[1].Trim();
                            var sequence       = parts[2].Trim();
                            var extractType    = (CustomItemExtractType)Enum.Parse(typeof(CustomItemExtractType), parts[3].Trim());

                            definitionList.Add(new CustomItemDefinition(name, classification, sequence, extractType));
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
