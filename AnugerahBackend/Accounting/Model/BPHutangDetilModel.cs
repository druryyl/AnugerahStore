using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Accounting.Model
{
    public class BPHutangDetilModel
    {
        public string BPHutangID { get; set; }
        public string BPHutangDetilID { get; set; }
        public string ReffID { get; set; }
        public string Tgl { get; set; }
        public string Jam { get; set; }
        public string Keterangan { get; set; }
        public decimal NilaiHutang { get; set; }
        public decimal NilaiLunas { get; set; }
    }
}
