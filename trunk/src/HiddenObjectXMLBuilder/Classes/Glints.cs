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
        XmlComment newComment;

		private BuilderConfig _builderConfig;
		private BuildOptions _buildOptions;


		public Glints(BuilderConfig builderConfig, BuildOptions buildOptions)
		{
            _builderConfig = builderConfig;
            _buildOptions = buildOptions;
			_glintsFileName = _buildOptions.dstFolder + "\\glints.xml";

			_glintsXmlDoc = new XmlDocument();
            

            _glintsRoot = _glintsXmlDoc.CreateElement("glints");
            newComment = _glintsXmlDoc.CreateComment("Add your glints here");


		}

		public void Save()
		{
            _glintsRoot.AppendChild(newComment);
			_glintsXmlDoc.AppendChild(_glintsRoot);
			_glintsXmlDoc.Save(_glintsFileName);
		}
    }
}
