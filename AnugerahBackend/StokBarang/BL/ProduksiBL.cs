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
    public interface IProduksiBL : ISearch<ProduksiSearchModel>
    {
        ProduksiModel Save(ProduksiModel model);
        void Delete(string produksiID);
        ProduksiModel GetData(string produksiID);
        IEnumerable<ProduksiModel> ListData(string tgl1, string tgl2);
    }

    public class ProduksiDepCon
    {
        public IProduksiDal ProduksiDal { get; set; }
        public IProduksiMaterialDal ProduksiMaterialDal { get; set; }
        public IProduksiHasilDal ProduksiHasilDal { get; set; }
        public IBrgDal BrgDal { get; set; }
        public IParameterNoBL ParamNoBL { get; set; }
    }

    public class ProduksiBL : IProduksiBL
    {
        private readonly ProduksiDepCon dep;

        public ProduksiBL()
        {
            dep = new ProduksiDepCon
            {
                ProduksiDal = new ProduksiDal(),
                ProduksiMaterialDal = new ProduksiMaterialDal(),
                ProduksiHasilDal = new ProduksiHasilDal(),
                BrgDal = new BrgDal(),
                ParamNoBL = new ParameterNoBL()
            };
            SearchFilter = new SearchFilter
            {
                IsDate = true,
                Date1 = DateTime.Now,
                Date2 = DateTime.Now,
            };
        }
        public ProduksiBL(ProduksiDepCon injDepCon)
        {
            dep = injDepCon;
        }

        public ProduksiModel Save(ProduksiModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            //  cek tgl
            if (!model.Tgl.IsValidTgl("dd-MM-yyyy"))
                throw new ArgumentException("Tgl invalid");

            //  cek jam
            if (!model.Jam.IsValidJam("HH:mm:ss"))
                throw new ArgumentException("Jam invalid");

            //  validasi list material
            if(model.ListMaterial == null)
                throw new ArgumentException("Material koosong");
            if (model.ListMaterial.Count() == 0)
                throw new ArgumentException("Material koosong");

            //  cek brg material
            foreach (var item in model.ListMaterial)
            {
                //  cek BrgID
                var brg = dep.BrgDal.GetData(item.BrgID);
                if (brg == null)
                    throw new ArgumentException("Material BrgID invalid");
                item.BrgName = brg.BrgName;

                //  qty tidak boleh nol atau minus
                if (item.Qty <= 0)
                    throw new ArgumentException("Material Qty = 0 or Minus");
            }

            //  validasi list hasil
            if (model.ListHasil == null)
                throw new ArgumentException("Hasil koosong");
            if (model.ListHasil.Count() == 0)
                throw new ArgumentException("Hasil koosong");

            //  cek brg hasil
            foreach (var item in model.ListHasil)
            {
                //  cek BrgID
                var brg = dep.BrgDal.GetData(item.BrgID);
                if (brg == null)
                    throw new ArgumentException("Hasil BrgID invalid");
                item.BrgName = brg.BrgName;
                //  qty tidak boleh nol atau minus
                if (item.Qty <= 0)
                    throw new ArgumentException("Hasil Qty = 0 or Minus");
            }

            //  simpan
            using (var trans = TransHelper.NewScope())
            {
                //  generate nomor transaksi
                if (model.ProduksiID.Trim() == "")
                    model.ProduksiID = GenNewID();

                //  hapus data lama
                dep.ProduksiHasilDal.Delete(model.ProduksiID);
                dep.ProduksiMaterialDal.Delete(model.ProduksiID);
                dep.ProduksiDal.Delete(model.ProduksiID);

                //  simpan data baru
                dep.ProduksiDal.Insert(model);
                foreach (var item in model.ListMaterial)
                    dep.ProduksiMaterialDal.Insert(item);
                foreach (var item in model.ListHasil)
                    dep.ProduksiHasilDal.Insert(item);

                trans.Complete();
            }
            return model;
        }

        private string GenNewID()
        {
            var prefix = "PR" + DateTime.Now.ToString("yyMM");
            var result = dep.ParamNoBL.GenNewID(prefix, 10);
            return result;
        }

        public void Delete(string produksiID)
        {
            using (var trans = TransHelper.NewScope())
            {
                dep.ProduksiHasilDal.Delete(produksiID);
                dep.ProduksiMaterialDal.Delete(produksiID);
                dep.ProduksiDal.Delete(produksiID);

                trans.Complete();
            }
        }

        public ProduksiModel GetData(string produksiID)
        {
            var result = dep.ProduksiDal.GetData(produksiID);
            if (result == null) return null;

            result.ListHasil = dep.ProduksiHasilDal.ListData(produksiID);
            result.ListMaterial = dep.ProduksiMaterialDal.ListData(produksiID);

            return result;
        }

        public IEnumerable<ProduksiModel> ListData(string tgl1, string tgl2)
        {
            return dep.ProduksiDal.ListData(tgl1, tgl2);
        }

        public SearchFilter SearchFilter { get; set; }

        public IEnumerable<ProduksiSearchModel> Search()
        {
            var listData = dep.ProduksiDal.ListData(SearchFilter.TglDMY1, SearchFilter.TglDMY2);
            if (listData == null) return null;

            var result = listData.Select(x => (ProduksiSearchModel)x);

            //  filter
            if (SearchFilter.UserKeyword != null)
                return
                    from c in result
                    where c.Keterangan.ContainMultiWord(SearchFilter.UserKeyword)
                    select c;

            return result;

        }
    }
}
