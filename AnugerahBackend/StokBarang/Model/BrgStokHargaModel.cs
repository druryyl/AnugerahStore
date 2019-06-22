using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.StokBarang.Model
{
    public class BrgStokHargaModel
    {
        public string BrgID { get; set; }
        public string BrgName { get; set; }
        public decimal Qty { get; set; }
        public decimal Harga { get; set; }
    }
}
