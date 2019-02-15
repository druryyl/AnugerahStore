using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Accounting.Model
{
    public class LunasKasBonModel
    {
        public string LunasKasBonID { get; set; }
        public string Tgl { get; set; }
        public string Jam { get; set; }
        public string PihakKeduaID { get; set; }
        public string PihakKeduaName { get; set; }
        public string KasBonID { get; set; }
        public decimal NilaiSisaPiutang { get; set; }
        public decimal NilaiTotLunas { get; set; }
        public IEnumerable<LunasKasBonDetilModel> ListLunas { get; set; }
    }

    public class LunasKasBonSearchModel
    {
        public string LunasKasBonID { get; set; }
        public string Tgl { get; set; }
        public string PihakKeduaName { get; set; }
        public string NilaiTotLunas { get; set; }

        public static explicit operator LunasKasBonSearchModel(LunasKasBonModel model)
        {
            var result = new LunasKasBonSearchModel
            {
                LunasKasBonID = model.LunasKasBonID,
                PihakKeduaName = model.PihakKeduaName,
                NilaiTotLunas = model.NilaiTotLunas.ToString("N0").PadLeft(13, ' '),
                Tgl = model.Tgl
            };
            return result;
        }
    }
}
