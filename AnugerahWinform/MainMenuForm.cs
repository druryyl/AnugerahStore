using AnugerahWinform.Accounting;
using AnugerahWinform.Keuangan;
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
    }
}
