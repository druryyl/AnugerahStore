using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Accounting.Model
{
    public class MutasiKasModel
    {
        public string MutasiKasID { get; set; }
        public string Tgl { get; set; }
        public string Jam { get; set; }
        public string PegawaiID { get; set; }
        public string PegawaiName { get; set; }
        public string JenisKasIDAsal { get; set; }
        public string JenisKasNameAsal { get; set; }
        public string JenisKasIDTujan { get; set; }
        public string JenisKasNameTujuan { get; set; }
        public string Keterangan { get; set; }
        public decimal NilaiKas { get; set; }
    }

    public class MutasiKasSearchModel
    {
        public string MutasiKasID { get; set; }
        public string Tgl { get; set; }
        public string Keterangan { get; set; }
        public decimal NilaiKas { get; set; }

        public static explicit operator MutasiKasSearchModel(MutasiKasModel model)
        {
            var result = new MutasiKasSearchModel
            {
                MutasiKasID = model.MutasiKasID,
                Tgl = model.Tgl,
                Keterangan = model.Keterangan,
                NilaiKas = model.NilaiKas
            };
            return result;
        }
    }
}
