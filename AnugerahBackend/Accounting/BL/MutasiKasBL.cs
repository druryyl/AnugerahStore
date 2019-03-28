using AnugerahBackend.Accounting.Dal;
using AnugerahBackend.Accounting.Model;
using AnugerahBackend.Support;
using AnugerahBackend.Support.BL;
using Ics.Helper.Database;
using Ics.Helper.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Accounting.BL
{
    public interface IMutasiKasBL
    {
        MutasiKasModel Save(MutasiKasModel model);
        void Delete(string id);
        MutasiKasModel GetData(string id);
        IEnumerable<MutasiKasModel> ListData(string tgl1, string tgl2);
    }

    public class MutasiKasDependency
    {
        public IMutasiKasDal MutasiKasDal { get; set; }
        public IParameterNoBL ParamNoBL { get; set; }
        public IJenisKasDal JenisKasDal { get; set; }
        public IPegawaiDal PegawaiDal { get; set; }
    }

    public class MutasiKasBL : IMutasiKasBL, ISearch<MutasiKasSearchModel>
    {
        private readonly MutasiKasDependency dep;

        public MutasiKasBL()
        {
            dep = new MutasiKasDependency
            {
                MutasiKasDal = new MutasiKasDal(),
                ParamNoBL = new ParameterNoBL(),
                JenisKasDal = new JenisKasDal()
            };
            SearchFilter = new SearchFilter
            {
                IsDate = true,
                Date1 = DateTime.Now,
                Date2 = DateTime.Now
            };
        }
        public MutasiKasBL(MutasiKasDependency injDep)
        {
            dep = injDep;
        }

        public MutasiKasModel Save(MutasiKasModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            //  cek pegawai
            var peg = dep.PegawaiDal.GetData(model.PegawaiID);
            if (peg == null)
                throw new ArgumentException("PegawaiID invalid");
            else
                model.PegawaiName = peg.PegawaiName;

            //  jenis kas asal
            var jenisKas = dep.JenisKasDal.GetData(model.JenisKasIDAsal);
            if (jenisKas == null)
                throw new ArgumentException("JenisKas Asal invalid");
            else
                model.JenisKasNameAsal = jenisKas.JenisKasName;

            //  jenis kas tujuan
            jenisKas = dep.JenisKasDal.GetData(model.JenisKasIDTujan);
            if (jenisKas == null)
                throw new ArgumentException("JenisKas Tujuan invalid");
            else
                model.JenisKasNameTujuan = jenisKas.JenisKasName;

            //  jenis kas asal dan tujuan harus beda
            if (model.JenisKasIDAsal == model.JenisKasIDTujan)
                throw new ArgumentException("JenisKas Asal dan Tujuan sama");

            //  nilai kas tidak boleh Nol
            if (model.NilaiKas == 0)
                throw new ArgumentException("Nilai Kas nol");

            //  proses save
            using (var trans = TransHelper.NewScope())
            {
                //  generate id baru (jika kosong)
                if (model.MutasiKasID.Trim() == "")
                    model.MutasiKasID = GenNewID();

                //  hapus data lama
                dep.MutasiKasDal.Delete(model.MutasiKasID);

                //  insert data lama
                dep.MutasiKasDal.Insert(model);
                
                //  commit trans
                trans.Complete();
            }
            return model;
        }

        private string GenNewID()
        {
            var prefix = "MK" + DateTime.Now.ToString("yyMM");
            var result = dep.ParamNoBL.GenNewID(prefix, 10);
            return result;
        }

        public void Delete(string id)
        {
            dep.MutasiKasDal.Delete(id);
        }

        public MutasiKasModel GetData(string id)
        {
            return dep.MutasiKasDal.GetData(id);
        }

        public IEnumerable<MutasiKasModel> ListData(string tgl1, string tgl2)
        {
            return dep.MutasiKasDal.ListData(tgl1, tgl2);
        }

        public SearchFilter SearchFilter { get; set; }

        public IEnumerable<MutasiKasSearchModel> Search()
        {
            var listData = dep.MutasiKasDal.ListData(SearchFilter.TglDMY1, SearchFilter.TglDMY2);
            if (listData == null) return null;

            //  convert ke SearchModel
            var result = listData.Select(x => (MutasiKasSearchModel)x);

            if (SearchFilter.UserKeyword != null)
                return
                    from c in result
                    where c.Keterangan.ContainMultiWord(SearchFilter.UserKeyword)
                    select c;

            return result;
        }
    }
}
