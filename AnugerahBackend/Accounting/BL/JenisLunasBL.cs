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

    public interface IJenisLunasBL : ISearch<JenisLunasModel>
    {
        JenisLunasModel Save(JenisLunasModel jenisLunas);

        void Delete(string id);

        JenisLunasModel GetData(string id);

        IEnumerable<JenisLunasModel> ListData();

        JenisLunasModel TryValidate(JenisLunasModel jenisLunas);
    }

    public class JenisLunasBL : IJenisLunasBL
    {
        private IJenisLunasDal _jenisLunasDal;
        private IJenisBiayaBL _jenisBiayaBL;
        public JenisLunasBL()
        {
            _jenisLunasDal = new JenisLunasDal();
            _jenisBiayaBL = new JenisBiayaBL();
            SearchFilter = new SearchFilter
            {
                IsDate = false
            };
        }

        public JenisLunasBL(IJenisLunasDal injJenisLunasDal)
        {
            _jenisLunasDal = injJenisLunasDal;
        }

        public JenisLunasModel Save(JenisLunasModel jenisLunas)
        {
            //  validasi
            var result = jenisLunas;
            result = TryValidate(jenisLunas);

            //  save
            var dummyJenisLunas = _jenisLunasDal.GetData(jenisLunas.JenisLunasID);
            if (dummyJenisLunas == null)
            {
                _jenisLunasDal.Insert(result);
            }
            else
            {
                _jenisLunasDal.Update(result);
            }

            return result;
        }

        public void Delete(string id)
        {
            _jenisLunasDal.Delete(id);
        }

        public JenisLunasModel GetData(string id)
        {
            return _jenisLunasDal.GetData(id);
        }

        public IEnumerable<JenisLunasModel> ListData()
        {
            return _jenisLunasDal.ListData();
        }

        public JenisLunasModel TryValidate(JenisLunasModel jenisLunas)
        {
            var result = jenisLunas;

            if (jenisLunas == null)
            {
                throw new ArgumentNullException(nameof(jenisLunas));
            }

            if (jenisLunas.JenisLunasID.Trim() == "")
            {
                throw new ArgumentException("JenisLunasID empty");
            }
            if (jenisLunas.JenisLunasName.Trim() == "")
            {
                throw new ArgumentException("JenisLunasName empty");
            }
            if(jenisLunas.JenisBiayaID.Trim() != "")
            {
                var jenisBiaya = _jenisBiayaBL.GetData(jenisLunas.JenisBiayaID);
                if (jenisBiaya == null)
                    throw new ArgumentException("JenisBiayaID invalid");
            }

            return result;
        }

        public SearchFilter SearchFilter { get; set; }

        public IEnumerable<JenisLunasModel> Search()
        {
            var listData = _jenisLunasDal.ListData();
            if (listData == null) return null;

            if (SearchFilter.UserKeyword != null)
                return
                    from c in listData
                    where c.JenisLunasName.ContainMultiWord(SearchFilter.UserKeyword)
                    select c;

            return listData;
        }
    }

}
