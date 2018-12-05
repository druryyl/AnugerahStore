using AnugerahBackend.StokBarang.Dal;
using AnugerahBackend.StokBarang.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.StokBarang.BL
{


    public interface ISubJenisBrgBL
    {
        SubJenisBrgModel Save(SubJenisBrgModel subJenisBrg);

        void Delete(string id);

        SubJenisBrgModel GetData(string id);

        IEnumerable<SubJenisBrgModel> ListData();

        SubJenisBrgModel TryValidate(SubJenisBrgModel subJenisBrg);
    }
    public class SubJenisBrgBL : ISubJenisBrgBL
    {
        private ISubJenisBrgDal _subJenisBrgDal;
        private IJenisBrgBL _jenisBrgBL;

        public SubJenisBrgBL()
        {
            _subJenisBrgDal = new SubJenisBrgDal();
            _jenisBrgBL = new JenisBrgBL();
        }

        public SubJenisBrgBL(ISubJenisBrgDal injSubJenisBrgDal,
            IJenisBrgBL injJenisBrgBL)
        {
            _subJenisBrgDal = injSubJenisBrgDal;
            _jenisBrgBL = injJenisBrgBL;
        }

        public SubJenisBrgModel Save(SubJenisBrgModel subJenisBrg)
        {
            //  validasi
            var result = subJenisBrg;
            result = TryValidate(subJenisBrg);

            //  save
            var dummySubJenisBrg = _subJenisBrgDal.GetData(subJenisBrg.SubJenisBrgID);
            if (dummySubJenisBrg == null)
            {
                _subJenisBrgDal.Insert(result);
            }
            else
            {
                _subJenisBrgDal.Update(result);
            }

            return result;
        }

        public void Delete(string id)
        {
            _subJenisBrgDal.Delete(id);
        }

        public SubJenisBrgModel GetData(string id)
        {
            return _subJenisBrgDal.GetData(id);
        }

        public IEnumerable<SubJenisBrgModel> ListData()
        {
            return _subJenisBrgDal.ListData();
        }

        public SubJenisBrgModel TryValidate(SubJenisBrgModel subJenisBrg)
        {
            var result = subJenisBrg;

            if (subJenisBrg == null)
            {
                throw new ArgumentNullException(nameof(subJenisBrg));
            }

            if (subJenisBrg.SubJenisBrgID.Trim() == "")
            {
                throw new ArgumentException("SubJenisBrgID empty");
            }
            if (subJenisBrg.SubJenisBrgName.Trim() == "")
            {
                throw new ArgumentException("SubJenisBrgName empty");
            }
            var jenisBrg = _jenisBrgBL.GetData(subJenisBrg.JenisBrgID);
            if(jenisBrg == null)
            {
                throw new ArgumentException("JenisBrgID invalid");
            }
            else
            {
                subJenisBrg.JenisBrgName = jenisBrg.JenisBrgName;
            }
            return result;
        }
    }
}
