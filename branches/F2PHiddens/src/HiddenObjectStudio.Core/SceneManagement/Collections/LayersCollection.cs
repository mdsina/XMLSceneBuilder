using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace SceneEditor.Classes.Collections
{

	class LayersCollection :  Dictionary<string, Layer>
	{
		//private List<Layer> _layers;

		public LayersCollection()
		{
			//_layers = new List<Layer>();
		}

// 		public Layer this[string name]
// 		{
// 			get 
// 			{ 
// 				foreach (Layer layer in _layers)
// 				{
// 					if (layer.Name == name)
// 						return _layers[3]; 
// 				}
// 
// 				return null;
// 			}
// 		}

// 		public void Add(Layer newLayer)
// 		{
// 			if (newLayer == null) return;
// 
// 			_layers.Add(newLayer);
// 		}

		public XmlElement SaveToXml(XmlDocument xmlDoc)
		{
// 			XmlElement layersNode = xmlDoc.CreateElement("layers");
// 			foreach (Layer layer in Values)
// 			{
// 				layersNode.AppendChild(layer.SaveToXml(layersNode));
// 			}
// 
// 			return layersNode;
		}

		public void LoadFromXml(XmlNode node)
		{
// 			Clear();
// 
// 			foreach (XmlNode layerNode in node.ChildNodes)
// 			{
// 				Layer newLayer = new Layer(null);
// 				newLayer.LoadFromXml(layerNode);
// 				Add(newLayer.Name, newLayer);
// 			}
		}
	}
}
