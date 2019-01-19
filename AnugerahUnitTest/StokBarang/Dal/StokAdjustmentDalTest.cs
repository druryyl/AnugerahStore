using AnugerahBackend.StokBarang.Dal;
using AnugerahBackend.StokBarang.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahUnitTest.StokBarang.Dal
{
    public interface IStokAdjustmentDalTest
    {
        void InsertTest();
        void UpdateTest();
        void DeleteTest();
        void VoidTest();
        void GetDataTest();
        void ListDataTest();

    }

    public class StokAdjustmentDalTest : IStokAdjustmentDalTest
    {
        public IStokAdjustmentDal _stokAdjustmentDal;

        public StokAdjustmentDalTest()
        {
            _stokAdjustmentDal = new StokAdjustmentDal();
        }

        StokAdjustmentModel StokAdjustmentDataFactory()
        {
            var result = new StokAdjustmentModel
            {
                StokAdjustmentID = "A1",
                TglTrs = "01-01-2000",
                JamTrs = "12:12:11",
                UserrID = "B1",
                TglVoid = "01-01-3000",
                JamVoid = "00:00:00",
                UserrIDVoid = "C1",
                Keterangan = "D1",
                ListBrg = null,
            };
            return result;
        }

        public void InsertTest()
        {
            throw new NotImplementedException();
        }

        public void UpdateTest()
        {
            throw new NotImplementedException();
        }

        public void DeleteTest()
        {
            throw new NotImplementedException();
        }

        public void VoidTest()
        {
            throw new NotImplementedException();
        }

        public void GetDataTest()
        {
            throw new NotImplementedException();
        }

        public void ListDataTest()
        {
            throw new NotImplementedException();
        }

        a
    }
}
