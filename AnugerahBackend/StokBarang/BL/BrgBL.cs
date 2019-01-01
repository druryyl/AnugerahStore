using AnugerahBackend.StokBarang.Dal;
using AnugerahBackend.StokBarang.Model;
using AnugerahBackend.Support.BL;
using Ics.Helper.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.StokBarang.BL
{

    public interface IBrgBL
    {
        BrgModel Save(BrgModel brg);

        void Delete(string id);

        BrgModel GetData(string id);

        IEnumerable<BrgModel> ListData();
        IEnumerable<BrgModel> ListData(string jenisID, string subID, string merkID, string colorID);
        IEnumerable<BrgModel> ListData(SubJenisBrgModel subJenisBrg);
        IEnumerable<BrgModel> ListData(string searchKeyword);

        IEnumerable<BrgJenisModel> ListGrouping();
        
        BrgModel TryValidate(BrgModel brg);
    }

    public class BrgBL : IBrgBL
    {
        private IBrgDal _brgDal;
        private ISubJenisBrgBL _subJenisBrgBL;
        private IMerkBL _merkBL;
        private IColorBL _colorBL;
        private IParameterNoBL _paramNoBL;

        public BrgBL()
        {
            _brgDal = new BrgDal();
            _subJenisBrgBL = new SubJenisBrgBL();
            _merkBL = new MerkBL();
            _colorBL = new ColorBL();
            _paramNoBL = new ParameterNoBL();
        }

        public BrgBL(IBrgDal injBrgDal, ISubJenisBrgBL injSubJenisBrgBL,
            IMerkBL injMerkBL, IColorBL injColorBL)
        {
            _brgDal = injBrgDal;
            _subJenisBrgBL = injSubJenisBrgBL;
            _merkBL = injMerkBL;
            _colorBL = injColorBL;
        }

        public BrgModel Save(BrgModel brg)
        {
            //  validasi
            var result = brg;
            result = TryValidate(brg);

            using (var trans = TransHelper.NewScope())
            {
                //  save
                if (brg.BrgID.Trim() == "")
                {
                    brg.BrgID = _paramNoBL.GenNewID("B", 5);
                    _brgDal.Insert(result);
                }
                else
                {
                    var dummyBrg = _brgDal.GetData(brg.BrgID);
                    if (dummyBrg == null)
                    {
                        _brgDal.Insert(result);
                    }
                    else
                    {
                        _brgDal.Update(result);
                    }
                }
                trans.Complete();
            }

            return result;
        }

        public void Delete(string id)
        {
            _brgDal.Delete(id);
        }

        public BrgModel GetData(string id)
        {
            return _brgDal.GetData(id);
        }

        public IEnumerable<BrgModel> ListData()
        {
            return _brgDal.ListData();
        }

        public BrgModel TryValidate(BrgModel brg)
        {
            var result = brg;

            if (brg == null)
            {
                throw new ArgumentNullException(nameof(brg));
            }

            if (brg.BrgName.Trim() == "")
            {
                throw new ArgumentException("BrgName empty");
            }

            var subJenisBrg = _subJenisBrgBL.GetData(brg.SubJenisBrgID);
            if(subJenisBrg == null)
            {
                throw new ArgumentException("SubJenisBrgID invalid");
            }
            else
            {
                brg.SubJenisBrgName = subJenisBrg.SubJenisBrgName;
            }

            if(brg.MerkID.Trim() != "")
            {
                var merk = _merkBL.GetData(brg.MerkID);
                if(merk == null)
                {
                    throw new ArgumentException("MerkID invalid");
                }
                else
                {
                    brg.MerkName = merk.MerkName;
                }
            }

            if(brg.ColorID.Trim() != "")
            {
                var color = _colorBL.GetData(brg.ColorID);
                if(color == null)
                {
                    throw new ArgumentException("ColorID invalid");
                }
            }
            return result;
        }

        public IEnumerable<BrgModel> ListData(SubJenisBrgModel subJenisBrg)
        {
            return _brgDal.ListData(subJenisBrg);
        }

        public IEnumerable<BrgModel> ListData(string searchKeyword)
        {
            return _brgDal.ListData(searchKeyword);
        }

        public IEnumerable<BrgJenisModel> ListGrouping()
        {
            var resultFlat = _brgDal.ListGrouping();
            if (resultFlat == null)
                return null;

            var result = new List<BrgJenisModel>();
            foreach(var item in resultFlat)
            {
                var jenisTemp = result.Find(x => x.JenisID == item.JenisBrgID);
                if (jenisTemp == null)
                {
                    jenisTemp = new BrgJenisModel
                    {
                        JenisID = item.JenisBrgID,
                        JenisName = item.JenisBrgName
                    };
                    result.Add(jenisTemp);
                }

                var subJenis = jenisTemp.ListSub.Find(x => x.SubID == item.SubJenisID);
                if (subJenis == null)
                {
                    subJenis = new BrgJenisSubModel
                    {
                        SubID = item.SubJenisID,
                        SubName = item.SubJenisName
                    };
                    jenisTemp.ListSub.Add(subJenis);
                }

                var merk = subJenis.ListMerk.Find(x => x.MerkID == item.MerkID);
                if (merk == null)
                {
                    merk = new BrgJenisSubMerkModel
                    {
                        MerkID = item.MerkID,
                        MerkName = item.MerkName
                    };
                    subJenis.ListMerk.Add(merk);
                }

                var color = merk.ListColor.Find(x => x.ColorID == item.ColorID);
                if(color == null)
                {
                    color = new BrgJenisSubMerkColorModel
                    {
                        ColorID = item.ColorID,
                        ColorName = item.ColorID,
                        RedValue = item.RedValue,
                        GreenValue = item.GreenValue,
                        BlueValue = item.BlueValue
                    };
                    merk.ListColor.Add(color);
                }
            }
            return result;
        }

        public IEnumerable<BrgModel> ListData(string jenisID, string subID, string merkID, string colorID)
        {
            return _brgDal.ListData(jenisID, subID, merkID, colorID)
        }
    }
}
