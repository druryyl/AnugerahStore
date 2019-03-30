using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnugerahBackend.Accounting.Dal;
using AnugerahBackend.Accounting.Model;
using AnugerahBackend.Support;
using Ics.Helper.Extensions;

namespace AnugerahBackend.Accounting.BL
{

    public interface IJenisKasBL : ISearch<JenisKasModel>
    {
        JenisKasModel Save(JenisKasModel model);

        void Delete(string id);

        JenisKasModel GetData(string id);

        IEnumerable<JenisKasModel> ListData();

        JenisKasModel TryValidate(JenisKasModel model);
    }


    public class JenisKasBL : IJenisKasBL
    {
        private IJenisKasDal _jenisKasDal;

        public JenisKasBL()
        {
            _jenisKasDal = new JenisKasDal();
            SearchFilter = new SearchFilter
            {
                IsDate = false,
            };
        }

        public JenisKasBL(IJenisKasDal injJenisKasDal)
        {
            _jenisKasDal = injJenisKasDal;
        }

        public JenisKasModel Save(JenisKasModel jenisKas)
        {
            //  validasi
            var result = jenisKas;
            result = TryValidate(jenisKas);

            //  save
            var dummyJenisKas = _jenisKasDal.GetData(jenisKas.JenisKasID);
            if (dummyJenisKas == null)
            {
                _jenisKasDal.Insert(result);
            }
            else
            {
                _jenisKasDal.Update(result);
            }

            return result;
        }

        public void Delete(string id)
        {
            _jenisKasDal.Delete(id);
        }

        public JenisKasModel GetData(string id)
        {
            return _jenisKasDal.GetData(id);
        }

        public IEnumerable<JenisKasModel> ListData()
        {
            return _jenisKasDal.ListData();
        }

        public JenisKasModel TryValidate(JenisKasModel jenisKas)
        {
            var result = jenisKas;

            if (jenisKas == null)
            {
                throw new ArgumentNullException(nameof(jenisKas));
            }

            if (jenisKas.JenisKasID.Trim() == "")
            {
                throw new ArgumentException("JenisKasID empty");
            }
            if (jenisKas.JenisKasName.Trim() == "")
            {
                throw new ArgumentException("JenisKasName empty");
            }

            return result;
        }

        public SearchFilter SearchFilter { get; set; }

        public IEnumerable<JenisKasModel> Search()
        {
            var listData = _jenisKasDal.ListData();
            if (listData == null)
                return null;

            IEnumerable<JenisKasModel> result;
            if (SearchFilter.UserKeyword != null)
                result =
                    from c in listData
                    where c.JenisKasName.ContainMultiWord(SearchFilter.UserKeyword)
                    select c;
            else
                result = listData;

            return result;
        }
    }
}
