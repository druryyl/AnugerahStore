using AnugerahBackend.StokBarang.Model;
using AnugerahBackend.StokBarang.BL;
using AnugerahBackend.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ics.Helper.StringDateTime;
using AnugerahBackend.Support.BL;
using AnugerahBackend.StokBarang.Dal;

namespace AnugerahBackend.StokBarang.BL
{
    public interface IStokControlBL : ISearchData<StokSearchModel>
    {
        void AddStok(string brgID, string tgl, string jam, long qty,
            double hpp, string jenisMutasiID, string trsMasukID, 
            string trsDOID, string batchNo);
        void AddStok(string stokControlID, long qty,
            string jenisMutasiID, string trsMasukID);

        void RemoveStok(string brgID, long qty, string stokControlID);
    }

    public class StokControlBL : IStokControlBL
    {
        private IStokControlDal _stokControlDal;
        private IStokInOutDal _stokControl2Dal;
        private IBrgBL _brgBL;
        private IJenisMutasiBL _jenisMutasiBL;
        private IParameterNoBL _paramNoBL;

        public StokControlBL()
        {
            _stokControlDal = new StokInDal();
            _stokControl2Dal = new StokInOutDal();

            _brgBL = new BrgBL();
            _jenisMutasiBL = new JenisMutasiBL();
            _paramNoBL = new ParameterNoBL();

        }

        public StokControlBL(IBrgBL injBrgBL, IJenisMutasiBL injJenisMuasiBL)
        {
            _brgBL = injBrgBL;
            _jenisMutasiBL = injJenisMuasiBL;

        }
        public void AddStok(string brgID, string tgl, string jam, long qty, double hpp,
            string jenisMutasiID, string trsMasukID, string trsDOID, string batchNo)
        {
            #region VALIDASI-INPUT
            //  validasi brg
            var brg = _brgBL.GetData(brgID);
            if (brg == null)
            {
                var errMsg = string.Format("BrgID invalid: {0}", brgID);
                throw new ArgumentException(errMsg);
            }

            //  cek jenis mutasi
            var jenisMutasi = _jenisMutasiBL.GetData(jenisMutasiID);
            if (jenisMutasi == null)
            {
                var errMsg = string.Format("JenisMutasiID invalid : {0}", jenisMutasiID);
                throw new ArgumentException(errMsg);
            }
            if (!jenisMutasi.IsBrgMasuk)
            {
                var errMsg = string.Format("JenisMutasiID invalid bukan BrgMasuk: {0}", jenisMutasiID);
                throw new ArgumentException(errMsg);
            }

            //  validasi tgl
            if (!tgl.IsValidTgl("dd-MM-yyyy"))
            {
                var errMsg = string.Format("Tgl invalid: {0}", tgl);
                throw new ArgumentException(errMsg);
            }
            //  validasi jam
            if (!tgl.IsValidJam("HH:mm:ss"))
            {
                var errMsg = string.Format("Jam invalid: {0}", jam);
                throw new ArgumentException(errMsg);
            }
            #endregion

            //  proses simpan stok control
            var prefix = string.Format("{0}-{1}-",
                brgID,
                DateTime.Now.ToString("yyMM"));
            var stokControlID = _paramNoBL.GenNewID(prefix, 13);
            var stokControl = new StokControlModel
            {
                StokControlID = stokControlID,
                BrgID = brgID,
                TglMasuk = tgl,
                JamMasuk = jam,
                QtyIn = qty,
                QtySaldo = qty,
                TrsMasukID = trsMasukID,
                TrsDOID = trsDOID,
                BatchNo = batchNo,
                Hpp = hpp
            };
            _stokControlDal.Insert(stokControl);

            //  proses simpan stok control2
            var prefix2 = stokControlID+"-";
            var stokControl2ID = _paramNoBL.GenNewID(prefix2, 16);
            var stokControl2 = new StokInOutModel
            {
                StokControl2ID = stokControl2ID,
                StokControlID = stokControlID,
                TglTrs = tgl,
                JamTrs = jam,
                ReffTrsID = trsMasukID,
                JenisMutasiID = jenisMutasiID,
                QtyIn = qty,
                QtyOut = 0,
                NilaiIn = hpp,
                NilaiOut = 0
            };
        }

        private void AddStokDetil(string stokControlID, long qty,
            string jenisMutasiID, string trsMasukID)
        {
            //TODO: INSERT CONSTROL STOK2 (Detil)
        }

        public void RemoveStok(string brgID, long qty, string stokControlID)
        {
            //  cek apakah stok ada
            var data
        }

        public IEnumerable<StokSearchModel> Search(string keyword)
        {
            throw new NotImplementedException();
        }
    }
}
