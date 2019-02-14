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
using Ics.Helper.StringDateTime;

namespace AnugerahWinform.Accounting
{
    public partial class BiayaForm : Form
    {
        private IBiayaBL _biayaBL;
        private IJenisBiayaBL _jenisBiayaBL;
        private IJenisKasBL _jenisKasBL;
        private IBPKasBL _bpKasBL;

        public BiayaForm()
        {
            InitializeComponent();

            _jenisBiayaBL = new JenisBiayaBL();
            _biayaBL = new BiayaBL();
            _jenisKasBL = new JenisKasBL();
            _bpKasBL = new BPKasBL();

            LoadJenisBiayaCombo();
            LoadJenisKasCombo();
        }

        private void LoadJenisBiayaCombo()
        {
            //  kosongkan combobox
            JenisBiayaCombo.DataSource = null;
            JenisBiayaCombo.Items.Clear();

            //  ambil data
            var listJenisBiaya = _jenisBiayaBL.ListData();

            //  exit jika kosong
            if (listJenisBiaya == null)
                return;

            listJenisBiaya = listJenisBiaya.OrderBy(x => x.JenisBiayaName).ToList();
            JenisBiayaCombo.DataSource = listJenisBiaya;
            JenisBiayaCombo.DisplayMember = "JenisBiayaName";
            JenisBiayaCombo.ValueMember = "JenisBiayaID";

            JenisBiayaCombo.SelectedItem = null;
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
            var biaya = new BiayaModel
            {
                BiayaID = BiayaIDText.Text,
                Tgl = TglText.Value.ToString("dd-MM-yyyy"),
                Jam = JamText.Text,
                JenisBiayaID = JenisBiayaCombo.SelectedValue.ToString(),
                JenisKasID = JenisKasCombo.SelectedValue.ToString(),
                Keterangan = KeteranganText.Text,
                NilaiBiaya = NilIText.Value
            };
            var result = _biayaBL.Save(biaya);

            _bpKasBL.Generate(result);
        }

        private void ClearForm()
        {
            BiayaIDText.Clear();
            TglText.Value = DateTime.Now;
            JamText.Text = DateTime.Now.ToString("HH:mm_ss");
            JenisBiayaCombo.SelectedIndex = -1;
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

        private void BiayaIDText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                SearchKodeTrs();
                TglText.Focus();
            }
        }
        private void SearchKodeTrs()
        {
            var searchForm = new SearchingForm<BiayaSearchModel>(_biayaBL);
            var resultDialog = searchForm.ShowDialog();
            if (resultDialog == DialogResult.OK)
            {
                var result = searchForm.SelectedDataKey;
                BiayaIDText.Text = result;
            }
        }
        private void ShowData()
        {
            var biaya = _biayaBL.GetData(BiayaIDText.Text);
            if (biaya == null)
            {
                ClearForm();
                return;
            }

            TglText.Value = biaya.Tgl.ToDate();
            JamText.Text = biaya.Jam;
            KeteranganText.Text = biaya.Keterangan;
            JenisBiayaCombo.SelectedValue = biaya.JenisBiayaID;
            JenisKasCombo.SelectedValue = biaya.JenisKasID;
            NilIText.Value = biaya.NilaiBiaya;
        }

        private void BiayaIDText_Validated(object sender, EventArgs e)
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
