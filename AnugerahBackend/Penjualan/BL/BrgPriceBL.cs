using AnugerahBackend.Penjualan.Dal;
using AnugerahBackend.Penjualan.Model;
using AnugerahBackend.StokBarang.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Penjualan.BL
{

    public interface IBrgPriceBL
    {
        IEnumerable<BrgPriceModel> Save(string brgID, IEnumerable<BrgPriceModel> brgPrice);

        void Delete(string id);

        IEnumerable<BrgPriceModel> ListData(string brgID);

        IEnumerable<BrgPriceModel> TryValidate(IEnumerable<BrgPriceModel> brgPrice);
    }

    public class BrgPriceBL : IBrgPriceBL
    {
        private IBrgPriceDal _brgPriceDal;
        private IBrgBL _brgBL;

        public BrgPriceBL()
        {
            _brgPriceDal = new BrgPriceDal();
            _brgBL = new BrgBL();
        }

        public BrgPriceBL(IBrgPriceDal injBrgPriceDal)
        {
            _brgPriceDal = injBrgPriceDal;
        }

        public IEnumerable<BrgPriceModel> Save(string brgID, IEnumerable<BrgPriceModel> listBrgPrice)
        {
            //  validasi
            var result = listBrgPrice;
            result = TryValidate(listBrgPrice);

            //  save
            //  delete data lama
            _brgPriceDal.Delete(brgID);
            //  insert data baru
            foreach(var item in listBrgPrice)
            {
                _brgPriceDal.Insert(brgID, item);
            }
            return result;
        }

        public void Delete(string id)
        {
            _brgPriceDal.Delete(id);
        }

        public IEnumerable<BrgPriceModel> ListData(string brgID)
        {
            return _brgPriceDal.ListData(brgID);
        }

        public IEnumerable<BrgPriceModel> TryValidate(IEnumerable<BrgPriceModel> listBrgPrice)
        {
            var result = listBrgPrice;

            if (listBrgPrice == null)
            {
                throw new ArgumentNullException(nameof(listBrgPrice));
            }

            foreach(var item in listBrgPrice)
            {
                if (item.BrgID.Trim() == "")
                {
                    throw new ArgumentException("BrgID empty");
                }

                var brg = _brgBL.GetData(item.BrgID);
                if(brg == null)
                {
                    var errMsg = string.Format("BrgID invalid {0}", item.BrgID);
                    throw new ArgumentException(errMsg);
                }
            }

            return result;
        }
    }
}
