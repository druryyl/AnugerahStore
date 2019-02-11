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

    public interface IJenisLunasDalTest
    {
        void Insert_ValidData_NoEx();
        void Update_ValidDat_NoEx();
        void Delete_ValidData_NoEx();
        void GetData_ValidData_NoEx();
        void ListData_ValidData_NoEx();
    }

    public class JenisLunasDalTest : IJenisLunasDalTest
    {
        private IJenisLunasDal _jenisLunasDal;

        public JenisLunasDalTest()
        {
            _jenisLunasDal = new JenisLunasDal();
        }

        JenisLunasModel JenisLunasDataFactory()
        {
            var result = new JenisLunasModel
            {
                JenisLunasID = "A1",
                JenisLunasName = "B1"
            };
            return result;
        }

        JenisLunasModel JenisLunas2DataFactory()
        {
            var result = new JenisLunasModel
            {
                JenisLunasID = "A2",
                JenisLunasName = "B2"
            };
            return result;
        }

        [Fact]
        public void Insert_ValidData_NoEx()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = JenisLunasDataFactory();

                //  act
                _jenisLunasDal.Insert(expected);

                //  assert
            }
        }

        [Fact]
        public void Update_ValidDat_NoEx()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrang
                var expected = JenisLunasDataFactory();

                //  act
                _jenisLunasDal.Update(expected);

                //  assert
            }
        }

        [Fact]
        public void Delete_ValidData_NoEx()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = JenisLunasDataFactory();
                _jenisLunasDal.Insert(expected);

                //  act
                _jenisLunasDal.Delete("A");

                //  assert
            }
        }

        [Fact]
        public void GetData_ValidData_NoEx()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = JenisLunasDataFactory();
                _jenisLunasDal.Insert(expected);

                //  act
                var actual = _jenisLunasDal.GetData("A1");

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
                var item1 = JenisLunasDataFactory();
                _jenisLunasDal.Insert(item1);
                var item2 = JenisLunas2DataFactory();
                _jenisLunasDal.Insert(item2);
                var expected = new List<JenisLunasModel>
                {
                    item1, item2
                };

                //  act
                var actual = _jenisLunasDal.ListData();

                //  assert
                actual.Should().BeEquivalentTo(expected);
            }
        }

    }
}
