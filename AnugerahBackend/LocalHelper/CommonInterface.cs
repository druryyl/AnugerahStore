using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.LocalHelper
{
    public interface IHeaderTrsDal<T>
    {
        void Insert(T model);
        void Update(T model);
        void Delete(string id);
        T GetData(string id);
        IEnumerable<T> ListData(string tgl1, string tgl2);
    }

    public interface IDetilTrsDal<T>
    {
        void Insert(T model);
        void Delete(string id);
        IEnumerable<T> ListData(string id);
    }

    public interface IMasterDal<T>
    {
        void Insert(T model);
        void Update(T model);
        void Delete(string id);
        T GetData(string id);
        IEnumerable<T> ListData();
    }
}
