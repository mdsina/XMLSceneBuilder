using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using SceneEditor.Forms;
using HiddenObjectStudio.Core;
using HiddenObjectStudio.Core.SceneManagement;


namespace SceneEditor
{
	public partial class LayerPropertiesControl : UserControl
	{
		private Layer _layer;
        private Animations _animations;
        private bool _isLayerModified;
        public bool IsLayerModified
        {
            get { return _isLayerModified; }
            set { _isLayerModified = value; }
        }
        public Layer Layer
		{
			get
			{
				return _layer;
			}

			set
			{
				_layer = value;
				UpdateControlsFromLayer();
				RefreshLayerProperties();
                IsLayerModified = false;
			}
		}

		

		public Animations SceneAnimations
		{
			get
			{
				return _animations;
			}

			set
			{
				_animations = value;
		//		DataGridViewComboBoxColumn column = (DataGridViewComboBoxColumn)dgvMapping.Columns["AnimationColumn"];
				//column.DataSource = _animations.Names;
				UpdateControlsFromLayer();
				RefreshLayerProperties();
			}

		}


        public void ClearAllLayerData()
        {
            textBoxLayerName.Text = "";
           
            checkBoxTexturePack.Checked = false;
            comboBoxTexturePack.Text = "";
            comboBoxTextureName.Text = "";
            
            checkBoxShader.Checked = false;
            comboBoxShader.Text = ""; 

            checkBoxFlipUV.Checked = false;
            comboBoxFlipUV.Text = "";

            checkBoxModel.Checked = false;
            comboBoxModel.Text = "";

            checkBoxSize.Checked = false;
            textBoxSizeX.Text = "";
            textBoxSizeY.Text = "";

            checkBoxScaleUV.Checked = false;

            checkBoxPosition.Checked = false;
            textBoxPositionX.Text = "";
            textBoxPositionY.Text = "";

            checkBoxScale.Checked = false;
            textBoxScaleX.Text = "";
            textBoxScaleY.Text = "";
            
        }

		public LayerPropertiesControl()
		{
			InitializeComponent();
		}


        public void SaveToLayer(Layer layer)
        {

            if (layer != null)
            {

                if (textBoxLayerName.Text != "")
                {
                    Layer.Name = textBoxLayerName.Text;    
                }

                if (checkBoxTexturePack.Checked)
                {
                    layer.SetAttribute(Layer.XmlAttribNameTexturePack, comboBoxTexturePack.Text);
                    layer.SetAttribute(Layer.XmlAttribNameTextureName, comboBoxTextureName.Text);
                }

                if (checkBoxShader.Checked)
                {
                    layer.SetAttribute(Layer.XmlAttribNameShader, comboBoxShader.Text);
                }

                if (checkBoxFlipUV.Checked)
                {
                    layer.SetAttribute(Layer.XmlAttribNameFlipUV, comboBoxFlipUV.Text);
                }

                if (checkBoxModel.Checked)
                {
                    layer.SetAttribute(Layer.XmlAttribNameModel, comboBoxModel.Text);
                }

                if (checkBoxSize.Checked)
                {
                    layer.SetAttribute(Layer.XmlAttribNameSize, textBoxSizeX.Text + " " + textBoxSizeY.Text);
                }

                if (checkBoxScaleUV.Checked)
                {
                    layer.SetAttribute(Layer.XmlAttribNameScalUV, "1");
                }
                IsLayerModified = false;
            }
        }

		public void RefreshLayerProperties()
		{
			// зависимости между отдельными полями

			checkBoxShader.Enabled = !checkBoxTexturePack.Checked;

			checkBoxTexturePack.Enabled = label1.Enabled = !checkBoxShader.Checked;

			checkBoxFlipUV.Enabled = !checkBoxTexturePack.Checked;

			checkBoxModel.Enabled = !checkBoxTexturePack.Checked;

			checkBoxSize.Enabled =
			checkBoxScaleUV.Enabled = !checkBoxTexturePack.Checked && !checkBoxModel.Checked;

			// синхронизация чекбоксов с соответствующими текстовыми полями
			comboBoxTexturePack.Enabled = comboBoxTextureName.Enabled = checkBoxTexturePack.Checked;

            comboBoxLayerCursor.Enabled = checkBoxLayerCursor.Enabled && checkBoxLayerCursor.Checked;

			comboBoxShader.Enabled = checkBoxShader.Enabled && checkBoxShader.Checked;

			comboBoxModel.Enabled = checkBoxModel.Enabled && checkBoxModel.Checked;

			comboBoxFlipUV.Enabled = checkBoxFlipUV.Enabled && checkBoxFlipUV.Checked;

			textBoxSizeX.Enabled =
			textBoxSizeY.Enabled = checkBoxSize.Enabled && checkBoxSize.Checked;

			textBoxPositionX.Enabled =
			textBoxPositionY.Enabled = checkBoxPosition.Enabled && checkBoxPosition.Checked;

			textBoxScaleX.Enabled =
			textBoxScaleY.Enabled = checkBoxScale.Checked;

            

			if (SceneAnimations != null)
			{
				
			}
		}
		
		private void UpdateControlsFromLayer()
		{
			if (Layer == null) return;
            ClearAllLayerData();
            string attrib;

            textBoxLayerName.Text = Layer.Name;

			attrib = Layer.GetAttribValue(Layer.XmlAttribNameTexturePack);
			if (attrib != string.Empty)
			{
				checkBoxTexturePack.Checked = true;
				comboBoxTexturePack.Text = attrib;
				comboBoxTextureName.Text = Layer.GetAttribValue(Layer.XmlAttribNameTextureName);

				checkBoxShader.Checked = false;
			}
			else
			{
				checkBoxTexturePack.Checked = false;
			}

			attrib = Layer.GetAttribValue(Layer.XmlAttribNameShader);
			if (attrib != string.Empty)
			{
				checkBoxShader.Checked = true;
				comboBoxShader.Text = attrib;
			}
			else
			{
				checkBoxShader.Checked = false;
			}

			attrib = Layer.GetAttribValue(Layer.XmlAttribNameFlipUV);
			if (attrib != string.Empty)
			{
				checkBoxFlipUV.Checked = true;
				comboBoxFlipUV.Text = attrib;
			}
			else
			{
				checkBoxFlipUV.Checked = false;
			}

			attrib = Layer.GetAttribValue(Layer.XmlAttribNameModel);
			if (attrib != string.Empty)
			{
				checkBoxModel.Checked = true;
				comboBoxModel.Text = attrib;
			}
			else
			{
				checkBoxModel.Checked = false;
			}

			attrib = Layer.GetAttribValue(Layer.XmlAttribNameSize);
			if (attrib != string.Empty)
			{
				checkBoxSize.Checked = true;
				string [] size = attrib.Split(' ');
				if (size.Length != 0)
				{
					textBoxSizeX.Text = size[0];
					if (size.Length > 1)
						textBoxSizeY.Text = size[1];
				}
				
			}
			else
			{
				checkBoxSize.Checked = false;
			}


			attrib = Layer.GetAttribValue(Layer.XmlAttribNameScalUV);
			if (attrib != string.Empty)
			{
				checkBoxScaleUV.Checked = true;
			}
			else
			{
				checkBoxScaleUV.Checked = false;
			}

// 			attrib = Layer.GetAttribValue(Layer.XmlAttribNameSelectionArea);
// 			if (attrib != string.Empty)
// 			{
// 				checkBoxSelectionArea.Checked = true;
// 				string[] size = attrib.Split(' ');
// 				if (size.Length != 0)
// 				{
// 					textBoxSelAreaX0.Text = size[0];
// 					if (size.Length > 1)
// 						textBoxSelAreaY0.Text = size[1];
// 					if (size.Length > 2)
// 						textBoxSelAreaX1.Text = size[2];
// 					if (size.Length > 3)
// 						textBoxSelAreaY1.Text = size[3];
// 				}
// 			}
// 			else
// 			{
// 				checkBoxSelectionArea.Checked = false;
// 			}

			attrib = Layer.GetAttribValue(Layer.XmlAttribNamePosition);
			if (attrib != string.Empty)
			{
				checkBoxPosition.Checked = true;
				string[] size = attrib.Split(' ');
				if (size.Length != 0)
				{
					textBoxPositionX.Text = size[0];
					if (size.Length > 1)
						textBoxPositionY.Text = size[1];
				}

			}
			else
			{
				checkBoxPosition.Checked = false;
			}

			attrib = Layer.GetAttribValue(Layer.XmlAttribNameScale);
			if (attrib != string.Empty)
			{
				checkBoxScale.Checked = true;
				string[] size = attrib.Split(' ');
				if (size.Length != 0)
				{
					textBoxScaleX.Text = size[0];
					if (size.Length > 1)
						textBoxScaleY.Text = size[1];
				}
			}
			else
			{
				checkBoxScale.Checked = false;
			}

            
			//dgvMapping.Rows.Clear();

			//foreach (Map layerMap in Layer.Maps)
			//{

			//    int index = dgvMapping.Rows.Add();
			//    DataGridViewRow row = dgvMapping.Rows[index];

			//    DataGridViewComboBoxCell cell0 = (DataGridViewComboBoxCell)row.Cells["EventColumn"];
			//    cell0.Value = layerMap.Event.Name;

			//    DataGridViewComboBoxCell cell1 = (DataGridViewComboBoxCell)row.Cells["AnimationColumn"];
			//    cell1.Value = layerMap.Animation.Name;
			//}
			
		}

		private void UpdateLayerFromControls()
		{
			if (Layer == null) return;

           

			if (checkBoxTexturePack.Checked)
			{
				Layer.SetAttribute(Layer.XmlAttribNameTexturePack, comboBoxTexturePack.Text);
				Layer.SetAttribute(Layer.XmlAttribNameTextureName, comboBoxTextureName.Text);
			}

			if (checkBoxShader.Checked)
			{
				Layer.SetAttribute(Layer.XmlAttribNameShader, comboBoxShader.Text);
			}

			if (checkBoxFlipUV.Checked)
			{
				Layer.SetAttribute(Layer.XmlAttribNameFlipUV, comboBoxFlipUV.Text);
			}

			if (checkBoxModel.Checked)
			{
				Layer.SetAttribute(Layer.XmlAttribNameModel, comboBoxModel.Text);
			}

			if (checkBoxSize.Checked)
			{
				Layer.SetAttribute(Layer.XmlAttribNameSize, textBoxSizeX.Text + " " + textBoxSizeY.Text);
			}

			if (checkBoxScaleUV.Checked)
			{
				Layer.SetAttribute(Layer.XmlAttribNameScalUV, "1");
			}

// 			if (checkBoxSelectionArea.Checked)
// 			{
// 				string val = textBoxSelAreaX0.Text + " " +
// 					textBoxSelAreaY0.Text + " " +
// 					textBoxSelAreaX1.Text + " " +
// 					textBoxSelAreaY1.Text;
// 				Layer.SetAttribute(Layer.XmlAttribNameSelectionArea, val);
// 			}

			if (checkBoxPosition.Checked)
			{
				Layer.SetAttribute(Layer.XmlAttribNamePosition, textBoxPositionX.Text + " " + textBoxPositionY.Text);
			}

			if (checkBoxScale.Checked)
			{
				Layer.SetAttribute(Layer.XmlAttribNameScale, textBoxScaleX.Text + " " + textBoxScaleY.Text);
			}

		//	if (dgvMapping.Rows.Count != 0)
		//	{
				Layer.Maps.Clear();

				//foreach (DataGridViewRow row in dgvMapping.Rows)
				//{
				//    if (row.IsNewRow) continue;
				//    Event evnt = SceneEvents.GetEvent(row.Cells["EventColumn"].Value.ToString());
				//    Animation animation = SceneAnimations.GetAnimation(row.Cells["AnimationColumn"].Value.ToString());
				//    Map newMap = new Map(evnt, animation);
				//    Layer.Maps.Add(newMap);
				//}
		//	}

		}

		private void checkBoxTexturePack_CheckedChanged(object sender, EventArgs e)
		{
			RefreshLayerProperties();
            
		}

		private void checkBoxShader_CheckedChanged(object sender, EventArgs e)
		{
			RefreshLayerProperties();
			
		}

		private void checkBoxFlipUV_CheckedChanged(object sender, EventArgs e)
		{
			RefreshLayerProperties();
			
		}

		private void checkBoxModel_CheckedChanged(object sender, EventArgs e)
		{
			RefreshLayerProperties();
			
		}

		private void checkBoxSize_CheckedChanged(object sender, EventArgs e)
		{
			RefreshLayerProperties();
			
		}

		private void checkBoxScaleUV_CheckedChanged(object sender, EventArgs e)
		{
			RefreshLayerProperties();
			
		}

		private void checkBoxSelectionArea_CheckedChanged(object sender, EventArgs e)
		{
			RefreshLayerProperties();
			
		}

		private void checkBoxPosition_CheckedChanged(object sender, EventArgs e)
		{
			RefreshLayerProperties();
			
		}

		private void checkBoxScale_CheckedChanged(object sender, EventArgs e)
		{
			RefreshLayerProperties();
			
		}

        private void checkBoxLayerCursor_CheckedChanged(object sender, EventArgs e)
        {
            RefreshLayerProperties();
        }

		private void comboBoxTexturePack_TextUpdate(object sender, EventArgs e)
		{
            
		//	UpdateLayerFromControls();
            
		}
		private void comboBoxTexturePack_SelectedIndexChanged(object sender, EventArgs e)
		{
		//	UpdateLayerFromControls();
		}

		private void comboBoxTextureName_TextUpdate(object sender, EventArgs e)
		{
		//	UpdateLayerFromControls();
		}
		private void comboBoxTextureName_SelectedIndexChanged(object sender, EventArgs e)
		{
			//UpdateLayerFromControls();

		}

		private void comboBoxShader_TextUpdate(object sender, EventArgs e)
		{
		//	UpdateLayerFromControls();
		}

		private void comboBoxFlipUV_TextUpdate(object sender, EventArgs e)
		{
		//	UpdateLayerFromControls();
		}
		private void comboBoxFlipUV_SelectedIndexChanged(object sender, EventArgs e)
		{
		//	UpdateLayerFromControls();
		}

		private void comboBoxModel_TextUpdate(object sender, EventArgs e)
		{
		//	UpdateLayerFromControls();
		}

		private void comboBoxModel_SelectedIndexChanged(object sender, EventArgs e)
		{
		//	UpdateLayerFromControls();
		}

		private void textBoxSizeX_TextChanged(object sender, EventArgs e)
		{
            if (textBoxSizeX.Enabled)
            {
                IsLayerModified = true;
            }
		}

		private void textBoxSizeY_TextChanged(object sender, EventArgs e)
		{
            if (textBoxSizeY.Enabled)
            {
                IsLayerModified = true;
            }
		}

		private void comboBoxScaleUV_SelectedIndexChanged(object sender, EventArgs e)
		{
           
		}

		private void textBoxSelAreaX0_TextChanged(object sender, EventArgs e)
		{
            
		}

		private void textBoxSelAreaY0_TextChanged(object sender, EventArgs e)
		{
            
		}

		private void textBoxSelAreaX1_TextChanged(object sender, EventArgs e)
		{
            
		}

		private void textBoxSelAreaY1_TextChanged(object sender, EventArgs e)
		{
            
		}

		private void textBoxPositionX_TextChanged(object sender, EventArgs e)
		{
            if (textBoxPositionX.Enabled)
            {
                IsLayerModified = true;
            }
		}

		private void textBoxPositionY_TextChanged(object sender, EventArgs e)
		{
            if (textBoxPositionY.Enabled)
            {
                IsLayerModified = true;
            }
		}

		private void textBoxScaleX_TextChanged(object sender, EventArgs e)
		{
            if (textBoxScaleX.Enabled)
            {
                IsLayerModified = true;
            }
		}

		private void textBoxScaleY_TextChanged(object sender, EventArgs e)
		{
            if (textBoxScaleY.Enabled)
            {
                IsLayerModified = true;
            }
		}

		private void textBoxLayerName_TextChanged(object sender, EventArgs e)
        {
            if (textBoxLayerName.Enabled)
            {
                IsLayerModified = true;
            }
            //SaveToLayer(Layer);
        }

        

		
	}
}
