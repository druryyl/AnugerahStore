using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Accounting.Model
{
    public class BPHutangModel
    {
        public string BPHutangID { get; set; }
        public string Tgl { get; set; }
        public string Jam { get; set; }
        public string PihakKeduaID { get; set; }
        public string PihakKeduaName { get; set; }
        public string Keterangan { get; set; }
        public string NilaiHutang { get; set; }
        public string NilaiLunas { get; set; }
    }
}
