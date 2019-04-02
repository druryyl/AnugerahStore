using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahWinform.Accounting.View
{
    public interface IMutasiKasView
    {
        string MutasiKasID { get; set; }
        string Tgl { get; set; }
        string Jam { get; set; }
        string PegawaiID { get; set; }
        string PegawaiName { get; set; }
        string JenisKasIDAsal { get; set; }
        string JenisKasNameAsal { get; set; }
        string JenisKasIDTujuan { get; set; }
        string JenisKasNameTujuan { get; set; }
        decimal NilaiKas { get; set; }
        string Keterangan { get; set; }
    }
}
