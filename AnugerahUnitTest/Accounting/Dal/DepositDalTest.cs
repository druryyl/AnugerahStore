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

    public interface IDepositDalTest
    {
        void Insert_ValidData_NoEx();
        void Update_ValidDat_NoEx();
        void Delete_ValidData_NoEx();
        void GetData_ValidData_NoEx();
        void ListData_ValidData_NoEx();
    }

    public class DepositDalTest : IDepositDalTest
    {
        private IDepositDal _depositDal;

        public DepositDalTest()
        {
            _depositDal = new DepositDal();
        }

        DepositModel DepositDataFactory()
        {
            var result = new DepositModel
            {
                DepositID = "A1",
                Tgl = "17-02-2019",
                Jam = "9:57:31",
                PihakKeduaID = "C1",
                PihakKeduaName = "D1",
                Keterangan = "E1",
                JenisBayarID = "F1",
                JenisBayarName = "G1",
                JenisKasID = "",
                JenisKasName = "",
                NilaiDeposit = 12000
            };
            return result;
        }

        [Fact]
        public void Insert_ValidData_NoEx()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = DepositDataFactory();

                //  act
                _depositDal.Insert(expected);

                //  assert
            }
        }

        [Fact]
        public void Update_ValidDat_NoEx()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrang
                var expected = DepositDataFactory();

                //  act
                _depositDal.Update(expected);

                //  assert
            }
        }

        [Fact]
        public void Delete_ValidData_NoEx()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = DepositDataFactory();
                _depositDal.Insert(expected);

                //  act
                _depositDal.Delete("A");

                //  assert
            }
        }

        [Fact]
        public void GetData_ValidData_NoEx()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = DepositDataFactory();
                _depositDal.Insert(expected);

                //  act
                var actual = _depositDal.GetData("A1");

                //  assert
                actual.Should().BeEquivalentTo(expected,
                    config => config
                        .Excluding(x => x.PihakKeduaName)
                        .Excluding(x => x.JenisBayarName));
            }
        }

        [Fact]
        public void ListData_ValidData_NoEx()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var item1 = DepositDataFactory();
                _depositDal.Insert(item1);
                var item2 = item1.CloneObject();
                item2.DepositID  = "A2";
                _depositDal.Insert(item2);
                var expected = new List<DepositModel>
                {
                    item1, item2
                };

                //  act
                var actual = _depositDal.ListData("17-02-2019", "17-02-2019");

                //  assert
                actual.Should().BeEquivalentTo(expected,
                    config => config
                        .Excluding(x => x.PihakKeduaName)
                        .Excluding(x => x.JenisBayarName));
            }
        }

    }
}
