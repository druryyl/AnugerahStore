using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnugerahBackend.Accounting.Dal;
using AnugerahBackend.Accounting.Model;
using AnugerahBackend.Pembelian.Dal;
using AnugerahBackend.Pembelian.Model;
using AnugerahBackend.Support;
using AnugerahBackend.Support.BL;
using Ics.Helper.Database;
using Ics.Helper.Extensions;

namespace AnugerahBackend.Pembelian.BL
{
    public interface ISupplierBL : ISearch<SupplierSearchModel>
    {
        SupplierModel Save(SupplierModel model);
        void Delete(string supplierID);
        IEnumerable<SupplierModel> ListData();
        SupplierModel GetData(string id);
    }

    public class SupplierBL : ISupplierBL
    {
        private ISupplierDal _supplierDal;
        private IParameterNoBL _paramNoBL;
        private IPihakKeduaDal _pihakKeduaDal;

        public SupplierBL()
        {
            _supplierDal = new SupplierDal();
            _paramNoBL = new ParameterNoBL();
            _pihakKeduaDal = new PihakKeduaDal();
        }

        public SupplierModel Save(SupplierModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            //  validasi nama
            if (model.SupplierName.Trim() == "")
                throw new ArgumentException("SupplierName kosong");

            //  simpan
            using (var trans = TransHelper.NewScope())
            {
                if (model.SupplierID.Trim() == "")
                    model.SupplierID = GenNewID();

                _supplierDal.Delete(model.SupplierID);
                _supplierDal.Insert(model);

                //  update pihak kedua
                _pihakKeduaDal.Delete(model.SupplierID);
                var pihakKedua = new PihakKeduaModel
                {
                    PihakKeduaID = model.SupplierID,
                    PihakKeduaName = model.SupplierName
                };
                _pihakKeduaDal.Insert(pihakKedua);

                trans.Complete();
            }
            return model;
        }

        private string GenNewID()
        {
            var prefix = "S";
            var result = _paramNoBL.GenNewID(prefix, 5);
            return result;
        }


        public void Delete(string supplierID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SupplierModel> ListData()
        {
            return _supplierDal.ListData();
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
