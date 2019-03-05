using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnugerahBackend.Penjualan.Model;
using AnugerahBackend.ReturJual.Dal;
using FluentAssertions;
using Ics.Helper.Database;
using Ics.Helper.Extensions;
using Xunit;

namespace AnugerahUnitTest.Penjualan
{
    public interface IReturJualDalTest
    {
        void InsertTest();
        void UpdateTest();
        void DeleteTest();
        void GetDataTest();
        void ListDataTest();
    }

    public class ReturJualDalTest : IReturJualDalTest
    {
        private IReturJualDal _returJualDal;
        public ReturJualDalTest()
        {
            _returJualDal = new ReturJualDal();
        }

        private ReturJualModel ReturJualDataFactory()
        {
            var result = new ReturJualModel
            {
                ReturJualID = "A1",
                Tgl = "23-02-2019",
                Jam = "08:00:21",
                PenjualanID = "B1",
                BuyerName = "C1",
                Keterangan = "D1",
                TotalRetur = 400,
            };
            return result;
        }

        [Fact]
        public void InsertTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrang
                var expected = ReturJualDataFactory();

                //  act
                _returJualDal.Insert(expected);

                //  assert
            }
        }

        [Fact]
        public void UpdateTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = ReturJualDataFactory();

                //  act
                _returJualDal.Update(expected);

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
                _returJualDal.Delete("A1");

            }
        }

        [Fact]
        public void GetDataTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = ReturJualDataFactory();
                _returJualDal.Insert(expected);

                //  act
                var actual = _returJualDal.GetData("A1");

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
                var expected1 = ReturJualDataFactory();
                var expected2 = expected1.CloneObject();
                expected2.ReturJualID = "A2";
                _returJualDal.Insert(expected1);
                _returJualDal.Insert(expected2);
                var expected = new List<ReturJualModel>
                {
                    expected1, expected2
                };

                //  act
                var actual = _returJualDal.ListData("23-02-2019", "23-02-2019");

                //  assert
                actual.Should().BeEquivalentTo(expected);
            }
        }
    }
}
