using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Keuangan.Model
{
    public class BukuKasModel
    {
        public string BukuKasID { get; set; }
        public string TglBuku { get; set; }
        public string JamBuku { get; set; }
        public string UserrID { get; set; }

        public decimal NilaiKas { get; set; }

        public string Keterangan { get; set; }

        public string ReffID { get; set; }
        public string JenisTrsKasirID { get; set; }
        public string JenisTrsKasirName { get; set; }


        public string PihakKetigaID { get; set; }
        public string PihakKetigaName { get; set; }

    }

    public class BukuKasSearchModel
    {
        public string BukuKasID { get; set; }
        public string TglBuku { get; set; }
        public string PihakKetigaName { get; set; }
        public string Nilai { get; set; }
        public string Keterangan { get; set; }

        public static explicit operator BukuKasSearchModel(BukuKasModel bukuKas)
        {
            return new BukuKasSearchModel
            {
                BukuKasID = bukuKas.BukuKasID,
                TglBuku = bukuKas.TglBuku,
                PihakKetigaName = bukuKas.PihakKetigaName,
                Nilai = bukuKas.NilaiKas.ToString("N0"),
                Keterangan = bukuKas.Keterangan
            };
        }

    }


}
