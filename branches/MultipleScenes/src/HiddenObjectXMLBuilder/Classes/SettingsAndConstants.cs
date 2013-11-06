using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Drawing;
using HiddenObjectStudio.Core;

namespace HiddenObjectsXMLBuilder
{
	public class SettingsAndConstants
	{
		public static string RootRegistryLocation
		{
			get
			{
				return "Software\\EleFun\\Tools\\HiddenObjectsXmlBuilder";
			}
		}

		public static string VersionedRegistryLocation
		{
			get
			{
				return RootRegistryLocation + "\\" + Application.ProductVersion;
			}
		}

        public static Rectangle MainFormPosition;
		public static FormWindowState MainFormState;

		public static string SourcePath;
		public static string DstScenesInGamePath;
		public static string TextFileInGamePath;

		public static bool RebuildTP;
		public static bool ActiveZonesVisible;
		public static bool BuildAlphaSelection;
		public static bool RebuildTexts;
		public static bool RebuildItems;
		public static bool RebuildHints;
		public static bool RebuildScene;
		public static bool RebuildResources;

		private const int SettingsLocation = 0; // 0 - registry, 1 - ini-file


		public static void SaveApplicationSettings()
		{
			RegistryKey rootRegKey = Registry.CurrentUser.CreateSubKey(SettingsAndConstants.RootRegistryLocation);

			if (rootRegKey == null) return;

			if (MainFormState == FormWindowState.Maximized)
			{
				HiddenObjectStudio.Core.Tools.SetParameterToReg(rootRegKey, "Maximized", true);
			}
			else
			{
				if (MainFormState != FormWindowState.Minimized)
				{
					HiddenObjectStudio.Core.Tools.SetParameterToReg(rootRegKey, "WindowLeft", MainFormPosition.Left);
					HiddenObjectStudio.Core.Tools.SetParameterToReg(rootRegKey, "WindowTop", MainFormPosition.Top);
					HiddenObjectStudio.Core.Tools.SetParameterToReg(rootRegKey, "WindowWidth", MainFormPosition.Size.Width);
					HiddenObjectStudio.Core.Tools.SetParameterToReg(rootRegKey, "WindowHeight", MainFormPosition.Size.Height);
					HiddenObjectStudio.Core.Tools.SetParameterToReg(rootRegKey, "Maximized", false);
				}
			}

			SettingsAndConstants.SavePreferences();

			rootRegKey.Close();
		}

		public static void LoadApplicationSettings()
		{
			RegistryKey rootRegKey = Registry.CurrentUser.OpenSubKey(SettingsAndConstants.RootRegistryLocation);

			if (HiddenObjectStudio.Core.Tools.GetParameterFromReg(rootRegKey, "Maximized", false))
			{
				MainFormState = FormWindowState.Maximized;
			}
			else
			{
				MainFormPosition.Location = new Point(
					HiddenObjectStudio.Core.Tools.GetParameterFromReg(rootRegKey, "WindowLeft", 0), 
					HiddenObjectStudio.Core.Tools.GetParameterFromReg(rootRegKey, "WindowTop", 0)
					);
				MainFormPosition.Width = HiddenObjectStudio.Core.Tools.GetParameterFromReg(rootRegKey, "WindowWidth", 0);
				MainFormPosition.Height = HiddenObjectStudio.Core.Tools.GetParameterFromReg(rootRegKey, "WindowHeight", 0);
				MainFormState = FormWindowState.Normal;
			}

			LoadPreferences();

			if (rootRegKey != null) rootRegKey.Close();
			
		}

		public static void SavePreferences()
		{
			RegistryKey versionedRegKey = Registry.CurrentUser.CreateSubKey(SettingsAndConstants.VersionedRegistryLocation);

			if (versionedRegKey == null) return;

			HiddenObjectStudio.Core.Tools.SetParameterToReg(versionedRegKey, "SourcePath", SourcePath);
			HiddenObjectStudio.Core.Tools.SetParameterToReg(versionedRegKey, "DstScenesInGamePath", DstScenesInGamePath);
			HiddenObjectStudio.Core.Tools.SetParameterToReg(versionedRegKey, "TextFileInGamePath", TextFileInGamePath);

			HiddenObjectStudio.Core.Tools.SetParameterToReg(versionedRegKey, "RebuildTP", RebuildTP);
			HiddenObjectStudio.Core.Tools.SetParameterToReg(versionedRegKey, "ActiveZonesVisible", ActiveZonesVisible);
			HiddenObjectStudio.Core.Tools.SetParameterToReg(versionedRegKey, "BuildAlphaSelection", BuildAlphaSelection);
			HiddenObjectStudio.Core.Tools.SetParameterToReg(versionedRegKey, "RebuildTexts", RebuildTexts);
			HiddenObjectStudio.Core.Tools.SetParameterToReg(versionedRegKey, "RebuildItems", RebuildItems);
			HiddenObjectStudio.Core.Tools.SetParameterToReg(versionedRegKey, "RebuildHints", RebuildHints);
			HiddenObjectStudio.Core.Tools.SetParameterToReg(versionedRegKey, "RebuildScene", RebuildScene);
			HiddenObjectStudio.Core.Tools.SetParameterToReg(versionedRegKey, "RebuildResources", RebuildResources);
	
			versionedRegKey.Close();
		}

		public static void LoadPreferences()
		{
			RegistryKey versionedRegKey = Registry.CurrentUser.OpenSubKey(SettingsAndConstants.VersionedRegistryLocation);

			SourcePath = HiddenObjectStudio.Core.Tools.GetParameterFromReg(versionedRegKey, "SourcePath", "data\\");
			DstScenesInGamePath = HiddenObjectStudio.Core.Tools.GetParameterFromReg(versionedRegKey, "DstScenesInGamePath", "..\\bin\\data\\gameplay\\main\\scenes\\");
			TextFileInGamePath = HiddenObjectStudio.Core.Tools.GetParameterFromReg(versionedRegKey, "TextFileInGamePath", "..\\bin\\data\\texts\\texts.xml"); 

			RebuildTP = HiddenObjectStudio.Core.Tools.GetParameterFromReg(versionedRegKey, "RebuildTP", true);
			ActiveZonesVisible = HiddenObjectStudio.Core.Tools.GetParameterFromReg(versionedRegKey, "ActiveZonesVisible", true);
			BuildAlphaSelection = HiddenObjectStudio.Core.Tools.GetParameterFromReg(versionedRegKey, "BuildAlphaSelection", false);
			RebuildTexts = HiddenObjectStudio.Core.Tools.GetParameterFromReg(versionedRegKey, "RebuildTexts", true);
			RebuildItems = HiddenObjectStudio.Core.Tools.GetParameterFromReg(versionedRegKey, "RebuildItems", true);
			RebuildHints = HiddenObjectStudio.Core.Tools.GetParameterFromReg(versionedRegKey, "RebuildHints", true);
			RebuildScene = HiddenObjectStudio.Core.Tools.GetParameterFromReg(versionedRegKey, "RebuildScene", true);
			RebuildResources = HiddenObjectStudio.Core.Tools.GetParameterFromReg(versionedRegKey, "RebuildResources", true);

			if (versionedRegKey != null) versionedRegKey.Close();
			
		}


	}
}
