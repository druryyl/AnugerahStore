using AnugerahBackend.Penjualan.BL;
using AnugerahBackend.Penjualan.Dal;
using AnugerahBackend.Penjualan.Model;
using AnugerahBackend.Support.BL;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AnugerahUnitTest.Penjualan.BL
{
    public interface IPriceBLTest
    {
        void Save_DataValid_ReturnExpected();
        void Save_PriceNull_ThrowArgEx();
        void Save_ListHargaNull_ThrowArgEx();
        void Save_PriceNameKosong_ThrowArgEx();
        void Save_ListHargaNol_ThrowArgEx();
        void Save_DoubleQty_ThrowArgEx();
        void Save_IDKosong_CallParamNoGenNewID();
        void Save_DataValid_CallPriceDalInsert();
        void Save_DataValid_CallPriceQtyDalInsert();

        void Delete_DataValid();
        void Delete_DataNotFound_ThrowArgEx();
        void Delete_DataValid_CallPriceDalDelete();
        void Delete_DataValid_CallPriceQtyDallDelete();

        void GetData_DataExist_ReturnData();
        void GetData_DataNotExist_ThrowArgEx();

        void ListData_DataExist_ReturnData();
        void ListData_DataNotExist_ThrowArgEx();
    }

    public class PriceBLTest : IPriceBLTest
    {
        private IPriceBL _sut;
        private Mock<IPriceDal> _priceDal;
        private Mock<IPriceQtyDal> _priceQtyDal;
        private Mock<IParameterNoBL> _paramNoBL;

        public PriceBLTest()
        {
            _priceDal = new Mock<IPriceDal>();
            _priceQtyDal = new Mock<IPriceQtyDal>();
            _paramNoBL = new Mock<IParameterNoBL>();
            var dep = new PriceBLDep
            {
                ParamNoBL = _paramNoBL.Object,
                PriceDal = _priceDal.Object,
                PriceQtyDal = _priceQtyDal.Object
            };
            _sut = new PriceBL(dep);
        }

        private PriceModel PriceFactory()
        {
            var result = new PriceModel
            {
                PriceID = "A",
                PriceName = "B"
            };
            var listHarga = new List<PriceQtyModel>
            {
                new PriceQtyModel{ PriceID = "A", Qty = 1, Harga = 1000, Diskon = 25},
                new PriceQtyModel{ PriceID = "A", Qty = 20, Harga = 900, Diskon = 50},
            };
            result.ListHarga = listHarga;
            return result;
        }

        [Fact]
        public void Save_DataValid_ReturnExpected()
        {
            //  arrange
            var expected = PriceFactory();

            //  act
            var actual = _sut.Save(expected);

            //  assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Save_PriceNull_ThrowArgEx()
        {
            //  arrange
            PriceModel expected = null;

            //  act
            var ex = Assert.Throws<ArgumentException>(
                () => _sut.Save(expected));

            //  assert
            ex.Should().NotBeNull();
        }

        [Fact]
        public void Save_ListHargaNull_ThrowArgEx()
        {
            //  arrange
            PriceModel expected = PriceFactory();
            expected.ListHarga = null;

            //  act
            var ex = Assert.Throws<ArgumentException>(
                () => _sut.Save(expected));

            //  assert
            ex.Should().NotBeNull();
        }

        [Fact]
        public void Save_PriceNameKosong_ThrowArgEx()
        {
            //  arrange
            PriceModel expected = PriceFactory();
            expected.PriceName = "";

            //  act
            var ex = Assert.Throws<ArgumentException>(
                () => _sut.Save(expected));

            //  assert
            ex.Should().NotBeNull();
        }

        [Fact]
        public void Save_ListHargaNol_ThrowArgEx()
        {
            //  arrange
            PriceModel expected = PriceFactory();
            var item = expected.ListHarga.FirstOrDefault();
            item.Qty = 0;

            //  act
            var ex = Assert.Throws<ArgumentException>(
                () => _sut.Save(expected));

            //  assert
            ex.Should().NotBeNull();
        }

        [Fact]
        public void Save_DoubleQty_ThrowArgEx()
        {
            //  arrange
            PriceModel expected = PriceFactory();
            var item = expected.ListHarga.FirstOrDefault();
            item.Qty = 20;

            //  act
            var ex = Assert.Throws<ArgumentException>(
                () => _sut.Save(expected));

            //  assert
            ex.Should().NotBeNull();
        }

        [Fact]
        public void Save_IDKosong_CallParamNoGenNewID()
        {
            //  arrange
            PriceModel expected = PriceFactory();
            expected.PriceID = "";

            //  act
            var actual = _sut.Save(expected);

            //  assert
            _paramNoBL.Verify(x => x.GenNewID("H", 5));
        }

        [Fact]
        public void Save_DataValid_CallPriceDalInsert()
        {
            //  arrange
            PriceModel expected = PriceFactory();

            //  act
            var actual = _sut.Save(expected);

            //  assert
            _paramNoBL.Verify(x => x.GenNewID("H", 5));
        }

        public void Save_DataValid_CallPriceQtyDalInsert()
        {
            throw new NotImplementedException();
        }

        public void Delete_DataValid()
        {
            throw new NotImplementedException();
        }

        public void Delete_DataNotFound_ThrowArgEx()
        {
            throw new NotImplementedException();
        }

        public void Delete_DataValid_CallPriceDalDelete()
        {
            throw new NotImplementedException();
        }

        public void Delete_DataValid_CallPriceQtyDallDelete()
        {
            throw new NotImplementedException();
        }

        public void GetData_DataExist_ReturnData()
        {
            throw new NotImplementedException();
        }

        public void GetData_DataNotExist_ThrowArgEx()
        {
            throw new NotImplementedException();
        }

        public void ListData_DataExist_ReturnData()
        {
            throw new NotImplementedException();
        }

        public void ListData_DataNotExist_ThrowArgEx()
        {
            throw new NotImplementedException();
        }
    }
}
