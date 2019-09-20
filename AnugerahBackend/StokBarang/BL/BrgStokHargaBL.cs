using AnugerahBackend.Penjualan.Dal;
using AnugerahBackend.StokBarang.Dal;
using AnugerahBackend.StokBarang.Model;
using AnugerahBackend.Support;
using Ics.Helper.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.StokBarang.BL
{
    public interface IBrgStokHargaBL : ISearch<BrgStokHargaModel>
    {
        void UpdateStok(string brgID);
        void UpdateHarga(string brgID);
    }
    public class BrgStokHargaBL : IBrgStokHargaBL
    {
        public IBrgStokHargaDal _brgStokHargaDal;
        public IBrgPriceDal _brgPriceDal;
        public SearchFilter SearchFilter { get; set; }

        public BrgStokHargaBL()
        {
            _brgStokHargaDal = new BrgStokHargaDal();
            _brgPriceDal = new BrgPriceDal();
        }
        public BrgStokHargaBL(IBrgStokHargaDal brgStokHargaDal,
                              IBrgPriceDal brgPriceDal)
        {
            _brgStokHargaDal = brgStokHargaDal;
            _brgPriceDal = brgPriceDal;
        }

        public void UpdateStok(string brgID)
        {
            var qtySisa = _brgStokHargaDal.ReCalcQty(brgID);
            var stokInfo = _brgStokHargaDal.GetData(brgID);

            if (stokInfo == null)
            {
                stokInfo = new BrgStokHargaModel
                {
                    BrgID = brgID,
                    Qty = qtySisa,
                    Harga = 0,
                };
                _brgStokHargaDal.Insert(stokInfo);
            }
            else
            {
                stokInfo.Qty = qtySisa;
                _brgStokHargaDal.Update(stokInfo);
            }
        }

        public void UpdateHarga(string brgID)
        {
            var price = _brgPriceDal.ListData(brgID).FirstOrDefault();
            var stokInfo = _brgStokHargaDal.GetData(brgID);

            if (stokInfo == null)
            {
                stokInfo = new BrgStokHargaModel
                {
                    BrgID = brgID,
                    Qty = 0,
                    Harga = Convert.ToDecimal(price.Harga),
                };
                _brgStokHargaDal.Insert(stokInfo);
            }
            else
            {
                stokInfo.Harga = Convert.ToDecimal(price.Harga);
                _brgStokHargaDal.Update(stokInfo);
            }
        }

        public IEnumerable<BrgStokHargaModel> Search()
        {
            var listData = _brgStokHargaDal.ListData();
            if (listData == null) return null;

            if (SearchFilter.StaticKeyword != null)
            {
                listData =
                    from c in listData
                    where c.BrgID == SearchFilter.StaticKeyword
                    select c;
            }


            var result = listData.Select(x => (BrgStokHargaModel)x);
            if (SearchFilter.UserKeyword != null)
                return
                    from c in result
                    where c.BrgName.ContainMultiWord(SearchFilter.UserKeyword)
                    select c;

            return result;
        }
    }
}
