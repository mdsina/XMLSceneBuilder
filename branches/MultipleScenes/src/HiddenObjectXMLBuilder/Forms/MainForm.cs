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
	
    public partial class MainForm : Form
    {
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
			checkBoxRebuildResources.Checked = SettingsAndConstants.RebuildResources;

            SrcRoot = SettingsAndConstants.SourcePath;
			DstRoot = SettingsAndConstants.DstScenesInGamePath;
			TextsXmlFileName = SettingsAndConstants.TextFileInGamePath;
			

			FillScenesList();


			RegistryKey regKey = Registry.CurrentUser.OpenSubKey("Software\\EleFun Tools");

			if (regKey == null)
			{
				MessageBox.Show("EleFun Tool не установлены!", "Ошипко", MessageBoxButtons.OK, MessageBoxIcon.Error);
				Close();
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
			SettingsAndConstants.RebuildResources = checkBoxRebuildResources.Checked;

			SettingsAndConstants.SourcePath = SrcRoot;
			SettingsAndConstants.DstScenesInGamePath = DstRoot;
			SettingsAndConstants.TextFileInGamePath = TextsXmlFileName;
		}

		private void FillScenesList()
		{
			buttonStart.Enabled = true;

			if (!Directory.Exists(SrcRoot))
			{
				listViewScenes.Items.Clear();
				listViewScenes.CheckBoxes = false;
				listViewScenes.Items.Add(new ListViewItem("Не найдена исходная папка: " + SrcRoot));
				buttonStart.Enabled = false;
				return;
			}

			string[] sceneNames = Directory.GetDirectories(SrcRoot);

			if (sceneNames.Length == 0)
			{
				listViewScenes.Items.Clear();
				listViewScenes.CheckBoxes = false;
				listViewScenes.Items.Add(new ListViewItem("Исходная папка пуста"));
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

					ListViewItem item = new ListViewItem();
					item.Tag = sceneBuildInfo;

					if (di.Name.Contains(" "))
					{
						item.Text = di.Name + " - в имени папки содержится пробел!";

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

								item.Text = di.Name + " - сабскрин";
								item.Checked = !Directory.Exists(dstPath);
								item.ForeColor = Color.Blue;
							}
							else
							{
								item.Text = di.Name;
								item.Checked = !Directory.Exists(dstPath);
							}
						}
						else
						{
							item.Text = di.Name + " - обнаружен файл final.txt, исключаем, по умолчанию, из сборки";
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

			Log("Делаю сцену '" + item.SceneName + "' из папки '" + srcFolder + "'");

			Builder builder = new Builder();

			BuildOptions options = new BuildOptions();

			DirectoryInfo diSrc = new DirectoryInfo(srcFolder);
			options.srcFolder = diSrc.FullName;

			DirectoryInfo diDst = new DirectoryInfo(dstFolder);
			options.dstFolder = diDst.FullName;

			options.textXmlFileName = textsXmlFileName;

			options.sceneName = item.SceneName;

			options.rebuildScene = checkBoxRebuildScene.Checked;

			options.rebuildItemsFile = checkBoxRebuildItems.Checked;
			options.rebuildHintsFile = checkBoxRebuildHints.Checked;

			options.rebuildTP = checkBoxRebuildTP.Checked;
			options.buildActiveZonesVisible = checkBoxActiveZonesVisible.Checked;
			options.buildAlphaSelection = checkBoxBuildAlphaSelection.Checked;

			options.rebuildTexts = checkBoxRebuildTexts.Checked;

			options.rebuildResourcesFile = checkBoxRebuildResources.Checked;

			options.isSubscreen = item.IsSubscreen;
				
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

#region Event Handlers

		private void btnStart_Click(object sender, EventArgs e)
		{
			string finalMessage = "Успешно выполнено.";

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

				Close();

				return;
			}

			MessageBox.Show(finalMessage, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

			Close();

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
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.Filter = "Texts.xml|texts.xml|Xml files|*.xml|All files|*.*";
			
			FileInfo fi = new FileInfo(TextsXmlFileName);
			
			dialog.InitialDirectory = fi.DirectoryName;
			dialog.CheckPathExists = true;

			if (DialogResult.OK == dialog.ShowDialog())
			{
				textBoxTextsXmlLocation.Text = dialog.FileName;
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


	}

    class SceneBuildInfo
    {
        public string SceneName;
        public bool IsSubscreen;
    };

}
