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

        string _oldItemNodeName;
        string _oldItemGameName;
        string _oldSmallPicPath;
        string _oldBigPicPath;

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
            Tools.TryToLoad(textDocXML, textFilenameNewItem);
           //textDocXML.Load(textFilenameNewItem);

            foreach (InventoryItem invItem in inventories.IntentoryItems)
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

        private void SelectSmallPic(FlowLayoutPanel flowLayoutPanel, TextBox textBox)
        {
            DialogResult dr = this.openFileDialogPic.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                string file = openFileDialogPic.FileName;
                try
                {
                    flowLayoutPanel.Controls.Clear();
                    PictureBox pb = new PictureBox();
                    Image loadedImage = Image.FromFile(file);
                    pb.Height = loadedImage.Height;
                    pb.Width = loadedImage.Width;
                    pb.Image = loadedImage;
                    flowLayoutPanel.Controls.Add(pb);

                    string fullFileName = openFileDialogPic.SafeFileName;
                    string fileName = fullFileName.Substring(0, fullFileName.Length - 4);
                    textBox.Text = fileName;

                    if ((pb.Height != 64) && (pb.Width != 64))
                    {
                        textBox.Text = String.Empty;
                        DialogResult resultSmallSizeError = System.Windows.Forms.MessageBox.Show("Picture size must be 64 x 64! Select image without '_big'!" + "\n\n" +
                            "Do you want re-select image?", "Error! Incorrect pictures size", MessageBoxButtons.OKCancel);
                        if (resultSmallSizeError == DialogResult.OK)
                        {
                            SelectSmallPic(flowLayoutPanel, textBox);
                        }
                    }
                }
                catch (Exception ex)
                {
                    textBox.Text = String.Empty;

                    MessageBox.Show("Cannot select the image: " + file.Substring(file.LastIndexOf('\\') + 1)
                        + ". You may not have permission to read the file, or " +
                        "it may be corrupt.\n\nReported error: " + ex.Message);
                }
            }
        }

        private void SelectBigPic(FlowLayoutPanel flowLayoutPanel, TextBox textBox)
        {
            DialogResult dr = this.openFileDialogPic.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                string file = openFileDialogPic.FileName;
                try
                {
                    flowLayoutPanel.Controls.Clear();
                    PictureBox pb = new PictureBox();
                    Image loadedImage = Image.FromFile(file);
                    pb.Height = loadedImage.Height;
                    pb.Width = loadedImage.Width;
                    pb.Image = loadedImage;
                    flowLayoutPanel.Controls.Add(pb);

                    string fullFileName = openFileDialogPic.SafeFileName;
                    string fileName = fullFileName.Substring(0, fullFileName.Length - 4);
                    textBox.Text = fileName;

                    if ((pb.Height != 256) && (pb.Width != 256))
                    {
                        textBox.Text = String.Empty;
                        DialogResult resultSmallSizeError = System.Windows.Forms.MessageBox.Show("Picture size must be 256 x 256! Select image with '_big'!" + "\n\n" +
                            "Do you want re-select image?", "Error! Incorrect pictures size", MessageBoxButtons.OKCancel);
                        if (resultSmallSizeError == DialogResult.OK)
                        {
                            SelectBigPic(flowLayoutPanel, textBox);
                        }
                    }
                }
                catch (Exception ex)
                {
                    textBox.Text = String.Empty;

                    MessageBox.Show("Cannot select the image: " + file.Substring(file.LastIndexOf('\\') + 1)
                        + ". You may not have permission to read the file, or " +
                        "it may be corrupt.\n\nReported error: " + ex.Message);
                }
            }
        }

        private void buttonSelectAddSmallPic_Click(object sender, EventArgs e)
        {
            SelectSmallPic(flowLayoutPanel4, textBoxSmallAddPicFilePath);
        }

        private void buttonSelectAddBigPic_Click(object sender, EventArgs e)
        {
            SelectBigPic(flowLayoutPanel3, textBoxBigAddPicFilePath);
        }

        private void buttonSelectSmallPic_Click(object sender, EventArgs e)
        {
            SelectSmallPic(flowLayoutPanel1, textBoxSmallPicFilePath);
        }

        private void buttonSelectBigPic_Click(object sender, EventArgs e)
        {
            SelectBigPic(flowLayoutPanel2, textBoxBigPicFilePath);
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

        private void buttonAddNewItem_Click(object sender, EventArgs e)
        {
            textBoxSearch.Text = String.Empty;
            AddItemsToXmlFile();
        }

        private void AddItemsToXmlFile()
        {
            string addItemBoxText = textBoxAddNewItem.Text;
            string inventoryNodeName = addItemBoxText;

            if ((addItemBoxText != String.Empty) && (textBoxSmallAddPicFilePath.Text != String.Empty) && (textBoxBigAddPicFilePath.Text != String.Empty) && (textBoxGameAddItemName.Text != String.Empty))
            {
                if (textBoxBigAddPicFilePath.Text == textBoxSmallAddPicFilePath.Text + "_big")
                {
                    AddToTexlXML(addItemBoxText, textBoxGameAddItemName.Text);
                    AddToInventoryXML(addItemBoxText, textBoxSmallAddPicFilePath.Text);
                    AddToResourcesXML(addItemBoxText, textBoxSmallAddPicFilePath.Text, textBoxBigAddPicFilePath.Text);
                }
                else { System.Windows.Forms.MessageBox.Show("Difference between small and big pictures must be in '_big' only!"); }
            }
            else { System.Windows.Forms.MessageBox.Show("Please fill in all fields!"); }
        }

        private void buttonEditItem_Click(object sender, EventArgs e)
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


        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                FillEditControl();
            }
        }

#region Add new item to XML files

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

#endregion

#region Edit item in XML files

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

            string invFilenameNewItem = Config.InventoryPath + "\\inventory.xml";
            
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

            string resFilenameNewItem = Config.InventoryPath + "\\resources.xml";

            string inventoryNodeName = itemName;

            //---ResourcesXML----------------------------------

            resDocXml = new XmlDocument();
            resDocXml.Load(resFilenameNewItem);
            resRootXml = (XmlElement)resDocXml.SelectSingleNode("inventory/items");


            XmlNode oldInvItemNodeSmallPic = (XmlNode)resDocXml.SelectSingleNode("inventory/items/shader[@name='" + _oldItemNodeName + "']");
            XmlNode oldInvItemNodeBigPic = (XmlNode)resDocXml.SelectSingleNode("inventory/items/shader[@name='" + _oldItemNodeName + "_big" + "']");
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

#endregion

        private void FillEditControl()
        {
            if (listView1.SelectedItems.Count != 0)
            {
                string[] nameArr = listView1.SelectedItems[0].SubItems[1].Text.Split('\n');

                string selectedInvItem = nameArr[0];

                if (nameArr.Length > 1)
                {
                    string itemGameName = nameArr[1].Replace("\"", "").Replace("(", "").Replace(")", "");
                    textBoxGameItemName.Text = itemGameName;
                }
                else
                {
                    MessageBox.Show("Inventory item didn't described in texts.xml");
                }
                
                InventoryItem invItem = inventories.GetInventoryItemByName(selectedInvItem);
                textBoxEditItem.Text = invItem.Name;

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
                
                string smallPicName = smallPicPathWithoutExt.Substring(smallPicPathWithoutExt.LastIndexOf('\\') + 1);
                string bigPicName = smallPicName + "_big";

                Image loadedImage2 = Image.FromFile(bigPicPath);
                pb2.Height = loadedImage2.Height;
                pb2.Width = loadedImage2.Width;
                pb2.Image = loadedImage2;
                pb2.Refresh();
                flowLayoutPanel2.Controls.Add(pb2);

                textBoxSmallPicFilePath.Text = smallPicName;
                textBoxBigPicFilePath.Text = bigPicName;

                _oldItemNodeName = invItem.Name;
                _oldSmallPicPath = smallPicName;
                _oldBigPicPath = bigPicName;
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                FillEditControl();
            }
        }

        private void textBoxEditItem_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBoxAddNewItem_TextChanged(object sender, EventArgs e)
        {
            string addItemBoxText = textBoxAddNewItem.Text;

            if (addItemBoxText != String.Empty)
            {
                buttonAddNewItem.Enabled = true;
            }
            else
            {
                buttonAddNewItem.Enabled = false;
            }
        }

        

        

        

    }
}
