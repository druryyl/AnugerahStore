using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Penjualan.Model
{
    public class PriceTagDetailModel
    {
        public string BrgID { get; set; }
        public int Minimum { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
    }
}
