using AnugerahBackend.Keuangan.Dal;
using AnugerahBackend.Keuangan.Model;
using AnugerahBackend.Support;
using Ics.Helper.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Keuangan.BL
{
    public interface IPihakKetigaBL : ISearch<PihakKetigaModel>
    {
        PihakKetigaModel Save(PihakKetigaModel pihakKetiga);
        void Delete(string pihakKetigaID);
        PihakKetigaModel GetData(string pihakKetigaID);
        IEnumerable<PihakKetigaModel> ListData();
    }

    public class PihakKetigaBL : IPihakKetigaBL
    {
        private IPihakKetigaDal _pihakKetigaDal;

        public PihakKetigaBL()
        {
            _pihakKetigaDal = new PihakKetigaDal();
            SearchFilter = new SearchFilter();
        }

        public PihakKetigaModel Save(PihakKetigaModel pihakKetiga)
        {
            throw new NotImplementedException();
        }

        public void Delete(string pihakKetigaID)
        {
            throw new NotImplementedException();
        }

        public PihakKetigaModel GetData(string pihakKetigaID)
        {
            return _pihakKetigaDal.GetData(pihakKetigaID);
        }

        public IEnumerable<PihakKetigaModel> ListData()
        {
            throw new NotImplementedException();
        }

        #region SEARCH
        public SearchFilter SearchFilter { get; set; }

        public IEnumerable<PihakKetigaModel> Search()
        {
            //  ambil data
            var result = _pihakKetigaDal.ListData();
            if (result == null) return null;

            if (SearchFilter.UserKeyword != null)
                return
                    from c in result
                    where c.PihakKetigaName.ContainMultiWord(SearchFilter.UserKeyword)
                    select c;

            return result;
        } 
        #endregion
    }
}
