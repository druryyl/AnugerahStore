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
    public interface ILunasKasBonDal : IHeaderTrsDal<LunasKasBonModel>
    {
        IEnumerable<LunasKasBonModel> ListData(string bpPiutangID);
    }
    public class LunasKasBonDal : ILunasKasBonDal
    {
        private string _connString;

        public LunasKasBonDal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void Insert(LunasKasBonModel model)
        {
            var sSql = @"
                INSERT INTO 
                    LunasKasBon (
                        LunasKasBonID, Tgl, Jam, 
                        PihakKeduaID, KasBonID, NilaiTotLunas) 
                VALUES (
                        @LunasKasBonID, @Tgl, @Jam, 
                        @PihakKeduaID, @KasBonID, @NilaiTotLunas ) ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@LunasKasBonID", model.LunasKasBonID);
                cmd.AddParam("@Tgl", model.Tgl.ToTglYMD());
                cmd.AddParam("@Jam", model.Jam);
                cmd.AddParam("@PihakKeduaID", model.PihakKeduaID);
                cmd.AddParam("@KasBonID", model.KasBonID);
                cmd.AddParam("@NilaiTotLunas", model.NilaiTotLunas);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(LunasKasBonModel model)
        {
            var sSql = @"
                UPDATE
                    LunasKasBon 
                SET
                    Tgl = @Tgl, 
                    Jam = @Jam, 
                    PihakKeduaID = @PihakKeduaID,
                    KasBonID = @KasBonID,
                    NilaiTotLunas = @NilaiTotLunas 
                WHERE
                    LunasKasBonID = @LunasKasBonID  ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@LunasKasBonID", model.LunasKasBonID);
                cmd.AddParam("@Tgl", model.Tgl.ToTglYMD());
                cmd.AddParam("@Jam", model.Jam);
                cmd.AddParam("@PihakKeduaID", model.PihakKeduaID);
                cmd.AddParam("@KasBonID", model.KasBonID);
                cmd.AddParam("@NilaiTotLunas", model.NilaiTotLunas);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string id)
        {
            var sSql = @"
                DELETE
                    LunasKasBon 
                WHERE
                    LunasKasBonID = @LunasKasBonID  ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@LunasKasBonID", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public LunasKasBonModel GetData(string id)
        {
            LunasKasBonModel result = null;
            var sSql = @"
                SELECT
                    aa.LunasKasBonID, aa.Tgl, aa.Jam, aa.PihakKeduaID,
                    aa.KasBonID, aa.NilaiTotLunas,
                    ISNULL(bb.PihakKeduaName, '') PihakKeduaName 
                FROM    
                    LunasKasBon aa
                    LEFT JOIN PihakKedua bb ON aa.PihakKeduaID = bb.PihakKeduaID 
                WHERE
                    aa.LunasKasBonID = @LunasKasBonID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@LunasKasBonID", id);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (!dr.HasRows) return null;
                    dr.Read();
                    result = new LunasKasBonModel
                    {
                        LunasKasBonID = dr["LunasKasBonID"].ToString(),
                        Tgl = dr["Tgl"].ToString().ToTglDMY(),
                        Jam = dr["Jam"].ToString(),
                        PihakKeduaID = dr["PihakKeduaID"].ToString(),
                        PihakKeduaName = dr["PihakKeduaName"].ToString(),
                        KasBonID = dr["KasBonID"].ToString(),
                        NilaiTotLunas = Convert.ToDecimal(dr["NilaiTotLunas"]),
                    };
                }
            }
            return result;
        }

        public IEnumerable<LunasKasBonModel> ListData(string tgl1, string tgl2)
        {
            List<LunasKasBonModel> result = null;
            var sSql = @"
                SELECT
                    aa.LunasKasBonID, aa.Tgl, aa.Jam, aa.PihakKeduaID,
                    aa.KasBonID, aa.NilaiTotLunas,
                    ISNULL(bb.PihakKeduaName, '') PihakKeduaName 
                FROM    
                    LunasKasBon aa
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
                    result = new List<LunasKasBonModel>();
                    while (dr.Read())
                    {
                        var item = new LunasKasBonModel
                        {
                            LunasKasBonID = dr["LunasKasBonID"].ToString(),
                            Tgl = dr["Tgl"].ToString().ToTglDMY(),
                            Jam = dr["Jam"].ToString(),
                            PihakKeduaID = dr["PihakKeduaID"].ToString(),
                            PihakKeduaName = dr["PihakKeduaName"].ToString(),
                            KasBonID = dr["KasBonID"].ToString(),
                            NilaiTotLunas = Convert.ToDecimal(dr["NilaiTotLunas"]),
                        };
                        result.Add(item);
                    }
                }
            }
            return result;
        }

        public IEnumerable<LunasKasBonModel> ListData(string kasBonID)
        {
            List<LunasKasBonModel> result = null;
            var sSql = @"
                SELECT
                    aa.LunasKasBonID, aa.Tgl, aa.Jam, aa.PihakKeduaID,
                    aa.KasBonID, aa.NilaiTotLunas,
                    ISNULL(bb.PihakKeduaName, '') PihakKeduaName 
                FROM    
                    LunasKasBon aa
                    LEFT JOIN PihakKedua bb ON aa.PihakKeduaID = bb.PihakKeduaID 
                WHERE
                    aa.KasBonID BETWEEN @KasBonID  ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@KasBonID", kasBonID);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (!dr.HasRows) return null;
                    result = new List<LunasKasBonModel>();
                    while (dr.Read())
                    {
                        var item = new LunasKasBonModel
                        {
                            LunasKasBonID = dr["LunasKasBonID"].ToString(),
                            Tgl = dr["Tgl"].ToString().ToTglDMY(),
                            Jam = dr["Jam"].ToString(),
                            PihakKeduaID = dr["PihakKeduaID"].ToString(),
                            PihakKeduaName = dr["PihakKeduaName"].ToString(),
                            KasBonID = dr["KasBonID"].ToString(),
                            NilaiTotLunas = Convert.ToDecimal(dr["NilaiTotLunas"]),
                        };
                        result.Add(item);
                    }
                }
            }
            return result;
        }
    }
}
