using System;
using System.Collections.Generic;
using System.Text;

namespace HiddenObjectsXMLBuilder
{
	public class Hints
	{
		public Hints()
		{
			private BuilderConfig _builderConfig;
			private BuildOptions _buildOptions;

			private Dictionary<string, XmlDocument> _itemsDocuments;


			public Items(BuilderConfig builderConfig, BuildOptions buildOptions)
			{
				_builderConfig = builderConfig;
				_buildOptions = buildOptions;

				_itemsDocuments = new Dictionary<string, XmlDocument>();

			}

			public void AddItem(FileName fn)
			{
				if (fn.IsCollectableItem)
				{
					XmlDocument itemsXmlDoc = AddItemsDoc(fn);

					XmlElement itemsNode = (XmlElement)itemsXmlDoc.SelectSingleNode("items");

					XmlElement itemNode = itemsXmlDoc.CreateElement(fn.TextureName);

					itemNode.SetAttribute("group", fn.GroupName);
					itemNode.SetAttribute("full_name", fn.TextureName);

					itemsNode.AppendChild(itemNode);
				}
			}

			private XmlDocument AddItemsDoc(FileName fn)
			{
				string itemsFileName = "items_" + fn.GetItemsIndex();
				XmlDocument xmlDoc = null;

				try
				{
					xmlDoc = _itemsDocuments[itemsFileName];
				}
				catch (KeyNotFoundException)
				{
					xmlDoc = new XmlDocument();
					_itemsDocuments[itemsFileName] = xmlDoc;
					xmlDoc.AppendChild(xmlDoc.CreateElement("items"));

				}

				return xmlDoc;
			}

			public void Save()
			{
				foreach (string itemsFileName in _itemsDocuments.Keys)
				{
					XmlDocument itemsXmlDoc = _itemsDocuments[itemsFileName];
					itemsXmlDoc.Save(Tool.AppendSlashIfNeeded(_buildOptions.dstFolder) + itemsFileName + ".xml");
				}

			}
		}
	}
}
