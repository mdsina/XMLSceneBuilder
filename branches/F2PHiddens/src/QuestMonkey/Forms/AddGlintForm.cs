using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HiddenObjectStudio.Core.SceneManagement;

namespace QuestMonkey
{
	public partial class AddGlintForm : Form
	{

		private Scene _scene;

		public string GlintName;

		public string LayerName;

		public Layer SelectedLayer;




		public AddGlintForm(Scene scene, string suggestedGlintName)
		{
			_scene = scene;

			SelectedLayer = null;

			GlintName = suggestedGlintName;

			InitializeComponent();
		}

		private void buttonSelectLayer_Click(object sender, EventArgs e)
		{
			SelectLayerForm form = new SelectLayerForm(_scene);

			if (DialogResult.OK == form.ShowDialog())
			{
				SelectedLayer = form.SelectedLayer;
				textBoxLayer.Text = SelectedLayer.FullName;
			}
		}

		private void AddGlintForm_Load(object sender, EventArgs e)
		{
			textBoxGlintName.Text = GlintName;
		}

		private void AddGlintForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			GlintName = textBoxGlintName.Text;
			LayerName = textBoxLayer.Text;
		}

		private void buttonOk_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();
		}

	}
}
