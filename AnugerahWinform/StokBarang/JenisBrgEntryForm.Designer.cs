namespace AnugerahWinform.StokBarang
{
    partial class JenisBrgEntryForm
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
            this.JenisBrgIDLabel = new System.Windows.Forms.Label();
            this.JenisBrgNameTextBox = new System.Windows.Forms.TextBox();
            this.JenisBrgIDTextBox = new System.Windows.Forms.TextBox();
            this.OKButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.JenisBrgIDLabel);
            this.panel1.Controls.Add(this.JenisBrgNameTextBox);
            this.panel1.Controls.Add(this.JenisBrgIDTextBox);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(394, 151);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(85, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Name";
            // 
            // JenisBrgIDLabel
            // 
            this.JenisBrgIDLabel.AutoSize = true;
            this.JenisBrgIDLabel.Location = new System.Drawing.Point(48, 52);
            this.JenisBrgIDLabel.Name = "JenisBrgIDLabel";
            this.JenisBrgIDLabel.Size = new System.Drawing.Size(77, 13);
            this.JenisBrgIDLabel.TabIndex = 2;
            this.JenisBrgIDLabel.Text = "Jenis Brg ID";
            // 
            // JenisBrgNameTextBox
            // 
            this.JenisBrgNameTextBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JenisBrgNameTextBox.Location = new System.Drawing.Point(131, 76);
            this.JenisBrgNameTextBox.MaxLength = 30;
            this.JenisBrgNameTextBox.Name = "JenisBrgNameTextBox";
            this.JenisBrgNameTextBox.Size = new System.Drawing.Size(181, 20);
            this.JenisBrgNameTextBox.TabIndex = 1;
            // 
            // JenisBrgIDTextBox
            // 
            this.JenisBrgIDTextBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JenisBrgIDTextBox.Location = new System.Drawing.Point(131, 49);
            this.JenisBrgIDTextBox.MaxLength = 3;
            this.JenisBrgIDTextBox.Name = "JenisBrgIDTextBox";
            this.JenisBrgIDTextBox.Size = new System.Drawing.Size(48, 20);
            this.JenisBrgIDTextBox.TabIndex = 0;
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(250, 169);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 1;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(331, 169);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 2;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // JenisBrgEntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 204);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Name = "JenisBrgEntryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Entry Jenis Brg";
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.JenisBrgEntryForm_PreviewKeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox JenisBrgNameTextBox;
        private System.Windows.Forms.TextBox JenisBrgIDTextBox;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label JenisBrgIDLabel;
    }
}