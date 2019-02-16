using AnugerahBackend.Penjualan.BL;
using AnugerahBackend.Penjualan.Dal;
using Ics.Helper.Extensions;
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
            var listData = Proses();
            ShowData(listData);
        }

        private IEnumerable<LaporanPenjualanModel> Proses()
        {
            var tgl1 = dateTimePicker1.Value.ToString("dd-MM-yyyy");
            var tgl2 = dateTimePicker2.Value.ToString("dd-MM-yyyy");
            var listData = _penjualanBL.ListData(tgl1, tgl2);
            if (listData == null) return null;

            var dataSource = new List<LaporanPenjualanModel>();

            foreach (var item in listData)
            {
                decimal kas = 0;
                decimal edcBca = 0;
                decimal trfBca = 0;
                decimal edcBri = 0;
                decimal trfBri = 0;

                item.ListBayar = _penjualanBayarDal.ListData(item.PenjualanID);

                if (item.ListBayar == null) continue;

                foreach (var itemBayar in item.ListBayar)
                {
                    if (itemBayar.JenisBayarID == "KAS") kas = itemBayar.NilaiBayar;
                    if (itemBayar.JenisBayarID == "ED1") edcBca = itemBayar.NilaiBayar;
                    if (itemBayar.JenisBayarID == "TR1") trfBca = itemBayar.NilaiBayar;
                    if (itemBayar.JenisBayarID == "ED2") edcBri = itemBayar.NilaiBayar;
                    if (itemBayar.JenisBayarID == "TR2") trfBri = itemBayar.NilaiBayar;
                }

                dataSource.Add(new LaporanPenjualanModel
                {
                    Tgl = item.TglPenjualan,
                    PenjualanID = item.PenjualanID,
                    BuyerName = item.BuyerName,
                    NilaiPenjualan = item.NilaiGrandTotal,
                    NilaiKas = kas,
                    NilaiEdcBca = edcBca,
                    NilaiTrfBca = trfBca,
                    NilaiEdcBri = edcBri,
                    NilaiTrfBri = trfBri,
                });
            }
            return dataSource;
        }

        private void ShowData(IEnumerable<LaporanPenjualanModel> listData)
        {
            LaporanKasirTable.Clear();
            if (listData == null) return;

            foreach (var item in listData)
            {

                LaporanKasirTable.Rows.Add(
                    item.Tgl,
                    item.PenjualanID,
                    item.BuyerName,
                    item.NilaiKas,
                    item.NilaiEdcBca,
                    item.NilaiTrfBca,
                    item.NilaiEdcBri,
                    item.NilaiTrfBri,
                    item.NilaiPenjualan);
            }
            var totJual = listData.Sum(x => x.NilaiPenjualan);
            var totKas = listData.Sum(x => x.NilaiKas);
            var totEdcBca = listData.Sum(x => x.NilaiEdcBca);
            var totTrfBca = listData.Sum(x => x.NilaiTrfBca);
            var totEdcBri = listData.Sum(x => x.NilaiEdcBri);
            var totTrfBri = listData.Sum(x => x.NilaiTrfBri);

            SaldoTable.Rows.Clear();
            SaldoTable.Rows.Add(totKas, totEdcBca, totTrfBca, totEdcBri, totTrfBri, totJual);
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            Search();
        }
        private void Search()
        {
            var listData = Proses();
            var keyword = SearchKeywordText.Text;
            var result = listData.Where(x => x.BuyerName.ContainMultiWord(keyword));
            ShowData(result);
        }
    }

    public class LaporanPenjualanModel
    {
        public string Tgl { get; set; }
        public string Jam { get; set; }
        public string PenjualanID { get; set; }
        public string BuyerName { get; set; }
        public decimal NilaiPenjualan { get; set; }
        public decimal NilaiKas { get; set; }
        public decimal NilaiEdcBca { get; set; }
        public decimal NilaiTrfBca { get; set; }
        public decimal NilaiEdcBri { get; set; }
        public decimal NilaiTrfBri { get; set; }
    }
}
