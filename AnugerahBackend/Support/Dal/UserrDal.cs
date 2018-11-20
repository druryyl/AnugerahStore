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
    public interface IUserrDal
    {
        void Insert(UserrModel userr);

        void Update(UserrModel userr);

        void Delete(string id);

        UserrModel GetData(string id);

        IEnumerable<UserrModel> ListData();
    }


    public class UserrDal : IUserrDal
    {
        public string _connString;

        public UserrDal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void Insert(UserrModel userr)
        {
            var sSql = @"
                INSERT INTO
                    Userr (
                        UserrID, UserrName, Password)
                VALUES (
                        @UserrID, @UserrName, @Password) ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@UserrID", userr.UserrID);
                cmd.AddParam("@UserrName", userr.UserrName);
                cmd.AddParam("@Password", userr.Password);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(UserrModel userr)
        {
            var sSql = @"
                UPDATE
                    Userr 
                SET
                    UserrName = @UserrName,
                    Password = @Password
                WHERE
                    UserrID = @UserrID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@UserrID", userr.UserrID);
                cmd.AddParam("@UserrName", userr.UserrName);
                cmd.AddParam("@Password", userr.Password);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string id)
        {
            var sSql = @"
                DELETE
                    Userr 
                WHERE
                    UserrID = @UserrID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@UserrID", id);
            }
        }

        public UserrModel GetData(string id)
        {
            UserrModel result = null;
            var sSql = @"
                SELECT
                    aa.UserrName, aa.Password
                FROM
                    Userr aa
                WHERE
                    aa.UserrID = @UserrID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@UserrID", id);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        dr.Read();
                        result = new UserrModel
                        {
                            UserrID = id,
                            UserrName = dr["UserrName"].ToString(),
                            Password = dr["Password"].ToString()
                        };
                    }
                }
            }
            return result;
        }

        public IEnumerable<UserrModel> ListData()
        {
            List<UserrModel> result = null;
            var sSql = @"
                SELECT
                    aa.UserrID, aa.UserrName, aa.Password
                FROM
                    Userr aa ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        result = new List<UserrModel>();
                        while (dr.Read())
                        {
                            var item = new UserrModel
                            {
                                UserrID = dr["UserrID"].ToString(),
                                UserrName = dr["UserrName"].ToString(),
                                Password = dr["Password"].ToString()
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