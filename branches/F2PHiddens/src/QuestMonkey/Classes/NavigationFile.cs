using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Collections.Specialized;
using HiddenObjectStudio.Core.LocationManagement;

namespace QuestMonkey.Classes
{
	public class Transition
	{
		private XmlElement _node;

		public string DstSceneName
		{
			get 
			{
				return _node.Name;
			}
		}

		public string LayerName
		{
			get
			{
				return _node.GetAttribute("layer_name");
			}
		}

		public StringCollection lockingQuests;

		public Transition(XmlNode xmlNode)
		{
			_node = (XmlElement)xmlNode;

		}
	}

	public class NavigationManager
	{
		private XmlDocument _doc;
		private XmlNode _root;
		private string _fileName;
		private DateTime _lastWriteTime;

		public NavigationManager(string fileName)
		{
			_doc = new XmlDocument();

			Load(fileName);

		}

		public XmlNode AddLocationNode(SceneInfo scene)
		{
			XmlNode newLocationXmlNode = _doc.CreateElement(scene.Name);

			_root.AppendChild(newLocationXmlNode);

			return newLocationXmlNode;

			//AllLocationsNodes.Add(newLocationXmlNode);
		}

		public XmlNode GetLocationNode(SceneInfo scene)
		{
			return _root.SelectSingleNode(scene.Name);
		}

		public List<Quest> GetQuestsOnScene(SceneInfo scene)
		{
			XmlNode sceneNode = GetLocationNode(scene);

			List<Quest> quests = new List<Quest>();

			if (sceneNode != null)
			{
				foreach (XmlNode questNode in sceneNode)
				{
					if (questNode.NodeType != XmlNodeType.Comment)
					{
						quests.Add(new Quest(questNode));
					}
				}
			}

			return quests;
		}

		public void Load(string fileName)
		{
			_fileName = fileName;

			_doc.Load(_fileName);
			_root = _doc.SelectSingleNode("navigation");

			//treeView.Nodes.Clear();

			// 			if (_root != null)
			// 			{
			// 				foreach (XmlNode locationNode in _root.ChildNodes)
			// 				{
			// 					SceneInfo scene = _locationManager.FindSceneOrSubscreenByName(locationNode.Name);
			// 
			// 					if (scene != null)
			// 					{
			// 						scene.Quests.Clear();
			// 
			// 						foreach (XmlNode questNode in locationNode.ChildNodes)
			// 						{
			// 							Quest newQuest = new Quest(questNode);
			// 
			// 							scene.Quests.Add(newQuest);
			// 						}
			// 					}
			// 					else
			// 					{
			// 						MessageBox.Show("Quests.xml содержит локаци, которой нет в levels.xml (" + locationNode.Name + ")!");
			// 					}
			// 				}
			// 			}

			FileInfo fi = new FileInfo(_fileName);
			_lastWriteTime = fi.LastWriteTimeUtc;
		}

		public void Save()
		{
			_doc.Save(_fileName);

			FileInfo fi = new FileInfo(_fileName);
			_lastWriteTime = fi.LastWriteTimeUtc;
		}

		public bool IsFileChanged()
		{
			if (!string.IsNullOrEmpty(_fileName))
			{
				FileInfo fi = new FileInfo(_fileName);

				return fi.LastWriteTimeUtc > _lastWriteTime;

			}

			return false;
		}
	}
}
