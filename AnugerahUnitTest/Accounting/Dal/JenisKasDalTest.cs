using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnugerahBackend.Accounting.Dal;
using AnugerahBackend.Accounting.Model;
using FluentAssertions;
using Ics.Helper.Database;
using Xunit;

namespace AnugerahUnitTest.Accounting.Dal
{

    public interface IJenisKasDalTest
    {
        void Insert_ValidData_NoEx();
        void Update_ValidDat_NoEx();
        void Delete_ValidData_NoEx();
        void GetData_ValidData_NoEx();
        void ListData_ValidData_NoEx();
    }

    public class JenisKasDalTest : IJenisKasDalTest
    {
        private IJenisKasDal _jenisKasDal;

        public JenisKasDalTest()
        {
            _jenisKasDal = new JenisKasDal();
        }

        JenisKasModel JenisKasDataFactory()
        {
            var result = new JenisKasModel
            {
                JenisKasID = "A1",
                JenisKasName = "B1"
            };
            return result;
        }

        JenisKasModel JenisKas2DataFactory()
        {
            var result = new JenisKasModel
            {
                JenisKasID = "A2",
                JenisKasName = "B2"
            };
            return result;
        }

        [Fact]
        public void Insert_ValidData_NoEx()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = JenisKasDataFactory();

                //  act
                _jenisKasDal.Insert(expected);

                //  assert
            }
        }

        [Fact]
        public void Update_ValidDat_NoEx()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrang
                var expected = JenisKasDataFactory();

                //  act
                _jenisKasDal.Update(expected);

                //  assert
            }
        }

        [Fact]
        public void Delete_ValidData_NoEx()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = JenisKasDataFactory();
                _jenisKasDal.Insert(expected);

                //  act
                _jenisKasDal.Delete("A");

                //  assert
            }
        }

        [Fact]
        public void GetData_ValidData_NoEx()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = JenisKasDataFactory();
                _jenisKasDal.Insert(expected);

                //  act
                var actual = _jenisKasDal.GetData("A1");

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
                var item1 = JenisKasDataFactory();
                _jenisKasDal.Insert(item1);
                var item2 = JenisKas2DataFactory();
                _jenisKasDal.Insert(item2);
                var expected = new List<JenisKasModel>
                {
                    item1, item2
                };

                //  act
                var actual = _jenisKasDal.ListData();

                //  assert
                actual.Should().BeEquivalentTo(expected);
            }
        }

    }
}
