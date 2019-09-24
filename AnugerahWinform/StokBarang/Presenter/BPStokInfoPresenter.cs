using AnugerahBackend.StokBarang.BL;
using AnugerahBackend.StokBarang.Model;
using AnugerahBackend.Support;
using AnugerahWinform.StokBarang.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahWinform.StokBarang.Presenter
{
    public class BPStokInfoPresenterDependency
    {
        public BPStokBL BPStokBL { get; set; }
        public BrgBL BrgBL { get; set; }
    }

    public class BPStokInfoPresenter
    {
        private readonly IBPStokInfoView _view;
        private readonly BPStokInfoPresenterDependency _dep;

        public BPStokInfoPresenter(IBPStokInfoView view)
        {
            _view = view;
            _dep = new BPStokInfoPresenterDependency
            {
                BPStokBL = new BPStokBL(),
                BrgBL = new BrgBL(),
            };
        }

        public BPStokInfoPresenter(IBPStokInfoView view, BPStokInfoPresenterDependency dep)
        {
            _view = view;
            _dep = dep;
        }

        public void Proses()
        {
            //  cari barangnya berdasarkan keyword
            var searchKeyword = _view.SearchKeyword;
            _dep.BrgBL.SearchFilter = new SearchFilter
            {
                UserKeyword = searchKeyword
            };
            IEnumerable<BrgSearchResultModel> listBrg = _dep.BrgBL.Search();

            //  jika barang tidak ditemukan, then escape point and kosongkan result
            if (listBrg == null)
            {
                _view.ListResult = new List<BPStokInfoRowModel>();
                return;
            }

            List<BPStokDetilView> result = new List<BPStokDetilView>();
            foreach(var item in listBrg)
            {
                var tgl1 = _view.PeriodeAwal.ToString("dd-MM-yyyy");
                var tgl2 = _view.PeriodeAkhir.ToString("dd-MM-yyyy");
                var result1 = _dep.BPStokBL.ListDetil(item.BrgID, tgl1, tgl2);
                if(result1 != null)
                    result.AddRange(result1);
            }
            var tempListResult = new List<BPStokInfoRowModel>();
            foreach(var item in result)
            {
                tempListResult.Add((BPStokInfoRowModel)item);
            }
            _view.ListResult = tempListResult;
        }

    }
}
