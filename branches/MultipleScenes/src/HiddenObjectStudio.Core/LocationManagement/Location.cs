using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace HiddenObjectStudio.Core.LocationManagement
{
	public class Location 
	{
        private static string PlaceAttributeName = "place";
        private static string GddNameFileAttributeName = "gdd_name";
        private static string GamePositionAttributeName = "game_pos";
        private static string PlaylistAttributeName = "playlist";

        public XmlElement _node;
        
		public string Name;

        public List<SceneInfo> AllScenes;

        public List<SceneInfo> AllSubscreens;

        public List<string> CommonResourcesFilePaths;

        public List<string> AllResourcesFilePaths;

		public List<string> MiniGameNames;

        public bool HasResNodes = false;

        public bool IsHiddenObject
        {
            get
            {
                bool hidden = false;
                foreach (SceneInfo scene in this.AllScenes)
                {
                    if (scene.IsHiddenObject)
                    {
                        hidden = true;
                    }
                }

                return hidden;
            }
        }

        public string PlaceName
        {
            get
            {
                return _node.GetAttribute(PlaceAttributeName);
            }

            set
            {
                _node.SetAttribute(PlaceAttributeName, value);
            }
        }

        public string GddName
        {
            get
            {
                return _node.GetAttribute(GddNameFileAttributeName);
            }

            set
            {
                _node.SetAttribute(GddNameFileAttributeName, value);
            }
        }

        public string GamePosition
        {
            get
            {
                string defaultValue = string.Empty;
                if (_node.Attributes[GamePositionAttributeName] != null)
                {
                    return _node.GetAttribute(GamePositionAttributeName);
                }
                else
                {
                    return defaultValue;
                }
            }

            set
            {
                _node.SetAttribute(GamePositionAttributeName, value);
            }
        }


        public string PlaylistName
        {
            get
            {
                return _node.GetAttribute(PlaylistAttributeName);
            }

            set
            {
                _node.SetAttribute(PlaylistAttributeName, value);
            }
        }

        public Location(XmlElement node)
		{
			_node = node;

			CommonResourcesFilePaths = new List<string>();

            AllResourcesFilePaths = new List<string>();
            AllScenes = new List<SceneInfo>();
            AllSubscreens = new List<SceneInfo>();

			MiniGameNames = new List<string>();
            
            Name = node.Attributes["place"].Value;

            XmlNode resNode = node.SelectSingleNode("common_resources");

            if (resNode != null)
            {
                LoadResourcesFiles(resNode);
                HasResNodes = true;
            }

            XmlNode rootScenesNode = node.SelectSingleNode("gameplay_scenes");

            AllResourcesFilePaths.AddRange(CommonResourcesFilePaths);

            if (rootScenesNode != null)
			{
                foreach (XmlNode scenesNode in rootScenesNode)
				{
                    if (scenesNode.NodeType != XmlNodeType.Comment)
                    {
                        SceneInfo newScene = new SceneInfo(scenesNode, this);
                        newScene.OwnerLocation = this;

                        AllScenes.Add(newScene);
                        AllSubscreens.AddRange(newScene.AllSubscreens);
                        AllResourcesFilePaths.AddRange(newScene.ResourcesFilePaths);
                    }
				}
			}
            	

			XmlNode miniGamesNode = node.SelectSingleNode("mini_games");

			if (miniGamesNode != null && miniGamesNode.NodeType != XmlNodeType.Comment)
			{
				foreach (XmlNode miniGameNode in miniGamesNode)
				{
					MiniGameNames.Add(miniGameNode.Name);
				}
			}
		}

		private void LoadResourcesFiles(XmlNode resNode)
        {
            CommonResourcesFilePaths.Clear();
           
            foreach(XmlNode node in resNode)
            {
                if (node.NodeType != XmlNodeType.Comment)
                {
                    CommonResourcesFilePaths.Add(node.Attributes["file_name"].Value);
                }
            }
        }
	}
		
}
