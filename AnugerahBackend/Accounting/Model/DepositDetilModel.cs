using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Accounting.Model
{
    public class DepositDetilModel
    {
        public string DepositID { get; set; }
        public string BrgID { get; set; }
        public decimal Qty { get; set; }
        public decimal Harga { get; set; }
        public decimal Diskon { get; set; }
        public decimal SubTotal { get; set; }
    }
}
