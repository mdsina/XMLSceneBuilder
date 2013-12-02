namespace HiddenObjectsXMLBuilder
{
    partial class ScenesForRM
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
            this.scenesList = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openResourceManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // scenesList
            // 
            this.scenesList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scenesList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.scenesList.ContextMenuStrip = this.contextMenuStrip1;
            this.scenesList.GridLines = true;
            this.scenesList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.scenesList.Location = new System.Drawing.Point(5, 12);
            this.scenesList.Name = "scenesList";
            this.scenesList.Size = new System.Drawing.Size(388, 648);
            this.scenesList.TabIndex = 19;
            this.scenesList.UseCompatibleStateImageBehavior = false;
            this.scenesList.View = System.Windows.Forms.View.Details;
            this.scenesList.SelectedIndexChanged += new System.EventHandler(this.scenesList_SelectedIndexChanged);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Scenes";
            this.columnHeader2.Width = 1000;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openResourceManagerToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(205, 48);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // openResourceManagerToolStripMenuItem
            // 
            this.openResourceManagerToolStripMenuItem.Name = "openResourceManagerToolStripMenuItem";
            this.openResourceManagerToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.openResourceManagerToolStripMenuItem.Text = "Open Resource Manager";
            this.openResourceManagerToolStripMenuItem.Click += new System.EventHandler(this.openResourceManagerToolStripMenuItem_Click);
            // 
            // ScenesForRM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 672);
            this.Controls.Add(this.scenesList);
            this.Name = "ScenesForRM";
            this.Text = "ScenesForRM";
            this.Load += new System.EventHandler(this.ScenesForRM_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView scenesList;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openResourceManagerToolStripMenuItem;
    }
}