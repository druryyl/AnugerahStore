﻿namespace AnugerahWinform.Penjualan
{
    partial class PricingForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.MainSplitContainer = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.JenisTreeView = new ComponentFactory.Krypton.Toolkit.KryptonTreeView();
            this.BrgSplitContainer = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.BrgGrid = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.BrgKodeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BrgNamaCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BrgJenisCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BrgMerkCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BrgColorCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BrgPriceCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PriceSplitContainer = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.PriceGrid = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.PriceQtyCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PriceHargaCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PriceDiskonCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExitButton = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.DeleteButton = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.SaveButton = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.PasteButton = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.CopyButton = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer.Panel1)).BeginInit();
            this.MainSplitContainer.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer.Panel2)).BeginInit();
            this.MainSplitContainer.Panel2.SuspendLayout();
            this.MainSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BrgSplitContainer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BrgSplitContainer.Panel1)).BeginInit();
            this.BrgSplitContainer.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BrgSplitContainer.Panel2)).BeginInit();
            this.BrgSplitContainer.Panel2.SuspendLayout();
            this.BrgSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BrgGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PriceSplitContainer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PriceSplitContainer.Panel1)).BeginInit();
            this.PriceSplitContainer.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PriceSplitContainer.Panel2)).BeginInit();
            this.PriceSplitContainer.Panel2.SuspendLayout();
            this.PriceSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PriceGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // MainSplitContainer
            // 
            this.MainSplitContainer.Cursor = System.Windows.Forms.Cursors.Default;
            this.MainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.MainSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.MainSplitContainer.Name = "MainSplitContainer";
            // 
            // MainSplitContainer.Panel1
            // 
            this.MainSplitContainer.Panel1.Controls.Add(this.JenisTreeView);
            // 
            // MainSplitContainer.Panel2
            // 
            this.MainSplitContainer.Panel2.Controls.Add(this.BrgSplitContainer);
            this.MainSplitContainer.SeparatorStyle = ComponentFactory.Krypton.Toolkit.SeparatorStyle.HighProfile;
            this.MainSplitContainer.Size = new System.Drawing.Size(969, 557);
            this.MainSplitContainer.SplitterDistance = 225;
            this.MainSplitContainer.TabIndex = 0;
            // 
            // JenisTreeView
            // 
            this.JenisTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.JenisTreeView.Location = new System.Drawing.Point(0, 0);
            this.JenisTreeView.Name = "JenisTreeView";
            this.JenisTreeView.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            this.JenisTreeView.Size = new System.Drawing.Size(225, 557);
            this.JenisTreeView.TabIndex = 0;
            this.JenisTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.JenisTreeView_AfterSelect);
            // 
            // BrgSplitContainer
            // 
            this.BrgSplitContainer.Cursor = System.Windows.Forms.Cursors.Default;
            this.BrgSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BrgSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.BrgSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.BrgSplitContainer.Name = "BrgSplitContainer";
            this.BrgSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // BrgSplitContainer.Panel1
            // 
            this.BrgSplitContainer.Panel1.Controls.Add(this.BrgGrid);
            // 
            // BrgSplitContainer.Panel2
            // 
            this.BrgSplitContainer.Panel2.Controls.Add(this.PriceSplitContainer);
            this.BrgSplitContainer.SeparatorStyle = ComponentFactory.Krypton.Toolkit.SeparatorStyle.HighProfile;
            this.BrgSplitContainer.Size = new System.Drawing.Size(739, 557);
            this.BrgSplitContainer.SplitterDistance = 372;
            this.BrgSplitContainer.TabIndex = 0;
            // 
            // BrgGrid
            // 
            this.BrgGrid.AllowUserToAddRows = false;
            this.BrgGrid.AllowUserToDeleteRows = false;
            this.BrgGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BrgGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BrgKodeCol,
            this.BrgNamaCol,
            this.BrgJenisCol,
            this.BrgMerkCol,
            this.BrgColorCol,
            this.BrgPriceCol});
            this.BrgGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BrgGrid.Location = new System.Drawing.Point(0, 0);
            this.BrgGrid.Name = "BrgGrid";
            this.BrgGrid.ReadOnly = true;
            this.BrgGrid.Size = new System.Drawing.Size(739, 372);
            this.BrgGrid.TabIndex = 0;
            // 
            // BrgKodeCol
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.BrgKodeCol.DefaultCellStyle = dataGridViewCellStyle6;
            this.BrgKodeCol.HeaderText = "Kode";
            this.BrgKodeCol.Name = "BrgKodeCol";
            this.BrgKodeCol.ReadOnly = true;
            this.BrgKodeCol.Width = 50;
            // 
            // BrgNamaCol
            // 
            this.BrgNamaCol.HeaderText = "Nama Brg";
            this.BrgNamaCol.Name = "BrgNamaCol";
            this.BrgNamaCol.ReadOnly = true;
            this.BrgNamaCol.Width = 200;
            // 
            // BrgJenisCol
            // 
            this.BrgJenisCol.HeaderText = "Jenis";
            this.BrgJenisCol.Name = "BrgJenisCol";
            this.BrgJenisCol.ReadOnly = true;
            this.BrgJenisCol.Width = 150;
            // 
            // BrgMerkCol
            // 
            this.BrgMerkCol.HeaderText = "Merk";
            this.BrgMerkCol.Name = "BrgMerkCol";
            this.BrgMerkCol.ReadOnly = true;
            // 
            // BrgColorCol
            // 
            this.BrgColorCol.HeaderText = "Color";
            this.BrgColorCol.Name = "BrgColorCol";
            this.BrgColorCol.ReadOnly = true;
            this.BrgColorCol.Width = 80;
            // 
            // BrgPriceCol
            // 
            this.BrgPriceCol.HeaderText = "Price";
            this.BrgPriceCol.Name = "BrgPriceCol";
            this.BrgPriceCol.ReadOnly = true;
            // 
            // PriceSplitContainer
            // 
            this.PriceSplitContainer.Cursor = System.Windows.Forms.Cursors.Default;
            this.PriceSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PriceSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.PriceSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.PriceSplitContainer.Name = "PriceSplitContainer";
            // 
            // PriceSplitContainer.Panel1
            // 
            this.PriceSplitContainer.Panel1.Controls.Add(this.PriceGrid);
            // 
            // PriceSplitContainer.Panel2
            // 
            this.PriceSplitContainer.Panel2.Controls.Add(this.ExitButton);
            this.PriceSplitContainer.Panel2.Controls.Add(this.DeleteButton);
            this.PriceSplitContainer.Panel2.Controls.Add(this.SaveButton);
            this.PriceSplitContainer.Panel2.Controls.Add(this.PasteButton);
            this.PriceSplitContainer.Panel2.Controls.Add(this.CopyButton);
            this.PriceSplitContainer.Size = new System.Drawing.Size(739, 180);
            this.PriceSplitContainer.SplitterDistance = 568;
            this.PriceSplitContainer.TabIndex = 0;
            // 
            // PriceGrid
            // 
            this.PriceGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PriceGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PriceQtyCol,
            this.PriceHargaCol,
            this.PriceDiskonCol});
            this.PriceGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PriceGrid.Location = new System.Drawing.Point(0, 0);
            this.PriceGrid.Name = "PriceGrid";
            this.PriceGrid.Size = new System.Drawing.Size(568, 180);
            this.PriceGrid.TabIndex = 0;
            // 
            // PriceQtyCol
            // 
            this.PriceQtyCol.HeaderText = "Min Qty";
            this.PriceQtyCol.Name = "PriceQtyCol";
            // 
            // PriceHargaCol
            // 
            this.PriceHargaCol.HeaderText = "Harga";
            this.PriceHargaCol.Name = "PriceHargaCol";
            // 
            // PriceDiskonCol
            // 
            this.PriceDiskonCol.HeaderText = "Diskon";
            this.PriceDiskonCol.Name = "PriceDiskonCol";
            // 
            // ExitButton
            // 
            this.ExitButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ExitButton.Location = new System.Drawing.Point(3, 152);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(160, 25);
            this.ExitButton.TabIndex = 4;
            this.ExitButton.Values.Text = "Exit";
            // 
            // DeleteButton
            // 
            this.DeleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteButton.Location = new System.Drawing.Point(3, 96);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(160, 25);
            this.DeleteButton.TabIndex = 3;
            this.DeleteButton.Values.Text = "Delete";
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.Location = new System.Drawing.Point(3, 65);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(160, 25);
            this.SaveButton.TabIndex = 2;
            this.SaveButton.Values.Text = "Save";
            // 
            // PasteButton
            // 
            this.PasteButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PasteButton.Location = new System.Drawing.Point(3, 34);
            this.PasteButton.Name = "PasteButton";
            this.PasteButton.Size = new System.Drawing.Size(160, 25);
            this.PasteButton.TabIndex = 1;
            this.PasteButton.Values.Text = "Paste";
            // 
            // CopyButton
            // 
            this.CopyButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CopyButton.Location = new System.Drawing.Point(3, 3);
            this.CopyButton.Name = "CopyButton";
            this.CopyButton.Size = new System.Drawing.Size(160, 25);
            this.CopyButton.TabIndex = 0;
            this.CopyButton.Values.Text = "Copy";
            // 
            // PricingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 557);
            this.Controls.Add(this.MainSplitContainer);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "PricingForm";
            this.Text = "PricingForm";
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer.Panel1)).EndInit();
            this.MainSplitContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer.Panel2)).EndInit();
            this.MainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).EndInit();
            this.MainSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BrgSplitContainer.Panel1)).EndInit();
            this.BrgSplitContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BrgSplitContainer.Panel2)).EndInit();
            this.BrgSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BrgSplitContainer)).EndInit();
            this.BrgSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BrgGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PriceSplitContainer.Panel1)).EndInit();
            this.PriceSplitContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PriceSplitContainer.Panel2)).EndInit();
            this.PriceSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PriceSplitContainer)).EndInit();
            this.PriceSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PriceGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer MainSplitContainer;
        private ComponentFactory.Krypton.Toolkit.KryptonTreeView JenisTreeView;
        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer BrgSplitContainer;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView BrgGrid;
        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer PriceSplitContainer;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView PriceGrid;
        private ComponentFactory.Krypton.Toolkit.KryptonButton ExitButton;
        private ComponentFactory.Krypton.Toolkit.KryptonButton DeleteButton;
        private ComponentFactory.Krypton.Toolkit.KryptonButton SaveButton;
        private ComponentFactory.Krypton.Toolkit.KryptonButton PasteButton;
        private ComponentFactory.Krypton.Toolkit.KryptonButton CopyButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn BrgKodeCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn BrgNamaCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn BrgJenisCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn BrgMerkCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn BrgColorCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn BrgPriceCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn PriceQtyCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn PriceHargaCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn PriceDiskonCol;
    }
}