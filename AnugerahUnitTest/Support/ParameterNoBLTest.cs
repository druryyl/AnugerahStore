using AnugerahBackend.Support;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AnugerahUnitTest.Support
{

    public interface IParameterNoBLTest
    {
        void TryValidate_ValidData_NoEx();
        void TryValidate_Prefix_Empty_ArgEx();
        void TryValidate_Value_Empty_ArgEx();


        void Save_DataExist_CallDalInsert();
        void Save_DataNotExist_CallDalUpdate();

        void Delete_CallDalDelete();
        void GetData_CallDalGetData();
        void ListData_CallDalListData();

    }
    public class ParameterNoBLTest : IParameterNoBLTest
    {
        public IParameterNoBL _parameterNoBL;
        public Mock<IParameterNoDal> _parameterNoDal;

        public ParameterNoBLTest()
        {
            _parameterNoDal = new Mock<IParameterNoDal>();
            _parameterNoBL = new ParameterNoBL(_parameterNoDal.Object);
        }

        ParameterNoModel ParameterNoDataFactory()
        {
            var result = new ParameterNoModel
            {
                Prefix = "A1",
                Value = 4
            };
            return result;
        }

        ParameterNoModel ParameterNoDataFactory2()
        {
            var result = new ParameterNoModel
            {
                Prefix = "A2",
                Value = 13
            };
            return result;
        }
        [Fact]
        public void TryValidate_ValidData_NoEx()
        {
            //  arrange
            var expected = ParameterNoDataFactory();

            //  act
            var actual = _parameterNoBL.TryValidate(expected);

            //  assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void TryValidate_Prefix_Empty_ArgEx()
        {
            //  arrange
            var expected = ParameterNoDataFactory();
            expected.Prefix = "";

            //  act
            var ex = Assert.Throws<ArgumentException>(
                () => _parameterNoBL.TryValidate(expected));

            //  assert
            ex.Message.Should().Contain("Prefix empty");
        }

        [Fact]
        public void TryValidate_Value_Empty_ArgEx()
        {
            //  arrange
            var expected = ParameterNoDataFactory();
            expected.Value = 0;

            //  act
            var ex = Assert.Throws<ArgumentException>(
                () => _parameterNoBL.TryValidate(expected));

            //  assert
            ex.Message.Should().Contain("Value empty");
        }

        [Fact]
        public void Save_DataExist_CallDalInsert()
        {
            //  arrange
            var expected = ParameterNoDataFactory();
            _parameterNoDal.Setup(x => x.GetData("A1"))
                .Returns(null as ParameterNoModel);

            //  act
            var actual = _parameterNoBL.Save(expected);

            //  assert
            _parameterNoDal.Verify(x => x.Insert(It.IsAny<ParameterNoModel>()), Times.Once);
            _parameterNoDal.Verify(x => x.Update(It.IsAny<ParameterNoModel>()), Times.Never);
        }

        [Fact]
        public void Save_DataNotExist_CallDalUpdate()
        {
            //  arrange
            var expected = ParameterNoDataFactory();
            _parameterNoDal.Setup(x => x.GetData("A1"))
                .Returns(new ParameterNoModel());

            //  act
            var actual = _parameterNoBL.Save(expected);

            //  assert
            _parameterNoDal.Verify(x => x.Update(It.IsAny<ParameterNoModel>()), Times.Once);
            _parameterNoDal.Verify(x => x.Insert(It.IsAny<ParameterNoModel>()), Times.Never);
        }

        [Fact]
        public void Delete_CallDalDelete()
        {
            //  arrange

            //  act
            _parameterNoBL.Delete("A1");

            //  assert
            _parameterNoDal.Verify(x => x.Delete(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void GetData_CallDalGetData()
        {
            //  arrange

            //  act
            var actual = _parameterNoBL.GetData("A1");

            //  assert
            _parameterNoDal.Verify(x => x.GetData(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void ListData_CallDalListData()
        {
            //  arrange

            //  act
            var actual = _parameterNoBL.ListData();

            //  assert
            _parameterNoDal.Verify(x => x.ListData(), Times.Once);
        }
    }
}
