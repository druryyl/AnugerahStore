﻿using AnugerahBackend.StokBarang.Model;
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

    public interface IBrgDal
    {
        void Insert(BrgModel brg);

        void Update(BrgModel brg);
        void Delete(string id);
        BrgModel GetData(string id);
        IEnumerable<BrgModel> ListData();
        IEnumerable<BrgModel> ListData(SubJenisBrgModel subJenisBrg);
        IEnumerable<BrgModel> ListData(string keywordSearch);
    }


    public class BrgDal : IBrgDal
    {
        private enum TipeListDataEnum
        {
            All, SubJenisBrg, SearchName
        }

        public string _connString;

        public BrgDal()
        {
            _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void Insert(BrgModel brg)
        {
            var sSql = @"
                INSERT INTO
                    Brg (
                        BrgID, BrgName, Keterangan,
                        SubJenisBrgID, MerkID, ColorID)
                VALUES (
                        @BrgID, @BrgName, @Keterangan,
                        @SubJenisBrgID, @MerkID, @ColorID) ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BrgID", brg.BrgID);
                cmd.AddParam("@BrgName", brg.BrgName);
                cmd.AddParam("@Keterangan", brg.Keterangan);
                cmd.AddParam("@SubJenisBrgID", brg.SubJenisBrgID);
                cmd.AddParam("@MerkID", brg.MerkID);
                cmd.AddParam("@ColorID", brg.ColorID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void Update(BrgModel brg)
        {
            var sSql = @"
                UPDATE
                    Brg 
                SET
                    BrgName = @BrgName,
                    Keterangan = @Keterangan,
                    SubJenisBrgID = @SubJenisBrgID,
                    MerkID = @MerkID,
                    ColorID = @ColorID  
                WHERE
                    BrgID = @BrgID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BrgID", brg.BrgID);
                cmd.AddParam("@BrgName", brg.BrgName);
                cmd.AddParam("@Keterangan", brg.Keterangan);
                cmd.AddParam("@SubJenisBrgID", brg.Keterangan);
                cmd.AddParam("@MerkID", brg.MerkID);
                cmd.AddParam("@ColorID", brg.ColorID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void Delete(string id)
        {
            var sSql = @"
                DELETE
                    Brg 
                WHERE
                    BrgID = @BrgID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BrgID", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public BrgModel GetData(string id)
        {
            BrgModel result = null;
            var sSql = @"
                SELECT
                    aa.BrgName, aa.Keterangan,
                    aa.SubJenisBrgID, aa.MerkID, aa.ColorID,
                    ISNULL(bb.SubJenisBrgName, '') SubJenisBrgName,
                    ISNULL(cc.MerkName, '') MerkName
                FROM
                    Brg aa
                    LEFT JOIN SubJenisBrg bb ON aa.SubJenisBrgID = bb.SubJenisBrgID
                    LEFT JOIN Merk cc ON aa.MerkID = cc.MerkID
                WHERE
                    aa.BrgID = @BrgID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BrgID", id);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        dr.Read();
                        result = new BrgModel
                        {
                            BrgID = id,
                            BrgName = dr["BrgName"].ToString(),
                            Keterangan = dr["Keterangan"].ToString(),
                            SubJenisBrgID = dr["SubJenisBrgID"].ToString(),
                            SubJenisBrgName = dr["SubJenisBrgName"].ToString(),
                            MerkID = dr["MerkID"].ToString(),
                            MerkName = dr["MerkName"].ToString(),
                            ColorID = dr["ColorID"].ToString(),
                        };
                    }
                }
            }
            return result;
        }

        private IEnumerable<BrgModel> ListData(TipeListDataEnum tipeList, string data)
        {
            List<BrgModel> result = null;
            var sSql = @"
                SELECT
                    aa.BrgID, aa.BrgName, aa.Keterangan,
                    aa.SubJenisBrgID, aa.MerkID, aa.ColorID,
                    ISNULL(bb.SubJenisBrgName, '') SubJenisBrgName,
                    ISNULL(cc.MerkName, '') MerkName
                FROM
                    Brg aa
                    LEFT JOIN SubJenisBrg bb ON aa.SubJenisBrgID = bb.SubJenisBrgID
                    LEFT JOIN Merk cc ON aa.MerkID = cc.MerkID ";
            switch (tipeList)
            {
                case TipeListDataEnum.All:
                    break;
                case TipeListDataEnum.SubJenisBrg:
                    sSql += " WHERE aa.SubJenisBrgID == @SubJenisBrgID ";
                    break;
                case TipeListDataEnum.SearchName:
                    sSql += " WHERE aa.BrgName LIKE @BrgName ";
                    break;
                default:
                    break;
            }

            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                switch (tipeList)
                {
                    case TipeListDataEnum.All:
                        break;
                    case TipeListDataEnum.SubJenisBrg:
                        cmd.AddParam("@SubJenisBrgID", data);
                        break;
                    case TipeListDataEnum.SearchName:
                        cmd.AddParam("@BrgName", "%" + data + "%");
                        break;
                    default:
                        break;
                }

                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        result = new List<BrgModel>();
                        while (dr.Read())
                        {
                            var item = new BrgModel
                            {
                                BrgID = dr["BrgID"].ToString(),
                                BrgName = dr["BrgName"].ToString(),
                                Keterangan = dr["Keterangan"].ToString(),
                                SubJenisBrgID = dr["SubJenisBrgID"].ToString(),
                                SubJenisBrgName = dr["SubJenisBrgName"].ToString(),
                                MerkID = dr["MerkID"].ToString(),
                                MerkName = dr["MerkName"].ToString(),
                                ColorID = dr["ColorID"].ToString(),
                            };
                            result.Add(item);
                        }
                    }
                }
            }
            return result;
        }

        public IEnumerable<BrgModel> ListData()
        {
            return ListData(TipeListDataEnum.All, "");
        }

        public IEnumerable<BrgModel> ListData(SubJenisBrgModel subJenisBrg)
        {
            return ListData(TipeListDataEnum.SubJenisBrg, subJenisBrg.SubJenisBrgID);
        }

        public IEnumerable<BrgModel> ListData(string keywordSearch)
        {
            return ListData(TipeListDataEnum.SearchName, keywordSearch);
        }
    }
}
