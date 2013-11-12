using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.IO;
using HiddenObjectStudio.Core;

namespace HiddenObjectsXMLBuilder
{
    class Navigation
    {
        XmlDocument NavigationsXML;
        XmlDocument QuestsXML;

        private BuilderConfig _builderConfig;
		private BuildOptions _buildOptions;

        public Navigation(BuilderConfig builderConfig, BuildOptions buildOptions)
		{
			_builderConfig = builderConfig;
			_buildOptions = buildOptions;

            NavigationsXML = new XmlDocument();
            QuestsXML = new XmlDocument();

            string _NavFileName = null;
            string _QuestsFileName = null;

            if (_buildOptions.rebuildNavigation)

            if (_buildOptions.sceneName.Contains("ce_"))
            {
                _NavFileName = "\\navigation_ce.xml";

                if (File.Exists(_buildOptions.navigationFilePath + _NavFileName))
                    NavigationsXML.Load(_buildOptions.navigationFilePath + _NavFileName);
                else
                {
                    _NavFileName = "\\navigation.xml";
                    if (File.Exists(_buildOptions.navigationFilePath + _NavFileName))
                        NavigationsXML.Load(_buildOptions.navigationFilePath + _NavFileName);
                    else
                        _NavFileName = null;
                }


                _QuestsFileName = "\\quest_ce.xml";


                QuestsXML.Load();

            } 
            else 
            {
                _NavFileName = "\\navigation.xml";
                _QuestsFileName = "\\quest_ce.xml";
            }

        }
    }
}
