using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class CheckSubsTemporaryTexturesForm : Form
    {
        List<string> outputResList;
        

        public CheckSubsTemporaryTexturesForm(List<string> takenOutputList)
        {
            InitializeComponent();

            this.outputResList = takenOutputList;

            FillResourcesTreeView(outputResList);
        }

        private void FillResourcesTreeView(List<string> resList)
        {

            if (resList.Count > 0)
            {
                foreach (string str in resList)
                {
                    string[] mass = str.Split('|');

                    string firtspart = mass[0];
                    string secondpart = mass[1];

                    ListViewItem newItem = new ListViewItem();
                    newItem.Text = firtspart;
                    newItem.SubItems.Add(secondpart);
                    newItem.SubItems.Add("");
                    listViewResult.Items.Add(newItem);
                    listViewResult.Refresh();
                }
                
            }
            
        }
    }
}
