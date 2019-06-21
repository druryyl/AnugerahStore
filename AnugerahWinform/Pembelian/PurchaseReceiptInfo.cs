using AnugerahBackend.Pembelian.BL;
using AnugerahBackend.Pembelian.Dal;
using AnugerahBackend.Pembelian.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnugerahWinform.Pembelian
{
    public partial class PurchaseReceiptInfo : Form
    {
        private IBPPurchaseDal _bpPurchaseDal;
        private IBPPurchaseReceiptDal _bpPurchaseReceiptDal;
        private IBPPurchaseBL _bpPurchaseBL;

        public PurchaseReceiptInfo()
        {
            InitializeComponent();
            _bpPurchaseDal = new BPPurchaseDal();
            _bpPurchaseReceiptDal = new BPPurchaseReceiptDal();
            _bpPurchaseBL = new BPPurchaseBL();

        }

        private void Proses(string tgl1, string tgl2)
        {

            IEnumerable<BPPurchaseReceiptModel>listData = _bpPurchaseReceiptDal.ListData(tgl1, tgl2);
            if (listData == null) return;
            var listDataSort = listData.OrderBy(x => x.BPPurchaseID + x.BrgID + x.NoUrut.ToString("N0"));
            List<BPPurchaseReceiptInfo> result = new List<BPPurchaseReceiptInfo>();

            decimal qtySisa = 0;
            string supplierName = "";
            bool isClosedPO = false;
            PurchaseReceiptTable.Rows.Clear();

            foreach (var item in listDataSort)
            {
                var trsID = item.BPPurchaseID;
                var bpPurchase = _bpPurchaseDal.GetData(item.BPPurchaseID);

                if (OutstandingCheckBox.Checked == true)
                    if (bpPurchase.IsClosed) continue;

                //  jika baris Purchase
                if (item.BPReceiptID.Trim() == "")
                {
                    supplierName = bpPurchase.SupplierName;
                    qtySisa = _bpPurchaseBL.GetQtyOutstanding(item.BPPurchaseID, item.BrgID);
                    isClosedPO = bpPurchase.IsClosed;
                }
                
                //  jika baris Receipt
                else
                {
                    trsID = "    " + item.BPReceiptID;
                    supplierName = "";
                    qtySisa = 0;
                    isClosedPO = false;
                }

                //  cek supplier
                if (item.QtyPurchase != 0)
                {
                    var status = "";
                    if (isClosedPO) status = "Close";
                    PurchaseReceiptTable.Rows.Add(
                        trsID, item.Tgl, supplierName, item.Keterangan,
                        item.QtyPurchase, null, qtySisa, status);
                }
                else
                {
                    PurchaseReceiptTable.Rows.Add(
                        trsID, item.Tgl, supplierName, item.Keterangan,
                        null, item.QtyReceipt, null, null);
                }
            }

            bool colorToggle = false;
            for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
            {
                var x = dataGridView1.Rows[i].Cells[1].Value.ToString();
                if (x.Trim().Substring(0, 2) == "PC")
                    colorToggle = !colorToggle;

                if (colorToggle)
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.White;
                else
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LemonChiffon;
            }
        }

        private class BPPurchaseReceiptInfo
        {
            public string Tgl { get; set; }
            public string TrsID { get; set; }
            public string Supplier { get; set; }
            public string Keterangan { get; set; }
            public long QtyPurchase { get; set; }
            public long QtyReceipt { get; set; }
            public long QtyOutstanding { get; set; }
        }

        private void ProsesButton_Click(object sender, EventArgs e)
        {
            var tgl1 = dateTimePicker1.Value.ToString("dd-MM-yyyy");
            var tgl2 = dateTimePicker2.Value.ToString("dd-MM-yyyy");

            Proses(tgl1, tgl2);
        }
    }

}
