using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.StokBarang.Model
{
    public class ProduksiModel
    {
        public string ProduksiID { get; set; }
        public string Tgl { get; set; }
        public string Jam { get; set; }
        public string Keterangan { get; set; }

        public IEnumerable<ProduksiMaterialModel> ListMaterial { get; set; }
        public IEnumerable<ProduksiHasilModel> ListHasil { get; set; }
    }

    public class ProduksiSearchModel
    {
        public string ProduksiID { get; set; }
        public string Tgl { get; set; }
        public string Keterangan { get; set; }

        public static explicit operator ProduksiSearchModel(ProduksiModel model)
        {
            var result = new ProduksiSearchModel
            {
                ProduksiID = model.ProduksiID,
                Tgl = model.Tgl,
                Keterangan = model.Keterangan
            };
            return result;
        }
    }
}
