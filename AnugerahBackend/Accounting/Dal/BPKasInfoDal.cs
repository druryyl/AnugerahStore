
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnugerahBackend.Accounting.Model;
using Ics.Helper.Extensions;
using Ics.Helper.StringDateTime;

namespace AnugerahBackend.Accounting.Dal
{
    public interface IBPKasInfoDal
    {
        IEnumerable<BPKasInfoModel> ListData(string tgl1, string tgl2);
    }

    public class BPKasInfoDal : IBPKasInfoDal
    {
        private string _connString;

        public BPKasInfoDal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public IEnumerable<BPKasInfoModel> ListData(string tgl1, string tgl2)
        {
            List<BPKasInfoModel> result = null;

            var sSql = @"
                SELECT
                    aa.BPKasID, aa.BPKasDetilID, bb.Tgl, bb.Jam,
                    bb.Keterangan, aa.JenisKasID, 
                    aa.NilaiKasMasuk, aa.NilaiKasKeluar,
                    ISNULL(cc.JenisKasName, '') JenisKasName
                FROM
                    BPKasDetil aa
                    INNER JOIN BPKas bb ON aa.BPKasID = bb.BPKasID
                    LEFT JOIN JenisKas cc ON aa.JenisKasID = cc.JenisKasID
                WHERE
                    bb.Tgl BETWEEN @Tgl1 AND @Tgl2 ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@Tgl1", tgl1.ToTglYMD());
                cmd.AddParam("@Tgl2", tgl2.ToTglYMD());
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (!dr.HasRows) return null;

                    result = new List<BPKasInfoModel>();
                    while (dr.Read())
                    {
                        var item = new BPKasInfoModel
                        {
                            BPKasID = dr["BPKasID"].ToString(),
                            BPKasDetilID = dr["BPKasDetilID"].ToString(),
                            Tgl = dr["Tgl"].ToString().ToDate(),
                            Jam = dr["Jam"].ToString(),
                            JenisKasID = dr["JenisKasID"].ToString(),
                            JenisKasName = dr["JenisKasName"].ToString(),
                            Keterangan = dr["Keterangan"].ToString(),
                            NilaiKasMasuk = Convert.ToDecimal(dr["NilaiKasMasuk"]),
                            NilaiKasKeluar = Convert.ToDecimal(dr["NilaiKasKeluar"]),
                        };
                        result.Add(item);
                    }
                }
            }
            return result;
        }

    }
}
