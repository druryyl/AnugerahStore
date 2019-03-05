using AnugerahBackend.Penjualan.Model;
using Ics.Helper.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Penjualan.Dal
{
    public interface IReturJualDetilDal
    {
        void Insert(ReturJualDetilModel returJualDetil);
        void Delete(string penjualanID);
        IEnumerable<ReturJualDetilModel> ListData(string penjualanID);
    }
    public class ReturJualDetilDal : IReturJualDetilDal
    {
        private string _connString;
        public ReturJualDetilDal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }
        public void Insert(ReturJualDetilModel returJualDetil)
        {
            var sSql = @"
                INSERT INTO
                    ReturJualDetil (
                        ReturJualID, ReturJualDetilID, BrgID, NoUrut, 
                        QtySisa, QtyRetur, HargaRetur, SubTotal)
                VALUES (                        
                        @ReturJualID, @ReturJualDetilID, @BrgID, @NoUrut, 
                        @QtySisa, @QtyRetur, @HargaRetur, @SubTotal) ";

            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@ReturJualID", returJualDetil.ReturJualID);
                cmd.AddParam("@ReturJualDetilID", returJualDetil.ReturJualDetilID);
                cmd.AddParam("@NoUrut", returJualDetil.NoUrut);
                cmd.AddParam("@BrgID", returJualDetil.BrgID);
                cmd.AddParam("@QtySisa", returJualDetil.QtySisa);
                cmd.AddParam("@QtyRetur", returJualDetil.QtyRetur);
                cmd.AddParam("@Harga", returJualDetil.HargaRetur);
                cmd.AddParam("@SubTotal", returJualDetil.SubTotal);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string returJualID)
        {
            var sSql = @"
                DELETE
                    ReturJualDetil 
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

        public IEnumerable<ReturJualDetilModel> ListData(string returJualID)
        {
            List<ReturJualDetilModel> result = null;
            var sSql = @"
                SELECT
                    aa.ReturJualID, aa.ReturJualID2, aa.NoUrut, aa.BrgID,
                    aa.Qty, aa.Harga, aa.Diskon, aa.SubTotal,
                    ISNULL(bb.BrgName, '') BrgName
                FROM
                    ReturJualDetil aa
                    LEFT JOIN Brg bb ON aa.BrgID = bb.BrgID 
                WHERE
                    aa.ReturJualID = @ReturJualID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@ReturJualID", returJualID);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        result = new List<ReturJualDetilModel>();
                        while (dr.Read())
                        {
                            var item = new ReturJualDetilModel
                            {
                                ReturJualID = returJualID,
                                ReturJualDetilID = dr["ReturJualDetilID"].ToString(),
                                NoUrut = Convert.ToInt16(dr["NoUrut"]),

                                BrgID = dr["BrgID"].ToString(),
                                BrgName = dr["BrgName"].ToString(),
                                QtySisa = Convert.ToInt32(dr["QtySisa"]),
                                QtyRetur = Convert.ToInt32(dr["QtyRetur"]),
                                HargaRetur = Convert.ToDecimal(dr["HargaRetur"]),
                                SubTotal = Convert.ToDecimal(dr["SubTotal"])
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
