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
            this.sT08SubJenisBrgToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuStrip.SuspendLayout();
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
            this.MainMenuStrip.Size = new System.Drawing.Size(900, 24);
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
            // sT08SubJenisBrgToolStripMenuItem
            // 
            this.sT08SubJenisBrgToolStripMenuItem.Name = "sT08SubJenisBrgToolStripMenuItem";
            this.sT08SubJenisBrgToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.sT08SubJenisBrgToolStripMenuItem.Text = "ST08 - Sub Jenis Brg...";
            this.sT08SubJenisBrgToolStripMenuItem.Click += new System.EventHandler(this.sT08SubJenisBrgToolStripMenuItem_Click);
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(900, 659);
            this.Controls.Add(this.MainMenuStrip);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsMdiContainer = true;
            this.Name = "MainMenuForm";
            this.Text = "Anugerah Store";
            this.MainMenuStrip.ResumeLayout(false);
            this.MainMenuStrip.PerformLayout();
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
    }
}

