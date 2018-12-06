﻿namespace AnugerahWinform.StokBarang
{
    partial class BarangListForm
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
            this.SubJenisBrgTree = new System.Windows.Forms.TreeView();
            this.BarangGrid = new System.Windows.Forms.DataGridView();
            this.SearchText = new System.Windows.Forms.TextBox();
            this.SearchLabel = new System.Windows.Forms.Label();
            this.BarangTabControl = new System.Windows.Forms.TabControl();
            this.KlasifikasiTab = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ColorPanel = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ColorComboBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.MerkComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.KeteranganLabel = new System.Windows.Forms.Label();
            this.SubJenisBrgComboBox = new System.Windows.Forms.ComboBox();
            this.JenisBrgComboBox = new System.Windows.Forms.ComboBox();
            this.KeteranganText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BrgNameText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BrgIDText = new System.Windows.Forms.TextBox();
            this.PhotoTab = new System.Windows.Forms.TabPage();
            this.PricingTab = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.button4 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.BarangGrid)).BeginInit();
            this.BarangTabControl.SuspendLayout();
            this.KlasifikasiTab.SuspendLayout();
            this.panel1.SuspendLayout();
            this.PricingTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // SubJenisBrgTree
            // 
            this.SubJenisBrgTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SubJenisBrgTree.Location = new System.Drawing.Point(3, 3);
            this.SubJenisBrgTree.Name = "SubJenisBrgTree";
            this.tableLayoutPanel1.SetRowSpan(this.SubJenisBrgTree, 3);
            this.SubJenisBrgTree.Size = new System.Drawing.Size(254, 576);
            this.SubJenisBrgTree.TabIndex = 0;
            // 
            // BarangGrid
            // 
            this.BarangGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BarangGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BarangGrid.Location = new System.Drawing.Point(263, 53);
            this.BarangGrid.Name = "BarangGrid";
            this.BarangGrid.Size = new System.Drawing.Size(602, 216);
            this.BarangGrid.TabIndex = 1;
            // 
            // SearchText
            // 
            this.SearchText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchText.Location = new System.Drawing.Point(59, 10);
            this.SearchText.Name = "SearchText";
            this.SearchText.Size = new System.Drawing.Size(543, 21);
            this.SearchText.TabIndex = 2;
            // 
            // SearchLabel
            // 
            this.SearchLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.SearchLabel.AutoSize = true;
            this.SearchLabel.Location = new System.Drawing.Point(3, 13);
            this.SearchLabel.Name = "SearchLabel";
            this.SearchLabel.Size = new System.Drawing.Size(47, 13);
            this.SearchLabel.TabIndex = 3;
            this.SearchLabel.Text = "&Search";
            // 
            // BarangTabControl
            // 
            this.BarangTabControl.Controls.Add(this.KlasifikasiTab);
            this.BarangTabControl.Controls.Add(this.PhotoTab);
            this.BarangTabControl.Controls.Add(this.PricingTab);
            this.BarangTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BarangTabControl.Location = new System.Drawing.Point(263, 275);
            this.BarangTabControl.Name = "BarangTabControl";
            this.BarangTabControl.SelectedIndex = 0;
            this.BarangTabControl.Size = new System.Drawing.Size(602, 304);
            this.BarangTabControl.TabIndex = 6;
            // 
            // KlasifikasiTab
            // 
            this.KlasifikasiTab.Controls.Add(this.button3);
            this.KlasifikasiTab.Controls.Add(this.button2);
            this.KlasifikasiTab.Controls.Add(this.SaveButton);
            this.KlasifikasiTab.Controls.Add(this.panel1);
            this.KlasifikasiTab.Location = new System.Drawing.Point(4, 22);
            this.KlasifikasiTab.Name = "KlasifikasiTab";
            this.KlasifikasiTab.Padding = new System.Windows.Forms.Padding(3);
            this.KlasifikasiTab.Size = new System.Drawing.Size(594, 278);
            this.KlasifikasiTab.TabIndex = 0;
            this.KlasifikasiTab.Text = "Data Barang";
            this.KlasifikasiTab.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(429, 251);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 32;
            this.button3.Text = "Delete";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(510, 251);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 31;
            this.button2.Text = "Exit";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.Location = new System.Drawing.Point(348, 251);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 30;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Beige;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.ColorPanel);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.comboBox5);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.ColorComboBox);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.MerkComboBox);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.KeteranganLabel);
            this.panel1.Controls.Add(this.SubJenisBrgComboBox);
            this.panel1.Controls.Add(this.JenisBrgComboBox);
            this.panel1.Controls.Add(this.KeteranganText);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.BrgNameText);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.BrgIDText);
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(579, 239);
            this.panel1.TabIndex = 29;
            // 
            // ColorPanel
            // 
            this.ColorPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ColorPanel.BackColor = System.Drawing.Color.Salmon;
            this.ColorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ColorPanel.Location = new System.Drawing.Point(503, 142);
            this.ColorPanel.Name = "ColorPanel";
            this.ColorPanel.Size = new System.Drawing.Size(64, 51);
            this.ColorPanel.TabIndex = 45;
            this.ColorPanel.MouseLeave += new System.EventHandler(this.ColorPanel_MouseLeave);
            this.ColorPanel.MouseHover += new System.EventHandler(this.ColorPanel_MouseHover);
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(302, 183);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 13);
            this.label9.TabIndex = 44;
            this.label9.Text = "[Reserved]";
            // 
            // comboBox5
            // 
            this.comboBox5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.comboBox5.Enabled = false;
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Location = new System.Drawing.Point(305, 199);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(262, 21);
            this.comboBox5.TabIndex = 43;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(302, 139);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 42;
            this.label8.Text = "Warna";
            // 
            // ColorComboBox
            // 
            this.ColorComboBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ColorComboBox.FormattingEnabled = true;
            this.ColorComboBox.Location = new System.Drawing.Point(305, 159);
            this.ColorComboBox.Name = "ColorComboBox";
            this.ColorComboBox.Size = new System.Drawing.Size(192, 21);
            this.ColorComboBox.TabIndex = 41;
            this.ColorComboBox.SelectedIndexChanged += new System.EventHandler(this.ColorComboBox_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(302, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 40;
            this.label7.Text = "Merk";
            // 
            // MerkComboBox
            // 
            this.MerkComboBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.MerkComboBox.FormattingEnabled = true;
            this.MerkComboBox.Location = new System.Drawing.Point(305, 115);
            this.MerkComboBox.Name = "MerkComboBox";
            this.MerkComboBox.Size = new System.Drawing.Size(262, 21);
            this.MerkComboBox.TabIndex = 39;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(302, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 38;
            this.label6.Text = "Sub Jenis";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(302, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 37;
            this.label5.Text = "Jenis";
            // 
            // KeteranganLabel
            // 
            this.KeteranganLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.KeteranganLabel.AutoSize = true;
            this.KeteranganLabel.Location = new System.Drawing.Point(12, 99);
            this.KeteranganLabel.Name = "KeteranganLabel";
            this.KeteranganLabel.Size = new System.Drawing.Size(73, 13);
            this.KeteranganLabel.TabIndex = 36;
            this.KeteranganLabel.Text = "Keterangan";
            // 
            // SubJenisBrgComboBox
            // 
            this.SubJenisBrgComboBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.SubJenisBrgComboBox.FormattingEnabled = true;
            this.SubJenisBrgComboBox.Location = new System.Drawing.Point(305, 75);
            this.SubJenisBrgComboBox.Name = "SubJenisBrgComboBox";
            this.SubJenisBrgComboBox.Size = new System.Drawing.Size(262, 21);
            this.SubJenisBrgComboBox.TabIndex = 35;
            // 
            // JenisBrgComboBox
            // 
            this.JenisBrgComboBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.JenisBrgComboBox.FormattingEnabled = true;
            this.JenisBrgComboBox.Location = new System.Drawing.Point(305, 35);
            this.JenisBrgComboBox.Name = "JenisBrgComboBox";
            this.JenisBrgComboBox.Size = new System.Drawing.Size(262, 21);
            this.JenisBrgComboBox.TabIndex = 34;
            this.JenisBrgComboBox.SelectedValueChanged += new System.EventHandler(this.JenisBrgComboBox_SelectedValueChanged);
            // 
            // KeteranganText
            // 
            this.KeteranganText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.KeteranganText.Location = new System.Drawing.Point(15, 115);
            this.KeteranganText.Multiline = true;
            this.KeteranganText.Name = "KeteranganText";
            this.KeteranganText.Size = new System.Drawing.Size(272, 105);
            this.KeteranganText.TabIndex = 33;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "Nama";
            // 
            // BrgNameText
            // 
            this.BrgNameText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.BrgNameText.Location = new System.Drawing.Point(15, 75);
            this.BrgNameText.Name = "BrgNameText";
            this.BrgNameText.Size = new System.Drawing.Size(272, 21);
            this.BrgNameText.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "Barang ID";
            // 
            // BrgIDText
            // 
            this.BrgIDText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.BrgIDText.Location = new System.Drawing.Point(15, 35);
            this.BrgIDText.Name = "BrgIDText";
            this.BrgIDText.Size = new System.Drawing.Size(272, 21);
            this.BrgIDText.TabIndex = 29;
            // 
            // PhotoTab
            // 
            this.PhotoTab.Location = new System.Drawing.Point(4, 22);
            this.PhotoTab.Name = "PhotoTab";
            this.PhotoTab.Padding = new System.Windows.Forms.Padding(3);
            this.PhotoTab.Size = new System.Drawing.Size(594, 278);
            this.PhotoTab.TabIndex = 1;
            this.PhotoTab.Text = "Photo";
            this.PhotoTab.UseVisualStyleBackColor = true;
            // 
            // PricingTab
            // 
            this.PricingTab.Controls.Add(this.dataGridView2);
            this.PricingTab.Location = new System.Drawing.Point(4, 22);
            this.PricingTab.Name = "PricingTab";
            this.PricingTab.Padding = new System.Windows.Forms.Padding(3);
            this.PricingTab.Size = new System.Drawing.Size(594, 278);
            this.PricingTab.TabIndex = 2;
            this.PricingTab.Text = "Pricing";
            this.PricingTab.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(6, 6);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(579, 270);
            this.dataGridView2.TabIndex = 2;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(673, 224);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 31;
            this.button4.Text = "Add New";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.BarangTabControl, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.BarangGrid, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.SubJenisBrgTree, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 310F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(868, 582);
            this.tableLayoutPanel1.TabIndex = 32;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Beige;
            this.panel2.Controls.Add(this.SearchLabel);
            this.panel2.Controls.Add(this.SearchText);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(263, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(602, 44);
            this.panel2.TabIndex = 33;
            // 
            // BarangListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 582);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.button4);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "BarangListForm";
            this.Text = "BarangListForm";
            ((System.ComponentModel.ISupportInitialize)(this.BarangGrid)).EndInit();
            this.BarangTabControl.ResumeLayout(false);
            this.KlasifikasiTab.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.PricingTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView SubJenisBrgTree;
        private System.Windows.Forms.DataGridView BarangGrid;
        private System.Windows.Forms.TextBox SearchText;
        private System.Windows.Forms.Label SearchLabel;
        private System.Windows.Forms.TabControl BarangTabControl;
        private System.Windows.Forms.TabPage KlasifikasiTab;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox ColorComboBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox MerkComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label KeteranganLabel;
        private System.Windows.Forms.ComboBox SubJenisBrgComboBox;
        private System.Windows.Forms.ComboBox JenisBrgComboBox;
        private System.Windows.Forms.TextBox KeteranganText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox BrgNameText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox BrgIDText;
        private System.Windows.Forms.TabPage PhotoTab;
        private System.Windows.Forms.TabPage PricingTab;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel ColorPanel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBox5;
    }
}