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
    public interface IProduksiHasilDal
    {
        void Insert(ProduksiHasilModel model);
        void Delete(string produksiID);
        IEnumerable<ProduksiHasilModel> ListData(string produksiID);
    }
    public class ProduksiHasilDal : IProduksiHasilDal
    {
        private readonly string _connString;

        public ProduksiHasilDal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }
        public void Insert(ProduksiHasilModel model)
        {
            var sSql = @"
                INSERT INTO 
                    ProduksiHasil (
                        ProduksiID, ProduksiID2, NoUrut, BrgID, 
                        Qty, Hpp, StokControl)
                VALUES (
                        @ProduksiID, @ProduksiID2, @NoUrut, @BrgID, 
                        @Qty, @Hpp, @StokControl) ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@ProduksiID", model.ProduksiID);
                cmd.AddParam("@ProduksiID2", model.ProduksiID2);
                cmd.AddParam("@NoUrut", model.NoUrut);
                cmd.AddParam("@BrgID", model.BrgID);
                cmd.AddParam("@Qty", model.Qty);
                cmd.AddParam("@Hpp", model.Hpp);
                cmd.AddParam("@StokControl", model.StokControl);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string produksiID)
        {
            var sSql = @"
                DELETE
                    ProduksiHasil 
                WHERE
                    ProduksiID = @ProduksiID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@ProduksiID", produksiID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<ProduksiHasilModel> ListData(string produksiID)
        {
            List<ProduksiHasilModel> result;
            var sSql = @"
                SELECT
                    aa.ProduksiID, aa.ProduksiID2, aa.NoUrut, aa.BrgID, 
                    aa.Qty, aa.Hpp, aa.StokControl,
                    ISNULL(bb.BrgName, '') BrgName
                FROM
                    ProduksiHasil aa
                    LEFT JOIN Brg bb ON aa.BrgID = bb.BrgID
                WHERE
                    Produksi = @ProduksiID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@ProduksiID", produksiID);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (!dr.HasRows) return null;
                    result = new List<ProduksiHasilModel>();
                    while (dr.Read())
                    {
                        var item = new ProduksiHasilModel
                        {
                            ProduksiID = dr["ProduksiID"].ToString(),
                            ProduksiID2 = dr["ProduksiID2"].ToString(),
                            NoUrut = Convert.ToInt16(dr["NoUrut"]),
                            BrgID = dr["BrgID"].ToString(),
                            BrgName = dr["BrgName"].ToString(),
                            Qty = Convert.ToInt64(dr["Qty"]),
                            Hpp = Convert.ToDecimal(dr["Hpp"]),
                            StokControl = dr["StokControl"].ToString()
                        };
                        result.Add(item);
                    }
                }
            }
            return result;
        }
    }
}
