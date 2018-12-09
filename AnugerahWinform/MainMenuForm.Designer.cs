namespace AnugerahWinform
{
    partial class MainMenuForm
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
            this.MainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.barangToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ColorMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.MerkMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.JenisBrgMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.sT08SubJenisBrgToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TipeBrgMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.BarangMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.StokOpnameMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.InfoStokMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.pembelianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bL01DistributorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.bL02OrderBeliToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bL03PembelianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.bL04InfoPembelianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.penjualanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jL01HargaJualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.jL02PenjualanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.jL03InfoPenjualanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.BarangShortcutButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.MainMenuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenuStrip
            // 
            this.MainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.barangToolStripMenuItem,
            this.pembelianToolStripMenuItem,
            this.penjualanToolStripMenuItem});
            this.MainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MainMenuStrip.Name = "MainMenuStrip";
            this.MainMenuStrip.Size = new System.Drawing.Size(1109, 24);
            this.MainMenuStrip.TabIndex = 1;
            this.MainMenuStrip.Text = "menuStrip1";
            // 
            // barangToolStripMenuItem
            // 
            this.barangToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ColorMenu,
            this.MerkMenu,
            this.JenisBrgMenu,
            this.sT08SubJenisBrgToolStripMenuItem,
            this.TipeBrgMenu,
            this.BarangMenu,
            this.toolStripMenuItem1,
            this.StokOpnameMenu,
            this.toolStripMenuItem6,
            this.InfoStokMenu});
            this.barangToolStripMenuItem.Name = "barangToolStripMenuItem";
            this.barangToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.barangToolStripMenuItem.Text = "&Stok";
            // 
            // ColorMenu
            // 
            this.ColorMenu.Name = "ColorMenu";
            this.ColorMenu.Size = new System.Drawing.Size(192, 22);
            this.ColorMenu.Text = "ST01 - &Color...";
            // 
            // MerkMenu
            // 
            this.MerkMenu.Name = "MerkMenu";
            this.MerkMenu.Size = new System.Drawing.Size(192, 22);
            this.MerkMenu.Text = "ST02 - &Merk...";
            // 
            // JenisBrgMenu
            // 
            this.JenisBrgMenu.Name = "JenisBrgMenu";
            this.JenisBrgMenu.Size = new System.Drawing.Size(192, 22);
            this.JenisBrgMenu.Text = "ST03 - &Jenis Brg...";
            this.JenisBrgMenu.Click += new System.EventHandler(this.JenisBrgMenu_Click);
            // 
            // sT08SubJenisBrgToolStripMenuItem
            // 
            this.sT08SubJenisBrgToolStripMenuItem.Name = "sT08SubJenisBrgToolStripMenuItem";
            this.sT08SubJenisBrgToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.sT08SubJenisBrgToolStripMenuItem.Text = "ST08 - Sub Jenis Brg...";
            this.sT08SubJenisBrgToolStripMenuItem.Click += new System.EventHandler(this.sT08SubJenisBrgToolStripMenuItem_Click);
            // 
            // TipeBrgMenu
            // 
            this.TipeBrgMenu.Name = "TipeBrgMenu";
            this.TipeBrgMenu.Size = new System.Drawing.Size(192, 22);
            this.TipeBrgMenu.Text = "ST04 - &Tipe Brg...";
            this.TipeBrgMenu.Click += new System.EventHandler(this.TipeBrgMenu_Click);
            // 
            // BarangMenu
            // 
            this.BarangMenu.Name = "BarangMenu";
            this.BarangMenu.Size = new System.Drawing.Size(192, 22);
            this.BarangMenu.Text = "ST05 - &Barang...";
            this.BarangMenu.Click += new System.EventHandler(this.BarangMenu_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(189, 6);
            // 
            // StokOpnameMenu
            // 
            this.StokOpnameMenu.Name = "StokOpnameMenu";
            this.StokOpnameMenu.Size = new System.Drawing.Size(192, 22);
            this.StokOpnameMenu.Text = "ST06 - Stop &Opname...";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(189, 6);
            // 
            // InfoStokMenu
            // 
            this.InfoStokMenu.Name = "InfoStokMenu";
            this.InfoStokMenu.Size = new System.Drawing.Size(192, 22);
            this.InfoStokMenu.Text = "ST07 - Info &Stok...";
            // 
            // pembelianToolStripMenuItem
            // 
            this.pembelianToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bL01DistributorToolStripMenuItem,
            this.toolStripMenuItem2,
            this.bL02OrderBeliToolStripMenuItem,
            this.bL03PembelianToolStripMenuItem,
            this.toolStripMenuItem3,
            this.bL04InfoPembelianToolStripMenuItem});
            this.pembelianToolStripMenuItem.Name = "pembelianToolStripMenuItem";
            this.pembelianToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.pembelianToolStripMenuItem.Text = "Pembelian";
            // 
            // bL01DistributorToolStripMenuItem
            // 
            this.bL01DistributorToolStripMenuItem.Name = "bL01DistributorToolStripMenuItem";
            this.bL01DistributorToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.bL01DistributorToolStripMenuItem.Text = "BL01 - Distributor...";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(196, 6);
            // 
            // bL02OrderBeliToolStripMenuItem
            // 
            this.bL02OrderBeliToolStripMenuItem.Name = "bL02OrderBeliToolStripMenuItem";
            this.bL02OrderBeliToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.bL02OrderBeliToolStripMenuItem.Text = "BL02 - Order Beli...";
            // 
            // bL03PembelianToolStripMenuItem
            // 
            this.bL03PembelianToolStripMenuItem.Name = "bL03PembelianToolStripMenuItem";
            this.bL03PembelianToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.bL03PembelianToolStripMenuItem.Text = "BL03 - Pembelian...";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(196, 6);
            // 
            // bL04InfoPembelianToolStripMenuItem
            // 
            this.bL04InfoPembelianToolStripMenuItem.Name = "bL04InfoPembelianToolStripMenuItem";
            this.bL04InfoPembelianToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.bL04InfoPembelianToolStripMenuItem.Text = "BL04 - Info Pembelian...";
            // 
            // penjualanToolStripMenuItem
            // 
            this.penjualanToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jL01HargaJualToolStripMenuItem,
            this.toolStripMenuItem4,
            this.jL02PenjualanToolStripMenuItem,
            this.toolStripMenuItem5,
            this.jL03InfoPenjualanToolStripMenuItem});
            this.penjualanToolStripMenuItem.Name = "penjualanToolStripMenuItem";
            this.penjualanToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.penjualanToolStripMenuItem.Text = "Penjualan";
            // 
            // jL01HargaJualToolStripMenuItem
            // 
            this.jL01HargaJualToolStripMenuItem.Name = "jL01HargaJualToolStripMenuItem";
            this.jL01HargaJualToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.jL01HargaJualToolStripMenuItem.Text = "JL01 - Harga Jual...";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(189, 6);
            // 
            // jL02PenjualanToolStripMenuItem
            // 
            this.jL02PenjualanToolStripMenuItem.Name = "jL02PenjualanToolStripMenuItem";
            this.jL02PenjualanToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.jL02PenjualanToolStripMenuItem.Text = "JL02 - Penjualan...";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(189, 6);
            // 
            // jL03InfoPenjualanToolStripMenuItem
            // 
            this.jL03InfoPenjualanToolStripMenuItem.Name = "jL03InfoPenjualanToolStripMenuItem";
            this.jL03InfoPenjualanToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.jL03InfoPenjualanToolStripMenuItem.Text = "JL03 - Info Penjualan...";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1109, 83);
            this.panel1.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.button5, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.BarangShortcutButton, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1109, 83);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // BarangShortcutButton
            // 
            this.BarangShortcutButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BarangShortcutButton.Image = global::AnugerahWinform.Properties.Resources.favicon;
            this.BarangShortcutButton.Location = new System.Drawing.Point(183, 3);
            this.BarangShortcutButton.Name = "BarangShortcutButton";
            this.BarangShortcutButton.Size = new System.Drawing.Size(84, 77);
            this.BarangShortcutButton.TabIndex = 0;
            this.BarangShortcutButton.Text = "Pricing";
            this.BarangShortcutButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BarangShortcutButton.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Image = global::AnugerahWinform.Properties.Resources.favicon;
            this.button1.Location = new System.Drawing.Point(93, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 77);
            this.button1.TabIndex = 1;
            this.button1.Text = "Items";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Image = global::AnugerahWinform.Properties.Resources.favicon;
            this.button2.Location = new System.Drawing.Point(3, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(84, 77);
            this.button2.TabIndex = 2;
            this.button2.Text = "Stock";
            this.button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button3.Image = global::AnugerahWinform.Properties.Resources.favicon;
            this.button3.Location = new System.Drawing.Point(453, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(84, 77);
            this.button3.TabIndex = 3;
            this.button3.Text = "Sale";
            this.button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button4.Image = global::AnugerahWinform.Properties.Resources.favicon;
            this.button4.Location = new System.Drawing.Point(363, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(84, 77);
            this.button4.TabIndex = 4;
            this.button4.Text = "Purchasing";
            this.button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button5.Image = global::AnugerahWinform.Properties.Resources.favicon;
            this.button5.Location = new System.Drawing.Point(273, 3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(84, 77);
            this.button5.TabIndex = 5;
            this.button5.Text = "Sale";
            this.button5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button5.UseVisualStyleBackColor = true;
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AnugerahWinform.Properties.Resources.anugerah_sps;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1109, 731);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.MainMenuStrip);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsMdiContainer = true;
            this.Name = "MainMenuForm";
            this.Text = "Anugerah Store";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainMenuForm_Load);
            this.MainMenuStrip.ResumeLayout(false);
            this.MainMenuStrip.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem barangToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ColorMenu;
        private System.Windows.Forms.ToolStripMenuItem MerkMenu;
        private System.Windows.Forms.ToolStripMenuItem JenisBrgMenu;
        private System.Windows.Forms.ToolStripMenuItem TipeBrgMenu;
        private System.Windows.Forms.ToolStripMenuItem BarangMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem StokOpnameMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem InfoStokMenu;
        private System.Windows.Forms.ToolStripMenuItem pembelianToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bL01DistributorToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem bL02OrderBeliToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bL03PembelianToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem bL04InfoPembelianToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem penjualanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jL01HargaJualToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem jL02PenjualanToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem jL03InfoPenjualanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sT08SubJenisBrgToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button BarangShortcutButton;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}

