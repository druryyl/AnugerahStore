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
    public interface IBPPiutangBL : ISearch<BPPiutangSearchModel>
    {
        void GenPiutang(KasBonModel kasBon);
        //void GenLunas()
    }

    public class BPPiutangBL : IBPPiutangBL
    {
        private ILunasKasBonDal _lunasKasBonDal;
        private IPihakKeduaBL _pihakKeduaBL;
        private IBPPiutangDal _bpPiutangDal;
        private IBPPiutangDetilDal _bpPiutangDetilDal;

        public BPPiutangBL()
        {
            _lunasKasBonDal = new LunasKasBonDal();
            _pihakKeduaBL = new PihakKeduaBL();
            _bpPiutangDal = new BPPiutangDal();
            _bpPiutangDetilDal = new BPPiutangDetilDal();
            SearchFilter = new SearchFilter
            {
                IsDate = false,
            };
        }

        public void GenPiutang(KasBonModel kasBon)
        {
            if (kasBon == null)
            {
                throw new ArgumentNullException(nameof(kasBon));
            }
            var bpPiutang = (BPPiutangModel)kasBon;
            Save(bpPiutang);
        }

        private void Save(BPPiutangModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            //  validate pihak kedua;
            var pihakKedua = _pihakKeduaBL.GetData(model.PihakKeduaID);
            if (pihakKedua == null)
                throw new ArgumentException("PihakKeduaID invalid");

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
    }

}
