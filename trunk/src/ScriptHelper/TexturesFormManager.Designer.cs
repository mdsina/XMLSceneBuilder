namespace WindowsFormsApplication2
{
    partial class TexturesFormManager
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.buttonTextUV = new System.Windows.Forms.Button();
            this.listBoxWhatFind = new System.Windows.Forms.ListBox();
            this.listBoxWhereFind = new System.Windows.Forms.ListBox();
            this.buttonCheckToUse = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBoxTexturePackConverter = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // buttonTextUV
            // 
            this.buttonTextUV.Location = new System.Drawing.Point(12, 12);
            this.buttonTextUV.Name = "buttonTextUV";
            this.buttonTextUV.Size = new System.Drawing.Size(75, 23);
            this.buttonTextUV.TabIndex = 0;
            this.buttonTextUV.Text = "TextUV";
            this.buttonTextUV.UseVisualStyleBackColor = true;
            this.buttonTextUV.Click += new System.EventHandler(this.buttonTextUV_Click);
            // 
            // listBoxWhatFind
            // 
            this.listBoxWhatFind.FormattingEnabled = true;
            this.listBoxWhatFind.Location = new System.Drawing.Point(12, 41);
            this.listBoxWhatFind.Name = "listBoxWhatFind";
            this.listBoxWhatFind.Size = new System.Drawing.Size(1208, 69);
            this.listBoxWhatFind.TabIndex = 2;
            // 
            // listBoxWhereFind
            // 
            this.listBoxWhereFind.FormattingEnabled = true;
            this.listBoxWhereFind.Location = new System.Drawing.Point(12, 116);
            this.listBoxWhereFind.Name = "listBoxWhereFind";
            this.listBoxWhereFind.Size = new System.Drawing.Size(1208, 693);
            this.listBoxWhereFind.TabIndex = 3;
            // 
            // buttonCheckToUse
            // 
            this.buttonCheckToUse.Location = new System.Drawing.Point(325, 12);
            this.buttonCheckToUse.Name = "buttonCheckToUse";
            this.buttonCheckToUse.Size = new System.Drawing.Size(103, 23);
            this.buttonCheckToUse.TabIndex = 4;
            this.buttonCheckToUse.Text = "Check pic to use";
            this.buttonCheckToUse.UseVisualStyleBackColor = true;
            this.buttonCheckToUse.Click += new System.EventHandler(this.buttonCheckToUse_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(434, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBoxTexturePackConverter
            // 
            this.checkBoxTexturePackConverter.AutoSize = true;
            this.checkBoxTexturePackConverter.Checked = true;
            this.checkBoxTexturePackConverter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxTexturePackConverter.Location = new System.Drawing.Point(93, 16);
            this.checkBoxTexturePackConverter.Name = "checkBoxTexturePackConverter";
            this.checkBoxTexturePackConverter.Size = new System.Drawing.Size(151, 17);
            this.checkBoxTexturePackConverter.TabIndex = 6;
            this.checkBoxTexturePackConverter.Text = "TexturePackConverter.xml";
            this.checkBoxTexturePackConverter.UseVisualStyleBackColor = true;
            // 
            // TexturesFormManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1227, 818);
            this.Controls.Add(this.checkBoxTexturePackConverter);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonCheckToUse);
            this.Controls.Add(this.listBoxWhereFind);
            this.Controls.Add(this.listBoxWhatFind);
            this.Controls.Add(this.buttonTextUV);
            this.Name = "TexturesFormManager";
            this.Text = "TexturesFormManager";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TexturesFormManager_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button buttonTextUV;
        private System.Windows.Forms.ListBox listBoxWhatFind;
        private System.Windows.Forms.ListBox listBoxWhereFind;
        private System.Windows.Forms.Button buttonCheckToUse;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBoxTexturePackConverter;
    }
}