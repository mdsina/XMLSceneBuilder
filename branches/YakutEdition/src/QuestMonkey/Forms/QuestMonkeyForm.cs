using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Diagnostics;
using HiddenObjectStudio.Core;
using HiddenObjectStudio.Core.SceneManagement;
using HiddenObjectStudio.Core.LocationManagement;
using HiddenObjectStudio.Core.InventoriesManagement;


namespace QuestMonkey
{
	internal partial class QuestMonkeyForm : Form
	{
		private Config Config;
		private string LevelsFileName; 
		private QuestsManger _questsManager;
		private GlintManager _glintManager;
		private LocationManager _locationManager;
		private Inventories _inventory;

		//private List<string> _inventory;

		private bool _isAllowToSetModifiedFlag;
		private bool _isModified;
		private bool _isFileModified;

		private bool _isReloadOperationCompleted;

		private bool IsFileModified
		{
			set 
			{
				if (_isAllowToSetModifiedFlag)
				{
					if (value)
					{
						this.Text = "Quest Monkey [Unsaved *]";
					}
					else
					{
						this.Text = "Quest Monkey";
					}

					_isFileModified = value;
				}

			}

			get
			{
				return _isFileModified;
			}

		}

		private List<TreeNode> _findResults;
		private int _prevFindPos;
		private string _prevSearchString;

		private bool IsModified
		{
			set
			{
				_isModified = value;

				if (value)
				{
					IsFileModified = true;
				}

				listViewQuestOnScene.Enabled = !value;
				treeViewPlaces.Enabled = !value;

				buttonSave.Enabled = _isModified;
			}

			get { return _isModified; }
		}

		private SceneInfo SelectedScene
		{
			get
			{
				if (treeViewPlaces.SelectedNode != null)
				{
					return (SceneInfo)treeViewPlaces.SelectedNode.Tag;
				}

				return null;
			}
		}


		/////////////////////////////////////////////////////////////////////////////////////////////////////////
		public QuestMonkeyForm()
		{
			Config = new Config();
			//bool a =  Config.Is

			LevelsFileName = Config.LevelsPath + "\\levels.xml";

			Config.BookmarksPath = Config.BinPath + "\\bookmarks.xml"; 

			InitializeComponent();

			_findResults = new List<TreeNode>();

            _inventory = new Inventories(Config.InventoryPath + "\\inventory.xml");
			//_inventory.LoadInventoriesXMl(Config.InventoryPath + "\\inventory.xml");

			IsModified = false;
		}

		private void OpenFile(string fileName)
		{
			_locationManager = new LocationManager(LevelsFileName);

			_questsManager = new QuestsManger(fileName);

			_glintManager = new GlintManager();
			_glintManager.Load(_locationManager);

			//_questsFile.Load(fileName);

			
			FillLocationsTree();

			FillDepQuestsCombo();

			FillAllLocationsCombo();

			// 			comboBoxAfterHidden.DataSource = _quests.AllLocationsNodes;
			// 			comboBoxAfterHidden.DisplayMember = "Name";

			

			IsFileModified = false;

			LoadBookmarks();

			IsModified = false;

			_isReloadOperationCompleted = true;
			_isAllowToSetModifiedFlag = true;

			UpdateStatusStrip("Opened '" + fileName + "'");
		}

		private void FillLocationsTree()
		{
			treeViewPlaces.Nodes.Clear();

			foreach (Location place in _locationManager.Locations)
			{
				TreeNode placeTreeNode = new TreeNode();
				place.MainScene.AttachToTreeNode(treeViewPlaces.Nodes, placeTreeNode);
			}

			treeViewPlaces.SelectedNode = treeViewPlaces.Nodes[0];

		}

		private void SaveBookmarks()
		{
// 			XmlDocument book = new XmlDocument();
// 			book.Load(BookmarksPath);
// 
// 			_bookmarksRoot = book.SelectSingleNode("bookmarks");
// 
// 			_bookmarksRoot.RemoveAll();
// 
// 			foreach (object item in listBoxBookmarks.Items)
// 			{
// 				XmlNode bNode = book.CreateElement(item.ToString());
// 				_bookmarksRoot.AppendChild(bNode);
// 			}
// 
// 			book.Save(BookmarksPath);
		}

		private void LoadBookmarks()
		{
// 			XmlDocument book = new XmlDocument();
// 			book.Load(BookmarksPath);
// 
// 			_bookmarksRoot = book.SelectSingleNode("bookmarks");
// 
// 
// 			listBoxBookmarks.Items.Clear();
// 
// 			foreach (XmlNode node in _bookmarksRoot.ChildNodes)
// 			{
// 				listBoxBookmarks.Items.Add(node.Name);
// 
// 			}
		}

		private void FillMiniGameNamesCombo()
		{
			Location selectedLocation = GetSelectedLocation();

            bool isFileWasModified = IsFileModified;

			if (selectedLocation != null)
			{
				comboBoxMiniGameName.DataSource = selectedLocation.MiniGameNames;
			}

            IsModified = false;

            if (!isFileWasModified)
            {
                IsFileModified = false;
            }


		}

		private void FillDepQuestsCombo()
		{
			comboBoxDependency.Items.Clear();

			foreach (string quest in _questsManager.GetAllQuests())
			{
				comboBoxDependency.Items.Add(quest);
			}
		}

		private void FillGlintsOnLocationCombo()
		{
			comboBoxAllGlintsOnLocation.Items.Clear();

			Location selectedLocation = GetSelectedLocation();

			if (selectedLocation != null)
			{
				foreach (Glint glint in _glintManager.GetAllGlintsOnLocation(selectedLocation.Name, _locationManager))
				{
					comboBoxAllGlintsOnLocation.Items.Add(glint.Name);
				}

			}
		}

		private void FillAllLocationsCombo()
		{
			comboBoxAfterHidden.Items.Clear();

			foreach (SceneInfo scene in _locationManager.AllScenes)
			{
				if (scene.Name.Contains("_ho"))
				{
					comboBoxAfterHidden.Items.Add(scene.Name);
				}
				
			}
		}

		private void FillQuestsOnSelectedSceneList()
		{
			if (SelectedScene != null)
			{
				listViewQuestOnScene.Items.Clear();

				foreach (Quest quest in _questsManager.GetQuestsOnScene(SelectedScene))
				{
					ListViewItem lvi = new ListViewItem(quest.Name);
					lvi.Tag = quest;
					if (quest.IsGeneratedDraft)
					{
						lvi.BackColor = Color.LightGoldenrodYellow;
						lvi.ForeColor = Color.Red;
					}
					listViewQuestOnScene.Items.Add(lvi);
				}

				if (listViewQuestOnScene.Items.Count > 0)
				{
					listViewQuestOnScene.Items[0].Selected = true;
					splitContainerQuestProps.Show();
				}
				else
				{
					splitContainerQuestProps.Hide();
				}
			}
			else
			{
				splitContainerQuestProps.Hide();
			}

			// 			XmlNode questNode = (XmlNode)e.Node.Tag;
			// 
			// 			if (e.Node.Parent != null)
			// 			{
			// 				LoadQuestFormDataFromXmlNode(questNode);
			// 				panelQuestProps.Show();
			// 
			// 				IsModified = false;
			// 			}
			// 			else
			// 			{
			// 				panelQuestProps.Hide();
			// 			}
		}

		private void FillGlintsOnSelectedScene()
		{
			if (SelectedScene != null)
			{
				listViewGlintsOnScene.Items.Clear();

				SceneGlints sceneGlints = _glintManager.GetSceneGlints(SelectedScene);

				if (sceneGlints != null)
				{
					foreach (Glint glint in sceneGlints.GetAllGlints())
					{
						ListViewItem lvi = new ListViewItem(glint.Name);
						lvi.SubItems.Add(glint.LayerName);
						lvi.Tag = glint;


						listViewGlintsOnScene.Items.Add(lvi);
					}

					if (listViewGlintsOnScene.Items.Count > 0)
					{
						listViewGlintsOnScene.Items[0].Selected = true;
					}
				}

			}
		}

		private Quest GetSelectedQuest()
		{
			if (listViewQuestOnScene.SelectedItems != null && listViewQuestOnScene.SelectedItems.Count > 0)
			{
				return (Quest)listViewQuestOnScene.SelectedItems[0].Tag;
			}

			return null;
		}

		private Glint GetSelectedGlint()
		{
			if (listViewGlintsOnScene.SelectedItems.Count > 0)
			{
				return (Glint)listViewGlintsOnScene.SelectedItems[0].Tag;
			}

			return null;
		}

		private Location GetSelectedLocation()
		{
			if (treeViewPlaces.SelectedNode != null)
			{
				SceneInfo sceneInfo = (SceneInfo)treeViewPlaces.SelectedNode.Tag;
				return sceneInfo.OwnerLocation;
			}

			return null;
			
		}

		private void LoadQuestFormDataFromXmlNode(Quest quest)
		{
			XmlNode questNode = quest.Node;

			if (questNode != null && questNode.Attributes != null && questNode.Attributes["type"] != null)
			{
				_isAllowToSetModifiedFlag = false;

				string type = questNode.Attributes["type"].Value;

				if (type == string.Empty)
				{
					comboBoxType.SelectedIndex = 0;
				}
				else
				{
					comboBoxType.SelectedItem = type;
				}

				UpdateQuestType();

				checkBoxDraft.Checked = quest.IsGeneratedDraft;

				textBoxName.Text = questNode.Name;

				textBoxHighlightLayer.Text = questNode.Attributes["highlight_layer"] != null
												? questNode.Attributes["highlight_layer"].Value
												: string.Empty;

				textBoxLocation.Text = questNode.ParentNode.Name;


				if (type == "inventory_item" || type == "apply_item")
				{
					comboBoxInvItemName.Text = questNode.Attributes["inventory_item"].Value;
				}
				
				if (type == "apply_item")
				{
					comboBoxDropZone.Text = questNode.Attributes["drop_zone"].Value;
				}
				
				if (type == "inventory_item")
				{
					checkBoxAfterHo.Enabled = true;
					checkBoxAfterHo.Checked = questNode.Attributes["after_hidden_scene"] != null;

					comboBoxAfterHidden.Enabled = checkBoxAfterHo.Checked;
					comboBoxAfterHidden.Text = questNode.ParentNode.Name;
				}
				else
				{
					checkBoxAfterHo.Enabled = false;
					checkBoxAfterHo.Checked = false;

					comboBoxAfterHidden.Enabled = false;
				}

				if (type == string.Empty)
				{
					checkBoxAfterHo.Enabled = true;
					comboBoxAfterHidden.Text = string.Empty;
				}

				if (type == "condition")
				{
					textBoxCondition.Enabled = true;
					textBoxCondition.Text = questNode.Attributes["condition"].Value;
				}
				else
				{
					textBoxCondition.Enabled = false;
					textBoxCondition.Text = string.Empty;
				}

				if (type == string.Empty)
				{
					textBoxCondition.Text = string.Empty;
				}

				if (type == "dialog")
				{
					textBoxDialog.Enabled = true;
					textBoxDialog.Text = questNode.Attributes["dialog"].Value;
				}
				else
				{
					textBoxDialog.Enabled = false;
					textBoxDialog.Text = string.Empty;
				}

				if (type == "click")
				{
					comboBoxClickOnLayer.Text = questNode.Attributes["click_layer"].Value;
				}
				else
				{
					comboBoxClickOnLayer.Text = string.Empty;
				}

				if (type == "complete_mini_game")
				{
					comboBoxMiniGameName.Text = questNode.Attributes["mini_game_name"].Value;
				}
				else
				{
					comboBoxMiniGameName.Text = string.Empty;
				}

				if (type == string.Empty)
				{
					textBoxDialog.Text = string.Empty;
				}

				textBoxPriority.Text = questNode.Attributes["priority"] != null
												? questNode.Attributes["priority"].Value
												: string.Empty;

				LoadDependencies(questNode);

				listBoxQuestGlints.Items.Clear();

				if (questNode.Attributes["glints"] != null && !string.IsNullOrEmpty(questNode.Attributes["glints"].Value))
				{
					string[] parts = questNode.Attributes["glints"].Value.Split('|');

					if (parts.Length > 0)
					{
						foreach (string glintName in parts)
						{
							if (glintName != string.Empty)
							{
								listBoxQuestGlints.Items.Add(glintName);
							}
							
						}
					}
				}


				IsModified = false;

				_isAllowToSetModifiedFlag = true;

			}
		}

		private void SaveQuestFormDataToXmlNode(Quest quest)
		{
			string type = comboBoxType.Text;

			XmlElement questNode = (XmlElement)quest.Node;

			questNode.SetAttribute("type", type);

			((XmlElement)questNode).SetAttribute("generated_draft", checkBoxDraft.Checked ? "1" : "0");

			questNode.SetAttribute("highlight_layer", textBoxHighlightLayer.Text);

			if (type == "inventory_item" || type == "apply_item")
			{
				questNode.SetAttribute("inventory_item", comboBoxInvItemName.Text);
			}

			if (type == "apply_item")
			{
				questNode.SetAttribute("drop_zone", comboBoxDropZone.Text);
			}

			if (type == "inventory_item")
			{
				if (checkBoxAfterHo.Checked)
				{
					questNode.SetAttribute("after_hidden_scene", comboBoxAfterHidden.Text);
				}
			}

			if (type == "condition")
			{
				questNode.SetAttribute("condition", textBoxCondition.Text);
			}

			if (type == "dialog")
			{
				questNode.SetAttribute("dialog", textBoxDialog.Text);
			}

			if (type == "click")
			{
				questNode.SetAttribute("click_layer", comboBoxClickOnLayer.Text);
			}

			if (type == "complete_mini_game")
			{
				questNode.SetAttribute("mini_game_name", comboBoxMiniGameName.Text);
			}

			SaveDependencies(questNode);

			string glints = "";

			foreach (object item in listBoxQuestGlints.Items)
			{
				glints += item.ToString() + "|";
			}
			if (glints.Length > 0)
			{
				int l = glints.Length - 1;
				glints = glints.Remove(l);
			}

			questNode.SetAttribute("glints", glints);

			IsModified = false;
		}

		private void SaveDependencies(XmlNode questNode)
		{
			XmlNode depNode = questNode.SelectSingleNode("dependency");

			if (listBoxDependencies.Items.Count > 0)
			{
				if (depNode == null)
				{
					depNode = questNode.OwnerDocument.CreateElement("dependency");

					questNode.AppendChild(depNode);
				}
				else
				{
					depNode.RemoveAll();
				}

				foreach (object dependencyName in listBoxDependencies.Items)
				{
					XmlElement dependencyNode = questNode.OwnerDocument.CreateElement(dependencyName.ToString());
					depNode.AppendChild(dependencyNode);
				}
			}
			else
			{
				if (depNode != null)
				{
					questNode.RemoveChild(depNode);
				}
				
			}

		}

		private void LoadDependencies(XmlNode questNode)
		{
			XmlNode depNode = questNode.SelectSingleNode("dependency");

			listBoxDependencies.Items.Clear();

			if (depNode != null)
			{
				foreach (XmlNode dependencyNode in depNode.ChildNodes)
				{
					listBoxDependencies.Items.Add(dependencyNode.Name);
				}
			}

		}

		private void UpdateQuestType()
		{
			IsModified = true;

			string type = comboBoxType.Text;

			comboBoxInvItemName.Enabled = type == "inventory_item" || type == "apply_item";
			if (type == "inventory_item" || type == "apply_item")
			{
				comboBoxInvItemName.Show();
				labelItemName.Show();
			}
			else
			{
				comboBoxInvItemName.Hide();
				labelItemName.Hide();
			}


			if (type == "apply_item")
			{
				comboBoxDropZone.Enabled = true;
				comboBoxDropZone.Show();

				buttonChooseDropZone.Show(); 

				labelDropZone.Show();

			}
			else
			{
				comboBoxDropZone.Enabled = false;
				comboBoxDropZone.Hide();

				buttonChooseDropZone.Hide(); 

				labelDropZone.Hide();
			}


			if (type == "inventory_item")
			{
				checkBoxAfterHo.Enabled = true;
				checkBoxAfterHo.Show();
				comboBoxAfterHidden.Show();
				comboBoxAfterHidden.Enabled = checkBoxAfterHo.Checked;

				
			}
			else
			{
				checkBoxAfterHo.Enabled = false;
				checkBoxAfterHo.Hide();
				comboBoxAfterHidden.Hide();
				checkBoxAfterHo.Checked = false;

				comboBoxAfterHidden.Enabled = false;
			}

			if (type == "condition")
			{
				textBoxCondition.Enabled = true;
				textBoxCondition.Show();

				labelCondition.Show();
			}
			else
			{
				textBoxCondition.Enabled = false;
				textBoxCondition.Hide();

				labelCondition.Hide();
			}

			if (type == "dialog")
			{
				textBoxDialog.Enabled = true;
				textBoxDialog.Show();
				labelDialog.Show();
			}
			else
			{
				textBoxDialog.Enabled = false;
				textBoxDialog.Hide();
				labelDialog.Hide();
			}

			if (type == "click")
			{
				comboBoxClickOnLayer.Show();
				labelClickLayer.Show();

				buttonChooseClickLayer.Show();
			}
			else
			{
				comboBoxClickOnLayer.Hide();
				labelClickLayer.Hide();

				buttonChooseClickLayer.Hide();
			}

			if (type == "complete_mini_game")
			{
				labelMiniGameName.Show();

				comboBoxMiniGameName.Show();
			}
			else
			{
				labelMiniGameName.Hide();

				comboBoxMiniGameName.Hide();

			}

		}

		private bool SelectQuestInListView(string questName)
		{
			foreach (ListViewItem lvi in listViewQuestOnScene.Items)
			{
				Quest quest = (Quest)lvi.Tag;

				if (quest.Name == questName)
				{
					lvi.Selected = true;

					return true;
				}
			}

			return false;
		}

		private void FindAndSelectQuest(string questName)
		{
			foreach (TreeNode locationNode in treeViewPlaces.Nodes)
			{
				SceneInfo scene = (SceneInfo)locationNode.Tag;

				foreach (Quest quest in _questsManager.GetQuestsOnScene(scene))
				{
					if (quest.Name == questName)
					{
						treeViewPlaces.SelectedNode = locationNode;

						SelectQuestInListView(questName);

						return;
					}

				}

				foreach (TreeNode subscreenNode in locationNode.Nodes)
				{
					SceneInfo subscreen = (SceneInfo)subscreenNode.Tag;

					foreach (Quest quest in _questsManager.GetQuestsOnScene(subscreen))
					{
						if (quest.Name == questName)
						{
							treeViewPlaces.SelectedNode = subscreenNode;

							SelectQuestInListView(questName);

							return;
						}
					}
				}
			}
		}

		private void UpdateStatusStrip(string message)
		{
			statusStrip.Items[0].Text = message;
		}


#region General form event handlers

		private void QuestMonkeyForm_Load(object sender, EventArgs e)
		{
			comboBoxType.Items.Add("");
			comboBoxType.Items.Add("inventory_item");
			comboBoxType.Items.Add("apply_item");
			comboBoxType.Items.Add("condition");
			comboBoxType.Items.Add("dialog");
			comboBoxType.Items.Add("click");
			comboBoxType.Items.Add("complete_mini_game");



			comboBoxInvItemName.DataSource = _inventory.IntentoryItems;
			comboBoxInvItemName.DisplayMember = "Name";

			OpenFile(Config.QuestsPath + "\\quest.xml");

			UpdateStatusStrip(string.Empty);
		}

		private void QuestMonkeyForm_Activated(object sender, EventArgs e)
		{
			if (_isReloadOperationCompleted && _questsManager.IsFileChanged() )
			{
				_isReloadOperationCompleted = false;

				DialogResult res = MessageBox.Show("File 'quests.xml' has changed since last save. Reload?", "Quests", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

				if (res == DialogResult.Yes)
				{
					OpenFile(Config.QuestsPath + @"\quest.xml");
					_isReloadOperationCompleted = true;
				}
			}
			else if (_isReloadOperationCompleted && _glintManager.IsAnyFileModified())
			{
				_isReloadOperationCompleted = false;

				DialogResult res = MessageBox.Show("Some glints file has changed since last save. Reload?", "Glints", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

				if (res == DialogResult.Yes)
				{
					_glintManager.Reload(_locationManager);

					FillGlintsOnSelectedScene();
				}

				_isReloadOperationCompleted = true;
			}
			else if (_isReloadOperationCompleted && _locationManager.CheckFileForModification())
			{
				_isReloadOperationCompleted = false;

				DialogResult res = MessageBox.Show("Levels.xml file has changed since last save. Reload?", "Levels.xml", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

				if (res == DialogResult.Yes)
				{
					OpenFile(Config.QuestsPath + @"\quest.xml");

					_isReloadOperationCompleted = true;
				}

				_isReloadOperationCompleted = true;
			}
			
		}

		private void QuestMonkeyForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (IsFileModified)
			{
				DialogResult res = MessageBox.Show("Save changes before exit?", "Exit", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
				if (DialogResult.Yes == res)
				{
					if (listViewQuestOnScene.SelectedItems.Count > 0)
					{
						Quest selectedQuets = (Quest)listViewQuestOnScene.SelectedItems[0].Tag;
						
						SaveQuestFormDataToXmlNode(selectedQuets);
					}

					SaveBookmarks();
					_questsManager.Save();
					e.Cancel = false;
				}
				else if (res == DialogResult.No)
				{
					e.Cancel = false;
				}
				else
				{
					e.Cancel = true;
				}
			}

			SaveBookmarks();
		}

#endregion


#region EventHandlers

#region	Locations tree event handlers

		private void treeViewPlaces_AfterSelect(object sender, TreeViewEventArgs e)
		{
			SceneInfo scene = (SceneInfo)e.Node.Tag;

			FillQuestsOnSelectedSceneList();

			FillGlintsOnSelectedScene();

			FillGlintsOnLocationCombo();

			FillMiniGameNamesCombo();

		}

		private void openSceneFileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (SelectedScene != null)
			{
				Process pr = new Process();
				pr.StartInfo.FileName = Config.ScenesPath + "\\" + SelectedScene.SceneFilePath;
				pr.Start();
			}


		}

		private void openScriptFileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (SelectedScene != null)
			{
				

				Scene scene = new Scene();
				scene.LoadFromXml(Config.ScenesPath + "\\" + SelectedScene.SceneFilePath);

				if (scene.ScriptFiles.Count > 0)
				{
					string firstScriptFile = scene.ScriptFiles[0];

					Process pr = new Process();
					pr.StartInfo.FileName = Config.ScenesPath + "\\" + SelectedScene.FolderName + "\\" + firstScriptFile;
					pr.Start();
				}

			}
		}


#endregion

#region Quest properties event handlers

		private void buttonAddDep_Click(object sender, EventArgs e)
		{
			if (!listBoxDependencies.Items.Contains(comboBoxDependency.Text) && comboBoxDependency.Text != string.Empty)
			{
				listBoxDependencies.Items.Add(comboBoxDependency.Text);

				if (!comboBoxDependency.Items.Contains(comboBoxDependency.Text))
				{
					textBoxNewQuest.Text = comboBoxDependency.Text;
				}

				IsModified = true;
			}
		}

		private void buttonRemoveDep_Click(object sender, EventArgs e)
		{
			if (listBoxDependencies.SelectedItem != null)
			{
				listBoxDependencies.Items.Remove(listBoxDependencies.SelectedItem);
				IsModified = true;
			}
		}

		private void textBoxHighlightLayer_TextChanged(object sender, EventArgs e)
		{
			IsModified = true;
		}

		private void comboBoxAfterHidden_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (comboBoxAfterHidden.Text != string.Empty)
			{
				IsModified = true;
			}
		}

		private void comboBoxInvItemName_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (comboBoxInvItemName.Text != string.Empty)
			{ 
				IsModified = true; 
			}

		}

		private void comboBoxDropZone_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (comboBoxDropZone.Text != string.Empty)
			{
				IsModified = true;
			}

		}

		private void textBoxCondition_TextChanged(object sender, EventArgs e)
		{
			if (textBoxCondition.Enabled)
			{
				IsModified = true;
			}
		}

		private void textBoxDialog_TextChanged(object sender, EventArgs e)
		{
			if (textBoxDialog.Enabled)
			{
				IsModified = true;
			}
		}

		private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateQuestType();
		}

		private void comboBoxAfterHidden_TextUpdate(object sender, EventArgs e)
		{
			if (comboBoxAfterHidden.Enabled)
			{
				IsModified = true;
			}
		}

		private void comboBoxInvItemName_TextUpdate(object sender, EventArgs e)
		{
			IsModified = true;
		}

		private void comboBoxDropZone_TextUpdate(object sender, EventArgs e)
		{
			IsModified = true;
		}

		private void buttonCopyDepName_Click(object sender, EventArgs e)
		{
			if (listBoxDependencies.SelectedItem != null)
			{
				Clipboard.SetText(listBoxDependencies.SelectedItem.ToString());
			}
		}

		private void checkBoxAfterHo_CheckedChanged(object sender, EventArgs e)
		{
			comboBoxAfterHidden.Enabled = checkBoxAfterHo.Checked;

			IsModified = true;
		}

		private void listBoxDependencies_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (listBoxDependencies.SelectedItem != null)
			{
				FindAndSelectQuest(listBoxDependencies.SelectedItem.ToString());
			}
		}

		private void buttonAddGlintToQuest_Click(object sender, EventArgs e)
		{
			string glintNameToAdd = comboBoxAllGlintsOnLocation.Text;

			if (!listBoxQuestGlints.Items.Contains(glintNameToAdd))
			{
				listBoxQuestGlints.Items.Add(glintNameToAdd);
				IsModified = true;
			}

		}

		private void buttonRemoveGlintFromQuest_Click(object sender, EventArgs e)
		{
			if (listBoxQuestGlints.SelectedItem != null)
			{
				listBoxQuestGlints.Items.Remove(listBoxQuestGlints.SelectedItem);

				IsModified = true;
			}
		}

		private void buttonChooseHighlightLayer_Click(object sender, EventArgs e)
		{
			if (SelectedScene != null)
			{
				Scene scene = new Scene();

				string sceneFileName = Config.ScenesPath + "\\" + SelectedScene.SceneFilePath;
				scene.LoadFromXml(sceneFileName);

				SelectLayerForm form = new SelectLayerForm(scene);

				if (DialogResult.OK == form.ShowDialog())
				{
					if (form.SelectedLayer != null)
					{
						textBoxHighlightLayer.Text = form.SelectedLayer.FullName;
						IsModified = true;
					}
				}

			}
		}

		private void buttonChooseDropZone_Click(object sender, EventArgs e)
		{
			if (SelectedScene != null)
			{
				Scene scene = new Scene();

				string sceneFileName = Config.ScenesPath + "\\" + SelectedScene.SceneFilePath;
				scene.LoadFromXml(sceneFileName);

				SelectLayerForm form = new SelectLayerForm(scene);

				if (DialogResult.OK == form.ShowDialog())
				{
					if (form.SelectedLayer != null)
					{
						comboBoxDropZone.Text = form.SelectedLayer.FullName;
						IsModified = true;
					}
				}
			}
		}

		private void buttonChooseClickLayer_Click(object sender, EventArgs e)
		{
			if (SelectedScene != null)
			{
				Scene scene = new Scene();

				string sceneFileName = Config.ScenesPath + "\\" + SelectedScene.SceneFilePath;
				scene.LoadFromXml(sceneFileName);

				SelectLayerForm form = new SelectLayerForm(scene);

				if (DialogResult.OK == form.ShowDialog())
				{
					if (form.SelectedLayer != null)
					{
						comboBoxClickOnLayer.Text = form.SelectedLayer.FullName;
						IsModified = true;
					}
				}
			}
		}

		private void checkBoxDraft_CheckedChanged(object sender, EventArgs e)
		{
			IsModified = true;
		}

		private void comboBoxClickOnLayer_TextUpdate(object sender, EventArgs e)
		{
			IsModified = true;
		}

		private void textBoxMiniGameName_TextChanged(object sender, EventArgs e)
		{
			IsModified = true;
		}

		private void comboBoxMiniGameName_TextUpdate(object sender, EventArgs e)
		{
			IsModified = true;
		}

		private void comboBoxMiniGameName_SelectedIndexChanged(object sender, EventArgs e)
		{
            if (comboBoxMiniGameName.Text != string.Empty)
            {
                IsModified = true;
            }
		}


#endregion

#region Quests control handlers

		private void buttonSave_Click(object sender, EventArgs e)
		{
			if (listViewQuestOnScene.SelectedItems.Count > 0)
			{
				Quest selectedQuest = (Quest)listViewQuestOnScene.SelectedItems[0].Tag;

				SaveQuestFormDataToXmlNode(selectedQuest);

				UpdateStatusStrip("Quest '" + selectedQuest.Name + "' saved");
			}
		}

		private void buttonCancelQuestModification_Click(object sender, EventArgs e)
		{
			IsModified = false;
		}

		private void buttonAddQuest_Click(object sender, EventArgs e)
		{
			SceneInfo selectedScene;

			if (textBoxNewQuest.Text != string.Empty)
			{
				if (treeViewPlaces.SelectedNode != null)
				{
					selectedScene = (SceneInfo)treeViewPlaces.SelectedNode.Tag;

					_questsManager.AddQuest(textBoxNewQuest.Text, selectedScene);

					FillDepQuestsCombo();

					FillQuestsOnSelectedSceneList();
				}

				//LoadQuestFormDataFromXmlNode(questNode);

				//TreeNode newTreeNode = new TreeNode(textBoxNewQuest.Text);

				//newTreeNode.Tag = questNode;

				//locationTreeNode.Nodes.Add(newTreeNode);

				//treeViewPlaces.SelectedNode = newTreeNode;


				UpdateQuestType();

				SelectQuestInListView(textBoxNewQuest.Text);

				IsModified = true;
			}

		}

		private void buttonRemoveQuest_Click(object sender, EventArgs e)
		{
			if (listViewQuestOnScene.SelectedItems != null &&
				listViewQuestOnScene.SelectedItems.Count != 0 &&
				treeViewPlaces.SelectedNode != null)
			{
				if (MessageBox.Show("Remove quest '" + listViewQuestOnScene.SelectedItems[0].Text + "'?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
				{
					_questsManager.RemoveQuestNode(
						listViewQuestOnScene.SelectedItems[0].Text,
						(SceneInfo)treeViewPlaces.SelectedNode.Tag);

					FillQuestsOnSelectedSceneList();

					FillDepQuestsCombo();

					IsFileModified = true;
				}
			}
		}

		private void textBoxFindQuest_TextChanged(object sender, EventArgs e)
		{

		}

		private void buttonFindQuest_Click(object sender, EventArgs e)
		{
			if (textBoxFindQuest.Text == string.Empty)
			{
				textBoxFindQuest.Focus();

				return;
			}

			if (textBoxFindQuest.Text != _prevSearchString && textBoxFindQuest.Text != string.Empty)
			{
				_findResults.Clear();

				foreach (TreeNode locationNode in treeViewPlaces.Nodes)
				{
					foreach (TreeNode questNode in locationNode.Nodes)
					{
						if (questNode.Text.Contains(textBoxFindQuest.Text))
						{
							_findResults.Add(questNode);
						}
					}
				}

				_prevFindPos = 0;

				if (_findResults.Count != 0)
				{
					treeViewPlaces.SelectedNode = _findResults[_prevFindPos++];

					_prevSearchString = textBoxFindQuest.Text;
				}
				else
				{
					MessageBox.Show("Not found", "Search");
				}

			}
			else
			{
				if (_findResults.Count != 0)
				{
					_prevFindPos++;

					if (_prevFindPos >= _findResults.Count)
					{
						_prevFindPos = 0;
					}

					treeViewPlaces.SelectedNode = _findResults[_prevFindPos];

				}
			}
		}

		private void buttonAddBookmark_Click(object sender, EventArgs e)
		{
// 			if (treeViewPlaces.SelectedNode != null && treeViewPlaces.SelectedNode.Parent != null)
// 			{
// 				listBoxBookmarks.Items.Add(treeViewPlaces.SelectedNode.Text);
// 
// 			}
		}

		private void buttonRemoveBookmark_Click(object sender, EventArgs e)
		{
// 			if (listBoxBookmarks.SelectedItem != null)
// 			{
// 				listBoxBookmarks.Items.Remove(listBoxBookmarks.SelectedItem);
// 			}
		}

		private void listBoxBookmarks_MouseDoubleClick(object sender, MouseEventArgs e)
		{
// 			if (listBoxBookmarks.SelectedItem != null)
// 			{
// 				FindAndSelectQuest(listBoxBookmarks.SelectedItem.ToString());
// 
// 			}

		}

		private void listViewQuestOnScene_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (listViewQuestOnScene.SelectedItems.Count > 0)
			{
				Quest selectedQuest = (Quest)listViewQuestOnScene.SelectedItems[0].Tag;

				if (selectedQuest != null)
				{
					LoadQuestFormDataFromXmlNode(selectedQuest);

					splitContainerQuestProps.Show();

					IsModified = false;
				}
				else
				{
					splitContainerQuestProps.Hide();
				}
			}
			else
			{
				splitContainerQuestProps.Hide();
			}
		}

#endregion

#region Glints control handlers
		private void buttonAddGlint_Click(object sender, EventArgs e)
		{
			if (SelectedScene != null)
			{
				Scene scene = new Scene();

				string sceneFileName = Config.ScenesPath + "\\" + SelectedScene.SceneFilePath;
				scene.LoadFromXml(sceneFileName);

				Quest selectedQuest = GetSelectedQuest();

				AddGlintForm form = new AddGlintForm(scene, selectedQuest != null ? selectedQuest.Name : "");

				if (DialogResult.OK == form.ShowDialog())
				{
					_glintManager.AddGlintToScene(form.GlintName, form.LayerName, SelectedScene);

					FillGlintsOnSelectedScene();

					FillGlintsOnLocationCombo();

					IsFileModified = true;
				}


			}
		}

		private void buttonRemoveGlint_Click(object sender, EventArgs e)
		{
			if (SelectedScene != null)
			{
				Glint selectedGlint = GetSelectedGlint();

				if (selectedGlint != null)
				{
					if (
						MessageBox.Show(
							"Are you sure?",
							"Remove glint",
							MessageBoxButtons.YesNo,
							MessageBoxIcon.Warning) == DialogResult.Yes)
					{
						_glintManager.RemoveGlintFromScene(selectedGlint.Name, SelectedScene);

						FillGlintsOnSelectedScene();

						FillGlintsOnLocationCombo();

						IsFileModified = true;
					}

				}
			}
		}

#endregion

#region Menu handlers

		private void findQuestToolStripMenuItem_Click(object sender, EventArgs e)
		{
			buttonFindQuest_Click(sender, e);
		}

		private void openLevelsxmlToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Process proc = new System.Diagnostics.Process();
			proc.StartInfo.FileName = LevelsFileName;
			proc.Start();
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog();

			if (DialogResult.OK == dlg.ShowDialog())
			{
				OpenFile(dlg.FileName);
			}
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			UpdateStatusStrip("Saving");

			Quest selectedQuest = GetSelectedQuest();

			if (selectedQuest != null)
			{
				SaveQuestFormDataToXmlNode(selectedQuest);
				IsModified = false;
			}
			

			_questsManager.Save();
			_glintManager.SaveAll();
			_locationManager.Save();
			SaveBookmarks();

			IsFileModified = false;

			UpdateStatusStrip("Saved");
		}

		private void generateTemplateToolStripMenuItem_Click(object sender, EventArgs e)
		{
			GenerateTemplateForm form = new GenerateTemplateForm(_locationManager, _questsManager, _glintManager, _inventory);

			form.ShowDialog();
			
			IsFileModified = form.IsModified;

			//Fill

			// 			form.Config.ProjectPath = ProjectPath;
			// 			form.P();
			// 			form.ShowDialog();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void saveQuestDataToolStripMenuItem_Click(object sender, EventArgs e)
		{
			buttonSave_Click(sender, e);
		}
#endregion


		
				

#endregion

				
	}
}
