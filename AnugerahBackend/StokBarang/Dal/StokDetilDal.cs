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
        IEnumerable<StokDetilModel> ListData(string stokID)
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

            }
        }
        public void Delete(string stokDetilID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StokDetilModel> ListData(string stokID)
        {
            throw new NotImplementedException();
        }
    }


}
