using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahWinform.Accounting.View
{
    public interface ILapKasView
    {
        DateTime PeriodeAwal { get; set; }
        DateTime PeriodeAkhir { get; set; }
        string SearchKeyword { get; set; }
        bool IsDetail { get; set; }
        int ProgressCounter { get; set; }
        int ProgressMax { get; set; }
        List<LapKasViewModel> ListResult { get; set; }
    }

    public class LapKasViewModel
    {
        public string Tgl { get; set; }
        public string Jam { get; set; } 
        public string NoTransaksi { get; set; }

        public decimal KasKecil { get; set; }
        public decimal KasBankBca { get; set; }
        public decimal KasBankBri { get; set; }
        public string Keterangan { get; set; }
    }
}
