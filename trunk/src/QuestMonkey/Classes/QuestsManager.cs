using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using HiddenObjectStudio.Core.LocationManagement;

namespace QuestMonkey
{
	public class QuestsManger
	{
		private XmlDocument _doc;
		private XmlNode _root;
		private string _fileName;
		private DateTime _lastWriteTime;


		public QuestsManger(string questName)
		{
			_doc = new XmlDocument();

			Load(questName);
			//Quests = new List<Quest>();

			//AllQuestNodes = new List<XmlNode>();
			//AllLocationsNodes = new List<XmlNode>();
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

		public Quest AddQuest(string name, SceneInfo scene)
		{
			XmlNode locationNode = GetLocationNode(scene);

			if (locationNode == null)
			{
				locationNode = AddLocationNode(scene);
			}

			XmlElement questNode = _doc.CreateElement(name);
			questNode.SetAttribute("type", "");

			locationNode.AppendChild(questNode);


			//string glintName = _glintsManager.AddGlintToScene(name, scene);

			questNode.SetAttribute("glints", "");

			Quest newQuest = new Quest(questNode);

			return newQuest;
		}

		public Quest GetQuest(string questName)
		{
			foreach (XmlNode locationNode in _root)
			{
				foreach (XmlNode questNode in locationNode)
				{
					if (questNode.Name == questName)
					{
						return new Quest(questNode);
					}
				}
			}

			return null;

		}

		public List<string> GetAllQuests()
		{
			List<string> allQuests = new List<string>();

			foreach(XmlNode locationNode in _root)
			{
				foreach (XmlNode questNode in locationNode)
				{
					if (questNode.NodeType != XmlNodeType.Comment)
					{
						allQuests.Add(questNode.Name);
					}
					
				}
			}

			return allQuests;
		}


		public void RemoveQuestNode(string name, SceneInfo scene)
		{
			XmlNode locationNode = GetLocationNode(scene);

			XmlNode questNode = locationNode.SelectSingleNode(name);

			locationNode.RemoveChild(questNode);
					
		}

		public void Load(string fileName)
		{
			_fileName = fileName; 
			
			_doc.Load(_fileName);
			_root = _doc.SelectSingleNode("quests");

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
