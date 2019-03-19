namespace AnugerahWinform.Pembelian
{
    partial class PurchaseReceiptInfo
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
            this.PurchaseReceiptBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PurchaseReceiptDataSet = new System.Data.DataSet();
            this.PurchaseReceiptTable = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataColumn5 = new System.Data.DataColumn();
            this.dataColumn6 = new System.Data.DataColumn();
            this.dataColumn7 = new System.Data.DataColumn();
            this.dataColumn8 = new System.Data.DataColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SearchButton = new System.Windows.Forms.Button();
            this.SearchKeywordText = new System.Windows.Forms.TextBox();
            this.ProsesButton = new System.Windows.Forms.Button();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.PurchaseID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trsIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tglDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplierDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.keteranganDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtyPurchaseDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtyReceiptDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtySisaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.closedPODataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OutstandingCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.PurchaseReceiptBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PurchaseReceiptDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PurchaseReceiptTable)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // PurchaseReceiptBindingSource
            // 
            this.PurchaseReceiptBindingSource.AllowNew = false;
            this.PurchaseReceiptBindingSource.DataMember = "PurchaseReceiptTable";
            this.PurchaseReceiptBindingSource.DataSource = this.PurchaseReceiptDataSet;
            // 
            // PurchaseReceiptDataSet
            // 
            this.PurchaseReceiptDataSet.DataSetName = "NewDataSet";
            this.PurchaseReceiptDataSet.Tables.AddRange(new System.Data.DataTable[] {
            this.PurchaseReceiptTable});
            // 
            // PurchaseReceiptTable
            // 
            this.PurchaseReceiptTable.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3,
            this.dataColumn4,
            this.dataColumn5,
            this.dataColumn6,
            this.dataColumn7,
            this.dataColumn8});
            this.PurchaseReceiptTable.TableName = "PurchaseReceiptTable";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "TrsID";
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "Tgl";
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "Supplier";
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "Keterangan";
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "QtyPurchase";
            this.dataColumn5.DataType = typeof(decimal);
            // 
            // dataColumn6
            // 
            this.dataColumn6.ColumnName = "QtyReceipt";
            this.dataColumn6.DataType = typeof(decimal);
            // 
            // dataColumn7
            // 
            this.dataColumn7.ColumnName = "QtySisa";
            this.dataColumn7.DataType = typeof(decimal);
            // 
            // dataColumn8
            // 
            this.dataColumn8.ColumnName = "ClosedPO";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Khaki;
            this.panel1.Controls.Add(this.OutstandingCheckBox);
            this.panel1.Controls.Add(this.SearchButton);
            this.panel1.Controls.Add(this.SearchKeywordText);
            this.panel1.Controls.Add(this.ProsesButton);
            this.panel1.Controls.Add(this.dateTimePicker2);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(933, 52);
            this.panel1.TabIndex = 22;
            // 
            // SearchButton
            // 
            this.SearchButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.SearchButton.Location = new System.Drawing.Point(838, 15);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(87, 23);
            this.SearchButton.TabIndex = 4;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            // 
            // SearchKeywordText
            // 
            this.SearchKeywordText.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.SearchKeywordText.Location = new System.Drawing.Point(631, 17);
            this.SearchKeywordText.Name = "SearchKeywordText";
            this.SearchKeywordText.Size = new System.Drawing.Size(199, 21);
            this.SearchKeywordText.TabIndex = 3;
            // 
            // ProsesButton
            // 
            this.ProsesButton.Location = new System.Drawing.Point(294, 11);
            this.ProsesButton.Name = "ProsesButton";
            this.ProsesButton.Size = new System.Drawing.Size(87, 23);
            this.ProsesButton.TabIndex = 2;
            this.ProsesButton.Text = "Proses";
            this.ProsesButton.UseVisualStyleBackColor = true;
            this.ProsesButton.Click += new System.EventHandler(this.ProsesButton_Click);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "dd-MMM-yyyy";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(154, 12);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(134, 21);
            this.dateTimePicker2.TabIndex = 1;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd-MMM-yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(14, 12);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(134, 21);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Transparent;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PurchaseID,
            this.trsIDDataGridViewTextBoxColumn,
            this.tglDataGridViewTextBoxColumn,
            this.supplierDataGridViewTextBoxColumn,
            this.keteranganDataGridViewTextBoxColumn,
            this.qtyPurchaseDataGridViewTextBoxColumn,
            this.qtyReceiptDataGridViewTextBoxColumn,
            this.qtySisaDataGridViewTextBoxColumn,
            this.closedPODataGridViewCheckBoxColumn});
            this.dataGridView1.DataSource = this.PurchaseReceiptBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 52);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(933, 429);
            this.dataGridView1.TabIndex = 23;
            // 
            // PurchaseID
            // 
            this.PurchaseID.DataPropertyName = "PurchaseID";
            this.PurchaseID.HeaderText = "PurchaseID";
            this.PurchaseID.Name = "PurchaseID";
            this.PurchaseID.ReadOnly = true;
            this.PurchaseID.Visible = false;
            // 
            // trsIDDataGridViewTextBoxColumn
            // 
            this.trsIDDataGridViewTextBoxColumn.DataPropertyName = "TrsID";
            this.trsIDDataGridViewTextBoxColumn.HeaderText = "TrsID";
            this.trsIDDataGridViewTextBoxColumn.Name = "trsIDDataGridViewTextBoxColumn";
            this.trsIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.trsIDDataGridViewTextBoxColumn.Width = 80;
            // 
            // tglDataGridViewTextBoxColumn
            // 
            this.tglDataGridViewTextBoxColumn.DataPropertyName = "Tgl";
            this.tglDataGridViewTextBoxColumn.HeaderText = "Tgl";
            this.tglDataGridViewTextBoxColumn.Name = "tglDataGridViewTextBoxColumn";
            this.tglDataGridViewTextBoxColumn.ReadOnly = true;
            this.tglDataGridViewTextBoxColumn.Width = 80;
            // 
            // supplierDataGridViewTextBoxColumn
            // 
            this.supplierDataGridViewTextBoxColumn.DataPropertyName = "Supplier";
            this.supplierDataGridViewTextBoxColumn.HeaderText = "Supplier";
            this.supplierDataGridViewTextBoxColumn.Name = "supplierDataGridViewTextBoxColumn";
            this.supplierDataGridViewTextBoxColumn.ReadOnly = true;
            this.supplierDataGridViewTextBoxColumn.Width = 150;
            // 
            // keteranganDataGridViewTextBoxColumn
            // 
            this.keteranganDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.keteranganDataGridViewTextBoxColumn.DataPropertyName = "Keterangan";
            this.keteranganDataGridViewTextBoxColumn.HeaderText = "Keterangan";
            this.keteranganDataGridViewTextBoxColumn.Name = "keteranganDataGridViewTextBoxColumn";
            this.keteranganDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // qtyPurchaseDataGridViewTextBoxColumn
            // 
            this.qtyPurchaseDataGridViewTextBoxColumn.DataPropertyName = "QtyPurchase";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.qtyPurchaseDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.qtyPurchaseDataGridViewTextBoxColumn.HeaderText = "Purchase";
            this.qtyPurchaseDataGridViewTextBoxColumn.Name = "qtyPurchaseDataGridViewTextBoxColumn";
            this.qtyPurchaseDataGridViewTextBoxColumn.ReadOnly = true;
            this.qtyPurchaseDataGridViewTextBoxColumn.Width = 80;
            // 
            // qtyReceiptDataGridViewTextBoxColumn
            // 
            this.qtyReceiptDataGridViewTextBoxColumn.DataPropertyName = "QtyReceipt";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N0";
            this.qtyReceiptDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.qtyReceiptDataGridViewTextBoxColumn.HeaderText = "Receipt";
            this.qtyReceiptDataGridViewTextBoxColumn.Name = "qtyReceiptDataGridViewTextBoxColumn";
            this.qtyReceiptDataGridViewTextBoxColumn.ReadOnly = true;
            this.qtyReceiptDataGridViewTextBoxColumn.Width = 80;
            // 
            // qtySisaDataGridViewTextBoxColumn
            // 
            this.qtySisaDataGridViewTextBoxColumn.DataPropertyName = "QtySisa";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N0";
            this.qtySisaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.qtySisaDataGridViewTextBoxColumn.HeaderText = "Sisa";
            this.qtySisaDataGridViewTextBoxColumn.Name = "qtySisaDataGridViewTextBoxColumn";
            this.qtySisaDataGridViewTextBoxColumn.ReadOnly = true;
            this.qtySisaDataGridViewTextBoxColumn.Width = 80;
            // 
            // closedPODataGridViewCheckBoxColumn
            // 
            this.closedPODataGridViewCheckBoxColumn.DataPropertyName = "ClosedPO";
            this.closedPODataGridViewCheckBoxColumn.HeaderText = "Closed";
            this.closedPODataGridViewCheckBoxColumn.Name = "closedPODataGridViewCheckBoxColumn";
            this.closedPODataGridViewCheckBoxColumn.ReadOnly = true;
            this.closedPODataGridViewCheckBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.closedPODataGridViewCheckBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.closedPODataGridViewCheckBoxColumn.Width = 80;
            // 
            // OutstandingCheckBox
            // 
            this.OutstandingCheckBox.AutoSize = true;
            this.OutstandingCheckBox.Location = new System.Drawing.Point(387, 15);
            this.OutstandingCheckBox.Name = "OutstandingCheckBox";
            this.OutstandingCheckBox.Size = new System.Drawing.Size(126, 17);
            this.OutstandingCheckBox.TabIndex = 5;
            this.OutstandingCheckBox.Text = "OutStanding Only";
            this.OutstandingCheckBox.UseVisualStyleBackColor = true;
            // 
            // PurchaseReceiptInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 481);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "PurchaseReceiptInfo";
            this.Text = "PurchaseReceiptInfo";
            ((System.ComponentModel.ISupportInitialize)(this.PurchaseReceiptBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PurchaseReceiptDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PurchaseReceiptTable)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.TextBox SearchKeywordText;
        private System.Windows.Forms.Button ProsesButton;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Data.DataSet PurchaseReceiptDataSet;
        private System.Data.DataTable PurchaseReceiptTable;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataColumn dataColumn5;
        private System.Data.DataColumn dataColumn6;
        private System.Data.DataColumn dataColumn7;
        private System.Data.DataColumn dataColumn8;
        private System.Windows.Forms.BindingSource PurchaseReceiptBindingSource;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn PurchaseID;
        private System.Windows.Forms.DataGridViewTextBoxColumn trsIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tglDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplierDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn keteranganDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyPurchaseDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyReceiptDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtySisaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn closedPODataGridViewCheckBoxColumn;
        private System.Windows.Forms.CheckBox OutstandingCheckBox;
    }
}