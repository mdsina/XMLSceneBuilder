using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.IO;
using HiddenObjectStudio.Core;

namespace HiddenObjectsXMLBuilder
{
	class Scene 
	{
		private BuilderConfig _builderConfig;
		private BuildOptions _buildOptions;
		private XmlDocument _sceneXmlDoc;
		private XmlElement _sceneRoot;
		private XmlElement _layersNode;
		private XmlElement _mapsNode;
		private XmlElement _animationsNode;
		private XmlElement _scriptsNode;

		private string _xmlFileName;

		private string _scriptFileName;

		private const string CollectAnimationName = "collect_animation";
		private string SceneRootNodeName = "scene";
		private const string LayersNodeName = "layers";
		private const string MapsNodeName = "maps";
		private const string AnimationsNodeName = "animations";
		private const string ScriptsNodeName = "scripts";

        public bool FoundParentNode(string _nodeName, XmlNode _tNode)
        {
            for (int i = 0; i < _tNode.ChildNodes.Count; i++)
            {
                if (_tNode.ChildNodes[i].Name == _nodeName)
                {
                    return true;
                }
            }
            return false;
        }

        

		public Scene(BuilderConfig builderConfig, BuildOptions buildOptions, string sceneName)
		{
			_builderConfig = builderConfig;
			_buildOptions = buildOptions;

            _scriptFileName = _buildOptions.sceneName + sceneName + ".lua";

            _xmlFileName = buildOptions.dstFolder + "\\" + buildOptions.sceneName + sceneName + ".xml";

			_sceneXmlDoc = new XmlDocument();

            SceneRootNodeName = buildOptions.sceneName + sceneName;

			if (_buildOptions.rebuildScene)
			{
				if (File.Exists(_xmlFileName))
				{
					_sceneXmlDoc.Load(_xmlFileName);
				}
			}
		
			_sceneRoot = (XmlElement)_sceneXmlDoc.DocumentElement;



			if (_sceneRoot == null)
			{
				_sceneRoot = _sceneXmlDoc.CreateElement(SceneRootNodeName);
				_sceneRoot.SetAttribute("include", _builderConfig.IncludesLibFileName);
				_sceneRoot.SetAttribute("edit", "1");
				_sceneXmlDoc.AppendChild(_sceneRoot);
			}

			AddScriptsNodeIfNeeded();

			AddAnimationsNodeIfNeeded();

			AddLayersNodeIfNeeded();

			AddMapsNodeIfNeeded();

		}

		public void UpdateNode(FileName fn)
		{
			XmlElement layerNode = (XmlElement)_layersNode.SelectSingleNode(fn.NodeName);

			if (layerNode != null)
			{
				if (fn.IsCollectableItem)
				{
					AddCollectAnimationIfNeeded(layerNode);
				}
			}
		}

		public void ProcessNode(FileName fn)
		{
            if (fn.IsWideTexture)
            {
                ProcessWideTextureNode(fn, WidePart.LeftPart);
                ProcessWideTextureNode(fn, WidePart.CenterPart);
                ProcessWideTextureNode(fn, WidePart.RightPart);
            }
            else
            {
                ProcessNormalTextureNode(fn);
            }
		}

		public void ProcessWideTextureNode(FileName fn, WidePart widePart)
		{
			try
			{
				XmlElement layerNode = (XmlElement)_layersNode.SelectSingleNode(fn.GetWideNodeName(widePart));

				if (layerNode == null)
				{
					layerNode = _sceneXmlDoc.CreateElement(fn.GetWideNodeName(widePart));

					layerNode.SetAttribute("texture_name", fn.GetWideTextureName(widePart));

					layerNode.SetAttribute("texture_pack", _buildOptions.sceneName + "/" + _builderConfig.TexturePackName);

					_layersNode.AppendChild(layerNode);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error on " + fn.FullFileName);

				throw ex;
			}
		}

		public void ProcessNormalTextureNode(FileName fn)
		{
			try
			{
				XmlElement layerNode = (XmlElement)_layersNode.SelectSingleNode(fn.NodeName);

				if (layerNode == null)
				{
					layerNode = _sceneXmlDoc.CreateElement(fn.NodeName);

					layerNode.SetAttribute("texture_name", fn.TextureName);

					layerNode.SetAttribute("texture_pack", _buildOptions.sceneName + "/" + _builderConfig.TexturePackName);

					if (fn.IsDropZone)
					{
						layerNode.SetAttribute("accepts_items", fn.AcceptsItemName);
					}

					_layersNode.AppendChild(layerNode);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error on " + fn.FullFileName);

				throw ex;
			}
		}

		public void Save()
		{
			//XmlWriter writer = new XmlTextWriter(, Encoding.GetEncoding("windows-1251"));

			if (_buildOptions.isSubscreen)
			{
				AddCloseButton();	
			}

            if (_buildOptions.isMinigame)
            {
                AddMinigameNode();
            }

            if (_buildOptions.hummingBird)
            {
				AddHummingBird();
            }

            if (_buildOptions.morfing)
            {
                AddMorfingObject();
            }
			CreateIncludesLib();

			CreateScript();

			_sceneXmlDoc.Save(_xmlFileName);
		}

        public void AddMinigameNode()
        {
            if (!FoundParentNode("minigame", _layersNode))
            {
                XmlElement minigameNode = _sceneXmlDoc.CreateElement("minigame");

                minigameNode.SetAttribute("mini_game_name", _buildOptions.sceneName);
                minigameNode.SetAttribute("maps", "minigame");
                minigameNode.SetAttribute("enabled", "0");

                _layersNode.AppendChild(minigameNode);
            }

            if (!FoundParentNode("reset_button", _layersNode))
            {
                XmlElement resetNode = _sceneXmlDoc.CreateElement("reset_button");

                resetNode.SetAttribute("position", "272 622");
                resetNode.SetAttribute("alpha", "0");
                resetNode.SetAttribute("template", "mini_games_common:mini_game_reset_button");

                _layersNode.AppendChild(resetNode);

            }
        }

		public void AddAnimationsNodeIfNeeded()
		{
			_animationsNode = (XmlElement)_sceneRoot.SelectSingleNode(AnimationsNodeName);
			if (_animationsNode == null)
			{
				_animationsNode = _sceneXmlDoc.CreateElement(AnimationsNodeName);
				_sceneRoot.AppendChild(_animationsNode);
			}

			if (!_animationsNode.HasAttribute("include"))
			{
				string includes = "scenes_common";

				if (_buildOptions.isSubscreen)
				{
					includes += ";subscreens_common";
				}
                if (_buildOptions.hummingBird)
                {
                    includes += ";humming_birds";
                }
                if (_buildOptions.fadeAnimation)
                {
                    includes += ";ncux_fade_animation";
                }
                if (_buildOptions.morfing)
                {
                    includes += ";morfing";
                }
                if (_buildOptions.isMinigame)
                {
                    includes += ";mini_games_common";
                }
				_animationsNode.SetAttribute("include", includes);
			}

		}

		public void AddScriptsNodeIfNeeded()
		{
			_scriptsNode = (XmlElement)_sceneRoot.SelectSingleNode(ScriptsNodeName);
			if (_scriptsNode == null)
			{
				_scriptsNode = _sceneXmlDoc.CreateElement(ScriptsNodeName);
				_scriptsNode.InnerXml = "<script file_name=\""  + _scriptFileName +  "\"/>";
				_sceneRoot.AppendChild(_scriptsNode);
                string includeScripts = "";
                if (_buildOptions.ee)
                {
                    includeScripts += "<include file_name=\"..\\common\\ee.lua\"/>";
                }
                if (_buildOptions.hummingBird)
                {
                    includeScripts += "<include file_name=\"..\\common\\humming_birds.lua\"/>";
                }
                if (_buildOptions.someFuncs)
                {
                    includeScripts += "<include file_name=\"..\\common\\some_funcs.lua\"/>";
                }
                if (_buildOptions.fadeAnimation)
                {
                    includeScripts += "<include file_name=\"..\\common\\ncux_fade_animation.lua\"/>";
                }
                if (_buildOptions.isMinigame)
                {
                    includeScripts += "<include file_name=\"..\\common\\mini_games_common.lua\"/>";
                }
                if (includeScripts.Length != 0)
                {
                    _scriptsNode.FirstChild.InnerXml = includeScripts;
                }
            }
		}

		public void AddMapsNodeIfNeeded()
		{
			_mapsNode = (XmlElement)_sceneRoot.SelectSingleNode(MapsNodeName);
			if (_mapsNode == null)
			{
				_mapsNode = _sceneXmlDoc.CreateElement(MapsNodeName);
                if (_buildOptions.isMinigame)
                {
                    XmlElement _mgNode = _sceneXmlDoc.CreateElement("minigame");
                    XmlElement _mgNode_subscribe_show = _sceneXmlDoc.CreateElement("subscribe");

                    _mgNode_subscribe_show.SetAttribute("event", "show_reset_button");
                    _mgNode_subscribe_show.SetAttribute("animation", "instant_show");

                    _mgNode.AppendChild(_mgNode_subscribe_show);

                    XmlElement _mgNode_subscribe_hide = _sceneXmlDoc.CreateElement("subscribe");

                    _mgNode_subscribe_hide.SetAttribute("event", "hide_reset_button");
                    _mgNode_subscribe_hide.SetAttribute("animation", "instant_hide");

                    _mgNode.AppendChild(_mgNode_subscribe_hide);

                    _mapsNode.AppendChild(_mgNode);
                    
                }
				_sceneRoot.AppendChild(_mapsNode);
			}

			if (!_mapsNode.HasAttribute("include"))
			{
				string includes = "scenes_common";

				if (_buildOptions.isSubscreen)
				{
					includes += ";subscreens_common";
				}
                if (_buildOptions.hummingBird)
                {
                    includes += ";humming_birds";
                }
                if (_buildOptions.fadeAnimation)
                {
                    includes += ";ncux_fade_animation";
                }
                if (_buildOptions.morfing)
                {
                    includes += ";morfing";
                }
                if (_buildOptions.isMinigame)
                {
                    includes += ";mini_games_common";
                }
				_mapsNode.SetAttribute("include", includes);
			}
		}

		private void AddLayersNodeIfNeeded()
		{
			_layersNode = (XmlElement)_sceneRoot.SelectSingleNode(LayersNodeName);

			if (_layersNode == null)
			{
				_layersNode = _sceneXmlDoc.CreateElement(LayersNodeName);

				_sceneRoot.AppendChild(_layersNode);

				if (_buildOptions.isSubscreen)
				{
					XmlElement malevichNode	= _sceneXmlDoc.CreateElement("malevich");

					malevichNode.SetAttribute("template", "subscreens_common:malevich");

					_layersNode.AppendChild(malevichNode);
				}

			}
		}

		private void AddCollectAnimationIfNeeded(XmlElement layerXmlNode)
		{
			string eventName = "collect_" + layerXmlNode.Name;

			XmlElement collectItemEventNode = (XmlElement)_mapsNode.SelectSingleNode(eventName);

			if (collectItemEventNode == null)
			{
				collectItemEventNode = _sceneXmlDoc.CreateElement(eventName);
				collectItemEventNode.SetAttribute("mouse_click", layerXmlNode.Name);

				_mapsNode.AppendChild(collectItemEventNode);
			}

			XmlElement layerEventsNode = (XmlElement)layerXmlNode.SelectSingleNode(MapsNodeName);
			if (layerEventsNode == null)
			{
				layerEventsNode = _sceneXmlDoc.CreateElement(MapsNodeName);
			}
			
			XmlElement layerEventNode = (XmlElement)layerEventsNode.SelectSingleNode(eventName);
			if (layerEventNode == null)
			{
				layerEventNode = _sceneXmlDoc.CreateElement(eventName);
				layerEventNode.SetAttribute("animation", CollectAnimationName);
				layerEventsNode.AppendChild(layerEventNode);

				if (layerEventsNode.ParentNode == null)
				{
					layerXmlNode.AppendChild(layerEventsNode);
				}
			}
		}

		private void CreateIncludesLib()
		{
			string includesLibFullFileName	= _buildOptions.dstFolder + "\\" +  _builderConfig.IncludesLibFileName;

			if (!File.Exists(includesLibFullFileName))
			{
				XmlDocument includesXml = new XmlDocument();

				string includesSection = @"<include_files>";

				includesSection += @"<scenes_common file_name=""..\common\scenes_common.xml""/>";

				if (_buildOptions.isSubscreen)
				{
					includesSection += @"<subscreens_common file_name=""..\common\subscreens_common.xml""/>";
				}

                if (_buildOptions.hummingBird)
                {
                    includesSection += @"<humming_birds file_name=""..\common\humming_birds.xml""/>";
                }
                if (_buildOptions.fadeAnimation)
                {
                    includesSection += @"<ncux_fade_animation file_name=""..\common\ncux_fade_animation.xml""/>";
                }
                if (_buildOptions.morfing)
                {
                    includesSection += @"<morfing file_name=""..\common\morfing.xml"" />";
                }
                if (_buildOptions.isMinigame)
                {
                    includesSection += @"<mini_games_common file_name=""..\common\mini_games_common.xml"" />";
                }
				includesSection += @"</include_files>";
				includesXml.InnerXml = includesSection;

				includesXml.Save(includesLibFullFileName);
			}
		}

		private void CreateScript()
		{
			string scriptFullFileName = HiddenObjectStudio.Core.Tools.AppendSlashIfNeeded(_buildOptions.dstFolder) + _scriptFileName;

			if (!File.Exists(scriptFullFileName))
			{
				StreamWriter sw = File.CreateText(scriptFullFileName);

				sw.WriteLine(@"-- " + _buildOptions.sceneName);
				sw.WriteLine(@"function init(scene)");
                if (_buildOptions.ee)
                {
                    sw.WriteLine("\tee:init(scene)");
                }
				sw.WriteLine(@"end");
				sw.WriteLine();
                sw.WriteLine(@"function startup(scene)");
                if (_buildOptions.ee)
                {
                    sw.WriteLine("\tee:startup(scene)");
                }
                sw.WriteLine(@"end");
                sw.WriteLine();
				sw.WriteLine(@"function update(scene)");
                if (_buildOptions.ee)
                {
                    sw.WriteLine("\tee:update()");
                }
                if (_buildOptions.isMinigame)
                {
                    sw.WriteLine();
                    sw.WriteLine("\tif scene:is_button_pushed(\"reset_button\") then");
                    sw.WriteLine("\tend");
                }

				sw.WriteLine(@"end");

                if (_buildOptions.isMinigame)
                {
                    sw.WriteLine();
                    sw.WriteLine(@"function ON_MINI_GAME_COMPLETE_"+_buildOptions.sceneName+"(scene)");
                    sw.WriteLine("\tscene:fire_event(\"hide_reset_button\")");
                    sw.WriteLine(@"end");
                }

				sw.Close();
			}
		}

		private void AddCloseButton()
		{
            if (!FoundParentNode("close_button", _layersNode))
            {
                XmlElement closeButtonNode = _sceneXmlDoc.CreateElement("close_button");
                closeButtonNode.SetAttribute("template", "subscreens_common:close_button");
                closeButtonNode.SetAttribute("position", "800 600");
                _layersNode.AppendChild(closeButtonNode);
            }
		}

		private void AddHummingBird()
		{
            if (!FoundParentNode("humming_birds", _layersNode))
            {
                XmlElement hummingBirdsNode = _sceneXmlDoc.CreateElement("humming_birds");
                hummingBirdsNode.SetAttribute("template", "humming_birds:");
                _layersNode.AppendChild(hummingBirdsNode);
            }
		}

        private void AddMorfingObject()
        {
            if (!FoundParentNode("morfing", _layersNode))
            {
                XmlElement morfingObjectNode = _sceneXmlDoc.CreateElement("morfing");
                XmlElement morfingObjectNodeChild = _sceneXmlDoc.CreateElement("smoke");
                morfingObjectNodeChild.SetAttribute("position", "500 500");
                morfingObjectNode.SetAttribute("template", "morfing:");
                morfingObjectNode.AppendChild(morfingObjectNodeChild);
                _layersNode.AppendChild(morfingObjectNode);
            }
        }
	}
}
