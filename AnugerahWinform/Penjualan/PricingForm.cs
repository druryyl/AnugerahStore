using AnugerahBackend.StokBarang.BL;
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

            const string NO_ID = "x";
            const string NO_NAME = "Others";

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

    }
}
