namespace HiddenObjectStudio.Core.Forms
{
    partial class AddModelForm
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
            this.checkBoxTempTextures = new System.Windows.Forms.CheckBox();
            this.textBoxModelFileName = new System.Windows.Forms.TextBox();
            this.textBoxModelName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonChooseTexture = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkBoxTempTextures
            // 
            this.checkBoxTempTextures.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxTempTextures.AutoSize = true;
            this.checkBoxTempTextures.Location = new System.Drawing.Point(175, 60);
            this.checkBoxTempTextures.Name = "checkBoxTempTextures";
            this.checkBoxTempTextures.Size = new System.Drawing.Size(116, 17);
            this.checkBoxTempTextures.TabIndex = 10;
            this.checkBoxTempTextures.Text = "Temporary textures";
            this.checkBoxTempTextures.UseVisualStyleBackColor = true;
            // 
            // textBoxModelFileName
            // 
            this.textBoxModelFileName.AllowDrop = true;
            this.textBoxModelFileName.Location = new System.Drawing.Point(104, 32);
            this.textBoxModelFileName.Name = "textBoxModelFileName";
            this.textBoxModelFileName.Size = new System.Drawing.Size(164, 20);
            this.textBoxModelFileName.TabIndex = 9;
            this.textBoxModelFileName.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBoxModelFileName_DragDrop);
            this.textBoxModelFileName.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBoxModelFileName_DragEnter);
            // 
            // textBoxModelName
            // 
            this.textBoxModelName.Location = new System.Drawing.Point(104, 6);
            this.textBoxModelName.Name = "textBoxModelName";
            this.textBoxModelName.Size = new System.Drawing.Size(164, 20);
            this.textBoxModelName.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Model File Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Model name:";
            // 
            // buttonChooseTexture
            // 
            this.buttonChooseTexture.Location = new System.Drawing.Point(274, 32);
            this.buttonChooseTexture.Name = "buttonChooseTexture";
            this.buttonChooseTexture.Size = new System.Drawing.Size(25, 20);
            this.buttonChooseTexture.TabIndex = 11;
            this.buttonChooseTexture.Text = "...";
            this.buttonChooseTexture.UseVisualStyleBackColor = true;
            this.buttonChooseTexture.Click += new System.EventHandler(this.buttonChooseTexture_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.Location = new System.Drawing.Point(91, 93);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(95, 23);
            this.buttonOK.TabIndex = 12;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // AddModelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 218);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonChooseTexture);
            this.Controls.Add(this.checkBoxTempTextures);
            this.Controls.Add(this.textBoxModelFileName);
            this.Controls.Add(this.textBoxModelName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddModelForm";
            this.Text = "AddModelForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxTempTextures;
        private System.Windows.Forms.TextBox textBoxModelFileName;
        private System.Windows.Forms.TextBox textBoxModelName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonChooseTexture;
        private System.Windows.Forms.Button buttonOK;
    }
}