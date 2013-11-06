using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace HiddenObjectStudio.Core.ResourcesManager
{
    public class TexturePack
    {
        private static string TexturePackNameAttributeName = "name";
        private static string FileNameAttributeName = "file_name";
        private static string TemporaryTexturesAttributeName = "temporary_textures";

        public XmlElement _node;

        public TexturePack(XmlNode node)
        {
            _node = (XmlElement)node;
        }

        public string TexturePackName
        {
            get
            {
                return _node.GetAttribute(TexturePackNameAttributeName);
            }

            set
            {
                _node.SetAttribute(TexturePackNameAttributeName, value);
            }
        }

        public string TexturePackFileName
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

        public void AttachToTreeNode(TreeNodeCollection treeNodes, TreeNode texturePackNode)
        {
            texturePackNode.Name = TexturePackName;
            texturePackNode.Text = TexturePackName;
            texturePackNode.Tag = this;
            texturePackNode.ImageIndex = 1;

            treeNodes.Add(texturePackNode);
        }

        public void SaveToXML(XmlNode xmlNode)
        {
            XmlDocument xmlDoc = xmlNode.OwnerDocument;

            XmlElement shaderNode = xmlDoc.CreateElement("texture_pack");

            if (TexturePackName != string.Empty)
            {
                shaderNode.SetAttribute(TexturePackNameAttributeName, TexturePackName);
            }

            if (TexturePackFileName != string.Empty)
            {
                shaderNode.SetAttribute(FileNameAttributeName, TexturePackFileName);
            }

            if (TemporaryTextures != string.Empty)
            {
                shaderNode.SetAttribute(TemporaryTexturesAttributeName, TemporaryTextures);
            }

            xmlNode.AppendChild(shaderNode);
        }
    }
}
