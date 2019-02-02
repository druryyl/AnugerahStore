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
    public interface IBukuKasDal
    {
        void Insert(BukuKasModel bukuKas);
        void Update(BukuKasModel bukuKas);
        void Delete(string bukuKasID);
        BukuKasModel GetData(string bukuKasID);
        IEnumerable<BukuKasModel> ListData(string tgl1, string tgl2);

    }
    public class BukuKasDal : IBukuKasDal
    {
        private string _connString;

        public BukuKasDal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void Insert(BukuKasModel bukuKas)
        {
            var sSql = @"
                INSERT INTO
                    BukuKas (
                        BukuKasID, TglBuku, JamBuku, UserrID,
                        NilaiKas, JenisTrsKasirID,
                        ReffID, Keterangan, PihakKetigaID)
                VALUES (
                        @BukuKasID, @TglBuku, @JamBuku, @UserrID,
                        @NilaiKas, @JenisTrsKasirID,
                        @ReffID, @Keterangan, @PihakKetigaID) ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BukuKasID", bukuKas.BukuKasID);
                cmd.AddParam("@TglBuku", bukuKas.TglBuku.ToTglYMD());
                cmd.AddParam("@JamBuku", bukuKas.JamBuku);
                cmd.AddParam("@UserrID", bukuKas.UserrID);

                cmd.AddParam("@NilaiKas", bukuKas.NilaiKas);
                cmd.AddParam("@JenisTrsKasirID", bukuKas.JenisTrsKasirID);

                cmd.AddParam("@ReffID", bukuKas.ReffID);
                cmd.AddParam("@Keterangan", bukuKas.Keterangan);
                cmd.AddParam("@PihakKetigaID", bukuKas.PihakKetigaID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(BukuKasModel bukuKas)
        {
            var sSql = @"
                UPDATE
                    BukuKas 
                SET 
                    TglBuku = @TglBuku, 
                    JamBuku = @JamBuku, 
                    UserrID = @UserrID,
                    NilaiKas = @NilaiKas, 
                    JenisTrsKasirID = @JenisTrsKasirID,
                    ReffID = @ReffID, 
                    Keterangan = @Keterangan,
                    PihakKetigaID = @PihakKetigaID
                WHERE
                    BukuKasID = @BukuKasID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BukuKasID", bukuKas.BukuKasID);
                cmd.AddParam("@TglBuku", bukuKas.TglBuku.ToTglYMD());
                cmd.AddParam("@JamBuku", bukuKas.JamBuku);
                cmd.AddParam("@UserrID", bukuKas.UserrID);
                cmd.AddParam("@NilaiKas", bukuKas.NilaiKas);
                cmd.AddParam("@JenisTrsKasirID", bukuKas.JenisTrsKasirID);
                cmd.AddParam("@ReffID", bukuKas.ReffID);
                cmd.AddParam("@Keterangan", bukuKas.Keterangan);
                cmd.AddParam("@PihakKetigaID", bukuKas.PihakKetigaID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string bukuKasID)
        {
            var sSql = @"
                DELETE
                    BukuKas
                WHERE
                    BukuKasID = @BukuKasID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BukuKasID", bukuKasID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public BukuKasModel GetData(string bukuKasID)
        {
            BukuKasModel result = null;
            var sSql = @"
                SELECT
                    aa.BukuKasID, aa.TglBuku, aa.JamBuku,
                    aa.UserrID, aa.NilaiKas, 
                    aa.JenisTrsKasirID,
                    aa.ReffID, aa.Keterangan, aa.PihakKetigaID,
                    ISNULL(bb.PihakKetigaName,'')PihakKetigaName,
                    ISNULL(cc.JenisTrsKasirName, '') JenisTrsKasirName

                FROM    
                    BukuKas aa
                    LEFT JOIN PihakKetiga bb ON aa.PihakKetigaID = bb.PihakKetigaID
                    LEFT JOIN JenisTrsKasir cc ON aa.JenisTrsKasirID = cc.JenisTrsKasirID
                WHERE
                    aa.BukuKasID = @BukuKasID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BukuKasID", bukuKasID);
                conn.Open();

                using (var dr = cmd.ExecuteReader())
                {
                    if (!dr.HasRows) return null;
                    dr.Read();
                    result = new BukuKasModel
                    {
                        BukuKasID = bukuKasID,
                        TglBuku = dr["TglBuku"].ToString().ToTglDMY(),
                        JamBuku = dr["JamBuku"].ToString(),
                        UserrID = dr["USerrID"].ToString(),

                        NilaiKas = Convert.ToDecimal(dr["NilaiKas"]),
                        JenisTrsKasirID = dr["JenisTrsKasirID"].ToString(),
                        JenisTrsKasirName = dr["JenisTrsKasirName"].ToString(),
                        ReffID = dr["ReffID"].ToString(),

                        Keterangan = dr["Keterangan"].ToString(),
                        PihakKetigaID = dr["PihakKetigaID"].ToString(),
                        PihakKetigaName = dr["PihakKetigaName"].ToString()
                    };
                }
            }
            return result;
        }

        public IEnumerable<BukuKasModel> ListData(string tgl1, string tgl2)
        {
            List<BukuKasModel> result = null;
            var sSql = @"
                SELECT
                    aa.BukuKasID, aa.TglBuku, aa.JamBuku,
                    aa.UserrID, aa.NilaiKas, 
                    aa.JenisTrsKasirID,
                    aa.ReffID, aa.Keterangan, aa.PihakKetigaID,
                    ISNULL(bb.PihakKetigaName,'')PihakKetigaName,
                    ISNULL(cc.JenisTrsKasirName, '') JenisTrsKasirName

                FROM    
                    BukuKas aa
                    LEFT JOIN PihakKetiga bb ON aa.PihakKetigaID = bb.PihakKetigaID
                    LEFT JOIN JenisTrsKasir cc ON aa.JenisTrsKasirID = cc.JenisTrsKasirID
                WHERE
                    TglBuku BETWEEN @Tgl1 AND @Tgl2 ";

            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@Tgl1", tgl1.ToTglYMD());
                cmd.AddParam("@Tgl2", tgl2.ToTglYMD());
                conn.Open();

                using (var dr = cmd.ExecuteReader())
                {
                    if (!dr.HasRows) return null;
                    result = new List<BukuKasModel>();
                    while (dr.Read())
                    {
                        var item = new BukuKasModel
                        {
                            BukuKasID = dr["BukuKasID"].ToString(),
                            TglBuku = dr["TglBuku"].ToString().ToTglDMY(),
                            JamBuku = dr["JamBuku"].ToString(),
                            UserrID = dr["USerrID"].ToString(),

                            NilaiKas = Convert.ToDecimal(dr["NilaiKas"]),
                            JenisTrsKasirID = dr["JenisTrsKasirID"].ToString(),
                            JenisTrsKasirName = dr["JenisTrsKasirName"].ToString(),

                            ReffID = dr["ReffID"].ToString(),
                            Keterangan = dr["Keterangan"].ToString(),
                            PihakKetigaID = dr["PihakKetigaID"].ToString(),
                            PihakKetigaName = dr["PihakKetigaName"].ToString()
                        };
                        result.Add(item);
                    }
                }
            }
            return result;
        }

    }
}
