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
    public interface IStokDal
    {
        void Insert(StokModel stok);
        void Update(StokModel stok);
        void Delete(string stokID);
        StokModel GetData(string stokID);
        IEnumerable<StokModel> ListData();
    }


    public class StokDal : IStokDal
    {
        public string _connString;

        public StokDal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void Insert(StokModel stok)
        {
            var sSql = @"
                INSERT INTO
                    Stok (
                        StokID, BrgID, TglMasuk, JamMasuk, 
                        TrsMasukID, TrsDOID, BatchNo, 
                        QtyIn, QtySaldo, Hpp)
                VALUES (
                        @StokID, @BrgID, @TglMasuk, @JamMasuk, 
                        @TrsMasukID, @TrsDOID, @BatchNo, 
                        @QtyIn, @QtySaldo, @Hpp) ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@StokID", stok.StokID);
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

        public void Update(StokModel stok)
        {
            var sSql = @"
                UPDATE
                    Stok,
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
                    StokID = @StokID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@StokID", stok.StokID);
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
                    Stok 
                WHERE
                    StokID = @StokID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@StokID", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public StokModel GetData(string id)
        {
            StokModel result = null;
            var sSql = @"
                SELECT
                    aa.BrgID
                FROM
                    Stok aa
                WHERE
                    aa.StokID = @StokID ";
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
                        result = new StokModel
                        {
                            StokID = id,
                            BrgID = dr["BrgID"].ToString()
                        };
                    }
                }
            }
            return result;
        }

        public IEnumerable<StokModel> ListData()
        {
            List<StokModel> result = null;
            var sSql = @"
                SELECT
                    aa.StokID, aa.BrgID
                FROM
                    Stok aa ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        result = new List<StokModel>();
                        while (dr.Read())
                        {
                            var item = new StokModel
                            {
                                StokID = dr["StokID"].ToString(),
                                BrgID = dr["BrgID"].ToString()
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
