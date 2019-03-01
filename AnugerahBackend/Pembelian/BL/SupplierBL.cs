using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnugerahBackend.Pembelian.Dal;
using AnugerahBackend.Pembelian.Model;
using AnugerahBackend.Support;
using Ics.Helper.Extensions;

namespace AnugerahBackend.Pembelian.BL
{
    public interface ISupplierBL : ISearch<SupplierSearchModel>
    {
        SupplierModel Save(SupplierModel model);
        void Delete(string supplierID);
        void ListData();
        SupplierModel GetData(string id);
    }

    public class SupplierBL : ISupplierBL
    {
        ISupplierDal _supplierDal;

        public SupplierBL()
        {
            _supplierDal = new SupplierDal();
        }

        public SupplierModel Save(SupplierModel model)
        {
            throw new NotImplementedException();
        }

        public void Delete(string supplierID)
        {
            throw new NotImplementedException();
        }

        public void ListData()
        {
            throw new NotImplementedException();
        }

        public SearchFilter SearchFilter { get; set; }

        public IEnumerable<SupplierSearchModel> Search()
        {
            //  ambil data
            var listAll = _supplierDal.ListData();
            if (listAll == null) return null;

            //  convert
            var result = listAll.Select(x => (SupplierSearchModel)x);

            //  filter
            if (SearchFilter.UserKeyword != null)
                return
                    from c in result
                    where c.SupplierName.ContainMultiWord(SearchFilter.UserKeyword)
                    select c;

            return result;
        }

        public SupplierModel GetData(string id)
        {
            return _supplierDal.GetData(id);
        }
    }
}
