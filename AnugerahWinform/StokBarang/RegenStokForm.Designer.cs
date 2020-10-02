namespace AnugerahWinform.StokBarang
{
    partial class RegenStokForm
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
            this.ProsesButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.BrgIDTextBox = new System.Windows.Forms.TextBox();
            this.SearchBrgButton = new System.Windows.Forms.Button();
            this.BrgNameTextBox = new System.Windows.Forms.TextBox();
            this.prgBar = new System.Windows.Forms.ProgressBar();
            this.ProsesNameLabel = new System.Windows.Forms.Label();
            this.ProgressLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Azure;
            this.panel1.Controls.Add(this.ProgressLabel);
            this.panel1.Controls.Add(this.ProsesNameLabel);
            this.panel1.Controls.Add(this.prgBar);
            this.panel1.Controls.Add(this.BrgNameTextBox);
            this.panel1.Controls.Add(this.SearchBrgButton);
            this.panel1.Controls.Add(this.BrgIDTextBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(586, 250);
            this.panel1.TabIndex = 0;
            // 
            // ProsesButton
            // 
            this.ProsesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ProsesButton.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.ProsesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ProsesButton.Location = new System.Drawing.Point(442, 268);
            this.ProsesButton.Name = "ProsesButton";
            this.ProsesButton.Size = new System.Drawing.Size(75, 23);
            this.ProsesButton.TabIndex = 1;
            this.ProsesButton.Text = "Proses";
            this.ProsesButton.UseVisualStyleBackColor = false;
            this.ProsesButton.Click += new System.EventHandler(this.ProsesButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ExitButton.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.Location = new System.Drawing.Point(523, 268);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(75, 23);
            this.ExitButton.TabIndex = 2;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(136, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Brg ID";
            // 
            // BrgIDTextBox
            // 
            this.BrgIDTextBox.Location = new System.Drawing.Point(180, 80);
            this.BrgIDTextBox.Name = "BrgIDTextBox";
            this.BrgIDTextBox.Size = new System.Drawing.Size(75, 22);
            this.BrgIDTextBox.TabIndex = 1;
            this.BrgIDTextBox.Validated += new System.EventHandler(this.BrgIDTextBox_Validated);
            // 
            // SearchBrgButton
            // 
            this.SearchBrgButton.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.SearchBrgButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SearchBrgButton.Location = new System.Drawing.Point(261, 80);
            this.SearchBrgButton.Name = "SearchBrgButton";
            this.SearchBrgButton.Size = new System.Drawing.Size(25, 23);
            this.SearchBrgButton.TabIndex = 2;
            this.SearchBrgButton.Text = "...";
            this.SearchBrgButton.UseVisualStyleBackColor = false;
            this.SearchBrgButton.Click += new System.EventHandler(this.SearchBrgButton_Click);
            // 
            // BrgNameTextBox
            // 
            this.BrgNameTextBox.Location = new System.Drawing.Point(180, 109);
            this.BrgNameTextBox.Name = "BrgNameTextBox";
            this.BrgNameTextBox.ReadOnly = true;
            this.BrgNameTextBox.Size = new System.Drawing.Size(299, 22);
            this.BrgNameTextBox.TabIndex = 3;
            // 
            // prgBar
            // 
            this.prgBar.Location = new System.Drawing.Point(13, 210);
            this.prgBar.Name = "prgBar";
            this.prgBar.Size = new System.Drawing.Size(559, 15);
            this.prgBar.TabIndex = 4;
            // 
            // ProsesNameLabel
            // 
            this.ProsesNameLabel.AutoSize = true;
            this.ProsesNameLabel.Location = new System.Drawing.Point(10, 194);
            this.ProsesNameLabel.Name = "ProsesNameLabel";
            this.ProsesNameLabel.Size = new System.Drawing.Size(11, 13);
            this.ProsesNameLabel.TabIndex = 5;
            this.ProsesNameLabel.Text = "-";
            // 
            // ProgressLabel
            // 
            this.ProgressLabel.AutoSize = true;
            this.ProgressLabel.Location = new System.Drawing.Point(10, 228);
            this.ProgressLabel.Name = "ProgressLabel";
            this.ProgressLabel.Size = new System.Drawing.Size(11, 13);
            this.ProgressLabel.TabIndex = 6;
            this.ProgressLabel.Text = "-";
            // 
            // RegenStokForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(610, 303);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.ProsesButton);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "RegenStokForm";
            this.Text = "RegenStokForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button ProsesButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.ProgressBar prgBar;
        private System.Windows.Forms.TextBox BrgNameTextBox;
        private System.Windows.Forms.Button SearchBrgButton;
        private System.Windows.Forms.TextBox BrgIDTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ProgressLabel;
        private System.Windows.Forms.Label ProsesNameLabel;
    }
}