﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnugerahBackend.StokBarang.Model;
using Ics.Helper.Extensions;
using Ics.Helper.StringDateTime;

namespace AnugerahBackend.StokBarang.Dal
{
    public interface IBPStokDetilDal
    {
        void Insert(BPStokDetilModel model);
        void Delete(string bpStokID);
        IEnumerable<BPStokDetilModel> ListData(string bpStokID);
        IEnumerable<BPStokDetilModel> ListData(string brgID, string tgl1, string tgl2);
    }

    public class BPStokDetilDal : IBPStokDetilDal
    {
        private string _connString;

        public BPStokDetilDal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }
        public void Insert(BPStokDetilModel model)
        {
            var sSql = @"
                INSERT INTO
                    BPStokDetil (
                        BPStokID, BPStokDetilID, NoUrut,
                        ReffID, Tgl, Jam,
                        QtyIn, NilaiHpp,
                        QtyOut, HargaJual)
                VALUES (
                        @BPStokID, @BPStokDetilID, @NoUrut,
                        @ReffID, @Tgl, @Jam,
                        @QtyIn, @NilaiHpp,
                        @QtyOut, @HargaJual) ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BPStokID", model.BPStokID);
                cmd.AddParam("@BPStokDetilID", model.BPStokDetilID);
                cmd.AddParam("@NoUrut", model.NoUrut);
                cmd.AddParam("@ReffID", model.ReffID);
                cmd.AddParam("@Tgl", model.Tgl.ToTglYMD());
                cmd.AddParam("@Jam", model.Jam);
                cmd.AddParam("@QtyIn", model.QtyIn);
                cmd.AddParam("NilaiHpp", model.NilaiHpp);
                cmd.AddParam("QtyOut", model.QtyOut);
                cmd.AddParam("@HargaJual", model.HargaJual);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string bpStokID)
        {
            var sSql = @"
                DELETE
                    BPStokDetil
                WHERE
                    BPStokID = @BPStokID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BPStokID", bpStokID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<BPStokDetilModel> ListData(string bpStokID)
        {
            List<BPStokDetilModel> result = null;
            var sSql = @"
                SELECT
                    BPStokID, BPStokDetilID, NoUrut, 
                    ReffID, Tgl, Jam,
                    QtyIn, NilaiHpp,
                    QtyOut, HargaJual 
                FROM
                    BPStokDetil
                WHERE
                    BPStokID = @BPStokID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BPStokID", bpStokID);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (!dr.HasRows) return null;
                    result = new List<BPStokDetilModel>();
                    while (dr.Read())
                    {
                        var item = new BPStokDetilModel
                        {
                            BPStokID = dr["BPStokID"].ToString(),
                            BPStokDetilID = dr["BPStokDetilID"].ToString(),
                            NoUrut = Convert.ToInt16(dr["NoUrut"]),
                            ReffID = dr["ReffID"].ToString(),
                            Tgl = dr["Tgl"].ToString().ToTglDMY(),
                            Jam = dr["Jam"].ToString(),
                            QtyIn = Convert.ToDecimal(dr["QtyIn"]),
                            NilaiHpp = Convert.ToDecimal(dr["NilaiHpp"]),
                            QtyOut = Convert.ToDecimal(dr["QtyOut"]),
                            HargaJual = Convert.ToDecimal(dr["HargaJual"])
                        };
                        result.Add(item);
                    }
                }
            }
            return result;
        }

        public IEnumerable<BPStokDetilModel> ListData(string brgID, string tgl1, string tgl2)
        {
            List<BPStokDetilModel> result = null;
            var sSql = @"
                SELECT
                    aa.BPStokID, aa.BPStokDetilID, aa.NoUrut, 
                    aa.ReffID, aa.Tgl, aa.Jam,
                    aa.QtyIn, aa.NilaiHpp,
                    aa.QtyOut, aa.HargaJual 
                FROM
                    BPStokDetil aa
                    LEFT JOIN BPStok bb ON aa.BPStokID = bb.BPStokID
                WHERE
                    bb.BrgID = @BrgID 
                    AND aa.Tgl BETWEEN @Tgl1 AND @Tgl2";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BrgID", brgID);
                cmd.AddParam("@Tgl1", tgl1.ToTglYMD());
                cmd.AddParam("@Tgl2", tgl2.ToTglYMD());
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (!dr.HasRows) return null;
                    result = new List<BPStokDetilModel>();
                    while (dr.Read())
                    {
                        var item = new BPStokDetilModel
                        {
                            BPStokID = dr["BPStokID"].ToString(),
                            BPStokDetilID = dr["BPStokDetilID"].ToString(),
                            NoUrut = Convert.ToInt16(dr["NoUrut"]),
                            ReffID = dr["ReffID"].ToString(),
                            Tgl = dr["Tgl"].ToString().ToTglDMY(),
                            Jam = dr["Jam"].ToString(),
                            QtyIn = Convert.ToDecimal(dr["QtyIn"]),
                            NilaiHpp = Convert.ToDecimal(dr["NilaiHpp"]),
                            QtyOut = Convert.ToDecimal(dr["QtyOut"]),
                            HargaJual = Convert.ToDecimal(dr["HargaJual"])
                        };
                        result.Add(item);
                    }
                }
            }
            return result;
        }
    }
}
