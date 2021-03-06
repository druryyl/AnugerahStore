﻿using System;
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
    public interface IBPHutangDetilDalTest
    {
        void InsertTest();
        void DeleteTest();
        void ListDataTest();
    }

    public class BPHutangDetilDalTest : IBPHutangDetilDalTest
    {
        private IBPHutangDetilDal _bpHutangDetilDal;
        public BPHutangDetilDalTest()
        {
            _bpHutangDetilDal = new BPHutangDetilDal();
        }

        private BPHutangDetilModel BPHutangDetilDataFactory()
        {
            var result = new BPHutangDetilModel
            {
                BPHutangID = "A1",
                BPHutangDetilID = "B1",
                ReffID = "C1",
                Tgl = "11-02-2019",
                Jam = "03:21:00",
                Keterangan = "D1",
                NilaiHutang = 51000,
                NilaiLunas = 41000
            };
            return result;
        }

        [Fact]
        public void InsertTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = BPHutangDetilDataFactory();

                //  act
                _bpHutangDetilDal.Insert(expected);

                //  assert

            }
        }

        [Fact]
        public void DeleteTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected = BPHutangDetilDataFactory();
                _bpHutangDetilDal.Insert(expected);

                //  act
                _bpHutangDetilDal.Delete("A1");

                //  assert
            }
        }

        [Fact]
        public void ListDataTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                var expected1 = BPHutangDetilDataFactory();
                _bpHutangDetilDal.Insert(expected1);
                var expected2 = expected1.CloneObject();
                expected2.BPHutangDetilID = "B2";
                _bpHutangDetilDal.Insert(expected2);
                var expected = new List<BPHutangDetilModel>
                {
                    expected1, expected2
                };

                //  act
                var actual = _bpHutangDetilDal.ListData("A1");

                //  assert
                actual.Should().BeEquivalentTo(expected);
            }
        }
    }
}
