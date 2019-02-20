using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnugerahBackend.Accounting.Model;
using AnugerahBackend.LocalHelper;
using Ics.Helper.Extensions;
using Ics.Helper.StringDateTime;

namespace AnugerahBackend.Accounting.Dal
{
    public interface IBPPiutangDal : IHeaderTrsDal<BPPiutangModel>
    {
        IEnumerable<BPPiutangModel> ListData();
    }
    public class BPPiutangDal : IBPPiutangDal
    {
        private string _connString;

        public BPPiutangDal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void Insert(BPPiutangModel model)
        {
            var sSql = @"
                INSERT INTO 
                    BPPiutang (
                        BPPiutangID, Tgl, Jam, PihakKeduaID,
                        Keterangan, NilaiPiutang, NilaiLunas) 
                VALUES (
                        @BPPiutangID, @Tgl, @Jam, @PihakKeduaID,
                        @Keterangan, @NilaiPiutang, @NilaiLunas ) ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BPPiutangID", model.BPPiutangID);
                cmd.AddParam("@Tgl", model.Tgl.ToTglYMD());
                cmd.AddParam("@Jam", model.Jam);
                cmd.AddParam("@PihakKeduaID", model.PihakKeduaID);
                cmd.AddParam("@Keterangan", model.Keterangan);
                cmd.AddParam("@NilaiPiutang", model.NilaiPiutang);
                cmd.AddParam("@NilaiLunas", model.NilaiLunas);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(BPPiutangModel model)
        {
            var sSql = @"
                UPDATE
                    BPPiutang 
                SET
                    Tgl = @Tgl, 
                    Jam = @Jam, 
                    PihakKeduaID = @PihakKeduaID,
                    Keterangan = @Keterangan, 
                    NilaiPiutang = @NilaiPiutang, 
                    NilaiLunas = @NilaiLunas 
                WHERE
                    BPPiutangID = @BPPiutangID  ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BPPiutangID", model.BPPiutangID);
                cmd.AddParam("@Tgl", model.Tgl.ToTglYMD());
                cmd.AddParam("@Jam", model.Jam);
                cmd.AddParam("@PihakKeduaID", model.PihakKeduaID);
                cmd.AddParam("@Keterangan", model.Keterangan);
                cmd.AddParam("@NilaiPiutang", model.NilaiPiutang);
                cmd.AddParam("@NilaiLunas", model.NilaiLunas);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string id)
        {
            var sSql = @"
                DELETE
                    BPPiutang 
                WHERE
                    BPPiutangID = @BPPiutangID  ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BPPiutangID", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public BPPiutangModel GetData(string id)
        {
            BPPiutangModel result = null;
            var sSql = @"
                SELECT
                    aa.BPPiutangID, aa.Tgl, aa.Jam, aa.PihakKeduaID,
                    aa.Keterangan, aa.NilaiPiutang, aa.NilaiLunas,
                    ISNULL(bb.PihakKeduaName, '') PihakKeduaName 
                FROM    
                    BPPiutang aa
                    LEFT JOIN PihakKedua bb ON aa.PihakKeduaID = bb.PihakKeduaID 
                WHERE
                    aa.BPPiutangID = @BPPiutangID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BPPiutangID", id);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (!dr.HasRows) return null;
                    dr.Read();
                    result = new BPPiutangModel
                    {
                        BPPiutangID = dr["BPPiutangID"].ToString(),
                        Tgl = dr["Tgl"].ToString().ToTglDMY(),
                        Jam = dr["Jam"].ToString(),
                        PihakKeduaID = dr["PihakKeduaID"].ToString(),
                        PihakKeduaName = dr["PihakKeduaName"].ToString(),
                        Keterangan = dr["Keterangan"].ToString(),
                        NilaiPiutang = Convert.ToDecimal(dr["NilaiPiutang"]),
                        NilaiLunas = Convert.ToDecimal(dr["NilaiLunas"]),
                    };
                }
            }
            return result;
        }

        public IEnumerable<BPPiutangModel> ListData(string tgl1, string tgl2)
        {
            List<BPPiutangModel> result = null;
            var sSql = @"
                SELECT
                    aa.BPPiutangID, aa.Tgl, aa.Jam, aa.PihakKeduaID,
                    aa.Keterangan, aa.NilaiPiutang, aa.NilaiLunas,
                    ISNULL(bb.PihakKeduaName, '') PihakKeduaName 
                FROM    
                    BPPiutang aa
                    LEFT JOIN PihakKedua bb ON aa.PihakKeduaID = bb.PihakKeduaID 
                WHERE
                    aa.Tgl BETWEEN @Tgl1 AND @Tgl2  ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@Tgl1", tgl1.ToTglYMD());
                cmd.AddParam("@Tgl2", tgl2.ToTglYMD());
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (!dr.HasRows) return null;
                    result = new List<BPPiutangModel>();
                    while (dr.Read())
                    {
                        var item = new BPPiutangModel
                        {
                            BPPiutangID = dr["BPPiutangID"].ToString(),
                            Tgl = dr["Tgl"].ToString().ToTglDMY(),
                            Jam = dr["Jam"].ToString(),
                            PihakKeduaID = dr["PihakKeduaID"].ToString(),
                            PihakKeduaName = dr["PihakKeduaName"].ToString(),
                            Keterangan = dr["Keterangan"].ToString(),
                            NilaiPiutang = Convert.ToDecimal(dr["NilaiPiutang"]),
                            NilaiLunas = Convert.ToDecimal(dr["NilaiLunas"]),
                        };
                        result.Add(item);
                    }
                }
            }
            return result;
        }

        public IEnumerable<BPPiutangModel> ListData()
        {
            List<BPPiutangModel> result = null;
            var sSql = @"
                SELECT
                    aa.BPPiutangID, aa.Tgl, aa.Jam, aa.PihakKeduaID,
                    aa.Keterangan, aa.NilaiPiutang, aa.NilaiLunas,
                    ISNULL(bb.PihakKeduaName, '') PihakKeduaName 
                FROM    
                    BPPiutang aa
                    LEFT JOIN PihakKedua bb ON aa.PihakKeduaID = bb.PihakKeduaID 
                WHERE
                    aa.NilaiPiutang <> aa.NilaiLunas  ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (!dr.HasRows) return null;
                    result = new List<BPPiutangModel>();
                    while (dr.Read())
                    {
                        var item = new BPPiutangModel
                        {
                            BPPiutangID = dr["BPPiutangID"].ToString(),
                            Tgl = dr["Tgl"].ToString().ToTglDMY(),
                            Jam = dr["Jam"].ToString(),
                            PihakKeduaID = dr["PihakKeduaID"].ToString(),
                            PihakKeduaName = dr["PihakKeduaName"].ToString(),
                            Keterangan = dr["Keterangan"].ToString(),
                            NilaiPiutang = Convert.ToDecimal(dr["NilaiPiutang"]),
                            NilaiLunas = Convert.ToDecimal(dr["NilaiLunas"]),
                        };
                        result.Add(item);
                    }
                }
            }
            return result;
        }
    }
}
