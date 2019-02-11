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
    public interface ILunasKasBonDetilDalTest
    {
        void InsertTest();
        void DeleteTest();
        void ListDataTest();
    }

    public class LunasKasBonDetilDalTest : ILunasKasBonDetilDalTest
    {
        private ILunasKasBonDetilDal _bpPiutangDetilDal;
        public LunasKasBonDetilDalTest()
        {
            _bpPiutangDetilDal = new LunasKasBonDetilDal();
        }

        private LunasKasBonDetilModel LunasKasBonDetilDataFactory()
        {
            var result = new LunasKasBonDetilModel
            {
                LunasKasBonID = "A1",
                LunasKasBonDetilID = "B1",
                JenisLunasID = "D1",
                JenisLunasName = "",
                NilaiLunas = 41000
            };
            return result;
        }

        [Fact]
        public void InsertTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = LunasKasBonDetilDataFactory();

                //  act
                _bpPiutangDetilDal.Insert(expected);

                //  assert

            }
        }

        [Fact]
        public void DeleteTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = LunasKasBonDetilDataFactory();
                _bpPiutangDetilDal.Insert(expected);

                //  act
                _bpPiutangDetilDal.Delete("A1");

                //  assert
            }
        }

        [Fact]
        public void ListDataTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected1 = LunasKasBonDetilDataFactory();
                _bpPiutangDetilDal.Insert(expected1);
                var expected2 = expected1.CloneObject();
                expected2.LunasKasBonDetilID = "B2";
                _bpPiutangDetilDal.Insert(expected2);
                var expected = new List<LunasKasBonDetilModel>
                {
                    expected1, expected2
                };

                //  act
                var actual = _bpPiutangDetilDal.ListData("A1");

                //  assert
                actual.Should().BeEquivalentTo(expected);
            }
        }
    }
}
