using AnugerahBackend.Support.Model;
using Ics.Helper.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Support.Dal
{

    public interface IParameterNoDal
    {
        void Insert(ParameterNoModel paramterNo);

        void Update(ParameterNoModel paramterNo);

        void Delete(string id);

        ParameterNoModel GetData(string id);

        IEnumerable<ParameterNoModel> ListData();
    }

    public class ParameterNoDal : IParameterNoDal
    {
        public string _connString;

        public ParameterNoDal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void Insert(ParameterNoModel parameterNo)
        {
            var sSql = @"
                INSERT INTO
                    ParameterNo (
                        Prefix, Value)
                VALUES (
                        @Prefix, @Value) ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@Prefix", parameterNo.Prefix);
                cmd.AddParam("@Value", parameterNo.Value);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(ParameterNoModel parameterNo)
        {
            var sSql = @"
                UPDATE
                    ParameterNo 
                SET
                    Value = @Value
                WHERE
                    Prefix = @Prefix ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@Prefix", parameterNo.Prefix);
                cmd.AddParam("@Value", parameterNo.Value);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string id)
        {
            var sSql = @"
                DELETE
                    ParameterNo 
                WHERE
                    Prefix = @Prefix ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@Prefix", id);
            }
        }

        public ParameterNoModel GetData(string id)
        {
            ParameterNoModel result = null;
            var sSql = @"
                SELECT
                    aa.Value
                FROM
                    ParameterNo aa
                WHERE
                    aa.Prefix = @Prefix ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@Prefix", id);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        dr.Read();
                        result = new ParameterNoModel
                        {
                            Prefix = id,
                            Value = Convert.ToInt64(dr["Value"])
                        };
                    }
                }
            }
            return result;
        }

        public IEnumerable<ParameterNoModel> ListData()
        {
            List<ParameterNoModel> result = null;
            var sSql = @"
                SELECT
                    aa.Prefix, aa.Value
                FROM
                    ParameterNo aa ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        result = new List<ParameterNoModel>();
                        while (dr.Read())
                        {
                            var item = new ParameterNoModel
                            {
                                Prefix = dr["Prefix"].ToString(),
                                Value = Convert.ToInt64(dr["Value"])
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
