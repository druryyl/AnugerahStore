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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.BayarGrid = new System.Windows.Forms.DataGridView();
            this.OKButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.PenjualanBayarBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PenjualanBayarDataSet = new System.Data.DataSet();
            this.DetilBayarTable = new System.Data.DataTable();
            this.JenisBayarIDCol = new System.Data.DataColumn();
            this.NilaiBayarCol = new System.Data.DataColumn();
            this.CatatanCol = new System.Data.DataColumn();
            this.jenisBayarIDColDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nilaiBayarColDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.catatanDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.BayarGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PenjualanBayarBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PenjualanBayarDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DetilBayarTable)).BeginInit();
            this.SuspendLayout();
            // 
            // BayarGrid
            // 
            this.BayarGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BayarGrid.AutoGenerateColumns = false;
            this.BayarGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BayarGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.jenisBayarIDColDataGridViewTextBoxColumn,
            this.nilaiBayarColDataGridViewTextBoxColumn,
            this.catatanDataGridViewTextBoxColumn});
            this.BayarGrid.DataSource = this.PenjualanBayarBindingSource;
            this.BayarGrid.Location = new System.Drawing.Point(12, 12);
            this.BayarGrid.Name = "BayarGrid";
            this.BayarGrid.Size = new System.Drawing.Size(659, 280);
            this.BayarGrid.TabIndex = 0;
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(515, 298);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 1;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            // 
            // CancelButton
            // 
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Location = new System.Drawing.Point(596, 298);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 2;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
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
            this.NilaiBayarCol,
            this.CatatanCol});
            this.DetilBayarTable.TableName = "DetilBayarTable";
            // 
            // JenisBayarIDCol
            // 
            this.JenisBayarIDCol.Caption = "Jenis Bayar ID";
            this.JenisBayarIDCol.ColumnName = "JenisBayarIDCol";
            // 
            // NilaiBayarCol
            // 
            this.NilaiBayarCol.Caption = "Nilai Bayar";
            this.NilaiBayarCol.ColumnName = "NilaiBayarCol";
            this.NilaiBayarCol.DataType = typeof(decimal);
            // 
            // CatatanCol
            // 
            this.CatatanCol.ColumnName = "Catatan";
            // 
            // jenisBayarIDColDataGridViewTextBoxColumn
            // 
            this.jenisBayarIDColDataGridViewTextBoxColumn.DataPropertyName = "JenisBayarIDCol";
            this.jenisBayarIDColDataGridViewTextBoxColumn.HeaderText = "Jenis Bayar";
            this.jenisBayarIDColDataGridViewTextBoxColumn.Name = "jenisBayarIDColDataGridViewTextBoxColumn";
            // 
            // nilaiBayarColDataGridViewTextBoxColumn
            // 
            this.nilaiBayarColDataGridViewTextBoxColumn.DataPropertyName = "NilaiBayarCol";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = "0";
            this.nilaiBayarColDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.nilaiBayarColDataGridViewTextBoxColumn.HeaderText = "Nilai Bayar";
            this.nilaiBayarColDataGridViewTextBoxColumn.Name = "nilaiBayarColDataGridViewTextBoxColumn";
            // 
            // catatanDataGridViewTextBoxColumn
            // 
            this.catatanDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.catatanDataGridViewTextBoxColumn.DataPropertyName = "Catatan";
            this.catatanDataGridViewTextBoxColumn.HeaderText = "Catatan";
            this.catatanDataGridViewTextBoxColumn.Name = "catatanDataGridViewTextBoxColumn";
            // 
            // PenjualanBayarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Khaki;
            this.CancelButton = this.CancelButton;
            this.ClientSize = new System.Drawing.Size(683, 333);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.BayarGrid);
            this.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.Name = "PenjualanBayarForm";
            this.Text = "PenjualanBayarForm";
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
        private System.Data.DataColumn NilaiBayarCol;
        private System.Data.DataColumn CatatanCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn jenisBayarIDColDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nilaiBayarColDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn catatanDataGridViewTextBoxColumn;
    }
}