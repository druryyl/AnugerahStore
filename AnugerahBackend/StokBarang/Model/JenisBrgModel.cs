﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.StokBarang.Model
{

    public class JenisBrgModel
    {
        public string JenisBrgID { get; set; }
        public string JenisBrgName { get; set; }
        public IEnumerable<JenisBrg2TipeModel> ListTipe { get; set; }
    }
}
