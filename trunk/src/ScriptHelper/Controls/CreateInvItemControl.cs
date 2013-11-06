using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using HiddenObjectStudio.Core;

namespace WindowsFormsApplication2.Controls
{
    public partial class CreateInvItemControl : UserControl
    {
		private Config Config;

        public CreateInvItemControl()
        {
            InitializeComponent();

			Config = new Config();

            InitializeOpenFileDialog();
        }

        private void InitializeOpenFileDialog()
        {
            // Set the file dialog to filter for graphics files.
            
            this.openFileDialogPic.Filter =
                "Images (*.PNG)|*.PNG|"+
                "All files (*.*)|*.*";

            // Allow the user to select multiple images.
            this.openFileDialogPic.Multiselect = false;
            this.openFileDialogPic.Title = "Select picture of inventory item!";
        }

        private void button5AddNewItem_Click(object sender, EventArgs e)
        {
            AddItemsToXmlFile();
        }

        private void AddItemsToXmlFile()
        {
            string addItemBoxText = textBoxAddNewItem.Text;
            string inventoryNodeName = addItemBoxText;

            if ((addItemBoxText != String.Empty) && (textBoxSmallPicFilePath.Text != String.Empty) && (textBoxBigPicFilePath.Text != String.Empty) && (textBoxGameItemName.Text != String.Empty))
            {
                if (textBoxBigPicFilePath.Text == textBoxSmallPicFilePath.Text + "_big")
                {
                    AddToTexlXML(addItemBoxText, textBoxGameItemName.Text);
                    AddToInventoryXML(addItemBoxText, textBoxSmallPicFilePath.Text);
                    AddToResourcesXML(addItemBoxText, textBoxSmallPicFilePath.Text, textBoxBigPicFilePath.Text);
                }
                else { System.Windows.Forms.MessageBox.Show("Difference between small and big pictures must be in '_big' only!"); }
            }
            else { System.Windows.Forms.MessageBox.Show("Please fill in all fields!"); }
        }

        private void AddToTexlXML(string itemName, string gameItemName)
        {
            XmlDocument textDocXML;
            XmlElement textRootXML;
            string textFilenameNewItem = Config.BinPath + "data\\texts\\texts.xml";

            string inventoryNodeName = itemName;

            textDocXML = new XmlDocument();
            textDocXML.Load(textFilenameNewItem);
            textRootXML = (XmlElement)textDocXML.SelectSingleNode("texts/gameplay/inventory_items");
            bool itemExistInTextsXml = false;

            foreach (XmlNode itemTextNode in textRootXML)
            {
                if (itemName == itemTextNode.Name)
                {
                    itemExistInTextsXml = true;
                    label6.Text = "Item Exist In Texts.Xml";
                }
            }
            if (itemExistInTextsXml == false)
            {
                XmlElement addInvItemNodeTextsXml = textDocXML.CreateElement(inventoryNodeName);
                addInvItemNodeTextsXml.SetAttribute("text", gameItemName);
                textRootXML.AppendChild(addInvItemNodeTextsXml);
                textDocXML.Save(textFilenameNewItem);
                label6.Text = "Completed";
                textBoxAddNewItem.Text = "";
            }
        }

        private void AddToInventoryXML(string itemName, string smallPicName)
        {
            XmlDocument inventoryDocXML;
            XmlElement inventoryRootXML;

            string invFilenameNewItem = Config.InventoryPath + "\\inventory.xml";

            string inventoryNodeName = itemName;

            inventoryDocXML = new XmlDocument();
            inventoryDocXML.Load(invFilenameNewItem);
            inventoryRootXML = (XmlElement)inventoryDocXML.SelectSingleNode("inventory");
            bool itemExistInInventoryXml = false;

            foreach (XmlNode itemInvNode in inventoryRootXML)
            {
                if (itemName == itemInvNode.Name)
                {
                    itemExistInInventoryXml = true;
                    label6.Text = "Item Exist In Inventory.Xml";
                }
            }
            if (itemExistInInventoryXml == false)
            {
                XmlElement addInvItemNodeInventoryXml = inventoryDocXML.CreateElement(inventoryNodeName);
                addInvItemNodeInventoryXml.SetAttribute("full_name", "puzzl_on_the_bed/" + itemName);
                addInvItemNodeInventoryXml.SetAttribute("shader", "inventory/items/" + smallPicName);
                inventoryRootXML.AppendChild(addInvItemNodeInventoryXml);
                inventoryDocXML.Save(invFilenameNewItem);
                label6.Text = "Completed";
                textBoxAddNewItem.Text = "";
            }

        }

        private void AddToResourcesXML(string itemName, string smallPicName, string bigPicName)
        {
            XmlDocument resDocXml;
            XmlElement resRootXml;

            string resFilenameNewItem = Config.InventoryPath + "\\resources.xml";

            string inventoryNodeName = itemName;

            //---ResourcesXML----------------------------------

            resDocXml = new XmlDocument();
            resDocXml.Load(resFilenameNewItem);
            resRootXml = (XmlElement)resDocXml.SelectSingleNode("inventory/items");
            bool itemExistInResXml = false;

            foreach (XmlNode itemResNode in resRootXml)
            {
                if (smallPicName == itemResNode.Attributes["name"].Value)
                {
                    itemExistInResXml = true;
                    label6.Text = "Item Exist In Resources.Xml";
                    System.Windows.Forms.MessageBox.Show("Item Exist In Resources.Xml! Added Only in inventory.xml and text.xml!");
                }
            }
            if (itemExistInResXml == false)
            {
                XmlElement addInvItemNodeResXml = resDocXml.CreateElement("shader");
                addInvItemNodeResXml.SetAttribute("name", smallPicName);
                addInvItemNodeResXml.SetAttribute("texture_name", "textures\\" + smallPicName);
                addInvItemNodeResXml.SetAttribute("temporary_textures", "1");
                resRootXml.AppendChild(addInvItemNodeResXml);
                resDocXml.Save(resFilenameNewItem);

                XmlElement addInvItemNodeResXmlBig = resDocXml.CreateElement("shader");
                addInvItemNodeResXmlBig.SetAttribute("name", bigPicName);
                addInvItemNodeResXmlBig.SetAttribute("texture_name", "textures\\" + bigPicName);
                addInvItemNodeResXmlBig.SetAttribute("temporary_textures", "1");
                resRootXml.AppendChild(addInvItemNodeResXmlBig);
                resDocXml.Save(resFilenameNewItem);

                label6.Text = "Completed";
                textBoxAddNewItem.Text = "";
            }
        }
        
        
        private void textBoxAddNewItem_TextChanged(object sender, EventArgs e)
        {
            string addItemBoxText = textBoxAddNewItem.Text;

            if (addItemBoxText != String.Empty)
            {
                button5AddNewItem.Enabled = true;
            }
            else
            {
                button5AddNewItem.Enabled = false;

            }
        }

        private void buttonSelectSmallPic_Click(object sender, EventArgs e)
        {
            DialogResult dr = this.openFileDialogPic.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                string file = openFileDialogPic.FileName;
                try
                {
                    flowLayoutPanel1.Controls.Clear();
                    PictureBox pb = new PictureBox();
                    Image loadedImage = Image.FromFile(file);
                    pb.Height = loadedImage.Height;
                    pb.Width = loadedImage.Width;
                    pb.Image = loadedImage;
                    flowLayoutPanel1.Controls.Add(pb);

                    string fullFileName = openFileDialogPic.SafeFileName;
                    string fileName = fullFileName.Substring(0, fullFileName.Length - 4);
                    textBoxSmallPicFilePath.Text = fileName;

                    if ((pb.Height != 64) && (pb.Width != 64))
                    {
                        textBoxSmallPicFilePath.Text = String.Empty;
                        DialogResult resultSmallSizeError = System.Windows.Forms.MessageBox.Show("Picture size must be 64 x 64! Select image without '_big'!" + "\n\n" +
                            "Do you want re-select image?", "Error! Incorrect pictures size", MessageBoxButtons.OKCancel);
                        if (resultSmallSizeError == DialogResult.OK)
                        {
                            buttonSelectSmallPic_Click(sender, e);
                        }
                    }
                }
                catch (Exception ex)
                {
                    textBoxSmallPicFilePath.Text = String.Empty;

                    MessageBox.Show("Cannot select the image: " + file.Substring(file.LastIndexOf('\\') + 1)
                        + ". You may not have permission to read the file, or " +
                        "it may be corrupt.\n\nReported error: " + ex.Message);
                }
            }
        }

        private void buttonSelectBigPic_Click(object sender, EventArgs e)
        {
            DialogResult dr = this.openFileDialogPic.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                 string file = openFileDialogPic.FileName;
                 try
                 {
                     flowLayoutPanel2.Controls.Clear();
                     PictureBox pb = new PictureBox();
                     Image loadedImage = Image.FromFile(file);
                     pb.Height = loadedImage.Height;
                     pb.Width = loadedImage.Width;
                     pb.Image = loadedImage;
                     flowLayoutPanel2.Controls.Add(pb);
                     
                     string fullFileName = openFileDialogPic.SafeFileName;
                     string fileName = fullFileName.Substring(0, fullFileName.Length - 4);
                     textBoxBigPicFilePath.Text = fileName;

                     if ((pb.Height != 256) && (pb.Width != 256))
                     {
                         textBoxBigPicFilePath.Text = String.Empty;
                         DialogResult resultSmallSizeError = System.Windows.Forms.MessageBox.Show("Picture size must be 256 x 256! Select image with '_big'!" + "\n\n" +
                             "Do you want re-select image?", "Error! Incorrect pictures size", MessageBoxButtons.OKCancel);
                         if (resultSmallSizeError == DialogResult.OK)
                         {
                             buttonSelectBigPic_Click(sender, e);
                         }
                     }
                 }
                 catch (Exception ex)
                 {
                     textBoxSmallPicFilePath.Text = String.Empty;

                     MessageBox.Show("Cannot select the image: " + file.Substring(file.LastIndexOf('\\') + 1)
                         + ". You may not have permission to read the file, or " +
                         "it may be corrupt.\n\nReported error: " + ex.Message);
                 }
            }
        }
    
    }
}
