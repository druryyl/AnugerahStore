using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahWinform.StokBarang.View
{
    public interface IBPStokRekapView
    {
        string SearchKeyword { get; set; }
        bool IsForecasting { get; set; }
        int ProgressCounter { get; set; }
        int ProgressMax { get; set; }

        decimal PeriodeAnalisa { get; set; }
        decimal LeadTime { get; set; }

        List<BPStokRekapRowModel> ListResult { get; set; }
        List<BPStokRekapRowForecastingModel> ListResultForecasting { get; set; }
    }
    public class BPStokRekapRowModel
    {
        public string BrgID { get; set; }
        public string BrgName { get; set; }
        public decimal Qty { get; set; }
    }

    public class BPStokRekapRowForecastingModel: BPStokRekapRowModel
    {
        public decimal MovingAvg { get; set; }
        public decimal MaxStock { get; set; }
        public decimal MinStock { get; set; }
        public decimal ReOrder { get; set; }
        public string Status { get; set; }
    }

}
