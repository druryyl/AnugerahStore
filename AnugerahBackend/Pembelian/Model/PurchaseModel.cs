using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Pembelian.Model
{
    public class PurchaseModel
    {
        public string PurchaseID { get; set; }
        public string Tgl { get; set; }
        public string Jam { get; set; }
        public string SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string Keterangan { get; set; }
        public decimal TotalHarga { get; set; }
        public decimal Diskon { get; set; }
        public decimal BiayaLain { get; set; }
        public decimal GrandTotal { get; set; }

        public bool IsClosed { get; set; }
        public IEnumerable<PurchaseDetilModel> ListBrg { get; set; }
    }

    public class PurchaseSearchResultModel
    {
        public string PurchaseID { get; set; }
        public string Tgl { get; set; }
        public string SupplierName { get; set; }
        public string GrandTotal { get; set; }

        public static explicit operator PurchaseSearchResultModel(PurchaseModel model)
        {
            var result = new PurchaseSearchResultModel
            {
                PurchaseID = model.PurchaseID,
                Tgl = model.Tgl,
                SupplierName = model.SupplierName,
                GrandTotal = model.GrandTotal.ToString("N0").PadLeft(13, ' ')
            };
            return result;
        }
    }
}
