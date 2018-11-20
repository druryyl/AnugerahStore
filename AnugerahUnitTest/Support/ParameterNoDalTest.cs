using AnugerahBackend.Support;
using AnugerahBackend.Support.Dal;
using AnugerahBackend.Support.Model;
using FluentAssertions;
using Ics.Helper.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AnugerahUnitTest.Support.Dal
{

    public interface IParameterNoDalTest
    {
        void Insert_ValidData_NoEx();
        void Update_ValidDat_NoEx();
        void Delete_ValidData_NoEx();
        void GetData_ValidData_NoEx();
        void ListData_ValidData_NoEx();
    }

    public class ParameterNoDalTest : IParameterNoDalTest
    {
        private IParameterNoDal _parameterNoDal;

        public ParameterNoDalTest()
        {
            _parameterNoDal = new ParameterNoDal();
        }

        ParameterNoModel ParameterNoDataFactory()
        {
            var result = new ParameterNoModel
            {
                Prefix = "A1",
                Value = 1
            };
            return result;
        }

        ParameterNoModel ParameterNo2DataFactory()
        {
            var result = new ParameterNoModel
            {
                Prefix = "A2",
                Value = 2
            };
            return result;
        }

        [Fact]
        public void Insert_ValidData_NoEx()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = ParameterNoDataFactory();

                //  act
                _parameterNoDal.Insert(expected);

                //  assert
            }
        }

        [Fact]
        public void Update_ValidDat_NoEx()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrang
                var expected = ParameterNoDataFactory();

                //  act
                _parameterNoDal.Update(expected);

                //  assert
            }
        }

        [Fact]
        public void Delete_ValidData_NoEx()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = ParameterNoDataFactory();
                _parameterNoDal.Insert(expected);

                //  act
                _parameterNoDal.Delete("A");

                //  assert
            }
        }

        [Fact]
        public void GetData_ValidData_NoEx()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = ParameterNoDataFactory();
                _parameterNoDal.Insert(expected);

                //  act
                var actual = _parameterNoDal.GetData("A1");

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
                var item1 = ParameterNoDataFactory();
                _parameterNoDal.Insert(item1);
                var item2 = ParameterNo2DataFactory();
                _parameterNoDal.Insert(item2);
                var expected = new List<ParameterNoModel>
                {
                    item1, item2
                };

                //  act
                var actual = _parameterNoDal.ListData();

                //  assert
                actual.Should().BeEquivalentTo(expected);
            }
        }

    }
}