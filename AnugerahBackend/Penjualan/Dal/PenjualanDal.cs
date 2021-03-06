﻿using AnugerahBackend.Penjualan.Model;
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
    public interface IPenjualanDal
    {
        void Insert(PenjualanModel penjualan);
        void Update(PenjualanModel penjualan);
        void Delete(string penjualanID);
        PenjualanModel GetData(string penjualanID);
        IEnumerable<PenjualanModel> ListData(string tgl1, string tgl2);
    }

    public class PenjualanDal : IPenjualanDal
    {
        private string _connString;

        public PenjualanDal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void Insert(PenjualanModel penjualan)
        {
            var sSql = @"
                INSERT INTO
                    Penjualan(
                        PenjualanID, TglPenjualan, JamPenjualan, BuyerName,
                        CustomerID, Alamat, NoTelp, Catatan, 
                        IsBayarDeposit, DepositID, NilaiDeposit, 
                        NilaiBiayaKirim, NilaiTotal, NilaiDiskonLain, 
                        NilaiBiayaLain, NilaiGrandTotal, NilaiBayar, NilaiKembali)
                VALUES (
                        @PenjualanID, @TglPenjualan, @JamPenjualan, @BuyerName,
                        @CustomerID, @Alamat, @NoTelp, @Catatan,
                        @IsBayarDeposit, @DepositID, @NilaiDeposit, 
                        @NilaiBiayaKirim, @NilaiTotal, @NilaiDiskonLain, 
                        @NilaiBiayaLain, @NilaiGrandTotal, @NilaiBayar, @NilaiKembali) ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@PenjualanID", penjualan.PenjualanID); 
                cmd.AddParam("@TglPenjualan", penjualan.TglPenjualan.ToTglYMD()); 
                cmd.AddParam("@JamPenjualan", penjualan.JamPenjualan);
                cmd.AddParam("@BuyerName", penjualan.BuyerName);
                cmd.AddParam("@CustomerID", penjualan.CustomerID);
                cmd.AddParam("@Alamat", penjualan.Alamat);
                cmd.AddParam("@NoTelp", penjualan.NoTelp);
                cmd.AddParam("@Catatan", penjualan.Catatan);
                cmd.AddParam("@IsBayarDeposit", penjualan.IsBayarDeposit);
                cmd.AddParam("@NilaiDeposit", penjualan.NilaiDeposit);
                cmd.AddParam("@DepositID", penjualan.DepositID);
                cmd.AddParam("@NilaiBiayaKirim", penjualan.NilaiBiayaKirim);
                cmd.AddParam("@NilaiTotal", penjualan.NilaiTotal); 
                cmd.AddParam("@NilaiDiskonLain", penjualan.NilaiDiskonLain);
                cmd.AddParam("@NilaiBiayaLain", penjualan.NilaiBiayaLain);
                cmd.AddParam("@NilaiGrandTotal", penjualan.NilaiGrandTotal);
                cmd.AddParam("@NilaiBayar", penjualan.NilaiBayar);
                cmd.AddParam("@NilaiKembali", penjualan.NilaiKembali);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(PenjualanModel penjualan)
        {
            var sSql = @"
                UPDATE
                    Penjualan
                SET
                    TglPenjualan = @TglPenjualan, 
                    JamPenjualan = @JamPenjualan, 
                    BuyerName = @BuyerName,
                    CustomerID = @CustomerID, 
                    Alamat = @Alamat, 
                    NoTelp = @NoTelp, 
                    Catatan = @Catatan,
                    IsBayarDeposit = @IsBayarDeposit,
                    DepositID = @DepositID, 
                    NilaiDeposit = @NilaiDeposit, 

                    NilaiBiayaKirim = @NilaiBiayaKirim, 
                    NilaiTotal = @NilaiTotal, 
                    NilaiDiskonLain = @NilaiDiskonLain,
                    NilaiBiayaLain = @NilaiBiayaLain, 
                    NilaiGrandTotal = @NilaiGrandTotal,
                    NilaiBayar = @NilaiBayar,
                    NilaiKembali = @NilaiKembali
                WHERE
                    PenjualanID = @PenjualanID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@PenjualanID", penjualan.PenjualanID);
                cmd.AddParam("@TglPenjualan", penjualan.TglPenjualan.ToTglYMD());
                cmd.AddParam("@JamPenjualan", penjualan.JamPenjualan);
                cmd.AddParam("@BuyerName", penjualan.BuyerName);
                cmd.AddParam("@CustomerID", penjualan.CustomerID);
                cmd.AddParam("@Alamat", penjualan.Alamat);
                cmd.AddParam("@NoTelp", penjualan.NoTelp);
                cmd.AddParam("@Catatan", penjualan.Catatan);
                cmd.AddParam("@IsBayarDeposit", penjualan.IsBayarDeposit);
                cmd.AddParam("@DepositID", penjualan.DepositID);
                cmd.AddParam("@NilaiDeposit", penjualan.NilaiDeposit);

                cmd.AddParam("@NilaiBiayaKirim", penjualan.NilaiBiayaKirim);
                cmd.AddParam("@NilaiTotal", penjualan.NilaiTotal);
                cmd.AddParam("@NilaiDiskonLain", penjualan.NilaiDiskonLain);
                cmd.AddParam("@NilaiBiayaLain", penjualan.NilaiBiayaLain);
                cmd.AddParam("@NilaiGrandTotal", penjualan.NilaiGrandTotal);
                cmd.AddParam("@NilaiBayar", penjualan.NilaiBayar);
                cmd.AddParam("@NilaiKembali", penjualan.NilaiKembali);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string penjualanID)
        {
            var sSql = @"
                DELETE
                    Penjualan
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

        public PenjualanModel GetData(string penjualanID)
        {
            PenjualanModel result = null;
            var sSql = @"
                SELECT
                    aa.PenjualanID, aa.TglPenjualan, aa.JamPenjualan, aa.BuyerName,
                    aa.CustomerID, aa.Alamat, aa.NoTelp, aa.Catatan, aa.IsBayarDeposit, aa.DepositID, 
                    aa.NilaiBiayaKirim, aa.NilaiTotal, aa.NilaiDiskonLain, aa.NilaiDeposit, 
                    aa.NilaiBiayaLain, aa.NilaiGrandTotal, aa.NilaiBayar, aa.NilaiKembali,
                    ISNULL(bb.CustomerName, '') CustomerName
                FROM
                    Penjualan aa
                    LEFT JOIN Customer bb ON aa.CustomerID = bb.CustomerID
                WHERE
                    PenjualanID = @PenjualanID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@PenjualanID", penjualanID);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        dr.Read();
                        result = new PenjualanModel
                        {
                            PenjualanID = dr["PenjualanID"].ToString(),
                            TglPenjualan = dr["TglPenjualan"].ToString().ToTglDMY(),
                            JamPenjualan = dr["JamPenjualan"].ToString(),

                            BuyerName = dr["BuyerName"].ToString(),
                            CustomerID = dr["CustomerID"].ToString(),
                            CustomerName = dr["CustomerName"].ToString(),
                            Alamat = dr["Alamat"].ToString(),
                            NoTelp = dr["NoTelp"].ToString(),
                            Catatan = dr["Catatan"].ToString(),

                            IsBayarDeposit = Convert.ToBoolean(dr["IsBayarDeposit"]),
                            DepositID = dr["DepositID"].ToString(),
                            NilaiDeposit = Convert.ToDecimal(dr["NilaiDeposit"]),

                            NilaiBiayaKirim = Convert.ToDecimal(dr["NilaiBiayaKirim"]),
                            NilaiTotal = Convert.ToDecimal(dr["NilaiTotal"]),
                            NilaiDiskonLain = Convert.ToDecimal(dr["NilaiDiskonLain"]),
                            NilaiBiayaLain = Convert.ToDecimal(dr["NilaiBiayaLain"]),
                            NilaiGrandTotal = Convert.ToDecimal(dr["NilaiGrandTotal"]),

                            NilaiBayar = Convert.ToDecimal(dr["NilaiBayar"]),
                            NilaiKembali = Convert.ToDecimal(dr["NilaiKembali"])
                        };

                    }
                }
            }
            return result;
        }

        public IEnumerable<PenjualanModel> ListData(string tgl1, string tgl2)
        {
            List<PenjualanModel> result = null;
            var sSql = @"
                SELECT
                    aa.PenjualanID, aa.TglPenjualan, aa.JamPenjualan, aa.BuyerName,
                    aa.CustomerID, aa.Alamat, aa.NoTelp, aa.Catatan, 
                    aa.IsBayarDeposit, aa.DepositID, aa.NilaiDeposit, 
                    aa.NilaiBiayaKirim, aa.NilaiTotal, aa.NilaiDiskonLain,
                    aa.NilaiBiayaLain, aa.NilaiGrandTotal, aa.NilaiBayar, aa.NilaiKembali,
                    ISNULL(bb.CustomerName, '') CustomerName
                FROM
                    Penjualan aa
                    LEFT JOIN Customer bb ON aa.CustomerID = bb.CustomerID
                WHERE
                    TglPenjualan BETWEEN @Tgl1 AND @Tgl2 ";
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
                        result = new List<PenjualanModel>();
                        while(dr.Read())
                        {
                            var item = new PenjualanModel
                            {
                                PenjualanID = dr["PenjualanID"].ToString(),
                                TglPenjualan = dr["TglPenjualan"].ToString().ToTglDMY(),
                                JamPenjualan = dr["JamPenjualan"].ToString(),

                                BuyerName = dr["BuyerName"].ToString(),
                                CustomerID = dr["CustomerID"].ToString(),
                                CustomerName = dr["CustomerName"].ToString(),
                                Alamat = dr["Alamat"].ToString(),
                                NoTelp = dr["NoTelp"].ToString(),
                                Catatan = dr["Catatan"].ToString(),

                                IsBayarDeposit = Convert.ToBoolean(dr["IsBayarDeposit"]),
                                DepositID = dr["DepositID"].ToString(),
                                NilaiDeposit = Convert.ToDecimal(dr["NilaiDeposit"]),

                                NilaiBiayaKirim = Convert.ToDecimal(dr["NilaiBiayaKirim"]),
                                NilaiTotal = Convert.ToDecimal(dr["NilaiTotal"]),
                                NilaiDiskonLain = Convert.ToDecimal(dr["NilaiDiskonLain"]),
                                NilaiBiayaLain = Convert.ToDecimal(dr["NilaiBiayaLain"]),
                                NilaiGrandTotal = Convert.ToDecimal(dr["NilaiGrandTotal"]),

                                NilaiBayar = Convert.ToDecimal(dr["NilaiBayar"]),
                                NilaiKembali = Convert.ToDecimal(dr["NilaiKembali"])
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
