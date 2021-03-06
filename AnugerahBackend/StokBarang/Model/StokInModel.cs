﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.StokBarang.Model
{
    public class StokInModel
    {
        public string StokInID { get; set; }
        public string BrgID { get; set; }
        public string BrgName { get; set; }
        public string TglMasuk { get; set; }
        public string JamMasuk { get; set; }
        public string TrsMasukID { get; set; }
        public decimal QtyIn { get; set; }
        public decimal QtySaldo { get; set; }
        public double Hpp { get; set; }
        
        public string StokControlID { get; set; }
        public string TrsDOID { get; set; }
    }

    public class StokSearchModel
    {
        public string BrgID { get; set; }
        public string BrgName { get; set; }
        public string BatchNo { get; set; }
        public decimal Qty { get; set; }
    }
}
