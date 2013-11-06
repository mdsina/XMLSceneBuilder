namespace HiddenObjectStudio.Forms
{
    partial class XtraMainForm
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
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.mFile = new DevExpress.XtraBars.BarSubItem();
            this.fileMenuNew = new DevExpress.XtraBars.BarButtonItem();
            this.fileMenuOpen = new DevExpress.XtraBars.BarButtonItem();
            this.fileMenuSave = new DevExpress.XtraBars.BarButtonItem();
            this.fileMenuSaveAs = new DevExpress.XtraBars.BarButtonItem();
            this.fileMenuExit = new DevExpress.XtraBars.BarButtonItem();
            this.mHelp = new DevExpress.XtraBars.BarSubItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanelSceneResources = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dockPanelSceneManager = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.buttonDeleteScene = new System.Windows.Forms.Button();
            this.buttonAddNewScene = new System.Windows.Forms.Button();
            this.treeViewSceneManager = new System.Windows.Forms.TreeView();
            this.xafTabbedMdiManager1 = new DevExpress.ExpressApp.Win.Templates.Controls.XafTabbedMdiManager(this.components);
            this.contextMenuEditScene = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editResourcesFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editMinigamesFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeLevelsxmlSceneDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanelSceneResources.SuspendLayout();
            this.dockPanelSceneManager.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xafTabbedMdiManager1)).BeginInit();
            this.contextMenuEditScene.SuspendLayout();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar2,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.DockManager = this.dockManager1;
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.mFile,
            this.mHelp,
            this.fileMenuOpen,
            this.fileMenuNew,
            this.fileMenuSave,
            this.fileMenuSaveAs,
            this.fileMenuExit});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 10;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 1;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.Text = "Tools";
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.mFile),
            new DevExpress.XtraBars.LinkPersistInfo(this.mHelp)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // mFile
            // 
            this.mFile.Caption = "File";
            this.mFile.Id = 3;
            this.mFile.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.fileMenuNew),
            new DevExpress.XtraBars.LinkPersistInfo(this.fileMenuOpen),
            new DevExpress.XtraBars.LinkPersistInfo(this.fileMenuSave),
            new DevExpress.XtraBars.LinkPersistInfo(this.fileMenuSaveAs),
            new DevExpress.XtraBars.LinkPersistInfo(this.fileMenuExit)});
            this.mFile.Name = "mFile";
            // 
            // fileMenuNew
            // 
            this.fileMenuNew.Caption = "New";
            this.fileMenuNew.Id = 6;
            this.fileMenuNew.Name = "fileMenuNew";
            // 
            // fileMenuOpen
            // 
            this.fileMenuOpen.Caption = "Open";
            this.fileMenuOpen.Id = 5;
            this.fileMenuOpen.Name = "fileMenuOpen";
            // 
            // fileMenuSave
            // 
            this.fileMenuSave.Caption = "Save";
            this.fileMenuSave.Id = 7;
            this.fileMenuSave.Name = "fileMenuSave";
            // 
            // fileMenuSaveAs
            // 
            this.fileMenuSaveAs.Caption = "Save As ...";
            this.fileMenuSaveAs.Id = 8;
            this.fileMenuSaveAs.Name = "fileMenuSaveAs";
            // 
            // fileMenuExit
            // 
            this.fileMenuExit.Caption = "Exit";
            this.fileMenuExit.Id = 9;
            this.fileMenuExit.Name = "fileMenuExit";
            // 
            // mHelp
            // 
            this.mHelp.Caption = "Help";
            this.mHelp.Id = 4;
            this.mHelp.Name = "mHelp";
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1262, 51);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 626);
            this.barDockControlBottom.Size = new System.Drawing.Size(1262, 23);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 51);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 575);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1262, 51);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 575);
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.HiddenPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanelSceneResources});
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanelSceneManager});
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl"});
            // 
            // dockPanelSceneResources
            // 
            this.dockPanelSceneResources.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dockPanelSceneResources.Controls.Add(this.dockPanel2_Container);
            this.dockPanelSceneResources.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.dockPanelSceneResources.FloatVertical = true;
            this.dockPanelSceneResources.ID = new System.Guid("6bb6b019-8de4-4e36-9c59-acfe1a3c242d");
            this.dockPanelSceneResources.Location = new System.Drawing.Point(0, 287);
            this.dockPanelSceneResources.Name = "dockPanelSceneResources";
            this.dockPanelSceneResources.OriginalSize = new System.Drawing.Size(256, 288);
            this.dockPanelSceneResources.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.dockPanelSceneResources.SavedIndex = 1;
            this.dockPanelSceneResources.SavedParent = this.dockPanelSceneManager;
            this.dockPanelSceneResources.Size = new System.Drawing.Size(256, 286);
            this.dockPanelSceneResources.Text = "Scene Resources";
            this.dockPanelSceneResources.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
            // 
            // dockPanel2_Container
            // 
            this.dockPanel2_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel2_Container.Name = "dockPanel2_Container";
            this.dockPanel2_Container.Size = new System.Drawing.Size(248, 259);
            this.dockPanel2_Container.TabIndex = 0;
            // 
            // dockPanelSceneManager
            // 
            this.dockPanelSceneManager.Controls.Add(this.dockPanel1_Container);
            this.dockPanelSceneManager.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanelSceneManager.ID = new System.Guid("6cc3ff08-dcc8-4823-9392-3a59e3002360");
            this.dockPanelSceneManager.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dockPanelSceneManager.Location = new System.Drawing.Point(0, 51);
            this.dockPanelSceneManager.Name = "dockPanelSceneManager";
            this.dockPanelSceneManager.OriginalSize = new System.Drawing.Size(256, 200);
            this.dockPanelSceneManager.Size = new System.Drawing.Size(256, 575);
            this.dockPanelSceneManager.Text = "mainScenesPanel";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.buttonDeleteScene);
            this.dockPanel1_Container.Controls.Add(this.buttonAddNewScene);
            this.dockPanel1_Container.Controls.Add(this.treeViewSceneManager);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(248, 548);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // buttonDeleteScene
            // 
            this.buttonDeleteScene.Location = new System.Drawing.Point(157, 520);
            this.buttonDeleteScene.Name = "buttonDeleteScene";
            this.buttonDeleteScene.Size = new System.Drawing.Size(78, 23);
            this.buttonDeleteScene.TabIndex = 7;
            this.buttonDeleteScene.Text = "Delete Scene";
            this.buttonDeleteScene.UseVisualStyleBackColor = true;
            // 
            // buttonAddNewScene
            // 
            this.buttonAddNewScene.Location = new System.Drawing.Point(8, 520);
            this.buttonAddNewScene.Name = "buttonAddNewScene";
            this.buttonAddNewScene.Size = new System.Drawing.Size(80, 23);
            this.buttonAddNewScene.TabIndex = 6;
            this.buttonAddNewScene.Text = "Add Scene";
            this.buttonAddNewScene.UseVisualStyleBackColor = true;
            // 
            // treeViewSceneManager
            // 
            this.treeViewSceneManager.Dock = System.Windows.Forms.DockStyle.Top;
            this.treeViewSceneManager.Location = new System.Drawing.Point(0, 0);
            this.treeViewSceneManager.Name = "treeViewSceneManager";
            this.treeViewSceneManager.Size = new System.Drawing.Size(248, 514);
            this.treeViewSceneManager.TabIndex = 5;
            this.treeViewSceneManager.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewSceneManager_AfterSelect);
            this.treeViewSceneManager.DoubleClick += new System.EventHandler(this.treeViewSceneManager_DoubleClick);
            this.treeViewSceneManager.MouseClick += new System.Windows.Forms.MouseEventHandler(this.treeViewSceneManager_MouseClick);
            // 
            // xafTabbedMdiManager1
            // 
            this.xafTabbedMdiManager1.AllowDragDrop = DevExpress.Utils.DefaultBoolean.True;
            this.xafTabbedMdiManager1.FloatOnDrag = DevExpress.Utils.DefaultBoolean.True;
            this.xafTabbedMdiManager1.MdiParent = this;
            // 
            // contextMenuEditScene
            // 
            this.contextMenuEditScene.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editResourcesFilesToolStripMenuItem,
            this.editMinigamesFilesToolStripMenuItem,
            this.changeLevelsxmlSceneDataToolStripMenuItem});
            this.contextMenuEditScene.Name = "contextMenuEditScene";
            this.contextMenuEditScene.Size = new System.Drawing.Size(233, 92);
            // 
            // editResourcesFilesToolStripMenuItem
            // 
            this.editResourcesFilesToolStripMenuItem.Name = "editResourcesFilesToolStripMenuItem";
            this.editResourcesFilesToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.editResourcesFilesToolStripMenuItem.Text = "Edit Resources Files";
            this.editResourcesFilesToolStripMenuItem.Click += new System.EventHandler(this.editResourcesFilesToolStripMenuItem_Click);
            // 
            // editMinigamesFilesToolStripMenuItem
            // 
            this.editMinigamesFilesToolStripMenuItem.Name = "editMinigamesFilesToolStripMenuItem";
            this.editMinigamesFilesToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.editMinigamesFilesToolStripMenuItem.Text = "Edit Minigames Files";
            this.editMinigamesFilesToolStripMenuItem.Click += new System.EventHandler(this.editMinigamesFilesToolStripMenuItem_Click);
            // 
            // changeLevelsxmlSceneDataToolStripMenuItem
            // 
            this.changeLevelsxmlSceneDataToolStripMenuItem.Name = "changeLevelsxmlSceneDataToolStripMenuItem";
            this.changeLevelsxmlSceneDataToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.changeLevelsxmlSceneDataToolStripMenuItem.Text = "Change Levels.xml scene Data";
            this.changeLevelsxmlSceneDataToolStripMenuItem.Click += new System.EventHandler(this.changeLevelsxmlSceneDataToolStripMenuItem_Click);
            // 
            // XtraMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 649);
            this.Controls.Add(this.dockPanelSceneManager);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IsMdiContainer = true;
            this.Name = "XtraMainForm";
            this.Text = "HiddenObjectEditor";
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanelSceneResources.ResumeLayout(false);
            this.dockPanelSceneManager.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xafTabbedMdiManager1)).EndInit();
            this.contextMenuEditScene.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarSubItem mFile;
        private DevExpress.XtraBars.BarButtonItem fileMenuNew;
        private DevExpress.XtraBars.BarButtonItem fileMenuOpen;
        private DevExpress.XtraBars.BarButtonItem fileMenuSave;
        private DevExpress.XtraBars.BarButtonItem fileMenuSaveAs;
        private DevExpress.XtraBars.BarButtonItem fileMenuExit;
        private DevExpress.XtraBars.BarSubItem mHelp;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.ExpressApp.Win.Templates.Controls.XafTabbedMdiManager xafTabbedMdiManager1;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanelSceneManager;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private System.Windows.Forms.TreeView treeViewSceneManager;
        private System.Windows.Forms.ContextMenuStrip contextMenuEditScene;
        private System.Windows.Forms.ToolStripMenuItem editResourcesFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editMinigamesFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeLevelsxmlSceneDataToolStripMenuItem;
        private DevExpress.XtraBars.Docking.DockPanel dockPanelSceneResources;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel2_Container;
        private System.Windows.Forms.Button buttonDeleteScene;
        private System.Windows.Forms.Button buttonAddNewScene;

    }
}