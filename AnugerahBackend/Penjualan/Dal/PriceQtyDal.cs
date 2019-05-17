using AnugerahBackend.Penjualan.Model;
using Ics.Helper.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Penjualan.Dal
{
    public interface IPriceQtyDal
    {
        void Insert(PriceQtyModel priceQty);
        void Delete(string priceID);
        IEnumerable<PriceQtyModel> ListData(string priceID);
    }
    public class PriceQtyDal : IPriceQtyDal
    {
        public readonly string _connString;

        public PriceQtyDal()
        {
            _connString = ConfigurationManager
                .ConnectionStrings["DefaultConnection"]
                .ConnectionString;
        }
        public void Insert(PriceQtyModel priceQty)
        {
            var sSql = @"
                INSERT INTO 
                    PriceQty (
                        PriceID, Qty, Harga, Diskon )
                VALUES (
                        @PriceID, @Qty, @Harga, @Diskon) ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@PriceID", priceQty.PriceID);
                cmd.AddParam("@Qty", priceQty.Qty);
                cmd.AddParam("@Harga", priceQty.Harga);
                cmd.AddParam("@Diskon", priceQty.Diskon);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string priceID)
        {
            var sSql = @"
                DELETE
                    PriceQty 
                WHERE
                    PriceID = @PriceID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@PriceID", priceID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<PriceQtyModel> ListData(string priceID)
        {
            List<PriceQtyModel> result;
            var sSql = @"
                SELECT
                    PriceID, Qty, Harga, Diskon
                FROM
                    PriceQty
                WHERE
                    PriceID = @PriceID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@PriceID", priceID);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (!dr.HasRows)
                        return null;

                    result = new List<PriceQtyModel>();
                    while (dr.Read())
                    {
                        var item = new PriceQtyModel
                        {
                            PriceID = dr["PriceID"].ToString(),
                            Qty = Convert.ToInt16(dr["Qty"]),
                            Harga = Convert.ToDecimal(dr["Harga"]),
                            Diskon = Convert.ToDecimal(dr["Diskon"])
                        };
                        result.Add(item);
                    }
                }
            }
            return result;
        }
    }
}
