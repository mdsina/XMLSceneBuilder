using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Reflection;

namespace HiddenObjectStudio.Core
{
	public class Config
	{
		private static string ConfigFileName = "HiddenObjectStudio.Config";
		//public static string ProjectPath = @"d:\Projects\Fear For Sale 2";
		//public static string ProjectPath = @"d:\Projects\Kari Anderson";

#region Private vars and props
		private XmlDocument _configDoc;
		private string _configFileName;

		private bool IsConfigFileExist;
#endregion

#region Private methods
		private string GetParameterFromConfigFile(string paramName, string defaultValue)
		{
			XmlElement node = (XmlElement)_configDoc.DocumentElement.SelectSingleNode(paramName);

			if (node != null)
			{
				return node.GetAttribute("value");
			}
			else
			{
				return defaultValue;
			}
		}

        private void SetParameterToConfigFile(string paramName, string newValue)
        {
            if (IsConfigFileExist)
            {
                _configDoc = new XmlDocument();
                _configDoc.Load(_configFileName);
            }
            else
            {
                _configDoc = new XmlDocument();
                _configDoc.AppendChild(_configDoc.CreateElement("Config"));
            }

            XmlElement node = (XmlElement)_configDoc.DocumentElement.SelectSingleNode(paramName);

            if (node != null)
            {
                node.SetAttribute("value", newValue);
            }
            else
            {
                XmlElement newNode = _configDoc.CreateElement(paramName);
                newNode.SetAttribute("value", newValue);
                _configDoc.DocumentElement.AppendChild(newNode);
            }

            _configDoc.Save(_configFileName);
        }

#endregion
		
#region Public properties

		public string ProjectPath
		{
			get
			{
				string defaultValue = AppDomain.CurrentDomain.BaseDirectory;

				if (IsConfigFileExist)
				{
					return GetParameterFromConfigFile(MethodBase.GetCurrentMethod().Name.Substring(4), defaultValue);
				}
				else
				{
					return defaultValue;
				}
			}
		}

		public string BinPath
		{
			get
			{
				string defaultValue = ProjectPath;

				if (IsConfigFileExist)
				{
					return GetParameterFromConfigFile(MethodBase.GetCurrentMethod().Name.Substring(4), defaultValue);
				}
				else
				{
					return defaultValue;
				}
				
			}
		}

		public string DataPath
		{ 
			get 
			{ 
				string defaultValue = BinPath + @"\data";

				if (IsConfigFileExist)
				{
					return GetParameterFromConfigFile(MethodBase.GetCurrentMethod().Name.Substring(4), defaultValue);
				}
				else
				{
					return defaultValue;
				}
			} 
		}

		public string LevelsPath
		{
			get
			{
				string defaultValue = DataPath + @"\levels";

				if (IsConfigFileExist)
				{
					return GetParameterFromConfigFile(MethodBase.GetCurrentMethod().Name.Substring(4), defaultValue);
				}
				else
				{
					return defaultValue;
				}
			}
		}

		public string TextsPath
		{
			get
			{
				string defaultValue = DataPath + @"\texts";

				if (IsConfigFileExist)
				{
					return GetParameterFromConfigFile(MethodBase.GetCurrentMethod().Name.Substring(4), defaultValue);
				}
				else
				{
					return defaultValue;
				}
			}
		}

		public string InventoryPath
		{
			get
			{
				string defaultValue = DataPath + @"\inventory";

				if (IsConfigFileExist)
				{
					return GetParameterFromConfigFile(MethodBase.GetCurrentMethod().Name.Substring(4), defaultValue);
				}
				else
				{
					return defaultValue;
				}				

			}
		}

		public string DiaryPath
		{
			get
			{
				string defaultValue = DataPath + @"\diary";

				if (IsConfigFileExist)
				{
					return GetParameterFromConfigFile(MethodBase.GetCurrentMethod().Name.Substring(4), defaultValue);
				}
				else
				{
					return defaultValue;
				}
			}
		}

		public string ScenesPath
		{
			get
			{
				string defaultValue = DataPath + @"\scenes";

				if (IsConfigFileExist)
				{
					return GetParameterFromConfigFile(MethodBase.GetCurrentMethod().Name.Substring(4), defaultValue);
				}
				else
				{
					return defaultValue;
				}
			}
		}

		public string QuestsPath
		{
			get
			{
				string defaultValue = DataPath + @"\hint_system";

				if (IsConfigFileExist)
				{
					return GetParameterFromConfigFile(MethodBase.GetCurrentMethod().Name.Substring(4), defaultValue);
				}
				else
				{
					return defaultValue;
				}
			}
		}

		public string SkipMenusFileName
		{
			get
			{
				string defaultValue = @"skip_menus.txt";

				if (IsConfigFileExist)
				{
					return GetParameterFromConfigFile(MethodBase.GetCurrentMethod().Name.Substring(4), defaultValue);
				}
				else
				{
					return defaultValue;
				}
			}
		}

		public string SkipMenusFileLocation
		{
			get
			{
				string defaultValue = DataPath + @"\ui";

				if (IsConfigFileExist)
				{
					return GetParameterFromConfigFile(MethodBase.GetCurrentMethod().Name.Substring(4), defaultValue);
				}
				else
				{
					return defaultValue;
				}
			}
		}

        public string ExecutableFileName
        {
            get
            {
                string defaultValue = string.Empty;

                if (IsConfigFileExist)
                {
                    return GetParameterFromConfigFile(MethodBase.GetCurrentMethod().Name.Substring(4), defaultValue);
                }
                else
                {
                    return defaultValue;
                }
            }
            set
            {
                SetParameterToConfigFile(MethodBase.GetCurrentMethod().Name.Substring(4), value);
            }
        }

		public string BookmarksPath
		{
			get 
			{
				return string.Empty;
			}

			set
			{
			}
		}

#endregion


		public Config()
		{
			_configFileName = AppDomain.CurrentDomain.BaseDirectory + ConfigFileName;

			IsConfigFileExist = File.Exists(_configFileName);

			if (IsConfigFileExist)
			{
				_configDoc = new XmlDocument();
				_configDoc.Load(_configFileName);
			}
		}
	}
}
