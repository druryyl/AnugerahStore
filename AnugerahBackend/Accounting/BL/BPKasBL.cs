using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnugerahBackend.Accounting.Dal;
using AnugerahBackend.Accounting.Model;
using AnugerahBackend.Penjualan.BL;
using AnugerahBackend.Penjualan.Model;
using Ics.Helper.Database;

namespace AnugerahBackend.Accounting.BL
{
    public interface IBPKasBL
    {
        BPKasModel Generate(BiayaModel biaya);
        void GenDelete(BiayaModel biaya);

        BPKasModel Generate(KasBonModel kasBon);
        BPKasModel Generate(LunasKasBonModel lunasKasBon, KasBonModel kasBon);
        BPKasModel Generate(PenjualanModel penjualan);
        BPKasModel Generate(DepositModel deposit);
        BPKasModel Generate(ReturDepositModel returDeposit);
        IEnumerable<BPKasModel> ListData(string tgl1, string tgl2);
    }

    public class BPKasBL : IBPKasBL
    {
        private IBPKasDal _bpKasDal;
        private IBPKasDetilDal _bpKasDetilDal;
        private IBiayaBL _biayaBL;
        private IJenisKasBL _jenisKasBL;
        private IJenisBayarBL _jenisBayarBL;

        public BPKasBL()
        {
            _bpKasDal = new BPKasDal();
            _bpKasDetilDal = new BPKasDetilDal();
            _biayaBL = new BiayaBL();
            _jenisKasBL = new JenisKasBL();
            _jenisBayarBL = new JenisBayarBL();
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

        public void GenDelete(BiayaModel biaya)
        {
            if (biaya == null)
            {
                throw new ArgumentNullException(nameof(biaya));
            }
            _bpKasDal.Delete(biaya.BiayaID);
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

        public BPKasModel Generate(PenjualanModel penjualan)
        {
            var bpKas = new BPKasModel
            {
                BPKasID = penjualan.PenjualanID,
                Tgl = penjualan.TglPenjualan,
                Jam = penjualan.JamPenjualan,
                Keterangan = string.Format("Penjualan {0} a/n {1}", penjualan.PenjualanID, penjualan.BuyerName),
                NilaiTotalKas = 0
            };
            var listBpKasDetil = new List<BPKasDetilModel>();

            //  update jenisKasID di detil penjualan
            foreach(var item in penjualan.ListBayar)
            {
                var jenisBayar = _jenisBayarBL.GetData(item.JenisBayarID);
                var jenisKas = _jenisKasBL.GetData(jenisBayar.JenisKasID);
                item.JenisKasID = jenisKas.JenisKasID;
                item.JenisKasName = jenisKas.JenisKasName;
            }

            var listJenisKas = _jenisKasBL.ListData();
            int noUrut = 1;
            foreach(var item in listJenisKas)
            {
                var bpKasDetil = new BPKasDetilModel
                {
                    BPKasID = penjualan.PenjualanID,
                    BPKasDetilID = penjualan.PenjualanID + '-' + noUrut.ToString().PadLeft(2, '0'),
                    JenisKasID = item.JenisKasID,
                    JenisKasName = item.JenisKasName,
                    NilaiKasMasuk = penjualan.ListBayar
                        .Where(x => x.JenisKasID == item.JenisKasID)
                        .Sum(x => x.NilaiBayar),
                };
                noUrut++;
                if (bpKasDetil.NilaiKasMasuk != 0)
                    listBpKasDetil.Add(bpKasDetil);
            }
            bpKas.ListDetil = listBpKasDetil;
            var result = Save(bpKas);
            return result;
        }
        public BPKasModel Generate(DepositModel deposit)
        {
            if (deposit == null)
            {
                throw new ArgumentNullException(nameof(deposit));
            }
            var bpKas = (BPKasModel)deposit;
            var result = Save(bpKas);
            return result;
        }
        public BPKasModel Generate(ReturDepositModel returDeposit)
        {
            if (returDeposit == null)
            {
                throw new ArgumentNullException(nameof(returDeposit));
            }
            var bpKas = (BPKasModel)returDeposit;
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
        public IEnumerable<BPKasModel> ListData(string tgl1, string tgl2)
        {
            var result = _bpKasDal.ListData(tgl1, tgl2);
            return result;
        }


    }
}
