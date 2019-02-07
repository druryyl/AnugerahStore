﻿using AnugerahBackend.Penjualan.BL;
using AnugerahBackend.Penjualan.Dal;
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
        private IPenjualanBayarDal _penjualanBayarDal;
        private ICustomerBL _customerBL;
        private IBrgPriceBL _brgPriceBL;

        private List<PenjualanBayarModel> _listBayarNonCash;

        public PenjualanForm()
        {
            InitializeComponent();

            _penjualanBL = new PenjualanBL();
            _brgBL = new BrgBL();
            _stokBL = new StokBL();
            _customerBL = new CustomerBL();
            _brgPriceBL = new BrgPriceBL();
            _penjualanBayarDal = new PenjualanBayarDal();

        }

        private void PenjualanForm_Load(object sender, EventArgs e)
        {
            AddRow();
            LoadCustomerComboBox();
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
        private void NewButton_Click(object sender, EventArgs e)
        {
            ClearForm();
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
        private void BrgGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                var row = BrgGrid.CurrentRow.Index;
                if (row != BrgGrid.Rows.Count - 1)
                    BrgGrid.Rows.RemoveAt(row);
                ReCalcTotal();
            }
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
            if (e.KeyCode == Keys.Enter)
                BiayaLainNumText.Focus();
        }
        private void BayarNonCashNumText_ValueChanged(object sender, EventArgs e)
        {
            ReCalcTotal();
        }
        private void BiayaLainNumText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                BayarButton.Focus();
        }
        private void JamTrsTimer_Tick(object sender, EventArgs e)
        {
            JamTextBox.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void BayarButton_Click(object sender, EventArgs e)
        {
            using (var penjualanBayarForm = new PenjualanBayarForm(_listBayarNonCash))
            {
                var result = penjualanBayarForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    if(penjualanBayarForm.ListBayar != null)
                        _listBayarNonCash = penjualanBayarForm.ListBayar
                            .Where(x => x.NilaiBayar != 0)
                            .ToList();
                }
            }
            BayarNonCashNumText.Value = _listBayarNonCash.Sum(x => x.NilaiBayar);
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveTransaksi();
            ClearForm();
        }
        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
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
            BayarCashNumText.Value = 0;
            BayarNonCashNumText.Value = 0;
            KembaliNumText.Value = 0;

            ReCalcTotal();
            JamTrsTimer.Enabled = true;
            DetilPenjualanTable.Rows.Clear();
            _listBayarNonCash = null;

            AddRow();
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
        private void SearchKodeTrs()
        {
            var searchForm = new SearchingForm<PenjualanSearchModel>(_penjualanBL);
            var resultDialog = searchForm.ShowDialog();
            if (resultDialog == DialogResult.OK)
            {
                var result = searchForm.SelectedDataKey;
                NoTrsTextBox.Text = result;
            }
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

            DiskonNumText.Value = penjualan.NilaiDiskonLain;
            BiayaLainNumText.Value = penjualan.NilaiBiayaLain;

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


            if (penjualan.ListBayar!= null)
            {
                foreach (var item in penjualan.ListBayar.Where(x => x.JenisBayarID != "KAS"))
                {
                    if (_listBayarNonCash == null)
                        _listBayarNonCash = new List<PenjualanBayarModel>();

                    _listBayarNonCash.Add(new PenjualanBayarModel
                    {
                        JenisBayarID = item.JenisBayarID,
                        JenisBayarName = item.JenisBayarName,
                        NilaiBayar = item.NilaiBayar,
                        Catatan = item.Catatan
                    });
                }

                if (penjualan.ListBayar.Where(x => x.JenisBayarID == "KAS").Any())
                {
                    BayarCashNumText.Value = penjualan.ListBayar
                        .Where(x => x.JenisBayarID == "KAS")
                        .Where(x => x.NilaiBayar > 0)
                        .Sum(x => x.NilaiBayar);
                }
            }
            ReCalcTotal();
        }

        private void AddRow()
        {
            DetilPenjualanTable.Rows.Add("", "", 0, 0, 0, 0);
        }
        private void SearchBrg(int rowIndex)
        {
            var searchForm = new SearchingForm<BrgSearchResultModel>(_brgBL);
            var resultDialog = searchForm.ShowDialog();
            if (resultDialog == DialogResult.OK)
            {
                var result = searchForm.SelectedDataKey;
                DetilPenjualanTable.Rows[rowIndex]["BrgID"] = result;
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

        private void ReCalcTotal()
        {
            decimal nilaiTotal = 0;
            foreach (DataRow row in DetilPenjualanTable.Rows)
            {
                nilaiTotal += Convert.ToDecimal(row["SubTotal"]);
            }
            TotalNumText.Value = nilaiTotal;

            decimal totBayarNonCash = 0;
            if(_listBayarNonCash!= null)
                foreach(var item in _listBayarNonCash)
                    totBayarNonCash += item.NilaiBayar;
            BayarNonCashNumText.Value = totBayarNonCash;

            GrandTotalNumText.Value = nilaiTotal - DiskonNumText.Value + BiayaLainNumText.Value;
            KembaliNumText.Value = BayarCashNumText.Value - GrandTotalNumText.Value + BayarNonCashNumText.Value;
        }
        private void SaveTransaksi()
        {
            //  pindah textbox ke variable utk proses simpan
            var kodeTrs = NoTrsTextBox.Text;
            var tglTrs = TanggalDateTime.Value.ToString("dd-MM-yyyy");
            var jamTrs = JamTextBox.Text;
            var customerID = "";
            if(CustomerComboBox.SelectedValue != null)
                customerID = CustomerComboBox.SelectedValue.ToString();
            //
            var buyerName = BuyerNameTextBox.Text;
            var alamat = AlamatTextBox.Text;
            var noTelpon = NoTelpTextBox.Text;
            var catatan = CatatanTextBox.Text;
            //
            var total = TotalNumText.Value;
            var diskon = DiskonNumText.Value;
            var biayaLain = BiayaLainNumText.Value ;
            var grandTotal = GrandTotalNumText.Value;
            var bayarCash = BayarCashNumText.Value;
            var kembali = KembaliNumText.Value;

            //--ambil data grid barang
            var dtlTrs = new List<Penjualan2Model>();
            var noUrut = 0;
            List<Penjualan2Model> listDetilBrg = null;
            foreach (DataRow dr in DetilPenjualanTable.Rows)
            {
                if (listDetilBrg == null)
                    listDetilBrg = new List<Penjualan2Model>();

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
                listDetilBrg.Add(dtlAdj);
                noUrut++;
            }

            //  siapkan object tampung pembayaran
            List<PenjualanBayarModel> listDetilBayar = null;
            //  ambil data bayar cash
            if (bayarCash != 0)
            {
                var itemBayarCash = new PenjualanBayarModel
                {
                    JenisBayarID = "KAS",
                    NilaiBayar = bayarCash,
                    Catatan = ""
                };
                var itemKembali = new PenjualanBayarModel
                {
                    JenisBayarID = "KAS",
                    NilaiBayar = -kembali,
                    Catatan = ""
                };
                listDetilBayar = new List<PenjualanBayarModel>
                {
                    itemBayarCash,
                    itemKembali
                };
            }
            //  ambil data bayar non cash
            if (_listBayarNonCash != null)
            {
                foreach(var item in _listBayarNonCash)
                {
                    var itemNonCash = new PenjualanBayarModel
                    {
                        JenisBayarID = item.JenisBayarID,
                        NilaiBayar = item.NilaiBayar,
                        Catatan = item.Catatan
                    };
                    if (listDetilBayar == null) listDetilBayar = new List<PenjualanBayarModel>();
                    listDetilBayar.Add(itemNonCash);
                }
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
                NilaiBayar = bayarCash,
                NilaiKembali = kembali,
                
                ListBrg = listDetilBrg,
                ListBayar = listDetilBayar
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

        private void BayarCashNumText_ValueChanged(object sender, EventArgs e)
        {
            ReCalcTotal();
        }

        private void BayarCashNumText_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F1)
            {
                BayarCashNumText.Value = GrandTotalNumText.Value - BayarNonCashNumText.Value;
            }
        }
    }
}
