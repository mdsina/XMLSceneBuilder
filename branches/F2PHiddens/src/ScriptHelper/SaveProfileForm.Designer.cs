namespace WindowsFormsApplication2
{
    partial class SaveProfileForm
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
            this.textBoxProfileFolderName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonChangeProfileFolder = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxSaveProfileWithName = new System.Windows.Forms.TextBox();
            this.buttonSaveProfile = new System.Windows.Forms.Button();
            this.buttonLoadProfile = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.listBoxProfiles = new System.Windows.Forms.ListBox();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxProfileFolderName
            // 
            this.textBoxProfileFolderName.Location = new System.Drawing.Point(142, 16);
            this.textBoxProfileFolderName.Name = "textBoxProfileFolderName";
            this.textBoxProfileFolderName.Size = new System.Drawing.Size(333, 20);
            this.textBoxProfileFolderName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Profile folder name:";
            // 
            // buttonChangeProfileFolder
            // 
            this.buttonChangeProfileFolder.Location = new System.Drawing.Point(481, 14);
            this.buttonChangeProfileFolder.Name = "buttonChangeProfileFolder";
            this.buttonChangeProfileFolder.Size = new System.Drawing.Size(24, 23);
            this.buttonChangeProfileFolder.TabIndex = 2;
            this.buttonChangeProfileFolder.Text = "...";
            this.buttonChangeProfileFolder.UseVisualStyleBackColor = true;
            this.buttonChangeProfileFolder.Click += new System.EventHandler(this.buttonChangeProfileFolder_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Save profile with name:";
            // 
            // textBoxSaveProfileWithName
            // 
            this.textBoxSaveProfileWithName.Location = new System.Drawing.Point(142, 49);
            this.textBoxSaveProfileWithName.Name = "textBoxSaveProfileWithName";
            this.textBoxSaveProfileWithName.Size = new System.Drawing.Size(333, 20);
            this.textBoxSaveProfileWithName.TabIndex = 4;
            // 
            // buttonSaveProfile
            // 
            this.buttonSaveProfile.Location = new System.Drawing.Point(102, 84);
            this.buttonSaveProfile.Name = "buttonSaveProfile";
            this.buttonSaveProfile.Size = new System.Drawing.Size(133, 54);
            this.buttonSaveProfile.TabIndex = 5;
            this.buttonSaveProfile.Text = "Save Profile";
            this.buttonSaveProfile.UseVisualStyleBackColor = true;
            this.buttonSaveProfile.Click += new System.EventHandler(this.buttonSaveProfile_Click);
            // 
            // buttonLoadProfile
            // 
            this.buttonLoadProfile.Location = new System.Drawing.Point(268, 84);
            this.buttonLoadProfile.Name = "buttonLoadProfile";
            this.buttonLoadProfile.Size = new System.Drawing.Size(133, 54);
            this.buttonLoadProfile.TabIndex = 6;
            this.buttonLoadProfile.Text = "Load Profile";
            this.buttonLoadProfile.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Saved profiles:";
            // 
            // listBoxProfiles
            // 
            this.listBoxProfiles.FormattingEnabled = true;
            this.listBoxProfiles.Location = new System.Drawing.Point(15, 192);
            this.listBoxProfiles.Name = "listBoxProfiles";
            this.listBoxProfiles.ScrollAlwaysVisible = true;
            this.listBoxProfiles.Size = new System.Drawing.Size(506, 342);
            this.listBoxProfiles.TabIndex = 9;
            this.listBoxProfiles.Tag = "";
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(102, 163);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(98, 23);
            this.buttonRefresh.TabIndex = 10;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // SaveProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 541);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.listBoxProfiles);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonLoadProfile);
            this.Controls.Add(this.buttonSaveProfile);
            this.Controls.Add(this.textBoxSaveProfileWithName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonChangeProfileFolder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxProfileFolderName);
            this.Name = "SaveProfileForm";
            this.Text = "SaveProfileForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxProfileFolderName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonChangeProfileFolder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxSaveProfileWithName;
        private System.Windows.Forms.Button buttonSaveProfile;
        private System.Windows.Forms.Button buttonLoadProfile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBoxProfiles;
        private System.Windows.Forms.Button buttonRefresh;
    }
}