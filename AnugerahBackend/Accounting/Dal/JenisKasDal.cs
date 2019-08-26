using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnugerahBackend.Accounting.Model;
using Ics.Helper.Extensions;

namespace AnugerahBackend.Accounting.Dal
{

    public interface IJenisKasDal
    {
        void Insert(JenisKasModel jenisKas);

        void Update(JenisKasModel jenisKas);

        void Delete(string id);

        JenisKasModel GetData(string id);

        IEnumerable<JenisKasModel> ListData();
    }


    public class JenisKasDal : IJenisKasDal
    {
        public string _connString;

        public JenisKasDal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void Insert(JenisKasModel jenisKas)
        {
            var sSql = @"
                INSERT INTO
                    JenisKas (
                        JenisKasID, JenisKasName, TipeKas)
                VALUES (
                        @JenisKasID, @JenisKasName, @TipeKas) ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@JenisKasID", jenisKas.JenisKasID);
                cmd.AddParam("@JenisKasName", jenisKas.JenisKasName);
                cmd.AddParam("@TipeKas", jenisKas.TipeKas);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(JenisKasModel jenisKas)
        {
            var sSql = @"
                UPDATE
                    JenisKas 
                SET
                    JenisKasName = @JenisKasName,
                    TipeKas = @TipeKas
                WHERE
                    JenisKasID = @JenisKasID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@JenisKasID", jenisKas.JenisKasID);
                cmd.AddParam("@JenisKasName", jenisKas.JenisKasName);
                cmd.AddParam("@TipeKas", jenisKas.TipeKas);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string id)
        {
            var sSql = @"
                DELETE
                    JenisKas 
                WHERE
                    JenisKasID = @JenisKasID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@JenisKasID", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public JenisKasModel GetData(string id)
        {
            JenisKasModel result = null;
            var sSql = @"
                SELECT
                    aa.JenisKasName, aa.TipeKas
                FROM
                    JenisKas aa
                WHERE
                    aa.JenisKasID = @JenisKasID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@JenisKasID", id);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        dr.Read();
                        result = new JenisKasModel
                        {
                            JenisKasID = id,
                            JenisKasName = dr["JenisKasName"].ToString(),
                            TipeKas = dr["TipeKas"].ToString()
                        };
                    }
                }
            }
            return result;
        }

        public IEnumerable<JenisKasModel> ListData()
        {
            List<JenisKasModel> result = null;
            var sSql = @"
                SELECT
                    aa.JenisKasID, aa.JenisKasName, aa.TipeKas
                FROM
                    JenisKas aa ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        result = new List<JenisKasModel>();
                        while (dr.Read())
                        {
                            var item = new JenisKasModel
                            {
                                JenisKasID = dr["JenisKasID"].ToString(),
                                JenisKasName = dr["JenisKasName"].ToString(),
                                TipeKas = dr["TipeKas"].ToString(),
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
