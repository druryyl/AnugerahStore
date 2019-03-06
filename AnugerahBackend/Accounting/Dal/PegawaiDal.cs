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

    public interface IPegawaiDal
    {
        void Insert(PegawaiModel model);

        void Update(PegawaiModel model);

        void Delete(string id);

        PegawaiModel GetData(string id);

        IEnumerable<PegawaiModel> ListData();
    }

    public class PegawaiDal : IPegawaiDal
    {
        public string _connString;

        public PegawaiDal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void Insert(PegawaiModel model)
        {
            var sSql = @"
                INSERT INTO
                    Pegawai (
                        PegawaiID, PegawaiName)
                VALUES (
                        @PegawaiID, @PegawaiName) ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@PegawaiID", model.PegawaiID);
                cmd.AddParam("@PegawaiName", model.PegawaiName);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(PegawaiModel model)
        {
            var sSql = @"
                UPDATE
                    Pegawai 
                SET
                    PegawaiName = @PegawaiName
                WHERE
                    PegawaiID = @PegawaiID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@PegawaiID", model.PegawaiID);
                cmd.AddParam("@PegawaiName", model.PegawaiName);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string id)
        {
            var sSql = @"
                DELETE
                    Pegawai 
                WHERE
                    PegawaiID = @PegawaiID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@PegawaiID", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public PegawaiModel GetData(string id)
        {
            PegawaiModel result = null;
            var sSql = @"
                SELECT
                    aa.PegawaiName
                FROM
                    Pegawai aa
                WHERE
                    aa.PegawaiID = @PegawaiID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@PegawaiID", id);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        dr.Read();
                        result = new PegawaiModel
                        {
                            PegawaiID = id,
                            PegawaiName = dr["PegawaiName"].ToString()
                        };
                    }
                }
            }
            return result;
        }

        public IEnumerable<PegawaiModel> ListData()
        {
            List<PegawaiModel> result = null;
            var sSql = @"
                SELECT
                    aa.PegawaiID, aa.PegawaiName
                FROM
                    Pegawai aa ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        result = new List<PegawaiModel>();
                        while (dr.Read())
                        {
                            var item = new PegawaiModel
                            {
                                PegawaiID = dr["PegawaiID"].ToString(),
                                PegawaiName = dr["PegawaiName"].ToString()
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
