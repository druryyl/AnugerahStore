﻿using AnugerahBackend.StokBarang.Dal;
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

namespace AnugerahBackend.StokBarang.BL
{

    public interface IStokAdjustmentBL : ISearch<StokAdjustmentSearchModel>
    {
        StokAdjustmentModel Save(StokAdjustmentModel stokAdjustment);

        void Void(string id);

        StokAdjustmentModel GetData(string id);

        IEnumerable<StokAdjustmentModel> ListData(string tgl1, string tgl2);

        StokAdjustmentModel TryValidate(StokAdjustmentModel stokAdjustment);
    }


    public class StokAdjustmentBL : IStokAdjustmentBL
    {
        private IStokAdjustmentDal _stokAdjustmentDal;
        private IStokAdjustment2Dal _stokAdjustment2Dal;
        private IParameterNoBL _paramNoBL;
        private IBrgBL _brgBL;
        private IStokBL _stokBL;

        public StokAdjustmentBL()
        {
            _stokAdjustmentDal = new StokAdjustmentDal();
            _stokAdjustment2Dal = new StokAdjustment2Dal();
            _paramNoBL = new ParameterNoBL();
            _brgBL = new BrgBL();
            _stokBL = new StokBL();
            SearchFilter = new SearchFilter
            {
                IsDate = true,
                Date1 = DateTime.Now,
                Date2 = DateTime.Now,
                UserKeyword = ""
            };
        }

        public StokAdjustmentBL(IStokAdjustmentDal injStokAdjustmentDal,
                IBrgBL injBrgBL, IParameterNoBL injParamNoBL)
        {
            _stokAdjustmentDal = injStokAdjustmentDal;
            _paramNoBL = injParamNoBL;
            _brgBL = injBrgBL;
        }

        public StokAdjustmentModel Save(StokAdjustmentModel stokAdjustment)
        {
            //  validasi
            var result = stokAdjustment;
            result = TryValidate(stokAdjustment);

            var trsID = "";

            //  save
            using (var trans = TransHelper.NewScope())
            {
                //  edit: delete data lama
                if (stokAdjustment.StokAdjustmentID.Trim() != "")
                {
                    //  kembalikan stok lama
                    _stokAdjustment2Dal.Delete(stokAdjustment.StokAdjustmentID);
                    _stokAdjustmentDal.Delete(stokAdjustment.StokAdjustmentID);
                    trsID = stokAdjustment.StokAdjustmentID;
                }
                //  baru: generate no.transaksi
                else
                {
                    var prefix = "AJ" + DateTime.Now.ToString("yyMM");
                    trsID = _paramNoBL.GenNewID(prefix, 10);
                }

                //  save header
                stokAdjustment.StokAdjustmentID = trsID;

                //  delete data lama
                _stokAdjustment2Dal.Delete(trsID);
                _stokAdjustmentDal.Delete(trsID);

                //  insert data baru
                _stokAdjustmentDal.Insert(stokAdjustment);
                foreach (var item in stokAdjustment.ListBrg)
                {
                    item.StokAdjustmentID = trsID;
                    item.StokAdjustmentID2 = string.Format("{0}-{1}", trsID, item.NoUrut.ToString().PadLeft(3, '0'));
                    _stokAdjustment2Dal.Insert(item);
                }
                trans.Complete();
            }
            return result;
        }

        private void ReserveStok(string stokAdjID)
        {
            //var stokAdj = GetData(stokAdjID);
            //foreach(var item in stokAdj.ListBrg)
            //{
            //    //  ambil barang
            //}
        }

        public void Void(string id)
        {
            using (var trans = TransHelper.NewScope())
            {
                _stokAdjustment2Dal.Delete(id);
                _stokAdjustmentDal.Delete(id);
                trans.Complete();
            }
        }

        public StokAdjustmentModel GetData(string id)
        {
            var header = _stokAdjustmentDal.GetData(id);
            if(header != null)
            {
                var detil = _stokAdjustment2Dal.ListData(id);
                if(detil != null)
                header.ListBrg = detil;
            }
            return header;
        }

        public IEnumerable<StokAdjustmentModel> ListData(string tgl1, string tgl2)
        {
            return _stokAdjustmentDal.ListData(tgl1, tgl2);
        }

        public StokAdjustmentModel TryValidate(StokAdjustmentModel stokAdjustment)
        {
            var result = stokAdjustment;

            if (stokAdjustment == null)
            {
                throw new ArgumentNullException(nameof(stokAdjustment));
            }

            //  validasi tgl dan jam
            if (!stokAdjustment.TglTrs.IsValidTgl("dd-MM-yyyy"))
            {
                throw new ArgumentException("Invalid Tgl.Stok Adjustment");
            }
            if (!stokAdjustment.JamTrs.IsValidJam("HH:mm:ss"))
            {
                throw new ArgumentException("Invalid Jam.Stok Adjustment");
            }
            //  cek BrgID
            foreach(var item in stokAdjustment.ListBrg)
            {
                var brg = _brgBL.GetData(item.BrgID);
                if (brg == null)
                    throw new ArgumentException("Invalid BrgID ");
                //  re-calc qty akhir
                item.QtyAkhir = item.QtyAwal + item.QtyAdjust;
            }
            return result;
        }

        public SearchFilter SearchFilter { get; set; }  
        public IEnumerable<StokAdjustmentSearchModel> Search()
        {
            var listData = _stokAdjustmentDal.ListData(SearchFilter.TglDMY1, SearchFilter.TglDMY2);

            if (listData == null) return null;

            var result = listData.Select(x => (StokAdjustmentSearchModel)x);
            if (!result.Any())
                return null;
            if (SearchFilter.UserKeyword != null)
                return
                    from c in result
                    where c.Keterangan.ContainMultiWord(SearchFilter.UserKeyword)
                    select c;

            return result;
        }
    }
}
