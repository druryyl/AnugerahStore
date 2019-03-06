using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AnugerahWinform.Accounting.Presenter;
using AnugerahWinform.Accounting.View;
using AnugerahWinform.Pembelian.Presenter;
using AnugerahWinform.Pembelian.View;

namespace AnugerahWinform.Accounting
{
    public partial class PegawaiForm : Form, IPegawaiView
    {
        private PegawaiPresenter _presenter;

        public PegawaiForm()
        {
            InitializeComponent();
            _presenter = new PegawaiPresenter(this);
        }

        public string PegawaiID
        {
            get => PegawaiIDTextBox.Text;
            set => PegawaiIDTextBox.Text = value;
        }
        public string PegawaiName
        {
            get => PegawaiNameTextBox.Text;
            set => PegawaiNameTextBox.Text = value;
        }
        public string Alamat
        {
            get => AlamatTextBox.Text;
            set => AlamatTextBox.Text = value;
        }
        public string NoTelp
        {
            get => NoTelpTextBox.Text;
            set => NoTelpTextBox.Text = value;
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            _presenter.PilihPegawai();
        }

        private void NewButton_Click(object sender, EventArgs e)
        {
            _presenter.New();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            _presenter.Save();
            _presenter.New();
        }
    }
}
