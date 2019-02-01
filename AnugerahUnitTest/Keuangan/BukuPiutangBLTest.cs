using AnugerahBackend.Keuangan.BL;
using AnugerahBackend.Keuangan.Dal;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahUnitTest.Keuangan
{
    public interface IBukuPiutangBLTest
    {
        void GenPiutang_Standard_Berhasil();
        void GenPiutang_DariBukuKas_SudahAdaPelunasan_Gagal();
        void GenPiutang_DariBukuKas_NilaiPlus_Gagal();

        void GenLunas_Standard_Berhasil();
        void GenLunas_DariBukuKas_NilaiMinus_Gagal();
        void GenLunas_DariBukuKas_MelebihiNilaiPiutang_Gagal();
        void GenLunas_DariBukuKas_TglLunasMendahuluiTglPiutang_Gagal();
    }

    public class BukuPiutangBLTest : IBukuPiutangBLTest
    {
        private IBukuPiutangBL _bukuPiutangBL;
        private Mock<IBukuPiutangDal> _bukuPiutangDal;
        private Mock<IBukuPiutangLunasDal> _bukuPiutangLunasDal;

        public BukuPiutangBLTest()
        {
            _bukuPiutangDal = new Mock<IBukuPiutangDal>();
            _bukuPiutangBL = new BukuPiutangBL(_bukuPiutangDal.Object);
        }

        public void GenPiutang_Standard_Berhasil()
        {
            throw new NotImplementedException();
        }

        public void GenPiutang_DariBukuKas_SudahAdaPelunasan_Gagal()
        {
            throw new NotImplementedException();
        }

        public void GenPiutang_DariBukuKas_NilaiPlus_Gagal()
        {
            throw new NotImplementedException();
        }


        public void GenLunas_Standard_Berhasil()
        {
            throw new NotImplementedException();
        }

        public void GenLunas_DariBukuKas_NilaiMinus_Gagal()
        {
            throw new NotImplementedException();
        }

        public void GenLunas_DariBukuKas_MelebihiNilaiPiutang_Gagal()
        {
            throw new NotImplementedException();
        }

        public void GenLunas_DariBukuKas_TglLunasMendahuluiTglPiutang_Gagal()
        {
            throw new NotImplementedException();
        }
    }
}
