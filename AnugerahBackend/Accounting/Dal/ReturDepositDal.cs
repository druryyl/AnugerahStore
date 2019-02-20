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
    public interface IReturDepositDal : IHeaderTrsDal<ReturDepositModel>
    {
    }
    public class ReturDepositDal : IReturDepositDal
    {
        private string _connString;

        public ReturDepositDal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void Insert(ReturDepositModel model)
        {
            var sSql = @"
                INSERT INTO 
                    ReturDeposit (
                        ReturDepositID, Tgl, Jam, 
                        DepositID, JenisKasID, Catatan,  
                        NilaiSisaDeposit, NilaiReturDeposit) 
                VALUES (
                        @ReturDepositID, @Tgl, @Jam, 
                        @DepositID, @JenisKasID, @Catatan, 
                        @NilaiSisaDeposit, @NilaiReturDeposit ) ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@ReturDepositID", model.ReturDepositID);
                cmd.AddParam("@Tgl", model.Tgl.ToTglYMD());
                cmd.AddParam("@Jam", model.Jam);
                cmd.AddParam("@DepositID", model.DepositID);
                cmd.AddParam("@JenisKasID", model.JenisKasID);
                cmd.AddParam("@Catatan", model.Catatan);
                cmd.AddParam("@NilaiSisaDeposit", model.NilaiSisaDeposit);
                cmd.AddParam("@NilaiReturDeposit", model.NilaiReturDeposit);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(ReturDepositModel model)
        {
            var sSql = @"
                UPDATE
                    ReturDeposit 
                SET
                    Tgl = @Tgl, 
                    Jam = @Jam, 
                    DepositID = @DepositID,
                    JenisKasID = @JenisKasID,
                    Catatan = @Catatan, 
                    NilaiSisaDeposit = @NilaiSisaDeposit, 
                    NilaiReturDeposit = @NilaiReturDeposit 
                WHERE
                    ReturDepositID = @ReturDepositID  ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@ReturDepositID", model.ReturDepositID);
                cmd.AddParam("@Tgl", model.Tgl.ToTglYMD());
                cmd.AddParam("@Jam", model.Jam);
                cmd.AddParam("@DepositID", model.DepositID);
                cmd.AddParam("@JenisKasID", model.JenisKasID);
                cmd.AddParam("@Catatan", model.Catatan);
                cmd.AddParam("@NilaiSisaDeposit", model.NilaiSisaDeposit);
                cmd.AddParam("@NilaiReturDeposit", model.NilaiReturDeposit);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string id)
        {
            var sSql = @"
                DELETE
                    ReturDeposit 
                WHERE
                    ReturDepositID = @ReturDepositID  ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@ReturDepositID", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public ReturDepositModel GetData(string id)
        {
            ReturDepositModel result = null;
            var sSql = @"
                SELECT
                    aa.ReturDepositID, aa.Tgl, aa.Jam, 
                    aa.DepositID, aa.JenisKasID, aa.Catatan,
                    aa.NilaiSisaDeposit, aa.NilaiReturDeposit,
                    ISNULL(bb.JenisKasName, '') JenisKasName,
                    ISNULL(dd.PihakKeduaName, '') PihakKeduaName
                FROM    
                    ReturDeposit aa
                    LEFT JOIN JenisKas bb ON aa.JenisKasID = bb.JenisKasID 
                    LEFT JOIN Deposit cc ON aa.DepositID = cc.DepositID
                    LEFT JOIN PihakKedua dd ON cc.PihakKeduaID = dd.PihakKeduaID
                WHERE
                    aa.ReturDepositID = @ReturDepositID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@ReturDepositID", id);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (!dr.HasRows) return null;
                    dr.Read();
                    result = new ReturDepositModel
                    {
                        ReturDepositID = dr["ReturDepositID"].ToString(),
                        Tgl = dr["Tgl"].ToString().ToTglDMY(),
                        Jam = dr["Jam"].ToString(),
                        DepositID = dr["DepositID"].ToString(),
                        PihakKeduaName = dr["PihakKeduaName"].ToString(),
                        JenisKasID = dr["JenisKasID"].ToString(),
                        JenisKasName = dr["JenisKasName"].ToString(),
                        Catatan = dr["Catatan"].ToString(), 
                        NilaiSisaDeposit = Convert.ToDecimal(dr["NilaiSisaDeposit"]),
                        NilaiReturDeposit = Convert.ToDecimal(dr["NilaiReturDeposit"]),
                    };
                }
            }
            return result;
        }

        public IEnumerable<ReturDepositModel> ListData(string tgl1, string tgl2)
        {
            List<ReturDepositModel> result = null;
            var sSql = @"
                SELECT
                    aa.ReturDepositID, aa.Tgl, aa.Jam, 
                    aa.DepositID, aa.JenisKasID, aa.Catatan,
                    aa.NilaiSisaDeposit, aa.NilaiReturDeposit,
                    ISNULL(bb.JenisKasName, '') JenisKasName,
                    ISNULL(dd.PihakKeduaName, '') PihakKeduaName
                FROM    
                    ReturDeposit aa
                    LEFT JOIN JenisKas bb ON aa.JenisKasID = bb.JenisKasID 
                    LEFT JOIN Deposit cc ON aa.DepositID = cc.DepositID
                    LEFT JOIN PihakKedua dd ON cc.PihakKeduaID = dd.PihakKeduaID
                WHERE
                    aa.Tgl BETWEEN @Tgl1 AND @Tgl2  ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@Tgl1", tgl1.ToTglYMD());
                cmd.AddParam("@Tgl2", tgl2.ToTglYMD());
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (!dr.HasRows) return null;
                    result = new List<ReturDepositModel>();
                    while (dr.Read())
                    {
                        var item = new ReturDepositModel
                        {
                            ReturDepositID = dr["ReturDepositID"].ToString(),
                            Tgl = dr["Tgl"].ToString().ToTglDMY(),
                            Jam = dr["Jam"].ToString(),
                            DepositID = dr["DepositID"].ToString(),
                            PihakKeduaName = dr["PihakKeduaName"].ToString(),
                            JenisKasID = dr["JenisKasID"].ToString(),
                            JenisKasName = dr["JenisKasName"].ToString(),
                            Catatan = dr["Catatan"].ToString(),
                            NilaiSisaDeposit = Convert.ToDecimal(dr["NilaiSisaDeposit"]),
                            NilaiReturDeposit = Convert.ToDecimal(dr["NilaiReturDeposit"]),
                        };
                        result.Add(item);
                    }
                }
            }
            return result;
        }
    }
}