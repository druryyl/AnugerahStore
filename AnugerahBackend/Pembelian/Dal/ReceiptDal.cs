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
    public interface IReceiptDal
    {
        void Insert(ReceiptModel model);
        void Update(ReceiptModel model);
        void Delete(string id);
        ReceiptModel GetData(string id);
        IEnumerable<ReceiptModel> ListData(string tgl1, string tgl2);

    }
    public class ReceiptDal : IReceiptDal
    {
        private string _connString;

        public ReceiptDal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }
        public void Insert(ReceiptModel model)
        {
            var sSql = @"
                INSERT INTO
                    Receipt (
                        ReceiptID, Tgl, Jam, PurchaseID,
                        SupplierID, Keterangan, TotalHarga,
                        Diskon, BiayaLain, GrandTotal)
                VALUES (
                        @ReceiptID, @Tgl, @Jam, @PurchaseID,
                        @SupplierID, @Keterangan, @TotalHarga,
                        @Diskon, @BiayaLain, @GrandTotal) ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@ReceiptID", model.ReceiptID);
                cmd.AddParam("@Tgl", model.Tgl.ToTglYMD());
                cmd.AddParam("@Jam", model.Jam);
                cmd.AddParam("@PurchaseID", model.PurchaseID);
                cmd.AddParam("@SupplierID", model.SupplierID);
                cmd.AddParam("@Keterangan", model.Keterangan);
                cmd.AddParam("@TotalHarga", model.TotalHarga);
                cmd.AddParam("@Diskon", model.Diskon);
                cmd.AddParam("@BiayaLain", model.BiayaLain);
                cmd.AddParam("@GrandTotal", model.GrandTotal);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(ReceiptModel model)
        {
            var sSql = @"
                UPDATE
                    Receipt 
                SET
                    Tgl = @Tgl, 
                    Jam = @Jam, 
                    PurchaseID = @PurchaseID,
                    SupplierID = @SupplierID, 
                    Keterangan = @Keterangan, 
                    TotalHarga = @TotalHarga,
                    Diskon = @Diskon, 
                    BiayaLain = @BiayaLain, 
                    GrandTotal = @GrandTotal
                WHERE
                    ReceiptID = @ReceiptID) ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@ReceiptID", model.ReceiptID);
                cmd.AddParam("@Tgl", model.Tgl.ToTglYMD());
                cmd.AddParam("@Jam", model.Jam);
                cmd.AddParam("@PurchaseID", model.PurchaseID);
                cmd.AddParam("@SupplierID", model.SupplierID);
                cmd.AddParam("@Keterangan", model.Keterangan);
                cmd.AddParam("@TotalHarga", model.TotalHarga);
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
                    Receipt
                WHERE
                    ReceiptID = @ReceiptID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@ReceiptID", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public ReceiptModel GetData(string id)
        {
            ReceiptModel result = null;

            var sSql = @"
                SELECT
                    ReceiptID, Tgl, Jam, PurchaseID,
                    SupplierID, Keterangan, TotalHarga, 
                    Diskon, BiayaLain, GrandTotal,
                    ISNULL(bb.SupplierName, '')
                FROM
                    Receipt aa
                    LEFT JOIN Supplier bb oN aa.SupplierID = bb.SupplierID
                WHERE
                    aa.ReceiptID = @ReceiptID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@ReceiptID", id);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (!dr.HasRows) return null;
                    dr.Read();
                    result = new ReceiptModel()
                    {
                        ReceiptID = dr["ReceiptID"].ToString(),
                        Tgl = dr["Tgl"].ToString(),
                        Jam = dr["Jam"].ToString(),
                        PurchaseID = dr["PurchaseID"].ToString(),
                        SupplierID = dr["SupplierID"].ToString(),
                        SupplierName = dr["SupplierName"].ToString(),
                        Keterangan = dr["Keterangan"].ToString(),
                        TotalHarga = Convert.ToDecimal(dr["TotalHarga"]),
                        Diskon = Convert.ToDecimal(dr["Diskon"]),
                        BiayaLain = Convert.ToDecimal(dr["BiayaLain"]),
                        GrandTotal = Convert.ToDecimal(dr["GrandTotal"]),
                    };
                }
            }
            return result;
        }

        public IEnumerable<ReceiptModel> ListData(string tgl1, string tgl2)
        {
            List<ReceiptModel> result = null;

            var sSql = @"
                SELECT
                    ReceiptID, Tgl, Jam, PurchaseID,
                    SupplierID, Keterangan, TotalHarga, 
                    Diskon, BiayaLain, GrandTotal,
                    ISNULL(bb.SupplierName, '')
                FROM
                    Receipt aa
                    LEFT JOIN Supplier bb oN aa.SupplierID = bb.SupplierID
                WHERE
                    aa.Tgl BETWEEN @Tgl1 AND @Tgl2 ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@Tgl1", tgl1.ToTglYMD());
                cmd.AddParam("@Tgl2", tgl2.ToTglYMD());
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (!dr.HasRows) return null;
                    result = new List<ReceiptModel>();
                    while(dr.Read())
                    { 
                        var item = new ReceiptModel()
                        {
                            ReceiptID = dr["ReceiptID"].ToString(),
                            Tgl = dr["Tgl"].ToString(),
                            Jam = dr["Jam"].ToString(),
                            PurchaseID = dr["PurchaseID"].ToString(),
                            SupplierID = dr["SupplierID"].ToString(),
                            SupplierName = dr["SupplierName"].ToString(),
                            Keterangan = dr["Keterangan"].ToString(),
                            TotalHarga = Convert.ToDecimal(dr["TotalHarga"]),
                            Diskon = Convert.ToDecimal(dr["Diskon"]),
                            BiayaLain = Convert.ToDecimal(dr["BiayaLain"]),
                            GrandTotal = Convert.ToDecimal(dr["GrandTotal"]),
                        };
                        result.Add(item);
                    }
                }
            }
            return result;
        }
    }
}
