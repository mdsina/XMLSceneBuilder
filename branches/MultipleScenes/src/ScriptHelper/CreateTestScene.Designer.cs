namespace WindowsFormsApplication2
{
    partial class CreateTestScene
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
            this.components = new System.ComponentModel.Container();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeaderType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderFramesCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderSpeed = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderVideoMode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxAddShader = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxShadersCount = new System.Windows.Forms.TextBox();
            this.buttonCreateShader = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.comboBoxHeight = new System.Windows.Forms.ComboBox();
            this.comboBoxWidth = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.labelCreateShader = new System.Windows.Forms.Label();
            this.textBoxFrameCount = new System.Windows.Forms.TextBox();
            this.textBoxAnimationSpeed = new System.Windows.Forms.TextBox();
            this.buttonRun = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxMode = new System.Windows.Forms.CheckBox();
            this.buttonCreateVideo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxVSize = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonAddTPack = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBoxRain = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBoxAddShader.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderType,
            this.columnHeaderSize,
            this.columnHeaderFramesCount,
            this.columnHeaderSpeed,
            this.columnHeaderVideoMode});
            this.listView1.ContextMenuStrip = this.contextMenuStrip1;
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(442, 552);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDown);
            // 
            // columnHeaderType
            // 
            this.columnHeaderType.Text = "Type";
            this.columnHeaderType.Width = 96;
            // 
            // columnHeaderSize
            // 
            this.columnHeaderSize.Text = "Size";
            this.columnHeaderSize.Width = 91;
            // 
            // columnHeaderFramesCount
            // 
            this.columnHeaderFramesCount.Text = "Frames Count";
            this.columnHeaderFramesCount.Width = 101;
            // 
            // columnHeaderSpeed
            // 
            this.columnHeaderSpeed.Text = "Speed";
            this.columnHeaderSpeed.Width = 71;
            // 
            // columnHeaderVideoMode
            // 
            this.columnHeaderVideoMode.Text = "Video Mode";
            this.columnHeaderVideoMode.Width = 73;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteItemToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(135, 26);
            // 
            // deleteItemToolStripMenuItem
            // 
            this.deleteItemToolStripMenuItem.Name = "deleteItemToolStripMenuItem";
            this.deleteItemToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.deleteItemToolStripMenuItem.Text = "Delete Item";
            this.deleteItemToolStripMenuItem.Click += new System.EventHandler(this.deleteItemToolStripMenuItem_Click);
            // 
            // groupBoxAddShader
            // 
            this.groupBoxAddShader.Controls.Add(this.label2);
            this.groupBoxAddShader.Controls.Add(this.textBoxShadersCount);
            this.groupBoxAddShader.Controls.Add(this.buttonCreateShader);
            this.groupBoxAddShader.Controls.Add(this.label13);
            this.groupBoxAddShader.Controls.Add(this.comboBoxHeight);
            this.groupBoxAddShader.Controls.Add(this.comboBoxWidth);
            this.groupBoxAddShader.Controls.Add(this.label14);
            this.groupBoxAddShader.Controls.Add(this.label9);
            this.groupBoxAddShader.Controls.Add(this.labelCreateShader);
            this.groupBoxAddShader.Controls.Add(this.textBoxFrameCount);
            this.groupBoxAddShader.Controls.Add(this.textBoxAnimationSpeed);
            this.groupBoxAddShader.Location = new System.Drawing.Point(460, 12);
            this.groupBoxAddShader.Name = "groupBoxAddShader";
            this.groupBoxAddShader.Size = new System.Drawing.Size(224, 161);
            this.groupBoxAddShader.TabIndex = 25;
            this.groupBoxAddShader.TabStop = false;
            this.groupBoxAddShader.Text = "Add shader";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 42;
            this.label2.Text = "Count";
            // 
            // textBoxShadersCount
            // 
            this.textBoxShadersCount.Location = new System.Drawing.Point(93, 104);
            this.textBoxShadersCount.Name = "textBoxShadersCount";
            this.textBoxShadersCount.Size = new System.Drawing.Size(123, 20);
            this.textBoxShadersCount.TabIndex = 41;
            this.textBoxShadersCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtType1_KeyPress);
            // 
            // buttonCreateShader
            // 
            this.buttonCreateShader.Location = new System.Drawing.Point(117, 130);
            this.buttonCreateShader.Name = "buttonCreateShader";
            this.buttonCreateShader.Size = new System.Drawing.Size(101, 23);
            this.buttonCreateShader.TabIndex = 40;
            this.buttonCreateShader.Text = "Create shader";
            this.buttonCreateShader.UseVisualStyleBackColor = true;
            this.buttonCreateShader.Click += new System.EventHandler(this.buttonCreateShader_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 28);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(27, 13);
            this.label13.TabIndex = 39;
            this.label13.Text = "Size";
            // 
            // comboBoxHeight
            // 
            this.comboBoxHeight.FormattingEnabled = true;
            this.comboBoxHeight.Items.AddRange(new object[] {
            "64",
            "128",
            "256",
            "512",
            "1024"});
            this.comboBoxHeight.Location = new System.Drawing.Point(158, 20);
            this.comboBoxHeight.Name = "comboBoxHeight";
            this.comboBoxHeight.Size = new System.Drawing.Size(58, 21);
            this.comboBoxHeight.TabIndex = 38;
            // 
            // comboBoxWidth
            // 
            this.comboBoxWidth.FormattingEnabled = true;
            this.comboBoxWidth.Items.AddRange(new object[] {
            "64",
            "128",
            "256",
            "512",
            "1024"});
            this.comboBoxWidth.Location = new System.Drawing.Point(94, 20);
            this.comboBoxWidth.Name = "comboBoxWidth";
            this.comboBoxWidth.Size = new System.Drawing.Size(58, 21);
            this.comboBoxWidth.TabIndex = 37;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 81);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(38, 13);
            this.label14.TabIndex = 36;
            this.label14.Text = "Speed";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 54);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "FrameCount";
            // 
            // labelCreateShader
            // 
            this.labelCreateShader.AutoSize = true;
            this.labelCreateShader.Location = new System.Drawing.Point(37, 422);
            this.labelCreateShader.Name = "labelCreateShader";
            this.labelCreateShader.Size = new System.Drawing.Size(0, 13);
            this.labelCreateShader.TabIndex = 24;
            // 
            // textBoxFrameCount
            // 
            this.textBoxFrameCount.Location = new System.Drawing.Point(93, 51);
            this.textBoxFrameCount.Name = "textBoxFrameCount";
            this.textBoxFrameCount.Size = new System.Drawing.Size(123, 20);
            this.textBoxFrameCount.TabIndex = 24;
            this.textBoxFrameCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtType1_KeyPress);
            // 
            // textBoxAnimationSpeed
            // 
            this.textBoxAnimationSpeed.Location = new System.Drawing.Point(93, 78);
            this.textBoxAnimationSpeed.Name = "textBoxAnimationSpeed";
            this.textBoxAnimationSpeed.Size = new System.Drawing.Size(123, 20);
            this.textBoxAnimationSpeed.TabIndex = 35;
            this.textBoxAnimationSpeed.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtType1_KeyPress);
            // 
            // buttonRun
            // 
            this.buttonRun.Location = new System.Drawing.Point(566, 466);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(118, 23);
            this.buttonRun.TabIndex = 27;
            this.buttonRun.Text = "buttonRun";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxMode);
            this.groupBox1.Controls.Add(this.buttonCreateVideo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBoxVSize);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(460, 179);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(224, 82);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add video";
            // 
            // checkBoxMode
            // 
            this.checkBoxMode.AutoSize = true;
            this.checkBoxMode.Location = new System.Drawing.Point(9, 53);
            this.checkBoxMode.Name = "checkBoxMode";
            this.checkBoxMode.Size = new System.Drawing.Size(92, 17);
            this.checkBoxMode.TabIndex = 41;
            this.checkBoxMode.Text = "Without alpha";
            this.checkBoxMode.UseVisualStyleBackColor = true;
            // 
            // buttonCreateVideo
            // 
            this.buttonCreateVideo.Location = new System.Drawing.Point(117, 49);
            this.buttonCreateVideo.Name = "buttonCreateVideo";
            this.buttonCreateVideo.Size = new System.Drawing.Size(101, 23);
            this.buttonCreateVideo.TabIndex = 40;
            this.buttonCreateVideo.Text = "Create video";
            this.buttonCreateVideo.UseVisualStyleBackColor = true;
            this.buttonCreateVideo.Click += new System.EventHandler(this.buttonCreateVideo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 39;
            this.label1.Text = "Size";
            // 
            // comboBoxVSize
            // 
            this.comboBoxVSize.FormattingEnabled = true;
            this.comboBoxVSize.Items.AddRange(new object[] {
            "1024 768",
            "1024 512",
            "1024 256",
            "1024 128",
            "1024 64",
            "512 512",
            "512 256",
            "512 128",
            "512 64",
            "256 256",
            "256 128",
            "256 64",
            "128 128",
            "128 64",
            "64 64"});
            this.comboBoxVSize.Location = new System.Drawing.Point(117, 20);
            this.comboBoxVSize.Name = "comboBoxVSize";
            this.comboBoxVSize.Size = new System.Drawing.Size(101, 21);
            this.comboBoxVSize.TabIndex = 37;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 422);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 24;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonAddTPack);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(460, 267);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(224, 47);
            this.groupBox2.TabIndex = 41;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Add TexturePack";
            // 
            // buttonAddTPack
            // 
            this.buttonAddTPack.Location = new System.Drawing.Point(93, 19);
            this.buttonAddTPack.Name = "buttonAddTPack";
            this.buttonAddTPack.Size = new System.Drawing.Size(125, 23);
            this.buttonAddTPack.TabIndex = 40;
            this.buttonAddTPack.Text = "Create Texture Pack";
            this.buttonAddTPack.UseVisualStyleBackColor = true;
            this.buttonAddTPack.Click += new System.EventHandler(this.buttonAddTPack_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(37, 422);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 13);
            this.label6.TabIndex = 24;
            // 
            // checkBoxRain
            // 
            this.checkBoxRain.AutoSize = true;
            this.checkBoxRain.Location = new System.Drawing.Point(469, 338);
            this.checkBoxRain.Name = "checkBoxRain";
            this.checkBoxRain.Size = new System.Drawing.Size(48, 17);
            this.checkBoxRain.TabIndex = 42;
            this.checkBoxRain.Text = "Rain";
            this.checkBoxRain.UseVisualStyleBackColor = true;
            // 
            // CreateTestScene
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 574);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.groupBoxAddShader);
            this.Controls.Add(this.checkBoxRain);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.buttonRun);
            this.Controls.Add(this.groupBox1);
            this.Name = "CreateTestScene";
            this.Text = "CreateTestScene";
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBoxAddShader.ResumeLayout(false);
            this.groupBoxAddShader.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeaderType;
        private System.Windows.Forms.ColumnHeader columnHeaderSize;
        private System.Windows.Forms.ColumnHeader columnHeaderFramesCount;
        private System.Windows.Forms.ColumnHeader columnHeaderSpeed;
        private System.Windows.Forms.GroupBox groupBoxAddShader;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labelCreateShader;
        private System.Windows.Forms.TextBox textBoxFrameCount;
        private System.Windows.Forms.TextBox textBoxAnimationSpeed;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox comboBoxHeight;
        private System.Windows.Forms.ComboBox comboBoxWidth;
        private System.Windows.Forms.Button buttonCreateShader;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteItemToolStripMenuItem;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonCreateVideo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxVSize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBoxMode;
        private System.Windows.Forms.ColumnHeader columnHeaderVideoMode;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonAddTPack;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBoxRain;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxShadersCount;
    }
}