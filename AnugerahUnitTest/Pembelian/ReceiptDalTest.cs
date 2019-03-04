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
    public interface IReceiptDalTest
    {
        void InsertTest();
        void UpdateTest();
        void DeleteTest();
        void GetDataTest();
        void ListDataTest();
    }

    public class ReceiptDalTest : IReceiptDalTest
    {
        private IReceiptDal _purchaseDal;
        public ReceiptDalTest()
        {
            _purchaseDal = new ReceiptDal();
        }

        private ReceiptModel ReceiptDataFactory()
        {
            var result = new ReceiptModel
            {
                ReceiptID = "A1",
                Tgl = "23-02-2019",
                Jam = "08:00:21",
                PurchaseID = "B1",
                SupplierID = "C1",
                SupplierName = "",
                TotalHarga = 400,
                Diskon = 200,
                BiayaLain = 100,
                GrandTotal = 300,
                Keterangan = "D1",
            };
            return result;
        }

        [Fact]
        public void InsertTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrang
                var expected = ReceiptDataFactory();

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
                var expected = ReceiptDataFactory();

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
                var expected = ReceiptDataFactory();
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
                var expected1 = ReceiptDataFactory();
                var expected2 = expected1.CloneObject();
                expected2.ReceiptID = "A2";
                _purchaseDal.Insert(expected1);
                _purchaseDal.Insert(expected2);
                var expected = new List<ReceiptModel>
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
