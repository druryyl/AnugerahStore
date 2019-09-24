using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahBackend.StokBarang.Model
{
    public class BPStokDetilModel
    {
        public string BPStokID { get; set; }
        public string BPStokDetilID { get; set; }
        public int NoUrut { get; set; }
        public string ReffID { get; set; }
        public string Tgl { get; set; }
        public string Jam { get; set; }

        public decimal QtyIn { get; set; }
        public decimal NilaiHpp { get; set; }

        public decimal QtyOut { get; set; }
        public decimal HargaJual { get; set; }
    }

    public class BPStokDetilView : BPStokDetilModel
    {
        public BPStokDetilView(BPStokDetilModel baseModel)
        {
            this.BPStokDetilID = baseModel.BPStokID;
            this.BPStokDetilID = baseModel.BPStokDetilID;
            this.NoUrut = baseModel.NoUrut;
            this.ReffID = baseModel.ReffID;
            this.Tgl = baseModel.Tgl;
            this.Jam = baseModel.Jam;
            this.QtyIn = baseModel.QtyIn;
            this.QtyOut = baseModel.QtyOut;
            this.NilaiHpp = baseModel.NilaiHpp;
            this.HargaJual = baseModel.HargaJual;
        }
        public BPStokDetilView()
        {

        }

        public string BrgID { get; set; }
        public string BrgName { get; set; }
        public string JenisMutasi { get; set; }
        public decimal SaldoQty { get; set; }
    }
}
