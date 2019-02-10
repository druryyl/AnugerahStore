using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Accounting.Model
{
    public class BiayaModel
    {
        public string BiayaID { get; set; }
        public string Tgl { get; set; }
        public string Jam { get; set; }
        public string Keterangan { get; set; }
        public decimal NilaiBiaya { get; set; }
    }
}
