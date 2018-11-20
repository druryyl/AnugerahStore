using AnugerahBackend.StokBarang;
using AnugerahBackend.StokBarang.Dal;
using AnugerahBackend.StokBarang.Model;
using FluentAssertions;
using Ics.Helper.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AnugerahUnitTest.StokBarang.BL
{

    public interface IColorDalTest
    {
        void Insert_ValidData_NoEx();
        void Update_ValidDat_NoEx();
        void Delete_ValidData_NoEx();
        void GetData_ValidData_NoEx();
        void ListData_ValidData_NoEx();
    }

    public class ColorDalTest : IColorDalTest
    {
        private IColorDal _colorDal;

        public ColorDalTest()
        {
            _colorDal = new ColorDal();
        }

        ColorModel ColorDataFactory()
        {
            var result = new ColorModel
            {
                ColorID = "A1",
                ColorName = "B1"
            };
            return result;
        }

        ColorModel Color2DataFactory()
        {
            var result = new ColorModel
            {
                ColorID = "A2",
                ColorName = "B2"
            };
            return result;
        }

        [Fact]
        public void Insert_ValidData_NoEx()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = ColorDataFactory();

                //  act
                _colorDal.Insert(expected);

                //  assert
            }
        }

        [Fact]
        public void Update_ValidDat_NoEx()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrang
                var expected = ColorDataFactory();

                //  act
                _colorDal.Update(expected);

                //  assert
            }
        }

        [Fact]
        public void Delete_ValidData_NoEx()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = ColorDataFactory();
                _colorDal.Insert(expected);

                //  act
                _colorDal.Delete("A");

                //  assert
            }
        }

        [Fact]
        public void GetData_ValidData_NoEx()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = ColorDataFactory();
                _colorDal.Insert(expected);

                //  act
                var actual = _colorDal.GetData("A1");

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
                var item1 = ColorDataFactory();
                _colorDal.Insert(item1);
                var item2 = Color2DataFactory();
                _colorDal.Insert(item2);
                var expected = new List<ColorModel>
                {
                    item1, item2
                };

                //  act
                var actual = _colorDal.ListData();

                //  assert
                actual.Should().BeEquivalentTo(expected);
            }
        }

    }
}
