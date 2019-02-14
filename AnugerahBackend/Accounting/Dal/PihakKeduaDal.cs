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

    public interface IPihakKeduaDal
    {
        void Insert(PihakKeduaModel model);

        void Update(PihakKeduaModel model);

        void Delete(string id);

        PihakKeduaModel GetData(string id);

        IEnumerable<PihakKeduaModel> ListData();
    }

    public class PihakKeduaDal : IPihakKeduaDal
    {
        public string _connString;

        public PihakKeduaDal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void Insert(PihakKeduaModel model)
        {
            var sSql = @"
                INSERT INTO
                    PihakKedua (
                        PihakKeduaID, PihakKeduaName)
                VALUES (
                        @PihakKeduaID, @PihakKeduaName) ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@PihakKeduaID", model.PihakKeduaID);
                cmd.AddParam("@PihakKeduaName", model.PihakKeduaName);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(PihakKeduaModel model)
        {
            var sSql = @"
                UPDATE
                    PihakKedua 
                SET
                    PihakKeduaName = @PihakKeduaName
                WHERE
                    PihakKeduaID = @PihakKeduaID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@PihakKeduaID", model.PihakKeduaID);
                cmd.AddParam("@PihakKeduaName", model.PihakKeduaName);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string id)
        {
            var sSql = @"
                DELETE
                    PihakKedua 
                WHERE
                    PihakKeduaID = @PihakKeduaID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@PihakKeduaID", id);
            }
        }

        public PihakKeduaModel GetData(string id)
        {
            PihakKeduaModel result = null;
            var sSql = @"
                SELECT
                    aa.PihakKeduaName
                FROM
                    PihakKedua aa
                WHERE
                    aa.PihakKeduaID = @PihakKeduaID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@PihakKeduaID", id);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        dr.Read();
                        result = new PihakKeduaModel
                        {
                            PihakKeduaID = id,
                            PihakKeduaName = dr["PihakKeduaName"].ToString()
                        };
                    }
                }
            }
            return result;
        }

        public IEnumerable<PihakKeduaModel> ListData()
        {
            List<PihakKeduaModel> result = null;
            var sSql = @"
                SELECT
                    aa.PihakKeduaID, aa.PihakKeduaName
                FROM
                    PihakKedua aa ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        result = new List<PihakKeduaModel>();
                        while (dr.Read())
                        {
                            var item = new PihakKeduaModel
                            {
                                PihakKeduaID = dr["PihakKeduaID"].ToString(),
                                PihakKeduaName = dr["PihakKeduaName"].ToString()
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
