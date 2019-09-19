using AnugerahBackend.Accounting.Dal;
using AnugerahBackend.Accounting.Model;
using FluentAssertions;
using Ics.Helper.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AnugerahUnitTest.Accounting.Dal
{

    public interface ILunasPiutangDalTest
    {
        void Insert_CekQuery();
        void Update_CekQuery();
        void Delete_CekQuery();

        void GetData_Exist_ReturnExpected();
        void GetData_NotExist_ReturnNull();

        void ListData_Exist_ReturnExpected();
        void ListData_NotExist_ReturnNull();
    }

    public class LunasPiutangDalTest : ILunasPiutangDalTest
    {
        private readonly ILunasPiutangDal _sut;

        //  constructor
        public LunasPiutangDalTest()
        {
            _sut = new LunasPiutangDal();
        }

        //  data factory
        public LunasPiutangModel LunasPiutangFactory1()
        {
            var result = new LunasPiutangModel
            {
                LunasPiutangID = "A1",
                Tgl = "15-01-2019",
                Jam = "01:00:00",
                PihakKeduaID = "B1",
                PihakKeduaName = "",
                PiutangID = "C1",
                TotalNilaiSisaPiutang = 2,
                TotalNilaiBayar = 1,
            };
            return result;
        }
        public LunasPiutangModel LunasPiutangFactory2()
        {
            var result = new LunasPiutangModel
            {
                LunasPiutangID = "A2",
                Tgl = "16-01-2019",
                Jam = "02:00:00",
                PihakKeduaID = "B2",
                PihakKeduaName = "",
                PiutangID = "C2",
                TotalNilaiSisaPiutang = 4,
                TotalNilaiBayar = 3,
            };
            return result;
        }


        [Fact]
        public void Insert_CekQuery()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = LunasPiutangFactory1();

                //  act
                _sut.Insert(expected);

                //  assert
            }
        }

        [Fact]
        public void Update_CekQuery()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = LunasPiutangFactory1();
                _sut.Insert(expected);
                expected.Tgl = "17-01-2019";

                //  act
                _sut.Update(expected);

                //  assert
            }
        }

        [Fact]
        public void Delete_CekQuery()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = LunasPiutangFactory1();
                _sut.Insert(expected);

                //  act
                _sut.Delete("A1");

                //  assert
            }
        }

        [Fact]
        public void GetData_Exist_ReturnExpected()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = LunasPiutangFactory1();
                _sut.Insert(expected);

                //  act
                var actual = _sut.GetData("A1");

                //  assert
                actual.Should().BeEquivalentTo(expected);
            }
        }

        [Fact]
        public void GetData_NotExist_ReturnNull()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange

                //  act
                var actual = _sut.GetData("A1");

                //  assert
                actual.Should().BeNull();
            }
        }

        [Fact]
        public void ListData_Exist_ReturnExpected()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected1 = LunasPiutangFactory1();
                var expected2 = LunasPiutangFactory2();
                var expected = new List<LunasPiutangModel>
                {
                    expected1, expected2
                };
                _sut.Insert(expected1);
                _sut.Insert(expected2);

                //  act
                var actual = _sut.ListData();

                //  assert
                actual.Should().BeEquivalentTo(actual);
            }
        }

        [Fact]
        public void ListData_NotExist_ReturnNull()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange

                //  act
                var actual = _sut.ListData();

                //  assert
                actual.Should().BeNull();
            }
        }
    }
}
