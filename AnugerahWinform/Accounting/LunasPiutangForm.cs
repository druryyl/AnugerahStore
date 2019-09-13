using AnugerahBackend.Accounting.Model;
using AnugerahBackend.Penjualan.Model;
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
    public partial class LunasPiutangForm : Form, ILunasPiutangView
    {
        private readonly LunasPiutangPresenter _presenter;
        
        //  hidden property
        private string _customerID;
        private List<BPPiutangViewModel> _listPiutang = new List<BPPiutangViewModel>();
        private List<JenisBayarViewModel> _listJenisBayar = new List<JenisBayarViewModel>();

        //  binding object
        private BindingSource _bpPiutangBindingSource = new BindingSource();

        public LunasPiutangForm()
        {
            InitializeComponent();
            _presenter = new LunasPiutangPresenter(this);

            //  bind collection to grid
            _bpPiutangBindingSource.DataSource = _listPiutang;
            ListPiutangGrid.DataSource = _bpPiutangBindingSource;

            var numberStyle = new DataGridViewCellStyle
            {
                Format = "N0",
                Alignment = DataGridViewContentAlignment.MiddleRight
            };
            ListPiutangGrid.Columns["BPPiutangID"].ReadOnly = true;
            ListPiutangGrid.Columns["BPPiutangID"].HeaderText = "Piutang ID";

            ListPiutangGrid.Columns["Tgl"].ReadOnly = true;
            ListPiutangGrid.Columns["Tgl"].HeaderText = "Tgl Nota";

            ListPiutangGrid.Columns["Nilai"].DefaultCellStyle = numberStyle;
            ListPiutangGrid.Columns["Nilai"].ReadOnly = true;

            ListPiutangGrid.Columns["Bayar"].DefaultCellStyle = numberStyle;
        }

        public string LunasPiutangID
        {
            get => LunasPiutangIDTextBox.Text;
            set => LunasPiutangIDTextBox.Text = value;
        }
        public string Tgl
        {
            get => TglTextBox.Value.ToString("dd-MM-yyyy");
            set => TglTextBox.Value = value.ToDate();
        }
        public string Jam
        {
            get => JamTextBox.Text;
            set => JamTextBox.Text = value;
        }
        public string CustomerID
        {
            get => _customerID;
            set => _customerID = value;
        }
        public string CustomerName
        {
            get => CustomerNameTextBox.Text;
            set => CustomerNameTextBox.Text = value;
        }
        public decimal TotalPiutang
        {
            get => TotalPiutangTextBox.Value;
            set => TotalPiutangTextBox.Value = value;
        }
        public decimal TotalBayar
        {
            get => TotalBayarTextBox.Value;
            set => TotalBayarTextBox.Value = value;
        }
        public List<BPPiutangViewModel> ListPiutang
        {
            get => _listPiutang;
            set => _listPiutang = value;
        }
        public List<JenisBayarViewModel> ListJenisBayar
        {
            get => _listJenisBayar;
            set => _listJenisBayar = value;
        }

        private void NewButton_Click(object sender, EventArgs e)
        {
            _presenter.NewLunasPiutang();
        }

        private void SearchCustomerButton_Click(object sender, EventArgs e)
        {
            _presenter.PilihCustomer();
        }

        private void ListPiutangGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            _presenter.ListPiutangValidated();
        }
    }
}
