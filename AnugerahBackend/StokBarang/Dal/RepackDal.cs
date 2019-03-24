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
    public interface IRepackDal
    {
        void Insert(RepackModel model);
        void Update(RepackModel model);
        void Delete(string id);
        RepackModel GetData(string id);
        IEnumerable<RepackModel> ListData(string tgl1, string tgl2);
    }
    public class RepackDal : IRepackDal
    {
        private readonly string _connString;

        public RepackDal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void Insert(RepackModel model)
        {
            var sSql = @"
                INSERT INTO
                    Repack (
                        RepackID, Tgl, Jam, BPStokID, 
                        BrgIDMaterial, QtyMaterial, HppMaterial,
                        BrgIDHasil, SlotControl, QtyHasil, HppHasil)
                VALUES (
                        @RepackID, @Tgl, @Jam, @BPStokID,  
                        @BrgIDMaterial, @QtyMaterial, @HppMaterial,
                        @BrgIDHasil, @SlotControl, @QtyHasil, @HppHasil) ";

            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@RepackID", model.RepackID);
                cmd.AddParam("@Tgl", model.Tgl.ToTglYMD());
                cmd.AddParam("@Jam", model.Jam);
                cmd.AddParam("@BPStokID", model.BPStokID);

                cmd.AddParam("BrgIDMaterial", model.BrgIDMaterial);
                cmd.AddParam("@QtyMaterial", model.QtyMaterial);
                cmd.AddParam("@HppMaterial", model.HppMaterial);

                cmd.AddParam("BrgIDHasil", model.BrgIDHasil);
                cmd.AddParam("@QtyHasil", model.QtyHasil);
                cmd.AddParam("@HppHasil", model.HppHasil);
                cmd.AddParam("@SlotControl", model.SlotControl);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(RepackModel model)
        {
            var sSql = @"
                UPDATE
                    Repack 
                SET
                    Tgl = @Tgl, 
                    Jam = @Jam, 
                    BPStokID = @BPStokID, 
                    BrgIDMaterial = @BrgIDMaterial, 
                    QtyMaterial = @QtyMaterial, 
                    HppMaterial = @HppMaterial, 
                    BrgIDHasil = @BrgIDHasil, 
                    SlotControl = @SlotControl,
                    QtyHasil = @QtyHasil, 
                    HppHasil = @HppHasil, 
                WHERE
                    RepackID = @RepackID ";

            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@RepackID", model.RepackID);
                cmd.AddParam("@Tgl", model.Tgl.ToTglYMD());
                cmd.AddParam("@Jam", model.Jam);
                cmd.AddParam("@BPStokID", model.BPStokID);
                cmd.AddParam("BrgIDMaterial", model.BrgIDMaterial);
                cmd.AddParam("@QtyMaterial", model.QtyMaterial);
                cmd.AddParam("@HppMaterial", model.HppMaterial);
                cmd.AddParam("BrgIDHasil", model.BrgIDHasil);
                cmd.AddParam("SlotControl", model.SlotControl);
                cmd.AddParam("@QtyHasil", model.QtyHasil);
                cmd.AddParam("@HppHasil", model.HppHasil);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string id)
        {
            var sSql = @"
                DELETE
                    Repack 
                WHERE
                    RepackID = @RepackID ";

            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@RepackID", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public RepackModel GetData(string id)
        {
            RepackModel result = null;

            var sSql = @"
                SELECT
                    aa.RepackID, aa.Tgl, aa.Jam, aa.BPStokID, 
                    aa.BrgIDMaterial, aa.QtyMaterial, aa.HppMaterial,
                    aa.BrgIDHasil, aa.SlotControl, aa.QtyHasil, aa.HppHasil,
                    ISNULL(bb.BrgName, '') BrgNameMaterial,
                    ISNULL(cc.BrgName, '') BrgNameHasil
                FROM
                    Repack aa
                    LEFT JOIN Brg bb ON aa.BrgIDMaterial = bb.BrgID
                    LEFT JOIN Brg cc ON aa.BrgIDHasil = cc.BrgID
                WHERE
                    RepackID = @RepackID ";

            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@RepackID", id);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (!dr.HasRows) return null;
                    dr.Read();
                    result = new RepackModel
                    {
                        RepackID = dr["RepackID"].ToString(),
                        Tgl = dr["Tgl"].ToString().ToTglDMY(),
                        Jam = dr["Jam"].ToString(),
                        BPStokID = dr["BPStokID"].ToString(),

                        BrgIDMaterial = dr["BrgIDMaterial"].ToString(),
                        BrgNameMaterial = dr["BrgNameMaterial"].ToString(),
                        QtyMaterial = Convert.ToInt64(dr["QtyMaterial"]),
                        HppMaterial = Convert.ToDecimal(dr["HppMaterial"]),

                        BrgIDHasil = dr["BrgIDHasil"].ToString(),
                        BrgNameHasil = dr["BrgNameHasil"].ToString(),
                        SlotControl = dr["SlotCOntrol"].ToString(),
                        QtyHasil = Convert.ToInt64(dr["QtyHasil"]),
                        HppHasil = Convert.ToDecimal(dr["HppHasil"])
                    };
                }
                cmd.ExecuteNonQuery();
            }
            return result;
        }

        public IEnumerable<RepackModel> ListData(string tgl1, string tgl2)
        {
            List<RepackModel> result = null;
            
            var sSql = @"
                SELECT
                    aa.RepackID, aa.Tgl, aa.Jam, aa.BPStokID, 
                    aa.BrgIDMaterial, aa.QtyMaterial, aa.HppMaterial,
                    aa.BrgIDHasil, aa.SlotControl, aa.QtyHasil, aa.HppHasil,
                    ISNULL(bb.BrgName, '') BrgNameMaterial,
                    ISNULL(cc.BrgName, '') BrgNameHasil
                FROM
                    Repack aa
                    LEFT JOIN Brg bb ON aa.BrgIDMaterial = bb.BrgID
                    LEFT JOIN Brg cc ON aa.BrgIDHasil = cc.BrgID
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
                    result = new List<RepackModel>();
                    while (dr.Read())
                    {
                        var item =  new RepackModel
                        {
                            RepackID = dr["RepackID"].ToString(),
                            Tgl = dr["Tgl"].ToString().ToTglDMY(),
                            Jam = dr["Jam"].ToString(),
                            BPStokID = dr["BPStokID"].ToString(),

                            BrgIDMaterial = dr["BrgIDMaterial"].ToString(),
                            BrgNameMaterial = dr["BrgNameMaterial"].ToString(),
                            QtyMaterial = Convert.ToInt64(dr["QtyMaterial"]),
                            HppMaterial = Convert.ToDecimal(dr["HppMaterial"]),

                            BrgIDHasil = dr["BrgIDHasil"].ToString(),
                            BrgNameHasil = dr["BrgNameHasil"].ToString(),
                            SlotControl = dr["SlotControl"].ToString(),
                            QtyHasil = Convert.ToInt64(dr["QtyHasil"]),
                            HppHasil = Convert.ToDecimal(dr["HppHasil"])
                        };
                        result.Add(item);
                    }
                }
            }
            return result;
        }
    }
}
