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
    public partial class ReceiptForm : Form, IReceiptView
    {
        private ISupplierBL _supplierBL;
        private IBrgBL _brgBL;
        private ReceiptPresenter presenter;

        public ReceiptForm()
        {
            InitializeComponent();
            _supplierBL = new SupplierBL();
            _brgBL = new BrgBL();
            presenter = new ReceiptPresenter(this);
        }

        #region VIEW-BINDING
        public string ReceiptID
        {
            get => ReceiptIDText.Text;
            set => ReceiptIDText.Text = value;
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
        public string PurchaseID
        {
            get => PurchaseIDText.Text;
            set => PurchaseIDText.Text = value;
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
        public List<ReceiptDetilModel> ListBrg
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

        private List<ReceiptDetilModel> GetListBrg()
        {
            List<ReceiptDetilModel> result = null;
            for (int i = 0; i <= ReceiptDetilTable.Rows.Count - 1; i++)
            {
                if (result == null) result = new List<ReceiptDetilModel>();
                var item = DataRowToModel(i);
                result.Add(item);
            }
            return result;
        }
        private void SetListBrg(IEnumerable<ReceiptDetilModel> listBrg)
        {
            if (listBrg == null) return;

            ReceiptDetilTable.Rows.Clear();
            foreach (var item in listBrg)
            {
                ReceiptDetilTable.Rows.Add("", "", 0, 0, 0, 0, 0);
                ModelToDataRow(ReceiptDetilTable.Rows.Count - 1, item);
            }
        }
        #endregion

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                presenter.Save();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            presenter.New();
        }
        private void NewButton_Click(object sender, EventArgs e)
        {
            presenter.New();
        }
        private void SearchSupplierButton_Click(object sender, EventArgs e)
        {
            SupplierIDText.Text = presenter.PilihSupplier();
        }

        private ReceiptDetilModel DataRowToModel(int rowIndex)
        {
            DataRow dr = ReceiptDetilTable.Rows[rowIndex];
            var result = new ReceiptDetilModel
            {
                NoUrut = rowIndex,
                BrgID = dr["BrgID"].ToString(),
                BrgName = dr["BrgName"].ToString(),
                Qty = Convert.ToInt64(dr["Qty"]),
                Harga = Convert.ToDecimal(dr["Harga"]),
                Diskon = Convert.ToDecimal(dr["Diskon"]),
                TaxRupiah = Convert.ToDecimal(dr["TaxRupiah"]),
                SubTotal = Convert.ToDecimal(dr["SubTotal"])
            };
            return result;
        }
        private void ModelToDataRow(int rowIndex, ReceiptDetilModel receiptDetil)
        {
            if (receiptDetil == null) return;
            DataRow dr = ReceiptDetilTable.Rows[rowIndex];
            dr["BrgID"] = receiptDetil.BrgID;
            dr["BrgName"] = receiptDetil.BrgName;
            dr["Qty"] = receiptDetil.Qty;
            dr["Harga"] = receiptDetil.Harga;
            dr["Diskon"] = receiptDetil.Diskon;
            dr["TaxRupiah"] = receiptDetil.TaxRupiah;
            dr["SubTotal"] = receiptDetil.SubTotal;
        }

        private void BrgGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var grid = (DataGridView)sender;
            if (grid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                var receiptDetil = DataRowToModel(e.RowIndex);
                receiptDetil = presenter.PilihBrg(receiptDetil);
                ModelToDataRow(e.RowIndex, receiptDetil);
            }
        }

        private void BrgGrid_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 0:
                    var receiptDetil = DataRowToModel(e.RowIndex);
                    receiptDetil = presenter.ValidateBrg(receiptDetil);
                    if (receiptDetil == null) return;
                    ModelToDataRow(e.RowIndex, receiptDetil);
                    break;

                case 3:
                case 4:
                case 5:
                case 6:
                    receiptDetil = DataRowToModel(e.RowIndex);
                    receiptDetil = presenter.Calculate(receiptDetil);
                    ModelToDataRow(e.RowIndex, receiptDetil);
                    presenter.CalculateTotal();
                    break;
            }

            if ((e.RowIndex == ReceiptDetilTable.Rows.Count - 1) &&
                (ReceiptDetilTable.Rows[e.RowIndex]["BrgName"].ToString().Trim() != ""))
                ReceiptDetilTable.Rows.Add("", "", 0, 0, 0, 0, 0);

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


        private void ReceiptForm_Load(object sender, EventArgs e)
        {
            presenter.New();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DiskonNumText_ValueChanged(object sender, EventArgs e)
        {
            presenter.CalculateTotal();
        }

        private void BiayaLainNumText_ValueChanged(object sender, EventArgs e)
        {
            presenter.CalculateTotal();
        }

        private void ReceiptIDText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                presenter.PilihReceipt();
        }
    }
}
