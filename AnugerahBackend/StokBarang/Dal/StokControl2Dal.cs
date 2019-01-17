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
        void Insert(StokControl2Model stokControl2);
        void Delete(string stokControl2ID);
        IEnumerable<StokControl2Model> ListData(string stokControlID);
    }

    public class StokControl2Dal : IStokDetilDal
    {
        public string _connString;

        public StokControl2Dal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void Insert(StokControl2Model stokControl2)
        {
            var sSql = @"
                INSERT INTO
                    StokControl2 (
                        StokControl2ID, StokID, TglTrs, JamTrs, ReffTrsID,
                        JenisMutasiID, QtyIn, QtyOut, NilaiIn, NilaiOut)
                VALUES (
                        @StokControl2ID, @StokID, @TglTrs, @JamTrs, @ReffTrsID,
                        @JenisMutasiID, @QtyIn, @QtyOut, @NilaiIn, @NilaiOut) ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@StokControl2ID", stokControl2.StokControl2ID);
                cmd.AddParam("@StokControlID", stokControl2.StokControlID);
                cmd.AddParam("@TglTrs", stokControl2.TglTrs);
                cmd.AddParam("@JamTrs", stokControl2.JamTrs);
                cmd.AddParam("@ReffTrsID", stokControl2.ReffTrsID);
                cmd.AddParam("@JenisMutasiID", stokControl2.JenisMutasiID);
                cmd.AddParam("@QtyIn", stokControl2.QtyIn);
                cmd.AddParam("@QtyOut", stokControl2.QtyOut);
                cmd.AddParam("@NilaiIn", stokControl2.NilaiIn );
                cmd.AddParam("@NilaiOut", stokControl2.NilaiOut);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string StokControl2ID)
        {
            var sSql = @"
                DELETE
                    StokControl2
                WHERE
                    StokDetilID = @StokDetilID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@StokControl2ID", StokControl2ID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<StokControl2Model> ListData(string stokControlID)
        {
            List<StokControl2Model> result = null;
            var sSql = @"
                SELECT
                    stokControl2ID, StokID, TglTrs, JamTrs, ReffTrsID,
                    JenisMutasiID, QtyIn, QtyOut, NilaiIn, NilaiOut
                FROM
                    stokControl2
                WHERE
                    stokControl2ID = @stokControl2ID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@StokID", stokControlID);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        result = new List<StokControl2Model>();
                        while (dr.Read())
                        {
                            var item = new StokControl2Model
                            {
                                StokControl2ID = dr["stokControl2ID"].ToString(),
                                StokControlID = dr["StokID"].ToString(),
                                TglTrs = dr["TglTrs"].ToString().ToTglDMY

                            }
                        }
                    }
                }
            }
        }
    }


}
