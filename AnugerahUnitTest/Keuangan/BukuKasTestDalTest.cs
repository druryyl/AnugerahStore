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

    public interface IBukuKasDalTest
    {
        void Insert_ValidData_NoEx();
        void Update_ValidDat_NoEx();
        void Delete_ValidData_NoEx();
        void GetData_ValidData_NoEx();
        void ListData_ValidData_NoEx();
    }

    public class BukuKasDalTest : IBukuKasDalTest
    {
        private IBukuKasDal _jenisTrsKasirDal;

        public BukuKasDalTest()
        {
            _jenisTrsKasirDal = new BukuKasDal();
        }

        BukuKasModel BukuKasDataFactory()
        {
            var result = new BukuKasModel
            {
                BukuKasID = "A1",
                TglBuku = "20-01-2019",
                JamBuku = "11:00:12",
                UserrID = "B2",
                NilaiKasMasuk = 21000,
                NilaiKasKeluar = 1000,
                ReffID = "C2",
                Keterangan = "D2",
                PihakKetigaID = "E2"
            };
            return result;
        }

        [Fact]
        public void Insert_ValidData_NoEx()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = BukuKasDataFactory();

                //  act
                _jenisTrsKasirDal.Insert(expected);

                //  assert
            }
        }

        [Fact]
        public void Update_ValidDat_NoEx()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrang
                var expected = BukuKasDataFactory();

                //  act
                _jenisTrsKasirDal.Update(expected);

                //  assert
            }
        }

        [Fact]
        public void Delete_ValidData_NoEx()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = BukuKasDataFactory();
                _jenisTrsKasirDal.Insert(expected);

                //  act
                _jenisTrsKasirDal.Delete("A");

                //  assert
            }
        }

        [Fact]
        public void GetData_ValidData_NoEx()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = BukuKasDataFactory();
                _jenisTrsKasirDal.Insert(expected);

                //  act
                var actual = _jenisTrsKasirDal.GetData("A1");

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
                var item1 = BukuKasDataFactory();
                _jenisTrsKasirDal.Insert(item1);
                var item2 = item1.CloneObject();
                item2.BukuKasID = "A2";
                _jenisTrsKasirDal.Insert(item2);
                var expected = new List<BukuKasModel>
                {
                    item1, item2
                };

                //  act
                var actual = _jenisTrsKasirDal.ListData(item1.TglBuku, item1.TglBuku);

                //  assert
                //  assert
                actual.Should().BeEquivalentTo(expected,
                    config => config
                        .Excluding(x => x.PihakKetigaName));
            }
        }

    }
}
