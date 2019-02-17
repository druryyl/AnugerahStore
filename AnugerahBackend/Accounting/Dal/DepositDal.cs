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
    public interface IDepositDal
    {
        void Insert(DepositModel model);
        void Update(DepositModel model);
        void Delete(string id);
        DepositModel GetData(string id);
        IEnumerable<DepositModel> ListData(string tgl1, string tgl2);
    }
    public class DepositDal : IDepositDal
    {
        private string _connString;

        public DepositDal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void Insert(DepositModel model)
        {
            var sSql = @"
                INSERT INTO
                    Deposit (
                        DepositID, Tgl, Jam, PihakKeduaID,
                        Keterangan, NilaiDeposit) 
                VALUES (
                        @DepositID, @Tgl, @Jam, @PihakKeduaID,
                        @Keterangan, @NilaiDeposit) ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql,conn))
            {
                cmd.AddParam("@DepositID", model.DepositID);
                cmd.AddParam("@Tgl", model.Tgl.ToTglYMD());
                cmd.AddParam("@Jam", model.Jam);
                cmd.AddParam("@PihakKeduaID", model.PihakKeduaID);
                cmd.AddParam("@Keterangan", model.Keterangan);
                cmd.AddParam("@NilaiDeposit", model.NilaiDeposit);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(DepositModel model)
        {
            var sSql = @"
                UPDATE
                    Deposit 
                SET
                    Tgl = @Tgl, 
                    Jam = @Jam, 
                    PihakKeduaID = @PihakKeduaID,
                    Keterangan = @Keterangan, 
                    NilaiDeposit = @NilaiDeposit 
                WHERE
x                   DepositID = @DepositID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@DepositID", model.DepositID);
                cmd.AddParam("@Tgl", model.Tgl.ToTglYMD());
                cmd.AddParam("@Jam", model.Jam);
                cmd.AddParam("@PihakKeduaID", model.PihakKeduaID);
                cmd.AddParam("@Keterangan", model.Keterangan);
                cmd.AddParam("@NilaiDeposit", model.NilaiDeposit);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string id)
        {
            var sSql = @"
                DELETE
                    Deposit 
                WHERE
x                   DepositID = @DepositID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@DepositID", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public DepositModel GetData(string id)
        {
            DepositModel result = null;

            var sSql = @"
                SELECT
                    aa.DepositID, aa.Tgl, aa.Jam, aa.PihakKeduaID,
                    aa.Keterangan, aa.NilaiDeposit,
                    ISNULL(bb.PihakKeduaID, '') PihakKeduaID 
                FROM
                    Deposit aa
                    LEFT JOIN PihakKedua bb ON aa.PihakKeduaID = bb.PihakKeduaID 
                WHERE
                    aa.DepositID = @DepositID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@DepositID", id);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (!dr.HasRows) return null;
                    dr.Read();
                    result = new DepositModel
                    {
                        DepositID = dr["DepositID"].ToString(),
                        Tgl = dr["Tgl"].ToString().ToTglDMY(),
                        Jam = dr["Jam"].ToString(),
                        PihakKeduaID = dr["PihakKeduaID"].ToString(),
                        PihakKeduaName = dr["PihakKeduaName"].ToString(),
                        Keterangan = dr["Keterangan"].ToString(),
                        NilaiDeposit = Convert.ToDecimal(dr["NilaiDeposit"]),
                    };
                }
            }
            return result;
        }

        public IEnumerable<DepositModel> ListData(string tgl1, string tgl2)
        {
            List<DepositModel> result = null;

            var sSql = @"
                SELECT
                    aa.DepositID, aa.Tgl, aa.Jam, aa.PihakKeduaID,
                    aa.Keterangan, aa.NilaiDeposit,
                    ISNULL(bb.PihakKeduaID, '') PihakKeduaID 
                FROM
                    Deposit aa
                    LEFT JOIN PihakKedua bb ON aa.PihakKeduaID = bb.PihakKeduaID 
                WHERE
                    aa.Tgl BETWEEN @Tgl1 AND @Tgl2 ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@Tgl1", tgl1.ToTglYMD());
                cmd.AddParam("@Tgl2", tgl2.ToTglYMD());
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (!dr.HasRows) return null;
                    result = new List<DepositModel>();
                    while (dr.Read())
                    {
                        var item = new DepositModel
                        {
                            DepositID = dr["DepositID"].ToString(),
                            Tgl = dr["Tgl"].ToString().ToTglDMY(),
                            Jam = dr["Jam"].ToString(),
                            PihakKeduaID = dr["PihakKeduaID"].ToString(),
                            PihakKeduaName = dr["PihakKeduaName"].ToString(),
                            Keterangan = dr["Keterangan"].ToString(),
                            NilaiDeposit = Convert.ToDecimal(dr["NilaiDeposit"]),
                        };
                        result.Add(item);
                    }
                }
            }
            return result;
        }
    }
}
