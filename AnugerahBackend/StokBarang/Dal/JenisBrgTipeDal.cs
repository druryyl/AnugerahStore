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

    public interface IJenisBrgTipeDal
    {
        void Insert(JenisBrgTipeModel jenisBrgTipe);

        void Update(JenisBrgTipeModel jenisBrgTipe);

        void Delete(string id);

        JenisBrgTipeModel GetData(string id);

        IEnumerable<JenisBrgTipeModel> ListData(string jenisBrgID);
    }

    public class JenisBrgTipeDal : IJenisBrgTipeDal
    {
        public string _connString;

        public JenisBrgTipeDal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void Insert(JenisBrgTipeModel jenisBrgTipe)
        {
            var sSql = @"
                INSERT INTO
                    JenisBrgTipe (
                        JenisBrgTipeID, JenisBrgTipeName, 
                        JenisBrgID, NoUrut)
                VALUES (
                        @JenisBrgTipeID, @JenisBrgTipeName
                        @JenisBrgID, @NoUrut) ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@JenisBrgTipeID", jenisBrgTipe.JenisBrgTipeID);
                cmd.AddParam("@JenisBrgTipeName", jenisBrgTipe.JenisBrgTipeName);
                cmd.AddParam("@JenisBrgID", jenisBrgTipe.JenisBrgID);
                cmd.AddParam("@NoUrut", jenisBrgTipe.NoUrut);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(JenisBrgTipeModel jenisBrgTipe)
        {
            var sSql = @"
                UPDATE
                    JenisBrgTipe 
                SET
                    JenisBrgTipeName = @JenisBrgTipeName,
                    JenisBrgID = @JenisBrgID,
                    NoUrut = @NoUrut
                WHERE
                    JenisBrgTipeID = @JenisBrgTipeID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@JenisBrgTipeID", jenisBrgTipe.JenisBrgTipeID);
                cmd.AddParam("@JenisBrgTipeName", jenisBrgTipe.JenisBrgTipeName);
                cmd.AddParam("@JenisBrgID", jenisBrgTipe.JenisBrgID);
                cmd.AddParam("@NoUrut", jenisBrgTipe.NoUrut);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string id)
        {
            var sSql = @"
                DELETE
                    JenisBrgTipe 
                WHERE
                    JenisBrgTipeID = @JenisBrgTipeID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@JenisBrgTipeID", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public JenisBrgTipeModel GetData(string id)
        {
            JenisBrgTipeModel result = null;
            var sSql = @"
                SELECT
                    aa.JenisBrgTipeName, aa.JenisBrgTipeName,
                    aa.JenisBrgID, aa.NoUrut,
                    ISNULL(bb.JenisBrgName, '') JenisBrgName
                FROM
                    JenisBrgTipe aa
                    LEFT JOIN JenisBrg bb 
                        ON aa.JenisBrgID = bb.JenisBrgID
                WHERE
                    aa.JenisBrgTipeID = @JenisBrgTipeID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@JenisBrgTipeID", id);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        dr.Read();
                        result = new JenisBrgTipeModel
                        {
                            JenisBrgTipeID = id,
                            JenisBrgTipeName = dr["JenisBrgTipeName"].ToString(),
                            JenisBrgID = dr["JenisBrgID"].ToString(),
                            JenisBrgName = dr["JenisBrgName"].ToString(),
                            NoUrut = Convert.ToInt16(dr["NoUrut"])

                        };
                    }
                }
            }
            return result;
        }

        public IEnumerable<JenisBrgTipeModel> ListData(string jenisBrgID)
        {
            List<JenisBrgTipeModel> result = null;
            var sSql = @"
                SELECT
                    aa.JenisBrgTipeID, aa.JenisBrgTipeName,
                    aa.JenisBrgID, aa.NoUrut,
                    ISNULL(bb.JenisBrgName, '') JenisBrgName
                FROM
                    JenisBrgTipe aa 
                    LEFT JOIN JenisBrg bb 
                        ON aa.JenisBrgID = bb.JenisBrgID 
                WHERE
                    aa.JenisBrgID = @JenisBrgID 
                ORDER BY
                    aa.NoUrut ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@JenisBrgID", jenisBrgID);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        result = new List<JenisBrgTipeModel>();
                        while (dr.Read())
                        {
                            var item = new JenisBrgTipeModel
                            {
                                JenisBrgTipeName = dr["JenisBrgTipeName"].ToString(),
                                JenisBrgID = dr["JenisBrgID"].ToString(),
                                JenisBrgName = dr["JenisBrgName"].ToString(),
                                NoUrut = Convert.ToInt16(dr["NoUrut"])
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
