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
        public List<TexturePack> TexturePacks;
        public List<Particles> Particles;
        public List<Container> Containers;
        private XmlElement _node;
        private bool _newNode = false;
        public string Name { get; set; }
        public string Type = "container";
        public Container ParentContainer;

        public Container(XmlNode node,Container parentContainer)
        {
            Containers = new List<Container>();
            Name = node.Name;
            Shaders = new List<Shader>();
            Models = new List<Model>();
            TexturePacks = new List<TexturePack>();
            Particles = new List<Particles>();
            if (node.ParentNode != null)
            {
                ParentContainer = parentContainer;
            }
            
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
                        Container newContainer = new Container(nodes, this);
                        Containers.Add(newContainer);
                        break;
                    case "shader":
                        //Shaders.GetShader(nodes);
                        Shader newShader = new Shader(nodes, this);
                        Shaders.Add(newShader);
                        break;
                    case "model":
                        Model newModel = new Model(nodes, this);
                        Models.Add(newModel);
                        break;
                    case "texture_pack":
                        TexturePack newTexturePack = new TexturePack(nodes, this);
                        TexturePacks.Add(newTexturePack);
                        break;
                    case "particles":
                        Particles newParticles = new Particles(nodes, this);
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
            foreach (TexturePack texturePack in TexturePacks)
            {
                texturePack.SaveToXML(parentNode);
            }
            
            foreach (Shader shader in Shaders)
            {
                shader.SaveToXML(parentNode);
            }

            /////////////////////////// TODO PArticles

            foreach (Particles particles in Particles)
            {
                particles.SaveToXML(parentNode);
            }

            foreach (Model model in Models)
            {
                model.SaveToXML(parentNode);
            }

            foreach (Container container in Containers)
            {
                XmlDocument xmlDoc = parentNode.OwnerDocument;

                XmlElement containerNode = xmlDoc.CreateElement(container.Name);

                parentNode.AppendChild(containerNode);

                container.SaveToXML(containerNode);
            }
        }

        public void ReAttachToTreeNode(TreeNodeCollection treeNodes, TreeNode treeNode)
        {
            foreach (TexturePack texturePack in TexturePacks)
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

            foreach (Particles particles in Particles)
            {
                bool found = false;

                foreach (TreeNode node in treeNode.Nodes)
                {
                    if (node.Text == particles.ParticlesName)
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    TreeNode particlesNode = new TreeNode();
                    particles.AttachToTreeNode(treeNode.Nodes, particlesNode);
                }
            }



            foreach (Container container in Containers)
            {
                bool found = false;

                foreach (TreeNode node in treeNode.Nodes)
                {
                    object obj = node.Tag;
                    Type type = obj.GetType();

                    if ((type.Name == "Container") && (node.Name == container.Name))
                    {
                        container.ReAttachToTreeNode(treeNode.Nodes, node);
                        found = true;
                    }
                }
                if (!found)
                {
                    TreeNode containerNode = new TreeNode();
                    container.AttachToTreeNode(treeNode.Nodes, containerNode);
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

            foreach (TexturePack texturePack in TexturePacks)
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
            Shader shader = new Shader(shaderNode, this);
            return shader;
        }

        public Model CreateModel()
        {
            XmlElement modelNode = _node.OwnerDocument.CreateElement("model");
            Model model = new Model(modelNode, this);
            return model;
        }

        public Particles CreateParticles()
        {
            XmlElement particlesNode = _node.OwnerDocument.CreateElement("particles");
            Particles particles = new Particles(particlesNode, this);
            return particles;
        }

        public Container CreateContainer(string containerName)
        {
            XmlElement containerNode = _node.OwnerDocument.CreateElement(containerName);
            Container containter = new Container(containerNode, this);
            return containter;
        }

        public TexturePack CreateTexturePack()
        {
            XmlElement texturePackNode = _node.OwnerDocument.CreateElement("texture_pack");
            TexturePack texturePack = new TexturePack(texturePackNode, this);
            return texturePack;
        }

        public void AddShader(Shader shader)
        {
            _node.AppendChild(shader._node);
            Shaders.Add(shader);
            _newNode = true;
        }

        public void DeleteShader(Shader shader)
        {
            Shaders.Remove(shader);
        }

        public void AddModel(Model model)
        {
            _node.AppendChild(model._node);
            Models.Add(model);
            _newNode = true;
        }

        public void DeleteModel(Model model)
        {
            Models.Remove(model);
        }

        public void AddParticles(Particles particles)
        {
            _node.AppendChild(particles._node);
            Particles.Add(particles);
            _newNode = true;
        }

        public void DeleteParticles(Particles particles)
        {
            Particles.Remove(particles);
        }

        public void AddContainer(Container container)
        {
            _node.AppendChild(container._node);
            Containers.Add(container);
            _newNode = true;
        }

        public void DeleteContainer(Container container)
        {
            Containers.Remove(container);
        }

        public void AddTexturePack(TexturePack texturePack)
        {
            _node.AppendChild(texturePack._node);
            TexturePacks.Add(texturePack);
            _newNode = true;
        }

        public void DeleteTexturePack(TexturePack texturePack)
        {
            TexturePacks.Remove(texturePack);
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