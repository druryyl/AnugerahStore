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

namespace AnugerahWinform.StokBarang
{
    public partial class BarangListForm : Form
    {
        private IJenisBrgBL _jenisBrgBL;
        private ISubJenisBrgBL _subJenisBrgBL;
        private IMerkBL _merkBL;
        private IColorBL _colorBL;
        private IBrgBL _brgBL;

        private int panelColorTop;
        private int panelColorLeft;

        public BarangListForm()
        {
            InitializeComponent();
            _jenisBrgBL = new JenisBrgBL();
            _subJenisBrgBL = new SubJenisBrgBL();
            _merkBL = new MerkBL();
            _colorBL = new ColorBL();
            _brgBL = new BrgBL();

            LoadListSubJenisBrgTree();
            LoadJenisBrgCombo();
            LoadMerkCombo();
            LoadColorCombo();

            panelColorTop = ColorPanel.Top;
            panelColorLeft = ColorPanel.Left;
        }

        void LoadListSubJenisBrgTree()
        {
            //  list jenisBrg
            var listJenisBrg = _jenisBrgBL.ListData();
            if (listJenisBrg == null)
                return;
            //
            SubJenisBrgTree.Nodes.Clear();
            foreach (var item in listJenisBrg)
            {
                SubJenisBrgTree.Nodes.Add(item.JenisBrgID, item.JenisBrgName);
                var listSubJenisBrg = _subJenisBrgBL.ListData(item.JenisBrgID);
                if(listSubJenisBrg != null)
                {
                    foreach(var item2 in listSubJenisBrg)
                    {
                        SubJenisBrgTree.Nodes[item.JenisBrgID]
                            .Nodes.Add(item2.SubJenisBrgID, item2.SubJenisBrgName);
                    }
                }
            }
        }

        void LoadJenisBrgCombo()
        {
            //  kosongkan combobox
            JenisBrgComboBox.DataSource = null;
            JenisBrgComboBox.Items.Clear();

            //  ambil data
            var listJenisBrg = _jenisBrgBL.ListData();
            
            //  exit jika kosong
            if (listJenisBrg == null)
                return;

            listJenisBrg = listJenisBrg.OrderBy(x => x.JenisBrgName).ToList();
            JenisBrgComboBox.DataSource = listJenisBrg;
            JenisBrgComboBox.DisplayMember = "JenisBrgName";
            JenisBrgComboBox.ValueMember = "JenisBrgID";
        }

        void LoadSubJenisBrgCombo()
        {
            //  kosongkan combobox
            SubJenisBrgComboBox.DataSource = null;
            SubJenisBrgComboBox.Items.Clear();

            //  ambil data
            var jenisBrgID = JenisBrgComboBox.SelectedValue;
            if (jenisBrgID == null)
                return;

            var listSubJenisBrg = _subJenisBrgBL.ListData(jenisBrgID.ToString());

            //  exit jika kosong
            if (listSubJenisBrg == null)
                return;

            listSubJenisBrg = listSubJenisBrg.OrderBy(x => x.SubJenisBrgName).ToList();
            SubJenisBrgComboBox.DataSource = listSubJenisBrg;
            SubJenisBrgComboBox.DisplayMember = "SubJenisBrgName";
            SubJenisBrgComboBox.ValueMember = "SubJenisBrgID";
        }

        void LoadMerkCombo()
        {
            MerkComboBox.DataSource = null;
            MerkComboBox.Items.Clear();

            //  ambil data
            var listMerk = _merkBL.ListData();

            //  exit jika kosong
            if (listMerk == null)
                return;

            listMerk = listMerk.OrderBy(x => x.MerkName).ToList();
            MerkComboBox.DataSource = listMerk;
            MerkComboBox.DisplayMember = "MerkName";
            MerkComboBox.ValueMember = "MerkID";
        }

        void LoadColorCombo()
        {
            ColorComboBox.DataSource = null;
            ColorComboBox.Items.Clear();

            //  ambil data
            var listColor = _colorBL.ListData();

            //  exit jika kosong
            if (listColor == null)
                return;

            var listColorWithHue =
                from c in listColor
                select new
                {
                    c.ColorID,
                    c.RedValue,
                    c.GreenValue,
                    c.BlueValue,
                    Hue = Color.FromName(c.ColorID).GetHue()
                };
            listColorWithHue = listColorWithHue
                .OrderBy(x => x.RedValue)
                .ThenBy(x => x.GreenValue)
                .ThenBy(x => x.BlueValue)
                .ToList();
            ColorComboBox.DataSource = listColorWithHue;
            ColorComboBox.DisplayMember = "ColorID";
            ColorComboBox.ValueMember = "ColorID";
            ColorPanel.BackColor = Color.FromName(ColorComboBox.SelectedValue.ToString());
        }

        private void JenisBrgComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadSubJenisBrgCombo();
        }

        private void ColorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ColorPanel.BackColor = Color.FromName(ColorComboBox.SelectedValue.ToString());
        }

        private void ColorPanel_MouseHover(object sender, EventArgs e)
        {
            ColorPanel.Dock = DockStyle.Fill;
        }

        private void ColorPanel_MouseLeave(object sender, EventArgs e)
        {
            ColorPanel.Dock = DockStyle.None;
            ColorPanel.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            var brg = new BrgModel
            {
                BrgID = BrgIDText.Text,
                BrgName = BrgNameText.Text,
                Keterangan = KeteranganText.Text,
                ColorID = ColorComboBox.SelectedValue.ToString(),
                SubJenisBrgID = SubJenisBrgComboBox.SelectedValue.ToString(),
                MerkID = MerkComboBox.SelectedValue.ToString()
            };

            try
            {
                var result = _brgBL.Save(brg);
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
                return;
            }

            // kosongkan tampilan jika berhasil
            BrgIDText.Clear();
            BrgNameText.Clear();
            KeteranganText.Clear();
            LoadJenisBrgCombo();
            LoadColorCombo();
            LoadMerkCombo();
        }
    }
}
