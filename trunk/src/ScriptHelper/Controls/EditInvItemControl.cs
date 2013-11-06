using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using HiddenObjectStudio.Core;
using System.IO;
using HiddenObjectStudio.Core.ResourcesManager;

namespace WindowsFormsApplication2.Controls
{
    public partial class EditInvItemControl : UserControl
    {
        string _oldItemNodeName;
        string _oldItemGameName;
        string _oldSmallPicPath;
        string _oldBigPicPath;
        
        public ResourcesData resourcesData;
		private Config Config;

        public EditInvItemControl(string selectedInvItem)
        {
            //resourcesData = new ResourcesData();
            InitializeComponent();
            Config = new Config();
            InitializeControl(selectedInvItem);
        }

        private void InitializeControl(string selectInvItem)
        {
            if (selectInvItem != "qweewqqq")
            {
                string invFilename = Config.InventoryPath + "\\inventory.xml";
                string resFilename = Config.InventoryPath + "\\resources.xml";
                string filepath = Config.InventoryPath + "\\textures\\";

                resourcesData = new ResourcesData(Config.InventoryPath + "\\resources.xml");
                
                XmlDocument resDoc, invDoc;
                XmlElement invRoot;
                
                XmlNode textName = GetInvItemNodeInTextsXMLByName(selectInvItem);
                textBoxGameItemName.Text = textName.Attributes["text"].Value;
                _oldItemGameName = textName.Attributes["text"].Value;
                if (File.Exists(invFilename))
                {
                    invDoc = new XmlDocument();
                    invDoc.Load(invFilename);
                    invRoot = (XmlElement)invDoc.SelectSingleNode("inventory");
                    XmlNode invItemNode = (XmlElement)invDoc.SelectSingleNode("inventory/" + selectInvItem);

                    if (invItemNode != null)
                    {
                        resDoc = new XmlDocument();
                        resDoc.Load(resFilename);

                        XmlElement resRoot = (XmlElement)resDoc.SelectSingleNode("inventory/items");
                        XmlElement resNode = (XmlElement)resRoot.FirstChild;

                        //   _inventory.Add(itemInvNode.Name);
                        string attText = invItemNode.Attributes["shader"].Value;
                        XmlNode test = resDoc.SelectSingleNode(AttString(attText, '/'));
                        XmlNodeList resTestSmall = resDoc.SelectNodes("inventory/items/shader[@name='" + AttString(attText, '/') + "']");
                        XmlNodeList resTestBig = resDoc.SelectNodes("inventory/items/shader[@name='" + AttString(attText, '/') + "_big" + "']");
                        if ((resTestSmall.Count > 0) && (resTestBig.Count > 0))
                        {
                            string resTextureNameSmall = AttString(resTestSmall[0].Attributes["texture_name"].Value, '\\');
                            string resTexturePathAndNameSmall = resTestSmall[0].Attributes["texture_name"].Value;

                            string resTextureNameBig = AttString(resTestBig[0].Attributes["texture_name"].Value, '\\');
                            string resTexturePathAndNameBig = resTestBig[0].Attributes["texture_name"].Value;

                            string filename = resTexturePathAndNameSmall + ".png";

                            string itemName = invItemNode.Name;

                            string shaderName = resTextureNameSmall;
                            
                            string smallpicFilePath = filepath + filename;
                            string smallpicName = resTexturePathAndNameSmall;
                            PictureBox pb1 = new PictureBox();
                            Image loadedImage = Image.FromFile(Config.InventoryPath + "\\" + filename);
                            pb1.Height = loadedImage.Height;
                            pb1.Width = loadedImage.Width;
                            pb1.Image = loadedImage;
                            flowLayoutPanel1.Controls.Add(pb1);

                            string bigpicFilePath = resTexturePathAndNameBig + ".png";
                            string bigpicName = resTexturePathAndNameBig;
                            PictureBox pb2 = new PictureBox();
                            Image loadedImage2 = Image.FromFile(Config.InventoryPath + "\\" + bigpicFilePath);
                            pb2.Height = loadedImage2.Height;
                            pb2.Width = loadedImage2.Width;
                            pb2.Image = loadedImage2;
                            flowLayoutPanel2.Controls.Add(pb2);

                            textBoxSmallPicFilePath.Text = smallpicName;
                            textBoxBigPicFilePath.Text = bigpicName;
                            textBoxEditItem.Text = itemName;

                            _oldItemNodeName = itemName;
                            _oldSmallPicPath = smallpicName;
                            _oldBigPicPath = bigpicName;
                        }

                    }
                }
            }
        }

        private XmlNode GetInvItemNodeInTextsXMLByName(string nodeName)
        {
            XmlDocument textDocXML;
            string textFilenameNewItem = Config.TextsPath + "\\texts.xml";

            textDocXML = new XmlDocument();
            textDocXML.Load(textFilenameNewItem);

            XmlNode textInvItemNode = (XmlNode)textDocXML.SelectSingleNode("texts/gameplay/inventory_items/" + nodeName);
            if (textInvItemNode != null)
            {
                return textInvItemNode;
            }
            return null;
        }

        private string AttString(string attName, char spliter)
        {
            string attSubString;
            attSubString = attName.Substring(attName.LastIndexOf(spliter) + 1);
            return attSubString;
        }

        private void button5EditItem_Click(object sender, EventArgs e)
        {
            DialogResult resultCheckChanges = System.Windows.Forms.MessageBox.Show("Are sure that you want to change this inventory Item?", "Editing confirmation!", MessageBoxButtons.OKCancel);
            if (resultCheckChanges == DialogResult.OK)
            {
                string addItemBoxText = textBoxEditItem.Text;
                string inventoryNodeName = addItemBoxText;

                if ((addItemBoxText != String.Empty) && (textBoxSmallPicFilePath.Text != String.Empty) && (textBoxBigPicFilePath.Text != String.Empty) && (textBoxGameItemName.Text != String.Empty))
                {
                    if (textBoxBigPicFilePath.Text == textBoxSmallPicFilePath.Text + "_big")
                    {
                        EditInvItemInTextsXML();
                        EditInvItemInInventoryXML(addItemBoxText, textBoxSmallPicFilePath.Text);
                        EditInvItemInResourcesXML(addItemBoxText, textBoxSmallPicFilePath.Text, textBoxBigPicFilePath.Text);
                    }
                    else { System.Windows.Forms.MessageBox.Show("Difference between small and big pictures must be in '_big' only!"); }
                }
                else { System.Windows.Forms.MessageBox.Show("Please fill in all fields!"); }
            }
            
        }

        private void EditInvItemInTextsXML()
        {
           // XmlNode textName = GetInvItemNodeInTextsXMLByName(textBoxEditItem.Name);

            XmlDocument textDocXML;
            string textFilenameNewItem = Config.TextsPath + "\\texts.xml";

            textDocXML = new XmlDocument();
            textDocXML.Load(textFilenameNewItem);

            XmlNode textInvItemNode = (XmlNode)textDocXML.SelectSingleNode("texts/gameplay/inventory_items");

            XmlNode oldTextInvItemNode = (XmlNode)textDocXML.SelectSingleNode("texts/gameplay/inventory_items/" + _oldItemNodeName);
            //oldTextInvItemNode.RemoveAll();
            textInvItemNode.RemoveChild(oldTextInvItemNode);
            
            XmlElement addInvItemNodeTextsXml = textDocXML.CreateElement(textBoxEditItem.Text);
            addInvItemNodeTextsXml.SetAttribute("text", textBoxGameItemName.Text);
            textInvItemNode.AppendChild(addInvItemNodeTextsXml);
            textDocXML.Save(textFilenameNewItem);
        }

        private void EditInvItemInInventoryXML(string itemName, string smallPicName)
        {
            XmlDocument inventoryDocXML;
            XmlElement inventoryRootXML;

            string invFilenameNewItem = Config.BinPath + "data\\gameplay\\main\\inventory\\inventory.xml";

            string inventoryNodeName = itemName;

            inventoryDocXML = new XmlDocument();
            inventoryDocXML.Load(invFilenameNewItem);
            inventoryRootXML = (XmlElement)inventoryDocXML.SelectSingleNode("inventory");

            XmlNode oldInvItemNode = (XmlNode)inventoryDocXML.SelectSingleNode("inventory/" + _oldItemNodeName);
            //oldTextInvItemNode.RemoveAll();
            inventoryRootXML.RemoveChild(oldInvItemNode);
            
            XmlElement addInvItemNodeInventoryXml = inventoryDocXML.CreateElement(inventoryNodeName);
            addInvItemNodeInventoryXml.SetAttribute("full_name", "puzzl_on_the_bed/" + itemName);
            addInvItemNodeInventoryXml.SetAttribute("shader", "inventory/items/" + itemName);
            inventoryRootXML.AppendChild(addInvItemNodeInventoryXml);
            inventoryDocXML.Save(invFilenameNewItem);
            textBoxEditItem.Text = "";
            
        }

        private void EditInvItemInResourcesXML(string itemName, string smallPicName, string bigPicName)
        {
            XmlDocument resDocXml;
            XmlElement resRootXml;

            string resFilenameNewItem = Config.BinPath + "data\\gameplay\\main\\inventory\\resources.xml";

            string inventoryNodeName = itemName;

            //---ResourcesXML----------------------------------

            resDocXml = new XmlDocument();
            resDocXml.Load(resFilenameNewItem);
            resRootXml = (XmlElement)resDocXml.SelectSingleNode("inventory/items");


            XmlNode oldInvItemNodeSmallPic = (XmlNode)resDocXml.SelectSingleNode("inventory/items/shader[@name='" + itemName + "']");
            XmlNode oldInvItemNodeBigPic = (XmlNode)resDocXml.SelectSingleNode("inventory/items/shader[@name='" + itemName + "_big" + "']");
            //oldTextInvItemNode.RemoveAll();
            resRootXml.RemoveChild(oldInvItemNodeSmallPic);
            resRootXml.RemoveChild(oldInvItemNodeBigPic);
            //     XmlNodeList levelSubNode = _levelsDocXml.SelectNodes("levels/stage/level/subscreens/" + listBoxLevelsPlace + "[@scene_folder='" + listBoxLevelsPlace + "']");


            XmlElement addInvItemNodeResXml = resDocXml.CreateElement("shader");
            addInvItemNodeResXml.SetAttribute("name", itemName);
            addInvItemNodeResXml.SetAttribute("texture_name", smallPicName);
            addInvItemNodeResXml.SetAttribute("temporary_textures", "1");
            resRootXml.AppendChild(addInvItemNodeResXml);
            resDocXml.Save(resFilenameNewItem);

            XmlElement addInvItemNodeResXmlBig = resDocXml.CreateElement("shader");
            addInvItemNodeResXmlBig.SetAttribute("name", itemName + "_big");
            addInvItemNodeResXmlBig.SetAttribute("texture_name", bigPicName);
            addInvItemNodeResXmlBig.SetAttribute("temporary_textures", "1");
            resRootXml.AppendChild(addInvItemNodeResXmlBig);
            resDocXml.Save(resFilenameNewItem);


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

                    string fullFileName = openFileDialogPic.FileName;
                    int texturesIndex = fullFileName.IndexOf("textures");
                    int newFullFileNameLength = fullFileName.Length - 4 - texturesIndex;
                    string fileName = fullFileName.Substring(texturesIndex, newFullFileNameLength);

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

                    string fullFileName = openFileDialogPic.FileName;
                    int texturesIndex = fullFileName.IndexOf("textures");
                    int newFullFileNameLength = fullFileName.Length - 4 - texturesIndex;
                    string fileName = fullFileName.Substring(texturesIndex, newFullFileNameLength);
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
