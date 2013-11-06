using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.Collections.Specialized;

namespace HiddenObjectStudio.Core.LocationManagement
{
	public class SceneInfo
	{
        private static string FolderAttributeName = "scene_folder";
        private static string FileAttributeName = "scene_file";
        private static string GlintsFileAttributeName = "glints_file";

        private static string HoItemsNodeName = "items_file";
        private static string HoHintsNodeName = "hints_file";

        public List<SceneInfo> AllSubscreens;

        public List<string> ResourcesFilePaths;
        
		private XmlElement _node;

        public bool HasResNodes = false;

		public string Name { get; set; }

		public Location OwnerLocation;

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


        public string ItemsName
        {
            get
            {
                return _node.GetAttribute(HoItemsNodeName);
            }

            set
            {
                _node.SetAttribute(HoItemsNodeName, value);
            }
        }

        public string HintsName
        {
            get
            {
                return _node.GetAttribute(HoHintsNodeName);
            }

            set
            {
                _node.SetAttribute(HoHintsNodeName, value);
            }
        }

        public string SceneFilePath
        {
            get
            {
                return FolderName + "\\" + FileName;
            }
        }
            
        public List<SceneInfo> ChildScenes;

		public SceneInfo(XmlNode node, Location ownerLocation)
		{
            if (node.NodeType != XmlNodeType.Comment)
            {
                _node = (XmlElement)node;

                Name = node.Name; 

                OwnerLocation = ownerLocation;

                ChildScenes = new List<SceneInfo>();

                AllSubscreens = new List<SceneInfo>();

                ResourcesFilePaths = new List<string>();

                XmlNode resNode = node.SelectSingleNode("resources");

                if (resNode != null)
                {
                    LoadResourcesFiles(resNode);
                    HasResNodes = true;
                }

                XmlNode subscreensNode = node.SelectSingleNode("subscreens");

                if (subscreensNode != null)
                {
                    foreach (XmlNode subscreenNode in subscreensNode)
                    {
                        if (subscreenNode.NodeType != XmlNodeType.Comment)
                        {
                            SceneInfo newSubscreen = new SceneInfo(subscreenNode, OwnerLocation);

                            //newSubscreen.OwnerLocation = this;

                            AllSubscreens.Add(newSubscreen);

                            XmlNode subSubscreensNode = subscreensNode.SelectSingleNode("subscreens");
                            if (subSubscreensNode != null)
                            {
                                foreach (XmlNode subsubscreenNode in subSubscreensNode)
                                {
                                    SceneInfo newSubSubscreen = new SceneInfo(subsubscreenNode, OwnerLocation);
                                    //newSubSubscreen.OwnerLocation = this;
                                    newSubscreen.ChildScenes.Add(newSubSubscreen);

                                    AllSubscreens.Add(newSubSubscreen);
                                }
                            }
                        }
                    }
                }
            }
		}

        private void LoadResourcesFiles(XmlNode resNode)
        {
            ResourcesFilePaths.Clear();

            foreach (XmlNode node in resNode)
            {
                if (node.NodeType != XmlNodeType.Comment)
                {
                    ResourcesFilePaths.Add(node.Attributes["file_name"].Value);
                }
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
