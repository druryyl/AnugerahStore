using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnugerahBackend.Pembelian.Model;

namespace AnugerahWinform.Pembelian.View
{
    public interface IPurchaseView
    {
        string PurchaseID { get; set; }
        string Tgl { get; set; }
        string Jam { get; set; }

        string SupplierID { get; set; }
        string SupplierName { get; set; }
        string Alamat { get; set; }
        string NoTelp { get; set; }

        string Catatan { get; set; }
        List<PurchaseDetilModel> ListBrg { get; set; }

        decimal Total { get; set; }
        decimal DiskonLain { get; set; }
        decimal BiayaLain { get; set; }
        decimal GrandTotal { get; set; }
    }
}
