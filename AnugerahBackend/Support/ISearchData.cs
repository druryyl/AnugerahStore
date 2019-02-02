using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Support
{
    public interface ISearchData<T>
    {
        IEnumerable<T> Search();
        IEnumerable<T> Search(string keyword);
        IEnumerable<T> Search(string keyword, string tgl1, string tgl2);
    }

    public interface ISearchStaticFilterData<T>
    {
        IEnumerable<T> SearchStaticFilter(string staticFilter);
        IEnumerable<T> SearchStaticFilter(string staticFilter, string keyword);
        IEnumerable<T> SearchStaticFilter(string staticFilter, string keyword, string tgl1, string tgl2);
    }


}
