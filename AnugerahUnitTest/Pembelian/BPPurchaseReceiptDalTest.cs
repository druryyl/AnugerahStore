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
    public interface IBPPurchaseReceiptDalTest
    {
        void InsertTest();
        void DeleteTest();
        void ListDataTest();
    }

    public class BPPurchaseReceiptDalTest : IBPPurchaseReceiptDalTest
    {
        private IBPPurchaseReceiptDal _purchaseDal;
        public BPPurchaseReceiptDalTest()
        {
            _purchaseDal = new BPPurchaseReceiptDal();
        }

        private BPPurchaseReceiptModel BPPurchaseReceiptDataFactory()
        {
            var result = new BPPurchaseReceiptModel
            {
                BPPurchaseID = "A1",
                BPReceiptID = "B1",
                BPDetilID = "C1",
                Tgl = "23-02-2019",
                Jam = "08:00:21",
                Keterangan = "",
                BrgID = "D1",
                QtyPurchase = 12,
                QtyReceipt = 31,
                Harga = 33,
                Diskon = 200,
                Tax = 100,
                SubTotal = 300,
            };
            return result;

        }

        [Fact]
        public void InsertTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrang
                var expected = BPPurchaseReceiptDataFactory();

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
                var expected1 = BPPurchaseReceiptDataFactory();
                var expected2 = expected1.CloneObject();
                expected2.BPReceiptID = "B2";
                _purchaseDal.Insert(expected1);
                _purchaseDal.Insert(expected2);
                var expected = new List<BPPurchaseReceiptModel>
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
