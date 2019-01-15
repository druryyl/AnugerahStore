using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.StokBarang.Model
{
    public class StokModel
    {
        public string StokID { get; set; }
        public string BrgID { get; set; }
        public string BrgName { get; set; }
        public string TglMasuk { get; set; }
        public string JamMasuk { get; set; }
        public string TrsMasukID { get; set; }
        public string TrsDOID { get; set; }
        public string BatchNo { get; set; }
        public long QtyIn { get; set; }
        public long QtySaldo { get; set; }
        public double Hpp { get; set; }
    }

    public class StokSearchModel
    {
        public string BrgID { get; set; }
        public string BrgName { get; set; }
        public string BatchNo { get; set; }
        public long Qty { get; set; }
    }
}
