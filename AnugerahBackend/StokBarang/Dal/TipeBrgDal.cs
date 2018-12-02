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

    public interface ITipeBrgDal
    {
        void Insert(TipeBrgModel tipeBrg);

        void Update(TipeBrgModel tipeBrg);

        void Delete(string id);

        TipeBrgModel GetData(string id);

        IEnumerable<TipeBrgModel> ListData();
        IEnumerable<TipeBrgModel> ListData(string jenisBrgID);
    }


    public class TipeBrgDal : ITipeBrgDal
    {
        public string _connString;

        public TipeBrgDal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void Insert(TipeBrgModel tipeBrg)
        {
            var sSql = @"
                INSERT INTO
                    TipeBrg (
                        TipeBrgID, TipeBrgName, JenisBrgID)
                VALUES (
                        @TipeBrgID, @TipeBrgName, @JenisBrgID) ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@TipeBrgID", tipeBrg.TipeBrgID);
                cmd.AddParam("@TipeBrgName", tipeBrg.TipeBrgName);
                cmd.AddParam("@JenisBrgID", tipeBrg.JenisBrgID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(TipeBrgModel tipeBrg)
        {
            var sSql = @"
                UPDATE
                    TipeBrg 
                SET
                    TipeBrgName = @TipeBrgName,
                    JenisBrgID = @JenisBrgID
                WHERE
                    TipeBrgID = @TipeBrgID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@TipeBrgID", tipeBrg.TipeBrgID);
                cmd.AddParam("@TipeBrgName", tipeBrg.TipeBrgName);
                cmd.AddParam("@JenisBrgID", tipeBrg.JenisBrgID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string id)
        {
            var sSql = @"
                DELETE
                    TipeBrg 
                WHERE
                    TipeBrgID = @TipeBrgID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@TipeBrgID", id);
            }
        }

        public TipeBrgModel GetData(string id)
        {
            TipeBrgModel result = null;
            var sSql = @"
                SELECT
                    aa.TipeBrgName, aa.JenisBrgID,
                    ISNULL(bb.JenisBrgName, '')
                FROM
                    TipeBrg aa
                    LEFT JOIN JenisBrg bb ON aa.JenisBrgID = bb.JenisBrgID
                WHERE
                    aa.TipeBrgID = @TipeBrgID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@TipeBrgID", id);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        dr.Read();
                        result = new TipeBrgModel
                        {
                            TipeBrgID = id,
                            TipeBrgName = dr["TipeBrgName"].ToString(),
                            JenisBrgID = dr["JenisBrgID"].ToString(),
                            JenisBrgName = dr["JenisBrgName"].ToString()
                        };
                    }
                }
            }
            return result;
        }

        public IEnumerable<TipeBrgModel> ListData()
        {
            List<TipeBrgModel> result = null;
            var sSql = @"
                SELECT
                    aa.TipeBrgID, aa.TipeBrgName,
                    aa.JenisBrgID,
                    ISNULL(bb.JenisBrgName, '') JenisBrgName
                FROM
                    TipeBrg aa ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        result = new List<TipeBrgModel>();
                        while (dr.Read())
                        {
                            var item = new TipeBrgModel
                            {
                                TipeBrgID = dr["TipeBrgID"].ToString(),
                                TipeBrgName = dr["TipeBrgName"].ToString(),
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

        public IEnumerable<TipeBrgModel> ListData(string jenisBrgID)
        {
            List<TipeBrgModel> result = null;
            var sSql = @"
                SELECT
                    aa.TipeBrgID, aa.TipeBrgName,
                    aa.JenisBrgID,
                    ISNULL(bb.JenisBrgName, '') JenisBrgName
                FROM
                    TipeBrg aa 
                WHERE
                    aa.JenisBrgID = @JenisBrgID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@JenisBrgID", jenisBrgID);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        result = new List<TipeBrgModel>();
                        while (dr.Read())
                        {
                            var item = new TipeBrgModel
                            {
                                TipeBrgID = dr["TipeBrgID"].ToString(),
                                TipeBrgName = dr["TipeBrgName"].ToString(),
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
