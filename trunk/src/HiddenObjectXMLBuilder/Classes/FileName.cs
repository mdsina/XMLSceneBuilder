using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using HiddenObjectStudio.Core;

namespace HiddenObjectsXMLBuilder
{
	enum WidePart
	{
		LeftPart,
		CenterPart,
		RightPart
	}

	class FileName
	{
		private string _fileName;

		public FileName(string fileName)
		{
			_fileName = fileName;
		}

		public string TextureName
		{
			get
			{
				if (IsStatic || IsBackground || IsActiveZone || IsDropZone)
				{
                    string textureName;
					textureName = Tools.CutDigitsFromHead(Tools.FilterString(TranslitName()));

                    if (textureName.LastIndexOf("_g")!=-1)
                    {
                       textureName = textureName.Remove(textureName.LastIndexOf("_g"));
                    }
                    if (DisableAlphaSelection)
                    {
                       return textureName.Replace("_das_", null);
                    }

                    return textureName;
				}
				else
				{
					return EnglishName;
				}
			}
		}

		public string NodeName
		{
			get 
			{
				string nodeName	= Tools.FilterBrackets(Tools.FilterString(TextureName).Replace(".", "_").Replace("-", "_"));
 
				if (char.IsNumber(TextureName[0]))
				{
					return "_" + nodeName;
				}
				else
				{
					return nodeName;
				}
				
				//MessageBox.Show("Имя XML ноды '" + Tool.FilterString(TextureName) + "' начинается на цифру - это не допустимо!", "Ошибонька!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public string GetWideNodeName(WidePart widePart)
		{
			switch (widePart)
			{
                case WidePart.LeftPart: { return NodeName + "_left"; break; }
                case WidePart.CenterPart: { return NodeName + "_center"; break; }
                case WidePart.RightPart: { return NodeName + "_right"; break; } 
			}

			return NodeName;
		}

		public string GetWideTextureName(WidePart widePart)
		{
			switch (widePart)
			{
				case WidePart.LeftPart:{ return TextureName + "_left"; } break;
				case WidePart.CenterPart:{ return TextureName + "_center"; } break;
				case WidePart.RightPart: { return TextureName + "_right"; } break;
			}

			return TextureName;
		}

		public string ItemsIndex
		{
			get
			{
				FileInfo fi = new FileInfo(_fileName);

				string[] tmp = fi.Name.Split('!');

				if (!tmp[1].ToLower().Contains("pick_"))
				{
                    throw new Exception("I can not get the scene number in which the object is found '" + _fileName + "'. \nMaybe there's something wrong with pick_XXX.");
				}

				string[] tmp1 = tmp[1].Split('_');

				return tmp1[1];
			}
		}

		public string FullFileName
		{
			get { return _fileName; }
		}

		public string FileNameWithoutExtension
		{
			get
			{
				FileInfo fi = new FileInfo(_fileName);

				string nameWithoutExtension = fi.Name.Substring(0, fi.Name.LastIndexOf('.'));
				if (nameWithoutExtension.Length == 0)
				{
                    throw new Exception("I can not reject the extension of the file name: " + _fileName);
				}

				return nameWithoutExtension;
			}
		}

		public bool IsCollectableItem
		{
			get 
			{
				return !IsStatic && !IsBackground && !IsDropZone && !IsActiveZone;
			}
		}

		public bool IsBackground
		{
			get
			{
				return _fileName.ToLower().Contains("background");
			}
		}

		public bool IsWideTexture
		{
			get
			{
				return _fileName.ToLower().Contains("back");
			}
		}

		public string LeftWidePartTextureName
		{
			get
			{
				return "";
			}
		}

		public bool IsStatic
		{
			get 
			{
				return (_fileName.IndexOf('!') == _fileName.LastIndexOf('!')) || 
					(!_fileName.ToLower().Contains("active_zone") &&
					!_fileName.ToLower().Contains("drop_zone") &&
					!_fileName.ToLower().Contains("pick"));
			}
		}

		public bool IsDropZone
		{
			get
			{
				string nameWithouExtension = FileNameWithoutExtension;
				
				if (nameWithouExtension.Contains("drop_zone")) return true;
				
				return false;
			}
		}

		public string AcceptsItemName
		{
			get
			{
				string nameWithouExtension = FileNameWithoutExtension;
				string[] tmp = nameWithouExtension.Split('!');

				if (tmp.Length == 3 && tmp[1] == "drop_zone") return tmp[2].Replace('+', '|');

				return string.Empty;
			}

		}

		public bool IsActiveZone
		{
			get
			{
				string nameWithouExtension = FileNameWithoutExtension;

				if (nameWithouExtension.Contains("active_zone")) return true;

				return false;
			}
		}

		public string RussianName
		{
			get
			{
				string nameWithouExtension = FileNameWithoutExtension;
				string[] tmp = nameWithouExtension.Split('!');

				if (!tmp[1].Contains("pick_"))
				{
                    throw new Exception("I can not get Russian name of the file: " + _fileName + ".  Because it does not collect items (no pick) ");
				}

				if (tmp.Length < 3)
				{
					throw new Exception("I can not get Russian name of the file: " + _fileName);
				}

				return HiddenObjectStudio.Core.Tools.FilterString(tmp[2].ToLower());
			}
		}

		public string EnglishName
		{
			get
			{
				string nameWithouExtension = FileNameWithoutExtension;
				string[] tmp = nameWithouExtension.Split('!');

				if (!tmp[1].Contains("pick_"))
				{
                    throw new Exception("I can not get the English name of the file: " + _fileName + ".  Because it does not collect items (no pick) ");
				}

				if (tmp.Length < 3)
				{
                    throw new Exception("I can not get the English name of the file: " + _fileName);
				}

				return HiddenObjectStudio.Core.Tools.FilterString(tmp[3].ToLower());
			}
		}

		public string GroupName
		{
			get
			{
				
				if (IsBackground || IsStatic) return "";

				string groupName = EnglishName;

				if (char.IsNumber(groupName[0]))
				{
					groupName = "_" + groupName;
				}

				// надо вырезать цифорку с конца, если она есть

				// находим позицию _ с конца
				int index = groupName.LastIndexOf('_');

				if (index > 0)
				{
					// вырезаем от _ до конца, там типа должна быть цифра
					string counter = groupName.Substring(index + 1, groupName.Length - index - 1);

					// смотрим, правда ли там цифра

					if (char.IsNumber(counter[0]))
					{
						// цифра в конце была, значит имя группы будет всё то, что до подчёркивания

						return groupName.Substring(0, index);
					}
					else
					{
						// ага.. подчёркивание было, но за ним - не цифра, значит всё это будет именем группы
						return groupName;
					}
				}
				else
				{
					return groupName;
				}
			}
		}

		public bool DisableAlphaSelection
		{
			get
			{
				return _fileName.ToLower().Contains("_das_");
			}
		}

		public string GetOnlyFileName()
		{
			FileInfo fi = new FileInfo(_fileName);
			return fi.Name;
		}

		public string GetActiveZoneType()
		{
			string nameWithouExtension = FileNameWithoutExtension;
			string[] tmp = nameWithouExtension.Split('!');

			if (tmp[1] == "active_zone") return tmp[2];

			return string.Empty;
		}

		public string GetSubscreenFolder()
		{
			string nameWithouExtension = FileNameWithoutExtension;
			string[] tmp = nameWithouExtension.Split('!');

			if (tmp[1] == "active_zone" && tmp[2] == "sub_screen") return tmp[3];

			return string.Empty;
		}
		
		public string GetSubscreenFile()
		{
			string nameWithouExtension = FileNameWithoutExtension;
			string[] tmp = nameWithouExtension.Split('!');

			if (tmp[1] == "active_zone" && tmp[2] == "sub_screen") return tmp[4];

			return string.Empty;
		}
		
		public string GetDestinationPlace()
		{
			string nameWithouExtension = FileNameWithoutExtension;
			string[] tmp = nameWithouExtension.Split('!');
			string[] tmp1;

			if (tmp[1] == "active_zone" && tmp[2] == "place")
			{
				tmp1 = tmp[3].Split('-');
				return tmp1[0] + ' ' + tmp1[1];
			}
			else
			{
                throw new Exception("I can not get the scene number to which a transition (place) from the file: " + _fileName);
			}

		}
		
		public string TranslitName()
		{
			string fileName = FileNameWithoutExtension;
			StringBuilder res = new StringBuilder(); //s= string.Empty;
			
			foreach (char c in fileName.ToLower())
			{
				switch (c)
				{
					case 'а': res.Append('a'); break;
					case 'б': res.Append('b'); break;
					case 'в': res.Append('v'); break;
					case 'г': res.Append('g'); break;
					case 'д': res.Append('d'); break;
					case 'е': res.Append('e'); break;
					case 'ё': res.Append('e'); break;
					case 'ж': res.Append("zh"); break;
					case 'з': res.Append('z'); break;
					case 'и': res.Append('i'); break;
					case 'й': res.Append('y'); break;
					case 'к': res.Append('k'); break;
					case 'л': res.Append('l'); break;
					case 'м': res.Append('m'); break;
					case 'н': res.Append('n'); break;
					case 'о': res.Append('o'); break;
					case 'п': res.Append('p'); break;
					case 'р': res.Append('r'); break;
					case 'с': res.Append('s'); break;
					case 'т': res.Append('t'); break;
					case 'у': res.Append('u'); break;
					case 'ф': res.Append('f'); break;
					case 'х': res.Append('h'); break;
					case 'ц': res.Append("ts"); break;
					case 'ч': res.Append("ch"); break;
					case 'ш': res.Append("sh"); break;
					case 'щ': res.Append("sch"); break;
					case 'ъ':  break;
					case 'ы': res.Append('y'); break;
					case 'ь':  break;
					case 'э': res.Append('e'); break;
					case 'ю': res.Append("yu"); break;
					case 'я': res.Append("ya"); break;
					default: res.Append(c); break;
				}
			}

			return res.ToString();
		}

	}
}
