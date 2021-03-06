﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnugerahBackend.Accounting.Dal;
using AnugerahBackend.Accounting.Model;
using AnugerahBackend.Support;
using AnugerahBackend.Support.BL;
using Ics.Helper.Database;
using Ics.Helper.Extensions;

namespace AnugerahBackend.Accounting.BL
{
    public interface IBiayaBL : ISearch<BiayaSearchModel>
    {
        IEnumerable<BiayaModel> Generate(LunasKasBonModel lunasKasBon);
        BiayaModel Save(BiayaModel model);
        void Delete(string id);
        BiayaModel GetData(string id);
        IEnumerable<BiayaModel> ListData(string tgl1, string tgl2);
    }
    public class BiayaBL : IBiayaBL
    {
        private IBiayaDal _biayaDal;
        private IParameterNoBL _paramNoBL;
        private IJenisBiayaBL _jenisBiayaBL;
        private IJenisKasBL _jenisKasBL;
        private IKasBonBL _kasBonBL;
        private IJenisLunasBL _jenisLunasBL;

        public BiayaBL()
        {
            _biayaDal = new BiayaDal();
            _paramNoBL = new ParameterNoBL();
            _jenisBiayaBL = new JenisBiayaBL();
            _jenisKasBL = new JenisKasBL();
            _kasBonBL = new KasBonBL();
            _jenisLunasBL = new JenisLunasBL();

            SearchFilter = new SearchFilter
            {
                IsDate = true,
                Date1 = DateTime.Now,
                Date2 = DateTime.Now
            };
        }

        public BiayaModel Save(BiayaModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            if (model.NilaiBiaya <= 0)
                throw new ArgumentException("Nilai Biaya invalid");

            var jenisBiaya = _jenisBiayaBL.GetData(model.JenisBiayaID);
            if (jenisBiaya == null)
                throw new ArgumentException("JenisBiayaID invalid");

            var jenisKas = _jenisKasBL.GetData(model.JenisKasID);
            if (jenisKas == null)
                throw new ArgumentException("JenisKasID invalid");

            if (model.BiayaID.Trim() == "")
                model.BiayaID = GenNewID();

            using (var trans = TransHelper.NewScope())
            {
                //  hapus data lama
                _biayaDal.Delete(model.BiayaID);
                //  simpan data baru
                _biayaDal.Insert(model);

                trans.Complete();
            }

            return model;
        }

        private string GenNewID()
        {
            var prefix = "BY" + DateTime.Now.ToString("yyMM");
            var result = _paramNoBL.GenNewID(prefix, 10);
            return result;
        }

        public void Delete(string id)
        {
            _biayaDal.Delete(id);
        }

        public BiayaModel GetData(string id)
        {
            return _biayaDal.GetData(id);
        }

        public IEnumerable<BiayaModel> ListData(string tgl1, string tgl2)
        {
            return _biayaDal.ListData(tgl1, tgl2);
        }

        public SearchFilter SearchFilter { get; set; }

        public IEnumerable<BiayaSearchModel> Search()
        {
            //  ambil data
            var listAll = _biayaDal.ListData(SearchFilter.TglDMY1, SearchFilter.TglDMY2);
            if (listAll == null) return null;

            //  convert ke SearchModel
            var result = listAll.Select(x => (BiayaSearchModel)x);

            if (SearchFilter.UserKeyword != null)
                return
                    from c in result
                    where c.Keterangan.ContainMultiWord(SearchFilter.UserKeyword)
                    select c;

            return result;
        }

        public IEnumerable<BiayaModel> Generate(LunasKasBonModel lunasKasBon)
        {
            List<BiayaModel> result = null;
            if (lunasKasBon == null)
            {
                throw new ArgumentNullException(nameof(lunasKasBon));
            }
            if(lunasKasBon.ListLunas == null)
            {
                throw new ArgumentNullException(nameof(lunasKasBon.ListLunas));
            }

            //  cek kasbon-nya exist atau tidak
            var kasBon = _kasBonBL.GetData(lunasKasBon.KasBonID);
            if (kasBon == null) throw new ArgumentException("KasBon tidak ditemukasn");
            
            //  cek apakah ada detil ListLunas yang BIAYA
            IEnumerable<LunasKasBonDetilModel> listDetilLunasKasBonBiaya =
                from c in lunasKasBon.ListLunas
                where c.JenisLunasID != "KAS"
                select c;
            if (listDetilLunasKasBonBiaya == null)
                return null;

            // Generate Biaya
            var noUrut = 0;
            foreach(var item in listDetilLunasKasBonBiaya)
            {
                var jenisLunas = _jenisLunasBL.GetData(item.JenisLunasID);
                if (jenisLunas == null)
                    throw new ArgumentException("Generate Biaya failed. JenisLunas invalid");

                var biaya = new BiayaModel
                {
                    BiayaID = lunasKasBon.LunasKasBonID +'-' + noUrut.ToString().PadLeft(2,'0'),
                    Tgl = lunasKasBon.Tgl,
                    Jam = lunasKasBon.Jam,
                    JenisBiayaID = jenisLunas.JenisBiayaID,
                    JenisKasID = kasBon.JenisKasID,
                    Keterangan = "[LUNAS-KASBON] " + jenisLunas.JenisLunasName + ' ' + kasBon.Keterangan,
                    NilaiBiaya = item.NilaiLunas
                };
                var itemResult = Save(biaya);

                if (result == null)
                    result = new List<BiayaModel>();

                result.Add(itemResult);
                noUrut++;
            }
            return result;
        }
    }
}
