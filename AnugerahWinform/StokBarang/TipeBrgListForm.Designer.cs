namespace AnugerahWinform.StokBarang
{
    partial class TipeBrgListForm
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
            this.JenisBrgGrid = new System.Windows.Forms.DataGridView();
            this.TipeBrgGrid = new System.Windows.Forms.DataGridView();
            this.ExitButton = new System.Windows.Forms.Button();
            this.NewButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.SearchButton = new System.Windows.Forms.Button();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.JenisBrgGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TipeBrgGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // JenisBrgGrid
            // 
            this.JenisBrgGrid.AllowUserToAddRows = false;
            this.JenisBrgGrid.AllowUserToDeleteRows = false;
            this.JenisBrgGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.JenisBrgGrid.Location = new System.Drawing.Point(14, 39);
            this.JenisBrgGrid.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.JenisBrgGrid.Name = "JenisBrgGrid";
            this.JenisBrgGrid.ReadOnly = true;
            this.JenisBrgGrid.Size = new System.Drawing.Size(488, 288);
            this.JenisBrgGrid.TabIndex = 2;
            this.JenisBrgGrid.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.JenisBrgGrid_RowEnter);
            // 
            // TipeBrgGrid
            // 
            this.TipeBrgGrid.AllowUserToAddRows = false;
            this.TipeBrgGrid.AllowUserToDeleteRows = false;
            this.TipeBrgGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TipeBrgGrid.Location = new System.Drawing.Point(14, 333);
            this.TipeBrgGrid.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TipeBrgGrid.Name = "TipeBrgGrid";
            this.TipeBrgGrid.ReadOnly = true;
            this.TipeBrgGrid.Size = new System.Drawing.Size(488, 150);
            this.TipeBrgGrid.TabIndex = 3;
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(415, 489);
            this.ExitButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(88, 23);
            this.ExitButton.TabIndex = 7;
            this.ExitButton.Text = "E&xit";
            this.ExitButton.UseVisualStyleBackColor = true;
            // 
            // NewButton
            // 
            this.NewButton.Location = new System.Drawing.Point(127, 489);
            this.NewButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.NewButton.Name = "NewButton";
            this.NewButton.Size = new System.Drawing.Size(88, 23);
            this.NewButton.TabIndex = 4;
            this.NewButton.Text = "&New";
            this.NewButton.UseVisualStyleBackColor = true;
            this.NewButton.Click += new System.EventHandler(this.NewButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(319, 489);
            this.DeleteButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(88, 23);
            this.DeleteButton.TabIndex = 6;
            this.DeleteButton.Text = "&Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            // 
            // EditButton
            // 
            this.EditButton.Location = new System.Drawing.Point(223, 489);
            this.EditButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(88, 23);
            this.EditButton.TabIndex = 5;
            this.EditButton.Text = "&Edit";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // SearchButton
            // 
            this.SearchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchButton.Location = new System.Drawing.Point(427, 10);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(75, 23);
            this.SearchButton.TabIndex = 1;
            this.SearchButton.Text = "&Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Location = new System.Drawing.Point(14, 12);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(407, 21);
            this.SearchTextBox.TabIndex = 0;
            // 
            // TipeBrgListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 524);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.SearchTextBox);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.NewButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.TipeBrgGrid);
            this.Controls.Add(this.JenisBrgGrid);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "TipeBrgListForm";
            this.Text = "Tipe Barang";
            ((System.ComponentModel.ISupportInitialize)(this.JenisBrgGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TipeBrgGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView JenisBrgGrid;
        private System.Windows.Forms.DataGridView TipeBrgGrid;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button NewButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.TextBox SearchTextBox;
    }
}