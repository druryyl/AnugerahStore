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
    public interface IReceiptDetilDalTest
    {
        void InsertTest();
        void DeleteTest();
        void ListDataTest();
    }

    public class ReceiptDetilDalTest : IReceiptDetilDalTest
    {
        private IReceiptDetilDal _receiptDal;

        public ReceiptDetilDalTest()
        {
            _receiptDal = new ReceiptDetilDal();
        }

        private ReceiptDetilModel ReceiptDetilDataFactory()
        {
            var result = new ReceiptDetilModel
            {
                ReceiptID = "A1",
                ReceiptDetilID = "B1",
                BrgID = "C1",
                BrgName = "",
                Harga = 1,
                NoUrut = 2,
                Qty = 3,
                Diskon = 200,
                SubTotal = 2121,
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
                var expected = ReceiptDetilDataFactory();

                //  act
                _receiptDal.Insert(expected);

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
                _receiptDal.Delete("A1");

            }
        }

        [Fact]
        public void ListDataTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected1 = ReceiptDetilDataFactory();
                var expected2 = expected1.CloneObject();
                expected2.ReceiptDetilID = "A2";
                _receiptDal.Insert(expected1);
                _receiptDal.Insert(expected2);
                var expected = new List<ReceiptDetilModel>
                {
                    expected1, expected2
                };

                //  act
                var actual = _receiptDal.ListData("A1");

                //  assert
                actual.Should().BeEquivalentTo(expected);
            }
        }
    }
}
