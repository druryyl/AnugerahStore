using AnugerahBackend.Penjualan.BL;
using AnugerahBackend.Penjualan.Dal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnugerahWinform.Penjualan
{
    public partial class LaporanPenjualanForm : Form
    {
        private IPenjualanBL _penjualanBL;
        private IPenjualanBayarDal _penjualanBayarDal;

        public LaporanPenjualanForm()
        {
            InitializeComponent();
            _penjualanBL = new PenjualanBL();
            _penjualanBayarDal = new PenjualanBayarDal();
        }

        private void ProsesButton_Click(object sender, EventArgs e)
        {
            Proses();
        }

        private void Proses()
        {
            var tgl1 = dateTimePicker1.Value.ToString("dd-MM-yyyy");
            var tgl2 = dateTimePicker2.Value.ToString("dd-MM-yyyy");
            var listData = _penjualanBL.ListData(tgl1, tgl2);
            if (listData == null) return;

            var dataSource = listData.ToList();

            LaporanKasirTable.Rows.Clear();
            foreach (var item in dataSource)
            {
                decimal kas = 0;
                decimal edcBca = 0;
                decimal trfBca = 0;
                decimal edcBri = 0;
                decimal trfBri = 0;
                item.ListBayar = _penjualanBayarDal.ListData(item.PenjualanID, false);

                if (item.ListBayar == null) continue;

                foreach (var itemBayar in item.ListBayar)
                {
                    if (itemBayar.JenisBayarID == "KAS") kas = itemBayar.NilaiBayar;
                    if (itemBayar.JenisBayarID == "ED1") edcBca = itemBayar.NilaiBayar;
                    if (itemBayar.JenisBayarID == "TR1") trfBca = itemBayar.NilaiBayar;
                    if (itemBayar.JenisBayarID == "ED2") edcBri = itemBayar.NilaiBayar;
                    if (itemBayar.JenisBayarID == "TR2") trfBri = itemBayar.NilaiBayar;
                }

                LaporanKasirTable.Rows.Add(
                    item.TglPenjualan,
                    item.PenjualanID,
                    item.BuyerName,
                    kas.ToString("N0").PadLeft(15, ' '),
                    edcBca.ToString("N0").PadLeft(15, ' '),
                    trfBca.ToString("N0").PadLeft(15, ' '),
                    edcBri.ToString("N0").PadLeft(15, ' '),
                    trfBri.ToString("N0").PadLeft(15, ' '));
            }


        }
    }

    public class LaporanPenjualanModel
    {
        public string Tgl { get; set; }
        public string Jam { get; set; }
        public string PenjualanID { get; set; }
        public string BuyerName { get; set; }
        public decimal NilaiKas { get; set; }
        public decimal NilaiEdcBca { get; set; }
        public decimal NilaiTrfBca { get; set; }
        public decimal NilaiEdcBri { get; set; }
        public decimal NilaiTrfBri { get; set; }
    }
}
