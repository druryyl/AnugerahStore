using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnugerahBackend.Accounting.Dal;
using AnugerahBackend.Accounting.Model;
using Ics.Helper.Database;

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

        public void InsertTest()
        {
            using (var trans = TransHelper.NewScope())
            {
                //  arrange
                //  act
                //  assert
            }
        }

        public void DeleteTest()
        {
            throw new NotImplementedException();
        }

        public void ListDataTest()
        {
            throw new NotImplementedException();
        }
    }
}
