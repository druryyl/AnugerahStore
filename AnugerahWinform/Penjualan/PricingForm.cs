using AnugerahBackend.StokBarang.BL;
using AnugerahBackend.StokBarang.Model;
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
        private IJenisBrgBL _jenisBrgBL;
        private ISubJenisBrgBL _subJenisBrgBL;
        private IMerkBL _merkBL;
        private IColorBL _colorBL;

        const string NO_ID = "x";
        const string NO_NAME = "Others";

        public PricingForm()
        {
            InitializeComponent();

            _brgBL = new BrgBL();

            LoadJenisTreeView();            

        }

        private void LoadJenisTreeView()
        {
            var listJenis = _brgBL.ListGrouping();
            if (listJenis == null) return;

            JenisTreeView.Nodes.Clear();
            foreach(var jenis in listJenis)
            {
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
                            merk.MerkName = NO_NAME;
                        }
                        subNode.Nodes.Add(merk.MerkID, merk.MerkName);
                        var merkNode = subNode.Nodes[merk.MerkID];
                        foreach(var color in merk.ListColor)
                        {
                            if (color.ColorID == "")
                            {
                                color.ColorID = NO_ID;
                                color.ColorName = NO_NAME;
                            }

                            merkNode.Nodes.Add(color.ColorID, color.ColorName);
                        }
                    }
                }
            }
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

            if (e.Node.Level == 1)
            {
                colorID = "";
                merkID = "";
                subID = "";

                jenisID = e.Node.Name;
            }

            var listBrg = _brgBL.ListData(jenisID, subID, merkID, colorID);

        }
    }
}
