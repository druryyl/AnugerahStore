﻿using AnugerahBackend.Penjualan.Dal;
using AnugerahBackend.Penjualan.Model;
using AnugerahBackend.StokBarang.BL;
using AnugerahBackend.StokBarang.Model;
using AnugerahBackend.Support;
using AnugerahBackend.Support.BL;
using Ics.Helper.Database;
using Ics.Helper.StringDateTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Penjualan.BL
{

    public interface IPenjualanBL : ISearchData<PenjualanSearchModel>
    {
        PenjualanModel Save(PenjualanModel penjualan);

        void Void(string id);

        PenjualanModel GetData(string id);

        IEnumerable<PenjualanModel> ListData(string tgl1, string tgl2);

        PenjualanModel TryValidate(PenjualanModel penjualan);
    }

    public class PenjualanBL : IPenjualanBL
    {
        private IPenjualanDal _penjualanDal;
        private IPenjualan2Dal _penjualan2Dal;
        private IParameterNoBL _paramNoBL;
        private IBrgBL _brgBL;

        public PenjualanBL()
        {
            _penjualanDal = new PenjualanDal();
            _penjualan2Dal = new Penjualan2Dal();
            _paramNoBL = new ParameterNoBL();
            _brgBL = new BrgBL();
        }

        public PenjualanBL(IPenjualanDal injPenjualanDal, IPenjualan2Dal injPenjualan2Dal,
            IBrgBL injBrgBL, IParameterNoBL injParamNoBL)
        {
            _penjualanDal = injPenjualanDal;
            _penjualan2Dal = injPenjualan2Dal;
            _paramNoBL = injParamNoBL;
            _brgBL = injBrgBL;
        }

        public PenjualanModel Save(PenjualanModel penjualan)
        {
            //  validasi
            var result = penjualan;
            result = TryValidate(penjualan);

            var trsID = "";

            //  save
            using (var trans = TransHelper.NewScope())
            {
                //  edit: delete data lama
                if (penjualan.PenjualanID.Trim() != "")
                {
                    _penjualan2Dal.Delete(penjualan.PenjualanID);
                    _penjualanDal.Delete(penjualan.PenjualanID);
                    trsID = penjualan.PenjualanID;
                }
                //  baru: generate no.transaksi
                else
                {
                    var prefix = "JL" + DateTime.Now.ToString("yyMM");
                    trsID = _paramNoBL.GenNewID(prefix, 10);
                }

                //  save header
                penjualan.PenjualanID = trsID;
                _penjualanDal.Insert(penjualan);
                //  save detil
                foreach (var item in penjualan.ListBrg)
                {
                    item.PenjualanID = trsID;
                    item.PenjualanID2 = string.Format("{0}-{1}", trsID, item.NoUrut.ToString().PadLeft(3, '0'));
                    _penjualan2Dal.Insert(item);
                }
                trans.Complete();
            }
            return result;

        }

        public void Void(string id)
        {
            using (var trans = TransHelper.NewScope())
            {
                _penjualan2Dal.Delete(id);
                _penjualanDal.Delete(id);
                trans.Complete();
            }
        }

        public PenjualanModel GetData(string id)
        {
            var header = _penjualanDal.GetData(id);
            if (header != null)
            {
                var detil = _penjualan2Dal.ListData(id);
                if (detil != null)
                    header.ListBrg = detil;
            }
            return header;
        }

        public IEnumerable<PenjualanModel> ListData(string tgl1, string tgl2)
        {
            return _penjualanDal.ListData(tgl1, tgl2);
        }

        public PenjualanModel TryValidate(PenjualanModel penjualan)
        {
            var result = penjualan;

            if (penjualan == null)
            {
                throw new ArgumentNullException(nameof(penjualan));
            }

            //  validasi tgl dan jam
            if (!penjualan.TglPenjualan.IsValidTgl("dd-MM-yyyy"))
            {
                throw new ArgumentException("Invalid Tgl.Penjualan");
            }
            if (!penjualan.JamPenjualan.IsValidJam("HH:mm:ss"))
            {
                throw new ArgumentException("Invalid Jam.Penjualan");
            }
            //  cek BrgID
            foreach (var item in penjualan.ListBrg)
            {
                var brg = _brgBL.GetData(item.BrgID);
                if (brg == null)
                    throw new ArgumentException("Invalid BrgID ");
                //  re-calc qty akhir
                item.SubTotal = (item.Harga - item.Diskon) * item.Qty;
            }
            return result;
        }

        public IEnumerable<PenjualanSearchModel> Search(string keyword)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PenjualanSearchModel> Search(string keyword, string tgl1, string tgl2)
        {
            var result = _penjualanDal.Search(keyword, tgl1, tgl2);
            return result;
        }
    }
}