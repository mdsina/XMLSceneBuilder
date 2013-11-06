using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Diagnostics;
using HiddenObjectStudio.Core;
using System.Windows.Forms;

namespace HiddenObjectsXMLBuilder
{
	class HoSet
	{
		public Dictionary<string, int> _groups;
		public Dictionary<string, string> _russianNames;

		public HoSet()
		{
			_groups = new Dictionary<string, int>();
			_russianNames = new Dictionary<string, string>();
		}

		public void AddGroup(FileName fn)
		{
			if (_groups.ContainsKey(fn.GroupName))
			{
				_groups[fn.GroupName]++;
			}
			else
			{
				_groups[fn.GroupName] = 1;
				_russianNames[fn.GroupName] = HiddenObjectStudio.Core.Tools.CutDigitsFromTail(fn.RussianName);
			}
		}


		public void SaveToXml(XmlNode node)
		{
			if (_groups.Count > 0)
			{
				foreach (string groupName in _groups.Keys)
				{
					XmlElement itemNode = (XmlElement)node.SelectSingleNode(groupName);

					if (itemNode == null)
					{
						itemNode = node.OwnerDocument.CreateElement(groupName);

						XmlNode countNode = CreateCountNode(node.OwnerDocument, groupName, 1, 1);

						itemNode.AppendChild(countNode);
					}

					node.AppendChild(itemNode);
				}
			}
		}

		public XmlNode CreateCountNode(XmlDocument xmlDoc, string str, int nodeCount, int itemsCount)
		{
			XmlElement node = xmlDoc.CreateElement("_1");
			node.SetAttribute("text", _russianNames[str].Replace('_', ' '));
			return node;
		}
	}

	class Texts
	{
		static public string HO_ITEMS_PATH = "gameplay/ho_items";

		private BuilderConfig _builderConfig;
		private BuildOptions _buildOptions;

		private XmlDocument _textsXmlDoc;
		private XmlElement _hoItemsNode;

		private Dictionary<string, HoSet> _hoSets;		


		public Texts(BuilderConfig builderConfig, BuildOptions buildOptions)
		{
			_builderConfig = builderConfig;
			_buildOptions = buildOptions;

			_textsXmlDoc = new XmlDocument();

			_hoSets = new Dictionary<string, HoSet>();

			if (File.Exists(_buildOptions.textXmlFileName))
			{
				_textsXmlDoc.Load(_buildOptions.textXmlFileName);
				_hoItemsNode  = (XmlElement)_textsXmlDoc.DocumentElement.SelectSingleNode(HO_ITEMS_PATH);

				if (_hoItemsNode == null)
				{
					throw new Exception("Не могу найти ноду '" + HO_ITEMS_PATH + "' в файле с текстами '" + _buildOptions.textXmlFileName + "'");
				}
			}
			else
			{
				throw new Exception("Не могу найти файл с текстами '" + _buildOptions.textXmlFileName + "'");
			}
		}

		public void AddGroup(FileName fn)
		{
			if (!fn.IsDropZone && !fn.IsActiveZone)
			{
				string ho_scene_name = GetHoSetName(fn.ItemsIndex);

				HoSet ho_text;

				if (_hoSets.ContainsKey(ho_scene_name))
				{
					ho_text = _hoSets[ho_scene_name];
				}
				else
				{
					ho_text = new HoSet();
					_hoSets.Add(ho_scene_name, ho_text);
				}

				ho_text.AddGroup(fn);
			}
		}

		public void Save()
		{
			foreach (string hoSetName in _hoSets.Keys)
			{
				XmlElement hoSetTextsNode = (XmlElement)_hoItemsNode.SelectSingleNode(hoSetName);

				if (hoSetTextsNode == null)
				{
					hoSetTextsNode = _hoItemsNode.OwnerDocument.CreateElement(hoSetName);
					_hoItemsNode.AppendChild(hoSetTextsNode);
				}

				_hoSets[hoSetName].SaveToXml(hoSetTextsNode);
			}

	
			//////////////////////////////////////////////////////////////////////////
			/// Save texts xml
			//textsNode.AppendChild(textsSceneNode);
			FileInfo fi = new FileInfo(_buildOptions.textXmlFileName);

			if (!Directory.Exists(fi.DirectoryName))
			{
				Directory.CreateDirectory(fi.DirectoryName);
			}

			XmlWriter textsWriter = new XmlTextWriter(_buildOptions.textXmlFileName, Encoding.GetEncoding("unicode"));
			_textsXmlDoc.Save(textsWriter);
			textsWriter.Close();


			FormatXml();
		}

		private void FormatXml()
		{
			Process p = new Process();
			p.StartInfo.FileName = HiddenObjectStudio.Core.Tools.AppendSlashIfNeeded(_builderConfig.ElefunToolsPath) + "FormatedXML.exe";
			p.StartInfo.Arguments = (new FileInfo(_buildOptions.textXmlFileName)).FullName;
			p.Start();
			p.WaitForExit();
		}

		public string GetHoSetName(string itemsIndex)
		{
			return _buildOptions.sceneName + "_" + itemsIndex;
		}
	}
}
