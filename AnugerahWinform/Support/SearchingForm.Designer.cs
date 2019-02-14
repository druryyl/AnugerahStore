namespace AnugerahWinform.Support
{
    partial class SearchingForm<T>
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.SearchButton = new System.Windows.Forms.Button();
            this.Tgl2DatePicker = new System.Windows.Forms.DateTimePicker();
            this.Tgl1DatePicker = new System.Windows.Forms.DateTimePicker();
            this.KeywordTextBox = new System.Windows.Forms.TextBox();
            this.ListDataGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.SearchButton);
            this.splitContainer1.Panel1.Controls.Add(this.Tgl2DatePicker);
            this.splitContainer1.Panel1.Controls.Add(this.Tgl1DatePicker);
            this.splitContainer1.Panel1.Controls.Add(this.KeywordTextBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ListDataGrid);
            this.splitContainer1.Size = new System.Drawing.Size(393, 492);
            this.splitContainer1.SplitterDistance = 58;
            this.splitContainer1.TabIndex = 0;
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(239, 30);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(75, 23);
            this.SearchButton.TabIndex = 3;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // Tgl2DatePicker
            // 
            this.Tgl2DatePicker.CustomFormat = "dd-MMM-yyyy";
            this.Tgl2DatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Tgl2DatePicker.Location = new System.Drawing.Point(121, 30);
            this.Tgl2DatePicker.Name = "Tgl2DatePicker";
            this.Tgl2DatePicker.Size = new System.Drawing.Size(112, 21);
            this.Tgl2DatePicker.TabIndex = 2;
            // 
            // Tgl1DatePicker
            // 
            this.Tgl1DatePicker.CustomFormat = "dd-MMM-yyyy";
            this.Tgl1DatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Tgl1DatePicker.Location = new System.Drawing.Point(3, 30);
            this.Tgl1DatePicker.Name = "Tgl1DatePicker";
            this.Tgl1DatePicker.Size = new System.Drawing.Size(112, 21);
            this.Tgl1DatePicker.TabIndex = 1;
            // 
            // KeywordTextBox
            // 
            this.KeywordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.KeywordTextBox.Location = new System.Drawing.Point(3, 3);
            this.KeywordTextBox.Name = "KeywordTextBox";
            this.KeywordTextBox.Size = new System.Drawing.Size(387, 21);
            this.KeywordTextBox.TabIndex = 0;
            this.KeywordTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeywordTextBox_KeyDown);
            // 
            // ListDataGrid
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ListDataGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.ListDataGrid.BackgroundColor = System.Drawing.Color.Turquoise;
            this.ListDataGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.ListDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ListDataGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.ListDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListDataGrid.Location = new System.Drawing.Point(0, 0);
            this.ListDataGrid.Name = "ListDataGrid";
            this.ListDataGrid.Size = new System.Drawing.Size(391, 428);
            this.ListDataGrid.TabIndex = 0;
            this.ListDataGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ListDataGrid_CellDoubleClick);
            this.ListDataGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ListDataGrid_KeyDown);
            // 
            // SearchingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 492);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "SearchingForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SearchingForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SearchingForm_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchingForm_KeyDown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ListDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox KeywordTextBox;
        private System.Windows.Forms.DataGridView ListDataGrid;
        private System.Windows.Forms.DateTimePicker Tgl2DatePicker;
        private System.Windows.Forms.DateTimePicker Tgl1DatePicker;
        private System.Windows.Forms.Button SearchButton;
    }
}