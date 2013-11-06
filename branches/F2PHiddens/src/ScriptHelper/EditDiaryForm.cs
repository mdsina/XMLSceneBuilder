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
using HiddenObjectStudio.Core;
using HiddenObjectStudio.Core.LocationManagement;

namespace WindowsFormsApplication2
{
    public partial class EditDiaryForm : Form
    {
		private Config Config;

        public EditDiaryForm()
        {
            InitializeComponent();

			Config = new Config();

        }

        private void openDiarySceneXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process proc = new System.Diagnostics.Process();

            string diarySceneFullFileName = Config.DiaryPath + "\\scene.xml";

            if (File.Exists(diarySceneFullFileName))
            {
                proc.StartInfo.FileName = diarySceneFullFileName;
                proc.StartInfo.UseShellExecute = true;
                proc.Start();

            }
        }

        private void openDiarySceneScriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process proc = new System.Diagnostics.Process();

            string diaryScriptFullFileName = Config.DiaryPath + "\\script.lua";

            if (File.Exists(diaryScriptFullFileName))
            {
                proc.StartInfo.FileName = diaryScriptFullFileName;
                proc.StartInfo.UseShellExecute = true;
                proc.Start();

            }
        }

        private void openDiarySceneResourcesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process proc = new System.Diagnostics.Process();

            string diaryResourcesFullFileName = Config.DiaryPath + "\\resources.xml";

            if (File.Exists(diaryResourcesFullFileName))
            {
                proc.StartInfo.FileName = diaryResourcesFullFileName;
                proc.StartInfo.UseShellExecute = true;
                proc.Start();

            }
        }

        private void buttonAddDiaryToScenePlayer_Click(object sender, EventArgs e)
        {
            string fileNameScenePlayerXml = Config.BinPath + "ScenePlayer.xml";

            XmlDocument scenePlayerDocXml = new XmlDocument();
             
            scenePlayerDocXml.Load(fileNameScenePlayerXml);

            XmlElement scenePlayerResNodeXml = (XmlElement)scenePlayerDocXml.SelectSingleNode("scene_player_config");

            foreach (XmlNode scenePlayerNode in scenePlayerResNodeXml)
            {
                if (scenePlayerNode.Name == "resource_files")
                {
                    scenePlayerNode.RemoveAll();

                    XmlElement addedResourcesNode = scenePlayerDocXml.CreateElement("file");

                    addedResourcesNode.SetAttribute("file_name", "data\\gameplay\\main\\diary\\resources.xml");

                    scenePlayerNode.AppendChild(addedResourcesNode);
                    
                }
                if (scenePlayerNode.Name == "scene_file")
                {
                    XmlElement addedSceneNode = scenePlayerDocXml.SelectSingleNode("scene_player_config/scene_file") as XmlElement;

                    if (addedSceneNode != null)
                    {
                        addedSceneNode.SetAttribute("file_name", "data\\gameplay\\main\\diary\\scene.xml");
                    }
                   
                }
            }
            scenePlayerDocXml.Save(fileNameScenePlayerXml);
        }
        }

}
