using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Drawing;
using HiddenObjectStudio.Core;

namespace SceneEditor
{
	public class SettingsAndConstants
	{
		public const string RegistryLocation = "Software\\EleFun\\Tools\\SceneEditor";
		public const string WindowTitle = "Scene Editor";
		public const string ProjectFilesFilter = "Scene Editor Project|*.spproject";
        public const string SpriteFilesFilter = "All images|*.bmp;*.jpg;*.png|BMP|*.bmp|JPG|*.jpg|PNG|*.png|All files|*.*";
		
		public static bool SpritesRelativePaths;
		public static bool LoadLastProjectOnStart;

		public static string LastProjectFileName;

        public static string LastProjectBrowsePath;
        public static string LastSpriteBrowsePath;
        public static string LastBackgroundBrowsePath;

        public static Rectangle MainFormPosition;
		public static FormWindowState MainFormState;
		public static bool DisplaySpriteActiveArea;


		private const int SettingsLocation = 0; // 0 - registry, 1 - ini-file


		public static void SaveApplicationSettings()
		{
			RegistryKey regKey = Registry.CurrentUser.CreateSubKey(SettingsAndConstants.RegistryLocation);

			if (regKey == null) return;

			HiddenObjectStudio.Core.Tools.SetParameterToReg(regKey, "LastProjectFile", LastProjectFileName);
			
            HiddenObjectStudio.Core.Tools.SetParameterToReg(regKey, "DisplaySpriteActiveArea", DisplaySpriteActiveArea);

            HiddenObjectStudio.Core.Tools.SetParameterToReg(regKey, "LastProjectBrowsePath", LastProjectBrowsePath);
            HiddenObjectStudio.Core.Tools.SetParameterToReg(regKey, "LastSpriteBrowsePath", LastSpriteBrowsePath);
            HiddenObjectStudio.Core.Tools.SetParameterToReg(regKey, "LastBackgroundBrowsePath", LastBackgroundBrowsePath);


			if (MainFormState == FormWindowState.Maximized)
			{
				HiddenObjectStudio.Core.Tools.SetParameterToReg(regKey, "Maximized", true);
			}
			else
			{
				if (MainFormState != FormWindowState.Minimized)
				{
					HiddenObjectStudio.Core.Tools.SetParameterToReg(regKey, "WindowLeft", MainFormPosition.Left);
					HiddenObjectStudio.Core.Tools.SetParameterToReg(regKey, "WindowTop", MainFormPosition.Top);
					HiddenObjectStudio.Core.Tools.SetParameterToReg(regKey, "WindowWidth", MainFormPosition.Size.Width);
					HiddenObjectStudio.Core.Tools.SetParameterToReg(regKey, "WindowHeight", MainFormPosition.Size.Height);
					HiddenObjectStudio.Core.Tools.SetParameterToReg(regKey, "Maximized", false);
				}
			}

			SettingsAndConstants.SavePreferences();

			regKey.Close();
		}

		public static void LoadApplicationSettings()
		{
			RegistryKey regKey = Registry.CurrentUser.OpenSubKey(SettingsAndConstants.RegistryLocation);

			LastProjectFileName = HiddenObjectStudio.Core.Tools.GetParameterFromReg(regKey, "LastProjectFile", string.Empty);
			DisplaySpriteActiveArea = HiddenObjectStudio.Core.Tools.GetParameterFromReg(regKey, "DisplaySpriteActiveArea", true);

            LastProjectBrowsePath = HiddenObjectStudio.Core.Tools.GetParameterFromReg(regKey, "LastProjectBrowsePath", string.Empty);
            LastSpriteBrowsePath = HiddenObjectStudio.Core.Tools.GetParameterFromReg(regKey, "LastSpriteBrowsePath", string.Empty);
            LastBackgroundBrowsePath = HiddenObjectStudio.Core.Tools.GetParameterFromReg(regKey, "LastBackgroundBrowsePath", string.Empty);

			if (HiddenObjectStudio.Core.Tools.GetParameterFromReg(regKey, "Maximized", false))
			{
				MainFormState = FormWindowState.Maximized;
			}
			else
			{
				MainFormPosition.Location = new Point(
					HiddenObjectStudio.Core.Tools.GetParameterFromReg(regKey, "WindowLeft", 0), 
					HiddenObjectStudio.Core.Tools.GetParameterFromReg(regKey, "WindowTop", 0)
					);
				MainFormPosition.Width = HiddenObjectStudio.Core.Tools.GetParameterFromReg(regKey, "WindowWidth", 0);
				MainFormPosition.Height = HiddenObjectStudio.Core.Tools.GetParameterFromReg(regKey, "WindowHeight", 0);
				MainFormState = FormWindowState.Normal;
			}

			LoadPreferences();

			if (regKey != null) regKey.Close();
			
		}

		public static void SavePreferences()
		{
			RegistryKey regKey = Registry.CurrentUser.CreateSubKey(SettingsAndConstants.RegistryLocation);
			if (regKey == null) return;

			HiddenObjectStudio.Core.Tools.SetParameterToReg(regKey, "SaveSpritesRelativePaths", SpritesRelativePaths);
			HiddenObjectStudio.Core.Tools.SetParameterToReg(regKey, "LoadLastProjectOnStart", LoadLastProjectOnStart);
			
			regKey.Close();
		}

		public static void LoadPreferences()
		{
			RegistryKey regKey = Registry.CurrentUser.OpenSubKey(SettingsAndConstants.RegistryLocation);
			
			SpritesRelativePaths = HiddenObjectStudio.Core.Tools.GetParameterFromReg(regKey, "SaveSpritesRelativePaths", true);
			LoadLastProjectOnStart = HiddenObjectStudio.Core.Tools.GetParameterFromReg(regKey, "LoadLastProjectOnStart", true);
			
			if (regKey != null) regKey.Close();
		}


	}
}
