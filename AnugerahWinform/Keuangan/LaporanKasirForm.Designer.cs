namespace AnugerahWinform.Keuangan
{
    partial class LaporanKasirForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.DataKasirBinding = new System.Windows.Forms.BindingSource(this.components);
            this.LaporangKasirDataSet = new System.Data.DataSet();
            this.LaporanKasirTable = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataColumn6 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.ProsesButton = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.dataColumn5 = new System.Data.DataColumn();
            this.tanggalColDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jamColDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noTransaksiColDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.keteranganColDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamaCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NilaiKasCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataKasirBinding)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LaporangKasirDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LaporanKasirTable)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSalmon;
            this.panel1.Controls.Add(this.ProsesButton);
            this.panel1.Controls.Add(this.dateTimePicker2);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(983, 52);
            this.panel1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tanggalColDataGridViewTextBoxColumn,
            this.jamColDataGridViewTextBoxColumn,
            this.noTransaksiColDataGridViewTextBoxColumn,
            this.keteranganColDataGridViewTextBoxColumn,
            this.NamaCol,
            this.NilaiKasCol});
            this.dataGridView1.DataSource = this.DataKasirBinding;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 52);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(983, 465);
            this.dataGridView1.TabIndex = 1;
            // 
            // DataKasirBinding
            // 
            this.DataKasirBinding.DataMember = "LaporanKasirTable";
            this.DataKasirBinding.DataSource = this.LaporangKasirDataSet;
            // 
            // LaporangKasirDataSet
            // 
            this.LaporangKasirDataSet.DataSetName = "NewDataSet";
            this.LaporangKasirDataSet.Tables.AddRange(new System.Data.DataTable[] {
            this.LaporanKasirTable});
            // 
            // LaporanKasirTable
            // 
            this.LaporanKasirTable.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3,
            this.dataColumn6,
            this.dataColumn4,
            this.dataColumn5});
            this.LaporanKasirTable.TableName = "LaporanKasirTable";
            // 
            // dataColumn1
            // 
            this.dataColumn1.Caption = "Tanggal";
            this.dataColumn1.ColumnName = "TanggalCol";
            // 
            // dataColumn2
            // 
            this.dataColumn2.Caption = "Jam";
            this.dataColumn2.ColumnName = "JamCol";
            // 
            // dataColumn3
            // 
            this.dataColumn3.Caption = "No Transaksi";
            this.dataColumn3.ColumnName = "NoTransaksiCol";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSalmon;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.numericUpDown1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 471);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(983, 46);
            this.panel2.TabIndex = 2;
            // 
            // dataColumn6
            // 
            this.dataColumn6.Caption = "Keterangan";
            this.dataColumn6.ColumnName = "KeteranganCol";
            // 
            // dataColumn4
            // 
            this.dataColumn4.Caption = "Nama";
            this.dataColumn4.ColumnName = "NamaCol";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(12, 12);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(155, 21);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(173, 12);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(155, 21);
            this.dateTimePicker2.TabIndex = 1;
            // 
            // ProsesButton
            // 
            this.ProsesButton.Location = new System.Drawing.Point(334, 11);
            this.ProsesButton.Name = "ProsesButton";
            this.ProsesButton.Size = new System.Drawing.Size(75, 23);
            this.ProsesButton.TabIndex = 2;
            this.ProsesButton.Text = "Proses";
            this.ProsesButton.UseVisualStyleBackColor = true;
            this.ProsesButton.Click += new System.EventHandler(this.ProsesButton_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDown1.Enabled = false;
            this.numericUpDown1.Location = new System.Drawing.Point(792, 13);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(179, 21);
            this.numericUpDown1.TabIndex = 0;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown1.ThousandsSeparator = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(745, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Saldo";
            // 
            // dataColumn5
            // 
            this.dataColumn5.Caption = "Nilai Kas";
            this.dataColumn5.ColumnName = "NilaiKasCol";
            // 
            // tanggalColDataGridViewTextBoxColumn
            // 
            this.tanggalColDataGridViewTextBoxColumn.DataPropertyName = "TanggalCol";
            this.tanggalColDataGridViewTextBoxColumn.HeaderText = "Tanggal";
            this.tanggalColDataGridViewTextBoxColumn.Name = "tanggalColDataGridViewTextBoxColumn";
            // 
            // jamColDataGridViewTextBoxColumn
            // 
            this.jamColDataGridViewTextBoxColumn.DataPropertyName = "JamCol";
            this.jamColDataGridViewTextBoxColumn.HeaderText = "Jam";
            this.jamColDataGridViewTextBoxColumn.Name = "jamColDataGridViewTextBoxColumn";
            // 
            // noTransaksiColDataGridViewTextBoxColumn
            // 
            this.noTransaksiColDataGridViewTextBoxColumn.DataPropertyName = "NoTransaksiCol";
            this.noTransaksiColDataGridViewTextBoxColumn.HeaderText = "No.Transaksi";
            this.noTransaksiColDataGridViewTextBoxColumn.Name = "noTransaksiColDataGridViewTextBoxColumn";
            // 
            // keteranganColDataGridViewTextBoxColumn
            // 
            this.keteranganColDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.keteranganColDataGridViewTextBoxColumn.DataPropertyName = "KeteranganCol";
            this.keteranganColDataGridViewTextBoxColumn.HeaderText = "Keterangan";
            this.keteranganColDataGridViewTextBoxColumn.Name = "keteranganColDataGridViewTextBoxColumn";
            // 
            // NamaCol
            // 
            this.NamaCol.DataPropertyName = "NamaCol";
            this.NamaCol.HeaderText = "Nama";
            this.NamaCol.Name = "NamaCol";
            this.NamaCol.Width = 200;
            // 
            // NilaiKasCol
            // 
            this.NilaiKasCol.DataPropertyName = "NilaiKasCol";
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = "0";
            this.NilaiKasCol.DefaultCellStyle = dataGridViewCellStyle2;
            this.NilaiKasCol.HeaderText = "Nilai Kas";
            this.NilaiKasCol.Name = "NilaiKasCol";
            this.NilaiKasCol.ReadOnly = true;
            // 
            // LaporanKasirForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 517);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "LaporanKasirForm";
            this.Text = "LaporanKasirForm";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataKasirBinding)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LaporangKasirDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LaporanKasirTable)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource DataKasirBinding;
        private System.Data.DataSet LaporangKasirDataSet;
        private System.Data.DataTable LaporanKasirTable;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Windows.Forms.Panel panel2;
        private System.Data.DataColumn dataColumn6;
        private System.Data.DataColumn dataColumn4;
        private System.Windows.Forms.Button ProsesButton;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
        private System.Data.DataColumn dataColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn tanggalColDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn jamColDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn noTransaksiColDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn keteranganColDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamaCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn NilaiKasCol;
    }
}