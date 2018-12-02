using AnugerahBackend.StokBarang.Dal;
using AnugerahBackend.StokBarang.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.StokBarang.BL
{

    public interface ITipeBrgBL
    {
        TipeBrgModel Save(TipeBrgModel tipeBrg);

        void Delete(string id);

        TipeBrgModel GetData(string id);

        IEnumerable<TipeBrgModel> ListData();

        IEnumerable<TipeBrgModel> ListData(string jenisBrgID);

        TipeBrgModel TryValidate(TipeBrgModel tipeBrg);
    }

    public class TipeBrgBL : ITipeBrgBL
    {
        private ITipeBrgDal _tipeBrgDal;

        public TipeBrgBL()
        {
            _tipeBrgDal = new TipeBrgDal();
        }

        public TipeBrgBL(ITipeBrgDal injTipeBrgDal)
        {
            _tipeBrgDal = injTipeBrgDal;
        }

        public TipeBrgModel Save(TipeBrgModel tipeBrg)
        {
            //  validasi
            var result = tipeBrg;
            result = TryValidate(tipeBrg);

            //  save
            var dummyTipeBrg = _tipeBrgDal.GetData(tipeBrg.TipeBrgID);
            if (dummyTipeBrg == null)
            {
                _tipeBrgDal.Insert(result);
            }
            else
            {
                _tipeBrgDal.Update(result);
            }

            return result;
        }

        public void Delete(string id)
        {
            _tipeBrgDal.Delete(id);
        }

        public TipeBrgModel GetData(string id)
        {
            return _tipeBrgDal.GetData(id);
        }

        public IEnumerable<TipeBrgModel> ListData()
        {
            return _tipeBrgDal.ListData();
        }

        public TipeBrgModel TryValidate(TipeBrgModel tipeBrg)
        {
            var result = tipeBrg;

            if (tipeBrg == null)
            {
                throw new ArgumentNullException(nameof(tipeBrg));
            }

            if (tipeBrg.TipeBrgID.Trim() == "")
            {
                throw new ArgumentException("TipeBrgID empty");
            }
            if (tipeBrg.TipeBrgName.Trim() == "")
            {
                throw new ArgumentException("TipeBrgName empty");
            }

            return result;
        }

        public IEnumerable<TipeBrgModel> ListData(string jenisBrgID)
        {
            return _tipeBrgDal.ListData(jenisBrgID);
        }
    }
}
