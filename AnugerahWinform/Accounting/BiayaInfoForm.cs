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
    public partial class BiayaInfoForm : Form
    {
        private IBiayaDal _biayaDal;

        public BiayaInfoForm()
        {
            InitializeComponent();
            _biayaDal = new BiayaDal();
        }

        private void ProsesButton_Click(object sender, EventArgs e)
        {
            var listData = Proses();
            ShowData(listData);
        }

        private IEnumerable<BiayaModel> Proses()
        {
            var tgl1 = dateTimePicker1.Value.ToString("dd-MM-yyyy");
            var tgl2 = dateTimePicker2.Value.ToString("dd-MM-yyyy");
            var listData = _biayaDal.ListData(tgl1, tgl2);
            if (listData == null) return null;
            return listData;
        }

        private void ShowData(IEnumerable<BiayaModel> listData)
        {
            BiayaInfoTable.Clear();
            if (listData == null) return;

            foreach (var item in listData.OrderBy(x => x.Tgl + x.Jam))
            {
                BiayaInfoTable.Rows.Add(
                    item.BiayaID,
                    item.Tgl,
                    item.Jam,
                    item.JenisBiayaName,
                    item.Keterangan,
                    item.NilaiBiaya);
            }
            var totBiaya = listData.Sum(x => x.NilaiBiaya);

            SaldoTable.Rows.Clear();
            SaldoTable.Rows.Add(totBiaya);
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
                    (c.JenisBiayaName.ContainMultiWord(keyword)) ||
                    (c.Keterangan.ContainMultiWord(keyword)))
                select c;

            ShowData(result);
        }
    }
}
