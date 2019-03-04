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

namespace AnugerahWinform.Pembelian.Presenter
{
    public class ReceiptPresenter
    {
        private IReceiptView _view;
        private IReceiptBL _receiptBL;
        private ISupplierBL _supplierBL;
        private IBrgBL _brgBL;

        public ReceiptPresenter(IReceiptView view)
        {
            _view = view;
            _receiptBL = new ReceiptBL();
            _supplierBL = new SupplierBL();
            _brgBL = new BrgBL();
        }
        public ReceiptPresenter(IReceiptView view, IReceiptBL bl, ISupplierBL supplierBL)
        {
            _view = view;
            _receiptBL = bl;
            _supplierBL = supplierBL;
        }

        public void Save()
        {
            var receipt = new ReceiptModel
            {
                ReceiptID = _view.ReceiptID,
                Tgl = _view.Tgl,
                Jam = _view.Jam,
                PurchaseID = _view.PurchaseID,
                SupplierID = _view.SupplierID,
                SupplierName = _view.SupplierName,
                Keterangan = _view.Catatan,
                TotalHarga = _view.Total,
                Diskon = _view.DiskonLain,
                BiayaLain = _view.BiayaLain,
                GrandTotal = _view.GrandTotal,
                ListBrg = _view.ListBrg
            };
            receipt.ListBrg = receipt.ListBrg.Where(x => x.BrgID != "").ToList();
            _receiptBL.Save(receipt);
        }

        public void New()
        {
            _view.ReceiptID = "";
            _view.Tgl = DateTime.Now.ToString("dd-MM-yyyy");
            _view.Jam = DateTime.Now.ToString("HH:mm:ss");
            _view.PurchaseID = "";
            _view.SupplierID = "";
            _view.SupplierName = "";
            _view.Alamat = "";
            _view.NoTelp = "";
            _view.Catatan = "";
            _view.ListBrg = new List<ReceiptDetilModel>();
            _view.Total = 0;
            _view.DiskonLain = 0;
            _view.BiayaLain = 0;
            _view.GrandTotal = 0;
            _view.ListBrg = new List<ReceiptDetilModel>
            {
                new ReceiptDetilModel
                {
                    BrgID = "",
                    BrgName = "",
                    Qty = 0,
                    Harga = 0,
                    Diskon = 0,
                    TaxRupiah = 0,
                    SubTotal = 0
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

        public ReceiptDetilModel PilihBrg(ReceiptDetilModel pd)
        {
            var searchForm = new SearchingForm<BrgSearchResultModel>(_brgBL);
            var resultDialog = searchForm.ShowDialog();
            if (resultDialog == DialogResult.OK)
            {
                var brgID = searchForm.SelectedDataKey;
                var brg = _brgBL.GetData(brgID);
                if (brg == null) return pd;

                if (pd == null) pd = new ReceiptDetilModel();

                pd.BrgID = brgID;
                pd.BrgName = brg.BrgName;
            }
            return pd;
        }

        public ReceiptDetilModel Calculate(ReceiptDetilModel rd)
        {
            rd.SubTotal = rd.Qty * (rd.Harga - rd.Diskon + rd.TaxRupiah);
            return rd;
        }

        public ReceiptDetilModel ValidateBrg(ReceiptDetilModel rd)
        {
            var brg = _brgBL.GetData(rd.BrgID);
            if (brg == null) return null;
            rd.BrgName = brg.BrgName;
            return rd;
        }

        public void CalculateTotal()
        {
            _view.Total = _view.ListBrg.Sum(x => x.SubTotal);
            _view.GrandTotal = _view.Total + _view.BiayaLain - _view.DiskonLain;
        }

        public void PilihReceipt()
        {
            var searchForm = new SearchingForm<ReceiptSearchResultModel>(_receiptBL);
            var resultDialog = searchForm.ShowDialog();
            if (resultDialog == DialogResult.OK)
            {
                var receiptID = searchForm.SelectedDataKey;
                var receipt = _receiptBL.GetData(receiptID);
                if (receipt == null) return;
                _view.ReceiptID = receipt.ReceiptID;
                _view.Tgl = receipt.Tgl;
                _view.Jam = receipt.Jam;
                _view.SupplierID = receipt.SupplierID;
                _view.SupplierName = receipt.SupplierName;
                _view.Catatan = receipt.Keterangan;
                var tempList = receipt.ListBrg.ToList();
                tempList.Add(new ReceiptDetilModel());

                _view.ListBrg = tempList;

                _view.BiayaLain = receipt.BiayaLain;
                _view.DiskonLain = receipt.Diskon;

                CalculateTotal();

                var supplier = _supplierBL.GetData(receipt.SupplierID);
                if (supplier == null) return;
                _view.Alamat = supplier.Alamat;
                _view.NoTelp = supplier.NoTelp;
            }
        }
    }
}