using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnugerahBackend.Pembelian.Dal;
using AnugerahBackend.Pembelian.Model;
using AnugerahBackend.StokBarang.Dal;
using Ics.Helper.Database;
using Ics.Helper.StringDateTime;

namespace AnugerahBackend.Pembelian.BL
{
    public interface IPuchaseBL
    {
        PurchaseModel Save(PurchaseModel model);
        void Delete(string id);
        PurchaseModel GetData(string id);
        IEnumerable<PurchaseModel> ListData(string tgl1, string tgl2);
    }
    public class PurchaseBLInjectContainer
    {
        public IPurchaseDal PurchaseDal { get; set; }
        public IPurchaseDetilDal PurchaseDetilDal { get; set; }
        public IBrgDal BrgDal { get; set; }
        public ISupplierDal SupplierDal { get; set; }
    }
    public class PurchaseBL : IPuchaseBL
    {
        private readonly PurchaseBLInjectContainer _i;

        public PurchaseBL()
        {
            _i = new PurchaseBLInjectContainer
            {
                PurchaseDal = new PurchaseDal(),
                PurchaseDetilDal = new PurchaseDetilDal(),
                BrgDal = new BrgDal(),
                SupplierDal = new SupplierDal(),
            };
        }

        public PurchaseBL(PurchaseBLInjectContainer inj)
        {
            _i = inj;
        }

        public PurchaseModel Save(PurchaseModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            //  validasi supplier
            var supplier = _i.SupplierDal.GetData(model.SupplierID);
            if (supplier == null)
                throw new ArgumentException("SupllierID invalid");
            else
                model.SupplierName = supplier.SupplierName;

            /* hitung ulang GrandTotal */
            model.GrandTotal = model.TotalHarga + model.BiayaLain - model.Diskon;

            /* validasi tanggal */
            if(!model.Tgl.IsValidTgl("dd-MM-yyyy"))
                throw new ArgumentException("Tgl invalid");

            /* validasi jam */
            if (!model.Jam.IsValidJam("HH:mm:ss"))
                throw new ArgumentException("Jam invalid");

            /* validasi kode barang */
            foreach (var item in model.ListBrg)
            {
                var brg = _i.BrgDal.GetData(item.BrgID);
                if (brg == null)
                    throw new ArgumentException("BrgID invalid");
            }

            /* update sub total detil */
            foreach (var item in model.ListBrg)
            {
                item.SubTotal = (item.Harga - item.Diskon + item.TaxRupiah) * item.Qty;
            }

            /* proses save */
            using (var trans = TransHelper.NewScope())
            {
                /* generate id jika belum ada */
                if (model.PurchaseID.Trim() == "")
                    model.PurchaseID = GenNewID();
            }

            return model;
        }

        private string GenNewID()
        {

        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public PurchaseModel GetData(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PurchaseModel> ListData(string tgl1, string tgl2)
        {
            throw new NotImplementedException();
        }
    }
}
