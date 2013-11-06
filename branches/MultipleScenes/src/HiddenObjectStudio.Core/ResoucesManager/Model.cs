using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace HiddenObjectStudio.Core.ResourcesManager
{
    public class Model
    {
        private static string ModelNameAttributeName = "name";
        private static string FileNameAttributeName = "file_name";
        private static string TemporaryTexturesAttributeName = "temporary_textures";

        public XmlElement _node;

        public Container ParentContainer;

        public Model(XmlNode node, Container parentContainer)
        {
            _node = (XmlElement)node;

            ParentContainer = parentContainer;
        }

        public string ModelName
        {
            get
            {
                return _node.GetAttribute(ModelNameAttributeName);
            }

            set
            {
                _node.SetAttribute(ModelNameAttributeName, value);
            }
        }

        public string ModelFileName
        {
            get
            {
                return _node.GetAttribute(FileNameAttributeName);
            }

            set
            {
                _node.SetAttribute(FileNameAttributeName, value);
            }
        }

        public string TemporaryTextures
        {
            get
            {
                return _node.GetAttribute(TemporaryTexturesAttributeName);
            }

            set
            {
                _node.SetAttribute(TemporaryTexturesAttributeName, value);
            }
        }

        public void SaveToXML(XmlNode xmlNode)
        {
            XmlDocument xmlDoc = xmlNode.OwnerDocument;

            XmlElement modelNode = xmlDoc.CreateElement("model");

            if (ModelName != string.Empty)
            {
                modelNode.SetAttribute(ModelNameAttributeName, ModelName);
            }

            if (ModelFileName != string.Empty)
            {
                modelNode.SetAttribute(FileNameAttributeName, ModelFileName);
            }

            if (TemporaryTextures != string.Empty)
            {
                modelNode.SetAttribute(TemporaryTexturesAttributeName, TemporaryTextures);
            }

            xmlNode.AppendChild(modelNode);
        }

        public void AttachToTreeNode(TreeNodeCollection treeNodes, TreeNode modelNode)
        {
            modelNode.Name = ModelName;
            modelNode.Text = ModelName;
            modelNode.Tag = this;
            modelNode.ImageIndex = 3;

            treeNodes.Add(modelNode);
        }
    }
}
