using System;
using System.Collections.Generic;
using AnugerahBackend.StokBarang.BL;
using AnugerahBackend.StokBarang.Dal;
using AnugerahBackend.StokBarang.Model;
using FluentAssertions;
using Ics.Helper.Extensions;
using Moq;
using Xunit;

namespace AnugerahUnitTest.StokBarang.BL
{
    public interface IBPStokBLTest
    {
        void Generate_AdjPlus_Berhasil();
        void Generate_AdjMin_SingleStokControl_Berhasil();
        void Generate_AdjMin_SingleStokControl_StokTidakCukup();
        void Generate_AdjMin_MultiStokControl_Berhasil();
        void Generate_AdjMin_MultiStokControl_StokTidakCukup();

    }
    public class BPStokBLTest : IBPStokBLTest
    {
        private IBPStokBL _bpStokBL;
        private Mock<IBPStokDal> _bpStokDal;
        private Mock<IBPStokDetilDal> _bpStokDetilDal;

        public BPStokBLTest()
        {
            _bpStokDal = new Mock<IBPStokDal>();
            _bpStokDetilDal = new Mock<IBPStokDetilDal>();
            _bpStokBL = new BPStokBL(_bpStokDal.Object, _bpStokDetilDal.Object);
        }

        #region DATA-FACTORY
        private BPStokModel BPStokHeaderDataFactory()
        {
            var result = new BPStokModel
            {
                BPStokID = "A1B1",
                BrgID = "B1",
                ReffID = "A1",
                Tgl = "20-02-2019",
                Jam = "21:39:00",
                NilaiHpp = 2000,
                QtyIn = 5,
                QtySisa = 5,
            };
            return result;
        }
        private BPStokDetilModel BPStokDetilDataFactory()
        {
            var result = new BPStokDetilModel
            {
                BPStokID = "A1B1",
                BPStokDetilID = "A1B1-001",
                NoUrut = 1,
                ReffID = "A1",
                Tgl = "20-02-2019",
                Jam = "21:39:00",
                QtyIn = 5,
                NilaiHpp = 2000,
                QtyOut = 0,
                HargaJual = 0,
            };
            return result;
        }
        private StokAdjustmentModel StokAdjustmentHeaderDataFactory()
        {
            var result = new StokAdjustmentModel
            {
                StokAdjustmentID = "A1",
                TglTrs = "20-02-2019",
                JamTrs = "21:39:00",
            };
            return result;
        }
        private StokAdjustment2Model StokAdjustmentDetilDataFactory()
        {
            var result = new StokAdjustment2Model
            {
                BrgID = "B1",
                QtyAdjust = 5,
                HppAdjust = 2000
            };
            return result;
        }
        #endregion

        [Fact]
        public void Generate_AdjPlus_Berhasil()
        {
            #region ARRANGE
            //  --trs adj
            var adj = StokAdjustmentHeaderDataFactory();
            adj.ListBrg = new List<StokAdjustment2Model>
            {
                StokAdjustmentDetilDataFactory()
            };
            //  -- bp stok
            var expected = BPStokHeaderDataFactory();
            expected.ListDetil = new List<BPStokDetilModel>
            {
                BPStokDetilDataFactory()
            }; 
            #endregion

            //  act
            var actual = _bpStokBL.Generate(adj);


            //  assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Generate_AdjMin_SingleStokControl_Berhasil()
        {
            #region ARRANGE
            //  arrange
            var adj = StokAdjustmentHeaderDataFactory();
            var adjDetil = StokAdjustmentDetilDataFactory();
            adj.ListBrg = new List<StokAdjustment2Model> { adjDetil };
            adjDetil.QtyAdjust = -3;
            //  bp stok
            var existingBPStok = BPStokHeaderDataFactory();
            existingBPStok.ListDetil = new List<BPStokDetilModel>
            {
                BPStokDetilDataFactory()
            };
            //  expected
            var expected1 = existingBPStok.CloneObject();
            expected1.QtySisa = 2;
            var addedDetil = new BPStokDetilModel
            {
                BPStokID = "A1B1",
                BPStokDetilID = "A1B1-002",
                NoUrut = 2,
                ReffID = "A1",
                Tgl = "20-02-2019",
                Jam = "21:39:00",
                QtyIn = 0,
                NilaiHpp = 0,
                QtyOut = 3,
                HargaJual = 2000,
            };
            expected1.ListDetil.Add(addedDetil);
            var expected = new List<BPStokModel> { expected1 };

            //  setup mocking
            _bpStokDal.Setup(x => x.ListData("B1"))
                .Returns(new List<BPStokModel> { BPStokHeaderDataFactory() });
            _bpStokDetilDal.Setup(x => x.ListData("A1B1"))
                .Returns(new List<BPStokDetilModel> { BPStokDetilDataFactory() });
            #endregion

            //  act
            var actual = _bpStokBL.Generate(adj);

            //  assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Generate_AdjMin_SingleStokControl_StokTidakCukup()
        {
            #region ARRANGE
            //  arrange
            var adj = StokAdjustmentHeaderDataFactory();
            var adjDetil = StokAdjustmentDetilDataFactory();
            adj.ListBrg = new List<StokAdjustment2Model> { adjDetil };
            adjDetil.QtyAdjust = -6;
            //  bp stok
            var existingBPStok = BPStokHeaderDataFactory();
            existingBPStok.ListDetil = new List<BPStokDetilModel>
            {
                BPStokDetilDataFactory()
            };
            //  expected
            var expected1 = existingBPStok.CloneObject();
            expected1.QtySisa = 2;
            var addedDetil = new BPStokDetilModel
            {
                BPStokID = "A1B1",
                BPStokDetilID = "A1B1-002",
                NoUrut = 2,
                ReffID = "A1",
                Tgl = "20-02-2019",
                Jam = "21:39:00",
                QtyIn = 0,
                NilaiHpp = 0,
                QtyOut = 3,
                HargaJual = 2000,
            };
            expected1.ListDetil.Add(addedDetil);
            var expected = new List<BPStokModel> { expected1 };

            //  setup mocking
            _bpStokDal.Setup(x => x.ListData("B1"))
                .Returns(new List<BPStokModel> { BPStokHeaderDataFactory() });
            _bpStokDetilDal.Setup(x => x.ListData("A1B1"))
                .Returns(new List<BPStokDetilModel> { BPStokDetilDataFactory() }); 
            #endregion

            //  act
            var ex = Assert.Throws<ArgumentException>(
                () => _bpStokBL.Generate(adj));

            //  assert
            ex.Message.Should().Contain("Stok tidak cukup");
        }

        [Fact]
        public void Generate_AdjMin_MultiStokControl_Berhasil()
        {
            #region ARRANGE
            //  arrange
            var adj = StokAdjustmentHeaderDataFactory();
            var adjDetil = StokAdjustmentDetilDataFactory();
            adj.ListBrg = new List<StokAdjustment2Model> { adjDetil };
            adjDetil.QtyAdjust = -7;

            //  bp stok
            var existingBPStok1 = BPStokHeaderDataFactory();
            existingBPStok1.ListDetil = new List<BPStokDetilModel>{BPStokDetilDataFactory()};
            var existingBPStok2 = existingBPStok1.CloneObject();

            //  expected
            var expected1 = existingBPStok1.CloneObject();
            expected1.QtySisa = 0;
            expected1.ListDetil.Add( new BPStokDetilModel
            {
                BPStokID = "A1B1",
                BPStokDetilID = "A1B1-002",
                NoUrut = 2,
                ReffID = "A1",
                Tgl = "20-02-2019",
                Jam = "21:39:00",
                QtyIn = 0,
                NilaiHpp = 0,
                QtyOut = 5,
                HargaJual = 2000,
            });
            //
            var expected2 = existingBPStok1.CloneObject();
            expected2.QtySisa = 3;
            expected2.ListDetil.Add(new BPStokDetilModel
            {
                BPStokID = "A1B1",
                BPStokDetilID = "A1B1-002",
                NoUrut = 2,
                ReffID = "A1",
                Tgl = "20-02-2019",
                Jam = "21:39:00",
                QtyIn = 0,
                NilaiHpp = 0,
                QtyOut = 2,
                HargaJual = 2000,
            });
            //
            var expected = new List<BPStokModel>{expected1, expected2};

            //  setup mocking
            _bpStokDal.Setup(x => x.ListData("B1"))
                .Returns(new List<BPStokModel> { BPStokHeaderDataFactory(), BPStokHeaderDataFactory() });
            _bpStokDetilDal.Setup(x => x.ListData("A1B1"))
                .Returns(new List<BPStokDetilModel> { BPStokDetilDataFactory() });
            #endregion

            //  act
            var actual = _bpStokBL.Generate(adj);

            //  assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Generate_AdjMin_MultiStokControl_StokTidakCukup()
        {
            #region ARRANGE
            //  arrange
            var adj = StokAdjustmentHeaderDataFactory();
            var adjDetil = StokAdjustmentDetilDataFactory();
            adj.ListBrg = new List<StokAdjustment2Model> { adjDetil };
            adjDetil.QtyAdjust = -12;

            //  bp stok
            var existingBPStok1 = BPStokHeaderDataFactory();
            existingBPStok1.ListDetil = new List<BPStokDetilModel> { BPStokDetilDataFactory() };
            var existingBPStok2 = existingBPStok1.CloneObject();

            //  setup mocking
            _bpStokDal.Setup(x => x.ListData("B1"))
                .Returns(new List<BPStokModel> { BPStokHeaderDataFactory(), BPStokHeaderDataFactory() });
            _bpStokDetilDal.Setup(x => x.ListData("A1B1"))
                .Returns(new List<BPStokDetilModel> { BPStokDetilDataFactory() });
            #endregion

            //  act
            var ex = Assert.Throws<ArgumentException>(
                () => _bpStokBL.Generate(adj));

            //  assert
            ex.Message.Should().Contain("Stok tidak cukup");
        }
    }
}
