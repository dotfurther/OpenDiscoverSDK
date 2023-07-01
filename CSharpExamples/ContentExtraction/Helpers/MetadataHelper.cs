// ***************************************************************************************
// 
//  Copyright © 2019-2023 dotFurther Inc. All rights reserved. 
//	 The software and associated documentation supplied hereunder are the proprietary 
//   information of dotFurther, inc., and are supplied subject to licence terms.
// 
// ***************************************************************************************
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using OpenDiscoverSDK.Interfaces.Content;

namespace ContentExtractionExample
{
    internal class MetadataHelper
    {
        /// <summary>
        /// Populates a ListView control with metadata.
        /// </summary>
        /// <param name="listView">The listView control to add metadata.</param>
        /// <param name="metadata">Metadata to add to listView control.</param>
        /// <param name="clearList">Clear existing items from listView?</param>
        internal static void PopulateListViewWithMetadata(ListView listView, Dictionary<string, IDocumentProperty> metadata, bool clearList = true)
        {
            try
            {
                listView.BeginUpdate();

                if (clearList)
                {
                    listView.Items.Clear();
                }

                foreach (var meta in metadata)
                {
                    var item = new ListViewItem(meta.Key);
                    item.UseItemStyleForSubItems = false;

                    var subItem = item.SubItems.Add(meta.Value.PropertyType.ToString());
                    subItem.ForeColor = Color.Teal;

                    subItem = item.SubItems.Add(meta.Value.IsUserDefined.ToString());

                    if (meta.Value.IsUserDefined)
                    {
                        subItem.ForeColor = Color.Blue;
                    }

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
                        case PropertyType.BooleanList:
                            item.SubItems.Add(string.Join("; ", ((BooleanListProperty)meta.Value).Value));
                            break;
                        case PropertyType.DateTimeList:
                            item.SubItems.Add(string.Join("; ", ((DateTimeListProperty)meta.Value).Value));
                            break;
                        case PropertyType.DoubleList:
                            item.SubItems.Add(string.Join("; ", ((DoubleListProperty)meta.Value).Value));
                            break;
                        case PropertyType.Int32List:
                            item.SubItems.Add(string.Join("; ", ((Int32ListProperty)meta.Value).Value));
                            break;
                        case PropertyType.Int64List:
                            item.SubItems.Add(string.Join("; ", ((Int64ListProperty)meta.Value).Value));
                            break;
                        case PropertyType.StringList:
                            item.SubItems.Add(string.Join("; ", ((StringListProperty)meta.Value).Value));
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

