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

namespace AnugerahWinform.StokBarang
{
    public partial class StokAdjustmentForm : Form
    {
        private IBrgBL _brgBL;
        public StokAdjustmentForm()
        {
            InitializeComponent();
            _brgBL = new BrgBL();
        }

        private void BrgGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F1)
            {
                var searchForm = new SearchingForm<BrgSearchResultModel>(_brgBL);
                searchForm.ShowDialog();
            }
        }
    }
}
