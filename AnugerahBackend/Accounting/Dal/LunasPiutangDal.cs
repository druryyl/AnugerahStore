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

    public interface ILunasPiutangDal
    {
        void Insert(LunasPiutangModel model);
        void Update(LunasPiutangModel model);
        void Delete(string id);
        LunasPiutangModel GetData(string id);
        IEnumerable<LunasPiutangModel> ListData(string tgl1, string tgl2);
    }


    public class LunasPiutangDal : ILunasPiutangDal
    {
        private readonly string _connString;

        public LunasPiutangDal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void Insert(LunasPiutangModel model)
        {
            //  define
            var sSql = @"
                INSERT INTO
                    LunasPiutang (
                        LunasPiutangID, Tgl, Jam,
                        PihakKeduaID, JenisBayarID,
                        TotalNilaiSisaPiutang, TotalNilaiBayar)
                VALUES (
                        @LunasPiutangID, @Tgl, @Jam,
                        @PihakKeduaID, @JenisBayarID,
                        @TotalNilaiSisaPiutang, @TotalNilaiBayar) ";

            //  execute
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@LunasPiutangID", model.LunasPiutangID);
                cmd.AddParam("@Tgl", model.Tgl.ToTglYMD());
                cmd.AddParam("@Jam", model.Jam);
                cmd.AddParam("@PihakKeduaID", model.PihakKeduaID);
                cmd.AddParam("@JenisBayarID", model.JenisBayarID);
                cmd.AddParam("@TotalNilaiSisaPiutang", model.TotalNilaiSisaPiutang);
                cmd.AddParam("@TotalNilaiBayar", model.TotalNilaiBayar);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(LunasPiutangModel model)
        {
            //  define
            var sSql = @"
                UPDATE
                    LunasPiutang 
                SET
                    Tgl = @Tgl,
                    Jam = @Jam,
                    PihakKeduaID = @PihakKeduaID,
                    JenisBayarID = @JenisBayarID, 
                    TotalNilaiSisaPiutang = @TotalNilaiSisaPiutang,
                    TotalNilaiBayar = @TotalNilaiBayar
                WHERE
                    LunasPiutangID = @LunasPiutangID ";

            //  execute
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@LunasPiutangID", model.LunasPiutangID);
                cmd.AddParam("@Tgl", model.Tgl.ToTglYMD());
                cmd.AddParam("@Jam", model.Jam);
                cmd.AddParam("@PihakKeduaID", model.PihakKeduaID);
                cmd.AddParam("@JenisBayarID", model.JenisBayarID);
                cmd.AddParam("@TotalNilaiSisaPiutang", model.TotalNilaiSisaPiutang);
                cmd.AddParam("@TotalNilaiBayar", model.TotalNilaiBayar);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string id)
        {
            //  define
            var sSql = @"
                DELETE 
                    LunasPiutang 
                WHERE
                    LunasPiutangID = @LunasPiutangID ";

            //  execute
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@LunasPiutangID", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public LunasPiutangModel GetData(string id)
        {
            //  define
            LunasPiutangModel result = null;
            var sSql = @"
                SELECT
                    aa.Tgl, aa.Jam,
                    aa.PihakKeduaID, aa.JenisBayarID, 
                    TotalNilaiSisaPiutang, TotalNilaiBayar,
                    ISNULL(bb.PihakKeduaName, '') PihakKeduaName,
                    ISNULL(cc.JenisBayarName, '') JenisBayarName
                FROM
                    LunasPiutang aa
                    LEFT JOIN PihakKedua bb ON aa.PihakKeduaID = bb.PihakKeduaID
                    LEFT JOIN JenisBayar cc ON aa.JenisBayarID = cc.JenisBayarID
                WHERE
                    aa.LunasPiutangID = @LunasPiutangID ";

            //  execute
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@LunasPiutangID", id);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (!dr.HasRows)
                        return null;

                    //  read
                    dr.Read();
                    result = new LunasPiutangModel
                    {
                        LunasPiutangID = id,
                        Tgl = dr["Tgl"].ToString(),
                        Jam = dr["Jam"].ToString(),
                        PihakKeduaID = dr["PihakKeduaID"].ToString(),
                        PihakKeduaName = dr["PihakKeduaName"].ToString(),
                        JenisBayarID = dr["JenisBayarID"].ToString(),
                        JenisBayarName = dr["JenisBayarName"].ToString(),
                        TotalNilaiSisaPiutang = Convert.ToDecimal(dr["TotalNilaiSisaPiutang"]),
                        TotalNilaiBayar  = Convert.ToDecimal(dr["TotalNilaiBayar"])
                    };
                }
            }
            return result;
        }

        public IEnumerable<LunasPiutangModel> ListData(string tgl1, string tgl2)
        {
            //   define
            List<LunasPiutangModel> result = null;
            var sSql = @"
                SELECT
                    aa.LunasPiutangID, aa.Tgl, aa.Jam,
                    aa.PihakKeduaID, aa.JenisBayarID, 
                    TotalNilaiSisaPiutang, TotalNilaiBayar,
                    ISNULL(bb.PihakKeduaName, '') PihakKeduaName,
                    ISNULL(cc.JenisBayarName, '') JenisBayarName
                FROM
                    LunasPiutang aa
                    LEFT JOIN PihakKedua bb ON aa.PihakKeduaID = bb.PihakKeduaID
                    LEFT JOIN JenisBayar cc ON aa.JenisBayarID = cc.JenisBayarID 
                WHERE
                    Tgl BETWEEN @Tgl1 AND @Tgl2 ";

            //  execute
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@Tgl1", tgl1.ToTglYMD());
                cmd.AddParam("@Tgl2", tgl2.ToTglYMD());
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (!dr.HasRows)
                        return null;

                    //  read
                    result = new List<LunasPiutangModel>();
                    while (dr.Read())
                    {
                        var item = new LunasPiutangModel
                        {
                            LunasPiutangID = dr["LunasPiutangID"].ToString(),
                            Tgl = dr["Tgl"].ToString(),
                            Jam = dr["Jam"].ToString(),
                            PihakKeduaID = dr["PihakKeduaID"].ToString(),
                            PihakKeduaName = dr["PihakKeduaName"].ToString(),
                            JenisBayarID = dr["JenisBayarID"].ToString(),
                            JenisBayarName = dr["JenisBayarName"].ToString(),
                            TotalNilaiSisaPiutang = Convert.ToDecimal(dr["TotalNilaiSisaPiutang"]),
                            TotalNilaiBayar = Convert.ToDecimal(dr["TotalNilaiBayar"])
                        };
                        result.Add(item);
                    }
                }
            }
            return result;
        }
    }
}
