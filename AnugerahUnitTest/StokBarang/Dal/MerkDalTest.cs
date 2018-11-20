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

namespace AnugerahUnitTest.StokBarang.Dal
{

    public interface IMerkDalTest
    {
        void Insert_ValidData_NoEx();
        void Update_ValidDat_NoEx();
        void Delete_ValidData_NoEx();
        void GetData_ValidData_NoEx();
        void ListData_ValidData_NoEx();
    }

    public class MerkDalTest : IMerkDalTest
    {
        private IMerkDal _merkDal;

        public MerkDalTest()
        {
            _merkDal = new MerkDal();
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

        MerkModel Merk2DataFactory()
        {
            var result = new MerkModel
            {
                MerkID = "A2",
                MerkName = "B2"
            };
            return result;
        }

        [Fact]
        public void Insert_ValidData_NoEx()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = MerkDataFactory();

                //  act
                _merkDal.Insert(expected);

                //  assert
            }
        }

        [Fact]
        public void Update_ValidDat_NoEx()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrang
                var expected = MerkDataFactory();

                //  act
                _merkDal.Update(expected);

                //  assert
            }
        }

        [Fact]
        public void Delete_ValidData_NoEx()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = MerkDataFactory();
                _merkDal.Insert(expected);

                //  act
                _merkDal.Delete("A");

                //  assert
            }
        }

        [Fact]
        public void GetData_ValidData_NoEx()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = MerkDataFactory();
                _merkDal.Insert(expected);

                //  act
                var actual = _merkDal.GetData("A1");

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
                var item1 = MerkDataFactory();
                _merkDal.Insert(item1);
                var item2 = Merk2DataFactory();
                _merkDal.Insert(item2);
                var expected = new List<MerkModel>
                {
                    item1, item2
                };

                //  act
                var actual = _merkDal.ListData();

                //  assert
                actual.Should().BeEquivalentTo(expected);
            }
        }

    }
}
