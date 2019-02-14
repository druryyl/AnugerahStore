using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnugerahBackend.Accounting.Dal;
using AnugerahBackend.Accounting.Model;
using Ics.Helper.Database;

namespace AnugerahBackend.Accounting.BL
{
    public interface IBPKasBL
    {
        void Generate(BiayaModel biaya);
    }

    public class BPKasBL : IBPKasBL
    {
        private IBPKasDal _bpKasDal;
        private IBPKasDetilDal _bpKasDetilDal;
        private IBiayaBL _biayaBL;
        private IJenisKasBL _jenisKasBL;

        public BPKasBL()
        {
            _bpKasDal = new BPKasDal();
            _bpKasDetilDal = new BPKasDetilDal();
            _biayaBL = new BiayaBL();
            _jenisKasBL = new JenisKasBL();
        }

        public void Generate(BiayaModel biaya)
        {
            if (biaya == null)
            {
                throw new ArgumentNullException(nameof(biaya));
            }

            var bpKas = (BPKasModel)biaya;
            Save(bpKas);
        }

        private void Save(BPKasModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            //  validate jenis kas di detil;
            foreach(var item in model.ListDetil)
            {
                var jenisKas = _jenisKasBL.GetData(item.JenisKasID);
                if (jenisKas == null)
                    throw new ArgumentException("Invalid Jenis Kas");
            }

            //  update nilai total di header
            model.NilaiTotalKas = model.ListDetil.Sum(x => x.NilaiKasMasuk);
            model.NilaiTotalKas = -model.ListDetil.Sum(x => x.NilaiKasKeluar);

            //  delete data lama
            using (var trans = TransHelper.NewScope())
            {
                _bpKasDetilDal.Delete(model.BPKasID);
                _bpKasDal.Delete(model.BPKasID);

                _bpKasDal.Insert(model);
                foreach (var item in model.ListDetil)
                    _bpKasDetilDal.Insert(item);

                trans.Complete();
            }
        }
    }
}
