using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Support
{
    public interface ISearchData<T>
    {
        IEnumerable<T> Search(string keyword);
    }
}
