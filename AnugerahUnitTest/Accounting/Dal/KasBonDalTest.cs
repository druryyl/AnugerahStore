using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnugerahBackend.Accounting.Dal;
using AnugerahBackend.Accounting.Model;
using FluentAssertions;
using Ics.Helper.Database;
using Ics.Helper.Extensions;
using Xunit;

namespace AnugerahUnitTest.Accounting.Dal
{
    public interface IKasBonDalTest
    {
        void InsertTest();
        void UpdateTest();
        void DeletetTest();
        void GetDataTest();
        void ListDataTest();
    }

    public class KasBonDalTest : IKasBonDalTest
    {
        private IKasBonDal _kasBonDal;

        public KasBonDalTest()
        {
            _kasBonDal = new KasBonDal();
        }

        private KasBonModel KasBonDataFactory()
        {
            var result = new KasBonModel
            {
                KasBonID = "A1",
                Tgl = "11-02-2019",
                Jam = "01:38:00",
                Keterangan = "B1",
                PihakKeduaID = "C1",
                PihakKeduaName = "",
                NilaiKasBon = 300000
            };
            return result;
        }

        [Fact]
        public void InsertTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = KasBonDataFactory();

                //  act
                _kasBonDal.Insert(expected);


                //  assert
            }
        }
        [Fact]
        public void UpdateTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = KasBonDataFactory();
                _kasBonDal.Insert(expected);

                //  act
                _kasBonDal.Update(expected);

                //  assert
            }
        }

        [Fact]
        public void DeletetTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = KasBonDataFactory();
                _kasBonDal.Insert(expected);

                //  act
                _kasBonDal.Delete("A1");

                //  assert
            }
        }

        [Fact]
        public void GetDataTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = KasBonDataFactory();
                _kasBonDal.Insert(expected);

                //  act
                var actual = _kasBonDal.GetData("A1");

                //  assert
                actual.Should().BeEquivalentTo(expected);
            }
        }

        [Fact]
        public void ListDataTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected1 = KasBonDataFactory();
                _kasBonDal.Insert(expected1);
                var expected2 = expected1.CloneObject();
                expected2.KasBonID = "A2";
                _kasBonDal.Insert(expected2);

                var expected = new List<KasBonModel>
                {
                    expected1, expected2
                };

                //  act
                var actual = _kasBonDal.ListData(expected1.Tgl, expected1.Tgl);

                //  assert
                actual.Should().BeEquivalentTo(expected);
            }
        }
    }
}
