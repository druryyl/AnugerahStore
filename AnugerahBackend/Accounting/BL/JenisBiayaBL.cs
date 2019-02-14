using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnugerahBackend.Accounting.Dal;
using AnugerahBackend.Accounting.Model;

namespace AnugerahBackend.Accounting.BL
{

    public interface IJenisBiayaBL
    {
        JenisBiayaModel Save(JenisBiayaModel model);

        void Delete(string id);

        JenisBiayaModel GetData(string id);

        IEnumerable<JenisBiayaModel> ListData();

        JenisBiayaModel TryValidate(JenisBiayaModel model);
    }


    public class JenisBiayaBL : IJenisBiayaBL
    {
        private IJenisBiayaDal _jenisBiayaDal;

        public JenisBiayaBL()
        {
            _jenisBiayaDal = new JenisBiayaDal();
        }

        public JenisBiayaBL(IJenisBiayaDal injJenisBiayaDal)
        {
            _jenisBiayaDal = injJenisBiayaDal;
        }

        public JenisBiayaModel Save(JenisBiayaModel jenisBiaya)
        {
            //  validasi
            var result = jenisBiaya;
            result = TryValidate(jenisBiaya);

            //  save
            var dummyJenisBiaya = _jenisBiayaDal.GetData(jenisBiaya.JenisBiayaID);
            if (dummyJenisBiaya == null)
            {
                _jenisBiayaDal.Insert(result);
            }
            else
            {
                _jenisBiayaDal.Update(result);
            }

            return result;
        }

        public void Delete(string id)
        {
            _jenisBiayaDal.Delete(id);
        }

        public JenisBiayaModel GetData(string id)
        {
            return _jenisBiayaDal.GetData(id);
        }

        public IEnumerable<JenisBiayaModel> ListData()
        {
            return _jenisBiayaDal.ListData();
        }

        public JenisBiayaModel TryValidate(JenisBiayaModel jenisBiaya)
        {
            var result = jenisBiaya;

            if (jenisBiaya == null)
            {
                throw new ArgumentNullException(nameof(jenisBiaya));
            }

            if (jenisBiaya.JenisBiayaID.Trim() == "")
            {
                throw new ArgumentException("JenisBiayaID empty");
            }
            if (jenisBiaya.JenisBiayaName.Trim() == "")
            {
                throw new ArgumentException("JenisBiayaName empty");
            }

            return result;
        }
    }
}
