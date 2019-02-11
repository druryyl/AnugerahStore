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
    public interface IBPKasDetilDalTest
    {
        void InsertTest();
        void DeleteTest();
        void ListDataTest();
    }

    public class BPKasDetilDalTest : IBPKasDetilDalTest
    {
        private IBPKasDetilDal _bpKasDetilDal;
        public BPKasDetilDalTest()
        {
            _bpKasDetilDal = new BPKasDetilDal();
        }

        private BPKasDetilModel BPKasDetilDataFactory()
        {
            var result = new BPKasDetilModel
            {
                BPKasID = "A1",
                BPKasDetilID = "B1",
                JenisKasID = "C1",
                JenisKasName = "",
                NilaiKasMasuk = 51000,
                NilaiKasKeluar = 41000
            };
            return result;
        }

        [Fact]
        public void InsertTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = BPKasDetilDataFactory();

                //  act
                _bpKasDetilDal.Insert(expected);

                //  assert

            }
        }

        [Fact]
        public void DeleteTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = BPKasDetilDataFactory();
                _bpKasDetilDal.Insert(expected);

                //  act
                _bpKasDetilDal.Delete("A1");

                //  assert
            }
        }

        [Fact]
        public void ListDataTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected1 = BPKasDetilDataFactory();
                _bpKasDetilDal.Insert(expected1);
                var expected2 = expected1.CloneObject();
                expected2.BPKasDetilID = "B2";
                _bpKasDetilDal.Insert(expected2);
                var expected = new List<BPKasDetilModel>
                {
                    expected1, expected2
                };

                //  act
                var actual = _bpKasDetilDal.ListData("A1");

                //  assert
                actual.Should().BeEquivalentTo(expected);
            }
        }
    }
}
