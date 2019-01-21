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
        private IStokBL _stokBL;

        public StokAdjustmentForm()
        {
            InitializeComponent();
            _brgBL = new BrgBL();
            _stokBL = new StokBL();


        }

        private void BrgGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F1)
            {
                var searchForm = new SearchingForm<BrgSearchResultModel>(_brgBL);
                searchForm.ShowDialog();
            }
        }

        private void BrgGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                SearchBrg(e.RowIndex);
                ShowDataBrgGrid(e.RowIndex);
            }
        }

        private void SearchBrg(int rowIndex)
        {
            var searchForm = new SearchingForm<BrgSearchResultModel>(_brgBL);
            var resultDialog = searchForm.ShowDialog();
            if(resultDialog == DialogResult.OK)
            {
                var result = searchForm.SelectedDataKey;
                var row = BrgGrid.Rows[rowIndex];
                row.Cells["BrgKodeCol"].Value = result;
                row.Cells["BrgQtyAdjustCol"].Selected = true;
            }
        }

        private void ShowDataBrgGrid(int rowIndex)
        {
            //  get key (KodeBrg)
            var row = BrgGrid.Rows[rowIndex];
            var kodeBrg = row.Cells["BrgKodeCol"].Value.ToString();

            //  get nama barang
            var brgName = "";
            var brg = _brgBL.GetData(kodeBrg);
            if(brg != null)
                brgName = brg.BrgName;

            //  get stok
            long qtyAwal = _stokBL.GetStok(kodeBrg);
            row.Cells["BrgQtyAwalCol"].Value = qtyAwal;

            //  tampilkan di grid
            row.Cells["BrgNamaCol"].Value = brgName;
            row.Cells["BrgQtyAwalCol"].Value = qtyAwal;
        }

        private void StokAdjustmentForm_Load(object sender, EventArgs e)
        {
            BrgGrid.Rows.Add("A11","", "Karet Rakel 23 mm", 4112, 5, 4117, 52450);

            //BrgGrid.Columns["BrgQtyAwalCol"].DefaultCellStyle.Format = "N2";
            //BrgQtyAwalCol.DefaultCellStyle.Format = "N2";
            //BrgQtyAdjustCol.DefaultCellStyle.Format = "N2";
            //BrgQtyAkhirCol.DefaultCellStyle.Format = "N2";
            //BrgHppCol.DefaultCellStyle.Format = "N2";
        }

        private void BrgGrid_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            var theGrid = (DataGridView)sender;
            if(e.ColumnIndex == BrgQtyAwalCol.Index)
            {
                var string1 = e.FormattedValue.ToString();
                theGrid.Rows[e.RowIndex].Cells["BrgQtyAwalCol"].Value = Convert.ToInt32(string1); 
            }
        }

        private void BrgGrid_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            string brgID = BrgGrid.Rows[e.RowIndex].Cells["BrgKodeCol"].Value.ToString();
            string namaBrg = BrgGrid.Rows[e.RowIndex].Cells["BrgNamaCol"].Value.ToString();
            long qtyAwal = Convert.ToInt64(BrgGrid.Rows[e.RowIndex].Cells["BrgQtyAwalCol"].Value);
            long qtyAdjust = Convert.ToInt64(BrgGrid.Rows[e.RowIndex].Cells["BrgQtyAdjustCol"].Value);
            long qtyAkhir = Convert.ToInt64(BrgGrid.Rows[e.RowIndex].Cells["BrgQtyAkhirCol"].Value);
            long hpp = Convert.ToInt64(BrgGrid.Rows[e.RowIndex].Cells["BrgHppCol"].Value);

            object[] rowData = { brgID, "", namaBrg, qtyAwal, qtyAdjust, qtyAkhir, hpp };
            BrgGrid.Rows.Add(rowData);

        }
    }
}
