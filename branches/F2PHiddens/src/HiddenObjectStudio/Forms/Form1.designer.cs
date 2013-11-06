namespace SceneEditor.Forms
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.barManager = new DevExpress.XtraBars.BarManager();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.tNew = new DevExpress.XtraBars.BarButtonItem();
            this.tOpen = new DevExpress.XtraBars.BarButtonItem();
            this.tSave = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.mFile = new DevExpress.XtraBars.BarSubItem();
            this.iNew = new DevExpress.XtraBars.BarButtonItem();
            this.iOpen = new DevExpress.XtraBars.BarButtonItem();
            this.iClose = new DevExpress.XtraBars.BarButtonItem();
            this.iSave = new DevExpress.XtraBars.BarButtonItem();
            this.iSaveAs = new DevExpress.XtraBars.BarButtonItem();
            this.iExit = new DevExpress.XtraBars.BarButtonItem();
            this.mHelp = new DevExpress.XtraBars.BarSubItem();
            this.iAbout = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.sItem = new DevExpress.XtraBars.BarStaticItem();
            this.sSecItem = new DevExpress.XtraBars.BarStaticItem();
            this.bar4 = new DevExpress.XtraBars.Bar();
            this.mPaintStyle = new DevExpress.XtraBars.BarSubItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager();
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.imageList = new System.Windows.Forms.ImageList();
            this.mOldStyles = new DevExpress.XtraBars.BarSubItem();
            this.iWXP = new DevExpress.XtraBars.BarCheckItem();
            this.iOffXP = new DevExpress.XtraBars.BarCheckItem();
            this.iOff2K = new DevExpress.XtraBars.BarCheckItem();
            this.iOff2003 = new DevExpress.XtraBars.BarCheckItem();
            this.iDefault = new DevExpress.XtraBars.BarCheckItem();
            this.mOfficeSkins = new DevExpress.XtraBars.BarSubItem();
            this.mBonusSkins = new DevExpress.XtraBars.BarSubItem();
            this.xafTabbedMdiManager1 = new DevExpress.ExpressApp.Win.Templates.Controls.XafTabbedMdiManager();
            this.dockPanel2 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.panelContainer1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel3 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel3_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xafTabbedMdiManager1)).BeginInit();
            this.dockPanel2.SuspendLayout();
            this.panelContainer1.SuspendLayout();
            this.dockPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // barManager
            // 
            this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2,
            this.bar1,
            this.bar3,
            this.bar4});
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.DockManager = this.dockManager1;
            this.barManager.Form = this;
            this.barManager.Images = this.imageList;
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.mFile,
            this.mHelp,
            this.iNew,
            this.iOpen,
            this.iClose,
            this.iSave,
            this.iSaveAs,
            this.iExit,
            this.iAbout,
            this.sItem,
            this.sSecItem,
            this.tNew,
            this.tOpen,
            this.tSave,
            this.mPaintStyle,
            this.mOldStyles,
            this.mOfficeSkins,
            this.mBonusSkins,
            this.iWXP,
            this.iOffXP,
            this.iOff2K,
            this.iOff2003,
            this.iDefault,
            this.barButtonItem1});
            this.barManager.MainMenu = this.bar1;
            this.barManager.MaxItemId = 31;
            this.barManager.StatusBar = this.bar3;
            // 
            // bar2
            // 
            this.bar2.BarName = "Tools";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 1;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.FloatLocation = new System.Drawing.Point(49, 157);
            this.bar2.FloatSize = new System.Drawing.Size(46, 29);
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.tNew),
            new DevExpress.XtraBars.LinkPersistInfo(this.tOpen),
            new DevExpress.XtraBars.LinkPersistInfo(this.tSave),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1)});
            this.bar2.Text = "Tools";
            // 
            // tNew
            // 
            this.tNew.Caption = "New";
            this.tNew.Id = 18;
            this.tNew.ImageIndex = 0;
            this.tNew.Name = "tNew";
            // 
            // tOpen
            // 
            this.tOpen.Caption = "Open";
            this.tOpen.Id = 19;
            this.tOpen.ImageIndex = 1;
            this.tOpen.Name = "tOpen";
            // 
            // tSave
            // 
            this.tSave.Caption = "Save";
            this.tSave.Id = 20;
            this.tSave.ImageIndex = 2;
            this.tSave.Name = "tSave";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 30;
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // bar1
            // 
            this.bar1.BarName = "Main menu";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.mFile),
            new DevExpress.XtraBars.LinkPersistInfo(this.mHelp)});
            this.bar1.OptionsBar.MultiLine = true;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Main menu";
            // 
            // mFile
            // 
            this.mFile.Caption = "&File";
            this.mFile.Id = 0;
            this.mFile.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.iNew),
            new DevExpress.XtraBars.LinkPersistInfo(this.iOpen),
            new DevExpress.XtraBars.LinkPersistInfo(this.iClose),
            new DevExpress.XtraBars.LinkPersistInfo(this.iSave),
            new DevExpress.XtraBars.LinkPersistInfo(this.iSaveAs),
            new DevExpress.XtraBars.LinkPersistInfo(this.iExit)});
            this.mFile.Name = "mFile";
            // 
            // iNew
            // 
            this.iNew.Caption = "&New";
            this.iNew.Id = 2;
            this.iNew.ImageIndex = 0;
            this.iNew.Name = "iNew";
            // 
            // iOpen
            // 
            this.iOpen.Caption = "&Open";
            this.iOpen.Id = 3;
            this.iOpen.ImageIndex = 1;
            this.iOpen.Name = "iOpen";
            // 
            // iClose
            // 
            this.iClose.Caption = "&Close";
            this.iClose.Id = 4;
            this.iClose.Name = "iClose";
            // 
            // iSave
            // 
            this.iSave.Caption = "&Save";
            this.iSave.Id = 5;
            this.iSave.ImageIndex = 2;
            this.iSave.Name = "iSave";
            // 
            // iSaveAs
            // 
            this.iSaveAs.Caption = "Save &As";
            this.iSaveAs.Id = 6;
            this.iSaveAs.ImageIndex = 3;
            this.iSaveAs.Name = "iSaveAs";
            // 
            // iExit
            // 
            this.iExit.Caption = "E&xit";
            this.iExit.Id = 7;
            this.iExit.Name = "iExit";
            // 
            // mHelp
            // 
            this.mHelp.Caption = "&Help";
            this.mHelp.Id = 1;
            this.mHelp.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.iAbout)});
            this.mHelp.Name = "mHelp";
            // 
            // iAbout
            // 
            this.iAbout.Caption = "&About";
            this.iAbout.Id = 8;
            this.iAbout.Name = "iAbout";
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.sItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.sSecItem)});
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // sItem
            // 
            this.sItem.Caption = "Some Info";
            this.sItem.Id = 9;
            this.sItem.Name = "sItem";
            this.sItem.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // sSecItem
            // 
            this.sSecItem.AutoSize = DevExpress.XtraBars.BarStaticItemSize.Spring;
            this.sSecItem.Caption = "Some Info";
            this.sSecItem.Id = 10;
            this.sSecItem.Name = "sSecItem";
            this.sSecItem.TextAlignment = System.Drawing.StringAlignment.Near;
            this.sSecItem.Width = 32;
            // 
            // bar4
            // 
            this.bar4.BarName = "SecTools";
            this.bar4.DockCol = 1;
            this.bar4.DockRow = 1;
            this.bar4.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar4.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.mPaintStyle)});
            this.bar4.Offset = 129;
            this.bar4.OptionsBar.AllowRename = true;
            this.bar4.Text = "SecTools";
            // 
            // mPaintStyle
            // 
            this.mPaintStyle.Caption = "Paint Style";
            this.mPaintStyle.Id = 21;
            this.mPaintStyle.Name = "mPaintStyle";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(950, 53);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 524);
            this.barDockControlBottom.Size = new System.Drawing.Size(950, 26);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 53);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 471);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(950, 53);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 471);
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanel3,
            this.panelContainer1});
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl"});
            // 
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.dockPanel1.ID = new System.Guid("f7bf9696-b5de-4109-b968-9fe43cf46a9d");
            this.dockPanel1.Location = new System.Drawing.Point(0, 0);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.OriginalSize = new System.Drawing.Size(200, 200);
            this.dockPanel1.Size = new System.Drawing.Size(200, 135);
            this.dockPanel1.Text = "dockPanel1";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(192, 108);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.White;
            this.imageList.Images.SetKeyName(0, "New_16x16.png");
            this.imageList.Images.SetKeyName(1, "Open_16x16.png");
            this.imageList.Images.SetKeyName(2, "Save_16x16.png");
            this.imageList.Images.SetKeyName(3, "SaveAs_16x16.png");
            // 
            // mOldStyles
            // 
            this.mOldStyles.Caption = "Old Styles";
            this.mOldStyles.Id = 22;
            this.mOldStyles.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.iWXP),
            new DevExpress.XtraBars.LinkPersistInfo(this.iOffXP),
            new DevExpress.XtraBars.LinkPersistInfo(this.iOff2K),
            new DevExpress.XtraBars.LinkPersistInfo(this.iOff2003),
            new DevExpress.XtraBars.LinkPersistInfo(this.iDefault)});
            this.mOldStyles.Name = "mOldStyles";
            // 
            // iWXP
            // 
            this.iWXP.Caption = "WindowsXP";
            this.iWXP.Description = "WindowsXP";
            this.iWXP.Id = 25;
            this.iWXP.Name = "iWXP";
            // 
            // iOffXP
            // 
            this.iOffXP.Caption = "OfficeXP";
            this.iOffXP.Description = "OfficeXP";
            this.iOffXP.Id = 26;
            this.iOffXP.Name = "iOffXP";
            // 
            // iOff2K
            // 
            this.iOff2K.Caption = "Office2000";
            this.iOff2K.Description = "Office2000";
            this.iOff2K.Id = 27;
            this.iOff2K.Name = "iOff2K";
            // 
            // iOff2003
            // 
            this.iOff2003.Caption = "Office2003";
            this.iOff2003.Description = "Office2003";
            this.iOff2003.Id = 28;
            this.iOff2003.Name = "iOff2003";
            // 
            // iDefault
            // 
            this.iDefault.Caption = "Default";
            this.iDefault.Description = "Default";
            this.iDefault.Id = 29;
            this.iDefault.Name = "iDefault";
            // 
            // mOfficeSkins
            // 
            this.mOfficeSkins.Caption = "Office Skins";
            this.mOfficeSkins.Id = 23;
            this.mOfficeSkins.Name = "mOfficeSkins";
            // 
            // mBonusSkins
            // 
            this.mBonusSkins.Caption = "Bonus Skins";
            this.mBonusSkins.Id = 24;
            this.mBonusSkins.Name = "mBonusSkins";
            // 
            // xafTabbedMdiManager1
            // 
            this.xafTabbedMdiManager1.AllowDragDrop = DevExpress.Utils.DefaultBoolean.True;
            this.xafTabbedMdiManager1.FloatOnDrag = DevExpress.Utils.DefaultBoolean.True;
            this.xafTabbedMdiManager1.MdiParent = this;
            this.xafTabbedMdiManager1.ShowToolTips = DevExpress.Utils.DefaultBoolean.True;
            this.xafTabbedMdiManager1.UseDocumentSelector = DevExpress.Utils.DefaultBoolean.True;
            // 
            // dockPanel2
            // 
            this.dockPanel2.Controls.Add(this.dockPanel2_Container);
            this.dockPanel2.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.dockPanel2.ID = new System.Guid("de21c4e2-ab47-49d0-b400-af124d4de77e");
            this.dockPanel2.Location = new System.Drawing.Point(0, 135);
            this.dockPanel2.Name = "dockPanel2";
            this.dockPanel2.OriginalSize = new System.Drawing.Size(200, 200);
            this.dockPanel2.Size = new System.Drawing.Size(200, 136);
            this.dockPanel2.Text = "dockPanel2";
            // 
            // dockPanel2_Container
            // 
            this.dockPanel2_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel2_Container.Name = "dockPanel2_Container";
            this.dockPanel2_Container.Size = new System.Drawing.Size(192, 109);
            this.dockPanel2_Container.TabIndex = 0;
            // 
            // panelContainer1
            // 
            this.panelContainer1.Controls.Add(this.dockPanel1);
            this.panelContainer1.Controls.Add(this.dockPanel2);
            this.panelContainer1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.panelContainer1.ID = new System.Guid("5eb63913-2b25-4ea4-9860-5c7a183688a2");
            this.panelContainer1.Location = new System.Drawing.Point(0, 53);
            this.panelContainer1.Name = "panelContainer1";
            this.panelContainer1.OriginalSize = new System.Drawing.Size(200, 200);
            this.panelContainer1.Size = new System.Drawing.Size(200, 271);
            this.panelContainer1.Text = "panelContainer1";
            // 
            // dockPanel3
            // 
            this.dockPanel3.Controls.Add(this.dockPanel3_Container);
            this.dockPanel3.Dock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
            this.dockPanel3.ID = new System.Guid("022b3a78-71ae-45d7-af2c-486ba98ae42d");
            this.dockPanel3.Location = new System.Drawing.Point(0, 324);
            this.dockPanel3.Name = "dockPanel3";
            this.dockPanel3.OriginalSize = new System.Drawing.Size(200, 200);
            this.dockPanel3.Size = new System.Drawing.Size(950, 200);
            this.dockPanel3.Text = "dockPanel3";
            // 
            // dockPanel3_Container
            // 
            this.dockPanel3_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel3_Container.Name = "dockPanel3_Container";
            this.dockPanel3_Container.Size = new System.Drawing.Size(942, 173);
            this.dockPanel3_Container.TabIndex = 0;
            // 
            // Form1
            // 
            this.AllowMdiBar = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 550);
            this.Controls.Add(this.panelContainer1);
            this.Controls.Add(this.dockPanel3);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IsMdiContainer = true;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xafTabbedMdiManager1)).EndInit();
            this.dockPanel2.ResumeLayout(false);
            this.panelContainer1.ResumeLayout(false);
            this.dockPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.Bar bar4;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarSubItem mFile;
        private DevExpress.XtraBars.BarSubItem mHelp;
        private DevExpress.XtraBars.BarButtonItem iNew;
        private DevExpress.XtraBars.BarButtonItem iOpen;
        private DevExpress.XtraBars.BarButtonItem iClose;
        private DevExpress.XtraBars.BarButtonItem iSave;
        private DevExpress.XtraBars.BarButtonItem iSaveAs;
        private DevExpress.XtraBars.BarButtonItem iExit;
        private DevExpress.XtraBars.BarButtonItem iAbout;
        private DevExpress.XtraBars.BarStaticItem sItem;
        private DevExpress.XtraBars.BarStaticItem sSecItem;
        private DevExpress.XtraBars.BarButtonItem tNew;
        private DevExpress.XtraBars.BarButtonItem tOpen;
        private DevExpress.XtraBars.BarButtonItem tSave;
        private DevExpress.XtraBars.BarSubItem mPaintStyle;
        private DevExpress.XtraBars.BarSubItem mOldStyles;
        private DevExpress.XtraBars.BarSubItem mOfficeSkins;
        private DevExpress.XtraBars.BarSubItem mBonusSkins;
        private DevExpress.XtraBars.BarCheckItem iWXP;
        private DevExpress.XtraBars.BarCheckItem iOffXP;
        private DevExpress.XtraBars.BarCheckItem iOff2K;
        private DevExpress.XtraBars.BarCheckItem iOff2003;
        private DevExpress.XtraBars.BarCheckItem iDefault;
        private System.Windows.Forms.ImageList imageList;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.ExpressApp.Win.Templates.Controls.XafTabbedMdiManager xafTabbedMdiManager1;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraBars.Docking.DockPanel panelContainer1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel2;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel2_Container;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel3;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel3_Container;

    }
}
