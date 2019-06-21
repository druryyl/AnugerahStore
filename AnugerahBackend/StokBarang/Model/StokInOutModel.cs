using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.StokBarang.Model
{
    public class StokInOutModel
    {
        public string StokInID { get; set; }
        public string StokInOutID { get; set; }
        public string TglTrs { get; set; }
        public string JamTrs { get; set; }
        public string ReffTrsID { get; set; }
        public string JenisMutasiID { get; set; }
        public string JenisMutasiName { get; set; }

        public string BrgID { get; set; }
        public string BrgName { get; set; }
        public string StokControlID { get; set; }


        public decimal QtyIn { get; set; }
        public decimal QtyOut { get; set; }
        public double Hpp { get; set; }
        public double HargaJual { get; set; }
    }
}
