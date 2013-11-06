using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.Diagnostics;
using HiddenObjectStudio.Core;

namespace HiddenObjectsXMLBuilder
{
    class TexturePack
    {
        private XmlDocument texturePackDoc;
        private XmlElement texturePackRoot;
		private BuilderConfig _builderConfig;
		private BuildOptions _buildOptions;


        public TexturePack(BuilderConfig builderConfig, BuildOptions buildOptions)
        {
			_builderConfig = builderConfig;
			_buildOptions = buildOptions;

            texturePackDoc = new XmlDocument();

            texturePackRoot = texturePackDoc.CreateElement("texture_packer");
			texturePackRoot.SetAttribute("name", buildOptions.dstFolder + "\\texture_pack\\" + _builderConfig.TexturePackName);
            texturePackRoot.SetAttribute("max_size", "1024 1024");
			texturePackRoot.SetAttribute("extension", "png");
        }

		public void AddNode(FileName fn)
		{
			try
			{
				XmlElement textureNode = null;

				textureNode = texturePackDoc.CreateElement("texture");

				textureNode.SetAttribute("name", fn.TextureName);
				textureNode.SetAttribute("texture_name", _buildOptions.srcFolder + "\\" + fn.FileNameWithoutExtension);

				if (!fn.DisableAlphaSelection)
				{
					textureNode.SetAttribute("min_alpha_selection", "150");
					textureNode.SetAttribute("make_alpha_selection", "1");
				}
				
				if (fn.IsCollectableItem && !fn.DisableAlphaSelection)
				{
					textureNode.SetAttribute("alpha_selection_expansion", "4");
				}

				if ((fn.IsActiveZone || fn.IsDropZone))
				{
					if (_buildOptions.buildActiveZonesVisible)
					{
						textureNode.SetAttribute("save_image", "1");
					}
					else
					{
						textureNode.SetAttribute("save_image", "0");
					}
				}

				if (_buildOptions.buildAlphaSelection)
				{
					textureNode.SetAttribute("show_alpha_selection", "1");
				}

				textureNode.SetAttribute("frame_count", "1");

				texturePackRoot.AppendChild(textureNode);
			}
			catch (Exception)
			{
				MessageBox.Show(fn.FullFileName, "Error");

				throw new Exception();
			}


		}

		public void Save()
		{
			string fileName = _buildOptions.dstFolder + "\\texture_pack.xml";
			texturePackDoc.AppendChild(texturePackRoot);
			XmlWriter texturePackWriter = new XmlTextWriter(fileName, Encoding.UTF8);
			texturePackDoc.Save(texturePackWriter);
			texturePackWriter.Close();

			Process p = new Process();
			p.StartInfo.FileName = HiddenObjectStudio.Core.Tools.AppendSlashIfNeeded(_builderConfig.ElefunToolsPath) + "FormatedXML.exe";
			p.StartInfo.Arguments = fileName;
			p.Start();
			p.WaitForExit();

		}

    }
}
