using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.Accounting.Model
{
    public class BPKasModel
    {
        public string BPKasID { get; set; }
        public string Tgl { get; set; }
        public string Jam { get; set; }
        public string Keterangan { get; set; }
        public decimal NilaiTotalKas { get; set; }
        public IEnumerable<BPKasDetilModel> ListDetil { get; set; }

        public static explicit operator BPKasModel(BiayaModel model)
        {
            var result = new BPKasModel
            {
                BPKasID = model.BiayaID,
                Tgl = model.Tgl,
                Jam = model.Jam,
                Keterangan = "Biaya " + model.Keterangan,
                NilaiTotalKas = -model.NilaiBiaya
            };

            var resultDetil = new BPKasDetilModel
            {
                BPKasID = model.BiayaID,
                BPKasDetilID = model.BiayaID + '-' + "01",
                JenisKasID = model.JenisKasID,
                NilaiKasMasuk = 0,
                NilaiKasKeluar = model.NilaiBiaya
            };

            result.ListDetil = new List<BPKasDetilModel> { resultDetil };
            return result;
        }

        public static explicit operator BPKasModel(KasBonModel model)
        {
            var result = new BPKasModel
            {
                BPKasID = model.KasBonID,
                Tgl = model.Tgl,
                Jam = model.Jam,
                Keterangan = "KasBon " + model.Keterangan,
                NilaiTotalKas = -model.NilaiKasBon
            };

            var resultDetil = new BPKasDetilModel
            {
                BPKasID = model.KasBonID,
                BPKasDetilID = model.KasBonID + '-' + "01",
                JenisKasID = model.JenisKasID,
                NilaiKasMasuk = 0,
                NilaiKasKeluar = model.NilaiKasBon
            };

            result.ListDetil = new List<BPKasDetilModel> { resultDetil };
            return result;
        }

        public static explicit operator BPKasModel(DepositModel model)
        {
            var result = new BPKasModel
            {
                BPKasID = model.DepositID,
                Tgl = model.Tgl,
                Jam = model.Jam,
                Keterangan = "Deposit " + model.Keterangan,
                NilaiTotalKas = model.NilaiDeposit
            };

            var resultDetil = new BPKasDetilModel
            {
                BPKasID = model.DepositID,
                BPKasDetilID = model.DepositID + '-' + "01",
                JenisKasID = model.JenisKasID,
                NilaiKasMasuk = model.NilaiDeposit,
                NilaiKasKeluar = 0
            };

            result.ListDetil = new List<BPKasDetilModel> { resultDetil };
            return result;
        }

        public static explicit operator BPKasModel(ReturDepositModel model)
        {
            var result = new BPKasModel
            {
                BPKasID = model.ReturDepositID,
                Tgl = model.Tgl,
                Jam = model.Jam,
                Keterangan = "Retur Deposit " + model.Catatan,
                NilaiTotalKas = -model.NilaiReturDeposit
            };

            var resultDetil = new BPKasDetilModel
            {
                BPKasID = model.ReturDepositID,
                BPKasDetilID = model.ReturDepositID + '-' + "01",
                JenisKasID = model.JenisKasID,
                NilaiKasMasuk = 0,
                NilaiKasKeluar = model.NilaiReturDeposit
            };

            result.ListDetil = new List<BPKasDetilModel> { resultDetil };
            return result;
        }

        public static explicit operator BPKasModel(MutasiKasModel model)
        {
            var result = new BPKasModel
            {
                BPKasID = model.MutasiKasID,
                Tgl = model.Tgl,
                Jam = model.Jam,
                Keterangan = "[MUTASI-KAS]" + model.Keterangan,
                NilaiTotalKas = 0
            };

            var resultDetilAsal = new BPKasDetilModel
            {
                BPKasID = model.MutasiKasID,
                BPKasDetilID = model.MutasiKasID+ '-' + "01",
                JenisKasID = model.JenisKasIDAsal,
                NilaiKasMasuk = 0,
                NilaiKasKeluar = model.NilaiKas
            };
            var resultDetilTujuan = new BPKasDetilModel
            {
                BPKasID = model.MutasiKasID,
                BPKasDetilID = model.MutasiKasID + '-' + "02",
                JenisKasID = model.JenisKasIDTujan,
                NilaiKasMasuk = model.NilaiKas,
                NilaiKasKeluar = 0
            };
            result.ListDetil = new List<BPKasDetilModel> { resultDetilAsal, resultDetilTujuan };
            return result;
        }
    }
}
