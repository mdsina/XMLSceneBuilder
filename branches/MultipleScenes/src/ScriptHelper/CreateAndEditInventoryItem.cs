using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class CreateAndEditInventoryItem : Form
    {
        public CreateAndEditInventoryItem(string controlState, string selectedInvItem)
        {
            InitializeComponent(selectedInvItem);

            if (controlState == "create")
            {
                createInvItemControl1.Visible = true;
                createInvItemControl1.Enabled = true;
                editInvItemControl1.Visible = false;
                editInvItemControl1.Enabled = false;
            }
            else if (controlState == "edit")
            {
                createInvItemControl1.Visible = false;
                createInvItemControl1.Enabled = false;
                editInvItemControl1.Visible = true;
                editInvItemControl1.Enabled = true;
            }
            else
            {
                createInvItemControl1.Visible = false;
                createInvItemControl1.Enabled = false;
                editInvItemControl1.Visible = false;
                editInvItemControl1.Enabled = false;
            }
        }
    }
}
