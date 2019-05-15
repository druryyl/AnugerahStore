using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Penjualan.Model
{
    public class PriceModel
    {
        public string PriceID { get; set; }
        public string PriceName { get; set; }
        public IEnumerable<PriceQtyModel> ListHarga { get; set; }
    }
}
