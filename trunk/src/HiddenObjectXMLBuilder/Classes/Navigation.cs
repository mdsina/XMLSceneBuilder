using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.IO;
using HiddenObjectStudio.Core;

namespace HiddenObjectsXMLBuilder
{
    class Navigation
    {
        XmlDocument NavigationsXML;
        XmlDocument QuestsXML;

        private BuilderConfig _builderConfig;
		private BuildOptions _buildOptions;
        string _NavFileName;
        string _QuestsFileName;
        XmlElement _navRoot;
        XmlElement _questRoot;
        bool hasChildNodeNav = false;
        bool hasChildNodeQuest = false;

        public Navigation(BuilderConfig builderConfig, BuildOptions buildOptions)
		{
			_builderConfig = builderConfig;
			_buildOptions = buildOptions;

            NavigationsXML = new XmlDocument();
            QuestsXML = new XmlDocument();

            _NavFileName = null;
            _QuestsFileName = null;

            if (_buildOptions.rebuildNavigation)

            if (_buildOptions.sceneName.Contains("ce_"))
            {
                _NavFileName = "\\navigation_ce.xml";

                if (!File.Exists(_buildOptions.navigationFilePath + _NavFileName))
                {
                    _NavFileName = "\\navigation.xml";

                    if (!File.Exists(_buildOptions.navigationFilePath + _NavFileName))
                        _NavFileName = null;
                }

                _QuestsFileName = "\\quest_ce.xml";

                if (!File.Exists(_buildOptions.navigationFilePath + _QuestsFileName))
                {
                    _QuestsFileName = "\\quest.xml";

                    if (!File.Exists(_buildOptions.navigationFilePath + _QuestsFileName))
                        _QuestsFileName = null;
                }

            } 
            else 
            {
                _NavFileName = "\\navigation_se.xml";

                if (!File.Exists(_buildOptions.navigationFilePath + _NavFileName))
                {
                    _NavFileName = "\\navigation.xml";

                    if (!File.Exists(_buildOptions.navigationFilePath + _NavFileName))
                        _NavFileName = null;
                }

                _QuestsFileName = "\\quest_se.xml";

                if (!File.Exists(_buildOptions.navigationFilePath + _QuestsFileName))
                {
                    _QuestsFileName = "\\quest.xml";

                    if (!File.Exists(_buildOptions.navigationFilePath + _QuestsFileName))
                        _QuestsFileName = null;
                }
            }// end main if

            if (_NavFileName != null)
            {
                NavigationsXML.Load(_buildOptions.navigationFilePath + _NavFileName);

                _navRoot = (XmlElement)NavigationsXML.FirstChild;
                

                for (int i = 0; i < _navRoot.ChildNodes.Count; i++ )
                {
                    if (!_buildOptions.isHO)
                    {
                        if (_navRoot.ChildNodes[i].Name == _buildOptions.sceneName)
                        {
                            hasChildNodeNav = true;
                            break;
                        }
                    }
                    else
                    {
                        if (_buildOptions.isHo01)
                        {
                            if (_navRoot.ChildNodes[i].Name == _buildOptions.sceneName + "_01")
                            {
                                hasChildNodeNav = true;
                                break;
                            }
                        }

                        if (_buildOptions.isHo02)
                        {
                            if (_navRoot.ChildNodes[i].Name == _buildOptions.sceneName + "_02")
                            {
                                hasChildNodeNav = true;
                                break;
                            }
                        }
                    }
                    
                }

            }// end Navigation file

            if (_QuestsFileName != null)
            {
                QuestsXML.Load(_buildOptions.navigationFilePath + _QuestsFileName);

                _questRoot = (XmlElement)QuestsXML.FirstChild;

                for (int i = 0; i < _questRoot.ChildNodes.Count; i++)
                {
                    if (!_buildOptions.isHO)
                    {
                        if (_questRoot.ChildNodes[i].Name == _buildOptions.sceneName)
                        {
                            hasChildNodeQuest = true;
                            break;
                        }
                    }
                    else
                    {
                        if (_buildOptions.isHo01)
                        {
                            if (_questRoot.ChildNodes[i].Name == _buildOptions.sceneName + "_01" )
                            {
                                hasChildNodeQuest = true;
                                break;
                            }
                        }
                        if (_buildOptions.isHo02)
                        {
                            if (_questRoot.ChildNodes[i].Name == _buildOptions.sceneName + "_02")
                            {
                                hasChildNodeQuest = true;
                                break;
                            }
                        }
                    }
                    
                }
                
            }// end quests file
        }//end constructor

        private void AddNode(string _name, XmlElement _child)
        {
            
        }

        public void Processing()
        {
            if (!hasChildNodeNav)
            {
                if (!_buildOptions.isHO)
                {
                    XmlElement _rootChild = NavigationsXML.CreateElement(_buildOptions.sceneName);

                    if (!_buildOptions.isMinigame && !_buildOptions.isSubscreen)
                    {
                        _rootChild.SetAttribute("map_location", _buildOptions.sceneName);
                    }
                    else
                    {
                        XmlElement SceneFoundedNode = null;
                        for (int i = 0; i < _navRoot.ChildNodes.Count; i++)
                        {
                            if (_buildOptions.sceneName.Contains(_navRoot.ChildNodes[i].Name))
                            {
                                SceneFoundedNode = (XmlElement)_navRoot.ChildNodes[i];
                                break;
                            }
                        }

                        if (SceneFoundedNode != null)
                        {
                            _rootChild.SetAttribute("map_location", SceneFoundedNode.Name);

                            if (_buildOptions.isSubscreen)
                            {
                                XmlElement _layerNode = NavigationsXML.CreateElement(SceneFoundedNode.Name);
                                _layerNode.SetAttribute("layer", "close_button");
                                _rootChild.AppendChild(_layerNode);
                            }
                        }

                        
                    }

                    _navRoot.AppendChild(_rootChild);
                }
                else
                {
                    XmlElement _rootChild1;
                    XmlElement _rootChild2;

                    if (_buildOptions.isHo01)
                    {
                        _rootChild1 = NavigationsXML.CreateElement(_buildOptions.sceneName + "_01");

                        XmlElement SceneFoundedNode = null;
                        for (int i = 0; i < _navRoot.ChildNodes.Count; i++)
                        {
                            if (_buildOptions.sceneName.Contains(_navRoot.ChildNodes[i].Name))
                            {
                                SceneFoundedNode = (XmlElement)_navRoot.ChildNodes[i];
                                break;
                            }
                        }

                        if (SceneFoundedNode != null)
                        {
                            _rootChild1.SetAttribute("map_location", SceneFoundedNode.Name);
                        }

                        _navRoot.AppendChild(_rootChild1);

                    }
                    if (_buildOptions.isHo02)
                    {
                        _rootChild2 = NavigationsXML.CreateElement(_buildOptions.sceneName + "_02");

                        XmlElement SceneFoundedNode = null;
                        for (int i = 0; i < _navRoot.ChildNodes.Count; i++)
                        {
                            if (_buildOptions.sceneName.Contains(_navRoot.ChildNodes[i].Name))
                            {
                                SceneFoundedNode = (XmlElement)_navRoot.ChildNodes[i];
                                break;
                            }
                        }

                        if (SceneFoundedNode != null)
                        {
                            _rootChild2.SetAttribute("map_location", SceneFoundedNode.Name);
                        }

                        _navRoot.AppendChild(_rootChild2);
                    }
                }

            }

            if (!hasChildNodeQuest)
            {
                if (!_buildOptions.isHO)
                {
                    XmlElement _rootChild = QuestsXML.CreateElement(_buildOptions.sceneName);

                    _questRoot.AppendChild(_rootChild);
                }
                else
                {
                    if (_buildOptions.isHo01)
                    {
                        XmlElement _rootChild = QuestsXML.CreateElement(_buildOptions.sceneName + "_01");

                        _questRoot.AppendChild(_rootChild);
                    }
                    if (_buildOptions.isHo02)
                    {
                        XmlElement _rootChild = QuestsXML.CreateElement(_buildOptions.sceneName + "_02");

                        _questRoot.AppendChild(_rootChild);
                    }
                }
                
            }
        } // end Processing

        public void Save()
        {
            if (_NavFileName != null)
            {
                NavigationsXML.Save(_buildOptions.navigationFilePath + _NavFileName);
            }
            if (_QuestsFileName != null)
            {
                QuestsXML.Save(_buildOptions.navigationFilePath + _QuestsFileName);
            }
            
        }
    }


}
