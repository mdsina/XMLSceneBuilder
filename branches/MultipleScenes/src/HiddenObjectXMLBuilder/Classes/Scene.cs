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

		public Scene(BuilderConfig builderConfig, BuildOptions buildOptions)
		{
			_builderConfig = builderConfig;
			_buildOptions = buildOptions;

			_scriptFileName = _buildOptions.sceneName + ".lua";



			_xmlFileName = buildOptions.dstFolder + "\\" + buildOptions.sceneName + ".xml";

			_sceneXmlDoc = new XmlDocument();

			SceneRootNodeName = buildOptions.sceneName;

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
				_sceneRoot.SetAttribute("edit", "0");
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
					else if (fn.IsActiveZone)
					{
						// 					string activeZondeType = fn.GetActiveZoneType();
						// 					if (activeZondeType == "place")
						// 					{
						// 						string destinationScene = fn.GetDestinationPlace();
						// 						layerNode.SetAttribute("destination_place", destinationScene);
						// 					}
						// 					else if (activeZondeType == "mini_game")
						// 					{
						// 
						// 					}

					}


					_layersNode.AppendChild(layerNode);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ошибка на "+ fn.FullFileName);

				throw ex;
			}

		}

		public void Save()
		{
			//XmlWriter writer = new XmlTextWriter(, Encoding.GetEncoding("windows-1251"));

			if (_buildOptions.isSubscreen)
			{
				XmlElement closeButtonNode = _sceneXmlDoc.CreateElement("close_button");
				closeButtonNode.SetAttribute("template", "subscreens_common:close_button");
				closeButtonNode.SetAttribute("position", "800 600");
				_layersNode.AppendChild(closeButtonNode);
			}
			
			CreateIncludesLib();

			CreateScript();

			_sceneXmlDoc.Save(_xmlFileName);
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
			}
		}

		public void AddMapsNodeIfNeeded()
		{
			_mapsNode = (XmlElement)_sceneRoot.SelectSingleNode(MapsNodeName);
			if (_mapsNode == null)
			{
				_mapsNode = _sceneXmlDoc.CreateElement(MapsNodeName);
				_sceneRoot.AppendChild(_mapsNode);
			}



			if (!_mapsNode.HasAttribute("include"))
			{
				string includes = "scenes_common";

				if (_buildOptions.isSubscreen)
				{
					includes += ";subscreens_common";
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
				sw.WriteLine(@"end");
				sw.WriteLine();
				sw.WriteLine(@"function update(scene)");
				sw.WriteLine(@"end");

				sw.Close();
			}
		}
	}
}
