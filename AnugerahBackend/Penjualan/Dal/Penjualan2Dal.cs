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
    public interface IPenjualan2Dal
    {
        void Insert(Penjualan2Model penjualan2);
        void Delete(string penjualanID);
        IEnumerable<Penjualan2Model> ListData(string penjualanID);
        IEnumerable<Penjualan2Model> ListDataBrg(string brgID);
    }
    public class Penjualan2Dal : IPenjualan2Dal
    {
        private string _connString;
        public Penjualan2Dal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }
        public void Insert(Penjualan2Model penjualan2)
        {
            var sSql = @"
                INSERT INTO
                    Penjualan2 (
                        PenjualanID, PenjualanID2, NoUrut, BrgID,
                        BPStokID, Qty, Harga, Diskon, SubTotal)
                VALUES (                        
                        @PenjualanID, @PenjualanID2, @NoUrut, @BrgID,
                        @BPStokID, @Qty, @Harga, @Diskon, @SubTotal) ";

            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@PenjualanID", penjualan2.PenjualanID);
                cmd.AddParam("@PenjualanID2", penjualan2.PenjualanID2);
                cmd.AddParam("@NoUrut", penjualan2.NoUrut);
                cmd.AddParam("@BrgID", penjualan2.BrgID);
                cmd.AddParam("@BPStokID", penjualan2.BPStokID);
                cmd.AddParam("@Qty", penjualan2.Qty);
                cmd.AddParam("@Harga", penjualan2.Harga);
                cmd.AddParam("@Diskon", penjualan2.Diskon);
                cmd.AddParam("@SubTotal", penjualan2.SubTotal);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string penjualanID)
        {
            var sSql = @"
                DELETE
                    Penjualan2 
                WHERE
                    PenjualanID = @PenjualanID ";

            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@PenjualanID", penjualanID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<Penjualan2Model> ListData(string penjualanID)
        {
            List<Penjualan2Model> result = null;
            var sSql = @"
                SELECT
                    aa.PenjualanID, aa.PenjualanID2, aa.NoUrut, aa.BrgID,
                    aa.BPStokID, aa.Qty, aa.Harga, aa.Diskon, aa.SubTotal,
                    ISNULL(bb.BrgName, '') BrgName
                FROM
                    Penjualan2 aa
                    LEFT JOIN Brg bb ON aa.BrgID = bb.BrgID 
                WHERE
                    aa.PenjualanID = @PenjualanID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@PenjualanID", penjualanID);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        result = new List<Penjualan2Model>();
                        while (dr.Read())
                        {
                            var item = new Penjualan2Model
                            {
                                PenjualanID = penjualanID,
                                PenjualanID2 = dr["PenjualanID2"].ToString(),
                                NoUrut = Convert.ToInt16(dr["NoUrut"]),

                                BrgID = dr["BrgID"].ToString(),
                                BPStokID = dr["BPStokID"].ToString(),
                                BrgName = dr["BrgName"].ToString(),

                                Qty = Convert.ToDecimal(dr["Qty"]),
                                Harga = Convert.ToDecimal(dr["Harga"]),
                                Diskon = Convert.ToDecimal(dr["Diskon"]),
                                SubTotal = Convert.ToDecimal(dr["SubTotal"])
                            };
                            result.Add(item);
                        }
                    }
                }
            }
            return result;
        }
        public IEnumerable<Penjualan2Model> ListDataBrg(string brgID)
        {
            List<Penjualan2Model> result = null;
            var sSql = @"
                SELECT
                    aa.PenjualanID, aa.PenjualanID2, aa.NoUrut, aa.BrgID,
                    aa.BPStokID, aa.Qty, aa.Harga, aa.Diskon, aa.SubTotal,
                    ISNULL(bb.BrgName, '') BrgName
                FROM
                    Penjualan2 aa
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
                        result = new List<Penjualan2Model>();
                        while (dr.Read())
                        {
                            var item = new Penjualan2Model
                            {
                                PenjualanID = dr["PenjualanID"].ToString(),
                                PenjualanID2 = dr["PenjualanID2"].ToString(),
                                NoUrut = Convert.ToInt16(dr["NoUrut"]),

                                BrgID = dr["BrgID"].ToString(),
                                BPStokID = dr["BPStokID"].ToString(),
                                BrgName = dr["BrgName"].ToString(),

                                Qty = Convert.ToDecimal(dr["Qty"]),
                                Harga = Convert.ToDecimal(dr["Harga"]),
                                Diskon = Convert.ToDecimal(dr["Diskon"]),
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
