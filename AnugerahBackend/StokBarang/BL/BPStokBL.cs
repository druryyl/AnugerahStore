using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnugerahBackend.Pembelian.Dal;
using AnugerahBackend.Pembelian.Model;
using AnugerahBackend.Penjualan.BL;
using AnugerahBackend.Penjualan.Dal;
using AnugerahBackend.Penjualan.Model;
using AnugerahBackend.StokBarang.Dal;
using AnugerahBackend.StokBarang.Model;
using AnugerahBackend.Support;
using Ics.Helper.Extensions;
using Ics.Helper.StringDateTime;

namespace AnugerahBackend.StokBarang.BL
{
    public interface IBPStokBL : ISearch<BPStokSearchModel>
    {
        IEnumerable<BPStokModel> Generate(StokAdjustmentModel adjustment);
        IEnumerable<BPStokModel> Generate(PenjualanModel penjualan);
        IEnumerable<BPStokModel> Generate(ReceiptModel receipt);
        IEnumerable<BPStokModel> Generate(RepackModel repack);
        BPStokModel GetData(string BPStokID);
        IEnumerable<BPStokModel> ListData();
        decimal GetStok(string kodeBrg);
        IEnumerable<BPStokDetilView> ListDetil(string brgID, string tgl1, string tgl2);
        decimal GetStokAwal(string brgID, string tgl1);
    }

    public class ProsesRegenStokEventArgs : EventArgs
    {
        public string Tgl { get; set; }
        public string TrsID { get; set; }
        public Int32 Counter { get; set; }
    }

    public class StartProsesStokEventArgs : EventArgs
    {
        public string ProsesName { get; set; }
        public Int32 DataCount { get; set; }
    }

    public class BPStokBL : IBPStokBL
    {
        public event ProsesRegenStokEventHandler ProsesRegenStok;
        public event StartProsesStokEventHandler StartProses;

        protected virtual void OnProsesRegenStok(ProsesRegenStokEventArgs e)
        {
            ProsesRegenStokEventHandler handler = ProsesRegenStok;
            handler?.Invoke(this, e);
        }

        protected virtual void OnStartProses(StartProsesStokEventArgs e)
        {
            StartProsesStokEventHandler handler = StartProses;
            handler?.Invoke(this, e);
        }

        public delegate void ProsesRegenStokEventHandler(object sender, ProsesRegenStokEventArgs e);
        public delegate void StartProsesStokEventHandler(object sender, StartProsesStokEventArgs e);


        private IBPStokDal _bpStokDal;
        private IBPStokDetilDal _bpStokDetilDal;
        private IBrgStokHargaBL _brgStokHargaBL;
        private IBrgDal _brgDal;
        private IPenjualanBL _penjualanBL;

        private IStokAdjustment2Dal _stokAdj2Dal;
        private IStokAdjustmentDal _stokAdjDal;

        private IPenjualan2Dal _penjualan2Dal;
        private IPenjualanDal _penjualanDal;

        private IReceiptDal _receiptDal;
        private IReceiptDetilDal _receiptDetilDal;

        public BPStokBL()
        {
            _bpStokDal = new BPStokDal();
            _bpStokDetilDal = new BPStokDetilDal();
            _brgStokHargaBL = new BrgStokHargaBL();
            _brgDal = new BrgDal();
            _penjualanBL = new PenjualanBL();
            _stokAdj2Dal = new StokAdjustment2Dal();
            _penjualan2Dal = new Penjualan2Dal();
            _receiptDetilDal = new ReceiptDetilDal();

            _penjualanDal = new PenjualanDal();
            _stokAdjDal = new StokAdjustmentDal();
            _receiptDal = new ReceiptDal();

            SearchFilter = new SearchFilter
            {
                IsDate = false
            };
        }

        public BPStokBL(IBPStokDal bpStokDal, IBPStokDetilDal bPStokDetilDal,
                        IBrgStokHargaBL brgStokHargaBL)
        {
            _bpStokDal = bpStokDal;
            _bpStokDetilDal = bPStokDetilDal;
            _brgStokHargaBL = brgStokHargaBL;
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
                    BPStokID = "",
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
                    BPStokID = "",
                };
                var genResult = RemoveStok(stokItem);
                if (result == null) result = new List<BPStokModel>();
                foreach(var item2 in genResult)
                    result.Add(item2);
            }

            //  update stok info
            foreach (var item in adjustment.ListBrg)
                _brgStokHargaBL.UpdateStok(item.BrgID);

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
                    BPStokID = item.BPStokID,
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

            //  update stok info
            foreach (var item in penjualan.ListBrg)
                _brgStokHargaBL.UpdateStok(item.BrgID);

            return result;
        }

        public IEnumerable<BPStokModel> Generate(ReceiptModel receipt)
        {
            if (receipt == null)
                throw new ArgumentNullException(nameof(receipt));
            if (receipt.ListBrg == null)
                throw new ArgumentNullException(nameof(receipt.ListBrg));

            List<BPStokModel> result = null;

            // generate yang plus dulu
            foreach (var item in receipt.ListBrg.Where(x => x.Qty > 0))
            {
                var stokItem = new StokItem
                {
                    ReffID = receipt.ReceiptID,
                    Tgl = receipt.Tgl,
                    Jam = receipt.Jam,
                    BrgID = item.BrgID,
                    BrgName = item.BrgName,
                    QtyIn = item.Qty,
                    NilaiHpp = item.Harga - item.Diskon - item.TaxRupiah,
                    QtyOut = 0,
                    HargaJual = 0,
                    BPStokID = "",
                };
                var genResult = AddStok(stokItem);
                if (result == null) result = new List<BPStokModel>();
                result.Add(genResult);
            }

            //  update stok info
            foreach (var item in receipt.ListBrg)
                _brgStokHargaBL.UpdateStok(item.BrgID);
            return result;
        }

        public IEnumerable<BPStokModel> Generate(RepackModel repack)
        {
            List<BPStokModel> result = null;
            if (repack == null)
                throw new ArgumentNullException(nameof(repack));

            //  ambil data data material untuk dikurangi stok-nya
            var stokMaterial = new StokItem
            {
                ReffID = repack.RepackID,
                Tgl = repack.Tgl,
                Jam = repack.Jam,
                BrgID = repack.BrgIDMaterial,
                BrgName = repack.BrgNameMaterial,
                QtyIn = 0,
                NilaiHpp = 0,
                QtyOut = repack.QtyMaterial,
                HargaJual = 0,
                BPStokID = repack.BPStokID,
            };
            var bpStokMaterial = RemoveStok(stokMaterial);

            //  insert data hasil untuk ditambahkan stoknya
            var stokHasil = new StokItem
            {
                ReffID = repack.RepackID,
                Tgl = repack.Tgl,
                Jam = repack.Jam,
                BrgID = repack.BrgIDHasil,
                BrgName = repack.BrgNameHasil,
                QtyIn = repack.QtyHasil,
                NilaiHpp = repack.HppHasil,
                QtyOut = 0,
                HargaJual = 0,
                BPStokID = repack.SlotControl,
            };
            var bpStokHasil = AddStok(stokHasil);

            //  update stok info
            _brgStokHargaBL.UpdateStok(repack.BrgIDMaterial);
            _brgStokHargaBL.UpdateStok(repack.BrgIDHasil);

            return result;
        }


        public void Generate(string brgID)
        {

            //  listing brg
            //  from adjustment plus
            var listStok = new List<StokItem>();
            var listAdj = _stokAdj2Dal.ListDataBrg(brgID);
            if(listAdj != null)
            {
                Int32 i2 = 0;
                var e1 = new StartProsesStokEventArgs
                {
                    ProsesName = "List Data Adjustment",
                    DataCount = listAdj.Count()
                };
                OnStartProses(e1);

                foreach(var item in listAdj)
                {
                    i2++;
                    var header = _stokAdjDal.GetData(item.StokAdjustmentID);
                    if (header is null) continue;

                    var e = new ProsesRegenStokEventArgs
                    {
                        Counter = i2,
                        Tgl = header.TglTrs,
                        TrsID = header.StokAdjustmentID
                    };
                    OnProsesRegenStok(e);
                    StokItem stok;
                    if (item.QtyAdjust > 0)
                        stok = new StokItem
                        {
                            ReffID = item.StokAdjustmentID,
                            Tgl = header.TglTrs,
                            Jam = header.JamTrs,
                            BrgID = item.BrgID,
                            BrgName = item.BrgName,
                            QtyIn = item.QtyAdjust,
                            NilaiHpp = item.HppAdjust,
                            QtyOut = 0,
                            HargaJual = 0,
                            BPStokID = ""
                        };
                    else
                        stok = new StokItem
                        {
                            ReffID = item.StokAdjustmentID,
                            Tgl = header.TglTrs,
                            Jam = header.JamTrs,
                            BrgID = item.BrgID,
                            BrgName = item.BrgName,
                            QtyIn = 0,
                            NilaiHpp = 0,
                            QtyOut = item.QtyAdjust * -1,
                            HargaJual = 0,
                            BPStokID = "",
                        };
                    listStok.Add(stok);
                }
            }

            var listJual = _penjualan2Dal.ListDataBrg(brgID);
            if (listJual != null)
            {
                Int32 i2 = 0;
                var e1 = new StartProsesStokEventArgs
                {
                    ProsesName = "List Data Penjualan",
                    DataCount = listJual.Count()
                };
                OnStartProses(e1);
                foreach (var item in listJual)
                {
                    i2++;
                    var header = _penjualanDal.GetData(item.PenjualanID);
                    if (header is null) continue;
                    var e = new ProsesRegenStokEventArgs
                    {
                        Counter = i2,
                        Tgl = header.TglPenjualan,
                        TrsID = header.PenjualanID
                    };
                    OnProsesRegenStok(e);
                    var stok = new StokItem 
                    { 
                        ReffID = header.PenjualanID,
                        Tgl = header.TglPenjualan,
                        Jam = header.JamPenjualan,
                        BrgID = item.BrgID,
                        BPStokID = item.BPStokID,
                        BrgName = item.BrgName,
                        QtyIn = 0,
                        NilaiHpp = 0,
                        QtyOut = item.Qty,
                        HargaJual = item.Harga,
                    };
                    listStok.Add(stok);
                }
            }

            var listReceipt = _receiptDetilDal.ListData(brgID);
            if (listReceipt != null)
            {
                Int32 i2 = 0;
                var e1 = new StartProsesStokEventArgs
                {
                    ProsesName = "List Data PenReceiptjualan",
                    DataCount = listReceipt.Count()
                };
                OnStartProses(e1);
                foreach (var item in listReceipt)
                {
                    i2++;
                    var header = _receiptDal.GetData(item.ReceiptID);
                    if (header is null) continue;
                    var e = new ProsesRegenStokEventArgs
                    {
                        Counter = i2,
                        Tgl = header.Tgl,
                        TrsID = header.ReceiptID
                    };
                    OnProsesRegenStok(e);
                    var stok = new StokItem
                    {
                        ReffID = header.ReceiptID,
                        Tgl = header.Tgl,
                        Jam = header.Jam,
                        BrgID = item.BrgID,
                        BrgName = item.BrgName,
                        QtyIn = item.Qty,
                        NilaiHpp = item.Harga - item.Diskon - item.TaxRupiah,
                        QtyOut = 0,
                        HargaJual = 0,
                        BPStokID = "",
                    };
                    listStok.Add(stok);
                }
            }

            Int32 i3 = 0;
            var e3 = new StartProsesStokEventArgs
            {
                ProsesName = "Re-generate stok",
                DataCount = listStok.Count()
            };
            OnStartProses(e3);
            var listProsesAdd = listStok.Where(x => x.QtyIn > 0);
            foreach (var item in listProsesAdd.OrderBy(x => x.Tgl + x.Jam))
            {
                i3++;
                var e = new ProsesRegenStokEventArgs
                {
                    Counter = i3,
                    Tgl = item.Tgl,
                    TrsID = item.ReffID
                };
                OnProsesRegenStok(e);
                _ = AddStok(item);
            }

            var listProsesRemove = listStok.Where(x => x.QtyOut > 0);
            foreach (var item in listProsesRemove.OrderBy(x => x.Tgl + x.Jam))
            {
                i3++;
                var e = new ProsesRegenStokEventArgs
                {
                    Counter = i3,
                    Tgl = item.Tgl,
                    TrsID = item.ReffID
                };
                OnProsesRegenStok(e);
                _ = RemoveStok(item);
            }

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
                StokControl = stokItem.BPStokID,
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

            //  hapus data lama
            _bpStokDetilDal.Delete(result.BPStokID);
            _bpStokDal.Delete(result.BPStokID);

            //  insert data baru
            _bpStokDal.Insert(result);
            foreach (var item in listDetil)
                _bpStokDetilDal.Insert(item);

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
            //  jika pengurangan stok untuk kasus tertentu
            //  (sudah ditetepkan stok mana yg dikurangi)
            if (stokItem.BPStokID.Trim() != "")
            {
                listBPStok = listBPStok.Where(x => x.BPStokID == stokItem.BPStokID);
            }

            //  hapus detil utk 'trs ini' dulu
            //  (kasus simpan ulang)
            foreach(var item in listBPStok)
            {
                item.ListDetil = item.ListDetil.Where(x => x.ReffID != stokItem.ReffID).ToList();
            }

            //  proses pengurangan stok, biar mudah di-pluskan dulu
            var qtyPengurang = stokItem.QtyOut;

            // proses pengurangan
            foreach(var item in listBPStok)
            {
                decimal qtyOut = 0;
                if (item.QtySisa >= qtyPengurang)
                    qtyOut = qtyPengurang;
                else
                    qtyOut = item.QtySisa;

                //  kurangi pengurangnya
                qtyPengurang -= qtyOut;

                // var noUrut = item.ListDetil.Count() + 1;

                //  jika hargajual = 0,
                //  maka ambil harga beli-nya
                if (stokItem.HargaJual == 0)
                    stokItem.HargaJual = item.NilaiHpp;

                //  bikin detil baru
                var bpStokDetil = new BPStokDetilModel
                {
                    BPStokID = item.BPStokID,
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

                //  generate ulang nomor urut-nya
                int noUrut = 1;
                foreach (var item2 in item.ListDetil.OrderBy(x => x.Tgl + x.Jam))
                {
                    item2.NoUrut = noUrut;
                    item2.BPStokDetilID = item.BPStokID + '-' + noUrut.ToString().PadLeft(3, '0');
                    noUrut++;
                }

                //  update header
                _bpStokDal.Update(item);
                //  delete detil
                _bpStokDetilDal.Delete(item.BPStokID);
                //  insert baru
                foreach(var item2 in item.ListDetil)
                    _bpStokDetilDal.Insert(item2);

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

        public BPStokModel GetData(string bpStokID)
        {
            return _bpStokDal.GetData(bpStokID);
        }

        public IEnumerable<BPStokModel> ListData()
        {
            return _bpStokDal.ListData();
        }

        public IEnumerable<BPStokDetilView> ListDetil(string brgID, string tgl1, string tgl2)
        {
            var stokTgl2 = GetStokAkhir(brgID, tgl2);
            var listBpStokDetil = _bpStokDetilDal.ListData(brgID, tgl1, tgl2);

            if((stokTgl2 <=0) && (listBpStokDetil==null))
                return null;

            var brg = _brgDal.GetData(brgID);
            string brgName = "";
            if (brg != null)
                brgName = brg.BrgName;

            var result = new List<BPStokDetilView>();

            //  ambil stok awal;
            decimal stokAwal = GetStokAwal(brgID, tgl1);
            decimal sumQtyIn = stokAwal;
            decimal sumQtyOut = 0;
            decimal saldoQty = stokAwal;
            int noUrut = 0;
            result.Add(new BPStokDetilView
            {
                BrgID = brgID,
                BrgName = brgName,
                BPStokID = "STOK-AWAL",
                BPStokDetilID = "STOK-AWAL-0",
                Tgl = tgl1,
                Jam = "00:00:00",
                NoUrut = noUrut,
                JenisMutasi = "",
                QtyIn = stokAwal,
                QtyOut = 0,
                NilaiHpp = 0,
                ReffID = "STOK-AWAL",
                SaldoQty = stokAwal,
                HargaJual = 0
            });
            if(listBpStokDetil != null)
                foreach(var item in listBpStokDetil.OrderBy(x => x.Tgl.ToTglYMD() + x.Jam))
                {
                    noUrut++;
                    sumQtyIn += item.QtyIn;
                    sumQtyOut += item.QtyOut;
                    saldoQty += (item.QtyIn - item.QtyOut);
                    var jenisTrs = "";
                    var item2 = new BPStokDetilView(item);
                    switch (item2.ReffID.Substring(0,2))
                    {
                        case "JL":
                            var jual = _penjualanBL.GetData(item.ReffID);
                            if (jual != null)
                                jenisTrs = string.Format("Jual - {0}", jual.BuyerName);
                            else
                                jenisTrs = "Jual";
                            break;
                        case "AJ":
                            jenisTrs = "Adjust";
                            break;
                        default:
                            break;
                    }
                    item2.JenisMutasi = jenisTrs;
                    item2.BrgID = "";
                    item2.BrgName = "";
                    item2.NoUrut = noUrut;
                    item2.SaldoQty = saldoQty;
                    result.Add(item2);
                }

            noUrut++;
            var itemSummary = new BPStokDetilView
            {
                BrgID = "",
                BrgName = "",
                BPStokID = "",
                BPStokDetilID = "",
                Tgl = "",
                Jam = "",
                NoUrut = noUrut,
                JenisMutasi = "BALANCE",
                QtyIn = sumQtyIn,
                QtyOut = sumQtyOut,
                NilaiHpp = 0,
                ReffID = "",
                SaldoQty = saldoQty,
                HargaJual = 0
            };
            result.Add(itemSummary);

            return result;
        }

        public decimal GetStokAwal(string brgID, string tgl1)
        {
            DateTime dtTgl1 = tgl1.ToDate();
            DateTime dtTgl0 = dtTgl1.AddDays(-1);
            var tgl0 = dtTgl0.ToString("dd-MM-yyyy");
            var listBPStok = _bpStokDetilDal.ListData(brgID, "01-01-1900", tgl0);
            if (listBPStok == null)
                return 0;
            else
                return listBPStok.Sum(x => x.QtyIn - x.QtyOut);
        }

        public decimal GetStokAkhir(string brgID, string tgl1)
        {
            DateTime dtTgl0 = tgl1.ToDate();
            var tgl0 = dtTgl0.ToString("dd-MM-yyyy");
            var listBPStok = _bpStokDetilDal.ListData(brgID, "01-01-1900", tgl0);
            if (listBPStok == null)
                return 0;
            else
                return listBPStok.Sum(x => x.QtyIn - x.QtyOut);
        }

        public SearchFilter SearchFilter { get; set; }

        public IEnumerable<BPStokSearchModel> Search()
        {
            var listData = _bpStokDal.ListData();
            if (listData == null) return null;

            if (SearchFilter.StaticKeyword != null)
            {
                listData =
                    from c in listData
                    where c.BrgID == SearchFilter.StaticKeyword
                    where c.StokControl.Trim() != ""
                    select c;
            }


            var result = listData.Select(x => (BPStokSearchModel)x);
            if (SearchFilter.UserKeyword != null)
                return
                    from c in result
                    where c.BrgName.ContainMultiWord(SearchFilter.UserKeyword)
                    select c;

            return result;
        }

        public decimal GetStok(string kodeBrg)
        {
            decimal result = 0;
            var listBPStok = _bpStokDal.ListData(kodeBrg);
            if (listBPStok == null)
                return 0;

            result = listBPStok.Sum(x => x.QtySisa);

            return result;
        }
    }
}
