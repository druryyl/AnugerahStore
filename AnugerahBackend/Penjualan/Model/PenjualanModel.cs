using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Penjualan.Model
{
    public class PenjualanModel
    {
        public string PenjualanID { get; set; }
        public string TglPenjualan { get; set; }
        public string JamPenjualan { get; set; }
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

        public decimal NilaiBayar { get; set; }
        public decimal NilaiKembali { get; set; }
        public IEnumerable<Penjualan2Model> ListBrg { get; set; }
        public IEnumerable<PenjualanBayarModel> ListBayar { get; set; }

    }

    public class PenjualanSearchModel
    {
        public string PenjualanID { get; set; }
        public string TglJual { get; set; }
        public string BuyerName { get; set; }
        public decimal NilaiGrandTotal { get; set; }
        public static explicit operator PenjualanSearchModel(PenjualanModel penjualan)
        {
            return new PenjualanSearchModel
            {
                PenjualanID = penjualan.PenjualanID,
                BuyerName = penjualan.BuyerName,
                TglJual = penjualan.TglPenjualan,
                NilaiGrandTotal = penjualan.NilaiGrandTotal
            };
        }
    }
}
