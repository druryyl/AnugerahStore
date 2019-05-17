using AnugerahBackend.Penjualan.Dal;
using AnugerahBackend.Penjualan.Model;
using FluentAssertions;
using Ics.Helper.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AnugerahUnitTest.Penjualan.Dal
{
    public interface IPriceQtyDalTest
    {
        void InsertTest();
        void DeleteTest();
        void ListDataTest();
    }
    public class PriceQtyDalTest : IPriceQtyDalTest
    {
        private readonly IPriceQtyDal _sut;

        public PriceQtyDalTest()
        {
            _sut = new PriceQtyDal();
        }

        PriceQtyModel PriceQtyFactory()
        {
            var result = new PriceQtyModel
            {
                PriceID = "A",
                Qty = 1,
                Harga = 5,
                Diskon = 2
            };
            return result;
        }

        [Fact]
        public void InsertTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = PriceQtyFactory();

                //  act
                _sut.Insert(expected);

                //  assert
            }
        }

        [Fact]
        public void DeleteTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = PriceQtyFactory();
                _sut.Insert(expected);
                expected.Harga = 7;

                //  act
                _sut.Delete("A");

                //  assert
            }
        }

        [Fact]
        public void ListDataTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected1 = PriceQtyFactory();
                var expected2 = PriceQtyFactory();
                expected2.Qty = 10;
                expected2.Harga = 8;
                var expected = new List<PriceQtyModel>
                {
                    expected1, expected2
                };
                _sut.Insert(expected1);
                _sut.Insert(expected2);

                //  act
                var actual = _sut.ListData("A");

                //  assert
                actual.Should().BeEquivalentTo(expected);
            }
        }
    }
}
