using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HiddenObjectStudio
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			SettingsAndConstants.LoadApplicationSettings();
            Application.Run(new Forms.XtraMainForm());
			SettingsAndConstants.SaveApplicationSettings();

		}
	}
}
