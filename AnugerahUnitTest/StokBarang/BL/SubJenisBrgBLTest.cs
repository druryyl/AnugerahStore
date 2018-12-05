using AnugerahBackend.StokBarang.BL;
using AnugerahBackend.StokBarang.Dal;
using AnugerahBackend.StokBarang.Model;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AnugerahUnitTest.StokBarang.BL
{

    public interface ISubJenisBrgBLTest
    {
        void TryValidate_ValidData_NoEx();
        void TryValidate_SubJenisBrgID_Empty_ArgEx();
        void TryValidate_SubJenisBrgName_Empty_ArgEx();


        void Save_DataExist_CallDalInsert();
        void Save_DataNotExist_CallDalUpdate();

        void Delete_CallDalDelete();
        void GetData_CallDalGetData();
        void ListData_CallDalListData();

    }
    public class SubJenisBrgBLTest : ISubJenisBrgBLTest
    {
        public ISubJenisBrgBL _subJenisBrgBL;
        public Mock<ISubJenisBrgDal> _subJenisBrgDal;
        public Mock<IJenisBrgBL> _jenisBrgBL;

        public SubJenisBrgBLTest()
        {
            _subJenisBrgDal = new Mock<ISubJenisBrgDal>();
            _jenisBrgBL = new Mock<IJenisBrgBL>();
            _subJenisBrgBL = new SubJenisBrgBL(_subJenisBrgDal.Object,
                _jenisBrgBL.Object);
        }

        SubJenisBrgModel SubJenisBrgDataFactory()
        {
            var result = new SubJenisBrgModel
            {
                SubJenisBrgID = "A1",
                SubJenisBrgName = "B1",
                JenisBrgID = "C1",
                JenisBrgName = "D1"
            };
            _jenisBrgBL.Setup(x => x.GetData(It.IsAny<string>())).Returns(new JenisBrgModel());

            return result;
        }

        SubJenisBrgModel SubJenisBrgDataFactory2()
        {
            var result = new SubJenisBrgModel
            {
                SubJenisBrgID = "A2",
                SubJenisBrgName = "B2",
                JenisBrgID = "C2",
                JenisBrgName = "D2"
            };
            _jenisBrgBL.Setup(x => x.GetData(It.IsAny<string>())).Returns(new JenisBrgModel());
            return result;
        }
        [Fact]
        public void TryValidate_ValidData_NoEx()
        {
            //  arrange
            var expected = SubJenisBrgDataFactory();

            //  act
            var actual = _subJenisBrgBL.TryValidate(expected);

            //  assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void TryValidate_SubJenisBrgID_Empty_ArgEx()
        {
            //  arrange
            var expected = SubJenisBrgDataFactory();
            expected.SubJenisBrgID = "";

            //  act
            var ex = Assert.Throws<ArgumentException>(
                () => _subJenisBrgBL.TryValidate(expected));

            //  assert
            ex.Message.Should().Contain("SubJenisBrgID empty");
        }

        [Fact]
        public void TryValidate_SubJenisBrgName_Empty_ArgEx()
        {
            //  arrange
            var expected = SubJenisBrgDataFactory();
            expected.SubJenisBrgName = "";

            //  act
            var ex = Assert.Throws<ArgumentException>(
                () => _subJenisBrgBL.TryValidate(expected));

            //  assert
            ex.Message.Should().Contain("SubJenisBrgName empty");
        }

        [Fact]
        public void Save_DataExist_CallDalInsert()
        {
            //  arrange
            var expected = SubJenisBrgDataFactory();
            _subJenisBrgDal.Setup(x => x.GetData("A1"))
                .Returns(null as SubJenisBrgModel);

            //  act
            var actual = _subJenisBrgBL.Save(expected);

            //  assert
            _subJenisBrgDal.Verify(x => x.Insert(It.IsAny<SubJenisBrgModel>()), Times.Once);
            _subJenisBrgDal.Verify(x => x.Update(It.IsAny<SubJenisBrgModel>()), Times.Never);
        }

        [Fact]
        public void Save_DataNotExist_CallDalUpdate()
        {
            //  arrange
            var expected = SubJenisBrgDataFactory();
            _subJenisBrgDal.Setup(x => x.GetData("A1"))
                .Returns(new SubJenisBrgModel());

            //  act
            var actual = _subJenisBrgBL.Save(expected);

            //  assert
            _subJenisBrgDal.Verify(x => x.Update(It.IsAny<SubJenisBrgModel>()), Times.Once);
            _subJenisBrgDal.Verify(x => x.Insert(It.IsAny<SubJenisBrgModel>()), Times.Never);
        }

        [Fact]
        public void Delete_CallDalDelete()
        {
            //  arrange

            //  act
            _subJenisBrgBL.Delete("A1");

            //  assert
            _subJenisBrgDal.Verify(x => x.Delete(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void GetData_CallDalGetData()
        {
            //  arrange

            //  act
            var actual = _subJenisBrgBL.GetData("A1");

            //  assert
            _subJenisBrgDal.Verify(x => x.GetData(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void ListData_CallDalListData()
        {
            //  arrange

            //  act
            var actual = _subJenisBrgBL.ListData();

            //  assert
            _subJenisBrgDal.Verify(x => x.ListData(), Times.Once);
        }
    }
}
