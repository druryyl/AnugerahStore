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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenuForm));
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.ribbonTab1 = new System.Windows.Forms.RibbonTab();
            this.PurchasingRibbonPanel = new System.Windows.Forms.RibbonPanel();
            this.PurchaseOrderButton = new System.Windows.Forms.RibbonButton();
            this.DeliveryButton = new System.Windows.Forms.RibbonButton();
            this.ReturButton = new System.Windows.Forms.RibbonButton();
            this.SalesRibbonPanel = new System.Windows.Forms.RibbonPanel();
            this.SellingButton = new System.Windows.Forms.RibbonButton();
            this.PreOrderButton = new System.Windows.Forms.RibbonButton();
            this.ribbonSeparator1 = new System.Windows.Forms.RibbonSeparator();
            this.PricingButton = new System.Windows.Forms.RibbonButton();
            this.StockManagementRibbonPanel = new System.Windows.Forms.RibbonPanel();
            this.StockOpnameButton = new System.Windows.Forms.RibbonButton();
            this.Adjustment = new System.Windows.Forms.RibbonButton();
            this.BarangPanel = new System.Windows.Forms.RibbonPanel();
            this.BarangButton = new System.Windows.Forms.RibbonButton();
            this.ribbonSeparator5 = new System.Windows.Forms.RibbonSeparator();
            this.JenisButton = new System.Windows.Forms.RibbonButton();
            this.SubJenisButton = new System.Windows.Forms.RibbonButton();
            this.ribbonSeparator6 = new System.Windows.Forms.RibbonSeparator();
            this.MerkButton = new System.Windows.Forms.RibbonButton();
            this.ColorButton = new System.Windows.Forms.RibbonButton();
            this.ribbonTab2 = new System.Windows.Forms.RibbonTab();
            this.BrgButton = new System.Windows.Forms.RibbonPanel();
            this.ribbonButton2 = new System.Windows.Forms.RibbonButton();
            this.ribbonSeparator2 = new System.Windows.Forms.RibbonSeparator();
            this.ribbonButton3 = new System.Windows.Forms.RibbonButton();
            this.ribbonSeparator3 = new System.Windows.Forms.RibbonSeparator();
            this.ribbonButton5 = new System.Windows.Forms.RibbonButton();
            this.ribbonButton6 = new System.Windows.Forms.RibbonButton();
            this.ribbonSeparator4 = new System.Windows.Forms.RibbonSeparator();
            this.ribbonButton7 = new System.Windows.Forms.RibbonButton();
            this.ribbonTab3 = new System.Windows.Forms.RibbonTab();
            this.SuspendLayout();
            // 
            // ribbon1
            // 
            this.ribbon1.CaptionBarVisible = false;
            this.ribbon1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ribbon1.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.Minimized = false;
            this.ribbon1.Name = "ribbon1";
            // 
            // 
            // 
            this.ribbon1.OrbDropDown.BorderRoundness = 8;
            this.ribbon1.OrbDropDown.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.OrbDropDown.Name = "";
            this.ribbon1.OrbDropDown.Size = new System.Drawing.Size(527, 447);
            this.ribbon1.OrbDropDown.TabIndex = 0;
            this.ribbon1.RibbonTabFont = new System.Drawing.Font("Trebuchet MS", 9F);
            this.ribbon1.Size = new System.Drawing.Size(1109, 136);
            this.ribbon1.TabIndex = 5;
            this.ribbon1.Tabs.Add(this.ribbonTab1);
            this.ribbon1.Tabs.Add(this.ribbonTab2);
            this.ribbon1.Tabs.Add(this.ribbonTab3);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 2, 20, 0);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue_2010;
            // 
            // ribbonTab1
            // 
            this.ribbonTab1.Name = "ribbonTab1";
            this.ribbonTab1.Panels.Add(this.PurchasingRibbonPanel);
            this.ribbonTab1.Panels.Add(this.SalesRibbonPanel);
            this.ribbonTab1.Panels.Add(this.StockManagementRibbonPanel);
            this.ribbonTab1.Panels.Add(this.BarangPanel);
            this.ribbonTab1.Text = "Transaction";
            // 
            // PurchasingRibbonPanel
            // 
            this.PurchasingRibbonPanel.Items.Add(this.PurchaseOrderButton);
            this.PurchasingRibbonPanel.Items.Add(this.DeliveryButton);
            this.PurchasingRibbonPanel.Items.Add(this.ReturButton);
            this.PurchasingRibbonPanel.Name = "PurchasingRibbonPanel";
            this.PurchasingRibbonPanel.Text = "Purchasing";
            // 
            // PurchaseOrderButton
            // 
            this.PurchaseOrderButton.Image = ((System.Drawing.Image)(resources.GetObject("PurchaseOrderButton.Image")));
            this.PurchaseOrderButton.LargeImage = ((System.Drawing.Image)(resources.GetObject("PurchaseOrderButton.LargeImage")));
            this.PurchaseOrderButton.Name = "PurchaseOrderButton";
            this.PurchaseOrderButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("PurchaseOrderButton.SmallImage")));
            this.PurchaseOrderButton.Text = "Purchase Order";
            // 
            // DeliveryButton
            // 
            this.DeliveryButton.Image = ((System.Drawing.Image)(resources.GetObject("DeliveryButton.Image")));
            this.DeliveryButton.LargeImage = ((System.Drawing.Image)(resources.GetObject("DeliveryButton.LargeImage")));
            this.DeliveryButton.Name = "DeliveryButton";
            this.DeliveryButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("DeliveryButton.SmallImage")));
            this.DeliveryButton.Text = "Delivery Order";
            // 
            // ReturButton
            // 
            this.ReturButton.Image = ((System.Drawing.Image)(resources.GetObject("ReturButton.Image")));
            this.ReturButton.LargeImage = ((System.Drawing.Image)(resources.GetObject("ReturButton.LargeImage")));
            this.ReturButton.Name = "ReturButton";
            this.ReturButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("ReturButton.SmallImage")));
            this.ReturButton.Text = "Return";
            // 
            // SalesRibbonPanel
            // 
            this.SalesRibbonPanel.Items.Add(this.SellingButton);
            this.SalesRibbonPanel.Items.Add(this.PreOrderButton);
            this.SalesRibbonPanel.Items.Add(this.ribbonSeparator1);
            this.SalesRibbonPanel.Items.Add(this.PricingButton);
            this.SalesRibbonPanel.Name = "SalesRibbonPanel";
            this.SalesRibbonPanel.Text = "Sales";
            // 
            // SellingButton
            // 
            this.SellingButton.Image = ((System.Drawing.Image)(resources.GetObject("SellingButton.Image")));
            this.SellingButton.LargeImage = ((System.Drawing.Image)(resources.GetObject("SellingButton.LargeImage")));
            this.SellingButton.Name = "SellingButton";
            this.SellingButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("SellingButton.SmallImage")));
            this.SellingButton.Text = "Selling";
            this.SellingButton.Click += new System.EventHandler(this.SellingButton_Click);
            // 
            // PreOrderButton
            // 
            this.PreOrderButton.Image = ((System.Drawing.Image)(resources.GetObject("PreOrderButton.Image")));
            this.PreOrderButton.LargeImage = ((System.Drawing.Image)(resources.GetObject("PreOrderButton.LargeImage")));
            this.PreOrderButton.Name = "PreOrderButton";
            this.PreOrderButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("PreOrderButton.SmallImage")));
            this.PreOrderButton.Text = "Pre-Order";
            // 
            // ribbonSeparator1
            // 
            this.ribbonSeparator1.Name = "ribbonSeparator1";
            // 
            // PricingButton
            // 
            this.PricingButton.Image = ((System.Drawing.Image)(resources.GetObject("PricingButton.Image")));
            this.PricingButton.LargeImage = ((System.Drawing.Image)(resources.GetObject("PricingButton.LargeImage")));
            this.PricingButton.Name = "PricingButton";
            this.PricingButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("PricingButton.SmallImage")));
            this.PricingButton.Text = "Pricing";
            this.PricingButton.Click += new System.EventHandler(this.PricingButton_Click);
            // 
            // StockManagementRibbonPanel
            // 
            this.StockManagementRibbonPanel.Items.Add(this.StockOpnameButton);
            this.StockManagementRibbonPanel.Items.Add(this.Adjustment);
            this.StockManagementRibbonPanel.Name = "StockManagementRibbonPanel";
            this.StockManagementRibbonPanel.Text = "Stock";
            // 
            // StockOpnameButton
            // 
            this.StockOpnameButton.Image = ((System.Drawing.Image)(resources.GetObject("StockOpnameButton.Image")));
            this.StockOpnameButton.LargeImage = ((System.Drawing.Image)(resources.GetObject("StockOpnameButton.LargeImage")));
            this.StockOpnameButton.Name = "StockOpnameButton";
            this.StockOpnameButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("StockOpnameButton.SmallImage")));
            this.StockOpnameButton.Text = "Posting";
            // 
            // Adjustment
            // 
            this.Adjustment.Image = ((System.Drawing.Image)(resources.GetObject("Adjustment.Image")));
            this.Adjustment.LargeImage = ((System.Drawing.Image)(resources.GetObject("Adjustment.LargeImage")));
            this.Adjustment.Name = "Adjustment";
            this.Adjustment.SmallImage = ((System.Drawing.Image)(resources.GetObject("Adjustment.SmallImage")));
            this.Adjustment.Text = "Adjustment";
            this.Adjustment.Click += new System.EventHandler(this.Adjustment_Click);
            // 
            // BarangPanel
            // 
            this.BarangPanel.Items.Add(this.BarangButton);
            this.BarangPanel.Items.Add(this.ribbonSeparator5);
            this.BarangPanel.Items.Add(this.JenisButton);
            this.BarangPanel.Items.Add(this.SubJenisButton);
            this.BarangPanel.Items.Add(this.ribbonSeparator6);
            this.BarangPanel.Items.Add(this.MerkButton);
            this.BarangPanel.Items.Add(this.ColorButton);
            this.BarangPanel.Name = "BarangPanel";
            this.BarangPanel.Text = "Barang";
            // 
            // BarangButton
            // 
            this.BarangButton.Image = ((System.Drawing.Image)(resources.GetObject("BarangButton.Image")));
            this.BarangButton.LargeImage = ((System.Drawing.Image)(resources.GetObject("BarangButton.LargeImage")));
            this.BarangButton.Name = "BarangButton";
            this.BarangButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("BarangButton.SmallImage")));
            this.BarangButton.Text = "Barang";
            this.BarangButton.Click += new System.EventHandler(this.BarangButton_Click);
            // 
            // ribbonSeparator5
            // 
            this.ribbonSeparator5.Name = "ribbonSeparator5";
            // 
            // JenisButton
            // 
            this.JenisButton.Image = ((System.Drawing.Image)(resources.GetObject("JenisButton.Image")));
            this.JenisButton.LargeImage = ((System.Drawing.Image)(resources.GetObject("JenisButton.LargeImage")));
            this.JenisButton.Name = "JenisButton";
            this.JenisButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("JenisButton.SmallImage")));
            this.JenisButton.Text = "Jenis";
            this.JenisButton.Click += new System.EventHandler(this.JenisButton_Click);
            // 
            // SubJenisButton
            // 
            this.SubJenisButton.Image = ((System.Drawing.Image)(resources.GetObject("SubJenisButton.Image")));
            this.SubJenisButton.LargeImage = ((System.Drawing.Image)(resources.GetObject("SubJenisButton.LargeImage")));
            this.SubJenisButton.Name = "SubJenisButton";
            this.SubJenisButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("SubJenisButton.SmallImage")));
            this.SubJenisButton.Text = "Sub Jenis";
            this.SubJenisButton.Click += new System.EventHandler(this.SubJenisButton_Click);
            // 
            // ribbonSeparator6
            // 
            this.ribbonSeparator6.Name = "ribbonSeparator6";
            // 
            // MerkButton
            // 
            this.MerkButton.Image = ((System.Drawing.Image)(resources.GetObject("MerkButton.Image")));
            this.MerkButton.LargeImage = ((System.Drawing.Image)(resources.GetObject("MerkButton.LargeImage")));
            this.MerkButton.Name = "MerkButton";
            this.MerkButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("MerkButton.SmallImage")));
            this.MerkButton.Text = "Merk";
            // 
            // ColorButton
            // 
            this.ColorButton.Image = ((System.Drawing.Image)(resources.GetObject("ColorButton.Image")));
            this.ColorButton.LargeImage = ((System.Drawing.Image)(resources.GetObject("ColorButton.LargeImage")));
            this.ColorButton.Name = "ColorButton";
            this.ColorButton.SmallImage = ((System.Drawing.Image)(resources.GetObject("ColorButton.SmallImage")));
            this.ColorButton.Text = "Color";
            this.ColorButton.Click += new System.EventHandler(this.ColorButton_Click);
            // 
            // ribbonTab2
            // 
            this.ribbonTab2.Name = "ribbonTab2";
            this.ribbonTab2.Panels.Add(this.BrgButton);
            this.ribbonTab2.Text = "Master Data";
            // 
            // BrgButton
            // 
            this.BrgButton.Items.Add(this.ribbonButton2);
            this.BrgButton.Items.Add(this.ribbonSeparator3);
            this.BrgButton.Items.Add(this.ribbonButton5);
            this.BrgButton.Items.Add(this.ribbonButton6);
            this.BrgButton.Items.Add(this.ribbonButton7);
            this.BrgButton.Name = "BrgButton";
            this.BrgButton.Text = "Barang Items";
            // 
            // ribbonButton2
            // 
            this.ribbonButton2.DropDownItems.Add(this.ribbonSeparator2);
            this.ribbonButton2.DropDownItems.Add(this.ribbonButton3);
            this.ribbonButton2.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton2.Image")));
            this.ribbonButton2.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton2.LargeImage")));
            this.ribbonButton2.Name = "ribbonButton2";
            this.ribbonButton2.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton2.SmallImage")));
            this.ribbonButton2.Text = "Barang Items";
            this.ribbonButton2.Click += new System.EventHandler(this.ribbonButton2_Click);
            // 
            // ribbonSeparator2
            // 
            this.ribbonSeparator2.Name = "ribbonSeparator2";
            // 
            // ribbonButton3
            // 
            this.ribbonButton3.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton3.Image")));
            this.ribbonButton3.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton3.LargeImage")));
            this.ribbonButton3.Name = "ribbonButton3";
            this.ribbonButton3.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton3.SmallImage")));
            this.ribbonButton3.Text = "ribbonButton3";
            // 
            // ribbonSeparator3
            // 
            this.ribbonSeparator3.Name = "ribbonSeparator3";
            // 
            // ribbonButton5
            // 
            this.ribbonButton5.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton5.Image")));
            this.ribbonButton5.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton5.LargeImage")));
            this.ribbonButton5.Name = "ribbonButton5";
            this.ribbonButton5.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton5.SmallImage")));
            this.ribbonButton5.Text = "ribbonButton5";
            // 
            // ribbonButton6
            // 
            this.ribbonButton6.DropDownItems.Add(this.ribbonSeparator4);
            this.ribbonButton6.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton6.Image")));
            this.ribbonButton6.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton6.LargeImage")));
            this.ribbonButton6.Name = "ribbonButton6";
            this.ribbonButton6.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton6.SmallImage")));
            this.ribbonButton6.Text = "ribbonButton6";
            // 
            // ribbonSeparator4
            // 
            this.ribbonSeparator4.Name = "ribbonSeparator4";
            // 
            // ribbonButton7
            // 
            this.ribbonButton7.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton7.Image")));
            this.ribbonButton7.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton7.LargeImage")));
            this.ribbonButton7.Name = "ribbonButton7";
            this.ribbonButton7.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton7.SmallImage")));
            this.ribbonButton7.Text = "ribbonButton7";
            // 
            // ribbonTab3
            // 
            this.ribbonTab3.Name = "ribbonTab3";
            this.ribbonTab3.Text = "Report";
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AnugerahWinform.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1109, 731);
            this.Controls.Add(this.ribbon1);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.Name = "MainMenuForm";
            this.Text = "Anugerah SPS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainMenuForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.RibbonTab ribbonTab1;
        private System.Windows.Forms.RibbonPanel PurchasingRibbonPanel;
        private System.Windows.Forms.RibbonTab ribbonTab2;
        private System.Windows.Forms.RibbonTab ribbonTab3;
        private System.Windows.Forms.RibbonButton PurchaseOrderButton;
        private System.Windows.Forms.RibbonButton DeliveryButton;
        private System.Windows.Forms.RibbonButton ReturButton;
        private System.Windows.Forms.RibbonPanel SalesRibbonPanel;
        private System.Windows.Forms.RibbonButton SellingButton;
        private System.Windows.Forms.RibbonButton PreOrderButton;
        private System.Windows.Forms.RibbonPanel StockManagementRibbonPanel;
        private System.Windows.Forms.RibbonButton StockOpnameButton;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator1;
        private System.Windows.Forms.RibbonButton PricingButton;
        private System.Windows.Forms.RibbonPanel BrgButton;
        private System.Windows.Forms.RibbonButton ribbonButton2;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator2;
        private System.Windows.Forms.RibbonButton ribbonButton3;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator3;
        private System.Windows.Forms.RibbonButton ribbonButton5;
        private System.Windows.Forms.RibbonButton ribbonButton6;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator4;
        private System.Windows.Forms.RibbonButton ribbonButton7;
        private System.Windows.Forms.RibbonButton Adjustment;
        private System.Windows.Forms.RibbonPanel BarangPanel;
        private System.Windows.Forms.RibbonButton BarangButton;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator5;
        private System.Windows.Forms.RibbonButton JenisButton;
        private System.Windows.Forms.RibbonButton SubJenisButton;
        private System.Windows.Forms.RibbonButton MerkButton;
        private System.Windows.Forms.RibbonButton ColorButton;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator6;
    }
}

