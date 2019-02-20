using System;
using System.Collections.Generic;
using System.Linq;
using AnugerahBackend.Accounting.Dal;
using AnugerahBackend.Accounting.Model;
using AnugerahBackend.Support;
using AnugerahBackend.Support.BL;
using Ics.Helper.Database;
using Ics.Helper.Extensions;

namespace AnugerahBackend.Accounting.BL
{
    public interface IReturDepositBL : ISearch<ReturDepositSearchModel>
    {
        ReturDepositModel Save(ReturDepositModel model);
        void Delete(string id);
        ReturDepositModel GetData(string id);
        IEnumerable<ReturDepositModel> ListData(string tgl1, string tgl2);
    }
    public class ReturDepositBL : IReturDepositBL
    {
        private IReturDepositDal _returDepositDal;
        private IDepositBL _depositBL;
        private IJenisKasBL _jenisKasBL;
        private IParameterNoBL _paramNoBL;

        public ReturDepositBL()
        {
            _returDepositDal = new ReturDepositDal();
            _depositBL = new DepositBL();
            _jenisKasBL = new JenisKasBL();
            _paramNoBL = new ParameterNoBL();

            SearchFilter = new SearchFilter
            {
                IsDate = true,
                Date1 = DateTime.Now,
                Date2 = DateTime.Now
            };
        }
        public ReturDepositModel Save(ReturDepositModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            //  validate depositID
            var deposit = _depositBL.GetData(model.DepositID);
            if (deposit == null)
                throw new ArgumentException("DepositID invalid");
            else
            {
                model.PihakKeduaName = deposit.PihakKeduaName;
            }

            //  validate jenisKas
            var jenisKas = _jenisKasBL.GetData(model.JenisKasID);
            if (jenisKas == null)
                throw new ArgumentException("JenisKasID invalid");
            else
                model.JenisKasName = jenisKas.JenisKasName;

            //  cek nilai retur harus antara 0 dan sisa deposit
            if (model.NilaiReturDeposit > model.NilaiSisaDeposit)
                throw new ArgumentException("NilaiReturDeposit Invalid");
            if (model.NilaiReturDeposit <= 0)
                throw new ArgumentException("NilaiReturDeposit Invalid minus");

            //  proses simpan
            using (var trans = TransHelper.NewScope())
            {
                if (model.ReturDepositID.Trim() == "")
                    model.ReturDepositID = GenNewID();

                // hapus data lama
                _returDepositDal.Delete(model.ReturDepositID);
                //  simpan data baru
                _returDepositDal.Insert(model);

                trans.Complete();
            }
            return model;
        }

        private string GenNewID()
        {
            var prefix = "RD" + DateTime.Now.ToString("yyMM");
            var result = _paramNoBL.GenNewID(prefix, 10);
            return result;
        }

        public void Delete(string id)
        {
            _returDepositDal.Delete(id);
        }

        public ReturDepositModel GetData(string id)
        {
            return _returDepositDal.GetData(id);
        }

        public IEnumerable<ReturDepositModel> ListData(string tgl1, string tgl2)
        {
            return _returDepositDal.ListData(tgl1, tgl2);
        }

        public SearchFilter SearchFilter { get; set; }

        public IEnumerable<ReturDepositSearchModel> Search()
        {
            //  ambil data
            var listAll = _returDepositDal.ListData(SearchFilter.TglDMY1, SearchFilter.TglDMY2);
            if (listAll == null) return null;

            //  convert ke SearchModel
            var result = listAll.Select(x => (ReturDepositSearchModel)x);

            if (SearchFilter.UserKeyword != null)
                return
                    from c in result
                    where c.PihakKeduaName.ContainMultiWord(SearchFilter.UserKeyword)
                    select c;

            return result;
        }
    }
}
