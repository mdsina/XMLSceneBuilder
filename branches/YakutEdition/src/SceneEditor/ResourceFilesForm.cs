using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SceneEditor
{
	public partial class ResourceFilesForm : Form
	{
		private ResourceFilesLibrary _library;

		public ResourceFilesForm(ResourceFilesLibrary library)
		{
			InitializeComponent();
			
			_library = library;

			RefreshFilesList();
		}

		private void RefreshFilesList()
		{
			listViewResourceFiles.Items.Clear();
			foreach (string fileName in _library.Files)
			{
				listViewResourceFiles.Items.Add(new ListViewItem(fileName));
			}

		}

		private void buttonAdd_Click(object sender, EventArgs e)
		{
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.Filter = "Xml files|*.xml|All files|*.*";
			dialog.Multiselect = true;
			if (DialogResult.OK == dialog.ShowDialog())
			{
				string [] fileNames = dialog.FileNames;
				_library.Add(ref fileNames);
				RefreshFilesList();
			}
		}

		private void buttonRemove_Click(object sender, EventArgs e)
		{
			if (listViewResourceFiles.SelectedItems.Count != 0)
			{
				if (DialogResult.Yes == MessageBox.Show("Are you sure?", "Really remove?", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
					foreach (ListViewItem item in listViewResourceFiles.SelectedItems)
					{
						_library.Remove(item.Text);
					}
					
			}

			RefreshFilesList();
		}

		private void buttonClose_Click(object sender, EventArgs e)
		{
			Close();
		}


		
	}
}
