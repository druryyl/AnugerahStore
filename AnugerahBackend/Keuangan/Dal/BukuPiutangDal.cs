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
    public interface IBukuPiutangDal
    {
        void Insert(BukuPiutangModel bukuPiutang);
        void Update(BukuPiutangModel bukuPiutang);
        void Delete(string bukuPiutangID);
        BukuPiutangModel GetData(string bukuPiutangID);
        IEnumerable<BukuPiutangModel> ListData(string tgl1, string tgl2);

    }
    public class BukuPiutangDal : IBukuPiutangDal
    {
        private string _connString;

        public BukuPiutangDal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void Insert(BukuPiutangModel bukuPiutang)
        {
            var sSql = @"
                INSERT INTO
                    BukuPiutang (
                        BukuPiutangID, TglBuku, JamBuku, UserrID,
                        PihakKetigaID, NilaiPiutang, NilaiSisa,
                        Keterangan, BukuKasID)
                VALUES (
                        @BukuPiutangID, @TglBuku, @JamBuku, @UserrID,
                        @PihakKetigaID, @NilaiPiutang, @NilaiSisa,
                        @Keterangan, @BukuKasID) ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BukuPiutangID", bukuPiutang.BukuPiutangID);
                cmd.AddParam("@TglBuku", bukuPiutang.TglBuku.ToTglYMD());
                cmd.AddParam("@JamBuku", bukuPiutang.JamBuku);
                cmd.AddParam("@UserrID", bukuPiutang.UserrID);
                cmd.AddParam("@PihakKetigaID", bukuPiutang.PihakKetigaID);
                cmd.AddParam("@NilaiPiutang", bukuPiutang.NilaiPiutang);
                cmd.AddParam("@NilaiSisa", bukuPiutang.NilaiSisa);
                cmd.AddParam("@Keterangan", bukuPiutang.Keterangan);
                cmd.AddParam("@BukuKasID", bukuPiutang.BukuKasID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(BukuPiutangModel bukuPiutang)
        {
            var sSql = @"
                UPDATE
                    BukuPiutang 
                SET 
                    TglBuku = @TglBuku, 
                    JamBuku = @JamBuku, 
                    UserrID = @UserrID,
                    PihakKetigaID = @PihakKetigaID, 
                    NilaiPiutang = @NilaiPiutang, 
                    NilaiSisa = @NilaiSisa,
                    Keterangan = @Keterangan, 
                    BukuKasID = @BukuKasID
                WHERE
                    BukuPiutangID = @BukuPiutangID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BukuPiutangID", bukuPiutang.BukuPiutangID);
                cmd.AddParam("@TglBuku", bukuPiutang.TglBuku.ToTglYMD());
                cmd.AddParam("@JamBuku", bukuPiutang.JamBuku);
                cmd.AddParam("@UserrID", bukuPiutang.UserrID);
                cmd.AddParam("@PihakKetigaID", bukuPiutang.PihakKetigaID);
                cmd.AddParam("@NilaiPiutang", bukuPiutang.NilaiPiutang);
                cmd.AddParam("@NilaiSisa", bukuPiutang.NilaiSisa);
                cmd.AddParam("@Keterangan", bukuPiutang.Keterangan);
                cmd.AddParam("@BukuKasID", bukuPiutang.BukuKasID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string bukuPiutangID)
        {
            var sSql = @"
                DELETE
                    BukuPiutang
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

        public BukuPiutangModel GetData(string bukuPiutangID)
        {
            BukuPiutangModel result = null;
            var sSql = @"
                SELECT
                    aa.BukuPiutangID, aa.TglBuku, aa.JamBuku, aa.UserrID,
                    aa.PihakKetigaID, aa.NilaiPiutang, aa.NilaiSisa,
                    aa.Keterangan, aa.BukuKasID,
                    ISNULL(bb.PihakKetigaName, '') PihakKetigaName
                FROM    
                    BukuPiutang aa
                    LEFT JOIN PihakKetiga bb ON aa.PihakKetigaID = bb.PihakKetigaID
                WHERE
                    aa.BukuPiutangID = @BukuPiutangID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BukuPiutangID", bukuPiutangID);
                conn.Open();

                using (var dr = cmd.ExecuteReader())
                {
                    if (!dr.HasRows) return null;
                    dr.Read();
                    result = new BukuPiutangModel
                    {
                        BukuPiutangID = bukuPiutangID,
                        TglBuku = dr["TglBuku"].ToString().ToTglDMY(),
                        JamBuku = dr["JamBuku"].ToString(),
                        UserrID = dr["USerrID"].ToString(),

                        PihakKetigaID = dr["PihakKetigaID"].ToString(),
                        PihakKetigaName = dr["PihakKetigaName"].ToString(),

                        NilaiPiutang = Convert.ToDecimal(dr["NilaiPiutang"]),
                        NilaiSisa= Convert.ToDecimal(dr["NilaiSisa"]),
                        Keterangan = dr["Keterangan"].ToString(),
                        BukuKasID = dr["BukuKasID"].ToString()
                    };
                }
            }
            return result;
        }

        public IEnumerable<BukuPiutangModel> ListData(string tgl1, string tgl2)
        {
            List<BukuPiutangModel> result = null;
            var sSql = @"
                SELECT
                    aa.BukuPiutangID, aa.TglBuku, aa.JamBuku, aa.UserrID,
                    aa.PihakKetigaID, aa.NilaiPiutang, aa.NilaiSisa,
                    aa.Keterangan, aa.BukuKasID,
                    ISNULL(bb.PihakKetigaName, '') PihakKetigaName
                FROM    
                    BukuPiutang aa
                    LEFT JOIN PihakKetiga bb ON aa.PihakKetigaID = bb.PihakKetigaID
                WHERE
                    aa.TglBuku BETWEEN @Tgl1 AND @Tgl2 ";

            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@Tgl1", tgl1.ToTglYMD());
                cmd.AddParam("@Tgl2", tgl2.ToTglYMD());
                conn.Open();

                using (var dr = cmd.ExecuteReader())
                {
                    if (!dr.HasRows) return null;
                    result = new List<BukuPiutangModel>();
                    while (dr.Read())
                    {
                        var item = new BukuPiutangModel
                        {
                            BukuPiutangID = dr["BukuPiutangID"].ToString(),
                            TglBuku = dr["TglBuku"].ToString().ToTglDMY(),
                            JamBuku = dr["JamBuku"].ToString(),
                            UserrID = dr["USerrID"].ToString(),

                            PihakKetigaID = dr["PihakKetigaID"].ToString(),
                            PihakKetigaName = dr["PihakKetigaName"].ToString(),

                            NilaiPiutang = Convert.ToDecimal(dr["NilaiPiutang"]),
                            NilaiSisa = Convert.ToDecimal(dr["NilaiSisa"]),
                            Keterangan = dr["Keterangan"].ToString(),
                            BukuKasID = dr["BukuKasID"].ToString()
                        };
                        result.Add(item);
                    }
                }
            }
            return result;
        }
    }
}
