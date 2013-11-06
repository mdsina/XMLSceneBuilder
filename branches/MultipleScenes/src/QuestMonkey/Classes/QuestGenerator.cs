using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using HiddenObjectStudio.Core;
using System.Windows.Forms;
using HiddenObjectStudio.Core.SceneManagement;
using HiddenObjectStudio.Core.LocationManagement;
using HiddenObjectStudio.Core.InventoriesManagement;

namespace QuestMonkey
{
	class QuestGenerator
	{
		private QuestsManger _questFile;
		private GlintManager _glintManager;
		private TextBox _logTextBox;
		private LocationManager _locationManager;
		private Inventories _inventory;

		private Config Config;


		private int _generatedQuestsCount;

		private StringBuilder _completeReport;

		public QuestGenerator(LocationManager scenesManager, QuestsManger questFile, GlintManager glintManager, Inventories inventory, TextBox textBox)
		{
			Config = new Config();

			_questFile = questFile;
			_logTextBox = textBox;
			_locationManager = scenesManager;
			_inventory = inventory;
			_glintManager = glintManager;

			_generatedQuestsCount = 0;
		}

		public void Generate()
		{
			_completeReport = new StringBuilder();
			foreach (Location location in _locationManager.Locations)
			{
                ParseScene(location.AllScenes[0]);

				foreach (SceneInfo subscreen in location.AllSubscreens)
				{
					ParseScene(subscreen);
				}
			}

			_completeReport.Append("Generated quests :" + _generatedQuestsCount);

			_logTextBox.Text = _completeReport.ToString();
		}

		public void ParseScene(SceneInfo sceneInfo)
		{
			Scene scene = new Scene();

			scene.LoadFromXml(Path.Combine(Config.ScenesPath, sceneInfo.SceneFilePath));

			foreach (string scriptFileName in scene.ScriptFiles)
			{
				string scriptFullFileName = Path.Combine(Path.Combine(Config.ScenesPath, sceneInfo.FolderName), scriptFileName);

				if (!File.Exists(scriptFullFileName)) continue;

				ParseScriptFile(scriptFullFileName, sceneInfo);
			}

			foreach (IntentoryItem item in _inventory.IntentoryItems)
			{
				if (FindLayer(scene.Layers, item.Name))
				{
					CreateCollectItemQuest(sceneInfo, item.Name);
				}
			}
		}

		private bool FindLayer(Layers layers, string layerName)
		{
			foreach (Layer layer in layers)
			{
				if (layer.Name == layerName)
				{
					return true;
				}
				else
				{
					if (layer.ChildLayers.Count > 0)
					{
						return FindLayer(layer.ChildLayers, layerName);
					}
				}
			}

			return false;

		}

		public void ParseScriptFile( string fileName, SceneInfo sceneInfo)
		{
			_completeReport.Append("Parsing file " + fileName + "..." + Environment.NewLine);

			StreamReader stream = File.OpenText(fileName);

			while (!stream.EndOfStream)
			{
				string line = stream.ReadLine();

				line.Trim();
				line.ToLower();

				if (line.StartsWith("function"))
				{
					string[] tmp = line.Split(' ');
					string functionName = ExtractFunctionName(tmp[1]);

					if (functionName.Contains("ON_CLICK_"))
					{
						CreateClickQuest(functionName, sceneInfo);
					}
					else if (functionName.Contains("ON_USE_"))
					{
						CreateApplyItemQuest(functionName, sceneInfo);
					}
				}
			}
		}
		
		private void CreateClickQuest(string functionName, SceneInfo scene)
		{
			string fullLayerName = functionName.Replace("ON_CLICK_", "");

			string slashedFullLayerName = fullLayerName.Replace("___", "/");

			string questName = "click_on_" + fullLayerName;

		
			Quest quest = _questFile.GetQuest(questName);

			if (quest == null)
			{
				_completeReport.Append("	.... adding quest " + questName + Environment.NewLine);

				Quest newQuest = _questFile.AddQuest(questName, scene);
				newQuest.IsGeneratedDraft = true;


				newQuest.SetAttribute("type", "click");
				newQuest.SetAttribute("click_layer", slashedFullLayerName);


				_glintManager.AddGlintToScene(questName, slashedFullLayerName, scene);

				_generatedQuestsCount++;
			}
		}

		private void CreateApplyItemQuest(string functionName, SceneInfo scene)
		{
			functionName = functionName.Replace("ON_USE_", "");
			functionName = functionName.Replace("_ON_", "@");

			string[] tmp = functionName.Split('@');

			string itemName = tmp[0];
			string dropZoneName = tmp[1];

			string dzNameWithoutDropZone = dropZoneName.Replace("drop_zone_", "");
			string questName = "use_" + itemName + "_on_" + dzNameWithoutDropZone;

			Quest quest = _questFile.GetQuest(questName);

			if (quest == null)
			{
				_completeReport.Append("	.... adding quest " + questName + Environment.NewLine);

				Quest newQuest = _questFile.AddQuest(questName, scene);
				newQuest.IsGeneratedDraft = true;

				newQuest.SetAttribute("type", "apply_item");
				newQuest.SetAttribute("inventory_item", itemName);
				newQuest.SetAttribute("drop_zone", dropZoneName);

				_glintManager.AddGlintToScene(questName, dropZoneName, scene);

				_generatedQuestsCount++;
			}
		}

		private void CreateCollectItemQuest(SceneInfo scene, string itemName)
		{
			string questNodeName = "collect_" + itemName;

			Quest quest = _questFile.GetQuest(questNodeName);

			if (quest == null)
			{
				_completeReport.Append("	.... adding quest " + questNodeName + Environment.NewLine);

				Quest newQuest = _questFile.AddQuest(questNodeName, scene);
				newQuest.IsGeneratedDraft = true;

				newQuest.SetAttribute("type", "inventory_item");
				newQuest.SetAttribute("inventory_item", itemName);

				_glintManager.AddGlintToScene(questNodeName, itemName, scene);

				_generatedQuestsCount++;
			}
		}

// 		private XmlNode GetFolderNode(string folderName)
// 		{
// 			XmlNode folderNode = _root.SelectSingleNode(folderName);
// 
// 			if (folderNode == null)
// 			{
// 				folderNode = Doc.CreateElement(folderName);
// 				_root.AppendChild(folderNode);
// 			}
// 
// 			return folderNode;
// 		}

		private string ExtractFunctionName(string input)
		{
			string[] tmp = input.Split('(');

			return tmp[0];
		}

		
			 
	}
}
