using AnugerahBackend.StokBarang.Model;
using Ics.Helper.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.StokBarang.Dal
{

    public interface IJenisMutasiDal
    {
        void Insert(JenisMutasiModel jenisMutasi);

        void Update(JenisMutasiModel jenisMutasi);

        void Delete(string id);

        JenisMutasiModel GetData(string id);

        IEnumerable<JenisMutasiModel> ListData();
    }

    public class JenisMutasiDal : IJenisMutasiDal
    {
        public string _connString;

        public JenisMutasiDal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void Insert(JenisMutasiModel jenisMutasi)
        {
            var sSql = @"
                INSERT INTO
                    JenisMutasi (
                        JenisMutasiID, JenisMutasiNAme)
                VALUES (
                        @JenisMutasiID, @JenisMutasiNAme) ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@JenisMutasiID", jenisMutasi.JenisMutasiID);
                cmd.AddParam("@JenisMutasiNAme", jenisMutasi.JenisMutasiName);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(JenisMutasiModel jenisMutasi)
        {
            var sSql = @"
                UPDATE
                    JenisMutasi 
                SET
                    JenisMutasiNAme = @JenisMutasiNAme
                WHERE
                    JenisMutasiID = @JenisMutasiID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@JenisMutasiID", jenisMutasi.JenisMutasiID);
                cmd.AddParam("@JenisMutasiNAme", jenisMutasi.JenisMutasiName);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string id)
        {
            var sSql = @"
                DELETE
                    JenisMutasi 
                WHERE
                    JenisMutasiID = @JenisMutasiID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@JenisMutasiID", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public JenisMutasiModel GetData(string id)
        {
            JenisMutasiModel result = null;
            var sSql = @"
                SELECT
                    aa.JenisMutasiNAme
                FROM
                    JenisMutasi aa
                WHERE
                    aa.JenisMutasiID = @JenisMutasiID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@JenisMutasiID", id);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        dr.Read();
                        result = new JenisMutasiModel
                        {
                            JenisMutasiID = id,
                            JenisMutasiName = dr["JenisMutasiNAme"].ToString()
                        };
                    }
                }
            }
            return result;
        }

        public IEnumerable<JenisMutasiModel> ListData()
        {
            List<JenisMutasiModel> result = null;
            var sSql = @"
                SELECT
                    aa.JenisMutasiID, aa.JenisMutasiNAme
                FROM
                    JenisMutasi aa ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        result = new List<JenisMutasiModel>();
                        while (dr.Read())
                        {
                            var item = new JenisMutasiModel
                            {
                                JenisMutasiID = dr["JenisMutasiID"].ToString(),
                                JenisMutasiName = dr["JenisMutasiNAme"].ToString()
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
