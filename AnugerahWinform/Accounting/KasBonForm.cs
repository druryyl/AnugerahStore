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
    public partial class KasBonForm : Form
    {
        private IKasBonBL _kasBonBL;
        private IPihakKeduaBL _pihakKeduaBL;
        private IJenisKasBL _jenisKasBL;
        private IBPKasBL _bpKasBL;
        private IBPPiutangBL _bpPiutangBL;

        public KasBonForm()
        {
            InitializeComponent();

            _pihakKeduaBL = new PihakKeduaBL();
            _kasBonBL = new KasBonBL();
            _jenisKasBL = new JenisKasBL();
            _bpKasBL = new BPKasBL();
            _bpPiutangBL = new BPPiutangBL();

            LoadPihakKeduaCombo();
            LoadJenisKasCombo();
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
            var kasBon = new KasBonModel
            {
                KasBonID = BiayaIDText.Text,
                Tgl = TglText.Value.ToString("dd-MM-yyyy"),
                Jam = JamText.Text,
                PihakKeduaID = PihakKeduaCombo.SelectedValue.ToString(),
                JenisKasID = JenisKasCombo.SelectedValue.ToString(),
                Keterangan = KeteranganText.Text,
                NilaiKasBon = NilIText.Value
            };

            using (var trans = TransHelper.NewScope())
            {
                var result = _kasBonBL.Save(kasBon);
                _bpKasBL.Generate(result);
                _bpPiutangBL.GenPiutang(result);
                trans.Complete();
            }
        }

        private void ClearForm()
        {
            BiayaIDText.Clear();
            TglText.Value = DateTime.Now;
            JamText.Text = DateTime.Now.ToString("HH:mm_ss");
            PihakKeduaCombo.SelectedIndex = -1;
            JenisKasCombo.SelectedIndex = -1;
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

        private void KasBonIDText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                SearchKodeTrs();
                TglText.Focus();
            }
        }
        private void SearchKodeTrs()
        {
            var searchForm = new SearchingForm<KasBonSearchModel>(_kasBonBL);
            var resultDialog = searchForm.ShowDialog();
            if (resultDialog == DialogResult.OK)
            {
                var result = searchForm.SelectedDataKey;
                BiayaIDText.Text = result;
            }
        }
        private void ShowData()
        {
            var kasBon = _kasBonBL.GetData(BiayaIDText.Text);
            if (kasBon == null)
            {
                ClearForm();
                return;
            }

            TglText.Value = kasBon.Tgl.ToDate();
            JamText.Text = kasBon.Jam;
            KeteranganText.Text = kasBon.Keterangan;
            PihakKeduaCombo.SelectedValue = kasBon.PihakKeduaID;
            JenisKasCombo.SelectedValue = kasBon.JenisKasID;
            NilIText.Value = kasBon.NilaiKasBon;
        }

        private void KasBonIDText_Validated(object sender, EventArgs e)
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
    }
}
