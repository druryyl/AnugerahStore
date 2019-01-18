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
    public interface IStokInOutDalTest
    {
        void InsertTest();
        void DeleteTest();
        void GetDataTest();
        void ListDataTest();
    }

    public class StokInOutDalTest : IStokInOutDalTest
    {
        private IStokInOutDal _stokInOutDal;

        public StokInOutDalTest()
        {
            _stokInOutDal = new StokInOutDal();
        }

        StokInOutModel StokInOutDataFactory()
        {
            var result = new StokInOutModel
            {
                StokInID = "A1",
                StokInOutID = "B1",
                TglTrs = "01-01-2000",
                JamTrs = "09:09:09",
                ReffTrsID = "C1",
                JenisMutasiID = "D1",
                BrgID = "E1",
                BrgName = "F1",
                StokControlID = "G1",
                QtyIn = 8,
                QtyOut = 0,
                Hpp = 210000,
                HargaJual = 22000,
            };
            return result;
        }

        StokInOutModel StokInOutDataFactory2()
        {
            var result = new StokInOutModel
            {
                StokInID = "A2",
                StokInOutID = "B2",
                TglTrs = "02-01-2000",
                JamTrs = "02:09:09",
                ReffTrsID = "C2",
                JenisMutasiID = "D2",
                BrgID = "E2",
                BrgName = "F2",
                StokControlID = "G2",
                QtyIn = 0,
                QtyOut = 4,
                Hpp = 220000,
                HargaJual = 32000,
            };
            return result;
        }

        [Fact]
        public void InsertTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = StokInOutDataFactory();

                //  act
                _stokInOutDal.Insert(expected);

                //  assert
            }
        }

        [Fact]
        public void DeleteTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = StokInOutDataFactory();
                _stokInOutDal.Insert(expected);

                //  act
                _stokInOutDal.Delete(expected.StokInOutID);

                //  assert
            }
        }

        [Fact]
        public void GetDataTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = StokInOutDataFactory();
                _stokInOutDal.Insert(expected);

                //  act
                var actual = _stokInOutDal.GetData(expected.StokInOutID);

                //  assert
                actual.Should().BeEquivalentTo(expected,
                    config => config
                        .Excluding(x => x.BrgName)
                        .Excluding(x => x.JenisMutasiName));
            }
        }

        [Fact]
        public void ListDataTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected1 = StokInOutDataFactory();
                _stokInOutDal.Insert(expected1);
                var expected2 = StokInOutDataFactory2();
                expected2.StokInID = expected1.StokInID;
                _stokInOutDal.Insert(expected2);
                var expected = new List<StokInOutModel>
                {
                    expected1, expected2
                };

                //  act
                var actual = _stokInOutDal.ListData(expected1.StokInID);

                //  assert
                actual.Should().BeEquivalentTo(expected,
                    config => config
                        .Excluding(x => x.BrgName)
                        .Excluding(x => x.JenisMutasiName));
            }
        }
    }
}
