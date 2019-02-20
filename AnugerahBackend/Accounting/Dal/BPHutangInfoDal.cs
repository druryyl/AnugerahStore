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
    public interface IBPHutangInfoDal
    {
        IEnumerable<BPHutangInfoModel> ListData(string tgl1, string tgl2);
        IEnumerable<BPHutangInfoModel> ListData();
    }
    public class BPHutangInfoDal : IBPHutangInfoDal
    {
        private string _connString;

        public BPHutangInfoDal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public IEnumerable<BPHutangInfoModel> ListData(string tgl1, string tgl2)
        {
            List<BPHutangInfoModel> result = null;

            var sSql = @"
                SELECT      
                    aa.BpHutangID, aa.ReffID, aa.Tgl, aa.Jam, 
                    aa.Keterangan, aa.NilaiHutang, aa.NilaiLunas,
                    ISNULL(cc.PihakKeduaName, '') PihakKeduaName
                FROM
                    BPHutangDetil aa
                    INNER JOIN BPHutang bb ON aa.BPHutangID = bb.BPHutangID
                    LEFT JOIN PihakKedua cc ON bb.PihakKeduaID = cc.PihakKeduaID
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
                    result = new List<BPHutangInfoModel>();
                    while (dr.Read())
                    {
                        var item = new BPHutangInfoModel
                        {
                            BPHutangID = dr["BPHutangID"].ToString(),
                            ReffID = dr["ReffID"].ToString(),
                            Tgl = dr["Tgl"].ToString().ToDate(),
                            Jam = dr["Jam"].ToString(),
                            Keterangan = dr["Keterangan"].ToString(),
                            PihakKeduaName = dr["PihakKeduaName"].ToString(),
                            NilaiHutang = Convert.ToDecimal(dr["NilaiHutang"]),
                            NilaiLunas = Convert.ToDecimal(dr["NilaiLunas"])
                        };
                        result.Add(item);
                    }
                }
            }
            return result;
        }

        public IEnumerable<BPHutangInfoModel> ListData()
        {
            List<BPHutangInfoModel> result = null;

            var sSql = @"
                SELECT      
                    aa.BpHutangID, aa.ReffID, aa.Tgl, aa.Jam, 
                    aa.Keterangan, aa.NilaiHutang, aa.NilaiLunas,
                    ISNULL(cc.PihakKeduaName, '') PihakKeduaName
                FROM
                    BPHutangDetil aa
                    INNER JOIN BPHutang bb ON aa.BPHutangID = bb.HutangID
                    LEFT JOIN PihakKedua cc ON bb.PihakKeduaID = cc.PihakKeduaID
                WHERE
                    aa.NilaiHutang <> aa.NilaiLunas ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (!dr.HasRows) return null;
                    result = new List<BPHutangInfoModel>();
                    while (dr.Read())
                    {
                        var item = new BPHutangInfoModel
                        {
                            BPHutangID = dr["BPHutangID"].ToString(),
                            ReffID = dr["ReffID"].ToString(),
                            Tgl = dr["Tg"].ToString().ToDate(),
                            Jam = dr["Jam"].ToString(),
                            Keterangan = dr["Keterangan"].ToString(),
                            PihakKeduaName = dr["PihakKeduaName"].ToString(),
                            NilaiHutang = Convert.ToDecimal(dr["NilaiHutang"]),
                            NilaiLunas = Convert.ToDecimal(dr["NilaiLunas"])
                        };
                        result.Add(item);
                    }
                }
            }
            return result;
        }
    }
}
