using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;

namespace HiddenObjectStudio.Core.SceneManagement
{
	public class Layer
    {
        public static string XmlAttribNameTexturePack = "texture_pack";
        public static string XmlAttribNameTextureName = "texture_name";
        public static string XmlAttribNameShader = "shader";
        public static string XmlAttribNameModel = "model";
        public static string XmlAttribNameScalUV = "scale_uv";
        public static string XmlAttribNameFlipUV = "flip_uv";
        public static string XmlAttribNameSize = "size";
        public static string XmlAttribNamePosition = "position";
        public static string XmlAttribNameScale = "scale";
        public static string XmlAttribNameSelectionArea = "selection_area";
        public static string XmlNodeNameMaps = "events";
        public static string XmlAttribMapAnimation = "animation";

		private string _name;
		
		private Layer _parentLayer;

		private Maps _maps;

		private Dictionary<string, string> _attributes;
        
		private Layers _childLayers;
       // private Layers _layers;
		
		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		public string FullName
		{
			get
			{
				if (Parent != null)
				{
					return Parent.FullName + "/" + Name;
				}
				else
				{
					return Name;
				}
			}
		}

		public Dictionary<string, string> Attributes
		{
			get { return _attributes; }
		}

        public Layers ChildLayers
        {
            get { return _childLayers; }
           
        }

		public Layer Parent
		{
			get { return _parentLayer; }
            set
            {
				_parentLayer = value;
// 				if (_parentLayer != null)
// 				{
// 					if (!_parentLayer.ChildLayers.Contains(this))
// 					{
// 						_parentLayer.AddChildLayer(this);
// 					}
// 				}

            }
		}

		public Maps Maps
		{
			get { return _maps; }
		}

		public Layer()
		{
			Name = "new_layer";

			//Parent = parentLayer;

			_childLayers = new Layers(this);

			_attributes = new Dictionary<string, string>();

			_maps = new Maps();
            
		}

        public string GetAttribValue(string attribName)
		{
			string res;
			try
			{
				res = _attributes[attribName];
			}
			catch (KeyNotFoundException)
			{
				return string.Empty;
			}

			return res;
		}

		public void SetAttribute(string attribName, string value)
		{
			_attributes[attribName] = value;
		}

		public void AttachToTreeNode(TreeNode treeNode)
		{
			treeNode.Text = Name;
			treeNode.Tag = this;

			foreach (Layer childLayer in _childLayers)
			{
				TreeNode childTreeNode = new TreeNode();
				childLayer.AttachToTreeNode(childTreeNode);
				treeNode.Nodes.Add(childTreeNode);
			}
		}

        public bool HasAttribut(string attrib)
        {
            if (_attributes.ContainsKey(attrib))
            {
                return true;
            }

            return false;
        }

        public List<Layer> GetAllLayers()
        {
            List<Layer> layers = new List<Layer>();

            foreach (Layer layer in this.ChildLayers)
            {
                layers.Add(layer);

                List<Layer> childLayers = new List<Layer>();
                childLayers = layer.GetAllLayers();
                layers.AddRange(childLayers);

            }
            return layers;
        }

		public void LoadFromXml(XmlNode xmlNode)
		{
			Name = xmlNode.Name;
 
			_attributes.Clear();
            if (xmlNode.NodeType != XmlNodeType.Comment)
            {
                foreach (XmlAttribute attrib in xmlNode.Attributes)
                {
                    _attributes.Add(attrib.Name, attrib.Value);
                }
            }


                // подгружаем мапы
                //_mapsSubNode = node.SelectSingleNode(XmlNodeNameMaps);
                //if (_mapsSubNode != null)
                //{
                //    foreach (XmlNode mapNode in _mapsSubNode)
                //    {
                //        string eventName = mapNode.Name;
                //        string animationName = mapNode.Attributes[XmlAttribMapAnimation].Value;
                //        Event evnt = _scene.GetEvent(eventName);
                //        Animation animation = _scene.GetAnimation(animationName);
                //        Map newMap = new Map(evnt, animation);
                //        _maps.Add(newMap);
                //    }
                //}

                // подгружаем детей

			_childLayers.Clear();

			if (xmlNode.ChildNodes.Count > 0)
			{
				_childLayers.LoadFromXml(xmlNode, this);
			}
		}

		public void SaveToXml(XmlNode xmlNode)
		{
			//XmlDocument xmlDoc = xmlNode.OwnerDocument;

			XmlElement xmlElement = (XmlElement) xmlNode;

			foreach (string attrib in _attributes.Keys)
			{
				if (Attributes[attrib] != null && Attributes[attrib] != string.Empty)
					xmlElement.SetAttribute(attrib, _attributes[attrib]);
			}
 
			//// сохраняем детей
			if (_childLayers.Count > 0)
			{
				_childLayers.SaveToXml(xmlNode);
			}


			//// сохраняем мапы
			//if (_maps.Count > 0)
			//{
			//    XmlNode mapsNode = xmlDoc.CreateElement(XmlNodeNameMaps);
			//    foreach (Map map in _maps)
			//    {
			//        XmlElement mapNode = xmlDoc.CreateElement(map.Event.Name);
			//        mapNode.SetAttribute(XmlAttribMapAnimation, map.Animation.Name);
			//        mapsNode.AppendChild(mapNode);
			//    }

			//    node.AppendChild(mapsNode);
			//}
			//return node;
		}

		public void AddChildLayer(Layer childLayer)
		{
			if (childLayer != null)
			{
				childLayer.Parent = this;

				if (!_childLayers.Contains(childLayer))
				{
					_childLayers.Add(childLayer);
				}
				
			}
			
		}

	}
}