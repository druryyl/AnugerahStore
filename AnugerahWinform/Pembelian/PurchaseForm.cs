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

        public PurchaseForm()
        {
            InitializeComponent();
            _supplierBL = new SupplierBL();
            _brgBL = new BrgBL();
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

        public bool IsClosedPO
        {
            get => ClosePOStatusLabel.Visible;
            set
            {
                ClosePOStatusLabel.Visible = value;
                ClosePOButton.Visible = !value;
            }
        }

        private List<PurchaseDetilModel> GetListBrg()
        {
            List<PurchaseDetilModel> result = null;
            for(int i = 0; i<= PurchaseDetilTable.Rows.Count - 1; i++)
            {
                if (result == null) result = new List<PurchaseDetilModel>();
                var item = DataRowToModel(i);
                result.Add(item);
            }
            return result;
        }
        private void SetListBrg(IEnumerable<PurchaseDetilModel> listBrg)
        {
            if (listBrg == null) return;

            PurchaseDetilTable.Rows.Clear();
            foreach (var item in listBrg)
            {
                PurchaseDetilTable.Rows.Add("", "", 0, 0, 0, 0, 0);
                ModelToDataRow(PurchaseDetilTable.Rows.Count - 1, item);
            }
        }
        #endregion

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                presenter.Save();
            }
            catch (ArgumentException ex )
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

        private PurchaseDetilModel DataRowToModel(int  rowIndex)
        {
            DataRow dr = PurchaseDetilTable.Rows[rowIndex];
            var result = new PurchaseDetilModel
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
        private void ModelToDataRow(int rowIndex, PurchaseDetilModel purchaseDetil)
        {
            if (purchaseDetil == null) return;
            DataRow dr = PurchaseDetilTable.Rows[rowIndex];
            dr["BrgID"] = purchaseDetil.BrgID;
            dr["BrgName"] = purchaseDetil.BrgName;
            dr["Qty"] = purchaseDetil.Qty;
            dr["Harga"] = purchaseDetil.Harga;
            dr["Diskon"] = purchaseDetil.Diskon;
            dr["TaxRupiah"] = purchaseDetil.TaxRupiah;
            dr["SubTotal"] = purchaseDetil.SubTotal;
        }

        private void BrgGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var grid = (DataGridView)sender;
            if (grid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                var purchaseDetil = DataRowToModel(e.RowIndex);
                purchaseDetil = presenter.PilihBrg(purchaseDetil);
                ModelToDataRow(e.RowIndex, purchaseDetil);
            }
        }

        private void BrgGrid_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 0:
                    var purchaseDetil = DataRowToModel(e.RowIndex);
                    purchaseDetil = presenter.ValidateBrg(purchaseDetil);
                    if (purchaseDetil == null) return;
                    ModelToDataRow(e.RowIndex, purchaseDetil);
                    break;

                case 3:
                case 4:
                case 5:
                case 6:
                    purchaseDetil = DataRowToModel(e.RowIndex);
                    purchaseDetil = presenter.Calculate(purchaseDetil);
                    ModelToDataRow(e.RowIndex, purchaseDetil);
                    presenter.CalculateTotal();
                    break;
            }

            if ((e.RowIndex == PurchaseDetilTable.Rows.Count - 1) &&
                (PurchaseDetilTable.Rows[e.RowIndex]["BrgName"].ToString().Trim() != ""))
                PurchaseDetilTable.Rows.Add("", "", 0, 0, 0, 0, 0);

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

        private void DiskonNumText_ValueChanged(object sender, EventArgs e)
        {
            presenter.CalculateTotal();
        }

        private void BiayaLainNumText_ValueChanged(object sender, EventArgs e)
        {
            presenter.CalculateTotal();
        }

        private void PurchaseIDText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                presenter.PilihPurchase();
        }

        private void ClosePOBuoon_Click(object sender, EventArgs e)
        {
            try
            {
                presenter.ClosePO();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
            presenter.New();
        }
    }
}
