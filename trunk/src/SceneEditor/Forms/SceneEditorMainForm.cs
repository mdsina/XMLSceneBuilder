using System;
using System.Windows.Forms;
using System.Drawing;
using System.Xml;
using HiddenObjectStudio.Core.SceneManagement;


namespace SceneEditor.Forms
{
	public partial class SceneEditorMainForm : Form
	{
		private ResourceFilesLibrary _library;
        private Scene _scene;
		//private Project _project;
        public Layer previosLayer;
        private TreeNode sourceNode;

        private string _filename;

        string treeNodeText;
        bool flagCheckNodeParents;
        bool leftMouseButton;
        bool rightMouseButton;

        public SceneEditorMainForm(string fileName)
		{
			_scene = new Scene();
			_scene.LoadFromXml(fileName);
            _filename = fileName;
			//scene.SceneFilePath
		   InitializeComponent();
           
			//_project = new Project();
			_library = new ResourceFilesLibrary();

            
			//comboBoxEventType.SelectedIndex = 0;
		}

		private void MainForm_Load(object sender, EventArgs e)
		{

           // this.treeViewLayers.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeViewLayers_ItemDrag);
          //  this.treeViewLayers.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeViewLayers_DragEnter);
          //  this.treeViewLayers.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeViewLayers_DragDrop);
           

			if ((WindowState = SettingsAndConstants.MainFormState) == FormWindowState.Normal)
			{
				Location = SettingsAndConstants.MainFormPosition.Location;
				Width = SettingsAndConstants.MainFormPosition.Width;
				Height = SettingsAndConstants.MainFormPosition.Height;
			}

			if (SettingsAndConstants.LastProjectFileName != string.Empty)
			{
				//_project.OpenProject(SettingsAndConstants.LastProjectFileName);
			}

			RefreshFormData();
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if ((SettingsAndConstants.MainFormState = WindowState) == FormWindowState.Normal)
			{
				SettingsAndConstants.MainFormPosition.Location = Location;
				SettingsAndConstants.MainFormPosition.Width = Width;
				SettingsAndConstants.MainFormPosition.Height = Height;
			}

			//SettingsAndConstants.LastProjectFileName = _project.FileName;
		}

		private void RefreshFormData()
		{
			//_scene = _project.Scene;
            textBoxSceneName.Text = _scene.Name;
			RefreshLayersTree();
			RefreshLayerProperties();

// 			if (_project.FileName != string.Empty)
// 				this.Text = SettingsAndConstants.WindowTitle + " - [" + _project.FileName + "]";
// 			else
// 				this.Text = SettingsAndConstants.WindowTitle + " - [untitled]";
		}

		private void RefreshLayerProperties()
		{
			layerPropertiesControl.SceneAnimations = _scene.Animations;
			layerPropertiesControl.RefreshLayerProperties();
		}

        private void RefreshLayersTree()
        {
            if (_scene == null) return;

            treeViewLayers.Nodes.Clear();

			foreach (Layer layer in _scene.Layers)
			{
				TreeNode layerNode = new TreeNode();
				layer.AttachToTreeNode(layerNode);
				treeViewLayers.Nodes.Add(layerNode);
			}		
            
        }
// 
// 
// 		private void newMenuItem_Click(object sender, EventArgs e)
// 		{
// 			//_project.NewProject();
//             RefreshFormData();
// 		}
// 
// 		private void openMenuItem_Click(object sender, EventArgs e)
// 		{
// 			OpenFileDialog dialog = new OpenFileDialog();
// 
// 			dialog.Filter = "XML files|*.xml|All files|*.*";
//             dialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
// 			if (DialogResult.OK == dialog.ShowDialog())
// 			{
// 				try
// 				{
// 					//_project.OpenProject(dialog.FileName);
// 				}
// 				catch (Exception ex)
// 				{
// 					MessageBox.Show(ex.Message);
// 				}
// 
// 				RefreshFormData();
// 			}
// 
// // 			listViewLayers.Items.Clear();
// // 			foreach (Layer layer in _scene.Layers.Values)
// // 			{
// // 				ListViewItem item = new ListViewItem(layer.Name);
// // 				listViewLayers.Items.Add(item);
// // 			}
// 			//_sceneController.UpdateView();
// 		}
// 
// 		private void saveMenuItem_Click(object sender, EventArgs e)
// 		{
// 			if (_project.FileName == null || _project.FileName == string.Empty)
// 				saveAsMenuItem_Click(sender, e);
// 			else
// 			{
//                 _project.Name = textBoxSceneName.Text;
// 
// 				_project.SaveProject();
// 			}
// 		}
// 
//         private void saveAsMenuItem_Click(object sender, EventArgs e)
//         {
//             SaveFileDialog dialog = new SaveFileDialog();
//             dialog.Filter = "XML files|*.xml|All files|*.*";
//             if (DialogResult.OK == dialog.ShowDialog())
//             {
//                 _project.SaveProjectAs(dialog.FileName);
//             }
//         }
// 
// 		private void exitMenuItem_Click(object sender, EventArgs e)
// 		{
// 			Close();
// 		}

		private void tabLayers_Click(object sender, EventArgs e)
		{

		}

		

		private void resourceFilesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ResourceFilesForm form = new ResourceFilesForm(_library);
		
			form.ShowDialog();
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
// 			switch (comboBoxEventType.SelectedIndex)
// 			{
// 				case 0:
// 					groupBoxTimerEventProps.Show();
// 					groupBoxMouseClickEventProps.Hide();
// 					groupBoxMouseOnEventProps.Hide();
// 					groupBoxMouseOutEventProps.Hide();
// 					groupBoxAnimationCompleteEventProps.Hide();
// 					break;
// 				case 1:
// 					groupBoxTimerEventProps.Hide();
// 					groupBoxMouseClickEventProps.Show();
// 					groupBoxMouseOnEventProps.Hide();
// 					groupBoxMouseOutEventProps.Hide();
// 					groupBoxAnimationCompleteEventProps.Hide();
// 					break;
// 				case 2:
// 					groupBoxTimerEventProps.Hide();
// 					groupBoxMouseClickEventProps.Hide();
// 					groupBoxMouseOnEventProps.Show();
// 					groupBoxMouseOutEventProps.Hide();
// 					groupBoxAnimationCompleteEventProps.Hide();
// 					break;
// 				case 3:
// 					groupBoxTimerEventProps.Hide();
// 					groupBoxMouseClickEventProps.Hide();
// 					groupBoxMouseOnEventProps.Hide();
// 					groupBoxMouseOutEventProps.Show();
// 					groupBoxAnimationCompleteEventProps.Hide();
// 					break;
// 				case 4:
// 					groupBoxTimerEventProps.Hide();
// 					groupBoxMouseClickEventProps.Hide();
// 					groupBoxMouseOnEventProps.Hide();
// 					groupBoxMouseOutEventProps.Hide();
// 					groupBoxAnimationCompleteEventProps.Show();
// 					break;
// 				default:
// 					groupBoxTimerEventProps.Hide();
// 					groupBoxMouseClickEventProps.Hide();
// 					groupBoxMouseOnEventProps.Hide();
// 					groupBoxMouseOutEventProps.Hide();
// 					groupBoxAnimationCompleteEventProps.Hide();
// 
// 					break;
// 
// 			}
		}


		private void treeViewLayers_AfterSelect(object sender, TreeViewEventArgs e)
		{
			
            layerPropertiesControl.Layer = (Layer)treeViewLayers.SelectedNode.Tag;
            previosLayer = layerPropertiesControl.Layer;
// 			dgvMapping.Rows.Clear();
// 			DataGridViewRow row = new DataGridViewRow();
// 			row.CreateCells();
// 
// 			row.Cells.Add(new DataGridViewCell());
// 			object[] p = { "test1", "test2", 55 };
// 			dgvMapping.Rows.Add(p);

		}

        private void treeViewLayers_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            //layerPropertiesControl.SaveToLayer((Layer)e.Node.Tag);
            if (layerPropertiesControl.IsLayerModified)
            {
                DialogResult res = MessageBox.Show("Save current quest?", "Save?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                if (DialogResult.Yes == res)
                {
                    if (previosLayer != null)
                    {
                        layerPropertiesControl.SaveToLayer(previosLayer);
                        e.Cancel = false;
                    }
                }
                else if (DialogResult.No == res)
                {
                    e.Cancel = false;
                    layerPropertiesControl.IsLayerModified = false;
                }
                else
                {
                    e.Cancel = true;
                }

            }  
        }

        private void buttonAddLayer_Click(object sender, EventArgs e)
        {

            if (treeViewLayers.SelectedNode != null)
            {
                if (treeViewLayers.SelectedNode.Parent != null)
                {
                    int index = treeViewLayers.SelectedNode.Parent.Nodes.IndexOf(treeViewLayers.SelectedNode);
                    
                    TreeNode newNode =  treeViewLayers.SelectedNode.Parent.Nodes.Insert(index + 1, "untitled");
                    
                    Layer newLayer = new Layer();
                    newLayer.AttachToTreeNode(newNode);
                    Layer parentLayer = (Layer)treeViewLayers.SelectedNode.Parent.Tag;
                        
                    _scene.Layers.Add(newLayer);

                }
                else
                {
                    int index = treeViewLayers.Nodes.IndexOf(treeViewLayers.SelectedNode);
                    TreeNode newNode = treeViewLayers.Nodes.Insert(index + 1, "untitled");
                   
                    Layer newLayer = new Layer();
                    newLayer.AttachToTreeNode(newNode);
                    _scene.Layers.Add(newLayer);
                }

            }

        }

        private void treeViewLayers_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            Layer layer = (Layer)e.Node.Tag;
            layer.Name = e.Label;
        }

        private void treeViewLayers_ItemDrag(object sender, ItemDragEventArgs e)
        {
            leftMouseButton = false;
            rightMouseButton = false;

            if (e.Button == MouseButtons.Left)
            {
                leftMouseButton = true;
                DoDragDrop(e.Item, DragDropEffects.Move);
            }
            if (e.Button == MouseButtons.Right)
            {
                rightMouseButton = true;
                DoDragDrop(e.Item, DragDropEffects.Move);
            }
        }

        private void treeViewLayers_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void treeViewLayers_DragDrop(object sender, DragEventArgs e)
        {
            TreeNode NewNode;
            
            if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false))
            {
                bool siblingNodeHaveCurNodeText = false;
                Point pt = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));
                TreeNode DestinationNode = ((TreeView)sender).GetNodeAt(pt);
                NewNode = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");
                flagCheckNodeParents = true;
                if (leftMouseButton)
                {
                    if (CheckNodeParents(DestinationNode, NewNode))
                    {
                        foreach (TreeNode siblingNode in DestinationNode.Nodes)
                        {
                            if (siblingNode.Text == NewNode.Text)
                            {
                                siblingNodeHaveCurNodeText = true;
                            }
                        }
                        if (!siblingNodeHaveCurNodeText)
                        {
                            DestinationNode.Nodes.Add((TreeNode)NewNode.Clone());
                            // DestinationNode.Expand();
                            //Remove Original Node
                            Layer oldLayer = (Layer)NewNode.Tag;
                            NewNode.Remove();
                            Layer layer = (Layer)NewNode.Tag;
                            layer.Parent = (Layer)DestinationNode.Tag;
                            _scene.Layers.Remove(oldLayer);
                        }
                    }
                }
                if (rightMouseButton)
                {
                    if (DestinationNode.Level == NewNode.Level)
                    {
                        
                        if (DestinationNode.Parent != null)
                        {

                            

                            DestinationNode.Parent.Nodes.Insert(DestinationNode.Index + 1, (TreeNode)NewNode.Clone());

                            Layer layer = (Layer)NewNode.Tag;
                            Layer parentLayer = (Layer)NewNode.Parent.Tag;
                          //  layer.Parent = parentLayer;
                            int oldIndexIns = parentLayer.ChildLayers.IndexOf(layer);

                            parentLayer.ChildLayers.RemoveAt(oldIndexIns);

                            Layer distLayer = (Layer)DestinationNode.Tag;
                            parentLayer = (Layer)DestinationNode.Parent.Tag;
                            distLayer.Parent = parentLayer;

                            int newIndexIns = parentLayer.ChildLayers.IndexOf(distLayer);
                            parentLayer.ChildLayers.Insert(newIndexIns + 1, layer);

                            NewNode.Remove();

                            
                        }
                        else 
                        {
                            DestinationNode.TreeView.Nodes.Insert(DestinationNode.Index + 1, (TreeNode)NewNode.Clone());

                            Layer layer = (Layer)NewNode.Tag;
                            
                            int oldIndexIns = _scene.Layers.IndexOf(layer);

                            _scene.Layers.RemoveAt(oldIndexIns);

                            Layer distLayer = (Layer)DestinationNode.Tag;

                            int newIndexIns = _scene.Layers.IndexOf(distLayer);
                            _scene.Layers.Insert(newIndexIns+1, layer);
                            
                            
                            NewNode.Remove();

                        }
//                         Layer layer = (Layer)NewNode.Tag;
//                         int oldIndex = DestinationNode.Index;

                        
                        //                         DestinationNode.TreeView.Nodes.Insert(DestinationNode.Index + 1, (TreeNode)NewNode.Clone());
//                         NewNode.Remove();
//                         Layer layer = (Layer)NewNode.Tag;
                        //                         object temp = NewNode.Tag;
//                         NewNode.Tag = DestinationNode.Tag;
//                         DestinationNode.Tag = temp;
                    }
                }
            }
        }

        private bool CheckNodeParents(TreeNode treeNode, TreeNode treeNodeToCheck)
        {
            if (treeNode.Parent != null)
            {
                if (treeNodeToCheck == treeNode.Parent)
                {
                    return false;
                }
                else
                {
                    return CheckNodeParents(treeNode.Parent, treeNodeToCheck);
                }
            }
            return true;
        }

        private void textBoxPositionY_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxPositionX_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxSizeY_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxSizeX_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxSize_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxPosition_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void saveMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void buttonLayerSave_Click(object sender, EventArgs e)
        {
            _scene.SaveToXml(_filename);
        }

        private void buttonDeleteLayer_Click(object sender, EventArgs e)
        {
            treeViewLayers.CollapseAll();
        }

        private void buttonExtract_Click(object sender, EventArgs e)
        {
            treeViewLayers.ExpandAll();
        }
    }
}