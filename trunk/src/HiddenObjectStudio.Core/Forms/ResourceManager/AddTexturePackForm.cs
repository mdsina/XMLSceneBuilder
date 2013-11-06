using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HiddenObjectStudio.Core.ResourcesManager;
using System.IO;
using HiddenObjectStudio.Core;

namespace HiddenObjectStudio.Core.Forms
{
    public partial class AddTexturePackForm : Form
    {
        private TexturePack _newTexturePack;
        private string _resFilePath;

        public AddTexturePackForm(TexturePack texturePack, string resFilePath)
        {
            _newTexturePack = texturePack;
            _resFilePath = resFilePath;

            InitializeComponent();

            textBoxTexturePackName.Text = texturePack.TexturePackName;
            textBoxTexturePackFileName.Text = texturePack.TexturePackFileName;
        }

        private void ModifyTexturePack()
        {
            _newTexturePack.TexturePackName = textBoxTexturePackName.Text;
            _newTexturePack.TexturePackFileName = textBoxTexturePackFileName.Text;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if ((textBoxTexturePackName.Text != string.Empty) && (textBoxTexturePackFileName.Text != string.Empty))
            {
                ModifyTexturePack();
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Please fill all fields!");
            }
            
        }

        private void textBoxTexturePackFileName_DragEnter(object sender, DragEventArgs e)
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

        private void textBoxTexturePackFileName_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                foreach (string file in files)
                {
                    FileInfo fileInfo = new FileInfo(file);

                    if (files.Length > 1)
                    {
                        MessageBox.Show("Error! Can't attach more than one files", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else if (files.Length == 1)
                    {
                        if (fileInfo.Extension.ToLower() == ".tpf") 
                        {
                            string valueToXML = Tools.GetPathBetweenFilesFolder(_resFilePath, file) + "\\" + Path.GetFileName(file);

                            textBoxTexturePackFileName.Text = valueToXML;
                        }
                    }
                }
            }
        }

        private string GetFileExtansion(string str)
        {
            str = str.Substring(str.LastIndexOf('.') + 1, 3);

            return str;
        }

        
    }
}
