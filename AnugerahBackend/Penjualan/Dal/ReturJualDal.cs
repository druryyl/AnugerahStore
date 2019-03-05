using AnugerahBackend.Penjualan.Model;
using Ics.Helper.Extensions;
using Ics.Helper.StringDateTime;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.ReturJual.Dal
{
    public interface IReturJualDal
    {
        void Insert(ReturJualModel returJual);
        void Update(ReturJualModel returJual);
        void Delete(string returJualID);
        ReturJualModel GetData(string returJualID);
        IEnumerable<ReturJualModel> ListData(string tgl1, string tgl2);
    }

    public class ReturJualDal : IReturJualDal
    {
        private string _connString;

        public ReturJualDal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void Insert(ReturJualModel returJual)
        {
            var sSql = @"
                INSERT INTO
                    ReturJual(
                        ReturJualID, Tgl, Jam, PenjualanID, 
                        BuyerName, Keterangan, TotalRetur )
                VALUES (
                        @ReturJualID, @Tgl, @Jam, @PenjualanID, 
                        @BuyerName, @Keterangan, @TotalRetur ) ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@ReturJualID", returJual.ReturJualID);
                cmd.AddParam("@Tgl", returJual.Tgl.ToTglYMD());
                cmd.AddParam("@Jam", returJual.Jam);
                cmd.AddParam("@PenjualanID", returJual.PenjualanID);
                cmd.AddParam("@BuyerName", returJual.BuyerName);
                cmd.AddParam("@Keterangan", returJual.Keterangan);
                cmd.AddParam("@TotalRetur", returJual.TotalRetur);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(ReturJualModel returJual)
        {
            var sSql = @"
                UPDATE
                    ReturJual
                SET
                    Tgl = @Tgl, 
                    Jam = @Jam,
                    PenjualanID = @PenjualanID, 
                    BuyerName = @BuyerName,
                    Keterangan = @Keterangan, 
                    TotalRetur = @TotalRetur 
                WHERE
                    ReturJualID = @ReturJualID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@ReturJualID", returJual.ReturJualID);
                cmd.AddParam("@Tgl", returJual.Tgl.ToTglYMD());
                cmd.AddParam("@Jam", returJual.Jam);

                cmd.AddParam("@PenjualanID", returJual.PenjualanID);
                cmd.AddParam("@BuyerName", returJual.BuyerName);
                cmd.AddParam("@Keterangan", returJual.Keterangan);
                cmd.AddParam("@TotalRetur", returJual.TotalRetur);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string returJualID)
        {
            var sSql = @"
                DELETE
                    ReturJual
                WHERE
                    ReturJualID = @ReturJualID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@ReturJualID", returJualID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public ReturJualModel GetData(string returJualID)
        {
            ReturJualModel result = null;
            var sSql = @"
                SELECT
                    ReturJualID, Tgl, Jam, PenjualanID, 
                    BuyerName, Keterangan, TotalRetur
                FROM
                    ReturJual
                WHERE
                    ReturJualID = @ReturJualID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@ReturJualID", returJualID);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        dr.Read();
                        result = new ReturJualModel
                        {
                            ReturJualID = dr["ReturJualID"].ToString(),
                            Tgl = dr["Tgl"].ToString().ToTglDMY(),
                            Jam = dr["Jam"].ToString(),

                            PenjualanID = dr["PenjualanID"].ToString(),
                            BuyerName = dr["BuyerName"].ToString(),
                            Keterangan = dr["Keterangan"].ToString(),
                            TotalRetur = Convert.ToDecimal(dr["TotalRetur"]),
                        };

                    }
                }
            }
            return result;
        }

        public IEnumerable<ReturJualModel> ListData(string tgl1, string tgl2)
        {
            List<ReturJualModel> result = null;
            var sSql = @"
                 SELECT
                    ReturJualID, Tgl, Jam, PenjualanID, 
                    BuyerName, Keterangan, TotalRetur
                FROM
                    ReturJual
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
                    if (dr.HasRows)
                    {
                        result = new List<ReturJualModel>();
                        while (dr.Read())
                        {
                            var item = new ReturJualModel
                            {
                                ReturJualID = dr["ReturJualID"].ToString(),
                                Tgl = dr["Tgl"].ToString().ToTglDMY(),
                                Jam = dr["Jam"].ToString(),

                                PenjualanID = dr["PenjualanID"].ToString(),
                                BuyerName = dr["BuyerName"].ToString(),
                                Keterangan = dr["Keterangan"].ToString(),
                                TotalRetur = Convert.ToDecimal(dr["TotalRetur"]),
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
