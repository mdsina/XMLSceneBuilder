using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace HiddenObjectStudio.Core.Forms
{
    public partial class AddContainerForm : Form
    {
        public string ContName
        {
            get;
            set;
        }
        
        public AddContainerForm(ref string contName)
        {
            ContName = contName;
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (textBoxContainerName.Text != string.Empty)
            {
                string str = textBoxContainerName.Text;
                char ch = str[0];
                if (char.IsNumber(ch))
                {
                    MessageBox.Show("Container Name can't begin with Number!");
                }
                else
                {
                    ContName = str;
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Please enter Container Name fisrt!");
            }
        }

        private void textBoxContainerName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsLetter(e.KeyChar) || (e.KeyChar == '_'))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
