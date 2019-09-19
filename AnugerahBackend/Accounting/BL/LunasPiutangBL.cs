using AnugerahBackend.Accounting.Dal;
using AnugerahBackend.Accounting.Model;
using AnugerahBackend.Penjualan.Dal;
using AnugerahBackend.Support;
using AnugerahBackend.Support.BL;
using Ics.Helper.Database;
using Ics.Helper.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Accounting.BL
{
    public interface ILunasPiutangBL : ISearch<LunasPiutangSearchModel>
    {
        void Save(LunasPiutangModel model);
        void Delete(string id);
        LunasPiutangModel GetData(string id);
        IEnumerable<LunasPiutangModel> ListData(string tgl1, string tgl2);
    }

    public class LunasPiutangBL : ILunasPiutangBL
    {
        private readonly ILunasPiutangDal _lunasPiutangDal;
        private readonly IPihakKeduaDal _pihakKeduaDal;
        private readonly IJenisBayarDal _jenisBayarDal;
        private readonly IBPPiutangBL _bpPiutangBL;
        private readonly IParameterNoBL _paramNoBL;
        private readonly ILunasPiutangDetilDal _lunasPiutangDetilDal;

        private const string TIPE_KAS_PIUTANG = "K04";

        public LunasPiutangBL()
        {
            _lunasPiutangDal = new LunasPiutangDal();
            _pihakKeduaDal = new PihakKeduaDal();
            _jenisBayarDal = new JenisBayarDal();
            _bpPiutangBL = new BPPiutangBL();
            _paramNoBL = new ParameterNoBL();
            _lunasPiutangDetilDal = new LunasPiutangDetilDal();

            SearchFilter = new SearchFilter
            {
                IsDate = true,
                Date1 = DateTime.Now,
                Date2 = DateTime.Now
            };

        }

        public LunasPiutangBL(ILunasPiutangDal lunasPiutangDal,
                IPihakKeduaDal pihakKeduaDal,
                IJenisBayarDal jenisBayarDal,
                IBPPiutangBL bpPiutangBL,
                IParameterNoBL paramNoBL,
                ILunasPiutangDetilDal lunasPiutangDetilDal)
        {
            _lunasPiutangDal = lunasPiutangDal;
            _pihakKeduaDal = pihakKeduaDal;
            _jenisBayarDal = jenisBayarDal;
            _bpPiutangBL = bpPiutangBL;
            _paramNoBL = paramNoBL;
            _lunasPiutangDetilDal = lunasPiutangDetilDal;
        }

        public void Save(LunasPiutangModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            //  validasi customer
            var customer = _pihakKeduaDal.GetData(model.PihakKeduaID);
            if (customer == null)
                throw new ArgumentException("CustomerID invalid");
            model.PihakKeduaName = customer.PihakKeduaName;

            //  validasi jenisbayar
            var jenisBayar = _jenisBayarDal.GetData(model.JenisBayarID);
            if (jenisBayar == null)
                throw new ArgumentException("JenisBayarID invalid");
            model.JenisBayarName = jenisBayar.JenisBayarName;

            //  pelunasan piutang tidak boleh dengan piutang
            if (jenisBayar.TipeKas == TIPE_KAS_PIUTANG)
                throw new ArgumentException("Pelunasan tidak boleh menggunakan Piutang");

            //  cek list piutang apakah benar milik customer ini;
            //  serta validasi nilai piutang vs nilai bayar
            foreach (var item in model.ListPiutangBayar)
            {
                var bpPiutang = _bpPiutangBL.GetData(item.PiutangID);
                if (bpPiutang == null)
                    throw new ArgumentException("PiutangID not found");
                if (bpPiutang.PihakKeduaID != model.PihakKeduaID)
                    throw new ArgumentException("PiutangID invalid Customer");
                if (bpPiutang.NilaiPiutang - bpPiutang.NilaiLunas < item.NilaiBayar)
                    throw new ArgumentException("Nilai Bayar melebihi piutang");
            }
            
            using (var trans = TransHelper.NewScope())
            {
                if (model.LunasPiutangID.Trim() == "")
                    model.LunasPiutangID = GenNewID();

                var noUrut = 1;
                foreach(var item in model.ListPiutangBayar)
                {
                    item.LunasPiutangID = model.LunasPiutangID;
                    var id2 = string.Format("{0}-{1}",
                        item.LunasPiutangID, 
                        noUrut.ToString().PadLeft(2, '0'));
                    item.LunasPiutangID2 = id2;
                    noUrut++;
                }

                //  hapus data lama
                _lunasPiutangDetilDal.Delete(model.LunasPiutangID);
                _lunasPiutangDal.Delete(model.LunasPiutangID);

                //  insert data baru
                _lunasPiutangDal.Insert(model);
                foreach(var item in model.ListPiutangBayar)
                    _lunasPiutangDetilDal.Insert(item);

                trans.Complete();
            }
        }

        private string GenNewID()
        {
            var prefix = "LP" + DateTime.Now.ToString("yyMM");
            var result = _paramNoBL.GenNewID(prefix, 10);
            return result;
        }
        public void Delete(string id)
        {
            using (var trans = TransHelper.NewScope())
            {
                _lunasPiutangDetilDal.Delete(id);
                _lunasPiutangDal.Delete(id);
                trans.Complete();

            }
        }

        public LunasPiutangModel GetData(string id)
        {
            var result = _lunasPiutangDal.GetData(id);
            if (result == null)
                return null;

            var resultDetil = _lunasPiutangDetilDal.ListData(id);
            result.ListPiutangBayar = resultDetil;
            return result;
        }

        public IEnumerable<LunasPiutangModel> ListData(string tgl1, string tgl2)
        {
            return _lunasPiutangDal.ListData(tgl1, tgl2);
        }

        public SearchFilter SearchFilter { get; set; }

        public IEnumerable<LunasPiutangSearchModel> Search()
        {
            //  ambil data
            var listAll = _lunasPiutangDal.ListData(SearchFilter.TglDMY1, SearchFilter.TglDMY2);
            if (listAll == null) return null;

            //  convert ke SearchModel
            var result = listAll.Select(x => (LunasPiutangSearchModel)x);

            if (SearchFilter.UserKeyword != null)
                return
                    from c in result
                    where c.CustomerName.ContainMultiWord(SearchFilter.UserKeyword)
                    select c;

            return result;
        }

    }
}
