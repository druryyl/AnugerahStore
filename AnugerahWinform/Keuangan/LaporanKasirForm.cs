using AnugerahBackend.Keuangan.BL;
using AnugerahBackend.Keuangan.Dal;
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

namespace AnugerahWinform.Keuangan
{
    public partial class LaporanKasirForm : Form
    {
        private IBukuKasBL _bukuKasBL;

        public LaporanKasirForm()
        {
            InitializeComponent();
            _bukuKasBL = new BukuKasBL();
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
            var listData = _bukuKasBL.ListData(tgl1, tgl2);
            if (listData == null) return null;

            var dataSource = new List<LaporanPenjualanModel>();

            foreach (var item in listData)
            {
                dataSource.Add(new LaporanPenjualanModel
                {
                    Tgl = item.TglBuku,
                    BukuKasID = item.BukuKasID,
                    JenisTrsKasirName = item.JenisTrsKasirName,
                    PihakKetigaName = item.PihakKetigaName,
                    Keterangan = item.Keterangan,
                    ReffID = item.ReffID,
                    NilaiKas = item.NilaiKas,
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
                decimal kasMasuk = 0;
                decimal kasKeluar = 0;
                if (item.NilaiKas > 0)
                    kasMasuk = item.NilaiKas;
                else
                    kasKeluar = item.NilaiKas * -1;

                LaporanKasirTable.Rows.Add(
                    item.Tgl,
                    item.BukuKasID,
                    item.JenisTrsKasirName,
                    item.PihakKetigaName,
                    item.Keterangan,
                    item.ReffID,
                    kasMasuk, kasKeluar);
            }
            var totKasMasuk = listData.Where(x => x.NilaiKas>0).Sum(x => x.NilaiKas);
            var totKasKeluar = listData.Where(x => x.NilaiKas < 0).Sum(x => x.NilaiKas * -1);

            SaldoTable.Rows.Clear();
            SaldoTable.Rows.Add(totKasMasuk, totKasKeluar, totKasMasuk - totKasKeluar);
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            Search();
        }
        private void Search()
        {
            var listData = Proses();
            var keyword = SearchKeywordText.Text;
            var result =
                from c in listData
                where (
                    (c.JenisTrsKasirName.ContainMultiWord(keyword)) ||
                    (c.PihakKetigaName.ContainMultiWord(keyword)) ||
                    (c.Keterangan.ContainMultiWord(keyword)))
                select c;

            ShowData(result);
        }
    }
    public class LaporanPenjualanModel
    {
        public string Tgl { get; set; }
        public string BukuKasID { get; set; }
        public string JenisTrsKasirName { get; set; }
        public string PihakKetigaName { get; set; }
        public string Keterangan { get; set; }
        public string ReffID { get; set; }
        public decimal NilaiKas { get; set; }
    }
}
