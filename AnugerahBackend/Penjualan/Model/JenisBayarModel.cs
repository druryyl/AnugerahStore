﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Penjualan.Model
{
    public class JenisBayarModel
    {
        public string JenisBayarID { get; set; }
        public string JenisBayarName { get; set; }
        public string JenisKasID { get; set; }
        public string JenisKasName { get; set; }
        public int NoUrut { get; set; }
        public string TipeKas { get; set; }
    }
}
