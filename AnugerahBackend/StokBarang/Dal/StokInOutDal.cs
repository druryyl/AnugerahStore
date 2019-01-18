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
    public interface IStokInOutDal
    {
        void Insert(StokInOutModel stokInOut);
        void Delete(string stokInOutID);
        StokInOutModel GetData(string stokInOutID);
        IEnumerable<StokInOutModel> ListData(string stokInOut);
    }

    public class StokInOutDal : IStokInOutDal
    {
        public string _connString;

        public StokInOutDal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void Insert(StokInOutModel stokInOut)
        {
            var sSql = @"
                INSERT INTO
                    StokInOut (
                        StokInID, StokInOutID, TglTrs, JamTrs, ReffTrsID,
                        JenisMutasiID, BrgID, StokControlID, 
                        QtyIn, QtyOut, Hpp, HargaJual)
                VALUES (
                        @StokInID, @StokInOutID, @TglTrs, @JamTrs, @ReffTrsID,
                        @JenisMutasiID, @BrgID, @StokControlID, 
                        @QtyIn, @QtyOut, @Hpp, @HargaJual) ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@StokInID", stokInOut.StokInID);
                cmd.AddParam("@StokInOutID", stokInOut.StokInOutID);

                cmd.AddParam("@TglTrs", stokInOut.TglTrs);
                cmd.AddParam("@JamTrs", stokInOut.JamTrs);
                cmd.AddParam("@ReffTrsID", stokInOut.ReffTrsID);
                cmd.AddParam("@JenisMutasiID", stokInOut.JenisMutasiID);

                cmd.AddParam("@BrgID", stokInOut.BrgID);
                cmd.AddParam("@StokControlID", stokInOut.StokControlID);

                cmd.AddParam("@QtyIn", stokInOut.QtyIn);
                cmd.AddParam("@QtyOut", stokInOut.QtyOut);
                cmd.AddParam("@Hpp", stokInOut.Hpp);
                cmd.AddParam("@HargaJual", stokInOut.HargaJual);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string stokInOutID)
        {
            var sSql = @"
                DELETE
                    StokControl2
                WHERE
                    StokDetilID = @StokDetilID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@StokControl2ID", stokInOutID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public StokInOutModel GetData(string stokInOutID)
        {
            StokInOutModel result = null;
            var sSql = @"
                SELECT
                    aa.StoInID, aa.StokInOutID, aa.TglTrs, aa.JamTrs, 
                    aa.ReffTrsID, aa.JenisMutasiID, 
                    aa.BrgID, aa.StokControlID, 
                    aa.QtyIn, aa.QtyOut, aa.Hpp, aa.HargaJual,
                    ISNULL(bb.BrgName, '') BrgName, 
                    ISNULL(cc.JenisMutasiName, '') JenisMutasiName
                FROM
                    StokControl2 aa
                    LEFT JOIN Brg bb ON aa.BrgId = bb.BrgID
                    LEFT JOIN JenisMutasi cc ON aa.JenisMutasiID = cc.JenisMutasiID
                WHERE
                    StokInOutID = @StokInOutID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@StokInOutID", stokInOutID);
                conn.Open();
                var dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    result = new StokInOutModel
                    {
                        StokInID = stokInOutID,
                        StokInOutID = dr["StokID"].ToString(),
                        TglTrs = dr["TglTrs"].ToString().ToTglDMY(),
                        JamTrs = dr["JamTrs"].ToString(),
                        ReffTrsID = dr["ReffTrsID"].ToString(),
                        JenisMutasiID = dr["JenisMutasiID"].ToString(),
                        JenisMutasiName = dr["JenisMutasiName"].ToString(),

                        BrgID = dr["BrgID"].ToString(),
                        BrgName = dr["BrgName"].ToString(),
                        StokControlID = dr["StokControlID"].ToString(),

                        QtyIn = Convert.ToInt64(dr["QtyIn"]),
                        QtyOut = Convert.ToInt64(dr["QtyOut"]),
                        Hpp = Convert.ToDouble(dr["Hpp"]),
                        HargaJual = Convert.ToDouble(dr["HargaJual"])
                    };
                }
            }
            return result;
        }

        public IEnumerable<StokInOutModel> ListData(string stokInID)
        {
            List<StokInOutModel> result = null;
            var sSql = @"
                SELECT
                    aa.StoInID, aa.StokInOutID, aa.TglTrs, aa.JamTrs, 
                    aa.ReffTrsID, aa.JenisMutasiID, 
                    aa.BrgID, aa.StokControlID, 
                    aa.QtyIn, aa.QtyOut, aa.Hpp, aa.HargaJual,
                    ISNULL(bb.BrgName, '') BrgName, 
                    ISNULL(cc.JenisMutasiName, '') JenisMutasiName
                FROM
                    StokControl2 aa
                    LEFT JOIN Brg bb ON aa.BrgId = bb.BrgID
                    LEFT JOIN JenisMutasi cc ON aa.JenisMutasiID = cc.JenisMutasiID
                WHERE
                    StokInID = @StokInID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@StokInID", stokInID);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        result = new List<StokInOutModel>();
                        while (dr.Read())
                        {
                            var item = new StokInOutModel
                            {
                                StokInID = dr["stokControl2ID"].ToString(),
                                StokInOutID= dr["StokID"].ToString(),
                                TglTrs = dr["TglTrs"].ToString().ToTglDMY(),
                                JamTrs = dr["JamTrs"].ToString(),
                                ReffTrsID = dr["ReffTrsID"].ToString(),
                                JenisMutasiID = dr["JenisMutasiID"].ToString(),
                                JenisMutasiName = dr["JenisMutasiName"].ToString(),

                                BrgID = dr["BrgID"].ToString(),
                                BrgName = dr["BrgName"].ToString(),
                                StokControlID = dr["StokControlID"].ToString(),

                                QtyIn = Convert.ToInt64(dr["QtyIn"]),
                                QtyOut = Convert.ToInt64(dr["QtyOut"]),
                                Hpp= Convert.ToDouble(dr["Hpp"]),
                                HargaJual = Convert.ToDouble(dr["HargaJual"])
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
