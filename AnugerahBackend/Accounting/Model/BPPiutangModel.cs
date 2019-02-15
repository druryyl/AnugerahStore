using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Accounting.Model
{
    public class BPPiutangModel
    {
        public string BPPiutangID { get; set; }
        public string Tgl { get; set; }
        public string Jam { get; set; }
        public string PihakKeduaID { get; set; }
        public string PihakKeduaName { get; set; }
        public string Keterangan { get; set; }
        public decimal NilaiPiutang { get; set; }
        public decimal NilaiLunas { get; set; }
        public IEnumerable<BPPiutangDetilModel> ListLunas { get; set; }

        public static explicit operator BPPiutangModel(KasBonModel model)
        {
            var resultHeader = new BPPiutangModel
            {
                BPPiutangID = model.KasBonID,
                Tgl = model.Tgl,
                Jam = model.Jam,
                Keterangan = model.Keterangan,
                PihakKeduaID = model.PihakKeduaID,
                PihakKeduaName = model.PihakKeduaName,
                NilaiPiutang = model.NilaiKasBon,
                NilaiLunas = 0
            };

            var resultDetil = new BPPiutangDetilModel
            {
                BPPiutangID = model.KasBonID,
                BPPiutangDetilID = model.KasBonID + '-' + "01",
                Tgl = model.Tgl,
                Jam = model.Jam,
                Keterangan = model.Keterangan,
                ReffID = model.KasBonID,
                NilaiPiutang = model.NilaiKasBon,
                NilaiLunas = 0
            };
            var listDetil = new List<BPPiutangDetilModel>
            {
                resultDetil
            };
            resultHeader.ListLunas = listDetil;
            return resultHeader;
        }
    }

    public class BPPiutangSearchModel
    {
        public string BPPiutangID { get; set; }
        public string Tgl { get; set; }
        public string PihakKeduaName { get; set; }
        public string NilaiSisaPiutang { get; set; }

        public static explicit operator BPPiutangSearchModel(BPPiutangModel model)
        {
            var result = new BPPiutangSearchModel
            {
                BPPiutangID = model.BPPiutangID,
                Tgl = model.Tgl,
                PihakKeduaName = model.PihakKeduaName,
                NilaiSisaPiutang = (model.NilaiPiutang - model.NilaiLunas).ToString("N0").PadLeft(12,' '),
            };
            return result;
        }
    }
}
