using AnugerahBackend.Accounting.BL;
using AnugerahBackend.Penjualan.Dal;
using AnugerahBackend.Penjualan.Model;
using AnugerahBackend.Support;
using AnugerahBackend.Support.BL;
using Ics.Helper.Database;
using Ics.Helper.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Penjualan.BL
{
    public interface ICustomerBL : ISearch<CustomerSearchModel>
    {
        CustomerModel Save(CustomerModel customer);
        void Delete(string id);
        CustomerModel GetData(string id);
        IEnumerable<CustomerModel> ListData();
    }

    public class CustomerBL : ICustomerBL
    {
        private ICustomerDal _customerDal;
        private IParameterNoBL _paramNoBL;
        private IPihakKeduaBL _pihakKeduaBL;

        public CustomerBL()
        {
            _customerDal = new CustomerDal();
            _paramNoBL = new ParameterNoBL();
            _pihakKeduaBL = new PihakKeduaBL();
            SearchFilter = new SearchFilter
            {
                IsDate = false
            };
        }

        public CustomerBL(ICustomerDal injCustomerDal)
        {
            _customerDal = injCustomerDal;
        }

        public CustomerModel Save(CustomerModel customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }

            //  validate nama
            if (customer.CustomerName.Trim() == "")
                throw new ArgumentException("CustomerName kosong");

            using (var trans = TransHelper.NewScope())
            {
                if (customer.CustomerID.Trim() == "")
                    customer.CustomerID = GenNewID();

                _customerDal.Delete(customer.CustomerID);
                _customerDal.Insert(customer);
                _pihakKeduaBL.Save(customer);
                trans.Complete();
            }

            return customer;
        }

        private string GenNewID()
        {
            var prefix = "C";
            var result = _paramNoBL.GenNewID(prefix, 5);
            return result;
        }
        public void Delete(string id)
        {
            using (var trans = TransHelper.NewScope())
            {
                _customerDal.Delete(id);
                _pihakKeduaBL.Delete(id);
                trans.Complete();
            }
        }

        public CustomerModel GetData(string id)
        {
            return _customerDal.GetData(id);
        }

        public IEnumerable<CustomerModel> ListData()
        {
            return _customerDal.ListData();
        }

        public SearchFilter SearchFilter { get; set; }

        public IEnumerable<CustomerSearchModel> Search()
        {
            //  ambil data
            var listData = _customerDal.ListData();
            if (listData == null) return null;

            //  convert to search model
            var result = listData.Select(x => (CustomerSearchModel)x);

            //  filter user keyword
            if (SearchFilter.UserKeyword != null)
                return
                    from c in result
                    where c.CustomerName.ContainMultiWord(SearchFilter.UserKeyword)
                    select c;

            return result;
        }
    }
}
