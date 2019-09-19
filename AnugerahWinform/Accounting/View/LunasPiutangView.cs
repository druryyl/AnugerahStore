using AnugerahBackend.Accounting.Model;
using AnugerahBackend.Penjualan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahWinform.Accounting.View
{
    public interface ILunasPiutangView
    {
        string LunasPiutangID { get; set; }
        string Tgl { get; set; }
        string Jam { get; set; }
        string CustomerID { get; set; }
        string CustomerName { get; set; }
        decimal TotalPiutang { get; set; }
        decimal TotalBayar { get; set; }
        string JenisBayarID { get; set; }
        string JenisBayarName { get; }
        List<BPPiutangViewModel> ListPiutang { get; set; }
    }

    public class BPPiutangViewModel
    {
        public string BPPiutangID { get; set; }
        public string Tgl { get; set; }
        public decimal Nilai { get; set; }
        public decimal Bayar { get; set; }
    }
}
