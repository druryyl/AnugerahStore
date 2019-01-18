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
    public interface IStokInDalTest
    {
        void InsertTest();
        void UpdateTest();
        void DeleteTest();
        void GetDataTest();
        void ListDataTest();
        void ListDataByStokControl();

    }

    public class StokInDalTest : IStokInDalTest
    {
        private IStokInDal _stokInDal;

        public StokInDalTest()
        {
            _stokInDal = new StokInDal();
        }

        StokInModel StokInDataFactory()
        {
            var result = new StokInModel
            {
                StokInID = "A1",
                BrgID = "B1",
                BrgName = "C1",
                TglMasuk = "20-01-1990",
                JamMasuk = "09:09:09",
                TrsMasukID = "D1",
                QtyIn = 30,
                QtySaldo = 5,
                Hpp = 25900,
                StokControlID = "E1",
                TrsDOID = "F1"
            };
            return result;
        }

        StokInModel StokInDataFactory2()
        {
            var result = new StokInModel
            {
                StokInID = "A2",
                BrgID = "B1",
                BrgName = "C2",
                TglMasuk = "21-01-1990",
                JamMasuk = "10:09:09",
                TrsMasukID = "D2",
                QtyIn = 20,
                QtySaldo = 15,
                Hpp = 25100,
                StokControlID = "E2",
                TrsDOID = "F2"
            };
            return result;
        }

        [Fact]
        public void InsertTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = StokInDataFactory();

                //  act
                _stokInDal.Insert(expected);
                
                //  assert  

            }
        }

        [Fact]
        public void UpdateTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = StokInDataFactory();

                //  act
                _stokInDal.Update(expected);

                //  assert  
            }
        }

        [Fact]
        public void DeleteTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = StokInDataFactory();
                _stokInDal.Insert(expected);

                //  act
                _stokInDal.Delete("A1");

                //  assert
            }
        }

        [Fact]
        public void GetDataTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = StokInDataFactory();
                _stokInDal.Insert(expected);

                //  act
                var actual = _stokInDal.GetData("A1");

                //  assert
                actual.Should().BeEquivalentTo(expected,
                    config => config
                        .Excluding(x => x.BrgName));
            }
        }

        [Fact]
        public void ListDataTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var item1 = StokInDataFactory();
                _stokInDal.Insert(item1);
                var item2 = StokInDataFactory2();
                _stokInDal.Insert(item2);
                var expected = new List<StokInModel>
                {
                    item1, item2
                };

                //  act
                var actual = _stokInDal.ListData("B1");

                //  assert
                actual.Should().BeEquivalentTo(expected,
                    config => config
                        .Excluding(x => x.BrgName));
            }
        }

        [Fact]
        public void ListDataByStokControl()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var item1 = StokInDataFactory();
                _stokInDal.Insert(item1);
                var item2 = StokInDataFactory2();
                item2.StokControlID = item1.StokControlID;
                _stokInDal.Insert(item2);
                var expected = new List<StokInModel>
                {
                    item1, item2
                };

                //  act
                var actual = _stokInDal.ListDataByStokControl(item1.StokControlID);

                //  assert
                actual.Should().BeEquivalentTo(expected,
                    config => config
                        .Excluding(x => x.BrgName));
            }
        }
    }
}
