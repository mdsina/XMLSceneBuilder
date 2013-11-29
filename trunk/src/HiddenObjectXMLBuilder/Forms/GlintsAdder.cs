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

namespace HiddenObjectsXMLBuilder
{
    public partial class GlintsAdder : Form
    {
        private struct GlintList
        {
            public String path;
            public ListViewItem item;
            public String folder;
            public String glintFile;
        }

        List<GlintList> GlintFiles = new List<GlintList>();

        private String __str;
        private String __strDst;
        public String _SelectedScene;
        public String _SelectedFolder;
        public String _SelectedGlint;

        public ListView.SelectedListViewItemCollection _SelectedLayers;

        public GlintsAdder(String _str, String _str2)
        {
            InitializeComponent();
            __str = _str;
            __strDst = _str2;
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        public XmlNode FoundChildNode(string _nodeName, XmlNode _tNode)
        {
            for (int i = 0; i < _tNode.ChildNodes.Count; i++)
            {
                if (_tNode.ChildNodes[i].Name == _nodeName)
                {
                    return _tNode.ChildNodes[i];
                }
            }
            return null;
        }

        private bool FoundParentNode(string _nodeName, XmlNode _tNode)
        {
            for (int i = 0; i < _tNode.ChildNodes.Count; i++)
            {
                if (_tNode.ChildNodes[i].Name == _nodeName)
                {
                    return true;
                }
            }
            return false;
        }

        private void GlintsAdder_Load(object sender, EventArgs e)
        {

            XmlDocument _glintsXmlDoc = new XmlDocument();
            _glintsXmlDoc.Load(__str);
            scenesList.CheckBoxes = false;

            XmlElement _glintsRoot = null, _layersNode_SE = null, _layersNode_CE = null;


            for (int i = 0; i < _glintsXmlDoc.ChildNodes.Count; i++ )
            {
                if (_glintsXmlDoc.ChildNodes[i].Name == "levels")
                {
                    _glintsRoot = (XmlElement)_glintsXmlDoc.ChildNodes[i];
                    break;
                }
            }
            
            if ( _glintsRoot != null)
            {
                _layersNode_SE = (XmlElement)_glintsRoot.FirstChild;
                _layersNode_CE = (XmlElement)_glintsRoot.LastChild;
            }

            if (_layersNode_SE != null)
            {
                for (int i = 0; i < _layersNode_SE.ChildNodes.Count; i++)
                {
                    if (_layersNode_SE.ChildNodes[i].Attributes != null) 
                    {
                        ListViewItem item = new ListViewItem();
                        item.Text = _layersNode_SE.ChildNodes[i].Attributes["gdd_name"].Value;

                        GlintList _list;
                        _list.path = __strDst + "\\" + _layersNode_SE.ChildNodes[i].Attributes["scene_folder"].Value + "\\" + _layersNode_SE.ChildNodes[i].Attributes["scene_file"].Value;
                        _list.item = item;
                        _list.folder = __strDst + "\\" + _layersNode_SE.ChildNodes[i].Attributes["scene_folder"].Value;

                        if (_layersNode_SE.ChildNodes[i].Attributes["glints_file"] != null)
                        {
                            _list.glintFile = __strDst + "\\" + _layersNode_SE.ChildNodes[i].Attributes["scene_folder"].Value + "\\" + _layersNode_SE.ChildNodes[i].Attributes["glints_file"].Value;
                        }
                        else
                            _list.glintFile = "";
                        

                        GlintFiles.Add(_list);
                        scenesList.Items.Add(item);
                    }

                    if (_layersNode_SE.ChildNodes[i].HasChildNodes)
                    {
                            XmlElement _subs = (XmlElement)FoundChildNode("subscreens", _layersNode_SE.ChildNodes[i]);

                            if (_subs != null)
                            {
                                if (_subs.HasChildNodes)
                                {
                                    for (int k = 0; k < _subs.ChildNodes.Count; k++)
                                    {
                                        if (_subs.ChildNodes[k].Attributes != null)
                                        {
                                            ListViewItem item = new ListViewItem();
                                            item.Text = _subs.ChildNodes[k].Name;

                                            GlintList _list;
                                            _list.path = __strDst + "\\" + _subs.ChildNodes[k].Attributes["scene_folder"].Value + "\\" + _subs.ChildNodes[k].Attributes["scene_file"].Value;
                                            _list.item = item;
                                            _list.folder = __strDst + "\\" + _subs.ChildNodes[k].Attributes["scene_folder"].Value;
                                            if (_subs.ChildNodes[k].Attributes["glints_file"] != null)
                                            {
                                                _list.glintFile = __strDst + "\\" + _subs.ChildNodes[k].Attributes["scene_folder"].Value + "\\" + _subs.ChildNodes[k].Attributes["glints_file"].Value;
                                            }
                                            else
                                                _list.glintFile = "";
                                            GlintFiles.Add(_list);
                                            scenesList.Items.Add(item);
                                        }
                                    }
                                }
                            
                            
                        }
                    }
                        
                }
            }

            if (_layersNode_CE != null)
            {
                for (int i = 0; i < _layersNode_CE.ChildNodes.Count; i++)
                {
                    if (_layersNode_CE.ChildNodes[i].Attributes != null)
                    {
                        ListViewItem item = new ListViewItem();
                        item.Text = _layersNode_CE.ChildNodes[i].Attributes["gdd_name"].Value;

                        GlintList _list;
                        _list.path = __strDst + "\\" + _layersNode_CE.ChildNodes[i].Attributes["scene_folder"].Value + "\\" + _layersNode_CE.ChildNodes[i].Attributes["scene_file"].Value;
                        _list.item = item;
                        _list.folder = __strDst + "\\" + _layersNode_CE.ChildNodes[i].Attributes["scene_folder"].Value;
                        if (_layersNode_CE.ChildNodes[i].Attributes["glints_file"] != null)
                        {
                            _list.glintFile = __strDst + "\\" + _layersNode_CE.ChildNodes[i].Attributes["scene_folder"].Value + "\\" + _layersNode_CE.ChildNodes[i].Attributes["glints_file"].Value;
                        }
                        else
                            _list.glintFile = "";
                        GlintFiles.Add(_list);
                        scenesList.Items.Add(item);
                    }


                    if (_layersNode_CE.ChildNodes[i].HasChildNodes)
                    {
                            XmlElement _subs = (XmlElement)FoundChildNode("subscreens", _layersNode_CE.ChildNodes[i]);
                            
                            if (_subs != null)
                            {
                                if (_subs.HasChildNodes)
                                {
                                    for (int k = 0; k < _subs.ChildNodes.Count; k++)
                                    {
                                        if (_subs.ChildNodes[k].Attributes != null)
                                        {
                                            ListViewItem item = new ListViewItem();
                                            item.Text = _subs.ChildNodes[k].Name;

                                            GlintList _list;
                                            _list.path = __strDst + "\\" + _subs.ChildNodes[k].Attributes["scene_folder"].Value + "\\" + _subs.ChildNodes[k].Attributes["scene_file"].Value;
                                            _list.item = item;
                                            _list.folder = __strDst + "\\" + _subs.ChildNodes[k].Attributes["scene_folder"].Value;
                                            if (_subs.ChildNodes[k].Attributes["glints_file"] != null)
                                            {
                                                _list.glintFile = __strDst + "\\" + _subs.ChildNodes[k].Attributes["scene_folder"].Value + "\\" + _subs.ChildNodes[k].Attributes["glints_file"].Value;
                                            }
                                            else
                                                _list.glintFile = "";
                                            GlintFiles.Add(_list);
                                            scenesList.Items.Add(item);
                                        }
                                    }
                                }
                            }
                        
                    }

                }
            }
            scenesList.Sort();

            scenesList.Items[0].Focused = true;
            scenesList.Items[0].Selected = true;
        }

        private void scenesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            layersList.Items.Clear();
            layersList.CheckBoxes = false;
            _SelectedLayers = null;
            _SelectedScene = "";
            _SelectedFolder = "";
            _SelectedGlint = "";

            XmlDocument _glintsXmlDoc;
		    XmlElement _glintsRoot;

            _glintsXmlDoc = new XmlDocument();

            if (this.scenesList.SelectedItems.Count == 1)
            {
                ListViewItem logToGet = this.scenesList.SelectedItems[0];

                for (int i = 0; i < GlintFiles.Count; i++)
                {
                    if (GlintFiles[i].item == logToGet)
                    {
                        _SelectedScene = GlintFiles[i].path;
                        _SelectedFolder = GlintFiles[i].folder;
                        _SelectedGlint = GlintFiles[i].glintFile;
                    }
                }

                _glintsXmlDoc.Load(_SelectedScene);

                _glintsRoot = (XmlElement)_glintsXmlDoc.DocumentElement;


                XmlElement _layersNode = (XmlElement)FoundChildNode("layers", _glintsRoot);

                if (_layersNode != null)
                    for (int j = 0; j < _layersNode.ChildNodes.Count; j++)
                    {
                        ListViewItem item = new ListViewItem();
                        item.Text = _layersNode.ChildNodes[j].Name;
                        layersList.Items.Add(item);
                    }

            }
            else
            {
                _SelectedScene = "";
                _SelectedFolder = "";
                _SelectedGlint = "";
            }
        }

        private void layersList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.layersList.SelectedItems.Count != 0)
            {
                _SelectedLayers = this.layersList.SelectedItems;
            }
            else
                _SelectedLayers = null;
        }

        private void AddGlintButton_Click(object sender, EventArgs e)
        {
            if ((_SelectedFolder != "") && (_SelectedLayers != null))
            {
                BuildOptions _options = new BuildOptions();
                _options.dstFolder = _SelectedFolder;
                Glints _glint = new Glints(_options, "", _SelectedGlint);

                for (int i = 0; i < _SelectedLayers.Count; i++)
                {
                    _glint.AddGlint(_SelectedLayers[i].Text);
                        
                }

                _glint.Save();

                MessageBox.Show("Selected Glints successfully added");
            }
        }
    }
}
