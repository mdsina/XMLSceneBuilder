using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace HiddenObjectStudio.Core.LocationManagement
{
	public class SceneInfo
	{
        private static string PlaceAttributeName = "place";
		private static string FolderAttributeName = "scene_folder";
		private static string FileAttributeName = "scene_file";
		private static string GlintsFileAttributeName = "glints_file";
        private static string GddNameFileAttributeName = "gdd_name";
        private static string GamePositionAttributeName = "game_pos";
        
		private XmlElement _node;

		public string Name { get; set;}

		public Location OwnerLocation;

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

		public string FolderName
		{
			get 
			{
				return _node.GetAttribute(FolderAttributeName);
			}

			set
			{
				_node.SetAttribute(FolderAttributeName, value);
			}
		}

		public string FileName 
		{
			get
			{
				return _node.GetAttribute(FileAttributeName);
			}

			set
			{
				_node.SetAttribute(FileAttributeName, value);
			}
		}

		public string GlintsFileName
		{
			get
			{
				return _node.GetAttribute(GlintsFileAttributeName);
			}

			set
			{
				_node.SetAttribute(GlintsFileAttributeName, value);
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

		public List<SceneInfo> ChildScenes;

		public string SceneFilePath
		{
			get 
			{
				return FolderName + "\\" + FileName;
			}
		}

		public SceneInfo(string name, XmlNode node)
		{
            if (node.NodeType != XmlNodeType.Comment)
            {
                _node = (XmlElement)node;

                Name = name;
                
                ChildScenes = new List<SceneInfo>();
            }
		}

		public void AttachToTreeNode(TreeNodeCollection treeNodes, TreeNode treeNode)
		{
            treeNode.Name = Name;
            treeNode.Text = Name;
            treeNode.Tag = this;

            treeNodes.Add(treeNode);

			foreach (SceneInfo subscene in ChildScenes)
			{
				TreeNode subsceneTreeNode = new TreeNode();

				subscene.AttachToTreeNode(treeNode.Nodes, subsceneTreeNode);
			}
		}

		public SceneInfo GetChildScene(string sceneName)
		{
			foreach(SceneInfo subscene in ChildScenes)
			{
				if (subscene.Name == sceneName)
				{
					return subscene;
				}
			}

			return null;
		}

		public SceneInfo GetChildSceneByFolderName(string folderName)
		{
			foreach (SceneInfo subscene in ChildScenes)
			{
				if (subscene.FolderName == folderName)
				{
					return subscene;
				}
			}

			return null;
		}

// 		public Quest GetQuest(string questName)
// 		{
// 			foreach (Quest quest in Quests)
// 			{
// 				if (quest.Name == questName)
// 				{
// 					return quest;
// 				}
// 			}
// 
// 			return null;
// 		}
	}
}
