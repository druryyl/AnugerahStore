using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Accounting.Model
{
    public class PegawaiModel
    {
        public string PegawaiID { get; set; }
        public string PegawaiName { get; set; }
        public string Alamat { get; set; }
        public string NoTelp { get; set; }
    }

    public class PegawaiSearchModel
    {
        public string PegawaiID { get; set; }
        public string PegawaiName { get; set; }

        public static explicit operator PegawaiSearchModel(PegawaiModel model)
        {
            var result = new PegawaiSearchModel
            {
                PegawaiID = model.PegawaiID,
                PegawaiName = model.PegawaiName
            };
            return result;
        }
    }
}
