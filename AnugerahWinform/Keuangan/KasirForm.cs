using AnugerahBackend.Keuangan.BL;
using AnugerahBackend.Keuangan.Dal;
using AnugerahBackend.Keuangan.Model;
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

namespace AnugerahWinform.Keuangan
{
    public partial class KasirForm : Form
    {
        private IJenisTrsKasirDal _jenisTrsKasirDal;
        private IPihakKetigaBL _pihakKetigaBL;
        private IBukuKasBL _bukuKasBL;
        private IBukuPiutangBL _bukuPiutangBL;

        public KasirForm()
        {
            InitializeComponent();
            _jenisTrsKasirDal = new JenisTrsKasirDal();
            _pihakKetigaBL = new PihakKetigaBL();
            _bukuKasBL = new BukuKasBL();
            _bukuPiutangBL = new BukuPiutangBL();

            LoadComboJenisTrs();
            ClearForm();
        }


        private void NewButton_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
        private void BukuKasIDTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                SearchBukuKas();
                ValidasiBukuKasID();
            }
        }
        private void SearchBukuKasButton_Click(object sender, EventArgs e)
        {
            SearchBukuKas();
            ValidasiBukuKasID();
        }

        private void JenisTrsCombo_SelectedValueChanged(object sender, EventArgs e)
        {
            SetEnabledReffID();
        }
        private void PihakKetigaText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                SearchPihakKetiga();
                ValidasiPihakKetigaID();
            }
        }
        private void SearchPihakKetigaButton_Click(object sender, EventArgs e)
        {
            SearchPihakKetiga();
            ValidasiPihakKetigaID();
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            //try
            //{
            SaveTransaksi();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //    return;
            //}

            ClearForm();
            BukuKasIDTextBox.Focus();
        }

        private void ClearForm()
        {
            BukuKasIDTextBox.Clear();
            TglBukuTextBox.Value = DateTime.Now;
            JamBukuTextBox.Text = DateTime.Now.ToString("HH:mm:ss");
            JenisTrsCombo.SelectedItem = null;
            PihakKetigaText.Clear();
            PihakKetigaNameText.Clear();
            ReffIDText.Clear();
            KeteranganText.Clear();
            NilaiText.Value = 0;
        }
        private void LoadComboJenisTrs()
        {
            //  kosongkan combobox
            JenisTrsCombo.DataSource = null;
            JenisTrsCombo.Items.Clear();

            //  ambil data
            var listJenisTrs = _jenisTrsKasirDal.ListData();

            //  exit jika kosong
            if (listJenisTrs == null)
                return;

            JenisTrsCombo.DataSource = listJenisTrs;
            JenisTrsCombo.DisplayMember = "JenisTrsKasirName";
            JenisTrsCombo.ValueMember = "JenisTrsKasirID";

            JenisTrsCombo.SelectedItem = null;
        }
        private void SetEnabledReffID()
        {
            switch (JenisTrsCombo.SelectedValue)
            {
                case "BIY":
                    ReffIDText.Clear();
                    ReffNotesText.Clear();
                    ReffIDText.Enabled = false;
                    ReffNotesText.Enabled = false;
                    break;

                case "PTG":
                    ReffIDText.Clear();
                    ReffNotesText.Clear();
                    ReffIDText.Enabled = false;
                    ReffNotesText.Enabled = false;
                    break;

                case "PTL":
                    ReffIDText.Enabled = true;
                    ReffNotesText.Enabled = true;
                    break;

                case "HTG":
                    ReffIDText.Clear();
                    ReffNotesText.Clear();
                    ReffIDText.Enabled = false;
                    ReffNotesText.Enabled = false;
                    break;

                case "HTL":
                    ReffIDText.Enabled = true;
                    ReffNotesText.Enabled = true;
                    break;

                default:
                    break;
            }
        }
        private void SearchBukuKas()
        {
            var searchForm = new SearchingForm<BukuKasSearchModel>(_bukuKasBL);
            var resultDialog = searchForm.ShowDialog();
            if (resultDialog == DialogResult.OK)
            {
                var result = searchForm.SelectedDataKey;
                BukuKasIDTextBox.Text = result;
            }
        }
        private void ValidasiBukuKasID()
        {
            var bukuKasID = BukuKasIDTextBox.Text;
            ClearForm();

            var bukuKas = _bukuKasBL.GetData(bukuKasID);
            if (bukuKas == null)
                return;

            BukuKasIDTextBox.Text = bukuKas.BukuKasID;
            TglBukuTextBox.Value = bukuKas.TglBuku.ToDate();
            JamBukuTextBox.Text = bukuKas.JamBuku;
            JenisTrsCombo.SelectedValue = bukuKas.JenisTrsKasirID;
            PihakKetigaText.Text = bukuKas.PihakKetigaID;
            PihakKetigaNameText.Text = bukuKas.PihakKetigaName;
            ReffIDText.Text = bukuKas.ReffID;
            KeteranganText.Text = bukuKas.Keterangan;
            NilaiText.Value = bukuKas.NilaiKas;

        }

        private void SearchPihakKetiga()
        {
            var searchForm = new SearchingForm<PihakKetigaModel>(_pihakKetigaBL);
            var resultDialog = searchForm.ShowDialog();
            if (resultDialog == DialogResult.OK)
            {
                var result = searchForm.SelectedDataKey;
                PihakKetigaText.Text = result;
            }
        }
        private void ValidasiPihakKetigaID()
        {
            var pihakKetiga = _pihakKetigaBL.GetData(PihakKetigaText.Text);
            if (pihakKetiga != null)
                PihakKetigaNameText.Text = pihakKetiga.PihakKetigaName;
            else
                PihakKetigaNameText.Text = "";
        }

        private void SearchBukuPiutang()
        {
            var pihakKetiga = PihakKetigaText.Text;
            var searchForm = new SearchingForm<BukuPiutangSearchModel>(_bukuPiutangBL);
            var resultDialog = searchForm.ShowDialog();
            if (resultDialog == DialogResult.OK)
            {
                var result = searchForm.SelectedDataKey;
                PihakKetigaText.Text = result;
            }

        }

        private void SaveTransaksi()
        {
            var jenisTrsID = JenisTrsCombo.SelectedValue.ToString();

            var bukuKas = new BukuKasModel
            {
                BukuKasID = BukuKasIDTextBox.Text,
                TglBuku = TglBukuTextBox.Value.ToString("dd-MM-yyyy"),
                JamBuku = JamBukuTextBox.Text,
                JenisTrsKasirID = JenisTrsCombo.SelectedValue.ToString(),
                ReffID = ReffIDText.Text,
                Keterangan = KeteranganText.Text,
                NilaiKas = NilaiText.Value,
                PihakKetigaID = PihakKetigaText.Text,
                UserrID = "",
            };
            _bukuKasBL.Save(bukuKas);
        }


    }
}
