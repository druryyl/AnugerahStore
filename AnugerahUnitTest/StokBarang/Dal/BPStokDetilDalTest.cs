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
    public interface IBPStokDetilDalTest
    {
        void InsertTest();
        void DeleteTest();
        void ListDataTest();
    }

    public class BPStokDetilDalTest : IBPStokDetilDalTest
    {
        private IBPStokDetilDal _bpStokDetilDal;

        public BPStokDetilDalTest()
        {
            _bpStokDetilDal = new BPStokDetilDal();
        }

        private BPStokDetilModel BPStokDetilDataFactory()
        {
            var result = new BPStokDetilModel
            {
                BPStokID = "A1",
                BPStokDetilID = "B1",
                NoUrut = 2,
                ReffID = "C1",
                Tgl = "20-02-2019",
                Jam = "21:12:00",
                QtyOut = 3,
                HargaJual = 55125,
            };
            return result;
        }

        [Fact]
        public void InsertTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = BPStokDetilDataFactory();

                //  act
                _bpStokDetilDal.Insert(expected);

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
                _bpStokDetilDal.Delete("A1");

                //  assert
            }
        }

        [Fact]
        public void ListDataTest()
        {
            //  arrange
            var expected1 = BPStokDetilDataFactory();
            var expected2 = expected1.CloneObject();
            expected2.BPStokDetilID = "B2";
            _bpStokDetilDal.Insert(expected1);
            _bpStokDetilDal.Insert(expected2);
            var expected = new List<BPStokDetilModel>
            {
                expected1, expected2
            };

            //  act
            var actual = _bpStokDetilDal.ListData("A1");

            //  assert
            actual.Should().BeEquivalentTo(expected);
        }
    }
}

