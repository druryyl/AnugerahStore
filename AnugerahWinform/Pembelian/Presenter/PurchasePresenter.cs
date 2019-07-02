using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AnugerahBackend.Pembelian.BL;
using AnugerahBackend.Pembelian.Model;
using AnugerahBackend.StokBarang.BL;
using AnugerahBackend.StokBarang.Model;
using AnugerahWinform.Pembelian.View;
using AnugerahWinform.Support;
using Ics.Helper.Database;

namespace AnugerahWinform.Pembelian.Presenter
{
    public class PurchasePresenter
    {
        private IPurchaseView _view;
        private IPurchaseBL _purchaseBL;
        private ISupplierBL _supplierBL;
        private IBrgBL _brgBL;
        private IBPPurchaseBL _bpPurchaseBL;

        public PurchasePresenter(IPurchaseView view)
        {
            _view = view;
            _purchaseBL = new PurchaseBL();
            _supplierBL = new SupplierBL();
            _brgBL = new BrgBL();
            _bpPurchaseBL = new BPPurchaseBL();
        }
        public PurchasePresenter(IPurchaseView view, IPurchaseBL bl, ISupplierBL supplierBL)
        {
            _view = view;
            _purchaseBL = bl;
            _supplierBL = supplierBL;
        }

        public void Save()
        {
            var purchase = new PurchaseModel
            {
                PurchaseID = _view.PurchaseID,
                Tgl = _view.Tgl,
                Jam = _view.Jam,
                SupplierID = _view.SupplierID,
                SupplierName = _view.SupplierName,
                Keterangan = _view.Catatan,
                TotalHarga = _view.Total,
                Diskon = _view.DiskonLain,
                BiayaLain = _view.BiayaLain,
                GrandTotal = _view.GrandTotal,
                ListBrg = _view.ListBrg,
                IsClosed = _view.IsClosedPO
            };
            purchase.ListBrg = purchase.ListBrg.Where(x => x.BrgID != "").ToList();

            using (var trans = TransHelper.NewScope())
            {
                var result = _purchaseBL.Save(purchase);
                var result2 = _bpPurchaseBL.Generate(result);
                trans.Complete();
            }
        }

        public void New()
        {
            _view.PurchaseID = "";
            _view.Tgl = DateTime.Now.ToString("dd-MM-yyyy");
            _view.Jam = DateTime.Now.ToString("HH:mm:ss");
            _view.SupplierID = "";
            _view.SupplierName = "";
            _view.Alamat = "";
            _view.NoTelp = "";
            _view.Catatan = "";
            _view.ListBrg = new List<PurchaseDetilModel>();
            _view.Total = 0;
            _view.DiskonLain = 0;
            _view.BiayaLain = 0;
            _view.GrandTotal = 0;
            _view.IsClosedPO = false;
            _view.ListBrg = new List<PurchaseDetilModel>
            {
                new PurchaseDetilModel
                {
                    BrgID = "",
                    BrgName = "",
                    Qty = 0,
                    Harga = 0,
                    Diskon = 0,
                    TaxRupiah = 0,
                    SubTotal = 0,
                }
            };
        }

        public string PilihSupplier()
        {
            var result = "";
            var searchForm = new SearchingForm<SupplierSearchModel>(_supplierBL);
            var resultDialog = searchForm.ShowDialog();
            if (resultDialog == DialogResult.OK)
            {
                result = searchForm.SelectedDataKey;
            }
            var supplier = _supplierBL.GetData(result);

            if (supplier != null)
            {
                _view.SupplierName = supplier.SupplierName;
                _view.Alamat = supplier.Alamat;
                _view.NoTelp = supplier.NoTelp;
            }

            return result;
        }

        public PurchaseDetilModel PilihBrg(PurchaseDetilModel pd)
        {
            var searchForm = new SearchingForm<BrgSearchResultModel>(_brgBL);
            var resultDialog = searchForm.ShowDialog();
            if (resultDialog == DialogResult.OK)
            {
                var brgID = searchForm.SelectedDataKey;
                var brg = _brgBL.GetData(brgID);
                if (brg == null) return pd;

                if (pd == null) pd = new PurchaseDetilModel();

                pd.BrgID = brgID;
                pd.BrgName = brg.BrgName;
            }
            return pd;
        }

        public PurchaseDetilModel Calculate(PurchaseDetilModel pd)
        {
            pd.SubTotal = pd.Qty * (pd.Harga - pd.Diskon + pd.TaxRupiah);
            return pd;
        }

        public PurchaseDetilModel ValidateBrg(PurchaseDetilModel pd)
        {
            var brg = _brgBL.GetData(pd.BrgID);
            if (brg == null) return null;
            pd.BrgName = brg.BrgName;
            return pd;
        }

        public void CalculateTotal()
        {
            if (_view.ListBrg == null)
                _view.Total = 0;
            else
                _view.Total = _view.ListBrg.Sum(x => x.SubTotal);

            _view.GrandTotal = _view.Total + _view.BiayaLain - _view.DiskonLain;
        }

        public void PilihPurchase()
        {
            var searchForm = new SearchingForm<PurchaseSearchResultModel>(_purchaseBL);
            var resultDialog = searchForm.ShowDialog();
            if (resultDialog == DialogResult.OK)
            {
                var purchaseID = searchForm.SelectedDataKey;
                var purchase = _purchaseBL.GetData(purchaseID);
                if (purchase == null) return;
                _view.PurchaseID = purchase.PurchaseID;
                _view.Tgl = purchase.Tgl;
                _view.Jam = purchase.Jam;
                _view.SupplierID = purchase.SupplierID;
                _view.SupplierName = purchase.SupplierName;
                _view.Catatan = purchase.Keterangan;
                _view.IsClosedPO = purchase.IsClosed;
                var tempList = purchase.ListBrg.ToList();
                tempList.Add(new PurchaseDetilModel());

                _view.ListBrg = tempList;

                _view.BiayaLain = purchase.BiayaLain;
                _view.DiskonLain = purchase.Diskon;

                CalculateTotal();

                var supplier = _supplierBL.GetData(purchase.SupplierID);
                if (supplier == null) return;
                _view.Alamat = supplier.Alamat;
                _view.NoTelp = supplier.NoTelp;
            }
        }

        public void ClosePO()
        {
            if (MessageBox.Show("Close PO?", "Purchase", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            var po = _purchaseBL.GetData(_view.PurchaseID);

            if (po == null)
                throw new ArgumentException("PO not found");

            var bpPurchase = _bpPurchaseBL.GetData(_view.PurchaseID);

            _bpPurchaseBL.ClosePO(bpPurchase);
            _purchaseBL.ClosePO(po);
        }
    }
}