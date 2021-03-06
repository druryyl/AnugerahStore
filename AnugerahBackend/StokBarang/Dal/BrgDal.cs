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
        IEnumerable<BrgModel> ListData(string jenisID, string subID, string merkID, string colorID);

        IEnumerable<string> ListKemasan();
        IEnumerable<BrgJenisFlatModel> ListGrouping();
        //IEnumerable<BrgSearchResultModel> Search(string keyword);
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
                        BrgID, BrgName, BrgNamePrint, Keterangan,
                        SubJenisBrgID, MerkID, ColorID,
                        Kemasan, IsAktif)
                VALUES (
                        @BrgID, @BrgName, @BrgNamePrint, @Keterangan,
                        @SubJenisBrgID, @MerkID, @ColorID, 
                        @Kemasan, @IsAktif) ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BrgID", brg.BrgID);
                cmd.AddParam("@BrgName", brg.BrgName);
                cmd.AddParam("@BrgNamePrint", brg.BrgNamePrint);
                cmd.AddParam("@Keterangan", brg.Keterangan);
                cmd.AddParam("@SubJenisBrgID", brg.SubJenisBrgID);
                cmd.AddParam("@MerkID", brg.MerkID);
                cmd.AddParam("@ColorID", brg.ColorID);
                cmd.AddParam("@Kemasan", brg.Kemasan);
                cmd.AddParam("@IsAktif", brg.IsAktif);
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
                    BrgNamePrint = @BrgNamePrint,
                    Keterangan = @Keterangan,
                    SubJenisBrgID = @SubJenisBrgID,
                    MerkID = @MerkID,
                    ColorID = @ColorID,
                    Kemasan = @Kemasan,
                    UpdateTimestamp = @UpdateTimestamp,
                    IsAktif = @IsAktif
                WHERE
                    BrgID = @BrgID ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@BrgID", brg.BrgID);
                cmd.AddParam("@BrgName", brg.BrgName);
                cmd.AddParam("@BrgNamePrint", brg.BrgName);
                cmd.AddParam("@Keterangan", brg.Keterangan);
                cmd.AddParam("@SubJenisBrgID", brg.SubJenisBrgID);
                cmd.AddParam("@MerkID", brg.MerkID);
                cmd.AddParam("@ColorID", brg.ColorID);
                cmd.AddParam("@Kemasan", brg.Kemasan);
                cmd.AddParam("@UpdateTimestamp", DateTime.Now);
                cmd.AddParam("@IsAktif", brg.IsAktif);
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
                    aa.BrgName, aa. BrgNamePrint, aa.Keterangan,
                    aa.SubJenisBrgID, aa.MerkID, aa.ColorID,
                    aa.Kemasan, 
                    aa.CreateTimestamp, aa.UpdateTimestamp,
                    aa.IsAktif,
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
                            BrgNamePrint = dr["BrgNamePrint"].ToString(),
                            Keterangan = dr["Keterangan"].ToString(),
                            SubJenisBrgID = dr["SubJenisBrgID"].ToString(),
                            SubJenisBrgName = dr["SubJenisBrgName"].ToString(),
                            MerkID = dr["MerkID"].ToString(),
                            MerkName = dr["MerkName"].ToString(),
                            ColorID = dr["ColorID"].ToString(),
                            Kemasan = dr["Kemasan"].ToString(),

                            CreateTimestamp = Convert.ToDateTime(dr["CreateTimestamp"]),
                            UpdateTimestamp = Convert.ToDateTime(dr["UpdateTimestamp"]),

                            IsAktif = Convert.ToBoolean(dr["IsAktif"])

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
                    aa.BrgID, aa.BrgName, aa.BrgNamePrint, aa.Keterangan,
                    aa.SubJenisBrgID, aa.MerkID, aa.ColorID,
                    aa.Kemasan, 
                    aa.CreateTimestamp, aa.UpdateTimestamp,
                    aa.IsAktif,
                    ISNULL(bb.SubJenisBrgName, '') SubJenisBrgName,
                    ISNULL(cc.MerkName, '') MerkName,
                    ISNULL(bb.JenisBrgID, '') JenisBrgID,
                    ISNULL(dd.JenisBrgName, '') JenisBrgName
                FROM
                    Brg aa
                    LEFT JOIN SubJenisBrg bb ON aa.SubJenisBrgID = bb.SubJenisBrgID
                    LEFT JOIN Merk cc ON aa.MerkID = cc.MerkID 
                    LEFT JOIN JenisBrg dd ON bb.JenisBrgID = dd.JenisBrgID ";
            switch (tipeList)
            {
                case TipeListDataEnum.All:
                    break;
                case TipeListDataEnum.SubJenisBrg:
                    sSql += " WHERE aa.SubJenisBrgID = @SubJenisBrgID ";
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
                                BrgNamePrint = dr["BrgNamePrint"].ToString(),
                                Keterangan = dr["Keterangan"].ToString(),
                                SubJenisBrgID = dr["SubJenisBrgID"].ToString(),
                                SubJenisBrgName = dr["SubJenisBrgName"].ToString(),
                                MerkID = dr["MerkID"].ToString(),
                                MerkName = dr["MerkName"].ToString(),
                                ColorID = dr["ColorID"].ToString(),
                                JenisBrgID = dr["JenisBrgID"].ToString(),
                                JenisBrgName = dr["JenisBrgName"].ToString(),
                                Kemasan = dr["Kemasan"].ToString(),

                                CreateTimestamp = Convert.ToDateTime(dr["CreateTimestamp"]),
                                UpdateTimestamp = Convert.ToDateTime(dr["UpdateTimestamp"]),
                                
                                IsAktif = Convert.ToBoolean(dr["IsAktif"])
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

        public IEnumerable<string> ListKemasan()
        {
            List<string> result = null;

            var sSql = @"
                SELECT DISTINCT
                    Kemasan
                FROM
                    Brg ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        result = new List<string>();
                        while (dr.Read())
                        {
                            var item = dr["Kemasan"].ToString();
                            result.Add(item);
                        }
                    }
                }
            }
            return result;
        }

        public IEnumerable<BrgJenisFlatModel> ListGrouping()
        {
            List<BrgJenisFlatModel> result = null;

            var sSql = @"
                SELECT DISTINCT
	                ISNULL(bb.JenisBrgID, '') JenisBrgID,
	                ISNULL(cc.JenisBrgName, '') JenisBrgName,
	                aa.SubJenisBrgID,
	                ISNULL(bb.SubJenisBrgName, '') SubJenisBrgName,
	                aa.MerkID, ISNULL(dd.MerkName, '') MerkName,
	                aa.ColorID, 
	                ISNULL(ee.RedValue,0) RedValue,
	                ISNULL(ee.GreenValue,0) GreenValue,
	                ISNULL(ee.BlueValue,0) BlueValue
                FROM
	                Brg aa
	                LEFT JOIN SubJenisBrg bb ON aa.SubJenisBrgID = bb.SubJenisBrgID
	                LEFT JOIN JenisBrg cc ON bb.JenisBrgID = cc.JenisBrgID
	                LEFT JOIN Merk dd ON aa.MerkID = dd.MerkID
	                LEFT JOIN Color ee ON aa.ColorID = ee.ColorID
                ";
            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        result = new List<BrgJenisFlatModel>();

                        while (dr.Read())
                        {
                            var item = new BrgJenisFlatModel
                            {
                                JenisBrgID = dr["JenisBrgID"].ToString(),
                                JenisBrgName = dr["JenisBrgName"].ToString(),
                                SubJenisID = dr["SubJenisBrgID"].ToString(),
                                SubJenisName = dr["SubJenisBrgName"].ToString(),
                                MerkID = dr["MerkID"].ToString(),
                                MerkName = dr["MerkName"].ToString(),
                                ColorID = dr["ColorID"].ToString(),
                                RedValue = Convert.ToInt16(dr["RedValue"]),
                                GreenValue = Convert.ToInt16(dr["GreenValue"]),
                                BlueValue = Convert.ToInt16(dr["BlueValue"]),
                            };
                            result.Add(item);
                        }
                    }
                }
            }
            return result; ;
        }

        public IEnumerable<BrgModel> ListData(string jenisBrgID, string subID, string merkID, string colorID)
        {
            const string NO_ID = "X";

            List<BrgModel> result = null;
            var sSql = @"
                SELECT
                    aa.BrgID, aa.BrgName, aa.BrgNamePrint, aa.Keterangan,
                    aa.SubJenisBrgID, aa.MerkID, aa.ColorID,
                    aa.Kemasan, 
                    aa.CreateTimestamp, aa.UpdateTimestamp,
                    aa.IsAktif,
                    ISNULL(bb.SubJenisBrgName, '') SubJenisBrgName,
                    ISNULL(cc.MerkName, '') MerkName,
                    ISNULL(bb.JenisBrgID, '') JenisBrgID,
                    ISNULL(dd.JenisBrgName, '') JenisBrgName
                FROM
                    Brg aa
                    LEFT JOIN SubJenisBrg bb ON aa.SubJenisBrgID = bb.SubJenisBrgID
                    LEFT JOIN Merk cc ON aa.MerkID = cc.MerkID 
                    LEFT JOIN JenisBrg dd ON bb.JenisBrgID = dd.JenisBrgID 
                WHERE
                    dd.JenisBrgID = @JenisBrgID ";
            
            if(subID.Trim() != "")
                sSql += @" 
                    AND aa.SubJenisBrgID = @SubJenisBrgID ";

            if(merkID.Trim() != "")
                sSql += @"
                    AND aa.MerkID = @MerkID ";

            if(colorID.Trim() != "")
                sSql += @"
                    AND aa.ColorID = @ColorID ";

            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                cmd.AddParam("@JenisBrgID", jenisBrgID);

                if (subID.Trim() != "")
                    cmd.AddParam("@SubJenisBrgID", subID);
                
                if(merkID.Trim() != "")
                {
                    if (merkID.ToUpper() == NO_ID.ToUpper()) merkID = "";
                    cmd.AddParam("@MerkID", merkID);
                }

                if (colorID.Trim() != "")
                {
                    if (colorID.ToUpper() == NO_ID.ToUpper()) colorID = "";
                    cmd.AddParam("@ColorID", colorID);
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
                                BrgNamePrint = dr["BrgNamePrint"].ToString(),
                                Keterangan = dr["Keterangan"].ToString(),
                                SubJenisBrgID = dr["SubJenisBrgID"].ToString(),
                                SubJenisBrgName = dr["SubJenisBrgName"].ToString(),
                                MerkID = dr["MerkID"].ToString(),
                                MerkName = dr["MerkName"].ToString(),
                                ColorID = dr["ColorID"].ToString(),
                                JenisBrgID = dr["JenisBrgID"].ToString(),
                                JenisBrgName = dr["JenisBrgName"].ToString(),
                                Kemasan = dr["Kemasan"].ToString(),

                                CreateTimestamp = Convert.ToDateTime(dr["CreateTimestamp"]),
                                UpdateTimestamp = Convert.ToDateTime(dr["UpdateTimestamp"]),
                                IsAktif = Convert.ToBoolean(dr["IsAktif"])
                            };
                            result.Add(item);
                        }
                    }
                }
            }
            return result;
        }

        public IEnumerable<BrgSearchResultModel> Search(string keyword)
        {
            List<BrgSearchResultModel> result = null;
            if (keyword.Trim() == "") return null;

            string[] words = keyword.Split(' ');
            
            var sSql = @" 
                SELECT 
                    BrgID, BrgName
                FROM
                    Brg
                WHERE ";

            if (words.Count() >= 1)
                sSql += @" BrgName LIKE @BrgName1 ";
            if (words.Count() >= 2)
                sSql += @" AND BrgName LIKE @BrgName2 ";
            if (words.Count() >= 3)
                sSql += @" AND BrgName LIKE @BrgName3 ";
            if (words.Count() >= 4)
                sSql += @" AND BrgName LIKE @BrgName4 ";
            if (words.Count() >= 5)
                sSql += @" AND BrgName LIKE @BrgName5 ";

            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {
                if (words.Count() >= 1)
                    cmd.AddParam("@BrgName1", "%" + words[0] + "%");
                if (words.Count() >= 2)
                    cmd.AddParam("@BrgName2", "%" + words[1] + "%");
                if (words.Count() >= 3)
                    cmd.AddParam("@BrgName3", "%" + words[2] + "%");
                if (words.Count() >= 4)
                    cmd.AddParam("@BrgName4", "%" + words[3] + "%");
                if (words.Count() >= 5)
                    cmd.AddParam("@BrgName5", "%" + words[4] + "%");

                conn.Open();
                using(var dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        result = new List<BrgSearchResultModel>();
                        while (dr.Read())
                        {
                            var item = new BrgSearchResultModel
                            {
                                BrgID = dr["BrgID"].ToString(),
                                BrgName = dr["BrgName"].ToString()
                            };
                            result.Add(item);
                        }
                    }
                }
            }
            return result;
        }

        public IEnumerable<BrgSearchResultModel> Search()
        {
            List<BrgSearchResultModel> result = null;
            var sSql = @"
                SELECT
                    BrgID, BrgName
                FROM
                    Brg ";

            using (var conn = new SqlConnection(_connString))
            using (var cmd = new SqlCommand(sSql, conn))
            {

                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        result = new List<BrgSearchResultModel>();
                        while (dr.Read())
                        {
                            var item = new BrgSearchResultModel
                            {
                                BrgID = dr["BrgID"].ToString(),
                                BrgName = dr["BrgName"].ToString(),
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
