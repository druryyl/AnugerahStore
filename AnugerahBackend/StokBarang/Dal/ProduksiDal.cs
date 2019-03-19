using AnugerahBackend.StokBarang.Model;
using Ics.Helper.Extensions;
using Ics.Helper.StringDateTime;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.StokBarang.Dal
{
    public interface IProduksiDal
    {
        void Insert(ProduksiModel model);
        void Update(ProduksiModel model);
        void Delete(string id);
        ProduksiModel GetData (string id);
        IEnumerable<ProduksiModel> ListData(string tgl1, string tgl2);
    }

    public class ProduksiDal : IProduksiDal
    {
        private readonly string _connString;

        public ProduksiDal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void Insert(ProduksiModel model)
        {
            var sSql = @"
                INSERT INTO
                    Produksi (
                        ProduksiID, Tgl, Jam, Keterangan )
                VALUES (
                        @ProduksiID, @Tgl, @Jam, @Keterangan) ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@ProduksiID", model.ProduksiID);
                cmd.AddParam("@Tgl", model.Tgl.ToTglYMD());
                cmd.AddParam("@Jam", model.Jam);
                cmd.AddParam("@Keterangan", model.Keterangan);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(ProduksiModel model)
        {
            var sSql = @"
                UPDATE
                    Produksi 
                SET 
                    Tgl = @Tgl, 
                    Jam = @Jam, 
                    Keterangan = @Keterangan
                WHERE
                    ProduksiID = @ProduksiID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@ProduksiID", model.ProduksiID);
                cmd.AddParam("@Tgl", model.Tgl.ToTglYMD());
                cmd.AddParam("@Jam", model.Jam);
                cmd.AddParam("@Keterangan", model.Keterangan);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string id)
        {
            var sSql = @"
                DELETE
                    Produksi 
                WHERE
                    ProduksiID = @ProduksiID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@ProduksiID", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public ProduksiModel GetData(string id)
        {
            ProduksiModel result = null;

            var sSql = @"
                SELECT
                    ProduksiID, Tgl, Jam, Keterangan
                FROM
                    Produksi
                WHERE
                    ProduksiID = @ProduksiID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@ProduksiID", id);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (!dr.HasRows) return null;
                    dr.Read();
                    result = new ProduksiModel
                    {
                        ProduksiID = id,
                        Tgl = dr["Tgl"].ToString().ToTglDMY(),
                        Jam = dr["Jam"].ToString(),
                        Keterangan = dr["Keterangan"].ToString()
                    };
                }
            }
            return result;
        }

        public IEnumerable<ProduksiModel> ListData(string tgl1, string tgl2)
        {
            List<ProduksiModel> result = null;
            var sSql = @"
                SELECT
                    ProduksiID, Tgl, Jam, Keterangan
                FROM
                    Produksi
                WHERE
                    Tgl BETWEEN @Tgl1 AND @Tgl2 ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@Tgl1", tgl1);
                cmd.AddParam("@Tgl2", tgl2);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (!dr.HasRows) return null;
                    result = new List<ProduksiModel>();
                    while (dr.Read())
                    {
                        var item = new ProduksiModel
                        {
                            ProduksiID = dr["ProduksiID"].ToString(),
                            Tgl = dr["Tgl"].ToString().ToTglDMY(),
                            Jam = dr["Jam"].ToString(),
                            Keterangan = dr["Keterangan"].ToString()
                        };
                        result.Add(item);
                    }
                }
            }
            return result;
        }
    }
}
