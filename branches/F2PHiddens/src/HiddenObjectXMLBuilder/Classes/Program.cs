using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace HiddenObjectsXMLBuilder
{
    class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

			SettingsAndConstants.LoadApplicationSettings();
            Application.Run(new MainForm());
			SettingsAndConstants.SaveApplicationSettings();
        }

    
    }
}
