using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Pembelian.Model
{
    public class BPPurchaseModel
    {
        public string BPPurchaseID { get; set; }
        public string Tgl { get; set; }
        public string Jam { get; set; }
        public string SupplierID { get; set; }
        public string Keterangan { get; set; }
        public decimal TotHargaPurchase { get; set; }
        public decimal TotHargaReceipt { get; set; }
        public decimal Diskon { get; set; }
        public decimal BiayaLain { get; set; }
        public decimal GrandTotal { get; set; }
    }
}
