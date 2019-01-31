using AnugerahBackend.Keuangan.Dal;
using AnugerahBackend.Keuangan.Model;
using FluentAssertions;
using Ics.Helper.Database;
using Ics.Helper.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AnugerahUnitTest.Keuangan
{

    public interface IBukuPiutangDalTest
    {
        void Insert_ValidData_NoEx();
        void Update_ValidDat_NoEx();
        void Delete_ValidData_NoEx();
        void GetData_ValidData_NoEx();
        void ListData_ValidData_NoEx();
    }

    public class BukuPiutangDalTest : IBukuPiutangDalTest
    {
        private IBukuPiutangDal _jenisTrsPiutangirDal;

        public BukuPiutangDalTest()
        {
            _jenisTrsPiutangirDal = new BukuPiutangDal();
        }

        BukuPiutangModel BukuPiutangDataFactory()
        {
            var result = new BukuPiutangModel
            {
                BukuPiutangID = "A1",
                TglBuku = "20-01-2019",
                JamBuku = "11:00:12",
                UserrID = "B1",
                PihakKetigaID = "C1",
                PihakKetigaName = "D1",
                NilaiPiutang = 21000,
                NilaiSisa = 1000,
                Keterangan = "E1",
                BukuKasID = "F1"
            };
            return result;
        }

        [Fact]
        public void Insert_ValidData_NoEx()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = BukuPiutangDataFactory();

                //  act
                _jenisTrsPiutangirDal.Insert(expected);

                //  assert
            }
        }

        [Fact]
        public void Update_ValidDat_NoEx()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrang
                var expected = BukuPiutangDataFactory();

                //  act
                _jenisTrsPiutangirDal.Update(expected);

                //  assert
            }
        }

        [Fact]
        public void Delete_ValidData_NoEx()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = BukuPiutangDataFactory();
                _jenisTrsPiutangirDal.Insert(expected);

                //  act
                _jenisTrsPiutangirDal.Delete("A");

                //  assert
            }
        }

        [Fact]
        public void GetData_ValidData_NoEx()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = BukuPiutangDataFactory();
                _jenisTrsPiutangirDal.Insert(expected);

                //  act
                var actual = _jenisTrsPiutangirDal.GetData("A1");

                //  assert
                actual.Should().BeEquivalentTo(expected,
                    config => config
                        .Excluding(x => x.PihakKetigaName));
            }
        }

        [Fact]
        public void ListData_ValidData_NoEx()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var item1 = BukuPiutangDataFactory();
                _jenisTrsPiutangirDal.Insert(item1);
                var item2 = item1.CloneObject();
                item2.BukuPiutangID = "A2";
                _jenisTrsPiutangirDal.Insert(item2);
                var expected = new List<BukuPiutangModel>
                {
                    item1, item2
                };

                //  act
                var actual = _jenisTrsPiutangirDal.ListData(item1.TglBuku, item1.TglBuku);

                //  assert
                actual.Should().BeEquivalentTo(expected,
                    config => config
                        .Excluding(x => x.PihakKetigaName));
            }
        }

    }
}
