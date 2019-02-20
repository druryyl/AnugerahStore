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

        public BPStokBL()
        {
            _bpStokDal = new BPStokDal();
            _bpStokDetilDal = new BPStokDetilDal();
        }

        public BPStokBL(IBPStokDal bpStokDal, IBPStokDetilDal bPStokDetilDal)
        {
            _bpStokDal = bpStokDal;
            _bpStokDetilDal = bPStokDetilDal;
        }

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

            // generate yang minus kemudian
            foreach (var item in adjustment.ListBrg.Where(x => x.QtyAdjust < 0))
            {
                var genResult = RemoveStok(item, adjustment);
                if (result == null) result = new List<BPStokModel>();
                foreach(var item2 in genResult)
                    result.Add(item2);
            }


            return result;
        }

        public IEnumerable<BPStokModel> Generate(PenjualanModel penjualan)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<BPStokModel> ListData(string brgID)
        {
            IEnumerable<BPStokModel> result = null;

            result = _bpStokDal.ListData(brgID);
            if(result != null)
            {
                foreach(var item in result)
                {
                    var listDetil = _bpStokDetilDal.ListData(item.BPStokID);
                    item.ListDetil = listDetil.ToList();
                }
            }
            return result;
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
                    NoUrut = 1,
                    ReffID = adj.StokAdjustmentID,
                    Tgl = adj.TglTrs,
                    Jam = adj.JamTrs,
                    QtyIn = itemAdj.QtyAdjust,
                    NilaiHpp = itemAdj.HppAdjust,
                    QtyOut = 0,
                    HargaJual = 0,
                }
            };
            result.ListDetil = listDetil;

            return result;
        }

        private IEnumerable<BPStokModel> RemoveStok(StokAdjustment2Model itemAdj, StokAdjustmentModel adj)
        {
            List<BPStokModel> result = null;

            //  null check
            if (itemAdj == null)
                throw new ArgumentNullException(nameof(itemAdj));
            if (adj == null)
                throw new ArgumentNullException(nameof(adj));

            //  list semua buku stok barang ini yang masih ada sisa stok
            var listBPStok = ListData(itemAdj.BrgID);
            if (listBPStok == null) return null;

            //  proses pengurangan stok, biar mudah di-pluskan dulu
            var qtyPengurang = itemAdj.QtyAdjust * -1;

            // proses pengurangan
            foreach(var item in listBPStok)
            {
                long qtyOut = 0;
                if (item.QtySisa >= qtyPengurang)
                    qtyOut = qtyPengurang;
                else
                    qtyOut = item.QtySisa;

                //  kurangi pengurangnya
                qtyPengurang -= qtyOut;

                var noUrut = item.ListDetil.Count() + 1;

                //  bikin detil baru
                var bpStokDetil = new BPStokDetilModel
                {
                    BPStokID = item.BPStokID,
                    BPStokDetilID = item.BPStokID + '-' + noUrut.ToString().PadLeft(3,'0'),
                    NoUrut = noUrut,
                    ReffID = adj.StokAdjustmentID,
                    Tgl = adj.TglTrs,
                    Jam = adj.JamTrs,
                    QtyIn = 0,
                    NilaiHpp = 0,
                    QtyOut = qtyOut,
                    HargaJual = item.NilaiHpp,
                };
                item.ListDetil.Add(bpStokDetil);
                item.QtySisa = item.QtyIn - item.ListDetil.Sum(x => x.QtyOut);

                //  add ke result
                if (result == null) result = new List<BPStokModel>();
                result.Add(item);

                //  update header
                _bpStokDal.Update(item);
                _bpStokDetilDal.Insert(bpStokDetil);

                if (qtyPengurang == 0) break;
            }

            //  jika masih belum selesai pengurangan stok-nya, 
            //  berarti stok ngga cukup. Throw error.
            if (qtyPengurang != 0)
            {
                var errMsg = string.Format("Stok tidak cukup : {0} - {1}", itemAdj.BrgID, itemAdj.BrgName);
                throw new ArgumentException(errMsg);
            }

            return result;
        }

    }
}
