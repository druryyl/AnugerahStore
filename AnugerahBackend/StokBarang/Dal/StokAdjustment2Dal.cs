using AnugerahBackend.StokBarang.Model;
using Ics.Helper.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.StokBarang.Dal
{

    public interface IStokAdjustment2Dal
    {
        void Insert(StokAdjustment2Model stokAdjustment2);

        void Delete(string id);

        IEnumerable<StokAdjustment2Model> ListData(string id);
    }


    public class StokAdjustment2Dal : IStokAdjustment2Dal
    {
        public string _connString;

        public StokAdjustment2Dal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void Insert(StokAdjustment2Model stokAdjustment2)
        {
            var sSql = @"
                INSERT INTO
                    StokAdjustment2 (
                        StokAdjustmentID, NoUrut, BrgID,
                        QtyAwal, QtyAkhir, QtyAdjust, HppAdjust)
                VALUES (
                        @StokAdjustmentID, @NoUrut, @BrgID,
                        @QtyAwal, @QtyAkhir, @QtyAdjust, @HppAdjust) ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@StokAdjustmentID", stokAdjustment2.StokAdjustmentID);
                cmd.AddParam("@NoUrut", stokAdjustment2.NoUrut);
                cmd.AddParam("@BrgID", stokAdjustment2.BrgID);
                cmd.AddParam("@QtyAwal", stokAdjustment2.QtyAwal);
                cmd.AddParam("@QtyAdjust", stokAdjustment2.QtyAdjust);
                cmd.AddParam("@QtyAkhir", stokAdjustment2.QtyAkhir);
                cmd.AddParam("@HppAdjust", stokAdjustment2.HppAdjust);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string id)
        {
            var sSql = @"
                DELETE
                    StokAdjustment2 
                WHERE
                    StokAdjustmentID = @StokAdjustmentID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@StokAdjustmentID", id);
            }
        }

        public IEnumerable<StokAdjustment2Model> ListData(string stokAdjustmentID)
        {
            List<StokAdjustment2Model> result = null;
            var sSql = @"
                SELECT
                    aa.StokAdjustmentID, aa.NoUrut, aa.BrgID,
                    aa.QtyAwal, aa.QtyAdjust, aa.QtyAkhir,
                    aa.HppAdjust,
                    ISNULL(bb.BrgName, '') BrgName
                FROM
                    StokAdjustment2 aa 
                    LEFT JOIN Brg bb ON aa.BrgID = bb.BrgID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        result = new List<StokAdjustment2Model>();
                        while (dr.Read())
                        {
                            var item = new StokAdjustment2Model
                            {
                                StokAdjustmentID = dr["StokAdjustmentID"].ToString(),
                                NoUrut = Convert.ToInt16(dr["NoUrut"]),
                                BrgID = dr["BrgID"].ToString(),
                                BrgName = dr["BrgName"].ToString(),
                                QtyAwal = Convert.ToInt32(dr["QtyAwal"]),
                                QtyAdjust = Convert.ToInt32(dr["QtyAdjust"]),
                                QtyAkhir = Convert.ToInt32(dr["QtyAkhir"]),
                                HppAdjust = Convert.ToDouble(dr["HppAdjust"])
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
