namespace AnugerahWinform.StokBarang
{
    partial class ProduksiForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.KeteranganTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TanggalDateTime = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.JamTextBox = new System.Windows.Forms.MaskedTextBox();
            this.NewButton = new System.Windows.Forms.Button();
            this.SearchProduksiButton = new System.Windows.Forms.Button();
            this.ProduksiIDTextBox = new System.Windows.Forms.TextBox();
            this.ProduksiLabel = new System.Windows.Forms.Label();
            this.MaterialGridView = new System.Windows.Forms.DataGridView();
            this.brgIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Search = new System.Windows.Forms.DataGridViewButtonColumn();
            this.brgNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hPPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaterialBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ProduksiDataSet = new System.Data.DataSet();
            this.MaterialTable = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.HasilTable = new System.Data.DataTable();
            this.dataColumn5 = new System.Data.DataColumn();
            this.dataColumn6 = new System.Data.DataColumn();
            this.dataColumn7 = new System.Data.DataColumn();
            this.dataColumn8 = new System.Data.DataColumn();
            this.HasilGridView = new System.Windows.Forms.DataGridView();
            this.brgIDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SearchBrgHasilButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.brgNameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtyDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hppDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HasilBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaterialGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaterialBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProduksiDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaterialTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HasilTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HasilGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HasilBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.LemonChiffon;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.KeteranganTextBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.TanggalDateTime);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.JamTextBox);
            this.panel1.Controls.Add(this.NewButton);
            this.panel1.Controls.Add(this.SearchProduksiButton);
            this.panel1.Controls.Add(this.ProduksiIDTextBox);
            this.panel1.Controls.Add(this.ProduksiLabel);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(458, 100);
            this.panel1.TabIndex = 0;
            // 
            // KeteranganTextBox
            // 
            this.KeteranganTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.KeteranganTextBox.Location = new System.Drawing.Point(205, 23);
            this.KeteranganTextBox.Multiline = true;
            this.KeteranganTextBox.Name = "KeteranganTextBox";
            this.KeteranganTextBox.Size = new System.Drawing.Size(241, 62);
            this.KeteranganTextBox.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(202, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Keterangan";
            // 
            // TanggalDateTime
            // 
            this.TanggalDateTime.CustomFormat = "dd-MMM-yyyy";
            this.TanggalDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.TanggalDateTime.Location = new System.Drawing.Point(11, 64);
            this.TanggalDateTime.Name = "TanggalDateTime";
            this.TanggalDateTime.Size = new System.Drawing.Size(114, 21);
            this.TanggalDateTime.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Tanggal";
            // 
            // JamTextBox
            // 
            this.JamTextBox.Location = new System.Drawing.Point(127, 64);
            this.JamTextBox.Mask = "99:99:99";
            this.JamTextBox.Name = "JamTextBox";
            this.JamTextBox.Size = new System.Drawing.Size(72, 21);
            this.JamTextBox.TabIndex = 15;
            // 
            // NewButton
            // 
            this.NewButton.Location = new System.Drawing.Point(139, 23);
            this.NewButton.Name = "NewButton";
            this.NewButton.Size = new System.Drawing.Size(60, 23);
            this.NewButton.TabIndex = 13;
            this.NewButton.Text = "New";
            this.NewButton.UseVisualStyleBackColor = true;
            // 
            // SearchProduksiButton
            // 
            this.SearchProduksiButton.Location = new System.Drawing.Point(112, 23);
            this.SearchProduksiButton.Name = "SearchProduksiButton";
            this.SearchProduksiButton.Size = new System.Drawing.Size(27, 23);
            this.SearchProduksiButton.TabIndex = 12;
            this.SearchProduksiButton.Text = "...";
            this.SearchProduksiButton.UseVisualStyleBackColor = true;
            // 
            // ProduksiIDTextBox
            // 
            this.ProduksiIDTextBox.Location = new System.Drawing.Point(11, 24);
            this.ProduksiIDTextBox.Name = "ProduksiIDTextBox";
            this.ProduksiIDTextBox.Size = new System.Drawing.Size(100, 21);
            this.ProduksiIDTextBox.TabIndex = 11;
            // 
            // ProduksiLabel
            // 
            this.ProduksiLabel.AutoSize = true;
            this.ProduksiLabel.Location = new System.Drawing.Point(8, 8);
            this.ProduksiLabel.Name = "ProduksiLabel";
            this.ProduksiLabel.Size = new System.Drawing.Size(74, 13);
            this.ProduksiLabel.TabIndex = 0;
            this.ProduksiLabel.Text = "Produksi ID";
            // 
            // MaterialGridView
            // 
            this.MaterialGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MaterialGridView.AutoGenerateColumns = false;
            this.MaterialGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MaterialGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.brgIDDataGridViewTextBoxColumn,
            this.Search,
            this.brgNameDataGridViewTextBoxColumn,
            this.qtyDataGridViewTextBoxColumn,
            this.hPPDataGridViewTextBoxColumn});
            this.MaterialGridView.DataSource = this.MaterialBindingSource;
            this.MaterialGridView.Location = new System.Drawing.Point(12, 131);
            this.MaterialGridView.Name = "MaterialGridView";
            this.MaterialGridView.Size = new System.Drawing.Size(458, 130);
            this.MaterialGridView.TabIndex = 1;
            this.MaterialGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MaterialGridView_CellContentClick);
            // 
            // brgIDDataGridViewTextBoxColumn
            // 
            this.brgIDDataGridViewTextBoxColumn.DataPropertyName = "BrgID";
            this.brgIDDataGridViewTextBoxColumn.HeaderText = "BrgID";
            this.brgIDDataGridViewTextBoxColumn.Name = "brgIDDataGridViewTextBoxColumn";
            this.brgIDDataGridViewTextBoxColumn.Width = 60;
            // 
            // Search
            // 
            this.Search.HeaderText = "...";
            this.Search.Name = "Search";
            this.Search.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Search.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Search.Width = 27;
            // 
            // brgNameDataGridViewTextBoxColumn
            // 
            this.brgNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.brgNameDataGridViewTextBoxColumn.DataPropertyName = "BrgName";
            this.brgNameDataGridViewTextBoxColumn.HeaderText = "BrgName";
            this.brgNameDataGridViewTextBoxColumn.Name = "brgNameDataGridViewTextBoxColumn";
            // 
            // qtyDataGridViewTextBoxColumn
            // 
            this.qtyDataGridViewTextBoxColumn.DataPropertyName = "Qty";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            this.qtyDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.qtyDataGridViewTextBoxColumn.HeaderText = "Qty";
            this.qtyDataGridViewTextBoxColumn.Name = "qtyDataGridViewTextBoxColumn";
            this.qtyDataGridViewTextBoxColumn.Width = 60;
            // 
            // hPPDataGridViewTextBoxColumn
            // 
            this.hPPDataGridViewTextBoxColumn.DataPropertyName = "HPP";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "NO";
            this.hPPDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.hPPDataGridViewTextBoxColumn.HeaderText = "HPP";
            this.hPPDataGridViewTextBoxColumn.Name = "hPPDataGridViewTextBoxColumn";
            // 
            // MaterialBindingSource
            // 
            this.MaterialBindingSource.DataMember = "MaterialTable";
            this.MaterialBindingSource.DataSource = this.ProduksiDataSet;
            // 
            // ProduksiDataSet
            // 
            this.ProduksiDataSet.DataSetName = "NewDataSet";
            this.ProduksiDataSet.Tables.AddRange(new System.Data.DataTable[] {
            this.MaterialTable,
            this.HasilTable});
            // 
            // MaterialTable
            // 
            this.MaterialTable.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3,
            this.dataColumn4});
            this.MaterialTable.TableName = "MaterialTable";
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
            this.dataColumn3.DataType = typeof(long);
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "HPP";
            this.dataColumn4.DataType = typeof(decimal);
            // 
            // HasilTable
            // 
            this.HasilTable.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn5,
            this.dataColumn6,
            this.dataColumn7,
            this.dataColumn8});
            this.HasilTable.TableName = "HasilTable";
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "BrgID";
            // 
            // dataColumn6
            // 
            this.dataColumn6.ColumnName = "BrgName";
            // 
            // dataColumn7
            // 
            this.dataColumn7.ColumnName = "Qty";
            this.dataColumn7.DataType = typeof(long);
            // 
            // dataColumn8
            // 
            this.dataColumn8.ColumnName = "Hpp";
            this.dataColumn8.DataType = typeof(decimal);
            // 
            // HasilGridView
            // 
            this.HasilGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HasilGridView.AutoGenerateColumns = false;
            this.HasilGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.HasilGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.brgIDDataGridViewTextBoxColumn1,
            this.SearchBrgHasilButton,
            this.brgNameDataGridViewTextBoxColumn1,
            this.qtyDataGridViewTextBoxColumn1,
            this.hppDataGridViewTextBoxColumn1});
            this.HasilGridView.DataSource = this.HasilBindingSource;
            this.HasilGridView.Location = new System.Drawing.Point(12, 280);
            this.HasilGridView.Name = "HasilGridView";
            this.HasilGridView.Size = new System.Drawing.Size(458, 130);
            this.HasilGridView.TabIndex = 2;
            // 
            // brgIDDataGridViewTextBoxColumn1
            // 
            this.brgIDDataGridViewTextBoxColumn1.DataPropertyName = "BrgID";
            this.brgIDDataGridViewTextBoxColumn1.HeaderText = "BrgID";
            this.brgIDDataGridViewTextBoxColumn1.Name = "brgIDDataGridViewTextBoxColumn1";
            this.brgIDDataGridViewTextBoxColumn1.Width = 60;
            // 
            // SearchBrgHasilButton
            // 
            this.SearchBrgHasilButton.HeaderText = "...";
            this.SearchBrgHasilButton.Name = "SearchBrgHasilButton";
            this.SearchBrgHasilButton.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SearchBrgHasilButton.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.SearchBrgHasilButton.Width = 27;
            // 
            // brgNameDataGridViewTextBoxColumn1
            // 
            this.brgNameDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.brgNameDataGridViewTextBoxColumn1.DataPropertyName = "BrgName";
            this.brgNameDataGridViewTextBoxColumn1.HeaderText = "BrgName";
            this.brgNameDataGridViewTextBoxColumn1.Name = "brgNameDataGridViewTextBoxColumn1";
            // 
            // qtyDataGridViewTextBoxColumn1
            // 
            this.qtyDataGridViewTextBoxColumn1.DataPropertyName = "Qty";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N0";
            this.qtyDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle7;
            this.qtyDataGridViewTextBoxColumn1.HeaderText = "Qty";
            this.qtyDataGridViewTextBoxColumn1.Name = "qtyDataGridViewTextBoxColumn1";
            this.qtyDataGridViewTextBoxColumn1.Width = 60;
            // 
            // hppDataGridViewTextBoxColumn1
            // 
            this.hppDataGridViewTextBoxColumn1.DataPropertyName = "Hpp";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N0";
            this.hppDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle8;
            this.hppDataGridViewTextBoxColumn1.HeaderText = "Hpp";
            this.hppDataGridViewTextBoxColumn1.Name = "hppDataGridViewTextBoxColumn1";
            // 
            // HasilBindingSource
            // 
            this.HasilBindingSource.DataMember = "HasilTable";
            this.HasilBindingSource.DataSource = this.ProduksiDataSet;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Material";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 264);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Hasil";
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.Location = new System.Drawing.Point(233, 416);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 5;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            // 
            // DeleteButton
            // 
            this.DeleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteButton.Location = new System.Drawing.Point(314, 416);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteButton.TabIndex = 6;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            // 
            // ExitButton
            // 
            this.ExitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ExitButton.Location = new System.Drawing.Point(395, 416);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(75, 23);
            this.ExitButton.TabIndex = 7;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            // 
            // ProduksiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Khaki;
            this.ClientSize = new System.Drawing.Size(484, 450);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.HasilGridView);
            this.Controls.Add(this.MaterialGridView);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ProduksiForm";
            this.Text = "ProduksiForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaterialGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaterialBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProduksiDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaterialTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HasilTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HasilGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HasilBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView MaterialGridView;
        private System.Windows.Forms.Label ProduksiLabel;
        private System.Windows.Forms.DataGridView HasilGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker TanggalDateTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox JamTextBox;
        private System.Windows.Forms.Button NewButton;
        private System.Windows.Forms.Button SearchProduksiButton;
        private System.Windows.Forms.TextBox ProduksiIDTextBox;
        private System.Windows.Forms.TextBox KeteranganTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Data.DataSet ProduksiDataSet;
        private System.Windows.Forms.BindingSource MaterialBindingSource;
        private System.Windows.Forms.BindingSource HasilBindingSource;
        private System.Data.DataTable MaterialTable;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataTable HasilTable;
        private System.Data.DataColumn dataColumn5;
        private System.Data.DataColumn dataColumn6;
        private System.Data.DataColumn dataColumn7;
        private System.Data.DataColumn dataColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn brgIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn Search;
        private System.Windows.Forms.DataGridViewTextBoxColumn brgNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hPPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn brgIDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewButtonColumn SearchBrgHasilButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn brgNameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn hppDataGridViewTextBoxColumn1;
    }
}