using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using AnugerahBackend.Pembelian.BL;
using AnugerahBackend.Pembelian.Model;
using AnugerahBackend.StokBarang.BL;
using AnugerahBackend.StokBarang.Model;
using AnugerahWinform.Pembelian.Presenter;
using AnugerahWinform.Pembelian.View;
using AnugerahWinform.Support;
using Ics.Helper.StringDateTime;

namespace AnugerahWinform.Pembelian
{
    public partial class PurchaseForm : Form, IPurchaseView
    {
        private ISupplierBL _supplierBL;
        private IBrgBL _brgBL;
        private PurchasePresenter presenter;
        private List<PurchaseDetilModel> _listBrg;

        public PurchaseForm()
        {
            InitializeComponent();
            _supplierBL = new SupplierBL();
            _brgBL = new BrgBL();
            _listBrg = new List<PurchaseDetilModel>();
            presenter = new PurchasePresenter(this);
        }

        #region VIEW-BINDING
        public string PurchaseID
        {
            get => PurchaseIDText.Text;
            set => PurchaseIDText.Text = value;
        }
        public string Tgl
        {
            get => TanggalDateTime.Value.ToString("dd-MM-yyyy");
            set => TanggalDateTime.Value = value.ToDate();
        }
        public string Jam
        {
            get => JamTextBox.Text;
            set => JamTextBox.Text = value;
        }
        public string SupplierID
        {
            get => SupplierIDText.Text;
            set => SupplierIDText.Text = value;
        }
        public string SupplierName
        {
            get => SupplierNameText.Text;
            set => SupplierNameText.Text = value;
        }
        public string Alamat
        {
            get => AlamatTextBox.Text;
            set => AlamatTextBox.Text = value;
        }
        public string NoTelp
        {
            get => NoTelpTextBox.Text;
            set => NoTelpTextBox.Text = value;
        }
        public string Catatan
        {
            get => CatatanTextBox.Text;
            set => CatatanTextBox.Text = value;
        }
        public List<PurchaseDetilModel> ListBrg
        {
            get => GetListBrg();
            set => SetListBrg(value);
        }

        public decimal Total
        {
            get => TotalNumText.Value;
            set => TotalNumText.Value = value;
        }
        public decimal DiskonLain
        {
            get => DiskonNumText.Value;
            set => DiskonNumText.Value = value;
        }
        public decimal BiayaLain
        {
            get => BiayaLainNumText.Value;
            set => BiayaLainNumText.Value = value;
        }
        public decimal GrandTotal
        {
            get => GrandTotalNumText.Value;
            set => GrandTotalNumText.Value = value;
        }

        private List<PurchaseDetilModel> GetListBrg()
        {
            List<PurchaseDetilModel> result = null;
            int noUrut = 1;
            foreach (DataRow dr in PurchaseDetilTable.Rows)
            {
                if (result == null) result = new List<PurchaseDetilModel>();
                result.Add(new PurchaseDetilModel
                {
                    BrgID = dr["BrgID"].ToString(),
                    BrgName = dr["BrgName"].ToString(),
                    NoUrut = noUrut,
                    Harga = Convert.ToDecimal(dr["Harga"]),
                    Diskon = Convert.ToDecimal(dr["Diskon"]),
                    TaxRupiah = Convert.ToDecimal(dr["TaxRupiah"]),
                    Qty = Convert.ToInt64(dr["Qty"]),
                    SubTotal = Convert.ToDecimal(dr["SubTotal"])
                });
            }
            return result;
        }
        private void SetListBrg(IEnumerable<PurchaseDetilModel> listBrg)
        {
            PurchaseDetilTable.Rows.Clear();
            foreach (var item in listBrg)
            {
                PurchaseDetilTable.Rows.Add(
                    item.BrgID, item.BrgID,
                    item.Qty, item.Harga, item.Diskon,
                    item.TaxRupiah, item.SubTotal);
            }
        } 
        #endregion


        private void SaveButton_Click(object sender, EventArgs e)
        {
            presenter.Save();
        }
        private void NewButton_Click(object sender, EventArgs e)
        {
            presenter.New();
        }
        private void SearchSupplierButton_Click(object sender, EventArgs e)
        {
            SupplierIDText.Text = presenter.PilihSupplier();
        }

        private void SearchBrg(int rowIndex)
        {
            
            var searchForm = new SearchingForm<BrgSearchResultModel>(_brgBL);
            var resultDialog = searchForm.ShowDialog();
            if (resultDialog == DialogResult.OK)
            {
                var result = searchForm.SelectedDataKey;
                PurchaseDetilTable.Rows[rowIndex]["BrgID"] = result;
            }
        }
        private void ShowDataBrgGrid(int rowIndex)
        {

            //  get key (KodeBrg)
            string kodeBrg = (string)PurchaseDetilTable.Rows[rowIndex]["BrgID"];

            //  get nama barang
            var brgName = "";
            var brg = _brgBL.GetData(kodeBrg);
            if (brg != null)
                brgName = brg.BrgName;

            //  tampilkan di grid
            var dr = PurchaseDetilTable.Rows[rowIndex];
            dr["BrgName"] = brgName;
            dr["SubTotal"] = 
                Convert.ToDecimal(dr["Qty"]) 
                - Convert.ToDecimal(dr["Diskon"])
                + Convert.ToDecimal(dr["TaxRupiah"]);

            PurchaseDetilTable.Rows[rowIndex]["BrgName"] = brgName;
            //PurchaseDetilTable.Rows[rowIndex]["SubTotal"] = x

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
            //var brgName = PurchaseDetilTable.Rows[e.RowIndex]["BrgName"].ToString();
            //if ((brgName.Trim() != "") && (e.RowIndex == PurchaseDetilTable.Rows.Count - 1))
            //    AddRow();
        }
        private void BrgGrid_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            PurchasePresenter presenter = new PurchasePresenter(this);
            switch (e.ColumnIndex)
            {
                case 0:
                    //var brg = _brgBL.GetData(ListBrg.ElementAt(e.RowIndex).BrgID);
                    //if (brg == null) return;
                    //ListBrg.ElementAt(e.RowIndex).BrgName = brg.BrgName;
                    break;

                case 3: case 4: case 5: case 6: case 7:
                    ShowDataBrgGrid(e.RowIndex);
                    break;
            }

        }

        private void BrgGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                var row = BrgGrid.CurrentRow.Index;
                if (row != BrgGrid.Rows.Count - 1)
                    BrgGrid.Rows.RemoveAt(row);
                //ReCalcTotal();
            }
        }


        private void PurchaseForm_Load(object sender, EventArgs e)
        {
            presenter.New();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
