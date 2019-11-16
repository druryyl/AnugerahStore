using AnugerahBackend.Support.Dal;
using AnugerahBackend.Support.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Support.BL
{

    public interface IUserrBL
    {
        UserrModel Save(UserrModel userr);
        void Save(string userName, string pass1, string pass2, string jenis);

        void Delete(string id);

        UserrModel GetData(string id);

        IEnumerable<UserrModel> ListData();

        UserrModel TryValidate(UserrModel userr);

        bool IsValidPassword(UserrModel userr, string pass);
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

            userr.Password = HashFunctions.GetHashString(userr.Password);
            return result;
        }

        private string Encrypt(string stringData)
        {
            var result = "";


            return result;
        }

        public bool IsValidPassword(UserrModel userr, string pass)
        {
            var userr2 = _userrDal.GetData(userr.UserrID);
            var hash1 = userr2.Password;
            var hash2 = HashFunctions.GetHashString(pass);
            if (hash1 == hash2)
                return true;
            else
                return false;
        }

        public void Save(string userName, string pass1, string pass2, string jenis)
        {
            if (userName.Trim() == "")
                throw new ArgumentException("UserName empty");

            if (pass1.Trim() == "")
                throw new ArgumentException("Password empty");

            if (pass1 != pass2)
                throw new ArgumentException("Password not match");

            var passHash = HashFunctions.GetHashString(pass1);

            var existing = _userrDal.GetData(userName);
            if (existing == null)
                _userrDal.Insert(new UserrModel
                {
                    UserrID = userName,
                    UserrName = userName,
                    Password = passHash,
                    Jenis = jenis
                });
            else
                _userrDal.Update(new UserrModel
                {
                    UserrID = userName,
                    UserrName = userName,
                    Password = passHash,
                    Jenis = jenis
                });

        }
    }

    public static class HashFunctions
    {
        private static byte[] GetHash(string inputString)
        {
            HashAlgorithm algorithm = SHA256.Create();
            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        public static string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));
            return sb.ToString();
        }
    }
}
