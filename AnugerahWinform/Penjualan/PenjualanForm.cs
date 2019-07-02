using AnugerahBackend.Accounting.BL;
using AnugerahBackend.Accounting.Model;
using AnugerahBackend.Penjualan.BL;
using AnugerahBackend.Penjualan.Dal;
using AnugerahBackend.Penjualan.Model;
using AnugerahBackend.StokBarang.BL;
using AnugerahBackend.StokBarang.Model;
using AnugerahWinform.Accounting;
using AnugerahWinform.PrintDoc;
using AnugerahWinform.Support;
using Ics.Helper.Database;
using Ics.Helper.Extensions;
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
        private IBPKasBL _bpKasBL;
        private IJenisBayarBL _jenisBayarBL;
        private IBPHutangBL _bpHutangBL;
        private IDepositBL _depositBL;
        private List<PenjualanBayarModel> _listBayarDetil;
        private IBrgStokHargaBL _brgStokHargaBL;
        private IBPStokBL _bpStokBL;

        public PenjualanForm()
        {
            InitializeComponent();

            _penjualanBL = new PenjualanBL();
            _brgBL = new BrgBL();
            _stokBL = new StokBL();
            _customerBL = new CustomerBL();
            _brgPriceBL = new BrgPriceBL();
            _penjualanBayarDal = new PenjualanBayarDal();
            _bpKasBL = new BPKasBL();
            _jenisBayarBL = new JenisBayarBL();
            _bpHutangBL = new BPHutangBL();
            _depositBL = new DepositBL();
            _bpStokBL = new BPStokBL();
            _brgStokHargaBL = new BrgStokHargaBL();
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
                if(e.ColumnIndex == 1)
                {
                    SearchBrg(e.RowIndex);
                    ShowDataBrgGrid(e.RowIndex);
                    ShowHargaBrg(e.RowIndex);
                }

                if(e.ColumnIndex == 4)
                {
                    SearchStok(e.RowIndex);
                    ShowDataBrgGrid(e.RowIndex);
                }
            }
        }
        private void BrgGrid_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            var brgName = DetilPenjualanTable.Rows[e.RowIndex]["BrgName"].ToString();
            if ((brgName.Trim() != "") && (e.RowIndex == DetilPenjualanTable.Rows.Count - 1))
                AddRow();

            if ((e.ColumnIndex == 5 ) || (e.ColumnIndex == 6))
            {
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
            using (var penjualanBayarForm = new PenjualanBayarForm(_listBayarDetil))
            {
                var result = penjualanBayarForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    if(penjualanBayarForm.ListBayar != null)
                        _listBayarDetil = penjualanBayarForm.ListBayar
                            .Where(x => x.NilaiBayar != 0)
                            .ToList();
                }
            }

            if (_listBayarDetil == null) return;

            BayarNonCashNumText.Value = _listBayarDetil.Where(x => x.JenisBayarID != "KAS").Sum(x => x.NilaiBayar);
            BayarCashNumText.Value = _listBayarDetil.Where(x => x.JenisBayarID == "KAS").Sum(x => x.NilaiBayar);

        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveTransaksi();

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

            BiayaKirimNumText.Value = 0;
            DiskonNumText.Value = 0;
            BiayaLainNumText.Value = 0;
            BayarCashNumText.Value = 0;
            BayarNonCashNumText.Value = 0;
            KembaliNumText.Value = 0;

            ReCalcTotal();
            JamTrsTimer.Enabled = true;
            DetilPenjualanTable.Rows.Clear();
            _listBayarDetil = null;

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
            DepositCheckBox.Checked = penjualan.IsBayarDeposit;
            DepositIDText.Text = penjualan.DepositID;
            ShowDeposit();
            NilaiDepositText.Value= penjualan.NilaiDeposit;
            BiayaKirimNumText.Value = penjualan.NilaiBiayaKirim;

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
                    item.SubTotal,
                    item.BPStokID
                    );
            }

            //  tampilkan keterangan Slot Control
            for (var i = 0; i <= penjualan.ListBrg.Count()-1; i++)
                ShowDataBrgGrid(i);

            AddRow();


            if (penjualan.ListBayar!= null)
            {
                foreach (var item in penjualan.ListBayar.Where(x => x.NilaiBayar >0))
                {
                    if (_listBayarDetil == null)
                        _listBayarDetil = new List<PenjualanBayarModel>();

                    _listBayarDetil.Add(new PenjualanBayarModel
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
            DetilPenjualanTable.Rows.Add("", "", 0, 0, 0, 0,"");
        }
        private void SearchBrg(int rowIndex)
        {
            using (var searchForm = new SearchingForm<BrgStokHargaModel>(_brgStokHargaBL))
            {
                var resultDialog = searchForm.ShowDialog();
                if (resultDialog == DialogResult.OK)
                {
                    var result = searchForm.SelectedDataKey;
                    DetilPenjualanTable.Rows[rowIndex]["BrgID"] = result;
                }
            }
        }
        private void SearchStok(int rowIndex)
        {
            var brg = DetilPenjualanTable.Rows[rowIndex]["BrgID"].ToString();
            _bpStokBL.SearchFilter.StaticKeyword = brg;
            using (var searchForm = new SearchingForm<BPStokSearchModel>(_bpStokBL))
            {
                var resultDialog = searchForm.ShowDialog();
                if (resultDialog == DialogResult.OK)
                {
                    var bpStok = _bpStokBL.GetData(searchForm.SelectedDataKey);
                    DetilPenjualanTable.Rows[rowIndex]["BPStokID"] = bpStok.BPStokID;
                }
            }
        }
        private void ShowHargaBrg(int rowIndex)
        {
            //  get key (KodeBrg)
            string kodeBrg = (string)DetilPenjualanTable.Rows[rowIndex]["BrgID"];

            //  get qty
            var qty = Convert.ToDecimal(DetilPenjualanTable.Rows[rowIndex]["Qty"]);
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

                if (dataHarga == null)
                    dataHarga = listHarga
                    .OrderByDescending(x => x.Qty)
                    .FirstOrDefault();

                harga = dataHarga.Harga;
                diskon = dataHarga.Diskon;
            }


            if (kodeBrg.ToLower().Contains("jasa"))
            {
                harga = Convert.ToDouble(DetilPenjualanTable.Rows[rowIndex]["Harga"]);
                diskon = Convert.ToDouble(DetilPenjualanTable.Rows[rowIndex]["Diskon"]);
            }
            DetilPenjualanTable.Rows[rowIndex]["Harga"] = harga;
            DetilPenjualanTable.Rows[rowIndex]["Diskon"] = diskon;
            DetilPenjualanTable.Rows[rowIndex]["SubTotal"] = (harga - diskon) * Convert.ToDouble(qty);
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

            //  cari keterangan stok control
            var bpStokID = (string)DetilPenjualanTable.Rows[rowIndex]["BPStokID"];
            if(bpStokID.Trim() != "")
            {
                var stok = _bpStokBL.GetData(bpStokID);
                if(stok != null)
                {
                    brgName = brgName + " " + stok.StokControl;
                }
            }

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

            if (_listBayarDetil != null)
            {
                BayarNonCashNumText.Value = _listBayarDetil.Where(x => x.JenisBayarID != "KAS").Sum(x => x.NilaiBayar);
                BayarCashNumText.Value = _listBayarDetil.Where(x => x.JenisBayarID == "KAS").Sum(x => x.NilaiBayar);
            }

            GrandTotalNumText.Value = BiayaKirimNumText.Value + nilaiTotal - DiskonNumText.Value + BiayaLainNumText.Value;
            decimal nilaiTotBayar = BayarNonCashNumText.Value + BayarCashNumText.Value;
            if (DepositCheckBox.Checked)
                nilaiTotBayar += NilaiDepositText.Value;

            KembaliNumText.Value = nilaiTotBayar - GrandTotalNumText.Value;

            if (KembaliNumText.Value < 0) KembaliNumText.Value = 0;

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
            var biayaKirim = BiayaKirimNumText.Value;
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
                    BPStokID = dr["BPStokID"].ToString(),
                    Qty = Convert.ToDecimal(dr["Qty"]),
                    Harga = Convert.ToDecimal(dr["Harga"]),
                    Diskon = Convert.ToDecimal(dr["Diskon"]),
                    SubTotal = Convert.ToDecimal(dr["SubTotal"])
                };
                listDetilBrg.Add(dtlAdj);
                noUrut++;
            }

            //  siapkan object tampung pembayaran
            List<PenjualanBayarModel> listDetilBayar = null;

            //  ambil data bayar detil
            if (_listBayarDetil != null)
            {
                foreach (var item in _listBayarDetil)
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

            if (kembali != 0)
            {
                var itemKembali = new PenjualanBayarModel
                {
                    JenisBayarID = "KAS",
                    NilaiBayar = -kembali,
                    Catatan = ""
                };
                if (listDetilBayar == null) listDetilBayar = new List<PenjualanBayarModel>();
                listDetilBayar.Add(itemKembali);
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

                IsBayarDeposit = DepositCheckBox.Checked,
                DepositID = DepositIDText.Text,
                NilaiDeposit = NilaiDepositText.Value, 

                NilaiBiayaKirim = biayaKirim,
                NilaiTotal = total,
                NilaiDiskonLain = diskon,
                NilaiBiayaLain = biayaLain,
                NilaiGrandTotal = grandTotal,
                NilaiBayar = bayarCash,
                NilaiKembali = kembali,
                
                ListBrg = listDetilBrg,
                ListBayar = listDetilBayar
            };

            PenjualanModel result = null;
            try
            {
                using (var trans = TransHelper.NewScope())
                {
                    //  save penjualan
                    result = _penjualanBL.Save(penjualan);
                    
                    //  generate kas
                    BPKasModel bpKas = null;
                    if(penjualan.ListBayar != null)
                        bpKas = _bpKasBL.Generate(penjualan);
                    
                    //  generate hutang lunas (kalo ada deposit)
                    BPHutangModel bpHutang = null;
                    if (penjualan.IsBayarDeposit)
                    {
                        var deposit = _depositBL.GetData(penjualan.DepositID);
                        bpHutang = _bpHutangBL.GenHutang(penjualan, deposit);
                    }

                    //  generate stok
                    //  copy original list
                    var listBrgOri = result.ListBrg.CloneObject();
                    //  remove item2 jasa di list
                    var listBrg = new List<Penjualan2Model>();
                    foreach(var item in result.ListBrg)
                        if(item.BrgID.ToLower().Contains("jasa"))
                        {

                        }
                        else
                        {
                            listBrg.Add(item);
                        }
                    result.ListBrg = listBrg;
                    var bpStok = _bpStokBL.Generate(result);
                    //  kembalikan list original-nya (utk kepentingan cetak)
                    result.ListBrg = listBrgOri;
                    trans.Complete();
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            if (result != null)
                LastIDLabel.Text = result.PenjualanID;

            if(MessageBox.Show("Cetak Nota ?","Penjualan", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var printDoc = new NotaJualPrintDoc(result);
                printDoc.Print();
            }
            ClearForm();
        }

        private void BayarCashNumText_ValueChanged(object sender, EventArgs e)
        {
            //  update listBayar
            //  jika belum ada isinya
            if (_listBayarDetil == null) _listBayarDetil = new List<PenjualanBayarModel>();

            //  jika belum ada baris KAS, tambahkan
            var jenisBayar = _jenisBayarBL.GetData("KAS");
            if (!_listBayarDetil.Where(x => x.JenisBayarID == "KAS").Any())
                _listBayarDetil.Add(new PenjualanBayarModel
                {
                    JenisBayarID = "KAS",
                    JenisBayarName = jenisBayar.JenisBayarName,
                    Catatan = "",
                });
            //  update nilai KAS
            foreach (var item in _listBayarDetil)
            {
                if (item.JenisBayarID == "KAS")
                {
                    item.NilaiBayar = BayarCashNumText.Value;
                    break;
                }
            }
            var totBayar = _listBayarDetil.Sum(x => x.NilaiBayar);
            if (DepositCheckBox.Checked)
                totBayar += NilaiDepositText.Value;
                
            KembaliNumText.Value = totBayar - GrandTotalNumText.Value;
            if (KembaliNumText.Value < 0) KembaliNumText.Value = 0;
        }

        private void BayarCashNumText_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F1)
            {
                BayarCashNumText.Value = GrandTotalNumText.Value - BayarNonCashNumText.Value;
            }
        }

        private void BayarCashNumText_Validated(object sender, EventArgs e)
        {
        }

        private void DepositCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            var checkBox = (CheckBox)sender;
            BayarDepositPanel.Visible = checkBox.Checked;
        }

        private void SearchDepositIDButton_Click(object sender, EventArgs e)
        {
            SearchDeposit();
            ShowDeposit();
        }

        private void SearchDeposit()
        {
            var searchForm = new SearchingForm<BPHutangSearchModel>(_bpHutangBL);
            var resultDialog = searchForm.ShowDialog();
            if (resultDialog == DialogResult.OK)
            {
                var result = searchForm.SelectedDataKey;
                DepositIDText.Text = result;
            }
        }

        private void ShowDeposit()
        {
            var bpHutang = _bpHutangBL.GetData(DepositIDText.Text);
            if(bpHutang == null)
            {
                TglDepositText.MinDate = DateTime.MinValue;
                TglDepositText.Value = TglDepositText.MinDate;
                JamDepositText.Text = "00:00:00";
                PihakKeduaNameText.Text = "";
                NilaiDepositText.Value = 0;
                KeteranganText.Text = "";
                return;
            }

            TglDepositText.Text = bpHutang.Tgl;
            JamDepositText.Text = bpHutang.Jam;
            PihakKeduaNameText.Text = bpHutang.PihakKeduaName;
            NilaiDepositText.Value = bpHutang.NilaiHutang - bpHutang.NilaiLunas;
            KeteranganText.Text = bpHutang.Keterangan;
        }

        private void BrgGrid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            var brgName = DetilPenjualanTable.Rows[e.RowIndex]["BrgName"].ToString();
            if ((brgName.Trim() != "") && (e.RowIndex == DetilPenjualanTable.Rows.Count - 1))
                AddRow();

            if ((e.ColumnIndex == 2) || (e.ColumnIndex == 4) || (e.ColumnIndex == 6))
            {
                if (brgName.ToLower().Contains("jasa"))
                {
                    //  boleh diedit jika JASA
                    e.Cancel = false;
                }
                else
                    e.Cancel = true;
            }
        }

        private void BiayaKirimNumText_ValueChanged(object sender, EventArgs e)
        {
            ReCalcTotal();
        }

        private void Deposit_Click(object sender, EventArgs e)
        {
            CreateDeposit();
        }

        private void CreateDeposit()
        {
            //  ambil list brg
            var listBrg = new List<DepositDetilModel>();
            foreach (DataRow dr in DetilPenjualanTable.Rows)
            {
                if (dr["BrgID"].ToString().Trim() == "") continue;

                var depositDetil = new DepositDetilModel()
                {
                    BrgID = dr["BrgID"].ToString(),
                    Qty = Convert.ToDecimal(dr["Qty"]),
                    Harga = Convert.ToDecimal(dr["Harga"]),
                    Diskon = Convert.ToDecimal(dr["Diskon"]),
                    SubTotal = Convert.ToDecimal(dr["SubTotal"])
                };
                listBrg.Add(depositDetil);
            }

            var jenisBayarID = "";
            if (_listBayarDetil != null)
            {
                jenisBayarID = _listBayarDetil.FirstOrDefault().JenisBayarID;
            }
            var pihakKeduaID = "";
            if(CustomerComboBox.SelectedValue != null)
            {
                pihakKeduaID = CustomerComboBox.SelectedValue.ToString();
            }


            //  save deposit
            var deposit = new DepositModel
            {
                Tgl = TanggalDateTime.Value.ToString("dd-MM-yyyy"),
                Jam = JamTextBox.Text,
                PihakKeduaID = pihakKeduaID,
                BuyerName = BuyerNameTextBox.Text,
                JenisBayarID = jenisBayarID,
                NilaiBiayaKirim = BiayaKirimNumText.Value,
                NilaiDeposit = GrandTotalNumText.Value,
                ListBrg = listBrg
            };

            var form = new DepositForm(deposit)
            {
                MdiParent = this.MdiParent,
                StartPosition = FormStartPosition.CenterScreen,
            };
            form.Show();
            ClearForm();
        }
    }
}
