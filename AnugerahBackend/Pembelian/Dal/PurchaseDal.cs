using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnugerahBackend.Pembelian.Model;
using System.Configuration;
using System.Data.SqlClient;
using Ics.Helper.Extensions;
using Ics.Helper.StringDateTime;

namespace AnugerahBackend.Pembelian.Dal
{
    public interface IPurchaseDal
    {
        void Insert(PurchaseModel model);
        void Update(PurchaseModel model);
        void Delete(string id);
        PurchaseModel GetData(string id);
        IEnumerable<PurchaseModel> ListData(string tgl1, string tgl2);
    }

    public class PurchaseDal : IPurchaseDal
    {
        private string _connString;

        public PurchaseDal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void Insert(PurchaseModel model)
        {
            var sSql = @"
                INSERT INTO 
                    Purchase (
                        PurchaseID, Tgl, Jam, SupplierID,
                        Keterangan, TotalHarga, Diskon, BiayaLain,
                        GrandTotal)
                VALUES (
                        @PurchaseID, @Tgl, @Jam, @SupplierID,
                        @Keterangan, @TotalHarga, @Diskon, @BiayaLain,
                        @GrandTotal) ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@PurchaseID", model.PurchaseID);
                cmd.AddParam("@Tgl", model.Tgl.ToTglYMD());
                cmd.AddParam("@Jam", model.Jam);
                cmd.AddParam("SupplierID", model.SupplierID);
                cmd.AddParam("@Keterangan", model.Keterangan);
                cmd.AddParam("@TotalHarga", model.TotalHarga);
                cmd.AddParam("@Diskon", model.Diskon);
                cmd.AddParam("@BiayaLain", model.BiayaLain);
                cmd.AddParam("@GrandTOtal", model.GrandTotal);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(PurchaseModel model)
        {
            var sSql = @"
                UPDATE
                    Purchase 
                SET
                    Tgl = @Tgl, 
                    Jam = @Jam, 
                    SupplierID = @SupplierID,
                    Keterangan = @Keterangan, 
                    TotalHarga = @TotalHarga, 
                    Diskon = @Diskon, 
                    BiayaLain = @BiayaLain,
                    GrandTotal = @GrandTotal
                WHERE
                    PurchaseID = @PurchaseID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@PurchaseID", model.PurchaseID);
                cmd.AddParam("@Tgl", model.Tgl.ToTglYMD());
                cmd.AddParam("@Jam", model.Jam);
                cmd.AddParam("SupplierID", model.SupplierID);
                cmd.AddParam("@Keterangan", model.Keterangan);
                cmd.AddParam("@TotalHarga", model.TotalHarga);
                cmd.AddParam("@Diskon", model.Diskon);
                cmd.AddParam("@BiayaLain", model.BiayaLain);
                cmd.AddParam("@GrandTOtal", model.GrandTotal);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string id)
        {
            var sSql = @"
                DELETE
                    Purchase 
                WHERE
                    PurchaseID = @PurchaseID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@PurchaseID", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public PurchaseModel GetData(string id)
        {
            PurchaseModel result = null;
            var sSql = @"
                SELECT
                    aa.PurchaseID, aa.Tgl, aa.Jam, aa.SupplierID, 
                    aa.Keterangan, aa.TotalHarga, aa.Diskon, aa.BiayaLain, 
                    aa.GrandTotal, 
                    ISNULL(bb.SupplierName, '') SUpplierName 
                FROM
                    Purchase aa
                    LEFT JOIN Supplier bb ON aa.SupplierID = bb.SupplierID
                WHERE
                    aa.PurchaseID = @PurchaseID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@PurchaseID", id);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (!dr.HasRows) return null;
                    dr.Read();
                    result = new PurchaseModel
                    {
                        PurchaseID = dr["PurchaseID"].ToString(),
                        Tgl = dr["Tgl"].ToString().ToTglDMY(),
                        Jam = dr["Jam"].ToString(),

                        SupplierID = dr["SupplierID"].ToString(),
                        SupplierName = dr["SupplierName"].ToString(),
                        Keterangan = dr["Keterangan"].ToString(),
                        TotalHarga = Convert.ToDecimal(dr["TotalHarga"]),
                        Diskon = Convert.ToDecimal(dr["Diskon"]),
                        BiayaLain = Convert.ToDecimal(dr["BiayaLain"]),
                        GrandTotal = Convert.ToDecimal(dr["GrandTotal"])
                    };
                }
                return result;
            }
        }

        public IEnumerable<PurchaseModel> ListData(string tgl1, string tgl2)
        {
            List<PurchaseModel> result = null;
            var sSql = @"
                SELECT
                    aa.PurchaseID, aa.Tgl, aa.Jam, aa.SupplierID, 
                    aa.Keterangan, aa.TotalHarga, aa.Diskon, aa.BiayaLain, 
                    aa.GrandTotal,
                    ISNULL(bb.SupplierName, '') SUpplierName 
                FROM
                    Purchase aa
                    LEFT JOIN Supplier bb ON aa.SupplierID = bb.SupplierID
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
                    result = new List<PurchaseModel>();
                    while (dr.Read())
                    {
                        var item = new PurchaseModel
                        {
                            PurchaseID = dr["PurchaseID"].ToString(),
                            Tgl = dr["Tgl"].ToString().ToTglDMY(),
                            Jam = dr["Jam"].ToString(),

                            SupplierID = dr["SupplierID"].ToString(),
                            SupplierName = dr["SupplierName"].ToString(),
                            Keterangan = dr["Keterangan"].ToString(),
                            TotalHarga = Convert.ToDecimal(dr["TotalHarga"]),
                            Diskon = Convert.ToDecimal(dr["Diskon"]),
                            BiayaLain = Convert.ToDecimal(dr["BiayaLain"]),
                            GrandTotal = Convert.ToDecimal(dr["GrandTotal"])
                        };
                        result.Add(item);
                    };
                }
                return result;
            }

        }
    }
}
