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
using HiddenObjectStudio.Core.SceneManagement;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections;

namespace WindowsFormsApplication2
{
    public partial class CreateShaderForm : Form
    {
        SceneInfo _sceneInfo;
        List<string> _animationName;
		private Config Config;
        Scene _Scene;
        string _SceneName;
        
        public CreateShaderForm(SceneInfo inputSceneInfo)
        {
            InitializeComponent();

			Config = new Config();

            this._sceneInfo = inputSceneInfo;
            Location location = _sceneInfo.OwnerLocation;

            if (location.IsHiddenObject)
            {
                _Scene = new Scene();
                _Scene.LoadFromXml(Config.ScenesPath + "\\" + _sceneInfo.SceneFilePath);
                _Scene.Layers.DisplayInTreeView(treeViewLayers.Nodes);
                _SceneName = Path.GetFileNameWithoutExtension(Config.ScenesPath + "\\" + _sceneInfo.SceneFilePath);
            }
            else
            {
                treeViewLayers.Nodes.Add("Scene " + _sceneInfo.Name + " isn't HO scene!");
            }
        }

        private void buttonCreateShader_Click(object sender, EventArgs e)
        {
            if (!checkBoxAnimOnly.Checked)
            {
                EditSceneRecourcesXml(textBoxShaderName.Text, textBoxFrameCount.Text, _sceneInfo.FolderName);
            }

            if (checkBoxAnimation.Checked)
            {
                CreateAnimationAndMaps();
            }

            
            textBoxShaderName.Text = "";
            textBoxFrameCount.Text = "";
            checkBoxAnimation.Checked = false;
            textBoxAnimationName.Text = "";
            textBoxAnimationSpeed.Text = "";
            checkBoxLoop.Checked = false;
        }

        private void EditSceneRecourcesXml(string shaderName, string frameCount, string sceneName)
        {
            string fileNameSceneRecourcesXml = AppDomain.CurrentDomain.BaseDirectory + "data\\scenes\\" + sceneName + "\\resources.xml";

            XmlDocument sceneRecourcesDocXml = new XmlDocument();
            sceneRecourcesDocXml.Load(fileNameSceneRecourcesXml);

            XmlElement scenePlayerResNodeXml = (XmlElement)sceneRecourcesDocXml.SelectSingleNode(sceneName);
            XmlElement addedShaderNode = sceneRecourcesDocXml.CreateElement("shader");
            addedShaderNode.SetAttribute("name", shaderName);
            addedShaderNode.SetAttribute("texture_name", "textures\\" + shaderName + "\\animation_00");
            addedShaderNode.SetAttribute("frame_count", frameCount);
            addedShaderNode.SetAttribute("temporary_textures", "1");
            scenePlayerResNodeXml.AppendChild(addedShaderNode);

            sceneRecourcesDocXml.Save(fileNameSceneRecourcesXml);
            labelCreateShader.Text = "successful";
        }

        private void CreateAnimationAndMaps()
        {
            string fileNameSceneXml = "";

            string loopState;

            fileNameSceneXml = Config.ScenesPath + "\\" + _sceneInfo.SceneFilePath;

            if ((fileNameSceneXml != "") && (_sceneInfo.FolderName != ""))
            {

                XmlDocument sceneFileForAmimation = new XmlDocument();

                sceneFileForAmimation.Load(fileNameSceneXml);

                XmlElement rootNode = sceneFileForAmimation.DocumentElement;

                string rootNodeName = rootNode.Name;

                XmlElement sceneFileNodeXml = (XmlElement)sceneFileForAmimation.SelectSingleNode(rootNodeName + "/animations");

                XmlElement addedAnimationNameNode = sceneFileForAmimation.CreateElement(textBoxAnimationName.Text);
                XmlElement addedAnimationShaderNameNode = sceneFileForAmimation.CreateElement("shader");

                addedAnimationShaderNameNode.SetAttribute("frames", comboBoxMin.SelectedIndex.ToString() + " " + comboBoxMax.SelectedIndex.ToString());
                if (checkBoxLoop.Checked == true)
                {
                    loopState = "1";
                }
                else
                {
                    loopState = "0";
                }
                addedAnimationShaderNameNode.SetAttribute("loop", loopState);
                addedAnimationShaderNameNode.SetAttribute("speed", textBoxAnimationSpeed.Text);


                sceneFileNodeXml.AppendChild(addedAnimationNameNode);

                addedAnimationNameNode.AppendChild(addedAnimationShaderNameNode);

                if (checkBoxFade.Checked)
                {
                    XmlElement addedAnimationFadeNode = sceneFileForAmimation.CreateElement("fade");
                    addedAnimationFadeNode.SetAttribute("alpha", textBoxMinAlpha.Text + " " + textBoxMaxAlpha.Text);
                    addedAnimationFadeNode.SetAttribute("time", textBoxFadeTime.Text);

                    addedAnimationNameNode.AppendChild(addedAnimationFadeNode);
                }

                if (checkBoxWindow.Checked)
                {
                    XmlElement addedAnimationWindowNode = sceneFileForAmimation.CreateElement("window");
                    addedAnimationWindowNode.SetAttribute("enabled", textBoxWindow.Text);
                    addedAnimationNameNode.AppendChild(addedAnimationWindowNode);
                }

                if (checkBoxCreateMap.Checked)
                {
                    XmlElement sceneLayerNodeXml = (XmlElement)sceneFileForAmimation.SelectSingleNode(rootNodeName + "/maps");
                    XmlElement addedAnimationMapNode = sceneFileForAmimation.CreateElement(textBoxShaderName.Text);
                    XmlElement addedAnimationSubscribeNode = sceneFileForAmimation.CreateElement("subscribe");
                    string fireEvent = textBoxFireEvent.Text;

                    if (fireEvent == String.Empty)
                    {
                        fireEvent = "_init";
                        addedAnimationSubscribeNode.SetAttribute("event", fireEvent);
                    }
                    else
                    {
                        addedAnimationSubscribeNode.SetAttribute("event", fireEvent);
                    }
                    addedAnimationSubscribeNode.SetAttribute("animation", comboBoxMapAnimation.SelectedItem.ToString());

                    sceneLayerNodeXml.AppendChild(addedAnimationMapNode);
                    addedAnimationMapNode.AppendChild(addedAnimationSubscribeNode);
                }
                //<active_zone_hall2floor2>
                //<subscribe event="use_stair_inv" animation="instant_show" />
                // </active_zone_hall2floor2>
                if (checkBoxCreateLayer.Checked)
                {//<dust shader="stair_break/dust" position="-12 -13" enabled="0" alpha="0" maps="dust" />
                    XmlElement sceneLayerNodeXml = (XmlElement)sceneFileForAmimation.SelectSingleNode(rootNodeName + "/layers");
                    XmlElement addedAnimationLayerNode = sceneFileForAmimation.CreateElement(textBoxShaderName.Text);
                    addedAnimationLayerNode.SetAttribute("shader", _sceneInfo.FolderName + "/" + textBoxShaderName.Text);

                    sceneLayerNodeXml.AppendChild(addedAnimationLayerNode);
                }

                sceneFileForAmimation.Save(fileNameSceneXml);
                labelCreateShader.Text = "successful";
            }
        }

        private void CreateShaderForm_Load(object sender, EventArgs e)
        {
           // SceneInfo sceneInfo = _sceneInfo;
        }

        private void textBoxFrameCount_TextChanged(object sender, EventArgs e)
        {
            List<string> _comboBoxMinValue = new List<string>();
            List<string> _comboBoxMaxValue = new List<string>();
            try
            {
                int framesMaxValue = Convert.ToInt16(textBoxFrameCount.Text);
                for (int i = 0; i < framesMaxValue; i++)
                {
                    _comboBoxMinValue.Add(Convert.ToString(i));
                    _comboBoxMaxValue.Add(Convert.ToString(i));
                }
                comboBoxMin.DataSource = _comboBoxMinValue;
                comboBoxMax.DataSource = _comboBoxMaxValue;
            }
            catch { }
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

        private void txtTypeAlpha_KeyPress(object sender, KeyPressEventArgs e)
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

        private void checkBoxAnimation_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAnimation.Checked == true)
            {
                groupBox2.Enabled = true;
            }
            else
            {
                groupBox2.Enabled = false;
            }
        }

        private void textBoxMinAlpha_TextChanged(object sender, EventArgs e)
        {
            string textBoxMinAlphaText = textBoxMinAlpha.Text;
            if (textBoxMinAlphaText != String.Empty)
            {
                int minAlphaValue = Convert.ToInt16(textBoxMinAlpha.Text);
                if ((minAlphaValue <= 1) && (minAlphaValue >= 0))
                {
                    //N00Bstvo ppc ya pisal kogdato(specom ostavlu)
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("0 <= AlphaValue<= 1");
                    textBoxMinAlpha.Text = "";
                }
            }
        }

        private void textBoxMaxAlpha_TextChanged(object sender, EventArgs e)
        {
            string textBoxMaxAlphaText = textBoxMaxAlpha.Text;
            if (textBoxMaxAlphaText != String.Empty)
            {
                int maxAlphaValue = Convert.ToInt16(textBoxMaxAlpha.Text);
                if ((maxAlphaValue <= 1) && (maxAlphaValue >= 0))
                {
                    //N00Bstvo ppc ya pisal kogdato
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("0 <= AlphaValue<= 1");
                    textBoxMaxAlpha.Text = "";
                }
            }
        }

        private void checkBoxFade_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxFade.Checked)
            {
                labelAlphaInFade.Enabled = true;
                label15.Enabled = true;
                textBoxMaxAlpha.Enabled = true;
                textBoxMinAlpha.Enabled = true;
                label16.Enabled = true;
                textBoxFadeTime.Enabled = true;
            }
            else
            {
                labelAlphaInFade.Enabled = false;
                label15.Enabled = false;
                textBoxMaxAlpha.Enabled = false;
                textBoxMinAlpha.Enabled = false;
                label16.Enabled = false;
                textBoxFadeTime.Enabled = false;
            }
        }

        private void checkBoxWindow_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxWindow.Checked)
            {
                textBoxWindow.Enabled = true;
                label17.Enabled = true;
            }
            else
            {
                textBoxWindow.Enabled = false;
                label17.Enabled = false;
            }
        }

        private void textBoxWindow_TextChanged(object sender, EventArgs e)
        {
            string textBoxMaxAlphaText = textBoxWindow.Text;
            if (textBoxMaxAlphaText != String.Empty)
            {
                int maxEnabledValue = Convert.ToInt16(textBoxWindow.Text);
                if ((maxEnabledValue <= 1) && (maxEnabledValue >= 0))
                {
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("EnabledValue = 0 || 1");
                    textBoxWindow.Text = "";
                }
            }
        }

        private void checkBoxCreateMap_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCreateMap.Checked)
            {
                textBoxFireEvent.Enabled = true;
                label18.Enabled = true;
                label19.Enabled = true;
                comboBoxMapAnimation.Enabled = true;
            }
            else
            {
                textBoxFireEvent.Enabled = false;
                label18.Enabled = false;
                label19.Enabled = false;
                comboBoxMapAnimation.Enabled = false;
            }
        }

        private void comboBoxMapAnimation_Click(object sender, EventArgs e)
        {
            _animationName = new List<string>();
            _animationName.Add("open_item");
            _animationName.Add("close_item");
            _animationName.Add("instant_show");
            _animationName.Add("instant_hide");
            _animationName.Add(textBoxAnimationName.Text);
            comboBoxMapAnimation.DataSource = _animationName;
        }

        private void InteractiveLayerModify(Layer layer)
        {
            layer.SetAttribute("cursor", "hand");
            layer.SetAttribute("maps", layer.Name);
        }

        private void AddCoverAllForInteractive()
        {
            bool coverAllExist = false;
            string coverAllMapName;

            if ((_Scene.Layers.GetLayer("cover_all") != null) || (_Scene.Layers.GetLayer("active_zone_cover_all") != null))
            {
                coverAllExist = true;
            }
            
            if (!coverAllExist)
            {
                //<cover_all size="1024 1024" enabled="0" alpha="0" no_rapid_clicks="1" maps="cover_all"/>
                Layer newLayer = new Layer();
                newLayer.Name = "cover_all";
                newLayer.SetAttribute("size", "1024 1024");
                newLayer.SetAttribute("enabled", "0");
                newLayer.SetAttribute("alpha", "0");
                newLayer.SetAttribute("no_rapid_clicks", "1");
                newLayer.SetAttribute("maps", newLayer.Name);
                coverAllMapName = newLayer.Name;

                _Scene.Layers.Add(newLayer);
            }
            else
            {
                Layer newLayer;
                if (_Scene.Layers.GetLayer("cover_all") != null)
                {
                   newLayer = _Scene.Layers.GetLayer("cover_all");
                }
                else
                {
                   newLayer = _Scene.Layers.GetLayer("active_zone_cover_all");
                }

                newLayer.SetAttribute("size", "1024 1024");
                newLayer.SetAttribute("enabled", "0");
                newLayer.SetAttribute("alpha", "0");
                newLayer.SetAttribute("no_rapid_clicks", "1");

                coverAllMapName = newLayer.GetAttribValue("maps");
                if (coverAllMapName == String.Empty)
                {
                    newLayer.SetAttribute("maps", newLayer.Name);
                    coverAllMapName = newLayer.Name;
                }

                
            }
            
            AddCoverAllMap(coverAllMapName);
        }

        private void AddCoverAllMap(string mapName)
        {
            Map map = _Scene.Maps.GetMap(mapName);
            if (map == null)
            {
                map = new Map(mapName);

                map.CreateSubsrcibtion("hide_cover_all", "instant_hide");
                map.CreateSubsrcibtion("show_cover_all", "instant_show");
                _Scene.Maps.Add(map);
            }
            else
            {
                bool existHide = false;
                bool existShow = false;
                foreach (Subscription sub in map.SubScriptions)
                {
                    if (sub.CheckSubcribeToExist("hide_cover_all", "instant_hide"))
                    {
                        existHide = true;
                    }

                    if (sub.CheckSubcribeToExist("show_cover_all", "instant_show"))
                    {
                        existShow = true;
                    }
                }
                if (!existHide)
                {
                    map.CreateSubsrcibtion("hide_cover_all", "instant_hide");
                }
                if (!existShow)
                {
                    map.CreateSubsrcibtion("show_cover_all", "instant_show");
                }
            }
            
            
        }


        private void AddAnimationsPickDropPut()
        {
            //Animation Pick
            Animation animationPick = new Animation();
            animationPick.Name = "pick";
            SubAnimation followMouseFollow = animationPick.CreateSubAnimation(SubAnimationType.Follow_mouse);
            followMouseFollow.AddAttribut("state", "pick");

            SubAnimation windowMouseFollow = animationPick.CreateSubAnimation(SubAnimationType.Window);
            windowMouseFollow.AddAttribut("enabled", "0");

            SubAnimation fadeMouseFollow = animationPick.CreateSubAnimation(SubAnimationType.Fade);
            fadeMouseFollow.AddAttribut("alpha", "0 1");

            //Animation Drop
            Animation animationDrop = new Animation();
            animationDrop.Name = "drop";
            SubAnimation followMouseDrop = animationDrop.CreateSubAnimation(SubAnimationType.Follow_mouse);
            followMouseDrop.AddAttribut("state", "drop");

            SubAnimation windowMouseDrop = animationDrop.CreateSubAnimation(SubAnimationType.Window);
            windowMouseDrop.AddAttribut("enabled", "1");
            
            //Animation Put
            Animation animationPut = new Animation();
            animationPut.Name = "put";
            SubAnimation followMouseApply = animationPut.CreateSubAnimation(SubAnimationType.Follow_mouse);
            followMouseApply.AddAttribut("state", "put");

            SubAnimation fadeMouseApply = animationPut.CreateSubAnimation(SubAnimationType.Fade);
            fadeMouseApply.AddAttribut("alpha", "1 0");
            fadeMouseApply.AddAttribut("time", "0.5");

            SubAnimation windowMouseApply = animationPut.CreateSubAnimation(SubAnimationType.Window);
            windowMouseApply.AddAttribut("enabled", "0");

            
            _Scene.Animations.Add(animationPick);
            _Scene.Animations.Add(animationDrop);
            _Scene.Animations.Add(animationPut);

            
        }

        private void AddDropZoneLayer(Layer layer)
        {
            Layer dropZoneLayer;
            if (_Scene.Layers.GetLayer("drop_zone_" + layer.Name) != null)
            {
                dropZoneLayer = _Scene.Layers.GetLayer("drop_zone_" + layer.Name);
                MessageBox.Show(dropZoneLayer.Name + "already exists!");
            }
            else
            {
                dropZoneLayer = new Layer();
                dropZoneLayer.Name = "drop_zone_" + layer.Name;
                dropZoneLayer.SetAttribute("size", "600 600");
                dropZoneLayer.SetAttribute("position", "200 200");
                dropZoneLayer.SetAttribute("cursor", "loupe");
                dropZoneLayer.SetAttribute("maps", dropZoneLayer.Name);

                _Scene.Layers.Add(dropZoneLayer);
            }

            AddDropZoneMap(layer);

        }

        private void AddDropZoneMap(Layer layer)
        {
            Map map = new Map("drop_zone_" + layer.Name);

            map.CreateSubsrcibtion(layer.Name + "_put", "instant_hide");

            _Scene.Maps.Add(map);
        }

        private void AddLayerMap(Layer layer)
        {
            Map map = new Map(layer.Name);

            map.CreateSubsrcibtion(layer.Name + "_pick", "pick");
            map.CreateSubsrcibtion(layer.Name + "_drop", "drop");
            map.CreateSubsrcibtion(layer.Name + "_put", "put");

            _Scene.Maps.Add(map);
        }

        private void AddPartToScript(Layer layer)
        {
            string sceneFilePath = Config.ScenesPath + "\\" + _sceneInfo.SceneFilePath;

            sceneFilePath = sceneFilePath.Substring(0, sceneFilePath.Length - 3);

            string scriptFilePath = sceneFilePath + "lua";

            string[] arrayLua = File.ReadAllLines(scriptFilePath);

            int indexFuncUpdate = 10000;

            for (int i = 0; i < arrayLua.Length; i++)
            {
                if (arrayLua[i].Contains("function update(scene)"))
                {
                    indexFuncUpdate = i;
                }
            }
            
            Array.Resize(ref arrayLua, arrayLua.Length + 30);

            if (indexFuncUpdate != 10000)
            {
                string c;
                for (int i = arrayLua.Length - 1; i > indexFuncUpdate + 30; i--)
                {
                    c = arrayLua[i];
                    arrayLua[i] = arrayLua[i - 30];
                    arrayLua[i - 30] = c;
                }
            }

            if (indexFuncUpdate != 10000)
            {
                string variableName = _SceneName + "_" + layer.Name;

                arrayLua[indexFuncUpdate + 1] = "";
                arrayLua[indexFuncUpdate + 2] = " -- pick put drop on " + layer.Name;
                arrayLua[indexFuncUpdate + 3] = "     if scene:is_clicked_on_layer(\"" + layer.Name + "\")";
                arrayLua[indexFuncUpdate + 4] = "     and scene:get_var(\"" + variableName + "\") == \"\"";
                arrayLua[indexFuncUpdate + 5] = "     then";
                arrayLua[indexFuncUpdate + 6] = "         scene:set_var(\"" + variableName + "\", \"picked\");";
                arrayLua[indexFuncUpdate + 7] = "         scene:fire_event(\""+ layer.Name + "_pick\");";
                arrayLua[indexFuncUpdate + 8] = "         scene:fire_event(\"show_cover_all\");";
                arrayLua[indexFuncUpdate + 9] = "         scene:set_var(\"_hide_cursor\", \"1\");";
                arrayLua[indexFuncUpdate + 10] = "    elseif scene:is_clicked_on_layer(\"drop_zone_" + layer.Name+ "\")";
                arrayLua[indexFuncUpdate + 11] = "    and scene:get_var(\"" + variableName + "\") == \"picked\"";
                arrayLua[indexFuncUpdate + 12] = "    then";
                arrayLua[indexFuncUpdate + 13] = "        scene:fire_event(\""+ layer.Name + "_put\");";
                arrayLua[indexFuncUpdate + 14] = "        scene:set_var(\"" + variableName + "\", \"put\");";
                arrayLua[indexFuncUpdate + 15] = "        scene:fire_event(\"hide_cover_all\");";
                arrayLua[indexFuncUpdate + 16] = "        scene:set_var(\"_hide_cursor\", \"\");";
                arrayLua[indexFuncUpdate + 17] = "        scene:play_sound(\"sounds/scenes/lynn_room_ho/propeller\")";
                arrayLua[indexFuncUpdate + 18] = "    elseif scene:is_clicked_on_layer(\"drop_zone_" + layer.Name+ "\")";
                arrayLua[indexFuncUpdate + 19] = "    and scene:get_var(\"" + variableName + "\") == \"\"";
                arrayLua[indexFuncUpdate + 20] = "    then";
                arrayLua[indexFuncUpdate + 21] = "        scene:set_var(\"_show_comment\", \"lynn_room_ho/comment_propeller_123\");";
                arrayLua[indexFuncUpdate + 22] = "    elseif scene:is_key_pressed_once(\"MOUSE1\")";
                arrayLua[indexFuncUpdate + 23] = "    and scene:get_var(\"" + variableName + "\") == \"picked\"";
                arrayLua[indexFuncUpdate + 24] = "    then";
                arrayLua[indexFuncUpdate + 25] = "        scene:fire_event(\"hide_cover_all\");";
                arrayLua[indexFuncUpdate + 26] = "        scene:fire_event(\""+ layer.Name + "_drop\");";
                arrayLua[indexFuncUpdate + 27] = "        scene:set_var(\"_hide_cursor\", \"\");";
                arrayLua[indexFuncUpdate + 28] = "        scene:set_var(\"" + variableName + "\", \"\");";
                arrayLua[indexFuncUpdate + 29] = "    end";
                arrayLua[indexFuncUpdate + 30] = "";

            }


            File.WriteAllLines(scriptFilePath, arrayLua);
        }

        private void buttonCreateInteractiveItem_Click(object sender, EventArgs e)
        {
            if (treeViewLayers.SelectedNode != null)
            {
                Layer layer = (Layer)treeViewLayers.SelectedNode.Tag;
                
                AddAnimationsPickDropPut();
                AddCoverAllForInteractive();
                InteractiveLayerModify(layer);
                AddLayerMap(layer);
                AddDropZoneLayer(layer);
                AddPartToScript(layer);
                
                _Scene.SaveToXml(Config.ScenesPath + "\\" + _sceneInfo.SceneFilePath);

                MessageBox.Show("Done!");
            }
            else
            {
                MessageBox.Show("Select Layer first!");
            }
        }

        private void treeViewLayers_AfterSelect(object sender, TreeViewEventArgs e)
        {
            textBoxSelected.Text = treeViewLayers.SelectedNode.Text;
        }

    }
}
