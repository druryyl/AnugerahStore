using AnugerahBackend.StokBarang;
using FluentAssertions;
using Ics.Helper.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AnugerahUnitTest.StokBarang
{

    public interface IJenisBrgDalTest
    {
        void Insert_ValidData_NoEx();
        void Update_ValidDat_NoEx();
        void Delete_ValidData_NoEx();
        void GetData_ValidData_NoEx();
        void ListData_ValidData_NoEx();
    }

    public class JenisBrgDalTest : IJenisBrgDalTest
    {
        private IJenisBrgDal _jenisBrgDal;

        public JenisBrgDalTest()
        {
            _jenisBrgDal = new JenisBrgDal();
        }

        JenisBrgModel JenisBrgDataFactory()
        {
            var result = new JenisBrgModel
            {
                JenisBrgID = "A1",
                JenisBrgName = "B1"
            };
            return result;
        }

        JenisBrgModel JenisBrg2DataFactory()
        {
            var result = new JenisBrgModel
            {
                JenisBrgID = "A2",
                JenisBrgName = "B2"
            };
            return result;
        }

        [Fact]
        public void Insert_ValidData_NoEx()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = JenisBrgDataFactory();

                //  act
                _jenisBrgDal.Insert(expected);

                //  assert
            }
        }

        [Fact]
        public void Update_ValidDat_NoEx()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrang
                var expected = JenisBrgDataFactory();

                //  act
                _jenisBrgDal.Update(expected);

                //  assert
            }
        }

        [Fact]
        public void Delete_ValidData_NoEx()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = JenisBrgDataFactory();
                _jenisBrgDal.Insert(expected);

                //  act
                _jenisBrgDal.Delete("A");

                //  assert
            }
        }

        [Fact]
        public void GetData_ValidData_NoEx()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = JenisBrgDataFactory();
                _jenisBrgDal.Insert(expected);

                //  act
                var actual = _jenisBrgDal.GetData("A1");

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
                var item1 = JenisBrgDataFactory();
                _jenisBrgDal.Insert(item1);
                var item2 = JenisBrg2DataFactory();
                _jenisBrgDal.Insert(item2);
                var expected = new List<JenisBrgModel>
                {
                    item1, item2
                };

                //  act
                var actual = _jenisBrgDal.ListData();

                //  assert
                actual.Should().BeEquivalentTo(expected);
            }
        }

    }
}
