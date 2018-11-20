using AnugerahBackend.Support;
using AnugerahBackend.Support.BL;
using AnugerahBackend.Support.Dal;
using AnugerahBackend.Support.Model;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AnugerahUnitTest.Support.BL
{

    public interface IUserrBLTest
    {
        void TryValidate_ValidData_NoEx();
        void TryValidate_UserrID_Empty_ArgEx();
        void TryValidate_UserrName_Empty_ArgEx();


        void Save_DataExist_CallDalInsert();
        void Save_DataNotExist_CallDalUpdate();

        void Delete_CallDalDelete();
        void GetData_CallDalGetData();
        void ListData_CallDalListData();

    }
    public class UserrBLTest : IUserrBLTest
    {
        public IUserrBL _userrBL;
        public Mock<IUserrDal> _userrDal;

        public UserrBLTest()
        {
            _userrDal = new Mock<IUserrDal>();
            _userrBL = new UserrBL(_userrDal.Object);
        }

        UserrModel UserrDataFactory()
        {
            var result = new UserrModel
            {
                UserrID = "A1",
                UserrName = "B1"
            };
            return result;
        }

        UserrModel UserrDataFactory2()
        {
            var result = new UserrModel
            {
                UserrID = "A2",
                UserrName = "B2"
            };
            return result;
        }
        [Fact]
        public void TryValidate_ValidData_NoEx()
        {
            //  arrange
            var expected = UserrDataFactory();

            //  act
            var actual = _userrBL.TryValidate(expected);

            //  assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void TryValidate_UserrID_Empty_ArgEx()
        {
            //  arrange
            var expected = UserrDataFactory();
            expected.UserrID = "";

            //  act
            var ex = Assert.Throws<ArgumentException>(
                () => _userrBL.TryValidate(expected));

            //  assert
            ex.Message.Should().Contain("UserrID empty");
        }

        [Fact]
        public void TryValidate_UserrName_Empty_ArgEx()
        {
            //  arrange
            var expected = UserrDataFactory();
            expected.UserrName = "";

            //  act
            var ex = Assert.Throws<ArgumentException>(
                () => _userrBL.TryValidate(expected));

            //  assert
            ex.Message.Should().Contain("UserrName empty");
        }

        [Fact]
        public void Save_DataExist_CallDalInsert()
        {
            //  arrange
            var expected = UserrDataFactory();
            _userrDal.Setup(x => x.GetData("A1"))
                .Returns(null as UserrModel);

            //  act
            var actual = _userrBL.Save(expected);

            //  assert
            _userrDal.Verify(x => x.Insert(It.IsAny<UserrModel>()), Times.Once);
            _userrDal.Verify(x => x.Update(It.IsAny<UserrModel>()), Times.Never);
        }

        [Fact]
        public void Save_DataNotExist_CallDalUpdate()
        {
            //  arrange
            var expected = UserrDataFactory();
            _userrDal.Setup(x => x.GetData("A1"))
                .Returns(new UserrModel());

            //  act
            var actual = _userrBL.Save(expected);

            //  assert
            _userrDal.Verify(x => x.Update(It.IsAny<UserrModel>()), Times.Once);
            _userrDal.Verify(x => x.Insert(It.IsAny<UserrModel>()), Times.Never);
        }

        [Fact]
        public void Delete_CallDalDelete()
        {
            //  arrange

            //  act
            _userrBL.Delete("A1");

            //  assert
            _userrDal.Verify(x => x.Delete(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void GetData_CallDalGetData()
        {
            //  arrange

            //  act
            var actual = _userrBL.GetData("A1");

            //  assert
            _userrDal.Verify(x => x.GetData(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void ListData_CallDalListData()
        {
            //  arrange

            //  act
            var actual = _userrBL.ListData();

            //  assert
            _userrDal.Verify(x => x.ListData(), Times.Once);
        }
    }
}
