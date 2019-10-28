namespace AnugerahWinform.Support
{
    partial class MarvelReporting
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
            this.MainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.ProsesProgressBar = new System.Windows.Forms.ProgressBar();
            this.PeriodeLabel = new System.Windows.Forms.Label();
            this.IsDetailCheckBox = new System.Windows.Forms.CheckBox();
            this.SearchLabel = new System.Windows.Forms.Label();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.PeriodeMonthCalender = new System.Windows.Forms.MonthCalendar();
            this.ProsesButton = new System.Windows.Forms.Button();
            this.ResultGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).BeginInit();
            this.MainSplitContainer.Panel1.SuspendLayout();
            this.MainSplitContainer.Panel2.SuspendLayout();
            this.MainSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ResultGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // MainSplitContainer
            // 
            this.MainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.MainSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.MainSplitContainer.Name = "MainSplitContainer";
            // 
            // MainSplitContainer.Panel1
            // 
            this.MainSplitContainer.Panel1.Controls.Add(this.ProsesProgressBar);
            this.MainSplitContainer.Panel1.Controls.Add(this.PeriodeLabel);
            this.MainSplitContainer.Panel1.Controls.Add(this.IsDetailCheckBox);
            this.MainSplitContainer.Panel1.Controls.Add(this.SearchLabel);
            this.MainSplitContainer.Panel1.Controls.Add(this.SearchTextBox);
            this.MainSplitContainer.Panel1.Controls.Add(this.PeriodeMonthCalender);
            this.MainSplitContainer.Panel1.Controls.Add(this.ProsesButton);
            // 
            // MainSplitContainer.Panel2
            // 
            this.MainSplitContainer.Panel2.Controls.Add(this.ResultGridView);
            this.MainSplitContainer.Size = new System.Drawing.Size(1132, 607);
            this.MainSplitContainer.SplitterDistance = 271;
            this.MainSplitContainer.TabIndex = 2;
            // 
            // ProsesProgressBar
            // 
            this.ProsesProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProsesProgressBar.Location = new System.Drawing.Point(12, 271);
            this.ProsesProgressBar.Name = "ProsesProgressBar";
            this.ProsesProgressBar.Size = new System.Drawing.Size(253, 12);
            this.ProsesProgressBar.TabIndex = 13;
            this.ProsesProgressBar.Visible = false;
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
            this.SearchLabel.Size = new System.Drawing.Size(107, 13);
            this.SearchLabel.TabIndex = 10;
            this.SearchLabel.Text = "Search Customer";
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
            this.ResultGridView.Size = new System.Drawing.Size(851, 586);
            this.ResultGridView.TabIndex = 3;
            // 
            // MarvelReporting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightYellow;
            this.ClientSize = new System.Drawing.Size(1132, 607);
            this.Controls.Add(this.MainSplitContainer);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MarvelReporting";
            this.Text = "Reporting";
            this.MainSplitContainer.Panel1.ResumeLayout(false);
            this.MainSplitContainer.Panel1.PerformLayout();
            this.MainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).EndInit();
            this.MainSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ResultGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer MainSplitContainer;
        private System.Windows.Forms.ProgressBar ProsesProgressBar;
        private System.Windows.Forms.Label PeriodeLabel;
        private System.Windows.Forms.CheckBox IsDetailCheckBox;
        private System.Windows.Forms.Label SearchLabel;
        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.MonthCalendar PeriodeMonthCalender;
        private System.Windows.Forms.Button ProsesButton;
        private System.Windows.Forms.DataGridView ResultGridView;
    }
}