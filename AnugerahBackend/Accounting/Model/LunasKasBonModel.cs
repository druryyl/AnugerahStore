﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Accounting.Model
{
    public class LunasKasBonModel
    {
        public string LunasKasBonID { get; set; }
        public string Tgl { get; set; }
        public string Jam { get; set; }
        public string PihakKeduaID { get; set; }
        public string PihakKeduaName { get; set; }
        public string KasBonID { get; set; }
        public string NilaiTotLunas { get; set; }
    }
}