using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Keuangan.Model
{
    public class BukuKasModel
    {
        public string BukuKasID { get; set; }
        public string TglBuku { get; set; }
        public string JamBuku { get; set; }
        public string UserrID { get; set; }

        public decimal NilaiKasMasuk { get; set; }
        public decimal NilaiKasKeluar { get; set; }
        public string ReffID { get; set; }
        public string Keterangan { get; set; }
        public string PihakKetigaID { get; set; }
        public string PihakKetigaName { get; set; }
    }
}
