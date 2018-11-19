using AnugerahBackend.StokBarang;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AnugerahUnitTest.StokBarang
{

    public interface IJenisBrgBLTest
    {
        void TryValidate_ValidData_NoEx();
        void TryValidate_JenisBrgID_Empty_ArgEx();
        void TryValidate_JenisBrgName_Empty_ArgEx();


        void Save_DataExist_CallDalInsert();
        void Save_DataNotExist_CallDalUpdate();

        void Delete_CallDalDelete();
        void GetData_CallDalGetData();
        void ListData_CallDalListData();

    }
    public class JenisBrgBLTest : IJenisBrgBLTest
    {
        public IJenisBrgBL _jenisBrgBL;
        public Mock<IJenisBrgDal> _jenisBrgDal;

        public JenisBrgBLTest()
        {
            _jenisBrgDal = new Mock<IJenisBrgDal>();
            _jenisBrgBL = new JenisBrgBL(_jenisBrgDal.Object);
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

        JenisBrgModel JenisBrgDataFactory2()
        {
            var result = new JenisBrgModel
            {
                JenisBrgID = "A2",
                JenisBrgName = "B2"
            };
            return result;
        }
        [Fact]
        public void TryValidate_ValidData_NoEx()
        {
            //  arrange
            var expected = JenisBrgDataFactory();
  
            //  act
            var actual = _jenisBrgBL.TryValidate(expected);

            //  assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void TryValidate_JenisBrgID_Empty_ArgEx()
        {
            //  arrange
            var expected = JenisBrgDataFactory();
            expected.JenisBrgID = "";

            //  act
            var ex = Assert.Throws<ArgumentException>(
                () => _jenisBrgBL.TryValidate(expected));

            //  assert
            ex.Message.Should().Contain("JenisBrgID empty");
        }

        [Fact]
        public void TryValidate_JenisBrgName_Empty_ArgEx()
        {
            //  arrange
            var expected = JenisBrgDataFactory();
            expected.JenisBrgName = "";

            //  act
            var ex = Assert.Throws<ArgumentException>(
                () => _jenisBrgBL.TryValidate(expected));

            //  assert
            ex.Message.Should().Contain("JenisBrgName empty");
        }

        [Fact]
        public void Save_DataExist_CallDalInsert()
        {
            //  arrange
            var expected = JenisBrgDataFactory();
            _jenisBrgDal.Setup(x => x.GetData("A1"))
                .Returns(null as JenisBrgModel);

            //  act
            var actual = _jenisBrgBL.Save(expected);

            //  assert
            _jenisBrgDal.Verify(x => x.Insert(It.IsAny<JenisBrgModel>()), Times.Once);
            _jenisBrgDal.Verify(x => x.Update(It.IsAny<JenisBrgModel>()), Times.Never);
        }

        [Fact]
        public void Save_DataNotExist_CallDalUpdate()
        {
            //  arrange
            var expected = JenisBrgDataFactory();
            _jenisBrgDal.Setup(x => x.GetData("A1"))
                .Returns(new JenisBrgModel());

            //  act
            var actual = _jenisBrgBL.Save(expected);

            //  assert
            _jenisBrgDal.Verify(x => x.Update(It.IsAny<JenisBrgModel>()), Times.Once);
            _jenisBrgDal.Verify(x => x.Insert(It.IsAny<JenisBrgModel>()), Times.Never);
        }

        [Fact]
        public void Delete_CallDalDelete()
        {
            //  arrange

            //  act
            _jenisBrgBL.Delete("A1");

            //  assert
            _jenisBrgDal.Verify(x => x.Delete(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void GetData_CallDalGetData()
        {
            //  arrange

            //  act
            var actual = _jenisBrgBL.GetData("A1");

            //  assert
            _jenisBrgDal.Verify(x => x.GetData(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void ListData_CallDalListData()
        {
            //  arrange

            //  act
            var actual = _jenisBrgBL.ListData();

            //  assert
            _jenisBrgDal.Verify(x => x.ListData(), Times.Once);
        }
    }
}
