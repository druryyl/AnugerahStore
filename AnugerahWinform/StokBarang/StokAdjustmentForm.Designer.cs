namespace AnugerahWinform.StokBarang
{
    partial class StokAdjustmentForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tglTransaksiDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.newButton = new System.Windows.Forms.Button();
            this.catatanButton = new System.Windows.Forms.Label();
            this.detilBrgGrid = new System.Windows.Forms.DataGridView();
            this.kodeBrgColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.namaBrgColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtyAwal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtyAdjust = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtyAkhir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diskonColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exitButton = new System.Windows.Forms.Button();
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
            this.mainTabControl.Size = new System.Drawing.Size(963, 540);
            this.mainTabControl.TabIndex = 5;
            // 
            // entryDataTabPage
            // 
            this.entryDataTabPage.BackColor = System.Drawing.Color.MistyRose;
            this.entryDataTabPage.Controls.Add(this.panel1);
            this.entryDataTabPage.Controls.Add(this.detilBrgGrid);
            this.entryDataTabPage.Controls.Add(this.exitButton);
            this.entryDataTabPage.Controls.Add(this.deleteButton);
            this.entryDataTabPage.Controls.Add(this.saveButton);
            this.entryDataTabPage.Location = new System.Drawing.Point(4, 22);
            this.entryDataTabPage.Name = "entryDataTabPage";
            this.entryDataTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.entryDataTabPage.Size = new System.Drawing.Size(955, 514);
            this.entryDataTabPage.TabIndex = 0;
            this.entryDataTabPage.Text = "Entry Data";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.textBox7);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tglTransaksiDateTimePicker);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.maskedTextBox1);
            this.panel1.Controls.Add(this.newButton);
            this.panel1.Controls.Add(this.catatanButton);
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(943, 105);
            this.panel1.TabIndex = 13;
            // 
            // textBox7
            // 
            this.textBox7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox7.Location = new System.Drawing.Point(615, 15);
            this.textBox7.Multiline = true;
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(313, 74);
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
            this.label1.Location = new System.Drawing.Point(47, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "No. Adjustment";
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
            // 
            // catatanButton
            // 
            this.catatanButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.catatanButton.AutoSize = true;
            this.catatanButton.Location = new System.Drawing.Point(536, 18);
            this.catatanButton.Name = "catatanButton";
            this.catatanButton.Size = new System.Drawing.Size(73, 13);
            this.catatanButton.TabIndex = 11;
            this.catatanButton.Text = "Keterangan";
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
            this.QtyAwal,
            this.QtyAdjust,
            this.QtyAkhir,
            this.diskonColumn});
            this.detilBrgGrid.Location = new System.Drawing.Point(6, 117);
            this.detilBrgGrid.Name = "detilBrgGrid";
            this.detilBrgGrid.Size = new System.Drawing.Size(941, 362);
            this.detilBrgGrid.TabIndex = 10;
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
            // QtyAwal
            // 
            this.QtyAwal.HeaderText = "Qty Awal";
            this.QtyAwal.Name = "QtyAwal";
            // 
            // QtyAdjust
            // 
            this.QtyAdjust.HeaderText = "Qty Adjust";
            this.QtyAdjust.Name = "QtyAdjust";
            // 
            // QtyAkhir
            // 
            this.QtyAkhir.HeaderText = "Qty Akhir";
            this.QtyAkhir.Name = "QtyAkhir";
            // 
            // diskonColumn
            // 
            this.diskonColumn.HeaderText = "HPP";
            this.diskonColumn.Name = "diskonColumn";
            // 
            // exitButton
            // 
            this.exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.exitButton.Location = new System.Drawing.Point(848, 485);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(87, 23);
            this.exitButton.TabIndex = 8;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteButton.Location = new System.Drawing.Point(755, 485);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(87, 23);
            this.deleteButton.TabIndex = 7;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Location = new System.Drawing.Point(662, 485);
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
            this.listDataTabPage.Size = new System.Drawing.Size(955, 514);
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
            // StokAdjustmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 540);
            this.Controls.Add(this.mainTabControl);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "StokAdjustmentForm";
            this.Text = "StokAdjustmentForm";
            this.mainTabControl.ResumeLayout(false);
            this.entryDataTabPage.ResumeLayout(false);
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker tglTransaksiDateTimePicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.Label catatanButton;
        private System.Windows.Forms.DataGridView detilBrgGrid;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TabPage listDataTabPage;
        private System.Windows.Forms.Button showListButton;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DataGridView listDataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn kodeBrgColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn namaBrgColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtyAwal;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtyAdjust;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtyAkhir;
        private System.Windows.Forms.DataGridViewTextBoxColumn diskonColumn;
    }
}