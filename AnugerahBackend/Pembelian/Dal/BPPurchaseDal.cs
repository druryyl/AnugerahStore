using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnugerahBackend.Pembelian.Model;
using Ics.Helper.Extensions;
using Ics.Helper.StringDateTime;

namespace AnugerahBackend.Pembelian.Dal
{
    public interface IBPPurchaseDal
    {
        void Insert(BPPurchaseModel model);
        void Update(BPPurchaseModel model);
        void Delete(string id);
        BPPurchaseModel GetData(string id);
        IEnumerable<BPPurchaseModel> ListData(string tgl1, string tgl2);
        IEnumerable<BPPurchaseModel> ListData();
    }

    public class BPPurchaseDal : IBPPurchaseDal
    {
        private readonly string _connString;

        public BPPurchaseDal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void Insert(BPPurchaseModel model)
        {
            var sSql = @"
                INSERT INTO
                    BPPurchase (
                        BPPurchaseID, Tgl, Jam, SupplierID, Keterangan, 
                        TotHargaPurchase, TotHargaReceipt, Diskon, 
                        BiayaLain, GrandTotal)
                VALUES (
                        @BPPurchaseID, @Tgl, @Jam, @SupplierID, @Keterangan, 
                        @TotHargaPurchase, @TotHargaReceipt, @Diskon, 
                        @BiayaLain, @GrandTotal) ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BPPurchaseID", model.BPPurchaseID);
                cmd.AddParam("@Tgl", model.Tgl.ToTglYMD());
                cmd.AddParam("@Jam", model.Jam);
                cmd.AddParam("@SupplierID", model.SupplierID);
                cmd.AddParam("@Keterangan", model.Keterangan);
                cmd.AddParam("@TotHargaPurchase", model.TotHargaPurchase);
                cmd.AddParam("@TotHargaReceipt", model.TotHargaReceipt);
                cmd.AddParam("@Diskon", model.Diskon);
                cmd.AddParam("@BiayaLain", model.BiayaLain);
                cmd.AddParam("@GrandTotal", model.GrandTotal);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(BPPurchaseModel model)
        {
            var sSql = @"
                UPDATE
                    BPPurchase 
                SET
                    BPPurchaseID = @BPPurchaseID, 
                    Tgl = @Tgl, 
                    Jam = @Jam, 
                    SupplierID = @SupplierID, 
                    Keterangan = @Keterangan, 
                    TotHargaPurchase = @TotHargaPurchase, 
                    TotHargaReceipt = @TotHargaReceipt, 
                    Diskon = @Diskon, 
                    BiayaLain = @BiayaLain, 
                    GrandTotal = @GrandTotal
                WHERE
                    BPPurchaseID = @BPPurchaseID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BPPurchaseID", model.BPPurchaseID);
                cmd.AddParam("@Tgl", model.Tgl.ToTglYMD());
                cmd.AddParam("@Jam", model.Jam);
                cmd.AddParam("@SupplierID", model.SupplierID);
                cmd.AddParam("@Keterangan", model.Keterangan);
                cmd.AddParam("@TotHargaPurchase", model.TotHargaPurchase);
                cmd.AddParam("@TotHargaReceipt", model.TotHargaReceipt);
                cmd.AddParam("@Diskon", model.Diskon);
                cmd.AddParam("@BiayaLain", model.BiayaLain);
                cmd.AddParam("@GrandTotal", model.GrandTotal);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string id)
        {
            var sSql = @"
                DELETE
                    BPPurchase 
                WHERE
                    BPPurchaseID = @BPPurchaseID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BPPurchaseID", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public BPPurchaseModel GetData(string id)
        {
            BPPurchaseModel result = null;

            var sSql = @"
                SELECT
                    aa.BPPurchaseID, aa.Tgl, aa.Jam, aa.SupplierID, aa.Keterangan, 
                    aa.TotHargaPurchase, aa.TotHargaReceipt, aa.Diskon, 
                    aa.BiayaLain, aa.GrandTotal,
                    ISNULL(bb.SupplierName, '') SupplierName
                FROM
                    BPPurchase aa
                    LEFT JOIN Supplier bb ON aa.SupplierID = bb.SupplierID
                WHERE
                    BPPurchaseID = @BPPurchaseID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BPPurchaseID", id);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (!dr.HasRows) return null;

                    dr.Read();
                    result = new BPPurchaseModel
                    {
                        BPPurchaseID = dr["BPPurchaseID"].ToString(),
                        Tgl = dr["Tgl"].ToString().ToTglDMY(),
                        Jam = dr["Jam"].ToString(),
                        SupplierID = dr["SupplierID"].ToString(),
                        Keterangan = dr["Keterangan"].ToString(),
                        TotHargaPurchase = Convert.ToDecimal(dr["TotHargaPurchase"]),
                        TotHargaReceipt = Convert.ToDecimal(dr["TotHargaReceipt"]),
                        Diskon = Convert.ToDecimal(dr["Diskon"]),
                        BiayaLain = Convert.ToDecimal(dr["BiayaLain"]),
                        GrandTotal = Convert.ToDecimal(dr["GrandTotal"])
                    };
                }
            }
            return result;
        }

        public IEnumerable<BPPurchaseModel> ListData(string tgl1, string tgl2)
        {
            List<BPPurchaseModel> result = null;

            var sSql = @"
                SELECT
                    BPPurchaseID, Tgl, Jam, SupplierID, Keterangan, 
                    TotHargaPurchase, TotHargaReceipt, Diskon, 
                    BiayaLain, GrandTotal
                FROM
                    BPPurchase 
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
                    if (!dr.HasRows) return null;
                    result = new List<BPPurchaseModel>();

                    while(dr.Read())
                    { 
                        var item = new BPPurchaseModel
                        {
                            BPPurchaseID = dr["BPPurchaseID"].ToString(),
                            Tgl = dr["Tgl"].ToString().ToTglDMY(),
                            Jam = dr["Jam"].ToString(),
                            SupplierID = dr["SupplierID"].ToString(),
                            Keterangan = dr["Keterangan"].ToString(),
                            TotHargaPurchase = Convert.ToDecimal(dr["TotHargaPurchase"]),
                            TotHargaReceipt = Convert.ToDecimal(dr["TotHargaReceipt"]),
                            Diskon = Convert.ToDecimal(dr["Diskon"]),
                            BiayaLain = Convert.ToDecimal(dr["BiayaLain"]),
                            GrandTotal = Convert.ToDecimal(dr["GrandTotal"])
                        };
                        result.Add(item);
                    }
                }
            }
            return result;
        }

        public IEnumerable<BPPurchaseModel> ListData()
        {
            List<BPPurchaseModel> result = null;

            var sSql = @"
                SELECT
                    BPPurchaseID, Tgl, Jam, SupplierID, Keterangan, 
                    TotHargaPurchase, TotHargaReceipt, Diskon, 
                    BiayaLain, GrandTotal
                FROM
                    BPPurchase 
                WHERE
                    TotHargaReceipt <> TotHargaPurchase ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (!dr.HasRows) return null;
                    result = new List<BPPurchaseModel>();

                    while (dr.Read())
                    {
                        var item = new BPPurchaseModel
                        {
                            BPPurchaseID = dr["BPPurchaseID"].ToString(),
                            Tgl = dr["Tgl"].ToString().ToTglDMY(),
                            Jam = dr["Jam"].ToString(),
                            SupplierID = dr["SupplierID"].ToString(),
                            Keterangan = dr["Keterangan"].ToString(),
                            TotHargaPurchase = Convert.ToDecimal(dr["TotHargaPurchase"]),
                            TotHargaReceipt = Convert.ToDecimal(dr["TotHargaReceipt"]),
                            Diskon = Convert.ToDecimal(dr["Diskon"]),
                            BiayaLain = Convert.ToDecimal(dr["BiayaLain"]),
                            GrandTotal = Convert.ToDecimal(dr["GrandTotal"])
                        };
                        result.Add(item);
                    }
                }
            }
            return result;
        }
    }
}
