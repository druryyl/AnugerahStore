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
    public interface ISupplierDal
    {
        void Insert(SupplierModel model);
        void Update(SupplierModel model);
        void Delete(string id);
        SupplierModel GetData(string id);
        IEnumerable<SupplierModel> ListData();

    }

    public class SupplierDal : ISupplierDal
    {
        private string _connString;

        public SupplierDal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void Insert(SupplierModel model)
        {
            var sSql = @"
                INSERT INTO
                    Supplier (
                        SupplierID, SupplierName, Alamat,
                        NoTelp) 
                VALUES (
                        @SupplierID, @SupplierName, @Alamat,
                        @NoTelp)";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@SupplierID", model.SupplierID);
                cmd.AddParam("@SupplierName", model.SupplierName);
                cmd.AddParam("@Alamat", model.Alamat);
                cmd.AddParam("@NoTelp", model.NoTelp);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(SupplierModel model)
        {
            var sSql = @"
                UPDATE
                    Supplier 
                SET
                    SupplierName = @SupplierName, 
                    Alamat = @Alamat,
                    NoTelp = @NoTelp  
                WHERE
                    SupplierID = @SupplierID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@SupplierID", model.SupplierID);
                cmd.AddParam("@SupplierName", model.SupplierName);
                cmd.AddParam("@Alamat", model.Alamat);
                cmd.AddParam("@NoTelp", model.NoTelp);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string id)
        {
            var sSql = @"
                DELETE
                    Supplier
                WHERE
                    SupplierID = @SupplierID ";
            using (var conn  = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@SupplierID", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public SupplierModel GetData(string id)
        {
            SupplierModel result = null;

            var sSql = @"
                SELECT
                    SupplierID, SupplierName, Alamat, NoTelp
                FROM
                    Supplier 
                WHERE
                    SupplierID = @SupplierID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@SupplierID", id);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (!dr.HasRows) return null;
                    dr.Read();
                    result = new SupplierModel
                    {
                        SupplierID = dr["SupplierID"].ToString(),
                        SupplierName = dr["SupplierName"].ToString(),
                        Alamat = dr["Alamat"].ToString(),
                        NoTelp = dr["NoTelp"].ToString()
                    };
                }
            }
            return result;
        }

        public IEnumerable<SupplierModel> ListData()
        {
            List<SupplierModel> result = null;

            var sSql = @"
                SELECT
                    SupplierID, SupplierName, Alamat, NoTelp
                FROM
                    Supplier ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (!dr.HasRows) return null;
                    result = new List<SupplierModel>();
                    while (dr.Read())
                    {
                        var item = new SupplierModel
                        {
                            SupplierID = dr["SupplierID"].ToString(),
                            SupplierName = dr["SupplierName"].ToString(),
                            Alamat = dr["Alamat"].ToString(),
                            NoTelp = dr["NoTelp"].ToString()
                        };
                        result.Add(item);
                    }
                }
            }
            return result;
        }
    }
}