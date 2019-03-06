using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnugerahBackend.Pembelian.Model;

namespace AnugerahWinform.Accounting.View
{
    public interface IPegawaiView
    {
        string PegawaiID { get; set; }
        string PegawaiName { get; set; }
        string Alamat { get; set; }
        string NoTelp { get; set; }
    }

}
