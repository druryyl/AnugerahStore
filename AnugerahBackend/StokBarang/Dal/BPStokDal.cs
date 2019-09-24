using System;
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
    public interface IBPStokDal
    {
        void Insert(BPStokModel model);
        void Update(BPStokModel model);
        void Delete(string bpStokID);
        BPStokModel GetData(string bpStokID);
        IEnumerable<BPStokModel> ListData(string brgID);
        IEnumerable<BPStokModel> ListData();
        IEnumerable<BPStokInfoDetilModel> ListData(string tgl1, string tgl2);
        IEnumerable<BPStokModel> ListData(string brgID, string tgl1, string tgl2);
    }

    public class BPStokDal : IBPStokDal
    {
        private string _connString;

        public BPStokDal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void Insert(BPStokModel model)
        {
            var sSql = @"
                INSERT INTO
                    BPStok (
                        BPStokID, ReffID, StokControl,
                        Tgl, Jam, BrgID,
                        NilaiHpp, QtyIn, QtySisa )
                VALUES (
                        @BPStokID, @ReffID, @StokControl,
                        @Tgl, @Jam, @BrgID,
                        @NilaiHpp, @QtyIn, @QtySisa ) ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BPStokID", model.BPStokID);
                cmd.AddParam("@ReffID", model.ReffID);
                cmd.AddParam("@StokControl", model.StokControl);
                cmd.AddParam("@Tgl", model.Tgl.ToTglYMD());
                cmd.AddParam("@Jam", model.Jam);
                cmd.AddParam("@BrgID", model.BrgID);
                cmd.AddParam("@NilaiHpp", model.NilaiHpp);
                cmd.AddParam("@QtyIn", model.QtyIn);
                cmd.AddParam("@QtySisa", model.QtySisa);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(BPStokModel model)
        {
            var sSql = @"
                UPDATE
                    BPStok 
                SET
                    ReffID = @ReffID, 
                    Tgl = @Tgl, 
                    StokControl = @StokControl,
                    Jam = @Jam, 
                    BrgID = @BrgID,
                    NilaiHpp = @NilaiHpp, 
                    QtyIn = @QtyIn, 
                    QtySisa = @QtySisa
                WHERE
                    BPStokID = @BPStokID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BPStokID", model.BPStokID);
                cmd.AddParam("@ReffID", model.ReffID);
                cmd.AddParam("@StokControl", model.StokControl);
                cmd.AddParam("@Tgl", model.Tgl.ToTglYMD());
                cmd.AddParam("@Jam", model.Jam);
                cmd.AddParam("@BrgID", model.BrgID);
                cmd.AddParam("@NilaiHpp", model.NilaiHpp);
                cmd.AddParam("@QtyIn", model.QtyIn);
                cmd.AddParam("@QtySisa", model.QtySisa);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string bpStokID)
        {
            var sSql = @"
                DELETE
                    BPStok 
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

        public BPStokModel GetData(string bpStokID)
        {
            BPStokModel result = null;
            var sSql = @"
                SELECT
                    aa.BPStokID, aa.ReffID, aa.StokControl,
                    aa.Tgl, aa.Jam, aa.BrgID,
                    aa.NilaiHpp, aa.QtyIn, aa.QtySisa,
                    ISNULL(bb.BrgName, '') BrgName
                FROM
                    BPStok aa
                    LEFT JOIN Brg bb ON aa.BrgID = bb.BrgID
                WHERE
                    BPStokID = @BPStokID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql,conn))
            {
                cmd.AddParam("@BPStokID", bpStokID);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (!dr.HasRows) return null;
                    dr.Read();
                    result = new BPStokModel
                    {
                        BPStokID = bpStokID,
                        ReffID = dr["ReffID"].ToString(),
                        StokControl = dr["StokControl"].ToString(),
                        Tgl = dr["Tgl"].ToString().ToTglDMY(),
                        Jam = dr["Jam"].ToString(),
                        BrgID = dr["BrgID"].ToString(),
                        BrgName = dr["BrgName"].ToString(),
                        NilaiHpp = Convert.ToDecimal(dr["NilaiHpp"]),
                        QtyIn = Convert.ToInt64(dr["QtyIn"]),
                        QtySisa = Convert.ToInt64(dr["QtySisa"])
                    };
                }
            }
            return result;
        }

        public IEnumerable<BPStokModel> ListData(string brgID)
        {
            List<BPStokModel> result = null;
            var sSql = @"
                SELECT
                    aa.BPStokID, aa.ReffID, aa.StokControl,
                    aa.Tgl, aa.Jam, aa.BrgID,
                    aa.NilaiHpp, aa.QtyIn, aa.QtySisa,
                    ISNULL(bb.BrgName, '') BrgName
                FROM
                    BPStok aa
                    LEFT JOIN Brg bb ON aa.BrgID = bb.BrgID
                WHERE
                    aa.BrgID = @BrgID 
                    AND aa.QtySisa > 0 
                ORDER BY
                    aa.Tgl, aa.Jam ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BrgID", brgID);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (!dr.HasRows) return null;
                    result = new List<BPStokModel>();
                    while (dr.Read())
                    {
                        var item = new BPStokModel
                        {
                            BPStokID = dr["BPStokID"].ToString(),
                            ReffID = dr["ReffID"].ToString(),
                            StokControl = dr["StokControl"].ToString(),
                            Tgl = dr["Tgl"].ToString().ToTglDMY(),
                            Jam = dr["Jam"].ToString(),
                            BrgID = dr["BrgID"].ToString(),
                            BrgName = dr["BrgName"].ToString(),
                            NilaiHpp = Convert.ToDecimal(dr["NilaiHpp"]),
                            QtyIn = Convert.ToDecimal(dr["QtyIn"]),
                            QtySisa = Convert.ToDecimal(dr["QtySisa"])
                        };
                        result.Add(item);
                    }
                }
            }
            return result;
        }

        public IEnumerable<BPStokModel> ListData()
        {
            List<BPStokModel> result = null;
            var sSql = @"
                SELECT
                    aa.BPStokID, aa.ReffID, aa.StokControl,
                    aa.Tgl, aa.Jam, aa.BrgID,
                    aa.NilaiHpp, aa.QtyIn, aa.QtySisa,
                    ISNULL(bb.BrgName, '') BrgName
                FROM
                    BPStok aa
                    LEFT JOIN Brg bb ON aa.BrgID = bb.BrgID
                WHERE
                    aa.QtySisa > 0 
                ORDER BY
                    aa.Tgl, aa.Jam ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (!dr.HasRows) return null;
                    result = new List<BPStokModel>();
                    while (dr.Read())
                    {
                        var item = new BPStokModel
                        {
                            BPStokID = dr["BPStokID"].ToString(),
                            ReffID = dr["ReffID"].ToString(),
                            StokControl = dr["StokControl"].ToString(),
                            Tgl = dr["Tgl"].ToString().ToTglDMY(),
                            Jam = dr["Jam"].ToString(),
                            BrgID = dr["BrgID"].ToString(),
                            BrgName = dr["BrgName"].ToString(),
                            NilaiHpp = Convert.ToDecimal(dr["NilaiHpp"]),
                            QtyIn = Convert.ToInt64(dr["QtyIn"]),
                            QtySisa = Convert.ToInt64(dr["QtySisa"])
                        };
                        result.Add(item);
                    }
                }
            }
            return result;
        }

        public IEnumerable<BPStokInfoDetilModel> ListData(string tgl1, string tgl2)
        {
            List<BPStokInfoDetilModel> result = null;

            var sSql = @"
                SELECT
                    aa.BPStokID, bb.NoUrut, bb.Tgl, aa.BrgID, 
                    bb.ReffID, bb.QtyIn, bb.NilaiHPP, bb.QtyOut, bb.HargaJual,
                    (bb.QtyIn * bb.NilaiHpp) NilaiPersediaan,
                    (bb.QtyOut * bb.HargaJual) PendapatanJual,
                    ISNULL(cc.BrgName, '') BrgName,
                    ISNULL(ee.SupplierName, '') SupplierName
                FROM
                    BPStok aa
                    INNER JOIN BPStokDetil bb ON aa.BPStokID = bb.BPStokID
                    LEFT JOIN Brg cc ON aa.BrgID = cc.BrgID
                    LEFT JOIN Receipt dd ON aa.ReffID = dd.ReceiptID
                    LEFT JOIN Supplier ee ON dd.SupplierID = ee.SupplierID
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

                    result = new List<BPStokInfoDetilModel>();
                    while (dr.Read())
                    {
                        var item = new BPStokInfoDetilModel
                        {
                            BPStokID = dr["BPStokID"].ToString(),
                            NoUrut = Convert.ToInt16(dr["NoUrut"].ToString()),
                            Tgl = dr["Tgl"].ToString().ToDate(),
                            SupplierName = dr["SupplierName"].ToString(),
                            BrgID = dr["BrgID"].ToString(),
                            BrgName = dr["BrgName"].ToString(),

                            ReffID = dr["ReffID"].ToString(),
                            QtyIn = Convert.ToInt64(dr["QtyIn"]),
                            NilaiHPP = Convert.ToDecimal(dr["NilaiHpp"].ToString()),
                            QtyOut = Convert.ToInt64(dr["QtyOut"]),
                            HargaJual = Convert.ToDecimal(dr["HargaJual"]),
                            NilaiPersediaan = Convert.ToDecimal(dr["NilaiPersediaan"]),
                            PendapatanJual = Convert.ToDecimal(dr["PendapatanJual"])
                        };
                        result.Add(item);
                    }
                }
            }
            return result;
        }

        public IEnumerable<BPStokModel> ListData(string brgID, string tgl1, string tgl2)
        {
            List<BPStokModel> result = null;

            var sSql = @"
                SELECT
                    aa.BPStokID, aa.ReffID, aa.StokControl,
                    aa.Tgl, aa.Jam, aa.BrgID,
                    aa.NilaiHpp, aa.QtyIn, aa.QtySisa,
                    ISNULL(bb.BrgName, '') BrgName
                FROM
                    BPStok aa
                    LEFT JOIN Brg bb ON aa.BrgID = bb.BrgID
                WHERE
                    aa.BrgID = @BrgID
                    AND aa.Tgl BETWEEN @Tgl1 AND @Tgl2 ";
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

                    result = new List<BPStokModel>();
                    while (dr.Read())
                    {
                        var item = new BPStokModel
                        {
                            BPStokID = dr["BPStokID"].ToString(),
                            ReffID = dr["ReffID"].ToString(),
                            StokControl = dr["StokControl"].ToString(),
                            Tgl = dr["Tgl"].ToString().ToTglDMY(),
                            Jam = dr["Jam"].ToString(),
                            BrgID = dr["BrgID"].ToString(),
                            BrgName = dr["BrgName"].ToString(),
                            NilaiHpp = Convert.ToDecimal(dr["NilaiHpp"]),
                            QtyIn = Convert.ToInt64(dr["QtyIn"]),
                            QtySisa = Convert.ToInt64(dr["QtySisa"])
                        };
                        result.Add(item);
                    }
                }
            }
            return result;
        }

    }
}
