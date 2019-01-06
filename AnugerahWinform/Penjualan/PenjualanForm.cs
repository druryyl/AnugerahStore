using AnugerahBackend.StokBarang.BL;
using AnugerahBackend.StokBarang.Model;
using AnugerahWinform.Support;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnugerahWinform.Penjualan
{
    public partial class PenjualanForm : Form
    {
        IBrgBL _brgBL;
        public PenjualanForm()
        {
            InitializeComponent();

            _brgBL = new BrgBL();
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            var searchForm = new SearchingForm<BrgSearchResultModel>(_brgBL);
            searchForm.ShowDialog();
        }
    }
}
