using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Pembelian.Model
{
    public class ReceiptDetilModel
    {
        public string ReceiptID { get; set; }
        public string ReceiptDetilID { get; set; }
        public int NoUrut { get; set; }
        public string BrgID { get; set; }
        public string BrgName { get; set; }
        public decimal Qty { get; set; }
        public decimal Harga { get; set; }
        public decimal Diskon { get; set; }
        public decimal TaxRupiah { get; set; }
        public decimal SubTotal { get; set; }
    }
}
