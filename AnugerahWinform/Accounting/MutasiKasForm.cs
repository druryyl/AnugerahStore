using AnugerahBackend.Accounting.BL;
using AnugerahBackend.Accounting.Model;
using AnugerahWinform.Accounting.Presenter;
using AnugerahWinform.Accounting.View;
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

namespace AnugerahWinform.Accounting
{
    public partial class MutasiKasForm : Form, IMutasiKasView
    {
        private readonly MutasiKasPresenter _presenter;

        public MutasiKasForm()
        {
            InitializeComponent();
            _presenter = new MutasiKasPresenter(this);
        }

        public string MutasiKasID
        {
            get => MutasiKasIDTextBox.Text;
            set => MutasiKasIDTextBox.Text = value;
        }
        public string Tgl
        {
            get => TglText.Value.ToString("dd-MM-yyyy");
            set => TglText.Value = value.ToDate();
        }
        public string Jam
        {
            get => JamText.Text;
            set => JamText.Text = value;
        }
        public string PegawaiID
        {
            get => KasirIDTextBox.Text;
            set => KasirIDTextBox.Text = value;
        }
        public string PegawaiName
        {
            get => KasirNameTextBox.Text;
            set => KasirNameTextBox.Text = value;
        }
        public string JenisKasIDAsal
        {
            get => JenisKasIDAsalTextBox.Text;
            set => JenisKasIDAsalTextBox.Text = value;
        }
        public string JenisKasNameAsal
        {
            get => JenisKasNameAsalTextBox.Text;
            set => JenisKasNameAsalTextBox.Text = value;
        }
        public string JenisKasIDTujuan
        {
            get => JenisKasIDTujuanTextBox.Text ;
            set => JenisKasIDTujuanTextBox.Text = value;
        }
        public string JenisKasNameTujuan
        {
            get => JenisKasNameTujuanTextBox.Text;
            set => JenisKasNameTujuanTextBox.Text = value;
        }
        public decimal NilaiKas
        {
            get => NilaiKasTextBox.Value;
            set => NilaiKasTextBox.Value = value;
        }
        public string Keterangan
        {
            get => KeteranganText.Text;
            set => KeteranganText.Text = value;
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            _presenter.PilihMutasiKas();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            _presenter.Save();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            _presenter.Delete();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NewButton_Click(object sender, EventArgs e)
        {
            _presenter.New();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _presenter.PilihKasir();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _presenter.PilihJenisKasAsal();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _presenter.PilihJenisKasTujuan();
        }
    }
}
