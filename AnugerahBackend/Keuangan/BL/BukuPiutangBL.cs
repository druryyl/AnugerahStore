using AnugerahBackend.Keuangan.Dal;
using AnugerahBackend.Keuangan.Model;
using AnugerahBackend.Support;
using AnugerahBackend.Support.BL;
using Ics.Helper.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Keuangan.BL
{
    public interface IBukuPiutangBL : ISearch<BukuPiutangSearchModel>
    {
        BukuPiutangModel GetData(string bukuPiutangID);
        BukuPiutangModel GenBukuPiutang(BukuKasModel bukuKas);
        BukuPiutangModel GenBukuPiutangLunas(BukuKasModel bukuKas);

    }

    public class BukuPiutangBL : IBukuPiutangBL
    {
        private IBukuPiutangDal _bukuPiutangDal;
        private IBukuPiutangLunasDal _bukuPiutangLunasDal;
        private IBukuHutangLunasDal _bukuHutangLunasDal;

        private IParameterNoBL _paramNoBL;

        public BukuPiutangBL()
        {
            _bukuPiutangDal = new BukuPiutangDal();
            _bukuPiutangLunasDal = new BukuPiutangLunasDal();
            _bukuHutangLunasDal = new BukuHutangLunasDal();
            _paramNoBL = new ParameterNoBL();
            SearchFilter = new SearchFilter();
        }

        public BukuPiutangBL(IBukuPiutangDal injBukuPiutangDal,
            IBukuPiutangLunasDal injBukuPiutangLunasDal,
            IBukuHutangLunasDal injBukuHutangLunasDal,
            IParameterNoBL injParamNoBL)
        {
            _bukuPiutangDal = injBukuPiutangDal;
            _bukuPiutangLunasDal = injBukuPiutangLunasDal;
            _bukuHutangLunasDal = injBukuHutangLunasDal;
            _paramNoBL = injParamNoBL;
        }


        private string GetBukuPiutangID(BukuKasModel bukuKas)
        {
            string result = null;
            var listPiutangDetil = _bukuPiutangLunasDal.ListData(bukuKas);
            if (listPiutangDetil != null)
                result = listPiutangDetil.First().BukuPiutangID;
            return result;
        }
        private string GenNewBukuPiutangID()
        {
            var prefix = "PT" + DateTime.Now.ToString("yyMM");
            var result = _paramNoBL.GenNewID(prefix, 10);
            return result;
        }

        private BukuPiutangModel CreateBukuPiutang(BukuKasModel bukuKas)
        {
            BukuPiutangModel result = null;

            //  piutang, nilai kas harus minus
            if (bukuKas.NilaiKas >= 0)
                throw new ArgumentException("Generate Piutang harus Kas Keluar");

            //  bentuk object bukuPiutang utuh atas bukuKas ini;
            //  
            //  cari bukuPiutangID-nya
            var bukuPiutangID = GetBukuPiutangID(bukuKas);
            //  jika ngga ada, bikin id baru (berarti data baru)
            if (bukuPiutangID == null)
                bukuPiutangID = GenNewBukuPiutangID();

            //  ambil data bukuPiutang berdasarkan piutangID-nya
            result = GetData(bukuPiutangID);
            if (result == null) result = new BukuPiutangModel();
            //
            //  update header-nya dengan data baru
            result.BukuPiutangID = bukuPiutangID;
            result.TglBuku = bukuKas.TglBuku;
            result.JamBuku = bukuKas.JamBuku;
            result.UserrID = bukuKas.UserrID;
            result.PihakKetigaID = bukuKas.PihakKetigaID;
            result.NilaiPiutang = bukuKas.NilaiKas;
            result.NilaiSisa = bukuKas.NilaiKas;
            result.Keterangan = bukuKas.Keterangan;
            result.BukuKasID = bukuKas.BukuKasID;
            //
            //  bikin list detil baru
            var newListDetil = new List<BukuPiutangLunasModel>();
            var noUrut = 0;
            var item = new BukuPiutangLunasModel
            {
                BukuPiutangLunasID = bukuPiutangID + "-" + noUrut.ToString().PadLeft(2,'0'),
                BukuPiutangID = bukuPiutangID,
                TglLunas = bukuKas.TglBuku,
                JamLunas = bukuKas.JamBuku,
                NilaiLunas = bukuKas.NilaiKas,
                BukuKasID = bukuKas.BukuKasID
            };
            newListDetil.Add(item);
            //
            //  tambahkan dari item2 listDetil yang lama
            //  kecuali yang bukuKasID yang "ini"
            if(result.ListLunas != null)
                foreach(var item2 in result.ListLunas.Where(x => x.BukuKasID !=bukuKas.BukuKasID))
                {
                    noUrut++;
                    item2.BukuPiutangLunasID = bukuPiutangID + "-" + noUrut.ToString().PadLeft(2, '0');
                    item2.BukuPiutangID = bukuPiutangID;
                    newListDetil.Add(item);
                }
            //  tempelkan ke object buku piutang yag baru
            result.ListLunas = newListDetil;
            //
            //  Proses Save
            return result;
        }

        private BukuPiutangModel Save(BukuPiutangModel bukuPiutang)
        {
            //  validasi nilai sisa piutang
            bukuPiutang.NilaiSisa = bukuPiutang.ListLunas.Sum(x => x.NilaiLunas);

            //  update bukuPiutangID di detil harus sama dengan header semuana
            foreach (var item in bukuPiutang.ListLunas)
                item.BukuPiutangID = bukuPiutang.BukuPiutangID;

            //  update bukuPiutangLunas ID
            var noUrut = 0;
            foreach(var item in bukuPiutang.ListLunas.OrderBy(x=>x.TglLunas).OrderBy(x => x.JamLunas))
            {
                var noBukuPiutangLunasID = string.Format("{0}-{1}",
                    bukuPiutang.BukuPiutangID, noUrut.ToString().PadLeft(2, '0'));
                item.BukuPiutangLunasID = noBukuPiutangLunasID;
                noUrut++;
            }

            //  - hapus data lama
            _bukuPiutangDal.Delete(bukuPiutang.BukuPiutangID);
            _bukuPiutangLunasDal.Delete(bukuPiutang.BukuPiutangID);
            //
            //  insert data baru
            _bukuPiutangDal.Insert(bukuPiutang);
            foreach (var item in bukuPiutang.ListLunas)
                _bukuPiutangLunasDal.Insert(item);

            return bukuPiutang;
        }

        public BukuPiutangModel GetData(string bukuPiutangID)
        {
            BukuPiutangModel result = null;
            result = _bukuPiutangDal.GetData(bukuPiutangID);
            if (result != null)
                result.ListLunas = _bukuPiutangLunasDal.ListData(bukuPiutangID);

            return result;
        }

        public BukuPiutangModel GenBukuPiutang(BukuKasModel bukuKas)
        {
            var bukuPiutang = CreateBukuPiutang(bukuKas);
            var result = Save(bukuPiutang);
            return result;
        }

        public BukuPiutangModel GenBukuPiutangLunas(BukuKasModel bukuKas)
        {
            //  ambil data piutang lunas lama
            BukuPiutangModel bukuPiutangLama = null;
            var bukuPiutangID = GetBukuPiutangID(bukuKas);
            if (bukuPiutangID != null)
            {
                bukuPiutangLama = GetData(bukuPiutangID);
                var listLunasLama = bukuPiutangLama.ListLunas.ToList();
                for(int i = 0; i <= listLunasLama.Count - 1; i++)
                {
                    if(listLunasLama[i].BukuKasID == bukuKas.BukuKasID)
                    {
                        listLunasLama.RemoveAt(i);
                        break;
                    }
                }
                bukuPiutangLama.ListLunas = listLunasLama;
            }
            
            //  ambil data piutang yang baru
            var bukuPiutangBaru = GetData(bukuKas.ReffID);
            var piutangLunas = new BukuPiutangLunasModel
            {
                TglLunas = bukuKas.TglBuku,
                JamLunas = bukuKas.JamBuku,
                NilaiLunas = bukuKas.NilaiKas,
                BukuKasID = bukuKas.BukuKasID
            };
            var listLunas = bukuPiutangBaru.ListLunas.ToList();
            //  hapus detil lunas lama yang bukukas-nya sama
            if (listLunas != null)
            {
                for (int i = 0; i <= listLunas.Count - 1; i++)
                {
                    if (listLunas[i].BukuKasID == bukuKas.BukuKasID)
                    {
                        listLunas.RemoveAt(i);
                        break;
                    }
                }
            }
            //bukuPiutangBaru.ListLunas = listLunas;
            listLunas.Add(piutangLunas);
            bukuPiutangBaru.ListLunas = listLunas;

            BukuPiutangModel result = null;
            //  simpan update data lama
            if (bukuPiutangLama!=null)
                result = Save(bukuPiutangLama);
            //  simpan data baru
            result = Save(bukuPiutangBaru);
            return result;
        }

        #region SEARCH
        public SearchFilter SearchFilter { get; set; }

        public IEnumerable<BukuPiutangSearchModel> Search()
        {
            var listData = _bukuPiutangDal.ListData(SearchFilter.StaticKeyword);
            if (listData == null) return null;

            var result = listData.Select(x => (BukuPiutangSearchModel)x);

            if (SearchFilter.UserKeyword != null)
                return
                    from c in result
                    where c.Keterangan.ContainMultiWord(SearchFilter.UserKeyword)
                    select c;

            return result;
        }

        #endregion
    }
}
