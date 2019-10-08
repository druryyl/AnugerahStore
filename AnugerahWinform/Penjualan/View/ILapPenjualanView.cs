using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahWinform.Penjualan.View
{
    public interface ILapPenjualanView
    {
        DateTime PeriodeAwal { get; set; }
        DateTime PeriodeAkhir { get; set; }
        string SearchKeyword { get; set; }
        bool IsDetail { get; set; }
        int ProgressCounter { get; set; }
        int ProgressMax { get; set; }
        List<PenjualanViewModel> ListResult { get; set; }
    }

    public class PenjualanViewModel
    {
        public string Tgl { get; set; }
        public string NoNota { get; set; }
        public string CustomerName { get; set; }

        public decimal Penjualan { get; set; }
        public decimal Kas { get; set; }
        public decimal BcaEdc { get; set; }
        public decimal BcaTrf { get; set; }
        public decimal BriEdc { get; set; }
        public decimal BriTrf { get; set; }
        public decimal Deposit { get; set; }
        public decimal Piutang { get; set; }
        public string Keterangan { get; set; }
    }
}
