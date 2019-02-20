using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnugerahBackend.Penjualan.Model;
using AnugerahBackend.StokBarang.Dal;
using AnugerahBackend.StokBarang.Model;

namespace AnugerahBackend.StokBarang.BL
{
    public interface IBPStokBL
    {
        IEnumerable<BPStokModel> Generate(StokAdjustmentModel adjustment);
        IEnumerable<BPStokModel> Generate(PenjualanModel penjualan);

        //  --generate dari DO (belum dibuat)
        //IEnumerable<BPStokModel> Generate()
    }

    public class BPStokBL : IBPStokBL
    {
        private IBPStokDal _bpStokDal;
        private IBPStokDetilDal _bpStokDetilDal;

        public IEnumerable<BPStokModel> Generate(StokAdjustmentModel adjustment)
        {
            if (adjustment == null)
                throw new ArgumentNullException(nameof(adjustment));
            if(adjustment.ListBrg == null)
                throw new ArgumentNullException(nameof(adjustment.ListBrg));

            List<BPStokModel> result = null;
            // generate yang plus dulu
            foreach(var item in adjustment.ListBrg.Where(x => x.QtyAdjust > 0))
            {
                var genResult = AddStok(item, adjustment);
                if (result == null) result = new List<BPStokModel>();
                result.Add(genResult);
            }

            return result;
        }

        public IEnumerable<BPStokModel> Generate(PenjualanModel penjualan)
        {
            throw new NotImplementedException();
        }


        private BPStokModel AddStok(StokAdjustment2Model itemAdj, StokAdjustmentModel adj)
        {
            //  null check
            if (itemAdj== null)
                throw new ArgumentNullException(nameof(itemAdj));
            if (adj == null)
                throw new ArgumentNullException(nameof(adj));

            var result = new BPStokModel
            {
                BPStokID = adj.StokAdjustmentID + itemAdj.BrgID,
                ReffID = adj.StokAdjustmentID,
                Tgl = adj.TglTrs,
                Jam = adj.JamTrs,
                BrgID = itemAdj.BrgID,
                BrgName = itemAdj.BrgName,
                NilaiHpp = itemAdj.HppAdjust,
                QtyIn = itemAdj.QtyAdjust,
                QtySisa = itemAdj.QtyAdjust
            };

            var listDetil = new List<BPStokDetilModel>
            {
                new BPStokDetilModel
                {
                    BPStokID = result.BPStokID,
                    BPStokDetilID = result.BPStokID + "-001",
                    
                }
            };
            result.ListDetil = listDetil;

            return result;
        }
    }
}
