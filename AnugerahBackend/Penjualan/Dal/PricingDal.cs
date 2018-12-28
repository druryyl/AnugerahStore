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

    public interface IPricingDal
    {
        void Insert(PriceTagDetailModel pricing);

        void Update(PriceTagDetailModel pricing);

        void Delete(string id);

        PriceTagDetailModel GetData(string id);

        IEnumerable<PriceTagDetailModel> ListData();
    }


    public class PricingDal : IPricingDal
    {
        public string _connString;

        public PricingDal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void Insert(PriceTagDetailModel pricing)
        {
            var sSql = @"
                INSERT INTO
                    Pricing (
                        BrgID, Price)
                VALUES (
                        @BrgID, @Price) ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BrgID", pricing.BrgID);
                cmd.AddParam("@Price", pricing.Price);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(PriceTagDetailModel pricing)
        {
            var sSql = @"
                UPDATE
                    Pricing 
                SET
                    Price = @Price
                WHERE
                    BrgID = @BrgID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BrgID", pricing.BrgID);
                cmd.AddParam("@Price", pricing.Price);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string id)
        {
            var sSql = @"
                DELETE
                    Pricing 
                WHERE
                    BrgID = @BrgID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BrgID", id);
            }
        }

        public PriceTagDetailModel GetData(string id)
        {
            PriceTagDetailModel result = null;
            var sSql = @"
                SELECT
                    aa.Price
                FROM
                    Pricing aa
                WHERE
                    aa.BrgID = @BrgID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BrgID", id);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        dr.Read();
                        result = new PriceTagDetailModel
                        {
                            BrgID = id,
                            Price = Convert.ToDouble(dr["Price"])
                        };
                    }
                }
            }
            return result;
        }

        public IEnumerable<PriceTagDetailModel> ListData()
        {
            List<PriceTagDetailModel> result = null;
            var sSql = @"
                SELECT
                    aa.BrgID, aa.Price
                FROM
                    Pricing aa ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        result = new List<PriceTagDetailModel>();
                        while (dr.Read())
                        {
                            var item = new PriceTagDetailModel
                            {
                                BrgID = dr["BrgID"].ToString(),
                                Price = Convert.ToDouble(dr["Price"])
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
