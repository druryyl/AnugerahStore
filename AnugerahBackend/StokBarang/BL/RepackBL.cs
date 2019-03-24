using AnugerahBackend.StokBarang.Dal;
using AnugerahBackend.StokBarang.Model;
using AnugerahBackend.Support;
using AnugerahBackend.Support.BL;
using Ics.Helper.Database;
using Ics.Helper.Extensions;
using Ics.Helper.StringDateTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.StokBarang.BL
{
    public interface IRepackBL : ISearch<RepackSearchModel>
    {
        RepackModel Save(RepackModel model);
        void Delete(string id);
        RepackModel GetData(string id);
        IEnumerable<RepackModel> ListData(string tgl1, string tgl2);
    }
    
    public class RepackDepCon
    {
        public IRepackDal RepackDal { get; set; }
        public IBrgDal BrgDal { get; set; }
        public IParameterNoBL ParamNoBL { get; set; }
    }

    public class RepackBL : IRepackBL
    {
        private RepackDepCon dep;

        public RepackBL()
        {
            dep = new RepackDepCon
            {
                RepackDal = new RepackDal(),
                BrgDal = new BrgDal(),
                ParamNoBL = new ParameterNoBL()
            };
            SearchFilter = new SearchFilter
            {
                IsDate = true
            };
        }

        public RepackModel Save(RepackModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            //  validasi tgl
            if (!model.Tgl.IsValidTgl("dd-MM-yyyy"))
                throw new ArgumentException("Tgl invalid");

            //  validasi jam
            if (!model.Jam.IsValidJam("HH:mm:ss"))
                throw new ArgumentException("Jam invalid");

            //  brg material
            var brg = dep.BrgDal.GetData(model.BrgIDMaterial);
            if (brg == null)
                throw new ArgumentException("Brg Material invalid");
            else
                model.BrgNameMaterial = brg.BrgName;

            //  brg hasil
            brg = dep.BrgDal.GetData(model.BrgIDHasil);
            if (brg == null)
                throw new ArgumentException("Brg Hasil invalid");
            else
                model.BrgNameHasil = brg.BrgName;

            //  validate qty nol
            if (model.QtyMaterial <= 0)
                throw new ArgumentException("Qty Material nol or minus");
            if (model.QtyHasil <= 0)
                throw new ArgumentException("Qty Hasil nol or minus");

            using (var trans = TransHelper.NewScope())
            {
                if (model.RepackID.Trim() == "")
                    model.RepackID = GenNewID();
            }

            return model;
        }

        private string GenNewID()
        {
            var prefix = "RP" + DateTime.Now.ToString("yyMM");
            var result = dep.ParamNoBL.GenNewID(prefix, 10);
            return result;
        }

        public void Delete(string id)
        {
            dep.RepackDal.Delete(id);
        }

        public RepackModel GetData(string id)
        {
            return dep.RepackDal.GetData(id);
        }

        public IEnumerable<RepackModel> ListData(string tgl1, string tgl2)
        {
            return dep.RepackDal.ListData(tgl1, tgl2);
        }

        public SearchFilter SearchFilter { get; set; }

        public IEnumerable<RepackSearchModel> Search()
        {
            var listData = dep.RepackDal.ListData(SearchFilter.TglDMY1, SearchFilter.TglDMY2);
            if (listData == null) return null;
            var result = listData.Select(x => (RepackSearchModel)x);

            //  filter
            if (SearchFilter.UserKeyword != null)
                return
                    from c in result
                    where c.BrgNameHasil.ContainMultiWord(SearchFilter.UserKeyword)
                    select c;

            return result;
        }
    }
}
