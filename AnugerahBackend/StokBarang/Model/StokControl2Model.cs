﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.StokBarang.Model
{
    public class StokControl2Model
    {
        public string StokControl2ID { get; set; }
        public string StokControlID { get; set; }
        public string TglTrs { get; set; }
        public string JamTrs { get; set; }
        public string ReffTrsID { get; set; }
        public string JenisMutasiID { get; set; }
        public long QtyIn { get; set; }
        public long QtyOut { get; set; }
        public double NilaiIn { get; set; }
        public double NilaiOut { get; set; }

    }
}