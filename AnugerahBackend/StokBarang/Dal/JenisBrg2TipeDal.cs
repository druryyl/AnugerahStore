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

    public interface IJenisBrg2TipeDal
    {
        void Insert(JenisBrg2TipeModel jenisBrgTipe);

        void Delete(string jenisBrgID);

        IEnumerable<JenisBrg2TipeModel> ListData(string jenisBrgID);
    }

    public class JenisBrg2TipeDal : IJenisBrg2TipeDal
    {
        public string _connString;

        public JenisBrg2TipeDal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void Insert(JenisBrg2TipeModel jenisBrg2Tipe)
        {
            var sSql = @"
                INSERT INTO
                    JenisBrg2Tipe (
                        JenisBrgTipeID, TipeBrgID, 
                        NoUrut)
                VALUES (
                        @JenisBrgTipeID, @TipeBrgID,
                        @NoUrut) ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@JenisBrgID", jenisBrg2Tipe.JenisBrgID);
                cmd.AddParam("@TipeBrgID", jenisBrg2Tipe.TipeBrgID);
                cmd.AddParam("@NoUrut", jenisBrg2Tipe.NoUrut);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string jenisBrgID)
        {
            var sSql = @"
                DELETE
                    JenisBrg2Tipe 
                WHERE
                    JenisBrgID = @JenisBrgID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@JenisBrgID", jenisBrgID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<JenisBrg2TipeModel> ListData(string jenisBrgID)
        {
            List<JenisBrg2TipeModel> result = null;
            var sSql = @"
                SELECT
                    aa.JenisBrgID, aa.TipeBrgID, aa.NoUrut,
                    ISNULL(cc.TipeBrgName, '') TipeBrgName
                FROM
                    JenisBrg2Tipe aa 
                    LEFT JOIN TipeBrg bb ON aa.TipeBrgID = bb.TipeBrgID
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
                        result = new List<JenisBrg2TipeModel>();
                        while (dr.Read())
                        {
                            var item = new JenisBrg2TipeModel
                            {
                                JenisBrgID = dr["JenisBrgID"].ToString(),
                                TipeBrgID = dr["TipeBrgID"].ToString(),
                                TipeBrgName = dr["TipeBrgName"].ToString(),
                                NoUrut = Convert.ToInt16(dr["NoUrut"]),
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
