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

namespace AnugerahUnitTest.StokBarang.Dal
{

    public interface ISubJenisBrgDalTest
    {
        void Insert_ValidData_NoEx();
        void Update_ValidDat_NoEx();
        void Delete_ValidData_NoEx();
        void GetData_ValidData_NoEx();
        void ListData_ValidData_NoEx();
    }

    public class SubJenisBrgDalTest : ISubJenisBrgDalTest
    {
        private ISubJenisBrgDal _subJenisBrgDal;

        public SubJenisBrgDalTest()
        {
            _subJenisBrgDal = new SubJenisBrgDal();
        }

        SubJenisBrgModel SubJenisBrgDataFactory()
        {
            var result = new SubJenisBrgModel
            {
                SubJenisBrgID = "A1",
                SubJenisBrgName = "B1",
                JenisBrgID = "C1"
            };
            return result;
        }

        SubJenisBrgModel SubJenisBrg2DataFactory()
        {
            var result = new SubJenisBrgModel
            {
                SubJenisBrgID = "A2",
                SubJenisBrgName = "B2",
                JenisBrgID = "C2"
            };
            return result;
        }

        [Fact]
        public void Insert_ValidData_NoEx()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = SubJenisBrgDataFactory();

                //  act
                _subJenisBrgDal.Insert(expected);

                //  assert
            }
        }

        [Fact]
        public void Update_ValidDat_NoEx()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrang
                var expected = SubJenisBrgDataFactory();

                //  act
                _subJenisBrgDal.Update(expected);

                //  assert
            }
        }

        [Fact]
        public void Delete_ValidData_NoEx()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = SubJenisBrgDataFactory();
                _subJenisBrgDal.Insert(expected);

                //  act
                _subJenisBrgDal.Delete("A");

                //  assert
            }
        }

        [Fact]
        public void GetData_ValidData_NoEx()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = SubJenisBrgDataFactory();
                _subJenisBrgDal.Insert(expected);

                //  act
                var actual = _subJenisBrgDal.GetData("A1");

                //  assert
                actual.Should().BeEquivalentTo(expected,
                    config => config
                        .Excluding(x => x.JenisBrgName));
            }
        }

        [Fact]
        public void ListData_ValidData_NoEx()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var item1 = SubJenisBrgDataFactory();
                _subJenisBrgDal.Insert(item1);
                var item2 = SubJenisBrg2DataFactory();
                _subJenisBrgDal.Insert(item2);
                var expected = new List<SubJenisBrgModel>
                {
                    item1, item2
                };

                //  act
                var actual = _subJenisBrgDal.ListData();

                //  assert
                actual.Should().BeEquivalentTo(expected,
                    config => config
                        .Excluding(x => x.JenisBrgName));
            }
        }

    }
}
