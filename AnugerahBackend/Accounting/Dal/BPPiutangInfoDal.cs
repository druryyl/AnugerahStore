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
    public interface IBPPiutangInfoDal
    {
        IEnumerable<BPPiutangInfoModel> ListData(string tgl1, string tgl2);
        IEnumerable<BPPiutangInfoModel> ListData();
    }
    public class BPPiutangInfoDal : IBPPiutangInfoDal
    {
        private string _connString;

        public BPPiutangInfoDal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public IEnumerable<BPPiutangInfoModel> ListData(string tgl1, string tgl2)
        {
            List<BPPiutangInfoModel> result = null;

            var sSql = @"
                SELECT      
                    aa.BpPiutangID, aa.ReffID, aa.Tgl, aa.Jam, 
                    aa.Keterangan, aa.NilaiPiutang, aa.NilaiLunas,
                    ISNULL(cc.PihakKeduaName, '') PihakKeduaName
                FROM
                    BPPiutangDetil aa
                    INNER JOIN BPPiutang bb ON aa.BPPiutangID = bb.BPPiutangID
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
                    result = new List<BPPiutangInfoModel>();
                    while (dr.Read())
                    {
                        var item = new BPPiutangInfoModel
                        {
                            BPPiutangID = dr["BPPiutangID"].ToString(),
                            ReffID = dr["ReffID"].ToString(),
                            Tgl = dr["Tgl"].ToString().ToDate(),
                            Jam = dr["Jam"].ToString(),
                            Keterangan = dr["Keterangan"].ToString(),
                            PihakKeduaName = dr["PihakKeduaName"].ToString(),
                            NilaiPiutang = Convert.ToDecimal(dr["NilaiPiutang"]),
                            NilaiLunas = Convert.ToDecimal(dr["NilaiLunas"])
                        };
                        result.Add(item);
                    }
                }
            }
            return result;
        }

        public IEnumerable<BPPiutangInfoModel> ListData()
        {
            List<BPPiutangInfoModel> result = null;

            var sSql = @"
                SELECT      
                    aa.BpPiutangID, aa.ReffID, aa.Tgl, aa.Jam, 
                    aa.Keterangan, aa.NilaiPiutang, aa.NilaiLunas,
                    ISNULL(cc.PihakKeduaName, '') PihakKeduaName
                FROM
                    BPPiutangDetil aa
                    INNER JOIN BPPiutang bb ON aa.BPPiutangID = bb.PiutangID
                    LEFT JOIN PihakKedua cc ON bb.PihakKeduaID = cc.PihakKeduaID
                WHERE
                    aa.NilaiPiutang <> aa.NilaiLunas ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (!dr.HasRows) return null;
                    result = new List<BPPiutangInfoModel>();
                    while (dr.Read())
                    {
                        var item = new BPPiutangInfoModel
                        {
                            BPPiutangID = dr["BPPiutangID"].ToString(),
                            ReffID = dr["ReffID"].ToString(),
                            Tgl = dr["Tg"].ToString().ToDate(),
                            Jam = dr["Jam"].ToString(),
                            Keterangan = dr["Keterangan"].ToString(),
                            PihakKeduaName = dr["PihakKeduaName"].ToString(),
                            NilaiPiutang = Convert.ToDecimal(dr["NilaiPiutang"]),
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
