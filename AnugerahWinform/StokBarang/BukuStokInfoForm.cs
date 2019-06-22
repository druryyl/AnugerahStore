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
    public partial class BukuStokInfoForm : Form
    {
        private BPStokDal _bpStokDal;

        public BukuStokInfoForm()
        {
            InitializeComponent();
            _bpStokDal = new BPStokDal();
        }

        private void ProsesButton_Click(object sender, EventArgs e)
        {
            var listData = Proses();
            ShowData(listData);
        }

        private IEnumerable<BPStokInfoDetilModel> Proses()
        {
            var tgl1 = dateTimePicker1.Value.ToString("dd-MM-yyyy");
            var tgl2 = dateTimePicker2.Value.ToString("dd-MM-yyyy");
            var listData = _bpStokDal.ListData(tgl1, tgl2);
            if (listData == null) return null;
            return listData;
        }

        private void ShowData(IEnumerable<BPStokInfoDetilModel> listData)
        {
            BukuStokInfoTable.Clear();
            if (listData == null) return;

            foreach (var item in listData.OrderBy(x => x.BrgName + x.BPStokID + x.NoUrut))
            {
                BukuStokInfoTable.Rows.Add(
                    item.BPStokID,
                    item.NoUrut,
                    item.Tgl,
                    item.BrgID,
                    item.ReffID,
                    item.QtyIn,
                    item.NilaiHPP,
                    item.QtyOut,
                    item.HargaJual,
                    item.NilaiPersediaan,
                    item.PendapatanJual,
                    item.BrgName,
                    item.SupplierName);
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
    }
}
