using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AnugerahWinform.Penjualan.Presenter;
using AnugerahWinform.Penjualan.View;

namespace AnugerahWinform.Penjualan
{
    public partial class CustomerForm : Form, ICustomerView
    {
        private CustomerPresenter _presenter;

        public CustomerForm()
        {
            InitializeComponent();
            _presenter = new CustomerPresenter(this);
        }

        public string CustomerID
        {
            get => CustomerIDTextBox.Text;
            set => CustomerIDTextBox.Text = value;
        }
        public string CustomerName
        {
            get => CustomerNameTextBox.Text;
            set => CustomerNameTextBox.Text = value;
        }
        public string Alamat1
        {
            get => AlamatTextBox.Text;
            set => AlamatTextBox.Text = value;
        }
        public string Alamat2
        {
            get => Alamat2TextBox.Text;
            set => Alamat2TextBox.Text = value;
        }
        public string NoTelp
        {
            get => NoTelponTextBox.Text;
            set => NoTelponTextBox.Text = value;
        }

        public string ContactPerson
        {
            get => ContactPersonTextBox.Text;
            set => ContactPersonTextBox.Text = value;
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            _presenter.PilihCustomer();
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
