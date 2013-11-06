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
			texturePackRoot.SetAttribute("wide_screen_base", "1024");
        }

		public void ProcessNode(FileName fn)
		{
			if (fn.IsWideTexture)
			{
				AddWideScreenNode(fn, WidePart.LeftPart);
				AddWideScreenNode(fn, WidePart.CenterPart);
				AddWideScreenNode(fn, WidePart.RightPart);
			}
			else
			{
				AddNormalNode(fn);
			}
		}

		private void AddWideScreenNode(FileName fn, WidePart widePart)
		{
			try
			{
				XmlElement textureNode = null;

				textureNode = texturePackDoc.CreateElement("texture");

				textureNode.SetAttribute("name", fn.GetWideTextureName(widePart));
				textureNode.SetAttribute(GetWidePartAttribute(widePart), _buildOptions.srcFolder + "\\" + fn.FileNameWithoutExtension);

				textureNode.SetAttribute("frame_count", "1");

				texturePackRoot.AppendChild(textureNode);
			}
			catch (Exception ex)
			{
				MessageBox.Show(fn.FullFileName + ": " + ex.Message, "Error");

				throw;
			}
		}

		private void AddNormalNode(FileName fn)
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
			catch (Exception ex)
			{
				MessageBox.Show(fn.FullFileName + ": " + ex.Message, "Error");

				throw;
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

		private string GetWidePartAttribute(WidePart widePart)
		{
			string postfix = "_part_of_wide_texture";

			switch (widePart)
			{
				case WidePart.LeftPart: { return "left" + postfix; } break;
				case WidePart.CenterPart: { return "center" + postfix; } break;
				case WidePart.RightPart: { return "right" + postfix; } break;
			}

			return string.Empty;
		}
    }
}
