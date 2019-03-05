using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Pembelian.Model
{
    public class BPPurchaseReceiptModel
    {
        public string BPPurchaseID { get; set; }
        public string BPReceiptID { get; set; }
        public string BPDetilID { get; set; }
        public int NoUrut { get; set; }
        public string Tgl { get; set; }
        public string Jam { get; set; }
        public string Keterangan { get; set; }
        public string BrgID { get; set; }
        public long QtyPurchase { get; set; }
        public long QtyReceipt { get; set; }
        public decimal Harga { get; set; }
        public decimal Diskon { get; set; }
        public decimal Tax { get; set; }
        public decimal SubTotal { get; set; }
    }
}
