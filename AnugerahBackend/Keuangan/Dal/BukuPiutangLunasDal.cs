using AnugerahBackend.Keuangan.Model;
using Ics.Helper.Extensions;
using Ics.Helper.StringDateTime;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Keuangan.Dal
{
    public interface IBukuPiutangLunasDal
    {
        void Insert(BukuPiutangLunasModel bukuPiutangLunas);
        void Update(BukuPiutangLunasModel bukuPiutangLunas);
        void Delete(string bukuPiutangLunasID);
        BukuPiutangLunasModel GetData(string bukuPiutangLunasID);
        IEnumerable<BukuPiutangLunasModel> ListData(string bukuPiutangID);
        IEnumerable<BukuPiutangLunasModel> ListData(BukuKasModel bukuKas);
    }
    public class BukuPiutangLunasDal : IBukuPiutangLunasDal
    {
        private string _connString;

        public BukuPiutangLunasDal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void Insert(BukuPiutangLunasModel bukuPiutangLunas)
        {
            var sSql = @"
                INSERT INTO
                    BukuPiutangLunas (
                        BukuPiutangLunasID, BukuPiutangID, TglLunas,
                        JamLunas, NilaiLunas, BukuKasID )
                VALUES (
                        @BukuPiutangLunasID, @BukuPiutangID, @TglLunas,
                        @JamLunas, @NilaiLunas, @BukuKasID ) ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BukuPiutangLunasID", bukuPiutangLunas.BukuPiutangLunasID);
                cmd.AddParam("@BukuPiutangID", bukuPiutangLunas.BukuPiutangID);
                cmd.AddParam("@TglLunas", bukuPiutangLunas.TglLunas.ToTglYMD());
                cmd.AddParam("@JamLunas", bukuPiutangLunas.JamLunas);
                cmd.AddParam("@NilaiLunas", bukuPiutangLunas.NilaiLunas);
                cmd.AddParam("@BukuKasID", bukuPiutangLunas.BukuKasID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(BukuPiutangLunasModel bukuPiutangLunas)
        {
            var sSql = @"
                UPDATE
                    BukuPiutangLunas 
                SET 
                    BukuPiutangID = @BukuPiutangID, 
                    TglLunas = @TglLunas,
                    JamLunas = @JamLunas, 
                    NilaiLunas = @NilaiLunas, 
                    BukuKasID = @BukuKasID 
                WHERE
                    BukuPiutangLunasID = @BukuPiutangLunasID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BukuPiutangLunasID", bukuPiutangLunas.BukuPiutangLunasID);
                cmd.AddParam("@BukuPiutangID", bukuPiutangLunas.BukuPiutangID);
                cmd.AddParam("@TglLunas", bukuPiutangLunas.TglLunas.ToTglYMD());
                cmd.AddParam("@JamLunas", bukuPiutangLunas.JamLunas);
                cmd.AddParam("@NilaiLunas", bukuPiutangLunas.NilaiLunas);
                cmd.AddParam("@BukuKasID", bukuPiutangLunas.BukuKasID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string bukuPiutangID)
        {
            var sSql = @"
                DELETE
                    BukuPiutangLunas 
                WHERE
                    BukuPiutangID = @BukuPiutangID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BukuPiutangID", bukuPiutangID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public BukuPiutangLunasModel GetData(string bukuPiutangLunasID)
        {
            BukuPiutangLunasModel result = null;
            var sSql = @"
                SELECT
                    BukuPiutangLunasID, BukuPiutangID, TglLunas,
                    JamLunas, NilaiLunas, BukuKasID                 
                FROM
                    BukuPiutangLunas
                WHERE
                    BukuPiutangLunasID = @BukuPiutangLunasID ";

            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BukuPiutangLunasID", bukuPiutangLunasID);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (!dr.HasRows) return result;
                    dr.Read();
                    result = new BukuPiutangLunasModel
                    {
                        BukuPiutangLunasID = bukuPiutangLunasID,
                        BukuPiutangID = dr["BukuPiutangID"].ToString(),
                        TglLunas = dr["TglLunas"].ToString().ToTglDMY(),
                        JamLunas = dr["JamLunas"].ToString(),
                        NilaiLunas = Convert.ToDecimal(dr["NilaiLunas"]),
                        BukuKasID = dr["BukuKasID"].ToString(),
                    };
                }
            }
            return result;
        }

        public IEnumerable<BukuPiutangLunasModel> ListData(string bukuPiutangID)
        {
            List<BukuPiutangLunasModel> result = null;
            var sSql = @"
                SELECT
                    BukuPiutangLunasID, BukuPiutangID, TglLunas,
                    JamLunas, NilaiLunas, BukuKasID                 
                FROM
                    BukuPiutangLunas
                WHERE
                    BukuPiutangID = @BukuPiutangID ";

            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BukuPiutangID", bukuPiutangID);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (!dr.HasRows) return result;
                    result = new List<BukuPiutangLunasModel>();

                    while (dr.Read())
                    {
                        var item = new BukuPiutangLunasModel
                        {
                            BukuPiutangLunasID = dr["BukuPiutangLunasID"].ToString(),
                            BukuPiutangID = dr["BukuPiutangID"].ToString(),
                            TglLunas = dr["TglLunas"].ToString().ToTglDMY(),
                            JamLunas = dr["JamLunas"].ToString(),
                            NilaiLunas = Convert.ToDecimal(dr["NilaiLunas"]),
                            BukuKasID = dr["BukuKasID"].ToString(),
                        };
                        result.Add(item);
                    }
                }
            }
            return result;
        }

        public IEnumerable<BukuPiutangLunasModel> ListData(BukuKasModel bukuKas)
        {
            List<BukuPiutangLunasModel> result = null;
            var sSql = @"
                SELECT
                    BukuPiutangLunasID, BukuPiutangID, TglLunas,
                    JamLunas, NilaiLunas, BukuKasID                 
                FROM
                    BukuPiutangLunas
                WHERE
                    BukuKasID = @BukuKasID ";

            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BukuKasID", bukuKas.BukuKasID);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (!dr.HasRows) return result;
                    result = new List<BukuPiutangLunasModel>();

                    while (dr.Read())
                    {
                        var item = new BukuPiutangLunasModel
                        {
                            BukuPiutangLunasID = dr["BukuPiutangLunasID"].ToString(),
                            BukuPiutangID = dr["BukuPiutangID"].ToString(),
                            TglLunas = dr["TglLunas"].ToString().ToTglDMY(),
                            JamLunas = dr["JamLunas"].ToString(),
                            NilaiLunas = Convert.ToDecimal(dr["NilaiLunas"]),
                            BukuKasID = dr["BukuKasID"].ToString(),
                        };
                        result.Add(item);
                    }
                }
            }
            return result;
        }
    }
}
