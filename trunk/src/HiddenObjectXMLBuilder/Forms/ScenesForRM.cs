using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Diagnostics;
using Microsoft.Win32;
using HiddenObjectStudio.Core;
using HiddenObjectStudio.Core.LocationManagement;
using HiddenObjectStudio.Core.ResourcesManager;
using HiddenObjectStudio.Core.Forms;

namespace HiddenObjectsXMLBuilder
{
    public partial class ScenesForRM : Form
    {
        private String _path;
        private String _DstRoot;
        private LocationManager Levels;

        private struct _Resources
        {
            public String _path;
            public ListViewItem item;
        }

        private List<_Resources> LevelsResources;

        public ScenesForRM(String path, String _p)
        {
            InitializeComponent();
            _path = path;
            _DstRoot = _p;
            Levels = new LocationManager(_path);
        }


        private void ScenesForRM_Load(object sender, EventArgs e)
        {
            scenesList.CheckBoxes = false;
            scenesList.MultiSelect = false;

            if (File.Exists(_path))
            {
                LevelsResources = new List<_Resources>();
                List<SceneInfo> _Scenes = Levels.AllScenes;

                for (int i = 0; i < _Scenes.Count; i++)
                {
                    ListViewItem item = new ListViewItem();

                    if (_Scenes[i].GddName != "")
                    {
                        item.Text = _Scenes[i].GddName;
                        item.ForeColor = Color.DarkRed;
                    }
                    else
                    {
                        item.Text = "       " + _Scenes[i].Name;
                        item.ForeColor = Color.Blue;
                    }

                    _Resources _tresource;
                    _tresource._path = _DstRoot + "\\" + _Scenes[i].FolderName + "\\" + "resources.xml";
                    _tresource.item = item;

                    LevelsResources.Add(_tresource);

                    scenesList.Items.Add(item);
                }

                scenesList.Items[0].Focused = true;
                scenesList.Items[0].Selected = true;
            }            
        }

        private void scenesList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void openResourceManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.scenesList.SelectedItems.Count == 1)
            {
                ListViewItem logToGet = this.scenesList.SelectedItems[0];

                for (int i = 0; i < LevelsResources.Count; i++)
                {
                    if (LevelsResources[i].item == logToGet)
                    {
                        if (File.Exists(LevelsResources[i]._path))
                        {
                            ResourcesManagerMainForm resourcesManagerMainForm = new ResourcesManagerMainForm(LevelsResources[i]._path);
                            resourcesManagerMainForm.Show();
                        }
                        break;
                    }
                }
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (scenesList.SelectedItems.Count == 0)
                e.Cancel = true;
        }
    }
}
