using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnugerahBackend.Pembelian.Model;

namespace AnugerahWinform.Pembelian.View
{
    public interface ISupplierView
    {
        string SupplierID { get; set; }
        string SupplierName { get; set; }
        string Alamat { get; set; }
        string NoTelp { get; set; }
    }

}
