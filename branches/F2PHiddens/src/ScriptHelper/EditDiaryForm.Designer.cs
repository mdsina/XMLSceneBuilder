namespace WindowsFormsApplication2
{
    partial class EditDiaryForm
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
            this.menuStripDiaryMain = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuDiaryMain = new System.Windows.Forms.ToolStripMenuItem();
            this.openDiarySceneXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openDiarySceneScriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openDiarySceneResourcesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonAddDiaryToScenePlayer = new System.Windows.Forms.Button();
            this.menuStripDiaryMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripDiaryMain
            // 
            this.menuStripDiaryMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuDiaryMain});
            this.menuStripDiaryMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripDiaryMain.Name = "menuStripDiaryMain";
            this.menuStripDiaryMain.Size = new System.Drawing.Size(487, 24);
            this.menuStripDiaryMain.TabIndex = 0;
            this.menuStripDiaryMain.Text = "Main";
            // 
            // toolStripMenuDiaryMain
            // 
            this.toolStripMenuDiaryMain.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openDiarySceneXMLToolStripMenuItem,
            this.openDiarySceneScriptToolStripMenuItem,
            this.openDiarySceneResourcesToolStripMenuItem});
            this.toolStripMenuDiaryMain.Name = "toolStripMenuDiaryMain";
            this.toolStripMenuDiaryMain.Size = new System.Drawing.Size(46, 20);
            this.toolStripMenuDiaryMain.Text = "Main";
            // 
            // openDiarySceneXMLToolStripMenuItem
            // 
            this.openDiarySceneXMLToolStripMenuItem.Name = "openDiarySceneXMLToolStripMenuItem";
            this.openDiarySceneXMLToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.openDiarySceneXMLToolStripMenuItem.Text = "Open diary scene XML";
            this.openDiarySceneXMLToolStripMenuItem.Click += new System.EventHandler(this.openDiarySceneXMLToolStripMenuItem_Click);
            // 
            // openDiarySceneScriptToolStripMenuItem
            // 
            this.openDiarySceneScriptToolStripMenuItem.Name = "openDiarySceneScriptToolStripMenuItem";
            this.openDiarySceneScriptToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.openDiarySceneScriptToolStripMenuItem.Text = "Open diary scene script";
            this.openDiarySceneScriptToolStripMenuItem.Click += new System.EventHandler(this.openDiarySceneScriptToolStripMenuItem_Click);
            // 
            // openDiarySceneResourcesToolStripMenuItem
            // 
            this.openDiarySceneResourcesToolStripMenuItem.Name = "openDiarySceneResourcesToolStripMenuItem";
            this.openDiarySceneResourcesToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.openDiarySceneResourcesToolStripMenuItem.Text = "Open diary scene resources";
            this.openDiarySceneResourcesToolStripMenuItem.Click += new System.EventHandler(this.openDiarySceneResourcesToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(292, 453);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add entries";
            // 
            // buttonAddDiaryToScenePlayer
            // 
            this.buttonAddDiaryToScenePlayer.Location = new System.Drawing.Point(310, 27);
            this.buttonAddDiaryToScenePlayer.Name = "buttonAddDiaryToScenePlayer";
            this.buttonAddDiaryToScenePlayer.Size = new System.Drawing.Size(171, 23);
            this.buttonAddDiaryToScenePlayer.TabIndex = 2;
            this.buttonAddDiaryToScenePlayer.Text = "Add diary to Scene Player";
            this.buttonAddDiaryToScenePlayer.UseVisualStyleBackColor = true;
            this.buttonAddDiaryToScenePlayer.Click += new System.EventHandler(this.buttonAddDiaryToScenePlayer_Click);
            // 
            // EditDiaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 500);
            this.Controls.Add(this.buttonAddDiaryToScenePlayer);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStripDiaryMain);
            this.MainMenuStrip = this.menuStripDiaryMain;
            this.Name = "EditDiaryForm";
            this.Text = "EditDiaryForm";
            this.menuStripDiaryMain.ResumeLayout(false);
            this.menuStripDiaryMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripDiaryMain;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuDiaryMain;
        private System.Windows.Forms.ToolStripMenuItem openDiarySceneXMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openDiarySceneScriptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openDiarySceneResourcesToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonAddDiaryToScenePlayer;
    }
}