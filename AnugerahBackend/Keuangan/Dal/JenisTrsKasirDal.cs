using AnugerahBackend.Keuangan.Model;
using Ics.Helper.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Keuangan.Dal
{


    public interface IJenisTrsKasirDal
    {
        void Insert(JenisTrsKasirModel jenisTrsKasir);

        void Update(JenisTrsKasirModel jenisTrsKasir);

        void Delete(string id);

        JenisTrsKasirModel GetData(string id);

        IEnumerable<JenisTrsKasirModel> ListData();
    }

    public class JenisTrsKasirDal : IJenisTrsKasirDal
    {
        public string _connString;

        public JenisTrsKasirDal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void Insert(JenisTrsKasirModel jenisTrsKasir)
        {
            var sSql = @"
                INSERT INTO
                    JenisTrsKasir (
                        JenisTrsKasirID, JenisTrsKasirName, IsKasKeluar)
                VALUES (
                        @JenisTrsKasirID, @JenisTrsKasirName, @IsKasKeluar) ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@JenisTrsKasirID", jenisTrsKasir.JenisTrsKasirID);
                cmd.AddParam("@JenisTrsKasirName", jenisTrsKasir.JenisTrsKasirName);
                cmd.AddParam("@IsKasKeluar", jenisTrsKasir.IsKasKeluar);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(JenisTrsKasirModel jenisTrsKasir)
        {
            var sSql = @"
                UPDATE
                    JenisTrsKasir 
                SET
                    JenisTrsKasirName = @JenisTrsKasirName,
                    IsKasKeluar = @IsKasKeluar
                WHERE
                    JenisTrsKasirID = @JenisTrsKasirID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@JenisTrsKasirID", jenisTrsKasir.JenisTrsKasirID);
                cmd.AddParam("@JenisTrsKasirName", jenisTrsKasir.JenisTrsKasirName);
                cmd.AddParam("@IsKasKeluar", jenisTrsKasir.IsKasKeluar);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string id)
        {
            var sSql = @"
                DELETE
                    JenisTrsKasir 
                WHERE
                    JenisTrsKasirID = @JenisTrsKasirID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@JenisTrsKasirID", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public JenisTrsKasirModel GetData(string id)
        {
            JenisTrsKasirModel result = null;
            var sSql = @"
                SELECT
                    aa.JenisTrsKasirName, aa.IsKasKeluar
                FROM
                    JenisTrsKasir aa
                WHERE
                    aa.JenisTrsKasirID = @JenisTrsKasirID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@JenisTrsKasirID", id);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        dr.Read();
                        result = new JenisTrsKasirModel
                        {
                            JenisTrsKasirID = id,
                            JenisTrsKasirName = dr["JenisTrsKasirName"].ToString(),
                            IsKasKeluar = Convert.ToBoolean(dr["IsKasKeluar"])
                        };
                    }
                }
            }
            return result;
        }

        public IEnumerable<JenisTrsKasirModel> ListData()
        {
            List<JenisTrsKasirModel> result = null;
            var sSql = @"
                SELECT
                    aa.JenisTrsKasirID, aa.JenisTrsKasirName,
                    aa.IsKasKeluar
                FROM
                    JenisTrsKasir aa ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        result = new List<JenisTrsKasirModel>();
                        while (dr.Read())
                        {
                            var item = new JenisTrsKasirModel
                            {
                                JenisTrsKasirID = dr["JenisTrsKasirID"].ToString(),
                                JenisTrsKasirName = dr["JenisTrsKasirName"].ToString(),
                                IsKasKeluar = Convert.ToBoolean(dr["IsKasKeluar"])
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
