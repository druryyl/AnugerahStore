using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Penjualan.Model
{
    public class Penjualan2Model
    {
        public string PenjualanID { get; set; }
        public string PenjualanID2 { get; set; }
        public int NoUrut { get; set; }
        public string BrgID { get; set; }
        public string BrgName { get; set; }
        public int Qty { get; set; }
        public decimal Harga { get; set; }
        public decimal Diskon { get; set; }
        public decimal SubTotal { get; set; }
    }
}
