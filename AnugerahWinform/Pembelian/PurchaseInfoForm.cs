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
using AnugerahBackend.Pembelian.BL;
using AnugerahBackend.Pembelian.Model;
using Ics.Helper.Extensions;

namespace AnugerahWinform.Pembelian
{
    public partial class PurchaseInfoForm : Form
    {
        private IPurchaseBL _purchaseBL;

        public PurchaseInfoForm()
        {
            InitializeComponent();
            _purchaseBL = new PurchaseBL();
        }

        private void ProsesButton_Click(object sender, EventArgs e)
        {
            var listData = Proses();
            ShowData(listData);
        }

        private IEnumerable<PurchaseModel> Proses()
        {
            var tgl1 = dateTimePicker1.Value.ToString("dd-MM-yyyy");
            var tgl2 = dateTimePicker2.Value.ToString("dd-MM-yyyy");
            var listData = _purchaseBL.ListData(tgl1, tgl2);
            if (listData == null) return null;
            return listData;
        }

        private void ShowData(IEnumerable<PurchaseModel> listData)
        {
            PurchaseInfoTable.Clear();
            if (listData == null) return;

            foreach (var item in listData.OrderBy(x => x.PurchaseID + x.Tgl + x.Jam))
            {
                PurchaseInfoTable.Rows.Add(
                    item.PurchaseID,
                    item.Tgl,
                    item.SupplierName,
                    item.Keterangan,
                    item.TotalHarga,
                    item.Diskon,
                    item.BiayaLain,
                    item.GrandTotal);
            }
            var totHarga = listData.Sum(x => x.TotalHarga);
            var totDiskon = listData.Sum(x => x.Diskon);
            var totBiaya = listData.Sum(x => x.BiayaLain);
            var totGrandTot = listData.Sum(x => x.GrandTotal);

            SaldoTable.Rows.Clear();
            SaldoTable.Rows.Add(totHarga, totDiskon, totBiaya, totGrandTot);
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
                    (c.SupplierName.ContainMultiWord(keyword)) ||
                    (c.Keterangan.ContainMultiWord(keyword)))
                select c;

            ShowData(result);
        }
    }
}
