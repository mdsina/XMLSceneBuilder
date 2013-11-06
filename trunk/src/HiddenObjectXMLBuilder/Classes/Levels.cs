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
    class Levels
    {
        private BuilderConfig _builderConfig;
        private BuildOptions _buildOptions;
        private XmlDocument _sceneXmlDoc;
        private XmlElement _sceneRoot;
        private XmlElement _layersNode_SE;
        private XmlElement _layersNode_CE;

        private string _xmlFileName;

        private const string LayersNodeName = "stage";
        private const string LevelNodeName = "level";
        private const string LevelNodeResource = "resources";
        private const string LevelNodeSubscreens = "subscreens";
        private const string LevelNodeMinigames = "mini_games";
        private const string LevelNodeResourceFileNodeName = "file";
        private const string LevelNodeResource_common = "data\\scenes\\common\\resources.xml";
        private const string LevelNodeResource_morfing = "data\\scenes\\common\\resources_morfing.xml";
        private const string LevelNodeResource_sub = "data\\scenes\\common\\resources_subscreens.xml";
        private const string GlintsFile = "glints.xml";
        private const string DefaultPlaylist = "game_playlist_default";
        private const string DefaultGamePos = "dm";
        private const string DefaultGDDNumber = "99. ";

        private bool FoundParentNode(string _nodeName, XmlNode _tNode)
        {
            for (int i = 0; i < _tNode.ChildNodes.Count; i++)
            {
                if (_tNode.ChildNodes[i].Name == _nodeName)
                {
                    return true;
                }
            }
            return false;
        }

        private bool FoundParentAttribute(string _attrName, string _placeName, XmlNode _tNode)
        {
            for (int i = 0; i < _tNode.ChildNodes.Count; i++)
            {
                if (_tNode.ChildNodes[i].Attributes != null)
                {
                    if (_tNode.ChildNodes[i].Attributes[_attrName].Value == _placeName)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public Levels(BuilderConfig builderConfig, BuildOptions buildOptions)
        {
            _builderConfig = builderConfig;
            _buildOptions = buildOptions;

            _xmlFileName = _buildOptions.levelsXmlFileName;

            _sceneXmlDoc = new XmlDocument();

            if (_buildOptions.rebuildLevels)
            {
                if (File.Exists(_xmlFileName))
                {
                    _sceneXmlDoc.Load(_xmlFileName);
                }
            }

            _sceneRoot = (XmlElement)_sceneXmlDoc.DocumentElement;
            _layersNode_SE = (XmlElement)_sceneRoot.FirstChild;
            _layersNode_CE = (XmlElement)_sceneRoot.LastChild;

        }

        private XmlElement AddResource(string Name)
        {

            XmlElement levelResourcesFiles;
            levelResourcesFiles = _sceneXmlDoc.CreateElement(LevelNodeResourceFileNodeName);

            levelResourcesFiles.SetAttribute("file_name", Name);

            return levelResourcesFiles;
        }

        private void AddMinigame(string Name, XmlNode Node)
        {

            XmlElement levelResourcesFiles;
            levelResourcesFiles = _sceneXmlDoc.CreateElement(Name);

            levelResourcesFiles.SetAttribute("type", "script_stub");
            levelResourcesFiles.SetAttribute("description", "gameplay/mini_games_descriptions/" + Name);
            levelResourcesFiles.SetAttribute("complete_mini_game_variable", Name + "_completed");

            bool FoundedMG = false;
            XmlElement levelMG_node = null;

            if (Name.Contains("_mg") || Name.Contains("_minigame") || Name.Contains("_mini_game") || Name.Contains("_puzzle"))
            {
                for (int i = 0; i < Node.ChildNodes.Count; i++)
                {
                    if (Node.ChildNodes[i].Name == LevelNodeMinigames)
                    {
                        levelMG_node = (XmlElement)Node.ChildNodes[i];
                        FoundedMG = true;
                    }
                }

                if (levelMG_node == null)
                {
                    levelMG_node = _sceneXmlDoc.CreateElement(LevelNodeMinigames);
                }

                if (!FoundParentNode(_buildOptions.sceneName, levelMG_node))
                {
                    levelMG_node.AppendChild(levelResourcesFiles);
                }

                if (FoundedMG == false)
                {
                    Node.AppendChild(levelMG_node);
                }
            }
        }

        public void ProcessNormalTextureNode(FileName fn)
        {
            try
            {
                if (!_buildOptions.sceneName.Contains("_ho"))
                {
                    if (_buildOptions.isSubscreen)
                    {
                        XmlElement counter = _layersNode_SE;
                        XmlNode FoundedLevel = null;

                        if (_buildOptions.sceneName.Contains("ce_"))
                            counter = _layersNode_CE;

                        for (int i = 0; i < counter.ChildNodes.Count; i++)
                        {
                            XmlNode curr = counter.ChildNodes[i];
                            if (_buildOptions.sceneName.Contains(curr.Attributes["place"].Value))
                            {
                                FoundedLevel = curr;
                                break;
                            }
                        }

                        if (FoundedLevel != null)
                        {
                            XmlElement layerNode;

                            layerNode = _sceneXmlDoc.CreateElement(_buildOptions.sceneName);

                            layerNode.SetAttribute("scene_folder", _buildOptions.sceneName);
                            layerNode.SetAttribute("scene_file", _buildOptions.sceneName + ".xml");
                            layerNode.SetAttribute("glints_file", GlintsFile);

                            XmlElement levelSubscreens = null;
                            XmlElement levelResources_node = null;
                            bool FoundedNodeSub = false;
                            bool FoundedNodeResource = false;

                            for (int i = 0; i < FoundedLevel.ChildNodes.Count; i++)
                            {
                                if (FoundedLevel.ChildNodes[i].Name == LevelNodeResource)
                                {
                                    levelResources_node = (XmlElement)FoundedLevel.ChildNodes[i];
                                    FoundedNodeResource = true;
                                }
                                if (FoundedLevel.ChildNodes[i].Name == LevelNodeSubscreens)
                                {
                                    levelSubscreens = (XmlElement)FoundedLevel.ChildNodes[i];
                                    FoundedNodeSub = true;
                                    break;
                                }
                            }

                            if (levelSubscreens == null)
                            {
                                levelSubscreens = _sceneXmlDoc.CreateElement(LevelNodeSubscreens);
                            }

                            if (!FoundParentNode(_buildOptions.sceneName, levelSubscreens))
                            {
                                levelSubscreens.AppendChild(layerNode);
                            }
                            
                            if (levelResources_node == null)
                            {
                                levelResources_node = _sceneXmlDoc.CreateElement(LevelNodeResource);
                            }

                            string resource_str = "data\\scenes\\" + _buildOptions.sceneName + "\\resources.xml";

                            if (!FoundParentAttribute("file_name", resource_str, levelResources_node))
                            {
                                levelResources_node.AppendChild(AddResource(resource_str));
                            }
                            
                            if (FoundedNodeSub == false)
                            {
                                FoundedLevel.AppendChild(levelSubscreens);
                            }

                            if (FoundedNodeResource == false)
                            {
                                FoundedLevel.AppendChild(levelResources_node);
                            }

                            AddMinigame(_buildOptions.sceneName, FoundedLevel);
                        }
                    }
                    else
                    {
                        XmlElement tLevel;

                        if (_buildOptions.sceneName.Contains("ce_")) 
                        {
                            tLevel = _layersNode_CE;
                        }
                        else
                        {
                            tLevel = _layersNode_SE;
                        }

                        
                        XmlElement layerNode;

                        layerNode = _sceneXmlDoc.CreateElement(LevelNodeName);

                        layerNode.SetAttribute("place", _buildOptions.sceneName);
                        layerNode.SetAttribute("scene_folder", _buildOptions.sceneName);
                        layerNode.SetAttribute("scene_file", _buildOptions.sceneName + ".xml");
                        layerNode.SetAttribute("glints_file", GlintsFile);
                        layerNode.SetAttribute("playlist", DefaultPlaylist);
                        layerNode.SetAttribute("game_pos", DefaultGamePos);
                        layerNode.SetAttribute("gdd_name", DefaultGDDNumber + _buildOptions.sceneName + " (" + System.Environment.UserName + ")");

                        XmlElement levelResources;
                        levelResources = _sceneXmlDoc.CreateElement(LevelNodeResource);

                        levelResources.AppendChild(AddResource(LevelNodeResource_common));
                        levelResources.AppendChild(AddResource(LevelNodeResource_sub));
                        levelResources.AppendChild(AddResource("data\\scenes\\" + _buildOptions.sceneName + "\\resources.xml"));

                        if (_buildOptions.morfing)
                        {
                            levelResources.AppendChild(AddResource(LevelNodeResource_morfing));
                        }

                        layerNode.AppendChild(levelResources);
                        AddMinigame(_buildOptions.sceneName, layerNode);

                        if (!FoundParentAttribute("place", _buildOptions.sceneName, tLevel))
                        {
                            tLevel.AppendChild(layerNode);
                        }
                    }
                }
            }
            
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка на " + fn.FullFileName);

                throw ex;
            }
        }

        public void Save()
        {
            _sceneXmlDoc.Save(_xmlFileName);
        }

    }
}
