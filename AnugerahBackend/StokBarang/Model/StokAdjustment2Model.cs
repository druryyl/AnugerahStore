using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.StokBarang.Model
{
    public class StokAdjustment2Model
    {
        public string StokAdjustmentID { get; set; }
        public string StokAdjustmentID2 { get; set; }
        public int NoUrut { get; set; }
        public string BrgID { get; set; }
        public string BrgName { get; set; }
        public long QtyAwal { get; set; }
        public long QtyAdjust { get; set; }
        public long QtyAkhir { get; set; }
        public double HppAdjust { get; set; }
    }
}
