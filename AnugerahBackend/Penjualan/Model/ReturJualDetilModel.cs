using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Penjualan.Model
{
    public class ReturJualDetilModel
    {
        public string ReturJualID { get; set; }
        public string ReturJualDetilID { get; set; }
        public int NoUrut { get; set; }
        public string BrgID { get; set; }
        public string BrgName { get; set; }
        public long QtySisa { get; set; }
        public long QtyRetur { get; set; }
        public decimal HargaRetur { get; set; }
        public decimal SubTotal { get; set; }
    }
}
