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
    public class SupplierPresenter
    {
        private ISupplierView _view;
        private ISupplierBL _supplierBL;

        public SupplierPresenter(ISupplierView view)
        {
            _view = view;
            _supplierBL = new SupplierBL();
        }

        public SupplierPresenter(ISupplierView view, ISupplierBL supplierBL)
        {
            _view = view;
            _supplierBL = supplierBL;
        }

        public void Save()
        {
            var supplier = new SupplierModel
            {
                SupplierID = _view.SupplierID,
                SupplierName = _view.SupplierName,
                Alamat = _view.Alamat,
                NoTelp = _view.NoTelp
            };

            var result = _supplierBL.Save(supplier);
        }

        public void New()
        {
            _view.SupplierID = "";
            _view.SupplierName = "";
            _view.Alamat = "";
            _view.NoTelp = "";
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
                _view.SupplierID = result;
                _view.SupplierName = supplier.SupplierName;
                _view.Alamat = supplier.Alamat;
                _view.NoTelp = supplier.NoTelp;
            }

            return result;
        }
    }
}