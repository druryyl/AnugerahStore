using AnugerahBackend.Support;
using FluentAssertions;
using Ics.Helper.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AnugerahUnitTest.Support
{

    public interface IUserrDalTest
    {
        void Insert_ValidData_NoEx();
        void Update_ValidDat_NoEx();
        void Delete_ValidData_NoEx();
        void GetData_ValidData_NoEx();
        void ListData_ValidData_NoEx();
    }

    public class UserrDalTest : IUserrDalTest
    {
        private IUserrDal _userrDal;

        public UserrDalTest()
        {
            _userrDal = new UserrDal();
        }

        UserrModel UserrDataFactory()
        {
            var result = new UserrModel
            {
                UserrID = "A1",
                UserrName = "B1",
                Password = "C1"
            };
            return result;
        }

        UserrModel Userr2DataFactory()
        {
            var result = new UserrModel
            {
                UserrID = "A2",
                UserrName = "B2",
                Password = "C2"
            };
            return result;
        }

        [Fact]
        public void Insert_ValidData_NoEx()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = UserrDataFactory();

                //  act
                _userrDal.Insert(expected);

                //  assert
            }
        }

        [Fact]
        public void Update_ValidDat_NoEx()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrang
                var expected = UserrDataFactory();

                //  act
                _userrDal.Update(expected);

                //  assert
            }
        }

        [Fact]
        public void Delete_ValidData_NoEx()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = UserrDataFactory();
                _userrDal.Insert(expected);

                //  act
                _userrDal.Delete("A");

                //  assert
            }
        }

        [Fact]
        public void GetData_ValidData_NoEx()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = UserrDataFactory();
                _userrDal.Insert(expected);

                //  act
                var actual = _userrDal.GetData("A1");

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
                var item1 = UserrDataFactory();
                _userrDal.Insert(item1);
                var item2 = Userr2DataFactory();
                _userrDal.Insert(item2);
                var expected = new List<UserrModel>
                {
                    item1, item2
                };

                //  act
                var actual = _userrDal.ListData();

                //  assert
                actual.Should().BeEquivalentTo(expected);
            }
        }

    }
}
