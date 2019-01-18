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
    public interface IStokInDal
    {
        void Insert(StokInModel stokIn);
        void Update(StokInModel stokIn);
        void Delete(string stokInID);
        StokInModel GetData(string stokInID);
        IEnumerable<StokInModel> ListData(string brgID);
        IEnumerable<StokInModel> ListDataByStokControl(string stokControlID);
    }


    public class StokInDal : IStokInDal
    {
        public string _connString;

        public StokInDal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void Insert(StokInModel stokIn)
        {
            var sSql = @"
                INSERT INTO
                    StokIn (
                        StokInID, BrgID, TglMasuk, JamMasuk, 
                        TrsMasukID, QtyIn, QtySaldo, Hpp, 
                        StokControlID, TrsDOID)
                VALUES (
                        @StokInID, @BrgID, @TglMasuk, @JamMasuk, 
                        @TrsMasukID, @QtyIn, @QtySaldo, @Hpp, 
                        @StokControlID, @TrsDOID) ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@StokInID", stokIn.StokInID);
                cmd.AddParam("@BrgID", stokIn.BrgID);
                cmd.AddParam("@TglMasuk", stokIn.TglMasuk.ToTglYMD());
                cmd.AddParam("@JamMasuk", stokIn.JamMasuk);
                cmd.AddParam("@TrsMasukID", stokIn.TrsMasukID);

                cmd.AddParam("@QtyIn", stokIn.QtyIn);
                cmd.AddParam("@QtySaldo", stokIn.QtySaldo);
                cmd.AddParam("@Hpp", stokIn.Hpp);

                cmd.AddParam("@StokControlID", stokIn.StokControlID);
                cmd.AddParam("@TrsDOID", stokIn.TrsDOID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(StokInModel stokIn)
        {
            var sSql = @"
                UPDATE
                    StokIn
                SET
                    BrgID = @BrgID,
                    TglMasuk = @TglMasuk, 
                    JamMasuk = @JamMasuk, 
                    TrsMasukID = @TrsMasukID, 
                    QtyIn = @QtyIn, 
                    QtySaldo = @QtySaldo, 
                    Hpp = @Hpp,
                    StokControlID = @StokControlID, 
                    TrsDOID = @TrsDOID
                WHERE
                    StokControlID = @StokControlID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@StokInID", stokIn.StokInID);
                cmd.AddParam("@BrgID", stokIn.BrgID);
                cmd.AddParam("@TglMasuk", stokIn.TglMasuk.ToTglYMD());
                cmd.AddParam("@JamMasuk", stokIn.JamMasuk);
                cmd.AddParam("@TrsMasukID", stokIn.TrsMasukID);

                cmd.AddParam("@QtyIn", stokIn.QtyIn);
                cmd.AddParam("@QtySaldo", stokIn.QtySaldo);
                cmd.AddParam("@Hpp", stokIn.Hpp);

                cmd.AddParam("@StokControlID", stokIn.StokControlID);
                cmd.AddParam("@TrsDOID", stokIn.TrsDOID);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string stokInID)
        {
            var sSql = @"
                DELETE
                    StokIn 
                WHERE
                    StokInID = @StokInID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@StokInID", stokInID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public StokInModel GetData(string stokInID)
        {
            StokInModel result = null;
            var sSql = @"
                SELECT
                    aa.StokInID, aa.BrgID, aa.TglMasuk, aa.JamMasuk, 
                    aa.TrsMasukID, 
                    aa.QtyIn, aa.QtySaldo, aa.Hpp,
                    aa.StokControlID, aa.TrsDOID, 
                    ISNULL(bb.BrgName, '') BrgName
                FROM
                    StokIn aa
                    LEFT JOIN Brg bb ON aa.BrgID = bb.BrgID
                WHERE
                    aa.StokInID = @StokInID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@StokInID", stokInID);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        dr.Read();
                        result = new StokInModel
                        {
                            StokInID = stokInID,
                            BrgID = dr["BrgID"].ToString(),
                            BrgName = dr["BrgName"].ToString(),
                            TglMasuk = dr["TglMasuk"].ToString().ToTglDMY(),
                            JamMasuk = dr["JamMasuk"].ToString(),
                            TrsMasukID = dr["TrsMasukID"].ToString(),
                            QtyIn = Convert.ToInt64(dr["QtyIn"]),
                            QtySaldo = Convert.ToInt64(dr["QtySaldo"]),
                            Hpp = Convert.ToDouble(dr["Hpp"]),
                            StokControlID = dr["StokControlID"].ToString(),
                            TrsDOID = dr["TrsDOID"].ToString(),
                        };
                    }
                }
            }
            return result;
        }

        public IEnumerable<StokInModel> ListData(string brgID)
        {
            List<StokInModel> result = null;
            var sSql = @"
                SELECT
                    aa.StokInID, aa.BrgID, aa.TglMasuk, aa.JamMasuk, 
                    aa.TrsMasukID, 
                    aa.QtyIn, aa.QtySaldo, aa.Hpp,
                    aa.StokControlID, aa.TrsDOID, 
                    ISNULL(bb.BrgName, '') BrgName
                FROM
                    StokIn aa
                    LEFT JOIN Brg bb ON aa.BrgID = bb.BrgID 
                WHERE
                    aa.BrgID = @BrgID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BrgID", brgID);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        result = new List<StokInModel>();
                        while (dr.Read())
                        {
                            var item = new StokInModel
                            {
                                StokInID = dr["StokInID"].ToString(),
                                BrgID = dr["BrgID"].ToString(),
                                BrgName = dr["BrgName"].ToString(),
                                TglMasuk = dr["TglMasuk"].ToString().ToTglDMY(),
                                JamMasuk = dr["JamMasuk"].ToString(),
                                TrsMasukID = dr["TrsMasukID"].ToString(),

                                QtyIn = Convert.ToInt64(dr["QtyIn"]),
                                QtySaldo = Convert.ToInt64(dr["QtySaldo"]),
                                Hpp = Convert.ToDouble(dr["Hpp"]),

                                StokControlID = dr["StokControlID"].ToString(),
                                TrsDOID = dr["TrsDOID"].ToString(),
                            };
                            result.Add(item);
                        }
                    }
                }
            }
            return result;
        }

        public IEnumerable<StokInModel> ListDataByStokControl(string stokControlID)
        {
            List<StokInModel> result = null;
            var sSql = @"
                SELECT
                    aa.StokInID, aa.BrgID, aa.TglMasuk, aa.JamMasuk, 
                    aa.TrsMasukID, 
                    aa.QtyIn, aa.QtySaldo, aa.Hpp,
                    aa.StokControlID, aa.TrsDOID, 
                    ISNULL(bb.BrgName, '') BrgName
                FROM
                    StokIn aa
                    LEFT JOIN Brg bb ON aa.BrgID = bb.BrgID 
                WHERE
                    aa.StokControlID = @StokControlID 
                    AND aa.QtySaldo <> 0
                ORDER BY
                    aa.StokInID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@StokControlID", stokControlID);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        result = new List<StokInModel>();
                        while (dr.Read())
                        {
                            var item = new StokInModel
                            {
                                StokInID = dr["StokInID"].ToString(),
                                BrgID = dr["BrgID"].ToString(),
                                BrgName = dr["BrgName"].ToString(),
                                TglMasuk = dr["TglMasuk"].ToString().ToTglDMY(),
                                JamMasuk = dr["JamMasuk"].ToString(),
                                TrsMasukID = dr["TrsMasukID"].ToString(),

                                QtyIn = Convert.ToInt64(dr["QtyIn"]),
                                QtySaldo = Convert.ToInt64(dr["QtySaldo"]),
                                Hpp = Convert.ToDouble(dr["Hpp"]),

                                StokControlID = dr["StokControlID"].ToString(),
                                TrsDOID = dr["TrsDOID"].ToString(),
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