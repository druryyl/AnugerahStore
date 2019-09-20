using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnugerahBackend.StokBarang.Model;
using Ics.Helper.Extensions;
using Ics.Helper.StringDateTime;

namespace AnugerahBackend.StokBarang.Dal
{
    public interface IBrgStokHargaDal
    {
        IEnumerable<BrgStokHargaModel> ListData();
        void Insert(BrgStokHargaModel model);
        void Update(BrgStokHargaModel model);
        void Delete(string id);
        BrgStokHargaModel GetData(string id);
        decimal ReCalcQty(string brgID);

    }

    public class BrgStokHargaDal : IBrgStokHargaDal
    {
        private string _connString;

        public BrgStokHargaDal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public IEnumerable<BrgStokHargaModel> ListData()
        {
            List<BrgStokHargaModel> result = null;
            var sSql = @"
                SELECT
                    aa.BrgID, aa.Qty, aa.Harga,
                    ISNULL(bb.BrgName, '') BrgName
                FROM
                    BrgStokHarga aa
                    LEFT JOIN Brg bb ON aa.BrgID = bb.BrgID 
                WHERE
                    bb.IsAktif = 1";

            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (!dr.HasRows) return null;

                    result = new List<BrgStokHargaModel>();
                    while (dr.Read())
                    {
                        var item = new BrgStokHargaModel
                        {
                            BrgID = dr["BrgID"].ToString(),
                            BrgName = dr["BrgName"].ToString(),
                            Qty = Convert.ToDecimal(dr["Qty"]),
                            Harga = Convert.ToDecimal(dr["Harga"])
                        };
                        result.Add(item);
                    }
                }
            }
            return result;
        }

        public void Insert(BrgStokHargaModel model)
        {
            var sSql = @"
                INSERT INTO
                    BrgStokHarga (
                        BrgID, Qty, Harga )
                VALUES (
                        @BrgID, @Qty, @Harga) ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BrgID", model.BrgID);
                cmd.AddParam("@Qty", model.Qty);
                cmd.AddParam("@Harga", model.Harga);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(BrgStokHargaModel model)
        {
            var sSql = @"
                UPDATE
                    BrgStokHarga 
                SET
                    Qty = @Qty 
                WHERE
                    BrgID = @BrgID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BrgID", model.BrgID);
                cmd.AddParam("@Qty", model.Qty);
                cmd.AddParam("@Harga", model.Harga);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string id)
        {
            var sSql = @"
                DELETE
                    BrgStokHarga
                WHERE
                    BrgID = @BrgID ";

            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BrgID", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public BrgStokHargaModel GetData(string id)
        {
            BrgStokHargaModel result = null;

            var sSql = @"
                SELECT
                    aa.Qty, aa.Harga,
                    ISNULL(bb.BrgName, '') BrgName
                FROM
                    BrgStokHarga aa
                    LEFT JOIN Brg bb ON aa.BrgID = bb.BrgID
                WHERE
                    aa.BrgID = @BrgID ";

            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BrgID", id);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (!dr.HasRows) return null;

                    dr.Read();
                    result = new BrgStokHargaModel
                    {
                        BrgID = id,
                        BrgName = dr["BrgName"].ToString(),
                        Qty = Convert.ToDecimal(dr["Qty"]),
                        Harga = Convert.ToDecimal(dr["Harga"])
                    };
                }
            }
            return result;
        }

        public decimal ReCalcQty(string brgID)
        {
            decimal result = 0;
            var sSql = @"
                SELECT
                    ISNULL(SUM(QtySisa) ,0) QtySisa
                FROM
                    BPStok
                WHERE
                    BrgID = @BrgID ";

            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BrgID", brgID);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (!dr.HasRows) return 0;

                    dr.Read();
                    result = Convert.ToDecimal(dr["QtySisa"]);
                }
            }
            return result;
        }
    }
}
