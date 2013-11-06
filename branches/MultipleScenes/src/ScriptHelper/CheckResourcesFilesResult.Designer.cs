namespace WindowsFormsApplication2
{
    partial class CheckResourcesFilesResult
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
            this.listViewPngResources = new System.Windows.Forms.ListView();
            this.columnResourcesFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderInDDSTexturePreparer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonAddToDDSTexturePreparer = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.buttonCheckSubsTT = new System.Windows.Forms.Button();
            this.buttonCheckResourcesToUsing = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewPngResources
            // 
            this.listViewPngResources.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnResourcesFile,
            this.columnHeader1,
            this.columnHeaderInDDSTexturePreparer});
            this.listViewPngResources.Dock = System.Windows.Forms.DockStyle.Top;
            this.listViewPngResources.Location = new System.Drawing.Point(0, 0);
            this.listViewPngResources.Name = "listViewPngResources";
            this.listViewPngResources.Size = new System.Drawing.Size(860, 449);
            this.listViewPngResources.TabIndex = 0;
            this.listViewPngResources.UseCompatibleStateImageBehavior = false;
            this.listViewPngResources.View = System.Windows.Forms.View.Details;
            // 
            // columnResourcesFile
            // 
            this.columnResourcesFile.Text = "FilePath:";
            this.columnResourcesFile.Width = 375;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Text:";
            this.columnHeader1.Width = 395;
            // 
            // columnHeaderInDDSTexturePreparer
            // 
            this.columnHeaderInDDSTexturePreparer.Text = "In DDSTexturePreparer";
            // 
            // buttonAddToDDSTexturePreparer
            // 
            this.buttonAddToDDSTexturePreparer.Location = new System.Drawing.Point(658, 473);
            this.buttonAddToDDSTexturePreparer.Name = "buttonAddToDDSTexturePreparer";
            this.buttonAddToDDSTexturePreparer.Size = new System.Drawing.Size(190, 23);
            this.buttonAddToDDSTexturePreparer.TabIndex = 1;
            this.buttonAddToDDSTexturePreparer.Text = "Add To DDSTexturePreparer.xml";
            this.buttonAddToDDSTexturePreparer.UseVisualStyleBackColor = true;
            this.buttonAddToDDSTexturePreparer.Click += new System.EventHandler(this.buttonAddToDDSTexturePreparer_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // buttonCheckSubsTT
            // 
            this.buttonCheckSubsTT.Location = new System.Drawing.Point(12, 473);
            this.buttonCheckSubsTT.Name = "buttonCheckSubsTT";
            this.buttonCheckSubsTT.Size = new System.Drawing.Size(159, 23);
            this.buttonCheckSubsTT.TabIndex = 2;
            this.buttonCheckSubsTT.Text = "Check subs to temporary";
            this.buttonCheckSubsTT.UseVisualStyleBackColor = true;
            this.buttonCheckSubsTT.Click += new System.EventHandler(this.buttonCheckSubsTT_Click);
            // 
            // buttonCheckResourcesToUsing
            // 
            this.buttonCheckResourcesToUsing.Location = new System.Drawing.Point(177, 473);
            this.buttonCheckResourcesToUsing.Name = "buttonCheckResourcesToUsing";
            this.buttonCheckResourcesToUsing.Size = new System.Drawing.Size(159, 23);
            this.buttonCheckResourcesToUsing.TabIndex = 3;
            this.buttonCheckResourcesToUsing.Text = "Check Resources To Using";
            this.buttonCheckResourcesToUsing.UseVisualStyleBackColor = true;
            this.buttonCheckResourcesToUsing.Click += new System.EventHandler(this.buttonCheckResourcesToUsing_Click);
            // 
            // CheckResourcesFilesResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 518);
            this.Controls.Add(this.buttonCheckResourcesToUsing);
            this.Controls.Add(this.buttonCheckSubsTT);
            this.Controls.Add(this.buttonAddToDDSTexturePreparer);
            this.Controls.Add(this.listViewPngResources);
            this.Name = "CheckResourcesFilesResult";
            this.Text = "CheckResourcesFilesResult";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewPngResources;
        private System.Windows.Forms.ColumnHeader columnResourcesFile;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button buttonAddToDDSTexturePreparer;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ColumnHeader columnHeaderInDDSTexturePreparer;
        private System.Windows.Forms.Button buttonCheckSubsTT;
        private System.Windows.Forms.Button buttonCheckResourcesToUsing;
    }
}