using AnugerahBackend.StokBarang.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahWinform.StokBarang.View
{
    public interface IProduksiView
    {
        string ProduksiID { get; set; }
        string Tgl { get; set; }
        string Jam { get; set; }
        string Keterangan { get; set; }

        List<ProduksiMaterialModel> ListMaterial { get; set; }
        List<ProduksiHasilModel> ListHasil { get; set; }
    }
}
