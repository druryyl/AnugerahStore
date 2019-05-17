using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Penjualan.Model
{
    public class PriceQtyModel
    {
        public string PriceID { get; set; }
        public int Qty { get; set; }
        public decimal Harga { get; set; }
        public decimal Diskon { get; set; }
    }
}
