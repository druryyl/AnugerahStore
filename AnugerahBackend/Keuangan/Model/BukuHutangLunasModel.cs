using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Keuangan.Model
{
    public class BukuHutangLunasModel
    {
        public string BukuHutangLunasID { get; set; }
        public string BukuHutangID { get; set; }
        public string TglLunas { get; set; }
        public string JamLunas { get; set; }
        public decimal NilaiLunas { get; set; }
        public string BukuKasID { get; set; }
    }
}
