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
        IEnumerable<LunasPiutangModel> ListData();
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
                        PihakKeduaID, PiutangID, 
                        NilaiSisaPiutang, NilaiLunas)
                VALUES (
                        @LunasPiutangID, @Tgl, @Jam
                        @PihakKeduaID, @PiutangID, 
                        @NilaiSisaPiutang, @NilaiLunas) ";

            //  execute
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@LunasPiutangID", model.LunasPiutangID);
                cmd.AddParam("@Tgl", model.Tgl.ToTglYMD());
                cmd.AddParam("@Jam", model.Jam);
                cmd.AddParam("@PihakKeduaID", model.PihakKeduaID);
                cmd.AddParam("@PiutangID", model.PiutangID);
                cmd.AddParam("@NilaiSisaPiutang", model.NilaiSisaPiutang);
                cmd.AddParam("@NilaiLunas", model.NilaiLunas);
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
                    PiutangID = @PiutangID,
                    NilaiSisaPiutang = @NilaiSisaPiutang,
                    NilaiLunas = @NilaiLunas
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
                cmd.AddParam("@PiutangID", model.PiutangID);
                cmd.AddParam("@NilaiSisaPiutang", model.NilaiSisaPiutang);
                cmd.AddParam("@NilaiLunas", model.NilaiLunas);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string id)
        {
            //  define
            var sSql = @"
                DELETE FROM 
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
                    aa.PihakKeduaID, aa.PiutangID, 
                    ISNULL(bb.PihakKeduaName, '') PihakKeduaName,
                    NilaiSisaPiutang, NilaiLunas
                FROM
                    LunasPiutang aa
                    LEFT JOIN PihakKedua bb ON aa.PihakKeduaID = bb.PihakKeduaID
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
                        PihaKeduaName = dr["PihakKeduaName"].ToString(),
                        PiutangID = dr["PiutangID"].ToString(),
                        NilaiSisaPiutang = Convert.ToDecimal(dr["NilaiSisaPiutang"]),
                        NilaiLunas = Convert.ToDecimal(dr["NilaiLunas"])
                    };
                }
            }
            return result;
        }

        public IEnumerable<LunasPiutangModel> ListData()
        {
            //   define
            List<LunasPiutangModel> result = null;
            var sSql = @"
                SELECT
                    aa.LunasPiutangID, aa.Tgl, aa.Jam,
                    aa.PihakKeduaID, aa.PiutangID,
                    aa.NilaiSisaPiutang, aa.NilaiLunas,
                    ISNULL(bb.PihakKeduaName, '') PihakKeduaName
                FROM
                    LunasPiutang aa 
                    LEFT JOIN PihakKedua bb ON aa.PihakKeduaID = bb.PihakKeduaID  ";

            //  execute
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
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
                            PihaKeduaName = dr["PihakKeduaName"].ToString(),
                            PiutangID = dr["PiutangID"].ToString(),
                            NilaiSisaPiutang = Convert.ToDecimal(dr["NilaiSisaPiutang"]),
                            NilaiLunas = Convert.ToDecimal(dr["NilaiLunas"])
                        };
                        result.Add(item);
                    }
                }
            }
            return result;
        }
    }
}
