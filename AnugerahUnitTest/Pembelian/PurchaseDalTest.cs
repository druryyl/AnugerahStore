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
    public interface IPurchaseDalTest
    {
        void InsertTest();
        void UpdateTest();
        void DeleteTest();
        void GetDataTest();
        void ListDataTest();
    }

    public class PurchaseDalTest : IPurchaseDalTest
    {
        private IPurchaseDal _purchaseDal;
        public PurchaseDalTest()
        {
            _purchaseDal = new PurchaseDal();
        }

        private PurchaseModel PurchaseDataFactory()
        {
            var result = new PurchaseModel
            {
                PurchaseID = "A1",
                Tgl = "23-02-2019",
                Jam = "08:00:21",
                SupplierID = "B1",
                SupplierName = "",
                BiayaLain = 100,
                Diskon = 200,
                GrandTotal = 300,
                Keterangan = "C1",
                TotalHarga = 400
            };
            return result;
        }

        [Fact]
        public void InsertTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrang
                var expected = PurchaseDataFactory();

                //  act
                _purchaseDal.Insert(expected);

                //  assert
            }
        }

        [Fact]
        public void UpdateTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = PurchaseDataFactory();

                //  act
                _purchaseDal.Update(expected);

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
        public void GetDataTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = PurchaseDataFactory();
                _purchaseDal.Insert(expected);

                //  act
                var actual = _purchaseDal.GetData("A1");

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
                var expected1 = PurchaseDataFactory();
                var expected2 = expected1.CloneObject();
                expected2.PurchaseID = "A2";
                _purchaseDal.Insert(expected1);
                _purchaseDal.Insert(expected2);
                var expected = new List<PurchaseModel>
                {
                    expected1, expected2
                };

                //  act
                var actual = _purchaseDal.ListData("23-02-2019", "23-02-2019");

                //  assert
                actual.Should().BeEquivalentTo(expected);
            }
        }
    }
}
