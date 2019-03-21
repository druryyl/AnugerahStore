﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahWinform.StokBarang.View
{
    public interface IRepackView
    {
        string RepackID { get; set; }
        string Tgl { get; set; }
        string Jam { get; set; }
        
        string BrgIDMaterial { get; set; }
        string BrgNameMaterial { get; set; }
        long QtyMaterial { get; set; }
        decimal HppMaterial { get; set; }

        string BrgIDHasil { get; set; }
        string BrgNameHasil { get; set; }
        long QtyHasil { get; set; }
        decimal HppHasil { get; set; }
    }
}
