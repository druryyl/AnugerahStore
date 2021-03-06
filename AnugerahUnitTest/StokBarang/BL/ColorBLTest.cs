﻿using AnugerahBackend.StokBarang;
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

    public interface IColorBLTest
    {
        void TryValidate_ValidData_NoEx();
        void TryValidate_ColorID_Empty_ArgEx();


        void Save_DataExist_CallDalInsert();
        void Save_DataNotExist_CallDalUpdate();

        void Delete_CallDalDelete();
        void GetData_CallDalGetData();
        void ListData_CallDalListData();

    }
    public class ColorBLTest : IColorBLTest
    {
        public IColorBL _colorBL;
        public Mock<IColorDal> _colorDal;

        public ColorBLTest()
        {
            _colorDal = new Mock<IColorDal>();
            _colorBL = new ColorBL(_colorDal.Object);
        }

        ColorModel ColorDataFactory()
        {
            var result = new ColorModel
            {
                ColorID = "A1",
                RedValue = 10,
                GreenValue = 20,
                BlueValue = 30
            };
            return result;
        }

        ColorModel ColorDataFactory2()
        {
            var result = new ColorModel
            {
                ColorID = "A2",
                RedValue = 30,
                GreenValue = 40,
                BlueValue = 50
            };
            return result;
        }
        [Fact]
        public void TryValidate_ValidData_NoEx()
        {
            //  arrange
            var expected = ColorDataFactory();

            //  act
            var actual = _colorBL.TryValidate(expected);

            //  assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void TryValidate_ColorID_Empty_ArgEx()
        {
            //  arrange
            var expected = ColorDataFactory();
            expected.ColorID = "";

            //  act
            var ex = Assert.Throws<ArgumentException>(
                () => _colorBL.TryValidate(expected));

            //  assert
            ex.Message.Should().Contain("ColorID empty");
        }

        [Fact]
        public void Save_DataExist_CallDalInsert()
        {
            //  arrange
            var expected = ColorDataFactory();
            _colorDal.Setup(x => x.GetData("A1"))
                .Returns(null as ColorModel);

            //  act
            var actual = _colorBL.Save(expected);

            //  assert
            _colorDal.Verify(x => x.Insert(It.IsAny<ColorModel>()), Times.Once);
            _colorDal.Verify(x => x.Update(It.IsAny<ColorModel>()), Times.Never);
        }

        [Fact]
        public void Save_DataNotExist_CallDalUpdate()
        {
            //  arrange
            var expected = ColorDataFactory();
            _colorDal.Setup(x => x.GetData("A1"))
                .Returns(new ColorModel());

            //  act
            var actual = _colorBL.Save(expected);

            //  assert
            _colorDal.Verify(x => x.Update(It.IsAny<ColorModel>()), Times.Once);
            _colorDal.Verify(x => x.Insert(It.IsAny<ColorModel>()), Times.Never);
        }

        [Fact]
        public void Delete_CallDalDelete()
        {
            //  arrange

            //  act
            _colorBL.Delete("A1");

            //  assert
            _colorDal.Verify(x => x.Delete(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void GetData_CallDalGetData()
        {
            //  arrange

            //  act
            var actual = _colorBL.GetData("A1");

            //  assert
            _colorDal.Verify(x => x.GetData(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void ListData_CallDalListData()
        {
            //  arrange

            //  act
            var actual = _colorBL.ListData();

            //  assert
            _colorDal.Verify(x => x.ListData(), Times.Once);
        }

        [Fact]
        public void DataSeed()
        {
            //var seeder = new ColorBL();
            //seeder.DataSeed();
        }

    }
}
