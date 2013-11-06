using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HiddenObjectStudio.Core;
using HiddenObjectStudio.Core.ResourcesManager;
using HiddenObjectStudio.Core.InventoriesManagement;
using System.Xml;
using System.IO;

namespace WindowsFormsApplication2
{
    public partial class InventoryManagerForm : Form
    {
        Config Config;
        public ResourcesData resourcesData;
        public Inventories inventories;
        public PictureBox pb1;
        public PictureBox pb2;

        private string _invFilename;
        private string _invResFilename;

        public InventoryManagerForm()
        {
            LoadData();

            pb1 = new PictureBox();
            pb2 = new PictureBox();

            InitializeComponent();

        }

        private void LoadData()
        {
            Config = new Config();

            _invFilename = Config.InventoryPath + "\\inventory.xml";
            _invResFilename = Config.InventoryPath + "\\resources.xml";

            resourcesData = new ResourcesData(_invResFilename);
            inventories = new Inventories(_invFilename);
        }

        public void InitListView()
        {
            inventories.LoadInventoriesXMl(_invFilename);
            resourcesData.LoadResourcesXMl(_invResFilename);

            XmlDocument textDocXML;
            string textFilenameNewItem = Config.TextsPath + "\\texts.xml";
            Image img;
            textDocXML = new XmlDocument();
            textDocXML.Load(textFilenameNewItem);

            foreach (IntentoryItem invItem in inventories.IntentoryItems)
            {
                List<string> AllParts = new List<string>();
                string allPartsString = String.Empty;

                foreach (Part part in invItem.PartsList)
                {
                    AllParts.Add(part.partName);
                    if (allPartsString == String.Empty)
                    {
                        allPartsString = part.partName;
                    }
                    else
                    {
                        allPartsString = allPartsString + "\n" + part.partName;
                    }
                }

                string attText = invItem.InvItemShaderName;

                string picPath = resourcesData.GetShaderPathByFullName(attText);



                if (File.Exists(picPath))
                {
                    img = Image.FromFile(picPath);
                }
                else
                {
                    img = null;
                }


                string textBoxText = textBoxSearch.Text;

                string itemName = string.Empty;

                string nameToShow = string.Empty;

                XmlNode textInvItemNode = (XmlNode)textDocXML.SelectSingleNode("texts/gameplay/inventory_items/" + invItem.Name);
                if (textInvItemNode != null)
                {
                    itemName = textInvItemNode.Attributes["text"].Value;
                }

                if (itemName != string.Empty)
                {
                    nameToShow = invItem.Name + '\n' + "(\"" + itemName + "\")";
                }
                else
                {
                    nameToShow = invItem.Name;
                }

                if (textBoxText == String.Empty)
                {

                    ListViewItem newItem = new ListViewItem();
                    if (img != null)
                    {
                        imageList1.Images.Add(Path.GetFileName(picPath), img);
                        newItem.ImageKey = Path.GetFileName(picPath);
                        listView1.LargeImageList.Images.Add(img);
                        listView1.SmallImageList.Images.Add(img);
                    }

                    newItem.SubItems.Add(nameToShow);
                    newItem.SubItems.Add(allPartsString);
                    listView1.Items.Add(newItem);

                    listView1.Refresh();
                }

                string[] searchMass = textBoxText.Split(' ');

                if ((textBoxText != String.Empty) && (StringContainsMassElement(searchMass, invItem.Name)))
                {

                    ListViewItem newItem = new ListViewItem();
                    if (img != null)
                    {
                        imageList1.Images.Add(Path.GetFileName(picPath), img);
                        newItem.ImageKey = Path.GetFileName(picPath);
                        listView1.LargeImageList.Images.Add(img);
                        listView1.SmallImageList.Images.Add(img);
                    }
                    newItem.SubItems.Add(nameToShow);
                    newItem.SubItems.Add(allPartsString);
                    listView1.Items.Add(newItem);

                    listView1.Refresh();

                }
            }
        }

        private bool StringContainsMassElement(string[] srtMass, string str)
        {
            for (int i = 0; i < srtMass.Length; i++)
            {
                if (!str.Contains(srtMass[i]))
                {
                    return false;
                }
            }
            return true;
        }

        private void buttonSelectBigPic_Click(object sender, EventArgs e)
        {

        }

        private void buttonSelectSmallPic_Click(object sender, EventArgs e)
        {

        }

        private void button5EditItem_Click(object sender, EventArgs e)
        {

        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            InitListView();
        }

        private void InventoryManagerForm_Load(object sender, EventArgs e)
        {
            InitListView();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBoxSearch.Text = String.Empty;
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                FillEditControl();
            }
            
        }

        private void FillEditControl()
        {
            if (listView1.SelectedItems.Count != 0)
            {
                string[] nameArr = listView1.SelectedItems[0].SubItems[1].Text.Split('\n');

                string selectedInvItem = nameArr[0];
                string itemGameName = nameArr[1].Replace("\"","").Replace("(","").Replace(")","");
                IntentoryItem invItem = inventories.GetInventoryItemByName(selectedInvItem);

                textBoxEditItem.Text = invItem.Name;

                textBoxGameItemName.Text = itemGameName;

                string attText = invItem.InvItemShaderName;

                string smallPicPath = resourcesData.GetShaderPathByFullName(attText);
                Image loadedImage = Image.FromFile(smallPicPath);
                pb1.Height = loadedImage.Height;
                pb1.Width = loadedImage.Width;
                pb1.Image = loadedImage;
                pb2.Refresh();
                flowLayoutPanel1.Controls.Add(pb1);

               // string bigPicPath = resourcesData.GetShaderPathByFullName(attText);
                string smallPicPathWithoutExt = resourcesData.GetShaderPathByFullName(attText).Substring(0, resourcesData.GetShaderPathByFullName(attText).Length - 4);
                string bigPicPath = smallPicPathWithoutExt + "_big.png"; 
                
                Image loadedImage2 = Image.FromFile(bigPicPath);
                pb2.Height = loadedImage2.Height;
                pb2.Width = loadedImage2.Width;
                pb2.Image = loadedImage2;
                pb2.Refresh();
                flowLayoutPanel2.Controls.Add(pb2);

                textBoxSmallPicFilePath.Text = smallPicPath;
                textBoxBigPicFilePath.Text = bigPicPath;
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                FillEditControl();
            }
        }

        private void buttonEditItem_Click(object sender, EventArgs e)
        {

        }

       
      
    }
}
