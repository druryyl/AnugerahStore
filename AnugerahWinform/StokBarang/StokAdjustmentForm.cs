﻿using AnugerahBackend.StokBarang.BL;
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
        private IStokAdjustmentBL _stokAdjustmentBL;

        public StokAdjustmentForm()
        {
            InitializeComponent();
            _stokAdjustmentBL = new StokAdjustmentBL();
            _brgBL = new BrgBL();
            _stokBL = new StokBL();

        }
        private void StokAdjustmentForm_Load(object sender, EventArgs e)
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
            if ((brgName.Trim() != "") && (e.RowIndex == DetilAdjTable.Rows.Count-1))
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
            var searchForm = new SearchingForm<BrgSearchResultModel>(_brgBL);
            var resultDialog = searchForm.ShowDialog();
            if(resultDialog == DialogResult.OK)
            {
                var result = searchForm.SelectedDataKey;
                DetilAdjTable.Rows[rowIndex]["BrgID"] = result;
            }
        }
        private void ShowDataBrgGrid(int rowIndex)
        {
            //  get key (KodeBrg)
            string kodeBrg = (string)DetilAdjTable.Rows[rowIndex]["BrgID"];

            //  get nama barang
            var brgName = "";
            var brg = _brgBL.GetData(kodeBrg);
            if(brg != null)
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
        }

        private void SaveTransaksi()
        {
            var kodeTrs = NoTrsTextBox.Text;
            var tglTrs = TanggalDateTime.Value.ToString("dd-MM-yyyy");
            var jamTrs = JamTextBox.Text;
            var keterangan = KeteranganTextBox.Text;
            var dtlTrs = new List<StokAdjustment2Model>();
            var noUrut = 0;
            List<StokAdjustment2Model> listDetilAdj = null;
            foreach (DataRow dr in DetilAdjTable.Rows)
            {
                if (listDetilAdj == null)
                    listDetilAdj = new List<StokAdjustment2Model>();

                if (dr["BrgID"].ToString().Trim() == "") continue;

                var dtlAdj = new StokAdjustment2Model()
                {
                    NoUrut = noUrut,
                    BrgID = dr["BrgID"].ToString(),
                    BrgName = "",
                    QtyAwal = Convert.ToInt32(dr["QtyAwal"]),
                    QtyAdjust = Convert.ToInt32(dr["QtyAdjust"]),
                    QtyAkhir = Convert.ToInt32(dr["QtyAkhir"]),
                    HppAdjust = Convert.ToDouble(dr["Hpp"])
                };
                listDetilAdj.Add(dtlAdj);

                noUrut++;
            }
            var stokAdj = new StokAdjustmentModel
            {
                StokAdjustmentID = kodeTrs,
                TglTrs = tglTrs,
                JamTrs = jamTrs,
                Keterangan = keterangan,
                TglVoid = "3000-01-01",
                JamVoid = "00:00:00",
                UserrID = "",
                UserrIDVoid = "",
                ListBrg = listDetilAdj
            };
            var result = _stokAdjustmentBL.Save(stokAdj);
            if (result != null)
                LastIDLabel.Text = result.StokAdjustmentID;
        }
    }
}
