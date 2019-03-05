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
    public interface IBPPurchaseReceiptDal
    {
        void Insert(BPPurchaseReceiptModel model);
        void Delete(string bpPurchaseID);
        IEnumerable<BPPurchaseReceiptModel> ListData(string bpPurchaseID);
    }

    public class BPPurchaseReceiptDal : IBPPurchaseReceiptDal
    {
        private readonly string _connString;

        public BPPurchaseReceiptDal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void Insert(BPPurchaseReceiptModel model)
        {
            var sSql = @"
                INSERT INTO
                    BPPurchaseReceipt (
                        BPPurchaseID, BPReceiptID, BPDetilID,
                        Tgl, Jam, Keterangan, BrgID,
                        QtyPurchase, QtyReceipt, Harga, Diskon, 
                        Tax, SubTotal)
                VALUES (
                        aa.BPPurchaseID, aa.BPReceiptID, aa.BPDetilID,
                        aa.Tgl, aa.Jam, aa.Keterangan, aa.BrgID,
                        aa.QtyPurchase, aa.QtyReceipt, aa.Harga, aa.Diskon, 
                        aa.Tax, aa.SubTotal) ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BPPurchaseID", model.BPPurchaseID);
                cmd.AddParam("@BPReceiptID", model.BPReceiptID);
                cmd.AddParam("@BPDetilID", model.BPPurchaseID);
                cmd.AddParam("@Tgl", model.Tgl.ToTglYMD());
                cmd.AddParam("@Jam", model.Jam);
                cmd.AddParam("@Keterangan", model.Keterangan);
                cmd.AddParam("@BrgID", model.BrgID);
                cmd.AddParam("@QtyPurchase", model.QtyPurchase);
                cmd.AddParam("@QtyReceipt", model.QtyReceipt);
                cmd.AddParam("@Harga", model.Harga);
                cmd.AddParam("@Diskon", model.Diskon);
                cmd.AddParam("@Tax", model.Tax);
                cmd.AddParam("@SubTotal", model.SubTotal);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string bpPurchaseID)
        {
            var sSql = @"
                UPDATE
                    BPPurchaseReceipt 
                WHERE
                    BPPurchaseID = @BPPurchaseID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BPPurchaseID", bpPurchaseID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<BPPurchaseReceiptModel> ListData(string bpPurchaseID)
        {
            List<BPPurchaseReceiptModel> result = null;

            var sSql = @"
                SELECT
                    BPPurchaseID, BPReceiptID, BPDetilID,
                    Tgl, Jam, Keterangan, BrgID,
                    QtyPurchase, QtyReceipt, Harga, Diskon, 
                    Tax, SubTotal
                FROM
                    BPPurchaseReceipt
                 WHERE
                    BPPurchaseID = @BPPurchaseID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BPPurchaseID", bpPurchaseID);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (!dr.HasRows) return null;
                    result = new List<BPPurchaseReceiptModel>();

                    while (dr.Read())
                    {
                        var item = new BPPurchaseReceiptModel
                        {
                            BPPurchaseID = dr["BPPurchaseID"].ToString(),
                            BPReceiptID = dr["BPReceiptID"].ToString(),
                            BPDetilID = dr["BPDetilID"].ToString(),
                            Tgl = dr["Tgl"].ToString().ToTglDMY(),
                            Jam = dr["Jam"].ToString(),
                            Keterangan = dr["Keterangan"].ToString(),
                            BrgID = dr["BrgID"].ToString(),
                            QtyPurchase = Convert.ToInt32(dr["QtyPurchase"]),
                            QtyReceipt = Convert.ToInt32(dr["QtyReceipt"]),
                            Harga = Convert.ToDecimal(dr["Harga"]),
                            Diskon = Convert.ToDecimal(dr["Diskon"]),
                            Tax = Convert.ToDecimal(dr["Tax"]),
                            SubTotal = Convert.ToDecimal(dr["SubTotal"])
                        };
                        result.Add(item);
                    }
                }
            }
            return result;
        }
    }
}
