using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using HiddenObjectStudio.Core;

namespace HiddenObjectsXMLBuilder
{
    class Glints
    {
        private XmlDocument _glintsXmlDoc;
		private XmlElement _glintsRoot;
		private string _glintsFileName;

		private BuilderConfig _builderConfig;
		private BuildOptions _buildOptions;


		public Glints(BuilderConfig builderConfig, BuildOptions buildOptions, string glintNumber)
		{
            _builderConfig = builderConfig;
            _buildOptions = buildOptions;
            _glintsFileName = _buildOptions.dstFolder + "\\glints" + glintNumber + ".xml";

            if (!File.Exists(_glintsFileName))
            {
                _glintsXmlDoc = new XmlDocument();
                _glintsRoot = _glintsXmlDoc.CreateElement("glints");
            }
            else
            {
                _glintsXmlDoc = new XmlDocument();
                _glintsXmlDoc.Load(_glintsFileName);

                for (int i = 0; i < _glintsXmlDoc.ChildNodes.Count; i++ )
                {
                    if (_glintsXmlDoc.ChildNodes[i].Name == "glints")
                    {
                        _glintsRoot = (XmlElement)_glintsXmlDoc.ChildNodes[i];
                        break;
                    }
                }
            }
		}

        public void AddGlint(string LayerName)
        {
            bool _ok = false;
            for (int i = 0; i < _glintsRoot.ChildNodes.Count; i++  )
            {
                if (_glintsRoot.ChildNodes[i].Name == LayerName)
                {
                    _ok = true;
                    break;
                }
            }

            if (!_ok)
            {
                XmlElement _LayerName = _glintsXmlDoc.CreateElement(LayerName);
                _LayerName.SetAttribute("layer", LayerName);
                _glintsRoot.AppendChild(_LayerName);
            }
            
        }

		public void Save()
		{
            
			_glintsXmlDoc.AppendChild(_glintsRoot);
			_glintsXmlDoc.Save(_glintsFileName);
		}
    }
}
