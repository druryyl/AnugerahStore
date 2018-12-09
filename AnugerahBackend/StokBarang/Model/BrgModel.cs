using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.StokBarang.Model
{
    public class BrgModel
    {
        public string BrgID { get; set; }
        public string BrgName { get; set; }
        public string Keterangan { get; set; }
        public string SubJenisBrgID { get; set; }
        public string SubJenisBrgName { get; set; }
        public string JenisBrgID { get; set; }
        public string JenisBrgName { get; set; }
        public string MerkID { get; set; }
        public string MerkName { get; set; }
        public string ColorID { get; set; }
        public string ColorName { get; set; }

        public DateTime CreateTimestamp { get; set; }
        public DateTime UpdateTimestamp { get; set; }
    }
}
