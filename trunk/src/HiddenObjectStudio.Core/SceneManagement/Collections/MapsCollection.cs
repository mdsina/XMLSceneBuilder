using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace SceneEditor.Classes.Collections
{
	class MapsCollection
	{
		private List<Map> _maps;

		public MapsCollection()
		{
			_maps = new List<Map>();
		}

		public void Add(Layer theLayer, Event theEvent, Animation theAnimation )
		{
			if (theLayer == null || theEvent == null || theAnimation == null) return;

			Map newMap = new Map(theLayer, theEvent, theAnimation);

			_maps.Add(newMap);
		}

		public Map FindMapForLayer(Layer layer)
		{
			foreach(Map map in _maps)
			{
				if (map.Layer == layer)
					return map;
			}

			return null;
		}

		public Map FindMapForLayer(string layerName)
		{
			foreach (Map map in _maps)
			{
				if (map.Layer.Name == layerName)
					return map;
			}

			return null;
		}

		public void SaveToXml(XmlNode nodeToSave)
		{
// 			foreach (XmlNode node in nodeToSave.ChildNodes)
// 			{
// 				Layer layer = FindMapForLayer(node.Name);
// 					
// 				//layersNode.AppendChild(layer.SaveToXml(layersNode));
// 			}
// 
// 			return layersNode;
// 			return null;
		}

		public void LoadFromXml(XmlNode node)
		{
			//Clear();

// 			foreach (XmlNode layerNode in node.ChildNodes)
// 			{
// 				Layer newLayer = new Layer();
// 				newLayer.LoadFromXml(layerNode);
// 				//Add(newLayer.Name, newLayer);
// 				//Add(newLayer);
// 			}
		}
	}
}
