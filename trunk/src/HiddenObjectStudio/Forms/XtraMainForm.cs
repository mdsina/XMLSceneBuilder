using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QuestMonkey;
using SceneEditor.Forms;
using HiddenObjectStudio.Classes;
using HiddenObjectStudio.Core;
using HiddenObjectStudio.Core.SceneManagement;
using HiddenObjectStudio.Core.LocationManagement;


namespace HiddenObjectStudio.Forms
{
    public partial class XtraMainForm : DevExpress.XtraEditors.XtraForm
    {
		public Project Project;

        private LocationManager _locationsManager;

        public XtraMainForm()
        {
			Project = new Project();

            Project.ProjectPath = "d:\\Projects\\KariAnderson\\bin\\";

            _locationsManager = new LocationManager(Project.ProjectPath + "data\\levels\\levels.xml");
            InitializeComponent();
            FillLocationsTree();
        }

      
        private void treeViewSceneManager_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void treeViewSceneManager_MouseClick(object sender, MouseEventArgs e)
        {
            Point pt = ((TreeView)sender).PointToScreen(new Point(e.X, e.Y));
            Point ptTreeNode = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));
            TreeNode DestinationNode = ((TreeView)sender).GetNodeAt(ptTreeNode);
            if (e.Button == MouseButtons.Right)
            {
                //contextMenuEditScene.Show(q);
                contextMenuEditScene.Show(pt);
            }
           
        }

        
        private void editResourcesFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditSceneResourcesForm editScResForm = new EditSceneResourcesForm();
            //dockPanelSceneResources.Show();
            //dockPanelSceneResources.Visibility
            //editScResForm.MdiParent = this;
            editScResForm.Show();
        }

        private void editMinigamesFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditMiniGamesForm editMiniGamesForm = new EditMiniGamesForm();
            editMiniGamesForm.Show();
        }

        private void changeLevelsxmlSceneDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScenePropertiesForm scenePropertiesForm = new ScenePropertiesForm();
            scenePropertiesForm.Show();
        }

        private void treeViewSceneManager_DoubleClick(object sender, EventArgs e)
        {
			SceneInfo selectedScene = (SceneInfo)treeViewSceneManager.SelectedNode.Tag;

			string sceneFileName = Project.ProjectPath + "data\\scenes\\" + selectedScene.SceneFilePath;

			SceneEditorMainForm sceneLayers = new SceneEditorMainForm(sceneFileName);
			sceneLayers.Text = selectedScene.Name;
            //   MDIMainForm mdiMainForm = new MDIMainForm();
            // MessageBox.Show(((TreeView)sender).SelectedNode.FullPath);
			
            sceneLayers.MdiParent = this;
            sceneLayers.Show();
        }

        private void FillLocationsTree()
        {
            
            //TreeView sceneTree = (TreeView)dockManager1.Panels[dockPanelSceneManager.Name].Controls[treeViewSceneManager.Name];
            
            treeViewSceneManager.Nodes.Clear();
            foreach (Location place in _locationsManager.Locations)
            {
                TreeNode placeTreeNode = new TreeNode();
                place.MainScene.AttachToTreeNode(treeViewSceneManager.Nodes, placeTreeNode);
            }

        }
    }
}