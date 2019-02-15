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
    public partial class LunasKasBonForm : Form
    {
        private ILunasKasBonBL _lunasKasBonBL;
        private IKasBonBL _kasBonBL;
        private IBPPiutangBL _bpPiutangBL;

        public LunasKasBonForm()
        {
            InitializeComponent();
            _lunasKasBonBL = new LunasKasBonBL();
            _kasBonBL = new KasBonBL();
            _bpPiutangBL = new BPPiutangBL();
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
            var lunasKasBon = new LunasKasBonModel
            {
                LunasKasBonID = LunasKasBonIDText.Text,
                Tgl = TglText.Value.ToString("dd-MM-yyyy"),
                Jam = JamText.Text,
                KasBonID = KasBonIDText.Text,
                PihakKeduaID = PihakKeduaText.Text,
                NilaiSisaPiutang = NilaiSisaPiutangText.Value,
                NilaiTotLunas = NilaiTotLunasText.Value
            };

            List<LunasKasBonDetilModel> listLunas = null;
            foreach(DataRow dr in ListLunasTable.Rows)
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

            using (var trans = TransHelper.NewScope())
            {
                var result = _lunasKasBonBL.Save(lunasKasBon);
                //_bpKasBL.Generate(result);
                //_bpPiutangBL.GenPiutang(result);
                trans.Complete();
            }
        }

        private void ClearForm()
        {
            LunasKasBonIDText.Clear();
            TglText.Value = DateTime.Now;
            JamText.Text = DateTime.Now.ToString("HH:mm:ss");
            KasBonIDText.Clear();
            PihakKeduaText.Clear();
            KeteranganText.Clear();
            NilaiSisaPiutangText.Value = 0;
            ListLunasTable.Rows.Clear();
            AddRow();
            NilaiTotLunasText.Value = 0;
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
            PihakKeduaText.Text = kasBon.PihakKeduaName;
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

        private void AddRow()
        {
            ListLunasTable.Rows.Add("", "", 0);
        }

        private void LunasKasBonIDText_Validated(object sender, EventArgs e)
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

        private void SearchKasBonButton_Click(object sender, EventArgs e)
        {
            SearchBPPiutang();
            ShowDataBPPiutang();
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
            PihakKeduaText.Text = bpPiutang.PihakKeduaName;
            KeteranganText.Text = bpPiutang.Keterangan;
            NilaiSisaPiutangText.Value = bpPiutang.NilaiPiutang - bpPiutang.NilaiLunas;

            ListLunasGrid.Focus();
        }
    }
}
