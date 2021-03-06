﻿using AnugerahBackend.StokBarang.Model;
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
    public interface IProduksiMaterialDal
    {
        void Insert(ProduksiMaterialModel model);
        void Delete(string produksiID);
        IEnumerable<ProduksiMaterialModel> ListData(string produksiID);
    }
    public class ProduksiMaterialDal : IProduksiMaterialDal
    {
        private readonly string _connString;

        public ProduksiMaterialDal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }
        public void Insert(ProduksiMaterialModel model)
        {
            var sSql = @"
                INSERT INTO 
                    ProduksiMaterial (
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
                    ProduksiMaterial 
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

        public IEnumerable<ProduksiMaterialModel> ListData(string produksiID)
        {
            List<ProduksiMaterialModel> result;
            var sSql = @"
                SELECT
                    aa.ProduksiID, aa.ProduksiID2, aa.NoUrut, aa.BrgID, 
                    aa.Qty, aa.Hpp, aa.StokControl,
                    ISNULL(bb.BrgName, '') BrgName
                FROM
                    ProduksiMaterial aa
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
                    result = new List<ProduksiMaterialModel>();
                    while (dr.Read())
                    {
                        var item = new ProduksiMaterialModel
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
