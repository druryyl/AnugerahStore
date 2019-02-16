using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AnugerahBackend.Accounting.Dal;
using AnugerahBackend.Accounting.Model;
using Ics.Helper.Extensions;

namespace AnugerahWinform.Accounting
{
    public partial class BPKasInfoForm : Form
    {
        private IBPKasInfoDal _bpKasInfoDal;

        public BPKasInfoForm()
        {
            InitializeComponent();
            _bpKasInfoDal = new BPKasInfoDal();
        }

        private void ProsesButton_Click(object sender, EventArgs e)
        {
            var listData = Proses();
            ShowData(listData);
        }

        private IEnumerable<BPKasInfoModel> Proses()
        {
            var tgl1 = dateTimePicker1.Value.ToString("dd-MM-yyyy");
            var tgl2 = dateTimePicker2.Value.ToString("dd-MM-yyyy");
            var listData = _bpKasInfoDal.ListData(tgl1, tgl2);
            if (listData == null) return null;
            return listData;
        }

        private void ShowData(IEnumerable<BPKasInfoModel> listData)
        {
            BPKasInfoTable.Clear();
            if (listData == null) return;

            foreach (var item in listData.OrderBy(x => x.Tgl + x.Jam))
            {
                BPKasInfoTable.Rows.Add(
                    item.BPKasID,
                    item.BPKasDetilID,
                    item.Tgl,
                    item.Jam,
                    item.JenisKasName,
                    item.Keterangan,
                    item.NilaiKasMasuk,
                    item.NilaiKasKeluar);
            }
            var totKasMasuk = listData.Sum(x => x.NilaiKasMasuk);
            var totKasKeluar = listData.Sum(x => x.NilaiKasKeluar);

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
                    (c.JenisKasName.ContainMultiWord(keyword)) ||
                    (c.Keterangan.ContainMultiWord(keyword)))
                select c;

            ShowData(result);
        }
    }
}
