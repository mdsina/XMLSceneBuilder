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
	class Resources
	{
		private XmlDocument _resourcesXmlDoc;
		private XmlElement _resourcesRoot;
		private XmlElement _texturePackNode;
		private string _resourcesFileName;

		private BuilderConfig _builderConfig;
		private BuildOptions _buildOptions;

		private List<FileName> _backgroundsList;

		public List<FileName> BackgroundsList
		{
			get
			{
				return _backgroundsList;
			}
		}

		public Resources(BuilderConfig builderConfig, BuildOptions buildOptions)
		{
			_builderConfig = builderConfig;
			_buildOptions = buildOptions;
			_backgroundsList = new List<FileName>();
			_resourcesFileName = _buildOptions.dstFolder + "\\resources.xml";

			_resourcesXmlDoc = new XmlDocument();

			_resourcesRoot = _resourcesXmlDoc.CreateElement(_buildOptions.sceneName);

			_texturePackNode = _resourcesXmlDoc.CreateElement("texture_pack");
			

		}

		public void AddNode(FileName fn)
		{
			BackgroundsList.Add(fn);

			string shaderFullFileName = _buildOptions.dstFolder + "\\" + _builderConfig.ShaderFolderName  + "\\" + fn.GetOnlyFileName();

			XmlElement backgroundNode = _resourcesXmlDoc.CreateElement("shader");

			backgroundNode.SetAttribute("name", fn.TextureName);
			backgroundNode.SetAttribute("texture_name", _builderConfig.ShaderFolderName  + "\\" + fn.FileNameWithoutExtension);
			// 						backgroundNode.SetAttribute("diffuse_file_name", _shaderFolderName + fn.FileNameWithoutExtension + ".jpg");
			// 						backgroundNode.SetAttribute("opacity_file_name", _shaderFolderName + fn.FileNameWithoutExtension + "_alpha.jpg");

			_resourcesRoot.AppendChild(backgroundNode);

		}

		public void Save()
		{
			_texturePackNode.SetAttribute("name", _builderConfig.TexturePackName);
			_texturePackNode.SetAttribute("file_name", "texture_pack\\" + _builderConfig.TexturePackName + ".tpf");
            if (_buildOptions.isSubscreen)
            {
                _texturePackNode.SetAttribute("temporary_textures", "1");
            }
			_resourcesRoot.AppendChild(_texturePackNode);
			_resourcesXmlDoc.AppendChild(_resourcesRoot);
			//XmlWriter writer = new XmlTextWriter(, Encoding.GetEncoding("windows-1251"));
			_resourcesXmlDoc.Save(_resourcesFileName);

// 			if (BackgroundsList.Count != 0)
// 			{
// 				Pow2AndCopy();
// 			}

		}

		private void Pow2AndCopy()
		{
			string dstFolder = HiddenObjectStudio.Core.Tools.AppendSlashIfNeeded(_buildOptions.dstFolder) + _builderConfig.ShaderFolderName;

			DirectoryInfo di = new DirectoryInfo(dstFolder);
			dstFolder = di.FullName;

			// check and create destination folder for textures
			if (!Directory.Exists(dstFolder))
			{
				Directory.CreateDirectory(dstFolder);
			}


			// copy them to destination
			foreach (FileName fn in BackgroundsList)
			{
				string dstFullFileName = HiddenObjectStudio.Core.Tools.AppendSlashIfNeeded(_buildOptions.dstFolder) + _builderConfig.ShaderFolderName + "\\" + fn.GetOnlyFileName();
				string srcFullFileName = HiddenObjectStudio.Core.Tools.AppendSlashIfNeeded(_buildOptions.srcFolder) + fn.GetOnlyFileName();

				try
				{
					if (File.Exists(dstFullFileName))
					{
						// 						if (DialogResult.Yes == MessageBox.Show(
						// 							"File: \"" + dstFullFileName + "\" is already exists. Overwrite?", 
						// 							"File exists", 
						// 							MessageBoxButtons.YesNo, 
						// 							MessageBoxIcon.Question))
						{
							File.Delete(dstFullFileName);
							File.Copy(srcFullFileName, dstFullFileName);
						}
					}
					else
					{
						File.Copy(srcFullFileName, dstFullFileName);
					}


				}
				catch (System.Exception ex)
				{
					MessageBox.Show("Немогу скопировать файл :" + "\"" + fn.FullFileName + "\" to: \"" + dstFullFileName + "\"" + "\n" + ex.Message, "Ошипко, ёма", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}


			// process files
			Process p = new Process();
			p.StartInfo.FileName = HiddenObjectStudio.Core.Tools.AppendSlashIfNeeded(_builderConfig.ElefunToolsPath) + "TexturePreparerTwoPow.exe";
			p.StartInfo.Arguments = dstFolder;
			p.Start();
			p.WaitForExit();

		}


	}
}
