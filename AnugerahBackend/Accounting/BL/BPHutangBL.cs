using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnugerahBackend.Accounting.Dal;
using AnugerahBackend.Accounting.Model;
using AnugerahBackend.Support;
using Ics.Helper.Database;
using Ics.Helper.Extensions;

namespace AnugerahBackend.Accounting.BL
{
    public interface IBPHutangBL : ISearch<BPHutangSearchModel>
    {
        BPHutangModel GenHutang(DepositModel deposit);
        //BPHutangModel GenHutang(LunasKasBonModel lunasKasBon, KasBonModel kasBon);
        BPHutangModel GetData(string piutangID);

        //void GenLunas()
    }

    public class BPHutangBL : IBPHutangBL
    {
        //private ILunasKasBonDal _lunasKasBonDal;
        private IPihakKeduaBL _pihakKeduaBL;
        private IBPHutangDal _bpHutangDal;
        private IBPHutangDetilDal _bpHutangDetilDal;

        public BPHutangBL()
        {
            //_lunasKasBonDal = new LunasKasBonDal();
            _pihakKeduaBL = new PihakKeduaBL();
            _bpHutangDal = new BPHutangDal();
            _bpHutangDetilDal = new BPHutangDetilDal();
            SearchFilter = new SearchFilter
            {
                IsDate = false,
            };
        }

        public BPHutangModel GetData(string piutangID)
        {
            var header = _bpHutangDal.GetData(piutangID);
            var detil = _bpHutangDetilDal.ListData(piutangID);
            header.ListLunas = detil;
            return header;
        }

        public BPHutangModel GenHutang(DepositModel deposit)
        {
            if (deposit == null)
            {
                throw new ArgumentNullException(nameof(deposit));
            }
            var bpHutang = (BPHutangModel)deposit;
            var result = Save(bpHutang);
            return result;
        }

        public BPHutangModel GenHutang(LunasKasBonModel lunasKasBon, KasBonModel kasBon)
        {
            ////  ambil data piutang berdasarkan kasBon
            //var bpHutang = GetData(kasBon.KasBonID);
            //if (bpHutang == null)
            //{
            //    var errMsg = string.Format("Hutang {0} tidak ditemukan ", kasBon.KasBonID);
            //    throw new ArgumentException(errMsg);
            //}

            ////  hapus detil lunas yang id-nya = lunasKasBonID
            //List<BPHutangDetilModel> newListLunas =
            //    (
            //        from c in bpHutang.ListLunas
            //        where c.ReffID != lunasKasBon.LunasKasBonID
            //        select c
            //    ).ToList();

            ////  tambahkan pelunasan dari lunasKasBon
            //int noUrut = newListLunas.Count + 1;
            //foreach (var item in lunasKasBon.ListLunas)
            //{
            //    newListLunas.Add(new BPHutangDetilModel
            //    {
            //        BPHutangID = bpHutang.BPHutangID,
            //        BPHutangDetilID = bpHutang.BPHutangID + '-' + noUrut.ToString().PadLeft(2, '0'),
            //        Tgl = lunasKasBon.Tgl,
            //        Jam = lunasKasBon.Jam,
            //        ReffID = item.LunasKasBonID,
            //        Keterangan = "   Pelunasan " + item.JenisLunasName,
            //        NilaiHutang = 0,
            //        NilaiLunas = item.NilaiLunas
            //    });
            //    noUrut++;
            //}

            //bpHutang.ListLunas = newListLunas;
            ////  simpan
            //var result = Save(bpHutang);
            //return result;
            throw new NotImplementedException();
        }

        private BPHutangModel Save(BPHutangModel model)
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

            //  update nilai total di header
            model.NilaiHutang = model.ListLunas.Sum(x => x.NilaiHutang);
            model.NilaiLunas = model.ListLunas.Sum(x => x.NilaiLunas);

            //  delete data lama
            using (var trans = TransHelper.NewScope())
            {
                _bpHutangDetilDal.Delete(model.BPHutangID);
                _bpHutangDal.Delete(model.BPHutangID);

                _bpHutangDal.Insert(model);
                foreach (var item in model.ListLunas)
                    _bpHutangDetilDal.Insert(item);

                trans.Complete();
            }
            return model;
        }

        public SearchFilter SearchFilter { get; set; }

        public IEnumerable<BPHutangSearchModel> Search()
        {
            var listData = _bpHutangDal.ListData();
            if (listData == null) return null;

            var result = listData.Select(x => (BPHutangSearchModel)x);

            if (SearchFilter.UserKeyword != null)
                return
                    from c in result
                    where c.PihakKeduaName.ContainMultiWord(SearchFilter.UserKeyword)
                    select c;

            return result;
        }


    }
}
