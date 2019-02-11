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

    public interface IBPKasDalTest
    {
        void InsertTest();
        void UpdateTest();
        void DeletetTest();
        void GetDataTest();
        void ListDataTest();
    }

    public class BPKasDalTest : IBPKasDalTest
    {
        private IBPKasDal _bpKasDal;

        public BPKasDalTest()
        {
            _bpKasDal = new BPKasDal();
        }

        private BPKasModel BPKasDataFactory()
        {
            var result = new BPKasModel
            {
                BPKasID = "A1",
                Tgl = "11-02-2019",
                Jam = "01:38:00",
                Keterangan = "C1",
                NilaiTotalKas = 250000
            };
            return result;
        }

        [Fact]
        public void InsertTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = BPKasDataFactory();

                //  act
                _bpKasDal.Insert(expected);


                //  assert
            }
        }
        [Fact]
        public void UpdateTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = BPKasDataFactory();
                _bpKasDal.Insert(expected);

                //  act
                _bpKasDal.Update(expected);

                //  assert
            }
        }

        [Fact]
        public void DeletetTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = BPKasDataFactory();
                _bpKasDal.Insert(expected);

                //  act
                _bpKasDal.Delete("A1");

                //  assert
            }
        }

        [Fact]
        public void GetDataTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = BPKasDataFactory();
                _bpKasDal.Insert(expected);

                //  act
                var actual = _bpKasDal.GetData("A1");

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
                var expected1 = BPKasDataFactory();
                _bpKasDal.Insert(expected1);
                var expected2 = expected1.CloneObject();
                expected2.BPKasID = "A2";
                _bpKasDal.Insert(expected2);

                var expected = new List<BPKasModel>
                {
                    expected1, expected2
                };

                //  act
                var actual = _bpKasDal.ListData(expected1.Tgl, expected1.Tgl);

                //  assert
                actual.Should().BeEquivalentTo(expected);
            }
        }
    }
}
