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
    public partial class BPHutangInfoForm : Form
    {
        private IBPHutangInfoDal _bpHutangInfoDal;

        public BPHutangInfoForm()
        {
            InitializeComponent();
            _bpHutangInfoDal = new BPHutangInfoDal();
        }

        private void ProsesButton_Click(object sender, EventArgs e)
        {
            var listData = Proses();
            ShowData(listData);
        }

        private IEnumerable<BPHutangInfoModel> Proses()
        {
            var tgl1 = dateTimePicker1.Value.ToString("dd-MM-yyyy");
            var tgl2 = dateTimePicker2.Value.ToString("dd-MM-yyyy");
            var listData = _bpHutangInfoDal.ListData(tgl1, tgl2);
            if (listData == null) return null;
            return listData;
        }

        private void ShowData(IEnumerable<BPHutangInfoModel> listData)
        {
            BPHutangInfoTable.Clear();
            if (listData == null) return;

            foreach (var item in listData.OrderBy(x => x.BPHutangID + x.Tgl + x.Jam))
            {
                BPHutangInfoTable.Rows.Add(
                    item.BPHutangID,
                    item.ReffID,
                    item.Tgl,
                    item.Jam,
                    item.PihakKeduaName,
                    item.Keterangan,
                    item.NilaiHutang,
                    item.NilaiLunas);
            }
            var totHutang = listData.Sum(x => x.NilaiHutang);
            var totLunas = listData.Sum(x => x.NilaiLunas);

            SaldoTable.Rows.Clear();
            SaldoTable.Rows.Add(totHutang, totLunas, totHutang - totLunas);
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
                    (c.PihakKeduaName.ContainMultiWord(keyword)) ||
                    (c.Keterangan.ContainMultiWord(keyword)))
                select c;

            ShowData(result);
        }
    }
}
