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
        public string JenisKasID { get; set; }
        public string JenisKasName { get; set; }
        public string Keterangan { get; set; }
        public decimal NilaiKasBon { get; set; }
    }

    public class KasBonSearchModel
    {
        public string KasBonID { get; set; }
        public string Tgl { get; set; }
        public string PihakKeduaName { get; set; }
        public string NilaiKasBon { get; set; }

        public static explicit operator KasBonSearchModel(KasBonModel model)
        {
            return new KasBonSearchModel
            {
                KasBonID = model.KasBonID,
                Tgl = model.Tgl,
                PihakKeduaName = model.PihakKeduaName,
                NilaiKasBon = model.NilaiKasBon.ToString("N0").PadLeft(13, ' ')
            };
        }
    }
}
