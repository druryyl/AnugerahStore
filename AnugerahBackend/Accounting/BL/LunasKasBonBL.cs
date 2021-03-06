﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnugerahBackend.Accounting.Dal;
using AnugerahBackend.Accounting.Model;
using AnugerahBackend.Penjualan.Dal;
using AnugerahBackend.Support;
using AnugerahBackend.Support.BL;
using Ics.Helper.Database;
using Ics.Helper.Extensions;

namespace AnugerahBackend.Accounting.BL
{
    public interface ILunasKasBonBL : ISearch<LunasKasBonSearchModel>
    {
        LunasKasBonModel Save(LunasKasBonModel model);
        void Delete(string id);
        LunasKasBonModel GetData(string id);
        IEnumerable<LunasKasBonModel> ListData(string tgl1, string tgl2);
    }

    public class LunasKasBonBL : ILunasKasBonBL
    {
        private ILunasKasBonDal _lunasKasBonDal;
        private ILunasKasBonDetilDal _lunasKasBonDetilDal;
        private IKasBonDal _kasBonDal;
        private IPihakKeduaDal _pihakKeduaDal;
        private IJenisLunasDal _jenisLunasDal;
        private IParameterNoBL _paramNoBL;
        private IPenjualanDal _penjualanDal;
        private IJenisBiayaDal _jenisBiayaDal;

        public LunasKasBonBL()
        {
            _lunasKasBonDal = new LunasKasBonDal();
            _lunasKasBonDetilDal = new LunasKasBonDetilDal();
            _kasBonDal = new KasBonDal();
            _pihakKeduaDal = new PihakKeduaDal();
            _jenisLunasDal = new JenisLunasDal();
            _paramNoBL = new ParameterNoBL();
            _penjualanDal = new PenjualanDal();
            _jenisBiayaDal = new JenisBiayaDal();

            SearchFilter = new SearchFilter
            {
                IsDate = true,
                Date1 = DateTime.Now,
                Date2 = DateTime.Now
            };
        }

        public LunasKasBonModel Save(LunasKasBonModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var kasBon = _kasBonDal.GetData(model.KasBonID);
            if (kasBon == null)
                throw new ArgumentException("PiutangID invalid");

            //  validate pihak kedua
            var pihakKedua = _pihakKeduaDal.GetData(model.PihakKeduaID);
            if (pihakKedua == null)
                throw new ArgumentException("PihakKeduaID invalid");
            else
                model.PihakKeduaName = pihakKedua.PihakKeduaName;

            if (kasBon.PihakKeduaID != model.PihakKeduaID)
                throw new ArgumentException("PihakKeduaID tidak sama dengan data KasBon");

            if (model.ListLunas == null)
                throw new ArgumentException("Detil Pelunasan masih kosong");

            //  update nilai total lunas
            model.NilaiTotLunas = model.ListLunas.Sum(x => x.NilaiLunas);

            if (model.NilaiSisaPiutang < model.NilaiTotLunas)
                throw new ArgumentException("Nilai Pelunasan KasBon terlalu banyak");

            foreach(var item in model.ListLunas)
            {
                var jenisLunas = _jenisLunasDal.GetData(item.JenisLunasID);
                if (jenisLunas == null)
                    throw new ArgumentException("JenisLunasID invalid : " + item.JenisLunasID);

                if (item.NilaiLunas <= 0)
                    throw new ArgumentException("Pelunasan tidak boleh minus atau nol");

                //  jika PelunasanID muncul, cek apakah NoPenjualan valid
                if(item.PenjualanID.Trim() != "")
                {
                    var penjualan = _penjualanDal.GetData(item.PenjualanID);
                    if (penjualan == null)
                        throw new ArgumentException("Penjualan ID invalid");

                    //  nomor referensi penjualan hanya boleh untuk jenis lunas biaya
                    var jenisBiaya = _jenisBiayaDal.GetData(jenisLunas.JenisBiayaID);
                    if (jenisBiaya == null)
                        throw new ArgumentException("Penjualan hanya diisi jika Biaya");
                }
            }

            using (var trans = TransHelper.NewScope())
            {
                //  generate id (jika baru)
                if (model.LunasKasBonID.Trim() == "")
                    model.LunasKasBonID = GenNewID();

                //  update id di detil;
                var noUrut = 1;
                foreach (var item in model.ListLunas)
                {
                    item.LunasKasBonID = model.LunasKasBonID;
                    item.LunasKasBonDetilID = model.LunasKasBonID + '-' + noUrut.ToString().PadLeft(2, '0');
                    noUrut++;
                }

                //  hapus data lama
                _lunasKasBonDal.Delete(model.LunasKasBonID);
                _lunasKasBonDetilDal.Delete(model.LunasKasBonID);

                //  simpan data baru
                _lunasKasBonDal.Insert(model);
                foreach (var item in model.ListLunas)
                    _lunasKasBonDetilDal.Insert(item);

                //  commit changes
                trans.Complete();
            }
            return model;
        }

        private string GenNewID()
        {
            var prefix = "LK" + DateTime.Now.ToString("yyMM");
            var result = _paramNoBL.GenNewID(prefix, 10);
            return result;
        }

        public void Delete(string id)
        {
            //  hapus data lama
            using (var trans = TransHelper.NewScope())
            {
                _lunasKasBonDal.Delete(id);
                _lunasKasBonDetilDal.Delete(id);
                trans.Complete();
            }
        }

        public LunasKasBonModel GetData(string id)
        {
            var header = _lunasKasBonDal.GetData(id);
            var detail = _lunasKasBonDetilDal.ListData(id);
            if(header != null)
                header.ListLunas = detail;
            return header;
        }

        public IEnumerable<LunasKasBonModel> ListData(string tgl1, string tgl2)
        {
            return _lunasKasBonDal.ListData(tgl1, tgl2);
        }

        public SearchFilter SearchFilter { get; set; }

        public IEnumerable<LunasKasBonSearchModel> Search()
        {
            //  ambil data
            var listAll = _lunasKasBonDal.ListData(SearchFilter.TglDMY1, SearchFilter.TglDMY2);
            if (listAll == null) return null;

            //  convert ke SearchModel
            var result = listAll.Select(x => (LunasKasBonSearchModel)x);

            if (SearchFilter.UserKeyword != null)
                return
                    from c in result
                    where c.PihakKeduaName.ContainMultiWord(SearchFilter.UserKeyword)
                    select c;

            return result;
        }
    }
}
