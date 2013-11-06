using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Microsoft.Win32;
using HiddenObjectStudio.Core;

namespace HiddenObjectsXMLBuilder
{
    partial class OptionsHO : Form
    {
        private string DefaultColor
        {
            get { return textBoxDefaultColor.Text; }
            set { textBoxDefaultColor.Text = value; }
        }

        private string InteractiveColor
        {
            get { return textBoxInteractiveColor.Text; }
            set { textBoxInteractiveColor.Text = value; }
        }

        private Items _items;


        public OptionsHO(Items items)
        {
            _items = items;
            InitializeComponent();
        }

        private void OptionsHO_load(object sender, EventArgs e)
        {
            DefaultColor = SettingsAndConstants.DefaultColor;
            InteractiveColor = SettingsAndConstants.InteractiveColor;
            FillItemsList();
        }

        private void FillItemsList()
        {
            listViewItems.CheckBoxes = true;
            foreach (string itemName in _items.GetItemsNames())
            {
                listViewItems.Items.Add(itemName);
            }

        }

        public List<string> GetInteractiveItems()
        {
            List<string> interactiveItems = new List<string>();
            foreach (ListViewItem item in listViewItems.Items)
            {
                if(item.Checked)
                {
                    interactiveItems.Add(item.Text);
                }
            }
            return interactiveItems;
        }

        public string GetDefaultColor()
        {
            return textBoxDefaultColor.Text;
        }

        public string GetInteractiveColor()
        {
            return textBoxInteractiveColor.Text;
        }

        private void OptionsHO_close(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OptionsHO_FormClosing(object sender, FormClosingEventArgs e)
        {
            SettingsAndConstants.DefaultColor = DefaultColor;
            SettingsAndConstants.InteractiveColor = InteractiveColor;
        }

        private void textBoxDefaultColor_TextChanged(object sender, EventArgs e)
        {

        }

    }


}
