using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Accounting.Model
{
    public class LunasPiutangModel
    {
        public string LunasPiutangID { get; set; }
        public string Tgl { get; set; }
        public string Jam { get; set; }
        public string PihakKeduaID { get; set; }
        public string PihaKeduaName { get; set; }
        public string PiutangID { get; set; }
        public string JenisKasID { get; set; }
        public decimal TotalNilaiSisaPiutang { get; set; }
        public decimal TotalNilaiBayar { get; set; }
    }

    public class LunasPiutangDetilModel
    {
        public string PiutangID { get; set; }   
        public string Tgl { get; set; }
        public decimal NilaiSisaPiutang { get; set; }
        public decimal NilaiBayar { get; set; }
    }
}
