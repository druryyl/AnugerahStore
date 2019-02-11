using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnugerahBackend.Accounting.Model;

namespace AnugerahBackend.Accounting.BL
{
    public interface IBiayaBL
    {
        BiayaModel Save(BiayaModel model);
        void Delete(string id);
        BiayaModel GetData(string id);
        IEnumerable<BiayaModel> ListData(string tgl1, string tgl2);
    }
    public class BiayaBL
    {

    }
}
