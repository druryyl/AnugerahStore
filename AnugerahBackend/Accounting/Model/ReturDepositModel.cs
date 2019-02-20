using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Accounting.Model
{
    public class ReturDepositModel
    {
        public string ReturDepositID { get; set; }
        public string Tgl { get; set; }
        public string Jam { get; set; } 
        public string DepositID { get; set; }
        public string PihakKeduaName { get; set; }
        public string JenisKasID { get; set; }
        public string JenisKasName { get; set; }
        public string Catatan { get; set; }
        public decimal NilaiSisaDeposit { get; set; }
        public decimal NilaiReturDeposit { get; set; }
    }

    public class ReturDepositSearchModel
    {
        public string ReturDepositID { get; set; }
        public string Tgl { get; set; }
        public string PihakKeduaName { get; set; }
        public string NilaiReturDeposit { get; set; }

        public static explicit operator ReturDepositSearchModel(ReturDepositModel model)
        {
            var result = new ReturDepositSearchModel
            {
                ReturDepositID = model.ReturDepositID,
                Tgl = model.Tgl,
                PihakKeduaName = model.PihakKeduaName,
                NilaiReturDeposit = model.NilaiReturDeposit.ToString("N0").PadLeft(15, ' ')
            };
            return result;
        }
    }
}
