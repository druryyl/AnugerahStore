using AnugerahBackend.StokBarang.Model;
using Ics.Helper.Extensions;
using Ics.Helper.StringDateTime;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.StokBarang.Dal
{

    public interface IStokAdjustmentDal
    {
        void Insert(StokAdjustmentModel stokAdjustment);

        void Update(StokAdjustmentModel stokAdjustment);

        void Delete(string stringID);
        void Void(string id, string userrIDVoid);

        StokAdjustmentModel GetData(string id);

        IEnumerable<StokAdjustmentModel> ListData(string tgl1, string tgl2);
    }


    public class StokAdjustmentDal : IStokAdjustmentDal
    {
        public string _connString;

        public StokAdjustmentDal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void Insert(StokAdjustmentModel stokAdjustment)
        {
            var sSql = @"
                INSERT INTO
                    StokAdjustment (
                        StokAdjustmentID, TglTrs, JamTrs, UserrID, 
                        TglVoid, JamVoid, UserrIDVoid, Keterangan)
                VALUES (
                        @StokAdjustmentID, @TglTrs, @JamTrs, @UserrID, 
                        @TglVoid, @JamVoid, @UserrIDVoid, @Keterangan) ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@StokAdjustmentID", stokAdjustment.StokAdjustmentID);
                cmd.AddParam("@TglTrs", stokAdjustment.TglTrs.ToTglYMD());
                cmd.AddParam("@JamTrs", stokAdjustment.JamTrs);
                cmd.AddParam("@UserrID", stokAdjustment.UserrID);
                cmd.AddParam("@TglVoid", stokAdjustment.TglVoid.ToTglYMD());
                cmd.AddParam("@JamVoid", stokAdjustment.JamVoid);
                cmd.AddParam("@UserrIDVoid", stokAdjustment.UserrIDVoid);
                cmd.AddParam("@Keterangan", stokAdjustment.Keterangan);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(StokAdjustmentModel stokAdjustment)
        {
            var sSql = @"
                UPDATE
                    StokAdjustment 
                SET
                    TglTrs = @TglTrs,
                    JamTrs = @JamTrs,
                    UserrID = @UserrID,
                    TglVoid = @TglVoid,
                    JamVoid = @JamVoid,
                    UserrIDVoid = @UserrIDVoid,
                    Keterangan = @Keterangan
                WHERE
                    StokAdjustmentID = @StokAdjustmentID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@StokAdjustmentID", stokAdjustment.StokAdjustmentID);
                cmd.AddParam("@TglTrs", stokAdjustment.TglTrs);
                cmd.AddParam("@JamTrs", stokAdjustment.JamTrs);
                cmd.AddParam("@UserrID", stokAdjustment.UserrID);
                cmd.AddParam("@TglVoid", stokAdjustment.TglVoid.ToTglYMD());
                cmd.AddParam("@JamVoid", stokAdjustment.JamVoid);
                cmd.AddParam("@UserrIDVoid", stokAdjustment.UserrIDVoid);
                cmd.AddParam("@Keterangan", stokAdjustment.Keterangan);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string id)
        {
            var sSql = @"
                DELETE
                    StokAdjustment
                WHERE
                    StokAdjustmentID = @StokAdjustmentID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@StokAdjustmentID", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Void(string id, string userrIDVoid)
        {
            var sSql = @"
                UPDATE
                    StokAdjustment 
                SET
                    TglVoid = @TglVoid,
                    JamVoid = @JamVoid,
                    UserrIDVoid = @UserrIDVoid
                WHERE
                    StokAdjustmentID = @StokAdjustmentID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@TglVoid", DateTime.Now.ToString("yyyy-MM-dd"));
                cmd.AddParam("@JamVoid", DateTime.Now.ToString("HH:mm:ss"));
                cmd.AddParam("@UserrIDVoid", userrIDVoid);
                cmd.AddParam("@StokAdjustmentID", id);

                conn.Open();
                cmd.ExecuteReader();
            }
        }

        public StokAdjustmentModel GetData(string id)
        {
            StokAdjustmentModel result = null;
            var sSql = @"
                SELECT
                    aa.TglTrs, aa.JamTrs,aa.UserrID, aa.Keterangan,
                    aa.TglVoid, aa.JamVoid aa.UserrIDVoid
                FROM
                    StokAdjustment aa
                WHERE
                    aa.StokAdjustmentID = @StokAdjustmentID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@StokAdjustmentID", id);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        dr.Read();
                        result = new StokAdjustmentModel
                        {
                            StokAdjustmentID = id,
                            TglTrs = dr["TglTrs"].ToString().ToTglDMY(),
                            JamTrs = dr["JamTrs"].ToString(),
                            UserrID = dr["UserrID"].ToString(),
                            TglVoid = dr["TglVoid"].ToString().ToTglDMY(),
                            JamVoid = dr["JamVoid"].ToString(),
                            Keterangan = dr["Keterangan"].ToString(),
                        };
                    }
                }
            }
            return result;
        }

        public IEnumerable<StokAdjustmentModel> ListData(string tgl1, string tgl2)
        {
            List<StokAdjustmentModel> result = null;
            var sSql = @"
                SELECT
                    aa.StokAdjustmentID, 
                    aa.TglTrs, aa.JamTrs, aa.UserrID, 
                    aa.TglVoid, aa.JamVoid, aa.UserrIDVoid,
                    aa.Keterangan
                FROM
                    StokAdjustment aa 
                WHERE
                    aa.TglTrs BETWEEN @Tgl1 AND @Tgl2
                ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@Tgl1", tgl1.ToTglYMD());
                cmd.AddParam("@Tgl2", tgl2.ToTglYMD());
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        result = new List<StokAdjustmentModel>();
                        while (dr.Read())
                        {
                            var item = new StokAdjustmentModel
                            {
                                StokAdjustmentID = dr["StokAdjustmentID"].ToString(),
                                TglTrs = dr["TglTrs"].ToString().ToTglDMY(),
                                JamTrs = dr["JamTrs"].ToString(),
                                UserrID = dr["UserrID"].ToString(),
                                TglVoid = dr["TglVoid"].ToString().ToTglDMY(),
                                JamVoid = dr["JamVoid"].ToString(),
                                Keterangan = dr["Keterangan"].ToString(),
                            };
                            result.Add(item);
                        }
                    }
                }
            }
            return result;
        }
    }
}
