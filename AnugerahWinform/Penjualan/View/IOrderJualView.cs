using AnugerahBackend.Penjualan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahWinform.Penjualan.View
{
    public interface IOrderJualView
    {
        string OrderJualID { get; set; }
        string TglOrderJual { get; set; }
        string JamOrderJual { get; set; }
        string CustomerID { get; set; }
        string CustomerName { get; set; }
        string BuyerName { get; set; }
        string Alamat { get; set; }
        string NoTelpon { get; set; }
        string Catatan { get; set; }

        List<OrderJual2Model> ListBrg { get; set; }

        decimal NilaiTotal { get; set; }
        decimal NilaiDiskonLain { get; set; }
        decimal NilaiBiayaLain { get; set; }
        decimal NilaiGrandTotal { get; set; }
    }
}
