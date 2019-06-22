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
    public interface IBPStokInfoDal
    {
        IEnumerable<BPStokInfoModel> ListData();
        void Insert(BPStokInfoModel model);
        void Update(BPStokInfoModel model);
        void Delete(string id);
        BPStokInfoModel GetData(string id);
        decimal ReCalcQty(string brgID);

    }

    public class BPStokInfoDal : IBPStokInfoDal
    {
        private string _connString;

        public BPStokInfoDal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public IEnumerable<BPStokInfoModel> ListData()
        {
            List<BPStokInfoModel> result = null;
            var sSql = @"
                SELECT
                    aa.BrgID, aa.Qty,
                    ISNULL(bb.BrgName, '') BrgName
                FROM
                    BPStokInfo aa
                    LEFT JOIN Brg bb ON aa.BrgID = bb.BrgID ";

            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (!dr.HasRows) return null;

                    result = new List<BPStokInfoModel>();
                    while (dr.Read())
                    {
                        var item = new BPStokInfoModel
                        {
                            BrgID = dr["BrgID"].ToString(),
                            BrgName = dr["BrgName"].ToString(),
                            Qty = Convert.ToDecimal(dr["Qty"])
                        };
                        result.Add(item);
                    }
                }
            }
            return result;
        }

        public void Insert(BPStokInfoModel model)
        {
            var sSql = @"
                INSERT INTO
                    BPStokInfo (
                        BrgID, Qty )
                VALUES (
                        @BrgID, @Qty) ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BrgID", model.BrgID);
                cmd.AddParam("@Qty", model.Qty);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(BPStokInfoModel model)
        {
            var sSql = @"
                UPDATE
                    BPStokInfo 
                SET
                    Qty = @Qty 
                WHERE
                    BrgID = @BrgID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BrgID", model.BrgID);
                cmd.AddParam("@Qty", model.Qty);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string id)
        {
            var sSql = @"
                DELETE
                    BPStokInfo
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

        public BPStokInfoModel GetData(string id)
        {
            BPStokInfoModel result = null;

            var sSql = @"
                SELECT
                    aa.Qty, 
                    ISNULL(bb.BrgName, '') BrgName
                FROM
                    BPStokInfo aa
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
                    result = new BPStokInfoModel
                    {
                        BrgID = id,
                        Qty = Convert.ToDecimal(dr["Qty"]),
                        BrgName = dr["BrgName"].ToString()
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
                    SUM(QtySisa) QtySisa
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
