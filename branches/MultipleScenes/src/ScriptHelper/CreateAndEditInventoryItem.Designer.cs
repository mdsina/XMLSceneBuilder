namespace WindowsFormsApplication2
{
    partial class CreateAndEditInventoryItem
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
        private void InitializeComponent(string str)
        {
            this.editInvItemControl1 = new WindowsFormsApplication2.Controls.EditInvItemControl(str);
            this.createInvItemControl1 = new WindowsFormsApplication2.Controls.CreateInvItemControl();
            this.SuspendLayout();
            // 
            // editInvItemControl1
            // 
            this.editInvItemControl1.Location = new System.Drawing.Point(2, 2);
            this.editInvItemControl1.Name = "editInvItemControl1";
            this.editInvItemControl1.Size = new System.Drawing.Size(600, 443);
            this.editInvItemControl1.TabIndex = 1;
            // 
            // createInvItemControl1
            // 
            this.createInvItemControl1.Location = new System.Drawing.Point(2, 2);
            this.createInvItemControl1.Name = "createInvItemControl1";
            this.createInvItemControl1.Size = new System.Drawing.Size(600, 443);
            this.createInvItemControl1.TabIndex = 0;
            // 
            // CreateAndEditInventoryItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 450);
            this.Controls.Add(this.editInvItemControl1);
            this.Controls.Add(this.createInvItemControl1);
            this.Name = "CreateAndEditInventoryItem";
            this.Text = "CreateAndEditInventoryItem";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.CreateInvItemControl createInvItemControl1;
        private Controls.EditInvItemControl editInvItemControl1;
    }
}