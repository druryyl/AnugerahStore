using AnugerahBackend.Penjualan.BL;
using AnugerahBackend.Penjualan.Model;
using AnugerahBackend.StokBarang.BL;
using AnugerahBackend.StokBarang.Model;
using AnugerahWinform.PrintDoc;
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
        private IBrgPriceBL _brgPriceBL;

        public PenjualanForm()
        {
            InitializeComponent();

            _penjualanBL = new PenjualanBL();
            _brgBL = new BrgBL();
            _stokBL = new StokBL();
            _customerBL = new CustomerBL();
            _brgPriceBL = new BrgPriceBL();

        }

        private void PenjualanForm_Load(object sender, EventArgs e)
        {
            AddRow();
            LoadCustomerComboBox();
        }

        private void LoadCustomerComboBox()
        {
            //  kosongkan combobox
            CustomerComboBox.DataSource = null;
            CustomerComboBox.Items.Clear();

            //  ambil data
            var listCustomer = _customerBL.ListData();

            //  exit jika kosong
            if (listCustomer == null)
                return;

            listCustomer = listCustomer.OrderBy(x => x.CustomerName).ToList();
            CustomerComboBox.DataSource = listCustomer;
            CustomerComboBox.DisplayMember = "CustomerName";
            CustomerComboBox.ValueMember = "CustomerID";

            CustomerComboBox.SelectedItem = null;
        }
        private void BrgGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                SearchBrg(e.RowIndex);
                ShowDataBrgGrid(e.RowIndex);
                ShowHargaBrg(e.RowIndex);
            }
        }
        private void BrgGrid_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            var brgName = DetilPenjualanTable.Rows[e.RowIndex]["BrgName"].ToString();
            if ((brgName.Trim() != "") && (e.RowIndex == DetilPenjualanTable.Rows.Count - 1))
                AddRow();

            if (e.ColumnIndex == 3)
            {
                ShowHargaBrg(e.RowIndex);
                ShowHargaBrg(e.RowIndex);
            }
        }
        private void BrgGrid_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                ShowDataBrgGrid(e.RowIndex);
                ShowHargaBrg(e.RowIndex);
            }
        }

        private void ShowHargaBrg(int rowIndex)
        {
            //  get key (KodeBrg)
            string kodeBrg = (string)DetilPenjualanTable.Rows[rowIndex]["BrgID"];
            //  get qty
            var qty = Convert.ToInt32(DetilPenjualanTable.Rows[rowIndex]["Qty"]);
            if (qty <= 0) qty = 1;
            //  get harga
            var listHarga = _brgPriceBL.ListData(kodeBrg);
            double harga = 0;
            double diskon = 0;
            if (listHarga != null)
            {
                var dataHarga = listHarga
                    .Where(x => x.Qty <= qty)
                    .OrderByDescending(x => x.Qty)
                    .FirstOrDefault();

                harga = dataHarga.Harga;
                diskon = dataHarga.Diskon;
            }

            DetilPenjualanTable.Rows[rowIndex]["Harga"] = harga;
            DetilPenjualanTable.Rows[rowIndex]["Diskon"] = diskon;
            DetilPenjualanTable.Rows[rowIndex]["SubTotal"] = (harga - diskon) * qty;
            ReCalcTotal();
        }

        private void ReCalcTotal()
        {
            decimal nilaiTotal = 0;
            foreach (DataRow row in DetilPenjualanTable.Rows)
            {
                nilaiTotal += Convert.ToDecimal(row["SubTotal"]);
            }
            TotalNumText.Value = nilaiTotal;
            GrandTotalNumText.Value = nilaiTotal - DiskonNumText.Value + BiayaLainNumText.Value;
            KembaliNumText.Value = GrandTotalNumText.Value - BayarNumText.Value;
        }

        private void SearchBrg(int rowIndex)
        {
            var searchForm = new SearchingForm<BrgSearchResultModel>(_brgBL, false);
            var resultDialog = searchForm.ShowDialog();
            if (resultDialog == DialogResult.OK)
            {
                var result = searchForm.SelectedDataKey;
                DetilPenjualanTable.Rows[rowIndex]["BrgID"] = result;
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
            string kodeBrg = (string)DetilPenjualanTable.Rows[rowIndex]["BrgID"];

            //  get nama barang
            var brgName = "";
            var brg = _brgBL.GetData(kodeBrg);
            if (brg != null)
                brgName = brg.BrgName;

            //  tampilkan di grid
            DetilPenjualanTable.Rows[rowIndex]["BrgName"] = brgName;
        }
        private void AddRow()
        {
            DetilPenjualanTable.Rows.Add("", "", 0, 0, 0, 0);
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveTransaksi();
            ClearForm();
        }

        private void SaveTransaksi()
        {
            var kodeTrs = NoTrsTextBox.Text;
            var tglTrs = TanggalDateTime.Value.ToString("dd-MM-yyyy");
            var jamTrs = JamTextBox.Text;
            var customerID = "";
            if(CustomerComboBox.SelectedValue != null)
                customerID = CustomerComboBox.SelectedValue.ToString();

            var buyerName = BuyerNameTextBox.Text;
            var alamat = AlamatTextBox.Text;
            var noTelpon = NoTelpTextBox.Text;
            var catatan = CatatanTextBox.Text;

            var total = TotalNumText.Value;
            var diskon = DiskonNumText.Value;
            var biayaLain = BiayaLainNumText.Value ;
            var grandTotal = GrandTotalNumText.Value;
            var bayar = BayarNumText.Value;
            var kembali = KembaliNumText.Value;

            var dtlTrs = new List<Penjualan2Model>();
            var noUrut = 0;
            List<Penjualan2Model> listDetilAdj = null;
            foreach (DataRow dr in DetilPenjualanTable.Rows)
            {
                if (listDetilAdj == null)
                    listDetilAdj = new List<Penjualan2Model>();

                if (dr["BrgID"].ToString().Trim() == "") continue;

                var dtlAdj = new Penjualan2Model()
                {
                    NoUrut = noUrut,
                    BrgID = dr["BrgID"].ToString(),
                    BrgName = "",
                    Qty = Convert.ToInt32(dr["Qty"]),
                    Harga = Convert.ToDouble(dr["Harga"]),
                    Diskon = Convert.ToDouble(dr["Diskon"]),
                    SubTotal = Convert.ToDouble(dr["SubTotal"])
                };
                listDetilAdj.Add(dtlAdj);

                noUrut++;
            }
            var penjualan = new PenjualanModel
            {
                PenjualanID = kodeTrs,
                TglPenjualan = tglTrs,
                JamPenjualan = jamTrs,
                CustomerID = customerID,
                BuyerName = buyerName,
                Alamat = alamat,
                NoTelp = noTelpon,
                Catatan = catatan,
                
                NilaiTotal = total,
                NilaiDiskonLain = diskon,
                NilaiBiayaLain = biayaLain,
                NilaiGrandTotal = grandTotal,
                NilaiBayar = bayar,
                NilaiKembali = kembali,
                
                ListBrg = listDetilAdj
            };
            var result = _penjualanBL.Save(penjualan);
            if (result != null)
                LastIDLabel.Text = result.PenjualanID;

            if(MessageBox.Show("Cetak Nota ?","Penjualan", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var printDoc = new NotaJualPrintDoc(result);
                printDoc.Print();
            }
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
            CustomerComboBox.SelectedItem = null;
            BuyerNameTextBox.Clear();
            AlamatTextBox.Clear();
            NoTelpTextBox.Clear();
            CatatanTextBox.Clear();
            DetilPenjualanTable.Rows.Clear();

            DiskonNumText.Value = 0;
            BiayaLainNumText.Value = 0;

            ReCalcTotal();
            JamTrsTimer.Enabled = true;
            DetilPenjualanTable.Rows.Clear();
            AddRow();
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
            var penjualan = _penjualanBL.GetData(id);

            if (penjualan == null)
            {
                ClearForm();
                return;
            }

            TanggalDateTime.Value = penjualan.TglPenjualan.ToDate();
            JamTextBox.Text = penjualan.JamPenjualan;
            CustomerComboBox.SelectedValue = penjualan.CustomerID;
            BuyerNameTextBox.Text = penjualan.BuyerName;
            AlamatTextBox.Text = penjualan.Alamat;
            NoTelpTextBox.Text = penjualan.NoTelp;
            CatatanTextBox.Text = penjualan.Catatan;

            //TotalNumText.Value = penjualan.NilaiTotal;
            DiskonNumText.Value = penjualan.NilaiDiskonLain;
            BiayaLainNumText.Value = penjualan.NilaiBiayaLain;
            //GrandTotalNumText.Value = penjualan.NilaiGrandTotal;
            //BayarNumText.Value = penjualan.NilaiBayar;
            //KembaliNumText.Value = penjualan.NilaiKembali;

            DetilPenjualanTable.Rows.Clear();
            foreach (var item in penjualan.ListBrg)
            {
                DetilPenjualanTable.Rows.Add(
                    item.BrgID,
                    item.BrgName,
                    item.Qty,
                    item.Harga,
                    item.Diskon,
                    item.SubTotal
                    );
            }
            AddRow();
            ReCalcTotal();
        }

        private void BayarTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void DiskonTextBox_Validated(object sender, EventArgs e)
        {
            //DiskonTextBox.Text = 
        }

        private void DiskonNumText_ValueChanged(object sender, EventArgs e)
        {
            ReCalcTotal();
        }

        private void BiayaLainNumText_ValueChanged(object sender, EventArgs e)
        {
            ReCalcTotal();
        }

        private void DiskonNumText_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                BiayaLainNumText.Focus();
        }

        private void BiayaLainNumText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                BayarButton.Focus();
        }

        private void BrgGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete)
            {
                var row = BrgGrid.CurrentRow.Index;
                if (row != BrgGrid.Rows.Count - 1)
                    BrgGrid.Rows.RemoveAt(row);
                ReCalcTotal();
            }
        }
    }
}
