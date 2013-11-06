using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace HiddenObjectStudio.Core.ResourcesManager
{
    public class Shader
    {
        private static string ShaderNameAttributeName = "name";
        private static string TextureNameAttributeName = "texture_name";
        private static string FrameCountAttributeName = "frame_count";
        private static string MipMapValue = "mip_map";
        private static string TemporaryTexturesAttributeName = "temporary_textures";

        public List<string> shaderAnimationPicPaths;

        public XmlElement _node;

        public Container ParentContainer;

        public Shader(XmlNode node, Container parentContainer)
        {
            _node = (XmlElement)node;

            ParentContainer = parentContainer;
            
        }

        public string ShaderName
        {
            get
            {
                return _node.GetAttribute(ShaderNameAttributeName);
            }

            set
            {
                _node.SetAttribute(ShaderNameAttributeName, value);
            }
        }

        public string TextureName
        {
            get
            {
                return _node.GetAttribute(TextureNameAttributeName);
            }

            set
            {
                _node.SetAttribute(TextureNameAttributeName, value);
            }
        }

        public string FrameCount
        {
            get
            {
                return _node.GetAttribute(FrameCountAttributeName);
            }

            set
            {
                _node.SetAttribute(FrameCountAttributeName, value);
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

        public string MipMap
        {
            get
            {
                return _node.GetAttribute(MipMapValue);
            }

            set
            {
                _node.SetAttribute(MipMapValue, value);
            }
        }

        public void AttachToTreeNode(TreeNodeCollection treeNodes, TreeNode shaderNode)
        {
            shaderNode.Name = ShaderName;
            shaderNode.Text = ShaderName;
            shaderNode.Tag = this;
            shaderNode.ImageIndex = 2;

            treeNodes.Add(shaderNode);
        }

        public string GetShaderFullNodePath()
        {
            string nodePath = String.Empty;

            XmlNode node = _node;

            while (node.ParentNode.NodeType != XmlNodeType.Document)
            {
                nodePath = node.ParentNode.Name + "/" + nodePath;
                node = node.ParentNode;
            }
            nodePath = nodePath + _node.Attributes["name"].Value;

            return nodePath;
        }

        public List<string> GetShaderPicPaths(string resDataFilePath)
        {
            List<string> shaderPicPaths = new List<string>();
            string textName = string.Empty;
            
            if (TextureName != string.Empty)
            {
                textName = TextureName;
            }
            
            if (FrameCount != string.Empty)
            {
                if (Convert.ToInt32(FrameCount) > 1)
                {
                    string intPart = textName.Substring(textName.LastIndexOf('_') + 1);
                    string firstPart = textName.Substring(0, textName.LastIndexOf('_') + 1);

                    int intPathLenght = intPart.Length;

                    int frames = Convert.ToInt32(FrameCount);

                    for (int i = 0; i < frames; i++)
                    {
                        string newIntStr = i.ToString();
                        int lenghtI = i.ToString().Length;
                        int diffr = intPathLenght - lenghtI;

                        for (int k = 0; k < diffr; k++)
                        {
                            newIntStr = "0" + newIntStr;
                        }

                        string newStr = firstPart + newIntStr;

                        string picPath = Tools.GetFolderByInputFolderAndPath(resDataFilePath, newStr);

                        shaderPicPaths.Add(picPath);
                    }
                }
                else
                {
                    if (textName != string.Empty)
                    {
                        shaderPicPaths.Add(Tools.GetFolderByInputFolderAndPath(resDataFilePath, textName));
                    }
                }
            }
            else
            {
                if (textName != string.Empty)
                {
                    shaderPicPaths.Add(Tools.GetFolderByInputFolderAndPath(resDataFilePath, textName));
                }
            }

            return shaderPicPaths;
            
        }

        public void SaveToXML(XmlNode xmlNode)
        {
            XmlDocument xmlDoc = xmlNode.OwnerDocument;

            XmlElement shaderNode = xmlDoc.CreateElement("shader");

            if (ShaderName != string.Empty)
            {
                shaderNode.SetAttribute(ShaderNameAttributeName, ShaderName);
            }

            if (TextureName != string.Empty)
            {
                shaderNode.SetAttribute(TextureNameAttributeName, TextureName);
            }

            if (FrameCount != string.Empty)
            {
                shaderNode.SetAttribute(FrameCountAttributeName, FrameCount);
            }

            if (TemporaryTextures != string.Empty)
            {
                shaderNode.SetAttribute(TemporaryTexturesAttributeName, TemporaryTextures);
            }

            if (MipMap != string.Empty)
            {
                shaderNode.SetAttribute(MipMapValue, MipMap);
            }

            xmlNode.AppendChild(shaderNode);
        }
    }
}
