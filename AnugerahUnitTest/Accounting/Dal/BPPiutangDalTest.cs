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

    public interface IBPPiutangDalTest
    {
        void InsertTest();
        void UpdateTest();
        void DeletetTest();
        void GetDataTest();
        void ListDataTest();
    }

    public class BPPiutangDalTest : IBPPiutangDalTest
    {
        private IBPPiutangDal _bpPiutangDal;

        public BPPiutangDalTest()
        {
            _bpPiutangDal = new BPPiutangDal();
        }

        private BPPiutangModel BPPiutangDataFactory()
        {
            var result = new BPPiutangModel
            {
                BPPiutangID = "A1",
                Tgl = "11-02-2019",
                Jam = "01:38:00",
                PihakKeduaID = "B1",
                Keterangan = "C1",
                NilaiPiutang = 300000,
                NilaiLunas = 250000
            };
            return result;
        }

        [Fact]
        public void InsertTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = BPPiutangDataFactory();

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
                var expected = BPPiutangDataFactory();
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
                var expected = BPPiutangDataFactory();
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
                var expected = BPPiutangDataFactory();
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
                var expected1 = BPPiutangDataFactory();
                _bpPiutangDal.Insert(expected1);
                var expected2 = expected1.CloneObject();
                expected2.BPPiutangID = "A2";
                _bpPiutangDal.Insert(expected2);

                var expected = new List<BPPiutangModel>
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
