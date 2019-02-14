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
    public interface IBiayaBL : ISearch<BiayaSearchModel>
    {
        BiayaModel Save(BiayaModel model);
        void Delete(string id);
        BiayaModel GetData(string id);
        IEnumerable<BiayaModel> ListData(string tgl1, string tgl2);
    }
    public class BiayaBL : IBiayaBL
    {
        private IBiayaDal _biayaDal;
        private IParameterNoBL _paramNoBL;
        private IJenisBiayaBL _jenisBiayaBL;
        private IJenisKasBL _jenisKasBL;

        public BiayaBL()
        {
            _biayaDal = new BiayaDal();
            _paramNoBL = new ParameterNoBL();
            _jenisBiayaBL = new JenisBiayaBL();
            _jenisKasBL = new JenisKasBL();

            SearchFilter = new SearchFilter
            {
                IsDate = true,
                Date1 = DateTime.Now,
                Date2 = DateTime.Now
            };
        }

        public BiayaModel Save(BiayaModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            if (model.NilaiBiaya <= 0)
                throw new ArgumentException("Nilai Biaya invalid");

            var jenisBiaya = _jenisBiayaBL.GetData(model.JenisBiayaID);
            if (jenisBiaya == null)
                throw new ArgumentException("JenisBiayaID invalid");

            var jenisKas = _jenisKasBL.GetData(model.JenisKasID);
            if (jenisKas == null)
                throw new ArgumentException("JenisKasID invalid");

            bool isNew = false;
            if (model.BiayaID.Trim() == "")
                isNew = true;

            using (var trans = TransHelper.NewScope())
            {
                if (isNew)
                {
                    model.BiayaID = GenNewID();
                    _biayaDal.Insert(model);
                }
                else
                {
                    _biayaDal.Update(model);
                }
                trans.Complete();
            }

            return model;
        }

        private string GenNewID()
        {
            var prefix = "BJ" + DateTime.Now.ToString("yyMM");
            var result = _paramNoBL.GenNewID(prefix, 10);
            return result;
        }

        public void Delete(string id)
        {
            _biayaDal.Delete(id);
        }

        public BiayaModel GetData(string id)
        {
            return _biayaDal.GetData(id);
        }

        public IEnumerable<BiayaModel> ListData(string tgl1, string tgl2)
        {
            return _biayaDal.ListData(tgl1, tgl2);
        }

        public SearchFilter SearchFilter { get; set; }

        public IEnumerable<BiayaSearchModel> Search()
        {
            //  ambil data
            var listAll = _biayaDal.ListData(SearchFilter.TglDMY1, SearchFilter.TglDMY2);
            if (listAll == null) return null;

            //  convert ke SearchModel
            var result = listAll.Select(x => (BiayaSearchModel)x);

            if (SearchFilter.UserKeyword != null)
                return
                    from c in result
                    where c.Keterangan.ContainMultiWord(SearchFilter.UserKeyword)
                    select c;

            return result;
        }
    }
}
