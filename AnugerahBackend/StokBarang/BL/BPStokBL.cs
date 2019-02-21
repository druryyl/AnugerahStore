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
                var stokItem = new StokItem
                {
                    ReffID = adjustment.StokAdjustmentID,
                    Tgl = adjustment.TglTrs,
                    Jam = adjustment.JamTrs,
                    BrgID = item.BrgID,
                    BrgName = item.BrgName,
                    QtyIn = item.QtyAdjust,
                    NilaiHpp = item.HppAdjust,
                    QtyOut = 0,
                    HargaJual = 0,
                };
                var genResult = AddStok(stokItem);
                if (result == null) result = new List<BPStokModel>();
                result.Add(genResult);
            }

            // generate yang minus kemudian
            foreach (var item in adjustment.ListBrg.Where(x => x.QtyAdjust < 0))
            {
                var stokItem = new StokItem
                {
                    ReffID = adjustment.StokAdjustmentID,
                    Tgl = adjustment.TglTrs,
                    Jam = adjustment.JamTrs,
                    BrgID = item.BrgID,
                    BrgName = item.BrgName,
                    QtyIn = 0,
                    NilaiHpp = 0,
                    QtyOut = item.QtyAdjust * -1,
                    HargaJual = 0,
                };
                var genResult = RemoveStok(stokItem);
                if (result == null) result = new List<BPStokModel>();
                foreach(var item2 in genResult)
                    result.Add(item2);
            }

            if(result != null)
            {
                //  delete data lama
                foreach(var item in result)
                {
                    _bpStokDal.Delete(item.BPStokID);
                    _bpStokDetilDal.Delete(item.BPStokID);
                }

                //  insert data baru
                foreach (var item in result)
                {
                    _bpStokDal.Insert(item);
                    foreach(var item2 in item.ListDetil)
                        _bpStokDetilDal.Insert(item2);
                }
            }

            return result;
        }

        public IEnumerable<BPStokModel> Generate(PenjualanModel penjualan)
        {
            if (penjualan == null)
                throw new ArgumentNullException(nameof(penjualan));
            if (penjualan.ListBrg == null)
                throw new ArgumentNullException(nameof(penjualan.ListBrg));

            List<BPStokModel> result = null;

            // generate minus
            foreach (var item in penjualan.ListBrg)
            {
                var stokItem = new StokItem
                {
                    ReffID = penjualan.PenjualanID,
                    Tgl = penjualan.TglPenjualan,
                    Jam = penjualan.JamPenjualan,
                    BrgID = item.BrgID,
                    BrgName = item.BrgName,
                    QtyIn = 0,
                    NilaiHpp = 0,
                    QtyOut = item.Qty,
                    HargaJual = item.Harga,
                };
                var genResult = RemoveStok(stokItem);
                if (result == null) result = new List<BPStokModel>();
                foreach (var item2 in genResult)
                    result.Add(item2);
            }

            if (result != null)
            {
                //  delete data lama
                foreach (var item in result)
                {
                    _bpStokDal.Delete(item.BPStokID);
                    _bpStokDetilDal.Delete(item.BPStokID);
                }

                //  insert data baru
                foreach (var item in result)
                {
                    _bpStokDal.Insert(item);
                    foreach (var item2 in item.ListDetil)
                        _bpStokDetilDal.Insert(item2);
                }
            }

            return result;
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



        private BPStokModel AddStok(StokItem stokItem)
        {
            //  null check
            if (stokItem== null)
                throw new ArgumentNullException(nameof(stokItem));

            var result = new BPStokModel
            {
                BPStokID = stokItem.ReffID + stokItem.BrgID,
                ReffID = stokItem.ReffID,
                Tgl = stokItem.Tgl,
                Jam = stokItem.Jam,
                BrgID = stokItem.BrgID,
                BrgName = stokItem.BrgName,
                QtyIn = stokItem.QtyIn,
                NilaiHpp = stokItem.NilaiHpp,
                QtySisa = stokItem.QtyOut,
            };

            var listDetil = new List<BPStokDetilModel>
            {
                new BPStokDetilModel
                {
                    BPStokID = result.BPStokID,
                    BPStokDetilID = result.BPStokID + "-001",
                    NoUrut = 1,
                    ReffID = stokItem.ReffID,
                    Tgl = stokItem.Tgl,
                    Jam = stokItem.Jam,
                    QtyIn = stokItem.QtyIn,
                    NilaiHpp = stokItem.NilaiHpp,
                    QtyOut = 0,
                    HargaJual = 0,
                }
            };
            result.ListDetil = listDetil;
            result.QtySisa = result.QtyIn - listDetil.Sum(x => x.QtyOut);

            return result;
        }

        private IEnumerable<BPStokModel> RemoveStok(StokItem stokItem)
        {
            List<BPStokModel> result = null;

            //  null check
            if (stokItem == null)
                throw new ArgumentNullException(nameof(stokItem));

            //  list semua buku stok barang ini yang masih ada sisa stok
            var listBPStok = ListData(stokItem.BrgID);
            if (listBPStok == null) return null;

            //  proses pengurangan stok, biar mudah di-pluskan dulu
            var qtyPengurang = stokItem.QtyOut;

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

                //  jika hargajual = 0,
                //  maka ambil harga beli-nya
                if (stokItem.HargaJual == 0)
                    stokItem.HargaJual = item.NilaiHpp;

                //  bikin detil baru
                var bpStokDetil = new BPStokDetilModel
                {
                    BPStokID = item.BPStokID,
                    BPStokDetilID = item.BPStokID + '-' + noUrut.ToString().PadLeft(3,'0'),
                    NoUrut = noUrut,
                    ReffID = stokItem.ReffID,
                    Tgl = stokItem.Tgl,
                    Jam = stokItem.Jam,
                    QtyIn = 0,
                    NilaiHpp = 0,
                    QtyOut = qtyOut,
                    HargaJual = stokItem.HargaJual,
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
                var errMsg = string.Format("Stok tidak cukup : {0} - {1}", stokItem.BrgID, stokItem.BrgName);
                throw new ArgumentException(errMsg);
            }

            return result;
        }

    }
}
