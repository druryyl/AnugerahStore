using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Penjualan.Model
{
    public class OrderJualModel
    {
        public string OrderJualID { get; set; }
        public string TglOrderJual { get; set; }
        public string JamOrderJual { get; set; }
        public string UserrID { get; set; }

        public string CustomerID { get; set; }
        public string BuyerName { get; set; }
        public string Alamat { get; set; }
        public string NoTelp { get; set; }
        public string Catatan { get; set; }

        public decimal NilaiTotal { get; set; }
        public decimal NilaiDiskonLain { get; set; }
        public decimal NilaiBiayaLain { get; set; }
        public decimal NilaiGrandTotal { get; set; }

        public IEnumerable<OrderJual2Model> ListBrg { get; set; }
    }

    public class OrderJualSearchModel
    {
        public string OrderJualID { get; set; }
        public string TglOrderJual { get; set; }
        public string BuyerName { get; set; }
        public string Total { get; set; }
        public static explicit operator OrderJualSearchModel(OrderJualModel orderJual)
        {
            return new OrderJualSearchModel
            {
                OrderJualID = orderJual.OrderJualID,
                BuyerName = orderJual.BuyerName,
                TglOrderJual = orderJual.TglOrderJual,
                Total = orderJual.NilaiGrandTotal.ToString("N0").PadLeft(12, ' ')
            };
        }
    }

}
