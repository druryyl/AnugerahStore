using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Accounting.Model
{
    public class BPKasModel
    {
        public string BPKasID { get; set; }
        public string Tgl { get; set; }
        public string Jam { get; set; }
        public string Keterangan { get; set; }
        public decimal NilaiTotalKas { get; set; }
        public IEnumerable<BPKasDetilModel> ListDetil { get; set; }

        public static explicit operator BPKasModel(BiayaModel model)
        {
            var result = new BPKasModel
            {
                BPKasID = model.BiayaID,
                Tgl = model.Tgl,
                Jam = model.Jam,
                Keterangan = model.Keterangan,
                NilaiTotalKas = -model.NilaiBiaya
            };

            var resultDetil = new BPKasDetilModel
            {
                BPKasID = model.BiayaID,
                BPKasDetilID = model.BiayaID + '-' + "01",
                JenisKasID = model.JenisKasID,
                NilaiKasMasuk = 0,
                NilaiKasKeluar = model.NilaiBiaya
            };

            result.ListDetil = new List<BPKasDetilModel> { resultDetil };
            return result;
        }
    }
}
