using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Accounting.Model
{
    public class OrderJualModel
    {
        public string OrderJualID { get; set; }
        public string Tgl { get; set; }
        public string Jam { get; set; }
        public string PihakKeduaID { get; set; }
        public string Keterangan { get; set; }
        public decimal NilaiEstimasi { get; set; }
        public string JenisKasID { get; set; }
    }
}
