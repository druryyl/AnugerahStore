using AnugerahBackend.Keuangan.Model;
using AnugerahBackend.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Keuangan.BL
{
    public interface IBukuHutangBL : ISearch<BukuHutangSearchModel>
    {
        void Generate(BukuKasModel bukuKas);
    }
    public class BukuHutangBL : IBukuHutangBL
    {
        public void Generate(BukuKasModel bukuKas)
        {
            throw new NotImplementedException();
        }



        #region SEARCH
        public SearchFilter SearchFilter {get; set; }
        public IEnumerable<BukuHutangSearchModel> Search()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
