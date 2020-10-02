using AnugerahBackend.StokBarang.BL;
using AnugerahBackend.StokBarang.Model;
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

namespace AnugerahWinform.StokBarang
{
    public partial class RegenStokForm : Form
    {
        private IBrgStokHargaBL _brgStokHargaBL;
        private IBrgBL _brgBL;
        private BPStokBL _bpStokBL;


        public RegenStokForm()
        {
            InitializeComponent();
            _brgStokHargaBL = new BrgStokHargaBL();
            _brgBL = new BrgBL();
            _bpStokBL = new BPStokBL();
            _bpStokBL.ProsesRegenStok += ProsesRegen;
            _bpStokBL.StartProses += StartProses;
        }


        private void ProsesRegen(object sender, ProsesRegenStokEventArgs e) 
        {
            ProgressLabel.Text = $"{e.Tgl} - {e.TrsID}";
            prgBar.Value = e.Counter;
            this.Refresh();
        }

        private void StartProses(object sender, StartProsesStokEventArgs e)
        {
            ProsesNameLabel.Text = e.ProsesName;
            prgBar.Maximum = e.DataCount;
            prgBar.Value = 0;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SearchBrgButton_Click(object sender, EventArgs e)
        {
            SearchBrg();
            ValidateBrgID();
        }

        private void BrgIDTextBox_Validated(object sender, EventArgs e)
        {
            ValidateBrgID();
        }
        private void ProsesButton_Click(object sender, EventArgs e)
        {
            Proses();
        }

        private void SearchBrg()
        {
            using (var searchForm = new SearchingForm<BrgStokHargaModel>(_brgStokHargaBL))
            {
                var resultDialog = searchForm.ShowDialog();
                if (resultDialog == DialogResult.OK)
                {
                    var result = searchForm.SelectedDataKey;
                    BrgIDTextBox.Text = result;
                }
            }
        }

        private void ValidateBrgID()
        {
            var brg = _brgBL.GetData(BrgIDTextBox.Text);
            if (brg is null)
                BrgNameTextBox.Text = string.Empty;
            else
                BrgNameTextBox.Text = brg.BrgName;
        }

        private void Proses()
        {
            _bpStokBL.Generate(BrgIDTextBox.Text);
        }

    }
}
