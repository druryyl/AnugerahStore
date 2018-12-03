namespace AnugerahWinform.StokBarang
{
    partial class TipeBrgEntryForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.TipeBrgIDLabel = new System.Windows.Forms.Label();
            this.TipeBrgNameTextBox = new System.Windows.Forms.TextBox();
            this.TipeBrgIDTextBox = new System.Windows.Forms.TextBox();
            this.CancelButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.JenisBrgIDLabel = new System.Windows.Forms.Label();
            this.JenisBrgNameTextBox = new System.Windows.Forms.TextBox();
            this.JenisBrgIDTextBox = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.JenisBrgIDLabel);
            this.panel1.Controls.Add(this.JenisBrgNameTextBox);
            this.panel1.Controls.Add(this.JenisBrgIDTextBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.TipeBrgIDLabel);
            this.panel1.Controls.Add(this.TipeBrgNameTextBox);
            this.panel1.Controls.Add(this.TipeBrgIDTextBox);
            this.panel1.Location = new System.Drawing.Point(14, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(459, 172);
            this.panel1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(103, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Name";
            // 
            // TipeBrgIDLabel
            // 
            this.TipeBrgIDLabel.AutoSize = true;
            this.TipeBrgIDLabel.Location = new System.Drawing.Point(70, 43);
            this.TipeBrgIDLabel.Name = "TipeBrgIDLabel";
            this.TipeBrgIDLabel.Size = new System.Drawing.Size(73, 13);
            this.TipeBrgIDLabel.TabIndex = 2;
            this.TipeBrgIDLabel.Text = "Tipe Brg ID";
            // 
            // TipeBrgNameTextBox
            // 
            this.TipeBrgNameTextBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TipeBrgNameTextBox.Location = new System.Drawing.Point(154, 70);
            this.TipeBrgNameTextBox.MaxLength = 30;
            this.TipeBrgNameTextBox.Name = "TipeBrgNameTextBox";
            this.TipeBrgNameTextBox.Size = new System.Drawing.Size(210, 20);
            this.TipeBrgNameTextBox.TabIndex = 1;
            // 
            // TipeBrgIDTextBox
            // 
            this.TipeBrgIDTextBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TipeBrgIDTextBox.Location = new System.Drawing.Point(154, 43);
            this.TipeBrgIDTextBox.MaxLength = 5;
            this.TipeBrgIDTextBox.Name = "TipeBrgIDTextBox";
            this.TipeBrgIDTextBox.Size = new System.Drawing.Size(55, 20);
            this.TipeBrgIDTextBox.TabIndex = 0;
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(386, 190);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(87, 23);
            this.CancelButton.TabIndex = 5;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(292, 190);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(87, 23);
            this.OKButton.TabIndex = 4;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // JenisBrgIDLabel
            // 
            this.JenisBrgIDLabel.AutoSize = true;
            this.JenisBrgIDLabel.Location = new System.Drawing.Point(108, 100);
            this.JenisBrgIDLabel.Name = "JenisBrgIDLabel";
            this.JenisBrgIDLabel.Size = new System.Drawing.Size(35, 13);
            this.JenisBrgIDLabel.TabIndex = 6;
            this.JenisBrgIDLabel.Text = "Jenis";
            // 
            // JenisBrgNameTextBox
            // 
            this.JenisBrgNameTextBox.Enabled = false;
            this.JenisBrgNameTextBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JenisBrgNameTextBox.Location = new System.Drawing.Point(193, 96);
            this.JenisBrgNameTextBox.MaxLength = 30;
            this.JenisBrgNameTextBox.Name = "JenisBrgNameTextBox";
            this.JenisBrgNameTextBox.ReadOnly = true;
            this.JenisBrgNameTextBox.Size = new System.Drawing.Size(210, 20);
            this.JenisBrgNameTextBox.TabIndex = 3;
            // 
            // JenisBrgIDTextBox
            // 
            this.JenisBrgIDTextBox.Enabled = false;
            this.JenisBrgIDTextBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JenisBrgIDTextBox.Location = new System.Drawing.Point(154, 97);
            this.JenisBrgIDTextBox.MaxLength = 3;
            this.JenisBrgIDTextBox.Name = "JenisBrgIDTextBox";
            this.JenisBrgIDTextBox.ReadOnly = true;
            this.JenisBrgIDTextBox.Size = new System.Drawing.Size(33, 20);
            this.JenisBrgIDTextBox.TabIndex = 2;
            // 
            // TipeBrgEntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 225);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OKButton);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "TipeBrgEntryForm";
            this.Text = "Entry Tipe Barang";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label TipeBrgIDLabel;
        private System.Windows.Forms.TextBox TipeBrgNameTextBox;
        private System.Windows.Forms.TextBox TipeBrgIDTextBox;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Label JenisBrgIDLabel;
        private System.Windows.Forms.TextBox JenisBrgNameTextBox;
        private System.Windows.Forms.TextBox JenisBrgIDTextBox;
    }
}