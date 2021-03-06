﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnugerahBackend.Accounting.Model;
using AnugerahBackend.LocalHelper;
using Ics.Helper.Extensions;
using Ics.Helper.StringDateTime;

namespace AnugerahBackend.Accounting.Dal
{
    public interface ILunasKasBonDetilDal : IDetilTrsDal<LunasKasBonDetilModel>
    {

    }

    public class LunasKasBonDetilDal : ILunasKasBonDetilDal
    {
        private string _connString;

        public LunasKasBonDetilDal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void Insert(LunasKasBonDetilModel model)
        {
            var sSql = @"
                INSERT INTO
                    LunasKasBonDetil (
                        LunasKasBonID, LunasKasBonDetilID, 
                        JenisLunasID, Keterangan, NilaiLunas, 
                        PenjualanID)
                VALUES (
                        @LunasKasBonID, @LunasKasBonDetilID, 
                        @JenisLunasID, @Keterangan, @NilaiLunas, 
                        @PenjualanID) ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@LunasKasBonID", model.LunasKasBonID);
                cmd.AddParam("@LunasKasBonDetilID", model.LunasKasBonDetilID);
                cmd.AddParam("@JenisLunasID", model.JenisLunasID);
                cmd.AddParam("@Keterangan", model.Keterangan);
                cmd.AddParam("@NilaiLunas", model.NilaiLunas);
                cmd.AddParam("@PenjualanID", model.PenjualanID);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string id)
        {
            var sSql = @"
                DELETE
                    LunasKasBonDetil
                WHERE
                    LunasKasBonID = @LunasKasBonID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@LunasKasBonID", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<LunasKasBonDetilModel> ListData(string id)
        {
            List<LunasKasBonDetilModel> result = null;
            var sSql = @"
                SELECT
                    aa.LunasKasBonID, aa.LunasKasBonDetilID, 
                    aa.JenisLunasID, aa.Keterangan, aa.NilaiLunas, 
                    aa.PenjualanID 
                FROM
                    LunasKasBonDetil aa
                WHERE
                    LunasKasBonID = @LunasKasBonID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@LunasKasBonID", id);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (!dr.HasRows) return null;
                    result = new List<LunasKasBonDetilModel>();
                    while (dr.Read())
                    {
                        var item = new LunasKasBonDetilModel
                        {
                            LunasKasBonID = dr["LunasKasBonID"].ToString(),
                            LunasKasBonDetilID = dr["LunasKasBonDetilID"].ToString(),
                            JenisLunasID = dr["JenisLunasID"].ToString(),
                            Keterangan = dr["Keterangan"].ToString(),
                            NilaiLunas = Convert.ToDecimal(dr["NilaiLunas"]),
                            PenjualanID = dr["PenjualanID"].ToString(),
                        };
                        result.Add(item);
                    }
                }
            }
            return result;
        }
    }
}
