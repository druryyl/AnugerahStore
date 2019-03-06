using AnugerahBackend.Penjualan.BL;
using AnugerahBackend.Penjualan.Model;
using AnugerahBackend.StokBarang.BL;
using AnugerahBackend.StokBarang.Model;
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

namespace AnugerahWinform.Penjualan
{
    public partial class PricingForm : Form
    {
        private IBrgBL _brgBL;
        private IColorBL _colorBL;
        private IBrgPriceBL _brgPriceBL;

        const string NO_ID = "x";
        const string NO_NAME_MERK = "[Tanpa Merk]";
        const string NO_NAME_COLOR = "[Tanpa Color]";

        public PricingForm()
        {
            InitializeComponent();

            _brgBL = new BrgBL();
            _colorBL = new ColorBL();
            _brgPriceBL = new BrgPriceBL();

        }

        private void LoadJenisTreeView()
        {
            PrgBar.Visible = true;
            PrgBar.Minimum = 0;
            PrgBar.Value = 0;
            var listJenis = _brgBL.ListGrouping();
            if (listJenis == null) return;
            PrgBar.Maximum = listJenis.Count();

            JenisTreeView.Nodes.Clear();
            foreach(var jenis in listJenis)
            {
                PrgBar.Value++;
                JenisTreeView.Nodes.Add(jenis.JenisID, jenis.JenisName);
                var jenisNode = JenisTreeView.Nodes[jenis.JenisID];
                foreach(var sub in jenis.ListSub)
                {
                    jenisNode.Nodes.Add(sub.SubID, sub.SubName);
                    var subNode = jenisNode.Nodes[sub.SubID];
                    foreach(var merk in sub.ListMerk)
                    {
                        if (merk.MerkID == "")
                        {
                            merk.MerkID = NO_ID;
                            merk.MerkName = NO_NAME_MERK;
                        }
                        subNode.Nodes.Add(merk.MerkID, merk.MerkName);
                        var merkNode = subNode.Nodes[merk.MerkID];
                        foreach(var color in merk.ListColor)
                        {
                            if (color.ColorID == "")
                            {
                                color.ColorID = NO_ID;
                                color.ColorName = NO_NAME_COLOR;
                            }

                            merkNode.Nodes.Add(color.ColorID, color.ColorName);
                        }
                    }
                }
            }
            PrgBar.Visible = false;
            PrgBar.Minimum = 0;
            PrgBar.Value = 0;
        }

        private void JenisTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ShowGridBrg(e);
        }

        private void ShowGridBrg(TreeViewEventArgs e)
        {
            var jenisID = "";
            var subID = "";
            var merkID = "";
            var colorID = "";

            if(e.Node.Level == 3)
            {
                colorID = e.Node.Name;

                var merkNode = e.Node.Parent;
                merkID = merkNode.Name;

                var subNode = merkNode.Parent;
                subID = subNode.Name;

                var jenisNode = subNode.Parent;
                jenisID = jenisNode.Name;
            }

            if (e.Node.Level == 2)
            {
                colorID = "";
                merkID = e.Node.Name;

                var subNode = e.Node.Parent;
                subID = subNode.Name;

                var jenisNode = subNode.Parent;
                jenisID = jenisNode.Name;
            }

            if (e.Node.Level == 1)
            {
                colorID = "";
                merkID = "";
                subID = e.Node.Name;

                var jenisNode = e.Node.Parent;
                jenisID = jenisNode.Name;
            }

            if (e.Node.Level == 0)
            {
                colorID = "";
                merkID = "";
                subID = "";

                jenisID = e.Node.Name;
            }

            //  query data
            var listBrg = _brgBL.ListData(jenisID, subID, merkID, colorID);

            FillGrid(listBrg);
        }

        private void FillGrid(IEnumerable<BrgModel> listData)
        {
            BrgGrid.Rows.Clear();

            if (listData == null)
                return;

            PrgBar.Value = 0;
            PrgBar.Maximum = listData.Count();
            foreach (var item in listData.OrderBy(x => x.BrgName))
            {
                PrgBar.Value++;
                object[] rowData = {item.BrgID, item.BrgName, item.JenisBrgName,
                            item.SubJenisBrgName, item.MerkName, item.ColorID, "Rp. "};
                BrgGrid.Rows.Add(rowData);
                if (item.ColorID.Trim() != "")
                {
                    var color = _colorBL.GetData(item.ColorID);
                    if (color != null)
                    {
                        BrgGrid.Rows[PrgBar.Value - 1].Cells["BrgColorCol"].Style.BackColor = _colorBL.GetFromRGB(color);
                        if (color.IsWhiteForeColor)
                            BrgGrid.Rows[PrgBar.Value - 1].Cells["BrgColorCol"].Style.ForeColor = Color.White;
                    }
                }
            }
            PrgBar.Value = 0;
        }

        private void LoadJenisBrgTreeView_Click(object sender, EventArgs e)
        {
            LoadJenisTreeView();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            var brgID = BrgGrid.CurrentRow.Cells["BrgKodeCol"].Value.ToString();
            if (PriceGrid.Rows.Count == 0) return;

            var listBrg = new List<BrgPriceModel>();
            foreach(DataGridViewRow item in PriceGrid.Rows)
            {
                var qty = Convert.ToInt16(item.Cells["PriceQtyCol"].Value);
                if (qty == 0) continue;

                var brgPrice = new BrgPriceModel
                {
                    BrgID = brgID,
                    Qty = qty,
                    Harga = Convert.ToDouble(item.Cells["PriceHargaCol"].Value),
                    Diskon = Convert.ToDouble(item.Cells["PriceDiskonCol"].Value)
                };
                listBrg.Add(brgPrice);
            }
            var result = _brgPriceBL.Save(brgID, listBrg);
        }

        private void BrgGrid_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            PriceGrid.Rows.Clear();
            var currentRow = BrgGrid.Rows[e.RowIndex];
            if (currentRow == null) return;

            var brgID = currentRow.Cells["BrgKodeCol"].Value;
            if (brgID == null) return;

            var brgPrice = _brgPriceBL.ListData(brgID.ToString());
            if (brgPrice == null) return;
            var stringPriceFlat = "";
            foreach(var item in brgPrice.OrderBy(x => x.Qty))
            {
                object[] rowData = { item.Qty, item.Harga, item.Diskon };
                PriceGrid.Rows.Add(rowData);

                var tempString = "";
                if (item.Qty != 1)
                    tempString= string.Format("x{0:n0} = ", item.Qty);

                tempString += string.Format("Rp.{0:n0}", item.Harga);

                if(item.Diskon != 0)
                    tempString += string.Format(" - {0:n0}", item.Diskon);

                stringPriceFlat += tempString;
                stringPriceFlat += " ֍֍֍ ";
            }
            currentRow.Cells["BrgPriceCol"].Value = stringPriceFlat;
        }

        private void CopyButton_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                BrgGrid.Rows.Clear();
                if (textBox1.Text == "") return;

                var listData = _brgBL.ListData(); 
                var keyword = textBox1.Text;
                var result =
                    from c in listData
                    where c.BrgName.ContainMultiWord(keyword)
                    select c;

                FillGrid(result);
            }
        }
    }
}
