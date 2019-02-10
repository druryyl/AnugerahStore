using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Accounting.Model
{
    public class BPKasDetilModel
    {
        public string BPKasID { get; set; }
        public string BPKasDetilID { get; set; }
        public string JenisKasID { get; set; }
        public string JenisKasName { get; set; }
        public decimal NilaiKasMasuk { get; set; }
        public decimal NilaiKasKeluar { get; set; }

    }
}
