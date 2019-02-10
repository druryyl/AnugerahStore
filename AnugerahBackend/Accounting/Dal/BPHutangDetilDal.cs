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
    public interface IBPHutangDetilDal : IDetilTrsDal<BPHutangDetilModel>
    {

    }

    public class BPHutangDetilDal : IBPHutangDetilDal
    {
        private string _connString;

        public BPHutangDetilDal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void Insert(BPHutangDetilModel model)
        {
            var sSql = @"
                INSERT INTO
                    BPHutangDetil (
                        BPHutangID, BPHutangDetilID, Tgl, Jam, 
                        Keterangan, NilaiHutang, NilaiLunas);
                VALUES (
                        @BPHutangID, @BPHutangDetilID, @Tgl, @Jam, 
                        @Keterangan, @NilaiHutang, @NilaiLunas) ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BPHutangID", model.BPHutangID);
                cmd.AddParam("@BPHutangDetilID", model.BPHutangDetilID);
                cmd.AddParam("@Tgl", model.Tgl.ToTglYMD());
                cmd.AddParam("@Jam", model.Jam);
                cmd.AddParam("@Keterangan", model.Keterangan);
                cmd.AddParam("@NilaiHutang", model.NilaiHutang);
                cmd.AddParam("@NilaiLunas", model.NilaiLunas);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string id)
        {
            var sSql = @"
                DELETE
                    BPHutangDetil
                WHERE
                    BPHutangID = @BPHutangID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BPHutangID", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<BPHutangDetilModel> ListData(string id)
        {
            List<BPHutangDetilModel> result = null;
            var sSql = @"
                SELECT
                    BPHutangID, BPHutangDetilID, Tgl, Jam, 
                    Keterangan, NilaiHutang, NilaiLunas);
                FROM
                    BPHutangDetil
                WHERE
                    BPHutangID = @BPHutangID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BPHutangID", id);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if(!dr.HasRows) return null;
                    result = new List<BPHutangDetilModel>();
                    while (dr.Read())
                    {
                        var item = new BPHutangDetilModel
                        {
                            BPHutangID = dr["BPHutangID"].ToString(),
                            BPHutangDetilID = dr["BPHutangDetilID"].ToString(),
                            ReffID = dr["ReffID"].ToString(),
                            Tgl = dr["Tgl"].ToString().ToTglDMY(),
                            Jam = dr["Jam"].ToString(),
                            Keterangan = dr["Keterangan"].ToString(),
                            NilaiHutang = Convert.ToDecimal(dr["NilaiHutang"]),
                            NilaiLunas = Convert.ToDecimal(dr["NilaiLunas"]),
                        };
                        result.Add(item);
                    }
                }
            }
            return result;
        }
    }
}
