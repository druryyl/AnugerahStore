using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnugerahBackend.Accounting.Model;

namespace AnugerahBackend.Accounting.Dal
{
    public interface IDepositDal
    {
        void Insert(DepositModel model);
        void Update(DepositModel model);
        void Delete(string id);
        DepositModel GetData(string id);
        IEnumerable<DepositModel> ListData(string tgl1, string tgl2);
    }
    class DepositDal
    {
    }
}
