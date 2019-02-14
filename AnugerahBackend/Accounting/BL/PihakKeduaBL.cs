using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnugerahBackend.Accounting.Dal;
using AnugerahBackend.Accounting.Model;

namespace AnugerahBackend.Accounting.BL
{

    public interface IPihakKeduaBL
    {
        PihakKeduaModel Save(PihakKeduaModel model);

        void Delete(string id);

        PihakKeduaModel GetData(string id);

        IEnumerable<PihakKeduaModel> ListData();

        PihakKeduaModel TryValidate(PihakKeduaModel model);
    }

    public class PihakKeduaBL : IPihakKeduaBL
    {
        private IPihakKeduaDal _pihakKeduaDal;

        public PihakKeduaBL()
        {
            _pihakKeduaDal = new PihakKeduaDal();
        }

        public PihakKeduaBL(IPihakKeduaDal injPihakKeduaDal)
        {
            _pihakKeduaDal = injPihakKeduaDal;
        }

        public PihakKeduaModel Save(PihakKeduaModel pihakKedua)
        {
            //  validasi
            var result = pihakKedua;
            result = TryValidate(pihakKedua);

            //  save
            var dummyPihakKedua = _pihakKeduaDal.GetData(pihakKedua.PihakKeduaID);
            if (dummyPihakKedua == null)
            {
                _pihakKeduaDal.Insert(result);
            }
            else
            {
                _pihakKeduaDal.Update(result);
            }

            return result;
        }

        public void Delete(string id)
        {
            _pihakKeduaDal.Delete(id);
        }

        public PihakKeduaModel GetData(string id)
        {
            return _pihakKeduaDal.GetData(id);
        }

        public IEnumerable<PihakKeduaModel> ListData()
        {
            return _pihakKeduaDal.ListData();
        }

        public PihakKeduaModel TryValidate(PihakKeduaModel pihakKedua)
        {
            var result = pihakKedua;

            if (pihakKedua == null)
            {
                throw new ArgumentNullException(nameof(pihakKedua));
            }

            if (pihakKedua.PihakKeduaID.Trim() == "")
            {
                throw new ArgumentException("PihakKeduaID empty");
            }
            if (pihakKedua.PihakKeduaName.Trim() == "")
            {
                throw new ArgumentException("PihakKeduaName empty");
            }

            return result;
        }
    }
}
