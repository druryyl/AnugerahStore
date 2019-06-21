using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.StokBarang.Model
{
    public class BPStokModel
    {
        public string BPStokID { get; set; }
        public string ReffID { get; set; }
        public string StokControl { get; set; }
        public string Tgl { get; set; }
        public string Jam { get; set; }
        public string BrgID { get; set; }
        public string BrgName { get; set; }
        public decimal NilaiHpp { get; set; }
        public decimal QtyIn { get; set; }
        public decimal QtySisa { get; set; }

        public List<BPStokDetilModel> ListDetil { get; set; }
    }

    public class BPStokSearchModel
    {
        public string BPStokID { get; set; }
        public string BrgName { get; set; }
        public decimal Qty { get; set; }

        public static explicit operator BPStokSearchModel(BPStokModel model)
        {
            var result = new BPStokSearchModel
            {
                BPStokID = model.BPStokID,
                BrgName = string.Format("{0} {1}",
                    model.BrgName, model.StokControl),
                Qty = model.QtySisa,
            };
            return result;
        }
    }

    public class BPStokBrgSearchModel
    {
        public string BrgID { get; set; }
        public string BrgName { get; set; }
        public decimal Qty { get; set; }
        public string BPStokID { get; set; }
    }
}
