using AnugerahWinform.Accounting;
using AnugerahWinform.Keuangan;
using AnugerahWinform.Pembelian;
using AnugerahWinform.Penjualan;
using AnugerahWinform.StokBarang;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnugerahWinform
{
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {
            Controls.OfType<MdiClient>().FirstOrDefault().BackColor = Color.DarkGray;
        }
        private void BarangButton_Click(object sender, EventArgs e)
        {
            var form = new BarangListForm
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen
            };
            form.Show();
        }
        private void JenisButton_Click(object sender, EventArgs e)
        {
            var form = new JenisBrgListForm
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen
            };
            form.Show();
        }
        private void SubJenisButton_Click(object sender, EventArgs e)
        {
            var form = new SubJenisBrgListForm
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen
            };
            form.Show();
        }

        private void ColorButton_Click(object sender, EventArgs e)
        {
            var form = new ColorForm
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen
            };
            form.Show();
        }

        private void PricingButton_Click(object sender, EventArgs e)
        {
            var form = new PricingForm
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen
            };
            form.Show();
        }

        private void ribbonButton2_Click(object sender, EventArgs e)
        {
            var form = new KryotonTestForm
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterParent
            };
            form.Show();
        }

        private void SellingButton_Click(object sender, EventArgs e)
        {
            var form = new PenjualanForm
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen
            };
            form.Show();
        }

        private void Adjustment_Click(object sender, EventArgs e)
        {
            var form = new StokAdjustmentForm
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen
            };
            form.Show();
        }

        private void KasirButton_Click(object sender, EventArgs e)
        {
            var form = new KasirForm
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen
            };
            form.Show();
        }

        private void LaporanKasirButton_Click(object sender, EventArgs e)
        {
            var form = new LaporanKasirForm
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen
            };
            form.Show();
        }

        private void LaporanPenjualanButton_Click(object sender, EventArgs e)
        {
            var form = new LaporanPenjualanForm
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen
            };
            form.Show();
        }

        private void BiayaButton_Click(object sender, EventArgs e)
        {
            var form = new BiayaForm
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen
            };
            form.Show();
        }

        private void KasBonButton_Click(object sender, EventArgs e)
        {
            var form = new KasBonForm
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen
            };
            form.Show();
        }

        private void LunasKasBonButton_Click(object sender, EventArgs e)
        {
            var form = new LunasKasBonForm
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen
            };
            form.Show();
        }

        private void LaporanBPKasButton_Click(object sender, EventArgs e)
        {
            var form = new BPKasInfoForm
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen
            };
            form.Show();
        }

        private void LapPiutangButton_Click(object sender, EventArgs e)
        {
            var form = new BPPiutangInfoForm
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen
            };
            form.Show();
        }

        private void DepositJualButton_Click(object sender, EventArgs e)
        {
            var form = new DepositForm
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen
            };
            form.Show();
        }

        private void LapHutangButton_Click(object sender, EventArgs e)
        {
            var form = new BPHutangInfoForm
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen
            };
            form.Show();
        }

        private void ReturDepositButton_Click(object sender, EventArgs e)
        {
            var form = new ReturDepositForm
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen
            };
            form.Show();
        }

        private void LaporanBiayaButton_Click(object sender, EventArgs e)
        {
            var form = new BiayaInfoForm
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen
            };
            form.Show();
        }

        private void BukuStokDetilInfoButton_Click(object sender, EventArgs e)
        {
            var form = new BukuStokInfoForm
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen
            };
            form.Show();
        }

        private void PurchaseOrderButton_Click(object sender, EventArgs e)
        {
            var form = new PurchaseForm
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen
            };
            form.Show();
        }

        private void DeliveryButton_Click(object sender, EventArgs e)
        {
            var form = new ReceiptForm
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen
            };
            form.Show();
        }

        private void SupplierButton_Click(object sender, EventArgs e)
        {
            var form = new SupplierForm
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen
            };
            form.Show();
        }

        private void LaporanPurchaseButton_Click(object sender, EventArgs e)
        {
            var form = new PurchaseInfoForm
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen
            };
            form.Show();
        }

        private void LaporanTerimaBrgButton_Click(object sender, EventArgs e)
        {
            var form = new ReceiptInfoForm
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen
            };
            form.Show();
        }

        private void CustomerButton_Click(object sender, EventArgs e)
        {
            var form = new CustomerForm
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen
            };
            form.Show();
        }
    }
}
