using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HiddenObjectStudio.Core.ResourcesManager;
using System.IO;
using System.Threading;
using HiddenObjectStudio.Core;
using HiddenObjectStudio.Core.SceneManagement;
using HiddenObjectStudio.Core.LocationManagement;
using System.Xml;
using System.Collections.Specialized;

namespace WindowsFormsApplication2
{
    public partial class TexturesFormManager : Form
    {
        private Config Config;
        private string levelsXmlPath;
        private Thread mainThread;
        private string _file = string.Empty;
        private Dictionary<string, StringCollection> _log;
        
        public TexturesFormManager(Config config, string inputLevelsXmlPath)
        {
            Config = config;
            levelsXmlPath = inputLevelsXmlPath;
            _log = new Dictionary<string, StringCollection>();

            InitializeComponent();
            InitializeOpenFileDialog();
        }

        private void InitializeOpenFileDialog()
        {
            // Set the file dialog to filter for graphics files.

            this.openFileDialog1.Filter =
                "XML (*.XML)|*.XML|" +
                "All files (*.*)|*.*";

            this.openFileDialog1.Multiselect = false;
            this.openFileDialog1.Title = "Select resources.xml!";
        }

        private void buttonTextUV_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog1.ShowDialog();

            if (dr == System.Windows.Forms.DialogResult.OK)
            {
            
                string file = openFileDialog1.FileName;

                if (File.Exists(file))
                {
                    _file = file;

                    if (_file != string.Empty)
                    {
                        mainThread = new Thread(TextureUV);
                        mainThread.Start();
                    }
                   
                }
            }
        }

        private void TextureUV()
        {
            string projPath = string.Empty;
            string shaderNameValue = string.Empty;

            LocationManager lm = new LocationManager(levelsXmlPath);

            List<string> resFilesList = AllResFilesOfProject();
            List<string> dontExistPngList = new List<string>();
            List<XmlNode> texturePackPathsList = new List<XmlNode>();

            XmlDocument xmlDoc = new XmlDocument();
            Tools.TryToLoad(xmlDoc, _file);
            //xmlDoc.Load(_file);

            XmlElement root = xmlDoc.DocumentElement;

            projPath = root.Attributes["project_path"].Value;

            if (projPath != string.Empty)
            {
                foreach (XmlElement xmlNode in root)
                {
                    string picPath = xmlNode.Attributes["name"].Value;
                    string textScale = xmlNode.Attributes["tex_scale_uv"].Value;
                    string inputSize = xmlNode.Attributes["size"].Value;

                    string picFullPath = projPath + "\\" + picPath;

                    Invoke(new MethodInvoker(
                       delegate
                       {
                           listBoxWhatFind.Items.Clear();
                           listBoxWhatFind.Items.Add(picFullPath);
                       }
                     ));

                    if (!xmlNode.Attributes["name"].Value.Contains("\\texture_pack\\"))
                    {
                        foreach (string curResFile in resFilesList)
                        {
                            if (File.Exists(Config.BinPath + curResFile))
                            {
                                ResourcesData resourcesData = new ResourcesData(Config.BinPath + curResFile);

                                shaderNameValue = resourcesData.GetShaderNameByFullPath(picFullPath, Config.BinPath + curResFile);

                                if (shaderNameValue != string.Empty)
                                {
                                    Invoke(new MethodInvoker(
                                                               delegate
                                                               {
                                                                   listBoxWhatFind.Items.Add(shaderNameValue);
                                                               }
                                                             ));

                                    ModificateShaderLayerInScene(shaderNameValue, lm, textScale, inputSize, curResFile, picFullPath);
                                }
                                //                             else
                                //                             {
                                //                                 dontExistPngList.Add(Config.BinPath + curResFile + "|" + "File doesn't exist");
                                //                             }
                            }

                        }

                        if (picPath.Contains("diary"))
                        {
                            ResourcesData resourcesData = new ResourcesData(Config.DiaryPath + "\\resources.xml");

                            shaderNameValue = resourcesData.GetShaderNameByFullPath(picFullPath, Config.DiaryPath + "\\resources.xml");

                            if (shaderNameValue != string.Empty)
                            {
                                Invoke(new MethodInvoker(
                                                           delegate
                                                           {
                                                               listBoxWhatFind.Items.Add(shaderNameValue);
                                                           }
                                                         ));

                                ModificateShaderLayerInDiary(shaderNameValue, textScale, inputSize, picFullPath);
                            }
                        }
                    }
                    else
                    {
                        if (xmlNode.Attributes["name"].Value.Contains("\\scenes\\"))
                        {
                            texturePackPathsList.Add(xmlNode);
                        }
                        
                    }
                }

                if (checkBoxTexturePackConverter.Checked)
                {
                    CreateXmlDocItemsTpf(texturePackPathsList);
                }
                
                MessageBox.Show("Done!");
            }
            else
            {
                MessageBox.Show("project_path value is Empty!");
            }

            DialogResult dr = MessageBox.Show("Do you want to save log", "Info", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                WriteLogInFile(projPath);
            }
        }

        private void CreateXmlDocItemsTpf(List<XmlNode> xmlNodeInputList)
        {
            string pathFolder = Tools.GetLastFolderNameFromPath(_file);
            string pathFile = pathFolder + "\\TexturePackConverter.xml";

            if (File.Exists(pathFile))
            {
                File.SetAttributes(pathFile, FileAttributes.Normal);
                File.Delete(pathFile);
            }

            XmlDocument xmlDoc = new XmlDocument();

            XmlElement root = xmlDoc.CreateElement("textures");

            xmlDoc.AppendChild(root);

            foreach (XmlNode node in xmlNodeInputList)
            {
                string nameValue = node.Attributes["name"].Value;

                string newNameValue = Tools.GetLastFolderNameFromPath(nameValue) + "\\items.tpf";

                XmlElement nodeElement = (XmlElement)xmlDoc.ImportNode(node, true);

                nodeElement.SetAttribute("name", newNameValue);

                root.AppendChild(nodeElement);
            }

            xmlDoc.Save(pathFile);
        }

        private void WriteLogInFile(string projPath)
        {
            string fileName = projPath + "\\log.xml";

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            XmlDocument xmlDoc = new XmlDocument();

            XmlElement root = xmlDoc.CreateElement("root");

            xmlDoc.AppendChild(root);

            foreach (string str in _log.Keys)
            {
                XmlElement node = xmlDoc.CreateElement("node");

                node.SetAttribute("png", str);

                root.AppendChild(node);

                StringCollection strCollect = _log[str];

                foreach (string strValue in strCollect)
                {
                    XmlElement childNode = null;

                    string[] arr = strValue.Split('|');
                    
                    if (arr.Length == 2)
                    {
                        childNode = xmlDoc.CreateElement("where");
                    }
                    else if (arr.Length == 3)
                    {
                        childNode = xmlDoc.CreateElement("NOT");
                    }

                    childNode.SetAttribute("sceneName", arr[0]);
                    childNode.SetAttribute("layerName", arr[1]);
                    if (arr.Length > 2)
                    {
                        childNode.SetAttribute("WARNING", arr[2]);
                    }
                    

                    node.AppendChild(childNode);
                }
            }

//             foreach (string str in dontExistPngList)
//             {
//                 string[] arr = str.Split('|');
// 
//                 XmlElement node = xmlDoc.CreateElement("dontExist");
// 
//                 node.SetAttribute("FilePath", arr[0]);
//                 node.SetAttribute("Value", arr[1]);
// 
//                 root.AppendChild(node);
//             }


            xmlDoc.Save(fileName);

            mainThread.Abort();
        }

        private void ModificateShaderLayerInDiary(string shaderNameValue, string textScale, string inputSize, string picFullPath)
        {
            Scene scene = new Scene();
            scene.LoadFromXml(Config.DiaryPath + "\\scene.xml");

            foreach (Layer layer in scene.AllLayers)
            {
                string layerAttrName = layer.GetAttribValue("shader");
                string layerAttrSize = layer.GetAttribValue("size");
                string layerAttrModel = layer.GetAttribValue("model");

                if (layerAttrName == shaderNameValue)
                {
                    if ((layer.HasAttribut("size")) || (layer.HasAttribut("model")))
                    {
                        Invoke(new MethodInvoker(
                                         delegate
                                         {
                                             listBoxWhereFind.Items.Add("Diary" + "   |   " + layer.Name);
                                             listBoxWhereFind.SelectedIndex = listBoxWhereFind.Items.Count - 1;
                                             listBoxWhereFind.SelectedIndex = -1;
                                         }
                                       ));

                        layer.SetAttribute("tex_scale_uv", textScale);

                        string value = "Diary" + "|" + layer.Name;

                        if (_log.ContainsKey(picFullPath))
                        {
                            StringCollection stringCollection = _log[picFullPath];

                            if (!stringCollection.Contains(value))
                            {
                                stringCollection.Add(value);
                            }

                        }
                        else
                        {
                            StringCollection stringCollection = new StringCollection();

                            _log.Add(picFullPath, stringCollection);

                            stringCollection.Add(value);

                        }

                        
                    }
                    else
                    {
                        if ((!layer.HasAttribut("selection")) && (!layer.HasAttribut("external_selection")))
                        {
                            layer.SetAttribute("external_selection", "./selection");

                            Layer selectionLayer = new Layer();
                            selectionLayer.Name = "selection";
                            selectionLayer.SetAttribute("size", inputSize);

                            layer.AddChildLayer(selectionLayer);
                        }
                    }
                    
                    
                }
            }

            scene.SaveToXml(Config.DiaryPath + "\\scene.xml");
        }

        private void ModificateShaderLayerInScene(string shaderNameValue, LocationManager lm, string textScale, string inputSize, string resFilePath, string picFullPath)
        {
            foreach (SceneInfo sceneInfo in lm.AllScenes)
            {
                Location location = sceneInfo.OwnerLocation;

                if (sceneInfo.SceneFilePath.Contains("intro"))
                {
                    Scene scene = new Scene();
                    scene.LoadFromXml(Config.ScenesPath + "\\" + sceneInfo.SceneFilePath);
                    Layers a = scene.AllLayers;
                }

                bool resFound = false;

                foreach (string resPath in location.ResourcesFilePaths)
                {
                    if (resPath == resFilePath)
                    {
                        resFound = true;
                    }
                }

                if (resFound)
                {
                    Scene scene = new Scene();

                    scene.LoadFromXml(Config.ScenesPath + "\\" + sceneInfo.SceneFilePath);

                    foreach (Layer layer in scene.AllLayers)
                    {
                        string layerAttrName = layer.GetAttribValue("shader");
                        string layerAttrSize = layer.GetAttribValue("size");
                        string layerAttrModel = layer.GetAttribValue("model");

                        if (layerAttrName == shaderNameValue)
                        {
                            if ((layer.HasAttribut("size")) || (layer.HasAttribut("model")))
                            {
                                Invoke(new MethodInvoker(
                                                 delegate
                                                 {
                                                     listBoxWhereFind.Items.Add(Config.ScenesPath + "\\" + sceneInfo.SceneFilePath + "   |   " + layer.Name);
                                                     listBoxWhereFind.SelectedIndex = listBoxWhereFind.Items.Count - 1;
                                                     listBoxWhereFind.SelectedIndex = -1;
                                                 }
                                               ));

                                layer.SetAttribute("tex_scale_uv", textScale);
                                
                                string value = sceneInfo.FolderName + "|" + layer.Name;
                               
                                if (_log.ContainsKey(picFullPath))
                                {
                                    StringCollection stringCollection = _log[picFullPath];

                                    if (!stringCollection.Contains(value))
                                    {
                                        stringCollection.Add(value);
                                    }
                                    
                                }
                                else
                                {
                                    StringCollection stringCollection = new StringCollection();
                                    
                                    _log.Add(picFullPath, stringCollection);

                                    stringCollection.Add(value);
                                    
                                }

                               
                            }
                            else
                            {
                                if ((!layer.HasAttribut("selection")) && (!layer.HasAttribut("external_selection")))
                                {
                                    layer.SetAttribute("external_selection", "./selection");

                                    Layer selectionLayer = new Layer();
                                    selectionLayer.Name = "selection";
                                    selectionLayer.SetAttribute("size", inputSize);

                                    layer.AddChildLayer(selectionLayer);
                                }

                                string value = sceneInfo.FolderName + "|" + layer.Name + "|" + "Size OR Model in Layer";

                                if (_log.ContainsKey(picFullPath))
                                {
                                    StringCollection stringCollection = _log[picFullPath];

                                    stringCollection.Add(value);
                                
                                }
                                else
                                {
                                    StringCollection stringCollection = new StringCollection();

                                    _log.Add(picFullPath, stringCollection);

                                    stringCollection.Add(value);

                                }
                            }
                        }
                    }
                    scene.SaveToXml(Config.ScenesPath + "\\" + sceneInfo.SceneFilePath);
                }
                
            }
        }

        private List<string> AllResFilesOfProject()
        {
            List<string> allResFiles = new List<string>();

            Scene scene = new Scene();

            LocationManager locationManager = new LocationManager(levelsXmlPath);

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

        private void TexturesFormManager_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (mainThread != null)
            {
                if (mainThread.IsAlive)
                {
                    mainThread.Abort();
                }
            }
        }

        private void buttonCheckToUse_Click(object sender, EventArgs e)
        {
            mainThread = new Thread(CheckPicturesToUse);
            mainThread.Start();
        }

        private void CheckPicturesToUse()
        {
            DirectoryInfo diaryDi = new DirectoryInfo(Config.DiaryPath);
            DirectoryInfo scenesDi = new DirectoryInfo(Config.ScenesPath);

            List<string> resFilesList = AllResFilesOfProject();

            List<string> unUsableTextures = new List<string>();

            string shaderNameValue = string.Empty;

            List<string> pngImageMassDiary = GetAllPicPathFromFolderFiles(diaryDi);
            List<string> pngImageMassScenes = GetAllPicPathFromFolderFiles(scenesDi);

            List<string> pngImageMass = new List<string>();
            
            pngImageMass.AddRange(pngImageMassScenes);
            pngImageMass.AddRange(pngImageMassDiary);

            LocationManager lm = new LocationManager(levelsXmlPath);

            string lastShaderName = string.Empty;
            string lastResName = string.Empty;

            foreach (string str in pngImageMass)
            {
                Invoke(new MethodInvoker(
                                    delegate
                                    {
                                        listBoxWhatFind.Items.Clear();
                                        listBoxWhatFind.Items.Add(str);
                                        
                                    }
                                  ));
                 bool foundLayer = false;
               
                 if (!str.Contains("\\texture_pack\\"))
                 {
                     foreach (string curResFile in resFilesList)
                     {
                         if (File.Exists(Config.BinPath + curResFile))
                         {
                             ResourcesData resourcesData = new ResourcesData(Config.BinPath + curResFile);

                             shaderNameValue = resourcesData.GetShaderNameByFullPathUsingAnimation(str, Config.BinPath + curResFile);

                             if (shaderNameValue != string.Empty)
                             {
                                 if ((lastShaderName != shaderNameValue) && (lastResName != curResFile))
                                 {
                                     foundLayer = SearchShaderInScenes(shaderNameValue, lm, curResFile, str);

                                     if (foundLayer)
                                     {
                                         lastShaderName = shaderNameValue;
                                         break;
                                     }
                                 }
                                 else
                                 {
                                     foundLayer = true;
                                 }

                             }

                         }

                         lastResName = curResFile;
                     }

                     if (!foundLayer)
                     {
                         if (str.Contains("diary"))
                         {
                             ResourcesData resourcesData = new ResourcesData(Config.DiaryPath + "\\resources.xml");

                             shaderNameValue = resourcesData.GetShaderNameByFullPathUsingAnimation(str, Config.DiaryPath + "\\resources.xml");

                             if (shaderNameValue != string.Empty)
                             {
                                 if (lastShaderName != shaderNameValue)
                                 {
                                     foundLayer = SearchShaderInDiary(shaderNameValue, str);
                                     if (foundLayer)
                                     {
                                         lastShaderName = shaderNameValue;
                                         continue;
                                     }
                                 }
                                 else
                                 {
                                     foundLayer = true;
                                 }

                             }

                         }
                     }
                     else
                     {
                         continue;
                     }

                     if (!foundLayer)
                     {
                         Invoke(new MethodInvoker(
                                         delegate
                                         {
                                             listBoxWhereFind.Items.Add(str);
                                             listBoxWhereFind.SelectedIndex = listBoxWhereFind.Items.Count - 1;
                                             listBoxWhereFind.SelectedIndex = -1;
                                         }
                                       ));

                         unUsableTextures.Add(str);
                     }
                 }
            }
                       
            MessageBox.Show("Done!");
        }

        private List<string> GetAllPicPathFromFolderFiles(DirectoryInfo di)
        {
            List<string> pngImageMass = new List<string>();

            string[] pngImageMassDi = Directory.GetFiles(di.FullName, "*.png");
            
            foreach (string str in pngImageMassDi)
            {
                pngImageMass.Add(str);
            }

            foreach (DirectoryInfo drs in di.GetDirectories())
            {
                pngImageMass.AddRange(GetAllPicPathFromFolderFiles(drs));
            }
            return pngImageMass;
        }

        private bool SearchShaderInScenes(string shaderNameValue, LocationManager lm, string resFilePath, string picFullPath)
        {
            bool foundLayer = true;

            foreach (SceneInfo sceneInfo in lm.AllScenes)
            {
                Location location = sceneInfo.OwnerLocation;

                if ((sceneInfo.PlaceName == "secrets_room_sub_bottle")/* && (shaderNameValue == "secrets_room/bottle")*/)
                {

                }

                bool resFound = false;

                foreach (string resPath in location.ResourcesFilePaths)
                {
                    if (resPath == resFilePath)
                    {
                        resFound = true;
                    }
                }

                if (resFound)
                {
                    Scene scene = new Scene();

                    scene.LoadFromXml(Config.ScenesPath + "\\" + sceneInfo.SceneFilePath);

                    foreach (Layer layer in scene.AllLayers)
                    {
                        string layerAttrName = layer.GetAttribValue("shader");

                        if (layerAttrName == shaderNameValue)
                        {
                            foundLayer = true;
                        }

                    }

                }


            }
            return foundLayer;
        }

        private bool SearchShaderInDiary(string shaderNameValue, string picFullPath)
        {
            bool foundLayer = false;

            Scene scene = new Scene();
            scene.LoadFromXml(Config.DiaryPath + "\\scene.xml");

            foreach (Layer layer in scene.AllLayers)
            {
                string layerAttrName = layer.GetAttribValue("shader");
                string layerAttrSize = layer.GetAttribValue("size");
                string layerAttrModel = layer.GetAttribValue("model");

                if (layerAttrName == shaderNameValue)
                {

                    foundLayer = true;

                }
            }

            return foundLayer;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string a = Tools.GetFolderByInputFolderAndPath("d:\\data_ncuxsp\\FFS\\data\\gameplay\\main\\scenes\\secretsroom\\resources.xml","..\\ddm_0\\textures\\ghosts\\watchman");
            MessageBox.Show(a);
        }
    }
}
