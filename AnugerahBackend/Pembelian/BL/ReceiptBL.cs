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
    public interface IReceiptBL : ISearch<ReceiptSearchResultModel>
    {
        ReceiptModel Save(ReceiptModel model);
        void Delete(string id);
        ReceiptModel GetData(string id);
        IEnumerable<ReceiptModel> ListData(string tgl1, string tgl2);
    }

    public class ReceiptBLDependencyContainer
    {
        public IReceiptDal ReceiptDal { get; set; }
        public IReceiptDetilDal ReceiptDetilDal { get; set; }
        public IBrgDal BrgDal { get; set; }
        public ISupplierDal SupplierDal { get; set; }
        public IParameterNoBL ParamNoBL { get; set; }
        public IPurchaseDal PurchaseDal { get; set; }
    }

    public class ReceiptBL : IReceiptBL
    {
        private readonly ReceiptBLDependencyContainer _dep;

        public ReceiptBL()
        {
            _dep = new ReceiptBLDependencyContainer
            {
                ReceiptDal = new ReceiptDal(),
                ReceiptDetilDal = new ReceiptDetilDal(),
                BrgDal = new BrgDal(),
                SupplierDal = new SupplierDal(),
                ParamNoBL = new ParameterNoBL(),
                PurchaseDal = new PurchaseDal(),
            };
            SearchFilter = new SearchFilter
            {
                IsDate = true,
                Date1 = DateTime.Now,
                Date2 = DateTime.Now
            };
        }

        public ReceiptBL(ReceiptBLDependencyContainer inj)
        {
            _dep = inj;
        }

        public ReceiptModel Save(ReceiptModel model)
        {
            #region VALIDASI
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            //  validasi PurchaseID
            if(model.PurchaseID.Trim() != "")
            {
                var purchase = _dep.PurchaseDal.GetData(model.PurchaseID);
                if (purchase == null)
                    throw new ArgumentException("PurchaseID invalid");
            }

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
                if (model.ReceiptID.Trim() == "")
                    model.ReceiptID = GenNewID();

                /* update id di detil */
                int noUrut = 1;
                foreach (var item in model.ListBrg)
                {
                    item.ReceiptID = model.ReceiptID;
                    item.ReceiptDetilID = model.ReceiptID + '-' + noUrut.ToString().PadLeft(3, '0');
                    item.NoUrut = noUrut;
                    noUrut++;
                }

                /* hapus data lama */
                _dep.ReceiptDetilDal.Delete(model.ReceiptID);
                _dep.ReceiptDal.Delete(model.ReceiptID);

                /* simpan data baru */
                _dep.ReceiptDal.Insert(model);
                foreach (var item in model.ListBrg)
                    _dep.ReceiptDetilDal.Insert(item);

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
            _dep.ReceiptDetilDal.Delete(id);
            _dep.ReceiptDal.Delete(id);
        }

        public ReceiptModel GetData(string id)
        {
            var result = _dep.ReceiptDal.GetData(id);
            if (result == null) return null;
            result.ListBrg = _dep.ReceiptDetilDal.ListData(id);
            return result;
        }

        public IEnumerable<ReceiptModel> ListData(string tgl1, string tgl2)
        {
            var result = _dep.ReceiptDal.ListData(tgl1, tgl2);
            return result;
        }

        public SearchFilter SearchFilter { get; set; }

        public IEnumerable<ReceiptSearchResultModel> Search()
        {
            var listData = _dep.ReceiptDal.ListData(SearchFilter.TglDMY1, SearchFilter.TglDMY2);
            if (listData == null) return null;

            //  convert ke SearchModel
            var result = listData.Select(x => (ReceiptSearchResultModel)x);

            //  filter
            if (SearchFilter.UserKeyword != null)
                return
                    from c in result
                    where c.SupplierName.ContainMultiWord(SearchFilter.UserKeyword)
                    select c;

            return result;
        }
    }
}
