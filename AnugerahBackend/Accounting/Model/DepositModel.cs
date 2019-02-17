using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Accounting.Model
{
    public class DepositModel
    {
        public string DepositID { get; set; }
        public string Tgl { get; set; }
        public string Jam { get; set; }
        public string PihakKeduaID { get; set; }
        public string PihakKeduaName { get; set; }
        public string Keterangan { get; set; }
        public string JenisBayarID { get; set; }
        public string JenisBayarName { get; set; }
        public string JenisKasID { get; set; }
        public string JenisKasName { get; set; }
        public decimal NilaiDeposit { get; set; }
    }

    public class DepositSearchModel
    {
        public string DepositID { get; set; }
        public string Tgl { get; set; }
        public string PihakKeduaName { get; set; }
        public string Keterangan { get; set; }
        public string  NilaiDeposit { get; set; }
        public static explicit operator DepositSearchModel(DepositModel model)
        {
            var result = new DepositSearchModel
            {
                DepositID = model.DepositID,
                Tgl = model.Tgl,
                Keterangan = model.Keterangan,
                PihakKeduaName = model.PihakKeduaName,
                NilaiDeposit = model.NilaiDeposit.ToString("N0").PadLeft(2,'0')
            };
            return result;
        }

    }
}
