using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnugerahBackend.Pembelian.Dal;
using AnugerahBackend.Pembelian.Model;
using AnugerahBackend.StokBarang.Dal;
using AnugerahBackend.Support;
using AnugerahBackend.Support.BL;
using Ics.Helper.Database;
using Ics.Helper.Extensions;
using Ics.Helper.StringDateTime;

namespace AnugerahBackend.Pembelian.BL
{
    public interface IPurchaseBL : ISearch<PurchaseSearchResultModel>
    {
        PurchaseModel Save(PurchaseModel model);
        void Delete(string id);
        PurchaseModel GetData(string id);
        IEnumerable<PurchaseModel> ListData(string tgl1, string tgl2);
        void ClosePO(PurchaseModel model);
        void OpenPO(PurchaseModel model);
    }

    public class PurchaseBLDependencyContainer
    {
        public IPurchaseDal PurchaseDal { get; set; }
        public IPurchaseDetilDal PurchaseDetilDal { get; set; }
        public IBrgDal BrgDal { get; set; }
        public ISupplierDal SupplierDal { get; set; }
        public IParameterNoBL ParamNoBL { get; set; }
    }

    public class PurchaseBL : IPurchaseBL
    {
        private readonly PurchaseBLDependencyContainer _dep;

        public PurchaseBL()
        {
            _dep = new PurchaseBLDependencyContainer
            {
                PurchaseDal = new PurchaseDal(),
                PurchaseDetilDal = new PurchaseDetilDal(),
                BrgDal = new BrgDal(),
                SupplierDal = new SupplierDal(),
                ParamNoBL = new ParameterNoBL(),
            };
            SearchFilter = new SearchFilter
            {
                IsDate = true,
                Date1 = DateTime.Now,
                Date2 = DateTime.Now
            };
        }

        public PurchaseBL(PurchaseBLDependencyContainer inj)
        {
            _dep = inj;
        }

        public PurchaseModel Save(PurchaseModel model)
        {
            #region VALIDASI
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (model.IsClosed)
                throw new ArgumentException("PO sudah di-close, tidak bisa disimpan ulang");

            //  validasi supplier
            var supplier = _dep.SupplierDal.GetData(model.SupplierID);
            if (supplier == null)
                throw new ArgumentException("SupllierID invalid");
            else
                model.SupplierName = supplier.SupplierName;

            /* hitung ulang GrandTotal */
            model.GrandTotal = model.TotalHarga + model.BiayaLain - model.Diskon;

            /* validasi tanggal */
            if (!model.Tgl.IsValidTgl("dd-MM-yyyy"))
                throw new ArgumentException("Tgl invalid");

            /* validasi jam */
            if (!model.Jam.IsValidJam("HH:mm:ss"))
                throw new ArgumentException("Jam invalid");

            /* validasi kode barang */
            foreach (var item in model.ListBrg)
            {
                var brg = _dep.BrgDal.GetData(item.BrgID);
                if (brg == null)
                    throw new ArgumentException("BrgID invalid");
            }

            /* update sub total detil */
            foreach (var item in model.ListBrg)
            {
                item.SubTotal = (item.Harga - item.Diskon + item.TaxRupiah) * item.Qty;
            }
            #endregion

            #region SAVE-DATA
            /* proses save */
            using (var trans = TransHelper.NewScope())
            {
                /* generate id jika belum ada */
                if (model.PurchaseID.Trim() == "")
                    model.PurchaseID = GenNewID();

                /* update id di detil */
                int noUrut = 1;
                foreach (var item in model.ListBrg)
                {
                    item.PurchaseID = model.PurchaseID;
                    item.PurchaseDetilID = model.PurchaseID + '-' + noUrut.ToString().PadLeft(3, '0');
                    item.NoUrut = noUrut;
                    noUrut++;
                }

                /* hapus data lama */
                _dep.PurchaseDetilDal.Delete(model.PurchaseID);
                _dep.PurchaseDal.Delete(model.PurchaseID);

                /* simpan data baru */
                _dep.PurchaseDal.Insert(model);
                foreach (var item in model.ListBrg)
                    _dep.PurchaseDetilDal.Insert(item);

                /* commit trans */
                trans.Complete();
            } 
            #endregion

            return model;
        }

        private string GenNewID()
        {
            var prefix = "PC" + DateTime.Now.ToString("yyMM");
            var result = _dep.ParamNoBL.GenNewID(prefix, 10);
            return result;
        }

        public void Delete(string id)
        {
            /* TODO: cek apakah ada penerimaan barang */
            /* jika sudah ada, tidak boleh delete     */
            _dep.PurchaseDetilDal.Delete(id);
            _dep.PurchaseDal.Delete(id);
        }

        public PurchaseModel GetData(string id)
        {
            var result = _dep.PurchaseDal.GetData(id);
            if (result == null) return null;
            result.ListBrg = _dep.PurchaseDetilDal.ListData(id);
            return result;
        }

        public IEnumerable<PurchaseModel> ListData(string tgl1, string tgl2)
        {
            var result = _dep.PurchaseDal.ListData(tgl1, tgl2);
            return result;
        }

        public SearchFilter SearchFilter { get; set; }

        public IEnumerable<PurchaseSearchResultModel> Search()
        {
            var listData = _dep.PurchaseDal.ListData(SearchFilter.TglDMY1, SearchFilter.TglDMY2);
            if (listData == null) return null;

            //  convert ke SearchModel
            var result = listData.Select(x => (PurchaseSearchResultModel)x);

            //  filter
            if (SearchFilter.UserKeyword != null)
                return
                    from c in result
                    where c.SupplierName.ContainMultiWord(SearchFilter.UserKeyword)
                    select c;

            return result;
        }

        public void ClosePO(PurchaseModel model)
        {
            var purchase = _dep.PurchaseDal.GetData(model.PurchaseID);
            if (purchase == null)
                throw new ArgumentException("PurchaseID invalid");

            purchase.IsClosed = true;
            _dep.PurchaseDal.Update(purchase);
        }

        public void OpenPO(PurchaseModel model)
        {
            var purchase = _dep.PurchaseDal.GetData(model.PurchaseID);
            if (purchase == null)
                throw new ArgumentException("PurchaseID invalid");

            purchase.IsClosed = false;
            _dep.PurchaseDal.Update(purchase);
        }
    }
}
