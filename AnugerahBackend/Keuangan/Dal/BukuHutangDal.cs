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
    public interface IBukuHutangDal
    {
        void Insert(BukuHutangModel bukuHutang);
        void Update(BukuHutangModel bukuHutang);
        void Delete(string bukuHutangID);
        BukuHutangModel GetData(string bukuHutangID);
        IEnumerable<BukuHutangModel> ListData(string tgl1, string tgl2);

    }
    public class BukuHutangDal : IBukuHutangDal
    {
        private string _connString;

        public BukuHutangDal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void Insert(BukuHutangModel bukuHutang)
        {
            var sSql = @"
                INSERT INTO
                    BukuHutang (
                        BukuHutangID, TglBuku, JamBuku, UserrID,
                        PihakKetigaID, NilaiHutang, NilaiSisa,
                        Keterangan, BukuKasID)
                VALUES (
                        @BukuHutangID, @TglBuku, @JamBuku, @UserrID,
                        @PihakKetigaID, @NilaiHutang, @NilaiSisa,
                        @Keterangan, @BukuKasID) ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BukuHutangID", bukuHutang.BukuHutangID);
                cmd.AddParam("@TglBuku", bukuHutang.TglBuku.ToTglYMD());
                cmd.AddParam("@JamBuku", bukuHutang.JamBuku);
                cmd.AddParam("@UserrID", bukuHutang.UserrID);
                cmd.AddParam("@PihakKetigaID", bukuHutang.PihakKetigaID);
                cmd.AddParam("@NilaiHutang", bukuHutang.NilaiHutang);
                cmd.AddParam("@NilaiSisa", bukuHutang.NilaiSisa);
                cmd.AddParam("@Keterangan", bukuHutang.Keterangan);
                cmd.AddParam("@BukuKasID", bukuHutang.BukuKasID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(BukuHutangModel bukuHutang)
        {
            var sSql = @"
                UPDATE
                    BukuHutang 
                SET 
                    TglBuku = @TglBuku, 
                    JamBuku = @JamBuku, 
                    UserrID = @UserrID,
                    PihakKetigaID = @PihakKetigaID, 
                    NilaiHutang = @NilaiHutang, 
                    NilaiSisa = @NilaiSisa,
                    Keterangan = @Keterangan, 
                    BukuKasID = @BukuKasID
                WHERE
                    BukuHutangID = @BukuHutangID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BukuHutangID", bukuHutang.BukuHutangID);
                cmd.AddParam("@TglBuku", bukuHutang.TglBuku.ToTglYMD());
                cmd.AddParam("@JamBuku", bukuHutang.JamBuku);
                cmd.AddParam("@UserrID", bukuHutang.UserrID);
                cmd.AddParam("@PihakKetigaID", bukuHutang.PihakKetigaID);
                cmd.AddParam("@NilaiHutang", bukuHutang.NilaiHutang);
                cmd.AddParam("@NilaiSisa", bukuHutang.NilaiSisa);
                cmd.AddParam("@Keterangan", bukuHutang.Keterangan);
                cmd.AddParam("@BukuKasID", bukuHutang.BukuKasID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string bukuHutangID)
        {
            var sSql = @"
                DELETE
                    BukuHutang
                WHERE
                    BukuHutangID = @BukuHutangID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BukuHutangID", bukuHutangID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public BukuHutangModel GetData(string bukuHutangID)
        {
            BukuHutangModel result = null;
            var sSql = @"
                SELECT
                    aa.BukuHutangID, aa.TglBuku, aa.JamBuku, aa.UserrID,
                    aa.PihakKetigaID, aa.NilaiHutang, aa.NilaiSisa,
                    aa.Keterangan, aa.BukuKasID,
                    ISNULL(bb.PihakKetigaName, '') PihakKetigaName
                FROM    
                    BukuHutang aa
                    LEFT JOIN PihakKetiga bb ON aa.PihakKetigaID = bb.PihakKetigaID
                WHERE
                    aa.BukuHutangID = @BukuHutangID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BukuHutangID", bukuHutangID);
                conn.Open();

                using (var dr = cmd.ExecuteReader())
                {
                    if (!dr.HasRows) return null;
                    dr.Read();
                    result = new BukuHutangModel
                    {
                        BukuHutangID = bukuHutangID,
                        TglBuku = dr["TglBuku"].ToString().ToTglDMY(),
                        JamBuku = dr["JamBuku"].ToString(),
                        UserrID = dr["USerrID"].ToString(),

                        PihakKetigaID = dr["PihakKetigaID"].ToString(),
                        PihakKetigaName = dr["PihakKetigaName"].ToString(),

                        NilaiHutang = Convert.ToDecimal(dr["NilaiHutang"]),
                        NilaiSisa = Convert.ToDecimal(dr["NilaiSisa"]),
                        Keterangan = dr["Keterangan"].ToString(),
                        BukuKasID = dr["BukuKasID"].ToString()
                    };
                }
            }
            return result;
        }

        public IEnumerable<BukuHutangModel> ListData(string tgl1, string tgl2)
        {
            List<BukuHutangModel> result = null;
            var sSql = @"
                SELECT
                    aa.BukuHutangID, aa.TglBuku, aa.JamBuku, aa.UserrID,
                    aa.PihakKetigaID, aa.NilaiHutang, aa.NilaiSisa,
                    aa.Keterangan, aa.BukuKasID,
                    ISNULL(bb.PihakKetigaName, '') PihakKetigaName
                FROM    
                    BukuHutang aa
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
                    result = new List<BukuHutangModel>();
                    while (dr.Read())
                    {
                        var item = new BukuHutangModel
                        {
                            BukuHutangID = dr["BukuHutangID"].ToString(),
                            TglBuku = dr["TglBuku"].ToString().ToTglDMY(),
                            JamBuku = dr["JamBuku"].ToString(),
                            UserrID = dr["USerrID"].ToString(),

                            PihakKetigaID = dr["PihakKetigaID"].ToString(),
                            PihakKetigaName = dr["PihakKetigaName"].ToString(),

                            NilaiHutang = Convert.ToDecimal(dr["NilaiHutang"]),
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
