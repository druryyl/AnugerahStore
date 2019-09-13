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
        public CustomerBL CustomerBL { get; set; }
    }

    public class LunasPiutangPresenter
    {
        private readonly ILunasPiutangView _view;
        private LunasPiutangPresenterDependency _dep;

        public LunasPiutangPresenter(ILunasPiutangView view)
        {
            _view = view;
            _dep = new LunasPiutangPresenterDependency
            {
                CustomerBL = new CustomerBL()
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
            _view.ListJenisBayar.Clear();
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

        public void ListPiutangValidated()
        {
            _view.TotalBayar = _view.ListPiutang.Sum(x => x.Bayar);
        }
    }

}
