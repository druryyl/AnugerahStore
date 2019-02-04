﻿using AnugerahBackend.Keuangan.Dal;
using AnugerahBackend.Keuangan.Model;
using AnugerahBackend.Support;
using AnugerahBackend.Support.BL;
using Ics.Helper.Database;
using Ics.Helper.StringDateTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Keuangan.BL
{
    public interface IBukuKasBL : ISearch<BukuKasSearchModel>
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
            if (bukuKas.NilaiKas > 0)
                if (jenisTrsKasir.IsKasKeluar)
                {
                    var errMsg = string.Format("Invalid NilaiKas vs JenisTrsKasir");
                    throw new ArgumentException(errMsg);
                }
            #endregion

            #region PROSES-SAVE
            //  generate id
            using (var trans = TransHelper.NewScope())
            {
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
                    case "PTG":
                        _bukuPiutangBL.GenBukuPiutang(bukuKas);
                        break;
                    case "PTL":
                        _bukuPiutangBL.GenBukuPiutangLunas(bukuKas);
                        break;
                    default:
                        break;
                }
                trans.Complete();
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
        public string SearchKeyword { get; set; }
        public DateTime SearchDate1 { get; set; }
        public DateTime SearchDate2 { get; set; }
        public string SearchStaticFilter { get; set; }
        public IEnumerable<BukuKasSearchModel> Search()
        {
            SearchDate1 = DateTime.Now;
            SearchDate2 = DateTime.Now;

            var listAll = _bukuKasDal.ListData(
                SearchDate1.ToString("dd-MM-yyyy"),
                SearchDate2.ToString("dd-MM-yyyy"));
            if (listAll == null) return null;

            var result = new List<BukuKasSearchModel>();
            foreach (var item in listAll)
            {
                result.Add(new BukuKasSearchModel
                {
                    BukuKasID = item.BukuKasID,
                    TglBuku = item.TglBuku,
                    PihakKetigaName = item.PihakKetigaName,
                    Nilai = item.NilaiKas.ToString("N0").PadLeft(12, ' '),
                    Keterangan = item.Keterangan
                });
            }

            if (SearchKeyword != null)
            {
                SearchKeyword = SearchKeyword.ToLower();
                result = result.Where(x => x
                    .PihakKetigaName.ToLower()
                    .Contains(SearchKeyword))
                    .ToList();
            }

            return result;
        }

        public IEnumerable<BukuKasSearchModel> Search(string keyword, string tgl1, string tgl2)
        {
            var listAll = _bukuKasDal.ListData(tgl1, tgl2);
            if (listAll == null) return null;

            var result = new List<BukuKasSearchModel>();
            foreach (var item in listAll.Where(
                x => x.PihakKetigaName.ToLower().Contains(keyword.ToLower())))
            {
                result.Add(new BukuKasSearchModel
                {
                    BukuKasID = item.BukuKasID,
                    TglBuku = item.TglBuku,
                    PihakKetigaName = item.PihakKetigaName,
                    Nilai = item.NilaiKas.ToString("N0").PadLeft(12, ' '),
                    Keterangan = item.Keterangan
                });
            }
            return result;
        }
        #endregion
    }
}
