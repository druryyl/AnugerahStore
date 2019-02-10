using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Accounting.Model
{
    public class KasBonModel
    {
        public string KasBonID { get; set; }
        public string Tgl { get; set; }
        public string Jam { get; set; }
        public string PihakKeduaID { get; set; }
        public string PihakKeduaName { get; set; }
        public string Keterangan { get; set; }
        public decimal NilaiKasBon { get; set; }
    }
}
