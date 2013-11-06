using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HiddenObjectStudio.Core.SceneManagement;
using HiddenObjectStudio.Core.LocationManagement;

namespace QuestMonkey
{
	public partial class SelectLayerForm : Form
	{
		private Scene _scene;

		public Layer SelectedLayer;

		public SelectLayerForm(Scene scene)
		{
			InitializeComponent();

			_scene = scene;
		}

		private void SelectLayerForm_Load(object sender, EventArgs e)
		{
			_scene.Layers.DisplayInTreeView(treeViewLayers.Nodes);
		}

		private void treeViewLayers_AfterSelect(object sender, TreeViewEventArgs e)
		{
			if (e.Node != null)
			{
				SelectedLayer = (Layer)e.Node.Tag;
			}
		}

		private void treeViewLayers_DoubleClick(object sender, EventArgs e)
		{
			SelectedLayer = (Layer)treeViewLayers.SelectedNode.Tag;
			DialogResult = DialogResult.OK;
			Close();
		}

		private void buttonSelectAndClose_Click(object sender, EventArgs e)
		{
			treeViewLayers_DoubleClick(sender, e);
		}
	}
}
