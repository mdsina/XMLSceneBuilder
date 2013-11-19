using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Diagnostics;
using Microsoft.Win32;
using HiddenObjectStudio.Core;

namespace HiddenObjectsXMLBuilder
{
    public struct Parameters
        {
            public string ItemName;
            public string pngPath;
            public string hintPath;
            public string scenesPath;
            public string textsPath;
            public string LevelsFilePath;
        }
	
    public partial class MainForm : Form
    {
        List<Parameters> BuilderParametresPath = new List<Parameters>();

		private string SrcRoot
		{
			get	{ return textBoxSrcPath.Text; }
			set { textBoxSrcPath.Text = value; }
		}

		private string DstRoot
		{
			get { return textBoxDstPath.Text; }
			set { textBoxDstPath.Text = value; }
		}

		private string TextsXmlFileName
		{
			get { return textBoxTextsXmlLocation.Text; }
			set { textBoxTextsXmlLocation.Text = value; }
		}

        private string LevelsXmlFileName
        {
            get { return textBoxLevelsXmlLocation.Text; }
            set { textBoxLevelsXmlLocation.Text = value; }
        }

        private string NavigationSystemPath
        {
            get { return textBoxNavigation.Text; }
            set { textBoxNavigation.Text = value; }
        }

        private string UserName
        {
            get { return textBoxName.Text; }
            set { textBoxName.Text = value; }
        }
    
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
			if ((WindowState = SettingsAndConstants.MainFormState) == FormWindowState.Normal)
			{
				Location = SettingsAndConstants.MainFormPosition.Location;
				Width = SettingsAndConstants.MainFormPosition.Width;
				Height = SettingsAndConstants.MainFormPosition.Height;
			}

			checkBoxRebuildTP.Checked = SettingsAndConstants.RebuildTP;
			checkBoxActiveZonesVisible.Checked = SettingsAndConstants.ActiveZonesVisible;
			checkBoxBuildAlphaSelection.Checked = SettingsAndConstants.BuildAlphaSelection;
			checkBoxRebuildTexts.Checked = SettingsAndConstants.RebuildTexts;
			checkBoxRebuildItems.Checked = SettingsAndConstants.RebuildItems;
			checkBoxRebuildHints.Checked = SettingsAndConstants.RebuildHints;
			checkBoxRebuildScene.Checked = SettingsAndConstants.RebuildScene;
            checkBoxRebuildLevels.Checked = SettingsAndConstants.RebuildLevels;
            checkBoxNavigation.Checked = SettingsAndConstants.RebuildNavigation;
            
			checkBoxRebuildResources.Checked = SettingsAndConstants.RebuildResources;
            checkBoxGlints.Checked = SettingsAndConstants.RebuildGlints;

            SrcRoot = SettingsAndConstants.SourcePath;
			DstRoot = SettingsAndConstants.DstScenesInGamePath;
			TextsXmlFileName = SettingsAndConstants.TextFileInGamePath;
            LevelsXmlFileName = SettingsAndConstants.LevelsFilePath;
            NavigationSystemPath = SettingsAndConstants.NavigationFilePath;
           
            UserName = SettingsAndConstants.UserName;

			FillScenesList();

			RegistryKey regKey = Registry.CurrentUser.OpenSubKey("Software\\EleFun Tools");

			if (regKey == null)
			{
				MessageBox.Show("EleFun Tool not installed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				Close();
			}

            if (File.Exists(Environment.CurrentDirectory + "\\Parametres.xml"))
            {
                XmlDocument Parametres = new XmlDocument();
                XmlElement ParametersRoot;
                Parametres.Load(Environment.CurrentDirectory + "\\Parametres.xml");

                ParametersRoot = (XmlElement)Parametres.FirstChild;

                for (int i = 0; i < ParametersRoot.ChildNodes.Count; i++ )
                {
                    Parameters _parameters;
                    _parameters.ItemName = ParametersRoot.ChildNodes[i].Name;
                    _parameters.hintPath = "";
                    _parameters.pngPath = "";
                    _parameters.textsPath = "";
                    _parameters.LevelsFilePath = "";
                    _parameters.scenesPath = "";

                    for (int j = 0; j < ParametersRoot.ChildNodes[i].ChildNodes.Count; j++ )
                    {
                        switch (ParametersRoot.ChildNodes[i].ChildNodes[j].Name)
                        {
                            case "NavigationSystemPath":
                                _parameters.hintPath = ParametersRoot.ChildNodes[i].ChildNodes[j].Attributes["value"].Value;
                                break;
                            case "SrcRoot":
                                _parameters.pngPath = ParametersRoot.ChildNodes[i].ChildNodes[j].Attributes["value"].Value;
                                break;
                            case "TextsXmlFileName":
                                _parameters.textsPath = ParametersRoot.ChildNodes[i].ChildNodes[j].Attributes["value"].Value;
                                break;
                            case "LevelsXmlFileName":
                                _parameters.LevelsFilePath = ParametersRoot.ChildNodes[i].ChildNodes[j].Attributes["value"].Value;
                                break;
                            case "DstRoot":
                                _parameters.scenesPath = ParametersRoot.ChildNodes[i].ChildNodes[j].Attributes["value"].Value;
                                break;
                        }
                    }

                    ToolStripMenuItem _Item = new ToolStripMenuItem();

                    BuilderParametresPath.Add(_parameters);

                    int _index = BuilderParametresPath.IndexOf(_parameters);

                    _Item.Text = BuilderParametresPath[_index].ItemName;

                    _Item.Click += new EventHandler(delegate(Object o, EventArgs a)
                    {
                        SrcRoot = BuilderParametresPath[_index].pngPath;
                        DstRoot = BuilderParametresPath[_index].scenesPath;
                        TextsXmlFileName = BuilderParametresPath[_index].textsPath;
                        NavigationSystemPath = BuilderParametresPath[_index].hintPath;
                        LevelsXmlFileName = BuilderParametresPath[_index].LevelsFilePath;
                    });

                    ToolStripMenuItem _DeleteItem = new ToolStripMenuItem();
                    _DeleteItem.Text = "Delete";
                    _DeleteItem.Name = "Delete";
                    _DeleteItem.Click += new EventHandler(delegate(Object o, EventArgs a)
                    {
                        if (File.Exists(Environment.CurrentDirectory + "\\Parametres.xml"))
                        {
                            XmlDocument _ParametresXmlDoc;
                            XmlElement _ParametresRoot;
                            string _ParametresFileName;

                            _ParametresFileName = Environment.CurrentDirectory + "\\Parametres.xml";

                            _ParametresXmlDoc = new XmlDocument();
                            _ParametresXmlDoc.Load(_ParametresFileName);

                            _ParametresRoot = (XmlElement)_ParametresXmlDoc.FirstChild;

                            for (int j = 0; j < _ParametresRoot.ChildNodes.Count; j++)
                            {
                                if (_ParametresRoot.ChildNodes[j].Name == _Item.Text)
                                {
                                    _ParametresRoot.RemoveChild(_ParametresRoot.ChildNodes[j]);
                                    break;
                                }
                            }

                            _ParametresXmlDoc.Save(_ParametresFileName);
                        }

                        BuilderParametresPath.Remove(_parameters);
                        toolStripMenuItemProjects.DropDownItems.Remove(_Item);

                    });

                    _Item.DropDownItems.Add(_DeleteItem);

                    toolStripMenuItemProjects.DropDownItems.Add(_Item);
                }
            }
        }

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if ((SettingsAndConstants.MainFormState = WindowState) == FormWindowState.Normal)
			{
				SettingsAndConstants.MainFormPosition.Location = Location;
				SettingsAndConstants.MainFormPosition.Width = Width;
				SettingsAndConstants.MainFormPosition.Height = Height;
			}

			SettingsAndConstants.RebuildTP = checkBoxRebuildTP.Checked;
			SettingsAndConstants.ActiveZonesVisible = checkBoxActiveZonesVisible.Checked;
			SettingsAndConstants.BuildAlphaSelection = checkBoxBuildAlphaSelection.Checked;
			SettingsAndConstants.RebuildTexts = checkBoxRebuildTexts.Checked;
			SettingsAndConstants.RebuildItems = checkBoxRebuildItems.Checked;
			SettingsAndConstants.RebuildHints = checkBoxRebuildHints.Checked;
			SettingsAndConstants.RebuildScene = checkBoxRebuildScene.Checked;
            SettingsAndConstants.RebuildLevels = checkBoxRebuildLevels.Checked;
			SettingsAndConstants.RebuildResources = checkBoxRebuildResources.Checked;
            SettingsAndConstants.RebuildNavigation = checkBoxNavigation.Checked;

			SettingsAndConstants.SourcePath = SrcRoot;
			SettingsAndConstants.DstScenesInGamePath = DstRoot;
			SettingsAndConstants.TextFileInGamePath = TextsXmlFileName;
            SettingsAndConstants.LevelsFilePath = LevelsXmlFileName;
            SettingsAndConstants.NavigationFilePath = NavigationSystemPath;
            SettingsAndConstants.UserName = UserName;

            if (BuilderParametresPath.Count != 0)
            {
                Options tOptions = new Options(BuilderParametresPath);
                tOptions.Save();
            }
		}

		private void FillScenesList()
		{
			buttonStart.Enabled = true;

            uint k = 0;

			if (!Directory.Exists(SrcRoot))
			{
                if (k == 0) listViewScenes.Items.Clear();
				listViewScenes.Items.Clear();
				listViewScenes.CheckBoxes = false;
                listViewScenes.Items.Add(new ListViewItem("Folder not found 'png': " + SrcRoot));
				buttonStart.Enabled = false;
                k++;
			}

            if (!Directory.Exists(DstRoot))
            {
                if (k == 0) listViewScenes.Items.Clear();
                listViewScenes.Items.Clear();
                listViewScenes.CheckBoxes = false;
                listViewScenes.Items.Add(new ListViewItem("Folder not found 'scenes': " + DstRoot));
                buttonStart.Enabled = false;
                k++;
            }

            if (!Directory.Exists(TextsXmlFileName) && checkBoxRebuildTexts.Checked)
            {
                if (k == 0) listViewScenes.Items.Clear();
                listViewScenes.CheckBoxes = false;
                listViewScenes.Items.Add(new ListViewItem("Folder not found 'texts': " + TextsXmlFileName));
                buttonStart.Enabled = false;
                k++;
            }

            if (!Directory.Exists(NavigationSystemPath) && checkBoxNavigation.Checked)
            {
                if (k == 0) listViewScenes.Items.Clear();
                listViewScenes.CheckBoxes = false;
                listViewScenes.Items.Add(new ListViewItem("Folder not found 'hint_system': " + NavigationSystemPath));
                buttonStart.Enabled = false;
                k++;
            }

            if (!File.Exists(LevelsXmlFileName) && checkBoxRebuildLevels.Checked)
            {
                if (k == 0)  listViewScenes.Items.Clear();
                listViewScenes.CheckBoxes = false;
                listViewScenes.Items.Add(new ListViewItem("File not found 'levels.xml': " + LevelsXmlFileName));
                buttonStart.Enabled = false;
                k++;
            }

            if ( k != 0)
            {
                return;
            }

			string[] sceneNames = Directory.GetDirectories(SrcRoot);

			if (sceneNames.Length == 0)
			{
				listViewScenes.Items.Clear();
				listViewScenes.CheckBoxes = false;
				listViewScenes.Items.Add(new ListViewItem("Folder is empty"));
			}
			else
			{
				listViewScenes.Items.Clear();
				listViewScenes.CheckBoxes = true;

				foreach (string scnName in sceneNames)
				{
					DirectoryInfo di = new DirectoryInfo(scnName);
					string dstPath = DstRoot + "\\" + di.Name;

					if (di.Name.ToLower().Contains(".svn")) continue;

					SceneBuildInfo sceneBuildInfo = new SceneBuildInfo();
					sceneBuildInfo.SceneName = di.Name;
					sceneBuildInfo.IsSubscreen = false;
                    sceneBuildInfo.isMinigame = false;

					ListViewItem item = new ListViewItem();
					item.Tag = sceneBuildInfo;

					if (di.Name.Contains(" "))
					{
                        item.Text = di.Name + " - space in the folder name!";

						item.Checked = false; //!Directory.Exists(dstPath);
						item.ForeColor = Color.Red;
					}
					else
					{
						if (!File.Exists(Path.Combine(dstPath, "final.txt")))
						{
							if (IsSubscreenScene(di.Name))
							{
								sceneBuildInfo.IsSubscreen = true;

								item.Text = di.Name + " - subscreen";
								//item.Checked = !Directory.Exists(dstPath);

                                if (IsMinigameScene(di.Name))
                                {
                                    sceneBuildInfo.isMinigame = true;
                                    item.Text += "-minigame";
                                    item.ForeColor = Color.DarkRed;
                                }
                                else
                                {
                                    item.ForeColor = Color.Blue;
                                }
								
							}
                            else if (IsMinigameScene(di.Name))
							{
                                sceneBuildInfo.isMinigame = true;
                                item.Text = di.Name + " - minigame"; ;
                                item.ForeColor = Color.DarkGoldenrod;
                                //item.Checked = !Directory.Exists(dstPath);
                            }
                            else
                            {
                                item.Text = di.Name;
                            }
						}
						else
						{
							item.Text = di.Name + " - File 'final.txt' was found, remove from build";
							item.Checked = false;
							item.ForeColor = Color.LightGray;
						}
					}

					listViewScenes.Items.Add(item);
				}
                listViewScenes.Items[0].Focused = true;
                listViewScenes.Items[0].Selected = true;
			}
		}

		private void Build(SceneBuildInfo item)
		{
			string srcFolder = Path.Combine(SrcRoot, item.SceneName);
			string dstFolder = Path.Combine(DstRoot, item.SceneName);
			string textsXmlFileName = textBoxTextsXmlLocation.Text;
            string levelsXmlFileName = textBoxLevelsXmlLocation.Text;
            string navigationFilePath = textBoxNavigation.Text;
            string UserName = textBoxName.Text;

			if (Directory.Exists(dstFolder))
			{
				//					Tool.CleanDirectory(dstFolder);

				// 					string msg = "The destination folder " + dstFolder + " is already exists and may contain some USEFUL data. \nDo you really want to overwrite it's content?";
				// 					if (DialogResult.Yes == MessageBox.Show(msg, "Warning", MessageBoxButtons.YesNo,	MessageBoxIcon.Question))
				// 					{
				// 					}
				// 					else
				// 					{
				// 						continue;
				// 					}
			}
			else
			{
				Directory.CreateDirectory(dstFolder);
			}

			Log("Build scene '" + item.SceneName + "' from '" + srcFolder + "'");

			Builder builder = new Builder();

			BuildOptions options = new BuildOptions();

			DirectoryInfo diSrc = new DirectoryInfo(srcFolder);
			options.srcFolder = diSrc.FullName;

			DirectoryInfo diDst = new DirectoryInfo(dstFolder);
			options.dstFolder = diDst.FullName;

			options.textXmlFileName = textsXmlFileName;
            options.levelsXmlFileName = levelsXmlFileName;
            options.navigationFilePath = navigationFilePath;
            options.UserName = UserName;

			options.sceneName = item.SceneName;

			options.rebuildScene = checkBoxRebuildScene.Checked;

			options.rebuildItemsFile = checkBoxRebuildItems.Checked;
			options.rebuildHintsFile = checkBoxRebuildHints.Checked;

			options.rebuildTP = checkBoxRebuildTP.Checked;
			options.buildActiveZonesVisible = checkBoxActiveZonesVisible.Checked;
			options.buildAlphaSelection = checkBoxBuildAlphaSelection.Checked;

			options.rebuildTexts = checkBoxRebuildTexts.Checked;
            options.rebuildLevels = checkBoxRebuildLevels.Checked;
            options.rebuildNavigation = checkBoxNavigation.Checked;

			options.rebuildResourcesFile = checkBoxRebuildResources.Checked;

			options.isSubscreen = item.IsSubscreen;
            options.isMinigame = item.isMinigame;

            options.rebuildGlintsFile = checkBoxGlints.Checked;

            options.ee = checkBoxEE.Checked;
            options.hummingBird = checkBoxHummingBirds.Checked;
            options.someFuncs = checkBoxSomeFuncs.Checked;
            options.fadeAnimation = checkBoxFadeAnimations.Checked;
            
            options.morfing = checkBoxMorfing.Checked && checkBoxSomeFuncs.Checked;

			builder.Build2(options);
		}

		private void Log(string str)
		{
			textBoxLog.AppendText("\r\n" + str);
		}

		public string AppendSlashIfNeeded(string str)
		{
			if (str[str.Length - 1] == '\\') return str;

			return str + '\\';
		}

		private bool IsSubscreenScene(string sceneName)
		{
			return sceneName.Contains("_sub");
		}

        private bool IsMinigameScene(string sceneName)
        {
            return (sceneName.Contains("_mg") || sceneName.Contains("_minigame") || sceneName.Contains("_mini_game") || sceneName.Contains("_puzzle"));
        }

#region Event Handlers

        private void StartBuild()
        {
            string finalMessage = "Success.";

            try
            {
                foreach (ListViewItem item in listViewScenes.Items)
                {
                    if (item.Checked)
                    {
                        Build((SceneBuildInfo)item.Tag);
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);

                //Close();

                return;
            }

            MessageBox.Show(finalMessage, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

            //Close();
        }

		private void btnStart_Click(object sender, EventArgs e)
		{
            StartBuild();
		}

		private void buttonBrowseSourcePath_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog dialog = new FolderBrowserDialog();

			DirectoryInfo di = new DirectoryInfo(SrcRoot);
			dialog.SelectedPath = di.FullName;
	
			if (DialogResult.OK == dialog.ShowDialog())
			{
				SrcRoot = dialog.SelectedPath;
				FillScenesList();
			}
		}

		private void buttonBrowseDstPath_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog dialog = new FolderBrowserDialog();
			
			DirectoryInfo di = new DirectoryInfo(DstRoot);
			dialog.SelectedPath = di.FullName;

			if (DialogResult.OK == dialog.ShowDialog())
			{
				DstRoot = dialog.SelectedPath;
				FillScenesList();
			}
		}
		
		private void buttonTextsXmlBrowse_Click(object sender, EventArgs e)
		{
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            DirectoryInfo di = new DirectoryInfo(SrcRoot);
            dialog.SelectedPath = di.FullName;

            if (DialogResult.OK == dialog.ShowDialog())
            {
                textBoxTextsXmlLocation.Text = dialog.SelectedPath;
                FillScenesList();
            }
		}

		private void textBoxSrcPath_TextChanged(object sender, EventArgs e)
		{

			    FillScenesList();
		}

		private void textBoxDstPath_TextChanged(object sender, EventArgs e)
		{
			    FillScenesList();
		}

		private void buttonSelectAll_Click(object sender, EventArgs e)
		{
			foreach (ListViewItem item in listViewScenes.Items)
			{
				item.Checked = true;
			}
		}

		private void buttonClearAll_Click(object sender, EventArgs e)
		{
			foreach (ListViewItem item in listViewScenes.Items)
			{
				item.Checked = false;
			}

		}

        private void listViewScenes_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            buttonStart.Enabled = false;

            foreach (ListViewItem item in listViewScenes.Items)
            {
                if (item.Checked) buttonStart.Enabled = true;
            }
        }

		private void radioButtonRebuildScene_CheckedChanged(object sender, EventArgs e)
		{
			checkBoxRebuildItems.Enabled = checkBoxRebuildScene.Checked;
			checkBoxRebuildHints.Enabled = checkBoxRebuildScene.Checked;
		}

		private void checkBoxRebuildTP_CheckedChanged(object sender, EventArgs e)
		{
			checkBoxBuildAlphaSelection.Enabled = 
			checkBoxActiveZonesVisible.Enabled = 
			checkBoxRebuildTP.Checked;
		}

#endregion

        private void checkBoxSomeFuncs_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxMorfing.Enabled = checkBoxSomeFuncs.Checked;
        }

        private void buttonLevelsXmlBrowse_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Levels.xml|levels.xml|Xml files|*.xml|All files|*.*";

            FileInfo fi = new FileInfo(TextsXmlFileName);

            dialog.InitialDirectory = fi.DirectoryName;
            dialog.CheckPathExists = true;

            if (DialogResult.OK == dialog.ShowDialog())
            {
                textBoxLevelsXmlLocation.Text = dialog.FileName;
            }
        }

        private void textBoxTextsXmlLocation_TextChanged(object sender, EventArgs e)
        {
            if (checkBoxRebuildTexts.Checked)
                FillScenesList();
        }

        private void textBoxLevelsXmlLocation_TextChanged(object sender, EventArgs e)
        {
            if (checkBoxRebuildLevels.Checked)
                FillScenesList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            DirectoryInfo di = new DirectoryInfo(SrcRoot);
            dialog.SelectedPath = di.FullName;

            if (DialogResult.OK == dialog.ShowDialog())
            {
                textBoxNavigation.Text = dialog.SelectedPath;
                FillScenesList();
            }
        }

        private void textBoxNavigation_TextChanged(object sender, EventArgs e)
        {
            if (checkBoxNavigation.Checked)
                FillScenesList();
        }

        private void checkBoxRebuildLevels_CheckedChanged(object sender, EventArgs e)
        {
            FillScenesList();
        }

        private void checkBoxRebuildTexts_CheckedChanged(object sender, EventArgs e)
        {
            FillScenesList();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            FillScenesList();
        }

        private void toolStripMenuItemAdd_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ProcessMenuitems()
        {
            ToolStripMenuItem _Item = new ToolStripMenuItem();

            string[] split = textBoxSrcPath.Text.Split(new Char[] { '\\' });

            for (int i = 0; i < split.Length; i++)
            {
                if (split[i] == "png")
                {
                    _Item.Text = split[i - 1];
                    break;
                }
            }

            bool _flag = false;

            if (BuilderParametresPath.Count != 0)
            {
                for (int i = 0; i < BuilderParametresPath.Count; i++)
                {
                    if (BuilderParametresPath[i].ItemName == _Item.Text)
                    {
                        _flag = true;
                    }
                }
            }

            if (!_flag)
            {
                Parameters _t_Parametres;
                _t_Parametres.ItemName = _Item.Text;
                _t_Parametres.pngPath = textBoxSrcPath.Text;
                _t_Parametres.hintPath = textBoxNavigation.Text;
                _t_Parametres.LevelsFilePath = textBoxLevelsXmlLocation.Text;
                _t_Parametres.textsPath = textBoxTextsXmlLocation.Text;
                _t_Parametres.scenesPath = textBoxDstPath.Text;

                BuilderParametresPath.Add(_t_Parametres);
                int _index = BuilderParametresPath.IndexOf(_t_Parametres);

                _Item.Click += new EventHandler(delegate(Object o, EventArgs a)
                {
                    SrcRoot = BuilderParametresPath[_index].pngPath;
                    DstRoot = BuilderParametresPath[_index].scenesPath;
                    TextsXmlFileName = BuilderParametresPath[_index].textsPath;
                    NavigationSystemPath = BuilderParametresPath[_index].hintPath;
                    LevelsXmlFileName = BuilderParametresPath[_index].LevelsFilePath;

                    /*if (a.Button == MouseButtons.Right)
                    {
                        ContextMenuStrip docMenu = new ContextMenuStrip();

                        ToolStripMenuItem deleteLabel = new ToolStripMenuItem();
                        deleteLabel.Text = "Delete";

                        docMenu.Items.AddRange(new ToolStripMenuItem[] { deleteLabel });
                        docMenu.Show(MousePosition);
                    }*/
                });

                ToolStripMenuItem _DeleteItem = new ToolStripMenuItem();
                _DeleteItem.Text = "Delete";
                _DeleteItem.Name = "Delete";
                _DeleteItem.Click += new EventHandler(delegate(Object o, EventArgs a)
                {
                    if (File.Exists(Environment.CurrentDirectory + "\\Parametres.xml"))
                    {
                        XmlDocument _ParametresXmlDoc;
                        XmlElement _ParametresRoot;
                        string _ParametresFileName;

                        _ParametresFileName = Environment.CurrentDirectory + "\\Parametres.xml";

                        _ParametresXmlDoc = new XmlDocument();
                        _ParametresXmlDoc.Load(_ParametresFileName);

                        _ParametresRoot = (XmlElement)_ParametresXmlDoc.FirstChild;

                        for (int i = 0; i < _ParametresRoot.ChildNodes.Count; i++)
                        {
                            if (_ParametresRoot.ChildNodes[i].Name == _Item.Text)
                            {
                                _ParametresRoot.RemoveChild(_ParametresRoot.ChildNodes[i]);
                                break;
                            }
                        }

                        _ParametresXmlDoc.Save(_ParametresFileName);
                    }

                    BuilderParametresPath.Remove(_t_Parametres);
                    toolStripMenuItemProjects.DropDownItems.Remove(_Item);

                });

                _Item.DropDownItems.Add(_DeleteItem);

                toolStripMenuItemProjects.DropDownItems.Add(_Item);

                MessageBox.Show(_Item.Text + " added to Projects");
            }
        }

        private void buttonSaveParametres_Click(object sender, MouseEventArgs e)
        {
            ProcessMenuitems();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.S))
            {
                ProcessMenuitems();
                return true;
            }
            if (keyData == (Keys.Control | Keys.B))
            {
                StartBuild();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

	}

    class SceneBuildInfo
    {
        public string SceneName;
        public bool IsSubscreen;
        public bool isMinigame;
    };

}
