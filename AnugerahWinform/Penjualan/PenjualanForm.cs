﻿using AnugerahBackend.Penjualan.BL;
using AnugerahBackend.Penjualan.Model;
using AnugerahBackend.StokBarang.BL;
using AnugerahBackend.StokBarang.Model;
using AnugerahWinform.Support;
using Ics.Helper.StringDateTime;
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
        private IBrgBL _brgBL;
        private IStokBL _stokBL;
        private IPenjualanBL _penjualanBL;
        private ICustomerBL _customerBL;

        public PenjualanForm()
        {
            InitializeComponent();
            _penjualanBL = new PenjualanBL();
            _brgBL = new BrgBL();
            _stokBL = new StokBL();

        }

        private void PenjualanForm_Load(object sender, EventArgs e)
        {
            AddRow();
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
        private void BrgGrid_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            var brgName = DetilAdjTable.Rows[e.RowIndex]["BrgName"].ToString();
            if ((brgName.Trim() != "") && (e.RowIndex == DetilAdjTable.Rows.Count - 1))
                AddRow();

        }
        private void BrgGrid_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                ShowDataBrgGrid(e.RowIndex);
            }
        }

        private void SearchBrg(int rowIndex)
        {
            var searchForm = new SearchingForm<BrgSearchResultModel>(_brgBL, true);
            var resultDialog = searchForm.ShowDialog();
            if (resultDialog == DialogResult.OK)
            {
                var result = searchForm.SelectedDataKey;
                DetilAdjTable.Rows[rowIndex]["BrgID"] = result;
            }
        }

        private void SearchKodeTrs()
        {
            var searchForm = new SearchingForm<PenjualanSearchModel>(_penjualanBL, true);
            var resultDialog = searchForm.ShowDialog();
            if (resultDialog == DialogResult.OK)
            {
                var result = searchForm.SelectedDataKey;
                NoTrsTextBox.Text = result;
            }
        }

        private void ShowDataBrgGrid(int rowIndex)
        {
            //  get key (KodeBrg)
            string kodeBrg = (string)DetilAdjTable.Rows[rowIndex]["BrgID"];

            //  get nama barang
            var brgName = "";
            var brg = _brgBL.GetData(kodeBrg);
            if (brg != null)
                brgName = brg.BrgName;

            //  get stok
            long qtyAwal = _stokBL.GetStok(kodeBrg);

            //  tampilkan di grid
            DetilAdjTable.Rows[rowIndex]["BrgName"] = brgName;
            DetilAdjTable.Rows[rowIndex]["QtyAwal"] = qtyAwal;
        }
        private void AddRow()
        {
            DetilAdjTable.Rows.Add("", "", 0, 0, 0, 0);
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveTransaksi();
            ClearForm();
            AddRow();
        }

        private void SaveTransaksi()
        {
            var kodeTrs = NoTrsTextBox.Text;
            var tglTrs = TanggalDateTime.Value.ToString("dd-MM-yyyy");
            var jamTrs = JamTextBox.Text;
            var keterangan = BuyerNameTextBox.Text;
            var dtlTrs = new List<Penjualan2Model>();
            var noUrut = 0;
            List<Penjualan2Model> listDetilAdj = null;
            foreach (DataRow dr in DetilAdjTable.Rows)
            {
                if (listDetilAdj == null)
                    listDetilAdj = new List<Penjualan2Model>();

                if (dr["BrgID"].ToString().Trim() == "") continue;

                var dtlAdj = new Penjualan2Model()
                {
                    NoUrut = noUrut,
                    BrgID = dr["BrgID"].ToString(),
                    BrgName = "",
                    //QtyAwal = Convert.ToInt32(dr["QtyAwal"]),
                    //QtyAdjust = Convert.ToInt32(dr["QtyAdjust"]),
                    //QtyAkhir = Convert.ToInt32(dr["QtyAkhir"]),
                    //HppAdjust = Convert.ToDouble(dr["Hpp"])
                };
                listDetilAdj.Add(dtlAdj);

                noUrut++;
            }
            var penjualan = new PenjualanModel
            {
                PenjualanID = kodeTrs,
                TglPenjualan = tglTrs,
                JamPenjualan = jamTrs,

                
                ListBrg = listDetilAdj
            };
            var result = _penjualanBL.Save(penjualan);
            if (result != null)
                LastIDLabel.Text = result.PenjualanID;
        }

        private void JamTrsTimer_Tick(object sender, EventArgs e)
        {
            JamTextBox.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void NewButton_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            NoTrsTextBox.Clear();
            TanggalDateTime.Value = DateTime.Now;
            BuyerNameTextBox.Clear();
            DetilAdjTable.Rows.Clear();
            JamTrsTimer.Enabled = true;
        }

        private void NoTrsTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                SearchKodeTrs();
                TanggalDateTime.Focus();
            }
        }

        private void NoTrsTextBox_Validated(object sender, EventArgs e)
        {
            ShowData();
        }

        private void ShowData()
        {
            JamTrsTimer.Enabled = false;
            var id = NoTrsTextBox.Text;
            var stokAdj = _penjualanBL.GetData(id);

            if (stokAdj == null)
            {
                ClearForm();
                return;
            }

            TanggalDateTime.Value = stokAdj.TglPenjualan.ToDate();
            JamTextBox.Text = stokAdj.JamPenjualan;
            //KeteranganTextBox.Text = stokAdj.Keterangan;
            DetilAdjTable.Rows.Clear();
            foreach (var item in stokAdj.ListBrg)
            {
                //DetilAdjTable.Rows.Add(
                //    item.BrgID,
                //    item.BrgName,
                //    item.QtyAwal,
                //    item.QtyAdjust,
                //    item.QtyAkhir,
                //    item.HppAdjust
                //    );
            }
            AddRow();
        }
    }
}
