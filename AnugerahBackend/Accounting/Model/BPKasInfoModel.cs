using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Accounting.Model
{
    public class BPKasInfoModel
    {
        public string BPKasID { get; set; }
        public string BPKasDetilID { get; set; }
        public DateTime Tgl { get; set; }
        public string Jam { get; set; }
        public string Keterangan { get; set; }
        public string JenisKasID { get; set; }
        public string JenisKasName { get; set; }
        public decimal NilaiKasMasuk { get; set; }
        public decimal NilaiKasKeluar { get; set; }
    }
}
