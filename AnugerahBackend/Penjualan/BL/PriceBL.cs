using AnugerahBackend.Penjualan.Dal;
using AnugerahBackend.Penjualan.Model;
using AnugerahBackend.Support.BL;
using Ics.Helper.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Penjualan.BL
{
    public interface IPriceBL
    {
        PriceModel Save(PriceModel price);
        PriceModel Delete(string id);
        PriceModel GetData(string id);
        IEnumerable<PriceModel> ListData();
    }

    public class PriceBLDep
    {
        public IPriceDal PriceDal { get; set; }
        public IPriceQtyDal PriceQtyDal { get; set; }
        public IParameterNoBL ParamNoBL { get; set; }
    }

    public class PriceBL : IPriceBL
    {
        private readonly PriceBLDep _dep;

        public PriceBL()
        {
            _dep = new PriceBLDep
            {
                PriceDal = new PriceDal(),
                PriceQtyDal = new PriceQtyDal(),
                ParamNoBL = new ParameterNoBL()
            };
        }

        public PriceBL(PriceBLDep dep)
        {
            _dep = dep;
        }

        public PriceModel Save(PriceModel price)
        {
            if (price == null)
                throw new ArgumentException("Price null");

            if (price.ListHarga == null)
                throw new ArgumentException("ListHarga null");

            if (price.PriceName.Trim() == "")
                throw new ArgumentException("PriceName empty");

            foreach(var item in price.ListHarga)
            {
                if (item.Qty == 0)
                    throw new ArgumentException("Qty NOL");
            }

            //  tidak boleh ada qty yang sama
            var listDoubleQty =
                from c in price.ListHarga
                group c by c.Qty into g
                select new
                {
                    Qty = g.Key,
                    Counter = g.Count()
                };
            if (listDoubleQty.Where(x => x.Counter > 1).Any())
                throw new ArgumentException("Qty Double");

            //  simpan
            using (var trans = TransHelper.NewScope())
            {
                //  generate id
                if (price.PriceID.Trim() == "")
                    price.PriceID = this.GenNewID();

                //  hapus data lama (jika ada)
                _dep.PriceQtyDal.Delete(price.PriceID);
                _dep.PriceDal.Delete(price.PriceID);

                //  save header
                _dep.PriceDal.Insert(price);
                price.ListHarga.ToList()
                    .ForEach(x => _dep.PriceQtyDal.Insert(x));

                //  commit
                trans.Complete();
            }
            return price;
        }

        private string GenNewID()
        {
            var prefix = "H";
            var result = _dep.ParamNoBL.GenNewID(prefix, 5);
            return result;
        }

        public PriceModel Delete(string id)
        {
            throw new NotImplementedException();
        }

        public PriceModel GetData(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PriceModel> ListData()
        {
            throw new NotImplementedException();
        }
    }
}
