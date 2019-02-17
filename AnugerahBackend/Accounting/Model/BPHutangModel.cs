using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Accounting.Model
{
    public class BPHutangModel
    {
        public string BPHutangID { get; set; }
        public string Tgl { get; set; }
        public string Jam { get; set; }
        public string PihakKeduaID { get; set; }
        public string PihakKeduaName { get; set; }
        public string Keterangan { get; set; }
        public decimal NilaiHutang { get; set; }
        public decimal NilaiLunas { get; set; }
        public IEnumerable<BPHutangDetilModel> ListLunas { get; set; }

        public static explicit operator BPHutangModel(DepositModel model)
        {
            if (model == null) return null;

            var result = new BPHutangModel
            {
                BPHutangID = model.DepositID,
                Tgl = model.Tgl,
                Jam = model.Jam,
                PihakKeduaID = model.PihakKeduaID,
                PihakKeduaName = model.PihakKeduaName,
                Keterangan = "Deposit " + model.Keterangan,
                NilaiHutang = model.NilaiDeposit,
                NilaiLunas = 0
            };

            var resultDetil = new BPHutangDetilModel
            {
                BPHutangID = model.DepositID,
                BPHutangDetilID = model.DepositID + '-' + "01",
                Tgl = model.Tgl,
                Jam = model.Jam,
                ReffID = model.DepositID,
                Keterangan = "Deposit " + model.Keterangan,
                NilaiHutang = model.NilaiDeposit,
                NilaiLunas = 0
            };

            result.ListLunas = new List<BPHutangDetilModel> { resultDetil };
            return result;
        }
    }

    public class BPHutangSearchModel
    {
        public string BPHutangID { get; set; }
        public string Tgl { get; set; }
        public string PihakKeduaName { get; set; }
        public string NilaiSisaHutang { get; set; }

        public static explicit operator BPHutangSearchModel(BPHutangModel model)
        {
            var result = new BPHutangSearchModel
            {
                BPHutangID = model.BPHutangID,
                Tgl = model.Tgl,
                PihakKeduaName = model.PihakKeduaName,
                NilaiSisaHutang = (model.NilaiHutang - model.NilaiLunas).ToString("N0").PadLeft(12, ' '),
            };
            return result;
        }
    }
}
