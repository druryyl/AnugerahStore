using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Pembelian.Model
{
    public class SupplierModel
    {
        public string SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string Alamat { get; set; }
        public string NoTelp { get; set; }
    }

    public class SupplierSearchModel
    {
        public string SupplierID { get; set; }
        public string SupplierName { get; set; }

        public static explicit operator SupplierSearchModel(SupplierModel model)
        {
            var result = new SupplierSearchModel
            {
                SupplierID = model.SupplierID,
                SupplierName = model.SupplierName
            };
            return result;
        }
    }
}
