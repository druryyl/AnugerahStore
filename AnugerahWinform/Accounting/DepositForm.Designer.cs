namespace AnugerahWinform.Accounting
{
    partial class DepositForm
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
            this.JenisBayarCombo = new System.Windows.Forms.ComboBox();
            this.JenisBayarLabel = new System.Windows.Forms.Label();
            this.SearchButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.NewButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.TglText = new System.Windows.Forms.DateTimePicker();
            this.LabelPihakKedua = new System.Windows.Forms.Label();
            this.PihakKeduaCombo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.NilIText = new System.Windows.Forms.NumericUpDown();
            this.KeteranganText = new System.Windows.Forms.TextBox();
            this.JamText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BiayaIDText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.JamTimer = new System.Windows.Forms.Timer(this.components);
            this.ErrorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.BuyerNameTextBox = new System.Windows.Forms.TextBox();
            this.BuyerNameLabel = new System.Windows.Forms.Label();
            this.MainTab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NilIText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider1)).BeginInit();
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
            this.MainTab.Size = new System.Drawing.Size(392, 564);
            this.MainTab.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Bisque;
            this.tabPage1.Controls.Add(this.BuyerNameTextBox);
            this.tabPage1.Controls.Add(this.BuyerNameLabel);
            this.tabPage1.Controls.Add(this.JenisBayarCombo);
            this.tabPage1.Controls.Add(this.JenisBayarLabel);
            this.tabPage1.Controls.Add(this.SearchButton);
            this.tabPage1.Controls.Add(this.ExitButton);
            this.tabPage1.Controls.Add(this.SaveButton);
            this.tabPage1.Controls.Add(this.NewButton);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.TglText);
            this.tabPage1.Controls.Add(this.LabelPihakKedua);
            this.tabPage1.Controls.Add(this.PihakKeduaCombo);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.NilIText);
            this.tabPage1.Controls.Add(this.KeteranganText);
            this.tabPage1.Controls.Add(this.JamText);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.BiayaIDText);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.DeleteButton);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(384, 538);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Input Transaksi";
            // 
            // JenisBayarCombo
            // 
            this.JenisBayarCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.JenisBayarCombo.FormattingEnabled = true;
            this.JenisBayarCombo.Location = new System.Drawing.Point(12, 417);
            this.JenisBayarCombo.Name = "JenisBayarCombo";
            this.JenisBayarCombo.Size = new System.Drawing.Size(358, 21);
            this.JenisBayarCombo.TabIndex = 9;
            // 
            // JenisBayarLabel
            // 
            this.JenisBayarLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.JenisBayarLabel.AutoSize = true;
            this.JenisBayarLabel.Location = new System.Drawing.Point(14, 401);
            this.JenisBayarLabel.Name = "JenisBayarLabel";
            this.JenisBayarLabel.Size = new System.Drawing.Size(73, 13);
            this.JenisBayarLabel.TabIndex = 12;
            this.JenisBayarLabel.Text = "Jenis Bayar";
            // 
            // SearchButton
            // 
            this.SearchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchButton.Location = new System.Drawing.Point(271, 32);
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
            this.ExitButton.Location = new System.Drawing.Point(280, 504);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(96, 23);
            this.ExitButton.TabIndex = 13;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.ClientSizeChanged += new System.EventHandler(this.ExitButton_Click);
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click_1);
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.Location = new System.Drawing.Point(6, 504);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(174, 23);
            this.SaveButton.TabIndex = 11;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // NewButton
            // 
            this.NewButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NewButton.Location = new System.Drawing.Point(310, 32);
            this.NewButton.Name = "NewButton";
            this.NewButton.Size = new System.Drawing.Size(60, 23);
            this.NewButton.TabIndex = 3;
            this.NewButton.Text = "New";
            this.NewButton.UseVisualStyleBackColor = true;
            this.NewButton.Click += new System.EventHandler(this.NewButton_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(272, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Jam";
            // 
            // TglText
            // 
            this.TglText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TglText.Location = new System.Drawing.Point(12, 73);
            this.TglText.Name = "TglText";
            this.TglText.Size = new System.Drawing.Size(257, 21);
            this.TglText.TabIndex = 4;
            // 
            // LabelPihakKedua
            // 
            this.LabelPihakKedua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LabelPihakKedua.AutoSize = true;
            this.LabelPihakKedua.Location = new System.Drawing.Point(14, 321);
            this.LabelPihakKedua.Name = "LabelPihakKedua";
            this.LabelPihakKedua.Size = new System.Drawing.Size(78, 13);
            this.LabelPihakKedua.TabIndex = 8;
            this.LabelPihakKedua.Text = "Pihak Kedua";
            // 
            // PihakKeduaCombo
            // 
            this.PihakKeduaCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PihakKeduaCombo.FormattingEnabled = true;
            this.PihakKeduaCombo.Location = new System.Drawing.Point(12, 337);
            this.PihakKeduaCombo.Name = "PihakKeduaCombo";
            this.PihakKeduaCombo.Size = new System.Drawing.Size(358, 21);
            this.PihakKeduaCombo.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 441);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Nilai Deposit";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Keterangan";
            // 
            // NilIText
            // 
            this.NilIText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NilIText.Location = new System.Drawing.Point(12, 457);
            this.NilIText.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.NilIText.Minimum = new decimal(new int[] {
            99999999,
            0,
            0,
            -2147483648});
            this.NilIText.Name = "NilIText";
            this.NilIText.Size = new System.Drawing.Size(358, 21);
            this.NilIText.TabIndex = 10;
            this.NilIText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NilIText.ThousandsSeparator = true;
            // 
            // KeteranganText
            // 
            this.KeteranganText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.KeteranganText.Location = new System.Drawing.Point(12, 113);
            this.KeteranganText.Multiline = true;
            this.KeteranganText.Name = "KeteranganText";
            this.KeteranganText.Size = new System.Drawing.Size(358, 205);
            this.KeteranganText.TabIndex = 6;
            // 
            // JamText
            // 
            this.JamText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.JamText.Location = new System.Drawing.Point(275, 73);
            this.JamText.Name = "JamText";
            this.JamText.Size = new System.Drawing.Size(95, 21);
            this.JamText.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tanggal";
            // 
            // BiayaIDText
            // 
            this.BiayaIDText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BiayaIDText.Location = new System.Drawing.Point(12, 33);
            this.BiayaIDText.Name = "BiayaIDText";
            this.BiayaIDText.ReadOnly = true;
            this.BiayaIDText.Size = new System.Drawing.Size(257, 21);
            this.BiayaIDText.TabIndex = 1;
            this.BiayaIDText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DepositIDText_KeyDown);
            this.BiayaIDText.Validated += new System.EventHandler(this.DepositIDText_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Deposit ID";
            // 
            // DeleteButton
            // 
            this.DeleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteButton.Location = new System.Drawing.Point(186, 504);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(88, 23);
            this.DeleteButton.TabIndex = 12;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(384, 501);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Informasi";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // JamTimer
            // 
            this.JamTimer.Enabled = true;
            this.JamTimer.Tick += new System.EventHandler(this.JamTimer_Tick);
            // 
            // ErrorProvider1
            // 
            this.ErrorProvider1.ContainerControl = this;
            // 
            // BuyerNameTextBox
            // 
            this.BuyerNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BuyerNameTextBox.Location = new System.Drawing.Point(12, 377);
            this.BuyerNameTextBox.Name = "BuyerNameTextBox";
            this.BuyerNameTextBox.Size = new System.Drawing.Size(357, 21);
            this.BuyerNameTextBox.TabIndex = 8;
            // 
            // BuyerNameLabel
            // 
            this.BuyerNameLabel.AutoSize = true;
            this.BuyerNameLabel.Location = new System.Drawing.Point(14, 361);
            this.BuyerNameLabel.Name = "BuyerNameLabel";
            this.BuyerNameLabel.Size = new System.Drawing.Size(182, 13);
            this.BuyerNameLabel.TabIndex = 13;
            this.BuyerNameLabel.Text = "Contact Person  / Buyer Name";
            // 
            // DepositForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 564);
            this.Controls.Add(this.MainTab);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "DepositForm";
            this.Text = "Deposit";
            this.MainTab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NilIText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl MainTab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ComboBox JenisBayarCombo;
        private System.Windows.Forms.Label JenisBayarLabel;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button NewButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker TglText;
        private System.Windows.Forms.Label LabelPihakKedua;
        private System.Windows.Forms.ComboBox PihakKeduaCombo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown NilIText;
        private System.Windows.Forms.TextBox KeteranganText;
        private System.Windows.Forms.TextBox JamText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox BiayaIDText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Timer JamTimer;
        private System.Windows.Forms.ErrorProvider ErrorProvider1;
        private System.Windows.Forms.TextBox BuyerNameTextBox;
        private System.Windows.Forms.Label BuyerNameLabel;
    }
}