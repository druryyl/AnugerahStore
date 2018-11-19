using Ics.Helper.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.StokBarang
{

    public interface IJenisBrgDal
    {
        void Insert(JenisBrgModel jenisBrg);

        void Update(JenisBrgModel jenisBrg);

        void Delete(string id);

        JenisBrgModel GetData(string id);

        IEnumerable<JenisBrgModel> ListData();
    }

    public class JenisBrgDal : IJenisBrgDal
    {
        public string _connString;

        public JenisBrgDal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void Insert(JenisBrgModel jenisBrg)
        {
            var sSql = @"
                INSERT INTO
                    JenisBrg (
                        JenisBrgID, JenisBrgName)
                VALUES (
                        @JenisBrgID, @JenisBrgName) ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@JenisBrgID", jenisBrg.JenisBrgID);
                cmd.AddParam("@JenisBrgName", jenisBrg.JenisBrgName);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(JenisBrgModel jenisBrg)
        {
            var sSql = @"
                UPDATE
                    JenisBrg 
                SET
                    JenisBrgName = @JenisBrgName
                WHERE
                    JenisBrgID = @JenisBrgID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@JenisBrgID", jenisBrg.JenisBrgID);
                cmd.AddParam("@JenisBrgName", jenisBrg.JenisBrgName);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string id)
        {
            var sSql = @"
                DELETE
                    JenisBrg 
                WHERE
                    JenisBrgID = @JenisBrgID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@JenisBrgID", id);
            }
        }

        public JenisBrgModel GetData(string id)
        {
            JenisBrgModel result = null;
            var sSql = @"
                SELECT
                    aa.JenisBrgName
                FROM
                    JenisBrg aa
                WHERE
                    aa.JenisBrgID = @JenisBrgID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@JenisBrgID", id);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        dr.Read();
                        result = new JenisBrgModel
                        {
                            JenisBrgID = id,
                            JenisBrgName = dr["JenisBrgName"].ToString()
                        };
                    }
                }
            }
            return result;
        }

        public IEnumerable<JenisBrgModel> ListData()
        {
            List<JenisBrgModel> result = null;
            var sSql = @"
                SELECT
                    aa.JenisBrgID, aa.JenisBrgName
                FROM
                    JenisBrg aa ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        result = new List<JenisBrgModel>();
                        while (dr.Read())
                        {
                            var item = new JenisBrgModel
                            {
                                JenisBrgID = dr["JenisBrgID"].ToString(),
                                JenisBrgName = dr["JenisBrgName"].ToString()
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
