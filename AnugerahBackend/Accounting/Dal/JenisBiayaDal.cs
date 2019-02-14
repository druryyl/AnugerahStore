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

    public interface IJenisBiayaDal
    {
        void Insert(JenisBiayaModel model);

        void Update(JenisBiayaModel model);

        void Delete(string id);

        JenisBiayaModel GetData(string id);

        IEnumerable<JenisBiayaModel> ListData();
    }

    public class JenisBiayaDal : IJenisBiayaDal
    {
        public string _connString;

        public JenisBiayaDal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void Insert(JenisBiayaModel model)
        {
            var sSql = @"
                INSERT INTO
                    JenisBiaya (
                        JenisBiayaID, JenisBiayaName)
                VALUES (
                        @JenisBiayaID, @JenisBiayaName) ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@JenisBiayaID", model.JenisBiayaID);
                cmd.AddParam("@JenisBiayaName", model.JenisBiayaName);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(JenisBiayaModel model)
        {
            var sSql = @"
                UPDATE
                    JenisBiaya 
                SET
                    JenisBiayaName = @JenisBiayaName
                WHERE
                    JenisBiayaID = @JenisBiayaID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@JenisBiayaID", model.JenisBiayaID);
                cmd.AddParam("@JenisBiayaName", model.JenisBiayaName);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string id)
        {
            var sSql = @"
                DELETE
                    JenisBiaya 
                WHERE
                    JenisBiayaID = @JenisBiayaID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@JenisBiayaID", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public JenisBiayaModel GetData(string id)
        {
            JenisBiayaModel result = null;
            var sSql = @"
                SELECT
                    aa.JenisBiayaName
                FROM
                    JenisBiaya aa
                WHERE
                    aa.JenisBiayaID = @JenisBiayaID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@JenisBiayaID", id);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        dr.Read();
                        result = new JenisBiayaModel
                        {
                            JenisBiayaID = id,
                            JenisBiayaName = dr["JenisBiayaName"].ToString()
                        };
                    }
                }
            }
            return result;
        }

        public IEnumerable<JenisBiayaModel> ListData()
        {
            List<JenisBiayaModel> result = null;
            var sSql = @"
                SELECT
                    aa.JenisBiayaID, aa.JenisBiayaName
                FROM
                    JenisBiaya aa ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        result = new List<JenisBiayaModel>();
                        while (dr.Read())
                        {
                            var item = new JenisBiayaModel
                            {
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
