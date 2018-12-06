using AnugerahBackend.StokBarang.Dal;
using AnugerahBackend.StokBarang.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.StokBarang.BL
{

    public interface IBrgBL
    {
        BrgModel Save(BrgModel brg);

        void Delete(string id);

        BrgModel GetData(string id);

        IEnumerable<BrgModel> ListData();

        BrgModel TryValidate(BrgModel brg);
    }

    public class BrgBL : IBrgBL
    {
        private IBrgDal _brgDal;
        private ISubJenisBrgBL _subJenisBrgBL;
        private IMerkBL _merkBL;
        private IColorBL _colorBL;

        public BrgBL()
        {
            _brgDal = new BrgDal();
            _subJenisBrgBL = new SubJenisBrgBL();
            _merkBL = new MerkBL();
            _colorBL = new ColorBL();
        }

        public BrgBL(IBrgDal injBrgDal, ISubJenisBrgBL injSubJenisBrgBL,
            IMerkBL injMerkBL, IColorBL injColorBL)
        {
            _brgDal = injBrgDal;
            _subJenisBrgBL = injSubJenisBrgBL;
            _merkBL = injMerkBL;
            _colorBL = injColorBL;
        }

        public BrgModel Save(BrgModel brg)
        {
            //  validasi
            var result = brg;
            result = TryValidate(brg);

            //  save
            var dummyBrg = _brgDal.GetData(brg.BrgID);
            if (dummyBrg == null)
            {
                _brgDal.Insert(result);
            }
            else
            {
                _brgDal.Update(result);
            }

            return result;
        }

        public void Delete(string id)
        {
            _brgDal.Delete(id);
        }

        public BrgModel GetData(string id)
        {
            return _brgDal.GetData(id);
        }

        public IEnumerable<BrgModel> ListData()
        {
            return _brgDal.ListData();
        }

        public BrgModel TryValidate(BrgModel brg)
        {
            var result = brg;

            if (brg == null)
            {
                throw new ArgumentNullException(nameof(brg));
            }

            if (brg.BrgID.Trim() == "")
            {
                throw new ArgumentException("BrgID empty");
            }
            if (brg.BrgName.Trim() == "")
            {
                throw new ArgumentException("BrgName empty");
            }

            var subJenisBrg = _subJenisBrgBL.GetData(brg.SubJenisBrgID);
            if(subJenisBrg == null)
            {
                throw new ArgumentException("SubJenisBrgID invalid");
            }
            else
            {
                brg.SubJenisBrgName = subJenisBrg.SubJenisBrgName;
            }

            if(brg.MerkID.Trim() != "")
            {
                var merk = _merkBL.GetData(brg.MerkID);
                if(merk == null)
                {
                    throw new ArgumentException("MerkID invalid");
                }
                else
                {
                    brg.MerkName = merk.MerkName;
                }
            }

            if(brg.ColorID.Trim() != "")
            {
                var color = _colorBL.GetData(brg.ColorID);
                if(color == null)
                {
                    throw new ArgumentException("ColorID invalid");
                }
            }
            return result;
        }
    }
}
