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
    public interface IStokAdjustmentDalTest
    {
        void InsertTest();
        void UpdateTest();
        void DeleteTest();
        void GetDataTest();
        void ListDataTest();

    }

    public class StokAdjustmentDalTest : IStokAdjustmentDalTest
    {
        public IStokAdjustmentDal _stokAdjustmentDal;

        public StokAdjustmentDalTest()
        {
            _stokAdjustmentDal = new StokAdjustmentDal();
        }

        StokAdjustmentModel StokAdjustmentDataFactory()
        {
            var result = new StokAdjustmentModel
            {
                StokAdjustmentID = "A1",
                TglTrs = "01-01-2000",
                JamTrs = "12:12:11",
                UserrID = "B1",
                TglVoid = "01-01-3000",
                JamVoid = "00:00:00",
                UserrIDVoid = "C1",
                Keterangan = "D1",
                ListBrg = null,
            };
            return result;
        }
        [Fact]
        public void InsertTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = StokAdjustmentDataFactory();

                //  act
                _stokAdjustmentDal.Insert(expected);

                //  assert

            }
        }

        [Fact]
        public void UpdateTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = StokAdjustmentDataFactory();

                //  act
                _stokAdjustmentDal.Update(expected);

                //  assert
            }
        }

        [Fact]
        public void DeleteTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = StokAdjustmentDataFactory();
                _stokAdjustmentDal.Insert(expected);

                //  act
                _stokAdjustmentDal.Delete(expected.StokAdjustmentID);

                //  assert
            }
        }

        [Fact]
        public void GetDataTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = StokAdjustmentDataFactory();
                _stokAdjustmentDal.Insert(expected);

                //  act
                var actual = _stokAdjustmentDal.GetData(expected.StokAdjustmentID);

                //  assert
                actual.Should().BeEquivalentTo(expected,
                    config => config
                        .Excluding(x => x.ListBrg));
            }
        }

        [Fact]
        public void ListDataTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected1 = StokAdjustmentDataFactory();
                var expected2 = expected1.CloneObject();
                expected2.StokAdjustmentID = "A2";
                var expected = new List<StokAdjustmentModel>
                {
                    expected1, expected2
                };
                _stokAdjustmentDal.Insert(expected1);
                _stokAdjustmentDal.Insert(expected2);

                //  act
                var actual = _stokAdjustmentDal.ListData(expected1.TglTrs, expected2.TglTrs);


                //  assert
                actual.Should().BeEquivalentTo(expected,
                    config => config
                        .Excluding(x => x.ListBrg));
            }
        }
    }
}
