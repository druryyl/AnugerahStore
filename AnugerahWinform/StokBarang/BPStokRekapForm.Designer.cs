namespace AnugerahWinform.StokBarang
{
    partial class BPStokRekapForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ForecastingPanel = new System.Windows.Forms.Panel();
            this.MinLevelNumText = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.MaxLevelNumText = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.PeriodeAnalisaNumText = new System.Windows.Forms.NumericUpDown();
            this.PeriodeLabel = new System.Windows.Forms.Label();
            this.ProsesProgressBar = new System.Windows.Forms.ProgressBar();
            this.IsForecastCheckBox = new System.Windows.Forms.CheckBox();
            this.SearchLabel = new System.Windows.Forms.Label();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.ProsesButton = new System.Windows.Forms.Button();
            this.ResultGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.ForecastingPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MinLevelNumText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxLevelNumText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PeriodeAnalisaNumText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResultGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ForecastingPanel);
            this.splitContainer1.Panel1.Controls.Add(this.ProsesProgressBar);
            this.splitContainer1.Panel1.Controls.Add(this.IsForecastCheckBox);
            this.splitContainer1.Panel1.Controls.Add(this.SearchLabel);
            this.splitContainer1.Panel1.Controls.Add(this.SearchTextBox);
            this.splitContainer1.Panel1.Controls.Add(this.ProsesButton);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ResultGridView);
            this.splitContainer1.Size = new System.Drawing.Size(1132, 607);
            this.splitContainer1.SplitterDistance = 271;
            this.splitContainer1.TabIndex = 1;
            // 
            // ForecastingPanel
            // 
            this.ForecastingPanel.Controls.Add(this.MinLevelNumText);
            this.ForecastingPanel.Controls.Add(this.label2);
            this.ForecastingPanel.Controls.Add(this.MaxLevelNumText);
            this.ForecastingPanel.Controls.Add(this.label1);
            this.ForecastingPanel.Controls.Add(this.PeriodeAnalisaNumText);
            this.ForecastingPanel.Controls.Add(this.PeriodeLabel);
            this.ForecastingPanel.Location = new System.Drawing.Point(3, 122);
            this.ForecastingPanel.Name = "ForecastingPanel";
            this.ForecastingPanel.Size = new System.Drawing.Size(269, 197);
            this.ForecastingPanel.TabIndex = 14;
            this.ForecastingPanel.Visible = false;
            // 
            // MinLevelNumText
            // 
            this.MinLevelNumText.Location = new System.Drawing.Point(7, 96);
            this.MinLevelNumText.Name = "MinLevelNumText";
            this.MinLevelNumText.Size = new System.Drawing.Size(257, 21);
            this.MinLevelNumText.TabIndex = 5;
            this.MinLevelNumText.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Min Level";
            this.label2.Visible = false;
            // 
            // MaxLevelNumText
            // 
            this.MaxLevelNumText.Location = new System.Drawing.Point(9, 56);
            this.MaxLevelNumText.Maximum = new decimal(new int[] {
            365,
            0,
            0,
            0});
            this.MaxLevelNumText.Name = "MaxLevelNumText";
            this.MaxLevelNumText.Size = new System.Drawing.Size(257, 21);
            this.MaxLevelNumText.TabIndex = 3;
            this.MaxLevelNumText.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Lead Time (hari)";
            // 
            // PeriodeAnalisaNumText
            // 
            this.PeriodeAnalisaNumText.Location = new System.Drawing.Point(9, 16);
            this.PeriodeAnalisaNumText.Maximum = new decimal(new int[] {
            365,
            0,
            0,
            0});
            this.PeriodeAnalisaNumText.Name = "PeriodeAnalisaNumText";
            this.PeriodeAnalisaNumText.Size = new System.Drawing.Size(257, 21);
            this.PeriodeAnalisaNumText.TabIndex = 1;
            this.PeriodeAnalisaNumText.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            // 
            // PeriodeLabel
            // 
            this.PeriodeLabel.AutoSize = true;
            this.PeriodeLabel.Location = new System.Drawing.Point(6, 0);
            this.PeriodeLabel.Name = "PeriodeLabel";
            this.PeriodeLabel.Size = new System.Drawing.Size(131, 13);
            this.PeriodeLabel.TabIndex = 0;
            this.PeriodeLabel.Text = "Periode Analisa (hari)";
            // 
            // ProsesProgressBar
            // 
            this.ProsesProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProsesProgressBar.Location = new System.Drawing.Point(12, 81);
            this.ProsesProgressBar.Name = "ProsesProgressBar";
            this.ProsesProgressBar.Size = new System.Drawing.Size(253, 12);
            this.ProsesProgressBar.TabIndex = 13;
            this.ProsesProgressBar.Visible = false;
            // 
            // IsForecastCheckBox
            // 
            this.IsForecastCheckBox.AutoSize = true;
            this.IsForecastCheckBox.Location = new System.Drawing.Point(12, 99);
            this.IsForecastCheckBox.Name = "IsForecastCheckBox";
            this.IsForecastCheckBox.Size = new System.Drawing.Size(91, 17);
            this.IsForecastCheckBox.TabIndex = 1;
            this.IsForecastCheckBox.Text = "Forecasting";
            this.IsForecastCheckBox.UseVisualStyleBackColor = true;
            this.IsForecastCheckBox.CheckedChanged += new System.EventHandler(this.IsForecastCheckBox_CheckedChanged);
            // 
            // SearchLabel
            // 
            this.SearchLabel.AutoSize = true;
            this.SearchLabel.Location = new System.Drawing.Point(12, 9);
            this.SearchLabel.Name = "SearchLabel";
            this.SearchLabel.Size = new System.Drawing.Size(92, 13);
            this.SearchLabel.TabIndex = 10;
            this.SearchLabel.Text = "Search Barang";
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchTextBox.Location = new System.Drawing.Point(12, 25);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(256, 21);
            this.SearchTextBox.TabIndex = 1;
            // 
            // ProsesButton
            // 
            this.ProsesButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProsesButton.Location = new System.Drawing.Point(12, 52);
            this.ProsesButton.Name = "ProsesButton";
            this.ProsesButton.Size = new System.Drawing.Size(256, 23);
            this.ProsesButton.TabIndex = 2;
            this.ProsesButton.Text = "Proses";
            this.ProsesButton.UseVisualStyleBackColor = true;
            this.ProsesButton.Click += new System.EventHandler(this.ProsesButton_Click);
            // 
            // ResultGridView
            // 
            this.ResultGridView.AllowUserToAddRows = false;
            this.ResultGridView.AllowUserToDeleteRows = false;
            this.ResultGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ResultGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ResultGridView.Location = new System.Drawing.Point(3, 9);
            this.ResultGridView.Name = "ResultGridView";
            this.ResultGridView.ReadOnly = true;
            this.ResultGridView.Size = new System.Drawing.Size(851, 577);
            this.ResultGridView.TabIndex = 3;
            // 
            // BPStokRekapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(1132, 607);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "BPStokRekapForm";
            this.Text = "Info Stok Rekap";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ForecastingPanel.ResumeLayout(false);
            this.ForecastingPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MinLevelNumText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxLevelNumText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PeriodeAnalisaNumText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResultGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ProgressBar ProsesProgressBar;
        private System.Windows.Forms.CheckBox IsForecastCheckBox;
        private System.Windows.Forms.Label SearchLabel;
        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.Button ProsesButton;
        private System.Windows.Forms.DataGridView ResultGridView;
        private System.Windows.Forms.Panel ForecastingPanel;
        private System.Windows.Forms.NumericUpDown MinLevelNumText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown MaxLevelNumText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown PeriodeAnalisaNumText;
        private System.Windows.Forms.Label PeriodeLabel;
    }
}