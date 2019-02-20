﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.StokBarang.Model
{
    public class BPStokDetilModel
    {
        public string BPStokID { get; set; }
        public string BPStokDetilID { get; set; }
        public int NoUrut { get; set; }
        public string ReffID { get; set; }
        public string Tgl { get; set; }
        public string Jam { get; set; }
        public decimal QtyOut { get; set; }
        public decimal HargaJual { get; set; }
    }
}
