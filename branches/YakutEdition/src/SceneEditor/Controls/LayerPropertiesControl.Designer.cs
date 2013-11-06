namespace SceneEditor
{
	partial class LayerPropertiesControl
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
            this.checkBoxScaleUV = new System.Windows.Forms.CheckBox();
            this.checkBoxSize = new System.Windows.Forms.CheckBox();
            this.comboBoxModel = new System.Windows.Forms.ComboBox();
            this.checkBoxModel = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxFlipUV = new System.Windows.Forms.ComboBox();
            this.checkBoxFlipUV = new System.Windows.Forms.CheckBox();
            this.comboBoxShader = new System.Windows.Forms.ComboBox();
            this.checkBoxShader = new System.Windows.Forms.CheckBox();
            this.checkBoxPosition = new System.Windows.Forms.CheckBox();
            this.checkBoxScale = new System.Windows.Forms.CheckBox();
            this.comboBoxTextureName = new System.Windows.Forms.ComboBox();
            this.comboBoxTexturePack = new System.Windows.Forms.ComboBox();
            this.checkBoxTexturePack = new System.Windows.Forms.CheckBox();
            this.textBoxSizeX = new System.Windows.Forms.TextBox();
            this.textBoxSizeY = new System.Windows.Forms.TextBox();
            this.textBoxPositionY = new System.Windows.Forms.TextBox();
            this.textBoxPositionX = new System.Windows.Forms.TextBox();
            this.textBoxScaleY = new System.Windows.Forms.TextBox();
            this.textBoxScaleX = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonEditControlProperties = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxLayerName = new System.Windows.Forms.TextBox();
            this.checkBoxLayerAlwaysAllowClicks = new System.Windows.Forms.CheckBox();
            this.checkBoxDoNotDiscardItem = new System.Windows.Forms.CheckBox();
            this.checkBoxLayerAlpha = new System.Windows.Forms.CheckBox();
            this.checkBoxLayerEnabled = new System.Windows.Forms.CheckBox();
            this.comboBoxLayerCursor = new System.Windows.Forms.ComboBox();
            this.checkBoxLayerCursor = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // checkBoxScaleUV
            // 
            this.checkBoxScaleUV.AutoSize = true;
            this.checkBoxScaleUV.Location = new System.Drawing.Point(3, 227);
            this.checkBoxScaleUV.Name = "checkBoxScaleUV";
            this.checkBoxScaleUV.Size = new System.Drawing.Size(69, 17);
            this.checkBoxScaleUV.TabIndex = 39;
            this.checkBoxScaleUV.Text = "scale_uv";
            this.checkBoxScaleUV.UseVisualStyleBackColor = true;
            this.checkBoxScaleUV.CheckStateChanged += new System.EventHandler(this.checkBoxScaleUV_CheckedChanged);
            // 
            // checkBoxSize
            // 
            this.checkBoxSize.AutoSize = true;
            this.checkBoxSize.Location = new System.Drawing.Point(3, 200);
            this.checkBoxSize.Name = "checkBoxSize";
            this.checkBoxSize.Size = new System.Drawing.Size(44, 17);
            this.checkBoxSize.TabIndex = 37;
            this.checkBoxSize.Text = "size";
            this.checkBoxSize.UseVisualStyleBackColor = true;
            this.checkBoxSize.CheckStateChanged += new System.EventHandler(this.checkBoxSize_CheckedChanged);
            // 
            // comboBoxModel
            // 
            this.comboBoxModel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxModel.FormattingEnabled = true;
            this.comboBoxModel.Location = new System.Drawing.Point(104, 171);
            this.comboBoxModel.Name = "comboBoxModel";
            this.comboBoxModel.Size = new System.Drawing.Size(316, 21);
            this.comboBoxModel.TabIndex = 36;
            this.comboBoxModel.SelectedIndexChanged += new System.EventHandler(this.comboBoxModel_SelectedIndexChanged);
            this.comboBoxModel.TextUpdate += new System.EventHandler(this.comboBoxModel_TextUpdate);
            // 
            // checkBoxModel
            // 
            this.checkBoxModel.AutoSize = true;
            this.checkBoxModel.Location = new System.Drawing.Point(3, 173);
            this.checkBoxModel.Name = "checkBoxModel";
            this.checkBoxModel.Size = new System.Drawing.Size(54, 17);
            this.checkBoxModel.TabIndex = 35;
            this.checkBoxModel.Text = "model";
            this.checkBoxModel.UseVisualStyleBackColor = true;
            this.checkBoxModel.CheckStateChanged += new System.EventHandler(this.checkBoxModel_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "texture_name";
            // 
            // comboBoxFlipUV
            // 
            this.comboBoxFlipUV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxFlipUV.FormattingEnabled = true;
            this.comboBoxFlipUV.Location = new System.Drawing.Point(104, 144);
            this.comboBoxFlipUV.Name = "comboBoxFlipUV";
            this.comboBoxFlipUV.Size = new System.Drawing.Size(316, 21);
            this.comboBoxFlipUV.TabIndex = 33;
            this.comboBoxFlipUV.SelectedIndexChanged += new System.EventHandler(this.comboBoxFlipUV_SelectedIndexChanged);
            this.comboBoxFlipUV.TextUpdate += new System.EventHandler(this.comboBoxFlipUV_TextUpdate);
            // 
            // checkBoxFlipUV
            // 
            this.checkBoxFlipUV.AutoSize = true;
            this.checkBoxFlipUV.Location = new System.Drawing.Point(3, 146);
            this.checkBoxFlipUV.Name = "checkBoxFlipUV";
            this.checkBoxFlipUV.Size = new System.Drawing.Size(57, 17);
            this.checkBoxFlipUV.TabIndex = 32;
            this.checkBoxFlipUV.Text = "flip_uv";
            this.checkBoxFlipUV.UseVisualStyleBackColor = true;
            this.checkBoxFlipUV.CheckStateChanged += new System.EventHandler(this.checkBoxFlipUV_CheckedChanged);
            // 
            // comboBoxShader
            // 
            this.comboBoxShader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxShader.FormattingEnabled = true;
            this.comboBoxShader.Location = new System.Drawing.Point(104, 117);
            this.comboBoxShader.Name = "comboBoxShader";
            this.comboBoxShader.Size = new System.Drawing.Size(316, 21);
            this.comboBoxShader.TabIndex = 31;
            this.comboBoxShader.TextUpdate += new System.EventHandler(this.comboBoxShader_TextUpdate);
            // 
            // checkBoxShader
            // 
            this.checkBoxShader.AutoSize = true;
            this.checkBoxShader.Location = new System.Drawing.Point(3, 119);
            this.checkBoxShader.Name = "checkBoxShader";
            this.checkBoxShader.Size = new System.Drawing.Size(58, 17);
            this.checkBoxShader.TabIndex = 30;
            this.checkBoxShader.Text = "shader";
            this.checkBoxShader.UseVisualStyleBackColor = true;
            this.checkBoxShader.CheckStateChanged += new System.EventHandler(this.checkBoxShader_CheckedChanged);
            // 
            // checkBoxPosition
            // 
            this.checkBoxPosition.AutoSize = true;
            this.checkBoxPosition.Location = new System.Drawing.Point(3, 254);
            this.checkBoxPosition.Name = "checkBoxPosition";
            this.checkBoxPosition.Size = new System.Drawing.Size(62, 17);
            this.checkBoxPosition.TabIndex = 26;
            this.checkBoxPosition.Text = "position";
            this.checkBoxPosition.UseVisualStyleBackColor = true;
            this.checkBoxPosition.CheckStateChanged += new System.EventHandler(this.checkBoxPosition_CheckedChanged);
            // 
            // checkBoxScale
            // 
            this.checkBoxScale.AutoSize = true;
            this.checkBoxScale.Location = new System.Drawing.Point(3, 281);
            this.checkBoxScale.Name = "checkBoxScale";
            this.checkBoxScale.Size = new System.Drawing.Size(51, 17);
            this.checkBoxScale.TabIndex = 24;
            this.checkBoxScale.Text = "scale";
            this.checkBoxScale.UseVisualStyleBackColor = true;
            this.checkBoxScale.CheckStateChanged += new System.EventHandler(this.checkBoxScale_CheckedChanged);
            // 
            // comboBoxTextureName
            // 
            this.comboBoxTextureName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxTextureName.FormattingEnabled = true;
            this.comboBoxTextureName.Location = new System.Drawing.Point(104, 90);
            this.comboBoxTextureName.Name = "comboBoxTextureName";
            this.comboBoxTextureName.Size = new System.Drawing.Size(316, 21);
            this.comboBoxTextureName.TabIndex = 23;
            this.comboBoxTextureName.SelectedIndexChanged += new System.EventHandler(this.comboBoxTextureName_SelectedIndexChanged);
            this.comboBoxTextureName.TextUpdate += new System.EventHandler(this.comboBoxTextureName_TextUpdate);
            // 
            // comboBoxTexturePack
            // 
            this.comboBoxTexturePack.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxTexturePack.FormattingEnabled = true;
            this.comboBoxTexturePack.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.comboBoxTexturePack.Location = new System.Drawing.Point(104, 63);
            this.comboBoxTexturePack.Name = "comboBoxTexturePack";
            this.comboBoxTexturePack.Size = new System.Drawing.Size(316, 21);
            this.comboBoxTexturePack.TabIndex = 22;
            this.comboBoxTexturePack.SelectedIndexChanged += new System.EventHandler(this.comboBoxTexturePack_SelectedIndexChanged);
            this.comboBoxTexturePack.TextUpdate += new System.EventHandler(this.comboBoxTexturePack_TextUpdate);
            // 
            // checkBoxTexturePack
            // 
            this.checkBoxTexturePack.AutoSize = true;
            this.checkBoxTexturePack.Location = new System.Drawing.Point(3, 65);
            this.checkBoxTexturePack.Name = "checkBoxTexturePack";
            this.checkBoxTexturePack.Size = new System.Drawing.Size(88, 17);
            this.checkBoxTexturePack.TabIndex = 21;
            this.checkBoxTexturePack.Text = "texture_pack";
            this.checkBoxTexturePack.UseVisualStyleBackColor = true;
            this.checkBoxTexturePack.CheckedChanged += new System.EventHandler(this.checkBoxTexturePack_CheckedChanged);
            // 
            // textBoxSizeX
            // 
            this.textBoxSizeX.Location = new System.Drawing.Point(104, 198);
            this.textBoxSizeX.Name = "textBoxSizeX";
            this.textBoxSizeX.Size = new System.Drawing.Size(63, 20);
            this.textBoxSizeX.TabIndex = 41;
            this.textBoxSizeX.TextChanged += new System.EventHandler(this.textBoxSizeX_TextChanged);
            // 
            // textBoxSizeY
            // 
            this.textBoxSizeY.Location = new System.Drawing.Point(173, 198);
            this.textBoxSizeY.Name = "textBoxSizeY";
            this.textBoxSizeY.Size = new System.Drawing.Size(63, 20);
            this.textBoxSizeY.TabIndex = 42;
            this.textBoxSizeY.TextChanged += new System.EventHandler(this.textBoxSizeY_TextChanged);
            // 
            // textBoxPositionY
            // 
            this.textBoxPositionY.Location = new System.Drawing.Point(173, 252);
            this.textBoxPositionY.Name = "textBoxPositionY";
            this.textBoxPositionY.Size = new System.Drawing.Size(63, 20);
            this.textBoxPositionY.TabIndex = 44;
            this.textBoxPositionY.TextChanged += new System.EventHandler(this.textBoxPositionY_TextChanged);
            // 
            // textBoxPositionX
            // 
            this.textBoxPositionX.Location = new System.Drawing.Point(104, 252);
            this.textBoxPositionX.Name = "textBoxPositionX";
            this.textBoxPositionX.Size = new System.Drawing.Size(63, 20);
            this.textBoxPositionX.TabIndex = 43;
            this.textBoxPositionX.TextChanged += new System.EventHandler(this.textBoxPositionX_TextChanged);
            // 
            // textBoxScaleY
            // 
            this.textBoxScaleY.Location = new System.Drawing.Point(173, 279);
            this.textBoxScaleY.Name = "textBoxScaleY";
            this.textBoxScaleY.Size = new System.Drawing.Size(63, 20);
            this.textBoxScaleY.TabIndex = 46;
            this.textBoxScaleY.TextChanged += new System.EventHandler(this.textBoxScaleY_TextChanged);
            // 
            // textBoxScaleX
            // 
            this.textBoxScaleX.Location = new System.Drawing.Point(104, 279);
            this.textBoxScaleX.Name = "textBoxScaleX";
            this.textBoxScaleX.Size = new System.Drawing.Size(63, 20);
            this.textBoxScaleX.TabIndex = 45;
            this.textBoxScaleX.TextChanged += new System.EventHandler(this.textBoxScaleX_TextChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(104, 32);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(189, 21);
            this.comboBox1.TabIndex = 52;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 53;
            this.label2.Text = "Layer type:";
            // 
            // buttonEditControlProperties
            // 
            this.buttonEditControlProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEditControlProperties.Location = new System.Drawing.Point(299, 32);
            this.buttonEditControlProperties.Name = "buttonEditControlProperties";
            this.buttonEditControlProperties.Size = new System.Drawing.Size(121, 22);
            this.buttonEditControlProperties.TabIndex = 54;
            this.buttonEditControlProperties.Text = "Edit...";
            this.buttonEditControlProperties.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(3, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 15);
            this.label3.TabIndex = 55;
            this.label3.Text = "Layer :";
            // 
            // textBoxLayerName
            // 
            this.textBoxLayerName.Location = new System.Drawing.Point(104, 6);
            this.textBoxLayerName.Name = "textBoxLayerName";
            this.textBoxLayerName.Size = new System.Drawing.Size(189, 20);
            this.textBoxLayerName.TabIndex = 56;
            this.textBoxLayerName.TextChanged += new System.EventHandler(this.textBoxLayerName_TextChanged);
            // 
            // checkBoxLayerAlwaysAllowClicks
            // 
            this.checkBoxLayerAlwaysAllowClicks.AutoSize = true;
            this.checkBoxLayerAlwaysAllowClicks.Location = new System.Drawing.Point(3, 424);
            this.checkBoxLayerAlwaysAllowClicks.Name = "checkBoxLayerAlwaysAllowClicks";
            this.checkBoxLayerAlwaysAllowClicks.Size = new System.Drawing.Size(118, 17);
            this.checkBoxLayerAlwaysAllowClicks.TabIndex = 60;
            this.checkBoxLayerAlwaysAllowClicks.Text = "Always Allow Clicks";
            this.checkBoxLayerAlwaysAllowClicks.UseVisualStyleBackColor = true;
            // 
            // checkBoxDoNotDiscardItem
            // 
            this.checkBoxDoNotDiscardItem.AutoSize = true;
            this.checkBoxDoNotDiscardItem.Location = new System.Drawing.Point(3, 447);
            this.checkBoxDoNotDiscardItem.Name = "checkBoxDoNotDiscardItem";
            this.checkBoxDoNotDiscardItem.Size = new System.Drawing.Size(122, 17);
            this.checkBoxDoNotDiscardItem.TabIndex = 59;
            this.checkBoxDoNotDiscardItem.Text = "Do Not Discard Item";
            this.checkBoxDoNotDiscardItem.UseVisualStyleBackColor = true;
            // 
            // checkBoxLayerAlpha
            // 
            this.checkBoxLayerAlpha.AutoSize = true;
            this.checkBoxLayerAlpha.Checked = true;
            this.checkBoxLayerAlpha.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxLayerAlpha.Location = new System.Drawing.Point(3, 368);
            this.checkBoxLayerAlpha.Name = "checkBoxLayerAlpha";
            this.checkBoxLayerAlpha.Size = new System.Drawing.Size(52, 17);
            this.checkBoxLayerAlpha.TabIndex = 58;
            this.checkBoxLayerAlpha.Text = "alpha";
            this.checkBoxLayerAlpha.UseVisualStyleBackColor = true;
            // 
            // checkBoxLayerEnabled
            // 
            this.checkBoxLayerEnabled.AutoSize = true;
            this.checkBoxLayerEnabled.Checked = true;
            this.checkBoxLayerEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxLayerEnabled.Location = new System.Drawing.Point(3, 345);
            this.checkBoxLayerEnabled.Name = "checkBoxLayerEnabled";
            this.checkBoxLayerEnabled.Size = new System.Drawing.Size(64, 17);
            this.checkBoxLayerEnabled.TabIndex = 57;
            this.checkBoxLayerEnabled.Text = "enabled";
            this.checkBoxLayerEnabled.UseVisualStyleBackColor = true;
            // 
            // comboBoxLayerCursor
            // 
            this.comboBoxLayerCursor.FormattingEnabled = true;
            this.comboBoxLayerCursor.Location = new System.Drawing.Point(104, 306);
            this.comboBoxLayerCursor.Name = "comboBoxLayerCursor";
            this.comboBoxLayerCursor.Size = new System.Drawing.Size(132, 21);
            this.comboBoxLayerCursor.TabIndex = 62;
            // 
            // checkBoxLayerCursor
            // 
            this.checkBoxLayerCursor.AutoSize = true;
            this.checkBoxLayerCursor.Location = new System.Drawing.Point(3, 308);
            this.checkBoxLayerCursor.Name = "checkBoxLayerCursor";
            this.checkBoxLayerCursor.Size = new System.Drawing.Size(55, 17);
            this.checkBoxLayerCursor.TabIndex = 63;
            this.checkBoxLayerCursor.Text = "cursor";
            this.checkBoxLayerCursor.UseVisualStyleBackColor = true;
            this.checkBoxLayerCursor.CheckedChanged += new System.EventHandler(this.checkBoxLayerCursor_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(104, 365);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(63, 20);
            this.textBox1.TabIndex = 64;
            // 
            // LayerPropertiesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.checkBoxLayerCursor);
            this.Controls.Add(this.comboBoxLayerCursor);
            this.Controls.Add(this.checkBoxLayerAlwaysAllowClicks);
            this.Controls.Add(this.checkBoxDoNotDiscardItem);
            this.Controls.Add(this.checkBoxLayerAlpha);
            this.Controls.Add(this.checkBoxLayerEnabled);
            this.Controls.Add(this.textBoxLayerName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonEditControlProperties);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBoxScaleY);
            this.Controls.Add(this.textBoxScaleX);
            this.Controls.Add(this.textBoxPositionY);
            this.Controls.Add(this.textBoxPositionX);
            this.Controls.Add(this.textBoxSizeY);
            this.Controls.Add(this.textBoxSizeX);
            this.Controls.Add(this.checkBoxScaleUV);
            this.Controls.Add(this.checkBoxSize);
            this.Controls.Add(this.comboBoxModel);
            this.Controls.Add(this.checkBoxModel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxFlipUV);
            this.Controls.Add(this.checkBoxFlipUV);
            this.Controls.Add(this.comboBoxShader);
            this.Controls.Add(this.checkBoxShader);
            this.Controls.Add(this.checkBoxPosition);
            this.Controls.Add(this.checkBoxScale);
            this.Controls.Add(this.comboBoxTextureName);
            this.Controls.Add(this.comboBoxTexturePack);
            this.Controls.Add(this.checkBoxTexturePack);
            this.MinimumSize = new System.Drawing.Size(378, 450);
            this.Name = "LayerPropertiesControl";
            this.Size = new System.Drawing.Size(423, 468);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox checkBoxScaleUV;
		private System.Windows.Forms.CheckBox checkBoxSize;
		private System.Windows.Forms.ComboBox comboBoxModel;
		private System.Windows.Forms.CheckBox checkBoxModel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox comboBoxFlipUV;
		private System.Windows.Forms.CheckBox checkBoxFlipUV;
		private System.Windows.Forms.ComboBox comboBoxShader;
		private System.Windows.Forms.CheckBox checkBoxShader;
		private System.Windows.Forms.CheckBox checkBoxPosition;
		private System.Windows.Forms.CheckBox checkBoxScale;
		private System.Windows.Forms.ComboBox comboBoxTextureName;
		private System.Windows.Forms.ComboBox comboBoxTexturePack;
		private System.Windows.Forms.CheckBox checkBoxTexturePack;
		private System.Windows.Forms.TextBox textBoxSizeX;
		private System.Windows.Forms.TextBox textBoxSizeY;
		private System.Windows.Forms.TextBox textBoxPositionY;
		private System.Windows.Forms.TextBox textBoxPositionX;
		private System.Windows.Forms.TextBox textBoxScaleY;
        private System.Windows.Forms.TextBox textBoxScaleX;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonEditControlProperties;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxLayerName;
        private System.Windows.Forms.CheckBox checkBoxLayerAlwaysAllowClicks;
        private System.Windows.Forms.CheckBox checkBoxDoNotDiscardItem;
        private System.Windows.Forms.CheckBox checkBoxLayerAlpha;
        private System.Windows.Forms.CheckBox checkBoxLayerEnabled;
        private System.Windows.Forms.ComboBox comboBoxLayerCursor;
        private System.Windows.Forms.CheckBox checkBoxLayerCursor;
        private System.Windows.Forms.TextBox textBox1;
	}
}
