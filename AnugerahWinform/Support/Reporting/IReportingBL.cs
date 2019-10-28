using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahWinform.Support.Reporting
{
    public interface IReportingBL<T>
    {
        IEnumerable<T> ListData(DateTime tgl1, DateTime tgl2);
    }
}
