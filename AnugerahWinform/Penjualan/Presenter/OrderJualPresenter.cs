using AnugerahBackend.Penjualan.BL;
using AnugerahBackend.Penjualan.Model;
using AnugerahBackend.StokBarang.BL;
using AnugerahBackend.StokBarang.Model;
using AnugerahWinform.Penjualan.View;
using AnugerahWinform.Support;
using Ics.Helper.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnugerahWinform.Penjualan.Presenter
{
    public class OrderJualPresenter
    {
        private IOrderJualView _view;
        private IOrderJualBL _orderJualBL;
        private IBrgBL _brgBL;
        private ICustomerBL _customerBL;

        public OrderJualPresenter(IOrderJualView view)
        {
            _view = view;
            _orderJualBL = new OrderJualBL();
            _brgBL = new BrgBL();
            _customerBL = new CustomerBL();
        }

        public OrderJualPresenter(IOrderJualView view, IOrderJualBL bl, 
            IBrgBL brgBL, ICustomerBL customerBL)
        {
            _view = view;
            _orderJualBL = bl;
            _brgBL = brgBL;
            _customerBL = customerBL;
        }

        public void Save()
        {
            var orderJual = new OrderJualModel
            {
                OrderJualID = _view.OrderJualID,
                TglOrderJual = _view.TglOrderJual,
                JamOrderJual = _view.JamOrderJual,

                CustomerID = _view.CustomerID,
                BuyerName = _view.BuyerName,
                Alamat = _view.Alamat,

                NoTelp = _view.NoTelpon,
                Catatan = _view.Catatan,

                NilaiTotal = _view.NilaiTotal,
                NilaiDiskonLain = _view.NilaiDiskonLain,
                NilaiBiayaLain = _view.NilaiBiayaLain,
                NilaiGrandTotal = _view.NilaiGrandTotal,
            };
            orderJual.ListBrg = orderJual.ListBrg.Where(x => x.BrgID != "").ToList();

            using (var trans = TransHelper.NewScope())
            {
                var result = _orderJualBL.Save(orderJual);
                trans.Complete();
            }
        }

        public void New()
        {
            _view.OrderJualID = "";
            _view.TglOrderJual = DateTime.Now.ToString("dd-MM-yyyy");
            _view.JamOrderJual = DateTime.Now.ToString("HH:mm:ss");
            _view.CustomerID = _view.CustomerID;
            _view.BuyerName = _view.BuyerName;
            _view.Alamat = _view.Alamat;
            _view.NoTelpon = _view.NoTelpon;
            _view.Catatan = _view.Catatan;
            _view.NilaiTotal = _view.NilaiTotal;
            _view.NilaiDiskonLain = _view.NilaiDiskonLain;
            _view.NilaiBiayaLain = _view.NilaiBiayaLain;
            _view.NilaiGrandTotal = _view.NilaiGrandTotal;
            _view.ListBrg = new List<OrderJual2Model>
            {
                new OrderJual2Model
                {
                    BrgID = "",
                    BrgName = "",
                    Qty = 0,
                    Harga = 0,
                    Diskon = 0,
                    SubTotal = 0,
                }
            };
        }

        public IEnumerable<CustomerModel> ListCustomer()
        {
            return _customerBL.ListData();
        }

        public OrderJual2Model PilihBrg(OrderJual2Model orderJual2)
        {
            var searchForm = new SearchingForm<BrgSearchResultModel>(_brgBL);
            var resultDialog = searchForm.ShowDialog();
            if (resultDialog == DialogResult.OK)
            {
                var brgID = searchForm.SelectedDataKey;
                var brg = _brgBL.GetData(brgID);
                if (brg == null) return orderJual2;

                if (orderJual2 == null) orderJual2 = new OrderJual2Model();

                orderJual2.BrgID = brgID;
                orderJual2.BrgName = brg.BrgName;
            }
            return orderJual2;
        }

        public string PilihCustomer()
        {
            var result = "";
            var searchForm = new SearchingForm<CustomerSearchModel>(_customerBL);
            var resultDialog = searchForm.ShowDialog();
            if (resultDialog == DialogResult.OK)
            {
                result = searchForm.SelectedDataKey;
            }
            var supplier = _customerBL.GetData(result);

            if (supplier != null)
            {
                _view.CustomerName = supplier.CustomerName;
                _view.Alamat = supplier.Alamat1;
                _view.NoTelpon = supplier.NoTelp;
            }

            return result;
        }

        public void Delete()
        {
            _orderJualBL.Void(_view.OrderJualID);
        }

        public OrderJual2Model Calculate(OrderJual2Model orderJual2)
        {
            var hargaSatu = orderJual2.Harga - orderJual2.Diskon;
            orderJual2.SubTotal = orderJual2.Qty * hargaSatu;
            return orderJual2;
        }

        public OrderJual2Model ValidateBrg(OrderJual2Model orderJual2)
        {
            var brg = _brgBL.GetData(orderJual2.BrgID);
            if (brg == null) return null;
            orderJual2.BrgName = brg.BrgName;
            return orderJual2;
        }
        public void CalculateTotal()
        {
            if (_view.ListBrg == null)
                _view.NilaiTotal = 0;
            else
                _view.NilaiTotal = _view.ListBrg.Sum(x => x.SubTotal);

            _view.NilaiGrandTotal = _view.NilaiTotal + 
                _view.NilaiBiayaLain - _view.NilaiDiskonLain;
        }
        public void PilihPurchase()
        {
            var searchForm = new SearchingForm<OrderJualSearchModel>(_orderJualBL);
            var resultDialog = searchForm.ShowDialog();
            if (resultDialog == DialogResult.OK)
            {
                var orderJualID = searchForm.SelectedDataKey;
                var orderJual = _orderJualBL.GetData(orderJualID);
                if (orderJual == null) return;
                _view.OrderJualID = orderJual.OrderJualID;
                _view.TglOrderJual = orderJual.TglOrderJual;
                _view.JamOrderJual = orderJual.JamOrderJual;
                _view.CustomerID = orderJual.CustomerID;
                _view.BuyerName= orderJual.BuyerName;
                _view.Catatan = orderJual.Catatan;

                var tempList = orderJual.ListBrg.ToList();
                tempList.Add(new OrderJual2Model());

                _view.ListBrg = tempList;

                _view.NilaiBiayaLain = orderJual.NilaiBiayaLain;
                _view.NilaiDiskonLain = orderJual.NilaiDiskonLain;

                CalculateTotal();

                var customer = _customerBL.GetData(orderJual.CustomerID);
                if (customer == null) return;
                _view.Alamat = customer.Alamat1;
                _view.NoTelpon = customer.NoTelp;
            }
        }
    }
}
