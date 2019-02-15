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
        BPKasModel Generate(BiayaModel biaya);
        BPKasModel Generate(KasBonModel kasBon);
        BPKasModel Generate(LunasKasBonModel lunasKasBon, KasBonModel kasBon);
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

        public BPKasModel Generate(BiayaModel biaya)
        {
            if (biaya == null)
            {
                throw new ArgumentNullException(nameof(biaya));
            }
            var bpKas = (BPKasModel)biaya;
            var result = Save(bpKas);
            return result;
        }

        public BPKasModel Generate(KasBonModel kasBon)
        {
            if (kasBon == null)
            {
                throw new ArgumentNullException(nameof(kasBon));
            }
            var bpKas = (BPKasModel)kasBon;
            var result = Save(bpKas);
            return result;
        }

        public BPKasModel Generate(LunasKasBonModel lunasKasBon, KasBonModel kasBon)
        {
            if (lunasKasBon == null)
            {
                throw new ArgumentNullException(nameof(lunasKasBon));
            }

            if (kasBon == null)
            {
                throw new ArgumentNullException(nameof(kasBon));
            }

            if (lunasKasBon.KasBonID != kasBon.KasBonID)
                throw new ArgumentException("KasBonID invalid");

            //  convert lunasKasBon menjadi object kasBon
            BPKasModel bpKas = new BPKasModel
            {
                BPKasID = lunasKasBon.LunasKasBonID,
                Tgl = lunasKasBon.Tgl,
                Jam = lunasKasBon.Jam,
                Keterangan = "Lunas KasBon " + kasBon.Keterangan,
                NilaiTotalKas = 0,
            };
            BPKasDetilModel detil = new BPKasDetilModel
            {
                BPKasID = bpKas.BPKasID,
                BPKasDetilID = bpKas.BPKasID + '-' + "01",
                JenisKasID = "K01",
                NilaiKasMasuk = 
                    lunasKasBon.ListLunas
                        .Where(x => x.JenisLunasID == "KAS")
                        .Sum(x => x.NilaiLunas)
            };
            bpKas.ListDetil = new List<BPKasDetilModel>
            {
                detil
            };

            var result = Save(bpKas);
            return result;
        }

        private BPKasModel Save(BPKasModel model)
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
                else
                    item.JenisKasName = jenisKas.JenisKasName;
            }

            //  update nilai total di header
            model.NilaiTotalKas = model.ListDetil.Sum(x => x.NilaiKasMasuk);
            model.NilaiTotalKas -= model.ListDetil.Sum(x => x.NilaiKasKeluar);

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

            return model;
        }
    }
}
