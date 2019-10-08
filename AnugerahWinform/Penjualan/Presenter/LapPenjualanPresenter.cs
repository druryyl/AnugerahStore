using AnugerahBackend.Penjualan.BL;
using AnugerahBackend.Penjualan.Model;
using AnugerahBackend.StokBarang.BL;
using AnugerahBackend.Support;
using AnugerahWinform.Penjualan.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahWinform.Penjualan.Presenter
{
    public class LapPenjualanPresenterDependency
    {
        public IPenjualanBL PenjualanBL { get; set; }
        public IBrgBL BrgBL { get; set; }
    }

    public class LapPenjualanPresenter
    {
        private readonly ILapPenjualanView _view;
        private readonly LapPenjualanPresenterDependency _dep;

        public LapPenjualanPresenter(ILapPenjualanView view)
        {
            _view = view;
            _dep = new LapPenjualanPresenterDependency
            {
                PenjualanBL = new PenjualanBL(),
                BrgBL = new BrgBL(),
            };
        }

        public LapPenjualanPresenter(ILapPenjualanView view, LapPenjualanPresenterDependency dep)
        {
            _view = view;
            _dep = dep;
        }

        public void Proses()
        {
            //  cari barangnya berdasarkan keyword
            var searchKeyword = _view.SearchKeyword;
            _dep.PenjualanBL.SearchFilter = new SearchFilter
            {
                UserKeyword = searchKeyword,
                Date1 = _view.PeriodeAwal,
                Date2 = _view.PeriodeAkhir
            };
            IEnumerable<PenjualanSearchModel> listPenjualan = _dep.PenjualanBL.Search();

            //  jika barang tidak ditemukan, then escape point and kosongkan result
            if (listPenjualan == null)
            {
                _view.ListResult = new List<PenjualanViewModel>();
                return;
            }

            //  persiapkan return value
            List<PenjualanViewModel> listResult = new List<PenjualanViewModel>();

            //  scan result, compose the returning list
            _view.ProgressCounter = 0;
            _view.ProgressMax = listPenjualan.Count();
            var result = new List<PenjualanViewModel>();
            var lastTgl = "";
            var itemTotal = new PenjualanViewModel
            {
                Tgl = "",
                NoNota = "",
                CustomerName = "TOTAL"
            };
            foreach (var item in listPenjualan.OrderBy(x => x.TglJual + x.PenjualanID))
            {
                var itemResult = new PenjualanViewModel
                {
                    Tgl = lastTgl == item.TglJual ? "" : item.TglJual,
                    NoNota = item.PenjualanID,
                    CustomerName = item.BuyerName,
                };
                lastTgl = item.TglJual;
                var jual = _dep.PenjualanBL.GetData(item.PenjualanID);

                itemResult.Penjualan = jual.NilaiGrandTotal;

                var tempItem = jual.ListBayar.Where(x => x.JenisBayarID == "KAS");
                if (tempItem != null) itemResult.Kas = tempItem.Sum(x => x.NilaiBayar);

                tempItem = jual.ListBayar.Where(x => x.JenisBayarID == "ED1");
                if (tempItem != null) itemResult.BcaEdc = tempItem.Sum(x => x.NilaiBayar);

                tempItem = jual.ListBayar.Where(x => x.JenisBayarID == "ED2");
                if (tempItem != null) itemResult.BriEdc = tempItem.Sum(x => x.NilaiBayar);

                tempItem = jual.ListBayar.Where(x => x.JenisBayarID == "TR1");
                if (tempItem != null) itemResult.BcaTrf = tempItem.Sum(x => x.NilaiBayar);

                tempItem = jual.ListBayar.Where(x => x.JenisBayarID == "TR2");
                if (tempItem != null) itemResult.BriTrf = tempItem.Sum(x => x.NilaiBayar);

                tempItem = jual.ListBayar.Where(x => x.JenisBayarID == "PTG");
                if (tempItem != null) itemResult.Piutang = tempItem.Sum(x => x.NilaiBayar);

                itemResult.Deposit = jual.NilaiDeposit;
                itemResult.Keterangan = jual.DepositID != "" ? $"Deposit: {jual.DepositID}" : "";
                result.Add(itemResult);

                //  update nilai total

                _view.ProgressCounter++;
            }
            itemTotal.Penjualan = result.Sum(x => x.Penjualan);
            itemTotal.Kas = result.Sum(x => x.Kas);
            itemTotal.BcaEdc = result.Sum(x => x.BcaEdc);
            itemTotal.BcaTrf = result.Sum(x => x.BcaTrf);
            itemTotal.BriEdc = result.Sum(x => x.BriEdc);
            itemTotal.BriTrf = result.Sum(x => x.BriTrf);
            itemTotal.Piutang = result.Sum(x => x.Piutang);
            itemTotal.Deposit = result.Sum(x => x.Deposit);
            result.Add(itemTotal);
            _view.ListResult = result;
        }
    }
}
