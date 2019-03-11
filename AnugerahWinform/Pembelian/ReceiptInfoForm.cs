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
    public partial class ReceiptInfoForm : Form
    {
        private IReceiptBL _receiptBL;

        public ReceiptInfoForm()
        {
            InitializeComponent();
            _receiptBL = new ReceiptBL();
        }

        private void ProsesButton_Click(object sender, EventArgs e)
        {
            var listData = Proses();
            ShowData(listData);
        }

        private IEnumerable<ReceiptModel> Proses()
        {
            var tgl1 = dateTimePicker1.Value.ToString("dd-MM-yyyy");
            var tgl2 = dateTimePicker2.Value.ToString("dd-MM-yyyy");
            var listData = _receiptBL.ListData(tgl1, tgl2);
            if (listData == null) return null;
            return listData;
        }

        private void ShowData(IEnumerable<ReceiptModel> listData)
        {
            ReceiptInfoTable.Clear();
            if (listData == null) return;

            foreach (var item in listData.OrderBy(x => x.ReceiptID + x.Tgl + x.Jam))
            {
                ReceiptInfoTable.Rows.Add(
                    item.ReceiptID,
                    item.Tgl,
                    item.SupplierName,
                    item.Keterangan,
                    null, null, null, null);
                var receipt = _receiptBL.GetData(item.ReceiptID);
                if (receipt == null) continue;
                foreach (var item2 in receipt.ListBrg)
                {
                    var ket = string.Format(" - {1}x : {0}",
                        item2.BrgName, item2.Qty.ToString("N0"));
                    ReceiptInfoTable.Rows.Add(
                        "", null, "", ket,
                        null, null, null, null);
                }
                ReceiptInfoTable.Rows.Add(
                    null, null, null, null,
                    item.TotalHarga,
                    item.Diskon,
                    item.BiayaLain,
                    item.GrandTotal);
            }
            var colorToggle = false;
            for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
            {
                if (dataGridView1.Rows[i].Cells[0].Value.ToString().Trim() != "")
                    colorToggle = !colorToggle;
                if (colorToggle)
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.White;
                else
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LemonChiffon;
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
