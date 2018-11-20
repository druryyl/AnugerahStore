using AnugerahBackend.StokBarang.Dal;
using AnugerahBackend.StokBarang.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.StokBarang.BL
{

    public interface IJenisBrgBL
    {
        JenisBrgModel Save(JenisBrgModel jenisBrg);

        void Delete(string id);

        JenisBrgModel GetData(string id);

        IEnumerable<JenisBrgModel> ListData();

        JenisBrgModel TryValidate(JenisBrgModel jenisBrg);
    }

    public class JenisBrgBL : IJenisBrgBL
    {
        private IJenisBrgDal _jenisBrgDal;

        public JenisBrgBL()
        {
            _jenisBrgDal = new JenisBrgDal();
        }

        public JenisBrgBL(IJenisBrgDal injJenisBrgDal)
        {
            _jenisBrgDal = injJenisBrgDal;
        }

        public JenisBrgModel Save(JenisBrgModel jenisBrg)
        {
            //  validasi
            var result = jenisBrg;
            result = TryValidate(jenisBrg);

            //  save
            var dummyJenisBrg = _jenisBrgDal.GetData(jenisBrg.JenisBrgID);
            if (dummyJenisBrg == null)
            {
                _jenisBrgDal.Insert(result);
            }
            else
            {
                _jenisBrgDal.Update(result);
            }

            return result;
        }

        public void Delete(string id)
        {
            _jenisBrgDal.Delete(id);
        }

        public JenisBrgModel GetData(string id)
        {
            return _jenisBrgDal.GetData(id);
        }

        public IEnumerable<JenisBrgModel> ListData()
        {
            return _jenisBrgDal.ListData();
        }

        public JenisBrgModel TryValidate(JenisBrgModel jenisBrg)
        {
            var result = jenisBrg;

            if (jenisBrg == null)
            {
                throw new ArgumentNullException(nameof(jenisBrg));
            }

            if (jenisBrg.JenisBrgID.Trim() == "")
            {
                throw new ArgumentException("JenisBrgID empty");
            }
            if (jenisBrg.JenisBrgName.Trim() == "")
            {
                throw new ArgumentException("JenisBrgName empty");
            }

            return result;
        }
    }
}
