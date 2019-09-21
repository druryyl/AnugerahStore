namespace AnugerahWinform.Accounting
{
    partial class LunasPiutangForm
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
            this.MainTab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.JenisBayarComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TglTextBox = new System.Windows.Forms.DateTimePicker();
            this.JamTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SearchLunasPiutangButton = new System.Windows.Forms.Button();
            this.NewButton = new System.Windows.Forms.Button();
            this.LunasPiutangIDTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TotalBayarTextBox = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.TotalPiutangTextBox = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.ListPiutangGrid = new System.Windows.Forms.DataGridView();
            this.SearchCustomerButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.CustomerNameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.MainTab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TotalBayarTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalPiutangTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListPiutangGrid)).BeginInit();
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
            this.MainTab.Size = new System.Drawing.Size(527, 587);
            this.MainTab.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Bisque;
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.JenisBayarComboBox);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.TglTextBox);
            this.tabPage1.Controls.Add(this.JamTextBox);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.SearchLunasPiutangButton);
            this.tabPage1.Controls.Add(this.NewButton);
            this.tabPage1.Controls.Add(this.LunasPiutangIDTextBox);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.TotalBayarTextBox);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.TotalPiutangTextBox);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.ListPiutangGrid);
            this.tabPage1.Controls.Add(this.SearchCustomerButton);
            this.tabPage1.Controls.Add(this.ExitButton);
            this.tabPage1.Controls.Add(this.SaveButton);
            this.tabPage1.Controls.Add(this.CustomerNameTextBox);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.DeleteButton);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(519, 561);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Input Transaksi";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(331, 484);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "Pelunasan";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Cara Pelunasan";
            // 
            // JenisBayarComboBox
            // 
            this.JenisBayarComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.JenisBayarComboBox.FormattingEnabled = true;
            this.JenisBayarComboBox.Location = new System.Drawing.Point(6, 139);
            this.JenisBayarComboBox.Name = "JenisBayarComboBox";
            this.JenisBayarComboBox.Size = new System.Drawing.Size(505, 21);
            this.JenisBayarComboBox.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(395, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "Jam";
            // 
            // TglTextBox
            // 
            this.TglTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TglTextBox.Location = new System.Drawing.Point(6, 59);
            this.TglTextBox.Name = "TglTextBox";
            this.TglTextBox.Size = new System.Drawing.Size(390, 21);
            this.TglTextBox.TabIndex = 3;
            // 
            // JamTextBox
            // 
            this.JamTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.JamTextBox.Location = new System.Drawing.Point(398, 59);
            this.JamTextBox.Name = "JamTextBox";
            this.JamTextBox.Size = new System.Drawing.Size(115, 21);
            this.JamTextBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Tanggal";
            // 
            // SearchLunasPiutangButton
            // 
            this.SearchLunasPiutangButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchLunasPiutangButton.Location = new System.Drawing.Point(398, 17);
            this.SearchLunasPiutangButton.Name = "SearchLunasPiutangButton";
            this.SearchLunasPiutangButton.Size = new System.Drawing.Size(33, 23);
            this.SearchLunasPiutangButton.TabIndex = 1;
            this.SearchLunasPiutangButton.Text = "...";
            this.SearchLunasPiutangButton.UseVisualStyleBackColor = true;
            this.SearchLunasPiutangButton.Click += new System.EventHandler(this.SearchLunasPiutangButton_Click);
            // 
            // NewButton
            // 
            this.NewButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NewButton.Location = new System.Drawing.Point(437, 17);
            this.NewButton.Name = "NewButton";
            this.NewButton.Size = new System.Drawing.Size(76, 23);
            this.NewButton.TabIndex = 2;
            this.NewButton.Text = "New";
            this.NewButton.UseVisualStyleBackColor = true;
            this.NewButton.Click += new System.EventHandler(this.NewButton_Click);
            // 
            // LunasPiutangIDTextBox
            // 
            this.LunasPiutangIDTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LunasPiutangIDTextBox.Location = new System.Drawing.Point(6, 19);
            this.LunasPiutangIDTextBox.Name = "LunasPiutangIDTextBox";
            this.LunasPiutangIDTextBox.ReadOnly = true;
            this.LunasPiutangIDTextBox.Size = new System.Drawing.Size(390, 21);
            this.LunasPiutangIDTextBox.TabIndex = 0;
            this.LunasPiutangIDTextBox.Validated += new System.EventHandler(this.LunasPiutangIDTextBox_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "No.Pelunasan Piutang";
            // 
            // TotalBayarTextBox
            // 
            this.TotalBayarTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TotalBayarTextBox.InterceptArrowKeys = false;
            this.TotalBayarTextBox.Location = new System.Drawing.Point(402, 482);
            this.TotalBayarTextBox.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.TotalBayarTextBox.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.TotalBayarTextBox.Name = "TotalBayarTextBox";
            this.TotalBayarTextBox.Size = new System.Drawing.Size(111, 21);
            this.TotalBayarTextBox.TabIndex = 10;
            this.TotalBayarTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TotalBayarTextBox.ThousandsSeparator = true;
            this.TotalBayarTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TotalBayarTextBox_KeyDown);
            this.TotalBayarTextBox.Validated += new System.EventHandler(this.TotalBayarTextBox_Validated);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(318, 459);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Total Piutang";
            // 
            // TotalPiutangTextBox
            // 
            this.TotalPiutangTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TotalPiutangTextBox.Location = new System.Drawing.Point(402, 457);
            this.TotalPiutangTextBox.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.TotalPiutangTextBox.Minimum = new decimal(new int[] {
            99999999,
            0,
            0,
            -2147483648});
            this.TotalPiutangTextBox.Name = "TotalPiutangTextBox";
            this.TotalPiutangTextBox.ReadOnly = true;
            this.TotalPiutangTextBox.Size = new System.Drawing.Size(111, 21);
            this.TotalPiutangTextBox.TabIndex = 9;
            this.TotalPiutangTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TotalPiutangTextBox.ThousandsSeparator = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 163);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "List Piutang";
            // 
            // ListPiutangGrid
            // 
            this.ListPiutangGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListPiutangGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ListPiutangGrid.Location = new System.Drawing.Point(6, 179);
            this.ListPiutangGrid.Name = "ListPiutangGrid";
            this.ListPiutangGrid.Size = new System.Drawing.Size(507, 272);
            this.ListPiutangGrid.TabIndex = 8;
            this.ListPiutangGrid.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.ListPiutangGrid_DataBindingComplete);
            // 
            // SearchCustomerButton
            // 
            this.SearchCustomerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchCustomerButton.Location = new System.Drawing.Point(480, 99);
            this.SearchCustomerButton.Name = "SearchCustomerButton";
            this.SearchCustomerButton.Size = new System.Drawing.Size(33, 23);
            this.SearchCustomerButton.TabIndex = 6;
            this.SearchCustomerButton.Text = "...";
            this.SearchCustomerButton.UseVisualStyleBackColor = true;
            this.SearchCustomerButton.Click += new System.EventHandler(this.SearchCustomerButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ExitButton.Location = new System.Drawing.Point(415, 527);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(98, 23);
            this.ExitButton.TabIndex = 13;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.Location = new System.Drawing.Point(6, 527);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(309, 23);
            this.SaveButton.TabIndex = 11;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CustomerNameTextBox
            // 
            this.CustomerNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CustomerNameTextBox.Location = new System.Drawing.Point(6, 99);
            this.CustomerNameTextBox.Name = "CustomerNameTextBox";
            this.CustomerNameTextBox.ReadOnly = true;
            this.CustomerNameTextBox.Size = new System.Drawing.Size(468, 21);
            this.CustomerNameTextBox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Customer";
            // 
            // DeleteButton
            // 
            this.DeleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteButton.Location = new System.Drawing.Point(321, 527);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(88, 23);
            this.DeleteButton.TabIndex = 12;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(519, 561);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Informasi";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // LunasPiutangForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 587);
            this.Controls.Add(this.MainTab);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "LunasPiutangForm";
            this.Text = "LunasPiutang";
            this.MainTab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TotalBayarTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalPiutangTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListPiutangGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl MainTab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown TotalPiutangTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button SearchCustomerButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.TextBox CustomerNameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.NumericUpDown TotalBayarTextBox;
        private System.Windows.Forms.Button SearchLunasPiutangButton;
        private System.Windows.Forms.Button NewButton;
        private System.Windows.Forms.TextBox LunasPiutangIDTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker TglTextBox;
        private System.Windows.Forms.TextBox JamTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView ListPiutangGrid;
        private System.Windows.Forms.ComboBox JenisBayarComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Timer timer1;
    }
}