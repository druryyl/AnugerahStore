using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnugerahBackend.Accounting.Dal;
using AnugerahBackend.Accounting.Model;
using AnugerahBackend.Penjualan.BL;
using AnugerahBackend.Support;
using AnugerahBackend.Support.BL;
using Ics.Helper.Database;
using Ics.Helper.Extensions;

namespace AnugerahBackend.Accounting.BL
{
    public interface IDepositBL : ISearch<DepositSearchModel>
    {
        DepositModel Save(DepositModel model);
        void Delete(string id);
        DepositModel GetData(string id);
        IEnumerable<DepositModel> ListData(string tgl1, string tgl2);
    }
    public class DepositBL : IDepositBL
    {
        private IDepositDal _depositDal;
        private IPihakKeduaBL _pihakKeduaBL;
        private IParameterNoBL _paramNoBL;
        private IJenisBayarBL _jenisBayarBL;

        public DepositBL()
        {
            _depositDal = new DepositDal();
            _pihakKeduaBL = new PihakKeduaBL();
            _paramNoBL = new ParameterNoBL();
            _jenisBayarBL = new JenisBayarBL();

            SearchFilter = new SearchFilter
            {
                IsDate = true,
                Date1 = DateTime.Now,
                Date2 = DateTime.Now,
            };
        }

        public DepositModel Save(DepositModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            //  cek pihak ke dua
            var pihakKedua = _pihakKeduaBL.GetData(model.PihakKeduaID);
            if (pihakKedua == null)
            {
                var errMsg = string.Format("PihakKeduaID invalid");
                throw new ArgumentException(errMsg);
            }
            else
            {
                model.PihakKeduaName = pihakKedua.PihakKeduaName;
            }

            //  cek jenis bayar
            var jenisBayar = _jenisBayarBL.GetData(model.JenisBayarID);
            if (jenisBayar == null)
                throw new ArgumentException("JenisBayarID Invalid ");
            else
            {
                model.JenisBayarName = jenisBayar.JenisBayarName;
                model.JenisKasID = jenisBayar.JenisKasID;
                model.JenisKasName = jenisBayar.JenisKasName;
            }

            //  cek nilai deposit
            if(model.NilaiDeposit <= 0 )
                throw new ArgumentException("Nilai Deposit tidak boleh minus");

            //  proses simpan
            using (var trans = TransHelper.NewScope())
            {
                if (model.DepositID.Trim() == "")
                {
                    model.DepositID = GenNewID();
                    _depositDal.Insert(model);
                }
                else
                {
                    _depositDal.Update(model);
                }
                trans.Complete();
            }
            return model;
        }

        private string GenNewID()
        {
            var prefix = "DP" + DateTime.Now.ToString("yyMM");
            var result = _paramNoBL.GenNewID(prefix, 10);
            return result;
        }


        public void Delete(string id)
        {
            _depositDal.Delete(id);
        }

        public DepositModel GetData(string id)
        {
            return _depositDal.GetData(id);
        }

        public IEnumerable<DepositModel> ListData(string tgl1, string tgl2)
        {
            return _depositDal.ListData(tgl1, tgl2);
        }

        public SearchFilter SearchFilter { get; set; }

        public IEnumerable<DepositSearchModel> Search()
        {
            //  ambil data
            var listAll = _depositDal.ListData(SearchFilter.TglDMY1, SearchFilter.TglDMY2);
            if (listAll == null) return null;

            //  convert ke SearchModel
            var result = listAll.Select(x => (DepositSearchModel)x);

            if (SearchFilter.UserKeyword != null)
                return
                    from c in result
                    where c.PihakKeduaName.ContainMultiWord(SearchFilter.UserKeyword)
                    select c;

            return result;
        }
    }
}
