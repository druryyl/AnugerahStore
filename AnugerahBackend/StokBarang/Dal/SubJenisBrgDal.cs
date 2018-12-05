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

    public interface ISubJenisBrgDal
    {
        void Insert(SubJenisBrgModel subJenisBrg);

        void Update(SubJenisBrgModel subJenisBrg);

        void Delete(string id);

        SubJenisBrgModel GetData(string id);

        IEnumerable<SubJenisBrgModel> ListData();
    }


    public class SubJenisBrgDal : ISubJenisBrgDal
    {
        public string _connString;

        public SubJenisBrgDal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void Insert(SubJenisBrgModel subJenisBrg)
        {
            var sSql = @"
                INSERT INTO
                    SubJenisBrg (
                        SubJenisBrgID, SubJenisBrgName,
                        JenisBrgID)
                VALUES (
                        @SubJenisBrgID, @SubJenisBrgName,
                        @JenisBrgID) ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@SubJenisBrgID", subJenisBrg.SubJenisBrgID);
                cmd.AddParam("@SubJenisBrgName", subJenisBrg.SubJenisBrgName);
                cmd.AddParam("@JenisBrgID", subJenisBrg.JenisBrgID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(SubJenisBrgModel subJenisBrg)
        {
            var sSql = @"
                UPDATE
                    SubJenisBrg 
                SET
                    SubJenisBrgName = @SubJenisBrgName,
                    JenisBrgID = @JenisBrgID
                WHERE
                    SubJenisBrgID = @SubJenisBrgID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@SubJenisBrgID", subJenisBrg.SubJenisBrgID);
                cmd.AddParam("@SubJenisBrgName", subJenisBrg.SubJenisBrgName);
                cmd.AddParam("@JenisBrgID", subJenisBrg.JenisBrgID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string id)
        {
            var sSql = @"
                DELETE
                    SubJenisBrg 
                WHERE
                    SubJenisBrgID = @SubJenisBrgID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@SubJenisBrgID", id);
            }
        }

        public SubJenisBrgModel GetData(string id)
        {
            SubJenisBrgModel result = null;
            var sSql = @"
                SELECT
                    aa.SubJenisBrgName, aa.JenisBrgID,
                    ISNULL(bb.JenisBrgID, '') JenisBrgName
                FROM
                    SubJenisBrg aa
                    LEFT JOIN JenisBrg bb ON aa.JenisBrgID = bb.JenisBrgID
                WHERE
                    aa.SubJenisBrgID = @SubJenisBrgID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@SubJenisBrgID", id);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        dr.Read();
                        result = new SubJenisBrgModel
                        {
                            SubJenisBrgID = id,
                            SubJenisBrgName = dr["SubJenisBrgName"].ToString(),
                            JenisBrgID = dr["JenisBrgID"].ToString(),
                            JenisBrgName = dr["JenisBrgName"].ToString(),
                        };
                    }
                }
            }
            return result;
        }

        public IEnumerable<SubJenisBrgModel> ListData()
        {
            List<SubJenisBrgModel> result = null;
            var sSql = @"
                SELECT
                    aa.SubJenisBrgID, aa.SubJenisBrgName,
                    aa.JenisBrgID, 
                    ISNULL(bb.JenisBrgName, '') JenisBrgName
                FROM
                    SubJenisBrg aa 
                    LEFT JOIN JenisBrg bb ON aa.JenisBrgID = bb.JenisBrgID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        result = new List<SubJenisBrgModel>();
                        while (dr.Read())
                        {
                            var item = new SubJenisBrgModel
                            {
                                SubJenisBrgID = dr["SubJenisBrgID"].ToString(),
                                SubJenisBrgName = dr["SubJenisBrgName"].ToString(),
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
