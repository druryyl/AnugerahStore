namespace AnugerahWinform.Accounting
{
    partial class ReturDepositForm
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
            this.SisaDepositText = new System.Windows.Forms.NumericUpDown();
            this.KeteranganReturDepositText = new System.Windows.Forms.TextBox();
            this.PihakKeduaNameText = new System.Windows.Forms.TextBox();
            this.SearchDepositButton = new System.Windows.Forms.Button();
            this.DepositIDText = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.JenisKasCombo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SearchButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.NewButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.TglText = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.NilaiReturText = new System.Windows.Forms.NumericUpDown();
            this.KeteranganDepositText = new System.Windows.Forms.TextBox();
            this.JamText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ReturDepositIDText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.JamTimer = new System.Windows.Forms.Timer(this.components);
            this.MainTab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SisaDepositText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NilaiReturText)).BeginInit();
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
            this.MainTab.Size = new System.Drawing.Size(394, 530);
            this.MainTab.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Bisque;
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.SisaDepositText);
            this.tabPage1.Controls.Add(this.KeteranganReturDepositText);
            this.tabPage1.Controls.Add(this.PihakKeduaNameText);
            this.tabPage1.Controls.Add(this.SearchDepositButton);
            this.tabPage1.Controls.Add(this.DepositIDText);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.JenisKasCombo);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.SearchButton);
            this.tabPage1.Controls.Add(this.ExitButton);
            this.tabPage1.Controls.Add(this.SaveButton);
            this.tabPage1.Controls.Add(this.NewButton);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.TglText);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.NilaiReturText);
            this.tabPage1.Controls.Add(this.KeteranganDepositText);
            this.tabPage1.Controls.Add(this.JamText);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.ReturDepositIDText);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.DeleteButton);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(386, 504);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Input Transaksi";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 377);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Sisa Deposit";
            // 
            // SisaDepositText
            // 
            this.SisaDepositText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SisaDepositText.Location = new System.Drawing.Point(8, 393);
            this.SisaDepositText.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.SisaDepositText.Minimum = new decimal(new int[] {
            99999999,
            0,
            0,
            -2147483648});
            this.SisaDepositText.Name = "SisaDepositText";
            this.SisaDepositText.ReadOnly = true;
            this.SisaDepositText.Size = new System.Drawing.Size(370, 21);
            this.SisaDepositText.TabIndex = 12;
            this.SisaDepositText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.SisaDepositText.ThousandsSeparator = true;
            // 
            // KeteranganReturDepositText
            // 
            this.KeteranganReturDepositText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.KeteranganReturDepositText.Location = new System.Drawing.Point(8, 275);
            this.KeteranganReturDepositText.Multiline = true;
            this.KeteranganReturDepositText.Name = "KeteranganReturDepositText";
            this.KeteranganReturDepositText.Size = new System.Drawing.Size(370, 59);
            this.KeteranganReturDepositText.TabIndex = 10;
            // 
            // PihakKeduaNameText
            // 
            this.PihakKeduaNameText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PihakKeduaNameText.Location = new System.Drawing.Point(8, 142);
            this.PihakKeduaNameText.Name = "PihakKeduaNameText";
            this.PihakKeduaNameText.ReadOnly = true;
            this.PihakKeduaNameText.Size = new System.Drawing.Size(370, 21);
            this.PihakKeduaNameText.TabIndex = 8;
            // 
            // SearchDepositButton
            // 
            this.SearchDepositButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchDepositButton.Location = new System.Drawing.Point(345, 113);
            this.SearchDepositButton.Name = "SearchDepositButton";
            this.SearchDepositButton.Size = new System.Drawing.Size(33, 23);
            this.SearchDepositButton.TabIndex = 7;
            this.SearchDepositButton.Text = "...";
            this.SearchDepositButton.UseVisualStyleBackColor = true;
            this.SearchDepositButton.Click += new System.EventHandler(this.SearchDepositButton_Click);
            // 
            // DepositIDText
            // 
            this.DepositIDText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DepositIDText.Location = new System.Drawing.Point(8, 113);
            this.DepositIDText.Name = "DepositIDText";
            this.DepositIDText.ReadOnly = true;
            this.DepositIDText.Size = new System.Drawing.Size(331, 21);
            this.DepositIDText.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 97);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Deposit ID";
            // 
            // JenisKasCombo
            // 
            this.JenisKasCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.JenisKasCombo.FormattingEnabled = true;
            this.JenisKasCombo.Location = new System.Drawing.Point(8, 353);
            this.JenisKasCombo.Name = "JenisKasCombo";
            this.JenisKasCombo.Size = new System.Drawing.Size(370, 21);
            this.JenisKasCombo.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 337);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Jenis Kas";
            // 
            // SearchButton
            // 
            this.SearchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchButton.Location = new System.Drawing.Point(267, 32);
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
            this.ExitButton.Location = new System.Drawing.Point(282, 470);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(96, 23);
            this.ExitButton.TabIndex = 16;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.Location = new System.Drawing.Point(6, 470);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(176, 23);
            this.SaveButton.TabIndex = 14;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // NewButton
            // 
            this.NewButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NewButton.Location = new System.Drawing.Point(306, 32);
            this.NewButton.Name = "NewButton";
            this.NewButton.Size = new System.Drawing.Size(72, 23);
            this.NewButton.TabIndex = 3;
            this.NewButton.Text = "New";
            this.NewButton.UseVisualStyleBackColor = true;
            this.NewButton.Click += new System.EventHandler(this.NewButton_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(268, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Jam";
            // 
            // TglText
            // 
            this.TglText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TglText.Location = new System.Drawing.Point(8, 73);
            this.TglText.Name = "TglText";
            this.TglText.Size = new System.Drawing.Size(257, 21);
            this.TglText.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 417);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Nilai Retur";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 259);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Catatan Retur Deposit";
            // 
            // NilaiReturText
            // 
            this.NilaiReturText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NilaiReturText.Location = new System.Drawing.Point(8, 433);
            this.NilaiReturText.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.NilaiReturText.Minimum = new decimal(new int[] {
            99999999,
            0,
            0,
            -2147483648});
            this.NilaiReturText.Name = "NilaiReturText";
            this.NilaiReturText.Size = new System.Drawing.Size(372, 21);
            this.NilaiReturText.TabIndex = 13;
            this.NilaiReturText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NilaiReturText.ThousandsSeparator = true;
            // 
            // KeteranganDepositText
            // 
            this.KeteranganDepositText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.KeteranganDepositText.Location = new System.Drawing.Point(8, 169);
            this.KeteranganDepositText.Multiline = true;
            this.KeteranganDepositText.Name = "KeteranganDepositText";
            this.KeteranganDepositText.ReadOnly = true;
            this.KeteranganDepositText.Size = new System.Drawing.Size(370, 68);
            this.KeteranganDepositText.TabIndex = 9;
            // 
            // JamText
            // 
            this.JamText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.JamText.Location = new System.Drawing.Point(271, 73);
            this.JamText.Name = "JamText";
            this.JamText.Size = new System.Drawing.Size(107, 21);
            this.JamText.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tanggal";
            // 
            // ReturDepositIDText
            // 
            this.ReturDepositIDText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ReturDepositIDText.Location = new System.Drawing.Point(8, 33);
            this.ReturDepositIDText.Name = "ReturDepositIDText";
            this.ReturDepositIDText.ReadOnly = true;
            this.ReturDepositIDText.Size = new System.Drawing.Size(257, 21);
            this.ReturDepositIDText.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Retur Deposit ID";
            // 
            // DeleteButton
            // 
            this.DeleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteButton.Location = new System.Drawing.Point(188, 470);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(88, 23);
            this.DeleteButton.TabIndex = 15;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(386, 504);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Informasi";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // JamTimer
            // 
            this.JamTimer.Enabled = true;
            this.JamTimer.Tick += new System.EventHandler(this.JamTimer_Tick);
            // 
            // ReturDepositForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 530);
            this.Controls.Add(this.MainTab);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ReturDepositForm";
            this.Text = "Retur Deposit";
            this.MainTab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SisaDepositText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NilaiReturText)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl MainTab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ComboBox JenisKasCombo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button NewButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker TglText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown NilaiReturText;
        private System.Windows.Forms.TextBox KeteranganDepositText;
        private System.Windows.Forms.TextBox JamText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ReturDepositIDText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown SisaDepositText;
        private System.Windows.Forms.TextBox KeteranganReturDepositText;
        private System.Windows.Forms.TextBox PihakKeduaNameText;
        private System.Windows.Forms.Button SearchDepositButton;
        private System.Windows.Forms.TextBox DepositIDText;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Timer JamTimer;
    }
}