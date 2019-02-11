using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnugerahBackend.Accounting.Dal;
using AnugerahBackend.Accounting.Model;
using FluentAssertions;
using Ics.Helper.Database;
using Ics.Helper.Extensions;
using Xunit;

namespace AnugerahUnitTest.Accounting.Dal
{

    public interface ILunasKasBonDalTest
    {
        void InsertTest();
        void UpdateTest();
        void DeletetTest();
        void GetDataTest();
        void ListDataTest();
    }

    public class LunasKasBonDalTest : ILunasKasBonDalTest
    {
        private ILunasKasBonDal _bpPiutangDal;

        public LunasKasBonDalTest()
        {
            _bpPiutangDal = new LunasKasBonDal();
        }

        private LunasKasBonModel LunasKasBonDataFactory()
        {
            var result = new LunasKasBonModel
            {
                LunasKasBonID = "A1",
                Tgl = "11-02-2019",
                Jam = "01:38:00",
                PihakKeduaID = "B1",
                PihakKeduaName= "",
                KasBonID = "C1",
                NilaiTotLunas = 250000
            };
            return result;
        }

        [Fact]
        public void InsertTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = LunasKasBonDataFactory();

                //  act
                _bpPiutangDal.Insert(expected);


                //  assert
            }
        }
        [Fact]
        public void UpdateTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = LunasKasBonDataFactory();
                _bpPiutangDal.Insert(expected);

                //  act
                _bpPiutangDal.Update(expected);

                //  assert
            }
        }

        [Fact]
        public void DeletetTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = LunasKasBonDataFactory();
                _bpPiutangDal.Insert(expected);

                //  act
                _bpPiutangDal.Delete("A1");

                //  assert
            }
        }

        [Fact]
        public void GetDataTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = LunasKasBonDataFactory();
                _bpPiutangDal.Insert(expected);

                //  act
                var actual = _bpPiutangDal.GetData("A1");

                //  assert
                actual.Should().BeEquivalentTo(expected);
            }
        }

        [Fact]
        public void ListDataTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected1 = LunasKasBonDataFactory();
                _bpPiutangDal.Insert(expected1);
                var expected2 = expected1.CloneObject();
                expected2.LunasKasBonID = "A2";
                _bpPiutangDal.Insert(expected2);

                var expected = new List<LunasKasBonModel>
                {
                    expected1, expected2
                };

                //  act
                var actual = _bpPiutangDal.ListData(expected1.Tgl, expected1.Tgl);

                //  assert
                actual.Should().BeEquivalentTo(expected);
            }
        }
    }
}
