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
        private IJenisBrg2TipeDal _jenisBrg2TipeDal;

        private ITipeBrgBL _tipeBrgBL;

        public JenisBrgBL()
        {
            _jenisBrgDal = new JenisBrgDal();
            _jenisBrg2TipeDal = new JenisBrg2TipeDal();
            _tipeBrgBL = new TipeBrgBL();
        }

        public JenisBrgBL(IJenisBrgDal injJenisBrgDal, 
            IJenisBrg2TipeDal injJenisBrg2TipeDal, ITipeBrgBL injTipeBrgBL)
        {
            _jenisBrgDal = injJenisBrgDal;
            _jenisBrg2TipeDal = injJenisBrg2TipeDal;
            _tipeBrgBL = injTipeBrgBL;
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

            //  save detil;
            //  hapus detil lama
            _jenisBrg2TipeDal.Delete(jenisBrg.JenisBrgID);
            int noUrut = 0;
            //  insert ulang detil baru
            foreach (var item in jenisBrg.ListTipe)
            {
                noUrut++;
                item.NoUrut = noUrut;
                _jenisBrg2TipeDal.Insert(item);
            }
            return result;
        }

        public void Delete(string id)
        {
            _jenisBrgDal.Delete(id);
            _jenisBrg2TipeDal.Delete(id);
        }

        public JenisBrgModel GetData(string id)
        {
            //  get header
            var jenisBrg = _jenisBrgDal.GetData(id);
            //  get detail
            var listJenisBrg2Tipe = _jenisBrg2TipeDal.ListData(id);
            //  attact detil to header
            jenisBrg.ListTipe = listJenisBrg2Tipe;
            return jenisBrg;
        }

        public IEnumerable<JenisBrgModel> ListData()
        {
            //  hanya list header saja
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

            //  cek detil
            if (jenisBrg.ListTipe != null)
            {
                foreach (var item in jenisBrg.ListTipe)
                {
                    var tipeBrg = _tipeBrgBL.GetData(item.TipeBrgID);
                    if (tipeBrg == null)
                        throw new ArgumentException("TipeBrgID invalid");
                    item.TipeBrgName = tipeBrg.TipeBrgName;
                }

            }

            return result;
        }
    }
}
