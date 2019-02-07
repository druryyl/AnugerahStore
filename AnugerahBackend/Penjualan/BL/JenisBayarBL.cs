using AnugerahBackend.Penjualan.Dal;
using AnugerahBackend.Penjualan.Model;
using AnugerahBackend.Support;
using Ics.Helper.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Penjualan.BL
{
    public interface IJenisBayarBL : ISearch<JenisBayarModel>
    {
        JenisBayarModel Save(JenisBayarModel jenisBayar);
        void Delete(string id);
        JenisBayarModel GetData(string id);
        IEnumerable<JenisBayarModel> ListData();
    }

    public class JenisBayarBL : IJenisBayarBL
    {
        private IJenisBayarDal _jenisBayarDal;

        public JenisBayarBL()
        {
            _jenisBayarDal = new JenisBayarDal();
            SearchFilter = new SearchFilter();
        }

        public JenisBayarBL(IJenisBayarDal injJenisBayarDal)
        {
            _jenisBayarDal = injJenisBayarDal;
        }
        public JenisBayarModel Save(JenisBayarModel jenisBayar)
        {
            if (jenisBayar == null)
            {
                throw new ArgumentNullException(nameof(jenisBayar));
            }
            if (jenisBayar.JenisBayarID == "")
                throw new ArgumentException("JenisBayarID empty");

            switch (jenisBayar.KasTransferEdc)
            {
                case "E": break;
                case "K": break;
                case "T": break;
                default:
                    throw new ArgumentException("KasTransferEdc Invalid");
            }

            if (jenisBayar.JenisBayarName == "")
                throw new ArgumentException("JenisBayarName invalid");

            var dummy = _jenisBayarDal.GetData(jenisBayar.JenisBayarID);
            if (dummy == null)
                _jenisBayarDal.Insert(jenisBayar);
            else
                _jenisBayarDal.Update(jenisBayar);

            return jenisBayar;
        }

        public void Delete(string id)
        {
            _jenisBayarDal.Delete(id);
        }

        public JenisBayarModel GetData(string id)
        {
            return _jenisBayarDal.GetData(id);
        }

        public IEnumerable<JenisBayarModel> ListData()
        {
            return _jenisBayarDal.ListData();
        }

        #region SEARCH
        public SearchFilter SearchFilter { get; set; }

        public IEnumerable<JenisBayarModel> Search()
        {
            //  ambil data
            var result = _jenisBayarDal.ListData();

            if (SearchFilter.UserKeyword != null)
                return
                    from c in result
                    where c.JenisBayarName.ContainMultiWord(SearchFilter.UserKeyword)
                    select c;

            return result;
        } 
        #endregion
    }
}
