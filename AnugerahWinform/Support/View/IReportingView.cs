using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahWinform.Support.View
{
    public interface IReportingView<T>
    {
        DateTime PeriodeAwal { get; set; }
        DateTime PeriodeAkhir { get; set; }
        string SearchKeyword { get; set; }
        bool IsDetail { get; set; }
        int ProgressCounter { get; set; }
        int ProgressMax { get; set; }
        List<T> ListData { get; set; }
    }
}
