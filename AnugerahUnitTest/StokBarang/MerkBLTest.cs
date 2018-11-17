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

    public interface IMerkBLTest
    {
        void TryValidate_ValidData_NoEx();
        void TryValidate_MerkID_Empty_ArgEx();
        void TryValidate_MerkName_Empty_ArgEx();


        void Save_DataExist_CallDalInsert();
        void Save_DataNotExist_CallDalUpdate();

        void Delete_CallDalDelete();
        void GetData_CallDalGetData();
        void ListData_CallDalListData();

    }
    public class MerkBLTest : IMerkBLTest
    {
        public IMerkBL _merkBL;
        public Mock<IMerkDal> _merkDal;

        public MerkBLTest()
        {
            _merkDal = new Mock<IMerkDal>();
            _merkBL = new MerkBL(_merkDal.Object);
        }

        MerkModel MerkDataFactory()
        {
            var result = new MerkModel
            {
                MerkID = "A1",
                MerkName = "B1"
            };
            return result;
        }

        MerkModel MerkDataFactory2()
        {
            var result = new MerkModel
            {
                MerkID = "A2",
                MerkName = "B2"
            };
            return result;
        }
        [Fact]
        public void TryValidate_ValidData_NoEx()
        {
            //  arrange
            var expected = MerkDataFactory();

            //  act
            var actual = _merkBL.TryValidate(expected);

            //  assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void TryValidate_MerkID_Empty_ArgEx()
        {
            //  arrange
            var expected = MerkDataFactory();
            expected.MerkID = "";

            //  act
            var ex = Assert.Throws<ArgumentException>(
                () => _merkBL.TryValidate(expected));

            //  assert
            ex.Message.Should().Contain("MerkID empty");
        }

        [Fact]
        public void TryValidate_MerkName_Empty_ArgEx()
        {
            //  arrange
            var expected = MerkDataFactory();
            expected.MerkName = "";

            //  act
            var ex = Assert.Throws<ArgumentException>(
                () => _merkBL.TryValidate(expected));

            //  assert
            ex.Message.Should().Contain("MerkName empty");
        }

        [Fact]
        public void Save_DataExist_CallDalInsert()
        {
            //  arrange
            var expected = MerkDataFactory();
            _merkDal.Setup(x => x.GetData("A1"))
                .Returns(null as MerkModel);

            //  act
            var actual = _merkBL.Save(expected);

            //  assert
            _merkDal.Verify(x => x.Insert(It.IsAny<MerkModel>()), Times.Once);
            _merkDal.Verify(x => x.Update(It.IsAny<MerkModel>()), Times.Never);
        }

        [Fact]
        public void Save_DataNotExist_CallDalUpdate()
        {
            //  arrange
            var expected = MerkDataFactory();
            _merkDal.Setup(x => x.GetData("A1"))
                .Returns(new MerkModel());

            //  act
            var actual = _merkBL.Save(expected);

            //  assert
            _merkDal.Verify(x => x.Update(It.IsAny<MerkModel>()), Times.Once);
            _merkDal.Verify(x => x.Insert(It.IsAny<MerkModel>()), Times.Never);
        }

        [Fact]
        public void Delete_CallDalDelete()
        {
            //  arrange

            //  act
            _merkBL.Delete("A1");

            //  assert
            _merkDal.Verify(x => x.Delete(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void GetData_CallDalGetData()
        {
            //  arrange

            //  act
            var actual = _merkBL.GetData("A1");

            //  assert
            _merkDal.Verify(x => x.GetData(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void ListData_CallDalListData()
        {
            //  arrange

            //  act
            var actual = _merkBL.ListData();

            //  assert
            _merkDal.Verify(x => x.ListData(), Times.Once);
        }
    }
}