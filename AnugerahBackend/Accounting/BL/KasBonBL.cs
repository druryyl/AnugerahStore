using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnugerahBackend.Accounting.Dal;
using AnugerahBackend.Accounting.Model;
using AnugerahBackend.Support;
using AnugerahBackend.Support.BL;
using Ics.Helper.Database;
using Ics.Helper.Extensions;

namespace AnugerahBackend.Accounting.BL
{
    public interface IKasBonBL : ISearch<KasBonSearchModel>
    {
        KasBonModel Save(KasBonModel model);
        void Delete(string id);
        KasBonModel GetData(string id);
        IEnumerable<KasBonModel> ListData(string tgl1, string tgl2);
    }
    public class KasBonBL : IKasBonBL
    {
        private IKasBonDal _kasBonDal;
        private IParameterNoBL _paramNoBL;
        private IPihakKeduaBL _jenisKasBonBL;
        private IJenisKasBL _jenisKasBL;

        public KasBonBL()
        {
            _kasBonDal = new KasBonDal();
            _paramNoBL = new ParameterNoBL();
            _jenisKasBonBL = new PihakKeduaBL();
            _jenisKasBL = new JenisKasBL();

            SearchFilter = new SearchFilter
            {
                IsDate = true,
                Date1 = DateTime.Now,
                Date2 = DateTime.Now
            };
        }

        public KasBonModel Save(KasBonModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            if (model.NilaiKasBon <= 0)
                throw new ArgumentException("Nilai KasBon invalid");

            var jenisKasBon = _jenisKasBonBL.GetData(model.PihakKeduaID);
            if (jenisKasBon == null)
                throw new ArgumentException("PihakKeduaID invalid");

            var jenisKas = _jenisKasBL.GetData(model.JenisKasID);
            if (jenisKas == null)
                throw new ArgumentException("JenisKasID invalid");

            bool isNew = false;
            if (model.KasBonID.Trim() == "")
                isNew = true;

            using (var trans = TransHelper.NewScope())
            {
                if (isNew)
                {
                    model.KasBonID = GenNewID();
                    _kasBonDal.Insert(model);
                }
                else
                {
                    _kasBonDal.Update(model);
                }
                trans.Complete();
            }

            return model;
        }

        private string GenNewID()
        {
            var prefix = "KB" + DateTime.Now.ToString("yyMM");
            var result = _paramNoBL.GenNewID(prefix, 10);
            return result;
        }

        public void Delete(string id)
        {
            _kasBonDal.Delete(id);
        }

        public KasBonModel GetData(string id)
        {
            return _kasBonDal.GetData(id);
        }

        public IEnumerable<KasBonModel> ListData(string tgl1, string tgl2)
        {
            return _kasBonDal.ListData(tgl1, tgl2);
        }

        public SearchFilter SearchFilter { get; set; }

        public IEnumerable<KasBonSearchModel> Search()
        {
            //  ambil data
            var listAll = _kasBonDal.ListData(SearchFilter.TglDMY1, SearchFilter.TglDMY2);
            if (listAll == null) return null;

            //  convert ke SearchModel
            var result = listAll.Select(x => (KasBonSearchModel)x);

            if (SearchFilter.UserKeyword != null)
                return
                    from c in result
                    where c.PihakKeduaName.ContainMultiWord(SearchFilter.UserKeyword)
                    select c;

            return result;
        }
    }
}
