using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Collections.Specialized;
using System.Collections;
using System.IO;
using System.Diagnostics;
using System.Threading;
using HiddenObjectStudio.Core;
using HiddenObjectStudio.Core.LocationManagement;
using HiddenObjectStudio.Core.SceneManagement;
using HiddenObjectStudio.Core.ResourcesManager;
using HiddenObjectStudio.Core.InventoriesManagement;
using System.Text.RegularExpressions;
using WindowsFormsApplication2.Controls;
using ResourcesManager;
using HiddenObjectStudio.Core.Forms;

namespace WindowsFormsApplication2
{
    public partial class MainForm : Form
    {
        private XmlDocument _levelsDocXml;
        private string _levelsXmlPath;
        string fileLocTxt;
        List<string> _itemsInScene;
        List<string> _dropZonesInScene;
        Point contMenuClickPoint;
        string runProjectName = "";
        private FormWindowState _OldFormState;
        Config Config;
        public ResourcesData resourcesData;
        public Inventories inventories;
        public string _invFilename;
        public string _invResFilename;
        public bool _partExistInSelectedList = false;
        SceneInfo _startLocSceneInfo;
        public bool ProjectWithPackFile = false;
        public int loadingProgress = 0;

        public MainForm()
        {
            Config = new Config();

            FileInfo fi = new FileInfo(Config.ProjectPath + "\\data\\pack.pak");

            _itemsInScene = new List<string>();

            if (fi.Exists)
            {
                ProjectWithPackFile = true;
            }

            InitializeComponent();

            InitializeOpenFileDialogExeFile();

            loadingProgress = 5;            

            _dropZonesInScene = new List<string>();

            if (!ProjectWithPackFile)
            {
                _invFilename = Config.InventoryPath + "\\inventory.xml";
                _invResFilename = Config.InventoryPath + "\\resources.xml";
            }
            else
            {
                _invFilename = Config.ProjectPath + "\\inventory.xml";
                _invResFilename = Config.ProjectPath + "\\resources.xml";

                CutHelperVersion();
            }

            if (!File.Exists(_invFilename))
            {
                if (!ProjectWithPackFile)
                {
                    MessageBox.Show("inventory.xml doesn't exist in data\\gameplay\\main\\inventory\\");
                    
                }
                else
                {
                    MessageBox.Show("inventory.xml doesn't exist in root folder");
                    
                }
            }

            if (!File.Exists(_invResFilename))
            {
                if (!ProjectWithPackFile)
                {
                    MessageBox.Show("resources.xml doesn't exist in data\\gameplay\\main\\inventory\\");
                }
                else
                {
                    MessageBox.Show("resources.xml doesn't exist in root folder");
                }
            }

            resourcesData = new ResourcesData(_invResFilename);
            loadingProgress = 15;
            inventories = new Inventories(_invFilename);
            loadingProgress = 25;
            
            fileLocTxt = Config.BinPath + "g_add_inventory_item.txt";

            string skipMenusFileName = "skip_menus.txt";
            string skipMenusFilePath = Config.DataPath + "\\ui\\" + skipMenusFileName;

            if (File.Exists(skipMenusFilePath))
            {
                checkBoxSkipMenus.Checked = true;
            }
            else
            {
                checkBoxSkipMenus.Checked = false;
            }

            runProjectName = this.Text;

            if (checkBoxHideToTray.Checked)
            {
                _notifyIcon.Visible = true;
            }
            else
            {
                _notifyIcon.Visible = false;
            }

            _notifyIcon.Text = "Fly's Scripter Helper";
            // _notifyIcon.MouseClick += new MouseEventHandler(_notifyIcon_MouseClick);
            this.Resize += new EventHandler(MainForm_Resize);

        }

        private void InitializeOpenFileDialogExeFile()
        {
            this.openFileDialogExeFileName.Filter =
                "Executable files (*.EXE)|*.EXE|" +
                "All files (*.*)|*.*";

            this.openFileDialogExeFileName.Multiselect = false;
            this.openFileDialogExeFileName.Title = "Select executable file!";
            string folderPath = Config.BinPath.Replace("\\\\", "\\");
            this.openFileDialogExeFileName.InitialDirectory = folderPath;
        }

        private void CutHelperVersion()
        {
            groupBoxServiceFunctions.Enabled = false;
            AddToScenePlayer.Enabled = false;
            OpenSceneXMLFile.Enabled = false;
            OpenSceneScriptFile.Enabled = false;
            OpenSceneResourcesFile.Enabled = false;
            CreateShaderToolSprip.Enabled = false;
            openSceneFolderToolStripMenuItem.Enabled = false;
            shaderViewerToolStripMenuItem.Enabled = false;

            contextMenuStripSubs.Enabled = false;

            buttonAddNewItem.Enabled = false;
                        
            button5.Enabled = false;

            columnHeader1.Width = 0;

            checkBoxHideToTray.Enabled = false;
            checkBoxSkipMenus.Enabled = false;
        }

        public void InitListView()
        {
            inventories.LoadInventoriesXMl(_invFilename);
            resourcesData.LoadResourcesXMl(_invResFilename);

            XmlDocument textDocXML;
            string textFilenameNewItem = Config.TextsPath + "\\texts.xml";
            Image img;
            textDocXML = new XmlDocument();
            Tools.TryToLoad(textDocXML, textFilenameNewItem);
            //textDocXML.Load(textFilenameNewItem);
            int countMin = 30;
            int count = countMin;
            loadingProgress = 30;
            
            foreach (InventoryItem invItem in inventories.IntentoryItems)
            {
                List<string> AllParts = new List<string>();
                string allPartsString = String.Empty;

                foreach (Part part in invItem.PartsList)
                {
                    AllParts.Add(part.partName);
                    if (allPartsString == String.Empty)
                    {
                        allPartsString = part.partName;
                    }
                    else
                    {
                        allPartsString = allPartsString + "\n" + part.partName;
                    }
                }
                
                string attText = invItem.InvItemShaderName;

                string picPath = resourcesData.GetShaderPathByFullName(attText);

                

                if (File.Exists(picPath))
                {
                    img = Image.FromFile(picPath);
                }
                else
                {
                    img = null;
                }
                

                string textBoxText = textBox1.Text;

                string itemName = string.Empty;

                string nameToShow = string.Empty;

                XmlNode textInvItemNode = (XmlNode)textDocXML.SelectSingleNode("texts/gameplay/inventory_items/" + invItem.Name);
                if (textInvItemNode != null)
                {
                    itemName = textInvItemNode.Attributes["text"].Value;
                }

                if (itemName != string.Empty)
                {
                    nameToShow = invItem.Name + '\n' + "(\"" + itemName + "\")";
                }
                else
                {
                    nameToShow = invItem.Name;
                }

                if (textBoxText == String.Empty)
                {
                    
                    ListViewItem newItem = new ListViewItem();
                    if (img != null)
                    {
                        imageList1.Images.Add(Path.GetFileName(picPath), img);
                        newItem.ImageKey = Path.GetFileName(picPath);
                        listView1.LargeImageList.Images.Add(img);
                        listView1.SmallImageList.Images.Add(img);
                    }
                    
                    newItem.SubItems.Add(nameToShow);
                    newItem.SubItems.Add(allPartsString);
                    listView1.Items.Add(newItem);
                    
                    listView1.Refresh();
                }

                string[] searchMass = textBoxText.Split(' ');

                if ((textBoxText != String.Empty) && (StringContainsMassElement(searchMass, invItem.Name)))
                {
                    
                    ListViewItem newItem = new ListViewItem();
                    if (img != null)
                    {
                        imageList1.Images.Add(Path.GetFileName(picPath), img);
                        newItem.ImageKey = Path.GetFileName(picPath);
                        listView1.LargeImageList.Images.Add(img);
                        listView1.SmallImageList.Images.Add(img);
                    }
                    newItem.SubItems.Add(nameToShow);
                    newItem.SubItems.Add(allPartsString);
                    listView1.Items.Add(newItem);
                    
                    listView1.Refresh();

                }
            }
        }

        private bool StringContainsMassElement(string[] srtMass, string str)
        {
            for (int i = 0; i < srtMass.Length; i++)
            {
                if (!str.Contains(srtMass[i]))
                {
                    return false;
                }
            }
            return true;
        }

        private string AttString(string attName, char spliter)
        {
            string attSubString;
            attSubString = attName.Substring(attName.LastIndexOf(spliter) + 1);
            return attSubString;
        }

        private void AddChoosenItemsToInventory()
        {
            if (selectedList.Items.Count > 0)
            {
                int attemptsCount = 10;
                bool success = false;

                do
                {
                    try
                    {
                        StreamWriter streamWriter = File.CreateText(fileLocTxt);

                        foreach (object o in selectedList.Items)
                        {
                            streamWriter.WriteLine(o.ToString());
                        }

                        streamWriter.Close();

                        success = true;
                    }
                    catch (System.SystemException)
                    {
                        attemptsCount--;

                        Thread.Sleep(10);
                    }

                } while (attemptsCount >= 0 && !success);

                label2.Text = "Successfully";
            }
            else
            {
                label2.Text = "Select Inventory Items First!!!";
            }
        }
        private void buttonAddChoosenItemsToInventory_Click(object sender, EventArgs e)
        {
            AddChoosenItemsToInventory();
        }

        private void selectedList_DoubleClick(object sender, EventArgs e)
        {
            DeleteInventoryItemFromChosen();
        }

        private void DeleteInventoryItemFromChosen()
        {
            if (selectedList.Items.Count > 0)
            {
                int removeItemIndex = selectedList.SelectedIndex;
                if (removeItemIndex >= 0)
                {
                    selectedList.Items.RemoveAt(removeItemIndex);
                    label2.Text = "";
                }
                else
                {
                    label2.Text = "Please select item in ListBox";
                }
            }
            ButtonEnabledFalse();
            selectedList.Refresh();
        }

        private void DeleteAllInventoryItemFromChosen()
        {
            if (selectedList.Items.Count > 0)
            {
                selectedList.Items.Clear();

            }
            ButtonEnabledFalse();
            label2.Text = "";
            selectedList.Refresh();
        }

        private void AddInventoryItemPartToChosen()
        {
            if (listView1.SelectedItems.Count != 0)
            {
                string[] mass = listView1.SelectedItems[0].SubItems[2].Text.Split('\n');

                if (selectedList.Items.Count == 0)
                {
                    
                    buttonUncheckItem.Enabled = false;
                    buttonUnCheckAll.Enabled = false;
                    foreach (string str in mass)
                    {
                        selectedList.Items.Add(str);
                    }
                    
                    buttonUncheckItem.Enabled = true;
                    buttonUnCheckAll.Enabled = true;
                }
                else
                {
                    if (selectedList.Items.Count > 0)
                    {
                        for (int j = 0; j < mass.Length; j++)
                        {
                            _partExistInSelectedList = false;
                            for (int i = 0; i < selectedList.Items.Count; i++)
                            {
                                string listBox3ItemName = (string)selectedList.Items[i];
                                if (listBox3ItemName == mass[j])
                                {
                                    label2.Text = "Already exist";
                                    _partExistInSelectedList = true;
                                }

                            }
                            if (!_partExistInSelectedList)
                            {
                                selectedList.Items.Add(mass[j]);
                            }
                        }

                        
                        buttonUncheckItem.Enabled = true;
                        buttonUnCheckAll.Enabled = true;
                        label2.Text = "";
                    }
                }
                selectedList.Refresh();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Please, select Inventory item before");
            }
        }

        private void AddInventoryItemToChosen()
        {

            if (listView1.SelectedItems.Count != 0)
            {
                string[] nameArr = listView1.SelectedItems[0].SubItems[1].Text.Split('\n');

                string selectedInvItem = nameArr[0];
                
                if (listView1.SelectedItems[0].SubItems[2].Text != String.Empty)
                {
                    AddInventoryItemPartToChosen();
                    return;
                }

                if (selectedList.Items.Count == 0)
                {
                    
                    buttonUncheckItem.Enabled = false;
                    buttonUnCheckAll.Enabled = false;
                    selectedList.Items.Add(selectedInvItem);
                    
                    buttonUncheckItem.Enabled = true;
                    buttonUnCheckAll.Enabled = true;
                }
                else
                {
                    if (selectedList.Items.Count > 0)
                    {
                        for (int i = 0; i < selectedList.Items.Count; i++)
                        {
                            string listBox3ItemName = (string)selectedList.Items[i];
                            if (listBox3ItemName == selectedInvItem)
                            {
                                label2.Text = "Already exist";
                                return;
                            }
                        }
                        selectedList.Items.Add(selectedInvItem);
                        buttonUncheckItem.Enabled = true;
                        buttonUnCheckAll.Enabled = true;
                        label2.Text = "";
                    }
                }
                selectedList.Refresh();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Please, select Inventory item before");
            }

        }
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            AddInventoryItemToChosen();
        }

        private void DeleteFile()
        {
            if (File.Exists(fileLocTxt))
            {
                File.Delete(fileLocTxt);
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            InitListView();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            DeleteFile();
        }


        private void ButtonEnabledFalse()
        {
            if (selectedList.Items.Count == 0)
            {
                buttonUncheckItem.Enabled = false;
                buttonUnCheckAll.Enabled = false;
            }
        }


        private void ReadLevelsXMLFile(string fileNameLevelsXml)
        {
            XmlElement levelsStageNodeXml = (XmlElement)_levelsDocXml.SelectSingleNode("levels/stage");

            LocationManager lm = new LocationManager(fileNameLevelsXml);

            StreamReader streamReader;

            string startLocTxtName = "start_location.txt";

            string startLocTxt = Config.ProjectPath + "\\" + startLocTxtName;

            string contents = String.Empty;

            if (File.Exists(startLocTxt))
            {
                streamReader = File.OpenText(startLocTxt);

                contents = streamReader.ReadToEnd();

                streamReader.Close();
            }
            foreach (SceneInfo sceneInfo in lm.AllMainScenes)
            {
                string sceneName = string.Empty;
                
                if (sceneInfo.GddName != string.Empty)
                {
                    sceneName = sceneInfo.GddName;
                }
                else
                {
                    sceneName = sceneInfo.Name;
                }
               
                ListViewItem newItem = new ListViewItem();
                newItem.Text = sceneName;
                newItem.Tag = sceneInfo;
                listViewLevels.Items.Add(newItem);
                if (contents != String.Empty)
                {
                    if (sceneName == contents)
                    {
                        newItem.BackColor = Color.Aqua;
                        _startLocSceneInfo = sceneInfo;
                        newItem.Selected = true;
                        listViewLevels.Select();
                        // = newItem;
                    }
                }
                
                listViewLevels.Refresh();
            }

            if (_startLocSceneInfo == null)
            {
                checkBoxLoadSceneWithAllInvItems.Enabled = false;
            }
            else
            {
                checkBoxLoadSceneWithAllInvItems.Enabled = true;
                checkBoxLoadSceneWithAllInvItems.Checked = true;
            }
        
        }

        private void EditScenePlayerXML(string nameScene, string fileName)
        {
            string fileNameScenePlayerXml = Config.BinPath + "ScenePlayer.xml";
            List<string> resFilePaths = new List<string>();
           // ResourcesData resData = new ResourcesData();
            XmlDocument scenePlayerDocXml = new XmlDocument();

            LocationManager locationManager = new LocationManager(_levelsXmlPath);
            Tools.TryToLoad(scenePlayerDocXml, fileNameScenePlayerXml);
           // scenePlayerDocXml.Load(fileNameScenePlayerXml);

            XmlElement scenePlayerResNodeXml = (XmlElement)scenePlayerDocXml.SelectSingleNode("scene_player_config");

            foreach (XmlNode scenePlayerNode in scenePlayerResNodeXml)
            {
                if (scenePlayerNode.Name == "resource_files")
                {
                    scenePlayerNode.RemoveAll();

                    SceneInfo scenInfo = locationManager.FindSceneOrSubscreenByFolderName(nameScene);

                    Location location = scenInfo.OwnerLocation;

                    foreach (string resFileName in location.ResourcesFilePaths)
                    {
                        XmlElement addedResourcesNode = scenePlayerDocXml.CreateElement("file");
                        addedResourcesNode.SetAttribute("file_name", resFileName);
                        scenePlayerNode.AppendChild(addedResourcesNode);
                    }

                }
                if (scenePlayerNode.Name == "scene_file")
                {
                    XmlElement addedSceneNode = scenePlayerDocXml.SelectSingleNode("scene_player_config/scene_file") as XmlElement;

                    if (addedSceneNode != null)
                    {
                        addedSceneNode.SetAttribute("file_name", "data\\scenes\\" + nameScene + "\\" + fileName);
                    }

                }
            }
            scenePlayerDocXml.Save(fileNameScenePlayerXml);
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            string fileNameLevelsXml;
            string exMessagePath = string.Empty;
            
            runGameToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Enter;
            
            if (!ProjectWithPackFile)
            {
                fileNameLevelsXml = Config.LevelsPath + "\\levels.xml";
                exMessagePath = " at data\\levels";
            }
            else
            {
                fileNameLevelsXml = Config.ProjectPath + "\\levels.xml";
                exMessagePath = " at root folder";
            }

            if (File.Exists(fileNameLevelsXml))
            {

                    _levelsDocXml = new XmlDocument();
                    Tools.TryToLoad(_levelsDocXml, fileNameLevelsXml);
                    //_levelsDocXml.Load(fileNameLevelsXml);

                    _levelsXmlPath = fileNameLevelsXml;

                    string fileNameTextsXml = Config.TextsPath + "\\texts.xml";

                    XmlDocument textDocXml = new XmlDocument();

                    Tools.TryToLoad(textDocXml, fileNameTextsXml);
                //    textDocXml.Load(fileNameTextsXml);

                    XmlElement textRootXml = (XmlElement)textDocXml.SelectSingleNode("texts/game_title");

                    string appName = this.Text;

                    string projName = textRootXml.Attributes["text"].Value;

                    Mutex ffs2_helper = new Mutex();

                    InitListView();

                    ReadLevelsXMLFile(fileNameLevelsXml);


                    if (!ProjectWithPackFile)
                    {
                        bool init = true;
                        EditPreconfigurateFile(init);

                        this.Text = textRootXml.Attributes["text"].Value + " - " + appName;

                    }
                    else
                    {
                        this.Text = textRootXml.Attributes["text"].Value + " - " + appName + " - Lite version";
                    }

            }
            else
            {
                MessageBox.Show("levels.xml doesn't exist" + exMessagePath);
                Application.Exit();
            }
        }


        private void AddToScenePlayer_Click(object sender, EventArgs e)
        {
            SceneInfo sceneInfo = (SceneInfo)listViewLevels.SelectedItems[0].Tag;

            Scene scene = new Scene();

            scene.LoadFromXml(Config.ScenesPath + "\\" + sceneInfo.SceneFilePath);

            EditScenePlayerXML(sceneInfo.FolderName, sceneInfo.FileName);

            labelCheckScenePlayer.Text = "Successful";

        }


        private void OpenSceneXMLFile_Click(object sender, EventArgs e)
        {
            Process proc = new System.Diagnostics.Process();

            SceneInfo sceneInfo = (SceneInfo)listViewLevels.SelectedItems[0].Tag;

            Scene scene = new Scene();

            scene.LoadFromXml(Config.ScenesPath + "\\" + sceneInfo.SceneFilePath);

            string sceneFullFileName = Config.ScenesPath + "\\" + sceneInfo.FolderName + "\\" + sceneInfo.FileName;

            if (File.Exists(sceneFullFileName))
            {
                proc.StartInfo.FileName = sceneFullFileName;
                proc.StartInfo.UseShellExecute = true;
                proc.Start();
            }
        }

        private void OpenSceneScriptFile_Click(object sender, EventArgs e)
        {
            Process proc = new System.Diagnostics.Process();

            SceneInfo sceneInfo = (SceneInfo)listViewLevels.SelectedItems[0].Tag;

            Scene scene = new Scene();

            scene.LoadFromXml(Config.ScenesPath + "\\" + sceneInfo.SceneFilePath);

            foreach (string scriptFileName in scene.ScriptFiles)
            {
                string scriptFullFileName = Config.ScenesPath + "\\" + sceneInfo.FolderName + "\\" + scriptFileName;

                if (!File.Exists(scriptFullFileName)) continue;

                proc.StartInfo.FileName = scriptFullFileName;
                proc.StartInfo.UseShellExecute = true;
                proc.Start();
            }
        }

        private void OpenSceneResourcesFile_Click(object sender, EventArgs e)
        {
            Process proc = new System.Diagnostics.Process();

            SceneInfo sceneInfo = (SceneInfo)listViewLevels.SelectedItems[0].Tag;

            Scene scene = new Scene();

            scene.LoadFromXml(Config.ScenesPath + "\\" + sceneInfo.SceneFilePath);

            string resourcesFullFileName = Config.ScenesPath + "\\" + sceneInfo.FolderName + "\\resources.xml";

            if (File.Exists(resourcesFullFileName))
            {
                proc.StartInfo.FileName = resourcesFullFileName;
                proc.StartInfo.UseShellExecute = true;
                proc.Start();

            }
        }

        private void resourcesManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunResourcesManager();
        }

        private void RunResourcesManager()
        {
            SceneInfo sceneInfo = (SceneInfo)listViewLevels.SelectedItems[0].Tag;

            string resourcesFullFileName = Config.ScenesPath + "\\" + sceneInfo.FolderName + "\\resources.xml";

            resourcesFullFileName = resourcesFullFileName.ToLower().Replace("\\\\", "\\");

            if (File.Exists(resourcesFullFileName))
            {
                ResourcesManagerMainForm resourcesManagerMainForm = new ResourcesManagerMainForm(resourcesFullFileName);
                resourcesManagerMainForm.Show();
            }
        }

        private void listBoxLevels_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ListBox listBoxLevels = ((ListBox)sender);

                contMenuClickPoint = new Point(e.X, e.Y);

                //    listBoxLevels.SelectedIndex = listBoxLevels.IndexFromPoint(contMenuClickPoint);
            }
        }

        private void listBoxLevels_MouseUp(object sender, MouseEventArgs e)
        {
            //     contextMenuEditScene.Show(contMenuClickPoint);
        }

        private void AddSceneToStartLocation_Click(object sender, EventArgs e)
        {
            SceneInfo sceneInfo = (SceneInfo)listViewLevels.SelectedItems[0].Tag;

            Scene scene = new Scene();

            string listBoxLevelsPlace = sceneInfo.FolderName;

            if (sceneInfo.Name.Contains("_ho"))
            {
                listBoxLevelsPlace = sceneInfo.Name;
            }

            XmlNodeList levelPlaceNode = _levelsDocXml.SelectNodes("levels/stage/level[@place='" + listBoxLevelsPlace + "']");

            XmlNodeList levelSubNode = _levelsDocXml.SelectNodes("levels/stage/level/subscreens/" + listBoxLevelsPlace + "[@scene_folder='" + listBoxLevelsPlace + "']");

            string startLocTxtName = "start_location.txt";
            string startLocTxt = Config.ProjectPath + "\\" + startLocTxtName;
            
            if (!File.Exists(startLocTxt))
            {
                StreamWriter streamWriter = File.CreateText(startLocTxt);
                streamWriter.Close();
            }

            if ((levelPlaceNode.Count > 0) && (levelSubNode.Count == 0))
            {
                StreamReader streamReader;

                if (File.Exists(startLocTxt))
                {
                    streamReader = File.OpenText(startLocTxt);

                    string contents = streamReader.ReadToEnd();

                    streamReader.Close();

                    StreamWriter streamWriter = File.CreateText(startLocTxt);

                    streamWriter.Write(listBoxLevelsPlace);

                    streamWriter.Close();

                }
                listViewLevels.SelectedItems[0].BackColor = Color.Aqua;
                checkBoxLoadSceneWithAllInvItems.Enabled = true;
                _startLocSceneInfo = (SceneInfo)listViewLevels.SelectedItems[0].Tag;
                for (int i = 0; i < listViewLevels.Items.Count; i++)
                {
                    if (listViewLevels.Items[i].Tag != listViewLevels.SelectedItems[0].Tag)
                    {
                        listViewLevels.Items[i].BackColor = Color.Transparent;
                    }
                }
            }
            if ((levelPlaceNode.Count == 0) && (levelSubNode.Count > 0))
            {
                labelCheckScenePlayer.Text = "Cant! This is subscreen";
            }
        }

        private void EditPreconfigurateFile(bool init)
        {
            string preConfigFilename;

            XmlElement preConfigRoot;
            preConfigFilename = Config.BinPath + "flyPreConfigurateFile.xml";

            XmlDocument preConfigDoc = new XmlDocument();

            if (File.Exists(preConfigFilename))
            {
                File.Delete(preConfigFilename);
            }

            preConfigDoc.AppendChild(preConfigDoc.CreateElement("preconfigurate"));
            XmlElement preConfigLocationsRootNode = (XmlElement)preConfigDoc.DocumentElement.AppendChild(preConfigDoc.CreateElement("locations"));

            preConfigRoot = preConfigDoc.DocumentElement;

            string rootNodeName = "preconfigurate";

            //preConfigLocationsNode = (XmlElement)preConfigDoc.SelectSingleNode(rootNodeName + "/locations");

            LocationManager lm = new LocationManager(_levelsXmlPath);

            foreach (Location loc in lm.Locations)
            {
                XmlElement locationConfigNode = preConfigDoc.CreateElement(loc.Name);
                preConfigLocationsRootNode.AppendChild(locationConfigNode);

                SceneInfo sceneInfo = loc.MainScene;
                XmlElement sceneConfigNode = preConfigDoc.CreateElement(sceneInfo.Name);
                locationConfigNode.AppendChild(sceneConfigNode);

                XmlElement itemsRootNode = preConfigDoc.CreateElement("items");
                sceneConfigNode.AppendChild(itemsRootNode);

                GetItems(sceneInfo, preConfigDoc, itemsRootNode);

                if (loc.AllSubscreens.Count > 0)
                {
                    XmlElement subscreensRootNode = preConfigDoc.CreateElement("subscreens");
                    sceneConfigNode.AppendChild(subscreensRootNode);

                    foreach (SceneInfo subscreenSceneInfo in loc.AllSubscreens)
                    {
                        XmlElement subNode = preConfigDoc.CreateElement(subscreenSceneInfo.Name);
                        subscreensRootNode.AppendChild(subNode);
                        subNode.AppendChild(itemsRootNode);

                        GetItems(subscreenSceneInfo, preConfigDoc, itemsRootNode);
                    }
                }
            }

            preConfigDoc.Save(preConfigFilename);
            if (!init)
            {
                System.Windows.Forms.MessageBox.Show("Done!");
            }
        }

        private void GetItems(SceneInfo sceneInfo, XmlDocument preConfigDoc, XmlElement itemsRootNode)
        {
            GetAllInventoryItemsFromScene(sceneInfo);

            for (int k = 0; k < _itemsInScene.Count; k++)
            {
                //XmlElement addedInventoryItemNode = (XmlElement)preConfigDoc.SelectSingleNode(preConfigLocationsRootNode + "/" + loc.Name + "/" + _itemsInScene[k]);
                //  if (addedInventoryItemNode == null)
                //   {
                XmlElement addedInventoryItemNode = preConfigDoc.CreateElement(_itemsInScene[k]);
                itemsRootNode.AppendChild(addedInventoryItemNode);
                //    }
            }
        }

        private void GetAllInventoryItemsFromScene(SceneInfo sceneInfo)
        {
            string fileNameSceneXml = "";

            string levelPlace = "";

            fileNameSceneXml = Config.ScenesPath + "\\" + sceneInfo.SceneFilePath;

            if (fileNameSceneXml != "")
            {

                XmlDocument sceneFile = new XmlDocument();

                if (File.Exists(fileNameSceneXml))
                {
                    try
                    {
                        sceneFile.Load(fileNameSceneXml);

                        XmlElement rootNode = sceneFile.DocumentElement;

                        string rootNodeName = rootNode.Name;

                        XmlElement sceneFileNodeXml = (XmlElement)sceneFile.SelectSingleNode(rootNodeName + "/layers");

                        List<string> allItems = new List<string>();
                        List<string> allItemParts = new List<string>();

                        _itemsInScene = GetSceneUsebleItems(sceneFileNodeXml, sceneFile, allItems, allItemParts);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error in: " + fileNameSceneXml
                         + ". Try to correct the .xml file " +
                         "it may be corrupt.\n\nReported error: " + ex.Message);
                    }
                }
            }
        }

        private List<string> GetSceneUsebleItems(XmlElement xmlNodeList, XmlDocument sceneFile, List<string> allItems, List<string> allItemParts)
        {
            _itemsInScene.Clear();

            foreach (XmlNode layersNode in xmlNodeList)
            {
                if (layersNode.NodeType != XmlNodeType.Comment)
                {
                    if (layersNode.Attributes["accepts_items"] != null)
                    {
                        string accItemName = layersNode.Attributes["accepts_items"].Value;
                        if (accItemName.Contains("|"))
                        {
                            accItemName = accItemName.Replace(" ", string.Empty);
                            string[] arr = accItemName.Split('|');
                            for (int i = 0; i < arr.Length; i++)
                            {
                                allItemParts = CheckItemToParts(arr[i]);
                                if (allItemParts.Count > 0)
                                {
                                    foreach (string part in allItemParts)
                                    {
                                        allItems.Add(part);
                                    }
                                }
                                else
                                {
                                    allItems.Add(arr[i]);
                                }

                            }
                        }
                        else
                        {
                            if (!allItems.Contains(accItemName))
                            {
                                allItemParts = CheckItemToParts(accItemName);
                                if (allItemParts.Count > 0)
                                {
                                    foreach (string part in allItemParts)
                                    {
                                        allItems.Add(part);
                                    }
                                }
                                else
                                {
                                    allItems.Add(accItemName);
                                }
                            }

                        }
                    }
                    else if (layersNode.ChildNodes.Count > 0)
                    {
                        XmlElement checkNode = (XmlElement)layersNode;
                        allItems = GetSceneUsebleItems(checkNode, sceneFile, allItems, allItemParts);
                    }
                }
            }
            return allItems;
        }

        private List<string> CheckItemToParts(string str)
        {
            List<string> allItemParts = new List<string>();
            InventoryItem invItem = inventories.GetInventoryItemByName(str);
            if (invItem != null)
            {
                foreach (Part part in invItem.PartsList)
                {
                    allItemParts.Add(part.partName);
                }
            }

            return allItemParts;

        }

        private void CreateShaderToolSprip_Click(object sender, EventArgs e)
        {
            SceneInfo sceneInfo = (SceneInfo)listViewLevels.SelectedItems[0].Tag;
            
            CreateShaderForm f = new CreateShaderForm(sceneInfo);
            f.Show();
        }

        private void GetItemsFromScene(string startScene)
        {
            List<string> items = new List<string>();
            SceneInfo sceneInfo;

            if (listViewLevels.SelectedItems.Count > 0)
            {
                sceneInfo = (SceneInfo)listViewLevels.SelectedItems[0].Tag;
            }
            else
            {
                sceneInfo = (SceneInfo)listViewLevels.Items[0].Tag;
            }

            if (startScene != String.Empty)
            {//##
                //     sceneInfo = _startLoc;
            }

            XmlDocument preConfigDocXML;

            XmlElement preConfigRootXML;

            if (File.Exists(Config.BinPath + "flyPreConfigurateFile.xml"))
            {
                string preConfigFilenameNewItem = Config.BinPath + "flyPreConfigurateFile.xml";

                preConfigDocXML = new XmlDocument();

                preConfigDocXML.Load(preConfigFilenameNewItem);

                preConfigRootXML = (XmlElement)preConfigDocXML.SelectSingleNode("preconfigurate/locations");

                foreach (XmlNode preConfigScenesXmlNode in preConfigRootXML)
                {
                    if (preConfigScenesXmlNode.Name == sceneInfo.FolderName)
                    {
                        items.Clear();

                        XmlElement preConfigSceneNode = (XmlElement)preConfigDocXML.SelectSingleNode("preconfigurate/locations/" + preConfigScenesXmlNode.Name);

                        LocationManager Lm = new LocationManager(_levelsXmlPath);

                        Location l = Lm.GetLocation(preConfigScenesXmlNode.Name);
                        if (l == null)
                        {//##
                            //                             SceneInfo subscreen = Lm.FindSceneOrSubscreenByName(preConfigScenesXmlNode.Name);
                            //                             l = subscreen.OwnerLocation;
                            //                             preConfigSceneNode = (XmlElement)preConfigDocXML.SelectSingleNode("preconfigurate/scenes/" + subscreen.OwnerLocation.Name);
                            //                             foreach (XmlNode preConfigItemsNode in preConfigSceneNode)
                            //                             {
                            //                                 if (!CheckExistedInvItemInSelectedList(preConfigItemsNode.Name) && (CheckExistedInvItemInInventory(preConfigItemsNode.Name)))
                            //                                 {
                            //                                     selectedList.Items.Add(preConfigItemsNode.Name);
                            //                                 }
                            //                             }
                        }
                        else
                        {
                            foreach (XmlNode preConfigItemsNode in preConfigSceneNode)
                            {
                                if (!CheckExistedInvItemInSelectedList(preConfigItemsNode.Name) && (CheckExistedInvItemInInventory(preConfigItemsNode.Name)))
                                {
                                    selectedList.Items.Add(preConfigItemsNode.Name);
                                }
                            }
                            foreach (SceneInfo subs in l.AllSubscreens)
                            {
                                preConfigSceneNode = (XmlElement)preConfigDocXML.SelectSingleNode("preconfigurate/locations/" + subs.Name);
                                if (preConfigSceneNode != null)
                                {
                                    foreach (XmlNode preConfigItemsNode in preConfigSceneNode)
                                    {
                                        if (!CheckExistedInvItemInSelectedList(preConfigItemsNode.Name) && (CheckExistedInvItemInInventory(preConfigItemsNode.Name)))
                                        {
                                            selectedList.Items.Add(preConfigItemsNode.Name);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                if (selectedList.Items.Count != 0)
                {
                    buttonUncheckItem.Enabled = true;
                    buttonUnCheckAll.Enabled = true;

                }
                selectedList.Refresh();
            }
            else
            {
                EditPreconfigurateFile(false);
                string strEmpt = String.Empty;
                GetItemsFromScene(strEmpt);
            }
        }

        private void buttonGetItemsFromScene_Click(object sender, EventArgs e)
        {
            string strEmpt = String.Empty;
            GetItemsFromScene(strEmpt);
        }

        private bool CheckExistedInvItemInInventory(string itemName)
        {
            foreach (InventoryItem invItem in inventories.IntentoryItems)
            {
                if (itemName == invItem.Name)
                {
                    return true;
                }
                else
                {
                    if (CheckExistedInvItemInInventoryParts(itemName))
                    {
                        return true;
                    }
                }
            }

            System.Windows.Forms.MessageBox.Show(itemName + " don't exist in inventory!");
            return false;
        }

        private bool CheckExistedInvItemInInventoryParts(string itemName)
        {
            foreach (InventoryItem invItem in inventories.IntentoryItems)
            {
                foreach (Part part in invItem.PartsList)
                {
                    if (itemName == part.partName)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool CheckExistedInvItemInSelectedList(string itemName)
        {
            if (selectedList.Items.Count > 0)
            {
                for (int i = 0; i < selectedList.Items.Count; i++)
                {
                    string listBox3ItemName = (string)selectedList.Items[i];
                    if (listBox3ItemName == itemName)
                    {
                        label2.Text = "Already exist";
                        return true;
                    }
                }

                return false;
            }
            else
            {
                return false;
            }
        }

        private void runGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonRunKA_Click(sender, e);
        }

        private void buttonRunKA_Click(object sender, EventArgs e)
        {
            if (checkBoxDeleteProfile.Checked)
            {
                DelProf();
            }
            if (checkBoxLoadSceneWithAllInvItems.Checked)
            {
                GetItemsFromScene(_startLocSceneInfo.Name);
                AddChoosenItemsToInventory();
            }

            Process proc = new System.Diagnostics.Process();

            DirectoryInfo di = new DirectoryInfo(Config.ProjectPath);

            string executableFileName = Config.ExecutableFileName;

            if (executableFileName != string.Empty)
            {
                proc.StartInfo.FileName = Config.BinPath + "\\" + executableFileName;
            }
            else
            {
                DialogResult dr = this.openFileDialogExeFileName.ShowDialog();
                if (dr == System.Windows.Forms.DialogResult.OK)
                {
                    string filePath = openFileDialogExeFileName.FileName;
                    string file = Path.GetFileName(filePath);
                    proc.StartInfo.FileName = Config.BinPath + "\\" + file;

                    Config.ExecutableFileName = file;
                }
            }

            if (ProjectWithPackFile)
            {
                foreach (FileInfo fi in di.GetFiles())
                {
                    if ((fi.Name.Contains("Witches")) && (fi.Name.Contains("Legacy")) && (fi.Name.Contains(".exe")))
                    {
                        proc.StartInfo.FileName = fi.FullName;
                        break;
                    }
                }
            }
            else
            {
                if (File.Exists(proc.StartInfo.FileName))
                {
                    proc.Start();
                }
                else
                {
                    MessageBox.Show("Exeutable file not found!");
                }
            }
           

        }

        private void DelProf()
        {
            Process proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = Config.BinPath + "\\delete_profile.cmd";
            if (File.Exists(proc.StartInfo.FileName))
            {
                proc.Start();
            }
        }
        private void buttonRunDelProf_Click(object sender, EventArgs e)
        {
            DelProf();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Process proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = Config.BinPath + "\\ScenePlayer - Release.exe";
            if (File.Exists(proc.StartInfo.FileName))
            {
                proc.Start();
            }
        }

        private void buttonOpenLevelsXML_Click(object sender, EventArgs e)
        {
            Process proc = new System.Diagnostics.Process();

            string levelsFullFileName = _levelsXmlPath;

            if (File.Exists(levelsFullFileName))
            {
                proc.StartInfo.FileName = levelsFullFileName;
                proc.StartInfo.UseShellExecute = true;
                proc.Start();
            }
        }

        private void buttonOpenInventoryXML_Click(object sender, EventArgs e)
        {
            Process proc = new System.Diagnostics.Process();

          //  string inventoryFullFileName = Config.InventoryPath + "\\inventory.xml";
          //  string invResoursesFullFileName = Config.InventoryPath + "\\resources.xml";

            string inventoryFullFileName = _invFilename;
            string invResoursesFullFileName = _invResFilename;

            if (File.Exists(inventoryFullFileName))
            {
                proc.StartInfo.FileName = inventoryFullFileName;
                proc.StartInfo.UseShellExecute = true;
                proc.Start();

            }

            if (File.Exists(invResoursesFullFileName))
            {
                proc.StartInfo.FileName = invResoursesFullFileName;
                proc.StartInfo.UseShellExecute = true;
                proc.Start();
            }
        }

        private void buttonDiary_Click(object sender, EventArgs e)
        {
            EditDiaryForm f = new EditDiaryForm();
            f.Show();
        }

        private void buttonCheckAllResources_Click(object sender, EventArgs e)
        {
            List<string> resFilesList = AllResFilesOfProject();
            List<string> resFilesWithPngList = new List<string>();

            foreach (string curResFile in resFilesList)
            {
                XmlDocument resSceneDocXML = new XmlDocument(); 

                XmlElement resSceneRootXML;

                if (File.Exists(Config.BinPath + curResFile))
                {
                    string resFIlePath = Config.BinPath + curResFile;

                    Tools.TryToLoad(resSceneDocXML, resFIlePath);
                    //resSceneDocXML.Load(Config.BinPath + curResFile);

                    resSceneRootXML = (XmlElement)resSceneDocXML.DocumentElement;

                    CheckResourcesFilesOfScene(resSceneRootXML, resFilesWithPngList, resFIlePath);
                }
                else
                {
                    resFilesWithPngList.Add(Config.BinPath + curResFile + "|" + "File doesn't exist");
                }
            }

            if (resFilesWithPngList.Count > 0)
            {
                CheckResourcesFilesResult f = new CheckResourcesFilesResult(resFilesWithPngList);
                f.Show();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Congratulate! All resources files is valid!", "Resource validation message", MessageBoxButtons.OK);
            }
        }

        private void CheckResourcesFilesOfScene(XmlNode resRootNode, List<string> list, string resFile)
        {
            foreach (XmlNode node in resRootNode)
            {
                string scenePath = resFile.Substring(0, resFile.Length - AttString(resFile, '\\').Length);

                if (node.Name == "shader")
                {
                    CheckTexturesFilesToExists(node, list, resFile, scenePath);

                    if ((node.Attributes["texture_name"] != null) && (!IsValidString(node.Attributes["texture_name"].Value)))
                    {
                        list.Add(resFile + "|" + node.Attributes["texture_name"].Value);
                    }

                    if (IsShaderWithMipMaps(node))
                    {
                        string resFolder = resFile.Substring(0, resFile.LastIndexOf('\\'));
                        list.Add("mip_map = 1 ====> " + resFolder + "|" + node.Attributes["texture_name"].Value);
                    }
                }

                if (node.Name == "model")
                {
                    CheckModelsFilesToExists(node, list, resFile, scenePath);
                }
            }

        }

        private void CheckTexturesFilesToExists(XmlNode node, List<string> list, string resFile, string scenePath)
        {
            if (node.Attributes["texture_name"] != null)
            {
                string texturePath = scenePath + node.Attributes["texture_name"].Value + ".png";
                if (!File.Exists(texturePath))
                {
                    list.Add(resFile + "|" + node.Attributes["name"].Value + " .Textures file don't exist, but described in resources.xml");
                }
                else
                {
                    if (!CheckSizeToPowOfTwo(texturePath))
                    {
                        list.Add(texturePath + "|" + " IMAGE DON'T Power of Two!");
                    }
                }
            }
            else
            {
                list.Add(resFile + "|" + "'textures_file' node - don't exist");
            }
        }

        public bool CheckSizeToPowOfTwo(string texturePath)
        {
            bool flagWidth = false;
            bool flagHeight = false;
            bool flag = false;
            Image img = Image.FromFile(texturePath);

            int imgWidth = img.Width;
            int imgHeight = img.Height;
            int maxValue = 1024;

            for (int i = 1; Math.Pow(2, i) <= maxValue; i++)
            {
                if (Math.Pow(2, i) == imgWidth)
                {
                    flagWidth = true;
                }
                if (Math.Pow(2, i) == imgHeight)
                {
                    flagHeight = true;
                }
            }
            if ((flagWidth) && (flagHeight))
            {
                flag = true;
            }

            return flag;
        }


        private void CheckModelsFilesToExists(XmlNode node, List<string> list, string resFile, string scenePath)
        {
            if (node.Attributes["file_name"] != null)
            {
                string modelPath = scenePath + node.Attributes["file_name"].Value;
                if (!File.Exists(modelPath))
                {
                    list.Add(resFile + "|" + node.Attributes["name"].Value + ". Model file don't exist, but described in resources.xml");
                }
            }
            else
            {
                list.Add(resFile + "|" + "'file_name' node - don't exist");
            }
        }

        private bool IsShaderWithMipMaps(XmlNode node)
        {
            if ((node.Attributes["mip_map"] != null) && (node.Attributes["mip_map"].Value == "1"))
            {
                return true;
            }
            return false;
        }

        private bool IsValidString(String str)
        {
            string newStr;
            while ((newStr = str.Substring(0, 3)) == "..\\")
            {
                str = str.Substring(3);
            }

            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsLetter(str[i]) && char.IsUpper(str[i]))
                {
                    return false;
                }
                if ((!char.IsLetterOrDigit(str[i]) && (str[i] != '\\') && (str[i] != '_')))
                {
                    return false;
                }
            }
            return true;
        }

        private List<string> AllResFilesOfProject()
        {
            List<string> allResFiles = new List<string>();

            Scene scene = new Scene();

            LocationManager locationManager = new LocationManager(_levelsXmlPath);

            foreach (Location location in locationManager.Locations)
            {
                foreach (string resFileName in location.ResourcesFilePaths)
                {
                    if (!allResFiles.Contains(resFileName))
                    {
                        allResFiles.Add(resFileName);
                    }
                }
            }
            return allResFiles;
        }

        private void buttonCheckItem_Click(object sender, EventArgs e)
        {
            AddInventoryItemToChosen();
        }

        private void buttonUncheckItem_Click(object sender, EventArgs e)
        {
            DeleteInventoryItemFromChosen();
        }

        private void buttonUnCheckAll_Click(object sender, EventArgs e)
        {
            DeleteAllInventoryItemFromChosen();
        }

        private void buttonOpenTextsXML_Click(object sender, EventArgs e)
        {
            Process proc = new System.Diagnostics.Process();

            string fileNameTextsXml = Config.TextsPath + "\\texts.xml";

            if (File.Exists(fileNameTextsXml))
            {
                proc.StartInfo.FileName = fileNameTextsXml;
                proc.StartInfo.UseShellExecute = true;
                proc.Start();
            }
        }

        private void inExplorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string myDocspath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            System.Diagnostics.Process prc = new System.Diagnostics.Process();

            SceneInfo sceneInfo = (SceneInfo)listViewLevels.SelectedItems[0].Tag;

            Scene scene = new Scene();

            scene.LoadFromXml(Config.ScenesPath + "\\" + sceneInfo.SceneFilePath);

            string sceneDocspath = Config.ScenesPath + "\\" + sceneInfo.FolderName;

            prc.StartInfo.FileName = sceneDocspath;
            //            prc.StartInfo.Arguments = myDocspath;
            prc.Start();
        }

        private void inTotalcmdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SceneInfo sceneInfo = (SceneInfo)listViewLevels.SelectedItems[0].Tag;

            Scene scene = new Scene();

            scene.LoadFromXml(Config.ScenesPath + "\\" + sceneInfo.SceneFilePath);

            string sceneDocspath = Config.ScenesPath + "\\" + sceneInfo.FolderName;
            string totalCmdPath = @"c:\totalcmd\TOTALCMD.exe";

            if (File.Exists(totalCmdPath))
            {
                ProcessStartInfo psiOpt = new ProcessStartInfo(totalCmdPath, "/N /T /S /R=" + sceneDocspath + "");

                Process procCommand = Process.Start(psiOpt);
            }
        }

        private void _notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (WindowState == FormWindowState.Normal || WindowState == FormWindowState.Maximized)
                {

                    _OldFormState = WindowState;

                    WindowState = FormWindowState.Minimized;

                }
                else
                {
                    Show();
                    WindowState = _OldFormState;
                }
            }
        }

        void MainForm_Resize(object sender, EventArgs e)
        {
            if (checkBoxHideToTray.Checked)
            {
                if (FormWindowState.Minimized == WindowState)
                {
                    Hide();
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            InventoryManagerForm f = new InventoryManagerForm();
            f.Show();

            //             string str = "create";
            //             CreateAndEditInventoryItem f = new CreateAndEditInventoryItem(str, "qweewqqq");
            //             f.Show();
        }

        private void checkBoxSkipMenus_CheckedChanged(object sender, EventArgs e)
        {
            string skipMenusFilePath = Config.SkipMenusFileLocation + "\\" + Config.SkipMenusFileName;

            if (checkBoxSkipMenus.Checked == true)
            {
                if (!File.Exists(skipMenusFilePath))
                {
                    StreamWriter streamWriter = File.CreateText(skipMenusFilePath);
                    streamWriter.Close();
                }
            }
            else
            {
                if (File.Exists(skipMenusFilePath))
                {
                    File.Delete(skipMenusFilePath);
                }
            }
        }

        private void shaderViewerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SceneInfo sceneInfo = (SceneInfo)listViewLevels.SelectedItems[0].Tag;

            Scene scene = new Scene();

            string sceneFolder = Config.ScenesPath + "\\" + sceneInfo.FolderName;
            ShaderViewerForm f = new ShaderViewerForm(sceneFolder);
            f.Show();
        }

        private void checkBoxHideToTray_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHideToTray.Checked)
            {
                _notifyIcon.Visible = true;
            }
            else
            {
                _notifyIcon.Visible = false;
            }
        }

        private void buttonCreateTestScene_Click(object sender, EventArgs e)
        {
            CreateTestScene f = new CreateTestScene();
            f.Show();
        }

        private void buttonDeleteSearch_Click(object sender, EventArgs e)
        {
            textBox1.Text = String.Empty;
        }

        private void listViewLevels_DoubleClick(object sender, EventArgs e)
        {
            SceneInfo sceneInfo = (SceneInfo)listViewLevels.SelectedItems[0].Tag;

            Scene scene = new Scene();

            string listBoxLevelsPlace = sceneInfo.FolderName;

            if (sceneInfo.Name.Contains("_ho"))
            {
                listBoxLevelsPlace = sceneInfo.Name;
            }

            XmlNodeList levelPlaceNode = _levelsDocXml.SelectNodes("levels/stage/level[@place='" + listBoxLevelsPlace + "']");

            XmlNodeList levelSubNode = _levelsDocXml.SelectNodes("levels/stage/level/subscreens/" + listBoxLevelsPlace + "[@scene_folder='" + listBoxLevelsPlace + "']");

            string startLocTxtName = "start_location.txt";

            string startLocTxt = Config.ProjectPath + "\\" + startLocTxtName; 
                        
            if (!File.Exists(startLocTxt))
            {
                StreamWriter streamWriter = File.CreateText(startLocTxt);
                streamWriter.Close();
            }

            if ((levelPlaceNode.Count > 0) && (levelSubNode.Count == 0))
            {
                StreamReader streamReader;

                if (File.Exists(startLocTxt))
                {
                    streamReader = File.OpenText(startLocTxt);

                    string contents = streamReader.ReadToEnd();

                    streamReader.Close();

                    StreamWriter streamWriter = File.CreateText(startLocTxt);
                    
                    streamWriter.Write(listBoxLevelsPlace);

                    streamWriter.Close();
                }
                listViewLevels.SelectedItems[0].BackColor = Color.Aqua;
                checkBoxLoadSceneWithAllInvItems.Enabled = true;
                _startLocSceneInfo = (SceneInfo)listViewLevels.SelectedItems[0].Tag;
                for (int i = 0; i < listViewLevels.Items.Count; i++)
                {
                    if (listViewLevels.Items[i].Tag != listViewLevels.SelectedItems[0].Tag)
                    {
                        listViewLevels.Items[i].BackColor = Color.Transparent;
                    }
                }
            }
            if ((levelPlaceNode.Count == 0) && (levelSubNode.Count > 0))
            {
                labelCheckScenePlayer.Text = "Cant! This is subscreen";
            }
        }

        private void listViewLevels_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            buttonGetItemsFromScene.Enabled = true;
            UpdateSceneSubs();
        }

        private void UpdateSceneSubs()
        {
            listViewSubs.Items.Clear();
            for (int x = 0; x < listViewLevels.Items.Count; x++)
            {
                if (listViewLevels.Items[x].Selected)
                {
                    SceneInfo curScene = (SceneInfo)listViewLevels.Items[x].Tag;

                    Location curLocation = curScene.OwnerLocation;

                    foreach (SceneInfo sceneInfo in curLocation.AllSubscreens)
                    {
                        string sceneName = sceneInfo.Name;
                        
                        ListViewItem newItem = new ListViewItem();
                        
                        newItem.Text = sceneName;
                        
                        newItem.Tag = sceneInfo;
                        
                        listViewSubs.Items.Add(newItem);

                        listViewSubs.Refresh();

                    }
                }
             }

            if (listViewSubs.Items.Count > 0)
            {
                listViewSubs.Items[0].Selected = true;
                //listViewSubs.Select();
            }
            
        }

        private void AddSubToScenePlayer_Click(object sender, EventArgs e)
        {
            if (listViewSubs.Items.Count > 0)
            {
                SceneInfo sceneInfo = (SceneInfo)listViewSubs.SelectedItems[0].Tag;

                Scene scene = new Scene();

                scene.LoadFromXml(Config.ScenesPath + "\\" + sceneInfo.SceneFilePath);

                EditScenePlayerXML(sceneInfo.FolderName, sceneInfo.FileName);

                labelCheckScenePlayer.Text = "Successful";
            }
            else
            {
                MessageBox.Show("Select scene with subscreens first!");
            }
        }

        private void OpenSubXMLFile_Click(object sender, EventArgs e)
        {
            if (listViewSubs.Items.Count > 0)
            {
                Process proc = new System.Diagnostics.Process();

                SceneInfo sceneInfo = (SceneInfo)listViewSubs.SelectedItems[0].Tag;

                Scene scene = new Scene();

                scene.LoadFromXml(Config.ScenesPath + "\\" + sceneInfo.SceneFilePath);

                string sceneFullFileName = Config.ScenesPath + "\\" + sceneInfo.FolderName + "\\" + sceneInfo.FileName;

                if (File.Exists(sceneFullFileName))
                {
                    proc.StartInfo.FileName = sceneFullFileName;
                    proc.StartInfo.UseShellExecute = true;
                    proc.Start();
                }
            }
            else
            {
                MessageBox.Show("Select scene with subscreens first!");
            }
        }

        private void OpenSubScriptFile_Click(object sender, EventArgs e)
        {
            if (listViewSubs.Items.Count > 0)
            {
                Process proc = new System.Diagnostics.Process();

                SceneInfo sceneInfo = (SceneInfo)listViewSubs.SelectedItems[0].Tag;

                Scene scene = new Scene();

                scene.LoadFromXml(Config.ScenesPath + "\\" + sceneInfo.SceneFilePath);

                foreach (string scriptFileName in scene.ScriptFiles)
                {
                    string scriptFullFileName = Config.ScenesPath + "\\" + sceneInfo.FolderName + "\\" + scriptFileName;

                    if (!File.Exists(scriptFullFileName)) continue;

                    proc.StartInfo.FileName = scriptFullFileName;
                    proc.StartInfo.UseShellExecute = true;
                    proc.Start();
                }
            }
            else
            {
                MessageBox.Show("Select scene with subscreens first!");
            }
        }

        private void OpenSubResourcesFile_Click(object sender, EventArgs e)
        {
            if (listViewSubs.Items.Count > 0)
            {
                Process proc = new System.Diagnostics.Process();

                SceneInfo sceneInfo = (SceneInfo)listViewSubs.SelectedItems[0].Tag;

                Scene scene = new Scene();

                scene.LoadFromXml(Config.ScenesPath + "\\" + sceneInfo.SceneFilePath);

                string resourcesFullFileName = Config.ScenesPath + "\\" + sceneInfo.FolderName + "\\resources.xml";

                if (File.Exists(resourcesFullFileName))
                {
                    proc.StartInfo.FileName = resourcesFullFileName;
                    proc.StartInfo.UseShellExecute = true;
                    proc.Start();

                }
            }
            else
            {
                MessageBox.Show("Select scene with subscreens first!");
            }
        }

        private void CreateShaderSubsToolSprip_Click(object sender, EventArgs e)
        {
            if (listViewSubs.Items.Count > 0)
            {
                SceneInfo sceneInfo = (SceneInfo)listViewSubs.SelectedItems[0].Tag;

                CreateShaderForm f = new CreateShaderForm(sceneInfo);
                f.Show();
            }
            else
            {
                MessageBox.Show("Select scene with subscreens first!");
            }
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            if (listViewSubs.Items.Count > 0)
            {
                string myDocspath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                System.Diagnostics.Process prc = new System.Diagnostics.Process();

                SceneInfo sceneInfo = (SceneInfo)listViewSubs.SelectedItems[0].Tag;

                Scene scene = new Scene();

                scene.LoadFromXml(Config.ScenesPath + "\\" + sceneInfo.SceneFilePath);

                string sceneDocspath = Config.ScenesPath + "\\" + sceneInfo.FolderName;

                prc.StartInfo.FileName = sceneDocspath;
                //            prc.StartInfo.Arguments = myDocspath;
                prc.Start();
            }
            else
            {
                MessageBox.Show("Select scene with subscreens first!");
            }
        }

        private void shaderSubViewerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewSubs.Items.Count > 0)
            {
                SceneInfo sceneInfo = (SceneInfo)listViewSubs.SelectedItems[0].Tag;

                Scene scene = new Scene();

                string sceneFolder = Config.ScenesPath + "\\" + sceneInfo.FolderName;
                ShaderViewerForm f = new ShaderViewerForm(sceneFolder);
                f.Show();
            }
            else
            {
                MessageBox.Show("Select scene with subscreens first!");
            }
        }

        private void buttonGetScenesPositions_Click(object sender, EventArgs e)
        {
            string fileNameLevelsXml;
            string exMessagePath = string.Empty;

            if (!ProjectWithPackFile)
            {
                fileNameLevelsXml = Config.LevelsPath + "\\levels.xml";
                exMessagePath = " at data\\levels";
            }
            else
            {
                fileNameLevelsXml = Config.ProjectPath + "\\levels.xml";
                exMessagePath = " at root folder";
            }

            if (File.Exists(fileNameLevelsXml))
            {
                ScenesForm f = new ScenesForm(_levelsDocXml, fileNameLevelsXml);
                f.Show();
            }
            else
            {
                MessageBox.Show("levels.xml doesn't exist" + exMessagePath);
                Application.Exit();
            }
        }

        private void buttonTextUv_Click(object sender, EventArgs e)
        {
            TexturesFormManager f = new TexturesFormManager(Config, _levelsXmlPath);
            f.Show();
        }

        private void buttonSaveProfile_Click(object sender, EventArgs e)
        {
            SaveProfileForm saveProfileForm = new SaveProfileForm(Config.ProfileFolderName);
            saveProfileForm.Show();
        }

        private void buttonLoadProfile_Click(object sender, EventArgs e)
        {

        }

        
    }
}