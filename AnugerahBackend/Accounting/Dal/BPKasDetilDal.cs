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
    public interface IBPKasDetilDal : IDetilTrsDal<BPKasDetilModel>
    {
    }

    public class BPKasDetilDal : IBPKasDetilDal
    {
        private string _connString;

        public BPKasDetilDal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void Insert(BPKasDetilModel model)
        {
            var sSql = @"
                INSERT INTO
                    BPKasDetil (
                        BPKasID, BPKasDetilID, JenisKasID, 
                        NilaiKasMasuk, NilaiKasKeluar)
                VALUES (
                        @BPKasID, @BPKasDetilID, @JenisKasID, 
                        @NilaiKasMasuk, @NilaiKasKeluar) ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BPKasID", model.BPKasID);
                cmd.AddParam("@BPKasDetilID", model.BPKasDetilID);
                cmd.AddParam("@JenisKasID", model.JenisKasID);
                cmd.AddParam("@NilaiKasMasuk", model.NilaiKasMasuk);
                cmd.AddParam("@NilaiKasKeluar", model.NilaiKasKeluar);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string id)
        {
            var sSql = @"
                DELETE
                    BPKasDetil
                WHERE
                    BPKasID = @BPKasID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BPKasID", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<BPKasDetilModel> ListData(string id)
        {
            List<BPKasDetilModel> result = null;
            var sSql = @"
                SELECT
                    aa.BPKasID, aa.BPKasDetilID, aa.JenisKasID, 
                    aa.NilaiKasMasuk, aa.NilaiKasKeluar,
                    ISNULL(bb.JenisKasName, '') JenisKasName
                FROM
                    BPKasDetil aa
                    LEFT JOIN JenisKas bb ON aa.JenisKasID = bb.JenisKasID
                WHERE
                    BPKasID = @BPKasID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BPKasID", id);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (!dr.HasRows) return null;
                    result = new List<BPKasDetilModel>();
                    while (dr.Read())
                    {
                        var item = new BPKasDetilModel
                        {
                            BPKasID = dr["BPKasID"].ToString(),
                            BPKasDetilID = dr["BPKasDetilID"].ToString(),
                            JenisKasID= dr["JenisKasID"].ToString(),
                            JenisKasName = dr["JenisKasName"].ToString(),
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
