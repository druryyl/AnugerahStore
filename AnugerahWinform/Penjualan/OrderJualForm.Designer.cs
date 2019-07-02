namespace AnugerahWinform.Penjualan
{
    partial class OrderJualForm
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
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.entryDataTabPage = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.GrandTotalNumText = new System.Windows.Forms.NumericUpDown();
            this.BiayaLainNumText = new System.Windows.Forms.NumericUpDown();
            this.DiskonNumText = new System.Windows.Forms.NumericUpDown();
            this.TotalNumText = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CustomerNameTextBox = new System.Windows.Forms.TextBox();
            this.SearchCustomerButton = new System.Windows.Forms.Button();
            this.CustomerIDTextBox = new System.Windows.Forms.TextBox();
            this.CatatanTextBox = new System.Windows.Forms.TextBox();
            this.CatatanLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.AlamatLabel = new System.Windows.Forms.Label();
            this.NoTelpTextBox = new System.Windows.Forms.TextBox();
            this.AlamatTextBox = new System.Windows.Forms.TextBox();
            this.CustomerLabel = new System.Windows.Forms.Label();
            this.LastIDLabel = new System.Windows.Forms.Label();
            this.BuyerNameTextBox = new System.Windows.Forms.TextBox();
            this.OrderJualIDTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TglOrderTextBox = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.JamOrderTextBox = new System.Windows.Forms.MaskedTextBox();
            this.NewButton = new System.Windows.Forms.Button();
            this.BuyerNameLabel = new System.Windows.Forms.Label();
            this.BrgGrid = new System.Windows.Forms.DataGridView();
            this.BrgGridButtonCol = new System.Windows.Forms.DataGridViewButtonColumn();
            this.BPStokID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SearchStokIDButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ExitButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.listDataTabPage = new System.Windows.Forms.TabPage();
            this.showListButton = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.listDataGrid = new System.Windows.Forms.DataGridView();
            this.mainTabControl.SuspendLayout();
            this.entryDataTabPage.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrandTotalNumText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BiayaLainNumText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DiskonNumText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalNumText)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BrgGrid)).BeginInit();
            this.listDataTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listDataGrid)).BeginInit();
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
            this.mainTabControl.Size = new System.Drawing.Size(979, 481);
            this.mainTabControl.TabIndex = 7;
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
            this.entryDataTabPage.Size = new System.Drawing.Size(971, 455);
            this.entryDataTabPage.TabIndex = 0;
            this.entryDataTabPage.Text = "Entry Data";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.LemonChiffon;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.GrandTotalNumText);
            this.panel2.Controls.Add(this.BiayaLainNumText);
            this.panel2.Controls.Add(this.DiskonNumText);
            this.panel2.Controls.Add(this.TotalNumText);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(6, 360);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(959, 60);
            this.panel2.TabIndex = 18;
            // 
            // GrandTotalNumText
            // 
            this.GrandTotalNumText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GrandTotalNumText.Enabled = false;
            this.GrandTotalNumText.InterceptArrowKeys = false;
            this.GrandTotalNumText.Location = new System.Drawing.Point(831, 19);
            this.GrandTotalNumText.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.GrandTotalNumText.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.GrandTotalNumText.Name = "GrandTotalNumText";
            this.GrandTotalNumText.ReadOnly = true;
            this.GrandTotalNumText.Size = new System.Drawing.Size(113, 21);
            this.GrandTotalNumText.TabIndex = 15;
            this.GrandTotalNumText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.GrandTotalNumText.ThousandsSeparator = true;
            // 
            // BiayaLainNumText
            // 
            this.BiayaLainNumText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BiayaLainNumText.InterceptArrowKeys = false;
            this.BiayaLainNumText.Location = new System.Drawing.Point(713, 20);
            this.BiayaLainNumText.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.BiayaLainNumText.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.BiayaLainNumText.Name = "BiayaLainNumText";
            this.BiayaLainNumText.Size = new System.Drawing.Size(113, 21);
            this.BiayaLainNumText.TabIndex = 14;
            this.BiayaLainNumText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.BiayaLainNumText.ThousandsSeparator = true;
            // 
            // DiskonNumText
            // 
            this.DiskonNumText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DiskonNumText.InterceptArrowKeys = false;
            this.DiskonNumText.Location = new System.Drawing.Point(595, 20);
            this.DiskonNumText.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.DiskonNumText.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.DiskonNumText.Name = "DiskonNumText";
            this.DiskonNumText.Size = new System.Drawing.Size(113, 21);
            this.DiskonNumText.TabIndex = 13;
            this.DiskonNumText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.DiskonNumText.ThousandsSeparator = true;
            this.DiskonNumText.ValueChanged += new System.EventHandler(this.DiskonNumText_ValueChanged);
            // 
            // TotalNumText
            // 
            this.TotalNumText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TotalNumText.Enabled = false;
            this.TotalNumText.InterceptArrowKeys = false;
            this.TotalNumText.Location = new System.Drawing.Point(476, 20);
            this.TotalNumText.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.TotalNumText.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.TotalNumText.Name = "TotalNumText";
            this.TotalNumText.ReadOnly = true;
            this.TotalNumText.Size = new System.Drawing.Size(113, 21);
            this.TotalNumText.TabIndex = 12;
            this.TotalNumText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TotalNumText.ThousandsSeparator = true;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(829, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "Grand Total";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(710, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Biaya Lain";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(592, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Diskon Lain";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(473, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Total";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.LemonChiffon;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.CustomerNameTextBox);
            this.panel1.Controls.Add(this.SearchCustomerButton);
            this.panel1.Controls.Add(this.CustomerIDTextBox);
            this.panel1.Controls.Add(this.CatatanTextBox);
            this.panel1.Controls.Add(this.CatatanLabel);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.AlamatLabel);
            this.panel1.Controls.Add(this.NoTelpTextBox);
            this.panel1.Controls.Add(this.AlamatTextBox);
            this.panel1.Controls.Add(this.CustomerLabel);
            this.panel1.Controls.Add(this.LastIDLabel);
            this.panel1.Controls.Add(this.BuyerNameTextBox);
            this.panel1.Controls.Add(this.OrderJualIDTextBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.TglOrderTextBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.JamOrderTextBox);
            this.panel1.Controls.Add(this.NewButton);
            this.panel1.Controls.Add(this.BuyerNameLabel);
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(959, 112);
            this.panel1.TabIndex = 13;
            // 
            // CustomerNameTextBox
            // 
            this.CustomerNameTextBox.BackColor = System.Drawing.Color.Beige;
            this.CustomerNameTextBox.Location = new System.Drawing.Point(243, 57);
            this.CustomerNameTextBox.Name = "CustomerNameTextBox";
            this.CustomerNameTextBox.Size = new System.Drawing.Size(218, 21);
            this.CustomerNameTextBox.TabIndex = 6;
            // 
            // SearchCustomerButton
            // 
            this.SearchCustomerButton.Location = new System.Drawing.Point(214, 56);
            this.SearchCustomerButton.Name = "SearchCustomerButton";
            this.SearchCustomerButton.Size = new System.Drawing.Size(27, 23);
            this.SearchCustomerButton.TabIndex = 5;
            this.SearchCustomerButton.Text = "...";
            this.SearchCustomerButton.UseVisualStyleBackColor = true;
            this.SearchCustomerButton.Click += new System.EventHandler(this.SearchCustomerButton_Click);
            // 
            // CustomerIDTextBox
            // 
            this.CustomerIDTextBox.Location = new System.Drawing.Point(148, 57);
            this.CustomerIDTextBox.Name = "CustomerIDTextBox";
            this.CustomerIDTextBox.Size = new System.Drawing.Size(64, 21);
            this.CustomerIDTextBox.TabIndex = 4;
            // 
            // CatatanTextBox
            // 
            this.CatatanTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CatatanTextBox.Location = new System.Drawing.Point(631, 57);
            this.CatatanTextBox.Multiline = true;
            this.CatatanTextBox.Name = "CatatanTextBox";
            this.CatatanTextBox.Size = new System.Drawing.Size(313, 45);
            this.CatatanTextBox.TabIndex = 10;
            // 
            // CatatanLabel
            // 
            this.CatatanLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CatatanLabel.AutoSize = true;
            this.CatatanLabel.Location = new System.Drawing.Point(573, 61);
            this.CatatanLabel.Name = "CatatanLabel";
            this.CatatanLabel.Size = new System.Drawing.Size(52, 13);
            this.CatatanLabel.TabIndex = 21;
            this.CatatanLabel.Text = "Catatan";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(566, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "NoTelpon";
            // 
            // AlamatLabel
            // 
            this.AlamatLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AlamatLabel.AutoSize = true;
            this.AlamatLabel.Location = new System.Drawing.Point(578, 12);
            this.AlamatLabel.Name = "AlamatLabel";
            this.AlamatLabel.Size = new System.Drawing.Size(47, 13);
            this.AlamatLabel.TabIndex = 19;
            this.AlamatLabel.Text = "Alamat";
            // 
            // NoTelpTextBox
            // 
            this.NoTelpTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NoTelpTextBox.Location = new System.Drawing.Point(631, 33);
            this.NoTelpTextBox.Name = "NoTelpTextBox";
            this.NoTelpTextBox.Size = new System.Drawing.Size(313, 21);
            this.NoTelpTextBox.TabIndex = 9;
            // 
            // AlamatTextBox
            // 
            this.AlamatTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AlamatTextBox.Location = new System.Drawing.Point(631, 9);
            this.AlamatTextBox.Name = "AlamatTextBox";
            this.AlamatTextBox.Size = new System.Drawing.Size(313, 21);
            this.AlamatTextBox.TabIndex = 8;
            // 
            // CustomerLabel
            // 
            this.CustomerLabel.AutoSize = true;
            this.CustomerLabel.Location = new System.Drawing.Point(61, 60);
            this.CustomerLabel.Name = "CustomerLabel";
            this.CustomerLabel.Size = new System.Drawing.Size(81, 13);
            this.CustomerLabel.TabIndex = 15;
            this.CustomerLabel.Text = "Customer ID";
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
            this.BuyerNameTextBox.Location = new System.Drawing.Point(148, 81);
            this.BuyerNameTextBox.Name = "BuyerNameTextBox";
            this.BuyerNameTextBox.Size = new System.Drawing.Size(313, 21);
            this.BuyerNameTextBox.TabIndex = 7;
            // 
            // OrderJualIDTextBox
            // 
            this.OrderJualIDTextBox.BackColor = System.Drawing.Color.Beige;
            this.OrderJualIDTextBox.Location = new System.Drawing.Point(148, 9);
            this.OrderJualIDTextBox.Name = "OrderJualIDTextBox";
            this.OrderJualIDTextBox.Size = new System.Drawing.Size(114, 21);
            this.OrderJualIDTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "No. Order Jual";
            // 
            // TglOrderTextBox
            // 
            this.TglOrderTextBox.CustomFormat = "dd-MMM-yyyy";
            this.TglOrderTextBox.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.TglOrderTextBox.Location = new System.Drawing.Point(148, 33);
            this.TglOrderTextBox.Name = "TglOrderTextBox";
            this.TglOrderTextBox.Size = new System.Drawing.Size(114, 21);
            this.TglOrderTextBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(91, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Tanggal";
            // 
            // JamOrderTextBox
            // 
            this.JamOrderTextBox.Location = new System.Drawing.Point(265, 33);
            this.JamOrderTextBox.Mask = "99:99:99";
            this.JamOrderTextBox.Name = "JamOrderTextBox";
            this.JamOrderTextBox.Size = new System.Drawing.Size(73, 21);
            this.JamOrderTextBox.TabIndex = 3;
            // 
            // NewButton
            // 
            this.NewButton.Location = new System.Drawing.Point(264, 8);
            this.NewButton.Name = "NewButton";
            this.NewButton.Size = new System.Drawing.Size(59, 23);
            this.NewButton.TabIndex = 1;
            this.NewButton.Text = "New";
            this.NewButton.UseVisualStyleBackColor = true;
            this.NewButton.Click += new System.EventHandler(this.NewButton_Click);
            // 
            // BuyerNameLabel
            // 
            this.BuyerNameLabel.AutoSize = true;
            this.BuyerNameLabel.Location = new System.Drawing.Point(53, 84);
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
            this.BrgGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BrgGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BrgGridButtonCol,
            this.BPStokID,
            this.SearchStokIDButton});
            this.BrgGrid.Location = new System.Drawing.Point(6, 124);
            this.BrgGrid.Name = "BrgGrid";
            this.BrgGrid.Size = new System.Drawing.Size(959, 230);
            this.BrgGrid.TabIndex = 11;
            // 
            // BrgGridButtonCol
            // 
            this.BrgGridButtonCol.HeaderText = "...";
            this.BrgGridButtonCol.Name = "BrgGridButtonCol";
            this.BrgGridButtonCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.BrgGridButtonCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.BrgGridButtonCol.Width = 25;
            // 
            // BPStokID
            // 
            this.BPStokID.DataPropertyName = "BPStokID";
            this.BPStokID.HeaderText = "Stok ID";
            this.BPStokID.Name = "BPStokID";
            this.BPStokID.Visible = false;
            this.BPStokID.Width = 110;
            // 
            // SearchStokIDButton
            // 
            this.SearchStokIDButton.HeaderText = "...";
            this.SearchStokIDButton.Name = "SearchStokIDButton";
            this.SearchStokIDButton.ReadOnly = true;
            this.SearchStokIDButton.Visible = false;
            this.SearchStokIDButton.Width = 25;
            // 
            // ExitButton
            // 
            this.ExitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ExitButton.Location = new System.Drawing.Point(864, 426);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(87, 23);
            this.ExitButton.TabIndex = 18;
            this.ExitButton.Text = "E&xit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteButton.Location = new System.Drawing.Point(771, 426);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(87, 23);
            this.deleteButton.TabIndex = 17;
            this.deleteButton.Text = "&Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Location = new System.Drawing.Point(678, 426);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(87, 23);
            this.saveButton.TabIndex = 16;
            this.saveButton.Text = "&Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
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
            this.listDataTabPage.Size = new System.Drawing.Size(971, 455);
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
            // OrderJualForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 481);
            this.Controls.Add(this.mainTabControl);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "OrderJualForm";
            this.Text = "Order Jual";
            this.mainTabControl.ResumeLayout(false);
            this.entryDataTabPage.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrandTotalNumText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BiayaLainNumText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DiskonNumText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalNumText)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BrgGrid)).EndInit();
            this.listDataTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage entryDataTabPage;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.NumericUpDown GrandTotalNumText;
        private System.Windows.Forms.NumericUpDown BiayaLainNumText;
        private System.Windows.Forms.NumericUpDown DiskonNumText;
        private System.Windows.Forms.NumericUpDown TotalNumText;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox CatatanTextBox;
        private System.Windows.Forms.Label CatatanLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label AlamatLabel;
        private System.Windows.Forms.TextBox NoTelpTextBox;
        private System.Windows.Forms.TextBox AlamatTextBox;
        private System.Windows.Forms.Label CustomerLabel;
        private System.Windows.Forms.Label LastIDLabel;
        private System.Windows.Forms.TextBox BuyerNameTextBox;
        private System.Windows.Forms.TextBox OrderJualIDTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker TglOrderTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox JamOrderTextBox;
        private System.Windows.Forms.Button NewButton;
        private System.Windows.Forms.Label BuyerNameLabel;
        private System.Windows.Forms.DataGridView BrgGrid;
        private System.Windows.Forms.DataGridViewButtonColumn BrgGridButtonCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn BPStokID;
        private System.Windows.Forms.DataGridViewButtonColumn SearchStokIDButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TabPage listDataTabPage;
        private System.Windows.Forms.Button showListButton;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DataGridView listDataGrid;
        private System.Windows.Forms.Button SearchCustomerButton;
        private System.Windows.Forms.TextBox CustomerIDTextBox;
        private System.Windows.Forms.TextBox CustomerNameTextBox;
    }
}