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
using Ics.Helper.Database;

namespace AnugerahBackend.StokBarang.BL
{
    public interface IStokBL : ISearch<StokSearchModel>
    {
        void AddStok(string brgID, decimal Qty, double hpp,
            string tgl, string jam, string trsMasukID,
            string trsDOID, string jenisMutasiID);

        void RemoveStok(string stokControlID, decimal Qty, double hargaJual,
            string tgl, string jam, string trsReffID,
            string jenisMutasiID);

        void RemoveStok(BrgModel brg, decimal Qty, double hargaJual,
            string jenisMutasiID, string trsReffID);

        decimal GetStok(string brgID);
    }

    public class StokBL : IStokBL
    {
        private const string PREFIX_STOK_IN = "SI";

        private IStokInDal _stokInDal;
        private IStokInOutDal _stokInOutDal;

        private IBrgBL _brgBL;
        private IJenisMutasiBL _jenisMutasiBL;
        private IParameterNoBL _paramNoBL;

        #region CONSTRUCTOR
        public StokBL()
        {
            _stokInDal = new StokInDal();
            _stokInOutDal = new StokInOutDal();

            _brgBL = new BrgBL();
            _jenisMutasiBL = new JenisMutasiBL();
            _paramNoBL = new ParameterNoBL();

        }

        public StokBL(
            IStokInDal injStokInDal, IStokInOutDal injStokInOutDal,
            IBrgBL injBrgBL, IJenisMutasiBL injJenisMutasiBL,
            IParameterNoBL injParamNoBL)
        {
            _stokInDal = injStokInDal;
            _stokInOutDal = injStokInOutDal;

            _brgBL = injBrgBL;
            _jenisMutasiBL = injJenisMutasiBL;
            _paramNoBL = injParamNoBL;
        }
        #endregion

        public void AddStok(string brgID, decimal qty, double hpp,
            string tgl, string jam, string trsMasukID,
            string trsDOID, string jenisMutasiID)
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

            #region PERSIAPAN-ID-TABLE
            //  contoh StokInID = SI.1901.00031
            var prefixStokIn = PREFIX_STOK_IN + DateTime.Now.ToString(".yyMM.");
            var stokInID = _paramNoBL.GenNewID(prefixStokIn, 12);
            //  contoh StokInOutID = SI.1901.00031.001
            var prefixStokInOut = stokInID + ".";
            var stokInOutID = _paramNoBL.GenNewID(prefixStokInOut, 16);
            //  contoh StokControlID = DO.1901.00021-B5431
            var stokControlID = string.Format("{0}-{1}", trsDOID, brgID);
            #endregion

            #region PROSES-INSERT-DATA
            using (var trans = TransHelper.NewScope())
            {
                var stokIn = new StokInModel
                {
                    StokInID = stokInID,
                    BrgID = brgID,

                    TglMasuk = tgl,
                    JamMasuk = jam,
                    TrsMasukID = trsMasukID,

                    QtyIn = qty,
                    QtySaldo = qty,
                    Hpp = hpp,

                    StokControlID = stokControlID,
                    TrsDOID = trsDOID,
                };
                _stokInDal.Insert(stokIn);

                var stokInOut = new StokInOutModel
                {
                    StokInID = stokInID,
                    StokInOutID = stokInOutID,

                    TglTrs = tgl,
                    JamTrs = jam,
                    ReffTrsID = trsMasukID,
                    JenisMutasiID = jenisMutasiID,

                    QtyIn = qty,
                    QtyOut = 0,
                    Hpp = hpp,
                    HargaJual = 0
                };
                _stokInOutDal.Insert(stokInOut);
                trans.Complete();
            }
            #endregion
        }

        public decimal GetStok(string brgID)
        {
            decimal result = 0;
            var listStok = _stokInDal.ListData(brgID);
            if (listStok != null)
                result = listStok.Sum(x => x.QtySaldo);
            return result;
        }

        public void RemoveStok(string stokControlID, decimal qty, double hargaJual,
            string tgl, string jam, string trsReffID,
            string jenisMutasiID)
        {

            #region VALIDASI-INPUT
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

            #region CEK-SALDO-STOK
            //  ambil semua StokIn yang StokControlID-nya sesuai parameter
            var listStokIn = _stokInDal.ListDataByStokControl(stokControlID);
            if (listStokIn == null)
                throw new ArgumentException("StokControlID invalid");
            //  sum qty saldo dan bandingkan 
            var qtySaldo = listStokIn.Sum(x => x.QtySaldo);
            if (qtySaldo < qty)
                throw new ArgumentException("Qty tidak mencukupi");
            #endregion

            #region INSERT-STOK-IN-OUT
            var qtyRemoveSisa = qty;
            foreach (var item in listStokIn)
            {
                //  tentukan qty remove stok per StokIn
                decimal qtyRemove = 0;
                if (item.QtySaldo <= qtyRemoveSisa)
                    qtyRemove = item.QtySaldo;
                else
                    qtyRemove = qtyRemoveSisa;
                item.QtySaldo -= qtyRemove;
                qtyRemoveSisa -= qtyRemove;

                //  update saldo (StokIn)
                _stokInDal.Update(item);

                //  update detil history (StokInOut)
                var prefixStokInOut = item.StokInID + ".";
                var stokInOutID = _paramNoBL.GenNewID(prefixStokInOut, 16);
                var stokInOut = new StokInOutModel
                {
                    StokInID = item.StokInID,
                    StokInOutID = stokInOutID,

                    TglTrs = tgl,
                    JamTrs = jam,
                    ReffTrsID = trsReffID,
                    JenisMutasiID = jenisMutasiID,

                    QtyIn = 0,
                    QtyOut = qtyRemove,
                    Hpp = item.Hpp,
                    HargaJual = hargaJual
                };
                _stokInOutDal.Insert(stokInOut);

                //  jika sudah berhasil remove sesuai qty, keluar
                if (qtyRemoveSisa <= 0) break;
            }
            #endregion  
        }

        public void RemoveStok(BrgModel brg, decimal Qty, double hargaJual, string jenisMutasiID, string trsReffID)
        {
            throw new NotImplementedException();
        }

        #region SEARCH
        public SearchFilter SearchFilter { get; set; }
        public IEnumerable<StokSearchModel> Search()
        {
            throw new NotImplementedException();
        }

        #endregion    }
    }
}
