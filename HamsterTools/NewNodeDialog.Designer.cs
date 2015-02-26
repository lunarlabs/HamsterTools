namespace HamsterTools
{
    partial class NewNodeDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.nullRadioButton = new System.Windows.Forms.RadioButton();
            this.ByteRadioButton = new System.Windows.Forms.RadioButton();
            this.Int16RadioButton = new System.Windows.Forms.RadioButton();
            this.Int32RadioButton = new System.Windows.Forms.RadioButton();
            this.Int64RadioButton = new System.Windows.Forms.RadioButton();
            this.DoubleRadioButton = new System.Windows.Forms.RadioButton();
            this.StringRadioButton = new System.Windows.Forms.RadioButton();
            this.CancelButton = new System.Windows.Forms.Button();
            this.CreateButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Create new node of type:";
            // 
            // nullRadioButton
            // 
            this.nullRadioButton.AutoSize = true;
            this.nullRadioButton.Checked = true;
            this.nullRadioButton.Location = new System.Drawing.Point(15, 25);
            this.nullRadioButton.Name = "nullRadioButton";
            this.nullRadioButton.Size = new System.Drawing.Size(43, 17);
            this.nullRadioButton.TabIndex = 1;
            this.nullRadioButton.Text = "Null";
            this.nullRadioButton.UseVisualStyleBackColor = true;
            // 
            // ByteRadioButton
            // 
            this.ByteRadioButton.AutoSize = true;
            this.ByteRadioButton.Enabled = false;
            this.ByteRadioButton.Location = new System.Drawing.Point(15, 48);
            this.ByteRadioButton.Name = "ByteRadioButton";
            this.ByteRadioButton.Size = new System.Drawing.Size(46, 17);
            this.ByteRadioButton.TabIndex = 1;
            this.ByteRadioButton.Text = "Byte";
            this.ByteRadioButton.UseVisualStyleBackColor = true;
            // 
            // Int16RadioButton
            // 
            this.Int16RadioButton.AutoSize = true;
            this.Int16RadioButton.Enabled = false;
            this.Int16RadioButton.Location = new System.Drawing.Point(15, 71);
            this.Int16RadioButton.Name = "Int16RadioButton";
            this.Int16RadioButton.Size = new System.Drawing.Size(87, 17);
            this.Int16RadioButton.TabIndex = 1;
            this.Int16RadioButton.Text = "16-bit Integer";
            this.Int16RadioButton.UseVisualStyleBackColor = true;
            // 
            // Int32RadioButton
            // 
            this.Int32RadioButton.AutoSize = true;
            this.Int32RadioButton.Enabled = false;
            this.Int32RadioButton.Location = new System.Drawing.Point(15, 94);
            this.Int32RadioButton.Name = "Int32RadioButton";
            this.Int32RadioButton.Size = new System.Drawing.Size(87, 17);
            this.Int32RadioButton.TabIndex = 1;
            this.Int32RadioButton.Text = "32-bit Integer";
            this.Int32RadioButton.UseVisualStyleBackColor = true;
            // 
            // Int64RadioButton
            // 
            this.Int64RadioButton.AutoSize = true;
            this.Int64RadioButton.Enabled = false;
            this.Int64RadioButton.Location = new System.Drawing.Point(15, 117);
            this.Int64RadioButton.Name = "Int64RadioButton";
            this.Int64RadioButton.Size = new System.Drawing.Size(87, 17);
            this.Int64RadioButton.TabIndex = 1;
            this.Int64RadioButton.Text = "64-bit Integer";
            this.Int64RadioButton.UseVisualStyleBackColor = true;
            // 
            // DoubleRadioButton
            // 
            this.DoubleRadioButton.AutoSize = true;
            this.DoubleRadioButton.Enabled = false;
            this.DoubleRadioButton.Location = new System.Drawing.Point(15, 140);
            this.DoubleRadioButton.Name = "DoubleRadioButton";
            this.DoubleRadioButton.Size = new System.Drawing.Size(129, 17);
            this.DoubleRadioButton.TabIndex = 1;
            this.DoubleRadioButton.Text = "Floating-Point Number";
            this.DoubleRadioButton.UseVisualStyleBackColor = true;
            // 
            // StringRadioButton
            // 
            this.StringRadioButton.AutoSize = true;
            this.StringRadioButton.Enabled = false;
            this.StringRadioButton.Location = new System.Drawing.Point(15, 163);
            this.StringRadioButton.Name = "StringRadioButton";
            this.StringRadioButton.Size = new System.Drawing.Size(52, 17);
            this.StringRadioButton.TabIndex = 1;
            this.StringRadioButton.Text = "String";
            this.StringRadioButton.UseVisualStyleBackColor = true;
            // 
            // CancelButton
            // 
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Location = new System.Drawing.Point(158, 214);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 2;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // CreateButton
            // 
            this.CreateButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.CreateButton.Location = new System.Drawing.Point(77, 214);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(75, 23);
            this.CreateButton.TabIndex = 3;
            this.CreateButton.Text = "Create";
            this.CreateButton.UseVisualStyleBackColor = true;
            // 
            // NewNodeDialog
            // 
            this.AcceptButton = this.CreateButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelButton;
            this.ClientSize = new System.Drawing.Size(245, 249);
            this.Controls.Add(this.CreateButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.StringRadioButton);
            this.Controls.Add(this.DoubleRadioButton);
            this.Controls.Add(this.Int64RadioButton);
            this.Controls.Add(this.Int32RadioButton);
            this.Controls.Add(this.Int16RadioButton);
            this.Controls.Add(this.ByteRadioButton);
            this.Controls.Add(this.nullRadioButton);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewNodeDialog";
            this.Text = "New Node";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton nullRadioButton;
        private System.Windows.Forms.RadioButton ByteRadioButton;
        private System.Windows.Forms.RadioButton Int16RadioButton;
        private System.Windows.Forms.RadioButton Int32RadioButton;
        private System.Windows.Forms.RadioButton Int64RadioButton;
        private System.Windows.Forms.RadioButton DoubleRadioButton;
        private System.Windows.Forms.RadioButton StringRadioButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button CreateButton;
    }
}