using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Penjualan.Model
{
    public class CustomerModel
    {
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Alamat1 { get; set; }
        public string Alamat2 { get; set; }
        public string NoTelp { get; set; }
        public string ContactPerson { get; set; }
    }

    public class CustomerSearchModel
    {
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Alamat1 { get; set; }
        public string NoTelp { get; set; }
    }

}
