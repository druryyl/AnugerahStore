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
        public string PihakKeduaName { get; set; }
        public string JenisBayarID { get; set; }
        public string JenisBayarName { get; set; }
        public string JenisKasID { get; set; }
        public decimal TotalNilaiSisaPiutang { get; set; }
        public decimal TotalNilaiBayar { get; set; }
        public IEnumerable<LunasPiutangDetilModel> ListPiutangBayar { get; set; }
    }

    public class LunasPiutangDetilModel
    {
        public string LunasPiutangID { get; set; }
        public string LunasPiutangID2 { get; set; }
        public string PiutangID { get; set; }   
        public string Tgl { get; set; }
        public decimal NilaiSisaPiutang { get; set; }
        public decimal NilaiBayar { get; set; }
    }

    public class LunasPiutangSearchModel
    {
        public string LunasPiutangID { get; set; }
        public string Tgl { get; set; }
        public string CustomerName { get; set; }
        public decimal TotalNilaiBayar { get; set; }

        public static explicit operator LunasPiutangSearchModel(LunasPiutangModel model)
        {
            return new LunasPiutangSearchModel
            {
                LunasPiutangID = model.LunasPiutangID,
                Tgl = model.Tgl,
                CustomerName = model.PihakKeduaName,
                TotalNilaiBayar = model.TotalNilaiBayar
            };
        }
    }
}
