using AnugerahBackend.StokBarang.Dal;
using AnugerahBackend.StokBarang.Model;
using FluentAssertions;
using Ics.Helper.Database;
using Ics.Helper.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AnugerahUnitTest.StokBarang.Dal
{
    public interface IStokAdjustment2DalTest
    {
        void InsertTest();
        void DeleteTest();
        void ListDataTest();

    }
    public class StokAdjustment2DalTest : IStokAdjustment2DalTest
    {
        public IStokAdjustment2Dal _stokAdjustment2Dal;

        public StokAdjustment2DalTest()
        {
            _stokAdjustment2Dal = new StokAdjustment2Dal();
        }

        StokAdjustment2Model StokAdjustment2DataFactory()
        {
            var result = new StokAdjustment2Model
            {
                StokAdjustmentID = "A1",
                StokAdjustmentID2 = "A11",
                NoUrut = 1,
                BrgID = "B1",
                BrgName = "",
                QtyAwal = 10,
                QtyAdjust = -2,
                QtyAkhir = 8,
                HppAdjust = 10000
            };
            return result;
        }

        StokAdjustment2Model StokAdjustment22DataFactory()
        {
            var result = new StokAdjustment2Model
            {
                StokAdjustmentID = "A1",
                StokAdjustmentID2 = "A12",
                NoUrut = 2,
                BrgID = "B2",
                BrgName = "",
                QtyAwal = 11,
                QtyAdjust = -3,
                QtyAkhir = 9,
                HppAdjust = 11000
            };
            return result;
        }


        [Fact]
        public void InsertTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = StokAdjustment2DataFactory();

                //  act
                _stokAdjustment2Dal.Insert(expected);


                //  assert
            }
        }

        [Fact]
        public void DeleteTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = StokAdjustment2DataFactory();
                _stokAdjustment2Dal.Insert(expected);

                //  act
                _stokAdjustment2Dal.Delete(expected.StokAdjustmentID);

                //  assert
            }
        }

        [Fact]
        public void ListDataTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected1 = StokAdjustment2DataFactory();
                //var expected2 = StokAdjustment22DataFactory();
                var expected2 = expected1.CloneObject();
                expected2.BrgID = "B2";
                expected2.StokAdjustmentID2 = "C2";
                _stokAdjustment2Dal.Insert(expected1);
                _stokAdjustment2Dal.Insert(expected2);
                var expected = new List<StokAdjustment2Model>
                {
                    expected1, expected2
                };

                //  act
                var actual = _stokAdjustment2Dal.ListData(expected1.StokAdjustmentID);

                //  assert
                actual.Should().BeEquivalentTo(expected,
                    config => config
                        .Excluding(x => x.BrgName));
            }
        }
    }
}
