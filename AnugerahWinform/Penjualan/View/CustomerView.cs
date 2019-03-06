using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahWinform.Penjualan.View
{
    public interface ICustomerView
    {
        string CustomerID { get; set; }
        string CustomerName { get; set; }
        string Alamat1 { get; set; }
        string Alamat2 { get; set; }
        string NoTelp { get; set; }
        string ContactPerson { get; set; }
    }
}
