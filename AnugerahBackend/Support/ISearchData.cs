using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Support
{

    public interface ISearch<T>
    {
        IEnumerable<T> Search();
        string SearchKeyword { get; set; }
        DateTime SearchDate1 { get; set; }
        DateTime SearchDate2 { get; set; }
        string SearchStaticFilter { get; set; }
    }

}
