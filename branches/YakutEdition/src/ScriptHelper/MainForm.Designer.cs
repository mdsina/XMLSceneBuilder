namespace WindowsFormsApplication2
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAddChoosenItemsToInventory = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.selectedList = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.buttonDeleteSearch = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonAddNewItem = new System.Windows.Forms.Button();
            this.buttonEditInvItem = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.listViewSubs = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStripSubs = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddSubToScenePlayer = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenSubXMLFile = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenSubScriptFile = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenSubResourcesFile = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateShaderSubsToolSprip = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.shaderSubViewerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxServiceFunctions = new System.Windows.Forms.GroupBox();
            this.buttonTextUv = new System.Windows.Forms.Button();
            this.buttonGetScenesPositions = new System.Windows.Forms.Button();
            this.buttonOpenLevelsXML = new System.Windows.Forms.Button();
            this.buttonOpenInventoryXML = new System.Windows.Forms.Button();
            this.buttonCreateTestScene = new System.Windows.Forms.Button();
            this.buttonOpenTextsXML = new System.Windows.Forms.Button();
            this.buttonCheckAllResources = new System.Windows.Forms.Button();
            this.buttonDiary = new System.Windows.Forms.Button();
            this.listViewLevels = new System.Windows.Forms.ListView();
            this.columnHeaderLevels = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuEditScene = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddToScenePlayer = new System.Windows.Forms.ToolStripMenuItem();
            this.AddSceneToStartLocation = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenSceneXMLFile = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenSceneScriptFile = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenSceneResourcesFile = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateShaderToolSprip = new System.Windows.Forms.ToolStripMenuItem();
            this.openSceneFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inExplorerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inTotalcmdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shaderViewerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkBoxDeleteProfile = new System.Windows.Forms.CheckBox();
            this.checkBoxLoadSceneWithAllInvItems = new System.Windows.Forms.CheckBox();
            this.checkBoxHideToTray = new System.Windows.Forms.CheckBox();
            this.checkBoxSkipMenus = new System.Windows.Forms.CheckBox();
            this.labelCheckScenePlayer = new System.Windows.Forms.Label();
            this.buttonUnCheckAll = new System.Windows.Forms.Button();
            this.buttonCheckItem = new System.Windows.Forms.Button();
            this.buttonUncheckItem = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.buttonRunDelProf = new System.Windows.Forms.Button();
            this.buttonRunKA = new System.Windows.Forms.Button();
            this.buttonGetItemsFromScene = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this._notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.openFileDialogExeFileName = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.indexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuStripSubs.SuspendLayout();
            this.groupBoxServiceFunctions.SuspendLayout();
            this.contextMenuEditScene.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chosen Inventory Items";
            // 
            // buttonAddChoosenItemsToInventory
            // 
            this.buttonAddChoosenItemsToInventory.Location = new System.Drawing.Point(52, 390);
            this.buttonAddChoosenItemsToInventory.Name = "buttonAddChoosenItemsToInventory";
            this.buttonAddChoosenItemsToInventory.Size = new System.Drawing.Size(169, 35);
            this.buttonAddChoosenItemsToInventory.TabIndex = 2;
            this.buttonAddChoosenItemsToInventory.Text = "Add chosen Items To current game inventory";
            this.buttonAddChoosenItemsToInventory.UseVisualStyleBackColor = true;
            this.buttonAddChoosenItemsToInventory.Click += new System.EventHandler(this.buttonAddChoosenItemsToInventory_Click);
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.LargeImageList = this.imageList1;
            this.listView1.Location = new System.Drawing.Point(6, 32);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(278, 549);
            this.listView1.SmallImageList = this.imageList1;
            this.listView1.TabIndex = 5;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Picture";
            this.columnHeader1.Width = 85;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Inventory Item Name";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Parts";
            this.columnHeader3.Width = 150;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(64, 64);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // selectedList
            // 
            this.selectedList.FormattingEnabled = true;
            this.selectedList.Location = new System.Drawing.Point(51, 28);
            this.selectedList.Name = "selectedList";
            this.selectedList.Size = new System.Drawing.Size(169, 329);
            this.selectedList.TabIndex = 6;
            this.selectedList.DoubleClick += new System.EventHandler(this.selectedList_DoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 370);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 9;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 27);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.buttonDeleteSearch);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.textBox1);
            this.splitContainer1.Panel1.Controls.Add(this.listView1);
            this.splitContainer1.Panel1.Controls.Add(this.buttonAddNewItem);
            this.splitContainer1.Panel1.Controls.Add(this.buttonEditInvItem);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.listViewSubs);
            this.splitContainer1.Panel2.Controls.Add(this.groupBoxServiceFunctions);
            this.splitContainer1.Panel2.Controls.Add(this.listViewLevels);
            this.splitContainer1.Panel2.Controls.Add(this.checkBoxDeleteProfile);
            this.splitContainer1.Panel2.Controls.Add(this.checkBoxLoadSceneWithAllInvItems);
            this.splitContainer1.Panel2.Controls.Add(this.checkBoxHideToTray);
            this.splitContainer1.Panel2.Controls.Add(this.checkBoxSkipMenus);
            this.splitContainer1.Panel2.Controls.Add(this.labelCheckScenePlayer);
            this.splitContainer1.Panel2.Controls.Add(this.buttonUnCheckAll);
            this.splitContainer1.Panel2.Controls.Add(this.buttonCheckItem);
            this.splitContainer1.Panel2.Controls.Add(this.buttonUncheckItem);
            this.splitContainer1.Panel2.Controls.Add(this.button5);
            this.splitContainer1.Panel2.Controls.Add(this.buttonRunDelProf);
            this.splitContainer1.Panel2.Controls.Add(this.buttonRunKA);
            this.splitContainer1.Panel2.Controls.Add(this.buttonGetItemsFromScene);
            this.splitContainer1.Panel2.Controls.Add(this.label7);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.selectedList);
            this.splitContainer1.Panel2.Controls.Add(this.buttonAddChoosenItemsToInventory);
            this.splitContainer1.Size = new System.Drawing.Size(1300, 624);
            this.splitContainer1.SplitterDistance = 287;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 10;
            // 
            // buttonDeleteSearch
            // 
            this.buttonDeleteSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDeleteSearch.Location = new System.Drawing.Point(236, 6);
            this.buttonDeleteSearch.Name = "buttonDeleteSearch";
            this.buttonDeleteSearch.Size = new System.Drawing.Size(38, 20);
            this.buttonDeleteSearch.TabIndex = 44;
            this.buttonDeleteSearch.Text = "X";
            this.buttonDeleteSearch.UseVisualStyleBackColor = true;
            this.buttonDeleteSearch.Click += new System.EventHandler(this.buttonDeleteSearch_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Search";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(50, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(180, 20);
            this.textBox1.TabIndex = 10;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // buttonAddNewItem
            // 
            this.buttonAddNewItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAddNewItem.Location = new System.Drawing.Point(12, 596);
            this.buttonAddNewItem.Name = "buttonAddNewItem";
            this.buttonAddNewItem.Size = new System.Drawing.Size(85, 23);
            this.buttonAddNewItem.TabIndex = 39;
            this.buttonAddNewItem.Text = "Add New InvItem";
            this.buttonAddNewItem.UseVisualStyleBackColor = true;
            this.buttonAddNewItem.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonEditInvItem
            // 
            this.buttonEditInvItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEditInvItem.Location = new System.Drawing.Point(198, 596);
            this.buttonEditInvItem.Name = "buttonEditInvItem";
            this.buttonEditInvItem.Size = new System.Drawing.Size(76, 23);
            this.buttonEditInvItem.TabIndex = 40;
            this.buttonEditInvItem.Text = "Edit InvItem";
            this.buttonEditInvItem.UseVisualStyleBackColor = true;
            this.buttonEditInvItem.Click += new System.EventHandler(this.buttonEditInvItem_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(608, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 13);
            this.label3.TabIndex = 47;
            this.label3.Text = "Subs and minigames";
            // 
            // listViewSubs
            // 
            this.listViewSubs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4});
            this.listViewSubs.ContextMenuStrip = this.contextMenuStripSubs;
            this.listViewSubs.FullRowSelect = true;
            this.listViewSubs.GridLines = true;
            this.listViewSubs.HideSelection = false;
            this.listViewSubs.Location = new System.Drawing.Point(611, 27);
            this.listViewSubs.MultiSelect = false;
            this.listViewSubs.Name = "listViewSubs";
            this.listViewSubs.Size = new System.Drawing.Size(282, 330);
            this.listViewSubs.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listViewSubs.TabIndex = 46;
            this.listViewSubs.UseCompatibleStateImageBehavior = false;
            this.listViewSubs.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Scenes";
            this.columnHeader4.Width = 282;
            // 
            // contextMenuStripSubs
            // 
            this.contextMenuStripSubs.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddSubToScenePlayer,
            this.OpenSubXMLFile,
            this.OpenSubScriptFile,
            this.OpenSubResourcesFile,
            this.CreateShaderSubsToolSprip,
            this.toolStripMenuItem7,
            this.shaderSubViewerToolStripMenuItem});
            this.contextMenuStripSubs.Name = "contextMenuEditScene";
            this.contextMenuStripSubs.Size = new System.Drawing.Size(298, 158);
            // 
            // AddSubToScenePlayer
            // 
            this.AddSubToScenePlayer.Name = "AddSubToScenePlayer";
            this.AddSubToScenePlayer.Size = new System.Drawing.Size(297, 22);
            this.AddSubToScenePlayer.Text = "Add scene to ScenePlayer";
            this.AddSubToScenePlayer.Click += new System.EventHandler(this.AddSubToScenePlayer_Click);
            // 
            // OpenSubXMLFile
            // 
            this.OpenSubXMLFile.Name = "OpenSubXMLFile";
            this.OpenSubXMLFile.Size = new System.Drawing.Size(297, 22);
            this.OpenSubXMLFile.Text = "Open scene XML file";
            this.OpenSubXMLFile.Click += new System.EventHandler(this.OpenSubXMLFile_Click);
            // 
            // OpenSubScriptFile
            // 
            this.OpenSubScriptFile.Name = "OpenSubScriptFile";
            this.OpenSubScriptFile.Size = new System.Drawing.Size(297, 22);
            this.OpenSubScriptFile.Text = "Open scene script file";
            this.OpenSubScriptFile.Click += new System.EventHandler(this.OpenSubScriptFile_Click);
            // 
            // OpenSubResourcesFile
            // 
            this.OpenSubResourcesFile.Name = "OpenSubResourcesFile";
            this.OpenSubResourcesFile.Size = new System.Drawing.Size(297, 22);
            this.OpenSubResourcesFile.Text = "Open scene resourses file";
            this.OpenSubResourcesFile.Click += new System.EventHandler(this.OpenSubResourcesFile_Click);
            // 
            // CreateShaderSubsToolSprip
            // 
            this.CreateShaderSubsToolSprip.Name = "CreateShaderSubsToolSprip";
            this.CreateShaderSubsToolSprip.Size = new System.Drawing.Size(297, 22);
            this.CreateShaderSubsToolSprip.Text = "Create shader and animations, layer ,maps";
            this.CreateShaderSubsToolSprip.Click += new System.EventHandler(this.CreateShaderSubsToolSprip_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem8,
            this.toolStripMenuItem9});
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(297, 22);
            this.toolStripMenuItem7.Text = "Open scene folder";
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(138, 22);
            this.toolStripMenuItem8.Text = "In explorer";
            this.toolStripMenuItem8.Click += new System.EventHandler(this.toolStripMenuItem8_Click);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Enabled = false;
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(138, 22);
            this.toolStripMenuItem9.Text = "In Totalcmd";
            // 
            // shaderSubViewerToolStripMenuItem
            // 
            this.shaderSubViewerToolStripMenuItem.Name = "shaderSubViewerToolStripMenuItem";
            this.shaderSubViewerToolStripMenuItem.Size = new System.Drawing.Size(297, 22);
            this.shaderSubViewerToolStripMenuItem.Text = "Shader Viewer";
            this.shaderSubViewerToolStripMenuItem.Click += new System.EventHandler(this.shaderSubViewerToolStripMenuItem_Click);
            // 
            // groupBoxServiceFunctions
            // 
            this.groupBoxServiceFunctions.Controls.Add(this.buttonTextUv);
            this.groupBoxServiceFunctions.Controls.Add(this.buttonGetScenesPositions);
            this.groupBoxServiceFunctions.Controls.Add(this.buttonOpenLevelsXML);
            this.groupBoxServiceFunctions.Controls.Add(this.buttonOpenInventoryXML);
            this.groupBoxServiceFunctions.Controls.Add(this.buttonCreateTestScene);
            this.groupBoxServiceFunctions.Controls.Add(this.buttonOpenTextsXML);
            this.groupBoxServiceFunctions.Controls.Add(this.buttonCheckAllResources);
            this.groupBoxServiceFunctions.Controls.Add(this.buttonDiary);
            this.groupBoxServiceFunctions.Location = new System.Drawing.Point(51, 474);
            this.groupBoxServiceFunctions.Name = "groupBoxServiceFunctions";
            this.groupBoxServiceFunctions.Size = new System.Drawing.Size(297, 144);
            this.groupBoxServiceFunctions.TabIndex = 45;
            this.groupBoxServiceFunctions.TabStop = false;
            this.groupBoxServiceFunctions.Text = "Service functions";
            // 
            // buttonTextUv
            // 
            this.buttonTextUv.Location = new System.Drawing.Point(226, 82);
            this.buttonTextUv.Name = "buttonTextUv";
            this.buttonTextUv.Size = new System.Drawing.Size(66, 49);
            this.buttonTextUv.TabIndex = 45;
            this.buttonTextUv.Text = "Text uv";
            this.buttonTextUv.UseVisualStyleBackColor = true;
            this.buttonTextUv.Click += new System.EventHandler(this.buttonTextUv_Click);
            // 
            // buttonGetScenesPositions
            // 
            this.buttonGetScenesPositions.Location = new System.Drawing.Point(225, 19);
            this.buttonGetScenesPositions.Name = "buttonGetScenesPositions";
            this.buttonGetScenesPositions.Size = new System.Drawing.Size(66, 49);
            this.buttonGetScenesPositions.TabIndex = 44;
            this.buttonGetScenesPositions.Text = "Get Scene Position";
            this.buttonGetScenesPositions.UseVisualStyleBackColor = true;
            this.buttonGetScenesPositions.Click += new System.EventHandler(this.buttonGetScenesPositions_Click);
            // 
            // buttonOpenLevelsXML
            // 
            this.buttonOpenLevelsXML.Location = new System.Drawing.Point(6, 19);
            this.buttonOpenLevelsXML.Name = "buttonOpenLevelsXML";
            this.buttonOpenLevelsXML.Size = new System.Drawing.Size(104, 26);
            this.buttonOpenLevelsXML.TabIndex = 30;
            this.buttonOpenLevelsXML.Text = "Open Levels.xml";
            this.buttonOpenLevelsXML.UseVisualStyleBackColor = true;
            this.buttonOpenLevelsXML.Click += new System.EventHandler(this.buttonOpenLevelsXML_Click);
            // 
            // buttonOpenInventoryXML
            // 
            this.buttonOpenInventoryXML.Location = new System.Drawing.Point(6, 51);
            this.buttonOpenInventoryXML.Name = "buttonOpenInventoryXML";
            this.buttonOpenInventoryXML.Size = new System.Drawing.Size(104, 49);
            this.buttonOpenInventoryXML.TabIndex = 31;
            this.buttonOpenInventoryXML.Text = "Open inventory and resources";
            this.buttonOpenInventoryXML.UseVisualStyleBackColor = true;
            this.buttonOpenInventoryXML.Click += new System.EventHandler(this.buttonOpenInventoryXML_Click);
            // 
            // buttonCreateTestScene
            // 
            this.buttonCreateTestScene.Location = new System.Drawing.Point(116, 106);
            this.buttonCreateTestScene.Name = "buttonCreateTestScene";
            this.buttonCreateTestScene.Size = new System.Drawing.Size(104, 25);
            this.buttonCreateTestScene.TabIndex = 43;
            this.buttonCreateTestScene.Text = "Create test scene";
            this.buttonCreateTestScene.UseVisualStyleBackColor = true;
            this.buttonCreateTestScene.Click += new System.EventHandler(this.buttonCreateTestScene_Click);
            // 
            // buttonOpenTextsXML
            // 
            this.buttonOpenTextsXML.Location = new System.Drawing.Point(6, 106);
            this.buttonOpenTextsXML.Name = "buttonOpenTextsXML";
            this.buttonOpenTextsXML.Size = new System.Drawing.Size(104, 26);
            this.buttonOpenTextsXML.TabIndex = 34;
            this.buttonOpenTextsXML.Text = "Open Texts.xml";
            this.buttonOpenTextsXML.UseVisualStyleBackColor = true;
            this.buttonOpenTextsXML.Click += new System.EventHandler(this.buttonOpenTextsXML_Click);
            // 
            // buttonCheckAllResources
            // 
            this.buttonCheckAllResources.Location = new System.Drawing.Point(116, 51);
            this.buttonCheckAllResources.Name = "buttonCheckAllResources";
            this.buttonCheckAllResources.Size = new System.Drawing.Size(104, 49);
            this.buttonCheckAllResources.TabIndex = 33;
            this.buttonCheckAllResources.Text = "Check all recources";
            this.buttonCheckAllResources.UseVisualStyleBackColor = true;
            this.buttonCheckAllResources.Click += new System.EventHandler(this.buttonCheckAllResources_Click);
            // 
            // buttonDiary
            // 
            this.buttonDiary.Location = new System.Drawing.Point(116, 19);
            this.buttonDiary.Name = "buttonDiary";
            this.buttonDiary.Size = new System.Drawing.Size(104, 25);
            this.buttonDiary.TabIndex = 32;
            this.buttonDiary.Text = "Diary";
            this.buttonDiary.UseVisualStyleBackColor = true;
            this.buttonDiary.Click += new System.EventHandler(this.buttonDiary_Click);
            // 
            // listViewLevels
            // 
            this.listViewLevels.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderLevels});
            this.listViewLevels.ContextMenuStrip = this.contextMenuEditScene;
            this.listViewLevels.FullRowSelect = true;
            this.listViewLevels.GridLines = true;
            this.listViewLevels.HideSelection = false;
            this.listViewLevels.Location = new System.Drawing.Point(312, 28);
            this.listViewLevels.MultiSelect = false;
            this.listViewLevels.Name = "listViewLevels";
            this.listViewLevels.Size = new System.Drawing.Size(282, 330);
            this.listViewLevels.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listViewLevels.TabIndex = 44;
            this.listViewLevels.UseCompatibleStateImageBehavior = false;
            this.listViewLevels.View = System.Windows.Forms.View.Details;
            this.listViewLevels.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listViewLevels_ItemSelectionChanged);
            this.listViewLevels.DoubleClick += new System.EventHandler(this.listViewLevels_DoubleClick);
            // 
            // columnHeaderLevels
            // 
            this.columnHeaderLevels.Text = "Scenes";
            this.columnHeaderLevels.Width = 282;
            // 
            // contextMenuEditScene
            // 
            this.contextMenuEditScene.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddToScenePlayer,
            this.AddSceneToStartLocation,
            this.OpenSceneXMLFile,
            this.OpenSceneScriptFile,
            this.OpenSceneResourcesFile,
            this.CreateShaderToolSprip,
            this.openSceneFolderToolStripMenuItem,
            this.shaderViewerToolStripMenuItem});
            this.contextMenuEditScene.Name = "contextMenuEditScene";
            this.contextMenuEditScene.Size = new System.Drawing.Size(298, 180);
            // 
            // AddToScenePlayer
            // 
            this.AddToScenePlayer.Name = "AddToScenePlayer";
            this.AddToScenePlayer.Size = new System.Drawing.Size(297, 22);
            this.AddToScenePlayer.Text = "Add scene to ScenePlayer";
            this.AddToScenePlayer.Click += new System.EventHandler(this.AddToScenePlayer_Click);
            // 
            // AddSceneToStartLocation
            // 
            this.AddSceneToStartLocation.Name = "AddSceneToStartLocation";
            this.AddSceneToStartLocation.Size = new System.Drawing.Size(297, 22);
            this.AddSceneToStartLocation.Text = "Add scene to start_location.txt";
            this.AddSceneToStartLocation.Click += new System.EventHandler(this.AddSceneToStartLocation_Click);
            // 
            // OpenSceneXMLFile
            // 
            this.OpenSceneXMLFile.Name = "OpenSceneXMLFile";
            this.OpenSceneXMLFile.Size = new System.Drawing.Size(297, 22);
            this.OpenSceneXMLFile.Text = "Open scene XML file";
            this.OpenSceneXMLFile.Click += new System.EventHandler(this.OpenSceneXMLFile_Click);
            // 
            // OpenSceneScriptFile
            // 
            this.OpenSceneScriptFile.Name = "OpenSceneScriptFile";
            this.OpenSceneScriptFile.Size = new System.Drawing.Size(297, 22);
            this.OpenSceneScriptFile.Text = "Open scene script file";
            this.OpenSceneScriptFile.Click += new System.EventHandler(this.OpenSceneScriptFile_Click);
            // 
            // OpenSceneResourcesFile
            // 
            this.OpenSceneResourcesFile.Name = "OpenSceneResourcesFile";
            this.OpenSceneResourcesFile.Size = new System.Drawing.Size(297, 22);
            this.OpenSceneResourcesFile.Text = "Open scene resourses file";
            this.OpenSceneResourcesFile.Click += new System.EventHandler(this.OpenSceneResourcesFile_Click);
            // 
            // CreateShaderToolSprip
            // 
            this.CreateShaderToolSprip.Name = "CreateShaderToolSprip";
            this.CreateShaderToolSprip.Size = new System.Drawing.Size(297, 22);
            this.CreateShaderToolSprip.Text = "Create shader and animations, layer ,maps";
            this.CreateShaderToolSprip.Click += new System.EventHandler(this.CreateShaderToolSprip_Click);
            // 
            // openSceneFolderToolStripMenuItem
            // 
            this.openSceneFolderToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inExplorerToolStripMenuItem,
            this.inTotalcmdToolStripMenuItem});
            this.openSceneFolderToolStripMenuItem.Name = "openSceneFolderToolStripMenuItem";
            this.openSceneFolderToolStripMenuItem.Size = new System.Drawing.Size(297, 22);
            this.openSceneFolderToolStripMenuItem.Text = "Open scene folder";
            // 
            // inExplorerToolStripMenuItem
            // 
            this.inExplorerToolStripMenuItem.Name = "inExplorerToolStripMenuItem";
            this.inExplorerToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.inExplorerToolStripMenuItem.Text = "In explorer";
            this.inExplorerToolStripMenuItem.Click += new System.EventHandler(this.inExplorerToolStripMenuItem_Click);
            // 
            // inTotalcmdToolStripMenuItem
            // 
            this.inTotalcmdToolStripMenuItem.Enabled = false;
            this.inTotalcmdToolStripMenuItem.Name = "inTotalcmdToolStripMenuItem";
            this.inTotalcmdToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.inTotalcmdToolStripMenuItem.Text = "In Totalcmd";
            this.inTotalcmdToolStripMenuItem.Click += new System.EventHandler(this.inTotalcmdToolStripMenuItem_Click);
            // 
            // shaderViewerToolStripMenuItem
            // 
            this.shaderViewerToolStripMenuItem.Name = "shaderViewerToolStripMenuItem";
            this.shaderViewerToolStripMenuItem.Size = new System.Drawing.Size(297, 22);
            this.shaderViewerToolStripMenuItem.Text = "Shader Viewer";
            this.shaderViewerToolStripMenuItem.Click += new System.EventHandler(this.shaderViewerToolStripMenuItem_Click);
            // 
            // checkBoxDeleteProfile
            // 
            this.checkBoxDeleteProfile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxDeleteProfile.AutoSize = true;
            this.checkBoxDeleteProfile.Checked = true;
            this.checkBoxDeleteProfile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDeleteProfile.Location = new System.Drawing.Point(804, 457);
            this.checkBoxDeleteProfile.Name = "checkBoxDeleteProfile";
            this.checkBoxDeleteProfile.Size = new System.Drawing.Size(139, 17);
            this.checkBoxDeleteProfile.TabIndex = 41;
            this.checkBoxDeleteProfile.Text = "Delete Profile on launch";
            this.checkBoxDeleteProfile.UseVisualStyleBackColor = true;
            this.checkBoxDeleteProfile.CheckedChanged += new System.EventHandler(this.checkBoxSkipMenus_CheckedChanged);
            // 
            // checkBoxLoadSceneWithAllInvItems
            // 
            this.checkBoxLoadSceneWithAllInvItems.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxLoadSceneWithAllInvItems.AutoSize = true;
            this.checkBoxLoadSceneWithAllInvItems.Location = new System.Drawing.Point(804, 480);
            this.checkBoxLoadSceneWithAllInvItems.Name = "checkBoxLoadSceneWithAllInvItems";
            this.checkBoxLoadSceneWithAllInvItems.Size = new System.Drawing.Size(163, 17);
            this.checkBoxLoadSceneWithAllInvItems.TabIndex = 41;
            this.checkBoxLoadSceneWithAllInvItems.Text = "Load scene with all Inv Items";
            this.checkBoxLoadSceneWithAllInvItems.UseVisualStyleBackColor = true;
            this.checkBoxLoadSceneWithAllInvItems.CheckedChanged += new System.EventHandler(this.checkBoxSkipMenus_CheckedChanged);
            // 
            // checkBoxHideToTray
            // 
            this.checkBoxHideToTray.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxHideToTray.AutoSize = true;
            this.checkBoxHideToTray.Location = new System.Drawing.Point(913, 5);
            this.checkBoxHideToTray.Name = "checkBoxHideToTray";
            this.checkBoxHideToTray.Size = new System.Drawing.Size(80, 17);
            this.checkBoxHideToTray.TabIndex = 42;
            this.checkBoxHideToTray.Text = "Hide to tray";
            this.checkBoxHideToTray.UseVisualStyleBackColor = true;
            this.checkBoxHideToTray.CheckedChanged += new System.EventHandler(this.checkBoxHideToTray_CheckedChanged);
            // 
            // checkBoxSkipMenus
            // 
            this.checkBoxSkipMenus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxSkipMenus.AutoSize = true;
            this.checkBoxSkipMenus.Location = new System.Drawing.Point(804, 503);
            this.checkBoxSkipMenus.Name = "checkBoxSkipMenus";
            this.checkBoxSkipMenus.Size = new System.Drawing.Size(84, 17);
            this.checkBoxSkipMenus.TabIndex = 41;
            this.checkBoxSkipMenus.Text = "Skip_menus";
            this.checkBoxSkipMenus.UseVisualStyleBackColor = true;
            this.checkBoxSkipMenus.CheckedChanged += new System.EventHandler(this.checkBoxSkipMenus_CheckedChanged);
            // 
            // labelCheckScenePlayer
            // 
            this.labelCheckScenePlayer.AutoSize = true;
            this.labelCheckScenePlayer.Location = new System.Drawing.Point(309, 370);
            this.labelCheckScenePlayer.Name = "labelCheckScenePlayer";
            this.labelCheckScenePlayer.Size = new System.Drawing.Size(0, 13);
            this.labelCheckScenePlayer.TabIndex = 18;
            // 
            // buttonUnCheckAll
            // 
            this.buttonUnCheckAll.Enabled = false;
            this.buttonUnCheckAll.Location = new System.Drawing.Point(3, 196);
            this.buttonUnCheckAll.Name = "buttonUnCheckAll";
            this.buttonUnCheckAll.Size = new System.Drawing.Size(43, 26);
            this.buttonUnCheckAll.TabIndex = 37;
            this.buttonUnCheckAll.Text = "<<<";
            this.buttonUnCheckAll.UseVisualStyleBackColor = true;
            this.buttonUnCheckAll.Click += new System.EventHandler(this.buttonUnCheckAll_Click);
            // 
            // buttonCheckItem
            // 
            this.buttonCheckItem.Location = new System.Drawing.Point(3, 106);
            this.buttonCheckItem.Name = "buttonCheckItem";
            this.buttonCheckItem.Size = new System.Drawing.Size(43, 26);
            this.buttonCheckItem.TabIndex = 36;
            this.buttonCheckItem.Text = "=>";
            this.buttonCheckItem.UseVisualStyleBackColor = true;
            this.buttonCheckItem.Click += new System.EventHandler(this.buttonCheckItem_Click);
            // 
            // buttonUncheckItem
            // 
            this.buttonUncheckItem.Enabled = false;
            this.buttonUncheckItem.Location = new System.Drawing.Point(3, 164);
            this.buttonUncheckItem.Name = "buttonUncheckItem";
            this.buttonUncheckItem.Size = new System.Drawing.Size(43, 26);
            this.buttonUncheckItem.TabIndex = 35;
            this.buttonUncheckItem.Text = "<=";
            this.buttonUncheckItem.UseVisualStyleBackColor = true;
            this.buttonUncheckItem.Click += new System.EventHandler(this.buttonUncheckItem_Click);
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.Location = new System.Drawing.Point(934, 571);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(59, 48);
            this.button5.TabIndex = 29;
            this.button5.Text = "Run Scene Player";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // buttonRunDelProf
            // 
            this.buttonRunDelProf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRunDelProf.Location = new System.Drawing.Point(739, 571);
            this.buttonRunDelProf.Name = "buttonRunDelProf";
            this.buttonRunDelProf.Size = new System.Drawing.Size(59, 48);
            this.buttonRunDelProf.TabIndex = 28;
            this.buttonRunDelProf.Text = "Delete profile";
            this.buttonRunDelProf.UseVisualStyleBackColor = true;
            this.buttonRunDelProf.Click += new System.EventHandler(this.buttonRunDelProf_Click);
            // 
            // buttonRunKA
            // 
            this.buttonRunKA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRunKA.Location = new System.Drawing.Point(804, 526);
            this.buttonRunKA.Name = "buttonRunKA";
            this.buttonRunKA.Size = new System.Drawing.Size(124, 93);
            this.buttonRunKA.TabIndex = 27;
            this.buttonRunKA.Text = "Run Game";
            this.buttonRunKA.UseVisualStyleBackColor = true;
            this.buttonRunKA.Click += new System.EventHandler(this.buttonRunKA_Click);
            // 
            // buttonGetItemsFromScene
            // 
            this.buttonGetItemsFromScene.Location = new System.Drawing.Point(226, 28);
            this.buttonGetItemsFromScene.Name = "buttonGetItemsFromScene";
            this.buttonGetItemsFromScene.Size = new System.Drawing.Size(80, 55);
            this.buttonGetItemsFromScene.TabIndex = 26;
            this.buttonGetItemsFromScene.Text = "Get items from scene <=";
            this.buttonGetItemsFromScene.UseVisualStyleBackColor = true;
            this.buttonGetItemsFromScene.Click += new System.EventHandler(this.buttonGetItemsFromScene_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(309, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Main scenes";
            // 
            // _notifyIcon
            // 
            this._notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("_notifyIcon.Icon")));
            this._notifyIcon.Text = "notifyIcon1";
            this._notifyIcon.Visible = true;
            this._notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this._notifyIcon_MouseClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1300, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.printToolStripMenuItem,
            this.printPreviewToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newToolStripMenuItem.Text = "&New";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "&Open";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(149, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveAsToolStripMenuItem.Text = "Save &As";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripMenuItem.Image")));
            this.printToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.printToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.printToolStripMenuItem.Text = "&Print";
            // 
            // printPreviewToolStripMenuItem
            // 
            this.printPreviewToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printPreviewToolStripMenuItem.Image")));
            this.printPreviewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
            this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.printPreviewToolStripMenuItem.Text = "Print Pre&view";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripSeparator3,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.toolStripSeparator4,
            this.selectAllToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            this.undoToolStripMenuItem.Text = "&Undo";
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            this.redoToolStripMenuItem.Text = "&Redo";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 6);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripMenuItem.Image")));
            this.cutToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            this.cutToolStripMenuItem.Text = "Cu&t";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripMenuItem.Image")));
            this.copyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            this.copyToolStripMenuItem.Text = "&Copy";
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripMenuItem.Image")));
            this.pasteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            this.pasteToolStripMenuItem.Text = "&Paste";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            this.selectAllToolStripMenuItem.Text = "Select &All";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runGameToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // runGameToolStripMenuItem
            // 
            this.runGameToolStripMenuItem.Name = "runGameToolStripMenuItem";
            this.runGameToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.runGameToolStripMenuItem.Text = "Run Game";
            this.runGameToolStripMenuItem.Click += new System.EventHandler(this.runGameToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.optionsToolStripMenuItem.Text = "&Options";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contentsToolStripMenuItem,
            this.indexToolStripMenuItem,
            this.searchToolStripMenuItem,
            this.toolStripSeparator5,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // contentsToolStripMenuItem
            // 
            this.contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
            this.contentsToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            this.contentsToolStripMenuItem.Text = "&Contents";
            // 
            // indexToolStripMenuItem
            // 
            this.indexToolStripMenuItem.Name = "indexToolStripMenuItem";
            this.indexToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            this.indexToolStripMenuItem.Text = "&Index";
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            this.searchToolStripMenuItem.Text = "&Search";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            this.aboutToolStripMenuItem.Text = "&About...";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 651);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1316, 689);
            this.Name = "MainForm";
            this.Text = "Fly\'s Scripter Helper";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuStripSubs.ResumeLayout(false);
            this.groupBoxServiceFunctions.ResumeLayout(false);
            this.contextMenuEditScene.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAddChoosenItemsToInventory;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ListBox selectedList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelCheckScenePlayer;
        private System.Windows.Forms.ContextMenuStrip contextMenuEditScene;
        private System.Windows.Forms.ToolStripMenuItem AddToScenePlayer;
        private System.Windows.Forms.ToolStripMenuItem AddSceneToStartLocation;
        private System.Windows.Forms.ToolStripMenuItem OpenSceneXMLFile;
        private System.Windows.Forms.ToolStripMenuItem OpenSceneScriptFile;
        private System.Windows.Forms.ToolStripMenuItem OpenSceneResourcesFile;
        private System.Windows.Forms.ToolStripMenuItem CreateShaderToolSprip;
        private System.Windows.Forms.Button buttonGetItemsFromScene;
        private System.Windows.Forms.Button buttonRunKA;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button buttonRunDelProf;
        private System.Windows.Forms.Button buttonOpenInventoryXML;
        private System.Windows.Forms.Button buttonOpenLevelsXML;
        private System.Windows.Forms.Button buttonDiary;
        private System.Windows.Forms.Button buttonCheckAllResources;
        private System.Windows.Forms.Button buttonOpenTextsXML;
        private System.Windows.Forms.Button buttonUnCheckAll;
        private System.Windows.Forms.Button buttonCheckItem;
        private System.Windows.Forms.Button buttonUncheckItem;
        private System.Windows.Forms.ToolStripMenuItem openSceneFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inExplorerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inTotalcmdToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon _notifyIcon;
        private System.Windows.Forms.Button buttonAddNewItem;
        private System.Windows.Forms.Button buttonEditInvItem;
        private System.Windows.Forms.CheckBox checkBoxSkipMenus;
        private System.Windows.Forms.ToolStripMenuItem shaderViewerToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBoxHideToTray;
        private System.Windows.Forms.Button buttonCreateTestScene;
        private System.Windows.Forms.Button buttonDeleteSearch;
        private System.Windows.Forms.ListView listViewLevels;
        private System.Windows.Forms.ColumnHeader columnHeaderLevels;
        private System.Windows.Forms.CheckBox checkBoxLoadSceneWithAllInvItems;
        private System.Windows.Forms.CheckBox checkBoxDeleteProfile;
        private System.Windows.Forms.GroupBox groupBoxServiceFunctions;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView listViewSubs;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripSubs;
        private System.Windows.Forms.ToolStripMenuItem AddSubToScenePlayer;
        private System.Windows.Forms.ToolStripMenuItem OpenSubXMLFile;
        private System.Windows.Forms.ToolStripMenuItem OpenSubScriptFile;
        private System.Windows.Forms.ToolStripMenuItem OpenSubResourcesFile;
        private System.Windows.Forms.ToolStripMenuItem CreateShaderSubsToolSprip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem shaderSubViewerToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialogExeFileName;
        private System.Windows.Forms.Button buttonGetScenesPositions;
        private System.Windows.Forms.Button buttonTextUv;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem indexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

