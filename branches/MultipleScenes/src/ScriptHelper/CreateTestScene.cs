using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using HiddenObjectStudio.Core;
using HiddenObjectStudio.Core.LocationManagement;
using HiddenObjectStudio.Core.SceneManagement;
using System.Xml;

namespace WindowsFormsApplication2
{
    public partial class CreateTestScene : Form
    {
        private const string SceneXmlFileName = "scene.xml";
        private const string ResourcesXmlFileName = "resources.xml";

		private Config Config;

        DirectoryInfo ddsPath, videoPath;
        Point contMenuClickPoint;
        private XmlDocument _levelsDocXml;
        string _fileNameLevelsXml;

        public CreateTestScene()
        {
            InitializeComponent();

			Config = new Config();

           // string ddsFolderPath = Config.BinPath + "dds_for_test";
          //  string ddsFolderPath = ddsPath.FullName.Replace("\\\\", "\\");
            ddsPath = new DirectoryInfo(Config.BinPath + "dds_for_test");
            videoPath = new DirectoryInfo(Config.BinPath + "video_for_test");

            _fileNameLevelsXml = Config.LevelsPath + "\\Levels.xml";

            _levelsDocXml = new XmlDocument();

            _levelsDocXml.Load(_fileNameLevelsXml);
        }

        private void txtType1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void buttonCreateShader_Click(object sender, EventArgs e)
        {
            if ((comboBoxWidth.SelectedItem != null) && (comboBoxHeight.SelectedItem != null) && (textBoxFrameCount.Text != String.Empty) && (textBoxAnimationSpeed.Text != String.Empty))
            {

                if (textBoxShadersCount.Text != String.Empty)
                {
                    int count = Convert.ToInt32(textBoxShadersCount.Text);
                    for (int i = 0; i < count; i++)
                    {
                        string shaderSize = comboBoxWidth.SelectedItem.ToString() + " " + comboBoxHeight.SelectedItem.ToString();
                        ListViewItem newItem = new ListViewItem();
                        newItem.Text = "shader";
                        newItem.SubItems.Add(shaderSize);
                        newItem.SubItems.Add(textBoxFrameCount.Text);
                        newItem.SubItems.Add(textBoxAnimationSpeed.Text);
                        listView1.Items.Add(newItem);
                        listView1.Refresh();
                        
                    }
                }
                else
                {
                    string shaderSize = comboBoxWidth.SelectedItem.ToString() + " " + comboBoxHeight.SelectedItem.ToString();
                    ListViewItem newItem = new ListViewItem();
                    newItem.Text = "shader";
                    newItem.SubItems.Add(shaderSize);
                    newItem.SubItems.Add(textBoxFrameCount.Text);
                    newItem.SubItems.Add(textBoxAnimationSpeed.Text);
                    listView1.Items.Add(newItem);
                    listView1.Refresh();
                    
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Please fill all field", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCreateVideo_Click(object sender, EventArgs e)
        {
            if (comboBoxVSize.SelectedItem != null)
            {
                string videoSize = comboBoxVSize.SelectedItem.ToString();
                ListViewItem newItem = new ListViewItem();
                newItem.Text = "video";
                newItem.SubItems.Add(videoSize);
                newItem.SubItems.Add("");
                newItem.SubItems.Add("");
                if (checkBoxMode.Checked)
                {
                    newItem.SubItems.Add("1");
                }
                else 
                { 
                    newItem.SubItems.Add("0"); 
                }
                
                listView1.Items.Add(newItem);
                listView1.Refresh();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Please fill all field", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAddTPack_Click(object sender, EventArgs e)
        {
            ListViewItem newItem = new ListViewItem();
            ListViewItem newItem1 = new ListViewItem();
            newItem.Text = "texture_pack";
            newItem.SubItems.Add("1024 512");
            newItem1.Text = "texture_pack";
            newItem1.SubItems.Add("1024 512");
            listView1.Items.Add(newItem);
            listView1.Items.Add(newItem1);
            listView1.Refresh();
        }

        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (listView1.Items.Count > 0)
            {
                if (e.Button == MouseButtons.Right)
                {
                    listView1 = ((ListView)sender);

                    contMenuClickPoint = new Point(e.X, e.Y);
                    // string selectedInvItem = listView1.SelectedItems[0].SubItems[1].Text;
                  //listView1.SelectedItems[0] = listView1.SelectedItems[0].IndexFromPoint(contMenuClickPoint);
                }
            }
        }

        private void deleteItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.SelectedItems[0].Remove();
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            DirectoryInfo outputDi = new DirectoryInfo(Config.ScenesPath + "\\test_scene");

            

            string filePath = outputDi.FullName + "\\scene.xml";

            string fileNameSceneRecourcesXml = outputDi.FullName + "\\resources.xml";
            try
            {
                if (outputDi.Exists)
                {

                    foreach (FileInfo fi in outputDi.GetFiles())
                    {
                        fi.Attributes = FileAttributes.Normal;
                        fi.Delete();
                    }
                    outputDi.Delete(true);

                }
                outputDi.Create();

                ClearLevelsXML();

                CreateScene(outputDi.FullName);

                CreateIncludesLib(outputDi.FullName);

                CreateResources(outputDi.FullName);

                CreateTexturesFolders();

                CreateTexturePackFolder();

                CreateVideoFolders();
                
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    if (listView1.Items[i].Text == "shader")
                    {
                        string typeItem = "shader";
                        string shaderName = "shader_" + i;
                        string shaderSize = listView1.Items[i].SubItems[1].Text;
                        string shaderFrames = listView1.Items[i].SubItems[2].Text;
                        string shaderSpeed = listView1.Items[i].SubItems[3].Text;
                        string videoMode = "";
                        FillSceneXML(typeItem, filePath, shaderName, shaderSize, shaderFrames, shaderSpeed, videoMode);
                        EditRecources(fileNameSceneRecourcesXml, shaderName, shaderSize, shaderFrames);
                    }
                    else if (listView1.Items[i].Text == "video")
                    {
                        string typeItem = "video";
                        string videoName = "video_" + i;
                        string videoSize = listView1.Items[i].SubItems[1].Text;
                        string videoFrames = "";
                        string videoSpeed = "";
                        string videoMode = listView1.Items[i].SubItems[4].Text;
                        FillSceneXML(typeItem, filePath, videoName, videoSize, videoFrames, videoSpeed, videoMode);
                    }
                    else if (listView1.Items[i].Text == "texture_pack")
                    {
                        string typeItem = "texture_pack";
                        string shaderName = "texture_pack_" + i;
                        string shaderSize = listView1.Items[i].SubItems[1].Text;
                        string shaderFrames = "";
                        string shaderSpeed = "";
                        string videoMode = "";
                        FillSceneXML(typeItem, filePath, shaderName, shaderSize, shaderFrames, shaderSpeed, videoMode);
                        EditRecourcesAddTexturePack(fileNameSceneRecourcesXml, shaderName, shaderSize);
                    }

                }
                if (checkBoxRain.Checked)
                {
                    CreateRain(outputDi.FullName);
                }

                AddTestSceneToLevelsXML();

                System.Windows.Forms.MessageBox.Show("Done", "Yahoo!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void ClearLevelsXML()
        {
            
            string listBoxLevelsPlace = "test_scene";

            XmlNodeList levelPlaceNode = _levelsDocXml.SelectNodes("levels/stage/level[@place='" + listBoxLevelsPlace + "']");
            if (levelPlaceNode.Count > 0)
            {
                XmlElement testSceneNode = (XmlElement)levelPlaceNode[0];

                testSceneNode.ParentNode.RemoveChild(testSceneNode);
                
            }
            _levelsDocXml.Save(_fileNameLevelsXml);
        }

        private void CreateRain(string str)
        {
            string fileNameSceneXml = "";
            
            fileNameSceneXml = str + "\\scene.xml";

            if (File.Exists(fileNameSceneXml))
            {

                XmlDocument sceneFileForAmimation = new XmlDocument();

                sceneFileForAmimation.Load(fileNameSceneXml);

                XmlElement rootNode = sceneFileForAmimation.DocumentElement;

                string rootNodeName = rootNode.Name;

                XmlElement sceneLayersNodeXml = (XmlElement)sceneFileForAmimation.SelectSingleNode(rootNodeName + "/layers");

                XmlElement addedAnimationLayerNode1 = sceneFileForAmimation.CreateElement("rain_1");
                addedAnimationLayerNode1.SetAttribute("effect", "rain");
                addedAnimationLayerNode1.SetAttribute("size", "1024 768");
                addedAnimationLayerNode1.SetAttribute("rain_density", "1.5");
                addedAnimationLayerNode1.SetAttribute("rain_scale", "0.3");
                addedAnimationLayerNode1.SetAttribute("rain_speed", "1000");
                addedAnimationLayerNode1.SetAttribute("rain_shift", "150");
                addedAnimationLayerNode1.SetAttribute("rain_deviation", "75");
                addedAnimationLayerNode1.SetAttribute("rain_die_area_height", "250");

                XmlElement addedAnimationLayerNode2 = sceneFileForAmimation.CreateElement("rain_2");
                addedAnimationLayerNode2.SetAttribute("effect", "rain");
                addedAnimationLayerNode2.SetAttribute("size", "1024 768");
                addedAnimationLayerNode2.SetAttribute("rain_density", "0.5");
                addedAnimationLayerNode2.SetAttribute("rain_scale", "0.6");
                addedAnimationLayerNode2.SetAttribute("rain_speed", "1000");
                addedAnimationLayerNode2.SetAttribute("rain_shift", "150");
                addedAnimationLayerNode2.SetAttribute("rain_deviation", "75");
                addedAnimationLayerNode2.SetAttribute("rain_die_area_height", "250");

                XmlElement addedAnimationLayerNode3 = sceneFileForAmimation.CreateElement("rain_3");
                addedAnimationLayerNode3.SetAttribute("effect", "rain");
                addedAnimationLayerNode3.SetAttribute("size", "1024 768");
                addedAnimationLayerNode3.SetAttribute("rain_density", "0.1");
                addedAnimationLayerNode3.SetAttribute("rain_speed", "1000");
                addedAnimationLayerNode3.SetAttribute("rain_shift", "150");
                addedAnimationLayerNode3.SetAttribute("rain_deviation", "75");
                addedAnimationLayerNode3.SetAttribute("rain_die_area_height", "250");


                sceneLayersNodeXml.AppendChild(addedAnimationLayerNode1);
                sceneLayersNodeXml.AppendChild(addedAnimationLayerNode2);
                sceneLayersNodeXml.AppendChild(addedAnimationLayerNode3);


                sceneFileForAmimation.Save(fileNameSceneXml);
            }
        }

        private void AddTestSceneToLevelsXML()
        {
            XmlElement levelsXMLRoot = (XmlElement)_levelsDocXml.SelectSingleNode("levels/stage");

            XmlElement testSceneNode = _levelsDocXml.CreateElement("level");
            testSceneNode.SetAttribute("place", "test_scene");
            testSceneNode.SetAttribute("scene_folder", "test_scene");
            testSceneNode.SetAttribute("scene_file", "scene.xml");

            XmlElement resourcesNode = _levelsDocXml.CreateElement("resources");

            XmlElement testSceneRes = _levelsDocXml.CreateElement("file");
            testSceneRes.SetAttribute("file_name", "data\\scenes\\test_scene\\resources.xml");

            XmlElement subRes = _levelsDocXml.CreateElement("file");
            subRes.SetAttribute("file_name", "data\\scenes\\common\\resources_subscreens.xml");

            XmlElement commonRes = _levelsDocXml.CreateElement("file");
            commonRes.SetAttribute("file_name", "data\\scenes\\common\\resources.xml");
            if (checkBoxRain.Checked)
            {
                XmlElement rainRes = _levelsDocXml.CreateElement("file");
                rainRes.SetAttribute("file_name", "data\\scenes\\common\\resources_rain.xml");
                resourcesNode.AppendChild(rainRes);
            }
            

            levelsXMLRoot.AppendChild(testSceneNode);
            testSceneNode.AppendChild(resourcesNode);

            resourcesNode.AppendChild(testSceneRes);
            resourcesNode.AppendChild(subRes);
            resourcesNode.AppendChild(commonRes);
            

            _levelsDocXml.Save(_fileNameLevelsXml);
        }

        private void CreateTexturesFolders()
        {
            DirectoryInfo testSceneTextures = new DirectoryInfo(Config.ScenesPath + "\\test_scene\\textures");
            testSceneTextures.Create();

            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].Text == "shader")
                {
                    DirectoryInfo shaderPicsFolder = new DirectoryInfo(Config.ScenesPath + "\\test_scene\\textures" + "\\shader_" + i);
                    shaderPicsFolder.Create();
                }
            }
        }

        private void CreateTexturePackFolder()
        {
            DirectoryInfo testSceneTextures = new DirectoryInfo(Config.ScenesPath + "\\test_scene\\texture_pack");
            testSceneTextures.Create();
        }

        private void CreateVideoFolders()
        {
            DirectoryInfo testSceneTextures = new DirectoryInfo(Config.ScenesPath + "\\test_scene\\video");
            testSceneTextures.Create();

            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].Text == "video")
                {
                    DirectoryInfo shaderPicsFolder = new DirectoryInfo(Config.ScenesPath + "\\test_scene\\video" + "\\video_" + i);
                    shaderPicsFolder.Create();
                }
            }
        }

        private void CreateScene(string str)
        {
            string filePath = str + "\\scene.xml";

            XmlDocument scene = new XmlDocument();
            XmlElement root = scene.CreateElement("scene");

            root.SetAttribute("include", "includes_lib.xml");
            root.SetAttribute("edit", "1");

            scene.AppendChild(root);

            XmlElement animations = scene.CreateElement("animations");
            animations.SetAttribute("include", "scenes_common;subscreens_common");

            XmlElement layers = scene.CreateElement("layers");

            XmlElement maps = scene.CreateElement("maps");
            maps.SetAttribute("include", "scenes_common;subscreens_common");

            root.AppendChild(animations);
            root.AppendChild(layers);
            root.AppendChild(maps);


            scene.Save(filePath);
        }

        private void CreateIncludesLib(string str)
        {
            string filePath = str + "\\includes_lib.xml";
            
            XmlDocument scene = new XmlDocument();
            XmlElement root = scene.CreateElement("include_files");

            scene.AppendChild(root);

            XmlElement scenes_common = scene.CreateElement("scenes_common");
            scenes_common.SetAttribute("file_name", "..\\common\\scenes_common.xml");

            XmlElement subscreens_common = scene.CreateElement("subscreens_common");
            subscreens_common.SetAttribute("file_name", "..\\common\\subscreens_common.xml");

            root.AppendChild(scenes_common);
            root.AppendChild(subscreens_common);

            scene.Save(filePath);
        }

        private void FillSceneXML(string typeItem, string filePath, string itemName, string itemSize, string itemFrames, string itemSpeed, string videoMode)
        {
            string fileNameSceneXml = "";

            fileNameSceneXml = filePath;

            if (File.Exists(fileNameSceneXml))
            {
                
                XmlDocument sceneFileForAmimation = new XmlDocument();

                sceneFileForAmimation.Load(fileNameSceneXml);

                XmlElement rootNode = sceneFileForAmimation.DocumentElement;

                string rootNodeName = rootNode.Name;
                if (typeItem == "shader")
                {
                    if (Convert.ToInt32(itemFrames) != 1)
                    {
                        CreateShaderAnimationSceneNode(sceneFileForAmimation, itemName, itemSize, itemFrames, itemSpeed);
                        CreateShaderMapSceneNode(sceneFileForAmimation, itemName);
                    }
                    CreateShaderLayerSceneNode(sceneFileForAmimation, itemName, itemSize, itemFrames);
                }
                else if (typeItem == "video")
                {
                    CreateVideoAnimationSceneNode(sceneFileForAmimation, itemName, itemSize, videoMode);
                    CreateVideoLayerSceneNode(sceneFileForAmimation, itemName, itemSize, videoMode);
                    CreateVideoMapSceneNode(sceneFileForAmimation, itemName);
                }
                else if (typeItem == "texture_pack")
                {
                    CreateTPackLayerSceneNode(sceneFileForAmimation, itemName, itemSize);
                   
                }
                
                sceneFileForAmimation.Save(fileNameSceneXml);
                labelCreateShader.Text = "successful";
            }
        }


#region "Create Shader in scene.xml"


        private void CreateShaderAnimationSceneNode(XmlDocument sceneFileForAmimation, string itemName, string itemSize, string itemFrames, string itemSpeed)
        {
            XmlElement rootNode = sceneFileForAmimation.DocumentElement;

            string rootNodeName = rootNode.Name;

            XmlElement sceneFileNodeXml = (XmlElement)sceneFileForAmimation.SelectSingleNode(rootNodeName + "/animations");

            XmlElement addedAnimationNameNode = sceneFileForAmimation.CreateElement(itemName);
                XmlElement addedAnimationShaderNameNode = sceneFileForAmimation.CreateElement("shader");

                addedAnimationShaderNameNode.SetAttribute("frames", "0" + " " + itemFrames);
                addedAnimationShaderNameNode.SetAttribute("loop", "1");
                addedAnimationShaderNameNode.SetAttribute("speed", itemSpeed);


                sceneFileNodeXml.AppendChild(addedAnimationNameNode);

                addedAnimationNameNode.AppendChild(addedAnimationShaderNameNode);

                XmlElement addedAnimationFadeNode = sceneFileForAmimation.CreateElement("fade");
                addedAnimationFadeNode.SetAttribute("alpha", "0" + " " + "1");
                addedAnimationFadeNode.SetAttribute("time", "0");
                addedAnimationNameNode.AppendChild(addedAnimationFadeNode);


                XmlElement addedAnimationWindowNode = sceneFileForAmimation.CreateElement("window");
                addedAnimationWindowNode.SetAttribute("enabled", "1");
                addedAnimationNameNode.AppendChild(addedAnimationWindowNode);
        }

        private void CreateShaderMapSceneNode(XmlDocument sceneFileForAmimation, string itemName)
        {
            XmlElement rootNode = sceneFileForAmimation.DocumentElement;

            string rootNodeName = rootNode.Name;

            XmlElement sceneLayerNodeXml = (XmlElement)sceneFileForAmimation.SelectSingleNode(rootNodeName + "/maps");

            XmlElement addedAnimationMapNode = sceneFileForAmimation.CreateElement(itemName);

            XmlElement addedAnimationSubscribeNode = sceneFileForAmimation.CreateElement("subscribe");

            addedAnimationSubscribeNode.SetAttribute("event", "_init");
            addedAnimationSubscribeNode.SetAttribute("animation", itemName);

            sceneLayerNodeXml.AppendChild(addedAnimationMapNode);
            addedAnimationMapNode.AppendChild(addedAnimationSubscribeNode);
        }

        private void CreateShaderLayerSceneNode(XmlDocument sceneFileForAmimation, string itemName, string itemSize, string itemFrames)
        {
            XmlElement rootNode = sceneFileForAmimation.DocumentElement;

            string rootNodeName = rootNode.Name;

            XmlElement sceneLayersNodeXml = (XmlElement)sceneFileForAmimation.SelectSingleNode(rootNodeName + "/layers");

            XmlElement addedAnimationLayerNode = sceneFileForAmimation.CreateElement(itemName);

            addedAnimationLayerNode.SetAttribute("shader", "test_scene/" + itemName);
            addedAnimationLayerNode.SetAttribute("size", itemSize);
            if (Convert.ToInt32(itemFrames) != 1)
            {
                addedAnimationLayerNode.SetAttribute("maps", itemName);
            }
            sceneLayersNodeXml.AppendChild(addedAnimationLayerNode);
        }
#endregion


#region "Create Shader in resources.xml"


        private void CreateResources(string str)
        {
            string fileNameSceneRecourcesXml = str + "\\resources.xml";
            XmlDocument sceneResources = new XmlDocument();
            XmlElement root = sceneResources.CreateElement("test_scene");
            sceneResources.AppendChild(root);
            sceneResources.Save(fileNameSceneRecourcesXml);
        }

        private void EditRecources(string filePath, string shaderName, string shaderSize, string shaderFrames)
        {
            string animName = "";

            string[] shSize = shaderSize.Split(' ');

            XmlDocument sceneRecourcesDocXml = new XmlDocument();
            sceneRecourcesDocXml.Load(filePath);

            XmlElement scenePlayerResNodeXml = (XmlElement)sceneRecourcesDocXml.SelectSingleNode("test_scene");
            XmlElement addedShaderNode = sceneRecourcesDocXml.CreateElement("shader");
            addedShaderNode.SetAttribute("name", shaderName);
            if (Convert.ToInt16(shaderFrames) > 0 && Convert.ToInt16(shaderFrames) < 100)
            {
                animName = "animation_00";
            }
            else
            {
                animName = "animation_000";
            }

            addedShaderNode.SetAttribute("texture_name", "textures\\" + shaderName + "\\" + animName);
            if (Convert.ToInt32(shaderFrames) != 1)
            {
                addedShaderNode.SetAttribute("frame_count", shaderFrames);
            }
            addedShaderNode.SetAttribute("temporary_textures", "1");
            scenePlayerResNodeXml.AppendChild(addedShaderNode);

            sceneRecourcesDocXml.Save(filePath);

            DirectoryInfo shaderPicsFolder = new DirectoryInfo(Config.ScenesPath + "\\test_scene\\textures\\" + shaderName);

            if (ddsPath.Exists)
            {
                foreach (FileInfo fi in ddsPath.GetFiles())
                {
                    if (fi.Extension.ToLower() != ".dds")
                    {
                        continue;
                    }

                    string[] ddsName = fi.Name.Split('x');
                    ddsName[1] = ddsName[1].Substring(0, ddsName[1].Length - 4);
                    if ((ddsName[0] != shSize[0]) || (ddsName[1] != shSize[1]))
                    {
                        continue;
                    }
                    else
                    {
                        for (int i = 0; i < Convert.ToInt16(shaderFrames); i++)
                        {
                            if (Convert.ToInt16(shaderFrames) > 0 && Convert.ToInt16(shaderFrames) < 100)
                            {
                                if (i < 10)
                                {
                                    fi.CopyTo(shaderPicsFolder + "\\animation_0" + i + ".dds");
                                }
                                else if ((i >= 10) && (i < 100))
                                {
                                    fi.CopyTo(shaderPicsFolder + "\\animation_" + i + ".dds");
                                }
                            }
                            else
                            {
                                if (i < 10)
                                {
                                    fi.CopyTo(shaderPicsFolder + "\\animation_00" + i + ".dds");
                                }
                                else if ((i >= 10) && (i < 100))
                                {
                                    fi.CopyTo(shaderPicsFolder + "\\animation_0" + i + ".dds");
                                }
                                else if ((i >= 100) && (i < 1000))
                                {
                                    fi.CopyTo(shaderPicsFolder + "\\animation_" + i + ".dds");
                                }
                            }
                        }
                    }
                }
            }
        }


#endregion



#region "Create Video in scene.xml"


        private void CreateVideoAnimationSceneNode(XmlDocument sceneFileForAmimation, string itemName, string itemSize, string videoMode)
        {
            XmlElement rootNode = sceneFileForAmimation.DocumentElement;

            string rootNodeName = rootNode.Name;

            XmlElement sceneFileNodeXml = (XmlElement)sceneFileForAmimation.SelectSingleNode(rootNodeName + "/animations");


            XmlElement addedAnimationNameNode = sceneFileForAmimation.CreateElement(itemName);
            XmlElement addedAnimationShaderNameNode = sceneFileForAmimation.CreateElement("video");

            addedAnimationShaderNameNode.SetAttribute("video_state", "play");
            addedAnimationShaderNameNode.SetAttribute("loop", "1");

            sceneFileNodeXml.AppendChild(addedAnimationNameNode);

            addedAnimationNameNode.AppendChild(addedAnimationShaderNameNode);

            XmlElement addedAnimationFadeNode = sceneFileForAmimation.CreateElement("fade");
            addedAnimationFadeNode.SetAttribute("alpha", "0" + " " + "1");
            addedAnimationFadeNode.SetAttribute("time", "0");
            addedAnimationNameNode.AppendChild(addedAnimationFadeNode);


            XmlElement addedAnimationWindowNode = sceneFileForAmimation.CreateElement("window");
            addedAnimationWindowNode.SetAttribute("enabled", "1");
            addedAnimationNameNode.AppendChild(addedAnimationWindowNode);
        }

        private void CreateVideoLayerSceneNode(XmlDocument sceneFileForAmimation, string itemName, string itemSize, string videoMode)
        {
            XmlElement rootNode = sceneFileForAmimation.DocumentElement;

            string rootNodeName = rootNode.Name;
            string videoPath = "data\\scenes\\test_scene\\video\\" + itemName + "\\" + itemName;

            XmlElement sceneLayersNodeXml = (XmlElement)sceneFileForAmimation.SelectSingleNode(rootNodeName + "/layers");

            XmlElement addedAnimationLayerNode = sceneFileForAmimation.CreateElement(itemName);

            addedAnimationLayerNode.SetAttribute("size", itemSize);
            addedAnimationLayerNode.SetAttribute("video_file", videoPath + ".ogv");
            if (Convert.ToInt16(videoMode) == 0)
            {
                addedAnimationLayerNode.SetAttribute("video_alpha_file", videoPath + "_alpha.ogv");
            }
            addedAnimationLayerNode.SetAttribute("maps", itemName);
            sceneLayersNodeXml.AppendChild(addedAnimationLayerNode);

            CopyVideoInSceneFolder(itemName, itemSize, videoMode);
        }

        private void CopyVideoInSceneFolder(string itemName, string itemSize, string videoMode)
        {
            DirectoryInfo sceneVideoFolder = new DirectoryInfo(Config.ScenesPath + "\\test_scene\\video\\" + itemName);
            itemSize = itemSize.Replace(' ', 'x');
            if (videoPath.Exists)
            {
                foreach (FileInfo fi in videoPath.GetFiles())
                {

                    if (fi.Extension.ToLower() != ".ogv")
                    {
                        continue;
                    }

                    string[] videoName = fi.Name.Split('_');

                    if (Convert.ToInt16(videoMode) == 1)
                    {
                        videoName[1] = videoName[1].Substring(0, videoName[1].Length - 4);
                        if ((videoName[0] != "hard") || (videoName[1] != itemSize))
                        {
                            continue;
                        }
                        fi.CopyTo(sceneVideoFolder + "\\" + itemName + ".ogv");
                    }
                    else
                    {
                        if (videoName.Length == 2)
                        {
                            videoName[1] = videoName[1].Substring(0, videoName[1].Length - 4);
                            if ((videoName[0] != "easy") || (videoName[1] != itemSize))
                            {
                                continue;
                            }
                            fi.CopyTo(sceneVideoFolder + "\\" + itemName + ".ogv");
                        }
                        else if (videoName.Length == 3)
                        {
                            videoName[2] = videoName[2].Substring(0, videoName[2].Length - 4);
                            if ((videoName[0] != "easy") || (videoName[1] != itemSize))
                            {
                                continue;
                            }
                            fi.CopyTo(sceneVideoFolder + "\\" + itemName + "_alpha.ogv");
                        }
                        
                        
                    }
                    
                }
            }
                    
        }


        private void CreateVideoMapSceneNode(XmlDocument sceneFileForAmimation, string itemName)
        {
            XmlElement rootNode = sceneFileForAmimation.DocumentElement;

            string rootNodeName = rootNode.Name;

            XmlElement sceneLayerNodeXml = (XmlElement)sceneFileForAmimation.SelectSingleNode(rootNodeName + "/maps");

            XmlElement addedAnimationMapNode = sceneFileForAmimation.CreateElement(itemName);

            XmlElement addedAnimationSubscribeNode = sceneFileForAmimation.CreateElement("subscribe");

            addedAnimationSubscribeNode.SetAttribute("event", "_init");
            addedAnimationSubscribeNode.SetAttribute("animation", itemName);

            sceneLayerNodeXml.AppendChild(addedAnimationMapNode);
            addedAnimationMapNode.AppendChild(addedAnimationSubscribeNode);
        }
    

#endregion

#region "Create Texture pack in scene.xml and resources.xml"


        private void CreateTPackLayerSceneNode(XmlDocument sceneFileForAmimation, string itemName, string itemSize)
        {
            XmlElement rootNode = sceneFileForAmimation.DocumentElement;

            string rootNodeName = rootNode.Name;

            XmlElement sceneLayersNodeXml = (XmlElement)sceneFileForAmimation.SelectSingleNode(rootNodeName + "/layers");

            XmlElement addedAnimationLayerNode = sceneFileForAmimation.CreateElement(itemName);

            addedAnimationLayerNode.SetAttribute("shader", "test_scene/" + itemName);
            addedAnimationLayerNode.SetAttribute("size", itemSize);
            
            sceneLayersNodeXml.AppendChild(addedAnimationLayerNode);
        }

        private void EditRecourcesAddTexturePack(string filePath, string shaderName, string shaderSize)
        {
            XmlDocument sceneRecourcesDocXml = new XmlDocument();
            sceneRecourcesDocXml.Load(filePath);

            XmlElement scenePlayerResNodeXml = (XmlElement)sceneRecourcesDocXml.SelectSingleNode("test_scene");
            XmlElement addedShaderNode = sceneRecourcesDocXml.CreateElement("shader");

            addedShaderNode.SetAttribute("name", shaderName);

            addedShaderNode.SetAttribute("texture_name", "texture_pack\\" + shaderName);
            addedShaderNode.SetAttribute("temporary_textures", "1");
            scenePlayerResNodeXml.AppendChild(addedShaderNode);

            sceneRecourcesDocXml.Save(filePath);

            DirectoryInfo shaderPicsFolder = new DirectoryInfo(Config.ScenesPath + "\\test_scene\\texture_pack");

            if (ddsPath.Exists)
            {
                foreach (FileInfo fi in ddsPath.GetFiles())
                {
                    if (fi.Extension.ToLower() != ".dds")
                    {
                        continue;
                    }

                    string[] ddsName = fi.Name.Split('x');
                    ddsName[1] = ddsName[1].Substring(0, ddsName[1].Length - 4);
                    if ((Convert.ToInt16(ddsName[0]) != 1024) || (Convert.ToInt16(ddsName[1]) != 512))
                    {
                        continue;
                    }
                    else
                    {
                        fi.CopyTo(shaderPicsFolder + "\\" + shaderName + ".dds");
                    }
                }
            }
        }

#endregion

        
    }
}
