using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.Xml;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace HiddenObjectStudio.Core
{
	public class Tools
	{
		public static Point ParsePoint(string input)
		{
			string [] xy = input.Split(' ');

			if (xy.Length != 2)
					throw new ArgumentException("Please specify two integers separated with space.");

			return new Point(Convert.ToInt32(xy[0]), Convert.ToInt32(xy[1]));
		}

		public static Size ParseSize(string input)
		{
			string[] xy = input.Split(' ');

			if (xy.Length != 2)
				throw new ArgumentException("Please specify two integers separated with space.");

			return new Size(Convert.ToInt32(xy[0]), Convert.ToInt32(xy[1]));
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

        public static string GetFolderByInputFolderAndPath(string startDiPath, string pathBetweenFolders)
        {
            string folderPath = string.Empty;
            
            if (startDiPath != string.Empty)
            {
                startDiPath = GetLastFolderNameFromPath(startDiPath);

                string startDiPathRoot = Path.GetPathRoot(startDiPath);

                string[] pathParts = pathBetweenFolders.Split(Path.DirectorySeparatorChar);

                for (int i = 0; i < pathParts.Length; i++)
                {
                    if (pathParts[i] == "..")
                    {
                        startDiPath = GetLastFolderNameFromPath(startDiPath);
                    }
                    else
                    {
                        startDiPath += "\\" + pathParts[i];
                    }
                    
                }
                folderPath = startDiPath + ".png";
            }

            return folderPath;
        }

        public static string GetPathBetweenFilesFolder(string startDiPath, string finalDiPath)
        {
            string outPath = string.Empty;
            if ((startDiPath != string.Empty) && (finalDiPath != string.Empty))
            {

                string startDiPathRoot = Path.GetPathRoot(startDiPath);
                string finalDiPathRoot = Path.GetPathRoot(finalDiPath);

                string bothPath;

                string[] firstMass = null;

                if (startDiPathRoot.ToLower() == finalDiPathRoot.ToLower())
                {
                    bothPath = CompareStringsInTxtFile(startDiPath, finalDiPath);

                    string cutFirst = startDiPath.Replace(bothPath, "");
                    string cutFinal = finalDiPath.Replace(bothPath, "");

                    if (cutFirst != string.Empty)
                    {
                        if (Path.HasExtension(cutFirst))
                        {
                            cutFirst = GetLastFolderNameFromPath(cutFirst);
                        }
                        if (cutFirst != string.Empty)
                        {
                            if (cutFirst[0] == '\\')
                            {
                                cutFirst = cutFirst.Remove(0, 1);
                            }
                            firstMass = cutFirst.Split('\\');
                        }

                    }
                    if (cutFinal != string.Empty)
                    {
                        if (Path.HasExtension(cutFinal))
                        {
                            cutFinal = GetLastFolderNameFromPath(cutFinal);
                        }
                        if (cutFinal != string.Empty)
                        {
                            if (cutFinal[0] == '\\')
                            {
                                cutFinal = cutFinal.Remove(0, 1);
                            }
                        }
                    }

                    if (firstMass != null)
                    {
                        for (int i = 0; i < firstMass.Length; i++)
                        {
                            outPath = outPath + "..\\";
                        }
                    }
                    if (cutFinal != string.Empty)
                    {
                        outPath = outPath + cutFinal;
                    }
                }
                else
                {
                    MessageBox.Show("Files must locate on one disk");
                }
            }
            return outPath;
        }

        

        public static string CompareStringsInTxtFile(string filePathFirst, string filePathSecond)
        {
            string folderName = string.Empty;
            int index = 0;

            int minStrLength = 0;

            if (filePathFirst.Length < filePathSecond.Length)
            {
                minStrLength = filePathFirst.Length;
                folderName = filePathFirst;
            }
            else
            {
                minStrLength = filePathSecond.Length;
                folderName = filePathSecond;
            }

            do
            {
                char notCompareChare = filePathFirst[index];

                if (filePathSecond[index] != notCompareChare)
                {
                    string q = filePathSecond.Substring(0, index);
                    folderName = GetLastFolderNameFromPath(q);
                    return folderName;
                }

                index++;
            } while (index < minStrLength);

            return folderName;
        }

        public static string GetLastFolderNameFromPath(string str)
        {
            string folderName = string.Empty;

            folderName = str.Substring(0, str.LastIndexOf('\\'));

            return folderName;
        }

        public static Bitmap ResizeBitmap(Bitmap b, int nWidth, int nHeight)
        {
            Bitmap result = new Bitmap(nWidth, nHeight);
            using (Graphics g = Graphics.FromImage((Image)result))
                g.DrawImage(b, 0, 0, nWidth, nHeight);
            return result;
        }

		static public void CleanDirectory(string directoryName)
		{
			if (!Directory.Exists(directoryName)) return;

			DirectoryInfo di = new DirectoryInfo(directoryName);
			if (di.Name.ToLower() == ".svn") return;

			string[] files = Directory.GetFiles(directoryName);
			for (int i = 0; i < files.Length; ++i)
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

		static public string FilterBrackets(string str)
		{
			return str.Replace('(', '_').Replace(')', '_');
		}

		static public string AppendSlashIfNeeded(string str)
		{
			if (str[str.Length - 1] == '\\') return str;

			return str + '\\';

		}
			
		public static string Translit(string str)
		{
			StringBuilder res = new StringBuilder();

			foreach (char c in str)
			{
				switch (c)
				{
					case 'а': res.Append('a'); break;
					case 'А': res.Append('A'); break;
					case 'б': res.Append('b'); break;
					case 'Б': res.Append('B'); break;
					case 'в': res.Append('v'); break;
					case 'В': res.Append('V'); break;
					case 'г': res.Append('g'); break;
					case 'Г': res.Append('G'); break;
					case 'д': res.Append('d'); break;
					case 'Д': res.Append('D'); break;
					case 'е': res.Append('e'); break;
					case 'Е': res.Append('E'); break;
					case 'ё': res.Append('e'); break;
					case 'Ё': res.Append('E'); break;
					case 'ж': res.Append("zh"); break;
					case 'Ж': res.Append("ZH"); break;
					case 'з': res.Append('z'); break;
					case 'З': res.Append('Z'); break;
					case 'и': res.Append('i'); break;
					case 'И': res.Append('I'); break;
					case 'й': res.Append('y'); break;
					case 'Й': res.Append('Y'); break;
					case 'к': res.Append('k'); break;
					case 'К': res.Append('K'); break;
					case 'л': res.Append('l'); break;
					case 'Л': res.Append('L'); break;
					case 'м': res.Append('m'); break;
					case 'М': res.Append('M'); break;
					case 'н': res.Append('n'); break;
					case 'Н': res.Append('N'); break;
					case 'о': res.Append('o'); break;
					case 'О': res.Append('O'); break;
					case 'п': res.Append('p'); break;
					case 'П': res.Append('P'); break;
					case 'р': res.Append('r'); break;
					case 'Р': res.Append('R'); break;
					case 'с': res.Append('s'); break;
					case 'С': res.Append('S'); break;
					case 'т': res.Append('t'); break;
					case 'Т': res.Append('T'); break;
					case 'у': res.Append('u'); break;
					case 'У': res.Append('U'); break;
					case 'ф': res.Append('f'); break;
					case 'Ф': res.Append('F'); break;
					case 'х': res.Append('h'); break;
					case 'Х': res.Append('H'); break;
					case 'ц': res.Append("ts"); break;
					case 'Ц': res.Append("TS"); break;
					case 'ч': res.Append("ch"); break;
					case 'Ч': res.Append("CH"); break;
					case 'ш': res.Append("sh"); break;
					case 'Ш': res.Append("SH"); break;
					case 'щ': res.Append("sch"); break;
					case 'Щ': res.Append("SCH"); break;
					case 'ъ': break;
					case 'Ъ': break;
					case 'ы': res.Append('y'); break;
					case 'Ы': res.Append('Y'); break;
					case 'ь': break;
					case 'Ь': break;
					case 'э': res.Append('e'); break;
					case 'Э': res.Append('E'); break;
					case 'ю': res.Append("yu"); break;
					case 'Ю': res.Append("YU"); break;
					case 'я': res.Append("ya"); break;
					case 'Я': res.Append("YA"); break;
					default: res.Append(c); break;
				}
			}

			return res.ToString();
		}

		public static string TrimHeadAndTailQuots(string str)
		{
			char[] chars = { ' ', '"' };

			return str.Trim(chars);
		}

        
	}
}
