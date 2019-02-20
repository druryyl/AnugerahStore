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

    public interface IBPHutangDalTest
    {
        void InsertTest();
        void UpdateTest();
        void DeletetTest();
        void GetDataTest();
        void ListDataTest();
    }

    public class BPHutangDalTest : IBPHutangDalTest
    {
        private IBPHutangDal _bpHutangDal;

        public BPHutangDalTest()
        {
            _bpHutangDal = new BPHutangDal();
        }

        private BPHutangModel BPHutangDataFactory()
        {
            var result = new BPHutangModel
            {
                BPHutangID = "A1",
                Tgl = "11-02-2019",
                Jam = "01:38:00",
                PihakKeduaID = "B1",
                PihakKeduaName = "",
                Keterangan = "C1",
                NilaiHutang = 300000,
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
                var expected = BPHutangDataFactory();

                //  act
                _bpHutangDal.Insert(expected);


                //  assert
            }
        }
        [Fact]
        public void UpdateTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = BPHutangDataFactory();
                _bpHutangDal.Insert(expected);

                //  act
                _bpHutangDal.Update(expected);

                //  assert
            }
        }

        [Fact]
        public void DeletetTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = BPHutangDataFactory();
                _bpHutangDal.Insert(expected);

                //  act
                _bpHutangDal.Delete("A1");

                //  assert
            }
        }

        [Fact]
        public void GetDataTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = BPHutangDataFactory();
                _bpHutangDal.Insert(expected);

                //  act
                var actual = _bpHutangDal.GetData("A1");

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
                var expected1 = BPHutangDataFactory();
                _bpHutangDal.Insert(expected1);
                var expected2 = expected1.CloneObject();
                expected2.BPHutangID = "A2";
                _bpHutangDal.Insert(expected2);

                var expected = new List<BPHutangModel>
                {
                    expected1, expected2
                };

                //  act
                var actual = _bpHutangDal.ListData(expected1.Tgl, expected1.Tgl);

                //  assert
                actual.Should().BeEquivalentTo(expected);
            }
        }
    }
}
