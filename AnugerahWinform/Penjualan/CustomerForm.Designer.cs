namespace AnugerahWinform.Penjualan
{
    partial class CustomerForm
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
            this.MainTab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.CustomerNameTextBox = new System.Windows.Forms.TextBox();
            this.AlamatLabel = new System.Windows.Forms.Label();
            this.Alamat2TextBox = new System.Windows.Forms.TextBox();
            this.AlamatTextBox = new System.Windows.Forms.TextBox();
            this.SearchButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.NewButton = new System.Windows.Forms.Button();
            this.CustomerIDTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.NoTelponTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ContactPersonTextBox = new System.Windows.Forms.TextBox();
            this.MainTab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTab
            // 
            this.MainTab.Controls.Add(this.tabPage1);
            this.MainTab.Controls.Add(this.tabPage2);
            this.MainTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTab.Location = new System.Drawing.Point(0, 0);
            this.MainTab.Name = "MainTab";
            this.MainTab.SelectedIndex = 0;
            this.MainTab.Size = new System.Drawing.Size(303, 351);
            this.MainTab.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Bisque;
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.ContactPersonTextBox);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.NoTelponTextBox);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.CustomerNameTextBox);
            this.tabPage1.Controls.Add(this.AlamatLabel);
            this.tabPage1.Controls.Add(this.Alamat2TextBox);
            this.tabPage1.Controls.Add(this.AlamatTextBox);
            this.tabPage1.Controls.Add(this.SearchButton);
            this.tabPage1.Controls.Add(this.ExitButton);
            this.tabPage1.Controls.Add(this.SaveButton);
            this.tabPage1.Controls.Add(this.NewButton);
            this.tabPage1.Controls.Add(this.CustomerIDTextBox);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.DeleteButton);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(295, 325);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Input Transaksi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Nama Customer";
            // 
            // CustomerNameTextBox
            // 
            this.CustomerNameTextBox.Location = new System.Drawing.Point(6, 74);
            this.CustomerNameTextBox.Name = "CustomerNameTextBox";
            this.CustomerNameTextBox.Size = new System.Drawing.Size(281, 21);
            this.CustomerNameTextBox.TabIndex = 21;
            // 
            // AlamatLabel
            // 
            this.AlamatLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AlamatLabel.AutoSize = true;
            this.AlamatLabel.Location = new System.Drawing.Point(8, 98);
            this.AlamatLabel.Name = "AlamatLabel";
            this.AlamatLabel.Size = new System.Drawing.Size(47, 13);
            this.AlamatLabel.TabIndex = 24;
            this.AlamatLabel.Text = "Alamat";
            // 
            // Alamat2TextBox
            // 
            this.Alamat2TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Alamat2TextBox.Location = new System.Drawing.Point(6, 139);
            this.Alamat2TextBox.Name = "Alamat2TextBox";
            this.Alamat2TextBox.Size = new System.Drawing.Size(281, 21);
            this.Alamat2TextBox.TabIndex = 23;
            // 
            // AlamatTextBox
            // 
            this.AlamatTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AlamatTextBox.Location = new System.Drawing.Point(6, 114);
            this.AlamatTextBox.Name = "AlamatTextBox";
            this.AlamatTextBox.Size = new System.Drawing.Size(281, 21);
            this.AlamatTextBox.TabIndex = 22;
            // 
            // SearchButton
            // 
            this.SearchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchButton.Location = new System.Drawing.Point(176, 32);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(33, 23);
            this.SearchButton.TabIndex = 2;
            this.SearchButton.Text = "...";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ExitButton.Location = new System.Drawing.Point(191, 291);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(96, 23);
            this.ExitButton.TabIndex = 12;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.Location = new System.Drawing.Point(6, 291);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(85, 23);
            this.SaveButton.TabIndex = 10;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // NewButton
            // 
            this.NewButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NewButton.Location = new System.Drawing.Point(215, 32);
            this.NewButton.Name = "NewButton";
            this.NewButton.Size = new System.Drawing.Size(72, 23);
            this.NewButton.TabIndex = 3;
            this.NewButton.Text = "New";
            this.NewButton.UseVisualStyleBackColor = true;
            this.NewButton.Click += new System.EventHandler(this.NewButton_Click);
            // 
            // CustomerIDTextBox
            // 
            this.CustomerIDTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CustomerIDTextBox.Location = new System.Drawing.Point(6, 33);
            this.CustomerIDTextBox.Name = "CustomerIDTextBox";
            this.CustomerIDTextBox.ReadOnly = true;
            this.CustomerIDTextBox.Size = new System.Drawing.Size(168, 21);
            this.CustomerIDTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Customer ID";
            // 
            // DeleteButton
            // 
            this.DeleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteButton.Location = new System.Drawing.Point(97, 291);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(88, 23);
            this.DeleteButton.TabIndex = 11;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(295, 307);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Informasi";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "NoTelpon";
            // 
            // NoTelponTextBox
            // 
            this.NoTelponTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NoTelponTextBox.Location = new System.Drawing.Point(6, 179);
            this.NoTelponTextBox.Name = "NoTelponTextBox";
            this.NoTelponTextBox.Size = new System.Drawing.Size(281, 21);
            this.NoTelponTextBox.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 203);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Contact Person";
            // 
            // ContactPersonTextBox
            // 
            this.ContactPersonTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ContactPersonTextBox.Location = new System.Drawing.Point(6, 219);
            this.ContactPersonTextBox.Name = "ContactPersonTextBox";
            this.ContactPersonTextBox.Size = new System.Drawing.Size(281, 21);
            this.ContactPersonTextBox.TabIndex = 29;
            // 
            // CustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 351);
            this.Controls.Add(this.MainTab);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "CustomerForm";
            this.Text = "CustomerForm";
            this.MainTab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl MainTab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox CustomerNameTextBox;
        private System.Windows.Forms.Label AlamatLabel;
        private System.Windows.Forms.TextBox Alamat2TextBox;
        private System.Windows.Forms.TextBox AlamatTextBox;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button NewButton;
        private System.Windows.Forms.TextBox CustomerIDTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox NoTelponTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ContactPersonTextBox;
    }
}