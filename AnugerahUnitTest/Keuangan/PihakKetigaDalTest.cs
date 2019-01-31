using AnugerahBackend.Keuangan.Dal;
using AnugerahBackend.Keuangan.Model;
using FluentAssertions;
using Ics.Helper.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AnugerahUnitTest.Keuangan
{

    public interface IPihakKetigaDalTest
    {
        void Insert_ValidData_NoEx();
        void Update_ValidDat_NoEx();
        void Delete_ValidData_NoEx();
        void GetData_ValidData_NoEx();
        void ListData_ValidData_NoEx();
    }

    public class PihakKetigaDalTest : IPihakKetigaDalTest
    {
        private IPihakKetigaDal _pihakKetigaDal;

        public PihakKetigaDalTest()
        {
            _pihakKetigaDal = new PihakKetigaDal();
        }

        PihakKetigaModel PihakKetigaDataFactory()
        {
            var result = new PihakKetigaModel
            {
                PihakKetigaID = "A1",
                PihakKetigaName = "B1"
            };
            return result;
        }

        PihakKetigaModel PihakKetiga2DataFactory()
        {
            var result = new PihakKetigaModel
            {
                PihakKetigaID = "A2",
                PihakKetigaName = "B2"
            };
            return result;
        }

        [Fact]
        public void Insert_ValidData_NoEx()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = PihakKetigaDataFactory();

                //  act
                _pihakKetigaDal.Insert(expected);

                //  assert
            }
        }

        [Fact]
        public void Update_ValidDat_NoEx()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrang
                var expected = PihakKetigaDataFactory();

                //  act
                _pihakKetigaDal.Update(expected);

                //  assert
            }
        }

        [Fact]
        public void Delete_ValidData_NoEx()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = PihakKetigaDataFactory();
                _pihakKetigaDal.Insert(expected);

                //  act
                _pihakKetigaDal.Delete("A");

                //  assert
            }
        }

        [Fact]
        public void GetData_ValidData_NoEx()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = PihakKetigaDataFactory();
                _pihakKetigaDal.Insert(expected);

                //  act
                var actual = _pihakKetigaDal.GetData("A1");

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
                var item1 = PihakKetigaDataFactory();
                _pihakKetigaDal.Insert(item1);
                var item2 = PihakKetiga2DataFactory();
                _pihakKetigaDal.Insert(item2);
                var expected = new List<PihakKetigaModel>
                {
                    item1, item2
                };

                //  act
                var actual = _pihakKetigaDal.ListData();

                //  assert
                actual.Should().BeEquivalentTo(expected);
            }
        }

    }
}
