namespace AnugerahWinform.Penjualan
{
    partial class PenjualanBayarForm
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
            this.BayarGrid = new System.Windows.Forms.DataGridView();
            this.PenjualanBayarBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PenjualanBayarDataSet = new System.Data.DataSet();
            this.DetilBayarTable = new System.Data.DataTable();
            this.JenisBayarIDCol = new System.Data.DataColumn();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.OKButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.jenisBayarIDColDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ButtonCol = new System.Windows.Forms.DataGridViewButtonColumn();
            this.jenisBayarNameColDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nilaiBayarColDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.catatanColDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.BayarGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PenjualanBayarBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PenjualanBayarDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DetilBayarTable)).BeginInit();
            this.SuspendLayout();
            // 
            // BayarGrid
            // 
            this.BayarGrid.AllowUserToAddRows = false;
            this.BayarGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BayarGrid.AutoGenerateColumns = false;
            this.BayarGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BayarGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.jenisBayarIDColDataGridViewTextBoxColumn,
            this.ButtonCol,
            this.jenisBayarNameColDataGridViewTextBoxColumn,
            this.nilaiBayarColDataGridViewTextBoxColumn,
            this.catatanColDataGridViewTextBoxColumn});
            this.BayarGrid.DataSource = this.PenjualanBayarBindingSource;
            this.BayarGrid.Location = new System.Drawing.Point(12, 12);
            this.BayarGrid.Name = "BayarGrid";
            this.BayarGrid.Size = new System.Drawing.Size(659, 280);
            this.BayarGrid.TabIndex = 0;
            // 
            // PenjualanBayarBindingSource
            // 
            this.PenjualanBayarBindingSource.DataMember = "DetilBayarTable";
            this.PenjualanBayarBindingSource.DataSource = this.PenjualanBayarDataSet;
            // 
            // PenjualanBayarDataSet
            // 
            this.PenjualanBayarDataSet.DataSetName = "NewDataSet";
            this.PenjualanBayarDataSet.Tables.AddRange(new System.Data.DataTable[] {
            this.DetilBayarTable});
            // 
            // DetilBayarTable
            // 
            this.DetilBayarTable.Columns.AddRange(new System.Data.DataColumn[] {
            this.JenisBayarIDCol,
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3});
            this.DetilBayarTable.TableName = "DetilBayarTable";
            // 
            // JenisBayarIDCol
            // 
            this.JenisBayarIDCol.Caption = "Kode";
            this.JenisBayarIDCol.ColumnName = "JenisBayarIDCol";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "JenisBayarNameCol";
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "NilaiBayarCol";
            this.dataColumn2.DataType = typeof(decimal);
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "CatatanCol";
            // 
            // OKButton
            // 
            this.OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OKButton.Location = new System.Drawing.Point(515, 298);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 1;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Location = new System.Drawing.Point(596, 298);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 2;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // jenisBayarIDColDataGridViewTextBoxColumn
            // 
            this.jenisBayarIDColDataGridViewTextBoxColumn.DataPropertyName = "JenisBayarIDCol";
            this.jenisBayarIDColDataGridViewTextBoxColumn.HeaderText = "Kode";
            this.jenisBayarIDColDataGridViewTextBoxColumn.Name = "jenisBayarIDColDataGridViewTextBoxColumn";
            this.jenisBayarIDColDataGridViewTextBoxColumn.Width = 50;
            // 
            // ButtonCol
            // 
            this.ButtonCol.HeaderText = "...";
            this.ButtonCol.Name = "ButtonCol";
            this.ButtonCol.Width = 25;
            // 
            // jenisBayarNameColDataGridViewTextBoxColumn
            // 
            this.jenisBayarNameColDataGridViewTextBoxColumn.DataPropertyName = "JenisBayarNameCol";
            this.jenisBayarNameColDataGridViewTextBoxColumn.HeaderText = "Jenis Bayar";
            this.jenisBayarNameColDataGridViewTextBoxColumn.Name = "jenisBayarNameColDataGridViewTextBoxColumn";
            // 
            // nilaiBayarColDataGridViewTextBoxColumn
            // 
            this.nilaiBayarColDataGridViewTextBoxColumn.DataPropertyName = "NilaiBayarCol";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = "0";
            this.nilaiBayarColDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.nilaiBayarColDataGridViewTextBoxColumn.HeaderText = "Nilai Bayar";
            this.nilaiBayarColDataGridViewTextBoxColumn.Name = "nilaiBayarColDataGridViewTextBoxColumn";
            // 
            // catatanColDataGridViewTextBoxColumn
            // 
            this.catatanColDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.catatanColDataGridViewTextBoxColumn.DataPropertyName = "CatatanCol";
            this.catatanColDataGridViewTextBoxColumn.HeaderText = "Catatan";
            this.catatanColDataGridViewTextBoxColumn.Name = "catatanColDataGridViewTextBoxColumn";
            // 
            // PenjualanBayarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleVioletRed;
            this.ClientSize = new System.Drawing.Size(683, 333);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.BayarGrid);
            this.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.Name = "PenjualanBayarForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PenjualanBayarForm";
            this.Load += new System.EventHandler(this.PenjualanBayarForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BayarGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PenjualanBayarBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PenjualanBayarDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DetilBayarTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView BayarGrid;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.BindingSource PenjualanBayarBindingSource;
        private System.Data.DataSet PenjualanBayarDataSet;
        private System.Data.DataTable DetilBayarTable;
        private System.Data.DataColumn JenisBayarIDCol;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn jenisBayarIDColDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn ButtonCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn jenisBayarNameColDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nilaiBayarColDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn catatanColDataGridViewTextBoxColumn;
    }
}