using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Penjualan.Model
{
    public class BrgPriceModel
    {
        public string BrgID { get; set; }
        public int Qty { get; set; }
        public double Harga { get; set; }
        public double Diskon { get; set; }

    }
}
