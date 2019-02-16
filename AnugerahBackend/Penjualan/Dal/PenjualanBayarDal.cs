using AnugerahBackend.Penjualan.Model;
using Ics.Helper.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Penjualan.Dal
{
    public interface IPenjualanBayarDal
    {
        void Insert(PenjualanBayarModel penjualanBayar);
        void Delete(string penjualanID);
        IEnumerable<PenjualanBayarModel> ListData(string penjualanID);
    }

    public class PenjualanBayarDal : IPenjualanBayarDal
    {
        private readonly string _connString;

        public PenjualanBayarDal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void Insert(PenjualanBayarModel penjualanBayar)
        {
            var sSql = @"
                INSERT INTO
                    PenjualanBayar (
                        PenjualanID, PenjualanID2, NoUrut,
                        JenisBayarID, NilaiBayar, Catatan )
                 VALUES (
                        @PenjualanID, @PenjualanID2, @NoUrut,
                        @JenisBayarID, @NilaiBayar, @Catatan) ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@PenjualanID", penjualanBayar.PenjualanID);
                cmd.AddParam("@PenjualanID2", penjualanBayar.PenjualanID2);
                cmd.AddParam("@NoUrut", penjualanBayar.NoUrut);
                cmd.AddParam("@JenisBayarID", penjualanBayar.JenisBayarID);
                cmd.AddParam("@NilaiBayar", penjualanBayar.NilaiBayar);
                cmd.AddParam("@Catatan", penjualanBayar.Catatan);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string penjualanID)
        {
            var sSql = @"
                DELETE
                    PenjualanBayar
                WHERE
                    PenjualanID = @PenjualanID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@PenjualanID", penjualanID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<PenjualanBayarModel> ListData(string penjualanID)
        {
            List<PenjualanBayarModel> result = null;
            string sSql = "";

            sSql = @"
                SELECT
                    aa.PenjualanID, aa.PenjualanID2, aa.NoUrut, 
                    aa.JenisBayarID, aa.NilaiBayar, aa.Catatan,
                    ISNULL(bb.JenisBayarName, '') JenisBayarName,
                    ISNULL(bb.JenisKasID, '') JenisKasID,
                    ISNULL(cc.JenisKasName, '') JenisKasName
                FROM
                    PenjualanBayar aa
                    LEFT JOIN JenisBayar bb ON aa.JenisBayarID = bb.JenisBayarID 
                    LEFT JOIN JenisKas cc ON bb.JenisKasID = cc.JenisKasID
                WHERE
                    aa.PenjualanID = @PenjualanID 
                ORDER BY 
                    aa.NoUrut ";

            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@PenjualanID", penjualanID);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (!dr.HasRows) return null;

                    result = new List<PenjualanBayarModel>();
                    while (dr.Read())
                    {
                        var item = new PenjualanBayarModel
                        {
                            PenjualanID = dr["PenjualanID"].ToString(),
                            PenjualanID2 = dr["PenjualanID2"].ToString(),
                            NoUrut = Convert.ToInt16(dr["NoUrut"]),
                            JenisBayarID = dr["JenisBayarID"].ToString(),
                            JenisBayarName = dr["JenisBayarName"].ToString(),
                            JenisKasID = dr["JenisKasID"].ToString(),
                            JenisKasName = dr["JenisKasName"].ToString(),
                            NilaiBayar = Convert.ToDecimal(dr["NilaiBayar"]),
                            Catatan = dr["Catatan"].ToString()
                        };
                        result.Add(item);
                    }
                }
            }
            return result;
        }
    }
}
