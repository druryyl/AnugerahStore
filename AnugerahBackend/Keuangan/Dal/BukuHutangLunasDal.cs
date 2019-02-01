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
    public interface IBukuHutangLunasDal
    {
        void Insert(BukuHutangLunasModel bukuHutangLunas);
        void Update(BukuHutangLunasModel bukuHutangLunas);
        void Delete(string bukuHutangLunasID);
        BukuHutangLunasModel GetData(string bukuHutangLunasID);
        IEnumerable<BukuHutangLunasModel> ListData(string bukuHutangID);
        IEnumerable<BukuHutangLunasModel> ListData(BukuKasModel bukuKas);
    }
    public class BukuHutangLunasDal : IBukuHutangLunasDal
    {
        private string _connString;

        public BukuHutangLunasDal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void Insert(BukuHutangLunasModel bukuHutangLunas)
        {
            var sSql = @"
                INSERT INTO
                    BukuHutangLunas (
                        BukuHutangLunasID, BukuHutangID, TglLunas,
                        JamLunas, NilaiLunas, BukuKasID )
                VALUES (
                        @BukuHutangLunasID, @BukuHutangID, @TglLunas,
                        @JamLunas, @NilaiLunas, @BukuKasID ) ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BukuHutangLunasID", bukuHutangLunas.BukuHutangLunasID);
                cmd.AddParam("@BukuHutangID", bukuHutangLunas.BukuHutangID);
                cmd.AddParam("@TglLunas", bukuHutangLunas.TglLunas.ToTglYMD());
                cmd.AddParam("@JamLunas", bukuHutangLunas.JamLunas);
                cmd.AddParam("@NilaiLunas", bukuHutangLunas.NilaiLunas);
                cmd.AddParam("@BukuKasID", bukuHutangLunas.BukuKasID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(BukuHutangLunasModel bukuHutangLunas)
        {
            var sSql = @"
                UPDATE
                    BukuHutangLunas 
                SET 
                    BukuHutangID = @BukuHutangID, 
                    TglLunas = @TglLunas,
                    JamLunas = @JamLunas, 
                    NilaiLunas = @NilaiLunas, 
                    BukuKasID = @BukuKasID 
                WHERE
                    BukuHutangLunasID = @BukuHutangLunasID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BukuHutangLunasID", bukuHutangLunas.BukuHutangLunasID);
                cmd.AddParam("@BukuHutangID", bukuHutangLunas.BukuHutangID);
                cmd.AddParam("@TglLunas", bukuHutangLunas.TglLunas.ToTglYMD());
                cmd.AddParam("@JamLunas", bukuHutangLunas.JamLunas);
                cmd.AddParam("@NilaiLunas", bukuHutangLunas.NilaiLunas);
                cmd.AddParam("@BukuKasID", bukuHutangLunas.BukuKasID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string bukuHutangLunasID)
        {
            var sSql = @"
                DELETE
                    BukuHutangLunas 
                WHERE
                    BukuHutangLunasID = @BukuHutangLunasID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BukuHutangLunasID", bukuHutangLunasID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public BukuHutangLunasModel GetData(string bukuHutangLunasID)
        {
            BukuHutangLunasModel result = null;
            var sSql = @"
                SELECT
                    BukuHutangLunasID, BukuHutangID, TglLunas,
                    JamLunas, NilaiLunas, BukuKasID                 
                FROM
                    BukuHutangLunas
                WHERE
                    BukuHutangLunasID = @BukuHutangLunasID ";

            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BukuHutangLunasID", bukuHutangLunasID);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (!dr.HasRows) return result;
                    dr.Read();
                    result = new BukuHutangLunasModel
                    {
                        BukuHutangLunasID = bukuHutangLunasID,
                        BukuHutangID = dr["BukuHutangID"].ToString(),
                        TglLunas = dr["TglLunas"].ToString().ToTglDMY(),
                        JamLunas = dr["JamLunas"].ToString(),
                        NilaiLunas = Convert.ToDecimal(dr["NilaiLunas"]),
                        BukuKasID = dr["BukuKasID"].ToString(),
                    };
                }
            }
            return result;
        }

        public IEnumerable<BukuHutangLunasModel> ListData(string bukuHutangID)
        {
            List<BukuHutangLunasModel> result = null;
            var sSql = @"
                SELECT
                    BukuHutangLunasID, BukuHutangID, TglLunas,
                    JamLunas, NilaiLunas, BukuKasID                 
                FROM
                    BukuHutangLunas
                WHERE
                    BukuHutangID = @BukuHutangID ";

            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BukuHutangID", bukuHutangID);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (!dr.HasRows) return result;
                    result = new List<BukuHutangLunasModel>();

                    while (dr.Read())
                    {
                        var item = new BukuHutangLunasModel
                        {
                            BukuHutangLunasID = dr["BukuHutangLunasID"].ToString(),
                            BukuHutangID = dr["BukuHutangID"].ToString(),
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

        public IEnumerable<BukuHutangLunasModel> ListData(BukuKasModel bukuKas)
        {
            List<BukuHutangLunasModel> result = null;
            var sSql = @"
                SELECT
                    BukuHutangLunasID, BukuHutangID, TglLunas,
                    JamLunas, NilaiLunas, BukuKasID                 
                FROM
                    BukuHutangLunas
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
                    result = new List<BukuHutangLunasModel>();

                    while (dr.Read())
                    {
                        var item = new BukuHutangLunasModel
                        {
                            BukuHutangLunasID = dr["BukuHutangLunasID"].ToString(),
                            BukuHutangID = dr["BukuHutangID"].ToString(),
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
