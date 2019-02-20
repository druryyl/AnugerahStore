using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.StokBarang.Model
{
    public class BPStokModel
    {
        public string BPStokID { get; set; }
        public string ReffID { get; set; }
        public string Tgl { get; set; }
        public string Jam { get; set; }
        public string BrgID { get; set; }
        public string BrgName { get; set; }
        public decimal NilaiHpp { get; set; }
        public long QtyIn { get; set; }
        public long QtySisa { get; set; }

        public IEnumerable<BPStokDetilModel> ListDetil { get; set; }
    }
}
