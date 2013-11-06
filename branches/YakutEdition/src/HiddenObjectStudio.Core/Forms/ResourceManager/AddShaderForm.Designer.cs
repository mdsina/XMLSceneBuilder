namespace HiddenObjectStudio.Core.Forms
{
    partial class AddShaderForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxShaderName = new System.Windows.Forms.TextBox();
            this.textBoxTextureName = new System.Windows.Forms.TextBox();
            this.checkBoxTempTextures = new System.Windows.Forms.CheckBox();
            this.checkBoxMipMap = new System.Windows.Forms.CheckBox();
            this.textBoxFrameCount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonChooseTexture = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.Location = new System.Drawing.Point(103, 141);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(97, 23);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Shader name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Texture name";
            // 
            // textBoxShaderName
            // 
            this.textBoxShaderName.Location = new System.Drawing.Point(91, 6);
            this.textBoxShaderName.Name = "textBoxShaderName";
            this.textBoxShaderName.Size = new System.Drawing.Size(177, 20);
            this.textBoxShaderName.TabIndex = 3;
            // 
            // textBoxTextureName
            // 
            this.textBoxTextureName.AllowDrop = true;
            this.textBoxTextureName.Location = new System.Drawing.Point(91, 32);
            this.textBoxTextureName.Name = "textBoxTextureName";
            this.textBoxTextureName.Size = new System.Drawing.Size(177, 20);
            this.textBoxTextureName.TabIndex = 4;
            this.textBoxTextureName.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBoxTextureName_DragDrop);
            this.textBoxTextureName.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBoxTextureName_DragEnter);
            // 
            // checkBoxTempTextures
            // 
            this.checkBoxTempTextures.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxTempTextures.AutoSize = true;
            this.checkBoxTempTextures.Location = new System.Drawing.Point(174, 75);
            this.checkBoxTempTextures.Name = "checkBoxTempTextures";
            this.checkBoxTempTextures.Size = new System.Drawing.Size(116, 17);
            this.checkBoxTempTextures.TabIndex = 5;
            this.checkBoxTempTextures.Text = "Temporary textures";
            this.checkBoxTempTextures.UseVisualStyleBackColor = true;
            // 
            // checkBoxMipMap
            // 
            this.checkBoxMipMap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxMipMap.AutoSize = true;
            this.checkBoxMipMap.Location = new System.Drawing.Point(174, 98);
            this.checkBoxMipMap.Name = "checkBoxMipMap";
            this.checkBoxMipMap.Size = new System.Drawing.Size(67, 17);
            this.checkBoxMipMap.TabIndex = 6;
            this.checkBoxMipMap.Text = "Mip Map";
            this.checkBoxMipMap.UseVisualStyleBackColor = true;
            // 
            // textBoxFrameCount
            // 
            this.textBoxFrameCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxFrameCount.Location = new System.Drawing.Point(91, 72);
            this.textBoxFrameCount.Name = "textBoxFrameCount";
            this.textBoxFrameCount.Size = new System.Drawing.Size(37, 20);
            this.textBoxFrameCount.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Frame Count";
            // 
            // buttonChooseTexture
            // 
            this.buttonChooseTexture.Location = new System.Drawing.Point(274, 32);
            this.buttonChooseTexture.Name = "buttonChooseTexture";
            this.buttonChooseTexture.Size = new System.Drawing.Size(25, 20);
            this.buttonChooseTexture.TabIndex = 9;
            this.buttonChooseTexture.Text = "...";
            this.buttonChooseTexture.UseVisualStyleBackColor = true;
            this.buttonChooseTexture.Click += new System.EventHandler(this.buttonChooseTexture_Click);
            // 
            // AddShaderForm
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 167);
            this.Controls.Add(this.buttonChooseTexture);
            this.Controls.Add(this.textBoxFrameCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.checkBoxMipMap);
            this.Controls.Add(this.checkBoxTempTextures);
            this.Controls.Add(this.textBoxTextureName);
            this.Controls.Add(this.textBoxShaderName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonOK);
            this.Name = "AddShaderForm";
            this.Text = "AddAndEditShaderForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxShaderName;
        private System.Windows.Forms.TextBox textBoxTextureName;
        private System.Windows.Forms.CheckBox checkBoxTempTextures;
        private System.Windows.Forms.CheckBox checkBoxMipMap;
        private System.Windows.Forms.TextBox textBoxFrameCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonChooseTexture;
    }
}