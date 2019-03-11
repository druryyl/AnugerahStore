using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnugerahBackend.Accounting.Dal;
using AnugerahBackend.Accounting.Model;
using AnugerahBackend.Pembelian.Model;
using AnugerahBackend.Penjualan.Model;

namespace AnugerahBackend.Accounting.BL
{

    public interface IPihakKeduaBL
    {
        PihakKeduaModel Save(PihakKeduaModel model);
        PihakKeduaModel Save(CustomerModel model);
        PihakKeduaModel Save(SupplierModel model);
        PihakKeduaModel Save(PegawaiModel model);


        void Delete(string id);

        PihakKeduaModel GetData(string id);

        IEnumerable<PihakKeduaModel> ListData();

    }

    public class PihakKeduaBL : IPihakKeduaBL
    {
        private IPihakKeduaDal _pihakKeduaDal;

        public PihakKeduaBL()
        {
            _pihakKeduaDal = new PihakKeduaDal();
        }

        public PihakKeduaBL(IPihakKeduaDal injPihakKeduaDal)
        {
            _pihakKeduaDal = injPihakKeduaDal;
        }

        private PihakKeduaModel _Save(PihakKeduaModel pihakKedua)
        {
            //  validasi
            if(string.IsNullOrWhiteSpace(pihakKedua.PihakKeduaID))
            {
                throw new ArgumentException("Pihak Kedua ID kosong");
            }

            if (string.IsNullOrWhiteSpace(pihakKedua.PihakKeduaName))
            {
                throw new ArgumentException("Pihak Kedua Name kosong");
            }

            //  save
            var dummyPihakKedua = _pihakKeduaDal.GetData(pihakKedua.PihakKeduaID);
            if (dummyPihakKedua == null)
            {
                _pihakKeduaDal.Insert(pihakKedua);
            }
            else
            {
                _pihakKeduaDal.Update(pihakKedua);
            }

            return pihakKedua;
        }

        public PihakKeduaModel Save(CustomerModel customer)
        {
            PihakKeduaModel result = new PihakKeduaModel
            {
                PihakKeduaID = customer.CustomerID,
                PihakKeduaName = customer.CustomerName
            };
            return _Save(result);
        }
        public PihakKeduaModel Save(SupplierModel supplier)
        {
            PihakKeduaModel result = new PihakKeduaModel
            {
                PihakKeduaID = supplier.SupplierID,
                PihakKeduaName = supplier.SupplierName
            };
            return _Save(result);
        }
        public PihakKeduaModel Save(PegawaiModel pegawai)
        {
            PihakKeduaModel result = new PihakKeduaModel
            {
                PihakKeduaID = pegawai.PegawaiID,
                PihakKeduaName = pegawai.PegawaiName
            };
            return _Save(result);
        }
        public PihakKeduaModel Save(PihakKeduaModel pihakKedua)
        {
            return _Save(pihakKedua);
        }

        public void Delete(string id)
        {
            _pihakKeduaDal.Delete(id);
        }
        public PihakKeduaModel GetData(string id)
        {
            return _pihakKeduaDal.GetData(id);
        }
        public IEnumerable<PihakKeduaModel> ListData()
        {
            return _pihakKeduaDal.ListData();
        }
    }
}
