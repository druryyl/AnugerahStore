using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Accounting.Model
{
    public class BiayaModel
    {
        public string BiayaID { get; set; }
        public string Tgl { get; set; }
        public string Jam { get; set; }
        public string Keterangan { get; set; }
        public string JenisBiayaID { get; set; }
        public string JenisBiayaName { get; set; }
        public string JenisKasID { get; set; }
        public string JenisKasName { get; set; }
        public decimal NilaiBiaya { get; set; }
    }

    public class BiayaSearchModel
    {
        public string BiayaID { get; set; }
        public string TglTrs { get; set; }
        public string Keterangan { get; set; }
        public string NilaiBiaya { get; set; }

        public static explicit operator BiayaSearchModel(BiayaModel model)
        {
            return new BiayaSearchModel
            {
                BiayaID = model.BiayaID,
                TglTrs = model.Tgl,
                Keterangan = model.Keterangan,
                NilaiBiaya = model.NilaiBiaya.ToString("N0").PadLeft(15, ' ')
            };
        }
    }
}
