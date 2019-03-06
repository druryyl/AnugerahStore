using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AnugerahWinform.Pembelian.Presenter;
using AnugerahWinform.Pembelian.View;

namespace AnugerahWinform.Pembelian
{
    public partial class SupplierForm : Form, ISupplierView
    {
        private SupplierPresenter _presenter;


        public SupplierForm()
        {
            InitializeComponent();
            _presenter = new SupplierPresenter(this);
        }

        public string SupplierID
        {
            get => SupplierIDTextBox.Text;
            set => SupplierIDTextBox.Text = value;
        }
        public string SupplierName
        {
            get => SupplierNameTextBox.Text;
            set => SupplierNameTextBox.Text = value;
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
            _presenter.PilihSupplier();
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
