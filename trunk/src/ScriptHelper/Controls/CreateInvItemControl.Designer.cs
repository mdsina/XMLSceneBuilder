namespace WindowsFormsApplication2.Controls
{
    partial class CreateInvItemControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxGameItemName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonSelectBigPic = new System.Windows.Forms.Button();
            this.textBoxBigPicFilePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSelectSmallPic = new System.Windows.Forms.Button();
            this.textBoxSmallPicFilePath = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button5AddNewItem = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxAddNewItem = new System.Windows.Forms.TextBox();
            this.openFileDialogPic = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanel2);
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxGameItemName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.buttonSelectBigPic);
            this.groupBox1.Controls.Add(this.textBoxBigPicFilePath);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.buttonSelectSmallPic);
            this.groupBox1.Controls.Add(this.textBoxSmallPicFilePath);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.button5AddNewItem);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBoxAddNewItem);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(600, 443);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add new Inventory item";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(334, 176);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(256, 256);
            this.flowLayoutPanel2.TabIndex = 26;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(334, 106);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(64, 64);
            this.flowLayoutPanel1.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Game item name:";
            // 
            // textBoxGameItemName
            // 
            this.textBoxGameItemName.Location = new System.Drawing.Point(6, 88);
            this.textBoxGameItemName.Name = "textBoxGameItemName";
            this.textBoxGameItemName.Size = new System.Drawing.Size(169, 20);
            this.textBoxGameItemName.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 182);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Big picture fileName:";
            // 
            // buttonSelectBigPic
            // 
            this.buttonSelectBigPic.Location = new System.Drawing.Point(286, 196);
            this.buttonSelectBigPic.Name = "buttonSelectBigPic";
            this.buttonSelectBigPic.Size = new System.Drawing.Size(26, 23);
            this.buttonSelectBigPic.TabIndex = 21;
            this.buttonSelectBigPic.Text = "...";
            this.buttonSelectBigPic.UseVisualStyleBackColor = true;
            this.buttonSelectBigPic.Click += new System.EventHandler(this.buttonSelectBigPic_Click);
            // 
            // textBoxBigPicFilePath
            // 
            this.textBoxBigPicFilePath.Enabled = false;
            this.textBoxBigPicFilePath.Location = new System.Drawing.Point(6, 198);
            this.textBoxBigPicFilePath.Name = "textBoxBigPicFilePath";
            this.textBoxBigPicFilePath.Size = new System.Drawing.Size(274, 20);
            this.textBoxBigPicFilePath.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Small picture fileName:";
            // 
            // buttonSelectSmallPic
            // 
            this.buttonSelectSmallPic.Location = new System.Drawing.Point(286, 128);
            this.buttonSelectSmallPic.Name = "buttonSelectSmallPic";
            this.buttonSelectSmallPic.Size = new System.Drawing.Size(26, 23);
            this.buttonSelectSmallPic.TabIndex = 18;
            this.buttonSelectSmallPic.Text = "...";
            this.buttonSelectSmallPic.UseVisualStyleBackColor = true;
            this.buttonSelectSmallPic.Click += new System.EventHandler(this.buttonSelectSmallPic_Click);
            // 
            // textBoxSmallPicFilePath
            // 
            this.textBoxSmallPicFilePath.Enabled = false;
            this.textBoxSmallPicFilePath.Location = new System.Drawing.Point(6, 131);
            this.textBoxSmallPicFilePath.Name = "textBoxSmallPicFilePath";
            this.textBoxSmallPicFilePath.Size = new System.Drawing.Size(274, 20);
            this.textBoxSmallPicFilePath.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 251);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 13);
            this.label6.TabIndex = 16;
            // 
            // button5AddNewItem
            // 
            this.button5AddNewItem.Location = new System.Drawing.Point(12, 246);
            this.button5AddNewItem.Name = "button5AddNewItem";
            this.button5AddNewItem.Size = new System.Drawing.Size(100, 23);
            this.button5AddNewItem.TabIndex = 15;
            this.button5AddNewItem.Text = "Add new Item";
            this.button5AddNewItem.UseVisualStyleBackColor = true;
            this.button5AddNewItem.Click += new System.EventHandler(this.button5AddNewItem_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Item Name:";
            // 
            // textBoxAddNewItem
            // 
            this.textBoxAddNewItem.Location = new System.Drawing.Point(6, 48);
            this.textBoxAddNewItem.Name = "textBoxAddNewItem";
            this.textBoxAddNewItem.Size = new System.Drawing.Size(169, 20);
            this.textBoxAddNewItem.TabIndex = 15;
            // 
            // openFileDialogPic
            // 
            this.openFileDialogPic.FileName = "openFileDialogPic";
            // 
            // CreateInvItemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "CreateInvItemControl";
            this.Size = new System.Drawing.Size(610, 453);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button5AddNewItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxAddNewItem;
        private System.Windows.Forms.OpenFileDialog openFileDialogPic;
        private System.Windows.Forms.Button buttonSelectSmallPic;
        private System.Windows.Forms.TextBox textBoxSmallPicFilePath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonSelectBigPic;
        private System.Windows.Forms.TextBox textBoxBigPicFilePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxGameItemName;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
