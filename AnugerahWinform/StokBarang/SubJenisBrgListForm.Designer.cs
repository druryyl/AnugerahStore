namespace AnugerahWinform.StokBarang
{
    partial class SubJenisBrgListForm
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
            this.SearchButton = new System.Windows.Forms.Button();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.EditButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.NewButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.SubJenisBrgGrid = new System.Windows.Forms.DataGridView();
            this.JenisBrgGrid = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.SubJenisBrgGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.JenisBrgGrid)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // SearchButton
            // 
            this.SearchButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.SearchButton.Location = new System.Drawing.Point(673, 1);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(75, 23);
            this.SearchButton.TabIndex = 9;
            this.SearchButton.Text = "&Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchTextBox.Location = new System.Drawing.Point(3, 2);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(667, 21);
            this.SearchTextBox.TabIndex = 8;
            // 
            // EditButton
            // 
            this.EditButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.EditButton.Location = new System.Drawing.Point(466, 0);
            this.EditButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(88, 23);
            this.EditButton.TabIndex = 13;
            this.EditButton.Text = "&Edit";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ExitButton.Location = new System.Drawing.Point(658, 0);
            this.ExitButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(88, 23);
            this.ExitButton.TabIndex = 15;
            this.ExitButton.Text = "E&xit";
            this.ExitButton.UseVisualStyleBackColor = true;
            // 
            // NewButton
            // 
            this.NewButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.NewButton.Location = new System.Drawing.Point(370, 0);
            this.NewButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.NewButton.Name = "NewButton";
            this.NewButton.Size = new System.Drawing.Size(88, 23);
            this.NewButton.TabIndex = 12;
            this.NewButton.Text = "&New";
            this.NewButton.UseVisualStyleBackColor = true;
            this.NewButton.Click += new System.EventHandler(this.NewButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.DeleteButton.Location = new System.Drawing.Point(562, 0);
            this.DeleteButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(88, 23);
            this.DeleteButton.TabIndex = 14;
            this.DeleteButton.Text = "&Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            // 
            // SubJenisBrgGrid
            // 
            this.SubJenisBrgGrid.AllowUserToAddRows = false;
            this.SubJenisBrgGrid.AllowUserToDeleteRows = false;
            this.SubJenisBrgGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SubJenisBrgGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SubJenisBrgGrid.Location = new System.Drawing.Point(4, 270);
            this.SubJenisBrgGrid.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.SubJenisBrgGrid.Name = "SubJenisBrgGrid";
            this.SubJenisBrgGrid.ReadOnly = true;
            this.SubJenisBrgGrid.Size = new System.Drawing.Size(748, 231);
            this.SubJenisBrgGrid.TabIndex = 11;
            // 
            // JenisBrgGrid
            // 
            this.JenisBrgGrid.AllowUserToAddRows = false;
            this.JenisBrgGrid.AllowUserToDeleteRows = false;
            this.JenisBrgGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.JenisBrgGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.JenisBrgGrid.Location = new System.Drawing.Point(4, 33);
            this.JenisBrgGrid.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.JenisBrgGrid.Name = "JenisBrgGrid";
            this.JenisBrgGrid.ReadOnly = true;
            this.JenisBrgGrid.Size = new System.Drawing.Size(748, 231);
            this.JenisBrgGrid.TabIndex = 10;
            this.JenisBrgGrid.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.JenisBrgGrid_RowEnter);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.SearchButton);
            this.panel1.Controls.Add(this.SearchTextBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(750, 24);
            this.panel1.TabIndex = 17;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.SubJenisBrgGrid, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.JenisBrgGrid, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(756, 535);
            this.tableLayoutPanel1.TabIndex = 18;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ExitButton);
            this.panel2.Controls.Add(this.DeleteButton);
            this.panel2.Controls.Add(this.NewButton);
            this.panel2.Controls.Add(this.EditButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 507);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(750, 25);
            this.panel2.TabIndex = 19;
            // 
            // SubJenisBrgListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 535);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "SubJenisBrgListForm";
            this.Text = "SubJenisBrgListForm";
            this.Load += new System.EventHandler(this.SubJenisBrgListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SubJenisBrgGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.JenisBrgGrid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button NewButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.DataGridView SubJenisBrgGrid;
        private System.Windows.Forms.DataGridView JenisBrgGrid;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
    }
}