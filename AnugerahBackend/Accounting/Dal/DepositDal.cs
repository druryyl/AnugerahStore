﻿using System;
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
                        BuyerName, Keterangan, JenisBayarID, 
                        NilaiBiayaKirim, NilaiDeposit) 
                VALUES (
                        @DepositID, @Tgl, @Jam, @PihakKeduaID,
                        @BuyerName, @Keterangan, @JenisBayarID, 
                        @NilaiBiayaKirim, @NilaiDeposit) ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql,conn))
            {
                cmd.AddParam("@DepositID", model.DepositID);
                cmd.AddParam("@Tgl", model.Tgl.ToTglYMD());
                cmd.AddParam("@Jam", model.Jam);
                cmd.AddParam("@PihakKeduaID", model.PihakKeduaID);
                cmd.AddParam("@BuyerName", model.BuyerName);

                cmd.AddParam("@Keterangan", model.Keterangan);
                cmd.AddParam("@JenisBayarID", model.JenisBayarID);

                cmd.AddParam("@NilaiBiayaKirim", model.NilaiBiayaKirim);
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
                    BuyerName = @BuyerName,
                    Keterangan = @Keterangan, 
                    JenisBayarID = @JenisBayarID, 
                    NilaiBiayaKirim = @NilaiBiayaKirim, 
                    NilaiDeposit = @NilaiDeposit 
                WHERE
                    DepositID = @DepositID ";

            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@DepositID", model.DepositID);
                cmd.AddParam("@Tgl", model.Tgl.ToTglYMD());
                cmd.AddParam("@Jam", model.Jam);
                cmd.AddParam("@PihakKeduaID", model.PihakKeduaID);
                cmd.AddParam("@BuyerName", model.BuyerName);

                cmd.AddParam("@Keterangan", model.Keterangan);
                cmd.AddParam("@JenisBayarID", model.JenisBayarID);

                cmd.AddParam("@NilaiBiayaKirim", model.NilaiBiayaKirim);
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
                   DepositID = @DepositID ";
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
                    aa.BuyerName, aa.Keterangan, aa.JenisBayarID, 
                    aa.NilaiBiayaKirim, aa.NilaiDeposit,
                    ISNULL(bb.PihakKeduaName, '') PihakKeduaName,
                    ISNULL(cc.JenisBayarName, '') JenisBayarName,
                    ISNULL(cc.JenisKasID, '') JenisKasID,
                    ISNULL(dd.JenisKasName, '') JenisKasName
                FROM
                    Deposit aa
                    LEFT JOIN PihakKedua bb ON aa.PihakKeduaID = bb.PihakKeduaID 
                    LEFT JOIN JenisBayar cc ON aa.JenisBayarID = cc.JenisBayarID
                    LEFT JOIN JenisKas dd ON cc.JenisKasID = dd.JenisKasID
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
                        BuyerName = dr["BuyerName"].ToString(),
                        
                        Keterangan = dr["Keterangan"].ToString(),
                        JenisBayarID = dr["JenisBayarID"].ToString(),
                        JenisBayarName = dr["JenisBayarName"].ToString(),
                        JenisKasID = dr["JenisKasID"].ToString(),
                        JenisKasName = dr["JenisKasName"].ToString(),
                        NilaiBiayaKirim = Convert.ToDecimal(dr["NilaiBiayaKirim"]),
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
                    aa.BuyerName, aa.Keterangan, aa.JenisBayarID, 
                    aa.NilaiBiayaKirim, aa.NilaiDeposit,
                    ISNULL(bb.PihakKeduaName, '') PihakKeduaName,
                    ISNULL(cc.JenisBayarName, '') JenisBayarName,
                    ISNULL(cc.JenisKasID, '') JenisKasID,
                    ISNULL(dd.JenisKasName, '') JenisKasName
                FROM
                    Deposit aa
                    LEFT JOIN PihakKedua bb ON aa.PihakKeduaID = bb.PihakKeduaID 
                    LEFT JOIN JenisBayar cc ON aa.JenisBayarID = cc.JenisBayarID
                    LEFT JOIN JenisKas dd ON cc.JenisKasID = dd.JenisKasID
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
                            BuyerName = dr["BuyerName"].ToString(),
                            Keterangan = dr["Keterangan"].ToString(),
                            JenisBayarID = dr["JenisBayarID"].ToString(),
                            JenisBayarName = dr["JenisBayarName"].ToString(),
                            JenisKasID = dr["JenisKasID"].ToString(),
                            JenisKasName = dr["JenisKasName"].ToString(),
                            NilaiBiayaKirim = Convert.ToDecimal(dr["NilaiBiayaKirim"]),
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
