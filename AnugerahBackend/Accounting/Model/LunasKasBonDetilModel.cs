using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Accounting.Model
{
    public class LunasKasBonDetilModel
    {
        public string LunasKasBonID { get; set; }
        public string LunasKasBonDetilID { get; set; }
        public string JenisLunasID { get; set; }
        public string JenisLunasName { get; set; }
        public decimal NilaiLunas { get; set; }
        public string PenjualanID { get; set; }
    }
}
