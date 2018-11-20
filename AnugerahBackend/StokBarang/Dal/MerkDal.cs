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

    public interface IMerkDal
    {
        void Insert(MerkModel merk);

        void Update(MerkModel merk);

        void Delete(string id);

        MerkModel GetData(string id);

        IEnumerable<MerkModel> ListData();
    }

    public class MerkDal : IMerkDal
    {
        public string _connString;

        public MerkDal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void Insert(MerkModel merk)
        {
            var sSql = @"
                INSERT INTO
                    Merk (
                        MerkID, MerkName)
                VALUES (
                        @MerkID, @MerkName) ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@MerkID", merk.MerkID);
                cmd.AddParam("@MerkName", merk.MerkName);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(MerkModel merk)
        {
            var sSql = @"
                UPDATE
                    Merk 
                SET
                    MerkName = @MerkName
                WHERE
                    MerkID = @MerkID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@MerkID", merk.MerkID);
                cmd.AddParam("@MerkName", merk.MerkName);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string id)
        {
            var sSql = @"
                DELETE
                    Merk 
                WHERE
                    MerkID = @MerkID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@MerkID", id);
            }
        }

        public MerkModel GetData(string id)
        {
            MerkModel result = null;
            var sSql = @"
                SELECT
                    aa.MerkName
                FROM
                    Merk aa
                WHERE
                    aa.MerkID = @MerkID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@MerkID", id);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        dr.Read();
                        result = new MerkModel
                        {
                            MerkID = id,
                            MerkName = dr["MerkName"].ToString()
                        };
                    }
                }
            }
            return result;
        }

        public IEnumerable<MerkModel> ListData()
        {
            List<MerkModel> result = null;
            var sSql = @"
                SELECT
                    aa.MerkID, aa.MerkName
                FROM
                    Merk aa ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        result = new List<MerkModel>();
                        while (dr.Read())
                        {
                            var item = new MerkModel
                            {
                                MerkID = dr["MerkID"].ToString(),
                                MerkName = dr["MerkName"].ToString()
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
