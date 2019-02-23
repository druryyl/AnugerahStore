using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnugerahBackend.Pembelian.Model;
using Ics.Helper.Extensions;

namespace AnugerahBackend.Pembelian.Dal
{
    public interface IPurchaseDetilDal
    {
        void Insert(PurchaseDetilModel model);
        void Delete(string purchaseID);
        IEnumerable<PurchaseDetilModel> ListData(string purchaseID);
    }

    public class PurchaseDetilDal : IPurchaseDetilDal
    {
        private string _connString;
        public PurchaseDetilDal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void Insert(PurchaseDetilModel model)
        {
            var sSql = @"
                INSERT INTO
                    PurchaseDetil (
                        PurchaseID, PurchaseDetilID, NoUrut, BrgID, 
                        Qty, Harga, Diskon, TaxProsen, TaxRupiah, 
                        SubTotal )
                VALUES (
                        @PurchaseID, @PurchaseDetilID, @NoUrut, @BrgID, 
                        @Qty, @Harga, @Diskon, @TaxProsen, @TaxRupiah, 
                        @SubTotal ) ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@PurchaseID", model.PurchaseID);
                cmd.AddParam("@PurchaseDetilID", model.PurchaseDetilID);
                cmd.AddParam("@NoUrut", model.NoUrut);
                cmd.AddParam("@BrgID", model.BrgID);
                cmd.AddParam("Qty", model.Qty);
                cmd.AddParam("@Harga", model.Harga);
                cmd.AddParam("@Diskon", model.Diskon);
                cmd.AddParam("@TaxProsen", model.TaxProsen);
                cmd.AddParam("@TaxRupiah", model.TaxRupiah);
                cmd.AddParam("@SubTotal", model.SubTotal);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string purchaseID)
        {
            var sSql = @"
                DELETE
                    PurchaseDetil
                WHERE
                    PurchaseID = @PurchaseID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@PurchaseID", purchaseID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<PurchaseDetilModel> ListData(string purchaseID)
        {
            List<PurchaseDetilModel> result = null;
            var sSql = @"
                SELECT
                    aa.PurchaseID, aa.PurchaseDetilID, aa.NoUrut, aa.BrgID,
                    aa.Qty, aa.Harga, aa.Diskon, aa.TaxProsen, aa.TaxRupiah,
                    aa.SubTotal,
                    ISNULL(bb.BrgName, '') BrgName 
                FROM
                    PurchaseDetil aa
                    LEFT JOIN Brg bb ON aa.BrgID = bb.BrgID 
                WHERE
                    aa.PurchaseID = @PurchaseID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@PurchaseID", purchaseID);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (!dr.HasRows) return null;
                    result = new List<PurchaseDetilModel>();
                    while (dr.Read())
                    {
                        var item = new PurchaseDetilModel
                        {
                            PurchaseID = dr["PurchaseID"].ToString(),
                            PurchaseDetilID = dr["PurchaseDetilID"].ToString(),
                            NoUrut = Convert.ToInt16(dr["NoUrut"]),
                            BrgID = dr["BrgID"].ToString(),
                            BrgName = dr["BrgName"].ToString(),
                            Qty = Convert.ToInt64(dr["Qty"]),
                            Harga = Convert.ToDecimal(dr["Harga"]),
                            Diskon = Convert.ToDecimal(dr["Diskon"]),
                            SubTotal = Convert.ToDecimal(dr["SubTotal"]),
                            TaxProsen = Convert.ToDouble(dr["TaxProsen"]),
                            TaxRupiah = Convert.ToDecimal(dr["TaxRupiah"])
                        };
                        result.Add(item);
                    }
                }
            }
            return result;
        }
    }
}
