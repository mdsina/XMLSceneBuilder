using System.Xml;
using System.Collections.Generic;

namespace HiddenObjectStudio.Core.SceneManagement
{
	public class Scene
	{
		public static string AnimationsNodeName = "animations";
		
		public static string LayersNodeName = "layers";
		public static string ScriptFileAttributeName = "file_name";

        public static string MapsNodeName = "maps";
        
        public Layers Layers;
		public Layers AllLayers;
		public Animations Animations;
		public Maps Maps;

		public XmlNode MainLayersNode;
        public XmlNode MainScriptsNode;
        public XmlNode MainAnimationsNode;
        public XmlNode MainMapsNode;
        
        
        private XmlNode _MainNode;

		public List<string> ScriptFiles;

        
		public string FileName;
        public string Name;

		public Scene()
		{
			Layers = new Layers();

            AllLayers = new Layers();

			Animations = new Animations();

			ScriptFiles = new List<string>();

            Maps = new Maps();
		}



		public void LoadFromXml(string fileName)
		{
			XmlDocument doc = new XmlDocument();

			doc.Load(fileName);

			XmlNode sceneNode = doc.DocumentElement;
            _MainNode = sceneNode;
            
            Name = sceneNode.Name;

			XmlNode animationsNode = sceneNode.SelectSingleNode(AnimationsNodeName);
            MainAnimationsNode = animationsNode;
			if (animationsNode != null)
			{
				Animations.LoadFromXml(animationsNode);
			}


            XmlNode layersNode = sceneNode.SelectSingleNode(LayersNodeName);
            MainLayersNode = layersNode;
            if (layersNode != null)
            {
                Layers.LoadFromXml(layersNode, null);
                
                foreach (Layer layer in Layers)
                {
                    AllLayers.Add(layer);
                    AllLayers.AddRange(layer.GetAllLayers());
                }
            }

            XmlNode mapsNode = sceneNode.SelectSingleNode(MapsNodeName);
            MainMapsNode = mapsNode;
            if (mapsNode != null)
            {
                Maps.LoadFromXml(mapsNode);
            }

			XmlNode scriptsNode = sceneNode.SelectSingleNode("scripts");
            MainScriptsNode = scriptsNode;
			if (scriptsNode != null)
			{
				foreach (XmlNode scriptNode in scriptsNode)
				{
					ScriptFiles.Add(scriptNode.Attributes[ScriptFileAttributeName].Value);
				}
			}
		}

		public void SaveToXml(string fileName)
		{
			XmlDocument doc = new XmlDocument();

			XmlElement sceneNode = doc.CreateElement(_MainNode.Name);
            
            foreach (XmlAttribute attr in _MainNode.Attributes)
            {
                sceneNode.SetAttribute(attr.Name, attr.Value);
            }

			doc.AppendChild(sceneNode);

            XmlNode scriptsNode = sceneNode.SelectSingleNode("scripts");
            if (scriptsNode == null)
            {
                XmlElement scriptElement = sceneNode.OwnerDocument.CreateElement("scripts");

                if (MainScriptsNode.Attributes["include"] != null)
                {
                    scriptElement.SetAttribute("include", MainScriptsNode.Attributes["include"].Value);
                }
                scriptsNode = (XmlNode)scriptElement;
                sceneNode.AppendChild(scriptsNode);
            }

            foreach (string value in ScriptFiles)
            {
                XmlElement scriptNode = sceneNode.OwnerDocument.CreateElement("script");
                scriptNode.SetAttribute(ScriptFileAttributeName, value);
                scriptsNode.AppendChild(scriptNode);
            }


			XmlNode animationsNode = sceneNode.SelectSingleNode(AnimationsNodeName);
			if (animationsNode == null)
			{
                XmlElement animationsElement = sceneNode.OwnerDocument.CreateElement(AnimationsNodeName);
                if (MainAnimationsNode.Attributes["include"] != null)
                {
                    animationsElement.SetAttribute("include", MainAnimationsNode.Attributes["include"].Value);
                }

                animationsNode = (XmlNode)animationsElement;

                sceneNode.AppendChild(animationsNode);
			}

            Animations.SaveToXml(animationsNode);

            XmlNode layersNode = sceneNode.SelectSingleNode(LayersNodeName);
			if (layersNode == null)
			{
                layersNode = sceneNode.OwnerDocument.CreateElement(LayersNodeName);
				sceneNode.AppendChild(layersNode);
			}
            Layers.SaveToXml(layersNode);
            //

            XmlNode mapsNode = sceneNode.SelectSingleNode(MapsNodeName);
            if (mapsNode == null)
			{
                XmlElement mapsElement = sceneNode.OwnerDocument.CreateElement(MapsNodeName);

                if (MainMapsNode.Attributes["include"] != null)
                {
                    mapsElement.SetAttribute("include", MainMapsNode.Attributes["include"].Value);
                }

                mapsNode = (XmlNode)mapsElement;

                sceneNode.AppendChild(mapsElement);
			}
            Maps.SaveToXml(mapsNode);

            
            
			doc.Save(fileName);
		}
	}
}