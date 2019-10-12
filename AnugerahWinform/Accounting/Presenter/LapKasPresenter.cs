using AnugerahBackend.Accounting.BL;
using AnugerahBackend.Accounting.Dal;
using AnugerahBackend.Accounting.Model;
using AnugerahBackend.Support;
using AnugerahWinform.Accounting.View;
using Ics.Helper.StringDateTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahWinform.Accounting.Presenter
{
    public class LapKasPresenterDependency
    {
        public IBPKasDal BPKasDal { get; set; }
        public IBPKasBL BPKasBL { get; set; }
        public IBPKasDetilDal BPKasDetilDal { get; set; }
    }

    public class LapKasPresenter
    {
        private readonly ILapKasView _view;
        private readonly LapKasPresenterDependency _dep;

        public LapKasPresenter(ILapKasView view)
        {
            _view = view;
            _dep = new LapKasPresenterDependency
            {
                BPKasDal = new BPKasDal(),
                BPKasDetilDal = new BPKasDetilDal(),
                BPKasBL = new BPKasBL()
            };
        }

        public LapKasPresenter(ILapKasView view, LapKasPresenterDependency dep)
        {
            _view = view;
            _dep = dep;
        }

        public void Proses()
        {
            //  cari barangnya berdasarkan keyword
            var searchKeyword = _view.SearchKeyword;
            _dep.BPKasBL.SearchFilter = new SearchFilter
            {
                UserKeyword = searchKeyword,
                Date1 = _view.PeriodeAwal,
                Date2 = _view.PeriodeAkhir
            };
            IEnumerable<BPKasSearchModel> listBPKas = _dep.BPKasBL.Search();

            //  jika kas tidak ditemukan, then escape point and kosongkan result
            if (listBPKas == null)
            {
                _view.ListResult = new List<LapKasViewModel>();
                return;
            }

            //  persiapkan return value
            List<LapKasViewModel> listResult = new List<LapKasViewModel>();

            //  scan result, compose the returning list
            _view.ProgressCounter = 0;
            _view.ProgressMax = listBPKas.Count();
            var result = new List<LapKasViewModel>();
            var lastTgl = "";
            var itemTotal = new LapKasViewModel
            {
                Tgl = "",
                Jam = "",
                NoTransaksi = "TOTAL",
            };
            foreach (var item in listBPKas.OrderBy(x => x.Tgl.ToTglYMD()+ x.Jam))
            {
                var itemResult = new LapKasViewModel
                {
                    Tgl = lastTgl == item.Tgl ? "" : item.Tgl,
                    Jam = item.Jam,
                    NoTransaksi = item.BPKasID,
                    Keterangan = item.Keterangan
                };
                lastTgl = item.Tgl;
                var listKas = _dep.BPKasDetilDal.ListData(item.BPKasID);

                if (listKas != null)
                {
                    var tempItem = listKas.Where(x => x.JenisKasID == "K01");
                    if (tempItem != null) itemResult.KasKecil = tempItem.Sum(x => x.NilaiKasMasuk - x.NilaiKasKeluar);

                    tempItem = listKas.Where(x => x.JenisKasID == "K02");
                    if (tempItem != null) itemResult.KasBankBca = tempItem.Sum(x => x.NilaiKasMasuk - x.NilaiKasKeluar);

                    tempItem = listKas.Where(x => x.JenisKasID == "K03");
                    if (tempItem != null) itemResult.KasBankBri = tempItem.Sum(x => x.NilaiKasMasuk - x.NilaiKasKeluar);

                }
                result.Add(itemResult);

                //  update nilai total

                _view.ProgressCounter++;
            }
            itemTotal.KasKecil = result.Sum(x => x.KasKecil);
            itemTotal.KasBankBca = result.Sum(x => x.KasBankBca);
            itemTotal.KasBankBri = result.Sum(x => x.KasBankBri);
            result.Add(itemTotal);
            _view.ListResult = result;
        }
    }
}
