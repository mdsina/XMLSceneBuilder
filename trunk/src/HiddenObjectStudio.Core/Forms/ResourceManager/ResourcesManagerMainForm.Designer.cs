namespace HiddenObjectStudio.Core.Forms
{
    partial class ResourcesManagerMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResourcesManagerMainForm));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.buttonSaveResFile = new System.Windows.Forms.Button();
            this.contextMenuAddItem = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addShaderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addModelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addContainerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addParticlesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addTexturePackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteContainerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialogAnimFirstImage = new System.Windows.Forms.OpenFileDialog();
            this.pictureBoxImage = new System.Windows.Forms.PictureBox();
            this.textBoxSize = new System.Windows.Forms.TextBox();
            this.contextMenuDeleteSomething = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.contextMenuAddItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).BeginInit();
            this.contextMenuDeleteSomething.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.AllowDrop = true;
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView1.FullRowSelect = true;
            this.treeView1.HideSelection = false;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.Location = new System.Drawing.Point(5, 27);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(568, 488);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeView1_DragDrop);
            this.treeView1.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeView1_DragEnter);
            this.treeView1.DragOver += new System.Windows.Forms.DragEventHandler(this.treeView1_DragOver);
            this.treeView1.DoubleClick += new System.EventHandler(this.treeView1_DoubleClick);
            this.treeView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "simpleNode.bmp");
            this.imageList1.Images.SetKeyName(1, "texturePackNode.bmp");
            this.imageList1.Images.SetKeyName(2, "shaderNode.bmp");
            this.imageList1.Images.SetKeyName(3, "modelNode.bmp");
            this.imageList1.Images.SetKeyName(4, "particlesNode.bmp");
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(585, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem1});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveAsToolStripMenuItem.Text = "Save as...";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem1.Text = "Exit";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // buttonSaveResFile
            // 
            this.buttonSaveResFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSaveResFile.Location = new System.Drawing.Point(5, 521);
            this.buttonSaveResFile.Name = "buttonSaveResFile";
            this.buttonSaveResFile.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveResFile.TabIndex = 2;
            this.buttonSaveResFile.Text = "Save";
            this.buttonSaveResFile.UseVisualStyleBackColor = true;
            this.buttonSaveResFile.Click += new System.EventHandler(this.buttonSaveResFile_Click);
            // 
            // contextMenuAddItem
            // 
            this.contextMenuAddItem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addShaderToolStripMenuItem,
            this.addModelToolStripMenuItem,
            this.addContainerToolStripMenuItem,
            this.addParticlesToolStripMenuItem,
            this.addTexturePackToolStripMenuItem,
            this.deleteContainerToolStripMenuItem});
            this.contextMenuAddItem.Name = "contextMenuEditScene";
            this.contextMenuAddItem.Size = new System.Drawing.Size(164, 136);
            // 
            // addShaderToolStripMenuItem
            // 
            this.addShaderToolStripMenuItem.Name = "addShaderToolStripMenuItem";
            this.addShaderToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.addShaderToolStripMenuItem.Text = "Add Shader";
            this.addShaderToolStripMenuItem.Click += new System.EventHandler(this.addShaderToolStripMenuItem_Click);
            // 
            // addModelToolStripMenuItem
            // 
            this.addModelToolStripMenuItem.Name = "addModelToolStripMenuItem";
            this.addModelToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.addModelToolStripMenuItem.Text = "Add Model";
            this.addModelToolStripMenuItem.Click += new System.EventHandler(this.addModelToolStripMenuItem_Click);
            // 
            // addContainerToolStripMenuItem
            // 
            this.addContainerToolStripMenuItem.Name = "addContainerToolStripMenuItem";
            this.addContainerToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.addContainerToolStripMenuItem.Text = "Add Container";
            this.addContainerToolStripMenuItem.Click += new System.EventHandler(this.addContainerToolStripMenuItem_Click);
            // 
            // addParticlesToolStripMenuItem
            // 
            this.addParticlesToolStripMenuItem.Name = "addParticlesToolStripMenuItem";
            this.addParticlesToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.addParticlesToolStripMenuItem.Text = "Add Particles";
            this.addParticlesToolStripMenuItem.Click += new System.EventHandler(this.addParticlesToolStripMenuItem_Click);
            // 
            // addTexturePackToolStripMenuItem
            // 
            this.addTexturePackToolStripMenuItem.Name = "addTexturePackToolStripMenuItem";
            this.addTexturePackToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.addTexturePackToolStripMenuItem.Text = "Add TexturePack";
            this.addTexturePackToolStripMenuItem.Click += new System.EventHandler(this.addTexturePackToolStripMenuItem_Click);
            // 
            // deleteContainerToolStripMenuItem
            // 
            this.deleteContainerToolStripMenuItem.Name = "deleteContainerToolStripMenuItem";
            this.deleteContainerToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.deleteContainerToolStripMenuItem.Text = "Delete Container";
            this.deleteContainerToolStripMenuItem.Click += new System.EventHandler(this.deleteContainerToolStripMenuItem_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox1.Location = new System.Drawing.Point(338, 523);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(235, 20);
            this.textBox1.TabIndex = 3;
            // 
            // pictureBoxImage
            // 
            this.pictureBoxImage.Location = new System.Drawing.Point(589, 53);
            this.pictureBoxImage.Name = "pictureBoxImage";
            this.pictureBoxImage.Size = new System.Drawing.Size(207, 145);
            this.pictureBoxImage.TabIndex = 5;
            this.pictureBoxImage.TabStop = false;
            // 
            // textBoxSize
            // 
            this.textBoxSize.Enabled = false;
            this.textBoxSize.Location = new System.Drawing.Point(589, 27);
            this.textBoxSize.Name = "textBoxSize";
            this.textBoxSize.Size = new System.Drawing.Size(196, 20);
            this.textBoxSize.TabIndex = 6;
            // 
            // contextMenuDeleteSomething
            // 
            this.contextMenuDeleteSomething.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteItemToolStripMenuItem});
            this.contextMenuDeleteSomething.Name = "contextMenuDeleteSomething";
            this.contextMenuDeleteSomething.Size = new System.Drawing.Size(135, 26);
            // 
            // deleteItemToolStripMenuItem
            // 
            this.deleteItemToolStripMenuItem.Name = "deleteItemToolStripMenuItem";
            this.deleteItemToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.deleteItemToolStripMenuItem.Text = "Delete Item";
            this.deleteItemToolStripMenuItem.Click += new System.EventHandler(this.deleteItemToolStripMenuItem_Click);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // ResourcesManagerMainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(585, 549);
            this.Controls.Add(this.textBoxSize);
            this.Controls.Add(this.pictureBoxImage);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.buttonSaveResFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ResourcesManagerMainForm";
            this.Text = "Resources Manager";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuAddItem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).EndInit();
            this.contextMenuDeleteSomething.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Button buttonSaveResFile;
        private System.Windows.Forms.ContextMenuStrip contextMenuAddItem;
        private System.Windows.Forms.ToolStripMenuItem addShaderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addModelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addContainerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addParticlesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addTexturePackToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialogAnimFirstImage;
        private System.Windows.Forms.PictureBox pictureBoxImage;
        private System.Windows.Forms.TextBox textBoxSize;
        private System.Windows.Forms.ToolStripMenuItem deleteContainerToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuDeleteSomething;
        private System.Windows.Forms.ToolStripMenuItem deleteItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
    }
}

