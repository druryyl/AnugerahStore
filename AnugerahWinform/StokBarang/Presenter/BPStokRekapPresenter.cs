using AnugerahBackend.StokBarang.BL;
using AnugerahBackend.StokBarang.Dal;
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
    public class BPStokRekapPresenterDependency
    {
        public BPStokDetilDal BPStokDetilDal { get; set; }
        public BPStokDal BPStokDal { get; set; }
        public BrgBL BrgBL { get; set; }
    }

    public class BPStokRekapPresenter
    {
        private readonly IBPStokRekapView _view;
        private readonly BPStokRekapPresenterDependency _dep;

        public BPStokRekapPresenter(IBPStokRekapView view)
        {
            _view = view;
            _dep = new BPStokRekapPresenterDependency
            {
                BPStokDal = new BPStokDal(),
                BPStokDetilDal = new BPStokDetilDal(),
                BrgBL = new BrgBL(),
            };
        }

        public BPStokRekapPresenter(IBPStokRekapView view, BPStokRekapPresenterDependency dep)
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
                _view.ListResult = new List<BPStokRekapRowModel>();
                return;
            }

            List<BPStokRekapRowModel> result = new List<BPStokRekapRowModel>();
            int brgCount = listBrg.Count();
            _view.ProgressCounter = 0;
            _view.ProgressMax = brgCount;
            foreach (var item in listBrg)
            {
                _view.ProgressCounter++;
                var result1 = _dep.BPStokDal.ListData(item.BrgID);
                if (result1 == null)
                    continue;
                var totQty = result1.Sum(x => x.QtySisa);
                result.Add(new BPStokRekapRowModel
                {
                    BrgID = item.BrgID,
                    BrgName = item.BrgName,
                    Qty = totQty
                });
            }

            if (_view.IsForecasting)
            {
                _view.ListResultForecasting = forecast(result);
            }
            else
                _view.ListResult = result;
        }

        private List<BPStokRekapRowForecastingModel> forecast(IEnumerable<BPStokRekapRowModel> data)
        {
            if (data == null)
                return null;

            var result = new List<BPStokRekapRowForecastingModel>();
            _view.ProgressCounter = 0;
            _view.ProgressMax = data.Count();
            foreach (var item in data)
            {
                _view.ProgressCounter++;
                var stokNow = item.Qty;

                //  cari penjualan rata2 harian
                DateTime startDate = DateTime.Now.AddDays(Convert.ToDouble(-_view.PeriodeAnalisa));
                var listJual = _dep.BPStokDetilDal.ListData(item.BrgID,
                    startDate.ToString("dd-MM-yyyy"),
                    DateTime.Now.ToString("dd-MM-yyyy"));
                //  ambil total penjualan
                decimal totJual = 0;
                if (listJual == null)
                    totJual = 0;
                else
                    totJual = listJual.Sum(x => x.QtyOut);

                //  hitang rata2
                decimal dailyOutAvg = 0;
                if (totJual != 0)
                    dailyOutAvg = totJual / _view.PeriodeAnalisa;

                var forecastItem = new BPStokRekapRowForecastingModel();
                forecastItem.BrgID = item.BrgID;
                forecastItem.BrgName = item.BrgName;
                forecastItem.Qty = item.Qty;

                forecastItem.MovingAvg = dailyOutAvg;
                forecastItem.MaxStock = Math.Ceiling(_view.PeriodeAnalisa * dailyOutAvg);
                forecastItem.MinStock = Math.Ceiling(_view.LeadTime * dailyOutAvg);

                if (dailyOutAvg != 0)
                    forecastItem.ReOrder = Math.Ceiling((item.Qty - forecastItem.MinStock) / dailyOutAvg);
                else
                    forecastItem.ReOrder = 0;

                if (item.Qty > forecastItem.MaxStock)
                    forecastItem.Status = "OverStock";

                if (item.Qty <= forecastItem.MinStock)
                    forecastItem.Status = "StockOut";

                result.Add(forecastItem);
            }
            return result;
        }

    }
}
