using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HiddenObjectStudio.Core.ResourcesManager;
using System.IO;
using HiddenObjectStudio.Core;

namespace HiddenObjectStudio.Core.Forms
{
    public partial class ResourcesManagerMainForm : Form
    {
        private static string ModelValueName = "Model";
        private static string ShaderValueName = "Shader";
        private static string TexturePackValueName = "TexturePack";
        private static string ContainerValueName = "Container";

        private Type _destNodeType;
        public List<TreeNode> _parents;
        public Boolean _resFileLoaded = false;
        public Boolean _resFileJustOpened = false;
        public ResourcesData resourcesData;
        private string _filePath;
        private int _shaderFrameCount = 0;
        
        public ResourcesManagerMainForm()
        {
            //resourcesData = new ResourcesData();
            InitializeComponent();
            InitializeOpenFileDialog();
            _parents = new List<TreeNode>();
        }

        private void InitializeOpenFileDialog()
        {
            // Set the file dialog to filter for graphics files.

            this.openFileDialog1.Filter =
                "XML (*.XML)|*.XML|" +
                "All files (*.*)|*.*";

            this.openFileDialog1.Multiselect = false;
            this.openFileDialog1.Title = "Select resources.xml!";

            this.openFileDialogAnimFirstImage.Filter =
                "png (*.png)|*.PNG|" +
                "All files (*.*)|*.*";

            this.openFileDialogAnimFirstImage.Multiselect = false;
            this.openFileDialogAnimFirstImage.Title = "Select first shader for Animation!";
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = this.openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                string file = openFileDialog1.FileName;

                OpenFile(file);
                
            }
        }

        private void OpenFile(string file)
        {
            _filePath = file;

            treeView1.Nodes.Clear();

            resourcesData = new ResourcesData(file);

            resourcesData.AttachToTree(treeView1);

            _resFileLoaded = true;

            _resFileJustOpened = true;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                //  ((TreeView)sender).SelectedNode.SelectedImageIndex = ((TreeView)sender).SelectedNode.ImageIndex;
                treeView1.SelectedNode.SelectedImageIndex = treeView1.SelectedNode.ImageIndex;
                _destNodeType = treeView1.SelectedNode.Tag.GetType();
            }

            if (_destNodeType != null)
            {
                if (_destNodeType.Name == "Shader")
                {
                    Shader shader = (Shader)treeView1.SelectedNode.Tag;
                    string fullPath = shader.GetShaderFullNodePath();
                    textBox1.Text = fullPath;
                }
                else
                {
                    textBox1.Text = String.Empty;
                }
            }
        }

        private void treeView1_MouseClick(object sender, MouseEventArgs e)
        {
            Point pt = ((TreeView)sender).PointToScreen(new Point(e.X, e.Y));
            Point ptTreeNode = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));
            TreeNode DestinationNode = ((TreeView)sender).GetNodeAt(ptTreeNode);

            if (e.Button == MouseButtons.Right)
            {
                if (_destNodeType != null)
                {
                    if (_destNodeType.Name == ContainerValueName)
                    {
                        contextMenuAddItem.Show(pt);
                    }
                }
            }
        }
        
        private void ExpandNode(TreeNode node)
        {
            if (node.Parent != null)
            {
                _parents.Add(node.Parent);
                ExpandNode(node.Parent);
            }
            for (int i = 0; i < _parents.Count; i++)
            {
                _parents[i].Expand();
            }
        }

        private void addShaderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Container parentContainer = (Container)treeView1.SelectedNode.Tag;
            Shader shader = parentContainer.CreateShader();

            AddShaderForm f = new AddShaderForm(shader, _filePath);
            DialogResult dr = f.ShowDialog();
            if (dr == DialogResult.OK)
            {
                parentContainer.AddShader(shader);
                //TreeNode newTreeNode = new TreeNode();
                // shader.AttachToTreeNode(treeView1.SelectedNode.Nodes, newTreeNode);
                resourcesData.ReAttachToTree(treeView1);
            }
        }
            
        private void addModelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Container parentContainer = (Container)treeView1.SelectedNode.Tag;
            Model model = parentContainer.CreateModel();

            AddModelForm f = new AddModelForm(model, _filePath);
            DialogResult dr = f.ShowDialog();
            if (dr == DialogResult.OK)
            {
                parentContainer.AddModel(model);
                //TreeNode newTreeNode = new TreeNode();
                // shader.AttachToTreeNode(treeView1.SelectedNode.Nodes, newTreeNode);
                resourcesData.ReAttachToTree(treeView1);
            }
        }

        private void addContainerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void addParticlesToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void addTexturePackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Container parentContainer = (Container)treeView1.SelectedNode.Tag;
            TexturePack tP = parentContainer.CreateTexturePack();

            AddTexturePackForm f = new AddTexturePackForm(tP, _filePath);

            DialogResult dr = f.ShowDialog();
            if (dr == DialogResult.OK)
            {
                parentContainer.AddTexturePack(tP);
                //TreeNode newTreeNode = new TreeNode();
                // shader.AttachToTreeNode(treeView1.SelectedNode.Nodes, newTreeNode);
                resourcesData.ReAttachToTree(treeView1);
            }
        }

        private void buttonGetShaderByName_Click(object sender, EventArgs e)
        {
            string shPath = resourcesData.GetShaderPathByFullName(textBox1.Text);
            if (shPath != String.Empty)
            {
                MessageBox.Show(shPath, "File Path", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Shader " + textBox1.Text + " don't exist in resources.xml");
            }
           
        }

        private void treeView1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }

        }

        private void treeView1_DragDrop(object sender, DragEventArgs e)
        {
            Container parentContainer = null;
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                
                foreach (string file in files)
                {
                    FileInfo fileInfo = new FileInfo(file);

                    if (fileInfo.Extension.ToLower() == ".xml")
                    {
                        if (files.Length > 1)
                        {
                            MessageBox.Show("Error! Can't attach more then one files", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else if (files.Length == 1)
                        {
                            OpenFile(file);
                        }
                    
                    }
                    if ((_resFileLoaded) && (!_resFileJustOpened))
                    {
                        if (Path.HasExtension(file))
                        {
                            if (_destNodeType == null)
                            {
                                MessageBox.Show("Select node first");
                                break;
                            }

                            if (_destNodeType.Name == ContainerValueName)
                            {
                                if (treeView1.SelectedNode != null)
                                {
                                    parentContainer = (Container)treeView1.SelectedNode.Tag;
                                }
                            }
                            else
                            {
                                if (treeView1.SelectedNode.Parent.Tag != null)
                                {
                                    parentContainer = (Container)treeView1.SelectedNode.Parent.Tag;
                                }
                            }

                            if (parentContainer != null)
                            {
                                if (fileInfo.Extension.ToLower() == ".png")
                                {
                                    Shader shader = parentContainer.CreateShader();

                                    shader.ShaderName = Path.GetFileNameWithoutExtension(fileInfo.Name);

                                    DialogResult dr = MessageBox.Show("Re-save image? Otherwise this image will be added to resources", "Info!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

                                    if (dr == DialogResult.Yes)
                                    {
                                        //this.folderBrowserDialog1.SelectedPath = CutFilePath(_filePath) + "\\";

                                        string filePath = SaveFileWithDialog(fileInfo.FullName);

                                        string valueToXML = Tools.GetPathBetweenFilesFolder(_filePath, filePath);

                                        string a = Path.GetFileNameWithoutExtension(filePath);

                                        shader.TextureName = valueToXML + "\\" + a;
                                    }
                                    else if (dr == DialogResult.No)
                                    {
                                        string valueToXML = Tools.GetPathBetweenFilesFolder(_filePath, fileInfo.FullName);

                                        string a = Path.GetFileNameWithoutExtension(fileInfo.FullName);

                                        if (Path.HasExtension(valueToXML))
                                        {
                                            shader.TextureName = valueToXML.Substring(0, valueToXML.Length - 4) + "\\" + a;
                                        }
                                        else
                                        {
                                            shader.TextureName = valueToXML + "\\" + a;
                                        }

                                    }
                                    else
                                    {
                                        break;
                                    }

                                    parentContainer.AddShader(shader);

                                    resourcesData.ReAttachToTree(treeView1);
                                }
                            }
                        }
                        else if (!Path.HasExtension(file))
                        {
                            DirectoryInfo di = new DirectoryInfo(file);

                            FileInfo[] filesInfo = di.GetFiles();

                            if (filesInfo.Length > 0)
                            {
                                if (_destNodeType == null)
                                {
                                    MessageBox.Show("Select node first");
                                    break;
                                }
                                if (_destNodeType.Name == ContainerValueName)
                                {
                                    if (treeView1.SelectedNode != null)
                                    {
                                        parentContainer = (Container)treeView1.SelectedNode.Tag;
                                    }
                                }
                                else
                                {
                                    if (treeView1.SelectedNode.Parent.Tag != null)
                                    {
                                        parentContainer = (Container)treeView1.SelectedNode.Parent.Tag;
                                    }
                                }

                                if (parentContainer != null)
                                {
                                    Shader shader = parentContainer.CreateShader();

                                    shader.ShaderName = Path.GetFileNameWithoutExtension(fileInfo.Name);

                                    if (files.Length > 1)
                                    {
                                        MessageBox.Show("Error! Can't attach more then one files", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                    else if (files.Length == 1)
                                    {
                                        DialogResult dr = MessageBox.Show("Re-save animation?", "Add Shader animation!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

                                        if (dr == DialogResult.Yes)
                                        {
                                            string filePath = SaveFileWithDialog(fileInfo.FullName);

                                            if (filePath == string.Empty)
                                            {
                                                break;
                                            }

                                            string valueToXML = Tools.GetPathBetweenFilesFolder(_filePath, filePath);

                                            string firstFrameName = GetFirstFrame(filePath);
                                            
                                            shader.TextureName = valueToXML + "\\" + firstFrameName;
                                            if (_shaderFrameCount != 0)
                                            {
                                                shader.FrameCount = _shaderFrameCount.ToString();
                                            }
                                            
                                        }
                                        else if (dr == DialogResult.No)
                                        {
                                            string valueToXML = Tools.GetPathBetweenFilesFolder(_filePath, fileInfo.FullName);

                                            string firstFrameName = GetFirstFrame(fileInfo.FullName);

                                            shader.TextureName = valueToXML + "\\" + firstFrameName;

                                            if (_shaderFrameCount != 0)
                                            {
                                                shader.FrameCount = _shaderFrameCount.ToString();
                                            }
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }

                                    parentContainer.AddShader(shader);

                                    resourcesData.ReAttachToTree(treeView1);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Folder is empty");
                            }
                        }
                    }
                    _resFileJustOpened = false;
                }
            }
        }

        private void AddShaderByMove()
        {

        }

        private string GetFirstFrame(string filePath)
        {
            OpenFileDialog oFileDialog = new OpenFileDialog();

            string outString = string.Empty;

            oFileDialog.Title = "Select first frame";
            oFileDialog.InitialDirectory = filePath;
            oFileDialog.Filter =
                 "png (*.png)|*.PNG|" +
                 "All files (*.*)|*.*";

            DialogResult drFirstFrame = oFileDialog.ShowDialog();

            if (drFirstFrame == DialogResult.OK)
            {
                outString = Path.GetFileNameWithoutExtension(oFileDialog.FileName);

                DirectoryInfo di = new DirectoryInfo(filePath);

                if (di.Exists)
                {
                    FileInfo[] files = di.GetFiles();

                    if (files.Length > 0)
                    {
                        _shaderFrameCount = files.Length;
                    }
                }
            }
            else if (drFirstFrame == DialogResult.Cancel)
            {
                DirectoryInfo di = new DirectoryInfo(filePath);

                if (di.Exists)
                {
                    FileInfo[] files = di.GetFiles();

                    if (files.Length >0)
                    {
                        outString = Path.GetFileNameWithoutExtension(files[0].Name);
                        
                        _shaderFrameCount = files.Length;
                        
                        MessageBox.Show("First frame name = " + outString);
                        
                    }
                }
            }
            else
            {
                outString = string.Empty;
            }

            return outString;
        }

        private string SaveFileWithDialog(string inputStr)
        {
            FileInfo fileInfo = null;
            DirectoryInfo directoryInfo = null;
            bool itsDir = true;

            saveFileDialog1.InitialDirectory = CutFilePath(_filePath) + "\\";

            FileAttributes attr = File.GetAttributes(inputStr);
            if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
            {
                directoryInfo = new DirectoryInfo(inputStr);

                saveFileDialog1.FileName = directoryInfo.Name;
                
                itsDir = true;
            }
            else
            {
                fileInfo = new FileInfo(inputStr);

                saveFileDialog1.FileName = fileInfo.Name;
                saveFileDialog1.Filter =
                     "png (*.png)|*.PNG|" +
                     "All files (*.*)|*.*";

                itsDir = false;
            }

            DialogResult folderDr = this.saveFileDialog1.ShowDialog();
            string outStr = string.Empty;

            if (folderDr == DialogResult.OK)
            {
                string newfilePath = saveFileDialog1.FileName;
                
                if (!itsDir)
                {

                    FileInfo newfileInfo = new FileInfo(newfilePath);

                    if (newfileInfo.Exists)
                    {
                        newfileInfo.Delete();
                    }

                    string oldFilePath = fileInfo.FullName;

                    if (Path.HasExtension(newfilePath))
                    {
                        fileInfo.CopyTo(newfilePath);
                        outStr = newfilePath;
                    }
                    else
                    {
                        fileInfo.CopyTo(newfilePath + ".png");
                        outStr = newfilePath + ".png";
                    }
                }
                else
                {
                    DirectoryInfo newDirInfo = new DirectoryInfo(newfilePath);

                    CopyDirectory(directoryInfo, newDirInfo);

                    outStr = newfilePath;

                }
            }
            else
            {
                MessageBox.Show("No money, no honey!","Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return outStr;
        }

        private void CopyDirectory(DirectoryInfo di, DirectoryInfo outputDi)
        {
            
            foreach (FileInfo fi in di.GetFiles())
            {
                string filePath = fi.FullName;
                string fileName = fi.Name;

                string newPath = outputDi.FullName + "\\" + fi.Name;

                if (!outputDi.Exists)
                {
                    outputDi.Create();
                }
                FileInfo newFi = new FileInfo(newPath);

                if (newFi.Exists)
                {
                    File.SetAttributes(newFi.FullName, FileAttributes.Normal);
                    newFi.Delete();
                }

                fi.CopyTo(newPath);
            }

            foreach (DirectoryInfo drs in di.GetDirectories())
            {
                string directoryPath = drs.FullName;
                string newDirectoryPath = outputDi.FullName + "\\" + drs.Name;
                DirectoryInfo newDirectoryInfo = new DirectoryInfo(newDirectoryPath);
                
                if (!newDirectoryInfo.Exists)
                {
                    newDirectoryInfo.Create();
                }

                CopyDirectory(drs, newDirectoryInfo);
            }
        }

        

        private string CutFilePath(string str)
        {
            str = str.Substring(0, str.LastIndexOf('\\'));

            return str;
        }

        private void treeView1_DragOver(object sender, DragEventArgs e)
        {
            Point ptTreeNode = (treeView1).PointToClient(MousePosition);
            TreeNode DestinationNode = (treeView1).GetNodeAt(ptTreeNode);
            treeView1.SelectedNode = DestinationNode;
            if (treeView1.SelectedNode != null)
            {
                _destNodeType = treeView1.SelectedNode.Tag.GetType();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            resourcesData.SaveToXml(_filePath);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = "d:\\Projects\\ShipOfSpirit\\Bin\\data\\aasdfasd\\www\\rr";
            string f = "d:\\Projects\\ShipOfSpirit\\Bin\\data\\scenes\\bow\\textures\\oblako";

            string a = Tools.GetPathBetweenFilesFolder(s, f);
//             if (_destNodeType.Name == "Container")
//             {
//                 if (treeView1.SelectedNode != null)
//                 {
//                     Container parentContainer = (Container)treeView1.SelectedNode.Tag;
//                     Shader shader = parentContainer.CreateShader();
// 
//                     AddShaderForm f = new AddShaderForm(shader);
//                     f.Show();
//                 }
//             }
//             else
//             {
//                 if (treeView1.SelectedNode.Parent.Tag != null)
//                 {
//                     Container parentContainer = (Container)treeView1.SelectedNode.Parent.Tag;
//                     Shader shader = parentContainer.CreateShader();
// 
//                     AddShaderForm f = new AddShaderForm(shader);
//                     f.Show();
// 
//                 }
//             }
        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            Type selectedNodeType;

            if (treeView1.SelectedNode != null)
            {
                selectedNodeType = treeView1.SelectedNode.Tag.GetType();

                if (selectedNodeType.Name == ShaderValueName)
                {
                    Shader shader = (Shader)treeView1.SelectedNode.Tag;
                    AddShaderForm f = new AddShaderForm(shader, _filePath);

                    
                    DialogResult dr = f.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        treeView1.Nodes.Clear();
                        resourcesData.AttachToTree(treeView1);
                    }
                }
                else if (selectedNodeType.Name == TexturePackValueName)
                {
                    TexturePack texturePack = (TexturePack)treeView1.SelectedNode.Tag;
                    AddTexturePackForm f = new AddTexturePackForm(texturePack, _filePath);
                    DialogResult dr = f.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        treeView1.Nodes.Clear();
                        resourcesData.AttachToTree(treeView1);
                    }
                }
                else if (selectedNodeType.Name == ModelValueName)
                {
                    Model model = (Model)treeView1.SelectedNode.Tag;
                    AddModelForm f = new AddModelForm(model, _filePath);
                    DialogResult dr = f.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        treeView1.Nodes.Clear();
                        resourcesData.AttachToTree(treeView1);
                    }
                }

            }
         //   treeView1.Refresh();
        }

        private void treeView1_NodeMouseHover(object sender, TreeNodeMouseHoverEventArgs e)
        {
            string imagePath = string.Empty;

            Type nodeType = e.Node.Tag.GetType();

            if (nodeType.Name == "Shader")
            {
                Shader shader = (Shader)e.Node.Tag;

                imagePath = Tools.GetFolderByInputFolderAndPath(_filePath, shader.TextureName);
                if (File.Exists(imagePath))
                {
                    Bitmap imageToShow = new Bitmap(imagePath);
                    Bitmap newImageToShow = null;
                    int formWidth = this.Width;

                    bool resize = false;

                    if (imageToShow.Width == 1024)
                    {
                        resize = true;
                        newImageToShow = Tools.ResizeBitmap(imageToShow, imageToShow.Width / 2, imageToShow.Height / 2);
                    }

                    textBoxSize.Text = string.Empty;
                    if (resize)
                    {
                        int newformWidth = 600 + newImageToShow.Width + 30;

                        if (formWidth < newformWidth)
                        {
                            do
                            {
                                this.Width += 5;
                            } while (this.Width < newformWidth);
                        }
                        else
                        {
                            do
                            {
                                this.Width -= 5;
                            } while (this.Width > newformWidth);
                        }

                        pictureBoxImage.Size = newImageToShow.Size;
                        pictureBoxImage.Image = newImageToShow;
                        textBoxSize.Text = newImageToShow.Size.Width + " | " + newImageToShow.Size.Height;
                    }
                    else
                    {
                        int newformWidth = 600 + imageToShow.Width + 30;

                        if (formWidth < newformWidth)
                        {
                            do
                            {
                                this.Width += 5;
                            } while (this.Width < newformWidth);
                        }
                        else
                        {
                            do
                            {
                                this.Width -= 5;
                            } while (this.Width > newformWidth);
                        }

                        pictureBoxImage.Size = imageToShow.Size;
                        pictureBoxImage.Image = imageToShow;
                        textBoxSize.Text = imageToShow.Size.Width + " | " + imageToShow.Size.Height;
                    }



                }
                else
                {
                    // mb todo
                }
            }
        }         
    }
}
