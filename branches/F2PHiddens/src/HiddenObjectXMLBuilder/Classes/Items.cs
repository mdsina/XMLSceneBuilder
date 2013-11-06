using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using HiddenObjectStudio.Core;
using System.Windows.Forms;

namespace HiddenObjectsXMLBuilder
{
	class Items
	{
		private BuilderConfig _builderConfig;
		private BuildOptions _buildOptions;

		private Dictionary<string, XmlDocument> _itemsDocuments;
		private Dictionary<string, XmlDocument> _hintsDocuments;


		public Items(BuilderConfig builderConfig, BuildOptions buildOptions)
		{
			_builderConfig = builderConfig;
			_buildOptions = buildOptions;

			_itemsDocuments = new Dictionary<string, XmlDocument>();
			_hintsDocuments = new Dictionary<string, XmlDocument>();
		}

		public void AddItem(FileName fn)
		{
			try
			{
				if (fn.IsCollectableItem)
				{
					if (_buildOptions.rebuildItemsFile)
					{
						XmlDocument itemsXmlDoc = AddItemsDoc(fn);

						XmlElement itemsNode = (XmlElement)itemsXmlDoc.SelectSingleNode("items");

						XmlElement itemNode = itemsXmlDoc.CreateElement(fn.TextureName);

						itemNode.SetAttribute("group", fn.GroupName);
						itemNode.SetAttribute("layer_full_name", fn.TextureName);

						itemsNode.AppendChild(itemNode);

					}


					if (_buildOptions.rebuildHintsFile)
					{
						XmlDocument hintsXmlDoc = AddHintsDoc(fn);

						XmlElement hintsNode = (XmlElement)hintsXmlDoc.SelectSingleNode("hints");


						XmlElement hintNode = hintsXmlDoc.CreateElement("hint");

						hintNode.SetAttribute("condition", "_collected-" + _buildOptions.sceneName + "_" + fn.ItemsIndex + "-" + fn.EnglishName + " = ''");

						hintNode.InnerXml = "<layer name=\"" + fn.EnglishName + "\"/>";

						hintsNode.AppendChild(hintNode);

					}

				}
			}
			catch (System.Exception)
			{
				MessageBox.Show(fn.FullFileName, "Error");

				throw new Exception();
			}
		}

		private XmlDocument AddItemsDoc(FileName fn)
		{
			string itemsFileName = "items_" + fn.ItemsIndex;
			XmlDocument xmlDoc = null;
			XmlElement root = null;

			if (_itemsDocuments.ContainsKey(itemsFileName))
			{
				xmlDoc = _itemsDocuments[itemsFileName];
				root = (XmlElement)xmlDoc.SelectSingleNode("items");
			}
			else
			{
				xmlDoc = new XmlDocument();
				root = xmlDoc.CreateElement("items");
				xmlDoc.AppendChild(root);

				_itemsDocuments[itemsFileName] = xmlDoc;
			}
			//root.SetAttribute("hints_file", "hints_" + fn.GetItemsIndex() + ".xml");

			return xmlDoc;
		}

		private XmlDocument AddHintsDoc(FileName fn)
		{
			string hintsFileName = "hints_" + fn.ItemsIndex;
			XmlDocument xmlDoc = null;

			if (_hintsDocuments.ContainsKey(hintsFileName))
			{
				xmlDoc = _hintsDocuments[hintsFileName];
			}
			else
			{
				xmlDoc = new XmlDocument();
				_hintsDocuments[hintsFileName] = xmlDoc;
				xmlDoc.AppendChild(xmlDoc.CreateElement("hints"));
				_hintsDocuments[hintsFileName] = xmlDoc;

			}

			return xmlDoc;
		}

		public void Save()
		{
			foreach (string itemsFileName in _itemsDocuments.Keys)
			{
				XmlDocument itemsXmlDoc = _itemsDocuments[itemsFileName];
				itemsXmlDoc.Save(HiddenObjectStudio.Core.Tools.AppendSlashIfNeeded(_buildOptions.dstFolder) + itemsFileName + ".xml");
			}

			foreach (string hintsFileName in _hintsDocuments.Keys)
			{
				XmlDocument hintsXmlDoc = _hintsDocuments[hintsFileName];
				hintsXmlDoc.Save(HiddenObjectStudio.Core.Tools.AppendSlashIfNeeded(_buildOptions.dstFolder) + hintsFileName + ".xml");
			}

		}

        public List<string> GetItemsNames()
        {
            List<string> itemsNames = new List<string>();
            foreach (string itemsFileName in _itemsDocuments.Keys)
            {
                XmlDocument itemsXmlDoc = _itemsDocuments[itemsFileName];
                
                XmlNode itemsNode = itemsXmlDoc.SelectSingleNode("items");

                XmlNodeList itemNodeList = itemsNode.ChildNodes;

                foreach (XmlNode itemNode in itemNodeList)
                {
                    itemsNames.Add(itemNode.Name); 
                }
                
            }
            return itemsNames;
        }

        public void AddColors(List<string> interactiveItems, string interactiveColor, string defaultColor)
        {
            foreach (string itemsFileName in _itemsDocuments.Keys)
            {
                XmlDocument itemsXmlDoc = _itemsDocuments[itemsFileName];

                XmlElement itemsNode = (XmlElement)itemsXmlDoc.SelectSingleNode("items");

                itemsNode.SetAttribute("default_color", defaultColor);

                XmlNodeList itemNodeList = itemsNode.ChildNodes;

                foreach (XmlElement itemNode in itemNodeList)
                {
                    if (interactiveItems.Contains(itemNode.Name))
                    {
                        itemNode.SetAttribute("color", interactiveColor);
                        itemNode.SetAttribute("revert_color_condition", _buildOptions.sceneName + "_" +
                            itemsFileName.Substring(6) + "_" + itemNode.Name + "_" + "color");
                    }
                }

            }
                
        }
	}
}
