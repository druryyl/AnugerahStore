using AnugerahBackend.Accounting.Model;
using Ics.Helper.Extensions;
using Ics.Helper.StringDateTime;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Accounting.Dal
{
    public interface ILunasPiutangDetilDal
    {
        void Insert(LunasPiutangDetilModel model);
        void Delete(string id);
        IEnumerable<LunasPiutangDetilModel> ListData(string id);
    }

    public class LunasPiutangDetilDal : ILunasPiutangDetilDal
    {
        private readonly string _connString;

        public LunasPiutangDetilDal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void Insert(LunasPiutangDetilModel model)
        {
            var sSql = @" 
                INSERT INTO
                    LunasPiutangDetil (
                        LunasPiutangID, LunasPiutangID2, PiutangID, Tgl,
                        NilaiSisaPiutang, NilaiBayar)
                VALUES (
                        @LunasPiutangID, @LunasPiutangID2, @PiutangID, @Tgl,
                        @NilaiSisaPiutang, @NilaiBayar) ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@LunasPiutangID", model.LunasPiutangID);
                cmd.AddParam("@LunasPiutangID2", model.LunasPiutangID2);
                cmd.AddParam("@PiutangID", model.PiutangID);
                cmd.AddParam("@Tgl", model.Tgl.ToTglYMD());
                cmd.AddParam("@NilaiSisaPiutang", model.NilaiSisaPiutang);
                cmd.AddParam("@NilaiBayar", model.NilaiBayar);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string id)
        {
            var sSql = @"
                DELETE
                    LunasPiutangDetil
                WHERE
                    LunasPiutangID = @LunasPiutangID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@LunasPiutangID", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<LunasPiutangDetilModel> ListData(string id)
        {
            List<LunasPiutangDetilModel> result = null;
            var sSql = @"
                SELECT
                    aa.LunasPiutangID, aa.LunasPiutangID2, aa.Tgl,
                    aa.PiutangID, aa.NilaiSisaPiutang, aa.NilaiBayar
                FROM
                    LunasPiutangDetil aa
                WHERE
                    LunasPiutangID = @LunasPiutangID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@LunasPiutangID", id);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (!dr.HasRows)
                        return null;
                    result = new List<LunasPiutangDetilModel>();
                    while (dr.Read())
                    {
                        var item = new LunasPiutangDetilModel
                        {
                            LunasPiutangID = id,
                            LunasPiutangID2 = dr["LunasPiutangID2"].ToString(),
                            PiutangID = dr["PiutangID"].ToString(),
                            Tgl = dr["Tgl"].ToString().ToTglDMY(),
                            NilaiSisaPiutang = Convert.ToDecimal(dr["NilaiSisaPiutang"]),
                            NilaiBayar = Convert.ToDecimal(dr["NilaiBayar"])
                        };
                        result.Add(item);
                    }
                }
            }
            return result;
        }
    }
}
