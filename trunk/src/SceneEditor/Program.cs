﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace SceneEditor
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
            Application.Run(new SceneEditor.Forms.SceneEditorMainForm("D:\\Work\\WL3\\bin\\data\\scenes\\bckyard\\bckyard.xml"));
		}
	}
}
