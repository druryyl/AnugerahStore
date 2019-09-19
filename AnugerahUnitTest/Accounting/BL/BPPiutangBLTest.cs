using AnugerahBackend.Accounting.BL;
using AnugerahBackend.Accounting.Dal;
using AnugerahBackend.Accounting.Model;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AnugerahUnitTest.Accounting.BL
{
    public class BPPiutangBLTest
    {
        private readonly BPPiutangBL _sut;
        private readonly Mock<IBPPiutangDal> _mockBPPiutangDal;

        public BPPiutangBLTest()
        {
            _mockBPPiutangDal = new Mock<IBPPiutangDal>();
            _sut = new BPPiutangBL(_mockBPPiutangDal.Object);
        }

        private BPPiutangModel BPPiutangFactory1()
        {
            var result = new BPPiutangModel
            {
                BPPiutangID = "A1",
                Tgl = "01-01-2019",
                Jam = "09:00:00",
                PihakKeduaID = "B1",
                PihakKeduaName = "C1",
                Keterangan = "D1",
                NilaiLunas = 0,
                NilaiPiutang = 25000,
                ListLunas = new List<BPPiutangDetilModel>
                {
                    new BPPiutangDetilModel
                    {
                        BPPiutangID = "A1",
                        BPPiutangDetilID = "E1",
                        ReffID = "F1",
                        Tgl = "01-01-2019",
                        Jam = "09:00:00",
                        Keterangan = "G1",
                        NilaiPiutang = 1000,
                        NilaiLunas = 0
                    }
                }
            };
            return result;
        }

        private BPPiutangModel BPPiutangFactory2()
        {
            var result = new BPPiutangModel
            {
                BPPiutangID = "A2",
                Tgl = "02-01-2019",
                Jam = "09:00:00",
                PihakKeduaID = "B1",
                PihakKeduaName = "C2",
                Keterangan = "D2",
                NilaiLunas = 1500,
                NilaiPiutang = 1500,
                ListLunas = new List<BPPiutangDetilModel>
                {
                    new BPPiutangDetilModel
                    {
                        BPPiutangID = "A2",
                        BPPiutangDetilID = "E2",
                        ReffID = "F2",
                        Tgl = "01-01-2019",
                        Jam = "09:00:00",
                        Keterangan = "G2",
                        NilaiPiutang = 1500,
                        NilaiLunas = 1500 
                    }
                }
            };
            return result;
        }

        [Fact]
        public void ListByCustomer_OnlyReturnCustomerWithPiutang()
        {
            //  arrange
            var expected = BPPiutangFactory1();
            var data2 = BPPiutangFactory2();
            var listPiutang = new List<BPPiutangModel>
            {
                expected, data2
            };
            _mockBPPiutangDal.Setup(x => x.ListData("B1"))
                .Returns(listPiutang);

            //  act
            var actual = _sut.ListByCustomer("B1");

            //  assert
            actual.FirstOrDefault().Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void ListByCustomer_AllCustomerPiutangLunas_ReturnNull()
        {
            //  arrange
            var expected = BPPiutangFactory1();
            expected.NilaiLunas = expected.NilaiPiutang;
            var data2 = BPPiutangFactory2();
            var listPiutang = new List<BPPiutangModel>
            {
                expected, data2
            };
            _mockBPPiutangDal.Setup(x => x.ListData("B1"))
                .Returns(listPiutang);

            //  act
            var actual = _sut.ListByCustomer("B1");

            //  assert
            actual.Should().BeNull();
        }
    }
}
