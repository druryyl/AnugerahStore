using AnugerahBackend.Keuangan.Dal;
using AnugerahBackend.Keuangan.Model;
using AnugerahBackend.Support;
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

        public IEnumerable<PihakKetigaModel> Search()
        {
            return _pihakKetigaDal.ListData();
        }

        public IEnumerable<PihakKetigaModel> Search(string keyword)
        {
            return _pihakKetigaDal.Search(keyword);
        }

        public IEnumerable<PihakKetigaModel> Search(string keyword, string tgl1, string tgl2)
        {
            throw new NotImplementedException();
        }
    }
}
