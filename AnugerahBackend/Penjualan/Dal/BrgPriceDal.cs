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
    public interface IBrgPriceDal
    {
        void Insert(string brgID, BrgPriceModel brgPrice);
        void Delete(string brgID);
        IEnumerable<BrgPriceModel> ListData(string brgID);
    }


    public class BrgPriceDal : IBrgPriceDal
    {
        public string _connString;

        public BrgPriceDal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void Insert(string brgID, BrgPriceModel brgPrice)
        {
            var sSql = @"
                INSERT INTO
                    BrgPrice (
                        BrgID, Qty, Harga, Diskon)
                VALUES (
                        @BrgID, @Qty, @Harga, @Diskon) ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BrgID", brgID);
                cmd.AddParam("@Qty", brgPrice.Qty);
                cmd.AddParam("@Harga", brgPrice.Harga);
                cmd.AddParam("@Diskon", brgPrice.Diskon);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string id)
        {
            var sSql = @"
                DELETE
                    BrgPrice 
                WHERE
                    BrgID = @BrgID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BrgID", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<BrgPriceModel> ListData(string brgID)
        {
            List<BrgPriceModel> result = null;
            var sSql = @"
                SELECT
                    aa.BrgID, aa.Qty, aa.Harga, aa.Diskon
                FROM
                    BrgPrice aa 
                WHERE
                    BrgID = @BrgID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BrgID", brgID);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        result = new List<BrgPriceModel>();
                        while (dr.Read())
                        {
                            var item = new BrgPriceModel
                            {
                                BrgID = dr["BrgID"].ToString(),
                                Qty = Convert.ToInt16(dr["Qty"]),
                                Harga = Convert.ToDouble(dr["Harga"]),
                                Diskon = Convert.ToDouble(dr["Diskon"])
                            };
                            result.Add(item);
                        }
                    }
                }
            }
            return result;
        }
    }
}
