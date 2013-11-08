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
            string itemName = _russianNames[str].Replace("_", " ");
			node.SetAttribute("text", itemName[0].ToString().ToUpper() + itemName.Substring(1));
			return node;
		}
	}

	class Texts
	{
		static public string HO_ITEMS_PATH = "gameplay/ho_items";
        static public string MINIGAME_DESC_PATH = "gameplay/mini_games_descriptions";

		private BuilderConfig _builderConfig;
		private BuildOptions _buildOptions;

		private XmlDocument _textsXmlDoc;
		private XmlElement _hoItemsNode;

        public String _TextsSE = null;
        public XmlDocument _TextsSENode;

        public String _TextsCE = null;
        public XmlDocument _TextsCENode;

        public String _TextsFH = null;
        public XmlDocument _TextsFHNode;
        public XmlDocument t_Document;

        public String _pDocName = null;

		private Dictionary<string, HoSet> _hoSets;		


		public Texts(BuilderConfig builderConfig, BuildOptions buildOptions)
		{
			_builderConfig = builderConfig;
			_buildOptions = buildOptions;

			_textsXmlDoc = new XmlDocument();
            _TextsCENode = new XmlDocument();
            _TextsSENode = new XmlDocument();
            _TextsFHNode = new XmlDocument();

			_hoSets = new Dictionary<string, HoSet>();

            if (File.Exists(_buildOptions.textXmlFileName + "\\texts_config.xml"))
			{
                _textsXmlDoc.Load(_buildOptions.textXmlFileName + "\\texts_config.xml");
				//_hoItemsNode  = (XmlElement)_textsXmlDoc.DocumentElement.SelectSingleNode(HO_ITEMS_PATH);
                    
                    if (_textsXmlDoc.ChildNodes[0] != null)
                    {
                        for (int i = 0; i < _textsXmlDoc.ChildNodes[0].ChildNodes.Count; i++)
                        {
                            switch (_textsXmlDoc.ChildNodes[0].ChildNodes[i].Attributes["file_name"].Value)
                            {
                                case "texts_first_hour.xml":
                                    _TextsFH = "\\texts_first_hour.xml";
                                    _TextsFHNode.Load(_buildOptions.textXmlFileName + _TextsFH);
                                    break;
                                case "texts_se.xml":
                                    _TextsSE = "\\texts_se.xml";
                                    _TextsSENode.Load(_buildOptions.textXmlFileName + _TextsSE);
                                    break;
                                case "texts_ce.xml":
                                    _TextsCE = "\\texts_ce.xml";
                                    _TextsCENode.Load(_buildOptions.textXmlFileName + _TextsCE);
                                    break;
                            }

                        }
                    }

                if (_buildOptions.sceneName.Contains("ce_"))
                {
                    if (_TextsCENode != null)
                    {
                        t_Document = _TextsCENode;
                        _pDocName = _TextsCE;
                    }
                }
                else
                {
                    if (_TextsFHNode != null)
                    {
                        t_Document = _TextsFHNode;
                        _pDocName = _TextsFH;
                    }
                }

                if (t_Document != null)
                {
                    String t_Desc = null;
                    String t_Desc2 = null;
                    if (_buildOptions.isMinigame)
                    {
                        t_Desc = MINIGAME_DESC_PATH;
                        t_Desc2 = "mini_games_descriptions";
                    }
                    else
                    {
                        t_Desc = HO_ITEMS_PATH;
                        t_Desc2 = "ho_items";
                    }

                    _hoItemsNode = (XmlElement)t_Document.DocumentElement.SelectSingleNode(t_Desc);
                    XmlElement _t_NodeGameplay = (XmlElement)t_Document.DocumentElement.SelectSingleNode("gameplay");

                    if (_hoItemsNode == null)
                    {
                        XmlElement t_hoItem = t_Document.CreateElement(t_Desc2);
                        _t_NodeGameplay.AppendChild(t_hoItem);
                        _hoItemsNode = t_hoItem;
                    }
                }
			}
            else if (File.Exists(_buildOptions.textXmlFileName + "\\texts.xml"))
            {
                _textsXmlDoc.Load(_buildOptions.textXmlFileName + "\\texts.xml");
                _pDocName = "texts.xml";

                String t_Desc = null;
                String t_Desc2 = null;
                if (_buildOptions.isMinigame)
                {
                    t_Desc = MINIGAME_DESC_PATH;
                    t_Desc2 = "mini_games_descriptions";
                }
                else
                {
                    t_Desc = HO_ITEMS_PATH;
                    t_Desc2 = "ho_items";
                }

                _hoItemsNode = (XmlElement)_textsXmlDoc.DocumentElement.SelectSingleNode(t_Desc);
                XmlElement _t_NodeGameplay = (XmlElement)_textsXmlDoc.DocumentElement.SelectSingleNode("gameplay");

                if (_hoItemsNode == null)
                {
                    XmlElement t_hoItem = _textsXmlDoc.CreateElement(t_Desc2);
                    _t_NodeGameplay.AppendChild(t_hoItem);
                    _hoItemsNode = t_hoItem;
                }

                t_Document = _textsXmlDoc;
            }
            else
            {
                throw new Exception("Не могу найти файл с текстами '" + _buildOptions.textXmlFileName + "texts.xml" + "'");
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
            if (_buildOptions.isMinigame)
			{
                XmlElement t_mg = t_Document.CreateElement(_buildOptions.sceneName);
                t_mg.SetAttribute("text", "TEST_ " + _buildOptions.sceneName + " description");

                if (!_buildOptions.FoundParentNode(_buildOptions.sceneName, _hoItemsNode))
                {
                    _hoItemsNode.AppendChild(t_mg);
                }
                
            }
            else
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
            }

			//////////////////////////////////////////////////////////////////////////
			/// Save texts xml
			//textsNode.AppendChild(textsSceneNode);
			FileInfo fi = new FileInfo(_buildOptions.textXmlFileName +_pDocName);

			if (!Directory.Exists(fi.DirectoryName))
			{
				Directory.CreateDirectory(fi.DirectoryName);
			}

            XmlWriter textsWriter = new XmlTextWriter(_buildOptions.textXmlFileName + _pDocName, Encoding.GetEncoding("unicode"));
            t_Document.Save(textsWriter);
			textsWriter.Close();


			FormatXml();
		}

		private void FormatXml()
		{
			Process p = new Process();
			p.StartInfo.FileName = HiddenObjectStudio.Core.Tools.AppendSlashIfNeeded(_builderConfig.ElefunToolsPath) + "FormatedXML.exe";
            p.StartInfo.Arguments = (new FileInfo(_buildOptions.textXmlFileName + _pDocName)).FullName;
			p.Start();
			p.WaitForExit();
		}

		public string GetHoSetName(string itemsIndex)
		{
			return _buildOptions.sceneName + "_" + itemsIndex;
		}
	}
}
