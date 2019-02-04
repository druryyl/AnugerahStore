using AnugerahBackend.Penjualan.Dal;
using AnugerahBackend.Penjualan.Model;
using AnugerahBackend.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Penjualan.BL
{
    public interface ICustomerBL : ISearch<CustomerSearchModel>
    {
        void Save(CustomerModel customer);
        void Delete(string id);
        CustomerModel GetData(string id);
        IEnumerable<CustomerModel> ListData();
    }

    public class CustomerBL : ICustomerBL
    {
        private ICustomerDal _customerDal;

        public CustomerBL()
        {
            _customerDal = new CustomerDal();
        }

        public CustomerBL(ICustomerDal injCustomerDal)
        {
            _customerDal = injCustomerDal;
        }

        public void Save(CustomerModel customer)
        {
            //  validate
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public CustomerModel GetData(string id)
        {
            return _customerDal.GetData(id);
        }

        public IEnumerable<CustomerModel> ListData()
        {
            return _customerDal.ListData();
        }

        public IEnumerable<CustomerSearchModel> Search(string keyword)
        {
            return _customerDal.Search(keyword);
        }

        public IEnumerable<CustomerSearchModel> Search(string keyword, string tgl1, string tgl2)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CustomerSearchModel> Search()
        {
            throw new NotImplementedException();
        }
    }
}
