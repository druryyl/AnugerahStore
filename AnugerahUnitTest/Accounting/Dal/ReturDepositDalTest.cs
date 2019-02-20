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

    public interface IReturDepositDalTest
    {
        void InsertTest();
        void UpdateTest();
        void DeletetTest();
        void GetDataTest();
        void ListDataTest();
    }

    public class ReturDepositDalTest : IReturDepositDalTest
    {
        private IReturDepositDal _returDepositDal;

        public ReturDepositDalTest()
        {
            _returDepositDal = new ReturDepositDal();
        }

        private ReturDepositModel ReturDepositDataFactory()
        {
            var result = new ReturDepositModel
            {
                ReturDepositID = "A1",
                Tgl = "11-02-2019",
                Jam = "01:38:00",
                DepositID = "B1",
                JenisKasID = "C1",
                Catatan = "D1",
                NilaiSisaDeposit = 2000,
                NilaiReturDeposit = 1500
            };
            return result;
        }

        [Fact]
        public void InsertTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = ReturDepositDataFactory();

                //  act
                _returDepositDal.Insert(expected);


                //  assert
            }
        }
        [Fact]
        public void UpdateTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = ReturDepositDataFactory();
                _returDepositDal.Insert(expected);

                //  act
                _returDepositDal.Update(expected);

                //  assert
            }
        }

        [Fact]
        public void DeletetTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = ReturDepositDataFactory();
                _returDepositDal.Insert(expected);

                //  act
                _returDepositDal.Delete("A1");

                //  assert
            }
        }

        [Fact]
        public void GetDataTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = ReturDepositDataFactory();
                _returDepositDal.Insert(expected);

                //  act
                var actual = _returDepositDal.GetData("A1");

                //  assert
                actual.Should().BeEquivalentTo(expected,
                    config => config
                        .Excluding(x => x.PihakKeduaName)
                        .Excluding(x => x.JenisKasName));
            }
        }

        [Fact]
        public void ListDataTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected1 = ReturDepositDataFactory();
                _returDepositDal.Insert(expected1);
                var expected2 = expected1.CloneObject();
                expected2.ReturDepositID = "A2";
                _returDepositDal.Insert(expected2);

                var expected = new List<ReturDepositModel>
                {
                    expected1, expected2
                };

                //  act
                var actual = _returDepositDal.ListData(expected1.Tgl, expected1.Tgl);

                //  assert
                actual.Should().BeEquivalentTo(expected,
                    config => config
                        .Excluding(x => x.PihakKeduaName)
                        .Excluding(x => x.JenisKasName));
            }
        }
    }
}
