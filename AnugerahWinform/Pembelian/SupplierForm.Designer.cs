namespace AnugerahWinform.Pembelian
{
    partial class SupplierForm
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
            this.SearchButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.NewButton = new System.Windows.Forms.Button();
            this.SupplierIDTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.SupplierNameTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.AlamatLabel = new System.Windows.Forms.Label();
            this.NoTelpTextBox = new System.Windows.Forms.TextBox();
            this.AlamatTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
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
            this.MainTab.Size = new System.Drawing.Size(303, 333);
            this.MainTab.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Bisque;
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.SupplierNameTextBox);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.AlamatLabel);
            this.tabPage1.Controls.Add(this.NoTelpTextBox);
            this.tabPage1.Controls.Add(this.AlamatTextBox);
            this.tabPage1.Controls.Add(this.SearchButton);
            this.tabPage1.Controls.Add(this.ExitButton);
            this.tabPage1.Controls.Add(this.SaveButton);
            this.tabPage1.Controls.Add(this.NewButton);
            this.tabPage1.Controls.Add(this.SupplierIDTextBox);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.DeleteButton);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(295, 307);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Input Transaksi";
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
            this.ExitButton.Location = new System.Drawing.Point(191, 273);
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
            this.SaveButton.Location = new System.Drawing.Point(6, 273);
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
            // SupplierIDTextBox
            // 
            this.SupplierIDTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SupplierIDTextBox.Location = new System.Drawing.Point(6, 33);
            this.SupplierIDTextBox.Name = "SupplierIDTextBox";
            this.SupplierIDTextBox.ReadOnly = true;
            this.SupplierIDTextBox.Size = new System.Drawing.Size(168, 21);
            this.SupplierIDTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Supplier ID";
            // 
            // DeleteButton
            // 
            this.DeleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteButton.Location = new System.Drawing.Point(97, 273);
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
            this.tabPage2.Size = new System.Drawing.Size(308, 454);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Informasi";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // SupplierNameTextBox
            // 
            this.SupplierNameTextBox.Location = new System.Drawing.Point(6, 74);
            this.SupplierNameTextBox.Name = "SupplierNameTextBox";
            this.SupplierNameTextBox.Size = new System.Drawing.Size(281, 21);
            this.SupplierNameTextBox.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "NoTelpon";
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
            // NoTelpTextBox
            // 
            this.NoTelpTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NoTelpTextBox.Location = new System.Drawing.Point(6, 154);
            this.NoTelpTextBox.Name = "NoTelpTextBox";
            this.NoTelpTextBox.Size = new System.Drawing.Size(281, 21);
            this.NoTelpTextBox.TabIndex = 23;
            // 
            // AlamatTextBox
            // 
            this.AlamatTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AlamatTextBox.Location = new System.Drawing.Point(6, 114);
            this.AlamatTextBox.Name = "AlamatTextBox";
            this.AlamatTextBox.Size = new System.Drawing.Size(281, 21);
            this.AlamatTextBox.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Nama Supplier";
            // 
            // SupplierForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 333);
            this.Controls.Add(this.MainTab);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "SupplierForm";
            this.Text = "SupplierForm";
            this.MainTab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl MainTab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button NewButton;
        private System.Windows.Forms.TextBox SupplierIDTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox SupplierNameTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label AlamatLabel;
        private System.Windows.Forms.TextBox NoTelpTextBox;
        private System.Windows.Forms.TextBox AlamatTextBox;
    }
}