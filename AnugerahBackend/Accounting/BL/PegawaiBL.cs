using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnugerahBackend.Accounting.Dal;
using AnugerahBackend.Accounting.Model;
using AnugerahBackend.Support;
using AnugerahBackend.Support.BL;
using Ics.Helper.Database;
using Ics.Helper.Extensions;

namespace AnugerahBackend.Accounting.BL
{

    public interface IPegawaiBL : ISearch<PegawaiSearchModel>
    {
        PegawaiModel Save(PegawaiModel model);

        void Delete(string id);

        PegawaiModel GetData(string id);

        IEnumerable<PegawaiModel> ListData();
    }


    public class PegawaiBL : IPegawaiBL
    {
        private IPegawaiDal _pegawaiDal;
        private IParameterNoBL _paramNoBL;
        private IPihakKeduaDal _pihakKeduaDal;

        public PegawaiBL()
        {
            _pegawaiDal = new PegawaiDal();
            _pihakKeduaDal = new PihakKeduaDal();
            _paramNoBL = new ParameterNoBL();
            SearchFilter = new SearchFilter
            {
                IsDate = false
            };
        }

        public PegawaiBL(IPegawaiDal injPegawaiDal, IPihakKeduaDal injPihakKeduaDal)
        {
            _pegawaiDal = injPegawaiDal;
            _pihakKeduaDal = injPihakKeduaDal;
        }

        public PegawaiModel Save(PegawaiModel pegawai)
        {
            if (pegawai == null)
            {
                throw new ArgumentNullException(nameof(pegawai));
            }

            if (pegawai.PegawaiName.Trim() == "")
                throw new ArgumentException("Pegawai Name kosong");

            using (var trans = TransHelper.NewScope())
            {
                if (pegawai.PegawaiID.Trim() == "")
                    pegawai.PegawaiID = GenNewID();

                //  simapn (hapus >> simpan)
                _pegawaiDal.Delete(pegawai.PegawaiID);
                _pegawaiDal.Insert(pegawai);

                //  update pihak kedua
                _pihakKeduaDal.Delete(pegawai.PegawaiID);
                var pihakKedua = new PihakKeduaModel
                {
                    PihakKeduaID = pegawai.PegawaiID,
                    PihakKeduaName = pegawai.PegawaiName
                };
                _pihakKeduaDal.Insert(pihakKedua);

                trans.Complete();
            }

            return pegawai;
        }

        private string GenNewID()
        {
            var prefix = "P";
            var result = _paramNoBL.GenNewID(prefix, 5);
            return result;
        }


        public void Delete(string id)
        {
            _pegawaiDal.Delete(id);
        }

        public PegawaiModel GetData(string id)
        {
            return _pegawaiDal.GetData(id);
        }

        public IEnumerable<PegawaiModel> ListData()
        {
            return _pegawaiDal.ListData();
        }

        public SearchFilter SearchFilter { get; set; }

        public IEnumerable<PegawaiSearchModel> Search()
        {
            //  ambil data
            var listAll = _pegawaiDal.ListData();
            if (listAll == null) return null;

            //  convert
            var result = listAll.Select(x => (PegawaiSearchModel)x);

            //  filter
            if (SearchFilter.UserKeyword != null)
                return
                    from c in result
                    where c.PegawaiName.ContainMultiWord(SearchFilter.UserKeyword)
                    select c;

            return result;
        }
    }
}
