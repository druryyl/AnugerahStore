using AnugerahBackend.Penjualan.Model;
using Ics.Helper.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Penjualan.Dal
{

    public interface ICustomerDal
    {
        void Insert(CustomerModel customer);
        void Update(CustomerModel customer);
        void Delete(string customerID);
        CustomerModel GetData(string customerID);
        IEnumerable<CustomerModel> ListData();
        IEnumerable<CustomerSearchModel> Search(string keyword);
    }

    public class CustomerDal : ICustomerDal
    {
        public string _connString;

        public CustomerDal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void Insert(CustomerModel customer)
        {
            var sSql = @"
                INSERT INTO
                    Customer (
                        CustomerID, CustomerName, Alamat1, Alamat2,
                        NoTelp, ContactPerson)
                VALUES (
                        @CustomerID, @CustomerName, @Alamat1, @Alamat2,
                        @NoTelp, @ContactPerson) ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@CustomerID", customer.CustomerID);
                cmd.AddParam("@CustomerName", customer.CustomerName);
                cmd.AddParam("@Alamat1", customer.Alamat1);
                cmd.AddParam("@Alamat2", customer.Alamat2);
                cmd.AddParam("@NoTelp", customer.NoTelp);
                cmd.AddParam("@ContactPerson", customer.ContactPerson);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(CustomerModel customer)
        {
            var sSql = @"
                UPDATE
                    Customer 
                SET
                    CustomerName = @CustomerName,
                    Alamat1 = @Alamat1,
                    Alamat2 = @Alamat2,
                    NoTelp = @NoTelp,
                    ContactPerson = @ContactPerson
                WHERE
                    CustomerID = @CustomerID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@CustomerID", customer.CustomerID);
                cmd.AddParam("@CustomerName", customer.CustomerName);
                cmd.AddParam("@Alamat1", customer.Alamat1);
                cmd.AddParam("@Alamat2", customer.Alamat2);
                cmd.AddParam("@NoTelp", customer.NoTelp);
                cmd.AddParam("@ContactPerson", customer.ContactPerson);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string id)
        {
            var sSql = @"
                DELETE
                    Customer 
                WHERE
                    CustomerID = @CustomerID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@CustomerID", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public CustomerModel GetData(string id)
        {
            CustomerModel result = null;
            var sSql = @"
                SELECT
                    aa.CustomerName, aa.Alamat1, 
                    aa.Alamat2, aa.NoTelp, aa.ContactPerson
                FROM
                    Customer aa
                WHERE
                    aa.CustomerID = @CustomerID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@CustomerID", id);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        dr.Read();
                        result = new CustomerModel
                        {
                            CustomerID = id,
                            CustomerName = dr["CustomerName"].ToString(),
                            Alamat1 = dr["Alamat1"].ToString(),
                            Alamat2 = dr["Alamat2"].ToString(),
                            NoTelp = dr["NoTelp"].ToString(),
                            ContactPerson = dr["ContactPerson"].ToString(),
                        };
                    }
                }
            }
            return result;
        }

        public IEnumerable<CustomerModel> ListData()
        {
            List<CustomerModel> result = null;
            var sSql = @"
                SELECT
                    aa.CustomerID, aa.CustomerName, aa.Alamat1, 
                    aa.Alamat2, aa.NoTelp, aa.ContactPerson
                FROM
                    Customer aa ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        result = new List<CustomerModel>();
                        while (dr.Read())
                        {
                            var item = new CustomerModel
                            {
                                CustomerID = dr["CustomerID"].ToString(),
                                CustomerName = dr["CustomerName"].ToString(),
                                Alamat1 = dr["Alamat1"].ToString(),
                                Alamat2 = dr["Alamat2"].ToString(),
                                NoTelp = dr["NoTelp"].ToString(),
                                ContactPerson = dr["ContactPerson"].ToString(),
                            };
                            result.Add(item);
                        }
                    }
                }
            }
            return result;
        }

        public IEnumerable<CustomerSearchModel> Search(string keyword)
        {
            List<CustomerSearchModel> result = null;
            var sSql = @"
                SELECT
                    aa.CustomerID, aa.CustomerName, aa.Alamat1,
                    aa.NoTelp
                FROM
                    Customer aa 
                WHERE
                    CustomerName LIKE @Keyword";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@Keyword", string.Format("%{0}%",keyword));
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        result = new List<CustomerSearchModel>();
                        while (dr.Read())
                        {
                            var item = new CustomerSearchModel
                            {
                                CustomerID = dr["CustomerID"].ToString(),
                                CustomerName = dr["CustomerName"].ToString(),
                                Alamat1 = dr["Alamat1"].ToString(),
                                NoTelp = dr["NoTelp"].ToString(),
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
