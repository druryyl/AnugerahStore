using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahWinform.Accounting.Model
{
    public class LapHutangModel
    {
        public string Tgl { get; set; }
        public string Jam { get; set; }
        public string NoBukti { get; set; }
        public string PihakKedua { get; set; }
        public decimal NilaiHutang { get; set; }
        public string Keterangan { get; set; }
    }
}
