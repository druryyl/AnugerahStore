using AnugerahBackend.Keuangan.Dal;
using AnugerahBackend.Keuangan.Model;
using FluentAssertions;
using Ics.Helper.Database;
using Ics.Helper.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AnugerahUnitTest.Keuangan
{
    public interface IBukuPiutangLunasDalTest
    {
        void InsertTest();
        void UpdateTest();
        void DeleteTest();
        void GetDataTest();
        void ListDataTest();
    }
    public class BukuPiutangLunasDalTest : IBukuPiutangLunasDalTest
    {
        private IBukuPiutangLunasDal _bukuPiutangLunasDal;

        public BukuPiutangLunasDalTest()
        {
            _bukuPiutangLunasDal = new BukuPiutangLunasDal();
        }

        [Fact]
        private BukuPiutangLunasModel BukuPiutangLunasDataFactory()
        {
            var result = new BukuPiutangLunasModel
            {
                BukuPiutangLunasID = "A1",
                BukuPiutangID = "B1",
                TglLunas = "31-01-2019",
                JamLunas = "01:02:03",
                NilaiLunas = 1200,
                BukuKasID = "C1"
            };
            return result;
        }

        [Fact]
        public void InsertTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = BukuPiutangLunasDataFactory();

                //  act
                _bukuPiutangLunasDal.Insert(expected);

                //  assert

            }
        }

        [Fact]
        public void UpdateTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = BukuPiutangLunasDataFactory();

                //  act
                _bukuPiutangLunasDal.Update(expected);

                //  assert

            }
        }

        [Fact]
        public void DeleteTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = BukuPiutangLunasDataFactory();

                //  act
                _bukuPiutangLunasDal.Delete(expected.BukuPiutangLunasID);

                //  assert

            }
        }

        [Fact]
        public void GetDataTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = BukuPiutangLunasDataFactory();
                _bukuPiutangLunasDal.Insert(expected);

                //  act
                var actual = _bukuPiutangLunasDal.GetData(expected.BukuPiutangLunasID);

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
                var expected1 = BukuPiutangLunasDataFactory();
                _bukuPiutangLunasDal.Insert(expected1);
                var expected2 = expected1.CloneObject();
                expected2.BukuPiutangLunasID = "A2";
                _bukuPiutangLunasDal.Insert(expected2);
                var expected = new List<BukuPiutangLunasModel>
                {
                    expected1, expected2
                };

                //  act
                var actual = _bukuPiutangLunasDal.ListData(expected1.BukuPiutangID);

                //  assert
                actual.Should().BeEquivalentTo(expected);
            }
        }
    }
}
