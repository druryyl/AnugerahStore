using AnugerahBackend.Keuangan.Dal;
using AnugerahBackend.Keuangan.Model;
using FluentAssertions;
using Ics.Helper.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AnugerahUnitTest.Keuangan
{

    public interface IJenisTrsKasirDalTest
    {
        void Insert_ValidData_NoEx();
        void Update_ValidDat_NoEx();
        void Delete_ValidData_NoEx();
        void GetData_ValidData_NoEx();
        void ListData_ValidData_NoEx();
    }

    public class JenisTrsKasirDalTest : IJenisTrsKasirDalTest
    {
        private IJenisTrsKasirDal _jenisTrsKasirDal;

        public JenisTrsKasirDalTest()
        {
            _jenisTrsKasirDal = new JenisTrsKasirDal();
        }

        JenisTrsKasirModel JenisTrsKasirDataFactory()
        {
            var result = new JenisTrsKasirModel
            {
                JenisTrsKasirID = "A1",
                JenisTrsKasirName = "B1"
            };
            return result;
        }

        JenisTrsKasirModel JenisTrsKasir2DataFactory()
        {
            var result = new JenisTrsKasirModel
            {
                JenisTrsKasirID = "A2",
                JenisTrsKasirName = "B2"
            };
            return result;
        }

        [Fact]
        public void Insert_ValidData_NoEx()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = JenisTrsKasirDataFactory();

                //  act
                _jenisTrsKasirDal.Insert(expected);

                //  assert
            }
        }

        [Fact]
        public void Update_ValidDat_NoEx()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrang
                var expected = JenisTrsKasirDataFactory();

                //  act
                _jenisTrsKasirDal.Update(expected);

                //  assert
            }
        }

        [Fact]
        public void Delete_ValidData_NoEx()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = JenisTrsKasirDataFactory();
                _jenisTrsKasirDal.Insert(expected);

                //  act
                _jenisTrsKasirDal.Delete("A");

                //  assert
            }
        }

        [Fact]
        public void GetData_ValidData_NoEx()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = JenisTrsKasirDataFactory();
                _jenisTrsKasirDal.Insert(expected);

                //  act
                var actual = _jenisTrsKasirDal.GetData("A1");

                //  assert
                actual.Should().BeEquivalentTo(expected);
            }
        }

        [Fact]
        public void ListData_ValidData_NoEx()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var item1 = JenisTrsKasirDataFactory();
                _jenisTrsKasirDal.Insert(item1);
                var item2 = JenisTrsKasir2DataFactory();
                _jenisTrsKasirDal.Insert(item2);
                var expected = new List<JenisTrsKasirModel>
                {
                    item1, item2
                };

                //  act
                var actual = _jenisTrsKasirDal.ListData();

                //  assert
                actual.Should().BeEquivalentTo(expected);
            }
        }

    }
}
