using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Windows.Forms;
using HiddenObjectStudio.Core;
using HiddenObjectStudio.Core.SceneManagement;
using HiddenObjectStudio.Core.LocationManagement;

namespace HiddenObjectStudio.Core.ResourcesManager
{
    public class ResourcesData
    {
        private Container _container;

        private XmlDocument _resourcesDocument;

        public List<Container> AllContainers;

        public String _filePath = String.Empty;

        public ResourcesData(string filePath)
        {
            _filePath = filePath;

            if (File.Exists(_filePath))
            {
                _resourcesDocument = new XmlDocument();
                _resourcesDocument.Load(_filePath);
                _container = new Container(_resourcesDocument.DocumentElement, null);
            }
        }

        public void LoadResourcesXMl(string filePath)
        {
            _filePath = filePath;

            if (File.Exists(_filePath))
            {
                _resourcesDocument = new XmlDocument();
                _resourcesDocument.Load(_filePath);
                _container = new Container(_resourcesDocument.DocumentElement, null);
            }
        }

        public void SaveToXml(string filePath)
        {
            XmlDocument doc = new XmlDocument();

            XmlElement rootContainerNode = doc.CreateElement(_container.Name);

            doc.AppendChild(rootContainerNode);

            _filePath = filePath;

            _container.SaveToXML(rootContainerNode);

            doc.Save(filePath);
        }

        public void AttachToTree(TreeView treeView)
        {
            TreeNode root = new TreeNode();
            _container.AttachToTreeNode(treeView.Nodes, root);
        }

        public void ReAttachToTree(TreeView treeView)
        {
            _container.ReAttachToTreeNode(treeView.Nodes, treeView.Nodes[0]);
        }
        
        public string GetShaderPathByFullName(string shaderName)
        {
            string shaderPath = String.Empty;
            string shaderNodeValue = String.Empty;

            // shaderNodeValue = _container.GetShaderPathByName(shaderName);

            shaderNodeValue = SearchShaderPathInContainersByName(_container, shaderName, shaderNodeValue);

            if (shaderNodeValue != String.Empty)
            {
                shaderNodeValue = shaderNodeValue.Replace('/', '\\');
                shaderPath = Path.Combine(Path.GetDirectoryName(_filePath), shaderNodeValue) + ".png";
            }
            return shaderPath;
        }

        public string GetShaderNameByFullPath(string shaderPath, string resFilePath)
        {
            shaderPath = shaderPath.Replace("\\\\", "\\");
            resFilePath = resFilePath.Replace("\\\\", "\\");

            string shaderXPath = string.Empty;

            string shaderName = string.Empty;

            string textureName = Tools.GetPathBetweenFilesFolder(resFilePath, shaderPath);

            string shaderShowName = Path.GetFileNameWithoutExtension(shaderPath);

            textureName = textureName + "\\" + shaderShowName;

            shaderName = _container.GetShaderNameByTextureValue(textureName, true);

            return shaderName;
        }

        public string GetShaderNameByFullPathUsingAnimation(string shaderPath, string resFilePath)
        {
            shaderPath = shaderPath.Replace("\\\\", "\\");
            resFilePath = resFilePath.Replace("\\\\", "\\");

            string shaderName = string.Empty;

            shaderName = _container.GetShaderNameByShaderPath(shaderPath, resFilePath, true);

            return shaderName;
        }
        
        public string SearchShaderPathInContainersByName(Container container, string shaderName, string outputShaderNodeValue)
        {
            outputShaderNodeValue = container.GetShaderPathByName(shaderName);
            if ((outputShaderNodeValue == String.Empty) && (container.Containers.Count > 0))
            {
                foreach (Container cont in container.Containers)
                {
                    outputShaderNodeValue = cont.GetShaderPathByName(shaderName);
                    if (outputShaderNodeValue == String.Empty)
                    {
                        if (container.Containers.Count > 0)
                        {
                            outputShaderNodeValue = SearchShaderPathInContainersByName(cont, shaderName, outputShaderNodeValue);
                            if (outputShaderNodeValue != String.Empty)
                            {
                                return outputShaderNodeValue;
                            }
                        }
                    }
                    else
                    {
                        return outputShaderNodeValue;
                    }
                }
            }
            if (outputShaderNodeValue != String.Empty)
            {
                return outputShaderNodeValue;
            }
            return String.Empty;
        }
    }        
}
