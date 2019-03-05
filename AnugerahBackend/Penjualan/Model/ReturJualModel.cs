using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Penjualan.Model
{
    public class ReturJualModel
    {
        public string ReturJualID { get; set; }
        public string Tgl { get; set; }
        public string Jam { get; set; }
        public string PenjualanID { get; set; }
        public string BuyerName { get; set; }
        public string Keterangan { get; set; }
        public decimal TotalRetur { get; set; }
    }
}
