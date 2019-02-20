using System;
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
    public interface IBiayaDal : IHeaderTrsDal<BiayaModel>
    {

    }

    public  class BiayaDal : IBiayaDal
    {
        private string _connString;

        public BiayaDal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void Insert(BiayaModel model)
        {
            var sSql = @"
                INSERT INTO
                    Biaya (
                        BiayaID, Tgl, Jam, Keterangan, 
                        JenisBiayaID, JenisKasID, NilaiBiaya)
                VALUES (
                        @BiayaID, @Tgl, @Jam, @Keterangan, 
                        @JenisBiayaID, @JenisKasID, @NilaiBiaya) ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BiayaID", model.BiayaID);
                cmd.AddParam("@Tgl", model.Tgl.ToTglYMD());
                cmd.AddParam("@Jam", model.Jam);
                cmd.AddParam("@Keterangan", model.Keterangan);
                cmd.AddParam("@JenisBiayaID", model.JenisBiayaID);
                cmd.AddParam("@JenisKasID", model.JenisKasID);
                cmd.AddParam("@NilaiBiaya", model.NilaiBiaya);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(BiayaModel model)
        {
            var sSql = @"
                UPDATE
                    Biaya 
                SET 
                    Tgl = @Tgl, 
                    Jam = @Jam, 
                    Keterangan = @Keterangan, 
                    JenisBiayaID = @JenisBiayaID, 
                    JenisKasID = @JenisKasID, 
                    NilaiBiaya = @NilaiBiaya 
                WHERE
                    BiayaID = @BiayaID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BiayaID", model.BiayaID);
                cmd.AddParam("@Tgl", model.Tgl.ToTglYMD());
                cmd.AddParam("@Jam", model.Jam);
                cmd.AddParam("@Keterangan", model.Keterangan);
                cmd.AddParam("@JenisBiayaID", model.JenisBiayaID);
                cmd.AddParam("@JenisKasID", model.JenisKasID);
                cmd.AddParam("@NilaiBiaya", model.NilaiBiaya);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string id)
        {
            var sSql = @"
                DELETE
                    Biaya
                WHERE
                    BiayaID = @BiayaID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BiayaID", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public BiayaModel GetData(string id)
        {
            BiayaModel result = null;
            var sSql = @"
                SELECT
                    aa.BiayaID, aa.Tgl, aa.Jam, aa.Keterangan, 
                    aa.JenisBiayaID, aa.JenisKasID, aa.NilaiBiaya,
                    ISNULL(bb.JenisBiayaName,'') JenisBiayaName,
                    ISNULL(cc.JenisKasName, '') JenisKasName
                FROM
                    Biaya aa
                    LEFT JOIN JenisBiaya bb ON aa.JenisBiayaID = bb.JenisBiayaID
                    LEFT JOIN JenisKas cc ON aa.JenisKasID = cc.JenisKasID
                WHERE
                    BiayaID = @BiayaID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BiayaID", id);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (!dr.HasRows) return null;
                    dr.Read();
                    result = new BiayaModel
                    {
                        BiayaID = id,
                        Tgl = dr["Tgl"].ToString().ToTglDMY(),
                        Jam = dr["Jam"].ToString(),
                        Keterangan = dr["Keterangan"].ToString(),
                        JenisBiayaID = dr["JenisBiayaID"].ToString(),
                        JenisBiayaName = dr["JenisBiayaName"].ToString(),
                        JenisKasID = dr["JenisKasID"].ToString(),
                        JenisKasName = dr["JenisKasName"].ToString(),
                        NilaiBiaya = Convert.ToDecimal(dr["NilaiBiaya"])
                    };
                }
            }
            return result;
        }

        public IEnumerable<BiayaModel> ListData(string tgl1, string tgl2)
        {
            List<BiayaModel> result = null;
            var sSql = @"
                SELECT
                    aa.BiayaID, aa.Tgl, aa.Jam, aa.Keterangan, 
                    aa.JenisBiayaID, aa.JenisKasID, aa.NilaiBiaya,
                    ISNULL(bb.JenisBiayaName, '') JenisBiayaName,
                    ISNULL(cc.JenisKasName, '') JenisKasName
                FROM
                    Biaya aa
                    LEFT JOIN JenisBiaya bb ON aa.JenisBiayaID = bb.JenisBiayaID
                    LEFT JOIN JenisKas cc ON aa.JenisKasID = cc.JenisKasID
                WHERE
                    Tgl BETWEEN @Tgl1 AND @Tgl2 ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@Tgl1", tgl1.ToTglYMD());
                cmd.AddParam("@Tgl2", tgl2.ToTglYMD());
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (!dr.HasRows) return null;
                    result = new List<BiayaModel>();
                    while (dr.Read())
                    {
                        var item = new BiayaModel
                        {
                            BiayaID = dr["BiayaID"].ToString(),
                            Tgl = dr["Tgl"].ToString().ToTglDMY(),
                            Jam = dr["Jam"].ToString(),
                            Keterangan = dr["Keterangan"].ToString(),
                            JenisBiayaID = dr["JenisBiayaID"].ToString(),
                            JenisBiayaName = dr["JenisBiayaName"].ToString(),
                            JenisKasID = dr["JenisKasID"].ToString(),
                            JenisKasName = dr["JenisKasName"].ToString(),
                            NilaiBiaya = Convert.ToDecimal(dr["NilaiBiaya"])
                        };
                        result.Add(item);
                    }
                }
            }
            return result;
        }
    }
}
