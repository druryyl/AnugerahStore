using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.StokBarang.Model
{
    public class ProduksiHasilModel
    {
        public string ProduksiID { get; set; }
        public string ProduksiID2 { get; internal set; }
        public int NoUrut { get; set; }
        public string BrgID { get; set; }
        public string BrgName { get; set; }
        public decimal Qty { get; set; }
        public decimal Hpp { get; set; }
        public string StokControl { get; set; }
    }
}
