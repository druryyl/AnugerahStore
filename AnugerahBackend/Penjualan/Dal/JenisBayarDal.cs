using AnugerahBackend.Penjualan.Model;
using AnugerahBackend.Support;
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

    public interface IJenisBayarDal
    {
        void Insert(JenisBayarModel jenisBayar);

        void Update(JenisBayarModel jenisBayar);

        void Delete(string id);

        JenisBayarModel GetData(string id);

        IEnumerable<JenisBayarModel> ListData();
    }


    public class JenisBayarDal : IJenisBayarDal
    {
        public string _connString;

        public JenisBayarDal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void Insert(JenisBayarModel jenisBayar)
        {
            var sSql = @"
                INSERT INTO
                    JenisBayar (
                        JenisBayarID, JenisBayarName, IsMesinEdc,
                        JenisKasID)
                VALUES (
                        @JenisBayarID, @JenisBayarName, @IsMesinEdc,
                        @JenisKasID) ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@JenisBayarID", jenisBayar.JenisBayarID);
                cmd.AddParam("@JenisBayarName", jenisBayar.JenisBayarName);
                cmd.AddParam("@IsMesinEdc", jenisBayar.KasTransferEdc);
                cmd.AddParam("@JenisKasID", jenisBayar.JenisKasID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(JenisBayarModel jenisBayar)
        {
            var sSql = @"
                UPDATE
                    JenisBayar 
                SET
                    JenisBayarName = @JenisBayarName,
                    IsMesinEdc = @IsMesinEdc,
                    JenisKasID = @JenisKasID
                WHERE
                    JenisBayarID = @JenisBayarID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@JenisBayarID", jenisBayar.JenisBayarID);
                cmd.AddParam("@JenisBayarName", jenisBayar.JenisBayarName);
                cmd.AddParam("@IsMesinEdc", jenisBayar.KasTransferEdc);
                cmd.AddParam("@JenisKasID", jenisBayar.JenisKasID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string id)
        {
            var sSql = @"
                DELETE
                    JenisBayar 
                WHERE
                    JenisBayarID = @JenisBayarID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@JenisBayarID", id);
            }
        }

        public JenisBayarModel GetData(string id)
        {
            JenisBayarModel result = null;
            var sSql = @"
                SELECT
                    aa.JenisBayarName,
                    aa.KasTransferEdc,
                    aa.JenisKasID, 
                    ISNULL(bb.JenisKasName, '') JenisKasName    
                FROM
                    JenisBayar aa
                    LEFT JOIN JenisKas bb ON aa.JenisKasID = bb.JenisKasID
                WHERE
                    aa.JenisBayarID = @JenisBayarID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@JenisBayarID", id);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        dr.Read();
                        result = new JenisBayarModel
                        {
                            JenisBayarID = id,
                            JenisBayarName = dr["JenisBayarName"].ToString(),
                            KasTransferEdc = dr["KasTransferEdc"].ToString(),
                            JenisKasID = dr["JenisKasID"].ToString(),
                            JenisKasName = dr["JenisKasName"].ToString()
                        };
                    }
                }
            }
            return result;
        }

        public IEnumerable<JenisBayarModel> ListData()
        {
            List<JenisBayarModel> result = null;
            var sSql = @"
                SELECT
                    aa.JenisBayarID, aa.JenisBayarName, aa.KasTransferEdc,
                    aa.JenisKasID, 
                    ISNULL(bb.JenisKasName, '') JenisKasName
                FROM
                    JenisBayar aa 
                    LEFT JOIN JenisKas bb ON aa.JenisKasID = bb.JenisKasID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        result = new List<JenisBayarModel>();
                        while (dr.Read())
                        {
                            var item = new JenisBayarModel
                            {
                                JenisBayarID = dr["JenisBayarID"].ToString(),
                                JenisBayarName = dr["JenisBayarName"].ToString(),
                                KasTransferEdc = dr["KasTransferEdc"].ToString(),
                                JenisKasID = dr["JenisKasID"].ToString(),
                                JenisKasName = dr["JenisKasName"].ToString()
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
