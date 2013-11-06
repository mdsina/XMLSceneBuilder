using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HiddenObjectStudio.Core;
using System.IO;

namespace WindowsFormsApplication2
{
    public partial class SaveProfileForm : Form
    {
        private string _profileFolderName;
        private string _fullProfileFolderPath;
        Config Config;
        DirectoryInfo _diProfilesFolder;

        public SaveProfileForm(string profileFolderName)
        {
            _profileFolderName = profileFolderName;

            Config = new Config();

            InitializeComponent();

            if (_profileFolderName == String.Empty)
            {
                _profileFolderName = ChangeProfileFolderName();
            }
            else
            {
                _fullProfileFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\EleFun Games\\" + _profileFolderName;
            }

            textBoxProfileFolderName.Text = _profileFolderName;
            Config.ProfileFolderName = _profileFolderName;

            _diProfilesFolder = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "\\Profiles\\");
            LoadSavedProfiles();
        }

        public string ChangeProfileFolderName()
        {
            string gameProfilePlace = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\EleFun Games\\";
            //DirectoryInfo di = new DirectoryInfo(gameProfilePlace);
            
            string folderPath = string.Empty;
            FolderBrowserDialog fbDialog = new FolderBrowserDialog();
            fbDialog.SelectedPath = gameProfilePlace;
            DialogResult dr = fbDialog.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                folderPath = fbDialog.SelectedPath;
                _fullProfileFolderPath = fbDialog.SelectedPath;
            }

            folderPath = folderPath.Substring(folderPath.LastIndexOf('\\')+1);
            return folderPath;
        }

        private void buttonChangeProfileFolder_Click(object sender, EventArgs e)
        {
            _profileFolderName = ChangeProfileFolderName();
            textBoxProfileFolderName.Text = _profileFolderName;
            Config.ProfileFolderName = _profileFolderName;
           
        }

        private void buttonSaveProfile_Click(object sender, EventArgs e)
        {
            if ((textBoxProfileFolderName.Text != string.Empty) && (textBoxSaveProfileWithName.Text != string.Empty))
            {
                
                DirectoryInfo diSourcePathProfile = new DirectoryInfo(_fullProfileFolderPath);

                if (!_diProfilesFolder.Exists)
                {
                    _diProfilesFolder.Create();
                }

                DirectoryInfo diDestPathProfile = new DirectoryInfo(_diProfilesFolder.FullName + textBoxSaveProfileWithName.Text);

                if (diDestPathProfile.Exists)
                {
                    DialogResult dr = MessageBox.Show(diDestPathProfile.Name + " already Exists. Replace?", "Profile already exists!", MessageBoxButtons.OKCancel);
                    if (dr == DialogResult.OK)
                    {
                        Tools.MakeNormalFilesAttribute(diDestPathProfile);
                        diDestPathProfile.Delete(true);
                        diDestPathProfile.Create();
                        Tools.CopyDirectory(diSourcePathProfile, diDestPathProfile);
                        MessageBox.Show("Done!");
                    }
                }
                else
                {
                    diDestPathProfile.Create();

                    Tools.CopyDirectory(diSourcePathProfile, diDestPathProfile);
                    LoadSavedProfiles();
                    MessageBox.Show("Done!");
                }
            }
        }

        private void LoadSavedProfiles()
        {
            listBoxProfiles.Items.Clear();

            DirectoryInfo diProfilesFolder = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "\\Profiles\\");

            foreach (DirectoryInfo diProfile in diProfilesFolder.GetDirectories())
            {
                listBoxProfiles.Items.Add(diProfile);
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            LoadSavedProfiles();
        }
        

        


    }
}
