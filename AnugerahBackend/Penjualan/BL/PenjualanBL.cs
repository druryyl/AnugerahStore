﻿using AnugerahBackend.Penjualan.Dal;
using AnugerahBackend.Penjualan.Model;
using AnugerahBackend.StokBarang.BL;
using AnugerahBackend.StokBarang.Model;
using AnugerahBackend.Support;
using AnugerahBackend.Support.BL;
using Ics.Helper.Database;
using Ics.Helper.Extensions;
using Ics.Helper.StringDateTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Penjualan.BL
{
    public interface IPenjualanBL : ISearch<PenjualanSearchModel>
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
        private IPenjualanBayarDal _penjualanBayarDal;
        private IParameterNoBL _paramNoBL;
        private IBrgBL _brgBL;
        private IJenisBayarDal _jenisBayarDal;
        private ICustomerDal _customerDal;

        public PenjualanBL()
        {
            _penjualanDal = new PenjualanDal();
            _penjualan2Dal = new Penjualan2Dal();
            _penjualanBayarDal = new PenjualanBayarDal();
            _paramNoBL = new ParameterNoBL();
            _brgBL = new BrgBL();
            _jenisBayarDal = new JenisBayarDal();
            _customerDal = new CustomerDal();
            SearchFilter = new SearchFilter
            {
                IsDate = true,
                Date1 = DateTime.Now,
                Date2 = DateTime.Now
            };

        }

        public PenjualanBL(IPenjualanDal injPenjualanDal, IPenjualan2Dal injPenjualan2Dal,
            IBrgBL injBrgBL, IParameterNoBL injParamNoBL, ICustomerDal injCustomerDal)
        {
            _penjualanDal = injPenjualanDal;
            _penjualan2Dal = injPenjualan2Dal;
            _paramNoBL = injParamNoBL;
            _brgBL = injBrgBL;
            _customerDal = injCustomerDal;
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
                    _penjualanBayarDal.Delete(penjualan.PenjualanID);
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
                //  save detil barang
                foreach (var item in penjualan.ListBrg)
                {
                    item.PenjualanID = trsID;
                    item.PenjualanID2 = string.Format("{0}-{1}", trsID, item.NoUrut.ToString().PadLeft(3, '0'));
                    _penjualan2Dal.Insert(item);
                }

                //  save detil bayar
                if(penjualan.ListBayar != null)
                    foreach(var item in penjualan.ListBayar)
                    {
                        item.PenjualanID = trsID;
                        item.PenjualanID2 = string.Format("{0}-{1}", trsID, item.NoUrut.ToString().PadLeft(2, '0'));

                        _penjualanBayarDal.Insert(item);
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
                var detilBrg = _penjualan2Dal.ListData(id);
                if (detilBrg != null)
                    header.ListBrg = detilBrg;

                var detilBayar = _penjualanBayarDal.ListData(id);
                if (detilBayar != null)
                    header.ListBayar = detilBayar;
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

            if (penjualan.CustomerID != "")
            {
                var customer = _customerDal.GetData(penjualan.CustomerID);
                penjualan.CustomerName = customer.CustomerName;
            }

            //  cek BrgID
            foreach (var item in penjualan.ListBrg)
            {
                var brg = _brgBL.GetData(item.BrgID);
                if (brg == null)
                    throw new ArgumentException("Invalid BrgID ");
                else
                    item.BrgName = brg.BrgName;
                //  re-calc qty akhir
                item.SubTotal = (item.Harga - item.Diskon) * item.Qty;
            }

            //  validasi pembayaran
            var noUrut = 0;
            decimal totalBayar = 0;
            if(penjualan.ListBayar != null)
            {
                foreach (var item in penjualan.ListBayar)
                {
                    var jenisBayar = _jenisBayarDal.GetData(item.JenisBayarID);
                    if (jenisBayar == null)
                        throw new ArgumentException("Invalid JenisBayarID");
                    else
                        item.JenisBayarName = jenisBayar.JenisBayarName;
                    item.NoUrut = noUrut;
                    noUrut++;
                }
                totalBayar = penjualan.ListBayar.Sum(x => x.NilaiBayar);
            }

            //  jumlah pembayaran tidak boleh kurang dari total
            totalBayar += penjualan.NilaiDeposit;

            if (totalBayar < penjualan.NilaiGrandTotal)
                throw new ArgumentException("Pembayaran kurang dari Nilai Grand Total");

            penjualan.NilaiKembali = penjualan.NilaiBayar - penjualan.NilaiGrandTotal;
            return result;
        }
        
        public SearchFilter SearchFilter { get; set; }

        public IEnumerable<PenjualanSearchModel> Search()
        {
            var listData = _penjualanDal.ListData(SearchFilter.TglDMY1, SearchFilter.TglDMY2);
            if (listData == null) return null;

            //  convert ke SearchModel
            var result = listData.Select(x => (PenjualanSearchModel)x);

            //  filter
            if (SearchFilter.UserKeyword != null)
                return
                    from c in result
                    where c.BuyerName.ContainMultiWord(SearchFilter.UserKeyword)
                    select c;

            return result;
        }
    }
}
