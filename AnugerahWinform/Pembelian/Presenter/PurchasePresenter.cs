using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AnugerahBackend.Pembelian.BL;
using AnugerahBackend.Pembelian.Model;
using AnugerahWinform.Pembelian.View;
using AnugerahWinform.Support;

namespace AnugerahWinform.Pembelian.Presenter
{
    public class PurchasePresenter
    {
        private IPurchaseView _view;
        private IPurchaseBL _purchaseBL;
        private ISupplierBL _supplierBL;

        public PurchasePresenter(IPurchaseView view)
        {
            _view = view;
            _purchaseBL = new PurchaseBL();
            _supplierBL = new SupplierBL();
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
                ListBrg = _view.ListBrg
            };
            _purchaseBL.Save(purchase);
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
            AddItemBrg(new PurchaseDetilModel
            {
                BrgID = "", BrgName = "",
                Qty = 0, Harga = 0, Diskon = 0,
                TaxRupiah = 0, SubTotal = 0
            });
        }

        public void AddItemBrg(PurchaseDetilModel model)
        {
            if(_view.ListBrg == null)
            {
                model.NoUrut = 1;
                _view.ListBrg = new List<PurchaseDetilModel> { model};
            }
            else
            {
                int noUrut = _view.ListBrg.Max(x => x.NoUrut);
                noUrut++;
                model.NoUrut = noUrut;
                _view.ListBrg.Add(model);
            }
        }

        public void RemoveItemBrg(int rowIndex)
        {
            var item = _view.ListBrg.First(x => x.NoUrut == rowIndex);
            if (item == null) return;
            _view.ListBrg.Remove(item);
        }
        public void UpdateList(int rowIndex, PurchaseDetilModel model)
        {
            var item = _view.ListBrg.First(x => x.NoUrut == rowIndex);
            if (item == null) return;
            item.BrgID = model.BrgID;
            item.BrgName = model.BrgName;
            item.Qty = model.Qty;
            item.Harga = model.Harga;
            item.Diskon = model.Diskon;
            item.TaxRupiah = model.TaxRupiah;
            item.SubTotal = model.SubTotal;
        }

        public void RecalcList(int rowIndex)
        {
            var item = _view.ListBrg.First(x => x.NoUrut == rowIndex);
            if (item == null) return;
            item.SubTotal = item.Qty * (item.Harga - item.Diskon + item.TaxRupiah);
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
    }
}
