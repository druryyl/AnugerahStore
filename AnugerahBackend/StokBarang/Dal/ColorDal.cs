using AnugerahBackend.StokBarang.Model;
using Ics.Helper.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.StokBarang.Dal
{

    public interface IColorDal
    {
        void Insert(ColorModel color);

        void Update(ColorModel color);

        void Delete(string id);

        ColorModel GetData(string id);

        IEnumerable<ColorModel> ListData();
    }

    public class ColorDal : IColorDal
    {
        public string _connString;

        public ColorDal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void Insert(ColorModel color)
        {
            var sSql = @"
                INSERT INTO
                    Color (
                        ColorID, ColorName, 
                        RedValue, GreenValue, BlueValue)
                VALUES (
                        @ColorID, @ColorName,
                        @RedValue, @GreenValue, @BlueValue) ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@ColorID", color.ColorID);
                cmd.AddParam("@ColorName", color.ColorName);
                cmd.AddParam("@RedValue", color.RedValue);
                cmd.AddParam("@GreenValue", color.GreenValue);
                cmd.AddParam("@BlueValue", color.BlueValue);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(ColorModel color)
        {
            var sSql = @"
                UPDATE
                    Color 
                SET
                    ColorName = @ColorName,
                    RedValue = @RedValue,
                    GreenValue = @GreenValue,
                    BlueValue = @BlueValue
                WHERE
                    ColorID = @ColorID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@ColorID", color.ColorID);
                cmd.AddParam("@ColorName", color.ColorName);
                cmd.AddParam("@RedValue", color.RedValue);
                cmd.AddParam("@GreenValue", color.GreenValue);
                cmd.AddParam("@BlueValue", color.BlueValue);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string id)
        {
            var sSql = @"
                DELETE
                    Color 
                WHERE
                    ColorID = @ColorID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@ColorID", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public ColorModel GetData(string id)
        {
            ColorModel result = null;
            var sSql = @"
                SELECT
                    aa.ColorName, aa.RedValue,
                    aa.GreenValue, aa.BlueValue
                FROM
                    Color aa
                WHERE
                    aa.ColorID = @ColorID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@ColorID", id);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        dr.Read();
                        result = new ColorModel
                        {
                            ColorID = id,
                            ColorName = dr["ColorName"].ToString(),
                            RedValue = Convert.ToInt16(dr["RedValue"]),
                            GreenValue = Convert.ToInt16(dr["GreenValue"]),
                            BlueValue = Convert.ToInt16(dr["BlueValue"])
                        };
                    }
                }
            }
            return result;
        }

        public IEnumerable<ColorModel> ListData()
        {
            List<ColorModel> result = null;
            var sSql = @"
                SELECT
                    aa.ColorID, aa.ColorName,
                    aa.RedValue, aa.GreenValue, aa.BlueValue
                FROM
                    Color aa ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        result = new List<ColorModel>();
                        while (dr.Read())
                        {
                            var item = new ColorModel
                            {
                                ColorID = dr["ColorID"].ToString(),
                                ColorName = dr["ColorName"].ToString(),
                                RedValue = Convert.ToInt16(dr["RedValue"]),
                                GreenValue = Convert.ToInt16(dr["GreenValue"]),
                                BlueValue = Convert.ToInt16(dr["BlueValue"])
                            };
                            result.Add(item);
                        }
                    }
                }
            }
            return result;
        }
    }
}
