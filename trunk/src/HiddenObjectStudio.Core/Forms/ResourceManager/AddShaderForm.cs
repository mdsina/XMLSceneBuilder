using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using HiddenObjectStudio.Core.ResourcesManager;
using System.IO;

namespace HiddenObjectStudio.Core.Forms
{
    public partial class AddShaderForm : Form
    {
        public Shader _newShader;
        private string _resFileName;
        private bool _hasResFileName = false;

        public AddShaderForm(Shader shader, string resFileName)
        {
            _newShader = shader;
            _resFileName = resFileName;

            if (_resFileName != string.Empty) _hasResFileName = true;
            
            InitializeComponent();

            textBoxShaderName.Text = shader.ShaderName;
            textBoxTextureName.Text = shader.TextureName;
            textBoxFrameCount.Text = shader.FrameCount;

            if (shader.MipMap == "1")
            {
                checkBoxMipMap.Checked = true;
            }

            if (shader.TemporaryTextures == "1")
            {
                checkBoxTempTextures.Checked = true;
            }

            if (!_hasResFileName)
            {
                buttonChooseTexture.Enabled = false;
                textBoxTextureName.AllowDrop = false;
            }
            else
            {
                buttonChooseTexture.Enabled = true;
                textBoxTextureName.AllowDrop = true;
            }
        }

        private void ModifyShader()
        {
            _newShader.ShaderName = textBoxShaderName.Text;
            _newShader.TextureName = textBoxTextureName.Text;

            if (checkBoxMipMap.Checked)
            {
                _newShader.MipMap = "1";
            }
            else
            {
                _newShader.MipMap = "0";
            }

            if (checkBoxTempTextures.Checked)
            {
                _newShader.TemporaryTextures = "1";
            }
            else
            {
                _newShader.TemporaryTextures = "0";
            }

        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            ModifyShader();
         //  Shaders.Add(newShader);
        }

        private void textBoxTextureName_DragEnter(object sender, DragEventArgs e)
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

        private void textBoxTextureName_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                if (files.Length == 1)
                {
                    if (Path.GetExtension(files[0]) == ".png")
                    {
                        textBoxTextureName.Text = string.Empty;
                        textBoxTextureName.Text = GetTextureFileName(files[0]);
                    }
                }
            }
        }


        

        private void buttonChooseTexture_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            
            fd.Filter =
                "Images (*.PNG)|*.PNG|"+
                "All files (*.*)|*.*";
            fd.Multiselect = false;
            fd.Title = "Select picture!";

            if (fd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filePath = fd.FileName;
                    textBoxTextureName.Text = string.Empty;

                    if (textBoxShaderName.Text == string.Empty)
                    {
                        textBoxShaderName.Text = Path.GetFileNameWithoutExtension(filePath);
                    }
                    textBoxTextureName.Text = Path.GetFileName(Path.GetDirectoryName(filePath)) + "\\" + Path.GetFileNameWithoutExtension(filePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
            
        }

        private string GetTextureFileName(string texturePath)
        {
            string value = Tools.GetPathBetweenFilesFolder(_resFileName, texturePath);

            string a = Path.GetFileNameWithoutExtension(texturePath);

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

        

       
    }
}
