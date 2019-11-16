// ***************************************************************************************
// 
//  Copyright © 2019-2020 dotFurther Inc. All rights reserved. 
//	 The software and associated documentation supplied hereunder are the proprietary 
//   information of dotFurther, inc., and are supplied subject to licence terms.
// 
// ***************************************************************************************
using System.Collections.Generic;
using System.Windows.Forms;
using OpenDiscoverSDK.Interfaces;
using OpenDiscoverSDK.Interfaces.Content;

namespace ContentExtractionExample
{
    internal class MetadataHelper
    {
        /// <summary>
        /// Populates a ListView control with metadata.
        /// </summary>
        /// <param name="listView"></param>
        /// <param name="metadata"></param>
        internal static void PopulateListViewWithMetadata(ListView listView, Dictionary<string, IDocumentProperty> metadata)
        {
            try
            {
                listView.BeginUpdate();
                listView.Items.Clear();

                foreach (var meta in metadata)
                {
                    var item = new ListViewItem(meta.Key);
                    item.SubItems.Add(meta.Value.PropertyType.ToString());

                    switch (meta.Value.PropertyType)
                    {
                        case PropertyType.String:
                            item.SubItems.Add(((StringProperty)meta.Value).Value);
                            break;
                        case PropertyType.DateTime:
                            item.SubItems.Add(string.Format("{0} ({1})", ((DateTimeProperty)meta.Value).Value.ToString(), ((DateTimeProperty)meta.Value).Value.Kind.ToString()));
                            break;
                        case PropertyType.Boolean:
                            item.SubItems.Add(((BooleanProperty)meta.Value).Value.ToString());
                            break;
                        case PropertyType.Double:
                            item.SubItems.Add(((DoubleProperty)meta.Value).Value.ToString());
                            break;
                        case PropertyType.Int32:
                            item.SubItems.Add(((Int32Property)meta.Value).Value.ToString());
                            break;
                        case PropertyType.Int64:
                            item.SubItems.Add(((Int64Property)meta.Value).Value.ToString());
                            break;
                        default:
                            item.SubItems.Add("Unknown Property Type");
                            break;
                    }

                    listView.Items.Add(item);
                }
            }
            catch
            {
            }
            finally
            {
                listView.EndUpdate();
            }
        }
    }
}

