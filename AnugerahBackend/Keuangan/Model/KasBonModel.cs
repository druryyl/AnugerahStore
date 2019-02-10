using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Keuangan.Model
{
    public class KasBonModel
    {
        public string KasBonID { get; set; }
        public string Tgl { get; set; }
        public string Jam { get; set; }
        public string KaryawanID { get; set; }
        public string Keperluan { get; set; }
        public string Nilai { get;set }
    }
}
