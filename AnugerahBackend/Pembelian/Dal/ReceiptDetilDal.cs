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
    public interface IReceiptDetilDal
    {
        void Insert(ReceiptDetilModel model);
        void Delete(string receiptID);
        IEnumerable<ReceiptDetilModel> ListData(string receiptID);
    }

    public class ReceiptDetilDal : IReceiptDetilDal
    {
        private string _connString;
        public ReceiptDetilDal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void Insert(ReceiptDetilModel model)
        {
            var sSql = @"
                INSERT INTO
                    ReceiptDetil (
                        ReceiptID, ReceiptDetilID, NoUrut, BrgID, 
                        Qty, Harga, Diskon, TaxRupiah, 
                        SubTotal )
                VALUES (
                        @ReceiptID, @ReceiptDetilID, @NoUrut, @BrgID, 
                        @Qty, @Harga, @Diskon, @TaxRupiah, 
                        @SubTotal ) ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@ReceiptID", model.ReceiptID);
                cmd.AddParam("@ReceiptDetilID", model.ReceiptDetilID);
                cmd.AddParam("@NoUrut", model.NoUrut);
                cmd.AddParam("@BrgID", model.BrgID);
                cmd.AddParam("Qty", model.Qty);
                cmd.AddParam("@Harga", model.Harga);
                cmd.AddParam("@Diskon", model.Diskon);
                cmd.AddParam("@TaxRupiah", model.TaxRupiah);
                cmd.AddParam("@SubTotal", model.SubTotal);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string receiptID)
        {
            var sSql = @"
                DELETE
                    ReceiptDetil
                WHERE
                    ReceiptID = @ReceiptID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@ReceiptID", receiptID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<ReceiptDetilModel> ListData(string receiptID)
        {
            List<ReceiptDetilModel> result = null;
            var sSql = @"
                SELECT
                    aa.ReceiptID, aa.ReceiptDetilID, aa.NoUrut, aa.BrgID,
                    aa.Qty, aa.Harga, aa.Diskon, aa.TaxRupiah,
                    aa.SubTotal,
                    ISNULL(bb.BrgName, '') BrgName 
                FROM
                    ReceiptDetil aa
                    LEFT JOIN Brg bb ON aa.BrgID = bb.BrgID 
                WHERE
                    aa.ReceiptID = @ReceiptID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@ReceiptID", receiptID);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (!dr.HasRows) return null;
                    result = new List<ReceiptDetilModel>();
                    while (dr.Read())
                    {
                        var item = new ReceiptDetilModel
                        {
                            ReceiptID = dr["ReceiptID"].ToString(),
                            ReceiptDetilID = dr["ReceiptDetilID"].ToString(),
                            NoUrut = Convert.ToInt16(dr["NoUrut"]),
                            BrgID = dr["BrgID"].ToString(),
                            BrgName = dr["BrgName"].ToString(),
                            Qty = Convert.ToInt64(dr["Qty"]),
                            Harga = Convert.ToDecimal(dr["Harga"]),
                            Diskon = Convert.ToDecimal(dr["Diskon"]),
                            SubTotal = Convert.ToDecimal(dr["SubTotal"]),
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
