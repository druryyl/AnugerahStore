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

namespace AnugerahBackend.Penjualan.Dal
{
    public interface IOrderJualDal
    {
        void Insert(OrderJualModel orderJual);
        void Update(OrderJualModel orderJual);
        void Delete(string orderJualID);
        OrderJualModel GetData(string orderJualID);
        IEnumerable<OrderJualModel> ListData(string tgl1, string tgl2);
    }

    public class OrderJualDal : IOrderJualDal
    {
        private string _connString;

        public OrderJualDal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void Insert(OrderJualModel orderJual)
        {
            var sSql = @"
                INSERT INTO
                    OrderJual(
                        OrderJualID, TglOrderJual, JamOrderJual, BuyerName,
                        CustomerID, Alamat, NoTelp, Catatan, 
                        IsBayarDeposit, DepositID, NilaiDeposit, 
                        NilaiTotal, NilaiDiskonLain, NilaiBiayaLain, 
                        NilaiGrandTotal, NilaiBayar, NilaiKembali)
                VALUES (
                        @OrderJualID, @TglOrderJual, @JamOrderJual, @BuyerName,
                        @CustomerID, @Alamat, @NoTelp, @Catatan,
                        @IsBayarDeposit, @DepositID, @NilaiDeposit, 
                        @NilaiTotal, @NilaiDiskonLain, @NilaiBiayaLain, 
                        @NilaiGrandTotal, @NilaiBayar, @NilaiKembali) ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@OrderJualID", orderJual.OrderJualID);
                cmd.AddParam("@TglOrderJual", orderJual.TglOrderJual.ToTglYMD());
                cmd.AddParam("@JamOrderJual", orderJual.JamOrderJual);
                cmd.AddParam("@BuyerName", orderJual.BuyerName);
                cmd.AddParam("@CustomerID", orderJual.CustomerID);
                cmd.AddParam("@Alamat", orderJual.Alamat);
                cmd.AddParam("@NoTelp", orderJual.NoTelp);
                cmd.AddParam("@Catatan", orderJual.Catatan);
                cmd.AddParam("@NilaiTotal", orderJual.NilaiTotal);
                cmd.AddParam("@NilaiDiskonLain", orderJual.NilaiDiskonLain);
                cmd.AddParam("@NilaiBiayaLain", orderJual.NilaiBiayaLain);
                cmd.AddParam("@NilaiGrandTotal", orderJual.NilaiGrandTotal);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(OrderJualModel orderJual)
        {
            var sSql = @"
                UPDATE
                    OrderJual
                SET
                    TglOrderJual = @TglOrderJual, 
                    JamOrderJual = @JamOrderJual, 
                    BuyerName = @BuyerName,
                    CustomerID = @CustomerID, 
                    Alamat = @Alamat, 
                    NoTelp = @NoTelp, 
                    Catatan = @Catatan,
                    IsBayarDeposit = @IsBayarDeposit,
                    DepositID = @DepositID, 
                    NilaiDeposit = @NilaiDeposit, 
    
                    NilaiTotal = @NilaiTotal, 
                    NilaiDiskonLain = @NilaiDiskonLain,
                    NilaiBiayaLain = @NilaiBiayaLain, 
                    NilaiGrandTotal = @NilaiGrandTotal,
                    NilaiBayar = @NilaiBayar,
                    NilaiKembali = @NilaiKembali
                WHERE
                    OrderJualID = @OrderJualID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@OrderJualID", orderJual.OrderJualID);
                cmd.AddParam("@TglOrderJual", orderJual.TglOrderJual.ToTglYMD());
                cmd.AddParam("@JamOrderJual", orderJual.JamOrderJual);
                cmd.AddParam("@BuyerName", orderJual.BuyerName);
                cmd.AddParam("@CustomerID", orderJual.CustomerID);
                cmd.AddParam("@Alamat", orderJual.Alamat);
                cmd.AddParam("@NoTelp", orderJual.NoTelp);
                cmd.AddParam("@Catatan", orderJual.Catatan);
                cmd.AddParam("@NilaiTotal", orderJual.NilaiTotal);
                cmd.AddParam("@NilaiDiskonLain", orderJual.NilaiDiskonLain);
                cmd.AddParam("@NilaiBiayaLain", orderJual.NilaiBiayaLain);
                cmd.AddParam("@NilaiGrandTotal", orderJual.NilaiGrandTotal);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string orderJualID)
        {
            var sSql = @"
                DELETE
                    OrderJual
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

        public OrderJualModel GetData(string orderJualID)
        {
            OrderJualModel result = null;
            var sSql = @"
                SELECT
                    OrderJualID, TglOrderJual, JamOrderJual, BuyerName,
                    CustomerID, Alamat, NoTelp, Catatan, IsBayarDeposit, DepositID, 
                    NilaiTotal, NilaiDiskonLain, NilaiDeposit, 
                    NilaiBiayaLain, NilaiGrandTotal, NilaiBayar, NilaiKembali
                FROM
                    OrderJual
                WHERE
                    OrderJualID = @OrderJualID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@OrderJualID", orderJualID);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        dr.Read();
                        result = new OrderJualModel
                        {
                            OrderJualID = dr["OrderJualID"].ToString(),
                            TglOrderJual = dr["TglOrderJual"].ToString().ToTglDMY(),
                            JamOrderJual = dr["JamOrderJual"].ToString(),

                            BuyerName = dr["BuyerName"].ToString(),
                            CustomerID = dr["CustomerID"].ToString(),
                            Alamat = dr["Alamat"].ToString(),
                            NoTelp = dr["NoTelp"].ToString(),
                            Catatan = dr["Catatan"].ToString(),

                            NilaiTotal = Convert.ToDecimal(dr["NilaiTotal"]),
                            NilaiDiskonLain = Convert.ToDecimal(dr["NilaiDiskonLain"]),
                            NilaiBiayaLain = Convert.ToDecimal(dr["NilaiBiayaLain"]),
                            NilaiGrandTotal = Convert.ToDecimal(dr["NilaiGrandTotal"]),
                        };

                    }
                }
            }
            return result;
        }

        public IEnumerable<OrderJualModel> ListData(string tgl1, string tgl2)
        {
            List<OrderJualModel> result = null;
            var sSql = @"
                SELECT
                    OrderJualID, TglOrderJual, JamOrderJual, BuyerName,
                    CustomerID, Alamat, NoTelp, Catatan, 
                    IsBayarDeposit, DepositID, NilaiDeposit, 
                    NilaiTotal, NilaiDiskonLain,
                    NilaiBiayaLain, NilaiGrandTotal, NilaiBayar, NilaiKembali
                FROM
                    OrderJual
                WHERE
                    TglOrderJual BETWEEN @Tgl1 AND @Tgl2 ";
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
                        result = new List<OrderJualModel>();
                        while (dr.Read())
                        {
                            var item = new OrderJualModel
                            {
                                OrderJualID = dr["OrderJualID"].ToString(),
                                TglOrderJual = dr["TglOrderJual"].ToString().ToTglDMY(),
                                JamOrderJual = dr["JamOrderJual"].ToString(),

                                BuyerName = dr["BuyerName"].ToString(),
                                CustomerID = dr["CustomerID"].ToString(),
                                Alamat = dr["Alamat"].ToString(),
                                NoTelp = dr["NoTelp"].ToString(),
                                Catatan = dr["Catatan"].ToString(),

                                NilaiTotal = Convert.ToDecimal(dr["NilaiTotal"]),
                                NilaiDiskonLain = Convert.ToDecimal(dr["NilaiDiskonLain"]),
                                NilaiBiayaLain = Convert.ToDecimal(dr["NilaiBiayaLain"]),
                                NilaiGrandTotal = Convert.ToDecimal(dr["NilaiGrandTotal"]),
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
