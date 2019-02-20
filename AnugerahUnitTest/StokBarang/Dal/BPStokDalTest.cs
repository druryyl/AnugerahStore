using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnugerahBackend.StokBarang.Dal;
using AnugerahBackend.StokBarang.Model;
using FluentAssertions;
using Ics.Helper.Database;
using Ics.Helper.Extensions;
using Xunit;

namespace AnugerahUnitTest.StokBarang.Dal
{
    public interface IBPStokDalTest
    {
        void InsertTest();
        void UpdateTest();
        void DeleteTest();
        void GetDataTest();
        void ListDataTest();
    }
    public class BPStokDalTest : IBPStokDalTest
    {
        private IBPStokDal _bpStokDal;

        public BPStokDalTest()
        {
            _bpStokDal = new BPStokDal();
        }

        private BPStokModel BPStokDataFactory()
        {
            var result = new BPStokModel
            {
                BPStokID = "A1",
                ReffID = "B1",
                Tgl = "20-02-2019",
                Jam = "20:15:00",
                BrgID = "C1",
                BrgName = "",
                NilaiHpp = 12,
                QtyIn = 13,
                QtySisa = 14
            };
            return result;
        }

        [Fact]
        public void InsertTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = BPStokDataFactory();

                //  act
                _bpStokDal.Insert(expected);

                //  assert
            }
        }

        [Fact]
        public void UpdateTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = BPStokDataFactory();

                //  act
                _bpStokDal.Update(expected);

                //  assert
            }
        }

        [Fact]
        public void DeleteTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange


                //  act
                _bpStokDal.Delete("A1");

                //  assert
            }
        }

        [Fact]
        public void GetDataTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = BPStokDataFactory();
                _bpStokDal.Insert(expected);

                //  act
                var actual = _bpStokDal.GetData("A1");

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
                var expected1 = BPStokDataFactory();
                _bpStokDal.Insert(expected1);
                var expected2 = expected1.CloneObject();
                expected2.BPStokID = "A2";
                var expected = new List<BPStokModel>
                {
                    expected1, expected2
                };
                _bpStokDal.Insert(expected2);

                //  act
                var actual = _bpStokDal.ListData("C1");

                //  assert
                actual.Should().BeEquivalentTo(expected);
            }
        }
    }
}
