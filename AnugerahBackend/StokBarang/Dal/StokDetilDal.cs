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
    public interface IStokDetilDal
    {
        void Insert(StokDetilModel stokDetil);
        void Delete(string stokDetilID);
        IEnumerable<StokDetilModel> ListData(string stokID);
    }

    public class StokDetilDal : IStokDetilDal
    {
        public string _connString;

        public StokDetilDal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void Insert(StokDetilModel stokDetil)
        {
            var sSql = @"
                INSERT INTO
                    StokDetil (
                        StokDetilID, StokID, TglTrs, JamTrs, ReffTrsID,
                        JenisMutasiID, QtyIn, QtyOut, NilaiIn, NilaiOut)
                VALUES (
                        @StokDetilID, @StokID, @TglTrs, @JamTrs, @ReffTrsID,
                        @JenisMutasiID, @QtyIn, @QtyOut, @NilaiIn, @NilaiOut) ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@StokDetilID", stokDetil.StokDetilID);
                cmd.AddParam("@StokID", stokDetil.StokID);
                cmd.AddParam("@TglTrs", stokDetil.TglTrs);
                cmd.AddParam("@JamTrs", stokDetil.JamTrs);
                cmd.AddParam("@ReffTrsID", stokDetil.ReffTrsID);
                cmd.AddParam("@JenisMutasiID", stokDetil.JenisMutasiID);
                cmd.AddParam("@QtyIn", stokDetil.QtyIn);
                cmd.AddParam("@QtyOut", stokDetil.QtyOut);
                cmd.AddParam("@NilaiIn", stokDetil.NilaiIn );
                cmd.AddParam("@NilaiOut", stokDetil.NilaiOut);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string stokDetilID)
        {
            var sSql = @"
                DELETE
                    StokDetil
                WHERE
                    StokDetilID = @StokDetilID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@StokDetilID", stokDetilID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<StokDetilModel> ListData(string stokID)
        {
            List<StokDetilModel> result = null;
            var sSql = @"
                SELECT
                    StokDetilID, StokID, TglTrs, JamTrs, ReffTrsID,
                    JenisMutasiID, QtyIn, QtyOut, NilaiIn, NilaiOut
                FROM
                    StokDetil
                WHERE
                    StokID = @StokID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@StokID", stokID);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        result = new List<StokDetilModel>();
                        while (dr.Read())
                        {
                            var item = new StokDetilModel
                            {
                                StokDetilID = dr["StokDetilID"].ToString(),
                                StokID = dr["StokID"].ToString(),

                            }
                        }
                    }
                }
            }
        }
    }


}
