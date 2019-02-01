using AnugerahBackend.Keuangan.Dal;
using AnugerahBackend.Keuangan.Model;
using AnugerahBackend.Support;
using AnugerahBackend.Support.BL;
using Ics.Helper.StringDateTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Keuangan.BL
{
    public interface IBukuKasBL : ISearchData<BukuKasSearchModel>
    {
        BukuKasModel Save(BukuKasModel bukuKas);
        void Delete(string bukuKasID);
        BukuKasModel GetData(string id);
        IEnumerable<BukuKasModel> ListData(string tgl1, string tgl2);
    }

    public class BukuKasBL : IBukuKasBL
    {
        private IBukuKasDal _bukuKasDal;
        private IPihakKetigaDal _pihakKetigaDal;
        private IJenisTrsKasirDal _jenisTrsKasirDal;
        private IParameterNoBL _paramNoBL;

        private IBukuPiutangBL _bukuPiutangBL;
        private IBukuHutangBL _bukuHutangBL;

        public BukuKasBL()
        {
            _bukuKasDal = new BukuKasDal();
            _pihakKetigaDal = new PihakKetigaDal();
            _jenisTrsKasirDal = new JenisTrsKasirDal();
            _paramNoBL = new ParameterNoBL();

            _bukuPiutangBL = new BukuPiutangBL();
            _bukuHutangBL = new BukuHutangBL();
        }

    public BukuKasModel Save(BukuKasModel bukuKas)
        {
            #region VALIDASI-DATA
            //  validasi null
            if (bukuKas == null)
            {
                throw new ArgumentNullException(nameof(bukuKas));
            }
            //  validasi tglBuku
            if (!bukuKas.TglBuku.IsValidTgl("dd-MM-yyyy"))
            {
                var errMsg = string.Format("Invalid TglBuku: {0}", bukuKas.TglBuku);
                throw new ArgumentException(errMsg);
            }
            //  validasi jamBuku
            if (!bukuKas.JamBuku.IsValidJam("HH:mm:ss"))
            {
                var errMsg = string.Format("Invalid JamBuku: {0}", bukuKas.JamBuku);
                throw new ArgumentException(errMsg);
            }

            //  validasi PihakKetigaID
            var pihakKetiga = _pihakKetigaDal.GetData(bukuKas.PihakKetigaID);
            if (pihakKetiga == null)
            {
                var errMsg = string.Format("Invalid PihakKetigaID {0}", bukuKas.PihakKetigaID);
                throw new ArgumentException(errMsg);
            }
            else
            {
                bukuKas.PihakKetigaName = pihakKetiga.PihakKetigaName;
            }

            //  validasi jenisTrsKasir
            var jenisTrsKasir = _jenisTrsKasirDal.GetData(bukuKas.JenisTrsKasirID);
            if (jenisTrsKasir == null)
            {
                var errMsg = string.Format("Invalid JenisTrsKasirID: {0}", bukuKas.JenisTrsKasirID);
                throw new ArgumentException(errMsg);
            }

            //  jumlahkan kasMasuk dan kasKeluar untuk menentukan 
            //  untuk menentukan 
            var totalNilaiKas = bukuKas.NilaiKasMasuk - bukuKas.NilaiKasKeluar;
            if (totalNilaiKas > 0)
                if (jenisTrsKasir.IsKasKeluar)
                {
                    var errMsg = string.Format("Invalid NilaiKas vs JenisTrsKasir");
                    throw new ArgumentException(errMsg);
                }
            #endregion

            #region PROSES-SAVE
            //  generate id
            var isNew = false;
            if (bukuKas.BukuKasID.Trim() == "")
            {
                bukuKas.BukuKasID = this.GenNewID();
                isNew = true;
            }
            if (isNew)
            {
                _bukuKasDal.Insert(bukuKas);
            }
            else
            {
                _bukuKasDal.Update(bukuKas);
            }
            #endregion

            switch (bukuKas.JenisTrsKasirID)
            {
                case "PTL":
                    _bukuPiutangBL.GenPiutang(bukuKas);
                    break;
                default:
                    break;
            }

            return bukuKas;
        }

        private string GenNewID()
        {
            var result = "";
            var prefix = "KS" + DateTime.Now.ToString("yyMM");
            result = _paramNoBL.GenNewID(prefix, 10);
            return result;
        }
     
        public void Delete(string bukuKasID)
        {
            throw new NotImplementedException();
        }

        public BukuKasModel GetData(string id)
        {
            return _bukuKasDal.GetData(id);
        }

        public IEnumerable<BukuKasModel> ListData(string tgl1, string tgl2)
        {
            return _bukuKasDal.ListData(tgl1, tgl2);
        }

        #region SEARCH
        public IEnumerable<BukuKasSearchModel> Search()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BukuKasSearchModel> Search(string keyword)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BukuKasSearchModel> Search(string keyword, string tgl1, string tgl2)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
