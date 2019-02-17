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
    public interface IBPHutangDal : IHeaderTrsDal<BPHutangModel>
    {
        IEnumerable<BPHutangModel> ListData();
    }
    public class BPHutangDal : IBPHutangDal
    {
        private string _connString;

        public BPHutangDal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void Insert(BPHutangModel model)
        {
            var sSql = @"
                INSERT INTO 
                    BPHutang (
                        BPHutangID, Tgl, Jam, PihakKeduaID,
                        Keterangan, NilaiHutang, NilaiLunas) 
                VALUES (
                        @BPHutangID, @Tgl, @Jam, @PihakKeduaID,
                        @Keterangan, @NilaiHutang, @NilaiLunas ) ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BPHutangID", model.BPHutangID);
                cmd.AddParam("@Tgl", model.Tgl.ToTglYMD());
                cmd.AddParam("@Jam", model.Jam);
                cmd.AddParam("@PihakKeduaID", model.PihakKeduaID);
                cmd.AddParam("@Keterangan", model.Keterangan);
                cmd.AddParam("@NilaiHutang", model.NilaiHutang);
                cmd.AddParam("@NilaiLunas", model.NilaiLunas);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(BPHutangModel model)
        {
            var sSql = @"
                UPDATE
                    BPHutang 
                SET
                    Tgl = @Tgl, 
                    Jam = @Jam, 
                    PihakKeduaID = @PihakKeduaID,
                    Keterangan = @Keterangan, 
                    NilaiHutang = @NilaiHutang, 
                    NilaiLunas = @NilaiLunas 
                WHERE
                    BPHutangID = @BPHutangID  ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BPHutangID", model.BPHutangID);
                cmd.AddParam("@Tgl", model.Tgl.ToTglYMD());
                cmd.AddParam("@Jam", model.Jam);
                cmd.AddParam("@PihakKeduaID", model.PihakKeduaID);
                cmd.AddParam("@Keterangan", model.Keterangan);
                cmd.AddParam("@NilaiHutang", model.NilaiHutang);
                cmd.AddParam("@NilaiLunas", model.NilaiLunas);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string id)
        {
            var sSql = @"
                DELETE
                    BPHutang 
                WHERE
                    BPHutangID = @BPHutangID  ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BPHutangID", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public BPHutangModel GetData(string id)
        {
            BPHutangModel result = null;
            var sSql = @"
                SELECT
                    aa.BPHutangID, aa.Tgl, aa.Jam, aa.PihakKeduaID,
                    aa.Keterangan, aa.NilaiHutang, aa.NilaiLunas,
                    ISNULL(bb.PihakKeduaName, ' ') PihakKeduaName 
                FROM    
                    BPHutang aa
                    LEFT JOIN PihakKedua bb ON aa.PihakKeduaID = bb.PihakKeduaID 
                WHERE
                    aa.BPHutangID = @BPHutangID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BPHutangID", id);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (!dr.HasRows) return null;
                    dr.Read();
                    result = new BPHutangModel
                    {
                        BPHutangID = dr["BPHutangID"].ToString(),
                        Tgl = dr["Tgl"].ToString().ToTglDMY(),
                        Jam = dr["Jam"].ToString(), 
                        PihakKeduaID = dr["PihakKeduaID"].ToString(),
                        Keterangan = dr["Keterangan"].ToString(), 
                        NilaiHutang = Convert.ToDecimal(dr["NilaiHutang"]), 
                        NilaiLunas = Convert.ToDecimal(dr["NilaiLunas"]),
                    };
                }
            }
            return result;
        }

        public IEnumerable<BPHutangModel> ListData(string tgl1, string tgl2)
        {
            List<BPHutangModel> result = null;
            var sSql = @"
                SELECT
                    aa.BPHutangID, aa.Tgl, aa.Jam, aa.PihakKeduaID,
                    aa.Keterangan, aa.NilaiHutang, aa.NilaiLunas,
                    ISNULL(bb.PihakKeduaName, ' ') PihakKeduaName 
                FROM    
                    BPHutang aa
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
                    result = new List<BPHutangModel>();
                    while(dr.Read())
                    { 
                        var item = new BPHutangModel
                        {
                            BPHutangID = dr["BPHutangID"].ToString(),
                            Tgl = dr["Tgl"].ToString().ToTglDMY(),
                            Jam = dr["Jam"].ToString(),
                            PihakKeduaID = dr["PihakKeduaID"].ToString(),
                            Keterangan = dr["Keterangan"].ToString(),
                            NilaiHutang = Convert.ToDecimal(dr["NilaiHutang"]),
                            NilaiLunas = Convert.ToDecimal(dr["NilaiLunas"]),
                        };
                        result.Add(item);
                    }
                }
            }
            return result;
        }

        public IEnumerable<BPHutangModel> ListData()
        {
            List<BPHutangModel> result = null;
            var sSql = @"
                SELECT
                    aa.BPHutangID, aa.Tgl, aa.Jam, aa.PihakKeduaID,
                    aa.Keterangan, aa.NilaiHutang, aa.NilaiLunas,
                    ISNULL(bb.PihakKeduaName, ' ') PihakKeduaName 
                FROM    
                    BPHutang aa
                    LEFT JOIN PihakKedua bb ON aa.PihakKeduaID = bb.PihakKeduaID 
                WHERE
                    aa.NilaiLunas < aa.NilaiHutang ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (!dr.HasRows) return null;
                    result = new List<BPHutangModel>();
                    while (dr.Read())
                    {
                        var item = new BPHutangModel
                        {
                            BPHutangID = dr["BPHutangID"].ToString(),
                            Tgl = dr["Tgl"].ToString().ToTglDMY(),
                            Jam = dr["Jam"].ToString(),
                            PihakKeduaID = dr["PihakKeduaID"].ToString(),
                            Keterangan = dr["Keterangan"].ToString(),
                            NilaiHutang = Convert.ToDecimal(dr["NilaiHutang"]),
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
