using AnugerahBackend.Penjualan.Dal;
using AnugerahBackend.Penjualan.Model;
using AnugerahBackend.StokBarang.BL;
using AnugerahBackend.Support;
using AnugerahBackend.Support.BL;
using Ics.Helper.Database;
using Ics.Helper.Extensions;
using Ics.Helper.StringDateTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Penjualan.BL
{
    public interface IOrderJualBL : ISearch<OrderJualSearchModel>
    {
        OrderJualModel Save(OrderJualModel orderJual);

        void Void(string id);

        OrderJualModel GetData(string id);

        IEnumerable<OrderJualModel> ListData(string tgl1, string tgl2);

        OrderJualModel TryValidate(OrderJualModel orderJual);
    }

    public class OrderJualBL : IOrderJualBL
    {
        private IOrderJualDal _orderJualDal;
        private IOrderJual2Dal _orderJual2Dal;
        private IParameterNoBL _paramNoBL;
        private IBrgBL _brgBL;
        private IJenisBayarDal _jenisBayarDal;

        public OrderJualBL()
        {
            _orderJualDal = new OrderJualDal();
            _orderJual2Dal = new OrderJual2Dal();
            _paramNoBL = new ParameterNoBL();
            _brgBL = new BrgBL();
            _jenisBayarDal = new JenisBayarDal();
            SearchFilter = new SearchFilter
            {
                IsDate = true,
                Date1 = DateTime.Now,
                Date2 = DateTime.Now
            };

        }

        public OrderJualBL(IOrderJualDal injOrderJualDal, IOrderJual2Dal injOrderJual2Dal,
            IBrgBL injBrgBL, IParameterNoBL injParamNoBL)
        {
            _orderJualDal = injOrderJualDal;
            _orderJual2Dal = injOrderJual2Dal;
            _paramNoBL = injParamNoBL;
            _brgBL = injBrgBL;
        }

        public OrderJualModel Save(OrderJualModel orderJual)
        {
            //  validasi
            var result = orderJual;
            result = TryValidate(orderJual);

            var trsID = "";

            //  save
            using (var trans = TransHelper.NewScope())
            {
                //  edit: delete data lama
                if (orderJual.OrderJualID.Trim() != "")
                {
                    _orderJual2Dal.Delete(orderJual.OrderJualID);
                    _orderJualDal.Delete(orderJual.OrderJualID);
                    trsID = orderJual.OrderJualID;
                }
                //  baru: generate no.transaksi
                else
                {
                    var prefix = "JL" + DateTime.Now.ToString("yyMM");
                    trsID = _paramNoBL.GenNewID(prefix, 10);
                }

                //  save header
                orderJual.OrderJualID = trsID;
                _orderJualDal.Insert(orderJual);
                //  save detil barang
                foreach (var item in orderJual.ListBrg)
                {
                    item.OrderJualID = trsID;
                    item.OrderJualID2 = string.Format("{0}-{1}", trsID, item.NoUrut.ToString().PadLeft(3, '0'));
                    _orderJual2Dal.Insert(item);
                }
                trans.Complete();
            }
            return result;
        }

        public void Void(string id)
        {
            using (var trans = TransHelper.NewScope())
            {
                _orderJual2Dal.Delete(id);
                _orderJualDal.Delete(id);
                trans.Complete();
            }
        }

        public OrderJualModel GetData(string id)
        {
            var header = _orderJualDal.GetData(id);
            if (header != null)
            {
                var detilBrg = _orderJual2Dal.ListData(id);
                if (detilBrg != null)
                    header.ListBrg = detilBrg;
            }
            return header;
        }

        public IEnumerable<OrderJualModel> ListData(string tgl1, string tgl2)
        {
            return _orderJualDal.ListData(tgl1, tgl2);
        }

        public OrderJualModel TryValidate(OrderJualModel orderJual)
        {
            var result = orderJual;

            if (orderJual == null)
            {
                throw new ArgumentNullException(nameof(orderJual));
            }

            //  validasi tgl dan jam
            if (!orderJual.TglOrderJual.IsValidTgl("dd-MM-yyyy"))
            {
                throw new ArgumentException("Invalid Tgl.OrderJual");
            }
            if (!orderJual.JamOrderJual.IsValidJam("HH:mm:ss"))
            {
                throw new ArgumentException("Invalid Jam.OrderJual");
            }
            //  cek BrgID
            foreach (var item in orderJual.ListBrg)
            {
                var brg = _brgBL.GetData(item.BrgID);
                if (brg == null)
                    throw new ArgumentException("Invalid BrgID ");
                else
                    item.BrgName = brg.BrgName;
                //  re-calc qty akhir
                item.SubTotal = (item.Harga - item.Diskon) * item.Qty;
            }

            return result;
        }

        public SearchFilter SearchFilter { get; set; }

        public IEnumerable<OrderJualSearchModel> Search()
        {
            var listData = _orderJualDal.ListData(SearchFilter.TglDMY1, SearchFilter.TglDMY2);
            if (listData == null) return null;

            //  convert ke SearchModel
            var result = listData.Select(x => (OrderJualSearchModel)x);

            //  filter
            if (SearchFilter.UserKeyword != null)
                return
                    from c in result
                    where c.BuyerName.ContainMultiWord(SearchFilter.UserKeyword)
                    select c;

            return result;
        }
    }
}
