using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using HiddenObjectStudio.Core;
using HiddenObjectStudio.Core.LocationManagement;
using System.IO;
using System.Threading;

namespace WindowsFormsApplication2
{
    public partial class ScenesForm : Form
    {
        private XmlDocument _levelsDocXml;
        private string _fileNameLevelsXml;
        Config Config;
        
        public ScenesForm(XmlDocument levelsXmlDoc, string levelsFilePath)
        {
            Config = new Config();
            InitializeComponent();
            _levelsDocXml = levelsXmlDoc;
            _fileNameLevelsXml = levelsFilePath;
        }

        private void buttonGetScenes_Click(object sender, EventArgs e)
        {
            listBoxScenes.Items.Clear();
            ReadLevelsXMLFile(_fileNameLevelsXml);
        }

        private void ReadLevelsXMLFile(string fileNameLevelsXml)
        {
            XmlElement levelsStageNodeXml = (XmlElement)_levelsDocXml.SelectSingleNode("levels/stage");

            LocationManager lm = new LocationManager(fileNameLevelsXml);
//##
//             foreach (SceneInfo sceneInfo in lm.AllMainScenes)
//             {
//                 string sceneName = string.Empty;
// 
//                 if (sceneInfo.GddName != string.Empty)
//                 {
//                     sceneName = sceneInfo.GddName;
//                 }
//                 else
//                 {
//                     sceneName = sceneInfo.Name;
//                 }
//                 listBoxScenes.DisplayMember = "Name";
//                 if ((!checkBoxDm.Checked) && (!checkBoxSe.Checked) && (!checkBoxCe.Checked))
//                 {
//                     listBoxScenes.Items.Add(sceneInfo);
//                 }
// 
//                 if (checkBoxDm.Checked)
//                 {
//                     if (sceneInfo.GamePosition == "dm")
//                     {
//                         listBoxScenes.Items.Add(sceneInfo);
//                         
//                     }
//                 }
// 
//                 if (checkBoxSe.Checked)
//                 {
//                     if (sceneInfo.GamePosition == "se")
//                     {
//                         listBoxScenes.Items.Add(sceneInfo);
//                     }
//                 }
// 
//                 if (checkBoxSe.Checked)
//                 {
//                     if (sceneInfo.GamePosition == "ce")
//                     {
//                         listBoxScenes.Items.Add(sceneInfo);
//                     }
//                 }
//                 listBoxScenes.Refresh();
//             }

            
        }

        private void buttonSaveToFile_Click(object sender, EventArgs e)
        {
            DialogResult dr = this.folderBrowserDialog1.ShowDialog();

            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                string file = folderBrowserDialog1.SelectedPath;

                string fileLocTxt = file + "\\scenes.txt";
                int attemptsCount = 10;

                bool success = false;

                do
                {
                    try
                    {
                        StreamWriter streamWriter = File.CreateText(fileLocTxt);

                        foreach (object o in listBoxScenes.Items)
                        {
                            SceneInfo sc = (SceneInfo)o;
                            string scenePath = "data\\scenes\\" + sc.FolderName + "\\";
                            streamWriter.WriteLine(scenePath);
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

            }
        }

        private void listBoxScenes_SelectedIndexChanged(object sender, EventArgs e)
        {
            SceneInfo sc = (SceneInfo)listBoxScenes.SelectedItem;
           // MessageBox.Show(sc.GamePosition);
        }
    }
}
