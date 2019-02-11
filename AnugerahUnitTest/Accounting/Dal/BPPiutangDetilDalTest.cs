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
    public interface IBPPiutangDetilDalTest
    {
        void InsertTest();
        void DeleteTest();
        void ListDataTest();
    }

    public class BPPiutangDetilDalTest : IBPPiutangDetilDalTest
    {
        private IBPPiutangDetilDal _bpPiutangDetilDal;
        public BPPiutangDetilDalTest()
        {
            _bpPiutangDetilDal = new BPPiutangDetilDal();
        }

        private BPPiutangDetilModel BPPiutangDetilDataFactory()
        {
            var result = new BPPiutangDetilModel
            {
                BPPiutangID = "A1",
                BPPiutangDetilID = "B1",
                ReffID = "C1",
                Tgl = "11-02-2019",
                Jam = "03:21:00",
                Keterangan = "D1",
                NilaiPiutang = 51000,
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
                var expected = BPPiutangDetilDataFactory();

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
                var expected = BPPiutangDetilDataFactory();
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
                var expected1 = BPPiutangDetilDataFactory();
                _bpPiutangDetilDal.Insert(expected1);
                var expected2 = expected1.CloneObject();
                expected2.BPPiutangDetilID = "B2";
                _bpPiutangDetilDal.Insert(expected2);
                var expected = new List<BPPiutangDetilModel>
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
