using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.StokBarang.Model
{
    public class RepackModel
    {
        public string RepackID { get; set; }
        public string Tgl { get; set; }
        public string Jam { get; set; }

        public string BPStokID { get; set; }
        public string BrgIDMaterial { get; set; }
        public string BrgNameMaterial { get; set; }
        public long QtyMaterial { get; set; }
        public decimal HppMaterial { get; set; }

        public string BrgIDHasil { get; set; }
        public string BrgNameHasil { get; set; }
        public string SlotControl { get; set; }
        public long QtyHasil { get; set; }
        public decimal HppHasil { get; set; }
    }

    public class RepackSearchModel
    {
        public string RepackID { get; set; }
        public string Tgl { get; set; }
        public string BrgNameHasil { get; set; }

        public static explicit operator RepackSearchModel(RepackModel model)
        {
            var result = new RepackSearchModel
            {
                RepackID = model.RepackID,
                Tgl = model.Tgl,
                BrgNameHasil = model.BrgNameHasil
            };
            return result;
        }
    }
}
