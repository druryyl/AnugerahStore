using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AnugerahBackend.Penjualan.BL;
using AnugerahBackend.Penjualan.Model;
using AnugerahWinform.Penjualan.View;
using AnugerahWinform.Support;

namespace AnugerahWinform.Penjualan.Presenter
{
    public class CustomerPresenter
    {
        private ICustomerView _view;
        private ICustomerBL _customerBL;

        public CustomerPresenter(ICustomerView view)
        {
            _view = view;
            _customerBL = new CustomerBL();
        }

        public CustomerPresenter(ICustomerView view, ICustomerBL customerBL)
        {
            _view = view;
            _customerBL = customerBL;
        }

        public void Save()
        {
            var customer = new CustomerModel
            {
                CustomerID = _view.CustomerID,
                CustomerName = _view.CustomerName,
                Alamat1 = _view.Alamat1,
                Alamat2 = _view.Alamat2,
                NoTelp = _view.NoTelp,
                ContactPerson = _view.ContactPerson
            };
            var result = _customerBL.Save(customer);
        }

        public void New()
        {
            _view.CustomerID = "";
            _view.CustomerName = "";
            _view.Alamat1 = "";
            _view.Alamat2 = "";
            _view.NoTelp = "";
            _view.ContactPerson = "";
        }

        public string PilihCustomer()
        {
            var result = "";
            var searchForm = new SearchingForm<CustomerSearchModel>(_customerBL);
            var resultDialog = searchForm.ShowDialog();
            if (resultDialog == DialogResult.OK)
            {
                result = searchForm.SelectedDataKey;
            }
            var supplier = _customerBL.GetData(result);

            if (supplier != null)
            {
                _view.CustomerID = result;
                _view.CustomerName = supplier.CustomerName;
                _view.Alamat1 = supplier.Alamat1;
                _view.Alamat2 = supplier.Alamat2;
                _view.NoTelp = supplier.NoTelp;
            }
            return result;
        }
    }
}
