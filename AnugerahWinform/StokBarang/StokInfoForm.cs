using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AnugerahBackend.StokBarang.Dal;
using AnugerahBackend.StokBarang.Model;
using Ics.Helper.Extensions;

namespace AnugerahWinform.StokBarang
{
    public partial class StokInfoForm : Form
    {
        private StokInfoDal _stokInfoDal;

        public StokInfoForm()
        {
            InitializeComponent();
            _stokInfoDal = new StokInfoDal();
        }

        private IEnumerable<StokInfoModel> Proses()
        {
            var listData = _stokInfoDal.ListData();
            if (listData == null) return null;
            return listData;
        }

        private void ShowData(IEnumerable<StokInfoModel> listData)
        {
            StokInfoTable.Clear();
            if (listData == null) return;

            foreach (var item in listData.OrderBy(x => x.BrgName))
            {
                StokInfoTable.Rows.Add(
                    item.BrgID,
                    item.BrgName,
                    item.Qty);
            }
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
                where c.BrgName.ContainMultiWord(keyword)
                select c;

            ShowData(result);
        }

        private void ProsesButton_Click(object sender, EventArgs e)
        {
            ShowData(Proses());
        }
    }
}
