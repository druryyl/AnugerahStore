﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Keuangan.Model
{
    public class BukuPiutangModel
    {
        public string BukuPiutangID { get; set; }
        public string TglBuku { get; set; }
        public string JamBuku { get; set; }
        public string UserrID { get; set; }
        public string PihakKetigaID { get; set; }
        public string PihakKetigaName { get; set; }

        public decimal NilaiPiutang { get; set; }
        public decimal NilaiSisa { get; set; }

        public string Keterangan { get; set; }
        public string BukuKasID { get; set; }
    }
}
