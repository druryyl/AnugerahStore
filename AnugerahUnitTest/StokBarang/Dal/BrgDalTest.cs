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

    public interface IBrgDalTest
    {
        void Insert_ValidData_NoEx();
        void Update_ValidDat_NoEx();
        void Delete_ValidData_NoEx();
        void GetData_ValidData_NoEx();
        void ListData_ValidData_NoEx();
    }

    public class BrgDalTest : IBrgDalTest
    {
        private IBrgDal _brgDal;

        public BrgDalTest()
        {
            _brgDal = new BrgDal();
        }

        BrgModel BrgDataFactory()
        {
            var result = new BrgModel
            {
                BrgID = "A1",
                BrgName = "B1",
                Keterangan = "C1",
                SubJenisBrgID = "D1",
                MerkID = "E1",
                ColorID = "F1",
                Kemasan = "G1",
            };
            return result;
        }

        BrgModel Brg2DataFactory()
        {
            var result = new BrgModel
            {
                BrgID = "A2",
                BrgName = "B2",
                Keterangan = "C2",
                SubJenisBrgID = "D2",
                MerkID = "E2",
                ColorID = "F2",
                Kemasan = "G2"
            };
            return result;
        }

        [Fact]
        public void Insert_ValidData_NoEx()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = BrgDataFactory();

                //  act
                _brgDal.Insert(expected);

                //  assert
            }
        }

        [Fact]
        public void Update_ValidDat_NoEx()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrang
                var expected = BrgDataFactory();

                //  act
                _brgDal.Update(expected);

                //  assert
            }
        }

        [Fact]
        public void Delete_ValidData_NoEx()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = BrgDataFactory();
                _brgDal.Insert(expected);

                //  act
                _brgDal.Delete("A");

                //  assert
            }
        }

        [Fact]
        public void GetData_ValidData_NoEx()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = BrgDataFactory();
                _brgDal.Insert(expected);

                //  act
                var actual = _brgDal.GetData("A1");

                //  assert
                actual.Should().BeEquivalentTo(expected,
                    config => config
                        .Excluding(x => x.SubJenisBrgName)
                        .Excluding(x => x.ColorName)
                        .Excluding(x => x.MerkName)
                        .Excluding(x => x.CreateTimestamp)
                        .Excluding(x => x.UpdateTimestamp)
                        .Excluding(x => x.JenisBrgID)
                        .Excluding(x => x.JenisBrgName));
            }
        }

        [Fact]
        public void ListData_ValidData_NoEx()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var item1 = BrgDataFactory();
                _brgDal.Insert(item1);
                var item2 = Brg2DataFactory();
                _brgDal.Insert(item2);
                var expected = new List<BrgModel>
                {
                    item1, item2
                };

                //  act
                var actual = _brgDal.ListData();

                //  assert
                actual.Should().BeEquivalentTo(expected,
                    config => config
                        .Excluding(x => x.SubJenisBrgName)
                        .Excluding(x => x.ColorName)
                        .Excluding(x => x.MerkName)
                        .Excluding(x => x.CreateTimestamp)
                        .Excluding(x => x.UpdateTimestamp)
                        .Excluding(x => x.JenisBrgID)
                        .Excluding(x => x.JenisBrgName));
            }
        }
    }
}
