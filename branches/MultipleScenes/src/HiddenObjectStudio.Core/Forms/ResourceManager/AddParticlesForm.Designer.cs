namespace HiddenObjectStudio.Core.Forms
{
    partial class AddParticlesForm
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
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonChooseTexture = new System.Windows.Forms.Button();
            this.checkBoxTempTextures = new System.Windows.Forms.CheckBox();
            this.textBoxParticlesFileName = new System.Windows.Forms.TextBox();
            this.textBoxParticlesName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.Location = new System.Drawing.Point(93, 84);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(114, 23);
            this.buttonOK.TabIndex = 19;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonChooseTexture
            // 
            this.buttonChooseTexture.Location = new System.Drawing.Point(274, 32);
            this.buttonChooseTexture.Name = "buttonChooseTexture";
            this.buttonChooseTexture.Size = new System.Drawing.Size(25, 20);
            this.buttonChooseTexture.TabIndex = 18;
            this.buttonChooseTexture.Text = "...";
            this.buttonChooseTexture.UseVisualStyleBackColor = true;
            this.buttonChooseTexture.Click += new System.EventHandler(this.buttonChooseTexture_Click);
            // 
            // checkBoxTempTextures
            // 
            this.checkBoxTempTextures.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxTempTextures.AutoSize = true;
            this.checkBoxTempTextures.Location = new System.Drawing.Point(175, 61);
            this.checkBoxTempTextures.Name = "checkBoxTempTextures";
            this.checkBoxTempTextures.Size = new System.Drawing.Size(116, 17);
            this.checkBoxTempTextures.TabIndex = 17;
            this.checkBoxTempTextures.Text = "Temporary textures";
            this.checkBoxTempTextures.UseVisualStyleBackColor = true;
            // 
            // textBoxParticlesFileName
            // 
            this.textBoxParticlesFileName.AllowDrop = true;
            this.textBoxParticlesFileName.Location = new System.Drawing.Point(104, 32);
            this.textBoxParticlesFileName.Name = "textBoxParticlesFileName";
            this.textBoxParticlesFileName.Size = new System.Drawing.Size(164, 20);
            this.textBoxParticlesFileName.TabIndex = 16;
            this.textBoxParticlesFileName.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBoxParticlesFileName_DragDrop);
            this.textBoxParticlesFileName.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBoxParticlesFileName_DragEnter);
            // 
            // textBoxParticlesName
            // 
            this.textBoxParticlesName.Location = new System.Drawing.Point(104, 6);
            this.textBoxParticlesName.Name = "textBoxParticlesName";
            this.textBoxParticlesName.Size = new System.Drawing.Size(164, 20);
            this.textBoxParticlesName.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Particles File Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Particles name:";
            // 
            // AddParticlesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 138);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonChooseTexture);
            this.Controls.Add(this.checkBoxTempTextures);
            this.Controls.Add(this.textBoxParticlesFileName);
            this.Controls.Add(this.textBoxParticlesName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddParticlesForm";
            this.Text = "AddParticlesForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonChooseTexture;
        private System.Windows.Forms.CheckBox checkBoxTempTextures;
        private System.Windows.Forms.TextBox textBoxParticlesFileName;
        private System.Windows.Forms.TextBox textBoxParticlesName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}