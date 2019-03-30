using AnugerahBackend.Accounting.Model;
using Ics.Helper.Extensions;
using Ics.Helper.StringDateTime;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Accounting.Dal
{
    public interface IMutasiKasDal
    {
        void Insert(MutasiKasModel model);
        void Update(MutasiKasModel model);
        void Delete(string id);
        MutasiKasModel GetData(string id);
        IEnumerable<MutasiKasModel> ListData(string tgl1, string tgl2);

    }
    public class MutasiKasDal : IMutasiKasDal
    {
        private readonly string _connString;

        public MutasiKasDal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void Insert(MutasiKasModel model)
        {
            var sSql = @"
                INSERT INTO
                    MutasiKas (
                        MutasiKasID, Tgl, Jam, PegawaiID, 
                        JenisKasIDAsal, JenisKasIDTujuan, Keterangan, 
                        NilaiKas)
                VALUES (
                        @MutasiKasID, @Tgl, @Jam, @PegawaiID, 
                        @JenisKasIDAsal, @JenisKasIDTujuan, @Keterangan,
                        @NilaiKas) ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@MutasiKasID", model.MutasiKasID);
                cmd.AddParam("@Tgl", model.Tgl.ToTglYMD());
                cmd.AddParam("@Jam", model.Jam);
                cmd.AddParam("@PegawaiID", model.PegawaiID);
                cmd.AddParam("@JenisKasIDAsal", model.JenisKasIDAsal);
                cmd.AddParam("@JenisKasIDTujuan", model.JenisKasIDTujan);
                cmd.AddParam("@Keterangan", model.Keterangan);
                cmd.AddParam("@NilaiKas", model.NilaiKas);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(MutasiKasModel model)
        {
            var sSql = @"
                UPDATE
                    MutasiKas 
                SET 
                    Tgl = @Tgl, 
                    Jam = @Jam, 
                    PegawaiID = @PegawaiID, 
                    JenisKasIDAsal = @JenisKasIDAsal, 
                    JenisKasIDTujuan = @JenisKasIDTujuan, 
                    Keterangan = @Keterangan,
                    NilaiKas = @NilaiKas
                WHERE
                    MutasiKasID = @MutasiKasID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@MutasiKasID", model.MutasiKasID);
                cmd.AddParam("@Tgl", model.Tgl.ToTglYMD());
                cmd.AddParam("@Jam", model.Jam);
                cmd.AddParam("@PegawaiID", model.PegawaiID);
                cmd.AddParam("@JenisKasIDAsal", model.JenisKasIDAsal);
                cmd.AddParam("@JenisKasIDTujuan", model.JenisKasIDTujan);
                cmd.AddParam("@Keterangan", model.Keterangan);
                cmd.AddParam("@NilaiKas", model.NilaiKas);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string id)
        {
            var sSql = @"
                DELETE
                    MutasiKas 
                WHERE
                    MutasiKasID = @MutasiKasID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@MutasiKasID", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public MutasiKasModel GetData(string id)
        {
            MutasiKasModel result = null;
            var sSql = @"
                SELECT
                    aa.MutasiKasID, aa.Tgl, aa.Jam, aa.PegawaiID, 
                    aa.JenisKasIDAsal, aa.JenisKasIDTujuan, aa.Keterangan,
                    aa.NilaiKas,
                    ISNULL(bb.PegawaiName, '') PegawaiName,
                    ISNULL(cc.JenisKasName, '') JenisKasNameAsal,
                    ISNULL(dd.JenisKasName, '') JenisKasNameTujuan
                FROM
                    MutasiKas aa 
                    LEFT JOIN Pegawai bb ON aa.PegawaiID = bb.PegawaiID
                    LEFT JOIN JenisKas cc ON aa.JenisKasIDAsal = cc.JenisKasID
                    LEFT JOIN JenisKas dd oN aa.JenisKasIDTujuan = dd.JenisKasID
                WHERE
                    MutasiKasID = @MutasiKasID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@MutasiKasID", id);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (!dr.HasRows) return null;
                    dr.Read();
                    result = new MutasiKasModel
                    {
                        MutasiKasID = id,
                        Tgl = dr["Tgl"].ToString().ToTglDMY(),
                        Jam = dr["Jam"].ToString(),
                        PegawaiID = dr["PegawaiID"].ToString(),
                        PegawaiName = dr["PegawaiName"].ToString(),
                        JenisKasIDAsal = dr["JenisKasIDAsal"].ToString(),
                        JenisKasNameAsal = dr["JenisKasNameAsal"].ToString(),
                        JenisKasIDTujan = dr["JenisKasIDTujuan"].ToString(),
                        JenisKasNameTujuan = dr["JenisKasNameTujuan"].ToString(),
                        Keterangan = dr["Keterangan"].ToString(),
                        NilaiKas = Convert.ToDecimal(dr["NilaiKas"])
                    };
                }
            }
            return result;
        }

        public IEnumerable<MutasiKasModel> ListData(string tgl1, string tgl2)
        {
            List<MutasiKasModel> result = null;
            var sSql = @"
                SELECT
                    aa.MutasiKasID, aa.Tgl, aa.Jam, aa.PegawaiID, 
                    aa.JenisKasIDAsal, aa.JenisKasIDTujuan, aa.Keterangan, 
                    aa.NilaiKas,
                    ISNULL(bb.PegawaiName, '') PegawaiName,
                    ISNULL(cc.JenisKasName, '') JenisKasNameAsal,
                    ISNULL(dd.JenisKasName, '') JenisKasNameTujuan
                FROM
                    MutasiKas aa 
                    LEFT JOIN Pegawai bb ON aa.PegawaiID = bb.PegawaiID
                    LEFT JOIN JenisKas cc ON aa.JenisKasIDAsal = cc.JenisKasID
                    LEFT JOIN JenisKas dd oN aa.JenisKasIDTujuan = dd.JenisKasID
                WHERE
                    Tgl BETWEEN @Tgl1 AND @Tgl2 ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@Tgl1", tgl1.ToTglYMD());
                cmd.AddParam("@Tgl2", tgl2.ToTglYMD());
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (!dr.HasRows) return null;
                    result = new List<MutasiKasModel>();
                    while (dr.Read())
                    {
                        var item = new MutasiKasModel
                        {
                            MutasiKasID = dr["MutasiKasID"].ToString(),
                            Tgl = dr["Tgl"].ToString().ToTglDMY(),
                            Jam = dr["Jam"].ToString(),
                            PegawaiID = dr["PegawaiID"].ToString(),
                            PegawaiName = dr["PegawaiName"].ToString(),
                            JenisKasIDAsal = dr["JenisKasIDAsal"].ToString(),
                            JenisKasNameAsal = dr["JenisKasNameAsal"].ToString(),
                            JenisKasIDTujan = dr["JenisKasIDTujuan"].ToString(),
                            JenisKasNameTujuan = dr["JenisKasNameTujuan"].ToString(),
                            Keterangan = dr["Keterangan"].ToString(),
                            NilaiKas = Convert.ToDecimal(dr["NilaiKas"])
                        };
                        result.Add(item);
                    }
                }
            }
            return result;
        }
    }
}
