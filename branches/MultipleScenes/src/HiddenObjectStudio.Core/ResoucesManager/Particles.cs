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

        public XmlElement _node;

        public Container ParentContainer;

        public Particles(XmlNode node, Container parentContainer)
        {
            _node = (XmlElement)node;

            ParentContainer = parentContainer;
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

        public void SaveToXML(XmlNode xmlNode)
        {
            XmlDocument xmlDoc = xmlNode.OwnerDocument;

            XmlElement particlesNode = xmlDoc.CreateElement("particles");

            if (ParticlesName != string.Empty)
            {
                particlesNode.SetAttribute(ParticlesNameAttributeName, ParticlesName);
            }

            if (ParticlesFileName != string.Empty)
            {
                particlesNode.SetAttribute(FileNameAttributeName, ParticlesFileName);
            }

            if (TemporaryTextures != string.Empty)
            {
                particlesNode.SetAttribute(TemporaryTexturesAttributeName, TemporaryTextures);
            }

            xmlNode.AppendChild(particlesNode);
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
