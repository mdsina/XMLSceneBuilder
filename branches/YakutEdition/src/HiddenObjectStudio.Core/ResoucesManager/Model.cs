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

        public Model(XmlNode node)
        {
            _node = (XmlElement)node;
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
