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
using AnugerahBackend.Accounting.Dal;
using AnugerahBackend.Accounting.Model;
using AnugerahWinform.Support;
using Ics.Helper.Database;
using Ics.Helper.StringDateTime;

namespace AnugerahWinform.Accounting
{
    public partial class LunasKasBonForm : Form
    {
        private ILunasKasBonBL _lunasKasBonBL;
        private IKasBonBL _kasBonBL;
        private IBPPiutangBL _bpPiutangBL;
        private IJenisLunasBL _jenisLunasBL;
        private IBPKasBL _bpKasBL;
        private IBiayaBL _biayaBL;
        public LunasKasBonForm()
        {
            InitializeComponent();
            _lunasKasBonBL = new LunasKasBonBL();
            _kasBonBL = new KasBonBL();
            _bpPiutangBL = new BPPiutangBL();
            _jenisLunasBL = new JenisLunasBL();
            _bpKasBL = new BPKasBL();
            _biayaBL = new BiayaBL();
            AddRow();
        }
        private void LunasKasBonIDText_Validated(object sender, EventArgs e)
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
        private void KasBonIDText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                SearchKodeTrs();
                TglText.Focus();
            }
        }
        private void SearchKasBonButton_Click(object sender, EventArgs e)
        {
            SearchBPPiutang();
            ShowDataBPPiutang();
        }

        private void ListLunasGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                SearchJenisLunas(e.RowIndex);
                ShowDataJenisLunas(e.RowIndex);
            }
        }
        private void ListLunasGrid_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            var jenisLunasName = ListLunasTable.Rows[e.RowIndex]["JenisLunasNameCol"].ToString();
            if ((jenisLunasName.Trim() != "") && (e.RowIndex == ListLunasTable.Rows.Count - 1))
                AddRow();
        }
        private void ListLunasGrid_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                ShowDataJenisLunas(e.RowIndex);
            }
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
            LunasKasBonIDText.Clear();
            TglText.Value = DateTime.Now;
            JamText.Text = DateTime.Now.ToString("HH:mm:ss");
            KasBonIDText.Clear();
            PihakKeduaIDText.Clear();
            PihakKeduaNameText.Clear();
            KeteranganText.Clear();
            NilaiSisaPiutangText.Value = 0;
            ListLunasTable.Rows.Clear();
            AddRow();
            NilaiTotLunasText.Value = 0;
        }
        private void SearchKodeTrs()
        {
            var searchForm = new SearchingForm<LunasKasBonSearchModel>(_lunasKasBonBL);
            var resultDialog = searchForm.ShowDialog();
            if (resultDialog == DialogResult.OK)
            {
                var result = searchForm.SelectedDataKey;
                LunasKasBonIDText.Text = result;
            }
        }
        private void ShowData()
        {
            var lunasKasBon = _lunasKasBonBL.GetData(LunasKasBonIDText.Text);
            if (lunasKasBon == null)
            {
                ClearForm();
                return;
            }

            TglText.Value = lunasKasBon.Tgl.ToDate();
            JamText.Text = lunasKasBon.Jam;
            KasBonIDText.Text = lunasKasBon.KasBonID;
            NilaiSisaPiutangText.Value = lunasKasBon.NilaiSisaPiutang;

            //  data kasbon
            var kasBon = _kasBonBL.GetData(lunasKasBon.KasBonID);
            PihakKeduaIDText.Text = kasBon.PihakKeduaID;
            PihakKeduaNameText.Text = kasBon.PihakKeduaName;
            KeteranganText.Text = kasBon.Keterangan;

            //  data grid
            ListLunasTable.Rows.Clear();
            foreach(var item in lunasKasBon.ListLunas)
            {
                ListLunasTable.Rows.Add(
                    item.JenisLunasID,
                    item.JenisLunasName, 
                    item.NilaiLunas
                    );
            }
            AddRow();
        }
        private void SearchBPPiutang()
        {
            var searchForm = new SearchingForm<BPPiutangSearchModel>(_bpPiutangBL);
            var resultDialog = searchForm.ShowDialog();
            if (resultDialog == DialogResult.OK)
            {
                var result = searchForm.SelectedDataKey;
                KasBonIDText.Text = result;
            }
        }
        private void ShowDataBPPiutang()
        {
            var bpPiutang = _bpPiutangBL.GetData(KasBonIDText.Text);
            if(bpPiutang == null)
            {
                ClearForm();
                return;
            }
            PihakKeduaIDText.Text = bpPiutang.PihakKeduaID;
            PihakKeduaNameText.Text = bpPiutang.PihakKeduaName;
            KeteranganText.Text = bpPiutang.Keterangan;
            NilaiSisaPiutangText.Value = bpPiutang.NilaiPiutang - bpPiutang.NilaiLunas;

            ListLunasGrid.Focus();
        }

        private void AddRow()
        {
            ListLunasTable.Rows.Add("", "", 0);
        }
        private void SearchJenisLunas(int rowIndex)
        {
            var searchForm = new SearchingForm<JenisLunasModel>(_jenisLunasBL);
            var resultDialog = searchForm.ShowDialog();
            if (resultDialog == DialogResult.OK)
            {
                var result = searchForm.SelectedDataKey;
                ListLunasTable.Rows[rowIndex]["JenisLunasIDCol"] = result;
            }
        }
        private void ShowDataJenisLunas(int rowIndex)
        {
            //  get key (jenisLunasID)
            string jenisLunasID = (string)ListLunasTable.Rows[rowIndex]["JenisLunasIDCol"];

            //  get nama barang
            var jenisLunasName = "";
            var jenisLunas = _jenisLunasBL.GetData(jenisLunasID);
            if (jenisLunas != null)
                jenisLunasName = jenisLunas.JenisLunasName;

            //  tampilkan di grid
            ListLunasTable.Rows[rowIndex]["JenisLunasNameCol"] = jenisLunasName;
        }

        private void Save()
        {
            var lunasKasBon = new LunasKasBonModel
            {
                LunasKasBonID = LunasKasBonIDText.Text,
                Tgl = TglText.Value.ToString("dd-MM-yyyy"),
                Jam = JamText.Text,
                KasBonID = KasBonIDText.Text,
                PihakKeduaID = PihakKeduaIDText.Text,
                NilaiSisaPiutang = NilaiSisaPiutangText.Value,
                NilaiTotLunas = NilaiTotLunasText.Value
            };

            List<LunasKasBonDetilModel> listLunas = null;
            foreach (DataRow dr in ListLunasTable.Rows)
            {
                if (listLunas == null) listLunas = new List<LunasKasBonDetilModel>();
                if (dr["JenisLunasNameCol"].ToString().Trim() == "") continue;

                listLunas.Add(new LunasKasBonDetilModel
                {
                    LunasKasBonID = "",
                    LunasKasBonDetilID = "",
                    JenisLunasID = dr["JenisLunasIDCol"].ToString(),
                    NilaiLunas = Convert.ToDecimal(dr["NilaiLunasCol"])
                });
            }
            lunasKasBon.ListLunas = listLunas;
            var kasBon = _kasBonBL.GetData(lunasKasBon.KasBonID);

            using (var trans = TransHelper.NewScope())
            {
                var result = _lunasKasBonBL.Save(lunasKasBon);
                var bpKas = _bpKasBL.Generate(lunasKasBon, kasBon);
                var bpPiutang = _bpPiutangBL.GenPiutang(lunasKasBon,kasBon);
                var biaya = _biayaBL.Generate(lunasKasBon);

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
