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
    public interface IBPKasDal : IHeaderTrsDal<BPKasModel>
    {

    }
    public class BPKasDal : IBPKasDal
    {
        private string _connString;

        public BPKasDal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void Insert(BPKasModel model)
        {
            var sSql = @"
                INSERT INTO 
                    BPKas (
                        BPKasID, Tgl, Jam, Keterangan,
                        NilaiTotalKas )
                VALUES (
                        @BPKasID, @Tgl, @Jam, @Keterangan,
                        @NilaiTotalKas) ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BPKasID", model.BPKasID);
                cmd.AddParam("@Tgl", model.Tgl.ToTglYMD());
                cmd.AddParam("@Jam", model.Jam);
                cmd.AddParam("@Keterangan", model.Keterangan);
                cmd.AddParam("@NilaiTotalKas", model.NilaiTotalKas);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(BPKasModel model)
        {
            var sSql = @"
                UPDATE
                    BPKas 
                SET
                    Tgl = @Tgl, 
                    Jam = @Jam, 
                    Keterangan = @Keterangan,
                    NilaiTotalKas = @NilaiTotalKas
                WHERE
                    BPKasID = @BPKasID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BPKasID", model.BPKasID);
                cmd.AddParam("@Tgl", model.Tgl.ToTglYMD());
                cmd.AddParam("@Jam", model.Jam);
                cmd.AddParam("@Keterangan", model.Keterangan);
                cmd.AddParam("@NilaiTotalKas", model.NilaiTotalKas);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string id)
        {
            var sSql = @"
                DELETE
                    BPKas 
                WHERE
                    BPKasID = @BPKasID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BPKasID", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public BPKasModel GetData(string id)
        {
            BPKasModel result = null;
            var sSql = @"
                SELECT
                    aa.BPKasID, aa.Tgl, aa.Jam, aa.Keterangan,
                    aa.NilaiTotalKas 
                FROM    
                    BPKas aa
                WHERE
                    aa.BPKasID = @BPKasID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BPKasID", id);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (!dr.HasRows) return null;
                    dr.Read();
                    result = new BPKasModel
                    {
                        BPKasID = dr["BPKasID"].ToString(),
                        Tgl = dr["Tgl"].ToString().ToTglDMY(),
                        Jam = dr["Jam"].ToString(),
                        Keterangan = dr["Keterangan"].ToString(),
                        NilaiTotalKas = Convert.ToDecimal(dr["NilaiTotalKas"]),
                    };
                }
            }
            return result;
        }

        public IEnumerable<BPKasModel> ListData(string tgl1, string tgl2)
        {
            List<BPKasModel> result = null;
            var sSql = @"
                SELECT
                    aa.BPKasID, aa.Tgl, aa.Jam, aa.Keterangan,
                    aa.NilaiTotalKas 
                FROM    
                    BPKas aa
                WHERE
                    aa.Tgl BETWEEN @Tgl1 AND @Tgl2 ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@Tgl1", tgl1.ToTglYMD());
                cmd.AddParam("@Tgl2", tgl2.ToTglYMD());
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (!dr.HasRows) return null;
                    result = new List<BPKasModel>();
                    while (dr.Read())
                    {
                        var item = new BPKasModel
                        {
                            BPKasID = dr["BPKasID"].ToString(),
                            Tgl = dr["Tgl"].ToString().ToTglDMY(),
                            Jam = dr["Jam"].ToString(),
                            Keterangan = dr["Keterangan"].ToString(),
                            NilaiTotalKas = Convert.ToDecimal(dr["NilaiTotalKas"]),
                        };
                        result.Add(item);
                    }
                }
            }
            return result;
        }
    }
}
