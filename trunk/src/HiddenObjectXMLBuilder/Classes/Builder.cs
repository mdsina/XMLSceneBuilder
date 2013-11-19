using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Win32;
using HiddenObjectStudio.Core;
using HiddenObjectsXMLBuilder.Forms;

namespace HiddenObjectsXMLBuilder
{
	struct BuildOptions
	{
		public string srcFolder;
        public string dstFolder; 
        public string textXmlFileName;
        public string levelsXmlFileName;
        public string navigationFilePath;
		public string sceneName;
        public string UserName;

		public bool rebuildScene;
        public bool rebuildLevels;
		public bool rebuildItemsFile;
		public bool rebuildHintsFile; 

	
		public bool rebuildTP;
		public bool buildAlphaSelection;
		public bool buildActiveZonesVisible;

		public bool rebuildResourcesFile;
        public bool rebuildGlintsFile;
        public bool rebuildNavigation;

		public bool isSubscreen;
        public bool isMinigame;
        public bool isHO;
        public bool isHo01;
        public List<string> HO01;
        public bool isHo02;
        public List<string> HO02;

		public bool rebuildTexts;

        public bool ee;
        public bool someFuncs;
        public bool hummingBird;
        public bool fadeAnimation;
        public bool morfing;

        public bool FoundParentNode(string _nodeName, XmlNode _tNode)
        {
            for (int i = 0; i < _tNode.ChildNodes.Count; i++)
            {
                if (_tNode.ChildNodes[i].Name == _nodeName)
                {
                    return true;
                }
            }
            return false;
        }

	}

	struct BuilderConfig
	{
		public string TexturePackName;
		public string ShaderFolderName;
		public string ElefunToolsPath;
		public string IncludesLibFileName;
        public string GlintsFileName;
	}

	class Builder
	{
		private BuilderConfig _config;

		private TexturePack _texturePack;
		private Resources _resources;
        private Glints _glints;
        private Glints _glintsHO1;
        private Glints _glintsHO2;
		private Scene _scene;
		private Texts _texts;
        private Items _items;
        private Levels _levels;
        private Navigation _navigation;
        
 

		public Builder()
		{
			_config.TexturePackName = "items";
			_config.ShaderFolderName = "textures";
			_config.IncludesLibFileName = "includes_lib.xml";
            _config.GlintsFileName = "glints.xml";
            

			RegistryKey regKey = Registry.CurrentUser.OpenSubKey("Software\\EleFun Tools");

			_config.ElefunToolsPath = (string)regKey.GetValue("");

			_texturePack = null;
			_resources = null;
            _glints = null;
            _glintsHO1 = null;
            _glintsHO2 = null;
			_scene = null;
			_texts = null;
			_items = null;
            _levels = null;
            _navigation = null;
            
		}
	
		public bool Build2(BuildOptions options)
		{
			//_config.sceneName = options.sceneName;
            options.isHO = false;
            options.isHo01 = false;
            options.isHo02 = false;
            options.HO01 = new List<string>();
            options.HO02 = new List<string>();
			try
			{
				List<string> textureNames = new List<string>();

				string[] files = Directory.GetFiles(options.srcFolder, "*.png");

				if (files.Length == 0)
				{
					throw new Exception("Not found *.png in folder.");
				}

                foreach (string fileName in files)
                {
                    if (fileName.Contains("pick_"))
                    {
                        if (fileName.Contains("pick_01"))
                        {
                            if (!options.isHo01)
                                options.isHo01 = true;

                            options.HO01.Add(fileName);
                        }

                        if (fileName.Contains("pick_02"))
                        {
                            if (!options.isHo02)
                                options.isHo02 = true;

                            options.HO02.Add(fileName);
                        }

                        if (!options.isHO)
                        {
                            options.isHO = true;
                        }
                    }
                    
                }

				//////////////////////////////////////////////////////////////////////////
				/// Create texture pack header

				if (options.rebuildTP)
				{
					 _texturePack =  new TexturePack(_config, options);

					//////////////////////////////////////////////////////////////////////////
					/// Create resource header
					 if (options.rebuildResourcesFile)
					 {
						 _resources = new Resources(_config, options);
					 }
				}

				//////////////////////////////////////////////////////////////////////////
				/// Create scene header

				if (options.rebuildScene)
				{
					_scene = new Scene(_config, options);
				}

				if (options.rebuildItemsFile || options.rebuildHintsFile)
				{
					_items = new Items(_config, options);
				}

				//////////////////////////////////////////////////////////////////////////
				/// Create texts header

				if (options.rebuildTexts)
				{
					_texts = new Texts(_config, options);
				}

                //////////////////////////////////////////////////////////////////////////
                /// Create navigation header

                if (options.rebuildNavigation)
                {
                    _navigation = new Navigation(_config, options);
                }

                //////////////////////////////////////////////////////////////////////////
                /// Initialize levels

                if (options.rebuildLevels)
                {
                    _levels = new Levels(_config, options);
                }
                //////////////////////////////////////////////////////////////////////////
                /// Create glints xml
                if (options.rebuildGlintsFile)
                {
                    _glints = new Glints(_config, options, "");
                    _glintsHO1 = new Glints(_config, options, "_01");
                    _glintsHO2 = new Glints(_config, options, "_02");

                }
				//////////////////////////////////////////////////////////////////////////
                
				foreach (string fileName in files)
				{
                    FileName fn = new FileName(fileName);

                    if ((options.rebuildGlintsFile))
                    {
                        if (fileName.LastIndexOf("_g") != -1)
                        {
                            if (options.isHO)
                            {
                                if (options.isHo01)
                                {
                                    if (fileName.Contains("_g1"))
                                    {
                                        _glintsHO1.AddGlint(fn.TextureName);
                                    }
                                    
                                }
                                if (options.isHo02)
                                {
                                    if (fileName.Contains("_g2"))
                                        _glintsHO2.AddGlint(fn.TextureName);
                                }
                            }
                            else
                            {
                                if (fileName.Contains("_g0"))
                                    _glints.AddGlint(fn.TextureName);
                            }

                        }
                    }

					if (fn.IsCollectableItem && _texts != null)
					{
						_texts.AddGroup(fn);
					}
					
					if (textureNames.Contains(fn.TextureName))
					{
                        throw new Exception("Error. Found duplicate the texture name: '" + fn.TextureName + "'\nFile:'" + fn.GetOnlyFileName() + "'");
					}
					else
					{
						textureNames.Add(fn.TextureName);
					}
                    //////////////////////////////////////////////////////////////////////////
                    /// Create scene node
					if (options.rebuildScene)
					{
						_scene.ProcessNode(fn);
					}
					//////////////////////////////////////////////////////////////////////////
					/// Create item node

					if (options.rebuildItemsFile)
					{
						_items.AddItem(fn);
					}
					//////////////////////////////////////////////////////////////////////////
					/// Create texture pack node

					if (options.rebuildTP)
					{
						_texturePack.ProcessNode(fn);
					}

				} // main loop

                if (options.rebuildLevels)
                {
                    _levels.ProcessNormalTextureNode();
                }

                if (options.rebuildNavigation)
                {
                    _navigation.Processing();
                }
				//////////////////////////////////////////////////////////////////////////
				/// Create texts node

				if (options.rebuildTexts)
				{
					_texts.Save();
				}


				//////////////////////////////////////////////////////////////////////////
				/// Save scene xml

				if (options.rebuildScene)
				{
					_scene.Save();
				}

                //////////////////////////////////////////////////////////////////////////
                /// Save navigation xml

                if (options.rebuildNavigation)
                {
                    _navigation.Save();
                }

                //////////////////////////////////////////////////////////////////////////
                /// Save levels xml

                if (options.rebuildLevels)
                {
                    _levels.Save();
                }

				//////////////////////////////////////////////////////////////////////////
				/// Save items xml

				if (options.rebuildItemsFile)
				{
                    if (_items.GetItemsNames().Count != 0)
                    {
                        OptionsHO _optionsHO = new OptionsHO(_items);
                        _optionsHO.ShowDialog();
                        List<string> interactiveItems = _optionsHO.GetInteractiveItems();
                        string defaultColor = _optionsHO.GetDefaultColor();
                        string interactiveColor = _optionsHO.GetInteractiveColor();
                        _items.AddColors(interactiveItems, interactiveColor, defaultColor);
                    }                    
					_items.Save();
				}

				//////////////////////////////////////////////////////////////////////////
				/// Save texture pack xml

				if (options.rebuildTP)
				{
					_texturePack.Save();
				
					if (options.rebuildTP)
					{
						DirectoryInfo di = new DirectoryInfo(options.dstFolder + "\\texture_pack");
	// 					di.Attributes = FileAttributes.Archive;
	// 
	// 					di.Delete(true);

						Process p = new Process();
						p.StartInfo.FileName = _config.ElefunToolsPath + "TexturePacker.exe";
						p.StartInfo.Arguments = options.dstFolder + "\\texture_pack.xml";
						p.Start();
						p.WaitForExit();
					}

					//////////////////////////////////////////////////////////////////////////
					/// Save resources xml
					if (options.rebuildResourcesFile)
					{
						_resources.Save();
					}            
				}

                //////////////////////////////////////////////////////////////////////////
                /// Save glints xml
                if (options.rebuildGlintsFile)
                {
                    if (options.isHO)
                    {
                        if (options.isHo01)
                        {
                            _glintsHO1.Save();
                        }
                        if (options.isHo02)
                        {
                            _glintsHO2.Save();
                        }
                    }
                    else
                    {
                        _glints.Save();
                    }
                }

			}
			catch (Exception ex)
			{
				throw new Exception("Error on scene '" + options.sceneName + "': " + ex.Message);
			}

			return true;
		}
		
	}
}
