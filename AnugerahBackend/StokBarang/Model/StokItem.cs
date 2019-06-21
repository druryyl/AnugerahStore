using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.StokBarang.Model
{
    public class StokItem
    {
        public string ReffID { get; set; }
        public string BPStokID { get; set; }
        public string Tgl { get; set; }
        public string Jam { get; set; }
        public string BrgID { get; set; }
        public string BrgName { get; set; }

        public decimal QtyIn { get; set; }
        public decimal NilaiHpp { get; set; }
        public decimal QtyOut { get; set; }
        public decimal HargaJual { get; set; }
    }
}
