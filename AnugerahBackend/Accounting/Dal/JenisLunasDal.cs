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

    public interface IJenisLunasDal
    {
        void Insert(JenisLunasModel jenisLunas);

        void Update(JenisLunasModel jenisLunas);

        void Delete(string id);

        JenisLunasModel GetData(string id);

        IEnumerable<JenisLunasModel> ListData();
    }


    public class JenisLunasDal : IJenisLunasDal
    {
        public string _connString;

        public JenisLunasDal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void Insert(JenisLunasModel jenisLunas)
        {
            var sSql = @"
                INSERT INTO
                    JenisLunas (
                        JenisLunasID, JenisLunasName, JenisBiayaID )
                VALUES (
                        @JenisLunasID, @JenisLunasName, @JenisBiayaID) ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@JenisLunasID", jenisLunas.JenisLunasID);
                cmd.AddParam("@JenisLunasName", jenisLunas.JenisLunasName);
                cmd.AddParam("@JenisBiayaID", jenisLunas.JenisBiayaID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(JenisLunasModel jenisLunas)
        {
            var sSql = @"
                UPDATE
                    JenisLunas 
                SET
                    JenisLunasName = @JenisLunasName,
                    JenisBiayaID = @JenisBiayaID
                WHERE
                    JenisLunasID = @JenisLunasID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@JenisLunasID", jenisLunas.JenisLunasID);
                cmd.AddParam("@JenisLunasName", jenisLunas.JenisLunasName);
                cmd.AddParam("@JenisBiayaID", jenisLunas.JenisBiayaID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string id)
        {
            var sSql = @"
                DELETE
                    JenisLunas 
                WHERE
                    JenisLunasID = @JenisLunasID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@JenisLunasID", id);
            }
        }

        public JenisLunasModel GetData(string id)
        {
            JenisLunasModel result = null;
            var sSql = @"
                SELECT
                    aa.JenisLunasName, aa.JenisBiayaID,
                    ISNULL(bb.JenisBiayaName, '') JenisBiayaName
                FROM
                    JenisLunas aa
                    LEFT JOIN JenisBiaya bb ON aa.JenisBiayaID = bb.JenisBiayaID
                WHERE
                    aa.JenisLunasID = @JenisLunasID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@JenisLunasID", id);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        dr.Read();
                        result = new JenisLunasModel
                        {
                            JenisLunasID = id,
                            JenisLunasName = dr["JenisLunasName"].ToString(),
                            JenisBiayaID = dr["JenisBiayaID"].ToString(),
                            JenisBiayaName = dr["JenisBiayaName"].ToString()
                        };
                    }
                }
            }
            return result;
        }

        public IEnumerable<JenisLunasModel> ListData()
        {
            List<JenisLunasModel> result = null;
            var sSql = @"
                SELECT
                    aa.JenisLunasID, aa.JenisLunasName, aa.JenisBiayaID,
                    ISNULL(bb.JenisBiayaName, '') JenisBiayaName
                FROM
                    JenisLunas aa
                    LEFT JOIN JenisBiaya bb ON aa.JenisBiayaID = bb.JenisBiayaID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        result = new List<JenisLunasModel>();
                        while (dr.Read())
                        {
                            var item = new JenisLunasModel
                            {
                                JenisLunasID = dr["JenisLunasID"].ToString(),
                                JenisLunasName = dr["JenisLunasName"].ToString(),
                                JenisBiayaID = dr["JenisBiayaID"].ToString(),
                                JenisBiayaName = dr["JenisBiayaName"].ToString()
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
