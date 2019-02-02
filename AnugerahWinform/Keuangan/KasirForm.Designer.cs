namespace AnugerahWinform.Keuangan
{
    partial class KasirForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ReffNotesText = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.SearchBukuKasButton = new System.Windows.Forms.Button();
            this.SearchPihakKetigaButton = new System.Windows.Forms.Button();
            this.PihakKetigaNameText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.NewButton = new System.Windows.Forms.Button();
            this.JamBukuTextBox = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.TglBukuTextBox = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.BukuKasIDTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.JenisTrsCombo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.PihakKetigaText = new System.Windows.Forms.TextBox();
            this.NilaiText = new System.Windows.Forms.NumericUpDown();
            this.ReffIDText = new System.Windows.Forms.TextBox();
            this.KeteranganText = new System.Windows.Forms.TextBox();
            this.ExitButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.KasirDataSet = new System.Data.DataSet();
            this.BukuKasTable = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataColumn5 = new System.Data.DataColumn();
            this.dataColumn6 = new System.Data.DataColumn();
            this.dataColumn7 = new System.Data.DataColumn();
            this.dataColumn8 = new System.Data.DataColumn();
            this.dataColumn9 = new System.Data.DataColumn();
            this.BukuKasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NilaiText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KasirDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BukuKasTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BukuKasBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(700, 472);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Salmon;
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.ExitButton);
            this.tabPage1.Controls.Add(this.DeleteButton);
            this.tabPage1.Controls.Add(this.SaveButton);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(692, 446);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Transaksi";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.MistyRose;
            this.panel1.Controls.Add(this.ReffNotesText);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.SearchBukuKasButton);
            this.panel1.Controls.Add(this.SearchPihakKetigaButton);
            this.panel1.Controls.Add(this.PihakKetigaNameText);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.NewButton);
            this.panel1.Controls.Add(this.JamBukuTextBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.TglBukuTextBox);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.BukuKasIDTextBox);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.JenisTrsCombo);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.PihakKetigaText);
            this.panel1.Controls.Add(this.NilaiText);
            this.panel1.Controls.Add(this.ReffIDText);
            this.panel1.Controls.Add(this.KeteranganText);
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(680, 405);
            this.panel1.TabIndex = 29;
            // 
            // ReffNotesText
            // 
            this.ReffNotesText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ReffNotesText.Location = new System.Drawing.Point(235, 209);
            this.ReffNotesText.Multiline = true;
            this.ReffNotesText.Name = "ReffNotesText";
            this.ReffNotesText.ReadOnly = true;
            this.ReffNotesText.Size = new System.Drawing.Size(313, 42);
            this.ReffNotesText.TabIndex = 11;
            // 
            // button4
            // 
            this.button4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button4.Location = new System.Drawing.Point(357, 180);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(28, 23);
            this.button4.TabIndex = 10;
            this.button4.Text = "...";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // SearchBukuKasButton
            // 
            this.SearchBukuKasButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SearchBukuKasButton.Location = new System.Drawing.Point(350, 45);
            this.SearchBukuKasButton.Name = "SearchBukuKasButton";
            this.SearchBukuKasButton.Size = new System.Drawing.Size(28, 23);
            this.SearchBukuKasButton.TabIndex = 1;
            this.SearchBukuKasButton.Text = "...";
            this.SearchBukuKasButton.UseVisualStyleBackColor = true;
            this.SearchBukuKasButton.Click += new System.EventHandler(this.SearchBukuKasButton_Click);
            // 
            // SearchPihakKetigaButton
            // 
            this.SearchPihakKetigaButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SearchPihakKetigaButton.Location = new System.Drawing.Point(357, 126);
            this.SearchPihakKetigaButton.Name = "SearchPihakKetigaButton";
            this.SearchPihakKetigaButton.Size = new System.Drawing.Size(28, 23);
            this.SearchPihakKetigaButton.TabIndex = 7;
            this.SearchPihakKetigaButton.Text = "...";
            this.SearchPihakKetigaButton.UseVisualStyleBackColor = true;
            this.SearchPihakKetigaButton.Click += new System.EventHandler(this.SearchPihakKetigaButton_Click);
            // 
            // PihakKetigaNameText
            // 
            this.PihakKetigaNameText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PihakKetigaNameText.Location = new System.Drawing.Point(235, 154);
            this.PihakKetigaNameText.Name = "PihakKetigaNameText";
            this.PihakKetigaNameText.ReadOnly = true;
            this.PihakKetigaNameText.Size = new System.Drawing.Size(249, 21);
            this.PihakKetigaNameText.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(145, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "No. Trs. Kasir";
            // 
            // NewButton
            // 
            this.NewButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NewButton.Location = new System.Drawing.Point(378, 45);
            this.NewButton.Name = "NewButton";
            this.NewButton.Size = new System.Drawing.Size(50, 23);
            this.NewButton.TabIndex = 2;
            this.NewButton.Text = "New";
            this.NewButton.UseVisualStyleBackColor = true;
            this.NewButton.Click += new System.EventHandler(this.NewButton_Click);
            // 
            // JamBukuTextBox
            // 
            this.JamBukuTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.JamBukuTextBox.Location = new System.Drawing.Point(355, 73);
            this.JamBukuTextBox.Mask = "99:99:99";
            this.JamBukuTextBox.Name = "JamBukuTextBox";
            this.JamBukuTextBox.Size = new System.Drawing.Size(73, 21);
            this.JamBukuTextBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(178, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Tanggal";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(196, 339);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "Nilai";
            // 
            // TglBukuTextBox
            // 
            this.TglBukuTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TglBukuTextBox.CustomFormat = "dd-MMM-yyyy";
            this.TglBukuTextBox.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.TglBukuTextBox.Location = new System.Drawing.Point(235, 73);
            this.TglBukuTextBox.Name = "TglBukuTextBox";
            this.TglBukuTextBox.Size = new System.Drawing.Size(114, 21);
            this.TglBukuTextBox.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(156, 260);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Keterangan";
            // 
            // BukuKasIDTextBox
            // 
            this.BukuKasIDTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BukuKasIDTextBox.BackColor = System.Drawing.Color.Khaki;
            this.BukuKasIDTextBox.Location = new System.Drawing.Point(235, 46);
            this.BukuKasIDTextBox.Name = "BukuKasIDTextBox";
            this.BukuKasIDTextBox.Size = new System.Drawing.Size(114, 21);
            this.BukuKasIDTextBox.TabIndex = 0;
            this.BukuKasIDTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BukuKasIDTextBox_KeyDown);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(151, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Pihak Ketiga";
            // 
            // JenisTrsCombo
            // 
            this.JenisTrsCombo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.JenisTrsCombo.FormattingEnabled = true;
            this.JenisTrsCombo.Location = new System.Drawing.Point(235, 100);
            this.JenisTrsCombo.Name = "JenisTrsCombo";
            this.JenisTrsCombo.Size = new System.Drawing.Size(150, 21);
            this.JenisTrsCombo.TabIndex = 5;
            this.JenisTrsCombo.SelectedValueChanged += new System.EventHandler(this.JenisTrsCombo_SelectedValueChanged);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(145, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Refference ID";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(134, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Jenis Transaksi";
            // 
            // PihakKetigaText
            // 
            this.PihakKetigaText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PihakKetigaText.BackColor = System.Drawing.Color.Khaki;
            this.PihakKetigaText.Location = new System.Drawing.Point(235, 127);
            this.PihakKetigaText.Name = "PihakKetigaText";
            this.PihakKetigaText.Size = new System.Drawing.Size(121, 21);
            this.PihakKetigaText.TabIndex = 6;
            this.PihakKetigaText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PihakKetigaText_KeyDown);
            // 
            // NilaiText
            // 
            this.NilaiText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NilaiText.Location = new System.Drawing.Point(236, 337);
            this.NilaiText.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.NilaiText.Minimum = new decimal(new int[] {
            99999999,
            0,
            0,
            -2147483648});
            this.NilaiText.Name = "NilaiText";
            this.NilaiText.Size = new System.Drawing.Size(120, 21);
            this.NilaiText.TabIndex = 13;
            this.NilaiText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NilaiText.ThousandsSeparator = true;
            // 
            // ReffIDText
            // 
            this.ReffIDText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ReffIDText.Location = new System.Drawing.Point(235, 181);
            this.ReffIDText.Name = "ReffIDText";
            this.ReffIDText.ReadOnly = true;
            this.ReffIDText.Size = new System.Drawing.Size(120, 21);
            this.ReffIDText.TabIndex = 9;
            // 
            // KeteranganText
            // 
            this.KeteranganText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.KeteranganText.Location = new System.Drawing.Point(235, 257);
            this.KeteranganText.Multiline = true;
            this.KeteranganText.Name = "KeteranganText";
            this.KeteranganText.Size = new System.Drawing.Size(313, 74);
            this.KeteranganText.TabIndex = 12;
            // 
            // ExitButton
            // 
            this.ExitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ExitButton.BackColor = System.Drawing.Color.MistyRose;
            this.ExitButton.Location = new System.Drawing.Point(611, 417);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(75, 23);
            this.ExitButton.TabIndex = 16;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = false;
            // 
            // DeleteButton
            // 
            this.DeleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteButton.BackColor = System.Drawing.Color.MistyRose;
            this.DeleteButton.Location = new System.Drawing.Point(530, 417);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteButton.TabIndex = 15;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = false;
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.BackColor = System.Drawing.Color.MistyRose;
            this.SaveButton.Location = new System.Drawing.Point(449, 417);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 144;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(692, 446);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // KasirDataSet
            // 
            this.KasirDataSet.DataSetName = "NewDataSet";
            this.KasirDataSet.Tables.AddRange(new System.Data.DataTable[] {
            this.BukuKasTable});
            // 
            // BukuKasTable
            // 
            this.BukuKasTable.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3,
            this.dataColumn4,
            this.dataColumn5,
            this.dataColumn6,
            this.dataColumn7,
            this.dataColumn8,
            this.dataColumn9});
            this.BukuKasTable.TableName = "BukuKasTable";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "BukuKasID";
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "TglBuku";
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "JamBuku";
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "JenisTrsKasirID";
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "ReffID";
            // 
            // dataColumn6
            // 
            this.dataColumn6.ColumnName = "PihakKetigaID";
            // 
            // dataColumn7
            // 
            this.dataColumn7.ColumnName = "Keterangan";
            // 
            // dataColumn8
            // 
            this.dataColumn8.ColumnName = "Nilai";
            // 
            // dataColumn9
            // 
            this.dataColumn9.ColumnName = "PihakKetigaName";
            // 
            // BukuKasBindingSource
            // 
            this.BukuKasBindingSource.DataMember = "BukuKasTable";
            this.BukuKasBindingSource.DataSource = this.KasirDataSet;
            // 
            // KasirForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 472);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "KasirForm";
            this.Text = "KasirForm";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NilaiText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KasirDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BukuKasTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BukuKasBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.NumericUpDown NilaiText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox JenisTrsCombo;
        private System.Windows.Forms.TextBox BukuKasIDTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker TglBukuTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox JamBukuTextBox;
        private System.Windows.Forms.Button NewButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox PihakKetigaText;
        private System.Windows.Forms.TextBox ReffIDText;
        private System.Windows.Forms.TextBox KeteranganText;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Panel panel1;
        private System.Data.DataSet KasirDataSet;
        private System.Windows.Forms.TextBox PihakKetigaNameText;
        private System.Data.DataTable BukuKasTable;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataColumn dataColumn5;
        private System.Data.DataColumn dataColumn6;
        private System.Data.DataColumn dataColumn7;
        private System.Data.DataColumn dataColumn8;
        private System.Windows.Forms.BindingSource BukuKasBindingSource;
        private System.Data.DataColumn dataColumn9;
        private System.Windows.Forms.Button SearchPihakKetigaButton;
        private System.Windows.Forms.Button SearchBukuKasButton;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox ReffNotesText;
    }
}