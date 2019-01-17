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
    public interface IStokControlDal
    {
        void Insert(StokControlModel stokControl);
        void Update(StokControlModel stokControl);
        void Delete(string stokControlID);
        StokControlModel GetData(string stokControlID);
        IEnumerable<StokControlModel> ListData();
    }


    public class StokControlDal : IStokControlDal
    {
        public string _connString;

        public StokControlDal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void Insert(StokControlModel stok)
        {
            var sSql = @"
                INSERT INTO
                    StokControl (
                        StokControlID, BrgID, TglMasuk, JamMasuk, 
                        TrsMasukID, TrsDOID, BatchNo, 
                        QtyIn, QtySaldo, Hpp)
                VALUES (
                        @StokControlID, @BrgID, @TglMasuk, @JamMasuk, 
                        @TrsMasukID, @TrsDOID, @BatchNo, 
                        @QtyIn, @QtySaldo, @Hpp) ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@StokControlID", stok.StokControlID);
                cmd.AddParam("@BrgID", stok.BrgID);
                cmd.AddParam("@TglMasuk", stok.TglMasuk.ToTglYMD());
                cmd.AddParam("@JamMasuk", stok.JamMasuk);
                cmd.AddParam("@TrsMasukID", stok.TrsMasukID);
                cmd.AddParam("@TrsDOID", stok.TrsDOID);
                cmd.AddParam("@BatchNo", stok.BatchNo);
                cmd.AddParam("@QtyIn", stok.QtyIn);
                cmd.AddParam("@QtySaldo", stok.QtySaldo);
                cmd.AddParam("@Hpp", stok.Hpp);

                cmd.ExecuteNonQuery();
            }
        }

        public void Update(StokControlModel stok)
        {
            var sSql = @"
                UPDATE
                    StokControl,
                SET
                    BrgID = @BrgID
                    TglMasuk = @TglMasuk, 
                    JamMasuk = @JamMasuk, 
                    TrsMasukID = @TrsMasukID, 
                    TrsDOID = @TrsDOID, 
                    BatchNo = @BatchNo, 
                    QtyIn = @QtyIn, 
                    QtySaldo = @QtySaldo, 
                    Hpp = @Hpp
                WHERE
                    StokControlID = @StokControlID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@StokControlID", stok.StokControlID);
                cmd.AddParam("@BrgID", stok.BrgID);
                cmd.AddParam("@TglMasuk", stok.TglMasuk.ToTglYMD());
                cmd.AddParam("@JamMasuk", stok.JamMasuk);
                cmd.AddParam("@TrsMasukID", stok.TrsMasukID);
                cmd.AddParam("@TrsDOID", stok.TrsDOID);
                cmd.AddParam("@BatchNo", stok.BatchNo);
                cmd.AddParam("@QtyIn", stok.QtyIn);
                cmd.AddParam("@QtySaldo", stok.QtySaldo);
                cmd.AddParam("@Hpp", stok.Hpp);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string id)
        {
            var sSql = @"
                DELETE
                    StokControl 
                WHERE
                    StokControlID = @StokControlID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@StokControlID", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public StokControlModel GetData(string id)
        {
            StokControlModel result = null;
            var sSql = @"
                SELECT
                    aa.StokControlID, aa.BrgID, aa.TglMasuk, aa.JamMasuk, 
                    aa.TrsMasukID, aa.TrsDOID, aa.BatchNo, 
                    aa.QtyIn, aa.QtySaldo, aa.Hpp,
                    ISNULL(bb.BrgName, '') BrgName
                FROM
                    StokControl aa
                    LEFT JOIN Brg bb ON aa.BrgID = bb.BrgID
                WHERE
                    aa.StokControlID = @StokControlID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@StokID", id);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        dr.Read();
                        result = new StokControlModel
                        {
                            StokControlID = id,
                            BrgID = dr["BrgID"].ToString(),
                            BrgName = dr["BrgName"].ToString(),
                            TglMasuk = dr["TglMasuk"].ToString().ToTglDMY(),
                            JamMasuk = dr["JamMasuk"].ToString(),
                            TrsMasukID = dr["TrsMasukID"].ToString(),
                            TrsDOID = dr["TrsDOID"].ToString(),
                            BatchNo = dr["BatchNo"].ToString(),
                            QtyIn = Convert.ToInt64(dr["QtyIn"]),
                            QtySaldo = Convert.ToInt64(dr["QtyOut"]),
                            Hpp = Convert.ToDouble(dr["Hpp"])
                        };
                    }
                }
            }
            return result;
        }

        public IEnumerable<StokControlModel> ListData()
        {
            List<StokControlModel> result = null;
            var sSql = @"
                SELECT
                    aa.StokControlID, aa.BrgID, aa.TglMasuk, aa.JamMasuk, 
                    aa.TrsMasukID, aa.TrsDOID, aa.BatchNo, 
                    aa.QtyIn, aa.QtySaldo, aa.Hpp,
                    ISNULL(bb.BrgName, '') BrgName
                FROM
                    Stok aa
                    LEFT JOIN Brg bb ON aa.BrgID = bb.BrgID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        result = new List<StokControlModel>();
                        while (dr.Read())
                        {
                            var item = new StokControlModel
                            {
                                StokControlID = dr["StokControlID"].ToString(),
                                BrgID = dr["BrgID"].ToString(),
                                BrgName = dr["BrgName"].ToString(),
                                TglMasuk = dr["TglMasuk"].ToString().ToTglDMY(),
                                JamMasuk = dr["JamMasuk"].ToString(),
                                TrsMasukID = dr["TrsMasukID"].ToString(),
                                TrsDOID = dr["TrsDOID"].ToString(),
                                BatchNo = dr["BatchNo"].ToString(),
                                QtyIn = Convert.ToInt64(dr["QtyIn"]),
                                QtySaldo = Convert.ToInt64(dr["QtyOut"]),
                                Hpp = Convert.ToDouble(dr["Hpp"])
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