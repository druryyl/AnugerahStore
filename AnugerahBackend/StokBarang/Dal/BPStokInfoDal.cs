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
    public interface IBPStokInfoDal
    {
        IEnumerable<BPStokInfoDetilModel> ListData(string tgl1, string tgl2);

    }

    public class BPStokInfoDetilDal
    {
        private string _connString;

        public BPStokInfoDetilDal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
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

    }
}
