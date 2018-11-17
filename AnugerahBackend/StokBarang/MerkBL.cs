using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.StokBarang
{

    public interface IMerkBL
    {
        MerkModel Save(MerkModel merk);

        void Delete(string id);

        MerkModel GetData(string id);

        IEnumerable<MerkModel> ListData();

        MerkModel TryValidate(MerkModel merk);
    }

    public class MerkBL : IMerkBL
    {
        private IMerkDal _merkDal;

        public MerkBL()
        {
            _merkDal = new MerkDal();
        }

        public MerkBL(IMerkDal injMerkDal)
        {
            _merkDal = injMerkDal;
        }

        public MerkModel Save(MerkModel merk)
        {
            //  validasi
            var result = merk;
            result = TryValidate(merk);

            //  save
            var dummyMerk = _merkDal.GetData(merk.MerkID);
            if (dummyMerk == null)
            {
                _merkDal.Insert(result);
            }
            else
            {
                _merkDal.Update(result);
            }

            return result;
        }

        public void Delete(string id)
        {
            _merkDal.Delete(id);
        }

        public MerkModel GetData(string id)
        {
            return _merkDal.GetData(id);
        }

        public IEnumerable<MerkModel> ListData()
        {
            return _merkDal.ListData();
        }

        public MerkModel TryValidate(MerkModel merk)
        {
            var result = merk;

            if (merk == null)
            {
                throw new ArgumentNullException(nameof(merk));
            }

            if (merk.MerkID.Trim() == "")
            {
                throw new ArgumentException("MerkID empty");
            }
            if (merk.MerkName.Trim() == "")
            {
                throw new ArgumentException("MerkName empty");
            }

            return result;
        }
    }
}
