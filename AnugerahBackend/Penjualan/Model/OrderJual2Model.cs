using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Penjualan.Model
{
    public class OrderJual2Model
    {
        public string OrderJualID { get; set; }
        public string OrderJualID2 { get; set; }
        public int NoUrut { get; set; }
        public string BrgID { get; set; }
        public string BPStokID { get; set; }
        public string BrgName { get; set; }
        public decimal Qty { get; set; }
        public decimal Harga { get; set; }
        public decimal Diskon { get; set; }
        public decimal SubTotal { get; set; }
    }
}
