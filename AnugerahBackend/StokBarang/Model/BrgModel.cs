using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.StokBarang.Model
{
    public class BrgModel
    {
        public string BrgID { get; set; }
        public string BrgName { get; set; }
        public string Keterangan { get; set; }
        public string SubJenisBrgID { get; set; }
        public string SubJenisBrgName { get; set; }
        public string JenisBrgID { get; set; }
        public string JenisBrgName { get; set; }
        public string MerkID { get; set; }
        public string MerkName { get; set; }
        public string ColorID { get; set; }
        public string ColorName { get; set; }
        public string Kemasan { get; set; }
        public DateTime CreateTimestamp { get; set; }
        public DateTime UpdateTimestamp { get; set; }
    }

    public class BrgJenisModel
    {
        public BrgJenisModel()
        {
            ListSub = new List<BrgJenisSubModel>();
        }
        public string JenisID { get; set; }
        public string JenisName { get; set; }
        public List<BrgJenisSubModel> ListSub { get; set; }
    }

    public class BrgJenisSubModel
    {
        public BrgJenisSubModel()
        {
            ListMerk = new List<BrgJenisSubMerkModel>();
        }
        public string SubID { get; set; }
        public string SubName { get; set; }
        public List<BrgJenisSubMerkModel> ListMerk { get; set; }
    }

    public class BrgJenisSubMerkModel
    {
        public BrgJenisSubMerkModel()
        {
            ListColor = new List<BrgJenisSubMerkColorModel>();
        }
        public string MerkID { get; set; }
        public string MerkName { get; set; }

        public List<BrgJenisSubMerkColorModel> ListColor { get; set; }
    }

    public class BrgJenisSubMerkColorModel
    {
        public string ColorID { get; set; }
        public string ColorName { get; set; }
        public int RedValue { get; set; }
        public int GreenValue { get; set; }
        public int BlueValue { get; set; }
    }

    public class BrgJenisFlatModel 
    {
        public string JenisBrgID { get; set; }
        public string JenisBrgName { get; set; }
        public string SubJenisID { get; set; }
        public string SubJenisName { get; set; }
        public string MerkID { get; set; }
        public string MerkName { get; set; }
        public string ColorID { get; set; }
        public int RedValue { get; set; }
        public int GreenValue { get;set; }
        public int BlueValue { get; set; }
    }

    public class BrgSearchResultModel
    {
        public string BrgID { get; set; }
        public string BrgName { get; set; }
    }
}
