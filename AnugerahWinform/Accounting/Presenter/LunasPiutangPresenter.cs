using AnugerahBackend.Accounting.BL;
using AnugerahBackend.Accounting.Model;
using AnugerahBackend.Penjualan.BL;
using AnugerahBackend.Penjualan.Model;
using AnugerahWinform.Accounting.View;
using AnugerahWinform.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnugerahWinform.Accounting.Presenter
{
    public class LunasPiutangPresenterDependency
    {
        public ICustomerBL CustomerBL { get; set; }
        public IBPPiutangBL BPPiutangBL { get; set; }
        public IJenisBayarBL JenisBayarBL { get; set; }
    }

    public class LunasPiutangPresenter
    {
        private readonly ILunasPiutangView _view;
        private LunasPiutangPresenterDependency _dep;
        private const string JENIS_KAS_PIUTANG = "K04";
        private const string DEFAULT_JENIS_BAYAR_ID = "KAS";
        public LunasPiutangPresenter(ILunasPiutangView view)
        {
            _view = view;
            _dep = new LunasPiutangPresenterDependency
            {
                CustomerBL = new CustomerBL(),
                BPPiutangBL = new BPPiutangBL(),
                JenisBayarBL = new JenisBayarBL()
            };
        }

        public LunasPiutangPresenter(ILunasPiutangView view, LunasPiutangPresenterDependency dep)
        {
            _view = view;
            _dep = dep;
        }

        public void NewLunasPiutang()
        {
            _view.LunasPiutangID = "";
            _view.Tgl = DateTime.Now.ToString("dd-MM-yyyy");
            _view.Jam = DateTime.Now.ToString("HH:mm:ss");
            _view.CustomerID = "";
            _view.CustomerName = "";
            _view.ListPiutang.Clear();
            _view.JenisBayarID = DEFAULT_JENIS_BAYAR_ID;
        }

        public void PilihCustomer()
        {
            var searchForm = new SearchingForm<CustomerSearchModel>(_dep.CustomerBL);
            var resultDialog = searchForm.ShowDialog();
            if (resultDialog != DialogResult.OK) return;

            var customerID = searchForm.SelectedDataKey;
            var customer = _dep.CustomerBL.GetData(customerID);

            if (customer != null)
            {
                _view.CustomerID = customerID;
                _view.CustomerName = customer.CustomerName;
            }
        }

        public IEnumerable<JenisBayarModel> ListJenisBayar()
        {
            var listJenisBayar = _dep.JenisBayarBL.ListData();

            //  escape point
            if (listJenisBayar == null)
                return null;

            var result =
                from c in listJenisBayar
                where c.JenisKasID != JENIS_KAS_PIUTANG
                select c;

            //  escape point
            if (!result.Any())
                return null;

            return result.ToList();
        }

        public void ListPiutang()
        {
            var listPiutang = _dep.BPPiutangBL.ListByCustomer(_view.CustomerID);

            if (listPiutang == null)
                return;

            var listPiutangViewModel = new List<BPPiutangViewModel>();
            foreach(var item in listPiutang)
            {
                var itemTemp = new BPPiutangViewModel
                {
                    BPPiutangID = item.BPPiutangID,
                    Tgl = item.Tgl,
                    Nilai = item.NilaiPiutang - item.NilaiLunas,
                    Bayar = 0
                };
                listPiutangViewModel.Add(itemTemp);
            }
            _view.ListPiutang = listPiutangViewModel;
        }

        public void ListPiutangValidated()
        {
            _view.TotalBayar = _view.ListPiutang.Sum(x => x.Bayar);
        }

        public void PelunasanValidated()
        {
            var nilaiSisaBagi = _view.TotalBayar;
            foreach(var item in _view.ListPiutang)
            {
                var bayar = Math.Min(nilaiSisaBagi, item.Nilai);
                item.Bayar = bayar;
                nilaiSisaBagi -= item.Bayar;
            }
        }
    }
}
