using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using Microsoft.Win32;

namespace HiddenObjectsXMLBuilder
{
	class Tool
	{
		static public void CleanDirectory(string directoryName)
		{
			if (!Directory.Exists(directoryName)) return;

			DirectoryInfo di = new DirectoryInfo(directoryName);
			if (di.Name.ToLower() == ".svn") return;

			string [] files = Directory.GetFiles(directoryName);
			for(int i = 0; i < files.Length; ++i)
			{
				File.Delete(files[i]);
			}

			string[] subDirictories = Directory.GetDirectories(directoryName);
			for (int i = 0; i < subDirictories.Length; ++i)
			{
				CleanDirectory(subDirictories[i]);
			}

		}

		static public string CutDigitsFromHead(string str)
		{
			int index = str.IndexOf('_');

			if (index > 0)
			{
				try
				{
					string strDigits = str.Substring(0, index);
					int tmp = Convert.ToInt32(strDigits);
				}
				catch (Exception)
				{
					return str;
				}

				return str.Substring(index + 1);
			}

			return str;

		}

		static public string CutDigitsFromTail(string str)
		{
			int index = str.LastIndexOf('_');

			if (index > 0)
			{
				try
				{
					string strDigits = str.Substring(index + 1);
					int tmp = Convert.ToInt32(strDigits);
				}
				catch (Exception)
				{
					return str;
				}

				return str.Substring(0, index);
			}

			return str;
		}

		static public string FilterString(string str)
		{
			return str.Replace(' ', '_').Replace('\'', '-').Replace('!', '_').Replace("'", "_").Replace('+', '_');
		}

		static public string AppendSlashIfNeeded(string str)
		{
			if (str[str.Length - 1] == '\\') return str;

			return str + '\\';

		}


		public static string GetParameterFromXml(XmlNode xmlNode, string attributeName, string defaultValue)
		{
			if (xmlNode.Attributes[attributeName] == null)
				return defaultValue;

			return xmlNode.Attributes[attributeName].Value.ToString();
		}

		public static int GetParameterFromXml(XmlNode xmlNode, string attributeName, int defaultValue)
		{
			if (xmlNode.Attributes[attributeName] == null)
				return defaultValue;

			return Convert.ToInt32(xmlNode.Attributes[attributeName].Value);
		}

		public static bool GetParameterFromXml(XmlNode xmlNode, string attributeName, bool defaultValue)
		{
			if (xmlNode.Attributes[attributeName] == null)
				return defaultValue;

			return Convert.ToBoolean(xmlNode.Attributes[attributeName].Value);
		}

		public static string GetParameterFromReg(RegistryKey key, string name, string defaultValue)
		{
			if (key == null) return defaultValue;

			if (key.GetValue(name) != null)
				return key.GetValue(name).ToString();
			else
				return defaultValue;
		}

		public static int GetParameterFromReg(RegistryKey key, string name, int defaultValue)
		{
			if (key == null) return defaultValue;

			if (key.GetValue(name) != null)
				return Convert.ToInt32(key.GetValue(name));
			else
				return defaultValue;
		}

		public static bool GetParameterFromReg(RegistryKey key, string name, bool defaultValue)
		{
			if (key == null) return defaultValue;

			if (key.GetValue(name) != null)
				return Convert.ToBoolean(key.GetValue(name));
			else
				return defaultValue;
		}

		public static void SetParameterToReg(RegistryKey key, string name, string value)
		{
			key.SetValue(name, value);
		}

		public static void SetParameterToReg(RegistryKey key, string name, int value)
		{
			key.SetValue(name, value);
		}

		public static void SetParameterToReg(RegistryKey key, string name, bool value)
		{
			key.SetValue(name, value);
		}

		public static string GetRelativeFileName(string baseFileName, string fileName)
		{
			string basePath = Path.GetDirectoryName(baseFileName);

			if (!fileName.ToUpper().StartsWith(basePath.ToUpper())) return fileName;

			return fileName.Remove(0, basePath.Length + 1);
		}
		

	}
}
