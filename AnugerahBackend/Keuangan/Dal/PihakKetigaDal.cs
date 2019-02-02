using AnugerahBackend.Keuangan.Model;
using Ics.Helper.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Keuangan.Dal
{

    public interface IPihakKetigaDal
    {
        void Insert(PihakKetigaModel pihakKetiga);

        void Update(PihakKetigaModel pihakKetiga);

        void Delete(string id);

        PihakKetigaModel GetData(string id);

        IEnumerable<PihakKetigaModel> ListData();
        IEnumerable<PihakKetigaModel> Search(string keyword);
    }


    public class PihakKetigaDal : IPihakKetigaDal
    {
        public string _connString;

        public PihakKetigaDal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void Insert(PihakKetigaModel pihakKetiga)
        {
            var sSql = @"
                INSERT INTO
                    PihakKetiga (
                        PihakKetigaID, PihakKetigaName)
                VALUES (
                        @PihakKetigaID, @PihakKetigaName) ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@PihakKetigaID", pihakKetiga.PihakKetigaID);
                cmd.AddParam("@PihakKetigaName", pihakKetiga.PihakKetigaName);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(PihakKetigaModel pihakKetiga)
        {
            var sSql = @"
                UPDATE
                    PihakKetiga 
                SET
                    PihakKetigaName = @PihakKetigaName
                WHERE
                    PihakKetigaID = @PihakKetigaID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@PihakKetigaID", pihakKetiga.PihakKetigaID);
                cmd.AddParam("@PihakKetigaName", pihakKetiga.PihakKetigaName);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string id)
        {
            var sSql = @"
                DELETE
                    PihakKetiga 
                WHERE
                    PihakKetigaID = @PihakKetigaID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@PihakKetigaID", id);
            }
        }

        public PihakKetigaModel GetData(string id)
        {
            PihakKetigaModel result = null;
            var sSql = @"
                SELECT
                    aa.PihakKetigaName
                FROM
                    PihakKetiga aa
                WHERE
                    aa.PihakKetigaID = @PihakKetigaID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@PihakKetigaID", id);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        dr.Read();
                        result = new PihakKetigaModel
                        {
                            PihakKetigaID = id,
                            PihakKetigaName = dr["PihakKetigaName"].ToString()
                        };
                    }
                }
            }
            return result;
        }

        public IEnumerable<PihakKetigaModel> ListData()
        {
            List<PihakKetigaModel> result = null;
            var sSql = @"
                SELECT
                    aa.PihakKetigaID, aa.PihakKetigaName
                FROM
                    PihakKetiga aa ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        result = new List<PihakKetigaModel>();
                        while (dr.Read())
                        {
                            var item = new PihakKetigaModel
                            {
                                PihakKetigaID = dr["PihakKetigaID"].ToString(),
                                PihakKetigaName = dr["PihakKetigaName"].ToString()
                            };
                            result.Add(item);
                        }
                    }
                }
            }
            return result;
        }

        public IEnumerable<PihakKetigaModel> Search(string keyword)
        {
            List<PihakKetigaModel> result = null;
            var sSql = @"
                SELECT
                    aa.PihakKetigaID, aa.PihakKetigaName
                FROM
                    PihakKetiga aa 
                WHERE
                    PihakKetigaName LIKE @PihakKetigaName ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@PihakKetigaName", string.Format("%{0}%", keyword));
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        result = new List<PihakKetigaModel>();
                        while (dr.Read())
                        {
                            var item = new PihakKetigaModel
                            {
                                PihakKetigaID = dr["PihakKetigaID"].ToString(),
                                PihakKetigaName = dr["PihakKetigaName"].ToString()
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
