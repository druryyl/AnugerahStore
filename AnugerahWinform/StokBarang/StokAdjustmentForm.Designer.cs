﻿namespace AnugerahWinform.StokBarang
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.entryDataTabPage = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LastIDLabel = new System.Windows.Forms.Label();
            this.KeteranganTextBox = new System.Windows.Forms.TextBox();
            this.NoTrsTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TanggalDateTime = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.JamTextBox = new System.Windows.Forms.MaskedTextBox();
            this.NewButton = new System.Windows.Forms.Button();
            this.catatanButton = new System.Windows.Forms.Label();
            this.BrgGrid = new System.Windows.Forms.DataGridView();
            this.StokAdjBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.StokAdjDataSet = new System.Data.DataSet();
            this.DetilAdjTable = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataColumn5 = new System.Data.DataColumn();
            this.dataColumn6 = new System.Data.DataColumn();
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
            this.brgIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BrgGridButtonCol = new System.Windows.Forms.DataGridViewButtonColumn();
            this.brgNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtyAwalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtyAdjustDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtyAkhirDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hppDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainTabControl.SuspendLayout();
            this.entryDataTabPage.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BrgGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StokAdjBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StokAdjDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DetilAdjTable)).BeginInit();
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
            this.mainTabControl.Size = new System.Drawing.Size(963, 481);
            this.mainTabControl.TabIndex = 5;
            // 
            // entryDataTabPage
            // 
            this.entryDataTabPage.BackColor = System.Drawing.Color.Salmon;
            this.entryDataTabPage.Controls.Add(this.panel1);
            this.entryDataTabPage.Controls.Add(this.BrgGrid);
            this.entryDataTabPage.Controls.Add(this.ExitButton);
            this.entryDataTabPage.Controls.Add(this.deleteButton);
            this.entryDataTabPage.Controls.Add(this.saveButton);
            this.entryDataTabPage.Location = new System.Drawing.Point(4, 22);
            this.entryDataTabPage.Name = "entryDataTabPage";
            this.entryDataTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.entryDataTabPage.Size = new System.Drawing.Size(955, 455);
            this.entryDataTabPage.TabIndex = 0;
            this.entryDataTabPage.Text = "Entry Data";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.MistyRose;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.LastIDLabel);
            this.panel1.Controls.Add(this.KeteranganTextBox);
            this.panel1.Controls.Add(this.NoTrsTextBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.TanggalDateTime);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.JamTextBox);
            this.panel1.Controls.Add(this.NewButton);
            this.panel1.Controls.Add(this.catatanButton);
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(943, 105);
            this.panel1.TabIndex = 13;
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
            // KeteranganTextBox
            // 
            this.KeteranganTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.KeteranganTextBox.Location = new System.Drawing.Point(615, 15);
            this.KeteranganTextBox.Multiline = true;
            this.KeteranganTextBox.Name = "KeteranganTextBox";
            this.KeteranganTextBox.Size = new System.Drawing.Size(313, 74);
            this.KeteranganTextBox.TabIndex = 13;
            // 
            // NoTrsTextBox
            // 
            this.NoTrsTextBox.BackColor = System.Drawing.Color.LavenderBlush;
            this.NoTrsTextBox.Location = new System.Drawing.Point(148, 15);
            this.NoTrsTextBox.Name = "NoTrsTextBox";
            this.NoTrsTextBox.Size = new System.Drawing.Size(114, 21);
            this.NoTrsTextBox.TabIndex = 0;
            this.NoTrsTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NoTrsTextBox_KeyDown);
            this.NoTrsTextBox.Validated += new System.EventHandler(this.NoTrsTextBox_Validated);
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
            this.NewButton.Click += new System.EventHandler(this.NewButton_Click);
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
            // BrgGrid
            // 
            this.BrgGrid.AllowUserToAddRows = false;
            this.BrgGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BrgGrid.AutoGenerateColumns = false;
            this.BrgGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BrgGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.brgIDDataGridViewTextBoxColumn,
            this.BrgGridButtonCol,
            this.brgNameDataGridViewTextBoxColumn,
            this.qtyAwalDataGridViewTextBoxColumn,
            this.qtyAdjustDataGridViewTextBoxColumn,
            this.qtyAkhirDataGridViewTextBoxColumn,
            this.hppDataGridViewTextBoxColumn});
            this.BrgGrid.DataSource = this.StokAdjBindingSource;
            this.BrgGrid.Location = new System.Drawing.Point(6, 117);
            this.BrgGrid.Name = "BrgGrid";
            this.BrgGrid.Size = new System.Drawing.Size(941, 303);
            this.BrgGrid.TabIndex = 10;
            this.BrgGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.BrgGrid_CellContentClick);
            this.BrgGrid.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.BrgGrid_CellValidated);
            this.BrgGrid.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.BrgGrid_CellValidating);
            // 
            // StokAdjBindingSource
            // 
            this.StokAdjBindingSource.AllowNew = true;
            this.StokAdjBindingSource.DataMember = "DetilAdjTable";
            this.StokAdjBindingSource.DataSource = this.StokAdjDataSet;
            // 
            // StokAdjDataSet
            // 
            this.StokAdjDataSet.DataSetName = "NewDataSet";
            this.StokAdjDataSet.Tables.AddRange(new System.Data.DataTable[] {
            this.DetilAdjTable});
            // 
            // DetilAdjTable
            // 
            this.DetilAdjTable.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3,
            this.dataColumn4,
            this.dataColumn5,
            this.dataColumn6});
            this.DetilAdjTable.TableName = "DetilAdjTable";
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
            this.dataColumn3.ColumnName = "QtyAwal";
            this.dataColumn3.DataType = typeof(decimal);
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "QtyAdjust";
            this.dataColumn4.DataType = typeof(decimal);
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "QtyAkhir";
            this.dataColumn5.DataType = typeof(decimal);
            // 
            // dataColumn6
            // 
            this.dataColumn6.ColumnName = "Hpp";
            this.dataColumn6.DataType = typeof(decimal);
            // 
            // ExitButton
            // 
            this.ExitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ExitButton.Location = new System.Drawing.Point(848, 426);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(87, 23);
            this.ExitButton.TabIndex = 8;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteButton.Location = new System.Drawing.Point(755, 426);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(87, 23);
            this.deleteButton.TabIndex = 7;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Location = new System.Drawing.Point(662, 426);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(87, 23);
            this.saveButton.TabIndex = 6;
            this.saveButton.Text = "Save";
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
            this.listDataTabPage.Size = new System.Drawing.Size(955, 455);
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
            this.JamTrsTimer.Tick += new System.EventHandler(this.JamTrsTimer_Tick);
            // 
            // brgIDDataGridViewTextBoxColumn
            // 
            this.brgIDDataGridViewTextBoxColumn.DataPropertyName = "BrgID";
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.brgIDDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.brgIDDataGridViewTextBoxColumn.HeaderText = "BrgID";
            this.brgIDDataGridViewTextBoxColumn.Name = "brgIDDataGridViewTextBoxColumn";
            this.brgIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // BrgGridButtonCol
            // 
            this.BrgGridButtonCol.HeaderText = "...";
            this.BrgGridButtonCol.Name = "BrgGridButtonCol";
            this.BrgGridButtonCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.BrgGridButtonCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.BrgGridButtonCol.Width = 25;
            // 
            // brgNameDataGridViewTextBoxColumn
            // 
            this.brgNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.brgNameDataGridViewTextBoxColumn.DataPropertyName = "BrgName";
            this.brgNameDataGridViewTextBoxColumn.HeaderText = "BrgName";
            this.brgNameDataGridViewTextBoxColumn.Name = "brgNameDataGridViewTextBoxColumn";
            this.brgNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // qtyAwalDataGridViewTextBoxColumn
            // 
            this.qtyAwalDataGridViewTextBoxColumn.DataPropertyName = "QtyAwal";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = "0";
            this.qtyAwalDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.qtyAwalDataGridViewTextBoxColumn.HeaderText = "QtyAwal";
            this.qtyAwalDataGridViewTextBoxColumn.Name = "qtyAwalDataGridViewTextBoxColumn";
            this.qtyAwalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // qtyAdjustDataGridViewTextBoxColumn
            // 
            this.qtyAdjustDataGridViewTextBoxColumn.DataPropertyName = "QtyAdjust";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = "0";
            this.qtyAdjustDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.qtyAdjustDataGridViewTextBoxColumn.HeaderText = "QtyAdjust";
            this.qtyAdjustDataGridViewTextBoxColumn.Name = "qtyAdjustDataGridViewTextBoxColumn";
            // 
            // qtyAkhirDataGridViewTextBoxColumn
            // 
            this.qtyAkhirDataGridViewTextBoxColumn.DataPropertyName = "QtyAkhir";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = "0";
            this.qtyAkhirDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.qtyAkhirDataGridViewTextBoxColumn.HeaderText = "QtyAkhir";
            this.qtyAkhirDataGridViewTextBoxColumn.Name = "qtyAkhirDataGridViewTextBoxColumn";
            this.qtyAkhirDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // hppDataGridViewTextBoxColumn
            // 
            this.hppDataGridViewTextBoxColumn.DataPropertyName = "Hpp";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = "0";
            this.hppDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.hppDataGridViewTextBoxColumn.HeaderText = "Hpp";
            this.hppDataGridViewTextBoxColumn.Name = "hppDataGridViewTextBoxColumn";
            // 
            // StokAdjustmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 481);
            this.Controls.Add(this.mainTabControl);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "StokAdjustmentForm";
            this.Text = "StokAdjustmentForm";
            this.Load += new System.EventHandler(this.StokAdjustmentForm_Load);
            this.mainTabControl.ResumeLayout(false);
            this.entryDataTabPage.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BrgGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StokAdjBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StokAdjDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DetilAdjTable)).EndInit();
            this.listDataTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage entryDataTabPage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox KeteranganTextBox;
        private System.Windows.Forms.TextBox NoTrsTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker TanggalDateTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox JamTextBox;
        private System.Windows.Forms.Button NewButton;
        private System.Windows.Forms.Label catatanButton;
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
        private System.Data.DataSet StokAdjDataSet;
        private System.Data.DataTable DetilAdjTable;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataColumn dataColumn5;
        private System.Data.DataColumn dataColumn6;
        private System.Windows.Forms.BindingSource StokAdjBindingSource;
        private System.Windows.Forms.Label LastIDLabel;
        private System.Windows.Forms.Timer JamTrsTimer;
        private System.Windows.Forms.DataGridViewTextBoxColumn brgIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn BrgGridButtonCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn brgNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyAwalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyAdjustDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyAkhirDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hppDataGridViewTextBoxColumn;
    }
}