namespace HiddenObjectStudio.Core.Forms
{
    partial class AddTexturePackForm
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
            this.textBoxTexturePackFileName = new System.Windows.Forms.TextBox();
            this.textBoxTexturePackName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSelectTpfFile = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxTexturePackFileName
            // 
            this.textBoxTexturePackFileName.AllowDrop = true;
            this.textBoxTexturePackFileName.Location = new System.Drawing.Point(122, 38);
            this.textBoxTexturePackFileName.Name = "textBoxTexturePackFileName";
            this.textBoxTexturePackFileName.Size = new System.Drawing.Size(177, 20);
            this.textBoxTexturePackFileName.TabIndex = 8;
            this.textBoxTexturePackFileName.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBoxTexturePackFileName_DragDrop);
            this.textBoxTexturePackFileName.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBoxTexturePackFileName_DragEnter);
            // 
            // textBoxTexturePackName
            // 
            this.textBoxTexturePackName.Location = new System.Drawing.Point(122, 12);
            this.textBoxTexturePackName.Name = "textBoxTexturePackName";
            this.textBoxTexturePackName.Size = new System.Drawing.Size(177, 20);
            this.textBoxTexturePackName.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "TexturePack file name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "TexturePack name:";
            // 
            // buttonSelectTpfFile
            // 
            this.buttonSelectTpfFile.Location = new System.Drawing.Point(305, 36);
            this.buttonSelectTpfFile.Name = "buttonSelectTpfFile";
            this.buttonSelectTpfFile.Size = new System.Drawing.Size(29, 23);
            this.buttonSelectTpfFile.TabIndex = 9;
            this.buttonSelectTpfFile.Text = "...";
            this.buttonSelectTpfFile.UseVisualStyleBackColor = true;
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(122, 80);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(87, 23);
            this.buttonOk.TabIndex = 10;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // AddTexturePackForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 115);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonSelectTpfFile);
            this.Controls.Add(this.textBoxTexturePackFileName);
            this.Controls.Add(this.textBoxTexturePackName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddTexturePackForm";
            this.Text = "AddTexturePackForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxTexturePackFileName;
        private System.Windows.Forms.TextBox textBoxTexturePackName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSelectTpfFile;
        private System.Windows.Forms.Button buttonOk;
    }
}