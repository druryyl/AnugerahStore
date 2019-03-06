using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnugerahBackend.StokBarang.Model;

namespace AnugerahBackend.StokBarang.Dal
{
    public interface IStokInfoDal
    {
        IEnumerable<StokInfoModel> ListData();
    }
    public class StokInfoDal : IStokInfoDal
    {
        private string _connString;

        public StokInfoDal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }
        public IEnumerable<StokInfoModel> ListData()
        {
            List<StokInfoModel> result = null;
            var sSql = @"
                SELECT
                    aa.BrgID, 
                    ISNULL(bb.BrgName, '')BrgName,
                    ISNULL(SUM(aa.QtySisa),0) Qty
                FROM
                    BPStok aa
                    LEFT JOIN Brg bb ON aa.BrgID = bb.BrgID
                GROUP BY
                    aa.BrgID, bb.BrgName
                HAVING
                    SUM(aa.QtySIsa) > 0 ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (!dr.HasRows) return null;
                    result = new List<StokInfoModel>();
                    while (dr.Read())
                    {
                        var item = new StokInfoModel
                        {
                            BrgID = dr["BrgID"].ToString(),
                            BrgName = dr["BrgName"].ToString(),
                            Qty = Convert.ToInt64(dr["Qty"])
                        };
                        result.Add(item);
                    }
                }
            }
            return result;
        }
    }
}
