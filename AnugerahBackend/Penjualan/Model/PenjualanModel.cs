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

        public double NilaiTotal { get; set; }
        public double NilaiDiskonLain { get; set; }
        public double NilaiBiayaLain { get; set; }
        public double NilaiGrandTotal { get; set; }

        public double NilaiBayar { get; set; }
        public double NilaiKembali { get; set; }
        public IEnumerable<Penjualan2Model> ListBrg { get; set; }
    }

    public class PenjualanSearchModel
    {
        public string PenjualanID { get; set; }
        public string TglJual { get; set; }
        public string CustomerName { get; set; }
        public double NilaiGrandTotal { get; set; }
    }
}
