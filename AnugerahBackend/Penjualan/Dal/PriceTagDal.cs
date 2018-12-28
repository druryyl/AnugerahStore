using AnugerahBackend.Penjualan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Penjualan.Dal
{

    public interface IPriceTagDal
    {
        void Insert(PriceTagModel priceTag);

        void Update(PriceTagModel priceTag);

        void Delete(string id);

        PriceTagModel GetData(string id);

        IEnumerable<PriceTagModel> ListData();
    }
}
