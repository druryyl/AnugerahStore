using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnugerahBackend.Pembelian.Dal;
using AnugerahBackend.Pembelian.Model;
using AnugerahBackend.StokBarang.Dal;
using AnugerahBackend.Support;
using Ics.Helper.Database;

namespace AnugerahBackend.Pembelian.BL
{
    public interface IBPPurchaseBL : ISearch<BPPurchaseSearchModel>
    {
        BPPurchaseModel Generate(PurchaseModel purchase);
        BPPurchaseModel Generate(ReceiptModel receipt);
        BPPurchaseModel GetData(string purchaseID);
    }
    public class BPPurchaseBL : IBPPurchaseBL
    {
        private IBPPurchaseDal _bpPurchaseDal;
        private IBPPurchaseReceiptDal _bpPurchaseReceiptDal;
        private ISupplierDal _supplierDal;
        private IBrgDal _brgDal;

        public BPPurchaseBL()
        {
            _bpPurchaseDal = new BPPurchaseDal();
            _bpPurchaseReceiptDal = new BPPurchaseReceiptDal();
            _supplierDal = new SupplierDal();
            _brgDal = new BrgDal();
        }

        public BPPurchaseModel Generate(PurchaseModel purchase)
        {
            if (purchase == null)
            {
                throw new ArgumentNullException(nameof(purchase));
            }
            
            //  ambil data purchase yang sudah ada
            BPPurchaseModel newPurchase = _bpPurchaseDal.GetData(purchase.PurchaseID);
            if (newPurchase == null)
                newPurchase = new BPPurchaseModel();

            //  header
            newPurchase.BPPurchaseID = purchase.PurchaseID;
            newPurchase.Tgl = purchase.Tgl;
            newPurchase.Jam = purchase.Jam;
            newPurchase.SupplierID = purchase.SupplierID;
            newPurchase.SupplierName = purchase.SupplierName;
            newPurchase.Keterangan = purchase.Keterangan;
            newPurchase.Diskon = purchase.Diskon;
            newPurchase.BiayaLain = purchase.BiayaLain;

            //  detil; hilangkan detil Purchase-nya
            newPurchase.ListBrg = newPurchase.ListBrg.Where(x => x.BPReceiptID.Trim() != "").ToList();
            //  tambahkan detil purchase baru;
            foreach(var item in purchase.ListBrg)
            {
                var newItem = new BPPurchaseReceiptModel()
                {
                    BPPurchaseID = purchase.PurchaseID,
                    BPReceiptID = "",
                    BPDetilID = item.PurchaseDetilID,
                    Tgl = purchase.Tgl,
                    Jam = purchase.Jam,
                    BrgID = item.BrgID,
                    QtyPurchase = item.Qty,
                    QtyReceipt = 0,
                    Harga = item.Harga,
                    Diskon = item.Diskon,
                    Tax = item.TaxRupiah,
                };
                newPurchase.ListBrg.Add(newItem);
            }
            var result = Save(newPurchase);
            return result;
        }

        public BPPurchaseModel Generate(ReceiptModel receipt)
        {
            if (receipt == null)
            {
                throw new ArgumentNullException(nameof(receipt));
            }

            #region UPDATE-PURCHASE-LAMA (KASUS EDIT)
            //  cari Purchase atas receipt ini (jika ada sebelumnya)
            BPPurchaseModel bpPurchaseLama = null;
            var listPurchase = _bpPurchaseReceiptDal.ListData(receipt);
            //  hilangkan receipt ini dari purchase tsb
            if (listPurchase != null)
            {
                var bpPurchasIDLama = listPurchase.First().BPPurchaseID;
                bpPurchaseLama = GetData(bpPurchasIDLama);
                bpPurchaseLama.ListBrg = bpPurchaseLama.ListBrg
                    .Where(x => x.BPReceiptID != receipt.ReceiptID)
                    .ToList();
            }
            #endregion

            //  update pruchase baru
            BPPurchaseModel bpPurchaseBaru = null;
            bpPurchaseBaru = GetData(receipt.PurchaseID);
            if (bpPurchaseBaru == null)
                throw new ArgumentException("Purchase Invalid");
            
            //  hilangka receipt ini dari purchase (jika ada / kasus edit)
            //  sebelum ditambahkan kembali
            bpPurchaseBaru.ListBrg = bpPurchaseBaru.ListBrg
                .Where(x => x.BPReceiptID == receipt.ReceiptID).ToList();

            //  tambahkan detil baru
            foreach(var item in receipt.ListBrg)
            {
                var newItem = new BPPurchaseReceiptModel()
                {
                    BPReceiptID = receipt.ReceiptID,
                    BPDetilID = item.ReceiptDetilID,
                    Tgl = receipt.Tgl,
                    Jam = receipt.Jam,
                    BrgID = item.BrgID,
                    Harga = item.Harga,
                    Diskon = item.Diskon,
                    Tax = item.TaxRupiah,
                    SubTotal = item.SubTotal,
                    QtyPurchase = 0,
                    QtyReceipt = item.Qty,
                    BPPurchaseID = receipt.PurchaseID,
                };
                bpPurchaseBaru.ListBrg.Add(newItem);
            }

            //  simpan data
            BPPurchaseModel result = null;
            using (var trans = TransHelper.NewScope())
            {
                var resultLama = Save(bpPurchaseLama);
                resultLama = Save(bpPurchaseBaru);
                trans.Complete();
            }
            return result;
        }

        public BPPurchaseModel GetData(string purchaseID)
        {
            var result = _bpPurchaseDal.GetData(purchaseID);
            result.ListBrg = _bpPurchaseReceiptDal.ListData(purchaseID).ToList();
            return result;
        }

        public SearchFilter SearchFilter { get; set; }

        public IEnumerable<BPPurchaseSearchModel> Search()
        {
            throw new NotImplementedException();
        }

        private BPPurchaseModel Save(BPPurchaseModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            //  validate supplier
            var supplier = _supplierDal.GetData(model.SupplierID);
            if (supplier == null)
                throw new ArgumentException("SupplierID invalie");
            else model.SupplierName = supplier.SupplierName;

            //  update nilai Total Harga dari detil
            model.TotHargaPurchase = model.ListBrg.Sum(x => x.QtyPurchase * (x.Harga - x.Diskon + x.Tax));
            model.TotHargaReceipt = model.ListBrg.Sum(x => x.QtyReceipt * (x.Harga - x.Diskon + x.Tax));

            //  validasi; penerimaan tidak boleh melebihi purchasing
            if (model.TotHargaReceipt > model.TotHargaPurchase)
                throw new ArgumentException("Penerimaan melebihi pembelian");

            //  update subtotal di detil
            foreach(var item in model.ListBrg)
                item.SubTotal = 
                    (item.QtyPurchase - item.QtyReceipt) * 
                    (item.Harga - item.Diskon + item.Tax);
            
            //  update keterangan di detil
            foreach(var item in model.ListBrg)
            {
                var brg = _brgDal.GetData(item.BrgID);
                if (brg == null)
                    throw new ArgumentException("BrgID invalid");
                if (item.BPReceiptID.Trim() == "")
                    item.Keterangan = string.Format("Purchase {0}", brg.BrgName);
                else
                    item.Keterangan = string.Format("    Received {0}", brg.BrgName);
            }

            //  atur urutannya sedemikian rupa kelihatan history penerimaan barang
            var listData = model.ListBrg.OrderBy(x => x.BrgID + x.Tgl + x.Jam);
            int i = 1;
            foreach (var item in listData)
            {
                item.NoUrut = i;
                i++;
            }
            model.ListBrg = listData.ToList();

            //  update kode Purchase di Detil harus sama dengan header
            foreach (var item in model.ListBrg)
                item.BPPurchaseID = model.BPPurchaseID;

            //  save
            using (var trans = TransHelper.NewScope())
            {
                //  hapus data lama
                _bpPurchaseReceiptDal.Delete(model.BPPurchaseID);
                _bpPurchaseDal.Delete(model.BPPurchaseID);

                //  insert data baru
                _bpPurchaseDal.Insert(model);
                foreach (var item in model.ListBrg)
                    _bpPurchaseReceiptDal.Insert(item);

                trans.Complete();
            }

            return model;
        }

    }
}
