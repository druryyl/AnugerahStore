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
                        ColorID, RedValue, 
                        GreenValue, BlueValue,
                        IsWhiteForeColor)
                VALUES (
                        @ColorID, @RedValue, 
                        @GreenValue, @BlueValue
                        @IsWhiteForeColor) ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@ColorID", color.ColorID);
                cmd.AddParam("@RedValue", color.RedValue);
                cmd.AddParam("@GreenValue", color.GreenValue);
                cmd.AddParam("@BlueValue", color.BlueValue);
                cmd.AddParam("@IsWhiteForeColor", color.IsWhiteForeColor);
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
                    RedValue = @RedValue,
                    GreenValue = @GreenValue,
                    BlueValue = @BlueValue,
                    IsWhiteForeColor = @IsWhiteForeColor
                WHERE
                    ColorID = @ColorID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@ColorID", color.ColorID);
                cmd.AddParam("@RedValue", color.RedValue);
                cmd.AddParam("@GreenValue", color.GreenValue);
                cmd.AddParam("@BlueValue", color.BlueValue);
                cmd.AddParam("@IsWhiteForeColor", color.IsWhiteForeColor);
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
                    aa.RedValue,
                    aa.GreenValue, aa.BlueValue,
                    aa.IsWhiteForeColor
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
                            RedValue = Convert.ToInt16(dr["RedValue"]),
                            GreenValue = Convert.ToInt16(dr["GreenValue"]),
                            BlueValue = Convert.ToInt16(dr["BlueValue"]),
                            IsWhiteForeColor = Convert.ToBoolean(dr["IsWhiteForeColor"])
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
                    aa.ColorID, aa.RedValue, 
                    aa.GreenValue, aa.BlueValue,
                    aa.IsWhiteForeColor
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
                                RedValue = Convert.ToInt16(dr["RedValue"]),
                                GreenValue = Convert.ToInt16(dr["GreenValue"]),
                                BlueValue = Convert.ToInt16(dr["BlueValue"]),
                                IsWhiteForeColor = Convert.ToBoolean(dr["IsWhiteForeColor"])
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
