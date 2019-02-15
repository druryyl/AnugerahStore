namespace AnugerahWinform.Accounting
{
    partial class LunasKasBonForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.MainTab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.NilaiTotLunasText = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.ListLunasGrid = new System.Windows.Forms.DataGridView();
            this.jenisLunasIDColDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ButtonSearchCol = new System.Windows.Forms.DataGridViewButtonColumn();
            this.jenisLunasNameColDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nilaiLunasColDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ListLunasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.LunasKasBonDataSet = new System.Data.DataSet();
            this.ListLunasTable = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.PihakKeduaNameText = new System.Windows.Forms.TextBox();
            this.SearchKasBonButton = new System.Windows.Forms.Button();
            this.KasBonIDText = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SearchLunasKasBonButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.NewButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.TglText = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.NilaiSisaPiutangText = new System.Windows.Forms.NumericUpDown();
            this.KeteranganText = new System.Windows.Forms.TextBox();
            this.JamText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.LunasKasBonIDText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.JamTimer = new System.Windows.Forms.Timer(this.components);
            this.PihakKeduaIDText = new System.Windows.Forms.TextBox();
            this.MainTab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NilaiTotLunasText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListLunasGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListLunasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LunasKasBonDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListLunasTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NilaiSisaPiutangText)).BeginInit();
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
            this.MainTab.Size = new System.Drawing.Size(476, 585);
            this.MainTab.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Bisque;
            this.tabPage1.Controls.Add(this.PihakKeduaIDText);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.NilaiTotLunasText);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.ListLunasGrid);
            this.tabPage1.Controls.Add(this.PihakKeduaNameText);
            this.tabPage1.Controls.Add(this.SearchKasBonButton);
            this.tabPage1.Controls.Add(this.KasBonIDText);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.SearchLunasKasBonButton);
            this.tabPage1.Controls.Add(this.ExitButton);
            this.tabPage1.Controls.Add(this.SaveButton);
            this.tabPage1.Controls.Add(this.NewButton);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.TglText);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.NilaiSisaPiutangText);
            this.tabPage1.Controls.Add(this.KeteranganText);
            this.tabPage1.Controls.Add(this.JamText);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.LunasKasBonIDText);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.DeleteButton);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(468, 559);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Input Transaksi";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(250, 488);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Nilai Pelunasan";
            // 
            // NilaiTotLunasText
            // 
            this.NilaiTotLunasText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.NilaiTotLunasText.Location = new System.Drawing.Point(349, 486);
            this.NilaiTotLunasText.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.NilaiTotLunasText.Minimum = new decimal(new int[] {
            99999999,
            0,
            0,
            -2147483648});
            this.NilaiTotLunasText.Name = "NilaiTotLunasText";
            this.NilaiTotLunasText.ReadOnly = true;
            this.NilaiTotLunasText.Size = new System.Drawing.Size(111, 21);
            this.NilaiTotLunasText.TabIndex = 19;
            this.NilaiTotLunasText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NilaiTotLunasText.ThousandsSeparator = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 274);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Pelunasan";
            // 
            // ListLunasGrid
            // 
            this.ListLunasGrid.AllowUserToAddRows = false;
            this.ListLunasGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListLunasGrid.AutoGenerateColumns = false;
            this.ListLunasGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ListLunasGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.jenisLunasIDColDataGridViewTextBoxColumn,
            this.ButtonSearchCol,
            this.jenisLunasNameColDataGridViewTextBoxColumn,
            this.nilaiLunasColDataGridViewTextBoxColumn});
            this.ListLunasGrid.DataSource = this.ListLunasBindingSource;
            this.ListLunasGrid.Location = new System.Drawing.Point(6, 290);
            this.ListLunasGrid.Name = "ListLunasGrid";
            this.ListLunasGrid.Size = new System.Drawing.Size(454, 190);
            this.ListLunasGrid.TabIndex = 17;
            this.ListLunasGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ListLunasGrid_CellContentClick);
            this.ListLunasGrid.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.ListLunasGrid_CellValidated);
            this.ListLunasGrid.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.ListLunasGrid_CellValidating);
            // 
            // jenisLunasIDColDataGridViewTextBoxColumn
            // 
            this.jenisLunasIDColDataGridViewTextBoxColumn.DataPropertyName = "JenisLunasIDCol";
            this.jenisLunasIDColDataGridViewTextBoxColumn.FillWeight = 50F;
            this.jenisLunasIDColDataGridViewTextBoxColumn.HeaderText = "Kode";
            this.jenisLunasIDColDataGridViewTextBoxColumn.Name = "jenisLunasIDColDataGridViewTextBoxColumn";
            this.jenisLunasIDColDataGridViewTextBoxColumn.ReadOnly = true;
            this.jenisLunasIDColDataGridViewTextBoxColumn.Width = 50;
            // 
            // ButtonSearchCol
            // 
            this.ButtonSearchCol.FillWeight = 20F;
            this.ButtonSearchCol.HeaderText = "...";
            this.ButtonSearchCol.Name = "ButtonSearchCol";
            this.ButtonSearchCol.ReadOnly = true;
            this.ButtonSearchCol.Width = 20;
            // 
            // jenisLunasNameColDataGridViewTextBoxColumn
            // 
            this.jenisLunasNameColDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.jenisLunasNameColDataGridViewTextBoxColumn.DataPropertyName = "JenisLunasNameCol";
            this.jenisLunasNameColDataGridViewTextBoxColumn.HeaderText = "Jenis Lunas";
            this.jenisLunasNameColDataGridViewTextBoxColumn.Name = "jenisLunasNameColDataGridViewTextBoxColumn";
            this.jenisLunasNameColDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nilaiLunasColDataGridViewTextBoxColumn
            // 
            this.nilaiLunasColDataGridViewTextBoxColumn.DataPropertyName = "NilaiLunasCol";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            this.nilaiLunasColDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.nilaiLunasColDataGridViewTextBoxColumn.HeaderText = "Nilai Lunas";
            this.nilaiLunasColDataGridViewTextBoxColumn.Name = "nilaiLunasColDataGridViewTextBoxColumn";
            // 
            // ListLunasBindingSource
            // 
            this.ListLunasBindingSource.DataMember = "ListLunasTable";
            this.ListLunasBindingSource.DataSource = this.LunasKasBonDataSet;
            // 
            // LunasKasBonDataSet
            // 
            this.LunasKasBonDataSet.DataSetName = "NewDataSet";
            this.LunasKasBonDataSet.Tables.AddRange(new System.Data.DataTable[] {
            this.ListLunasTable});
            // 
            // ListLunasTable
            // 
            this.ListLunasTable.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3});
            this.ListLunasTable.TableName = "ListLunasTable";
            // 
            // dataColumn1
            // 
            this.dataColumn1.Caption = "ID";
            this.dataColumn1.ColumnName = "JenisLunasIDCol";
            // 
            // dataColumn2
            // 
            this.dataColumn2.Caption = "Nama";
            this.dataColumn2.ColumnName = "JenisLunasNameCol";
            // 
            // dataColumn3
            // 
            this.dataColumn3.Caption = "Nilai Lunas";
            this.dataColumn3.ColumnName = "NilaiLunasCol";
            this.dataColumn3.DataType = typeof(decimal);
            // 
            // PihakKeduaNameText
            // 
            this.PihakKeduaNameText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PihakKeduaNameText.Location = new System.Drawing.Point(76, 153);
            this.PihakKeduaNameText.Name = "PihakKeduaNameText";
            this.PihakKeduaNameText.ReadOnly = true;
            this.PihakKeduaNameText.Size = new System.Drawing.Size(384, 21);
            this.PihakKeduaNameText.TabIndex = 16;
            // 
            // SearchKasBonButton
            // 
            this.SearchKasBonButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchKasBonButton.Location = new System.Drawing.Point(427, 113);
            this.SearchKasBonButton.Name = "SearchKasBonButton";
            this.SearchKasBonButton.Size = new System.Drawing.Size(33, 23);
            this.SearchKasBonButton.TabIndex = 15;
            this.SearchKasBonButton.Text = "...";
            this.SearchKasBonButton.UseVisualStyleBackColor = true;
            this.SearchKasBonButton.Click += new System.EventHandler(this.SearchKasBonButton_Click);
            // 
            // KasBonIDText
            // 
            this.KasBonIDText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.KasBonIDText.Location = new System.Drawing.Point(6, 113);
            this.KasBonIDText.Name = "KasBonIDText";
            this.KasBonIDText.ReadOnly = true;
            this.KasBonIDText.Size = new System.Drawing.Size(415, 21);
            this.KasBonIDText.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 97);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "KasBon ID";
            // 
            // SearchLunasKasBonButton
            // 
            this.SearchLunasKasBonButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchLunasKasBonButton.Location = new System.Drawing.Point(349, 32);
            this.SearchLunasKasBonButton.Name = "SearchLunasKasBonButton";
            this.SearchLunasKasBonButton.Size = new System.Drawing.Size(33, 23);
            this.SearchLunasKasBonButton.TabIndex = 2;
            this.SearchLunasKasBonButton.Text = "...";
            this.SearchLunasKasBonButton.UseVisualStyleBackColor = true;
            this.SearchLunasKasBonButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ExitButton.Location = new System.Drawing.Point(364, 525);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(96, 23);
            this.ExitButton.TabIndex = 12;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.Location = new System.Drawing.Point(6, 525);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(258, 23);
            this.SaveButton.TabIndex = 10;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // NewButton
            // 
            this.NewButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NewButton.Location = new System.Drawing.Point(388, 32);
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
            this.label6.Location = new System.Drawing.Point(350, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Jam";
            // 
            // TglText
            // 
            this.TglText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TglText.Location = new System.Drawing.Point(6, 73);
            this.TglText.Name = "TglText";
            this.TglText.Size = new System.Drawing.Size(341, 21);
            this.TglText.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Pihak Kedua";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(238, 265);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Nilai Sisa Piutang";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Keterangan";
            // 
            // NilaiSisaPiutangText
            // 
            this.NilaiSisaPiutangText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NilaiSisaPiutangText.Location = new System.Drawing.Point(349, 263);
            this.NilaiSisaPiutangText.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.NilaiSisaPiutangText.Minimum = new decimal(new int[] {
            99999999,
            0,
            0,
            -2147483648});
            this.NilaiSisaPiutangText.Name = "NilaiSisaPiutangText";
            this.NilaiSisaPiutangText.ReadOnly = true;
            this.NilaiSisaPiutangText.Size = new System.Drawing.Size(111, 21);
            this.NilaiSisaPiutangText.TabIndex = 9;
            this.NilaiSisaPiutangText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NilaiSisaPiutangText.ThousandsSeparator = true;
            // 
            // KeteranganText
            // 
            this.KeteranganText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.KeteranganText.Location = new System.Drawing.Point(6, 193);
            this.KeteranganText.Multiline = true;
            this.KeteranganText.Name = "KeteranganText";
            this.KeteranganText.ReadOnly = true;
            this.KeteranganText.Size = new System.Drawing.Size(454, 64);
            this.KeteranganText.TabIndex = 6;
            // 
            // JamText
            // 
            this.JamText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.JamText.Location = new System.Drawing.Point(353, 73);
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
            // LunasKasBonIDText
            // 
            this.LunasKasBonIDText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LunasKasBonIDText.Location = new System.Drawing.Point(6, 33);
            this.LunasKasBonIDText.Name = "LunasKasBonIDText";
            this.LunasKasBonIDText.ReadOnly = true;
            this.LunasKasBonIDText.Size = new System.Drawing.Size(341, 21);
            this.LunasKasBonIDText.TabIndex = 1;
            this.LunasKasBonIDText.Validated += new System.EventHandler(this.LunasKasBonIDText_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "No.Pelunasan KasBon";
            // 
            // DeleteButton
            // 
            this.DeleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteButton.Location = new System.Drawing.Point(270, 525);
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
            this.tabPage2.Size = new System.Drawing.Size(468, 559);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Informasi";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // JamTimer
            // 
            this.JamTimer.Enabled = true;
            this.JamTimer.Tick += new System.EventHandler(this.JamTimer_Tick);
            // 
            // PihakKeduaIDText
            // 
            this.PihakKeduaIDText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PihakKeduaIDText.Location = new System.Drawing.Point(6, 153);
            this.PihakKeduaIDText.Name = "PihakKeduaIDText";
            this.PihakKeduaIDText.ReadOnly = true;
            this.PihakKeduaIDText.Size = new System.Drawing.Size(67, 21);
            this.PihakKeduaIDText.TabIndex = 21;
            // 
            // LunasKasBonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 585);
            this.Controls.Add(this.MainTab);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "LunasKasBonForm";
            this.Text = "LunasKasBonForm";
            this.MainTab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NilaiTotLunasText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListLunasGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListLunasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LunasKasBonDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListLunasTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NilaiSisaPiutangText)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl MainTab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button SearchLunasKasBonButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button NewButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker TglText;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown NilaiSisaPiutangText;
        private System.Windows.Forms.TextBox KeteranganText;
        private System.Windows.Forms.TextBox JamText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox LunasKasBonIDText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Timer JamTimer;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox PihakKeduaNameText;
        private System.Windows.Forms.Button SearchKasBonButton;
        private System.Windows.Forms.TextBox KasBonIDText;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView ListLunasGrid;
        private System.Data.DataSet LunasKasBonDataSet;
        private System.Windows.Forms.BindingSource ListLunasBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn jenisLunasIDColDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn ButtonSearchCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn jenisLunasNameColDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nilaiLunasColDataGridViewTextBoxColumn;
        private System.Data.DataTable ListLunasTable;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown NilaiTotLunasText;
        private System.Windows.Forms.TextBox PihakKeduaIDText;
    }
}