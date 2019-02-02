using AnugerahBackend.Keuangan.BL;
using AnugerahBackend.Keuangan.Dal;
using AnugerahBackend.Keuangan.Model;
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

namespace AnugerahWinform.Keuangan
{
    public partial class KasirForm : Form
    {
        private IJenisTrsKasirDal _jenisTrsKasirDal;
        private IPihakKetigaBL _pihakKetigaBL;
        private IBukuKasBL _bukuKasBL;

        public KasirForm()
        {
            InitializeComponent();
            _jenisTrsKasirDal = new JenisTrsKasirDal();
            _pihakKetigaBL = new PihakKetigaBL();
            _bukuKasBL = new BukuKasBL();

            LoadComboJenisTrs();
            ClearForm();
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

        private void SearchPihakKetiga()
        {
            var searchForm = new SearchingForm<PihakKetigaModel>(_pihakKetigaBL, false);
            var resultDialog = searchForm.ShowDialog();
            if (resultDialog == DialogResult.OK)
            {
                var result = searchForm.SelectedDataKey;
                PihakKetigaText.Text = result;
            }
        }

        private void SearchBukuKas()
        {
            var searchForm = new SearchingForm<BukuKasSearchModel>(_bukuKasBL, true);
            var resultDialog = searchForm.ShowDialog();
            if (resultDialog == DialogResult.OK)
            {
                var result = searchForm.SelectedDataKey;
                BukuKasIDTextBox.Text = result;
            }
        }

        private void ValidasiPihakKetigaID()
        {
            var pihakKetiga = _pihakKetigaBL.GetData(PihakKetigaText.Text);
            if(pihakKetiga != null)
                PihakKetigaNameText.Text = pihakKetiga.PihakKetigaName;
            else
                PihakKetigaNameText.Text = "";
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

        private void SaveTransaksi()
        {
            var jenisTrsID = JenisTrsCombo.SelectedValue.ToString();
            decimal nilaiKasMasuk = 0;
            decimal nilaiKasKeluar = 0;
            if ((jenisTrsID == "BIY") || (jenisTrsID == "PTG") || (jenisTrsID == "HTL"))
                nilaiKasKeluar = NilaiText.Value;
            else
                nilaiKasMasuk = NilaiText.Value;

            var bukuKas = new BukuKasModel
            {
                BukuKasID = BukuKasIDTextBox.Text,
                TglBuku = TglBukuTextBox.Value.ToString("dd-MM-yyyy"),
                JamBuku = JamBukuTextBox.Text,
                JenisTrsKasirID = JenisTrsCombo.SelectedValue.ToString(),
                ReffID = ReffIDText.Text,
                Keterangan = KeteranganText.Text,
                NilaiKasMasuk = nilaiKasMasuk,
                NilaiKasKeluar = nilaiKasKeluar,
                PihakKetigaID = PihakKetigaText.Text,
                UserrID = "",
            };
            _bukuKasBL.Save(bukuKas);
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

        private void NewButton_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveTransaksi();
            ClearForm();
            BukuKasIDTextBox.Focus();
        }
    }
}
