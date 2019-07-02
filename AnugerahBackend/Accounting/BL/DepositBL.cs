using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnugerahBackend.Accounting.Dal;
using AnugerahBackend.Accounting.Model;
using AnugerahBackend.Penjualan.BL;
using AnugerahBackend.StokBarang.BL;
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
        string ListBrgString(DepositModel model);
    }
    public class DepositBL : IDepositBL
    {
        private IDepositDal _depositDal;
        private IPihakKeduaBL _pihakKeduaBL;
        private IParameterNoBL _paramNoBL;
        private IJenisBayarBL _jenisBayarBL;
        private IBrgBL _brgBL;
        private IDepositDetilDal _depositDetilDal;

        public DepositBL()
        {
            _depositDal = new DepositDal();
            _pihakKeduaBL = new PihakKeduaBL();
            _paramNoBL = new ParameterNoBL();
            _jenisBayarBL = new JenisBayarBL();
            _brgBL = new BrgBL();
            _depositDetilDal = new DepositDetilDal();

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

            if(model.ListBrg != null)
            {
                foreach(var item in model.ListBrg)
                {

                    var brg = _brgBL.GetData(item.BrgID);
                    if (brg == null)
                        throw new ArgumentException("BrgID invalid");
                }
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
                    if(model.ListBrg != null)
                        foreach (var item in model.ListBrg)
                        {
                            item.DepositID = model.DepositID;
                            _depositDetilDal.Insert(item);
                        }
                }
                else
                {
                    _depositDetilDal.Delete(model.DepositID);
                    _depositDal.Update(model);
                    if (model.ListBrg != null)
                        foreach (var item in model.ListBrg)
                        {
                            item.DepositID = model.DepositID;
                            _depositDetilDal.Insert(item);
                        }
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
            var listBrg = _depositDetilDal.ListBrg(id);

            var result = _depositDal.GetData(id);
            if (result != null)
                result.ListBrg = listBrg;
            return result;
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

        public string ListBrgString(DepositModel model)
        {
            if (model.ListBrg == null) return "";
            string result = "";
            foreach(var item in model.ListBrg)
            {
                var brg = _brgBL.GetData(item.BrgID);
                result += brg.BrgName;
                result += Environment.NewLine;
                result += string.Format("    {0}x  {1}",
                    item.Qty.ToString(), item.Harga.ToString("N0"));
                result += Environment.NewLine;
            }

            if(model.NilaiBiayaKirim != 0)
            {
                result += "Estimasi Biaya Kirim";
                result += Environment.NewLine;
                result += string.Format("    {0}x  {1}",
                    1, model.NilaiBiayaKirim.ToString("N0"));
                result += Environment.NewLine;
            }

            return result;
        }
    }
}
