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
using AnugerahWinform.Support;
using Ics.Helper.Database;
using Ics.Helper.StringDateTime;

namespace AnugerahWinform.Accounting
{
    public partial class ReturDepositForm : Form
    {
        private IReturDepositBL _returDepositBL;
        private IDepositBL _depositBL;
        private IBPHutangBL _bpHutangBL;
        private IJenisKasBL _jenisKasBL;
        private IBPKasBL _bpKasBL;

        public ReturDepositForm()
        {
            InitializeComponent();
            _returDepositBL = new ReturDepositBL();
            _depositBL = new DepositBL();
            _bpHutangBL = new BPHutangBL();
            _jenisKasBL = new JenisKasBL();
            _bpKasBL = new BPKasBL();

            LoadJenisKasCombo();
        }
        private void ReturDepositIDText_Validated(object sender, EventArgs e)
        {
            ShowData();
            TglText.Focus();
        }
        private void NewButton_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
        private void SearchButton_Click(object sender, EventArgs e)
        {
            SearchKodeTrs();
            ShowData();
            TglText.Focus();
        }
        private void ReturDepositIDText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                SearchKodeTrs();
                TglText.Focus();
            }
        }
        private void SearchDepositButton_Click(object sender, EventArgs e)
        {
            SearchBPHutang();
            ShowDataBPHutang();
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
        private void JamTimer_Tick(object sender, EventArgs e)
        {
            UpdateJamText();
        }

        private void ClearForm()
        {
            ReturDepositIDText.Clear();
            TglText.Value = DateTime.Now;
            JamText.Text = DateTime.Now.ToString("HH:mm:ss");
            DepositIDText.Clear();
            PihakKeduaNameText.Clear();
            PihakKeduaNameText.Clear();
            KeteranganDepositText.Clear();
            SisaDepositText.Value = 0;
            NilaiReturText.Value = 0;
        }
        private void SearchKodeTrs()
        {
            var searchForm = new SearchingForm<ReturDepositSearchModel>(_returDepositBL);
            var resultDialog = searchForm.ShowDialog();
            if (resultDialog == DialogResult.OK)
            {
                var result = searchForm.SelectedDataKey;
                ReturDepositIDText.Text = result;
            }
        }
        private void ShowData()
        {
            var returDeposit = _returDepositBL.GetData(ReturDepositIDText.Text);
            if (returDeposit == null)
            {
                ClearForm();
                return;
            }

            TglText.Value = returDeposit.Tgl.ToDate();
            JamText.Text = returDeposit.Jam;
            DepositIDText.Text = returDeposit.DepositID;
            PihakKeduaNameText.Text = returDeposit.PihakKeduaName;
            SisaDepositText.Value = returDeposit.NilaiSisaDeposit;
            var deposit = _depositBL.GetData(returDeposit.DepositID);
            KeteranganDepositText.Text = deposit.Keterangan;

            KeteranganReturDepositText.Text = returDeposit.Catatan;

            JenisKasCombo.SelectedValue = returDeposit.JenisKasID;
            NilaiReturText.Value = returDeposit.NilaiReturDeposit;
            
        }
        private void SearchBPHutang()
        {
            var searchForm = new SearchingForm<BPHutangSearchModel>(_bpHutangBL);
            var resultDialog = searchForm.ShowDialog();
            if (resultDialog == DialogResult.OK)
            {
                var result = searchForm.SelectedDataKey;
                DepositIDText.Text = result;
            }
        }
        private void ShowDataBPHutang()
        {
            var bpHutang = _bpHutangBL.GetData(DepositIDText.Text);
            if (bpHutang == null)
            {
                ClearForm();
                return;
            }
            PihakKeduaNameText.Text = bpHutang.PihakKeduaName;
            KeteranganDepositText.Text = bpHutang.Keterangan;
            SisaDepositText.Value = bpHutang.NilaiHutang - bpHutang.NilaiLunas;
        }

        private void LoadJenisKasCombo()
        {
            //  kosongkan combobox
            JenisKasCombo.DataSource = null;
            JenisKasCombo.Items.Clear();

            //  ambil data
            var listJenisKas = _jenisKasBL.ListData();

            //  exit jika kosong
            if (listJenisKas == null)
                return;

            listJenisKas = listJenisKas.OrderBy(x => x.JenisKasName).ToList();
            JenisKasCombo.DataSource = listJenisKas;
            JenisKasCombo.DisplayMember = "JenisKasName";
            JenisKasCombo.ValueMember = "JenisKasID";

            JenisKasCombo.SelectedItem = null;
        }
        private void Save()
        {
            var returDeposit = new ReturDepositModel
            {
                ReturDepositID = ReturDepositIDText.Text,
                Tgl = TglText.Value.ToString("dd-MM-yyyy"),
                Jam = JamText.Text,
                DepositID = DepositIDText.Text,
                JenisKasID = JenisKasCombo.SelectedValue.ToString(),
                Catatan = KeteranganReturDepositText.Text,
                NilaiSisaDeposit = SisaDepositText.Value,
                NilaiReturDeposit = NilaiReturText.Value
            };

            var deposit = _depositBL.GetData(returDeposit.DepositID);

            using (var trans = TransHelper.NewScope())
            {
                var result = _returDepositBL.Save(returDeposit);
                var bpKas = _bpKasBL.Generate(returDeposit);
                var bpHutang = _bpHutangBL.GenHutang(returDeposit, deposit);

                trans.Complete();
            }
        }
        private void UpdateJamText()
        {
            JamText.Text = DateTime.Now.ToString("HH:mm:ss");
        }
        private void UpdateTglText()
        {
            TglText.Value = DateTime.Now;
        }

    }
}
