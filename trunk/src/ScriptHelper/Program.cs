using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApplication2
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
            Application.Run(new MainForm());
            
        }
    }

    public class Factory : Form
    {
        public Factory()
        {
            this.Visible = false;

            MainForm f = new MainForm();

            LoadingForm loadingForm = new LoadingForm();
            loadingForm.Show();
        }

    }
}
