namespace AnugerahWinform.StokBarang
{
    partial class BPStokInfoForm
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
            this.IsDetailCheckBox = new System.Windows.Forms.CheckBox();
            this.SearchLabel = new System.Windows.Forms.Label();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.PeriodeMonthCalender = new System.Windows.Forms.MonthCalendar();
            this.ProsesButton = new System.Windows.Forms.Button();
            this.ResultGridView = new System.Windows.Forms.DataGridView();
            this.PeriodeLabel = new System.Windows.Forms.Label();
            this.ProsesProgressBar = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.ProsesProgressBar);
            this.splitContainer1.Panel1.Controls.Add(this.PeriodeLabel);
            this.splitContainer1.Panel1.Controls.Add(this.IsDetailCheckBox);
            this.splitContainer1.Panel1.Controls.Add(this.SearchLabel);
            this.splitContainer1.Panel1.Controls.Add(this.SearchTextBox);
            this.splitContainer1.Panel1.Controls.Add(this.PeriodeMonthCalender);
            this.splitContainer1.Panel1.Controls.Add(this.ProsesButton);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ResultGridView);
            this.splitContainer1.Size = new System.Drawing.Size(1132, 607);
            this.splitContainer1.SplitterDistance = 271;
            this.splitContainer1.TabIndex = 0;
            // 
            // IsDetailCheckBox
            // 
            this.IsDetailCheckBox.AutoSize = true;
            this.IsDetailCheckBox.Location = new System.Drawing.Point(12, 289);
            this.IsDetailCheckBox.Name = "IsDetailCheckBox";
            this.IsDetailCheckBox.Size = new System.Drawing.Size(59, 17);
            this.IsDetailCheckBox.TabIndex = 1;
            this.IsDetailCheckBox.Text = "Detail";
            this.IsDetailCheckBox.UseVisualStyleBackColor = true;
            this.IsDetailCheckBox.Visible = false;
            // 
            // SearchLabel
            // 
            this.SearchLabel.AutoSize = true;
            this.SearchLabel.Location = new System.Drawing.Point(12, 199);
            this.SearchLabel.Name = "SearchLabel";
            this.SearchLabel.Size = new System.Drawing.Size(92, 13);
            this.SearchLabel.TabIndex = 10;
            this.SearchLabel.Text = "Search Barang";
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchTextBox.Location = new System.Drawing.Point(12, 215);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(256, 21);
            this.SearchTextBox.TabIndex = 1;
            // 
            // PeriodeMonthCalender
            // 
            this.PeriodeMonthCalender.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PeriodeMonthCalender.Location = new System.Drawing.Point(24, 9);
            this.PeriodeMonthCalender.MaxSelectionCount = 31;
            this.PeriodeMonthCalender.Name = "PeriodeMonthCalender";
            this.PeriodeMonthCalender.TabIndex = 0;
            this.PeriodeMonthCalender.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.PeriodeMonthCalender_DateChanged);
            // 
            // ProsesButton
            // 
            this.ProsesButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProsesButton.Location = new System.Drawing.Point(12, 242);
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
            // PeriodeLabel
            // 
            this.PeriodeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PeriodeLabel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PeriodeLabel.Location = new System.Drawing.Point(12, 180);
            this.PeriodeLabel.Name = "PeriodeLabel";
            this.PeriodeLabel.Size = new System.Drawing.Size(256, 19);
            this.PeriodeLabel.TabIndex = 11;
            this.PeriodeLabel.Text = "[Periode]";
            this.PeriodeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProsesProgressBar
            // 
            this.ProsesProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProsesProgressBar.Location = new System.Drawing.Point(12, 271);
            this.ProsesProgressBar.Name = "ProsesProgressBar";
            this.ProsesProgressBar.Size = new System.Drawing.Size(253, 12);
            this.ProsesProgressBar.TabIndex = 13;
            this.ProsesProgressBar.Visible = false;
            // 
            // BPStokInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(1132, 607);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "BPStokInfoForm";
            this.Text = "Info Stok Detil";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ResultGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.MonthCalendar PeriodeMonthCalender;
        private System.Windows.Forms.Button ProsesButton;
        private System.Windows.Forms.DataGridView ResultGridView;
        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.CheckBox IsDetailCheckBox;
        private System.Windows.Forms.Label SearchLabel;
        private System.Windows.Forms.Label PeriodeLabel;
        private System.Windows.Forms.ProgressBar ProsesProgressBar;
    }
}