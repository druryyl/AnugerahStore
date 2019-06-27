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
    public interface IOrderJual2Dal
    {
        void Insert(OrderJual2Model orderJual2);
        void Delete(string orderJualID);
        IEnumerable<OrderJual2Model> ListData(string orderJualID);
    }
    public class OrderJual2Dal : IOrderJual2Dal
    {
        private string _connString;
        public OrderJual2Dal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }
        public void Insert(OrderJual2Model orderJual2)
        {
            var sSql = @"
                INSERT INTO
                    OrderJual2 (
                        OrderJualID, OrderJualID2, NoUrut, BrgID,
                        BPStokID, Qty, Harga, Diskon, SubTotal)
                VALUES (                        
                        @OrderJualID, @OrderJualID2, @NoUrut, @BrgID,
                        @BPStokID, @Qty, @Harga, @Diskon, @SubTotal) ";

            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@OrderJualID", orderJual2.OrderJualID);
                cmd.AddParam("@OrderJualID2", orderJual2.OrderJualID2);
                cmd.AddParam("@NoUrut", orderJual2.NoUrut);
                cmd.AddParam("@BrgID", orderJual2.BrgID);
                cmd.AddParam("@BPStokID", orderJual2.BPStokID);
                cmd.AddParam("@Qty", orderJual2.Qty);
                cmd.AddParam("@Harga", orderJual2.Harga);
                cmd.AddParam("@Diskon", orderJual2.Diskon);
                cmd.AddParam("@SubTotal", orderJual2.SubTotal);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string orderJualID)
        {
            var sSql = @"
                DELETE
                    OrderJual2 
                WHERE
                    OrderJualID = @OrderJualID ";

            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@OrderJualID", orderJualID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<OrderJual2Model> ListData(string orderJualID)
        {
            List<OrderJual2Model> result = null;
            var sSql = @"
                SELECT
                    aa.OrderJualID, aa.OrderJualID2, aa.NoUrut, aa.BrgID,
                    aa.BPStokID, aa.Qty, aa.Harga, aa.Diskon, aa.SubTotal,
                    ISNULL(bb.BrgName, '') BrgName
                FROM
                    OrderJual2 aa
                    LEFT JOIN Brg bb ON aa.BrgID = bb.BrgID 
                WHERE
                    aa.OrderJualID = @OrderJualID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@OrderJualID", orderJualID);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        result = new List<OrderJual2Model>();
                        while (dr.Read())
                        {
                            var item = new OrderJual2Model
                            {
                                OrderJualID = orderJualID,
                                OrderJualID2 = dr["OrderJualID2"].ToString(),
                                NoUrut = Convert.ToInt16(dr["NoUrut"]),

                                BrgID = dr["BrgID"].ToString(),
                                BPStokID = dr["BPStokID"].ToString(),
                                BrgName = dr["BrgName"].ToString(),

                                Qty = Convert.ToInt32(dr["Qty"]),
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
