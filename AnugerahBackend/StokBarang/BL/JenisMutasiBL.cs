using AnugerahBackend.StokBarang.Dal;
using AnugerahBackend.StokBarang.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.StokBarang.BL
{

    public interface IJenisMutasiBL
    {
        JenisMutasiModel Save(JenisMutasiModel jenisMutasi);

        void Delete(string id);

        JenisMutasiModel GetData(string id);

        IEnumerable<JenisMutasiModel> ListData();

        JenisMutasiModel TryValidate(JenisMutasiModel jenisMutasi);
    }

    public class JenisMutasiBL : IJenisMutasiBL
    {
        private IJenisMutasiDal _jenisMutasiDal;

        public JenisMutasiBL()
        {
            _jenisMutasiDal = new JenisMutasiDal();
        }

        public JenisMutasiBL(IJenisMutasiDal injJenisMutasiDal)
        {
            _jenisMutasiDal = injJenisMutasiDal;
        }

        public JenisMutasiModel Save(JenisMutasiModel jenisMutasi)
        {
            //  validasi
            var result = jenisMutasi;
            result = TryValidate(jenisMutasi);

            //  save
            var dummyJenisMutasi = _jenisMutasiDal.GetData(jenisMutasi.JenisMutasiID);
            if (dummyJenisMutasi == null)
            {
                _jenisMutasiDal.Insert(result);
            }
            else
            {
                _jenisMutasiDal.Update(result);
            }

            return result;
        }

        public void Delete(string id)
        {
            _jenisMutasiDal.Delete(id);
        }

        public JenisMutasiModel GetData(string id)
        {
            return _jenisMutasiDal.GetData(id);
        }

        public IEnumerable<JenisMutasiModel> ListData()
        {
            return _jenisMutasiDal.ListData();
        }

        public JenisMutasiModel TryValidate(JenisMutasiModel jenisMutasi)
        {
            var result = jenisMutasi;

            if (jenisMutasi == null)
            {
                throw new ArgumentNullException(nameof(jenisMutasi));
            }

            if (jenisMutasi.JenisMutasiID.Trim() == "")
            {
                throw new ArgumentException("JenisMutasiID empty");
            }
            if (jenisMutasi.JenisMutasiName.Trim() == "")
            {
                throw new ArgumentException("JenisMUtasiName empty");
            }

            return result;
        }
    }
}
