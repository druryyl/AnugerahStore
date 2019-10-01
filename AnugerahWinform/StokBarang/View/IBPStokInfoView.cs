using AnugerahBackend.StokBarang.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahWinform.StokBarang.View
{
    public interface IBPStokInfoView
    {
        DateTime PeriodeAwal { get; set; }
        DateTime PeriodeAkhir { get; set; }
        string SearchKeyword { get; set; }
        bool IsDetail { get; set; }
        int ProgressCounter { get; set; }
        int ProgressMax { get; set; }
        List<BPStokInfoRowModel> ListResult { get; set; }
    }

    public class BPStokInfoRowModel
    {
        public string BrgID { get; set; }
        public string BrgName { get; set; }
        public string Tgl { get; set; }
        public string Jam { get; set; }
        public string ReffID { get; set; }
        public string Keterangan { get; set; }
        public decimal QtyIn { get; set; }
        public decimal QtyOut { get; set; }
        public decimal Saldo { get; set; }

        
        public static explicit operator BPStokInfoRowModel(BPStokDetilView v)
        {
            if (v == null)
                return null;

            var result = new BPStokInfoRowModel
            {
                BrgID = v.BrgID,
                BrgName = v.BrgName,
                Tgl = v.Tgl,
                Jam = v.Jam,
                Keterangan = v.JenisMutasi,
                ReffID = v.ReffID,
                QtyIn = v.QtyIn,
                QtyOut = v.QtyOut,
                Saldo = v.SaldoQty
            };
            return result;
        }
    }
}
