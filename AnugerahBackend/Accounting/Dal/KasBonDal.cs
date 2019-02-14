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
    public interface IKasBonDal : IHeaderTrsDal<KasBonModel>
    {

    }

    public class KasBonDal : IKasBonDal
    {
        private string _connString;

        public KasBonDal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void Insert(KasBonModel model)
        {
            var sSql = @"
                INSERT INTO
                    KasBon (
                        KasBonID, Tgl, Jam, Keterangan, 
                        PihakKeduaID, JenisKasID, NilaiKasBon)
                VALUES (
                        @KasBonID, @Tgl, @Jam, @Keterangan, 
                        @PihakKeduaID, @JenisKasID, @NilaiKasBon) ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@KasBonID", model.KasBonID);
                cmd.AddParam("@Tgl", model.Tgl.ToTglYMD());
                cmd.AddParam("@Jam", model.Jam);
                cmd.AddParam("@Keterangan", model.Keterangan);
                cmd.AddParam("@PihakKeduaID", model.PihakKeduaID);
                cmd.AddParam("@JenisKasID", model.JenisKasID);
                cmd.AddParam("@NilaiKasBon", model.NilaiKasBon);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(KasBonModel model)
        {
            var sSql = @"
                UPDATE
                    KasBon 
                SET 
                    Tgl = @Tgl, 
                    Jam = @Jam, 
                    Keterangan = @Keterangan, 
                    PihakKeduaID = @PihakKeduaID,
                    JenisKasID = @JenisKasID,
                    NilaiKasBon = @NilaiKasBon 
                WHERE
                    KasBonID = @KasBonID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@KasBonID", model.KasBonID);
                cmd.AddParam("@Tgl", model.Tgl.ToTglYMD());
                cmd.AddParam("@Jam", model.Jam);
                cmd.AddParam("@Keterangan", model.Keterangan);
                cmd.AddParam("@PihakKeduaID", model.PihakKeduaID);
                cmd.AddParam("@JenisKasID", model.JenisKasID);
                cmd.AddParam("@NilaiKasBon", model.NilaiKasBon);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string id)
        {
            var sSql = @"
                DELETE
                    KasBon
                WHERE
                    KasBonID = @KasBonID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@KasBonID", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public KasBonModel GetData(string id)
        {
            KasBonModel result = null;
            var sSql = @"
                SELECT
                    aa.KasBonID, aa.Tgl, aa.Jam, aa.Keterangan, 
                    aa.PihakKeduaID, aa.JenisKasID, aa.NilaiKasBon,
                    ISNULL(bb.PihakKeduaName, '') PihakKeduaName,
                    ISNULL(cc.JenisKasName, '') JenisKasName
                FROM
                    KasBon aa
                    LEFT JOIN PihakKedua bb ON aa.PihakKeduaID = bb.PihakKeduaID
                    LEFT JOIN JenisKas cc ON aa.JenisKasID = cc.JenisKasID
                WHERE
                    KasBonID = @KasBonID ";

            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@KasBonID", id);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (!dr.HasRows) return null;
                    dr.Read();
                    result = new KasBonModel
                    {
                        KasBonID = id,
                        Tgl = dr["Tgl"].ToString().ToTglDMY(),
                        Jam = dr["Jam"].ToString(),
                        Keterangan = dr["Keterangan"].ToString(),
                        PihakKeduaID = dr["PihakKeduaID"].ToString(),
                        PihakKeduaName = dr["PihakKeduaName"].ToString(),
                        JenisKasID = dr["JenisKasID"].ToString(),
                        JenisKasName = dr["JenisKasName"].ToString(),
                        NilaiKasBon = Convert.ToDecimal(dr["NilaiKasBon"])
                    };
                }
            }
            return result;
        }

        public IEnumerable<KasBonModel> ListData(string tgl1, string tgl2)
        {
            List<KasBonModel> result = null;
            var sSql = @"
                SELECT
                    aa.KasBonID, aa.Tgl, aa.Jam, aa.Keterangan, 
                    aa.PihakKeduaID, aa.JenisKasID, aa.NilaiKasBon,
                    ISNULL(bb.PihakKeduaName, '') PihakKeduaName,
                    ISNULL(cc.JenisKasName, '') JenisKasName
                FROM
                    KasBon aa
                    LEFT JOIN PihakKedua bb ON aa.PihakKeduaID = bb.PihakKeduaID
                    LEFT JOIN JenisKas cc ON aa.JenisKasID = cc.JenisKasID
                WHERE
                    Tgl BETWEEN @Tgl1 AND @Tgl2 ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@Tgl1", tgl1.ToTglYMD());
                cmd.AddParam("@Tgl2", tgl2.ToTglYMD());
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (!dr.HasRows) return null;
                    result = new List<KasBonModel>();
                    while (dr.Read())
                    {
                        var item = new KasBonModel
                        {
                            KasBonID = dr["KasBonID"].ToString(),
                            Tgl = dr["Tgl"].ToString().ToTglDMY(),
                            Jam = dr["Jam"].ToString(),
                            Keterangan = dr["Keterangan"].ToString(),
                            PihakKeduaID = dr["PihakKeduaID"].ToString(),
                            PihakKeduaName = dr["PihakKeduaName"].ToString(),
                            JenisKasID = dr["JenisKasID"].ToString(),
                            JenisKasName = dr["JenisKasName"].ToString(),
                            NilaiKasBon = Convert.ToDecimal(dr["NilaiKasBon"])
                        };
                        result.Add(item);
                    }
                }
            }
            return result;
        }
    }
}
