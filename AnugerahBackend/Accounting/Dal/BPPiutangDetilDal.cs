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
    public interface IBPPiutangDetilDal : IDetilTrsDal<BPPiutangDetilModel>
    {

    }

    public class BPPiutangDetilDal : IBPPiutangDetilDal
    {
        private string _connString;

        public BPPiutangDetilDal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void Insert(BPPiutangDetilModel model)
        {
            var sSql = @"
                INSERT INTO
                    BPPiutangDetil (
                        BPPiutangID, BPPiutangDetilID, ReffID, 
                        Tgl, Jam, Keterangan, 
                        NilaiPiutang, NilaiLunas)
                VALUES (
                        @BPPiutangID, @BPPiutangDetilID, @ReffID, 
                        @Tgl, @Jam, @Keterangan, 
                        @NilaiPiutang, @NilaiLunas) ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BPPiutangID", model.BPPiutangID);
                cmd.AddParam("@BPPiutangDetilID", model.BPPiutangDetilID);
                cmd.AddParam("@ReffID", model.ReffID);
                cmd.AddParam("@Tgl", model.Tgl.ToTglYMD());
                cmd.AddParam("@Jam", model.Jam);
                cmd.AddParam("@Keterangan", model.Keterangan);
                cmd.AddParam("@NilaiPiutang", model.NilaiPiutang);
                cmd.AddParam("@NilaiLunas", model.NilaiLunas);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string id)
        {
            var sSql = @"
                DELETE
                    BPPiutangDetil
                WHERE
                    BPPiutangID = @BPPiutangID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BPPiutangID", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<BPPiutangDetilModel> ListData(string id)
        {
            List<BPPiutangDetilModel> result = null;
            var sSql = @"
                SELECT
                    BPPiutangID, BPPiutangDetilID, ReffID, 
                    Tgl, Jam, Keterangan, 
                    NilaiPiutang, NilaiLunas
                FROM
                    BPPiutangDetil
                WHERE
                    BPPiutangID = @BPPiutangID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BPPiutangID", id);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (!dr.HasRows) return null;
                    result = new List<BPPiutangDetilModel>();
                    while (dr.Read())
                    {
                        var item = new BPPiutangDetilModel
                        {
                            BPPiutangID = dr["BPPiutangID"].ToString(),
                            BPPiutangDetilID = dr["BPPiutangDetilID"].ToString(),
                            ReffID = dr["ReffID"].ToString(),
                            Tgl = dr["Tgl"].ToString().ToTglDMY(),
                            Jam = dr["Jam"].ToString(),
                            Keterangan = dr["Keterangan"].ToString(),
                            NilaiPiutang = Convert.ToDecimal(dr["NilaiPiutang"]),
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
