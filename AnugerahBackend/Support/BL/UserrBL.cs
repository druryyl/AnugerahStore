using AnugerahBackend.Support.Dal;
using AnugerahBackend.Support.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Support.BL
{

    public interface IUserrBL
    {
        UserrModel Save(UserrModel userr);

        void Delete(string id);

        UserrModel GetData(string id);

        IEnumerable<UserrModel> ListData();

        UserrModel TryValidate(UserrModel userr);
    }


    public class UserrBL : IUserrBL
    {
        private IUserrDal _userrDal;

        public UserrBL()
        {
            _userrDal = new UserrDal();
        }

        public UserrBL(IUserrDal injUserrDal)
        {
            _userrDal = injUserrDal;
        }

        public UserrModel Save(UserrModel userr)
        {
            //  validasi
            var result = userr;
            result = TryValidate(userr);

            //  save
            var dummyUserr = _userrDal.GetData(userr.UserrID);
            if (dummyUserr == null)
            {
                _userrDal.Insert(result);
            }
            else
            {
                _userrDal.Update(result);
            }

            return result;
        }

        public void Delete(string id)
        {
            _userrDal.Delete(id);
        }

        public UserrModel GetData(string id)
        {
            return _userrDal.GetData(id);
        }

        public IEnumerable<UserrModel> ListData()
        {
            return _userrDal.ListData();
        }

        public UserrModel TryValidate(UserrModel userr)
        {
            var result = userr;

            if (userr == null)
            {
                throw new ArgumentNullException(nameof(userr));
            }

            if (userr.UserrID.Trim() == "")
            {
                throw new ArgumentException("UserrID empty");
            }
            if (userr.UserrName.Trim() == "")
            {
                throw new ArgumentException("UserrName empty");
            }

            return result;
        }
    }
}
