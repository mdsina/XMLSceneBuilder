using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace HiddenObjectStudio.Core.ResourcesManager
{
    public class Particles
    {
        private static string ParticlesNameAttributeName = "name";
        private static string FileNameAttributeName = "file_name";
        private static string TemporaryTexturesAttributeName = "temporary_textures";

        private XmlElement _node;

        public Particles(XmlNode node)
        {
            _node = (XmlElement)node;
        }

        public string ParticlesName
        {
            get
            {
                return _node.GetAttribute(ParticlesNameAttributeName);
            }

            set
            {
                _node.SetAttribute(ParticlesNameAttributeName, value);
            }
        }

        public string ParticlesFileName
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

        public void AttachToTreeNode(TreeNodeCollection treeNodes, TreeNode particlesNode)
        {
            particlesNode.Name = ParticlesName;
            particlesNode.Text = ParticlesName;
            particlesNode.Tag = this;
            particlesNode.ImageIndex = 4;

            treeNodes.Add(particlesNode);
        }
    }
}
