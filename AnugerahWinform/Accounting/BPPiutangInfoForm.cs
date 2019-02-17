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
    public partial class BPPiutangInfoForm : Form
    {
        private IBPPiutangInfoDal _bpPiutangInfoDal;

        public BPPiutangInfoForm()
        {
            InitializeComponent();
            _bpPiutangInfoDal = new BPPiutangInfoDal();
        }

        private void ProsesButton_Click(object sender, EventArgs e)
        {
            var listData = Proses();
            ShowData(listData);
        }

        private IEnumerable<BPPiutangInfoModel> Proses()
        {
            var tgl1 = dateTimePicker1.Value.ToString("dd-MM-yyyy");
            var tgl2 = dateTimePicker2.Value.ToString("dd-MM-yyyy");
            var listData = _bpPiutangInfoDal.ListData(tgl1, tgl2);
            if (listData == null) return null;
            return listData;
        }

        private void ShowData(IEnumerable<BPPiutangInfoModel> listData)
        {
            BPPiutangInfoTable.Clear();
            if (listData == null) return;

            foreach (var item in listData.OrderBy(x => x.BPPiutangID + x.Tgl + x.Jam))
            {
                BPPiutangInfoTable.Rows.Add(
                    item.BPPiutangID,
                    item.ReffID,
                    item.Tgl,
                    item.Jam,
                    item.PihakKeduaName,
                    item.Keterangan,
                    item.NilaiPiutang,
                    item.NilaiLunas);
            }
            var totPiutang = listData.Sum(x => x.NilaiPiutang);
            var totLunas = listData.Sum(x => x.NilaiLunas);

            SaldoTable.Rows.Clear();
            SaldoTable.Rows.Add(totPiutang, totLunas, totPiutang - totLunas);
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
