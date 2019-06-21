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
    public interface IPriceBrgDal
    {
        void Insert(PriceBrgModel model);
        void Delete(string priceID);
        IEnumerable<PriceBrgModel> ListData(string priceID);
    }

    class ModelMap
    {
        public ModelMap(string propertyName, string fieldName)
        {
            PropertyName = propertyName;
            FieldName = fieldName;
        }
        public string PropertyName { get; set; }
        public string FieldName { get; set; }
    }

    public class PriceBrgDal : IPriceBrgDal
    {
        private readonly string _connString;
        private List<ModelMap> _modelMap;
        public PriceBrgDal()
        {
            _connString = ConfigurationManager
                .ConnectionStrings["Default Connection"].ConnectionString;
        }
        public void Insert(PriceBrgModel model)
        {
            var sSql = @"
                INSERT INTO (
                    PriceID, BrgID)
                VALUES (
                    @PriceID, @BrgID) ";
            using (var conn = new SqlConnection(_connString))
            using  (var cmd = new SqlCommand(sSql, conn))
            {
                conn.Open();

                cmd.AddParam("@PriceID", model.PriceID);
                cmd.AddParam("@BrgID", model.BrgID);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string priceID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PriceBrgModel> ListData(string priceID)
        {
            throw new NotImplementedException();
        }
    }
}
