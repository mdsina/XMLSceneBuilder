using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using HiddenObjectStudio.Core;

namespace HiddenObjectsXMLBuilder
{
    class Options
    {
        private XmlDocument _ParametresXmlDoc;
		private XmlElement _ParametresRoot;
		private string _ParametresFileName;

        public Options(List<Parameters> _List)
		{
            if (!File.Exists(Environment.CurrentDirectory + "\\Parametres.xml"))
            {
                _ParametresFileName = Environment.CurrentDirectory + "\\Parametres.xml";

                _ParametresXmlDoc = new XmlDocument();

                _ParametresRoot = _ParametresXmlDoc.CreateElement("parametres");
                
                if (_List.Count != 0)
                {
                    for (int i = 0; i < _List.Count; i++ )
                    {
                        XmlElement tElement = _ParametresXmlDoc.CreateElement(_List[i].ItemName);

                        XmlElement tElementPNG = _ParametresXmlDoc.CreateElement("SrcRoot");
                        tElementPNG.SetAttribute("value", _List[i].pngPath);

                        XmlElement tElementTexts = _ParametresXmlDoc.CreateElement("TextsXmlFileName");
                        tElementTexts.SetAttribute("value", _List[i].textsPath);

                        XmlElement tElementLevels = _ParametresXmlDoc.CreateElement("LevelsXmlFileName");
                        tElementLevels.SetAttribute("value", _List[i].LevelsFilePath);

                        XmlElement tElementHints = _ParametresXmlDoc.CreateElement("NavigationSystemPath");
                        tElementHints.SetAttribute("value", _List[i].hintPath);

                        XmlElement tElementScenes = _ParametresXmlDoc.CreateElement("DstRoot");
                        tElementScenes.SetAttribute("value", _List[i].scenesPath);

                        tElement.AppendChild(tElementPNG);
                        tElement.AppendChild(tElementTexts);
                        tElement.AppendChild(tElementLevels);
                        tElement.AppendChild(tElementHints);
                        tElement.AppendChild(tElementScenes);

                        _ParametresRoot.AppendChild(tElement);
                    }

                    _ParametresXmlDoc.AppendChild(_ParametresRoot);
                }
            }
            else
            {
                _ParametresFileName = Environment.CurrentDirectory + "\\Parametres.xml";

                _ParametresXmlDoc = new XmlDocument();
                _ParametresXmlDoc.Load(_ParametresFileName);

                _ParametresRoot = (XmlElement)_ParametresXmlDoc.FirstChild;

                if (_List.Count != 0)
                {
                    for (int i = 0; i < _List.Count; i++)
                    {
                        bool _flag = false;
                        for (int j = 0; j < _ParametresRoot.ChildNodes.Count; j++ )
                        {
                            if (_ParametresRoot.ChildNodes[j].Name == _List[i].ItemName)
                            {
                                _flag = true;
                            }
                        }

                        if (!_flag)
                        {
                            XmlElement tElement = _ParametresXmlDoc.CreateElement(_List[i].ItemName);

                            XmlElement tElementPNG = _ParametresXmlDoc.CreateElement("SrcRoot");
                            tElementPNG.SetAttribute("value", _List[i].pngPath);

                            XmlElement tElementTexts = _ParametresXmlDoc.CreateElement("TextsXmlFileName");
                            tElementTexts.SetAttribute("value", _List[i].textsPath);

                            XmlElement tElementLevels = _ParametresXmlDoc.CreateElement("LevelsXmlFileName");
                            tElementLevels.SetAttribute("value", _List[i].LevelsFilePath);

                            XmlElement tElementHints = _ParametresXmlDoc.CreateElement("NavigationSystemPath");
                            tElementHints.SetAttribute("value", _List[i].hintPath);

                            XmlElement tElementScenes = _ParametresXmlDoc.CreateElement("DstRoot");
                            tElementScenes.SetAttribute("value", _List[i].scenesPath);

                            tElement.AppendChild(tElementPNG);
                            tElement.AppendChild(tElementTexts);
                            tElement.AppendChild(tElementLevels);
                            tElement.AppendChild(tElementHints);
                            tElement.AppendChild(tElementScenes);

                            _ParametresRoot.AppendChild(tElement);
                        }
                        
                    }
                }
            }

		}

		public void Save()
		{
			_ParametresXmlDoc.Save(_ParametresFileName);
		}
    }
}
