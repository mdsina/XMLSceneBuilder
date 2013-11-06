using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace HiddenObjectStudio.Core.ResourcesManager
{
    public class Container
    {
        public List<Shader> Shaders;
        public List<Model> Models;
        public List<TexturePack> TexturePack;
        public List<Particles> Particles;
        public List<Container> Containers;
        private XmlElement _node;
        private bool _newNode = false;
        public string Name { get; set; }
        public string Type = "container";

        public Container(XmlNode node)
        {
            Containers = new List<Container>();
            Name = node.Name;
            Shaders = new List<Shader>();
            Models = new List<Model>();
            TexturePack = new List<TexturePack>();
            Particles = new List<Particles>();

            _node = (XmlElement)node;
            LoadFromXML(_node);
        }

        private void LoadFromXML(XmlNode parentNode)
        {
           foreach (XmlElement nodes in parentNode)
            {
                switch (GetType(nodes))
                {
                    case "container":
                        Container newContainer = new Container(nodes);
                        Containers.Add(newContainer);
                        break;
                    case "shader":
                        //Shaders.GetShader(nodes);
                        Shader newShader = new Shader(nodes);
                        Shaders.Add(newShader);
                        break;
                    case "model":
                        Model newModel = new Model(nodes);
                        Models.Add(newModel);
                        break;
                    case "texture_pack":
                        TexturePack newTexturePack = new TexturePack(nodes);
                        TexturePack.Add(newTexturePack);
                        break;
                    case "particles":
                        Particles newParticles = new Particles(nodes);
                        Particles.Add(newParticles);
                        break;
                    default:
                        //System.Windows.Forms.MessageBox.Show("Error! Unsigned node detected!");
                        break;
                }
            }
            
        }

        public void SaveToXML(XmlNode parentNode)
        {
            foreach (TexturePack texturePack in TexturePack)
            {
                texturePack.SaveToXML(parentNode);
            }
            
            foreach (Shader shader in Shaders)
            {
                shader.SaveToXML(parentNode);
            }
        }

        public void ReAttachToTreeNode(TreeNodeCollection treeNodes, TreeNode treeNode)
        {
            foreach (TexturePack texturePack in TexturePack)
            {
                bool found = false;

                foreach (TreeNode node in treeNode.Nodes)
                {
                    if (node.Text == texturePack.TexturePackName)
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    TreeNode texturePackNode = new TreeNode();
                    texturePack.AttachToTreeNode(treeNode.Nodes, texturePackNode);
                }
                
            }

            foreach (Shader shader in Shaders)
            {
                bool found = false;

                foreach (TreeNode node in treeNode.Nodes)
                {
                    if (node.Text == shader.ShaderName)
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    TreeNode shaderNode = new TreeNode();
                    shader.AttachToTreeNode(treeNode.Nodes, shaderNode);
                }
            }



            foreach (Model model in Models)
            {
                bool found = false;

                foreach (TreeNode node in treeNode.Nodes)
                {
                    if (node.Text == model.ModelName)
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    TreeNode modelNode = new TreeNode();
                    model.AttachToTreeNode(treeNode.Nodes, modelNode);
                }
                
            }
// 
//             foreach (Particles particles in Particles)
//             {
//                 TreeNode particlesNode = new TreeNode();
//                 particles.AttachToTreeNode(treeNode.Nodes, particlesNode);
//             }
// 
//             

            foreach (Container container in Containers)
            {
                foreach (TreeNode node in treeNode.Nodes)
                {
                    object obj = node.Tag;
                    Type type = obj.GetType();

                    if ((type.Name == "Container") && (node.Name == container.Name))
                    {
                        container.ReAttachToTreeNode(treeNode.Nodes, node);
                    }

                }
            }

        }

        public void AttachToTreeNode(TreeNodeCollection treeNodes, TreeNode treeNode)
        {
            treeNode.Name = Name;
            treeNode.Text = Name;
            treeNode.Tag = this;
            treeNode.ImageIndex = 0;

            treeNodes.Add(treeNode);
            foreach (TexturePack texturePack in TexturePack)
            {
                TreeNode texturePackNode = new TreeNode();
                texturePack.AttachToTreeNode(treeNode.Nodes, texturePackNode);
            }

            foreach (Shader shader in Shaders)
            {
                TreeNode shaderNode = new TreeNode();
                shader.AttachToTreeNode(treeNode.Nodes, shaderNode);
            }

            foreach (Model model in Models)
            {
                TreeNode modelNode = new TreeNode();
                model.AttachToTreeNode(treeNode.Nodes, modelNode);
            }

            foreach (Particles particles in Particles)
            {
                TreeNode particlesNode = new TreeNode();
                particles.AttachToTreeNode(treeNode.Nodes, particlesNode);
            }

            foreach (Container container in Containers)
            {
                TreeNode containerNode = new TreeNode();

                container.AttachToTreeNode(treeNode.Nodes, containerNode);
            }

        }

        public string GetType(XmlElement node)
        {
            string type = String.Empty;
            if (!node.HasAttributes)
            {
                type = "container";
            }
            else if (node.Name == "shader")
            {
                type = "shader";
            }
            else if (node.Name == "model")
            {
                type = "model";
            }
            else if (node.Name == "texture_pack")
            {
                type = "texture_pack";
            }
            else if (node.Name == "particles")
            {
                type = "particles";
            }
            return type;
        }

        public Shader CreateShader()
        {
            XmlElement shaderNode = _node.OwnerDocument.CreateElement("shader");
            Shader shader = new Shader(shaderNode);
            return shader;
        }

        public Model CreateModel()
        {
            XmlElement modelNode = _node.OwnerDocument.CreateElement("model");
            Model model = new Model(modelNode);
            return model;
        }

        public TexturePack CreateTexturePack()
        {
            XmlElement texturePackNode = _node.OwnerDocument.CreateElement("texture_pack");
            TexturePack texturePack = new TexturePack(texturePackNode);
            return texturePack;
        }

        public void AddShader(Shader shader)
        {
            _node.AppendChild(shader._node);
            Shaders.Add(shader);
            _newNode = true;
        }

        public void AddModel(Model model)
        {
            _node.AppendChild(model._node);
            Models.Add(model);
            _newNode = true;
        }

        public void AddTexturePack(TexturePack texturePack)
        {
            _node.AppendChild(texturePack._node);
            TexturePack.Add(texturePack);
            _newNode = true;
        }

        public string GetShaderPathByName(string shaderName)
        {
            string shaderPath = string.Empty;
            foreach (Shader shader in Shaders)
            {
                shaderPath = shader.GetShaderFullNodePath();
                if (shaderPath == shaderName)
                {
                    return shader.TextureName;
                }
            }
            return string.Empty;
        }

        public string GetShaderNameByTextureValue(string shaderPath, bool searchAtChildren)
        {
            string shaderFullPath = String.Empty;

            foreach (Shader shader in Shaders)
            {
                if (shaderPath == shader.TextureName)
                {
                    shaderFullPath = shader.GetShaderFullNodePath();
                    return shaderFullPath;
                }
            }

            if (searchAtChildren)
            {
                foreach (Container cont in Containers)
                {

                    string recValue = cont.GetShaderNameByTextureValue(shaderPath, true);

                    if (recValue != string.Empty)
                    {
                        return recValue;
                    }
                }
            }
            
            return shaderFullPath;
        }

        public string GetShaderNameByShaderPath(string shaderPath, string resFilePath, bool searchAtChildren)
        {
            string shaderFullPath = String.Empty;
            
            foreach (Shader shader in Shaders)
            {
                List<string> shadersPicPathList = shader.GetShaderPicPaths(resFilePath);
                foreach (string str in shadersPicPathList)
                {
                    if (str.ToLower() == shaderPath.ToLower())
                    {
                        shaderFullPath = shader.GetShaderFullNodePath();
                        return shaderFullPath;
                    }
                }
                
            }

            if (searchAtChildren)
            {
                foreach (Container cont in Containers)
                {

                    string recValue = cont.GetShaderNameByShaderPath(shaderPath, resFilePath, true);

                    if (recValue != string.Empty)
                    {
                        return recValue;
                    }
                }
            }

            return shaderFullPath;
        }
    }
}