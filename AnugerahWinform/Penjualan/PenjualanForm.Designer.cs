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
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.entryDataTabPage = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tglTransaksiDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.newButton = new System.Windows.Forms.Button();
            this.catatanButton = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.supplierComboBox = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.detilBrgGrid = new System.Windows.Forms.DataGridView();
            this.exitButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.listDataTabPage = new System.Windows.Forms.TabPage();
            this.showListButton = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.listDataGrid = new System.Windows.Forms.DataGridView();
            this.kodeBrgColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.namaBrgColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Satuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hargaSatuanColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diskonColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subTotalColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.mainTabControl.SuspendLayout();
            this.entryDataTabPage.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.detilBrgGrid)).BeginInit();
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
            this.mainTabControl.Size = new System.Drawing.Size(979, 579);
            this.mainTabControl.TabIndex = 4;
            // 
            // entryDataTabPage
            // 
            this.entryDataTabPage.BackColor = System.Drawing.Color.MistyRose;
            this.entryDataTabPage.Controls.Add(this.panel2);
            this.entryDataTabPage.Controls.Add(this.panel1);
            this.entryDataTabPage.Controls.Add(this.detilBrgGrid);
            this.entryDataTabPage.Controls.Add(this.exitButton);
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
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.textBox8);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.textBox6);
            this.panel2.Controls.Add(this.textBox5);
            this.panel2.Controls.Add(this.textBox4);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(6, 452);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(959, 66);
            this.panel2.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(834, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Grand Total";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(612, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Biaya Lain";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(837, 29);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(107, 21);
            this.textBox6.TabIndex = 5;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(611, 29);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(107, 21);
            this.textBox5.TabIndex = 4;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(498, 29);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(107, 21);
            this.textBox4.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(495, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Total";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.textBox7);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tglTransaksiDateTimePicker);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.maskedTextBox1);
            this.panel1.Controls.Add(this.newButton);
            this.panel1.Controls.Add(this.catatanButton);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.supplierComboBox);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(959, 105);
            this.panel1.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(638, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "No. HP";
            // 
            // textBox7
            // 
            this.textBox7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox7.Location = new System.Drawing.Point(691, 15);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(253, 21);
            this.textBox7.TabIndex = 13;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(148, 15);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(142, 21);
            this.textBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(81, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "No. Sales";
            // 
            // tglTransaksiDateTimePicker
            // 
            this.tglTransaksiDateTimePicker.CustomFormat = "dd-MMM-yyyy";
            this.tglTransaksiDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tglTransaksiDateTimePicker.Location = new System.Drawing.Point(148, 42);
            this.tglTransaksiDateTimePicker.Name = "tglTransaksiDateTimePicker";
            this.tglTransaksiDateTimePicker.Size = new System.Drawing.Size(114, 21);
            this.tglTransaksiDateTimePicker.TabIndex = 1;
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
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(268, 42);
            this.maskedTextBox1.Mask = "HH:mm:ss";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(73, 21);
            this.maskedTextBox1.TabIndex = 8;
            // 
            // newButton
            // 
            this.newButton.Location = new System.Drawing.Point(296, 13);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(59, 23);
            this.newButton.TabIndex = 9;
            this.newButton.Text = "New";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // catatanButton
            // 
            this.catatanButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.catatanButton.AutoSize = true;
            this.catatanButton.Location = new System.Drawing.Point(585, 18);
            this.catatanButton.Name = "catatanButton";
            this.catatanButton.Size = new System.Drawing.Size(100, 13);
            this.catatanButton.TabIndex = 11;
            this.catatanButton.Text = "Customer Name";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(691, 42);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(253, 21);
            this.textBox2.TabIndex = 3;
            // 
            // supplierComboBox
            // 
            this.supplierComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.supplierComboBox.AutoSize = true;
            this.supplierComboBox.Location = new System.Drawing.Point(631, 45);
            this.supplierComboBox.Name = "supplierComboBox";
            this.supplierComboBox.Size = new System.Drawing.Size(47, 13);
            this.supplierComboBox.TabIndex = 10;
            this.supplierComboBox.Text = "Alamat";
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.Location = new System.Drawing.Point(691, 69);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(253, 21);
            this.textBox3.TabIndex = 4;
            // 
            // detilBrgGrid
            // 
            this.detilBrgGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.detilBrgGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.detilBrgGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.kodeBrgColumn,
            this.namaBrgColumn,
            this.Qty,
            this.Satuan,
            this.hargaSatuanColumn,
            this.diskonColumn,
            this.subTotalColumn});
            this.detilBrgGrid.Location = new System.Drawing.Point(6, 117);
            this.detilBrgGrid.Name = "detilBrgGrid";
            this.detilBrgGrid.Size = new System.Drawing.Size(957, 329);
            this.detilBrgGrid.TabIndex = 10;
            // 
            // exitButton
            // 
            this.exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.exitButton.Location = new System.Drawing.Point(864, 524);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(87, 23);
            this.exitButton.TabIndex = 8;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteButton.Location = new System.Drawing.Point(771, 524);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(87, 23);
            this.deleteButton.TabIndex = 7;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Location = new System.Drawing.Point(678, 524);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(87, 23);
            this.saveButton.TabIndex = 6;
            this.saveButton.Text = "Save";
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
            this.listDataGrid.Size = new System.Drawing.Size(961, 514);
            this.listDataGrid.TabIndex = 11;
            // 
            // kodeBrgColumn
            // 
            this.kodeBrgColumn.HeaderText = "Kode";
            this.kodeBrgColumn.Name = "kodeBrgColumn";
            this.kodeBrgColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.kodeBrgColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // namaBrgColumn
            // 
            this.namaBrgColumn.HeaderText = "Nama Barang";
            this.namaBrgColumn.Name = "namaBrgColumn";
            this.namaBrgColumn.ReadOnly = true;
            this.namaBrgColumn.Width = 350;
            // 
            // Qty
            // 
            this.Qty.HeaderText = "Qty";
            this.Qty.Name = "Qty";
            this.Qty.Width = 50;
            // 
            // Satuan
            // 
            this.Satuan.HeaderText = "Satuan";
            this.Satuan.Name = "Satuan";
            // 
            // hargaSatuanColumn
            // 
            this.hargaSatuanColumn.HeaderText = "Harga Sat";
            this.hargaSatuanColumn.Name = "hargaSatuanColumn";
            // 
            // diskonColumn
            // 
            this.diskonColumn.HeaderText = "Diskon";
            this.diskonColumn.Name = "diskonColumn";
            // 
            // subTotalColumn
            // 
            this.subTotalColumn.HeaderText = "Sub Total";
            this.subTotalColumn.Name = "subTotalColumn";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(724, 29);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(107, 21);
            this.textBox8.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(724, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Diskon";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Customer ID";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(148, 69);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(193, 21);
            this.comboBox1.TabIndex = 16;
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
            this.mainTabControl.ResumeLayout(false);
            this.entryDataTabPage.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.detilBrgGrid)).EndInit();
            this.listDataTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage entryDataTabPage;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker tglTransaksiDateTimePicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.Label catatanButton;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label supplierComboBox;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.DataGridView detilBrgGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn kodeBrgColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn namaBrgColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Satuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn hargaSatuanColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn diskonColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn subTotalColumn;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TabPage listDataTabPage;
        private System.Windows.Forms.Button showListButton;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DataGridView listDataGrid;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}