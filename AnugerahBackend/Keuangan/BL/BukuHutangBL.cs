using AnugerahBackend.Keuangan.Model;
using AnugerahBackend.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Keuangan.BL
{
    public interface IBukuHutangBL : ISearchData<BukuHutangSearchModel>
    {
        void Generate(BukuKasModel bukuKas);
    }
    public class BukuHutangBL : IBukuHutangBL
    {
        #region SEARCH
        public IEnumerable<BukuHutangSearchModel> Search()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BukuHutangSearchModel> Search(string keyword)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BukuHutangSearchModel> Search(string keyword, string tgl1, string tgl2)
        {
            throw new NotImplementedException();
        } 
        #endregion
    }
}
