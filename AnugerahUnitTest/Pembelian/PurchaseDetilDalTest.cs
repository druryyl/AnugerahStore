using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnugerahBackend.Pembelian.Dal;
using AnugerahBackend.Pembelian.Model;
using FluentAssertions;
using Ics.Helper.Database;
using Ics.Helper.Extensions;
using Xunit;

namespace AnugerahUnitTest.Pembelian
{
    public interface IPurchaseDetilDalTest
    {
        void InsertTest();
        void DeleteTest();
        void ListDataTest();
    }

    public class PurchaseDetilDalTest : IPurchaseDetilDalTest
    {
        private IPurchaseDetilDal _purchaseDal;

        public PurchaseDetilDalTest()
        {
            _purchaseDal = new PurchaseDetilDal();
        }

        private PurchaseDetilModel PurchaseDetilDataFactory()
        {
            var result = new PurchaseDetilModel
            {
                PurchaseID = "A1",
                PurchaseDetilID = "B1",
                BrgID = "C1",
                BrgName = "",
                Harga = 1,
                NoUrut = 2,
                Qty = 3,
                Diskon = 200,
                SubTotal = 2121,
                TaxProsen = 7.6,
                TaxRupiah = 122
            };
            return result;
        }

        [Fact]
        public void InsertTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrang
                var expected = PurchaseDetilDataFactory();

                //  act
                _purchaseDal.Insert(expected);

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
                _purchaseDal.Delete("A1");

            }
        }

        [Fact]
        public void ListDataTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected1 = PurchaseDetilDataFactory();
                var expected2 = expected1.CloneObject();
                expected2.PurchaseDetilID = "A2";
                _purchaseDal.Insert(expected1);
                _purchaseDal.Insert(expected2);
                var expected = new List<PurchaseDetilModel>
                {
                    expected1, expected2
                };

                //  act
                var actual = _purchaseDal.ListData("A1");

                //  assert
                actual.Should().BeEquivalentTo(expected);
            }
        }
    }
}
