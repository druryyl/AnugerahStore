using AnugerahBackend.StokBarang.Model;
using AnugerahBackend.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.StokBarang.BL
{
    public interface IStokBL : ISearchData<StokSearchModel>
    {
        void AddStok(string brgID, string tgl, string jam, long qty,
            double hpp, string trsMasukID, string trsDOID, string batchNo);
        void RemoveStok(string brgID, long qty, string batchNo);
    }

    public class StokBL : IStokBL
    {
        public void AddStok(string brgID, string tgl, string jam, long qty, double hpp, string trsMasukID, string trsDOID, string batchNo)
        {
            throw new NotImplementedException();
        }

        public void RemoveStok(string brgID, long qty, string batchNo)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StokSearchModel> Search(string keyword)
        {
            throw new NotImplementedException();
        }
    }
}
