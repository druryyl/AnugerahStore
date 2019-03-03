using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Pembelian.Model
{
    public class ReceiptModel
    {
        public string ReceiptID { get; set; }
        public string Tgl { get; set; }
        public string Jam { get; set; }
        public string PurchaseID { get; set; }
        public string SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string Keterangan { get; set; }
        public decimal TotalHarga { get; set; }
        public decimal Diskon { get; set; }
        public decimal BiayaLain { get; set; }
        public decimal GrandTotal { get; set; }

    }
}
