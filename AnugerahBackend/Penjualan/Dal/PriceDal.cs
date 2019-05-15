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
    public interface IPriceDal
    {
        void Insert(PriceModel price);
        void Update(PriceModel price);
        void Delete(string priceID);
        PriceModel GetData(string priceID);
        IEnumerable<PriceModel> ListData();
    }

    public class PriceDal : IPriceDal
    {
        private readonly string _connString;
        public PriceDal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void Insert(PriceModel price)
        {
            var sSql = @"
                INSERT INTO
                    Price (
                        PriceID, PriceName )
                VALUES (
                        @PriceID, @PriceName) ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@PriceID", price.PriceID);
                cmd.AddParam("@PriceName", price.PriceName);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(PriceModel price)
        {
            var sSql = @"
                UPDATE
                    Price 
                SET
                    PriceName = @PriceName
                WHERE
                    PriceID = @PriceID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@PriceID", price.PriceID);
                cmd.AddParam("@PriceName", price.PriceName);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string priceID)
        {
            var sSql = @"
                DELETE
                    Price 
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

        public PriceModel GetData(string priceID)
        {
            PriceModel result = null;
            var sSql = @"
                SELECT
                    PriceID, PriceName
                FROM
                    Price
                WHERE
                    PriceID = @PriceID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@PriceID", priceID);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (!dr.HasRows) return null;
                    result = new PriceModel
                    {
                        PriceID = dr["PriceID"].ToString(),
                        PriceName = dr["PriceName"].ToString()
                    };
                }
            }
            return result;
        }

        public IEnumerable<PriceModel> ListData()
        {
            throw new NotImplementedException();
        }
    }
}
