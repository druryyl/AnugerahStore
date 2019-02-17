using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Accounting.Model
{
    public class BPPiutangInfoModel
    {
        public DateTime Tgl { get; set; }
        public string Jam { get; set; }
        public string BPPiutangID { get; set; }
        public string ReffID { get; set; }
        public string PihakKeduaName { get; set; }
        public string Keterangan { get; set; }
        public decimal NilaiPiutang { get; set; }
        public decimal NilaiLunas { get; set; }
    }
}
