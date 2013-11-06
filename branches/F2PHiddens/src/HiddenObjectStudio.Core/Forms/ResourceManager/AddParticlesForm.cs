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
    public partial class AddParticlesForm : Form
    {
        public Particles _newParticles;
        private string _resFileName;
        private bool _hasResFileName = false;

        public AddParticlesForm(Particles particles, string resFileName)
        {
            _newParticles = particles;
            _resFileName = resFileName;

            InitializeComponent();

            if (_resFileName != string.Empty) _hasResFileName = true;

            textBoxParticlesName.Text = particles.ParticlesName;
            textBoxParticlesFileName.Text = particles.ParticlesFileName;

            if (particles.TemporaryTextures == "1")
            {
                checkBoxTempTextures.Checked = true;
            }

            if (!_hasResFileName)
            {
                buttonChooseTexture.Enabled = false;
                textBoxParticlesFileName.AllowDrop = false;
            }
            else
            {
                buttonChooseTexture.Enabled = true;
                textBoxParticlesFileName.AllowDrop = true;
            }
        }

        private void ModifyParticles()
        {
            _newParticles.ParticlesName = textBoxParticlesName.Text;
            _newParticles.ParticlesFileName = textBoxParticlesFileName.Text;

            if (checkBoxTempTextures.Checked)
            {
                _newParticles.TemporaryTextures = "1";
            }
            else
            {
                _newParticles.TemporaryTextures = "0";
            }

        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            ModifyParticles();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonChooseTexture_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();

            fd.Filter =
                "Particles (*.psf)|*.psf|" +
                "All files (*.*)|*.*";
            fd.Multiselect = false;
            fd.Title = "Select particles!";

            DialogResult dr = fd.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                string filePath = fd.FileName;
                textBoxParticlesFileName.Text = string.Empty;
                textBoxParticlesFileName.Text = GetParticlesFileName(filePath);
            }
        }

        private string GetParticlesFileName(string texturePath)
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

        private void textBoxParticlesFileName_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                if (files.Length == 1)
                {
                    if (Path.GetExtension(files[0]) == ".psf")
                    {
                        textBoxParticlesFileName.Text = string.Empty;
                        textBoxParticlesFileName.Text = GetParticlesFileName(files[0]);
                    }
                }
            }
        }

        private void textBoxParticlesFileName_DragEnter(object sender, DragEventArgs e)
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
    }
}
