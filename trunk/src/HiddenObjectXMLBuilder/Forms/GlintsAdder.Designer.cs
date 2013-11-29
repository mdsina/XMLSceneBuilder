namespace HiddenObjectsXMLBuilder
{
    partial class GlintsAdder
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.scenesList = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AddGlintButton = new System.Windows.Forms.Button();
            this.layersList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 12);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.scenesList);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.AddGlintButton);
            this.splitContainer1.Panel2.Controls.Add(this.layersList);
            this.splitContainer1.Size = new System.Drawing.Size(800, 473);
            this.splitContainer1.SplitterDistance = 379;
            this.splitContainer1.TabIndex = 16;
            // 
            // scenesList
            // 
            this.scenesList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scenesList.CheckBoxes = true;
            this.scenesList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.scenesList.GridLines = true;
            this.scenesList.Location = new System.Drawing.Point(3, 0);
            this.scenesList.Name = "scenesList";
            this.scenesList.Size = new System.Drawing.Size(377, 473);
            this.scenesList.TabIndex = 18;
            this.scenesList.UseCompatibleStateImageBehavior = false;
            this.scenesList.View = System.Windows.Forms.View.Details;
            this.scenesList.SelectedIndexChanged += new System.EventHandler(this.scenesList_SelectedIndexChanged);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Scenes";
            this.columnHeader2.Width = 1000;
            // 
            // AddGlintButton
            // 
            this.AddGlintButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.AddGlintButton.Location = new System.Drawing.Point(0, 440);
            this.AddGlintButton.Margin = new System.Windows.Forms.Padding(3, 3, 3, 20);
            this.AddGlintButton.Name = "AddGlintButton";
            this.AddGlintButton.Size = new System.Drawing.Size(417, 33);
            this.AddGlintButton.TabIndex = 18;
            this.AddGlintButton.Text = "Add glint for slected layer";
            this.AddGlintButton.UseVisualStyleBackColor = true;
            this.AddGlintButton.Click += new System.EventHandler(this.AddGlintButton_Click);
            // 
            // layersList
            // 
            this.layersList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.layersList.CheckBoxes = true;
            this.layersList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.layersList.GridLines = true;
            this.layersList.Location = new System.Drawing.Point(3, 0);
            this.layersList.Name = "layersList";
            this.layersList.Size = new System.Drawing.Size(411, 419);
            this.layersList.TabIndex = 17;
            this.layersList.UseCompatibleStateImageBehavior = false;
            this.layersList.View = System.Windows.Forms.View.Details;
            this.layersList.SelectedIndexChanged += new System.EventHandler(this.layersList_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Scene\'s Layers";
            this.columnHeader1.Width = 1000;
            // 
            // GlintsAdder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 546);
            this.Controls.Add(this.splitContainer1);
            this.Name = "GlintsAdder";
            this.Text = "GlintsAdder";
            this.Load += new System.EventHandler(this.GlintsAdder_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView scenesList;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ListView layersList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button AddGlintButton;

    }
}