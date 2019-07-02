using AnugerahBackend.Penjualan.Model;
using AnugerahWinform.Penjualan.Presenter;
using AnugerahWinform.Penjualan.View;
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

namespace AnugerahWinform.Penjualan
{
    public partial class OrderJualForm : Form, IOrderJualView
    {
        private OrderJualPresenter presenter;

        public OrderJualForm()
        {
            InitializeComponent();
            presenter = new OrderJualPresenter(this);
        }

        public string OrderJualID
        {
            get => OrderJualIDTextBox.Text;
            set => OrderJualIDTextBox.Text = value;
        }

        public string TglOrderJual
        {
            get => TglOrderTextBox.Value.ToString("dd-MM-yyyy");
            set => TglOrderTextBox.Value = value.ToDate();
        }
        public string JamOrderJual
        {
            get => JamOrderTextBox.Text;
            set => JamOrderTextBox.Text = value;
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
        public string BuyerName
        {
            get => BuyerNameTextBox.Text;
            set => BuyerNameTextBox.Text = value;
        }
        public string Alamat
        {
            get => AlamatTextBox.Text;
            set => AlamatTextBox.Text = value;
        }
        public string NoTelpon
        {
            get => NoTelpTextBox.Text;
            set => NoTelpTextBox.Text = value;
        }
        public string Catatan
        {
            get => CatatanTextBox.Text;
            set => CatatanTextBox.Text = value;
        }
        public List<OrderJual2Model> ListBrg { get; set; }

        public decimal NilaiTotal
        {
            get => TotalNumText.Value;
            set => TotalNumText.Value = value;
        }
        public decimal NilaiDiskonLain
        {
            get => DiskonNumText.Value;
            set => DiskonNumText.Value = value;
        }
        public decimal NilaiBiayaLain
        {
            get => BiayaLainNumText.Value;
            set => BiayaLainNumText.Value = value;
        }
        public decimal NilaiGrandTotal
        {
            get => GrandTotalNumText.Value;
            set => GrandTotalNumText.Value = value;
        }

        private void NewButton_Click(object sender, EventArgs e)
        {
            presenter.New();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DiskonNumText_ValueChanged(object sender, EventArgs e)
        {
            presenter.CalculateTotal();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            presenter.Save();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Hapus Order Jual?","Order Jual", 
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            presenter.Delete();
        }

        private void SearchCustomerButton_Click(object sender, EventArgs e)
        {
            CustomerIDTextBox.Text = presenter.PilihCustomer();
        }
    }
}
