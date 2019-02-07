using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Support
{

    public interface ISearch<T>
    {
        SearchFilter SearchFilter { get; set; }
        IEnumerable<T> Search();
    }

    public class SearchFilter
    {
        public string UserKeyword { get; set; }
        public bool IsDate { get; set; }
        public DateTime Date1 { get; set; }
        public DateTime Date2 { get; set; }
        public string StaticKeyword { get; set; }

        public string TglDMY1 { get => Date1.ToString("dd-MM-yyyy"); }
        public string TglDMY2 { get => Date2.ToString("dd-MM-yyyy"); }

        public SearchFilter()
        {
            UserKeyword = null;
            IsDate = false;
            Date1 = DateTime.MinValue;
            Date2 = DateTime.MinValue;
            StaticKeyword = null;
        }
    }
}
