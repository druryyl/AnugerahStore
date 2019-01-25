namespace AnugerahWinform.Penjualan
{
    partial class PenjualanForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.entryDataTabPage = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.CatatanLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.AlamatLabel = new System.Windows.Forms.Label();
            this.NoTelpTextBox = new System.Windows.Forms.TextBox();
            this.AlamatTextBox = new System.Windows.Forms.TextBox();
            this.CustomerComboBox = new System.Windows.Forms.ComboBox();
            this.CustomerIDLabel = new System.Windows.Forms.Label();
            this.LastIDLabel = new System.Windows.Forms.Label();
            this.BuyerNameTextBox = new System.Windows.Forms.TextBox();
            this.NoTrsTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TanggalDateTime = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.JamTextBox = new System.Windows.Forms.MaskedTextBox();
            this.NewButton = new System.Windows.Forms.Button();
            this.BuyerNameLabel = new System.Windows.Forms.Label();
            this.BrgGrid = new System.Windows.Forms.DataGridView();
            this.ExitButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.listDataTabPage = new System.Windows.Forms.TabPage();
            this.showListButton = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.listDataGrid = new System.Windows.Forms.DataGridView();
            this.JamTrsTimer = new System.Windows.Forms.Timer(this.components);
            this.PenjualanBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PenjualanDataSet = new System.Data.DataSet();
            this.DetilPenjualanTable = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataColumn5 = new System.Data.DataColumn();
            this.dataColumn6 = new System.Data.DataColumn();
            this.BrgIDCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BrgGridButtonCol = new System.Windows.Forms.DataGridViewButtonColumn();
            this.BrgNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtyCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HargaCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiskonCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTotalCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainTabControl.SuspendLayout();
            this.entryDataTabPage.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BrgGrid)).BeginInit();
            this.listDataTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PenjualanBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PenjualanDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DetilPenjualanTable)).BeginInit();
            this.SuspendLayout();
            // 
            // mainTabControl
            // 
            this.mainTabControl.Controls.Add(this.entryDataTabPage);
            this.mainTabControl.Controls.Add(this.listDataTabPage);
            this.mainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTabControl.Location = new System.Drawing.Point(0, 0);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(979, 579);
            this.mainTabControl.TabIndex = 6;
            // 
            // entryDataTabPage
            // 
            this.entryDataTabPage.BackColor = System.Drawing.Color.Khaki;
            this.entryDataTabPage.Controls.Add(this.panel2);
            this.entryDataTabPage.Controls.Add(this.panel1);
            this.entryDataTabPage.Controls.Add(this.BrgGrid);
            this.entryDataTabPage.Controls.Add(this.ExitButton);
            this.entryDataTabPage.Controls.Add(this.deleteButton);
            this.entryDataTabPage.Controls.Add(this.saveButton);
            this.entryDataTabPage.Location = new System.Drawing.Point(4, 22);
            this.entryDataTabPage.Name = "entryDataTabPage";
            this.entryDataTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.entryDataTabPage.Size = new System.Drawing.Size(971, 553);
            this.entryDataTabPage.TabIndex = 0;
            this.entryDataTabPage.Text = "Entry Data";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.LemonChiffon;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.textBox7);
            this.panel2.Controls.Add(this.textBox6);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.textBox2);
            this.panel2.Controls.Add(this.textBox5);
            this.panel2.Controls.Add(this.textBox3);
            this.panel2.Controls.Add(this.textBox4);
            this.panel2.Location = new System.Drawing.Point(6, 407);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(959, 111);
            this.panel2.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(773, 81);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 29;
            this.label9.Text = "Kembali";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(785, 54);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 28;
            this.label8.Text = "Bayar";
            // 
            // textBox7
            // 
            this.textBox7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox7.Location = new System.Drawing.Point(832, 78);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(113, 21);
            this.textBox7.TabIndex = 27;
            // 
            // textBox6
            // 
            this.textBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox6.Location = new System.Drawing.Point(832, 51);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(113, 21);
            this.textBox6.TabIndex = 26;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(829, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "Grand Total";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(710, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Biaya Lain";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(592, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Diskon Lain";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(473, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Total";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(476, 24);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(113, 21);
            this.textBox2.TabIndex = 14;
            // 
            // textBox5
            // 
            this.textBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox5.Location = new System.Drawing.Point(832, 24);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(113, 21);
            this.textBox5.TabIndex = 17;
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.Location = new System.Drawing.Point(595, 24);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(113, 21);
            this.textBox3.TabIndex = 15;
            // 
            // textBox4
            // 
            this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox4.Location = new System.Drawing.Point(713, 24);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(113, 21);
            this.textBox4.TabIndex = 16;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.LemonChiffon;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.CatatanLabel);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.AlamatLabel);
            this.panel1.Controls.Add(this.NoTelpTextBox);
            this.panel1.Controls.Add(this.AlamatTextBox);
            this.panel1.Controls.Add(this.CustomerComboBox);
            this.panel1.Controls.Add(this.CustomerIDLabel);
            this.panel1.Controls.Add(this.LastIDLabel);
            this.panel1.Controls.Add(this.BuyerNameTextBox);
            this.panel1.Controls.Add(this.NoTrsTextBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.TanggalDateTime);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.JamTextBox);
            this.panel1.Controls.Add(this.NewButton);
            this.panel1.Controls.Add(this.BuyerNameLabel);
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(959, 147);
            this.panel1.TabIndex = 13;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(631, 69);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(313, 60);
            this.textBox1.TabIndex = 22;
            // 
            // CatatanLabel
            // 
            this.CatatanLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CatatanLabel.AutoSize = true;
            this.CatatanLabel.Location = new System.Drawing.Point(573, 69);
            this.CatatanLabel.Name = "CatatanLabel";
            this.CatatanLabel.Size = new System.Drawing.Size(52, 13);
            this.CatatanLabel.TabIndex = 21;
            this.CatatanLabel.Text = "Catatan";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(566, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "NoTelpon";
            // 
            // AlamatLabel
            // 
            this.AlamatLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AlamatLabel.AutoSize = true;
            this.AlamatLabel.Location = new System.Drawing.Point(578, 18);
            this.AlamatLabel.Name = "AlamatLabel";
            this.AlamatLabel.Size = new System.Drawing.Size(47, 13);
            this.AlamatLabel.TabIndex = 19;
            this.AlamatLabel.Text = "Alamat";
            // 
            // NoTelpTextBox
            // 
            this.NoTelpTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NoTelpTextBox.Location = new System.Drawing.Point(631, 42);
            this.NoTelpTextBox.Name = "NoTelpTextBox";
            this.NoTelpTextBox.Size = new System.Drawing.Size(313, 21);
            this.NoTelpTextBox.TabIndex = 18;
            // 
            // AlamatTextBox
            // 
            this.AlamatTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AlamatTextBox.Location = new System.Drawing.Point(631, 15);
            this.AlamatTextBox.Name = "AlamatTextBox";
            this.AlamatTextBox.Size = new System.Drawing.Size(313, 21);
            this.AlamatTextBox.TabIndex = 17;
            // 
            // CustomerComboBox
            // 
            this.CustomerComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CustomerComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CustomerComboBox.FormattingEnabled = true;
            this.CustomerComboBox.Location = new System.Drawing.Point(148, 69);
            this.CustomerComboBox.Name = "CustomerComboBox";
            this.CustomerComboBox.Size = new System.Drawing.Size(313, 21);
            this.CustomerComboBox.TabIndex = 16;
            // 
            // CustomerIDLabel
            // 
            this.CustomerIDLabel.AutoSize = true;
            this.CustomerIDLabel.Location = new System.Drawing.Point(61, 72);
            this.CustomerIDLabel.Name = "CustomerIDLabel";
            this.CustomerIDLabel.Size = new System.Drawing.Size(81, 13);
            this.CustomerIDLabel.TabIndex = 15;
            this.CustomerIDLabel.Text = "Customer ID";
            // 
            // LastIDLabel
            // 
            this.LastIDLabel.AutoSize = true;
            this.LastIDLabel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LastIDLabel.Location = new System.Drawing.Point(361, 18);
            this.LastIDLabel.Name = "LastIDLabel";
            this.LastIDLabel.Size = new System.Drawing.Size(0, 13);
            this.LastIDLabel.TabIndex = 14;
            // 
            // BuyerNameTextBox
            // 
            this.BuyerNameTextBox.Location = new System.Drawing.Point(148, 96);
            this.BuyerNameTextBox.Name = "BuyerNameTextBox";
            this.BuyerNameTextBox.Size = new System.Drawing.Size(313, 21);
            this.BuyerNameTextBox.TabIndex = 13;
            // 
            // NoTrsTextBox
            // 
            this.NoTrsTextBox.BackColor = System.Drawing.Color.Beige;
            this.NoTrsTextBox.Location = new System.Drawing.Point(148, 15);
            this.NoTrsTextBox.Name = "NoTrsTextBox";
            this.NoTrsTextBox.Size = new System.Drawing.Size(114, 21);
            this.NoTrsTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "No. Adjustment";
            // 
            // TanggalDateTime
            // 
            this.TanggalDateTime.CustomFormat = "dd-MMM-yyyy";
            this.TanggalDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.TanggalDateTime.Location = new System.Drawing.Point(148, 42);
            this.TanggalDateTime.Name = "TanggalDateTime";
            this.TanggalDateTime.Size = new System.Drawing.Size(114, 21);
            this.TanggalDateTime.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(91, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Tanggal";
            // 
            // JamTextBox
            // 
            this.JamTextBox.Location = new System.Drawing.Point(268, 42);
            this.JamTextBox.Mask = "99:99:99";
            this.JamTextBox.Name = "JamTextBox";
            this.JamTextBox.Size = new System.Drawing.Size(73, 21);
            this.JamTextBox.TabIndex = 8;
            // 
            // NewButton
            // 
            this.NewButton.Location = new System.Drawing.Point(268, 13);
            this.NewButton.Name = "NewButton";
            this.NewButton.Size = new System.Drawing.Size(59, 23);
            this.NewButton.TabIndex = 9;
            this.NewButton.Text = "New";
            this.NewButton.UseVisualStyleBackColor = true;
            // 
            // BuyerNameLabel
            // 
            this.BuyerNameLabel.AutoSize = true;
            this.BuyerNameLabel.Location = new System.Drawing.Point(53, 99);
            this.BuyerNameLabel.Name = "BuyerNameLabel";
            this.BuyerNameLabel.Size = new System.Drawing.Size(89, 13);
            this.BuyerNameLabel.TabIndex = 11;
            this.BuyerNameLabel.Text = "Nama Pembeli";
            // 
            // BrgGrid
            // 
            this.BrgGrid.AllowUserToAddRows = false;
            this.BrgGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BrgGrid.AutoGenerateColumns = false;
            this.BrgGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BrgGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BrgIDCol,
            this.BrgGridButtonCol,
            this.BrgNameCol,
            this.QtyCol,
            this.HargaCol,
            this.DiskonCol,
            this.SubTotalCol});
            this.BrgGrid.DataSource = this.PenjualanBindingSource;
            this.BrgGrid.Location = new System.Drawing.Point(6, 159);
            this.BrgGrid.Name = "BrgGrid";
            this.BrgGrid.Size = new System.Drawing.Size(959, 242);
            this.BrgGrid.TabIndex = 10;
            // 
            // ExitButton
            // 
            this.ExitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ExitButton.Location = new System.Drawing.Point(864, 524);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(87, 23);
            this.ExitButton.TabIndex = 8;
            this.ExitButton.Text = "E&xit";
            this.ExitButton.UseVisualStyleBackColor = true;
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteButton.Location = new System.Drawing.Point(771, 524);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(87, 23);
            this.deleteButton.TabIndex = 7;
            this.deleteButton.Text = "&Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Location = new System.Drawing.Point(678, 524);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(87, 23);
            this.saveButton.TabIndex = 6;
            this.saveButton.Text = "&Save";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // listDataTabPage
            // 
            this.listDataTabPage.Controls.Add(this.showListButton);
            this.listDataTabPage.Controls.Add(this.comboBox2);
            this.listDataTabPage.Controls.Add(this.dateTimePicker2);
            this.listDataTabPage.Controls.Add(this.dateTimePicker1);
            this.listDataTabPage.Controls.Add(this.listDataGrid);
            this.listDataTabPage.Location = new System.Drawing.Point(4, 22);
            this.listDataTabPage.Name = "listDataTabPage";
            this.listDataTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.listDataTabPage.Size = new System.Drawing.Size(971, 553);
            this.listDataTabPage.TabIndex = 1;
            this.listDataTabPage.Text = "List Data";
            this.listDataTabPage.UseVisualStyleBackColor = true;
            // 
            // showListButton
            // 
            this.showListButton.Location = new System.Drawing.Point(466, 4);
            this.showListButton.Name = "showListButton";
            this.showListButton.Size = new System.Drawing.Size(94, 23);
            this.showListButton.TabIndex = 15;
            this.showListButton.Text = "Show List";
            this.showListButton.UseVisualStyleBackColor = true;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(246, 6);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(214, 21);
            this.comboBox2.TabIndex = 14;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "dd-MMM-yyyy";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(126, 6);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(114, 21);
            this.dateTimePicker2.TabIndex = 13;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd-MMM-yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(6, 6);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(114, 21);
            this.dateTimePicker1.TabIndex = 12;
            // 
            // listDataGrid
            // 
            this.listDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listDataGrid.Location = new System.Drawing.Point(6, 33);
            this.listDataGrid.Name = "listDataGrid";
            this.listDataGrid.Size = new System.Drawing.Size(945, 475);
            this.listDataGrid.TabIndex = 11;
            // 
            // JamTrsTimer
            // 
            this.JamTrsTimer.Enabled = true;
            this.JamTrsTimer.Interval = 1000;
            // 
            // PenjualanBindingSource
            // 
            this.PenjualanBindingSource.AllowNew = true;
            this.PenjualanBindingSource.DataMember = "DetilPenjualanTable";
            this.PenjualanBindingSource.DataSource = this.PenjualanDataSet;
            // 
            // PenjualanDataSet
            // 
            this.PenjualanDataSet.DataSetName = "NewDataSet";
            this.PenjualanDataSet.Tables.AddRange(new System.Data.DataTable[] {
            this.DetilPenjualanTable});
            // 
            // DetilPenjualanTable
            // 
            this.DetilPenjualanTable.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3,
            this.dataColumn4,
            this.dataColumn5,
            this.dataColumn6});
            this.DetilPenjualanTable.TableName = "DetilPenjualanTable";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "BrgID";
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "BrgName";
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "Qty";
            this.dataColumn3.DataType = typeof(int);
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "Harga";
            this.dataColumn4.DataType = typeof(double);
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "Diskon";
            this.dataColumn5.DataType = typeof(double);
            // 
            // dataColumn6
            // 
            this.dataColumn6.ColumnName = "SubTotal";
            this.dataColumn6.DataType = typeof(double);
            // 
            // BrgIDCol
            // 
            this.BrgIDCol.DataPropertyName = "BrgID";
            this.BrgIDCol.HeaderText = "BrgID";
            this.BrgIDCol.Name = "BrgIDCol";
            // 
            // BrgGridButtonCol
            // 
            this.BrgGridButtonCol.HeaderText = "...";
            this.BrgGridButtonCol.Name = "BrgGridButtonCol";
            this.BrgGridButtonCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.BrgGridButtonCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.BrgGridButtonCol.Width = 25;
            // 
            // BrgNameCol
            // 
            this.BrgNameCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.BrgNameCol.DataPropertyName = "BrgName";
            this.BrgNameCol.HeaderText = "BrgName";
            this.BrgNameCol.Name = "BrgNameCol";
            // 
            // QtyCol
            // 
            this.QtyCol.DataPropertyName = "Qty";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = "0";
            this.QtyCol.DefaultCellStyle = dataGridViewCellStyle1;
            this.QtyCol.HeaderText = "Qty";
            this.QtyCol.Name = "QtyCol";
            // 
            // HargaCol
            // 
            this.HargaCol.DataPropertyName = "Harga";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = "0";
            this.HargaCol.DefaultCellStyle = dataGridViewCellStyle2;
            this.HargaCol.HeaderText = "Harga";
            this.HargaCol.Name = "HargaCol";
            // 
            // DiskonCol
            // 
            this.DiskonCol.DataPropertyName = "Diskon";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = "0";
            this.DiskonCol.DefaultCellStyle = dataGridViewCellStyle3;
            this.DiskonCol.HeaderText = "Diskon";
            this.DiskonCol.Name = "DiskonCol";
            // 
            // SubTotalCol
            // 
            this.SubTotalCol.DataPropertyName = "SubTotal";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = "0";
            this.SubTotalCol.DefaultCellStyle = dataGridViewCellStyle4;
            this.SubTotalCol.HeaderText = "SubTotal";
            this.SubTotalCol.Name = "SubTotalCol";
            // 
            // PenjualanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 579);
            this.Controls.Add(this.mainTabControl);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "PenjualanForm";
            this.Text = "PenjualanForm";
            this.Load += new System.EventHandler(this.PenjualanForm_Load);
            this.mainTabControl.ResumeLayout(false);
            this.entryDataTabPage.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BrgGrid)).EndInit();
            this.listDataTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PenjualanBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PenjualanDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DetilPenjualanTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage entryDataTabPage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LastIDLabel;
        private System.Windows.Forms.TextBox BuyerNameTextBox;
        private System.Windows.Forms.TextBox NoTrsTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker TanggalDateTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox JamTextBox;
        private System.Windows.Forms.Button NewButton;
        private System.Windows.Forms.Label BuyerNameLabel;
        private System.Windows.Forms.DataGridView BrgGrid;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TabPage listDataTabPage;
        private System.Windows.Forms.Button showListButton;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DataGridView listDataGrid;
        private System.Windows.Forms.Timer JamTrsTimer;
        private System.Windows.Forms.BindingSource PenjualanBindingSource;
        private System.Data.DataSet PenjualanDataSet;
        private System.Data.DataTable DetilPenjualanTable;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataColumn dataColumn5;
        private System.Data.DataColumn dataColumn6;
        private System.Windows.Forms.ComboBox CustomerComboBox;
        private System.Windows.Forms.Label CustomerIDLabel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label CatatanLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label AlamatLabel;
        private System.Windows.Forms.TextBox NoTelpTextBox;
        private System.Windows.Forms.TextBox AlamatTextBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn BrgIDCol;
        private System.Windows.Forms.DataGridViewButtonColumn BrgGridButtonCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn BrgNameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtyCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn HargaCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiskonCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubTotalCol;
    }
}