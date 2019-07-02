using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AnugerahBackend.Accounting.BL;
using AnugerahBackend.Accounting.Model;
using AnugerahBackend.Penjualan.BL;
using AnugerahWinform.Support;
using Ics.Helper.Database;
using Ics.Helper.StringDateTime;

namespace AnugerahWinform.Accounting
{
    public partial class DepositForm : Form
    {
        private IDepositBL _depositBL;
        private IPihakKeduaBL _pihakKeduaBL;
        private IJenisBayarBL _jenisBayarBL;
        private IBPKasBL _bpKasBL;
        private IBPHutangBL _bpHutangBL;


        public DepositForm(DepositModel deposit)
        {
            InitializeComponent();

            _pihakKeduaBL = new PihakKeduaBL();
            _depositBL = new DepositBL();
            _jenisBayarBL = new JenisBayarBL();
            _bpKasBL = new BPKasBL();
            _bpHutangBL = new BPHutangBL();

            LoadPihakKeduaCombo();
            LoadJenisBayarCombo();
            if (deposit != null)
                ShowGeneratedDeposit(deposit);
        }

        private void ShowGeneratedDeposit(DepositModel deposit)
        {
            if (deposit == null)
            {
                ClearForm();
                return;
            }

            TglText.Value = deposit.Tgl.ToDate();
            JamText.Text = deposit.Jam;
            decimal estimasiBiayaKirim = deposit.NilaiDeposit -
                deposit.ListBrg.Sum(x => x.SubTotal);
            KeteranganText.Text = _depositBL
                .ListBrgString(deposit.ListBrg, estimasiBiayaKirim);
            PihakKeduaCombo.SelectedValue = deposit.PihakKeduaID;
            JenisBayarCombo.SelectedValue = deposit.JenisBayarID;
            NilIText.Value = deposit.NilaiDeposit;
        }

        private void LoadPihakKeduaCombo()
        {
            //  kosongkan combobox
            PihakKeduaCombo.DataSource = null;
            PihakKeduaCombo.Items.Clear();

            //  ambil data
            var listJenisBiaya = _pihakKeduaBL.ListData();

            //  exit jika kosong
            if (listJenisBiaya == null)
                return;

            listJenisBiaya = listJenisBiaya.OrderBy(x => x.PihakKeduaName).ToList();
            PihakKeduaCombo.DataSource = listJenisBiaya;
            PihakKeduaCombo.DisplayMember = "PihakKeduaName";
            PihakKeduaCombo.ValueMember = "PihakKeduaID";

            PihakKeduaCombo.SelectedItem = null;
        }

        private void LoadJenisBayarCombo()
        {
            //  kosongkan combobox
            JenisBayarCombo.DataSource = null;
            JenisBayarCombo.Items.Clear();

            //  ambil data
            var listJenisBayar = _jenisBayarBL.ListData();

            //  exit jika kosong
            if (listJenisBayar == null)
                return;

            listJenisBayar = listJenisBayar.OrderBy(x => x.JenisBayarName).ToList();
            JenisBayarCombo.DataSource = listJenisBayar;
            JenisBayarCombo.DisplayMember = "JenisBayarName";
            JenisBayarCombo.ValueMember = "JenisBayarID";

            JenisBayarCombo.SelectedItem = null;
        }


        private void UpdateJamText()
        {
            JamText.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void UpdateTglText()
        {
            TglText.Value = DateTime.Now;
        }

        private void JamTimer_Tick(object sender, EventArgs e)
        {
            UpdateJamText();
        }

        private void Save()
        {
            var deposit = new DepositModel
            {
                DepositID = BiayaIDText.Text,
                Tgl = TglText.Value.ToString("dd-MM-yyyy"),
                Jam = JamText.Text,
                PihakKeduaID = PihakKeduaCombo.SelectedValue.ToString(),
                JenisBayarID = JenisBayarCombo.SelectedValue.ToString(),
                Keterangan = KeteranganText.Text,
                NilaiDeposit = NilIText.Value
            };

            using (var trans = TransHelper.NewScope())
            {
                var result = _depositBL.Save(deposit);
                _bpKasBL.Generate(result);
                _bpHutangBL.GenHutang(result);
                trans.Complete();
            }
        }

        private void ClearForm()
        {
            BiayaIDText.Clear();
            TglText.Value = DateTime.Now;
            JamText.Text = DateTime.Now.ToString("HH:mm:ss");
            PihakKeduaCombo.SelectedIndex = -1;
            JenisBayarCombo.SelectedIndex = -1;
            KeteranganText.Clear();
            NilIText.Value = 0;
        }

        private void NewButton_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Save();
            ClearForm();
            TglText.Focus();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DepositIDText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                SearchKodeTrs();
                TglText.Focus();
            }
        }
        private void SearchKodeTrs()
        {
            var searchForm = new SearchingForm<DepositSearchModel>(_depositBL);
            var resultDialog = searchForm.ShowDialog();
            if (resultDialog == DialogResult.OK)
            {
                var result = searchForm.SelectedDataKey;
                BiayaIDText.Text = result;
            }
        }
        private void ShowData()
        {
            var deposit = _depositBL.GetData(BiayaIDText.Text);
            if (deposit == null)
            {
                ClearForm();
                return;
            }

            TglText.Value = deposit.Tgl.ToDate();
            JamText.Text = deposit.Jam;
            KeteranganText.Text = deposit.Keterangan;
            PihakKeduaCombo.SelectedValue = deposit.PihakKeduaID;
            JenisBayarCombo.SelectedValue = deposit.JenisBayarID;
            NilIText.Value = deposit.NilaiDeposit;
        }

        private void DepositIDText_Validated(object sender, EventArgs e)
        {
            ShowData();
            TglText.Focus();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            SearchKodeTrs();
            ShowData();
            TglText.Focus();
        }

        private void ExitButton_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
