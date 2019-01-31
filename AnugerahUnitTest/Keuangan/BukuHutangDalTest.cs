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

    public interface IBukuHutangDalTest
    {
        void Insert_ValidData_NoEx();
        void Update_ValidDat_NoEx();
        void Delete_ValidData_NoEx();
        void GetData_ValidData_NoEx();
        void ListData_ValidData_NoEx();
    }

    public class BukuHutangDalTest : IBukuHutangDalTest
    {
        private IBukuHutangDal _jenisTrsHutangirDal;

        public BukuHutangDalTest()
        {
            _jenisTrsHutangirDal = new BukuHutangDal();
        }

        BukuHutangModel BukuHutangDataFactory()
        {
            var result = new BukuHutangModel
            {
                BukuHutangID = "A1",
                TglBuku = "20-01-2019",
                JamBuku = "11:00:12",
                UserrID = "B1",
                PihakKetigaID = "C1",
                PihakKetigaName = "D1",
                NilaiHutang = 21000,
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
                var expected = BukuHutangDataFactory();

                //  act
                _jenisTrsHutangirDal.Insert(expected);

                //  assert
            }
        }

        [Fact]
        public void Update_ValidDat_NoEx()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrang
                var expected = BukuHutangDataFactory();

                //  act
                _jenisTrsHutangirDal.Update(expected);

                //  assert
            }
        }

        [Fact]
        public void Delete_ValidData_NoEx()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = BukuHutangDataFactory();
                _jenisTrsHutangirDal.Insert(expected);

                //  act
                _jenisTrsHutangirDal.Delete("A");

                //  assert
            }
        }

        [Fact]
        public void GetData_ValidData_NoEx()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = BukuHutangDataFactory();
                _jenisTrsHutangirDal.Insert(expected);

                //  act
                var actual = _jenisTrsHutangirDal.GetData("A1");

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
                var item1 = BukuHutangDataFactory();
                _jenisTrsHutangirDal.Insert(item1);
                var item2 = item1.CloneObject();
                item2.BukuHutangID = "A2";
                _jenisTrsHutangirDal.Insert(item2);
                var expected = new List<BukuHutangModel>
                {
                    item1, item2
                };

                //  act
                var actual = _jenisTrsHutangirDal.ListData(item1.TglBuku, item1.TglBuku);

                //  assert
                actual.Should().BeEquivalentTo(expected,
                    config => config
                        .Excluding(x => x.PihakKetigaName));
            }
        }

    }
}
