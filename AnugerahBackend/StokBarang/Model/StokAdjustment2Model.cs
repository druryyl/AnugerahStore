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
        public decimal QtyAwal { get; set; }
        public decimal QtyAdjust { get; set; }
        public decimal QtyAkhir { get; set; }
        public decimal HppAdjust { get; set; }
    }
}
