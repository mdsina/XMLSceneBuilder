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
        private static string HoItemsNodeName = "items_file";

        private XmlNode _node;
        
		public string Name;

		public SceneInfo MainScene;

		public List<SceneInfo> AllSubscreens;

        public StringCollection ResourcesFilePaths;

		public List<string> MiniGameNames;

		public List<SceneInfo> Subscreens
		{
			get { return MainScene.ChildScenes; }
		}

        public bool IsHiddenObject
        {
            get
            {
                if (_node.Attributes[HoItemsNodeName] != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

		public Location(XmlNode node)
		{
			_node = node;

			AllSubscreens = new List<SceneInfo>();

            ResourcesFilePaths = new StringCollection();

			MiniGameNames = new List<string>();
            
            Name = node.Attributes["place"].Value;
            
            XmlNode resNode = node.SelectSingleNode("resources");

            if (resNode != null)
            {
                LoadResourcesFiles(resNode);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("resNode = null");
            }
			MainScene = new SceneInfo(Name, node);
			MainScene.OwnerLocation = this;

			XmlNode subscreensNode = node.SelectSingleNode("subscreens");

			if (subscreensNode != null)
			{
				foreach (XmlNode subscreenNode in subscreensNode)
				{
                    if (subscreenNode.NodeType != XmlNodeType.Comment)
                    {
                        SceneInfo newSubscreen = new SceneInfo(subscreenNode.Name, subscreenNode);
                        newSubscreen.OwnerLocation = this;

                        MainScene.ChildScenes.Add(newSubscreen);

                        AllSubscreens.Add(newSubscreen);

                        foreach (XmlNode subsubscreenNode in subscreenNode)
                        {
                            SceneInfo newSubSubscreen = new SceneInfo(subsubscreenNode.Name, subsubscreenNode);
                            newSubSubscreen.OwnerLocation = this;
                            newSubscreen.ChildScenes.Add(newSubSubscreen);

                            AllSubscreens.Add(newSubSubscreen);
                        }
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
            ResourcesFilePaths.Clear();
           
            foreach(XmlNode node in resNode)
            {
                if (node.NodeType != XmlNodeType.Comment)
                {
                    ResourcesFilePaths.Add(node.Attributes["file_name"].Value);
                }
            }
        }
	}
		
}
