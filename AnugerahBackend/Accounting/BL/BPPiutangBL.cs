using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnugerahBackend.Accounting.Dal;
using AnugerahBackend.Accounting.Model;
using AnugerahBackend.Penjualan.Dal;
using AnugerahBackend.Penjualan.Model;
using AnugerahBackend.Support;
using Ics.Helper.Database;
using Ics.Helper.Extensions;

namespace AnugerahBackend.Accounting.BL
{
    public interface IBPPiutangBL : ISearch<BPPiutangSearchModel>
    {
        BPPiutangModel GenPiutang(KasBonModel kasBon);
        BPPiutangModel GenPiutang(PenjualanModel penjualan);
        void GenPiutangDelete(KasBonModel kasBon);
        BPPiutangModel GenPiutang(LunasKasBonModel lunasKasBon, KasBonModel kasBon);
        BPPiutangModel GetData(string piutangID);
        IEnumerable<BPPiutangModel>ListByCustomer(string customerID);
        void GenLunasPiutang(LunasPiutangModel lunasPiutang);
        void GenLunasPiutangCancel(LunasPiutangModel lunasPiutang);
        //void GenLunas()
    }


    public class BPPiutangBL : IBPPiutangBL
    {
        private ILunasKasBonDal _lunasKasBonDal;
        private IPihakKeduaBL _pihakKeduaBL;
        private IBPPiutangDal _bpPiutangDal;
        private IBPPiutangDetilDal _bpPiutangDetilDal;
        private IJenisBayarDal _jenisBayarDal;

        public BPPiutangBL()
        {
            _lunasKasBonDal = new LunasKasBonDal();
            _pihakKeduaBL = new PihakKeduaBL();
            _bpPiutangDal = new BPPiutangDal();
            _bpPiutangDetilDal = new BPPiutangDetilDal();
            _jenisBayarDal = new JenisBayarDal();
            SearchFilter = new SearchFilter
            {
                IsDate = false,
            };
        }

        public BPPiutangBL(IBPPiutangDal bpPiutangDal)
        {
            _bpPiutangDal = bpPiutangDal;
        }

        public BPPiutangModel GetData(string piutangID)
        {
            var header = _bpPiutangDal.GetData(piutangID);
            if (header == null)
                return null;
            var detil = _bpPiutangDetilDal.ListData(piutangID);
            header.ListLunas = detil;
            return header;
        }

        public BPPiutangModel GenPiutang(KasBonModel kasBon)
        {
            if (kasBon == null)
            {
                throw new ArgumentNullException(nameof(kasBon));
            }
            var bpPiutang = (BPPiutangModel)kasBon;
            var result = Save(bpPiutang);
            return result;
        }

        public void GenLunasPiutang(LunasPiutangModel lunasPiutang)
        {
            using (var trans = TransHelper.NewScope())
            {
                foreach (var item in lunasPiutang.ListPiutangBayar)
                {
                    if (item.NilaiBayar == 0)
                        continue;

                    var bpPiutang = this.GetData(item.PiutangID);
                    var pelunasanBaru = new BPPiutangDetilModel
                    {
                        ReffID = item.LunasPiutangID,
                        Tgl = lunasPiutang.Tgl,
                        Jam = lunasPiutang.Jam,
                        Keterangan = "Pelunasan Piutang",
                        NilaiPiutang = 0,
                        NilaiLunas = item.NilaiBayar
                    };
                    var newListLunas = new List<BPPiutangDetilModel>();
                    newListLunas.AddRange(bpPiutang.ListLunas);
                    newListLunas.Add(pelunasanBaru);
                    var noUrut = 1;
                    foreach(var item2 in newListLunas)
                    {
                        item2.BPPiutangID = item.PiutangID;
                        item2.BPPiutangDetilID = string.Format("{0}-{1}",
                            item.PiutangID, noUrut.ToString().PadLeft(2, '0'));
                        noUrut++;
                    }
                    bpPiutang.ListLunas = newListLunas;
                    this.Save(bpPiutang);
                }
                trans.Complete();
            }
        }

        public void GenLunasPiutangCancel(LunasPiutangModel lunasPiutang)
        {
            using (var trans = TransHelper.NewScope())
            {
                foreach (var item in lunasPiutang.ListPiutangBayar)
                {
                    //  ambil data bpPiutang
                    var bpPiutang = this.GetData(item.PiutangID);
                    if (bpPiutang.ListLunas == null)
                        continue;
                    //  ubah ienumerable => list (biar bisa di-remove)
                    var listLunas = new List<BPPiutangDetilModel>();
                    listLunas.AddRange(bpPiutang.ListLunas);
                    //  cari item pelunasannya
                    var pelunasan = listLunas.Find(x => x.ReffID == lunasPiutang.LunasPiutangID);
                    //  escape point
                    if (pelunasan == null)
                        continue;
                    //  remove
                    listLunas.Remove(pelunasan);
                    bpPiutang.ListLunas = listLunas;
                    //  proses
                    this.Save(bpPiutang);
                }
                trans.Complete();
            }
        }


        public void GenPiutangDelete(KasBonModel kasBon)
        {
            if (kasBon == null)
            {
                throw new ArgumentNullException(nameof(kasBon));
            }

            //  jika sudah ada pelunasan, tidak bisa di hapus
            var bpPiutang = GetData(kasBon.KasBonID);
            if (bpPiutang == null)
                throw new ArgumentException("KasBon invalid");

            if (bpPiutang.NilaiLunas > 0)
                throw new ArgumentException("KasBon sudah ada pelunasan, tidak dapat di hapus");

            _bpPiutangDetilDal.Delete(kasBon.KasBonID);
            _bpPiutangDal.Delete(kasBon.KasBonID);
        }

        public BPPiutangModel GenPiutang(LunasKasBonModel lunasKasBon, KasBonModel kasBon)
        {
            //  ambil data piutang berdasarkan kasBon
            var bpPiutang = GetData(kasBon.KasBonID);
            if(bpPiutang == null)
            {
                var errMsg = string.Format("Piutang {0} tidak ditemukan ", kasBon.KasBonID);
                throw new ArgumentException(errMsg);
            }

            //  hapus detil lunas yang id-nya = lunasKasBonID
            List<BPPiutangDetilModel> newListLunas = 
                (
                    from c in bpPiutang.ListLunas
                    where c.ReffID != lunasKasBon.LunasKasBonID
                    select c
                ).ToList();

            //  tambahkan pelunasan dari lunasKasBon
            int noUrut = newListLunas.Count + 1;
            foreach(var item in lunasKasBon.ListLunas)
            {
                newListLunas.Add(new BPPiutangDetilModel
                {
                    BPPiutangID = bpPiutang.BPPiutangID,
                    BPPiutangDetilID = bpPiutang.BPPiutangID + '-' + noUrut.ToString().PadLeft(2, '0'),
                    Tgl = lunasKasBon.Tgl,
                    Jam = lunasKasBon.Jam,
                    ReffID = item.LunasKasBonID,
                    Keterangan = "   Pelunasan " + item.Keterangan,
                    NilaiPiutang = 0,
                    NilaiLunas = item.NilaiLunas
                });
                noUrut++;
            }

            bpPiutang.ListLunas = newListLunas;
            //  simpan
            var result = Save(bpPiutang);
            return result;
        }

        private bool IsJualPiutang(PenjualanModel penjualan)
        {
            const string TipeKasPiutang = "PT";
            var isPiutang = false;
            foreach (var item in penjualan.ListBayar)
            {
                var jenisBayar = _jenisBayarDal.GetData(item.JenisBayarID);
                if (jenisBayar.TipeKas == TipeKasPiutang)
                {
                    isPiutang = true;
                    break;
                }
            }
            return isPiutang;
        }

        private decimal GetNilaiPiutangJual(PenjualanModel penjualan)
        {
            const string TipeKasPiutang = "PT";
            decimal result = 0;
            foreach (var item in penjualan.ListBayar)
            {
                var jenisBayar = _jenisBayarDal.GetData(item.JenisBayarID);
                if (jenisBayar.TipeKas == TipeKasPiutang)
                    result += item.NilaiBayar;
            }
            return result;
        }


        public BPPiutangModel GenPiutang(PenjualanModel penjualan)
        {
            if (penjualan == null)
            {
                throw new ArgumentNullException(nameof(penjualan));
            }

            if (!IsJualPiutang(penjualan)) return null;

            var nilaiPiutang = GetNilaiPiutangJual(penjualan);
            //  header piutang
            var bpPiutang = new BPPiutangModel
            {
                BPPiutangID = penjualan.PenjualanID,
                Tgl = penjualan.TglPenjualan,
                Jam = penjualan.JamPenjualan,
                Keterangan = "Penjualan",
                PihakKeduaID = penjualan.CustomerID,
                PihakKeduaName = penjualan.CustomerName,
                NilaiPiutang = nilaiPiutang,
                NilaiLunas = 0
            };

            //  detil piutang
            var resultDetil = new BPPiutangDetilModel
            {
                BPPiutangID = penjualan.PenjualanID,
                BPPiutangDetilID = penjualan.PenjualanID + '-' + "01",
                Tgl = penjualan.TglPenjualan,
                Jam = penjualan.JamPenjualan,
                Keterangan = "Piutang Jual",
                ReffID = penjualan.PenjualanID,
                NilaiPiutang = nilaiPiutang,
                NilaiLunas = 0
            };
            var listDetil = new List<BPPiutangDetilModel>
            {
                resultDetil
            };
            bpPiutang.ListLunas = listDetil;

            var result = Save(bpPiutang);
            return result;
        }

        private BPPiutangModel Save(BPPiutangModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            //  validate pihak kedua;
            var pihakKedua = _pihakKeduaBL.GetData(model.PihakKeduaID);
            if (pihakKedua == null)
                throw new ArgumentException("PihakKeduaID invalid");
            else
                model.PihakKeduaName = pihakKedua.PihakKeduaName;

            //  kasus simpan ulang; pastikan belum ada pelunasan
            var bpPiutang = GetData(model.BPPiutangID);
            if(bpPiutang != null)
            {
                //if (bpPiutang.NilaiLunas > 0)
                    //throw new ArgumentException("Piutang sudah ada pelunasan, tidak bisa simpan ulang");
            }

            //  update nilai total di header
            model.NilaiPiutang = model.ListLunas.Sum(x => x.NilaiPiutang);
            model.NilaiLunas = model.ListLunas.Sum(x => x.NilaiLunas);

            //  delete data lama
            using (var trans = TransHelper.NewScope())
            {
                _bpPiutangDetilDal.Delete(model.BPPiutangID);
                _bpPiutangDal.Delete(model.BPPiutangID);

                _bpPiutangDal.Insert(model);
                foreach (var item in model.ListLunas)
                    _bpPiutangDetilDal.Insert(item);

                trans.Complete();
            }
            return model;
        }

        public SearchFilter SearchFilter { get; set; }

        public IEnumerable<BPPiutangSearchModel> Search()
        {
            var listData = _bpPiutangDal.ListData();
            if (listData == null) return null;

            var result = listData.Select(x => (BPPiutangSearchModel)x);

            if (SearchFilter.UserKeyword != null)
                return
                    from c in result
                    where c.PihakKeduaName.ContainMultiWord(SearchFilter.UserKeyword)
                    select c;

            return result;
        }

        public IEnumerable<BPPiutangModel> ListByCustomer(string customerID)
        {
            var listBPPiutang = _bpPiutangDal.ListData(customerID);
            if (listBPPiutang == null)
                return null;

            var result =
                from c in listBPPiutang
                where c.NilaiLunas != c.NilaiPiutang
                select c;
            if (!result.Any())
                return null;

            return result;
        }

    }
}
