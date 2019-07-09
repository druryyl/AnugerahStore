using AnugerahBackend.Accounting.Model;
using Ics.Helper.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Accounting.Dal
{
    public interface IDepositDetilDal
    {
        void Insert(DepositDetilModel model);
        void Delete(string depositID);
        IEnumerable<DepositDetilModel> ListBrg(string depositID);

    }
    public class DepositDetilDal : IDepositDetilDal
    {
        private readonly string _connString;

        public DepositDetilDal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"]
                .ConnectionString;
        }
        public void Insert(DepositDetilModel model)
        {
            var sSql = @"
                INSERT INTO
                    DepositDetil (
                        DepositID, BrgID, Qty, Harga, SubTotal)
                VALUES (
                        @DepositID, @BrgID, @Qty, @Harga, @SubTotal) ";

            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@DepositID", model.DepositID);
                cmd.AddParam("@BrgID", model.BrgID);
                cmd.AddParam("@Qty", model.Qty);
                cmd.AddParam("@Harga", model.Harga);
                cmd.AddParam("@SubTotal", model.SubTotal);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string depositID)
        {
            var sSql = @"
                DELETE
                    DepositDetil
                WHERE
                    DepositID = @DepositID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@DepositID", depositID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<DepositDetilModel> ListBrg(string depositID)
        {
            List<DepositDetilModel> result = null;

            var sSql = @"
                SELECT
                    BrgID, Qty, Harga, SubTotal
                FROM
                    DepositDetil 
                WHERE
                    DepositID = @DepositID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@DepositID", depositID);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (!dr.HasRows) return null;

                    result = new List<DepositDetilModel>();
                    while (dr.Read())
                    {
                        var item = new DepositDetilModel
                        {
                            BrgID = dr["BrgID"].ToString(),
                            Qty = Convert.ToDecimal(dr["Qty"]),
                            Harga = Convert.ToDecimal(dr["Harga"]),
                            SubTotal = Convert.ToDecimal(dr["SubTotal"])
                        };
                        result.Add(item);
                    }
                }
            }
            return result;
        }
    }
}
