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
    public interface ISupplierDalTest
    {
        void InsertTest();
        void UpdateTest();
        void DeleteTest();
        void GetDataTest();
        void ListDataTest();
    }

    public class SupplierDalTest : ISupplierDalTest
    {
        private ISupplierDal _supplierDal;
        public SupplierDalTest()
        {
            _supplierDal = new SupplierDal();
        }

        private SupplierModel SupplierDataFactory()
        {
            var result = new SupplierModel
            {
                SupplierID = "A1",
                SupplierName = "B1",
                Alamat = "C1",
                NoTelp = "D1"
            };
            return result;
        }

        [Fact]
        public void InsertTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrang
                var expected = SupplierDataFactory();

                //  act
                _supplierDal.Insert(expected);

                //  assert
            }
        }

        [Fact]
        public void UpdateTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = SupplierDataFactory();

                //  act
                _supplierDal.Update(expected);

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
                _supplierDal.Delete("A1");

            }
        }

        [Fact]
        public void GetDataTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = SupplierDataFactory();
                _supplierDal.Insert(expected);

                //  act
                var actual = _supplierDal.GetData("A1");

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
                var expected1 = SupplierDataFactory();
                var expected2 = expected1.CloneObject();
                expected2.SupplierID = "A2";
                _supplierDal.Insert(expected1);
                _supplierDal.Insert(expected2);
                var expected = new List<SupplierModel>
                {
                    expected1, expected2
                };

                //  act
                var actual = _supplierDal.ListData();

                //  assert
                actual.Should().BeEquivalentTo(expected);
            }
        }
    }
}
