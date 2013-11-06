namespace WindowsFormsApplication2
{
    partial class ScenesForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxDm = new System.Windows.Forms.CheckBox();
            this.checkBoxSe = new System.Windows.Forms.CheckBox();
            this.checkBoxCe = new System.Windows.Forms.CheckBox();
            this.listBoxScenes = new System.Windows.Forms.ListBox();
            this.buttonGetScenes = new System.Windows.Forms.Button();
            this.buttonSaveToFile = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxCe);
            this.groupBox1.Controls.Add(this.checkBoxSe);
            this.groupBox1.Controls.Add(this.checkBoxDm);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(148, 89);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Scenes Position";
            // 
            // checkBoxDm
            // 
            this.checkBoxDm.AutoSize = true;
            this.checkBoxDm.Location = new System.Drawing.Point(6, 19);
            this.checkBoxDm.Name = "checkBoxDm";
            this.checkBoxDm.Size = new System.Drawing.Size(104, 17);
            this.checkBoxDm.TabIndex = 1;
            this.checkBoxDm.Text = "Scenes in Demo";
            this.checkBoxDm.UseVisualStyleBackColor = true;
            // 
            // checkBoxSe
            // 
            this.checkBoxSe.AutoSize = true;
            this.checkBoxSe.Location = new System.Drawing.Point(6, 42);
            this.checkBoxSe.Name = "checkBoxSe";
            this.checkBoxSe.Size = new System.Drawing.Size(106, 17);
            this.checkBoxSe.TabIndex = 2;
            this.checkBoxSe.Text = "Scenes in 2 hour";
            this.checkBoxSe.UseVisualStyleBackColor = true;
            // 
            // checkBoxCe
            // 
            this.checkBoxCe.AutoSize = true;
            this.checkBoxCe.Location = new System.Drawing.Point(6, 65);
            this.checkBoxCe.Name = "checkBoxCe";
            this.checkBoxCe.Size = new System.Drawing.Size(122, 17);
            this.checkBoxCe.TabIndex = 3;
            this.checkBoxCe.Text = "Scenes in Collectors";
            this.checkBoxCe.UseVisualStyleBackColor = true;
            // 
            // listBoxScenes
            // 
            this.listBoxScenes.FormattingEnabled = true;
            this.listBoxScenes.Location = new System.Drawing.Point(166, 12);
            this.listBoxScenes.Name = "listBoxScenes";
            this.listBoxScenes.Size = new System.Drawing.Size(212, 277);
            this.listBoxScenes.Sorted = true;
            this.listBoxScenes.TabIndex = 4;
            this.listBoxScenes.SelectedIndexChanged += new System.EventHandler(this.listBoxScenes_SelectedIndexChanged);
            // 
            // buttonGetScenes
            // 
            this.buttonGetScenes.Location = new System.Drawing.Point(27, 107);
            this.buttonGetScenes.Name = "buttonGetScenes";
            this.buttonGetScenes.Size = new System.Drawing.Size(113, 23);
            this.buttonGetScenes.TabIndex = 5;
            this.buttonGetScenes.Text = "Get Scenes";
            this.buttonGetScenes.UseVisualStyleBackColor = true;
            this.buttonGetScenes.Click += new System.EventHandler(this.buttonGetScenes_Click);
            // 
            // buttonSaveToFile
            // 
            this.buttonSaveToFile.Location = new System.Drawing.Point(27, 185);
            this.buttonSaveToFile.Name = "buttonSaveToFile";
            this.buttonSaveToFile.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveToFile.TabIndex = 6;
            this.buttonSaveToFile.Text = "Save To";
            this.buttonSaveToFile.UseVisualStyleBackColor = true;
            this.buttonSaveToFile.Click += new System.EventHandler(this.buttonSaveToFile_Click);
            // 
            // ScenesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 298);
            this.Controls.Add(this.buttonSaveToFile);
            this.Controls.Add(this.buttonGetScenes);
            this.Controls.Add(this.listBoxScenes);
            this.Controls.Add(this.groupBox1);
            this.Name = "ScenesForm";
            this.Text = "ScenesForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBoxCe;
        private System.Windows.Forms.CheckBox checkBoxSe;
        private System.Windows.Forms.CheckBox checkBoxDm;
        private System.Windows.Forms.ListBox listBoxScenes;
        private System.Windows.Forms.Button buttonGetScenes;
        private System.Windows.Forms.Button buttonSaveToFile;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}