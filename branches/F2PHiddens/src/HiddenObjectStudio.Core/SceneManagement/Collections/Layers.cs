using System.Collections.Generic;
using System.Xml;
using System.Windows.Forms;

namespace HiddenObjectStudio.Core.SceneManagement
{
	public class Layers : List<Layer>
	{
		private Layer _parentLayer;
        
		public Layers()
		{
		}

		public Layers(Layer parentLayer)
		{
			_parentLayer = parentLayer;
		}

		public void SaveToXml(XmlNode xmlNode)
		{
			XmlDocument xmlDoc = xmlNode.OwnerDocument;

			foreach (Layer layer in this)
			{
                XmlNode layerNode = null;
				layerNode = xmlNode.SelectSingleNode(layer.Name);

				if (layerNode == null)
				{
					layerNode = xmlDoc.CreateElement(layer.Name);
					xmlNode.AppendChild(layerNode);
				}

				layer.SaveToXml(layerNode);
			}
		}

        public void LoadFromXml(XmlNode node, Layer parent)
		{
			Clear();

			foreach (XmlNode layerNode in node.ChildNodes)
			{
				//Layer layer = GetLayer(layerNode.Name);
                                
                Layer layer = new Layer();
				layer.Parent = parent;
				layer.LoadFromXml(layerNode);
                
                Add(layer);
            }
		}

//         public Layers GetAllLayers(XmlNode node, Layer parent)
//         {
//             List<Layer> layers = new List<Layer>();
//             foreach (Layer layer in this)
//             {
//                 layers.Add(layer);
//                 
//                 List<Layer> childLayers = new List<Layer>();
//                 childLayers = layer.GetAllLayers();
//                 layers.AddRange(childLayers);
//                 
//             }
//             return
//         }

        public Layer GetLayer(string name)
        {
            foreach (Layer layer in this)
            {
                if (layer.Name == name)
                {
                    return layer;
                }
            }

            return null;
        }

        public Layer GetShader()
        {
            //TODO//TODO//TODO//TODO//TODO//TODO//TODO//TODO//TODO//TODO//TODO//TODO//TODO//TODO//TODO//TODO//TODO//TODO//TODO//TODO//TODO//TODO
            return null;
        }

		public void Add(Layer newLayer)
		{
			base.Add(newLayer);
		}

		public void DisplayInTreeView(TreeNodeCollection treeNodeCollection)
		{
			treeNodeCollection.Clear();

			foreach (Layer layer in this)
			{
				TreeNode layerTreeNode = new TreeNode(layer.Name);
				layerTreeNode.Tag = layer;

				treeNodeCollection.Add(layerTreeNode);

				if (layer.ChildLayers.Count > 0)
				{
					layer.ChildLayers.DisplayInTreeView(layerTreeNode.Nodes);
				}
			}

		}
	};
}