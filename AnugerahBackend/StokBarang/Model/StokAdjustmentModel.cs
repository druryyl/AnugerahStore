using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.StokBarang.Model
{
    public class StokAdjustmentModel
    {
        public string StokAdjustmentID { get; set; }
        public string TglTrs { get; set; }
        public string JamTrs { get; set; }
        public string UserrID { get; set; }
        public string TglVoid { get; set; }
        public string JamVoid { get; set; }
        public string UserrIDVoid { get; set; }
        public string Keterangan { get; set; }

        public IEnumerable<StokAdjustment2Model> ListBrg { get; set; }
    }

    public class StokAdjustmentSearchModel
    {
        public string StokAdjustmentID { get; set; }
        public string TglTrs { get; set; }
        public string JamTrs { get; set; }
        public string Keterangan { get; set; }
        public static explicit operator StokAdjustmentSearchModel(StokAdjustmentModel model)
        {
            return new StokAdjustmentSearchModel
            {
                StokAdjustmentID = model.StokAdjustmentID,
                TglTrs = model.TglTrs,
                JamTrs = model.JamTrs,
                Keterangan = model.Keterangan
            };
        }
    }
}
