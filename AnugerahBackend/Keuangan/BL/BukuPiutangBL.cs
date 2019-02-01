using AnugerahBackend.Keuangan.Dal;
using AnugerahBackend.Keuangan.Model;
using AnugerahBackend.Support;
using AnugerahBackend.Support.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Keuangan.BL
{
    public interface IBukuPiutangBL : ISearchData<BukuPiutangSearchModel>
    {
        void GenPiutang(BukuKasModel bukuKas);
        void GenPiutangLunas(BukuKasModel bukuKas);
    }

    public class BukuPiutangBL : IBukuPiutangBL
    {
        private IBukuPiutangDal _bukuPiutangDal;
        private IBukuPiutangLunasDal _bukuPiutangLunasDal;
        private IBukuHutangLunasDal _bukuHutangLunasDal;

        private IParameterNoBL _paramNoBL;

        public BukuPiutangBL()
        {
            _bukuPiutangDal = new BukuPiutangDal();
            _bukuPiutangLunasDal = new BukuPiutangLunasDal();
            _bukuHutangLunasDal = new BukuHutangLunasDal();
            _paramNoBL = new ParameterNoBL();
        }

        public BukuPiutangBL(IBukuPiutangDal injBukuPiutangDal,
            IBukuPiutangLunasDal injBukuPiutangLunasDal,
            IBukuHutangLunasDal injBukuHutangLunasDal,
            IParameterNoBL injParamNoBL)
        {
            _bukuPiutangDal = injBukuPiutangDal;
            _bukuPiutangLunasDal = injBukuPiutangLunasDal;
            _bukuHutangLunasDal = injBukuHutangLunasDal;
            _paramNoBL = injParamNoBL;
        }

        public BukuPiutangModel GetData(string bukuPiutangID)
        {
            BukuPiutangModel result = null;
            result = _bukuPiutangDal.GetData(bukuPiutangID);
            if (result != null)
                result.ListLunas = _bukuPiutangLunasDal.ListData(bukuPiutangID);

            return result;
        }

        private string GetBukuPiutangID(BukuKasModel bukuKas)
        {
            string result = null;
            var listPiutangDetil = _bukuPiutangLunasDal.ListData(bukuKas);
            if (listPiutangDetil != null)
                result = listPiutangDetil.First().BukuPiutangID;
            return result;
        }

        public void GenPiutang(BukuKasModel bukuKas)
        {
            //  piutang, nilai kas harus minus
            if (bukuKas.NilaiKasMasuk - bukuKas.NilaiKasKeluar >= 0)
                throw new ArgumentException("Generate Piutang harus Kas Keluar");

            //  cari bukuPiutangID-nya
            var bukuPiutangID = GetBukuPiutangID(bukuKas);
            if(bukuPiutangID == null)
                bukuPiutangID = GenNewBukuPiutangID();

            //  ambil data bukuPiutang
            var bukuPiutang = GetData(bukuPiutangID);
            if(bukuPiutang == null)
            {
                bukuPiutang = new BukuPiutangModel
                {
                    BukuPiutangID = bukuPiutangID,
                    TglBuku = bukuKas.TglBuku,
                    JamBuku = bukuKas.JamBuku,
                    UserrID = bukuKas.UserrID,
                    PihakKetigaID = bukuKas.PihakKetigaID,
                    NilaiPiutang = bukuKas.NilaiKasKeluar - bukuKas.NilaiKasMasuk,
                    NilaiSisa = bukuKas.NilaiKasKeluar - bukuKas.NilaiKasMasuk,
                    Keterangan = bukuKas.Keterangan,
                    BukuKasID = bukuKas.BukuKasID,
                };

                var bukuPiutangDetil = new BukuPiutangLunasModel
                {
                    BukuPiutangLunasID = kodePiutang + "-01",
                    BukuPiutangID = kodePiutang,
                    TglLunas = bukuKas.TglBuku,
                    JamLunas = bukuKas.JamBuku,
                    NilaiLunas = bukuKas.NilaiKasKeluar - bukuKas.NilaiKasMasuk
                };
            }


            //  hapus semua pencatatan piutang lunas (detil) atas bukuKas ini
            var listPiutangLunas = _bukuPiutangLunasDal.ListData(bukuKas);
            if (listPiutangLunas != null)
                foreach (var item in listPiutangLunas)
                    _bukuPiutangLunasDal.Delete(item.BukuPiutangLunasID);

            //  hapus semua pencatatan hutang lunas (detil) atas bukuKas ini
            var listHutangLunas = _bukuHutangLunasDal.ListData(bukuKas);
            if (listHutangLunas != null)
                foreach (var item in listHutangLunas)
                    _bukuHutangLunasDal.Delete(item.BukuHutangLunasID);

            //  cari kodePiutang (kasus save ulang)
            var kodePiutang = "";
            if (listPiutangLunas != null)
                kodePiutang = listPiutangLunas.First().BukuPiutangID;
            else
                kodePiutang = GenNewBukuPiutangID();

            //  insert header
            var bukuPiutang = new BukuPiutangModel
            {
                BukuPiutangID = kodePiutang,
                TglBuku = bukuKas.TglBuku,
                JamBuku = bukuKas.JamBuku,
                UserrID = bukuKas.UserrID,
                PihakKetigaID = bukuKas.PihakKetigaID,
                NilaiPiutang = bukuKas.NilaiKasKeluar - bukuKas.NilaiKasMasuk,
                NilaiSisa = bukuKas.NilaiKasKeluar - bukuKas.NilaiKasMasuk,
                Keterangan = bukuKas.Keterangan,
                BukuKasID = bukuKas.BukuKasID,
            };
            _bukuPiutangDal.Delete(kodePiutang);
            _bukuPiutangDal.Insert(bukuPiutang);
            
            //  insert detil
            var bukuPiutangDetil = new BukuPiutangLunasModel
            {
                BukuPiutangLunasID = kodePiutang + "-01",
                BukuPiutangID = kodePiutang,
                TglLunas = bukuKas.TglBuku,
                JamLunas = bukuKas.JamBuku,
                NilaiLunas = bukuKas.NilaiKasKeluar - bukuKas.NilaiKasMasuk
            };
        }

        private string GenNewBukuPiutangID()
        {
            var prefix = "PT" + DateTime.Now.ToString("yyMM");
            var result = _paramNoBL.GenNewID(prefix, 10);
            return result;
        }

        public void GenPiutangLunas(BukuKasModel bukuKas)
        {
            throw new NotImplementedException();
        }


        #region SEARCH
        public IEnumerable<BukuPiutangSearchModel> Search()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BukuPiutangSearchModel> Search(string keyword)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BukuPiutangSearchModel> Search(string keyword, string tgl1, string tgl2)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
