using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.StokBarang.Model
{
    public class BPStokInfoDetilModel
    {
        public string BPStokID { get; set; }
        public int NoUrut { get; set; }
        public DateTime Tgl { get; set; }
        public string BrgID { get; set; }
        public string BrgName { get; set; }
        public string ReffID { get; set; }
        public long QtyIn { get; set; }
        public decimal NilaiHPP { get; set; }
        public long QtyOut { get; set; }
        public decimal HargaJual { get; set; }
        public decimal NilaiPersediaan { get; set; }
        public decimal PendapatanJual { get; set; }
    }
}
