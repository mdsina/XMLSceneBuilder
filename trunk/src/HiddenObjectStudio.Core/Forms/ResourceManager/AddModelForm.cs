using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HiddenObjectStudio.Core.ResourcesManager;
using System.IO;

namespace HiddenObjectStudio.Core.Forms
{
    public partial class AddModelForm : Form
    {
        public Model _newModel;
        private string _resFileName;
        private bool _hasResFileName = false;

        public AddModelForm(Model model,string resFileName)
        {
            _newModel = model;
            _resFileName = resFileName;

            if (_resFileName != string.Empty) _hasResFileName = true;

            InitializeComponent();

            textBoxModelName.Text = model.ModelName;
            textBoxModelFileName.Text = model.ModelFileName;
            
            if (model.TemporaryTextures == "1")
            {
                checkBoxTempTextures.Checked = true;
            }

            if (!_hasResFileName)
            {
                buttonChooseTexture.Enabled = false;
                textBoxModelFileName.AllowDrop = false;
            }
            else
            {
                buttonChooseTexture.Enabled = true;
                textBoxModelFileName.AllowDrop = true;
            }
        }

        private void ModifyModel()
        {
            _newModel.ModelName = textBoxModelName.Text;
            _newModel.ModelFileName = textBoxModelFileName.Text;

            if (checkBoxTempTextures.Checked)
            {
                _newModel.TemporaryTextures = "1";
            }
            else
            {
                _newModel.TemporaryTextures = "0";
            }

        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            ModifyModel();
            DialogResult = DialogResult.OK;
            Close();
        }


        private void buttonChooseTexture_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();

            fd.Filter =
                "Models (*.MLF)|*.MLF|" +
                "All files (*.*)|*.*";
            fd.Multiselect = false;
            fd.Title = "Select model!";

            DialogResult dr = fd.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                string filePath = fd.FileName;
                textBoxModelFileName.Text = string.Empty;

                if (textBoxModelName.Text == string.Empty)
                {
                    textBoxModelName.Text = Path.GetFileNameWithoutExtension(filePath);
                }
                textBoxModelFileName.Text = Path.GetFileName(Path.GetDirectoryName(filePath)) + "\\" + Path.GetFileName(filePath);
            }

        }

        private string GetModelFileName(string texturePath)
        {
            string value = Tools.GetPathBetweenFilesFolder(_resFileName, texturePath);

            string a = Path.GetFileName(texturePath);

            if (Path.HasExtension(value))
            {
                value = value.Substring(0, value.Length - 4) + "\\" + a;
            }
            else
            {
                value = value + "\\" + a;
            }
            return value;
        }

        private void textBoxModelFileName_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            } 
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void textBoxModelFileName_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                if (files.Length == 1)
                {
                    if (Path.GetExtension(files[0]) == ".mlf")
                    {
                        textBoxModelFileName.Text = string.Empty;
                        textBoxModelFileName.Text = GetModelFileName(files[0]);
                    }
                }
            }
        }
    }
}
