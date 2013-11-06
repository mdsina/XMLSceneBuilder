using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using HiddenObjectStudio.Core.SceneManagement;
using HiddenObjectStudio.Core.LocationManagement;
using HiddenObjectStudio.Core;
using System.IO;

namespace WindowsFormsApplication2
{
    public partial class CheckResourcesFilesResult : Form
    {
        private Config Config;
        List<string> outputResList;

        public CheckResourcesFilesResult(List<string> takenOutputList)
        {
            InitializeComponent();

            Config = new Config();

            this.outputResList = takenOutputList;
            FillResourcesTreeView(outputResList);

            this.openFileDialog1.Filter =
                "XML (*.XML)|*.XML|" +
                "All files (*.*)|*.*";

            this.openFileDialog1.Multiselect = false;
            this.openFileDialog1.Title = "Select DDSTexturePreparer.xml!";
        }
        private void FillResourcesTreeView(List<string> resList)
        {

            if (resList.Count > 0)
            {
                foreach (string str in resList)
                {
                    string[] mass = str.Split('|');
                    string firtspart = mass[0];
                    string secondpart = mass[1];

                    ListViewItem newItem = new ListViewItem();
                    newItem.Text = firtspart;
                    newItem.SubItems.Add(secondpart);
                    newItem.SubItems.Add("");
                    listViewPngResources.Items.Add(newItem);
                    listViewPngResources.Refresh();
                }

            }

        }

        private void buttonAddToDDSTexturePreparer_Click(object sender, EventArgs e)
        {
            string itemText;
            string subItemText;
            string[] resName;
            string resAnimCheck;
            string filePathPartOne;
            string filePathPartTwo;
            string filePath;


            DialogResult dr = this.openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                string file = openFileDialog1.FileName;

                XmlDocument DDSTexturePreparer = new XmlDocument();

                DDSTexturePreparer.Load(file);

                XmlElement rootElement = DDSTexturePreparer.DocumentElement;

                for (int i = 0; i < listViewPngResources.Items.Count; i++)
                {
                    itemText = listViewPngResources.Items[i].Text;

                    subItemText = listViewPngResources.Items[i].SubItems[1].Text;

                    resAnimCheck = subItemText.Substring(subItemText.LastIndexOf('\\') + 1);

                    resName = itemText.Split(' ');

                    if (resName[0] == "mip_map")
                    {
                        filePathPartOne = resName[4].Substring(resName[4].LastIndexOf("data\\") + 5);

                        if (resAnimCheck.Contains("animation"))
                        {
                            filePathPartTwo = subItemText.Substring(0, subItemText.LastIndexOf('\\')) + "\\animation";
                        }
                        else
                        {
                            filePathPartTwo = subItemText;
                        }

                        filePath = filePathPartOne + "\\" + filePathPartTwo;

                        foreach (XmlElement texture in rootElement)
                        {
                            if (texture.Attributes["diffuse_file_name"] == null) continue;

                            if (texture.Attributes["diffuse_file_name"].Value.Contains(filePath))
                            {
                                texture.SetAttribute("mipmaps", "1");
                            }
                        }
                    }
                }
                DDSTexturePreparer.Save(file);
                System.Windows.Forms.MessageBox.Show("Done!", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonCheckSubsTT_Click(object sender, EventArgs e)
        {
            List<string> resFilesList = AllResFilesOfSubs();
            List<string> resFilesWithoutTempTexturesList = new List<string>();

            foreach (string curResFile in resFilesList)
            {
                XmlDocument resSceneDocXML = new XmlDocument(); ;

                XmlElement resSceneRootXML;

                if (File.Exists(Config.BinPath + curResFile))
                {
                    resSceneDocXML.Load(Config.BinPath + curResFile);

                    string resFIlePath = Config.BinPath + curResFile;

                    resSceneRootXML = (XmlElement)resSceneDocXML.DocumentElement;

                    CheckResourcesFilestoTempTextures(resSceneRootXML, resFilesWithoutTempTexturesList, resFIlePath);
                }
                else
                {
                    resFilesWithoutTempTexturesList.Add(Config.BinPath + curResFile + "|" + "File doesn't exist");
                }
            }

            if (resFilesWithoutTempTexturesList.Count > 0)
            {
                CheckSubsTemporaryTexturesForm f = new CheckSubsTemporaryTexturesForm(resFilesWithoutTempTexturesList);
                f.Show();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Congratulate! All resources files is valid!", "Resource validation message", MessageBoxButtons.OK);
            }

        }

        private void CheckResourcesFilestoTempTextures(XmlNode resRootNode, List<string> list, string resFile)
        {
            foreach (XmlNode node in resRootNode)
            {
                if ((node.Attributes["temporary_textures"] != null) && (node.Attributes["temporary_textures"].Value != "1"))
                {
                    list.Add(resFile + "|" + node.Attributes["name"].Value);
                }
                if (node.Attributes["temporary_textures"] == null)
                {
                    list.Add(resFile + "|" + node.Attributes["name"].Value);
                }
            }

        }

        private List<string> AllResFilesOfSubs()
        {
            List<string> allResFiles = new List<string>();

            Scene scene = new Scene();

            LocationManager locationManager = new LocationManager(Config.LevelsPath + @"\levels.xml");

            foreach (Location location in locationManager.Locations)
            {
                foreach (SceneInfo scenInfo in location.AllSubscreens)
                {
                    foreach (string resFileName in location.AllResourcesFilePaths)
                    {
                        if (resFileName.Contains(scenInfo.FolderName))
                        {
                            if (!allResFiles.Contains(resFileName))
                            {
                                allResFiles.Add(resFileName);
                            }
                        }
                    }
                }
            }

            return allResFiles;
        }

        private string AttString(string attName, char spliter)
        {
            string attSubString;
            attSubString = attName.Substring(attName.LastIndexOf(spliter) + 1);
            return attSubString;
        }

        private void buttonCheckResourcesToUsing_Click(object sender, EventArgs e)
        {
            List<string> allUnUseResFiles = new List<string>();

            Scene scene = new Scene();

            LocationManager locationManager = new LocationManager(Config.LevelsPath + @"\levels.xml");

            foreach (Location location in locationManager.Locations)
            {
                List<String> AllSceneInLoc = GetAllScenesInLocation(location);


                foreach (string resFileName in location.AllResourcesFilePaths)
                {
                    XmlDocument resSceneDocXML = new XmlDocument();

                    XmlElement resSceneRootXML;

                    string resFilePath = Config.BinPath + resFileName;

                    if (File.Exists(resFilePath))
                    {
                        string resFolder = GetSubstringBetweenLastSlashes(resFilePath);

                        resSceneDocXML.Load(resFilePath);

                        resSceneRootXML = (XmlElement)resSceneDocXML.DocumentElement;

                        foreach (string sceneFilePath in AllSceneInLoc)
                        {
                            string mainSceneFilePath = sceneFilePath;

                            XmlDocument mainSceneDocXML = new XmlDocument(); ;

                            XmlElement mainSceneRootXML;

                            if (File.Exists(mainSceneFilePath))
                            {
                                mainSceneDocXML.Load(mainSceneFilePath);

                                mainSceneRootXML = (XmlElement)mainSceneDocXML.DocumentElement;

                                XmlElement mainSceneLeyersNode = (XmlElement)mainSceneRootXML.SelectSingleNode("layers"); ;

                                string sceneFolder = GetSubstringBetweenLastSlashes(mainSceneFilePath);

                                if (sceneFolder == resFolder)
                                {
                                    if (mainSceneLeyersNode != null)
                                    {
                                        FindResourceInScene(allUnUseResFiles, resFilePath, resSceneRootXML, mainSceneLeyersNode);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        allUnUseResFiles.Add(Config.BinPath + resFileName + "|" + "File doesn't exist");
                    }
                }

            }
            if (allUnUseResFiles.Count > 0)
            {
                CheckResourcesFilesResult f = new CheckResourcesFilesResult(allUnUseResFiles);
                f.Show();
            }
        }

        private string GetSubstringBetweenLastSlashes(string inputString)
        {
            string outputString = inputString.Substring(0, inputString.LastIndexOf("\\"));
            outputString = AttString(outputString, '\\');
            return outputString;
        }
        private List<String> GetAllScenesInLocation(Location location)
        {
            List<String> allScenesPath = new List<String>();
            string mainSceneFilePath = Config.ScenesPath + "\\" + location.AllScenes[0].SceneFilePath;
            allScenesPath.Add(mainSceneFilePath);
            foreach (SceneInfo sceneInfo in location.AllSubscreens)
            {
                string subNamePath = Config.ScenesPath + "\\" + sceneInfo.SceneFilePath;
                allScenesPath.Add(subNamePath);
            }
            return allScenesPath;
        }
        
        private void FindResourceInScene(List<string> list, string resFile, XmlNode resRootNode, XmlNode mainSceneLeyersNode)
        {
            List<XmlNode> AllShadersInResources = new List<XmlNode>();
            List<XmlNode> AllShadersInScene = new List<XmlNode>();
            GetAllShaderInResourcesXML(resRootNode, AllShadersInResources);
            GetAllShaderInSceneXML(mainSceneLeyersNode, AllShadersInScene);

            if ((AllShadersInResources.Count != 0))
            {
                foreach (XmlNode resShaderNode in AllShadersInResources)
                {
                    bool found = false;
                    string nodePath = String.Empty;
                    XmlNode node = resShaderNode;

                    while (node.ParentNode.NodeType != XmlNodeType.Document)
                    {
                        nodePath = node.ParentNode.Name + "/" + nodePath;
                        node = node.ParentNode;
                    }

                    foreach (XmlNode sceneShaderNode in AllShadersInScene)
                    {
                        if (sceneShaderNode.Attributes["shader"].Value == nodePath + resShaderNode.Attributes["name"].Value)
                        {
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        list.Add(resFile + "|" + resShaderNode.Attributes["name"].Value + " don't use in scene");
                    }
                }
            }
            // ПОПРОБОВАТЬ ВСТАВИТЬ ПЕРВЫЙ КАРД С ПНГ С КОНТУРОМ И БЕЗ!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        }

        private void GetAllShaderInResourcesXML(XmlNode resRootNode, List<XmlNode> AllShadersInResources)
        {
            foreach (XmlNode node in resRootNode.ChildNodes)
            {
                if (node.NodeType != XmlNodeType.Comment)
                {
                    if (node.Name == "shader")
                    {
                        AllShadersInResources.Add(node);
                    }
                    else
                    {
                        if (node.Attributes.Count == 0)
                        {
                            GetAllShaderInResourcesXML(node, AllShadersInResources);
                        }
                    }
                }
            }
        }

        private void GetAllShaderInSceneXML(XmlNode mainSceneLeyersNode, List<XmlNode> AllShadersInScene)
        {
            foreach (XmlNode node in mainSceneLeyersNode.ChildNodes)
            {
                if (node.NodeType != XmlNodeType.Comment)
                {
                    if (node.Attributes["shader"] != null)
                    {
                        AllShadersInScene.Add(node);
                    }
                    GetAllShaderInSceneXML(node, AllShadersInScene);
                }
            }
        }

    }
}
