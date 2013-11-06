namespace QuestMonkey
{
	partial class SelectLayerForm
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
			this.treeViewLayers = new System.Windows.Forms.TreeView();
			this.buttonSelectAndClose = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// treeViewLayers
			// 
			this.treeViewLayers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.treeViewLayers.Location = new System.Drawing.Point(12, 12);
			this.treeViewLayers.Name = "treeViewLayers";
			this.treeViewLayers.Size = new System.Drawing.Size(382, 398);
			this.treeViewLayers.TabIndex = 0;
			this.treeViewLayers.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewLayers_AfterSelect);
			this.treeViewLayers.DoubleClick += new System.EventHandler(this.treeViewLayers_DoubleClick);
			// 
			// buttonSelectAndClose
			// 
			this.buttonSelectAndClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSelectAndClose.Location = new System.Drawing.Point(238, 418);
			this.buttonSelectAndClose.Name = "buttonSelectAndClose";
			this.buttonSelectAndClose.Size = new System.Drawing.Size(156, 23);
			this.buttonSelectAndClose.TabIndex = 2;
			this.buttonSelectAndClose.Text = "Select and close";
			this.buttonSelectAndClose.UseVisualStyleBackColor = true;
			this.buttonSelectAndClose.Click += new System.EventHandler(this.buttonSelectAndClose_Click);
			// 
			// SelectLayerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(406, 453);
			this.Controls.Add(this.buttonSelectAndClose);
			this.Controls.Add(this.treeViewLayers);
			this.Name = "SelectLayerForm";
			this.Text = "SelectLayerForm";
			this.Load += new System.EventHandler(this.SelectLayerForm_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TreeView treeViewLayers;
		private System.Windows.Forms.Button buttonSelectAndClose;

	}
}